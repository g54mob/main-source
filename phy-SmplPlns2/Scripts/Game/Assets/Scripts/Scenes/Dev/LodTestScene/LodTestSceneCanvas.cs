using Assets.Scripts.Misc.SimpleBehaviours.Camera;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scenes.Dev.LodTestScene
{
	public class LodTestSceneCanvas : MonoBehaviour
	{
		[SerializeField]
		private SimpleCameraOrbitScript _camera;

		[SerializeField]
		private TextMeshProUGUI _distanceLabel;

		[SerializeField]
		private Slider _distanceSlider;

		protected virtual void Awake()
		{
			_distanceSlider.onValueChanged.AddListener(OnDistanceValueChanged);
		}

		protected virtual void Update()
		{
			_distanceSlider.minValue = _camera.Camera.nearClipPlane;
			_distanceSlider.maxValue = _camera.Camera.farClipPlane;
			_distanceSlider.SetValueWithoutNotify(_camera.CameraToFocalPointDistance);
			_distanceLabel.text = _camera.CameraToFocalPointDistance.ToString("N0") + " m";
		}

		private void OnDistanceValueChanged(float distance)
		{
			_camera.CameraToFocalPointDistance = distance;
		}
	}
}
