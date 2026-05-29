using System.Collections;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class CameraTravelingControler : MonoBehaviour
	{
		private Vector3 _originPosition;

		private Vector3 _originLookAt;

		private Vector3 _destinationPosition;

		private CameraTravelingHandler _cameraHandler;

		private bool _onDestination;

		private bool _onMovement;

		[SerializeField]
		private float travelingTime;

		[SerializeField]
		private AnimationCurve travelingPositionCurve;

		[SerializeField]
		private AnimationCurve travelingRotationCurve;

		[SerializeField]
		private Transform viewTarget;

		[SerializeField]
		private UnityEvent onDestination;

		public void StartTraveling(CameraTravelingHandler p_cameraTravelingHandler, Transform p_destination)
		{
			if (!_onMovement && !_onDestination)
			{
				_originPosition = p_cameraTravelingHandler.transform.position;
				_originLookAt = p_cameraTravelingHandler.transform.position + p_cameraTravelingHandler.transform.forward * 20f;
				_destinationPosition = p_destination.position;
				_cameraHandler = p_cameraTravelingHandler;
				StartCoroutine(StartTravelingRoutine());
			}
		}

		public void BackToOrigin()
		{
			if (!_onMovement && _onDestination)
			{
				StartCoroutine(BackToOriginRoutine());
			}
		}

		private IEnumerator StartTravelingRoutine()
		{
			_cameraHandler.LockAll(p_toLockAll: true);
			_onMovement = true;
			float timer = 0f;
			while (timer < travelingTime)
			{
				timer += Time.deltaTime;
				float time = Mathf.InverseLerp(0f, travelingTime, timer);
				_cameraHandler.transform.position = Vector3.Lerp(_originPosition, _destinationPosition, travelingPositionCurve.Evaluate(time));
				_cameraHandler.transform.LookAt(Vector3.Lerp(_originLookAt, viewTarget.position, travelingRotationCurve.Evaluate(time)));
				yield return null;
			}
			_cameraHandler.transform.position = _destinationPosition;
			_cameraHandler.transform.LookAt(viewTarget.position);
			onDestination?.Invoke();
			_onDestination = true;
			_onMovement = false;
		}

		private IEnumerator BackToOriginRoutine()
		{
			_onMovement = true;
			_onDestination = false;
			float timer = travelingTime;
			while (timer > 0f)
			{
				timer -= Time.deltaTime;
				float time = Mathf.InverseLerp(0f, travelingTime, timer);
				_cameraHandler.transform.position = Vector3.Lerp(_originPosition, _destinationPosition, travelingPositionCurve.Evaluate(time));
				_cameraHandler.transform.LookAt(Vector3.Lerp(_originLookAt, viewTarget.position, travelingRotationCurve.Evaluate(time)));
				yield return null;
			}
			_cameraHandler.transform.position = _originPosition;
			_cameraHandler.transform.LookAt(_originLookAt);
			_cameraHandler.LockAll(p_toLockAll: false);
			_cameraHandler = null;
			_onMovement = false;
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestTravelingStart()
		{
			StartTraveling(MonoSingleton<CameraTravelingHandler>.Instance, base.transform);
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestBackTraveling()
		{
			BackToOrigin();
		}
	}
}
