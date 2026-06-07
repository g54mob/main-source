using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class DisableInDemoMode : MonoBehaviour
	{
		public void Awake()
		{
			if (RuntimeGlobals.DemoMode)
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
