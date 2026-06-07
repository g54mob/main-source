using UnityEngine;

namespace Assets.Scripts.OperatingSystem
{
	public class AndroidManagerScript : MobileManagerScript
	{
		public static AndroidManagerScript CreateAndroidManager(GameObject parent)
		{
			AndroidManagerScript androidManagerScript = new GameObject("AndroidManager").AddComponent<AndroidManagerScript>();
			androidManagerScript.transform.SetParent(parent.transform);
			return androidManagerScript;
		}
	}
}
