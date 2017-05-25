using Android.App;
using Android.Widget;
using Android.OS;
using SALLab03;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var Helper = new SharedProject.MySharedCode();
            new AlertDialog.Builder(this)
                .SetMessage(Helper.GetFilePath("demo.dat"))
                .Show();

            Validate();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

        private async void Validate()
        {
            var serviceClient = new ServiceClient();
            var studentEmail = "XXX";
            var password = "XXX";
            var myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var result = await serviceClient.ValidateAsync(studentEmail, password, myDevice);
            var builder = new AlertDialog.Builder(this);
            var alert = builder.Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage($"{result.Status}\n{result.Fullname}\n{result.Token}");
            alert.SetButton("Ok", (s, ev) => { });
            alert.Show();
        }
    }
}

