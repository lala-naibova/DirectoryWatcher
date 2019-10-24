# DirectoryWatcher
basic live directory watcher library in c#


### Overview
```csharp
    static void Main(string[] args)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        var watcher1 = new DirectoryWatcher(@"D:\smart-cart", TimeSpan.FromSeconds(4));
        var watcher2 = new DirectoryWatcher(desktopPath, TimeSpan.FromSeconds(5));

        watcher1.WhenNewFilesAppear += WriteToConsole;
        watcher2.WhenNewFilesAppear += WriteToConsole;

        watcher1.Start();
        watcher2.Start();

        Console.ReadKey();    
    }

    static void WriteToConsole(object sender, NewFilesInfoEventArgs ea)
    { 
        Console.WriteLine(string.Join("\n", ea.fileNames));
    }
```

Since implementation is event-driven, it's possible to watch (subscribe) as many as directories you want.
And they will work parallel.

Also, different time intervals can be set.

#### Exposed events
- `SomeFilesMissed`
- `NewFilesDetected`
