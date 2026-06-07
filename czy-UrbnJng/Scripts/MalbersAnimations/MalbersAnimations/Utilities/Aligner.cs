using System.Collections;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Aling/Aligner")]
	public class Aligner : MonoBehaviour, IAlign
	{
		public TransformReference mainPoint = new TransformReference();

		public TransformReference secondPoint = new TransformReference();

		[Min(0f)]
		public float LookAtRadius;

		[Min(0f)]
		public float AlignTime = 0.25f;

		[Tooltip("Add an offset to the rotation alignment")]
		public float AngleOffset;

		public AnimationCurve AlignCurve = new AnimationCurve(MTools.DefaultCurve);

		public bool AlignPos = true;

		public bool AlignRot = true;

		public bool DoubleSided = true;

		public bool AlignLookAt;

		public Color DebugColor = new Color(1f, 0.23f, 0f, 1f);

		private IDeltaRootMotion deltaRootMotion;

		public bool Active
		{
			get
			{
				return base.enabled;
			}
			set
			{
				base.enabled = value;
			}
		}

		public Transform MainPoint => mainPoint.Value;

		public Transform SecondPoint => secondPoint.Value;

		public virtual void Set_MainPoint(Transform value)
		{
			mainPoint.Value = value;
		}

		public virtual void Set_SecondPoint(Transform value)
		{
			secondPoint.Value = value;
		}

		public virtual void Align(GameObject Target)
		{
			Align(Target.transform);
		}

		public virtual void Align(Component Target)
		{
			Align(Target.transform.FindObjectCore());
		}

		public virtual void StopAling()
		{
			StopAllCoroutines();
		}

		public virtual void Align_Self_To(GameObject Target)
		{
			Align_Self_To(Target.transform);
		}

		public virtual void Align_Self_To(Collider Target)
		{
			Align_Self_To(Target.transform);
		}

		public virtual void Align_Self_To(Component Target)
		{
			Align_Self_To(Target.transform);
		}

		public virtual void Align_Self_To(Transform reference)
		{
			if (!Active || !MainPoint || !(reference != null))
			{
				return;
			}
			IObjectCore objectCore = reference.FindInterface<IObjectCore>();
			if (objectCore != null)
			{
				reference = objectCore.transform;
			}
			if (AlignLookAt)
			{
				StartCoroutine(AlignLookAtTransform(mainPoint, reference, AlignTime, AlignCurve));
				if (LookAtRadius > 0f)
				{
					StartCoroutine(MTools.AlignTransformRadius(reference, mainPoint, AlignTime, LookAtRadius, AlignCurve));
				}
				return;
			}
			if (AlignPos)
			{
				Vector3 position = reference.position;
				StartCoroutine(MTools.AlignTransform_Position(MainPoint, position, AlignTime, AlignCurve));
			}
			if (AlignRot)
			{
				Quaternion rotation = reference.rotation;
				Quaternion rotation2 = MainPoint.rotation;
				if (DoubleSided)
				{
					Quaternion quaternion = reference.rotation * Quaternion.Euler(0f, 180f, 0f);
					float num = Quaternion.Angle(rotation2, rotation);
					float num2 = Quaternion.Angle(rotation2, quaternion);
					StartCoroutine(MTools.AlignTransform_Rotation(MainPoint, (num < num2) ? rotation : quaternion, AlignTime, AlignCurve));
				}
				else
				{
					StartCoroutine(MTools.AlignTransform_Rotation(MainPoint, rotation, AlignTime, AlignCurve));
				}
			}
		}

		public virtual void Align(Transform TargetToAlign)
		{
			if (!Active || !MainPoint || !(TargetToAlign != null))
			{
				return;
			}
			deltaRootMotion = TargetToAlign.TryDeltaRootMotion();
			if (AlignLookAt)
			{
				StartCoroutine(AlignLookAtTransform(TargetToAlign, mainPoint, AlignTime, AlignCurve));
				if (LookAtRadius > 0f)
				{
					StartCoroutine(MTools.AlignTransformRadius(TargetToAlign, mainPoint, AlignTime, LookAtRadius, AlignCurve));
				}
				return;
			}
			Vector3 position = TargetToAlign.transform.position;
			Vector3 vector = MainPoint.position;
			if ((bool)SecondPoint)
			{
				vector = position.ClosestPointOnLine(MainPoint.position, SecondPoint.position);
			}
			Vector3 position2 = base.transform.InverseTransformPoint(vector);
			position2.z *= -1f;
			position2 = base.transform.TransformPoint(position2);
			float num = Vector3.Distance(position, vector);
			float num2 = Vector3.Distance(position, position2);
			if (AlignPos)
			{
				if (DoubleSided)
				{
					vector = ((num2 < num) ? position2 : vector);
				}
				StartCoroutine(MTools.AlignTransform_Position(TargetToAlign.transform, vector, AlignTime, AlignCurve));
			}
			if (!AlignRot)
			{
				return;
			}
			Quaternion quaternion = MainPoint.rotation;
			Quaternion rotation = TargetToAlign.transform.rotation;
			if (DoubleSided)
			{
				Quaternion quaternion2 = quaternion * Quaternion.Euler(0f, 180f, 0f);
				if (num == num2)
				{
					num = Quaternion.Angle(rotation, quaternion);
					num2 = Quaternion.Angle(rotation, quaternion2);
				}
				quaternion = ((num2 < num) ? quaternion2 : quaternion);
			}
			StartCoroutine(MTools.AlignTransform_Rotation(TargetToAlign.transform, quaternion * Quaternion.Euler(0f, AngleOffset, 0f), AlignTime, AlignCurve));
		}

		private IEnumerator AlignLookAtTransform(Transform t1, Transform t2, float time, AnimationCurve curve = null)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate Wait = new WaitForFixedUpdate();
			Quaternion CurrentRot = t1.rotation;
			Vector3 normalized = (t2.position - t1.position).normalized;
			normalized.y = t1.forward.y;
			Quaternion FinalRot = Quaternion.LookRotation(normalized) * Quaternion.Euler(0f, AngleOffset, 0f);
			while (time > 0f && elapsedTime <= time)
			{
				float t3 = curve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.rotation = Quaternion.SlerpUnclamped(CurrentRot, FinalRot, t3);
				elapsedTime += Time.fixedDeltaTime;
				yield return Wait;
			}
			t1.rotation = FinalRot;
			deltaRootMotion?.ResetDeltaRootMotion();
		}
	}
}
