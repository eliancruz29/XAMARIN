namespace MyTunes.Shared
{
    public interface IStreamLoader
    {
        System.IO.Stream GetStreamForFilename(string filename);
    }
}
