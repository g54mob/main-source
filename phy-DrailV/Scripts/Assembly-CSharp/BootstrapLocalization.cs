using System.Collections;
using I2.Loc;
using UnityEngine;

public class BootstrapLocalization : MonoBehaviour
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void RegisterI2PrefsReroute()
	{
		PersistentStorage.mStorage = new I2PrefReroute();
	}

	private IEnumerator Start()
	{
		yield return null;
		yield return null;
		yield return null;
		SceneSwitcher.BootstrapToNextScene();
	}
}
