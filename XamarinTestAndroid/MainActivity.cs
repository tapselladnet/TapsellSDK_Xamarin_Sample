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
        private static Button Request_ad, Show_ad, Request_native_ad, Request_native_video_ad, Request_ad_video, Show_ad_video, request_banner_ad_video, Request_native_ad_video;
        private static TextView title, description, ctaButton, sponsored, title_video, description_video, ctaButton_video, sponsored_video;
        private static ImageView banner, logo, logo_video;
        private static ViewGroup adParent, adParent_video, banner_video;

        private static string adId = "";
        private static string zoneId = "";

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

            Tapsell.initialize(Application.Context, config, appKey);

            Tapsell.requestBannerAd(this, "59fd723c404ded000185a184", BannerType.BANNER_320x50, BannerGravity.BOTTOM, BannerGravity.CENTER);

            Tapsell.setRewardListener((string adId, string zoneId, bool rewarded, bool compeleted) =>
            {
                Console.WriteLine("Ad with id = " + adId + " finished " + (compeleted ? "successfully" : "unsuccessfully"));
                MainActivity.Show_ad.Enabled = false;
            });

            Request_ad = FindViewById<Button>(Resource.Id.request_ad);
            Show_ad = FindViewById<Button>(Resource.Id.show_ad);
            Request_native_ad = FindViewById<Button>(Resource.Id.request_native_ad);
            Request_native_video_ad = FindViewById<Button>(Resource.Id.request_native_video_ad);

            //+++++++++++++++++++++++++++++
            title = FindViewById<TextView>(Resource.Id.title);
            description = FindViewById<TextView>(Resource.Id.description);
            ctaButton = FindViewById<TextView>(Resource.Id.ctaButton);
            sponsored = FindViewById<TextView>(Resource.Id.sponsored);

            banner = FindViewById<ImageView>(Resource.Id.banner);
            logo = FindViewById<ImageView>(Resource.Id.logo);

            adParent = FindViewById<ViewGroup>(Resource.Id.ad_parent);
            //+++++++++++++++++++++++++++++

            //+++++++++++++++++++++++++++++
            title_video = FindViewById<TextView>(Resource.Id.title_video);
            description_video = FindViewById<TextView>(Resource.Id.description_video);
            ctaButton_video = FindViewById<TextView>(Resource.Id.ctaButton_video);
            sponsored_video = FindViewById<TextView>(Resource.Id.sponsored_video);

            banner_video = FindViewById<ViewGroup>(Resource.Id.banner_video);
            logo_video = FindViewById<ImageView>(Resource.Id.logo_video);

            adParent_video = FindViewById<ViewGroup>(Resource.Id.ad_parent_video);
            //+++++++++++++++++++++++++++++

            Request_ad.Click += delegate
            {
                String zoneId = "59fd721c404ded000185a005";
                Tapsell.requestAd(this, zoneId, false,
                    (string adId, string zone) =>
                    {
                        // onAdAvailable
                        Console.WriteLine("On Ad Available adId = " + adId);
                        MainActivity.adId = adId;
                        MainActivity.zoneId = zoneId;
                        MainActivity.Show_ad.Enabled = true;
                    },

                    (string errorMessage) =>
                    {
                        // onError
                        Console.WriteLine("On Error messeage = " + errorMessage);
                        MainActivity.Show_ad.Enabled = false;
                    },

                    (string adId, string zone) =>
                    {
                        // onExpiring
                        // this ad is expired, you must download a new ad for this zone
                        Console.WriteLine("Ad with id = " + adId + " is Expiring zoneId = " + zoneId);
                        MainActivity.Show_ad.Enabled = false;
                    },

                    () =>
                    {
                        // onNoAdAvailable
                        Console.WriteLine("On No Ad Available!");
                        MainActivity.Show_ad.Enabled = false;
                    },

                    () =>
                    {
                        // onNoNetwork
                        Console.WriteLine("On No Network!");
                        MainActivity.Show_ad.Enabled = false;
                    });
            };

            Request_native_ad.Click += delegate
            {
                String zoneId = "5a379ee4dc93ee0001c0fb13";
                Tapsell.requestNativeBannerAd(this, zoneId,
                    (string nativeAdId) =>
                    {
                        // onAdFilled
                        Console.WriteLine("onAdFilled adId = " + nativeAdId);
                        Tapsell.fillNativeBannerAd(this, nativeAdId, title, description, banner, logo, ctaButton, sponsored, adParent);
                    },

                    (string errorMessage) =>
                    {
                        // onError
                        Console.WriteLine("On Error messeage = " + errorMessage);
                    },

                    () =>
                    {
                        // onNoAdAvailable
                        Console.WriteLine("On No Ad Available!");
                    },

                    () =>
                    {
                        // onNoNetwork
                        Console.WriteLine("On No Network!");
                    });
            };

            Request_native_video_ad.Click += delegate
            {
                String zoneId = "5a379f01799e6f0001a460a2";
                Tapsell.requestNativeVideoAd(this, zoneId,
                    (string nativeAdId) =>
                    {
                        // onAdFilled
                        Console.WriteLine("onAdFilled adId = " + nativeAdId);
                        Tapsell.fillNativeVideoAd(this, nativeAdId, true, true, title_video, description_video, banner_video, logo_video, ctaButton_video, sponsored_video, adParent_video);
                    },

                    (string errorMessage) =>
                    {
                        // onError
                        Console.WriteLine("On Error messeage = " + errorMessage);
                    },

                    () =>
                    {
                        // onNoAdAvailable
                        Console.WriteLine("On No Ad Available!");
                    },

                    () =>
                    {
                        // onNoNetwork
                        Console.WriteLine("On No Network!");
                    });
            };

            Show_ad.Click += delegate
            {
                Console.WriteLine("show ad adId = " + adId);

                TapsellShowAdConfiguration showAdConfig = new TapsellShowAdConfiguration();
                showAdConfig.isBackDisabled = false;
                showAdConfig.isImmersiveMode = false;
                showAdConfig.rotationMode = TapsellShowAdConfiguration.ROTATION_LOCKED_LANDSCAPE;
                showAdConfig.doesShowDialog = true;



                if (adId != "")
                {
                    Tapsell.showAd(this, adId, showAdConfig,
                        (string adId) =>
                        {
                            //onOpened
                            Console.WriteLine("Ad with id = " + adId + " opened!");
                        },
                        (string adId) =>
                        {
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

