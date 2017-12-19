package mono.ir.tapsell.xamarin;


public class NativeBannerAdLoadListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		ir.tapsell.xamarin.NativeBannerAdLoadListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onNativeError:(Ljava/lang/String;)V:GetOnNativeError_Ljava_lang_String_Handler:IR.Tapsell.Xamarin.INativeBannerAdLoadListenerInvoker, TapsellXamarinSdk\n" +
			"n_onNativeNoAdAvailable:()V:GetOnNativeNoAdAvailableHandler:IR.Tapsell.Xamarin.INativeBannerAdLoadListenerInvoker, TapsellXamarinSdk\n" +
			"n_onNativeNoNetwork:()V:GetOnNativeNoNetworkHandler:IR.Tapsell.Xamarin.INativeBannerAdLoadListenerInvoker, TapsellXamarinSdk\n" +
			"n_onNativeRequestFilled:(Ljava/lang/String;)V:GetOnNativeRequestFilled_Ljava_lang_String_Handler:IR.Tapsell.Xamarin.INativeBannerAdLoadListenerInvoker, TapsellXamarinSdk\n" +
			"";
		mono.android.Runtime.register ("IR.Tapsell.Xamarin.INativeBannerAdLoadListenerImplementor, TapsellXamarinSdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NativeBannerAdLoadListenerImplementor.class, __md_methods);
	}


	public NativeBannerAdLoadListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == NativeBannerAdLoadListenerImplementor.class)
			mono.android.TypeManager.Activate ("IR.Tapsell.Xamarin.INativeBannerAdLoadListenerImplementor, TapsellXamarinSdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onNativeError (java.lang.String p0)
	{
		n_onNativeError (p0);
	}

	private native void n_onNativeError (java.lang.String p0);


	public void onNativeNoAdAvailable ()
	{
		n_onNativeNoAdAvailable ();
	}

	private native void n_onNativeNoAdAvailable ();


	public void onNativeNoNetwork ()
	{
		n_onNativeNoNetwork ();
	}

	private native void n_onNativeNoNetwork ();


	public void onNativeRequestFilled (java.lang.String p0)
	{
		n_onNativeRequestFilled (p0);
	}

	private native void n_onNativeRequestFilled (java.lang.String p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
