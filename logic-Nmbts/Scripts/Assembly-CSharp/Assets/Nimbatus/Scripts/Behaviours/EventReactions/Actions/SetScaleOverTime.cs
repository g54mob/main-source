using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class SetScaleOverTime : NimbatusAction
	{
		public bool CustomTransform;

		[ShowIf("CustomTransform", true)]
		public Transform Transform;

		public Vector2 StartScale;

		public Vector2 TargetScale;

		public float Delay;

		public float ScaleTime;

		public AnimationCurve ScaleCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public override void Execute()
		{
			Transform = (CustomTransform ? (Transform ?? OwnWorldObject.transform) : OwnWorldObject.transform);
			OwnWorldObject.StartCoroutine(Scale());
		}

		private IEnumerator Scale()
		{
			if (Delay > 0f)
			{
				yield return new WaitForSecondsRealtime(Delay);
			}
			float t = 0f;
			while (t < ScaleTime)
			{
				t += Time.deltaTime;
				Transform.localScale = Vector2.Lerp(StartScale, TargetScale, ScaleCurve.Evaluate(t / ScaleTime));
				yield return null;
			}
			Transform.localScale = TargetScale;
		}
	}
}
