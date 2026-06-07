using System;
using UnityEngine;

namespace JBooth.MicroSplat
{
	[ExecuteInEditMode]
	public class MicroSplatBlendableObject : MonoBehaviour
	{
		[HideInInspector]
		public MicroSplatObject msObject;

		public float blendDistance = 1f;

		public float normalBlendDistance = 1f;

		[Range(0.0001f, 1f)]
		public float blendContrast = 0.0001f;

		[Range(0.25f, 4f)]
		public float blendCurve = 1f;

		[Range(0f, 1f)]
		public float slopeFilter = 1f;

		[Range(1f, 40f)]
		public float slopeContrast = 20f;

		[Range(0f, 1f)]
		public float slopeNoise = 0.35f;

		private static MaterialPropertyBlock props;

		[Range(1f, 80f)]
		public float matrixBlend = 1f;

		[Range(0f, 1f)]
		public float snowDampening;

		[Range(0f, 1f)]
		public float snowWidth;

		public float noiseScale = 1f;

		public bool doSnow = true;

		public bool doTerrainBlend = true;

		public Texture2D normalFromObject;

		private void OnEnable()
		{
			Sync();
		}

		private void Start()
		{
			Sync();
		}

		public Bounds TransformBounds(Bounds localBounds)
		{
			Vector3 center = base.transform.TransformPoint(localBounds.center);
			Vector3 extents = localBounds.extents;
			Vector3 vector = base.transform.TransformVector(extents.x, 0f, 0f);
			Vector3 vector2 = base.transform.TransformVector(0f, extents.y, 0f);
			Vector3 vector3 = base.transform.TransformVector(0f, 0f, extents.z);
			extents.x = Mathf.Abs(vector.x) + Mathf.Abs(vector2.x) + Mathf.Abs(vector3.x);
			extents.y = Mathf.Abs(vector.y) + Mathf.Abs(vector2.y) + Mathf.Abs(vector3.y);
			extents.z = Mathf.Abs(vector.z) + Mathf.Abs(vector2.z) + Mathf.Abs(vector3.z);
			return new Bounds
			{
				center = center,
				extents = extents
			};
		}

		public void Sync()
		{
			if (msObject == null)
			{
				Debug.LogWarning("Terrain Blending: No Terrain Found");
				return;
			}
			Material blendMatInstance = msObject.GetBlendMatInstance();
			if (blendMatInstance == null)
			{
				Debug.LogWarning("Terrain Blending: No blend instance found from " + msObject.name);
				return;
			}
			blendMatInstance.enableInstancing = false;
			Renderer component = GetComponent<Renderer>();
			Material[] array = component.sharedMaterials;
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == blendMatInstance && blendMatInstance != null)
				{
					flag = true;
				}
				else if (array[i] == null || array[i].shader == null || array[i].shader.name.Contains("_TerrainObjectBlend"))
				{
					flag = true;
					array[i] = blendMatInstance;
					component.sharedMaterials = array;
				}
			}
			if (!flag)
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = blendMatInstance;
				component.sharedMaterials = array;
			}
			if (props == null)
			{
				props = new MaterialPropertyBlock();
			}
			props.Clear();
			props.SetVector("_TerrainBlendParams", new Vector4(blendDistance, blendContrast, msObject.transform.position.y, blendCurve));
			props.SetVector("_TerrainBlendParams2", new Vector4(matrixBlend, 0f, 0f, 0f));
			props.SetVector("_SlopeBlendParams", new Vector4(slopeFilter, slopeContrast, slopeNoise, normalBlendDistance));
			props.SetVector("_SnowBlendParams", new Vector4(snowWidth, 0f, 0f, 0f));
			props.SetFloat("_TBNoiseScale", noiseScale);
			props.SetVector("_FeatureFilters", new Vector4(doTerrainBlend ? 0f : 1f, doSnow ? 0f : 1f, 0f, 0f));
			if (normalFromObject != null)
			{
				props.SetTexture("_NormalOriginal", normalFromObject);
			}
			component.SetPropertyBlock(props);
		}
	}
}
