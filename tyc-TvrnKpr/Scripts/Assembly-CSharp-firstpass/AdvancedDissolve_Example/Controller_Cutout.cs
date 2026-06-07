using System.Collections.Generic;
using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Cutout : MonoBehaviour
	{
		public enum CUTOUT_SOURCE
		{
			MainMapAlpha = 0,
			CustomMap = 1,
			TwoCustomMaps = 2,
			ThreeCustomMaps = 3
		}

		public enum MAPPING
		{
			Normal = 0,
			Triplanar = 1,
			ScreenSpace = 2
		}

		public enum TRIPLANAR_SPACE
		{
			World = 0,
			Local = 1
		}

		public enum UVSET
		{
			UV0 = 0,
			UV1 = 1
		}

		public enum TEXTURE_BLEND
		{
			Multiple = 0,
			Add = 1
		}

		public enum TEXTURE_CHANNEL
		{
			Red = 0,
			Green = 1,
			Blue = 2,
			Alpha = 3
		}

		public bool updateGlobal;

		public bool unscaledTime;

		private float time;

		private List<Material> _materials;

		[Space(10f)]
		public float noise;

		[Space(10f)]
		public Texture texture1;

		public Vector2 texture1Tiling;

		public Vector2 texture1Offset;

		public Vector3 texture1Scroll;

		public TEXTURE_CHANNEL texture1Channel;

		[Range(0f, 1f)]
		public float texture1Intensity;

		[Space(10f)]
		public Texture texture2;

		public Vector2 texture2Tiling;

		public Vector2 texture2Offset;

		public Vector3 texture2Scroll;

		public TEXTURE_CHANNEL texture2Channel;

		[Range(0f, 1f)]
		public float texture2Intensity;

		[Space(10f)]
		public Texture texture3;

		public Vector2 texture3Tiling;

		public Vector2 texture3Offset;

		public Vector3 texture3Scroll;

		public TEXTURE_CHANNEL texture3Channel;

		[Range(0f, 1f)]
		public float texture3Intensity;

		[Space(10f)]
		public UVSET uvSet;

		public TEXTURE_BLEND textureBlend;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateShaderData()
		{
		}

		public void UpdateCutoutSourceKeyword(CUTOUT_SOURCE cutoutSource)
		{
		}

		public void UpdateMappingKeyword(MAPPING mapping)
		{
		}
	}
}
