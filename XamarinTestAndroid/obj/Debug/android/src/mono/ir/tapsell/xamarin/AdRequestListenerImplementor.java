package mono.ir.tapsell.xamarin;


public class AdRequestListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		ir.tapsell.xamarin.AdRequestListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdAvailable:(Ljava/lang/String;Ljava/lang/String;)V:GetOnAdAvailable_Ljava_lang_String_Ljava_lang_String_Handler:IR.Tapsell.Xamarin.IAdRequestListenerInvoker, TapsellXamarinSdk\n" +
			"n_onError:(Ljava/lang/String;)V:GetOnError_Ljava_lang_String_Handler:IR.Tapsell.Xamarin.IAdRequestListenerInvoker, TapsellXamarinSdk\n" +
			"n_onExpiring:(Ljava/lang/String;Ljava/lang/String;)V:GetOnExpiring_Ljava_lang_String_Ljava_lang_String_Handler:IR.Tapsell.Xamarin.IAdRequestListenerInvoker, TapsellXamarinSdk\n" +
			"n_onNoAdAvailable:()V:GetOnNoAdAvailableHandler:IR.Tapsell.Xamarin.IAdRequestListenerInvoker, TapsellXamarinSdk\n" +
			"n_onNoNetwork:()V:GetOnNoNetworkHandler:IR.Tapsell.Xamarin.IAdRequestListenerInvoker, TapsellXamarinSdk\n" +
			"";
		mono.android.Runtime.register ("IR.Tapsell.Xamarin.IAdRequestListenerImplementor, TapsellXamarinSdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AdRequestListenerImplementor.class, __md_methods);
	}


	public AdRequestListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AdRequestListenerImplementor.class)
			mono.android.TypeManager.Activate ("IR.Tapsell.Xamarin.IAdRequestListenerImplementor, TapsellXamarinSdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onAdAvailable (java.lang.String p0, java.lang.String p1)
	{
		n_onAdAvailable (p0, p1);
	}

	private native void n_onAdAvailable (java.lang.String p0, java.lang.String p1);


	public void onError (java.lang.String p0)
	{
		n_onError (p0);
	}

	private native void n_onError (java.lang.String p0);


	public void onExpiring (java.lang.String p0, java.lang.String p1)
	{
		n_onExpiring (p0, p1);
	}

	private native void n_onExpiring (java.lang.String p0, java.lang.String p1);


	public void onNoAdAvailable ()
	{
		n_onNoAdAvailable ();
	}

	private native void n_onNoAdAvailable ();


	public void onNoNetwork ()
	{
		n_onNoNetwork ();
	}

	private native void n_onNoNetwork ();

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
