//#signInWithGoogleA

document.addEventListener('click', e => {
    if (e.target.closest("#signInWithGoogleA")) {
        document.getElementById('signInWithGoogleForm').submit();
    }
});