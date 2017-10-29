package mono.ir.tapsell.xamarin;


public class AdShowListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		ir.tapsell.xamarin.AdShowListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onClosed:(Ljava/lang/String;)V:GetOnClosed_Ljava_lang_String_Handler:IR.Tapsell.Xamarin.IAdShowListenerInvoker, TapsellXamarinSdk\n" +
			"n_onOpened:(Ljava/lang/String;)V:GetOnOpened_Ljava_lang_String_Handler:IR.Tapsell.Xamarin.IAdShowListenerInvoker, TapsellXamarinSdk\n" +
			"";
		mono.android.Runtime.register ("IR.Tapsell.Xamarin.IAdShowListenerImplementor, TapsellXamarinSdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AdShowListenerImplementor.class, __md_methods);
	}


	public AdShowListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AdShowListenerImplementor.class)
			mono.android.TypeManager.Activate ("IR.Tapsell.Xamarin.IAdShowListenerImplementor, TapsellXamarinSdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onClosed (java.lang.String p0)
	{
		n_onClosed (p0);
	}

	private native void n_onClosed (java.lang.String p0);


	public void onOpened (java.lang.String p0)
	{
		n_onOpened (p0);
	}

	private native void n_onOpened (java.lang.String p0);

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
