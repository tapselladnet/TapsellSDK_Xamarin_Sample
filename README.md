<div dir="rtl">
<a href="#part1">تنظیمات اولیه پروژه Xamarin در Visual Studio</a></br>
  <a href="#part2">پیاده‌سازی تبلیغات ویدئویی (Interstitial/Rewarded Video) و بنری تمام صفحه (Interstitial Banner) در پروژه Xamarin</a></br>
  <a href="#part3">پیاده‌سازی تبلیغات ویدئویی هم‌نما (Native Video) در پروژه Xamarin</a></br>
  <a href="#part4">پیاده‌سازی تبلیغات بنری هم‌نما (Native Banner) در پروژه Xamarin</a></br>
  <a href="#part5">پیاده‌سازی تبلیغات بنری استاندارد در پروژه Xamarin</a></br>
  <a href="#part6">موارد پیشرفته‌تر در SDK تپسل (Xamarin)</a></br>
</div>
</br></br>

<div dir="rtl" id="part1">
  <h1>تنظیمات اولیه پروژه Xamarin در Visual Studio</h1>
  جهت راه اندازی تبلیغات تپسل در اپلیکیشن شما، ابتدا باید مراحل زیر را در پروژه خود انجام دهید.
<h3><strong>گام ۱: دریافت </strong><strong>SDK</strong><strong> تپسل</strong></h3>
ابتدا فایل dll مربوط به SDK تپسل را از آدرس زیر دانلود کنید.
<p style="text-align: center;"><a href="https://storage.backtory.com/tapsell-server/sdk/TapsellXamarinSdk.dll"><button>دریافت فایل</button></a></p>
&nbsp;
<h3><strong>گام ۲: افزودن </strong><strong>SDK</strong><strong> تپسل به پروژه شما</strong></h3>
فایل دانلود شده را در پوشه در فولدر اصلی پروژه خود کپی کنید و سپس در Visual studio از پنجره Solution explorer با راست کلیک بر روی References موجود در پروژه اندروید تان گزینه Add Reference را انتخاب و از پنجره باز شده Browse را انتخاب و فایل DLL دانلود شده را به پروژه معرفی کنید. سپس پروژه را Clean و دوباره Rebuild کنید.
<h3><strong>گام ۳: آپدیت فایل Manifest</strong></h3>
مجوز دسترسی های (Permission) زیر را به پروژه اضافه کنید:
<pre dir="ltr">&lt;<span style="color: #003366;">uses-permission</span> <span style="color: #800080;">android<span style="color: #00ccff;">:name=</span></span><span style="color: #008000;">"android.permission.ACCESS_NETWORK_STATE"</span> /&gt;
&lt;<span style="color: #003366;">uses-permission</span> <span style="color: #800080;">android</span><span style="color: #00ccff;">:name=</span><span style="color: #008000;">"android.permission.INTERNET"</span> /&gt;
&lt;<span style="color: #003366;">uses-permission</span> <span style="color: #800080;">android</span><span style="color: #00ccff;">:name=</span><span style="color: #008000;">"android.permission.READ_PHONE_STATE"</span> /&gt;<span style="color: #999999;">&lt;!--optional--&gt;</span>
&lt;<span style="color: #003366;">uses-permission</span> <span style="color: #800080;">android</span><span style="color: #00ccff;">:name=</span><span style="color: #008000;">"android.permission.VIBRATE"</span> /&gt;<span style="color: #999999;">&lt;!--optional--&gt;</span>
&lt;<span style="color: #003366;">uses-permission</span> <span style="color: #800080;">android</span><span style="color: #00ccff;">:name=</span><span style="color: #008000;">"android.permission.ACCESS_COARSE_LOCATION"</span>/&gt;<span style="color: #999999;">&lt;!--optional--&gt;</span></pre>
همانطور که در کد فوق مشخص شده‌است، دسترسی‌‌های موقعیت (<code>ACCESS_COARSE_LOCATION</code>) و لرزش دستگاه (<code>VIBRATE</code>) اختیاری هستند اما درصورتیکه این دسترسی‌ها را نیز در برنامه خود قرار دهید، تبلیغات نشان‌داده‌شده به کاربر از کیفیت بالاتری برخوردار خواهد بود.

در بخش application از فایل منیفست برنامه، activity زیر را اضافه کنید.
<pre dir="ltr">&lt;<span style="color: #000080;">manifest</span>&gt;
…
&lt;<span style="color: #000080;">application</span>&gt;
…
&lt;<span style="color: #000080;">activity</span> <span style="color: #800080;">android</span><span style="color: #00ccff;">:name=</span><span style="color: #008000;">"ir.tapsell.sdk.TapsellAdActivity"</span> 
          <span style="color: #800080;">android</span><span style="color: #00ccff;">:configChanges=</span><span style="color: #008000;">"keyboardHidden|orientation|screenSize"</span> &gt;
