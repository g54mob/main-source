using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class DisplayLocationDescription : MonoBehaviour
	{
		public UILabel Label;

		public void Update()
		{
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation != null)
			{
				Label.text = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.GetDescription();
			}
			else
			{
				Label.text = "";
			}
		}
	}
}
