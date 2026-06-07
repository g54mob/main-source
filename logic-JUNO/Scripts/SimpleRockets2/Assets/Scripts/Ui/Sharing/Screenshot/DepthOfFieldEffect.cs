using Assets.Scripts.Cameras;
using ModApi;
using UI.Xml;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace Assets.Scripts.Ui.Sharing.Screenshot
{
	public class DepthOfFieldEffect
	{
		private Camera _camera;

		private DepthOfField _depthOfField;

		private bool _enabled;

		private Transform _focalTransform;

		private XmlLayout _layout;

		private SliderControl _sliderAperture;

		private SliderControl _sliderFocalSize;

		private Vector3 _targetPosition = Vector3.zero;

		public bool Available => _depthOfField != null;

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (_enabled != value)
				{
					if (value)
					{
						Activate();
					}
					else
					{
						Deactivate();
					}
				}
			}
		}

		public DepthOfFieldEffect(XmlLayout xmlLayout)
		{
			_layout = xmlLayout;
			_sliderAperture = new SliderControl(xmlLayout.GetElementById("slider-aperture"));
			_sliderAperture.Slider.value = 0.5f;
			_sliderAperture.Slider.onValueChanged.AddListener(delegate(float x)
			{
				OnApertureSliderChanged(x);
			});
			_sliderFocalSize = new SliderControl(xmlLayout.GetElementById("slider-focal-size"));
			_sliderFocalSize.Slider.value = 0.5f;
			_sliderFocalSize.Slider.onValueChanged.AddListener(delegate(float x)
			{
				OnFocalSizeSliderChanged(x);
			});
			_camera = GetCamera();
			_depthOfField = _camera?.gameObject.GetComponent<DepthOfField>();
			if (!Available)
			{
				xmlLayout.GetElementById("effect-button-dof").SetActive(active: false);
			}
		}

		public void Update()
		{
			if (Enabled)
			{
				Vector3 position = _layout.GetElementById("camera-focus").rectTransform.position;
				Ray ray = Utilities.ScreenPointToRay(_camera, new Vector3(position.x, position.y, 0f));
				RaycastHit hitInfo = default(RaycastHit);
				int num = -1543503871;
				if (Game.InDesignerScene)
				{
					num |= 0x2000;
				}
				if (Physics.Raycast(ray, out hitInfo, 10000f, num, QueryTriggerInteraction.Ignore))
				{
					_targetPosition = hitInfo.point;
				}
				else
				{
					_targetPosition = _camera.transform.position + _camera.transform.forward * 20f;
				}
				_focalTransform.position = Vector3.Lerp(_focalTransform.position, _targetPosition, Time.unscaledDeltaTime * 2f);
			}
		}

		private void Activate()
		{
			if (_depthOfField != null)
			{
				if (_focalTransform == null)
				{
					_focalTransform = new GameObject("DepthOfFieldFocus").transform;
					_focalTransform.position = _camera.transform.position + _camera.transform.forward * 20f;
				}
				_depthOfField.focalTransform = _focalTransform;
				_depthOfField.enabled = true;
				_enabled = true;
				SceneCameraScript.UpdateDepthTextureState();
			}
			UpdateDepthOfField();
		}

		private void Deactivate()
		{
			if (_depthOfField != null)
			{
				_depthOfField.focalTransform = null;
				_depthOfField.enabled = false;
				if (_focalTransform != null)
				{
					Object.Destroy(_focalTransform.gameObject);
					_focalTransform = null;
				}
			}
			_enabled = false;
			SceneCameraScript.UpdateDepthTextureState();
			UpdateDepthOfField();
		}

		private Camera GetCamera()
		{
			if (Game.InDesignerScene)
			{
				return Game.Instance.Designer.DesignerCamera.Camera;
			}
			if (Game.InFlightScene)
			{
				return Game.Instance.FlightScene.ViewManager.GameView.GameCamera.NearCamera;
			}
			return null;
		}

		private void OnApertureSliderChanged(float x)
		{
			UpdateDepthOfField();
		}

		private void OnFocalSizeSliderChanged(float x)
		{
			UpdateDepthOfField();
		}

		private void UpdateDepthOfField()
		{
			XmlElement elementById = _layout.GetElementById("effect-button-dof");
			XmlElement elementById2 = _layout.GetElementById("effect-panel-dof");
			if (Enabled)
			{
				elementById2.SetActive(active: true);
				elementById.AddClass("btn-primary");
				_depthOfField.blurSampleCount = DepthOfField.BlurSampleCount.Low;
				_depthOfField.enabled = true;
				_depthOfField.focalSize = _sliderFocalSize.Slider.value;
				_depthOfField.aperture = _sliderAperture.Slider.value;
				_depthOfField.focalLength = 1f;
				_depthOfField.maxBlurSize = 5f;
				_sliderFocalSize.ValueText.text = Utilities.FormatPercentage(_sliderFocalSize.Slider.value);
				_sliderAperture.ValueText.text = Utilities.FormatPercentage(_sliderAperture.Slider.value);
			}
			else
			{
				elementById2.SetActive(active: false);
				elementById.RemoveClass("btn-primary");
				_depthOfField.enabled = false;
			}
		}
	}
}
