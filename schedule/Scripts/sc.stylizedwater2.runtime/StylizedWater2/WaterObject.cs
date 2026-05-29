using System.Collections.Generic;
using UnityEngine;

namespace StylizedWater2
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("Stylized Water 2/Water Object")]
	public class WaterObject : MonoBehaviour
	{
		public static readonly List<WaterObject> Instances;

		public Material material;

		public MeshFilter meshFilter;

		public MeshRenderer meshRenderer;

		private static Vector3 s_PositionOffset;

		private static readonly int _WaterPositionOffset;

		private static float m_customTimeValue;

		private static readonly int CustomTimeID;

		private MaterialPropertyBlock _props;

		public static Vector3 PositionOffset
		{
			internal get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public static float CustomTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MaterialPropertyBlock props
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		private void CreatePropertyBlock(Renderer sourceRenderer)
		{
		}

		private void Reset()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnValidate()
		{
		}

		public Material FetchWaterMaterial()
		{
			return null;
		}

		public void ApplyInstancedProperties()
		{
		}

		public bool CanTouch(Vector3 position)
		{
			return false;
		}

		public void AssignMesh(Mesh mesh)
		{
		}

		public void AssignMaterial(Material newMaterial)
		{
		}

		public static WaterObject New(Material waterMaterial = null, Mesh mesh = null)
		{
			return null;
		}

		public static WaterObject Find(Vector3 position, bool rotationSupport)
		{
			return null;
		}
	}
}
