package md5b2a92b679c80e6353631eb09c5c78835;


public class RewardListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		ir.tapsell.xamarin.RewardListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdShowFinished:(Ljava/lang/String;Ljava/lang/String;ZZ)V:GetOnAdShowFinished_Ljava_lang_String_Ljava_lang_String_ZZHandler:IR.Tapsell.Xamarin.IRewardListenerInvoker, TapsellXamarinSdk\n" +
			"";
		mono.android.Runtime.register ("IR.Tapsell.Xamarin.RewardListener, TapsellXamarinSdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RewardListener.class, __md_methods);
	}


	public RewardListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == RewardListener.class)
			mono.android.TypeManager.Activate ("IR.Tapsell.Xamarin.RewardListener, TapsellXamarinSdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onAdShowFinished (java.lang.String p0, java.lang.String p1, boolean p2, boolean p3)
	{
		n_onAdShowFinished (p0, p1, p2, p3);
	}

	private native void n_onAdShowFinished (java.lang.String p0, java.lang.String p1, boolean p2, boolean p3);

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
