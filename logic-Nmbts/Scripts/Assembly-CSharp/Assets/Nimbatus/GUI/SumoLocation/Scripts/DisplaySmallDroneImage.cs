using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SumoLocation.Scripts
{
	public class DisplaySmallDroneImage : MonoBehaviour
	{
		public NimbatusDrone Drone;

		public UITexture Texture;

		public void Update()
		{
			if (Drone != null)
			{
				Drone.DroneData.Image.wrapMode = TextureWrapMode.Clamp;
				Texture.mainTexture = Drone.DroneData.Image;
			}
		}
	}
}
