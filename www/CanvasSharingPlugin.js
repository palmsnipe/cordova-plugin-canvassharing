

  module.exports = {
    
    saveImageDataToLibrary:function(successCallback, failureCallback, canvas) {
        // successCallback required
        if (typeof successCallback != "function") {
            console.log("CanvasSharingPlugin Error: successCallback is not a function");
        }
        else if (typeof failureCallback != "function") {
            console.log("CanvasSharingPlugin Error: failureCallback is not a function");
        }
        else {
            var imageData = canvas;
            // var canvas = (typeof canvasId === "string") ? document.getElementById(canvasId) : canvasId;
            // var imageData = canvas.toDataURL().replace(/data:image\/png;base64,/,'');
            return cordova.exec(successCallback, failureCallback, "CanvasSharingPlugin","saveImageDataToLibrary",[imageData]);
        }
    }
    
    // saveImageDataToLibrary:function(successCallback, failureCallback, canvasId) {
    //     // successCallback required
    //     if (typeof successCallback != "function") {
    //         console.log("Canvas2ImagePlugin Error: successCallback is not a function");
    //     }
    //     else if (typeof failureCallback != "function") {
    //         console.log("Canvas2ImagePlugin Error: failureCallback is not a function");
    //     }
    //     else {
    //         var canvas = (typeof canvasId === "string") ? document.getElementById(canvasId) : canvasId;
    //         var imageData = canvas.toDataURL().replace(/data:image\/png;base64,/,'');
    //         return cordova.exec(successCallback, failureCallback, "CanvasSharingPlugin","saveImageDataToLibrary",[imageData]);
    //     }
    // }
  };
  
