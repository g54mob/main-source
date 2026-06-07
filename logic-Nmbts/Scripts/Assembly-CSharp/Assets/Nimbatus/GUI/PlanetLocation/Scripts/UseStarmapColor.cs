using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine;

namespace Assets.Nimbatus.GUI.PlanetLocation.Scripts
{
	public class UseStarmapColor : MonoBehaviour
	{
		public UITexture Texture;

		private void Start()
		{
			Texture.color = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.SelectedStarmapColor;
		}
	}
}