&lt;<span style="color: #000080;">/activity</span>&gt;
&lt;<span style="color: #000080;">/application</span>&gt;
…
&lt;<span style="color: #000080;">/manifest</span>&gt;</pre>
&nbsp;
<h3>گام ۴: دریافت کلید تپسل</h3>
وارد پنل مدیریت تپسل شده و با تعریف یک اپلیکیشن جدید با عنوان پکیج اپلیکیشن اندرویدی خود، یک کلید تپسل دریافت کنید.
<p style="text-align: center;"><a href="https://dashboard.tapsell.ir"><button>ورود به داشبورد تپسل</button></a></p>
&nbsp;
<h3>گام ۵: شروع کار با SDK تپسل</h3>
ابتدا برای دسترسی به کدهای تپسل از تکه کد زیر استفاده کنید
<pre dir="ltr">using IR.Tapsell.Xamarin;</pre>
سپس تابع زیر را در یکی از اسکریپت های برنامه ی خود که در ابتدای برنامه اجرا می شود فراخوانی کنید.
<pre dir="ltr">Tapsell.initialize(Application.Context, appKey);</pre>
ورودی appKey کلید تپسلی است که در گام قبل از پنل تپسل دریافت کردید.
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific, sans-serif, Tahoma, Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 1007px; top: 1820px;">
<div id="s3gt_translate_tooltip_mini_logo" class="s3gt_translate_tooltip_mini" title="Translate selected text"></div>
<div id="s3gt_translate_tooltip_mini_sound" class="s3gt_translate_tooltip_mini" title="Play"></div>
<div id="s3gt_translate_tooltip_mini_copy" class="s3gt_translate_tooltip_mini" title="Copy text to Clipboard"></div>
<style type="text/css" media="print">#s3gt_translate_tooltip_mini { display: none !important; }</style></div>
  </div>
  
  <div dir="rtl" id="part2">
  <h1>پیاده‌سازی تبلیغات ویدئویی (Interstitial/Rewarded Video) و بنری تمام صفحه (Interstitial Banner) در پروژه Xamarin</h1>
  <h3>گام 1: دریافت تبلیغ</h3>
نمایش یک تبلیغ ویدئویی در اپلیکیشن به دو صورت ممکن است صورت پذیرد. یک روش، نمایش تبلیغ بصورت stream می باشد. در این حالت، همزمان که کاربر درحال مشاهده بخشی از تبلیغ است، ادامه آن از اینترنت لود می گردد. ممکن است به دلیل کندی سرعت اینترنت، در این حالت کاربر با مکث های متعددی در هنگام دریافت و مشاهده تبلیغ مواجه شود. برای اینکه کاربر در هنگام نمایش تبلیغ منتظر نماند و تجربه کاربر در استفاده از اپلیکیشن بهبود یابد،روش دیگری نیز در SDK تپسل تعبیه شده است که در آن ابتدا فایل ویدئوی تبلیغاتی بطور کامل بارگذاری شده و سپس تبلیغ نمایش داده می شود.
همچنین در تپسل، تبلیغ می تواند در ناحیه‌های مختلفی از برنامه شما (مانند فروشگاه، انتهای هر مرحله، ابتدای مرحله جهت دریافت امتیاز دوبرابر، دریافت بنزین/لایف و ...) پخش شود. در تپسل به این ناحیه‌ها zone گفته می شود. ناحیه‌های هر اپلیکیشن در پنل تپسل تعریف می شوند.

با اجرای تابع زیر، می توانید یک درخواست تبلیغ به تپسل ارسال کرده و یک تبلیغ دریافت نمایید:
<pre dir="ltr">Tapsell.requestAd(context, zoneId, isCached, Action&lt;string, string&gt; onAdAvailable,
                        Action&lt;string&gt; onError, Action&lt;string, string&gt; onExpiring,
                        Action&lt;&gt; onNoAdAvailable, Action&lt;&gt; onNoNetwork);</pre>
