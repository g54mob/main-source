using System.Collections;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Animal Controller/Scale Bones Fix")]
	public class ScaleBonesFix : MonoBehaviour, IAnimatorListener
	{
		private MAnimal animal;

		public float Offset = -0.2f;

		public float duration = 0.2f;

		Transform IAnimatorListener.transform => base.transform;

		private void Awake()
		{
			animal = this.FindComponent<MAnimal>();
		}

		public void FixHeight(bool active)
		{
			StartCoroutine(SmoothFix(active));
		}

		public IEnumerator SmoothFix(bool active)
		{
			float t = 0f;
			float startpos = animal.height;
			float endpos = startpos + (active ? Offset : (0f - Offset));
			while (t < duration)
			{
				animal.height = Mathf.Lerp(startpos, endpos, t / duration);
				t += Time.deltaTime;
				yield return null;
			}
			animal.height = endpos;
			yield return null;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}
	}
}
