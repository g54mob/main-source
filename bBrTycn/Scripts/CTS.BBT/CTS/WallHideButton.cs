using System;
using CTS.Core;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace CTS
{
	public class WallHideButton : CTSBehaviour
	{
		private static readonly int SHWallHeight = Shader.PropertyToID("WallHeight");

		[SerializeField]
		[Range(0f, 1f)]
		private float _hiddenHeight = 0.2f;

		[SerializeField]
		private float _updateSpeed = 0.5f;

		[SerializeField]
		private AnimationCurve _updateCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		private DOGetter<float> _getValue;

		private DOSetter<float> _setValue;

		public static float CurrentValue { get; private set; } = 1f;

		public static bool Active { get; private set; } = false;

		public static event Action<float> ValueChanged;

		public static event Action<bool> ActiveStateChanged;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Init()
		{
			Shader.SetGlobalFloat(SHWallHeight, 0f);
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			Active = false;
			CurrentValue = 1f;
			_getValue = GetValue;
			_setValue = SetValue;
		}

		private void OnDestroy()
		{
			Shader.SetGlobalFloat(SHWallHeight, 0f);
			CurrentValue = 1f;
		}

		private float GetValue()
		{
			return CurrentValue;
		}

		private void SetValue(float value)
		{
			CurrentValue = value;
			Shader.SetGlobalFloat(SHWallHeight, 1f - value);
			WallHideButton.ValueChanged?.Invoke(value);
		}

		public void SetActive(bool value)
		{
			if (value != Active)
			{
				this.DOKill();
				Active = value;
				WallHideButton.ActiveStateChanged?.Invoke(value);
				DOTween.To(_getValue, _setValue, value ? _hiddenHeight : 1f, _updateSpeed).SetTarget(this).SetUpdate(isIndependentUpdate: true)
					.SetEase(_updateCurve);
			}
		}
	}
}
