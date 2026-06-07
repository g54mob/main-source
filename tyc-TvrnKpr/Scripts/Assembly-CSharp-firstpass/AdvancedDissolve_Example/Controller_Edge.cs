using System.Collections.Generic;
using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Edge : MonoBehaviour
	{
		public enum TEXTURE_TYPE
		{
			None = 0,
			Gradient = 1,
			MainMap = 2,
			Custom = 3
		}

		public enum SHAPE
		{
			Solid = 0,
			Smooth = 1,
			Smooth_Squared = 2
		}

		public bool updateGlobal;

		private List<Material> _materials;

		[Range(0f, 1f)]
		[Space(10f)]
		public float width;

		public SHAPE shape;

		public Color color;

		public float intensity;

		[Space(10f)]
		public Texture texture;

		public bool reverse;

		[Range(-1f, 1f)]
		public float alphaOffset;

		public float phaseOffset;

		[Range(1f, 10f)]
		public float blur;

		public bool isDynamic;

		[Space(10f)]
		public float GIMultyplier;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateShaderData()
		{
		}

		public void UpdateTextureTypeKeyword(TEXTURE_TYPE textureType)
		{
		}
	}
}
