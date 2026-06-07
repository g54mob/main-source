using System;
using System.Runtime.InteropServices;
using AOT;
using Factory;

public class AppleReachability : IReachability, ICreatedInScopeHandler, IReleasedFromScopeHandler
{
	private InternetConnectivity _connectivity;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("AppleReachability");

	private static AppleReachability Instance;

	public InternetConnectivity Connectivity => _connectivity;

	public bool CanConnectManually => false;

	public event Action<InternetConnectivity> ConnectivityChanged;

	public void OnCreatedInScope(IScope scope)
	{
		Instance = this;
		StartCheckingReachability(Marshal.GetFunctionPointerForDelegate<Action<bool>>(OnReachabilityChanged));
	}

	public void OnReleasedFromScope(IScope scope)
	{
		Instance = null;
	}

	public void OpenSilentConnection(IReachability.ConnectionOpened connectionOpened)
	{
		connectionOpened(new InternetConnectionHandle(this));
	}

	public void OpenManualConnection(IReachability.ConnectionOpened connectionOpened)
	{
		OpenSilentConnection(connectionOpened);
	}

	public void CloseConnection(InternetConnectionHandle handle)
	{
	}

	[MonoPInvokeCallback(typeof(Action<bool>))]
	private static void OnReachabilityChanged(bool reachable)
	{
		Log.Info("Reachability changed to {0}.", reachable);
		if (Instance != null)
		{
			InternetConnectivity internetConnectivity = (reachable ? InternetConnectivity.Connected : InternetConnectivity.Disconnected);
			if (Instance._connectivity != internetConnectivity)
			{
				Instance._connectivity = internetConnectivity;
				Instance.ConnectivityChanged?.Invoke(internetConnectivity);
			}
		}
	}

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern void StartCheckingReachability(IntPtr reachabilityChangedHandler);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool IsReachable();
}
