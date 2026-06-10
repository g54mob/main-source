using System;
using UnityEngine;

namespace FIMSpace.FTools
{
	[Serializable]
	public class FIK_CCDProcessor : FIK_ProcessorBase
	{
		[Serializable]
		public class CCDIKBone : FIK_IKBoneBase
		{
			[Range(0f, 180f)]
			public float AngleLimit = 45f;

			[Range(0f, 180f)]
			public float TwistAngleLimit = 5f;

			public Vector3 ForwardOrientation;

			public float FrameWorldLength = 1f;

			public Vector2 HingeLimits = Vector2.zero;

			public Quaternion PreviousHingeRotation;

			public float PreviousHingeAngle;

			public Vector3 LastIKLocPosition;

			public Quaternion LastIKLocRotation;

			public CCDIKBone IKParent { get; private set; }

			public CCDIKBone IKChild { get; private set; }

			public CCDIKBone(Transform t)
				: base(t)
			{
			}

			public void Init(CCDIKBone child, CCDIKBone parent)
			{
				LastIKLocPosition = base.transform.localPosition;
				IKParent = parent;
				if (child != null)
				{
					SetChild(child);
				}
				IKChild = child;
			}

			public override void SetChild(FIK_IKBoneBase child)
			{
				base.SetChild(child);
			}

			public void AngleLimiting()
			{
				Quaternion quaternion = Quaternion.Inverse(LastKeyLocalRotation) * base.transform.localRotation;
				Quaternion quaternion2 = quaternion;
				if (FEngineering.VIsZero(HingeLimits))
				{
					if (AngleLimit < 180f)
					{
						quaternion2 = LimitSpherical(quaternion2);
					}
					if (TwistAngleLimit < 180f)
					{
						quaternion2 = LimitZ(quaternion2);
					}
				}
				else
				{
					quaternion2 = LimitHinge(quaternion2);
				}
				if (!quaternion2.QIsSame(quaternion))
				{
					base.transform.localRotation = LastKeyLocalRotation * quaternion2;
				}
			}

			private Quaternion LimitSpherical(Quaternion rotation)
			{
				if (rotation.QIsZero())
				{
					return rotation;
				}
				Vector3 vector = rotation * ForwardOrientation;
				Quaternion quaternion = Quaternion.RotateTowards(Quaternion.identity, Quaternion.FromToRotation(ForwardOrientation, vector), AngleLimit);
				return Quaternion.FromToRotation(vector, quaternion * ForwardOrientation) * rotation;
			}

			private Quaternion LimitZ(Quaternion currentRotation)
			{
				Vector3 vector = new Vector3(ForwardOrientation.y, ForwardOrientation.z, ForwardOrientation.x);
				Vector3 normal = currentRotation * ForwardOrientation;
				Vector3 tangent = vector;
				Vector3.OrthoNormalize(ref normal, ref tangent);
				vector = currentRotation * vector;
				Vector3.OrthoNormalize(ref normal, ref vector);
				Quaternion quaternion = Quaternion.FromToRotation(vector, tangent) * currentRotation;
				if (TwistAngleLimit <= 0f)
				{
					return quaternion;
				}
				return Quaternion.RotateTowards(quaternion, currentRotation, TwistAngleLimit);
			}

			private Quaternion LimitHinge(Quaternion rotation)
			{
				Quaternion quaternion = Quaternion.FromToRotation(rotation * ForwardOrientation, ForwardOrientation) * rotation * Quaternion.Inverse(PreviousHingeRotation);
				float num = Quaternion.Angle(Quaternion.identity, quaternion);
				Vector3 vector = new Vector3(ForwardOrientation.z, ForwardOrientation.x, ForwardOrientation.y);
				Vector3 rhs = Vector3.Cross(vector, ForwardOrientation);
				if (Vector3.Dot(quaternion * vector, rhs) > 0f)
				{
					num = 0f - num;
				}
				PreviousHingeAngle = Mathf.Clamp(PreviousHingeAngle + num, HingeLimits.x, HingeLimits.y);
				PreviousHingeRotation = Quaternion.AngleAxis(PreviousHingeAngle, ForwardOrientation);
				return PreviousHingeRotation;
			}
		}

		public CCDIKBone[] IKBones;

		public bool ContinousSolving = true;

		[Range(0f, 1f)]
		public float SyncWithAnimator = 1f;

		[Range(1f, 12f)]
		public int ReactionQuality = 2;

		[Range(0f, 1f)]
		public float Smoothing;

		[Range(0f, 1.5f)]
		public float MaxStretching;

		public AnimationCurve StretchCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public bool Use2D;

		public CCDIKBone StartIKBone => IKBones[0];

		public CCDIKBone EndIKBone => IKBones[IKBones.Length - 1];

		public float ActiveLength { get; private set; }

