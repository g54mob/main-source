using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.PlanetLocation.Scripts
{
	public class DisplayPreviewImage : MonoBehaviour
	{
		public UITexture TargetTexture;

		public void Start()
		{
			TargetTexture.mainTexture = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.GetPreviewImage();
		}
	}
}
