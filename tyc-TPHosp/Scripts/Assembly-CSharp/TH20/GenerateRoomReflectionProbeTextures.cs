using System;
using System.Collections.Generic;
using FullInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20
{
	[fiInspectorOnly]
	public class GenerateRoomReflectionProbeTextures : MonoBehaviour
	{
		[Serializable]
		public class CubemapEntry
		{
			public string Name = "Untitled";

			public GameObject Parent;

			public Cubemap Cubemap;
		}

		[Serializable]
		public class CameraCubemapEntryPair
		{
			public Camera Camera;

			public CubemapEntry CubemapEntry;
		}

		[SerializeField]
		[FormerlySerializedAs("_cubemapsUnitySerialised")]
		private List<CameraCubemapEntryPair> _cubemaps = new List<CameraCubemapEntryPair>();

		[InspectorRange(2f, 2048f)]
		[SerializeField]
		private int _cubemapSize = 512;

		[SerializeField]
		private string _cubemapAssetPath = "Assets/Data/Textures/RoomCubeMaps/";

		public List<CameraCubemapEntryPair> Cubemaps => _cubemaps;

		public int CubemapSize => _cubemapSize;

		public string CubemapAssetPath => _cubemapAssetPath;

		protected void OnValidate()
		{
			_cubemapSize = Mathf.ClosestPowerOfTwo(_cubemapSize);
		}
	}
}
