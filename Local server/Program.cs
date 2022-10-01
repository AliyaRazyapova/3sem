namespace Double
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8888/google/";

            HttpServer server = new HttpServer(url);

            server.Start();
        }
    }
}
