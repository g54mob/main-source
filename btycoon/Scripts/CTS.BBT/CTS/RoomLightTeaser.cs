using System;
using System.Collections;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class RoomLightTeaser : CTSBehaviour
	{
		private class RoomLight
		{
			public float CurrentIntensity;

			public Color CurrentColor;

			public Color CurrentColorGoal;

			public Light Light { get; }

			public float IntensityGoal { get; }

			public Color ColorGoal { get; }

			public RoomLight(Light light)
			{
				Light = light;
				IntensityGoal = light.intensity;
				ColorGoal = light.color;
			}
		}

		[SerializeField]
		[CurveRange(0f, 0f, 1f, 1f, EColor.Clear)]
		private AnimationCurve _turnOnCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[CurveRange(0f, 0f, 1f, 1f, EColor.Clear)]
		private AnimationCurve _turnOffCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private Color _disabledColor = Color.red;

		[SerializeField]
		private Room.EStatus _startRoomStatus;

		[SerializeField]
		private Room.EStatus _targetStatus;

		private RoomLight[] _lights;

		protected override void OnAwake()
		{
			base.OnAwake();
			Light[] componentsInChildren = GetComponentsInChildren<Light>();
			_lights = new RoomLight[componentsInChildren.Length];
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				_lights[i] = new RoomLight(componentsInChildren[i]);
			}
		}

		[Button(null, EButtonEnableMode.Playmode)]
		protected override void OnEnabled()
		{
			base.OnEnabled();
			ResetLights();
			switch (_targetStatus)
			{
			case Room.EStatus.Unavailable:
				StartCoroutine(LightsRoutine(_turnOffCurve, 0f));
				break;
			case Room.EStatus.Disabled:
				StartCoroutine(LightsRoutine(_turnOffCurve, 0.4f));
				break;
			case Room.EStatus.Enabled:
				StartCoroutine(LightsRoutine(_turnOnCurve, 1f));
				break;
			}
		}

		private void ResetLights()
		{
			StopAllCoroutines();
			float num = _startRoomStatus switch
			{
				Room.EStatus.Unavailable => 0f, 
				Room.EStatus.Disabled => 0.4f, 
				Room.EStatus.Enabled => 1f, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			RoomLight[] lights = _lights;
			foreach (RoomLight roomLight in lights)
			{
				roomLight.Light.intensity = num * roomLight.IntensityGoal;
				roomLight.Light.color = (((double)num > 0.5) ? roomLight.ColorGoal : _disabledColor);
			}
		}

		private IEnumerator LightsRoutine(AnimationCurve curve, float goal)
		{
			RoomLight[] lights = _lights;
			foreach (RoomLight roomLight in lights)
			{
				roomLight.CurrentIntensity = roomLight.Light.intensity;
				roomLight.CurrentColor = roomLight.Light.color;
				roomLight.CurrentColorGoal = (((double)goal > 0.5) ? roomLight.ColorGoal : _disabledColor);
			}
			float duration = curve.keys[^1].time;
			for (float time = 0f; time < duration; time += Time.unscaledDeltaTime)
			{
				float t = curve.Evaluate(time);
				lights = _lights;
				foreach (RoomLight roomLight2 in lights)
				{
					roomLight2.Light.intensity = Mathf.Lerp(roomLight2.CurrentIntensity, goal * roomLight2.IntensityGoal, t);
					roomLight2.Light.color = Color.Lerp(roomLight2.CurrentColor, roomLight2.CurrentColorGoal, t);
				}
				yield return null;
			}
			lights = _lights;
			foreach (RoomLight roomLight3 in lights)
			{
				roomLight3.Light.intensity = goal * roomLight3.IntensityGoal;
				roomLight3.Light.color = roomLight3.CurrentColorGoal;
			}
		}
	}
}
