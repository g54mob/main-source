using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	public class LandscapeObjectListItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public Button Button;

		public RawImage Image;

		public TooltipSpawner Tooltip;

		public GameObject CameraPrefab;

		public RenderTexture RenderTexturePrefab;

		[SerializeField]
		private float _cameraPitch = -30f;

		[SerializeField]
		private float _cameraRotationSpeed = 32f;

		private Camera _camera;

		private Light _light;

		private RenderTexture _texture;

		private GameObject _item;

		private bool _hasRendered;

		private bool _mouseOver;

		private float _rotation;

		private Bounds _meshBounds;

		private float _cameraDistance;

		private void Awake()
		{
			_texture = UnityEngine.Object.Instantiate(RenderTexturePrefab);
			GameObject gameObject = UnityEngine.Object.Instantiate(CameraPrefab);
			_camera = gameObject.GetComponent<Camera>();
			_camera.targetTexture = _texture;
			_light = gameObject.GetComponentInChildren<Light>();
			Image.texture = _texture;
			_camera.enabled = false;
			GameObjectUtils.SetActive(_camera.gameObject, isActive: false);
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(_item);
			UnityEngine.Object.Destroy(_texture);
			UnityEngine.Object.Destroy(_camera.gameObject);
		}

		public void Update()
		{
			if (!(_item != null))
			{
				return;
			}
			bool flag = new Rect(0f, 0f, Screen.width, Screen.height).Contains(base.transform.position);
			_camera.enabled = flag;
			GameObjectUtils.SetActive(Image.gameObject, flag);
			GameObjectUtils.SetActive(_camera.gameObject, flag);
			if (!flag)
			{
				return;
			}
			if (_mouseOver || !_hasRendered)
			{
				_rotation -= Time.unscaledDeltaTime * _cameraRotationSpeed;
				GameObjectUtils.SetActive(_camera.gameObject, isActive: true);
			}
			else
			{
				float num = Mathf.DeltaAngle(_rotation, 0f);
				_rotation += num * Time.unscaledDeltaTime * _cameraRotationSpeed * 0.1f;
				if (num < 1f)
				{
					GameObjectUtils.SetActive(_camera.gameObject, isActive: false);
				}
			}
			FrameCamera();
			if (_camera.enabled)
			{
				_hasRendered = true;
			}
		}

		public void SetDefinition(RoomItemDefinition definition, int index)
		{
			GameObject prefab = definition.GetPrefab();
			if (prefab != null)
			{
				_item = UnityEngine.Object.Instantiate(prefab);
				_item.transform.position = Vector3.zero;
				_item.SetLayerRecursively(LayerMask.NameToLayer("Metagame"));
				_meshBounds = _item.RenderBounds();
				if (_meshBounds.size.sqrMagnitude > 0f)
				{
					float num = 1f / Mathf.Max(Mathf.Max(_meshBounds.extents.x, _meshBounds.extents.y), _meshBounds.extents.z);
					_meshBounds.center *= num;
					_meshBounds.extents *= num;
					_cameraDistance = _meshBounds.size.magnitude / 2f / Mathf.Sin(_camera.fieldOfView * ((float)Math.PI / 180f) / 2f);
					float num2 = 10f;
					Vector3 vector = new Vector3((float)(index & 0x1F) * num2, 10f, (float)(index >> 5) * num2);
					_meshBounds.center += vector;
					_item.transform.position = vector;
					_item.transform.localScale *= num;
				}
				_camera.nearClipPlane = _cameraDistance - _cameraDistance / 2f;
				_camera.farClipPlane = _cameraDistance + _cameraDistance / 2f;
				FrameCamera();
				Tooltip.TooltipText = definition.DebugTag;
			}
		}

		private void FrameCamera()
		{
			Vector3 vector = Quaternion.Euler(_cameraPitch, _rotation, 0f) * Vector3.forward * _cameraDistance + _meshBounds.center;
			_camera.transform.position = vector;
			_camera.transform.LookAt(_meshBounds.center);
			if (_light != null)
			{
				_light.range = Vector3.Distance(_meshBounds.center, vector) * 3f;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_mouseOver = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_mouseOver = false;
		}
	}
}
