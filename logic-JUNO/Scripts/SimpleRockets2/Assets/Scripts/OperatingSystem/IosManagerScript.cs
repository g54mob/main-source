using UnityEngine;

namespace Assets.Scripts.OperatingSystem
{
	public class IosManagerScript : MobileManagerScript
	{
		public static IosManagerScript CreateIosManager(GameObject parent)
		{
			IosManagerScript iosManagerScript = new GameObject("iOSManager").AddComponent<IosManagerScript>();
			iosManagerScript.transform.SetParent(parent.transform);
			return iosManagerScript;
		}
	}
}
