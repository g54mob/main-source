using System.Collections.Generic;

public class GadgetPrefsController : Controller, ILogOrigin
{
	public class GadgetPref
	{
		public bool security_dialogDisplayed;

		public bool security_allowWebcam;

		public bool security_allowNetworkComunication;
	}

	public class RemotePrintedGadgetPref : GadgetPref
	{
		public string updateId;
	}

	private Dictionary<uint, GadgetPref> localGadgetPrefs;

	private Dictionary<ulong, RemotePrintedGadgetPref> remotePrintedGadgetPrefs;

	private string localDirectory;

	private string remoteDirectory;

	public override void Init()
	{
	}

	private bool AreRemotePrefsValid(SerializedGadgetMetaData metadata, RemotePrintedGadgetPref gadgetPref)
	{
		return false;
	}

	public void OnGadgetDeleted(SerializedGadgetMetaData metadata)
	{
	}

	public void SaveAll()
	{
	}

	private void SaveLocalPrefs(uint guid, GadgetPref prefs)
	{
	}

	private void SaveRemotePrintedPrefs(ulong fileId, RemotePrintedGadgetPref prefs)
	{
	}

	public GadgetPref GetPrefs(SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public void SavePrefs(SerializedGadgetMetaData metadata)
	{
	}

	private void SaveLocalDesktopState(uint guid, SerializedDesktopGadgetState desktopState)
	{
	}

	private void SaveRemotePrintedDesktopState(ulong fileId, SerializedDesktopGadgetState desktopState)
	{
	}

	public SerializedDesktopGadgetState GetDesktopState(SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public void SaveDesktopState(SerializedGadgetMetaData metadata, SerializedDesktopGadgetState desktopGadgetState)
	{
	}

	private void OnApplicationQuit()
	{
	}
}
