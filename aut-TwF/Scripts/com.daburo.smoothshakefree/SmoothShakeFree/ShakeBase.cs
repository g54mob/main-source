using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmoothShakeFree
{
	public abstract class ShakeBase : MonoBehaviour
	{
		[Header("Time Settings")]
		[Tooltip("Settings for the shake timing")]
		public TimeSettings timeSettings;

		private bool willStop;

		[HideInInspector]
		internal Shaker[] shakers;

		[HideInInspector]
		internal readonly List<Coroutine> activeShakeRoutines = new List<Coroutine>();

		[HideInInspector]
		internal Coroutine clearAfterFinished;

		[HideInInspector]
		internal Vector3[] sum;

		internal void Awake()
		{
			shakers = GetShakers();
			sum = new Vector3[shakers.Length];
			if (timeSettings.enableOnStart)
			{
				StartShake();
			}
		}

		internal void Start()
		{
			if (timeSettings.enableOnStart)
			{
				StartShake();
			}
		}

		public virtual void StartShake()
		{
			willStop = false;
			if (activeShakeRoutines.Count == 0)
			{
				clearAfterFinished = StartCoroutine(ClearAfterFinished());
				SaveDefaultValues();
				for (int i = 0; i < shakers.Length; i++)
				{
					activeShakeRoutines.Add(StartCoroutine(ShakeRoutine(shakers[i], timeSettings, i)));
				}
			}
			else
			{
				ForceStop();
				StartShake();
			}
		}

		public void StartShake(SmoothShakeFreePreset preset)
		{
			ApplyPresetSettings(preset);
			StartShake();
		}

		public void StopShake()
		{
			willStop = true;
		}

		public void ForceStop()
		{
			for (int i = 0; i < activeShakeRoutines.Count; i++)
			{
				if (activeShakeRoutines[i] != null)
				{
					StopCoroutine(activeShakeRoutines[i]);
					activeShakeRoutines[i] = null;
				}
			}
			if (clearAfterFinished != null)
			{
				StopCoroutine(clearAfterFinished);
				clearAfterFinished = null;
			}
			for (int j = 0; j < sum.Length; j++)
			{
				sum[j] = Vector3.zero;
			}
			activeShakeRoutines.Clear();
			ResetDefaultValues();
			willStop = false;
		}

		protected IEnumerator ClearAfterFinished()
		{
			if (timeSettings.constantShake)
			{
				while (!willStop)
				{
					yield return null;
				}
				yield return new WaitForSeconds(timeSettings.fadeOutDuration);
				ForceStop();
			}
			else
			{
				yield return new WaitForSeconds(timeSettings.GetShakeDuration());
				ForceStop();
			}
		}

		protected IEnumerator ShakeRoutine(Shaker shaker, TimeSettings timeSettings, int i)
		{
			bool isFadingOut = false;
			if (timeSettings.fadeInDuration > 0f)
			{
				yield return FadeRoutine(this.timeSettings.fadeInCurve, shaker, timeSettings, isFadingOut, i);
			}
			if (timeSettings.holdDuration > 0f && !this.timeSettings.constantShake)
			{
				yield return HoldRoutine(timeSettings.holdDuration, shaker, timeSettings, i);
			}
			if (this.timeSettings.constantShake)
			{
				yield return HoldRoutine(float.PositiveInfinity, shaker, timeSettings, i);
			}
			isFadingOut = true;
			if (timeSettings.fadeOutDuration > 0f)
			{
				yield return FadeRoutine(this.timeSettings.fadeOutCurve, shaker, timeSettings, isFadingOut, i);
			}
		}

		private IEnumerator FadeRoutine(AnimationCurve curve, Shaker shaker, TimeSettings timeSettings, bool isFadingOut, int i)
		{
			if (curve.length <= 1)
			{
				yield break;
			}
			if (isFadingOut && timeSettings.holdDuration == 0f && timeSettings.fadeInDuration == 0f)
			{
				timeSettings.fadeValue = 1f;
			}
			Keyframe[] keys = curve.keys;
			float tEnd = (isFadingOut ? timeSettings.fadeOutDuration : timeSettings.fadeInDuration);
			for (float t = 0f; t < tEnd; t += Time.deltaTime)
			{
				if (!isFadingOut && willStop)
				{
					yield break;
				}
				float time = Utility.Remap(t, 0f, tEnd, keys[0].time, keys[^1].time);
				timeSettings.fadeValue = curve.Evaluate(time);
				Execute(shaker, timeSettings, i);
				yield return null;
			}
			timeSettings.fadeValue = Utility.Remap(curve.Evaluate(keys[^1].time), keys[0].value, keys[^1].value, isFadingOut ? 1 : 0, (!isFadingOut) ? 1 : 0);
			Execute(shaker, timeSettings, i);
		}

		private IEnumerator HoldRoutine(float duration, Shaker shaker, TimeSettings timeSettings, int i)
		{
			if (timeSettings.fadeValue == 0f)
			{
				timeSettings.fadeValue = 1f;
			}
			float t = 0f;
			if (float.IsInfinity(duration))
			{
				while (!willStop)
				{
					Execute(shaker, timeSettings, i);
					yield return null;
				}
				yield break;
			}
			for (; t < duration; t += Time.deltaTime)
			{
				if (willStop)
				{
					yield break;
				}
				Execute(shaker, timeSettings, i);
				yield return null;
			}
			if (timeSettings.fadeOutDuration == 0f)
			{
				timeSettings.fadeValue = 0f;
				Execute(shaker, timeSettings, i);
			}
		}

		protected virtual void Execute(Shaker shaker, TimeSettings timeSettings, int i)
		{
			sum[i] = shaker.Evaluate(Time.time) * timeSettings.fadeValue;
		}

		protected virtual void ApplySum()
		{
			Apply(sum);
		}

		private void Update()
		{
			if (activeShakeRoutines.Count > 0)
			{
				ApplySum();
			}
		}

		internal abstract void Apply(Vector3[] value);

		protected abstract Shaker[] GetShakers();

		internal abstract void SaveDefaultValues();

		internal abstract void ResetDefaultValues();

		internal abstract void ApplyPresetSettings(SmoothShakeFreePreset preset);
	}
}
