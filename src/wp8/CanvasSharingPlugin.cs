﻿using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using System.Text;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using Microsoft.Phone.Tasks;

public class CanvasSharingPlugin : BaseCommand
{
    public CanvasSharingPlugin()
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
            
            DispatchCommandResult(new PluginResult(PluginResult.Status.OK, picture.Name));
        }
        catch (Exception ex)
        {
            DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, ex.Message));
        }
    }
    
}