		public FIK_CCDProcessor(Transform[] bonesChain)
		{
			IKBones = new CCDIKBone[bonesChain.Length];
			FIK_IKBoneBase[] bones = new CCDIKBone[IKBones.Length];
			base.Bones = bones;
			for (int i = 0; i < bonesChain.Length; i++)
			{
				IKBones[i] = new CCDIKBone(bonesChain[i]);
				base.Bones[i] = IKBones[i];
			}
			IKTargetPosition = base.EndBone.transform.position;
			IKTargetRotation = base.EndBone.transform.rotation;
		}

		public override void Init(Transform root)
		{
			if (base.Initialized)
			{
				return;
			}
			base.fullLength = 0f;
			for (int i = 0; i < base.Bones.Length; i++)
			{
				CCDIKBone cCDIKBone = IKBones[i];
				CCDIKBone child = null;
				CCDIKBone parent = null;
				if (i > 0)
				{
					parent = IKBones[i - 1];
				}
				else if (i < base.Bones.Length - 1)
				{
					child = IKBones[i + 1];
				}
				if (i < base.Bones.Length - 1)
				{
					IKBones[i].Init(child, parent);
					base.fullLength += cCDIKBone.BoneLength;
					cCDIKBone.ForwardOrientation = Quaternion.Inverse(cCDIKBone.transform.rotation) * (IKBones[i + 1].transform.position - cCDIKBone.transform.position);
				}
				else
				{
					IKBones[i].Init(child, parent);
					cCDIKBone.ForwardOrientation = Quaternion.Inverse(cCDIKBone.transform.rotation) * (IKBones[IKBones.Length - 1].transform.position - IKBones[0].transform.position);
				}
			}
			base.Initialized = true;
		}

		public override void Update()
		{
			if (!base.Initialized || IKWeight <= 0f)
			{
				return;
			}
			CCDIKBone cCDIKBone = IKBones[0];
			if (ContinousSolving)
			{
				while (cCDIKBone != null)
				{
					cCDIKBone.LastKeyLocalRotation = cCDIKBone.transform.localRotation;
					cCDIKBone.transform.localPosition = cCDIKBone.LastIKLocPosition;
					cCDIKBone.transform.localRotation = cCDIKBone.LastIKLocRotation;
					cCDIKBone = cCDIKBone.IKChild;
				}
			}
			else if (SyncWithAnimator > 0f)
			{
				while (cCDIKBone != null)
				{
					cCDIKBone.LastKeyLocalRotation = cCDIKBone.transform.localRotation;
					cCDIKBone = cCDIKBone.IKChild;
				}
			}
			if (ReactionQuality < 0)
			{
				ReactionQuality = 1;
			}
			Vector3 vector = Vector3.zero;
			if (ReactionQuality > 1)
			{
				vector = GetGoalPivotOffset();
			}
			for (int i = 0; i < ReactionQuality && (i < 1 || vector.sqrMagnitude != 0f || !(Smoothing > 0f) || !(GetVelocityDifference() < Smoothing * Smoothing)); i++)
			{
				LastLocalDirection = RefreshLocalDirection();
				Vector3 vector2 = IKTargetPosition + vector;
				cCDIKBone = IKBones[IKBones.Length - 2];
				if (!Use2D)
				{
					while (cCDIKBone != null)
					{
						float num = cCDIKBone.MotionWeight * IKWeight;
						if (num > 0f)
						{
							Quaternion quaternion = Quaternion.FromToRotation(base.Bones[base.Bones.Length - 1].transform.position - cCDIKBone.transform.position, vector2 - cCDIKBone.transform.position) * cCDIKBone.transform.rotation;
							if (num < 1f)
							{
								cCDIKBone.transform.rotation = Quaternion.Lerp(cCDIKBone.transform.rotation, quaternion, num);
							}
							else
							{
								cCDIKBone.transform.rotation = quaternion;
							}
						}
						cCDIKBone.AngleLimiting();
						cCDIKBone = cCDIKBone.IKParent;
					}
					continue;
				}
				while (cCDIKBone != null)
				{
					float num2 = cCDIKBone.MotionWeight * IKWeight;
					if (num2 > 0f)
					{
						Vector3 vector3 = base.Bones[base.Bones.Length - 1].transform.position - cCDIKBone.transform.position;
						Vector3 vector4 = vector2 - cCDIKBone.transform.position;
						cCDIKBone.transform.rotation = Quaternion.AngleAxis(Mathf.DeltaAngle(Mathf.Atan2(vector3.x, vector3.y) * 57.29578f, Mathf.Atan2(vector4.x, vector4.y) * 57.29578f) * num2, Vector3.back) * cCDIKBone.transform.rotation;
					}
					cCDIKBone.AngleLimiting();
					cCDIKBone = cCDIKBone.IKParent;
				}
			}
			LastLocalDirection = RefreshLocalDirection();
			if (MaxStretching > 0f)
			{
				ActiveLength = Mathf.Epsilon;
				cCDIKBone = IKBones[0];
				while (cCDIKBone.IKChild != null)
				{
					cCDIKBone.FrameWorldLength = (cCDIKBone.transform.position - cCDIKBone.IKChild.transform.position).magnitude;
					ActiveLength += cCDIKBone.FrameWorldLength;
					cCDIKBone = cCDIKBone.IKChild;
				}
				Vector3 vector5 = IKTargetPosition - base.StartBone.transform.position;
				float num3 = vector5.magnitude / ActiveLength;
				if (num3 > 1f)
				{
					for (int j = 1; j < IKBones.Length; j++)
					{
						IKBones[j].transform.position += vector5.normalized * (IKBones[j - 1].BoneLength * MaxStretching) * StretchCurve.Evaluate(0f - (1f - num3));
					}
				}
			}
			for (cCDIKBone = IKBones[0]; cCDIKBone != null; cCDIKBone = cCDIKBone.IKChild)
			{
				cCDIKBone.LastIKLocRotation = cCDIKBone.transform.localRotation;
				cCDIKBone.LastIKLocPosition = cCDIKBone.transform.localPosition;
				Quaternion quaternion2 = cCDIKBone.LastIKLocRotation * Quaternion.Inverse(cCDIKBone.InitialLocalRotation);
				cCDIKBone.transform.localRotation = Quaternion.Lerp(cCDIKBone.LastIKLocRotation, quaternion2 * cCDIKBone.LastKeyLocalRotation, SyncWithAnimator);
				if (IKWeight < 1f)
				{
					cCDIKBone.transform.localRotation = Quaternion.Lerp(cCDIKBone.LastKeyLocalRotation, cCDIKBone.transform.localRotation, IKWeight);
				}
			}
		}

