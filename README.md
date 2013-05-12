# scriptcs

## Why should you care?
Write C# apps with a text editor, nuget and the power of Rosyln!

**Note**: *Roslyn is a pre-release CTP and currently an unsupported technology. As such there may be changes in Roslyn itself that could impact this project. Please bear that in mind when using scriptcs*

* More on why I developed this [here] (http://codebetter.com/glennblock/2013/02/28/scriptcs-living-on-the-edge-in-c-without-a-project-on-the-wings-of-roslyn-and-nuget/)
* Check out our goals and rodmap [here] (https://github.com/scriptcs/scriptcs/wiki/Project-goals-and-roadmap)

## Pre-reqs
* Install scriptcs from Chocolatey `cinst scriptcs` or
* Build the project from the source and put `scriptcs.exe` in your path.

## Quick start
* Open a cmd prompt as admin
* run `scriptcs -install scriptcs.webapi`
* create a `server.csx` with your favorite editor. Paste the text below into the file and save (notice no namespaces & no top level class).

```csharp
public class TestController : ApiController {
  public string Get() {
    return "Hello world!";
  }
}

var webApi = Require<WebApi>();
var server = webApi.CreateServer("http://localhost:8080");
server.OpenAsync().Wait();

Console.WriteLine("Listening...");
Console.ReadKey();
server.CloseAsync().Wait();
```
* run `scriptcs server.csx`

This will launch a web api host with a sample controller, which you can access from the browser.

## How it works
scriptcs relies on Roslyn for loading loose C# script files. It will automatically discover nuget packages local to the app and load the binaries.

## Docs
* [Referencing other scripts from your script](https://github.com/scriptcs/scriptcs/wiki/Referencing-scripts)
* [Debugging overview & How To](https://github.com/scriptcs/scriptcs/blob/dev/docs/DEBUGGING.md)

## Contributing
* Read our [Contribution Guidelines](https://github.com/scriptcs/scriptcs/blob/master/CONTRIBUTING.md). 
* List of all [contributors to date](https://github.com/scriptcs/scriptcs/wiki/Contributors). Thanks!

## Credits
* Special thanks to [@filip_woj](http://twitter.com/filip_woj) for being the inspiration behind this with his Roslyn Web API posts.
* Thanks to the Roslyn team who helped point me in the right direction.

## Coordinators
* Glenn Block ([@gblock](https://twitter.com/gblock))
* Justin Rusbatch ([@jrusbatch](https://twitter.com/jrusbatch))
* Filip Wojcieszyn ([@filip_woj](https://twitter.com/filip_woj))

## Community
Want to chat? In addition to Twitter, you can find us on [Google Groups](https://groups.google.com/forum/?fromgroups#!forum/scriptcs) and [JabbR](https://jabbr.net/#/rooms/scriptcs)!

## License 
[Apache 2 License](https://github.com/scriptcs/scriptcs/blob/master/LICENSE.md)

