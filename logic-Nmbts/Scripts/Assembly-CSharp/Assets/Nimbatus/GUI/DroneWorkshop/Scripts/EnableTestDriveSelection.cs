using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class EnableTestDriveSelection : MonoBehaviour
	{
		public UIButtonOffset Animation;

		public void Start()
		{
			Animation.enabled = RuntimeGlobals.GameModeSettings.MultipleTestDriveModes;
		}
	}
}
