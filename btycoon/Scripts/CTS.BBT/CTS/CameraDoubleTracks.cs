using System;
using System.Collections;
using Cinemachine;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class CameraDoubleTracks : MonoBehaviour
	{
		[SerializeField]
		private CinemachineDollyCart _positionTrack;

		[SerializeField]
		private AnimationCurve _positionCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private CinemachineDollyCart _lookAtTrack;

		[SerializeField]
		private AnimationCurve _lookAtCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private float _duration;

		[SerializeField]
		private bool _useUnscaledTime;

		private Camera _camera;

		private void Start()
		{
			_camera = Camera.main;
		}

		[Button(null, EButtonEnableMode.Playmode)]
		public void Play()
		{
			StopAllCoroutines();
			if (!(_camera == null))
			{
				StartCoroutine(Routine());
			}
		}

		private IEnumerator Routine()
		{
			Func<float> getDeltaTime = (_useUnscaledTime ? ((Func<float>)(() => Time.unscaledDeltaTime)) : ((Func<float>)(() => Time.deltaTime)));
			for (float time = 0f; time < 1f; time += getDeltaTime() / _duration)
			{
				_positionTrack.m_Position = _positionCurve.Evaluate(time);
				_lookAtTrack.m_Position = _lookAtCurve.Evaluate(time);
				_camera.transform.position = _positionTrack.transform.position;
				_camera.transform.LookAt(_lookAtTrack.transform.position, Vector3.up);
				yield return null;
			}
		}
	}
}
