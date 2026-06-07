using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancerPro
{
	[ExecuteInEditMode]
	public class GPUINoGOPrefabDrawer : MonoBehaviour
	{
		public GameObject prefabObject;

		public GPUIProfile profile;

		public int instanceCount = 1000;

		public float spacing = 1.5f;

		public bool enableColorVariations;

		public string variationKeyword = "GPUI_COLOR_VARIATION";

		public string variationBufferName = "gpuiProFloat4Variation";

		public Text instanceCountText;

		private int _rendererKey;

		private GraphicsBuffer _colorBuffer;

		private bool _isInitialized;

		public void OnEnable()
		{
			RegisterRenderers();
		}

		public void OnDisable()
		{
			DisposeRenderers();
		}

		private void OnValidate()
		{
			if (GPUIRenderingSystem.IsActive && _isInitialized)
			{
				RegisterRenderers();
			}
		}

		private void RegisterRenderers()
		{
			DisposeRenderers();
			_isInitialized = true;
			if (instanceCount <= 0 || prefabObject == null)
			{
				return;
			}
			GPUICoreAPI.RegisterRenderer(this, prefabObject, (profile == null) ? GPUIProfile.DefaultProfile : profile, out _rendererKey);
			GPUICoreAPI.SetTransformBufferData(_rendererKey, GenerateMatrixArray());
			Renderer[] componentsInChildren = prefabObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] sharedMaterials = componentsInChildren[i].sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (!(material == null))
					{
						if (enableColorVariations)
						{
							material.EnableKeyword(variationKeyword);
							GPUICoreAPI.AddMaterialPropertyOverride(_rendererKey, variationBufferName, GenerateColorBuffer());
						}
						else
						{
							material.DisableKeyword(variationKeyword);
						}
					}
				}
			}
			if (instanceCountText != null)
			{
				instanceCountText.text = instanceCount.FormatNumberWithSuffix();
			}
		}

		private void DisposeRenderers()
		{
			_isInitialized = false;
			if (_rendererKey != 0)
			{
				GPUICoreAPI.DisposeRenderer(_rendererKey);
				_rendererKey = 0;
			}
			if (_colorBuffer != null)
			{
				_colorBuffer.Dispose();
				_colorBuffer = null;
			}
		}

		private Matrix4x4[] GenerateMatrixArray()
		{
			Matrix4x4[] array = new Matrix4x4[instanceCount];
			Matrix4x4 matrix = Matrix4x4.identity;
			int num = Mathf.FloorToInt(Mathf.Pow(instanceCount, 1f / 3f));
			int num2 = num * num;
			Vector3 position = base.transform.position;
			for (int i = 0; i < instanceCount; i++)
			{
				matrix.SetPosition(new Vector3(i % num, i / num2, i / num % num) * spacing + position);
				array[i] = matrix;
			}
			return array;
		}

		private GraphicsBuffer GenerateColorBuffer()
		{
			if (_colorBuffer != null)
			{
				_colorBuffer.Dispose();
			}
			Color[] array = new Color[instanceCount];
			Random.InitState(42);
			for (int i = 0; i < instanceCount; i++)
			{
				array[i] = Random.ColorHSV();
			}
			_colorBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, instanceCount, Marshal.SizeOf(typeof(Color)));
			_colorBuffer.SetData(array);
			return _colorBuffer;
		}
	}
}
