using ModApi.Craft;
using ModApi.Flight.GameView;
using UnityEngine;

namespace Assets.Scripts.Flight.Effects
{
	public class ShakeCameraByFlightConditions : MonoBehaviour
	{
		private ICameraShake _cameraShake;

		[SerializeField]
		private float _dragIntensity;

		[SerializeField]
		private float _thrustIntensity;

		[SerializeField]
		private float _hoverIntensity;

		private float DragFreq()
		{
			return 7f;
		}

		private float ThrustFreq()
		{
			return 5f;
		}

		private float HoverFreq()
		{
			return 3f;
		}

		private float DragIntensity()
		{
			return _dragIntensity;
		}

		private float ThrustIntensity()
		{
			return _thrustIntensity;
		}

		private float HoverIntensity()
		{
			return _hoverIntensity;
		}

		private void OnDestroy()
		{
			_cameraShake?.RemoveShake(DragIntensity, DragFreq);
			_cameraShake?.RemoveShake(ThrustIntensity, ThrustFreq);
			_cameraShake?.RemoveShake(HoverIntensity, HoverFreq);
		}

		private void OnDisable()
		{
			_dragIntensity = (_thrustIntensity = (_hoverIntensity = 0f));
		}

		private void Start()
		{
			_cameraShake = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.CameraShake;
			_cameraShake.AddShake(DragIntensity, DragFreq);
			_cameraShake.AddShake(ThrustIntensity, ThrustFreq);
			_cameraShake.AddShake(HoverIntensity, HoverFreq);
		}

		private void Update()
		{
			ICraftNode craftNode = FlightSceneScript.Instance.CraftNode;
			if (!craftNode.IsDestroyed)
			{
				ICraftScript craftScript = craftNode.CraftScript;
				float num = Vector3.Distance(base.transform.position, craftNode.FramePosition);
				num = Mathf.Min(1f, 10f * craftScript.Mass / Mathf.Max(float.Epsilon, num * num));
				float num2 = 0.1f * craftScript.FlightData.CurrentEngineThrust / Mathf.Max(float.Epsilon, craftScript.Mass);
				_dragIntensity = Mathf.Lerp(_dragIntensity, num * Mathf.Max(0f, 5f * craftScript.DragAcceleration.magnitude / Mathf.Max(craftScript.AtmosphereSample.SpeedOfSound, 100f) - 0.2f), Time.deltaTime);
				_thrustIntensity = Mathf.Lerp(_thrustIntensity, num * Mathf.Max(0f, 0.2f * (num2 - 3f)), Time.deltaTime);
				_hoverIntensity = Mathf.Lerp(_hoverIntensity, num * Mathf.SmoothStep(0f, 1f, num2 * (2f - num2)) / Mathf.Max(1f, craftScript.SurfaceVelocity.magnitude), Time.deltaTime);
			}
			else
			{
				_dragIntensity = 0f;
				_thrustIntensity = 0f;
				_hoverIntensity = 0f;
			}
		}
	}
}
