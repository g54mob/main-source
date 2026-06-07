using System.Collections;
using UnityEngine;

namespace MalbersAnimations
{
	[CreateAssetMenu(menuName = "Malbers Animations/Extras/Anim Transform", order = 2100)]
	public class TransformAnimation : ScriptableCoroutine
	{
		public enum AnimTransType
		{
			TransformAnimation = 0,
			MountTriggerAdjustment = 1
		}

		public AnimTransType animTrans;

		private static readonly Keyframe[] K = new Keyframe[2]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		};

		public float time = 1f;

		public float delay = 1f;

		public bool UsePosition;

		public Vector3 Position;

		public AnimationCurve PosCurve = new AnimationCurve(K);

		public bool SeparateAxisPos;

		public AnimationCurve PosXCurve = new AnimationCurve(K);

		public AnimationCurve PosYCurve = new AnimationCurve(K);

		public AnimationCurve PosZCurve = new AnimationCurve(K);

		public bool UseRotation;

		public Vector3 Rotation;

		public AnimationCurve RotCurve = new AnimationCurve(K);

		public bool SeparateAxisRot;

		public AnimationCurve RotXCurve = new AnimationCurve(K);

		public AnimationCurve RotYCurve = new AnimationCurve(K);

		public AnimationCurve RotZCurve = new AnimationCurve(K);

		public bool UseScale;

		public Vector3 Scale = Vector3.one;

		public AnimationCurve ScaleCurve = new AnimationCurve(K);

		public Vector3 TargetPos { get; private set; }

		public Vector3 TargetRot { get; private set; }

		public Vector3 TargetScale { get; private set; }

		public Vector3 StartPos { get; private set; }

		public Vector3 StartRot { get; private set; }

		public Vector3 StartScale { get; private set; }

		public void Play(Transform item)
		{
			StartCoroutine(item, PlayTransformAnimation(item, time, delay));
		}

		public void PlayForever(Transform item)
		{
			StartCoroutine(item, PlayTransformAnimationForever(item, time, delay));
		}

		internal override void Evaluate(MonoBehaviour mono, Transform target, float time, AnimationCurve curve = null)
		{
			mono.StartCoroutine(PlayTransformAnimation(target, time, 0f));
		}

		internal IEnumerator PlayTransformAnimation(Transform item, float time, float delay)
		{
			if (item != null)
			{
				if (delay != 0f)
				{
					yield return new WaitForSeconds(delay);
				}
				float elapsedTime = 0f;
				StartPos = item.localPosition;
				StartRot = item.localEulerAngles;
				StartScale = item.localScale;
				TargetPos = StartPos + Position;
				TargetRot = StartRot + Rotation;
				TargetScale = Vector3.Scale(StartScale, Scale);
				while (time > 0f && elapsedTime <= time && item != null)
				{
					float t = PosCurve.Evaluate(elapsedTime / time);
					float t2 = RotCurve.Evaluate(elapsedTime / time);
					float t3 = ScaleCurve.Evaluate(elapsedTime / time);
					if (UsePosition)
					{
						item.localPosition = Vector3.LerpUnclamped(StartPos, TargetPos, t);
					}
					if (UseRotation)
					{
						item.transform.localEulerAngles = Vector3.LerpUnclamped(StartRot, TargetRot, t2);
					}
					if (UseScale)
					{
						item.transform.localScale = Vector3.LerpUnclamped(StartScale, TargetScale, t3);
					}
					elapsedTime += Time.deltaTime;
					yield return null;
				}
				ExitValue(item);
			}
			yield return null;
			Stop(item);
		}

		internal override void ExitValue(Component component)
		{
			Transform transform = (Transform)component;
			if (!(transform == null))
			{
				if (UsePosition)
				{
					float t = PosCurve.Evaluate(1f / time);
					transform.localPosition = Vector3.LerpUnclamped(StartPos, TargetPos, t);
				}
				if (UseRotation)
				{
					float t2 = RotCurve.Evaluate(1f / time);
					transform.transform.localEulerAngles = Vector3.LerpUnclamped(StartRot, TargetRot, t2);
				}
				if (UseScale)
				{
					float t3 = ScaleCurve.Evaluate(1f / time);
					transform.transform.localScale = Vector3.LerpUnclamped(StartScale, TargetScale, t3);
				}
			}
		}

		internal IEnumerator PlayTransformAnimation(Transform item)
		{
			yield return PlayTransformAnimation(item, time, delay);
		}

		internal IEnumerator PlayTransformAnimationForever(Transform item)
		{
			yield return PlayTransformAnimationForever(item, time, delay);
		}

		internal IEnumerator PlayTransformAnimationForever(Transform item, float time, float delay)
		{
			if (item != null)
			{
				if (delay != 0f)
				{
					yield return new WaitForSeconds(delay);
				}
				float elapsedTime = 0f;
				Vector3 StartPos = item.localPosition;
				Vector3 StartRot = item.localEulerAngles;
				Vector3 StartScale = item.localScale;
				Vector3 TargetPos = StartPos + Position;
				Vector3 TargetRot = StartRot + Rotation;
				Vector3 TargetScale = Vector3.Scale(StartScale, Scale);
				while (true)
				{
					float t = PosCurve.Evaluate(elapsedTime / time);
					float t2 = RotCurve.Evaluate(elapsedTime / time);
					float t3 = ScaleCurve.Evaluate(elapsedTime / time);
					if (UsePosition)
					{
						item.localPosition = Vector3.LerpUnclamped(StartPos, TargetPos, t);
					}
					if (UseRotation)
					{
						item.transform.localEulerAngles = Vector3.LerpUnclamped(StartRot, TargetRot, t2);
					}
					if (UseScale)
					{
						item.transform.localScale = Vector3.LerpUnclamped(StartScale, TargetScale, t3);
					}
					elapsedTime += Time.deltaTime;
					elapsedTime %= time;
					yield return null;
				}
			}
			yield return null;
			Stop(item);
		}
	}
}
