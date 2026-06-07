using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public class InitSettings : MonoBehaviour
	{
		public void Awake()
		{
			RuntimeGlobals.Settings.Init();
		}
	}
}
