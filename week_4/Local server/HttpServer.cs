using System.Net;
using System.Text;

namespace Double
{
    public class HttpServer
    {
        private readonly string _url;

        private readonly HttpListener listener;
     
        public HttpServer(string url)
        {
            _url = url;
            listener = new HttpListener();
            listener.Prefixes.Add(_url);    
        }

        public void Start()
        {
            Console.WriteLine("Запуск сервера...");
            listener.Start();
            Console.WriteLine("Сервер запущен");
            Listener();
        }

        public void Stop()
        {
            Console.WriteLine("Остановка сервера...");
            listener.Stop();
            Console.WriteLine("Сервер остановлен");
        }

        private void Listener()
        {
            while(true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                byte[] buffer = new byte[0];
                try
                {
                    string responseStr = File.ReadAllText(@"C:/Users/Admin/Desktop/rep/github/Razyapova_Aliya_11-106/Local server/Google.html");
                    buffer = Encoding.UTF8.GetBytes(responseStr);
                }
                catch (Exception exc)
                {
                    Stop();
                    Console.WriteLine();
                    Console.WriteLine("Для перезагрузки: Restart");
                    Console.WriteLine("Для выхода: Stop");
                    Console.WriteLine();

                    while (true)
                    {
                        string inp = Console.ReadLine();
                        if (inp == "Restart")
                            Start();
                        else if (inp == "Stop")
                            break;
                    }
                }
                response.ContentLength64 = buffer.Length;
                Stream outp = response.OutputStream;
                outp.Write(buffer, 0, buffer.Length);
                outp.Close();
            }
        }
    }
}