		protected Vector3 GetGoalPivotOffset()
		{
			if (!GoalPivotOffsetDetected())
			{
				return Vector3.zero;
			}
			Vector3 normalized = (IKTargetPosition - IKBones[0].transform.position).normalized;
			Vector3 rhs = new Vector3(normalized.y, normalized.z, normalized.x);
			if (IKBones[IKBones.Length - 2].AngleLimit < 180f || IKBones[IKBones.Length - 2].TwistAngleLimit < 180f)
			{
				rhs = IKBones[IKBones.Length - 2].transform.rotation * IKBones[IKBones.Length - 2].ForwardOrientation;
			}
			return Vector3.Cross(normalized, rhs) * IKBones[IKBones.Length - 2].BoneLength * 0.5f;
		}

		private bool GoalPivotOffsetDetected()
		{
			if (!base.Initialized)
			{
				return false;
			}
			Vector3 vector = base.Bones[base.Bones.Length - 1].transform.position - base.Bones[0].transform.position;
			Vector3 vector2 = IKTargetPosition - base.Bones[0].transform.position;
			float magnitude = vector.magnitude;
			float magnitude2 = vector2.magnitude;
			if (magnitude2 == 0f)
			{
				return false;
			}
			if (magnitude == 0f)
			{
				return false;
			}
			if (magnitude < magnitude2)
			{
				return false;
			}
			if (magnitude < base.fullLength - base.Bones[base.Bones.Length - 2].BoneLength * 0.1f)
			{
				return false;
			}
			if (magnitude2 > magnitude)
			{
				return false;
			}
			if (Vector3.Dot(vector / magnitude, vector2 / magnitude2) < 0.999f)
			{
				return false;
			}
			return true;
		}

		private Vector3 RefreshLocalDirection()
		{
			LocalDirection = base.Bones[0].transform.InverseTransformDirection(base.Bones[base.Bones.Length - 1].transform.position - base.Bones[0].transform.position);
			return LocalDirection;
		}

		private float GetVelocityDifference()
		{
			return Vector3.SqrMagnitude(LocalDirection - LastLocalDirection);
		}

		public void AutoLimitAngle(float angleLimit = 60f, float twistAngleLimit = 50f)
		{
			if (IKBones != null)
			{
				float num = 1f / (float)IKBones.Length;
				for (int i = 0; i < IKBones.Length; i++)
				{
					IKBones[i].AngleLimit = angleLimit * Mathf.Min(1f, (float)(i + 1) * num * 3f);
					IKBones[i].TwistAngleLimit = twistAngleLimit * Mathf.Min(1f, (float)(i + 1) * num * 4.5f);
				}
			}
		}

		public void AutoWeightBones(float baseValue = 1f)
		{
			float num = baseValue / ((float)base.Bones.Length * 1.3f);
			for (int i = 0; i < base.Bones.Length; i++)
			{
				base.Bones[i].MotionWeight = baseValue - num * (float)i;
			}
		}

		public void AutoWeightBones(AnimationCurve weightCurve)
		{
			for (int i = 0; i < base.Bones.Length; i++)
			{
				base.Bones[i].MotionWeight = Mathf.Clamp(weightCurve.Evaluate((float)i / (float)base.Bones.Length), 0f, 1f);
			}
		}
	}
}
