// Toastr notification
window.ShowToastr = function (type, message) {
    if (type === "success") {
        toastr.success(message);
    }
    else if (type === "error") {
        toastr.error(message);
    }
}

// Toastr confirm delete - trả về true/false qua DotNet
window.ShowDeleteConfirm = function (message) {
    return confirm(message);
}