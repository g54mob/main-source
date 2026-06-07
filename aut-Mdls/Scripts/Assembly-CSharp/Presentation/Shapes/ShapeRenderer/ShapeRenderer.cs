using System.Collections.Generic;
using Data.Shapes;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Presentation.Shapes.ShapeRenderer
{
	public class ShapeRenderer : MonoBehaviour
	{
		private static readonly int RenderTexture = Shader.PropertyToID("_RenderTexture");

		[SerializeField]
		private Transform _shapeParent;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private Transform _cameraOrigin;

		[SerializeField]
		private Material _rendererMaterial;

		[SerializeField]
		private Material _previewShapeMaterial;

		[SerializeField]
		private int _renderedTextureSize = 520;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		protected ShapeMeshLibrary _shapeMeshLibrary;

		[SerializeField]
		private float _minZoomLevel;

		[SerializeField]
		private float _maxZoomLevel;

		private GameObject _shapeLoaderObject;

		private ShapeHashPair _shapeHash;

		private Material _material;

		private RenderTexture _renderTexture;

		private bool _continuous;

		private bool _updateCamRot;

		private bool _inUse;

		private const int MAX_SHAPE_SIZE = 16;

		private List<Object> _sources = new List<Object>();

		public bool IsRendering => _camera.enabled;

		public bool InUse => _inUse;

		public void Setup()
		{
			_renderTexture = new RenderTexture(_renderedTextureSize, _renderedTextureSize, GraphicsFormat.R32G32B32A32_SFloat, GraphicsFormat.None);
			_camera.targetTexture = _renderTexture;
			_renderTexture.name = base.gameObject.name + " Render Texture";
			_renderTexture.Create();
			_material = Object.Instantiate(_rendererMaterial);
			_material.SetTexture(RenderTexture, _renderTexture);
			_camera.transform.forward = (_shapeParent.transform.position - _camera.transform.position).normalized;
			ResetRendering();
		}

		public Material StartRender(ShapeData shapeData, bool continuous, bool updateCameraRotation, Object source)
		{
			ResetRendering();
			if (!continuous && updateCameraRotation)
			{
				_cameraOrigin.rotation = _cameraLocator.Camera.transform.parent.rotation;
			}
			ShapeLoader shapeLoader = ShapeLoader.CreateFromShapeData(shapeData, _shapeMeshLibrary, _previewShapeMaterial, _shapeParent.position, Quaternion.identity);
			shapeLoader.transform.SetParent(_shapeParent);
			shapeLoader.Shape.Position = Vector3.zero;
			shapeLoader.transform.localPosition = Vector3.zero;
			Vector3Int bounds = shapeLoader.Shape.GetBounds();
			shapeLoader.transform.localPosition -= Vector3.up * ((float)bounds.y / 2f * 0.1f);
			_camera.orthographicSize = GetCameraOrthoSize(bounds);
			shapeLoader.gameObject.layer = _shapeParent.gameObject.layer;
			base.gameObject.SetActive(value: true);
			_camera.enabled = true;
			_shapeLoaderObject = shapeLoader.gameObject;
			_shapeHash = shapeData.GetShapeHash();
			_updateCamRot = updateCameraRotation;
			_continuous = continuous;
			_camera.Render();
			_inUse = true;
			AddSource(source);
			return _material;
		}

		public Material AddSource(Object source)
		{
			if (!_sources.Contains(source))
			{
				_sources.Add(source);
			}
			return _material;
		}

		private void RemoveSource(Object source)
		{
			_sources.Remove(source);
		}

		private float GetCameraOrthoSize(Vector3Int bounds)
		{
			float num = (float)bounds.x * 0.4f;
			float num2 = (float)bounds.y * 0.5f;
			float num3 = (float)bounds.z * 0.4f;
			return Mathf.Max(num + num2, num + num3, num2 + num3) * 0.1f;
		}

		public void StopRender(Object source)
		{
			RemoveSource(source);
			if (_sources.Count <= 0)
			{
				ResetRendering();
			}
		}

		private void ResetRendering()
		{
			StopContinuousRendering();
			_sources.Clear();
			_shapeHash = default(ShapeHashPair);
			_inUse = false;
		}

		private void StopContinuousRendering()
		{
			if (_shapeLoaderObject != null)
			{
				Object.Destroy(_shapeLoaderObject);
			}
			_camera.enabled = false;
			base.gameObject.SetActive(value: false);
		}

		public bool CompareShapeHash(ShapeHashPair shapeHash)
		{
			return _shapeHash == shapeHash;
		}

		private void Update()
		{
			if (IsRendering)
			{
				if (_updateCamRot)
				{
					_cameraOrigin.rotation = _cameraLocator.Camera.transform.parent.rotation;
				}
				if (!_continuous)
				{
					StopContinuousRendering();
				}
			}
		}
	}
}
