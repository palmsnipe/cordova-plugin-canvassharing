module.exports = {
    saveImageDataToLibrary: function(successCallback, failureCallback, canvas) {
        // successCallback required
        if (typeof successCallback != "function") {
            console.log("CanvasSharingPlugin Error: successCallback is not a function");
        }
        else if (typeof failureCallback != "function") {
            console.log("CanvasSharingPlugin Error: failureCallback is not a function");
        }
        else {
            var imageData = canvas.replace(/data:image\/png;base64,/,'');
            return cordova.exec(successCallback, failureCallback, "CanvasSharing","saveImageDataToLibrary",[imageData]);
        }
    },
    sharePicture: function(successCallback, failureCallback, path) {
        // successCallback required
        if (typeof successCallback != "function") {
            console.log("CanvasSharingPlugin Error: successCallback is not a function");
        }
        else if (typeof failureCallback != "function") {
            console.log("CanvasSharingPlugin Error: failureCallback is not a function");
        }
        else {
            return cordova.exec(successCallback, failureCallback, "CanvasSharing","sharePicture",[path]);
        }
    },
    appVersion: function(successCallback, failureCallback) {
        // successCallback required
        if (typeof successCallback != "function") {
            console.log("CanvasSharingPlugin Error: successCallback is not a function");
        }
        else if (typeof failureCallback != "function") {
            console.log("CanvasSharingPlugin Error: failureCallback is not a function");
        }
        else {
            return cordova.exec(successCallback, failureCallback, "CanvasSharing","appVersion",[]);
        }
    },
    sendEmail: function(title, description, picturepath, successCallback, failureCallback) {
        // successCallback required
        if (typeof successCallback != "function") {
            console.log("CanvasSharingPlugin Error: successCallback is not a function");
        }
        else if (typeof failureCallback != "function") {
            console.log("CanvasSharingPlugin Error: failureCallback is not a function");
        }
        else {
            return cordova.exec(successCallback, failureCallback, "CanvasSharing","sendEmail",[title, description, picturepath]);
        }
    },
    showAppBar: function(items, successCallback, failureCallback) {
        // successCallback required
        if (typeof successCallback != "function") {
            console.log("CanvasSharingPlugin Error: successCallback is not a function");
        }
        else if (typeof failureCallback != "function") {
            console.log("CanvasSharingPlugin Error: failureCallback is not a function");
        }
        else {
            return cordova.exec(successCallback, failureCallback, "CanvasSharing","showAppBar", items);
        }
    },
    hideAppBar: function(successCallback, failureCallback) {
        // successCallback required
        if (typeof successCallback != "function") {
            console.log("CanvasSharingPlugin Error: successCallback is not a function");
        }
        else if (typeof failureCallback != "function") {
            console.log("CanvasSharingPlugin Error: failureCallback is not a function");
        }
        else {
            return cordova.exec(successCallback, failureCallback, "CanvasSharing","hideAppBar", []);
        }
    }
};
  
