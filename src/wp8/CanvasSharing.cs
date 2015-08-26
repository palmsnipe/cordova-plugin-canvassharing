using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;
using System;
using System.IO;
using System.Text;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using Microsoft.Phone.Tasks;
//  using System.Xml;
//  using System.Xml.Linq;

namespace Cordova.Extension.Commands
{

    public class CanvasSharing : BaseCommand
    {
        public CanvasSharing()
        {
        }
    
        public void saveImageDataToLibrary(string jsonArgs)
        {
            try
            {
                var options = JsonHelper.Deserialize<string[]>(jsonArgs);
    
                string imageData = options[0];
                byte[] imageBytes = Convert.FromBase64String(imageData);
    
                using (var imageStream = new MemoryStream(imageBytes))
                {
                    imageStream.Seek(0, SeekOrigin.Begin);
    
                    string fileName = String.Format("kortti_{0:yyyyMMdd_HHmmss}", DateTime.Now);
                    var library = new MediaLibrary();
                    var picture = library.SavePicture(fileName, imageStream);
    
                    if (picture.Name.Contains(fileName))
                    {
                        DispatchCommandResult(new PluginResult(PluginResult.Status.OK, picture.GetPath()));
                    }
                    else
                    {
                        DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, 
                            "Failed to save image: " + picture.Name));
                    }
                }
            }
            catch (Exception ex)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, ex.Message));
            }
        }
    
        public void sharePicture(string jsonArgs)
        {
            try
            {
                var options = JsonHelper.Deserialize<string[]>(jsonArgs);
    
                string path = options[0];
                Microsoft.Phone.Tasks.ShareMediaTask smt = new ShareMediaTask();
                smt.FilePath = path; 
                smt.Show();
                
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK, path));
            }
            catch (Exception ex)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, ex.Message));
            }
        }
    
        public void appVersion(string jsonArgs)
        {
            DispatchCommandResult(new PluginResult(PluginResult.Status.OK, "toto"));
            //  try
            //  {
            //      //  var options = JsonHelper.Deserialize<string[]>(jsonArgs);
            //      DispatchCommandResult(new PluginResult(PluginResult.Status.OK, "toto"));
            //      //string version = XDocument.Load("WMAppManifest.xml").Root.Element("App").Attribute("Version").Value;
    
            //      //if (String.IsNullOrEmpty(version))
            //      //{
            //      //    DispatchCommandResult(new PluginResult(PluginResult.Status.OK, version));
            //      //}
            //      //else
            //      //{
            //      //    DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR,
            //      //        "Unable to get the version number"));
            //      //}
            //  }
            //  catch (Exception ex)
            //  {
            //      DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, ex.Message));
            //  }
        }
        
    }

}