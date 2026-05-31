using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class CameraFadeTraveling : MonoBehaviour
	{
		private Vector3 _originPosition;

		private Vector3 _destinationPosition;

		private bool _onDestination;

		private bool _onMovement;

		[SerializeField]
		private List<StringKey> _buttonsToDisable = new List<StringKey>();

		private readonly LockToggle _lockToggle = new LockToggle();

		[SerializeField]
		private Vector3 travelingRelativePositionDestination;

		[SerializeField]
		private float travelingTime;

		[SerializeField]
		private AnimationCurve travelingPositionCurve;

		public Action onBeginMovement;

		public Action onFinishedMovement;

		public bool startToFadeIn;

		private void Start()
		{
			_lockToggle.Lock();
		}

		public void StartTraveling(Vector3 p_destination)
		{
			if (!_onMovement && !_onDestination)
			{
				_originPosition = MonoSingleton<CameraTravelingHandler>.Instance.transform.position;
				_destinationPosition = p_destination;
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

		private void OnDisable()
		{
			_lockToggle.Clear();
		}

		private void LockButtons()
		{
			foreach (StringKey item in _buttonsToDisable)
			{
				if (CTSSelectable.TryGet(item, out var controller))
				{
					_lockToggle.Add(controller);
				}
			}
		}

		private IEnumerator StartTravelingRoutine()
		{
			LockButtons();
			onBeginMovement?.Invoke();
			if (startToFadeIn)
			{
				FadeControler.instance?.FadeIn(0.5f);
			}
			else
			{
				FadeControler.instance?.FadeOut(0.5f);
			}
			MonoSingleton<CameraTravelingHandler>.Instance.LockAll(p_toLockAll: true);
			_onMovement = true;
			float timer = 0f;
			while (timer < travelingTime)
			{
				timer += Time.unscaledDeltaTime;
				float time = Mathf.InverseLerp(0f, travelingTime, timer);
				MonoSingleton<CameraTravelingHandler>.Instance.transform.position = Vector3.Lerp(_originPosition, _destinationPosition, travelingPositionCurve.Evaluate(time));
				yield return null;
			}
			MonoSingleton<CameraTravelingHandler>.Instance.transform.position = _destinationPosition;
			_onDestination = true;
			_onMovement = false;
			onFinishedMovement?.Invoke();
			_lockToggle.Clear();
		}

		private IEnumerator BackToOriginRoutine()
		{
			LockButtons();
			onBeginMovement?.Invoke();
			if (!startToFadeIn)
			{
				FadeControler.instance?.FadeIn(0.5f);
			}
			else
			{
				FadeControler.instance?.FadeOut(0.5f);
			}
			_onMovement = true;
			_onDestination = false;
			float timer = travelingTime;
			while (timer > 0f)
			{
				timer -= Time.unscaledDeltaTime;
				float time = Mathf.InverseLerp(0f, travelingTime, timer);
				MonoSingleton<CameraTravelingHandler>.Instance.transform.position = Vector3.Lerp(_originPosition, _destinationPosition, travelingPositionCurve.Evaluate(time));
				yield return null;
			}
			MonoSingleton<CameraTravelingHandler>.Instance.transform.position = _originPosition;
			MonoSingleton<CameraTravelingHandler>.Instance.LockAll(p_toLockAll: false);
			_onMovement = false;
			onFinishedMovement?.Invoke();
			_lockToggle.Clear();
		}

		public void TeleportMainCameraHere()
		{
			MonoSingleton<CameraTravelingHandler>.Instance.transform.position = base.transform.position;
			MonoSingleton<CameraTravelingHandler>.Instance.transform.rotation = base.transform.rotation;
		}

		public void TeleportMeToMainCamera()
		{
			base.transform.position = MonoSingleton<CameraTravelingHandler>.Instance.transform.position;
			base.transform.rotation = MonoSingleton<CameraTravelingHandler>.Instance.transform.rotation;
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestTravelingStart()
		{
			Vector3 p_destination = MonoSingleton<CameraTravelingHandler>.Instance.transform.position + MonoSingleton<CameraTravelingHandler>.Instance.transform.forward * travelingRelativePositionDestination.z + MonoSingleton<CameraTravelingHandler>.Instance.transform.right * travelingRelativePositionDestination.x + MonoSingleton<CameraTravelingHandler>.Instance.transform.up * travelingRelativePositionDestination.y;
			StartTraveling(p_destination);
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestBackTraveling()
		{
			BackToOrigin();
		}
	}
}