هر درخواست شامل یک ورودی <code>zoneId</code> است که باید آن را از <a href="https://dashboard.tapsell.ir/">داشبورد تپسل</a> در صفحه اپلیکیشن خود دریافت کنید. ورودی <code>isCached</code> یک متغیر <code>bool</code> (با مقدار True/False) می باشد که نشان می دهد که آیا تبلیغ باید ابتدا دانلود شده و سپس به کاربر نشان داده شود یا خیر.
<p dir="ltr">[ht_message mstyle="danger" title="کش کردن ویدئو" " show_icon="" id="" class="" style="" ]تنها در ناحیه‌هایی که کاربر با احتمال زیادی پس از باز کردن اپلیکیشن تبلیغ آن را مشاهده می‌کند، از تبلیغ Cached استفاده کنید. جهت توضیحات بیشتر درباره روش انتخاب متد دریافت مناسب، <a href="https://answers.tapsell.ir/?ht_kb=cached-vs-streamed">اینجا</a> را مطالعه کنید.[/ht_message]</p>
در اکشن <code>onAdAvailable</code> شناسه یک تبلیغ به شما برگردانده می شود که می بایست جهت نمایش تبلیغ آن را ذخیره نمایید. جهت توضیحات بیشتر به قطعه کد پیاده سازی اکشن که در ادامه آمده است توجه نمایید.
<pre dir="ltr">Tapsell.requestAd(this, zoneId, false,
 (string adId , string zone) =&gt; {
      // onAdAvailable
       Console.WriteLine("On Ad Available adId = " + adId);
 },

 (string errorMessage) =&gt; {
       // onError
       Console.WriteLine("On Error messeage = " + errorMessage);
 },

 (string adId, string zone) =&gt; {
      // onExpiring
      // this ad is expired, you must download a new ad for this zone
      Console.WriteLine("Ad with id = " + adId + " is Expiring zoneId = " + zoneId);
 },

 () =&gt; {
      // onNoAdAvailable
      Console.WriteLine("On No Ad Available!");
 },

 () =&gt; {
      // onNoNetwork
      Console.WriteLine("On No Network!");
 });
</pre>
توضیحات اکشن های مختلف و شرایط اجرا شدن آن ها در جدول ۱ آمده است.

&nbsp;
<table style="text-align: center; border-collapse: collapse;" width="100%"><caption>جدول ۱ اکشن های دریافت نتیجه درخواست تبلیغ</caption>
<tbody>
<tr style="border-bottom: 1px solid #ddd;">
<th width="40%">تابع</th>
<th width="60%">توضیحات (زمان اجرا)</th>
</tr>
<tr style="background-color: #fefefe;">
<td dir="ltr" width="40%">onError(string)</td>
<td>هنگامی که هر نوع خطایی در پروسه‌ی دریافت تبلیغ بوجود بیاید</td>
</tr>
<tr style="background-color: #f2f2f2;">
<td dir="ltr" width="40%">onAdAvailable(string , string)</td>
<td width="60%">زمانی که تبلیغ دریافت شده و آماده‌ی نمایش باشد.</td>
</tr>
<tr style="background-color: #fefefe;">
<td dir="ltr" width="40%">onNoAdAvailable ()</td>
<td width="60%">در صورتی که تبلیغی برای نمایش وجود نداشته باشد.</td>
</tr>
<tr style="background-color: #f2f2f2;">
<td dir="ltr" width="40%">onNoNetwork ()</td>
<td width="60%">زمانی که دسترسی به شبکه موجود نباشد.</td>
</tr>
<tr style="background-color: #fefefe;">
<td dir="ltr" width="40%">onExpiring(string , string)</td>
<td width="60%">زمانی که تبلیغ منقضی شود. هر تبلیغ مدت زمان مشخصی معتبر است و در صورتی که تا قبل از آن نمایش داده نشود منقضی شده و دیگر قابل نمایش نخواهد بود.</td>
</tr>
</tbody>
</table>
&nbsp;
<h3>گام 2: نمایش تبلیغ</h3>
برای نمایش تبلیغ از تابع showAd استفاده کنید (این تابع حداکثر یک بار برای هر تبلیغ قابل اجراست) :
<pre dir="ltr"><span style="color: #000080;">Tapsell</span>.showAd(context , adId , TapsellShowAdConfiguration config ,
                Action&lt;string&gt; onOpened , Action&lt;string&gt; onClosed);
</pre>
ورودی <code>adId</code> ، همان مقداریست که در گام قبل و در اکشن <code>onAdAvailable</code> به شما داده شده‌است. مقادیر <code>onOpened</code> و <code>onClosed</code> دو اکشن مربوط به باز و بسته شدن تبلیغ هستند که میتوانید مانند اکشن های گام 4 از آنها استفاده نمایید. ورودی TapsellShowAdConfiguration تنظیمات نمایش تبلیغ می باشد که توضیح پارامتر های آن در جدول ۲ آورده شده است.

&nbsp;
<table style="text-align: center; border-collapse: collapse;" width="100%" cellpadding="6"><caption>جدول ۲ پارامتر های کلاس TapsellShowAdConfiguration </caption>
<tbody>
<tr style="border-bottom: 1px solid #ddd;">
<th width="40%">متغیر (نوع)</th>
<th width="60%">توضیحات</th>
</tr>
<tr style="background-color: #fefefe;">
<td dir="ltr" width="40%">isBackDisabled (bool)</td>
<td width="60%">
<div align="right">در هنگام پخش تبلیغ دکمه‌ی بازگشت گوشی فعال باشد یا خیر</div></td>
</tr>
<tr style="background-color: #f2f2f2;">
<td dir="ltr" width="40%">isImmmersiveMode (bool)</td>
<td width="60%">
<div align="right">فعال‌سازی حالت Immersive در هنگام پخش تبلیغ (فقط در اندروید)</div></td>
</tr>
<tr style="background-color: #fefefe;">
<td dir="ltr" width="40%">rotationMode (int)</td>
<td width="60%">
<div align="right">تعیین وضعیت گوشی در هنگام پخش تبلیغ به یکی از سه حالت:</div>
<div align="left">ROTATION_LOCKED_PORTRAIT
ROTATION_LOCKED_LANDSCAPE
ROTATION_UNLOCKED
ROTATION_LOCKED_REVERSED_PORTRAIT
ROTATION_LOCKED_REVERSED_LANDSCAPE</div></td>
</tr>
<tr style="background-color: #f2f2f2;">
<td dir="ltr" width="40%">doesShowDialog (bool)</td>
<td width="60%">
<div align="right">نمایش دیالوگ اخطار در هنگام بازگشت از تبلیغات جایزه‌دار</div></td>
</tr>
</tbody>
</table>
یک نمونه پیاده‌سازی درخواست تبلیغ در ادامه آمده است.
<pre dir="ltr">TapsellShowAdConfiguration showAdConfig = new TapsellShowAdConfiguration();
showAdConfig.isBackDisabled = false;
showAdConfig.isImmersiveMode = false;
showAdConfig.rotationMode = TapsellShowAdConfiguration.ROTATION_LOCKED_LANDSCAPE;
showAdConfig.doesShowDialog = true;

Tapsell.ShowAd(this, adId, showAdConfig,
       (string adId) =&gt;{
           //onOpened
           Console.WriteLine("Ad with id = " + adId + " opened!");
       },
       (string adId) =&gt; {
           //onClosed
           Console.WriteLine("Ad with id = " + adId + " closed!");
       });
</pre>
&nbsp;
<h3>گام 3: دریافت نتیجه نمایش تبلیغ</h3>
در صورتیکه در اپلیکیشن خود از تبلیغات جایزه‌دار استفاده می‌کنید، جهت دریافت نتیجه نمایش تبلیغ‌ها، باید یک اکشن مطابق زیر به SDK تپسل بدهید.
<pre dir="ltr">Tapsell.setRewardListener((string adId,string zoneId , bool rewarded ,bool compeleted)=&gt;{
      Console.WriteLine("Ad with id = " + adId + " finished " + (compeleted ? "successfully" : "unsuccessfully"));
      //Your Code
});</pre>
پس از نمایش تبلیغ، اکشن onAdShowFinished اجرا می‌شود و نتیجه نمایش تبلیغ بازگردانده می‌شود. درصورتیکه تبلیغ نمایش داده شده جایزه‌دار باشد، متغیر rewarded دارای مقدار true خواهد بود. همچنین درصورتیکه تبلیغ تا انتها دیده شود، متغیر completed دارای مقدار true خواهد بود. در صورتی که تبلیغ جایزه‌دار باشد و مشاهده ویدئو تا انتها انجام شده باشد، باید جایزه درون برنامه (سکه، اعتبار، بنزین یا ...) را به کاربر بدهید.
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific,sans-serif,Tahoma,Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 1011px; top: 68px; opacity: 0.7;"></div>
  </div>
  
  <div dir="rtl" id="part3">
  <h1>پیاده‌سازی تبلیغات ویدئویی هم‌نما (Native Video) در پروژه Xamarin</h1>
  <h3><strong>گام 1: ساختن Layout نمایش تبلیغ هم‌نما</strong></h3>
در تبلیغات هم‌نما، شما قادر هستید ویژگی‌های ظاهری هر یک از اجزای تبلیغ (اندازه، محل قرارگیری، رنگ فونت و...) را بصورتی که هماهنگ با محتوای اپلیکیشن شما باشد تعیین کنید. لذا باید Layout هم‌نما اپلیکیشن خود را که مدنظرتان است ایجاد کرده و به SDK تپسل بدهید.

هرقالب محتوای که برای تبلیغات هم‌نما ویدئویی ارائه می‌شود میبایست دارای حداقل سه آیتم عنوان تبلیغ، نشانگر تبلیغ بودن و ویدئو را دارا باشد. SDK تپسل جهت نمایش ویدئو در تبلیغات هم‌نما، از پلیر مخصوص خود استفاده می‌کند که برای نسخه‌های مختلف اندروید و استفاده در صفحات قابل اسکرول بهینه‌سازی شده است. لذا برای نمایش ویدئو کافیست یک layout در فایل <code>xml</code> خود اضافه کنید که در اصل در بر گیرنده پلیر ویدئو خواهد بود. شکل کلی قالب محتوایی تبلیغات هم‌نما ویدئویی بصورت زیر می‌باشد:
<pre style="direction: ltr; margin: 0; line-height: 125%;"><span style="color: #000080;">&lt;RelativeLayout</span> 
    <span style="color: #800080;">android</span>:layout_width=<span style="color: #008000;">"match_parent"</span>
    <span style="color: #800080;">android</span>:layout_height=<span style="color: #008000;">"wrap_content"</span><span style="color: #000080;">&gt;</span>

    <span style="color: #000080;">&lt;ImageView</span>
        <span style="color: #800080;">android</span>:id=<span style="color: #008000;">"@id/tapsell_nativead_logo"</span>
        ... <span style="color: #000080;">/&gt;</span>

    <span style="color: #000080;">&lt;TextView</span>
        <span style="color: #800080;">android</span>:id=<span style="color: #008000;">"@id/tapsell_nativead_title"</span>
        ... <span style="color: #000080;">/&gt;</span>

    <span style="color: #000080;">&lt;TextView</span>
        <span style="color: #800080;">android</span>:id=<span style="color: #008000;">"@id/tapsell_nativead_sponsored"</span>
        ... <span style="color: #000080;">/&gt;</span>

    <span style="color: #000080;">&lt;TextView</span>
        <span style="color: #800080;">android</span>:id=<span style="color: #008000;">"@id/tapsell_nativead_description"</span>
        ... <span style="color: #000080;">/&gt;</span>

    <span style="color: #000080;">&lt;FrameLayout</span>
        <span style="color: #800080;">android</span>:id=<span style="color: #008000;">"@id/tapsell_nativead_video"</span>
        ... <span style="color: #000080;">/&gt;</span>

    <span style="color: #000080;">&lt;Button</span>
        <span style="color: #800080;">android</span>:id=<span style="color: #008000;">"@id/tapsell_nativead_cta"</span>
        ... <span style="color: #000080;">/&gt;</span>

<span style="color: #000080;">&lt;/RelativeLayout&gt;
</span></pre>
<h3><strong>گام 2: درخواست تبلیغ ویدئویی هم‌نما</strong></h3>
در تپسل، تبلیغ می تواند در ناحیه‌های مختلفی از برنامه شما (مانند منو اصلی، بین پست‌ها و ...) پخش شود. در تپسل به این ناحیه‌ها zone گفته می شود. ناحیه‌های هر اپلیکیشن در داشبورد تپسل تعریف می شوند.

با اجرای تابع زیر، می‌توانید یک درخواست تبلیغ به تپسل ارسال کرده و یک تبلیغ دریافت نمایید:
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell.requestNativeVideoAd(Context context, string zoneId, 
   Action&lt;string&gt; onAdFilled, Action&lt;string&gt; onError, 
   Action onNoAdAvailable, Action onNoNetwork)</pre>
هر درخواست شامل یک ورودی شناسه تبلیغ‌گاه (<code>zoneId)</code> است که نشانگر محل نمایش تبلیغ در اپلیکیشن شماست. تبلیغ‌گاه مرتبط با این شناسه در داشبورد تپسل باید از نوع بنری هم‌نما باشد. نتیجه درخواست بصورت اکشن به برنامه شما بازگردانده می‌شود. توضیحات اکشن های موجود در جدول زیر آمده است:
<table width="100%"><caption> اکشن های دریافت نتیجه درخواست تبلیغ</caption>
<tbody>
<tr>
<th width="40%">تابع</th>
<th width="60%">توضیحات (زمان اجرا)</th>
</tr>
<tr>
<td width="40%">onError(string)</td>
<td>هنگامی که هر نوع خطایی در پروسه‌ی دریافت تبلیغ بوجود بیاید</td>
</tr>
<tr>
<td width="40%">onAdFilled(string)</td>
<td width="60%">زمانی که تبلیغ دریافت شده و آماده‌ی نمایش باشد.</td>
</tr>
<tr>
<td width="40%">onNoAdAvailable()</td>
<td width="60%">در صورتی که تبلیغی برای نمایش وجود نداشته باشد.</td>
</tr>
<tr>
<td width="40%">onNoNetwork()</td>
<td width="60%">زمانی که دسترسی به شبکه موجود نباشد.</td>
</tr>
</tbody>
</table>
در ادامه یه نمونه پیاده سازی شده این تابع را مشاهده خواهید کرد:
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell.requestNativeVideoAd(this,"5a379f01799e6f0001a460a2",
        (string nativeAdId) =&gt; {
        // onAdFilled
        Console.WriteLine("onAdFilled adId = " + nativeAdId);
      },

         (string errorMessage) =&gt; {
         // onError
         Console.WriteLine("On Error messeage = " + errorMessage);
      },

         () =&gt; {
         // onNoAdAvailable
         Console.WriteLine("On No Ad Available!");
      },

          () =&gt; {
          // onNoNetwork
          Console.WriteLine("On No Network!");
      });</pre>
<h3><strong>گام 3: نمایش تبلیغ هم‌نما</strong></h3>
پس از اینکه شناسه تبلیغ از اکشن onAdFilled دریافت کردید می توانید با استفاده از تابع زیر آنرا نمایش دهید:
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell.fillNativeVideoAd(Context context, String adId,
                                          bool autoStartVideo, bool fullscreenOnClick,
                                          TextView tvTitle, TextView tvDescription,
                                          ViewGroup vgVideoContainerParent, ImageView ivLogo,
                                          TextView tvCTAButton, TextView tvSponsored,
                                          ViewGroup adContainer)
</pre>
&nbsp;

ورودی nativeAdId شناسه تبلیغ است که در گام قبل و در اکشن onAdFilled به شما داده شده‌است. ورودی <code>autoStartVideo</code> مشخص کننده این است که ویدئو بعد از لود شدن در صفحه بصورت اتوماتیک اجرا شود یا خیر. همچنین <code>fullscreenOnClick</code> تعیین کننده این است که آیا زمان کلیک کردن کاربر روی ویدئو باید ویدئو بصورت تمام صفحه نمایش داده شود یا خیر. ورودی‌های بعدی به ترتیب نشانگر عنوان تبلیغ، توضیحات تبلیغ، layout نمایش ویدئو، لوگو تبلیغ، دکمه دعوت از کاربر و نشانگر آگهی بودن می‌باشند. آخرین ورودی نیز layout دربرگیرنده تبلیغ هست که اختیاری بوده و می‌تواند <code>Null</code> باشد. یک نمونه پیاده سازی تابع را در زیر مشاهده میکنید که ویو های آن قبلا در onCreate اکتیویتی با تابع FindViewById شناسانده شده اند:
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell.fillNativeVideoAd(this, nativeAdId, 
      true, true, title_video, description_video, banner_video, logo_video, ctaButton_video, 
      sponsored_video, adParent_video);</pre>
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific, sans-serif, Tahoma, Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 968px; top: 1098px;"></div>
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific, sans-serif, Tahoma, Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 10px; top: 487px;"></div>
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific, sans-serif, Tahoma, Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 941px; top: 3046px; opacity: 0.55;">
<div id="s3gt_translate_tooltip_mini_logo" class="s3gt_translate_tooltip_mini" title="Translate selected text"></div>
<div id="s3gt_translate_tooltip_mini_sound" class="s3gt_translate_tooltip_mini" title="Play"></div>
<div id="s3gt_translate_tooltip_mini_copy" class="s3gt_translate_tooltip_mini" title="Copy text to Clipboard"></div>
<style type="text/css" media="print">#s3gt_translate_tooltip_mini { display: none !important; }</style></div>
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific, sans-serif, Tahoma, Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 932px; top: 2602px; opacity: 0.65;">
<div id="s3gt_translate_tooltip_mini_logo" class="s3gt_translate_tooltip_mini" title="Translate selected text"></div>
<div id="s3gt_translate_tooltip_mini_sound" class="s3gt_translate_tooltip_mini" title="Play"></div>
<div id="s3gt_translate_tooltip_mini_copy" class="s3gt_translate_tooltip_mini" title="Copy text to Clipboard"></div>
</div>
  </div>
  
  <div dir="rtl" id="part4">
  <h1>پیاده‌سازی تبلیغات بنری هم‌نما (Native Banner) در پروژه Xamarin</h1>
  <h3 style="text-align: right;">گام 1: ساختن Layout نمایش تبلیغ هم‌نما</h3>
در تبلیغات هم‌نما، شما قادر هستید ویژگی‌های ظاهری هر یک از اجزای تبلیغ (اندازه، محل قرارگیری، رنگ فونت و...) را بصورتی که هماهنگ با محتوای اپلیکیشن شما باشد تعیین کنید. لذا باید Layout هم‌نما اپلیکیشن خود را که مدنظرتان است ایجاد کرده و به SDK تپسل معرفی کنید. هرقالب محتوای که برای تبلیغات هم‌نما بنری ارائه می‌شود میبایست دارای حداقل دو آیتم عنوان تبلیغ، نشانگر تبلیغ بودن را دارا باشد. شکل کلی قالب محتوایی تبلیغات هم‌نما ویدئویی بصورت زیر می‌باشد:
<pre dir="ltr">&lt;RelativeLayout
    android:layout_width="match_parent"
    android:layout_height="match_parent"&gt;

    &lt;ImageView
        android:id="@id/tapsell_nativead_logo"
        ... /&gt;

    &lt;TextView
        android:id="@id/tapsell_nativead_title"
        ... /&gt;

    &lt;TextView
        android:id="@id/tapsell_nativead_sponsored"
        ... /&gt;

    &lt;TextView
        android:id="@id/tapsell_nativead_description"
        ... /&gt;

    &lt;ImageView
        android:id="@id/tapsell_nativead_banner"
        ... /&gt;

    &lt;Button
        android:id="@id/tapsell_nativead_cta"
        ... /&gt;

&lt;/RelativeLayout&gt;</pre>
<h3><strong>گام 2: درخواست تبلیغ بنری هم‌نما</strong></h3>
در تپسل، تبلیغ می تواند در ناحیه‌های مختلفی از برنامه شما (مانند منو اصلی، بین پست‌ها و ...) پخش شود. در تپسل به این ناحیه‌ها zone گفته می شود. ناحیه‌های هر اپلیکیشن در داشبورد تپسل تعریف می شوند. با اجرای تابع زیر، می‌توانید یک درخواست تبلیغ به تپسل ارسال کرده و یک تبلیغ دریافت نمایید:
<pre style="direction: ltr; margin: 0; line-height: 125%;">requestNativeBannerAd(Context context, string zoneId, 
    Action&lt;string&gt; onAdFilled, Action&lt;string&gt; onError, 
    Action onNoAdAvailable, Action onNoNetwork)
</pre>
هر درخواست شامل یک ورودی شناسه تبلیغ‌گاه (<code>zoneId)</code> است که نشانگر محل نمایش تبلیغ در اپلیکیشن شماست. تبلیغ‌گاه مرتبط با این شناسه در داشبورد تپسل باید از نوع بنری هم‌نما باشد. نتیجه درخواست بصورت اکشن به برنامه شما بازگردانده می‌شود. توضیحات اکشن های موجود در جدول زیر آمده است:
<table width="100%"><caption>اکشن های دریافت نتیجه درخواست تبلیغ</caption>
<tbody>
<tr>
<th width="40%">تابع</th>
<th width="60%">توضیحات (زمان اجرا)</th>
</tr>
<tr>
<td width="40%">onError(string)</td>
<td>هنگامی که هر نوع خطایی در پروسه‌ی دریافت تبلیغ بوجود بیاید</td>
</tr>
<tr>
<td width="40%">onAdFilled(string)</td>
<td width="60%">زمانی که تبلیغ دریافت شده و آماده‌ی نمایش باشد.</td>
</tr>
<tr>
<td width="40%">onNoAdAvailable()</td>
<td width="60%">در صورتی که تبلیغی برای نمایش وجود نداشته باشد.</td>
</tr>
<tr>
<td width="40%">onNoNetwork()</td>
<td width="60%">زمانی که دسترسی به شبکه موجود نباشد.</td>
</tr>
</tbody>
</table>
در ادامه یه نمونه پیاده سازی شده این تابع را مشاهده خواهید کرد:
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell.requestNativeBannerAd(this, "5a379ee4dc93ee0001c0fb13",
                    (string nativeAdId) =&gt; {
                        // onAdFilled
                        Console.WriteLine("onAdFilled adId = " + nativeAdId);
                    },

                    (string errorMessage) =&gt; {
                        // onError
                        Console.WriteLine("On Error messeage = " + errorMessage);
                    },

                    () =&gt; {
                        // onNoAdAvailable
                        Console.WriteLine("On No Ad Available!");
                    },

                    () =&gt; {
                        // onNoNetwork
                        Console.WriteLine("On No Network!");
                    });</pre>
<h3><strong>گام 3: نمایش تبلیغ هم‌نما</strong></h3>
پس از اینکه شناسه تبلیغ از اکشن onAdFilled دریافت کردید می توانید با استفاده از تابع زیر آنرا نمایش دهید:
<pre style="direction: ltr; margin: 0; line-height: 125%;">fillNativeBannerAd(Context context, String adId,
    TextView tvTitle, TextView tvDescription,
    ImageView ivBanner, ImageView ivLogo,
    TextView tvCTAButton, TextView tvSponsored,
    ViewGroup adContainer)
</pre>
&nbsp;

ورودی adId شناسه تبلیغ است که در گام قبل و در اکشن onAdFilled به شما داده شده‌است. ورودی‌های بعدی به ترتیب نشانگر عنوان تبلیغ، توضیحات تبلیغ، ImageView نمایش دهنده بنر، لوگو تبلیغ، دکمه دعوت از کاربر و نشانگر آگهی بودن می‌باشند. آخرین ورودی نیز layout دربرگیرنده تبلیغ هست. یک نمونه پیاده سازی تابع را در زیر مشاهده میکنید که ویو های آن قبلا در onCreate اکتیویتی با تابع FindViewById شناسانده شده اند:
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell.fillNativeBannerAd(this, nativeAdId, title, 
     description, banner, logo, ctaButton, sponsored, adParent);</pre>
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific, sans-serif, Tahoma, Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 968px; top: 1098px;"></div>
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific, sans-serif, Tahoma, Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 10px; top: 487px;"></div>
  </div>
  
  <div dir="rtl" id="part5">
  <h1>پیاده‌سازی تبلیغات بنری استاندارد در پروژه Xamarin</h1>
  <h3>گام 1: نمایش تبلیغ بنری استاندارد</h3>
جهت نمایش بنر استاندارد، باید محلی برای نمایش آن در صفحه در نظر بگیرید. بنر استاندارد، دارای سایزهای استانداردی است که در SDK تپسل مشخص شده اند. جهت نمایش بنر، از تابع زیر استفاده کنید:
<pre dir="ltr">requestBannerAd(Context context ,string zoneId , int bannerType , int horizontalGravity , 
int verticalGravity, Action&lt;string&gt; onError, 
Action onNoAdAvailable, Action onNoNetwork, Action onRequestFilled, Action onHideBannerView)</pre>
مقدار zoneId کلیدی ست که بعد از ساخت اپلیکیشن در پنل و ثبت یک zone از نوع بنری استاندارد دریافت میکنید.ورودی BannerType اندازه های مختلف را بیان میکند و شامل مقادیر  BANNER_320x50 ,BANNER_320x100 ,BANNER_250x250 , BANNER_300x250 میباشد. ورودی horizontalGravity نشان میدهد که آیا تبلیغ، بالا یا پایین صفحه باشد همچنین verticalGravity بیان میکند که تبلیغ از جهت عرضی در کجای صفحه باشد. پاسخ درخواست تبلیغ از طریق اکشن های ورودی دریافت میشود. یک نمونه پیاده سازی کد به شکل زیر است:
<pre dir="ltr">Tapsell.requestBannerAd(this, "59fd723c404ded000185a184", BannerType.BANNER_320x50, BannerGravity.BOTTOM, BannerGravity.CENTER, 
                    () =&gt; {
                        // onRequestFilled
                        Console.WriteLine("onAdFilled");
                    },

                    (string errorMessage) =&gt; {
                        // onError
                        Console.WriteLine("On Error messeage = " + errorMessage);
                    },

                    () =&gt; {
                        // onNoAdAvailable
                        Console.WriteLine("On No Ad Available!");
                    },

                    () =&gt; {
                        // onNoNetwork
                        Console.WriteLine("On No Network!");
                    },

                    () =&gt; {
                        // onHide
                        Console.WriteLine("On Hide");
                    });</pre>
  </div>
  
  <div dir="rtl" id="part6">
  <h1>موارد پیشرفته‌تر در SDK تپسل (Xamarin)</h1>
  <h3>تنظیمات کشینگ</h3>
همانطور که در بخش <a href="https://answers.tapsell.ir/?ht_kb=xamarin-sdk-p2">پیاده‌سازی SDK تپسل در پروژه Xamarin</a> گفته شد، از نسخه ۳ به بعد تپسل قابلیت نمایش ویدئو بصورت استریم و همینطور نمایش ویدئو بعد از دانلود فایل (کشینگ) را دارد. با این قابلیت، قبل از نمایش تبلیغ و در هنگامی که کاربر مشغول استفاده از اپلیکیشن است، ویدئو بطور کامل دریافت می‌شود و کاربر بدون هیچگونه مکثی می‌تواند ویدئو را تماشا کند.

از طرف دیگر، در اپلیکیشن‌ها و بازی‌های آنلاین، دریافت ویدئو در پس زمینه ممکن است در روند اصلی برنامه خلل ایجاد کند و آن را کند نماید.

جهت جلوگیری از اشغال پهنای باند زیاد توسط تپسل، شما می‌توانید درصد مشخصی از کل پهنای باند موجود را به دانلود ویدئو اختصاص دهید. جهت انجام این عمل، تابع زیر را قبل از درخواست تبلیغ، فراخوانی کنید.
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell<span style="color: #333333;">.</span><span style="color: #0000cc;">setMaxAllowedBandwidthUsagePercentage</span><span style="color: #333333;">(</span>context<span style="color: #333333;">,</span> maxPercentage<span style="color: #333333;">);</span></pre>
&nbsp;

در این تابع، ورودی <code>maxPercentage</code> حداکثر درصدی از پهنای باند در دسترس اپلیکیشن است که SDK تپسل از آن برای دریافت ویدئو استفاده می‌کند. این پارامتر باید عددی بین 0 تا 100 باشد.

همچنین درصورتی که از سرعت دانلود واقعی کاربر در اپلیکیشن خود اطلاع دارید می‌توانید به کمک تابع زیر، مقدار حداکثر پهنای باند قابل استفاده برای دانلود ویدئو را به کمک تابع زیر تنظیم کنید.
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell<span style="color: #333333;">.</span><span style="color: #0000cc;">setMaxAllowedBandwidthUsage</span><span style="color: #333333;">(</span>context<span style="color: #333333;">,</span> maxBpsSpeed<span style="color: #333333;">);</span></pre>
&nbsp;

ورودی دوم این تابع، میزان حداکثر سرعت دانلود ویدئو است که باید به واحد بایت بر ثانیه داده شود.

در صورتی که در بخشی از اپلیکیشن خود می‌خواهید تنظیمات مربوط به محدودیت سرعت دانلود را غیرفعال نمایید، از تابع زیر استفاده کنید.
<pre style="direction: ltr; margin: 0; line-height: 125%;">Tapsell<span style="color: #333333;">.</span><span style="color: #0000cc;">clearBandwidthUsageConstrains</span><span style="color: #333333;">(</span>context<span style="color: #333333;">);</span></pre>
&nbsp;

توضیحات بیشتر درباره کشینگ و استریمینگ در SDK تپسل را <a href="https://answers.tapsell.ir/?ht_kb=cached-vs-streamed">اینجا</a> بخوانید.

&nbsp;
<h3>تنظیمات دسترسی‌های زمان اجرا (Run Time Permissions)</h3>
از نسخه اندروید 6 و بالاتر، برخی دسترسی‌ها در اندروید در زمان اجرا باید از کاربر درخواست شوند. یکی از این دسترسی‌ها، دسترسی <code>READ_PHONE_STATE</code> است که توسط تپسل استفاده می‌شود و بدون این دسترسی نمایش بخشی از تبلیغات به کاربر ممکن نیست. برای سهولت پیاده‌سازی در صورت وجود این دسترسی در manifest برنامه، SDK تپسل بصورت اتوماتیک دسترسی‌ را از کاربر درخواست می‌کند و هربار درخواست تبلیغی ارسال شود، درصورتی که دسترسی مورد نیاز موجود نباشد، این دسترسی از کاربر خواسته می شود.

در صورتی که شما می‌خواهید درخواست دسترسی‌ها از کاربر را به نحو دیگری در اپلیکیشن خود پیاده‌سازی نمایید، می‌توانید این ویژگی پیش‌فرض را در تپسل غیر فعال کنید. جهت انجام این عمل، کافیست ویژگی‌های مورد نیاز را هنگام فراخواهی تابع <code>initialize</code> از کتابخانه تپسل به عنوان ورودی تابع استفاده کنید.
<pre style="direction: ltr; margin: 0; line-height: 125%;"><span style="color: #333333;">TapsellConfiguration config = new TapsellConfiguration();
config.permissionHandlerMode = TapsellConfiguration.PERMISSION_HANDLER_AUTO;

//config.isDebugMode = true;
//config.maxAllowedBandwidthUsage = 50;
//config.maxAllowedBandwidthUsagePercentage = 60;

Tapsell.initialize(Application.Context,config, appKey);</span></pre>
با این دستور، درخواست دسترسی توسط SDK تپسل به کاربر نشان داده نمی‌شود و می‌توانید بصورت مطلوب خود آن را پیاده‌سازی نمایید. در صورتی که دسترسی <code>READ_PHONE_STATE</code> در manifest برنامه شما وجود ندارد، باید حالت <code>PERMISSION_HANDLER_DISABLED</code> در آماده سازی برنامه به عنوان ورودی داده شود. مقادیر <code>permissionHandlerMode</code> در جدول 1 آمده است.
<table style="text-align: center; border-collapse: collapse;" width="100%"><caption>جدول ۱ مقادیر PermissionHandlerMode</caption>
<tbody>
<tr style="border-bottom: 1px solid #ddd;">
<th width="40%">مقدار</th>
<th width="60%">توضیحات</th>
</tr>
<tr style="background-color: #fefefe;">
<td dir="ltr" width="40%">PERMISSION_HANDLER_DISABLED</td>
<td>درخواست مجوز از کاربر غیرفعال می شود</td>
</tr>
<tr style="background-color: #f2f2f2;">
<td dir="ltr" width="40%">PERMISSION_HANDLER_AUTO</td>
<td width="60%">به صورت خودکار از کاربر اجازه دسترسی میگیرد و در صورت عدم تایید درخواست را تکرار نمی کند</td>
</tr>
<tr style="background-color: #fefefe;">
<td dir="ltr" width="40%">PERMISSION_HANDLER_AUTO_INSIST</td>
<td width="60%">به صورت خودکار از کاربر اجازه دسترسی میگیرد و در صورت عدم تایید ، هربار عدم دسترسی را به کاربر اعلام میکند</td>
</tr>
</tbody>
</table>
&nbsp;
<h3>حالت دیباگ (Debug Mode)</h3>
در هنگام پیاده‌سازی SDK، ممکن است بدلیل عدم رعایت نکات گفته شده و یا خطاهای دیگر، تبلیغات قابل دریافت و نمایش نباشند. حالت دیباگ جهت تسهیل فرآیند عیب‌یابی در هنگام پیاده‌سازی تعبیه شده است. با فعالسازی این حالت، می‌توانید گزارش‌های لاگ نمایش داده شده توسط SDK را در logcat مشاهده کنید. برای فعالسازی حالت دیباگ کافیست یک شی از کلاس <code>TapsellConfiguration</code> ایجاد کنید و پس از تنظیم ویژگی‌های مورد نیاز، هنگام فراخواهی تابع <code>initialize</code> از کتابخانه تپسل آن را نیز به عنوان ورودی تابع استفاده کنید یا اینکه به صورت مستقیم از دستور زیر استفاده کنید.
<pre dir="ltr">Tapsell.setDebugMode(<span style="color: #333333;">Application.Context</span>, true);</pre>
سپس از بخش Android Device Logging، لاگ‌های نوشته شده را بررسی کنید.

<img class="wp-image-1958 aligncenter" src="https://answers.tapsell.ir/wp-content/uploads/2017/10/Capture-300x73.jpg" alt="" width="999" height="243" />
<div id="s3gt_translate_tooltip_mini" class="s3gt_translate_tooltip_mini_box" style="background: initial !important; border: initial !important; border-radius: initial !important; border-spacing: initial !important; border-collapse: initial !important; direction: ltr !important; flex-direction: initial !important; font-weight: initial !important; height: initial !important; letter-spacing: initial !important; min-width: initial !important; max-width: initial !important; min-height: initial !important; max-height: initial !important; margin: auto !important; outline: initial !important; padding: initial !important; position: absolute; table-layout: initial !important; text-align: initial !important; text-shadow: initial !important; width: initial !important; word-break: initial !important; word-spacing: initial !important; overflow-wrap: initial !important; box-sizing: initial !important; display: initial !important; color: inherit !important; font-size: 13px !important; font-family: X-LocaleSpecific,sans-serif,Tahoma,Helvetica !important; line-height: 13px !important; vertical-align: top !important; white-space: inherit !important; left: 968px; top: 2175px;">
<div id="s3gt_translate_tooltip_mini_logo" class="s3gt_translate_tooltip_mini" title="Translate selected text"></div>
<div id="s3gt_translate_tooltip_mini_sound" class="s3gt_translate_tooltip_mini" title="Play"></div>
<div id="s3gt_translate_tooltip_mini_copy" class="s3gt_translate_tooltip_mini" title="Copy text to Clipboard"></div>
<style type="text/css" media="print">#s3gt_translate_tooltip_mini { display: none !important; }</style></div>
  </div>
  
