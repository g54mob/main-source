using System.Collections;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/UI/Float Lerp")]
	public class FloatLerp : MonoBehaviour
	{
		public enum LerpType
		{
			Lerp = 0,
			MoveTowards = 1,
			SmoothDamp = 2,
			Curve = 3
		}

		[Tooltip("Target value we want to achieve")]
		public FloatReference TargetValue = new FloatReference();

		[Tooltip("Current float value")]
		public FloatReference CurrentValue = new FloatReference();

		[Tooltip("Type of lerping to use")]
		public LerpType lerpType;

		[Tooltip("Lerp Value to use for the smoothness")]
		[Min(0.01f)]
		public float Lerp = 5f;

		[Min(0.001f)]
		public float Threshhold = 0.001f;

		public AnimationCurve curve = new AnimationCurve(MTools.DefaultCurve);

		[Min(0.01f)]
		public float curveTime = 0.5f;

		[Tooltip("Delay the Lerp for this amount of seconds")]
		public float delay = 0.2f;

		[Tooltip("Lerp only when the Target Value is lower than the current value")]
		public bool DecreasingOnly;

		private IEnumerator ILerp;

		public FloatEvent OnValueLerped = new FloatEvent();

		private WaitForSeconds delayWait;

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		public void SetValue_NoLerp(float value)
		{
			TargetValue = value;
			CurrentValue = value;
			OnValueLerped.Invoke(value);
		}

		public void SetValue(float value)
		{
			TargetValue = value;
			if (DecreasingOnly && (float)TargetValue > (float)CurrentValue)
			{
				CurrentValue = value;
				OnValueLerped.Invoke(value);
				return;
			}
			if (ILerp != null)
			{
				StopCoroutine(ILerp);
			}
			ILerp = null;
			if (delayWait == null)
			{
				delayWait = new WaitForSeconds(delay);
			}
			switch (lerpType)
			{
			case LerpType.Lerp:
				ILerp = C_NormalLerp();
				break;
			case LerpType.MoveTowards:
				ILerp = C_MoveTowards();
				break;
			case LerpType.SmoothDamp:
				ILerp = C_SmoothDamp();
				break;
			case LerpType.Curve:
				ILerp = C_Curve();
				break;
			}
			StartCoroutine(ILerp);
		}

		public IEnumerator C_NormalLerp()
		{
			yield return delayWait;
			while (Mathf.Abs((float)CurrentValue - (float)TargetValue) > Threshhold)
			{
				CurrentValue = Mathf.Lerp(CurrentValue, TargetValue, Time.deltaTime * Lerp);
				OnValueLerped.Invoke(CurrentValue);
				yield return null;
			}
			CurrentValue = TargetValue;
			OnValueLerped.Invoke(CurrentValue);
		}

		public IEnumerator C_MoveTowards()
		{
			yield return delayWait;
			while (Mathf.Abs((float)CurrentValue - (float)TargetValue) > Threshhold)
			{
				CurrentValue = Mathf.MoveTowards(CurrentValue, TargetValue, Time.deltaTime * Lerp);
				OnValueLerped.Invoke(CurrentValue);
				yield return null;
			}
			CurrentValue = TargetValue;
			OnValueLerped.Invoke(CurrentValue);
		}

		public IEnumerator C_SmoothDamp()
		{
			yield return delayWait;
			float r = 0f;
			while (Mathf.Abs((float)CurrentValue - (float)TargetValue) > Threshhold)
			{
				CurrentValue = Mathf.SmoothDamp(CurrentValue, TargetValue, ref r, Time.deltaTime * Lerp);
				OnValueLerped.Invoke(CurrentValue);
				yield return null;
			}
			CurrentValue = TargetValue;
			OnValueLerped.Invoke(CurrentValue);
		}

		public IEnumerator C_Curve()
		{
			yield return delayWait;
			float elapsedTime = 0f;
			float StartValue = CurrentValue;
			while (elapsedTime < curveTime)
			{
				CurrentValue = Mathf.LerpUnclamped(StartValue, TargetValue, curve.Evaluate(elapsedTime / curveTime));
				elapsedTime += Time.deltaTime;
				OnValueLerped.Invoke(CurrentValue);
				yield return null;
			}
			CurrentValue = TargetValue;
			OnValueLerped.Invoke(CurrentValue);
		}
	}
}
