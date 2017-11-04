using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using IR.Tapsell.Xamarin;

namespace XamarinTestAndroid
{
    [Activity(Label = "XamarinTestAndroid", MainLauncher = true, Icon = "@drawable/logo")]
    public class MainActivity : Activity
    {
        public static Button Request_ad, Show_ad, request_banner_ad;
        public static string adId = "";

        protected override void OnResume()
        {
            base.OnResume();
            Tapsell.requestBannerAd(this, "59fd723c404ded000185a184", BannerType.BANNER_320x50, BannerGravity.BOTTOM, BannerGravity.CENTER);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            String appKey = "ptmfmdshloahjqioqlhgrgtsnhdcodhelfagaiaqflpfsqroanappmohegqtklggemkmsr";

            TapsellConfiguration config = new TapsellConfiguration();
            config.isDebugMode = true;
            config.permissionHandlerMode = TapsellConfiguration.PERMISSION_HANDLER_AUTO;
            //config.maxAllowedBandwidthUsage = 50;
            //config.maxAllowedBandwidthUsagePercentage = 60;

            Tapsell.initialize(Application.Context,config, appKey);

            Tapsell.setRewardListener((string adId,string zoneId , bool rewarded ,bool compeleted)=>{
                Console.WriteLine("Ad with id = " + adId + " finished " + (compeleted ? "successfully" : "unsuccessfully"));
                MainActivity.Show_ad.Enabled = false;
            });

            Request_ad = FindViewById<Button>(Resource.Id.Request_ad);
            Show_ad = FindViewById<Button>(Resource.Id.Show_ad);

            Request_ad.Click += delegate
            {
                String zoneId = "59fd721c404ded000185a005";
                Tapsell.requestAd(this, zoneId, false,
                    (string adId , string zone) => {
                        // onAdAvailable
                        Console.WriteLine("On Ad Available adId = " + adId);
                        MainActivity.adId = adId;
                        MainActivity.Show_ad.Enabled = true;
                    },

                    (string errorMessage) => {
                        // onError
                        Console.WriteLine("On Error messeage = " + errorMessage);
                        MainActivity.Show_ad.Enabled = false;
                    },

                    (string adId, string zone) => {
                        // onExpiring
                        // this ad is expired, you must download a new ad for this zone
                        Console.WriteLine("Ad with id = " + adId + " is Expiring zoneId = " + zoneId);
                        MainActivity.Show_ad.Enabled = false;
                    },

                    () => {
                        // onNoAdAvailable
                        Console.WriteLine("On No Ad Available!");
                        MainActivity.Show_ad.Enabled = false;
                    },

                    () => {
                        // onNoNetwork
                        Console.WriteLine("On No Network!");
                        MainActivity.Show_ad.Enabled = false;
                    });
            };

            Show_ad.Click += delegate
            {
                Console.WriteLine("show ad adId = " + adId);

                if (adId != "")
                {
                    Tapsell.showAd(this, adId, false, false, RotationMode.ROTATION_LOCKED_LANDSCAPE, true,
                        (string adId) =>{
                            //onOpened
                            Console.WriteLine("Ad with id = " + adId + " opened!");
                        },
                        (string adId) => {
                            //onClosed
                            Console.WriteLine("Ad with id = " + adId + " closed!");
                        });
                }
            };

            //request_banner_ad.Click += delegate
            //{
            //    Console.WriteLine("show ad adId = " + adId);

            //    Tapsell.requestBannerAd(this, "59a27ab94684655433e74ef8", BannerType.BANNER_320x50, BannerGravity.BOTTOM, BannerGravity.CENTER);
            //};
        }
    }
}

