using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab09
{
    [Activity(Label = "Lab09", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView tvName;
        TextView tvStatus;
        TextView tvToken;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Inicializar UI:
            tvName = FindViewById<TextView>(Resource.Id.tvName);
            tvStatus = FindViewById<TextView>(Resource.Id.tvStatus);
            tvToken = FindViewById<TextView>(Resource.Id.tvToken);

            //Validar:
            string email = "";
            string password = "";
            string device = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);

            Validate(email, password, device);
        }      

        public async void Validate(string Email, string Password, string Device)
        {
            var ServiceClient = new SALLab09.ServiceClient();
            var response = await ServiceClient.ValidateAsync(Email, Password, Device);

            tvName.Text = response.Fullname;
            tvStatus.Text = response.Status.ToString();
            tvToken.Text = response.Token;
        }
    }
}

