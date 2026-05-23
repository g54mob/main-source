using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bozo.ModularCharacters
{
	public class IconCapture : MonoBehaviour
	{
		[Serializable]
		public class IconCaptureSettings
		{
			public OutfitType type;

			public Camera camera;

			public bool showHead = true;

			public bool showBody = true;
		}

		[SerializeField]
		private RenderTexture iconTexture;

		[SerializeField]
		private Camera iconCamera;

		[SerializeField]
		private Transform parent;

		[SerializeField]
		private string path = "BoZo_ModularAnimeCharacters/Textures/OutfitIcons";

		[SerializeField]
		private GameObject BackingBody;

		[SerializeField]
		private GameObject BackingHead;

		[SerializeField]
		private List<Outfit> outfits = new List<Outfit>();

		[SerializeField]
		private Color[] Colors;

		private Camera activeCam;

		[SerializeField]
		private IconCaptureSettings[] cameraSettings;

		[SerializeField]
		private Dictionary<OutfitType, IconCaptureSettings> cameras = new Dictionary<OutfitType, IconCaptureSettings>();

		private void Awake()
		{
			IconCaptureSettings[] array = cameraSettings;
			foreach (IconCaptureSettings iconCaptureSettings in array)
			{
				cameras.Add(iconCaptureSettings.type, iconCaptureSettings);
			}
		}

		[ContextMenu("Capture")]
		public void Capture()
		{
		}

		public void Capture(GameObject gameObject)
		{
		}
	}
}
