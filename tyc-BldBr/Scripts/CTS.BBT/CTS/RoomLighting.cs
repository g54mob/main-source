using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(Room))]
	public class RoomLighting : MonoBehaviour
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
		private Transform _lightFolder;

		[SerializeField]
		[CurveRange(0f, 0f, 1f, 1f, EColor.Clear)]
		private AnimationCurve _turnOnCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[CurveRange(0f, 0f, 1f, 1f, EColor.Clear)]
		private AnimationCurve _turnOffCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private Color _disabledColor = Color.red;

		private RoomLight[] _lights;

		private ReflectionProbe[] _probes;

		private Room _roomRef;

		private void Awake()
		{
			_probes = GetComponentsInChildren<ReflectionProbe>();
			Light[] componentsInChildren = _lightFolder.GetComponentsInChildren<Light>();
			_lights = new RoomLight[componentsInChildren.Length];
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				_lights[i] = new RoomLight(componentsInChildren[i]);
			}
			_roomRef = GetComponent<Room>();
			_roomRef.OnStatusChange += OnRoomStatusChange;
			_roomRef.SettingRoomVisibility += OnRoomVisible;
		}

		private void OnRoomStatusChange(Room.EStatus value)
		{
			StopAllCoroutines();
			switch (value)
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

		private void OnRoomVisible(bool value)
		{
			if (value)
			{
				ReflectionProbe[] probes = _probes;
				for (int i = 0; i < probes.Length; i++)
				{
					probes[i].RenderProbe();
				}
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
			if (_roomRef.VisibleRoom)
			{
				OnRoomVisible(value: true);
			}
			lights = _lights;
			foreach (RoomLight roomLight3 in lights)
			{
				roomLight3.Light.intensity = goal * roomLight3.IntensityGoal;
				roomLight3.Light.color = roomLight3.CurrentColorGoal;
			}
		}

		private void OnDestroy()
		{
			_roomRef.OnStatusChange += OnRoomStatusChange;
		}
	}
}
