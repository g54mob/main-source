using CTS.Rendering;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(1)]
	public class VisionDisplay : MonoBehaviour
	{
		[SerializeField]
		private Vision _vision;

		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private float _nearPlane = 0.05f;

		private Transform _visionAnchor;

		private bool _active;

		private RenderTexture _depthTexture;

		private RenderDepthRequest _lastRequest;

		private static readonly int SHDepthTexture = Shader.PropertyToID("_DepthTexture");

		private static readonly int SHWorldToViewMatrix = Shader.PropertyToID("_WorldToViewMatrix");

		private static readonly int SHViewToClipMatrix = Shader.PropertyToID("_ViewToClipMatrix");

		private static readonly int SHConeParams = Shader.PropertyToID("_ConeParams");

		private static LayerMask DepthMask => 1 << LayerMask.NameToLayer("Wall");

		private void Awake()
		{
			if (!_vision)
			{
				_vision = GetComponent<Vision>();
			}
			if (!_meshRenderer)
			{
				_meshRenderer = GetComponent<MeshRenderer>();
			}
			_visionAnchor = _meshRenderer.transform.parent;
			_depthTexture = new RenderTexture(256, 64, 24, RenderTextureFormat.Depth, RenderTextureReadWrite.Linear);
			UpdateShader();
			EnableDisplay(value: false);
		}

		private void Update()
		{
			if (_meshRenderer.gameObject.activeSelf && (_lastRequest == null || _lastRequest.WasRendered))
			{
				_lastRequest = RenderDepthRequests.CreateNew(_depthTexture, base.transform.position, base.transform.rotation, _vision.Distance, _nearPlane, _vision.Angle, DepthMask);
				_meshRenderer.material.SetMatrix(SHWorldToViewMatrix, GL.GetGPUProjectionMatrix(_lastRequest.TemporaryCamera.projectionMatrix, renderIntoTexture: true) * _lastRequest.TemporaryCamera.worldToCameraMatrix);
			}
		}

		private void UpdateShader()
		{
			_visionAnchor.localScale = Vector3.one * _vision.Distance;
			Material material = _meshRenderer.material;
			material.SetTexture(SHDepthTexture, _depthTexture);
			material.SetVector(SHConeParams, new Vector4(_vision.Distance, _vision.Angle));
			_meshRenderer.material = material;
		}

		private void OnEnable()
		{
			if (_active)
			{
				EnableDisplay(value: true);
			}
		}

		private void OnDisable()
		{
			EnableDisplay(value: false);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void OnValidate()
		{
			if (Application.isPlaying && (bool)_meshRenderer && (bool)_visionAnchor)
			{
				UpdateShader();
			}
		}

		private void OnDestroy()
		{
			if (_lastRequest != null && !_lastRequest.WasRendered)
			{
				RenderDepthRequests.ClearRequest(_lastRequest);
			}
		}

		private void EnableDisplay(bool value)
		{
			if ((bool)_meshRenderer)
			{
				_meshRenderer.gameObject.SetActive(value);
			}
		}

		public void SetVisionDisplay(bool p_value)
		{
			if (base.enabled)
			{
				_active = p_value;
				EnableDisplay(_active);
			}
		}
	}
}
