using System;
using System.Collections.Generic;
using ModApi;
using ModApi.Flight.GameView;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Flight.Effects
{
	public class CameraShakeScript : MonoBehaviour, ICameraShake
	{
		private Vector3 _currentRotationOffset;

		private FlightSettings _flightSettings;

		private IGameCamera _gameCamera;

		private Dictionary<Tuple<CameraShakeFloat, CameraShakeFloat>, Vector3> _offsets = new Dictionary<Tuple<CameraShakeFloat, CameraShakeFloat>, Vector3>();

		private List<Tuple<CameraShakeFloat, CameraShakeFloat>> _shakes = new List<Tuple<CameraShakeFloat, CameraShakeFloat>>();

		private List<Tuple<CameraShakeFloat, CameraShakeFloat>> _shakesAwaitingRemoval = new List<Tuple<CameraShakeFloat, CameraShakeFloat>>();

		private Dictionary<Tuple<CameraShakeFloat, CameraShakeFloat>, float> _shakeTimes = new Dictionary<Tuple<CameraShakeFloat, CameraShakeFloat>, float>();

		[SerializeField]
		private float _subFrequency;

		[SerializeField]
		private float _subIntensity;

		[SerializeField]
		private float _testFrequency;

		[SerializeField]
		private float _testIntensity;

		public void AddShake(CameraShakeFloat intensity, CameraShakeFloat frequency)
		{
			Tuple<CameraShakeFloat, CameraShakeFloat> tuple = new Tuple<CameraShakeFloat, CameraShakeFloat>(intensity, frequency);
			if (!_shakes.Contains(tuple))
			{
				_shakes.Add(tuple);
				_offsets[tuple] = Vector3.zero;
				_shakeTimes.Add(tuple, 0f);
				if (_shakesAwaitingRemoval.Contains(tuple))
				{
					_shakesAwaitingRemoval.Remove(tuple);
				}
				return;
			}
			throw new Exception("Already contains a shake with the given intensity and frequency functions");
		}

		public void RemoveShake(CameraShakeFloat intensity, CameraShakeFloat frequency)
		{
			Tuple<CameraShakeFloat, CameraShakeFloat> tuple = null;
			foreach (Tuple<CameraShakeFloat, CameraShakeFloat> shake in _shakes)
			{
				if (intensity == shake.Item1 && frequency == shake.Item2)
				{
					tuple = shake;
					break;
				}
			}
			if (tuple != null)
			{
				_shakes.Remove(tuple);
				_shakeTimes.Remove(tuple);
				_shakesAwaitingRemoval.Add(tuple);
				return;
			}
			throw new Exception("Couldn't find camera shake with intensity method " + intensity.Target.GetType().FullName + "." + intensity.Method.Name + " and frequency method " + frequency.Target.GetType().FullName + "." + frequency.Method.Name);
		}

		[ContextMenu("Add Sub Shake")]
		private void AddSubShake()
		{
			AddShake(GetSubShakeIntensity, GetSubShakeFrequency);
		}

		private void Awake()
		{
			_flightSettings = Game.Instance.Settings.Game.Flight;
			_gameCamera = GetComponent<IGameCamera>();
			_gameCamera.RegisterRotationOffset(GetShakeRotation);
		}

		private Vector3 GetShakeRotation()
		{
			return _currentRotationOffset;
		}

		private float GetSubShakeFrequency()
		{
			return _subFrequency;
		}

		private float GetSubShakeIntensity()
		{
			return _subIntensity;
		}

		private float GetTestShakeFrequency()
		{
			return _testFrequency;
		}

		private float GetTestShakeIntensity()
		{
			return _testIntensity * (float)_flightSettings.CameraShake;
		}

		private void OnDisable()
		{
			RemoveShake(GetTestShakeIntensity, GetTestShakeFrequency);
			RemoveShake(GetSubShakeIntensity, GetSubShakeFrequency);
		}

		private void OnEnable()
		{
			AddShake(GetTestShakeIntensity, GetTestShakeFrequency);
			AddShake(GetSubShakeIntensity, GetSubShakeFrequency);
		}

		[ContextMenu("Remove Sub Shake")]
		private void RemoveSubShake()
		{
			RemoveShake(GetSubShakeIntensity, GetSubShakeFrequency);
		}

		private void Update()
		{
			_currentRotationOffset = Vector3.zero;
			if ((float)_flightSettings.CameraShake == 0f)
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			foreach (Tuple<CameraShakeFloat, CameraShakeFloat> shake in _shakes)
			{
				float num = shake.Item2();
				float num2 = shake.Item1();
				if (!Mathf.Approximately(num, 0f) && !Mathf.Approximately(num2, 0f))
				{
					_shakeTimes[shake] += deltaTime * num;
					Vector3 target = new Vector3((Mathf.PerlinNoise(_shakeTimes[shake], 0f) * 2f - 1f) * num2, (Mathf.PerlinNoise(0f, _shakeTimes[shake]) * 2f - 1f) * num2, (Mathf.PerlinNoise(_shakeTimes[shake] / 2f, _shakeTimes[shake] / 2f) * 2f - 1f) * num2);
					_offsets[shake] = Vector3.MoveTowards(_offsets[shake], target, Time.deltaTime * Mathf.Max(num2 * 5f * num, 50f));
					_currentRotationOffset += _offsets[shake];
				}
			}
			for (int num3 = _shakesAwaitingRemoval.Count - 1; num3 >= 0; num3--)
			{
				Tuple<CameraShakeFloat, CameraShakeFloat> tuple = _shakesAwaitingRemoval[num3];
				_offsets[tuple] = Vector3.MoveTowards(_offsets[tuple], Vector3.zero, Time.deltaTime * 100f);
				_currentRotationOffset += _offsets[tuple];
				if (Utilities.CompareVector3s(_offsets[tuple], Vector3.zero))
				{
					_offsets.Remove(tuple);
					_shakesAwaitingRemoval.Remove(tuple);
				}
			}
		}
	}
}
