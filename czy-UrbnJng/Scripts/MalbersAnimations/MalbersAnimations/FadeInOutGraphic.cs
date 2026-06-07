using System.Collections;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/UI/Fade In-Out Graphic")]
	public class FadeInOutGraphic : MonoBehaviour
	{
		public CanvasGroup group;

		public FloatReference defaultAlpha = new FloatReference(0f);

		[FormerlySerializedAs("time")]
		public FloatReference timeEnter = new FloatReference(0.15f);

		public FloatReference timeExit = new FloatReference(0.15f);

		public FloatReference delayIn = new FloatReference(0f);

		public FloatReference delayOut = new FloatReference(0f);

		public AnimationCurve fadeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		private IEnumerator I_FadeIn;

		private IEnumerator I_FadeOut;

		private void Start()
		{
			group.alpha = defaultAlpha;
		}

		private void Reset()
		{
			group = GetComponent<CanvasGroup>();
			if (group == null)
			{
				group = base.gameObject.AddComponent<CanvasGroup>();
			}
			group.interactable = false;
		}

		public virtual void Fade_In_Out(bool fade)
		{
			if (fade)
			{
				Fade_In();
			}
			else
			{
				Fade_Out();
			}
		}

		public virtual void Fade_In()
		{
			if (I_FadeIn == null && base.isActiveAndEnabled)
			{
				StopAllCoroutines();
				I_FadeOut = null;
				StartCoroutine(I_FadeIn = C_Fade(1f, timeEnter));
			}
		}

		public virtual void Fade_Out()
		{
			if (I_FadeOut == null && base.isActiveAndEnabled && base.isActiveAndEnabled)
			{
				StopAllCoroutines();
				I_FadeIn = null;
				StartCoroutine(I_FadeOut = C_Fade(0f, timeExit));
			}
		}

		private IEnumerator C_Fade(float value, float time)
		{
			if ((float)delayIn > 0f && value == 1f)
			{
				yield return new WaitForSeconds(delayIn);
			}
			if ((float)delayOut > 0f && value == 0f)
			{
				yield return new WaitForSeconds(delayOut);
			}
			float elapsedTime = 0f;
			float startAlpha = group.alpha;
			while (group.alpha != value || (time > 0f && elapsedTime <= time))
			{
				float t = ((fadeCurve != null) ? fadeCurve.Evaluate(elapsedTime / time) : (elapsedTime / time));
				group.alpha = Mathf.Lerp(startAlpha, value, t);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			group.alpha = value;
			yield return null;
			if (value == 0f)
			{
				I_FadeOut = null;
			}
			else
			{
				I_FadeIn = null;
			}
		}
	}
}
