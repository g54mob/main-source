using System;
using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	[ExecuteInEditMode]
	public class GPUISphericalVegetationDrawer : MonoBehaviour
	{
		[Serializable]
		public struct VegetationSetting
		{
			public GameObject prefab;

			public GPUIProfile profile;

			[Range(0f, 10000f)]
			public int spawnAmount;

			public Vector2 minMaxScale;

			[NonSerialized]
			public Matrix4x4[] matrices;
		}

		[SerializeField]
		public Transform sphereTransform;

		[SerializeField]
		public float scaleMultiplier = 1f;

		[SerializeField]
		public int seed;

		[SerializeField]
		public List<VegetationSetting> vegetationSettings;

		[NonSerialized]
		private int[] _renderKeys;

		[NonSerialized]
		private Matrix4x4 _previousMatrix;

		[NonSerialized]
		private bool _isInitialized;

		private void OnEnable()
		{
			if (vegetationSettings != null && vegetationSettings.Count != 0 && !(sphereTransform == null))
			{
				RegisterRenderers();
			}
		}

		private void OnDisable()
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

		public void RegisterRenderers()
		{
			DisposeRenderers();
			CreateMatrices();
			_renderKeys = new int[vegetationSettings.Count];
			for (int i = 0; i < vegetationSettings.Count; i++)
			{
				if (vegetationSettings[i].matrices != null && GPUICoreAPI.RegisterRenderer(this, vegetationSettings[i].prefab, vegetationSettings[i].profile, out _renderKeys[i]))
				{
					GPUICoreAPI.SetTransformBufferData(_renderKeys[i], vegetationSettings[i].matrices);
				}
			}
			_previousMatrix.SetTRS(sphereTransform.position, Quaternion.identity, sphereTransform.lossyScale);
			GPUICoreAPI.AddCameraEventOnPreCull(HandleFloatingOrigin);
			_isInitialized = true;
		}

		public void DisposeRenderers()
		{
			_isInitialized = false;
			GPUICoreAPI.RemoveCameraEventOnPreCull(HandleFloatingOrigin);
			if (_renderKeys == null)
			{
				return;
			}
			for (int i = 0; i < _renderKeys.Length; i++)
			{
				if (_renderKeys[i] != 0)
				{
					GPUICoreAPI.DisposeRenderer(_renderKeys[i]);
				}
			}
			_renderKeys = null;
		}

		public void CreateMatrices()
		{
			for (int i = 0; i < vegetationSettings.Count; i++)
			{
				if (seed != 0)
				{
					UnityEngine.Random.InitState(seed + i);
				}
				VegetationSetting value = vegetationSettings[i];
				Matrix4x4[] array = new Matrix4x4[vegetationSettings[i].spawnAmount];
				Vector3 position = sphereTransform.position;
				Vector3 vector = sphereTransform.localScale * scaleMultiplier;
				for (int j = 0; j < array.Length; j++)
				{
					Vector3 vector2 = Vector3.Normalize(UnityEngine.Random.insideUnitSphere) * vector.x / 2f + position;
					Quaternion q = Quaternion.FromToRotation(Vector3.up, vector2 - position) * Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
					array[j] = Matrix4x4.TRS(vector2, q, Vector3.one * UnityEngine.Random.Range(vegetationSettings[i].minMaxScale.x, vegetationSettings[i].minMaxScale.y));
				}
				value.matrices = array;
				vegetationSettings[i] = value;
			}
		}

		private void HandleFloatingOrigin(GPUICameraData cameraData)
		{
			Matrix4x4 localToWorldMatrix = sphereTransform.localToWorldMatrix;
			if (!(localToWorldMatrix == _previousMatrix))
			{
				Matrix4x4 matrixOffset = localToWorldMatrix * _previousMatrix.inverse;
				for (int i = 0; i < _renderKeys.Length; i++)
				{
					GPUITransformBufferUtility.ApplyMatrixOffsetToTransforms(_renderKeys[i], matrixOffset);
				}
				_previousMatrix = localToWorldMatrix;
			}
		}
	}
}
