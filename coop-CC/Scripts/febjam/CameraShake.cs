using System;
using System.Collections.Generic;
using Aggro.Core;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class CameraShake : AggroManagerBase<CameraShake>
{
	private struct Shake
	{
		public float amount;

		public float scale;

		public float duration;

		public float startTime;
	}

	[Serializable]
	public class ShakeStrengthValue
	{
		[Min(0f)]
		public float amount = 1f;

		[Min(0f)]
		public float duration = 0.2f;

		[Min(0f)]
		public float scale = 15f;

		[Space]
		public VibrateStrength vibrateStrength = VibrateStrength.None;

		[Header("Fall Off")]
		public Vector2 fallOffMinMaxDistance = new Vector2(10f, 30f);

		public EasingFunction.Ease fallOffEase = EasingFunction.Ease.EaseOutQuad;
	}

	public Transform shakeTarget;

	public ShakeStrengthValue[] shakeStrengths;

	private List<Shake> _shakes = new List<Shake>();

	private Quaternion _originalRot;

	private static readonly int SETTING_SCREENSHAKE = AggroSettings.IdToHash("game-screenshake");

	protected override void OnEntityCreated()
	{
		_originalRot = shakeTarget.localRotation;
	}

	protected override void OnUpdatePresentation()
	{
		if (AggroManagerBase<CameraController>.instance.mode != CameraController.Mode.PlayerFollow)
		{
			return;
		}
		Vector3 vector = default(Vector3);
		for (int i = 0; i < _shakes.Count; i++)
		{
			Shake shake = _shakes[i];
			float x = shake.duration - (Time.time - shake.startTime);
			x = math.max(x, 0f);
			vector.x += (Mathf.PerlinNoise(Time.time * shake.scale, 0f) - 0.5f) * shake.amount * (x / shake.duration);
			vector.y += (Mathf.PerlinNoise(0f, Time.time * shake.scale) - 0.5f) * shake.amount * (x / shake.duration);
			if (x == 0f)
			{
				_shakes.RemoveAtSwapBack(i);
				i--;
			}
		}
		float value = AggroSettings.GetSetting<FloatSetting>(SETTING_SCREENSHAKE).value;
		Quaternion quaternion2 = Quaternion.Euler(vector * value);
		shakeTarget.localRotation = quaternion2 * _originalRot;
	}

	public void AddShake(float amount = 1f, float duration = 0.2f, float scale = 15f)
	{
		Shake item = new Shake
		{
			amount = amount,
			duration = duration,
			scale = scale,
			startTime = Time.time
		};
		_shakes.Add(item);
	}

	public void AddShake(ShakeStrength strength)
	{
		if (strength != ShakeStrength.None)
		{
			ShakeStrengthValue shakeStrengthValue = shakeStrengths[math.clamp((int)strength, 0, shakeStrengths.Length - 1)];
			AddShake(shakeStrengthValue.amount, shakeStrengthValue.duration, shakeStrengthValue.scale);
			AggroInputManager.Vibrate(shakeStrengthValue.vibrateStrength);
		}
	}

	public void AddShakeFromPosition(ShakeStrength strength, Vector3 position)
	{
		if (strength == ShakeStrength.None || !GameUtil.TryGetLocalPlayer(out var player))
		{
			return;
		}
		ShakeStrengthValue shakeStrengthValue = shakeStrengths[math.clamp((int)strength, 0, shakeStrengths.Length - 1)];
		float num = math.distancesq(position, player.transform.position);
		if (num < shakeStrengthValue.fallOffMinMaxDistance.x * shakeStrengthValue.fallOffMinMaxDistance.x || num >= shakeStrengthValue.fallOffMinMaxDistance.y * shakeStrengthValue.fallOffMinMaxDistance.y)
		{
			AddShake(shakeStrengthValue.amount, shakeStrengthValue.duration, shakeStrengthValue.scale);
			AggroInputManager.Vibrate(shakeStrengthValue.vibrateStrength);
			return;
		}
		float x = math.sqrt(num);
		float value = math.unlerp(shakeStrengthValue.fallOffMinMaxDistance.x, shakeStrengthValue.fallOffMinMaxDistance.y, x);
		float num2 = EasingFunction.Evaluate(shakeStrengthValue.fallOffEase, 1f, 0f, value);
		AddShake(shakeStrengthValue.amount * num2, shakeStrengthValue.duration, shakeStrengthValue.scale);
		if (shakeStrengthValue.vibrateStrength != VibrateStrength.None)
		{
			GlobalScriptableObject<InputGlobalData>.instance.GetVibrateValues(shakeStrengthValue.vibrateStrength, out var lowFrequency, out var highFrequency, out var duration);
			AggroInputManager.Vibrate(lowFrequency * num2, highFrequency * num2, duration);
		}
	}
}
