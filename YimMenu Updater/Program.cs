namespace YimUpdater
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainGUI());
        }
    }
}