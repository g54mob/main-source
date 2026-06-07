using System;
using System.Collections.Generic;
using FIMSpace.AnimationTools;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[Serializable]
	public class RagdollBonesChain
	{
		[NonSerialized]
		private RagdollHandler _prentHandler;

		public string ChainName = "Bones Chain";

		public ERagdollChainType ChainType = ERagdollChainType.Unknown;

		public List<RagdollChainBone> BoneSetups = new List<RagdollChainBone>();

		[Tooltip("Multiplicator value for colliders size excluding bone-forward axis")]
		[Range(0.1f, 2f)]
		public float ChainThicknessMultiplier = 1f;

		[Tooltip("Multiplicator value for colliders size")]
		[Range(0f, 2f)]
		public float ChainScaleMultiplier = 1f;

		[Tooltip("Multiplying target mass value for all bones in the chain")]
		[Range(0f, 1f)]
		public float MassMultiplier = 1f;

		[Tooltip("Multiplying target joint force value for all bones in the chain")]
		[Range(0f, 2f)]
		public float MusclesForce = 1f;

		[Tooltip("Multiplying target joint angle limit ranges for all bones in the chain")]
		[Range(0.1f, 2f)]
		public float AxisLimitRange = 1f;

		[Tooltip("Bypassing configurable joint limits")]
		public bool UnlimitedRotations;

		[Tooltip("Joints connected mass scale - Can help out calming down too much sensitive bones")]
		public float ConnectedMassScale = 1f;

		[Tooltip("If this connected mass value should be used all the time, and not serve as multiplier")]
		public bool ConnectedMassOverride;

		[Tooltip("Detaching limb bones hierarchy. It can help animating tails and fixes handling kinematic bones, but it is not working with reconstruction mode.")]
		public bool Detach = true;

		[Tooltip("Selective limb Ragdoll Blend multiplier")]
		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		public float ChainBlend = 1f;

		[Tooltip("Override all ragdoll blend parameters (not including internal per bone blend multipliers) with this value (set 0 to not use it, set 0.0000001 to override blend chain being off)")]
		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		public float OverrideBlend;

		[Tooltip("Applying alternative interia tensors for the chain's rigidbodies. It will make motion smooth and slower, dedicated to be used just in long chains made out of many bones or chains which are unstable.")]
		public bool AlternativeTensors;

		[Tooltip("Alternative tensors switch on fall mode.")]
		public bool AlternativeTensorsOnFall;

		internal bool tensorsSwitched;

		[Tooltip("Multiplying hard matching parameter over whole chain")]
		[Range(0f, 1f)]
		public float HardMatchMultiply = 1f;

		[NonSerialized]
		public float blendOnCollisionCulldown;

		[NonSerialized]
		public float blendOnCollisionMin;

		private bool playmodeDetached;

		public RagdollHandler ParentHandler => _prentHandler;

		public RagdollChainBone LastBone => BoneSetups[BoneSetups.Count - 1];

		[field: NonSerialized]
		public List<RagdollBoneProcessor> RuntimeBoneProcessors { get; private set; }

		[field: NonSerialized]
		public RagdollChainBone ConnectionBone { get; private set; }

		public float ChainBonesLength { get; private set; }

		public bool PlaymodeInitialized { get; private set; }

		public List<RagdollChainBone.InBetweenBone> ParentConnectionBones { get; private set; }

		public Transform DummyParentObject { get; private set; }

		public void AutoAdjustColliders(bool isHumanoid)
		{
			if (ChainType == ERagdollChainType.Core || ChainType == ERagdollChainType.Unknown)
			{
				AutoAdjustColliders_Core(isHumanoid);
			}
			else
			{
				AutoAdjustColliders_Limb();
			}
		}

		public void AutoAdjustColliders_Limb()
		{
			for (int i = 0; i < BoneSetups.Count; i++)
			{
				Transform sourceBone = BoneSetups[i].SourceBone;
				if (!(sourceBone == null))
				{
					Transform transform = null;
					if (i < BoneSetups.Count - 1)
					{
						transform = BoneSetups[i + 1].SourceBone;
					}
					if (transform == null)
					{
						transform = SkeletonRecognize.GetContinousChildTransform(sourceBone);
					}
					RagdollChainBone ragdollChainBone = BoneSetups[i];
					Vector3 vector = sourceBone.position;
					if ((ChainType.IsLeg() || ChainType.IsArm()) && i == 0 && (bool)sourceBone.parent)
					{
						vector = Vector3.LerpUnclamped(sourceBone.parent.position, vector, 0.75f);
					}
					if (transform != null)
					{
						AdjustColliderSettingsBasingOnTheStartEndPosition(ragdollChainBone, i, vector, transform.position);
					}
					else if ((bool)ragdollChainBone.SourceBone && ragdollChainBone.BaseColliderSetup != null && ragdollChainBone.SourceBone.lossyScale.x != 0f)
					{
						ragdollChainBone.BaseColliderSetup.ColliderBoxSize = Vector3.one * (1f / ragdollChainBone.SourceBone.lossyScale.x);
						ragdollChainBone.BaseColliderSetup.ColliderLength = 1f / ragdollChainBone.SourceBone.lossyScale.y;
						ragdollChainBone.BaseColliderSetup.ColliderRadius = 1f / ragdollChainBone.SourceBone.lossyScale.x;
					}
				}
			}
		}

		public void AutoAdjustColliders_Core(bool isHumanoid)
		{
			if (BoneSetups.Count < 1 || BoneSetups[0].SourceBone == null)
			{
				return;
			}
			Transform baseTransform = ParentHandler.GetBaseTransform();
			Vector3 vector = BoneSetups[0].SourceBone.position;
			Vector3 position = BoneSetups[0].SourceBone.position;
			_ = (vector - baseTransform.position).normalized;
			for (int i = 0; i < BoneSetups.Count; i++)
			{
				Transform sourceBone = BoneSetups[i].SourceBone;
				if (sourceBone == null)
				{
					continue;
				}
				RagdollChainBone bone = BoneSetups[i];
				if (i == BoneSetups.Count - 1 && isHumanoid)
				{
					List<SkinnedMeshRenderer> list = new List<SkinnedMeshRenderer>();
					Transform[] componentsInChildren = baseTransform.GetComponentsInChildren<Transform>(includeInactive: true);
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						SkinnedMeshRenderer component = componentsInChildren[j].GetComponent<SkinnedMeshRenderer>();
						if ((bool)component)
						{
							list.Add(component);
						}
					}
					Vector3 axis = FVectorMethods.ChooseDominantAxis(baseTransform.InverseTransformDirection(sourceBone.position - vector));
					Vector3 vector2 = baseTransform.InverseTransformPoint(vector);
					if (list.Count > 0)
					{
						float num = GetAxisValue(axis, vector2);
						Vector3 vector3 = vector2;
						for (int k = 0; k < list.Count; k++)
						{
							SkinnedMeshRenderer skinnedMeshRenderer = list[k];
							Vector3 vector4 = baseTransform.InverseTransformPoint(skinnedMeshRenderer.bounds.max);
							Vector3 vector5 = baseTransform.InverseTransformPoint(skinnedMeshRenderer.bounds.min);
							float axisValue = GetAxisValue(axis, vector4);
							if (axisValue > num)
							{
								num = axisValue;
								vector3 = vector4;
							}
							axisValue = GetAxisValue(axis, vector5);
							if (axisValue > num)
							{
								num = axisValue;
								vector3 = vector5;
							}
						}
						vector3 = ((!(vector3 == vector2)) ? SetAxisValue(axis, vector2, vector3) : baseTransform.InverseTransformPoint(SkeletonRecognize.GetContinousChildTransform(sourceBone).position));
						position = baseTransform.TransformPoint(vector3);
					}
					else
					{
						float num2 = GetAxisValue(axis, vector2);
						Transform transform = sourceBone;
						componentsInChildren = sourceBone.GetComponentsInChildren<Transform>(includeInactive: true);
						foreach (Transform transform2 in componentsInChildren)
						{
							Vector3 getFrom = baseTransform.InverseTransformPoint(transform2.position);
							float axisValue2 = GetAxisValue(axis, getFrom);
							if (axisValue2 > num2)
							{
								num2 = axisValue2;
								transform = transform2;
							}
						}
						if (transform == sourceBone)
						{
							transform = SkeletonRecognize.GetContinousChildTransform(sourceBone);
						}
						position = transform.position + (transform.position - vector) * 0.3f;
					}
					AdjustColliderSettingsBasingOnTheStartEndPosition(bone, i, vector, position);
				}
				else if (i == 0)
				{
					if (sourceBone.childCount > 1)
					{
						Vector3 a = Vector3.zero;
						float num3 = 0f;
						for (int l = 0; l < sourceBone.childCount; l++)
						{
							Transform child = sourceBone.GetChild(l);
							if (!(child == sourceBone))
							{
								a = ((num3 != 0f) ? Vector3.LerpUnclamped(a, child.position, 0.5f) : child.position);
								num3 += 1f;
							}
						}
						vector = Vector3.LerpUnclamped(a, vector, (num3 == 2f) ? 0.3f : 0.75f);
						position = BoneSetups[i + 1].SourceBone.position;
					}
					else
					{
						vector = Vector3.LerpUnclamped(baseTransform.position, vector, 0.9f);
						position = BoneSetups[i + 1].SourceBone.position;
					}
				}
				else if (i + 1 < BoneSetups.Count)
				{
					if (BoneSetups[i + 1].SourceBone == null)
					{
						Debug.Log("[Ragdoll Animator 2] Ragdoll Generator - Null bone in " + ChainName + " chain!");
						break;
					}
					position = BoneSetups[i + 1].SourceBone.position;
				}
				else
				{
					if (BoneSetups[i].SourceBone == null || BoneSetups[i - 1].SourceBone == null)
					{
						break;
					}
					position = BoneSetups[i].SourceBone.position + (BoneSetups[i].SourceBone.position - BoneSetups[i - 1].SourceBone.position);
				}
				AdjustColliderSettingsBasingOnTheStartEndPosition(bone, i, vector, position);
				vector = position;
			}
		}

		public Vector3 AdjustColliderSettingsBasingOnTheStartEndPosition(RagdollChainBone bone, int boneIndex, Vector3 startPosition, Vector3 targetEndPosition)
		{
			Vector3 vector = targetEndPosition - startPosition;
			Vector3 normalized = vector.normalized;
			float magnitude = bone.SourceBone.InverseTransformVector(vector).magnitude;
			Vector3 position = Vector3.LerpUnclamped(targetEndPosition, startPosition, 0.5f);
			float x = bone.SourceBone.lossyScale.x;
			x = ((x == 0f) ? 1f : (1f / x));
			float num = GetChainAverageRadius(boneIndex) * x;
			Vector3 axis = bone.SourceBone.InverseTransformVector(normalized);
			axis = FVectorMethods.ChooseDominantAxis(axis);
			bone.BaseColliderSetup.ColliderBoxSize = Vector3.one * (num * 1.5f);
			bone.BaseColliderSetup.ColliderLength = magnitude;
			AdjustColliderDirectionParams(bone, axis, magnitude);
			bone.BaseColliderSetup.ColliderCenter = bone.SourceBone.InverseTransformPoint(position);
			bone.BaseColliderSetup.ColliderRadius = Mathf.Min(bone.BaseColliderSetup.ColliderLength, num);
			if (bone.BaseColliderSetup.ColliderLength / 2f < bone.BaseColliderSetup.ColliderRadius)
			{
				bone.BaseColliderSetup.ColliderLength = bone.BaseColliderSetup.ColliderRadius * 2f;
			}
			if (bone.BaseColliderSetup.ColliderType == RagdollChainBone.EColliderType.Sphere)
			{
				bone.BaseColliderSetup.ColliderRadius = magnitude / 2f;
			}
			return axis;
		}

		private void AdjustColliderDirectionParams(RagdollChainBone bone, Vector3 colliderDir, float diffLocalMagn)
		{
			if (colliderDir.x > 0.1f || colliderDir.x < -0.1f)
			{
				bone.BaseColliderSetup.ColliderBoxSize.x = diffLocalMagn;
				bone.BaseColliderSetup.CapsuleDirection = RagdollChainBone.ECapsuleDirection.X;
			}
			if (colliderDir.y > 0.1f || colliderDir.y < -0.1f)
			{
				bone.BaseColliderSetup.ColliderBoxSize.y = diffLocalMagn;
				bone.BaseColliderSetup.CapsuleDirection = RagdollChainBone.ECapsuleDirection.Y;
			}
			if (colliderDir.z > 0.1f || colliderDir.z < -0.1f)
			{
				bone.BaseColliderSetup.ColliderBoxSize.z = diffLocalMagn;
				bone.BaseColliderSetup.CapsuleDirection = RagdollChainBone.ECapsuleDirection.Z;
			}
		}

		private float GetAxisValue(Vector3 axis, Vector3 getFrom)
		{
			if (axis.x > 0.1f || axis.x < -0.1f)
			{
				return getFrom.x;
			}
			if (axis.y > 0.1f || axis.y < -0.1f)
			{
				return getFrom.y;
			}
			if (axis.z > 0.1f || axis.z < -0.1f)
			{
				return getFrom.z;
			}
			return 0f;
		}

		private Vector3 SetAxisValue(Vector3 axis, Vector3 baseValue, Vector3 selectFrom)
		{
			if (axis.x > 0.1f || axis.x < -0.1f)
			{
				return new Vector3(selectFrom.x, baseValue.y, baseValue.z);
			}
			if (axis.y > 0.1f || axis.y < -0.1f)
			{
				return new Vector3(baseValue.x, selectFrom.y, baseValue.z);
			}
			if (axis.z > 0.1f || axis.z < -0.1f)
			{
				return new Vector3(baseValue.x, baseValue.y, selectFrom.z);
			}
			return baseValue;
		}

		public float GetChainAverageRadius(int boneIndex)
		{
			if (ChainType == ERagdollChainType.Core)
			{
				if (boneIndex > 1 && boneIndex == BoneSetups.Count - 1)
				{
					return 0.14f;
				}
				return 0.185f;
			}
			if (ChainType.IsArm())
			{
				if (BoneSetups.Count > 2 && boneIndex == BoneSetups.Count - 1)
				{
					return 0.05f;
				}
				return 0.06f;
			}
			if (ChainType.IsLeg())
			{
				return 0.085f;
			}
			return 0.04f;
		}

		public static void CopyColliderSettingTo(Collider copyFrom, Collider pasteTo)
		{
			if (copyFrom is CapsuleCollider && pasteTo is CapsuleCollider)
			{
				CapsuleCollider capsuleCollider = copyFrom as CapsuleCollider;
				CapsuleCollider obj = pasteTo as CapsuleCollider;
				CopyProvidesContacts(obj, capsuleCollider);
				obj.center = capsuleCollider.center;
				obj.radius = capsuleCollider.radius;
				obj.direction = capsuleCollider.direction;
				obj.height = capsuleCollider.height;
			}
			else if (copyFrom is SphereCollider && pasteTo is SphereCollider)
			{
				SphereCollider sphereCollider = copyFrom as SphereCollider;
				SphereCollider obj2 = pasteTo as SphereCollider;
				CopyProvidesContacts(obj2, sphereCollider);
				obj2.center = sphereCollider.center;
				obj2.radius = sphereCollider.radius;
			}
			else if (copyFrom is BoxCollider && pasteTo is BoxCollider)
			{
				BoxCollider boxCollider = copyFrom as BoxCollider;
				BoxCollider obj3 = pasteTo as BoxCollider;
				CopyProvidesContacts(obj3, boxCollider);
				obj3.center = boxCollider.center;
				obj3.size = boxCollider.size;
			}
			else if (copyFrom is MeshCollider && pasteTo is MeshCollider)
			{
				MeshCollider meshCollider = copyFrom as MeshCollider;
				MeshCollider obj4 = pasteTo as MeshCollider;
				obj4.convex = meshCollider.convex;
				CopyProvidesContacts(obj4, meshCollider);
				obj4.sharedMesh = meshCollider.sharedMesh;
			}
			pasteTo.sharedMaterial = copyFrom.sharedMaterial;
		}

		private static void CopyProvidesContacts(Collider to, Collider from)
		{
			to.providesContacts = from.providesContacts;
		}

		public void AutoAdjustPhysics()
		{
			if (BoneSetups.Count != 0)
			{
				float totalLimbMul = GetChainTypePercentageMass() * 0.01f;
				for (int i = 0; i < BoneSetups.Count; i++)
				{
					BoneSetups[i].MassMultiplier = GetBoneMassPercentage(i, totalLimbMul) * 0.01f * 2f;
				}
				MassMultiplier = 0.5f;
				AutoAdjustJointsAxes();
				AutoAdjustJointsLimits();
			}
		}

		public void AutoAdjustJointsAxes()
		{
			for (int i = 0; i < BoneSetups.Count; i++)
			{
				Transform sourceBone = BoneSetups[i].SourceBone;
				if (!(sourceBone == null))
				{
					Transform transform = null;
					if (i < BoneSetups.Count - 1)
					{
						transform = BoneSetups[i + 1].SourceBone;
					}
					if (transform == null)
					{
						transform = SkeletonRecognize.GetContinousChildTransform(sourceBone);
					}
					RagdollChainBone bone = BoneSetups[i];
					Vector3 position = sourceBone.position;
					if (!(transform == null))
					{
						AdjustJointAxesBasingOnTheStartEndPosition(bone, i, position, transform.position);
					}
				}
			}
			if (ChainType != ERagdollChainType.Core)
			{
				return;
			}
			RagdollChainBone ragdollChainBone = BoneSetups[BoneSetups.Count - 1];
			if (BoneSetups.Count > 2)
			{
				if (ParentHandler == null || ParentHandler.GetBaseTransform() == null)
				{
					ragdollChainBone.SetMainAxisByVector(Vector3.Cross(ragdollChainBone.GetMainAxis(), ragdollChainBone.GetSecondaryAxis()));
				}
				else
				{
					ragdollChainBone.SetMainAxisByVector(ragdollChainBone.SourceBone.InverseTransformDirection(ParentHandler.GetBaseTransform().right));
					ragdollChainBone.SetSecondaryAxisByVector(ragdollChainBone.SourceBone.InverseTransformDirection(ParentHandler.GetBaseTransform().forward));
				}
				if (ragdollChainBone.MainAxis != EJointAxis.Custom && ragdollChainBone.MainAxis == ragdollChainBone.SecondaryAxis)
				{
					ragdollChainBone.SetMainAxisByVector(FVectorMethods.GetCounterAxis(ragdollChainBone.GetMainAxis()));
				}
			}
		}

		private void AdjustJointAxesBasingOnTheStartEndPosition(RagdollChainBone bone, int boneIndex, Vector3 startPosition, Vector3 targetEndPosition)
		{
			Vector3 normalized = (targetEndPosition - startPosition).normalized;
			Vector3 secondaryAxisByVector = bone.SourceBone.InverseTransformVector(normalized);
			bone.SetSecondaryAxisByVector(secondaryAxisByVector);
			secondaryAxisByVector = bone.GetSecondaryAxis();
			bone.SetMainAxisByVector(Vector3.Cross(secondaryAxisByVector, -bone.SourceBone.InverseTransformVector(ParentHandler.GetBaseTransform().forward)));
			if (bone.MainAxis != EJointAxis.Custom && bone.MainAxis == bone.SecondaryAxis)
			{
				bone.SetMainAxisByVector(FVectorMethods.GetCounterAxis(bone.GetMainAxis()));
			}
		}

		public void AutoAdjustJointsLimits()
		{
			RagdollChainBone ragdollChainBone = BoneSetups[0];
			if (ChainType == ERagdollChainType.Core)
			{
				ragdollChainBone.MainAxisLowLimit = -35f;
				ragdollChainBone.MainAxisHighLimit = 35f;
				ragdollChainBone.SecondaryAxisAngleLimit = 20f;
				ragdollChainBone.ThirdAxisAngleLimit = 20f;
			}
			else if (ChainType.IsLeg())
			{
				ragdollChainBone.MainAxisLowLimit = -55f;
				ragdollChainBone.MainAxisHighLimit = 45f;
				ragdollChainBone.SecondaryAxisAngleLimit = 15f;
				ragdollChainBone.ThirdAxisAngleLimit = 45f;
			}
			else if (ChainType.IsArm())
			{
				ragdollChainBone.MainAxisLowLimit = -50f;
				ragdollChainBone.MainAxisHighLimit = 75f;
				ragdollChainBone.SecondaryAxisAngleLimit = 35f;
				ragdollChainBone.ThirdAxisAngleLimit = 55f;
			}
			else
			{
				ragdollChainBone.MainAxisLowLimit = -35f;
				ragdollChainBone.MainAxisHighLimit = 35f;
				ragdollChainBone.SecondaryAxisAngleLimit = 35f;
				ragdollChainBone.ThirdAxisAngleLimit = 35f;
			}
			if (BoneSetups.Count < 2)
			{
				return;
			}
			for (int i = 1; i < BoneSetups.Count - 1; i++)
			{
				RagdollChainBone ragdollChainBone2 = BoneSetups[i];
				if (ChainType == ERagdollChainType.Core)
				{
					float num = BoneSetups.Count - 2;
					if (num < 1f)
					{
						num = 1f;
					}
					ragdollChainBone2.MainAxisLowLimit = -22f / num;
					ragdollChainBone2.MainAxisHighLimit = 70f / num;
					ragdollChainBone2.SecondaryAxisAngleLimit = 30f;
					ragdollChainBone2.ThirdAxisAngleLimit = 20f;
				}
				else if (ChainType.IsLeg())
				{
					ragdollChainBone2.MainAxisLowLimit = -60f;
					ragdollChainBone2.MainAxisHighLimit = 10f;
					ragdollChainBone2.SecondaryAxisAngleLimit = 10f;
					ragdollChainBone2.ThirdAxisAngleLimit = 15f;
				}
				else if (ChainType.IsArm())
				{
					ragdollChainBone2.MainAxisLowLimit = -8f;
					ragdollChainBone2.MainAxisHighLimit = 55f;
					ragdollChainBone2.SecondaryAxisAngleLimit = 10f;
					ragdollChainBone2.ThirdAxisAngleLimit = 10f;
				}
				else
				{
					ragdollChainBone2.MainAxisLowLimit = -30f;
					ragdollChainBone2.MainAxisHighLimit = 30f;
					ragdollChainBone2.SecondaryAxisAngleLimit = 30f;
					ragdollChainBone2.ThirdAxisAngleLimit = 30f;
				}
			}
			RagdollChainBone ragdollChainBone3 = BoneSetups[BoneSetups.Count - 1];
			if (ChainType == ERagdollChainType.Core)
			{
				ragdollChainBone3.MainAxisLowLimit = -45f;
				ragdollChainBone3.MainAxisHighLimit = 30f;
				ragdollChainBone3.SecondaryAxisAngleLimit = 20f;
				ragdollChainBone3.ThirdAxisAngleLimit = 55f;
			}
			else if (ChainType.IsLeg())
			{
				ragdollChainBone3.MainAxisLowLimit = -40f;
				ragdollChainBone3.MainAxisHighLimit = 40f;
				ragdollChainBone3.SecondaryAxisAngleLimit = 15f;
				ragdollChainBone3.ThirdAxisAngleLimit = 40f;
			}
			else if (ChainType.IsArm())
			{
				ragdollChainBone3.MainAxisLowLimit = -75f;
				ragdollChainBone3.MainAxisHighLimit = 50f;
				ragdollChainBone3.SecondaryAxisAngleLimit = 90f;
				ragdollChainBone3.ThirdAxisAngleLimit = 30f;
			}
			else
			{
				ragdollChainBone3.MainAxisLowLimit = -30f;
				ragdollChainBone3.MainAxisHighLimit = 30f;
				ragdollChainBone3.SecondaryAxisAngleLimit = 30f;
				ragdollChainBone3.ThirdAxisAngleLimit = 30f;
			}
		}

		public float GetChainTypePercentageMass()
		{
			if (ChainType == ERagdollChainType.Core)
			{
				return 50f;
			}
			if (ChainType.IsLeg())
			{
				return 16f;
			}
			if (ChainType.IsArm())
			{
				return 6f;
			}
			if (ChainType == ERagdollChainType.OtherLimb)
			{
				return 20f;
			}
			return 16f;
		}

		public float GetBoneMassPercentage(int index, float totalLimbMul)
		{
			if (index == BoneSetups.Count - 1 && BoneSetups.Count > 2)
			{
				if (ChainType == ERagdollChainType.Core)
				{
					return totalLimbMul * 12f;
				}
				if (ChainType.IsLeg())
				{
					return totalLimbMul * 14f;
				}
				if (ChainType.IsArm())
				{
					return totalLimbMul * 14f;
				}
				if (ChainType == ERagdollChainType.OtherLimb)
				{
					return totalLimbMul / (float)BoneSetups.Count * 16f;
				}
				return totalLimbMul / (float)BoneSetups.Count * 14f;
			}
			if (index == 0)
			{
				float num = BoneSetups.Count - 3;
				if (num < 1f)
				{
					num = 1f;
				}
				if (ChainType == ERagdollChainType.Core)
				{
					return totalLimbMul * 26f / num;
				}
				if (ChainType.IsLeg())
				{
					return totalLimbMul * 50f / num;
				}
				if (ChainType.IsArm())
				{
					return totalLimbMul * 45f / num;
				}
				_ = ChainType;
				_ = 64;
				return totalLimbMul / (float)BoneSetups.Count * 18f / num;
			}
			float num2 = BoneSetups.Count - 2;
			if (num2 < 1f)
			{
				num2 = 1f;
			}
			if (ChainType == ERagdollChainType.Core)
			{
				return totalLimbMul * 24f / num2;
			}
			if (ChainType.IsLeg())
			{
				return totalLimbMul * 25f / num2;
			}
			if (ChainType.IsArm())
			{
				return totalLimbMul * 28f / num2;
			}
			if (ChainType == ERagdollChainType.OtherLimb)
			{
				return totalLimbMul / (float)BoneSetups.Count * 16f / num2;
			}
			return totalLimbMul / (float)BoneSetups.Count * 18f / num2;
		}

		public float GetChainTypePercentageMassReal()
		{
			if (ChainType == ERagdollChainType.Core)
			{
				return 58f;
			}
			if (ChainType.IsLeg())
			{
				return 16f;
			}
			if (ChainType.IsArm())
			{
				return 5f;
			}
			if (ChainType == ERagdollChainType.OtherLimb)
			{
				return 5f;
			}
			return 8f;
		}

		public float GetBoneMassPercentageReal(int index, float totalLimbMul)
		{
			if (index == BoneSetups.Count - 1 && BoneSetups.Count > 2)
			{
				if (ChainType == ERagdollChainType.Core)
				{
					return totalLimbMul * 13.79f;
				}
				if (ChainType.IsLeg())
				{
					return totalLimbMul * 9.375f;
				}
				if (ChainType.IsArm())
				{
					return totalLimbMul * 14f;
				}
				if (ChainType == ERagdollChainType.OtherLimb)
				{
					return totalLimbMul / (float)BoneSetups.Count * 0.55f;
				}
				return totalLimbMul / (float)BoneSetups.Count * 0.65f;
			}
			if (index == 0)
			{
				float num = BoneSetups.Count - 3;
				if (num < 1f)
				{
					num = 1f;
				}
				if (ChainType == ERagdollChainType.Core)
				{
					return totalLimbMul * 29.3f / num;
				}
				if (ChainType.IsLeg())
				{
					return totalLimbMul * 63f / num;
				}
				if (ChainType.IsArm())
				{
					return totalLimbMul * 54f / num;
				}
				_ = ChainType;
				_ = 64;
				return totalLimbMul / (float)BoneSetups.Count * 1f / num;
			}
			float num2 = BoneSetups.Count - 2;
			if (num2 < 1f)
			{
				num2 = 1f;
			}
			if (ChainType == ERagdollChainType.Core)
			{
				return totalLimbMul * 26.3f / num2;
			}
			if (ChainType.IsLeg())
			{
				return totalLimbMul * 27.5f / num2;
			}
			if (ChainType.IsArm())
			{
				return totalLimbMul * 32f / num2;
			}
			_ = ChainType;
			_ = 64;
			return totalLimbMul / (float)BoneSetups.Count * 0.8f / num2;
		}

		public void EnsureCollisionIgnoreBetweenChildBones()
		{
			if (BoneSetups.Count > 1)
			{
				RagdollChainBone otherBone = BoneSetups[0];
				for (int i = 1; i < BoneSetups.Count; i++)
				{
					BoneSetups[i].IgnoreCollisionsWith(otherBone);
					otherBone = BoneSetups[i];
				}
			}
			if (BoneSetups.Count > 0 && ConnectionBone != null)
			{
				BoneSetups[0].IgnoreCollisionsWith(ConnectionBone);
			}
		}

		public void CheckIfShouldIgnoreByBounds(RagdollChainBone otherBone, float boundsSize = 1.1f)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				if (boneSetup != otherBone)
				{
					boneSetup.CheckIfShouldIgnoreByBounds(otherBone, boundsSize);
				}
			}
		}

		private void ScaleCollider(Collider c, float scale)
		{
			if (c is BoxCollider)
			{
				BoxCollider obj = c as BoxCollider;
				obj.size *= scale;
				obj.center *= scale;
			}
			else if (c is SphereCollider)
			{
				SphereCollider obj2 = c as SphereCollider;
				obj2.radius *= scale;
				obj2.center *= scale;
			}
			else if (c is CapsuleCollider)
			{
				CapsuleCollider obj3 = c as CapsuleCollider;
				obj3.height *= scale;
				obj3.radius *= scale;
				obj3.center *= scale;
			}
		}

		public void EnsureCollisionIgnoreBetweenBonesUsingBounds(List<RagdollBonesChain> chains, float scaleUpFactor = 1.2f)
		{
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in BoneSetups)
				{
					if (boneSetup.MainBoneCollider == null || boneSetup.BoundedIgnoreScale <= 0f)
					{
						continue;
					}
					foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
					{
						Collider gameCollider = collider.GameCollider;
						if (gameCollider.transform.lossyScale.x == 0f)
						{
							Debug.Log("[Ragdoll Animator 2] Detected zero scale object! It is not supported! (" + gameCollider.transform.name + ")");
							continue;
						}
						Bounds bounds = gameCollider.bounds;
						bounds.size *= scaleUpFactor * collider.BoundedIgnoreScale * boneSetup.BoundedIgnoreScale;
						ScaleCollider(gameCollider, gameCollider.transform.lossyScale.x * scaleUpFactor * boneSetup.BoundedIgnoreScale);
						foreach (RagdollChainBone boneSetup2 in chain.BoneSetups)
						{
							if (boneSetup == boneSetup2 || boneSetup2.MainBoneCollider == null || boneSetup2.BoundedIgnoreScale <= 0f)
							{
								continue;
							}
							foreach (RagdollChainBone.ColliderSetup collider2 in boneSetup2.Colliders)
							{
								Collider gameCollider2 = collider2.GameCollider;
								if (gameCollider2.transform.lossyScale.x == 0f)
								{
									Debug.Log("[Ragdoll Animator 2] Detected zero scale object! It is not supported! (" + gameCollider2.transform.name + ")");
									continue;
								}
								Bounds bounds2 = collider2.GameCollider.bounds;
								bounds2.size *= scaleUpFactor * collider2.BoundedIgnoreScale * boneSetup2.BoundedIgnoreScale;
								if (bounds.Intersects(bounds2))
								{
									collider2.IgnoreCollisionWith(collider, ignore: true);
								}
								if (!(collider.GameCollider is MeshCollider) && !(gameCollider2 is MeshCollider))
								{
									ScaleCollider(gameCollider2, gameCollider2.transform.lossyScale.x * scaleUpFactor * boneSetup2.BoundedIgnoreScale);
									if (Physics.ComputePenetration(gameCollider, gameCollider.transform.position, gameCollider.transform.rotation, gameCollider2, gameCollider2.transform.position, gameCollider2.transform.rotation, out var _, out var _))
									{
										collider2.IgnoreCollisionWith(collider, ignore: true);
									}
									ScaleCollider(gameCollider2, 1f / (gameCollider2.transform.lossyScale.x * scaleUpFactor * boneSetup2.BoundedIgnoreScale));
								}
							}
						}
						ScaleCollider(gameCollider, 1f / (gameCollider.transform.lossyScale.x * scaleUpFactor * boneSetup.BoundedIgnoreScale));
					}
				}
			}
			bool isFallingOrSleep = ParentHandler.IsFallingOrSleep;
			foreach (RagdollBonesChain chain2 in chains)
			{
				foreach (RagdollChainBone boneSetup3 in BoneSetups)
				{
					boneSetup3.RefreshCollider(chain2, isFallingOrSleep, onSource: false);
				}
			}
		}

		public void RemoveBoneAndItsChildren(RagdollChainBone parentBone)
		{
			List<RagdollChainBone> list = CollectAllConnectedBones(parentBone);
			List<RagdollChainBone.InBetweenBone> list2 = CollectAllFillBones(list);
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				RagdollChainBone.InBetweenBone inBetweenBone = list2[num];
				ParentHandler.skeletonFillExtraBonesList.Remove(inBetweenBone);
				if ((bool)inBetweenBone.DummyBone)
				{
					UnityEngine.Object.Destroy(inBetweenBone.DummyBone.gameObject);
				}
			}
			foreach (RagdollChainBone item in list)
			{
				item.ParentDismembered = true;
				if ((bool)item.GameRigidbody)
				{
					UnityEngine.Object.Destroy(item.GameRigidbody.gameObject);
				}
			}
			foreach (RagdollChainBone item2 in list)
			{
				item2.ParentChain.RemoveRuntimeBoneProcessing(item2);
				item2.ParentChain.ParentHandler.RemoveBoneFromRuntimeCalculations(item2);
			}
		}

		public void RemoveRuntimeBoneProcessing(RagdollChainBone ragdollChainBone)
		{
			RuntimeBoneProcessors.Remove(ragdollChainBone.BoneProcessor);
			BoneSetups.Remove(ragdollChainBone);
		}

		public List<RagdollChainBone> CollectAllConnectedBones(RagdollChainBone bone, bool includeSelf = true)
		{
			List<RagdollChainBone> list = new List<RagdollChainBone>();
			int index = bone.ParentChain.GetIndex(bone);
			if (index == -1)
			{
				return list;
			}
			if (includeSelf)
			{
				list.Add(bone);
			}
			for (int i = index; i < bone.ParentChain.BoneSetups.Count; i++)
			{
				list.Add(bone.ParentChain.BoneSetups[i]);
			}
			foreach (RagdollBonesChain chain in ParentHandler.Chains)
			{
				if (chain == this || !list.Contains(chain.ConnectionBone))
				{
					continue;
				}
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					list.Add(boneSetup);
				}
			}
			return list;
		}

		public List<RagdollChainBone.InBetweenBone> CollectAllFillBones(List<RagdollChainBone> bones)
		{
			List<RagdollChainBone.InBetweenBone> list = new List<RagdollChainBone.InBetweenBone>();
			for (int num = ParentHandler.skeletonFillExtraBonesList.Count - 1; num >= 0; num--)
			{
				RagdollChainBone.InBetweenBone inBetweenBone = ParentHandler.skeletonFillExtraBonesList[num];
				foreach (RagdollChainBone bone in bones)
				{
					if (SkeletonRecognize.IsChildOf(inBetweenBone.DummyBone, bone.PhysicalDummyBone))
					{
						list.Add(inBetweenBone);
						break;
					}
				}
			}
			return list;
		}

		public void SwitchPhysics(bool enable)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.SwitchPhysics(enable);
			}
		}

		public void SetParentHandler(RagdollHandler handler)
		{
			_prentHandler = handler;
		}

		public float GetScaleMultiplier()
		{
			if (ParentHandler != null)
			{
				return ParentHandler.RagdollSizeMultiplier * ChainScaleMultiplier;
			}
			return ChainScaleMultiplier;
		}

		public float GetThicknessMultiplier()
		{
			if (ChainThicknessMultiplier == 0f)
			{
				ChainThicknessMultiplier = 1f;
			}
			if (ParentHandler != null)
			{
				if (ParentHandler.RagdollThicknessMultiplier == 0f)
				{
					ParentHandler.RagdollThicknessMultiplier = 1f;
				}
				return ParentHandler.RagdollThicknessMultiplier * ChainThicknessMultiplier;
			}
			return ChainThicknessMultiplier;
		}

		public void CompletePlaymodeInitialization()
		{
			if (PlaymodeInitialized)
			{
				return;
			}
			RuntimeBoneProcessors = new List<RagdollBoneProcessor>();
			ChainBonesLength = 0f;
			RagdollChainBone ragdollChainBone = null;
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.PlaymodeInitialize(this);
				if (!boneSetup.IsAnchor)
				{
					RuntimeBoneProcessors.Add(boneSetup.BoneProcessor);
				}
				if (ragdollChainBone != null)
				{
					ChainBonesLength += Vector3.Distance(ragdollChainBone.SourceBone.position, boneSetup.SourceBone.position);
				}
				boneSetup.SetParentBone(ragdollChainBone);
				ragdollChainBone = boneSetup;
			}
			PlaymodeInitialized = true;
		}

		public RagdollBonesChain(RagdollHandler ragdollHandler)
		{
			SetParentHandler(ragdollHandler);
		}

		public RagdollChainBone AddNewBone(Transform sceneBone)
		{
			if (sceneBone != null)
			{
				for (int i = 0; i < BoneSetups.Count; i++)
				{
					if (BoneSetups[i].SourceBone == sceneBone)
					{
						return BoneSetups[i];
					}
				}
			}
			RagdollChainBone ragdollChainBone = new RagdollChainBone();
			ragdollChainBone.SourceBone = sceneBone;
			BoneSetups.Add(ragdollChainBone);
			return ragdollChainBone;
		}

		public RagdollChainBone AddNewBone(ERagdollBoneID boneID, RagdollChainBone.EColliderType colliderType = RagdollChainBone.EColliderType.Capsule)
		{
			RagdollChainBone ragdollChainBone = AddNewBone(ParentHandler.Mecanim.GetBoneTransform((HumanBodyBones)boneID));
			ragdollChainBone.BaseColliderSetup.ColliderType = colliderType;
			ragdollChainBone.BoneID = boneID;
			return ragdollChainBone;
		}

		public RagdollChainBone AddNewBone(bool assignSuggestion = true, RagdollChainBone.EColliderType colliderType = RagdollChainBone.EColliderType.Capsule)
		{
			Transform sourceBone = null;
			if (assignSuggestion && BoneSetups.Count > 0)
			{
				Transform sourceBone2 = BoneSetups[BoneSetups.Count - 1].SourceBone;
				if (sourceBone2 != null)
				{
					sourceBone = SkeletonRecognize.GetContinousChildTransform(sourceBone2);
				}
			}
			return AddNewBone(sourceBone, colliderType);
		}

		public RagdollChainBone AddNewBone(Transform sourceBone, RagdollChainBone.EColliderType colliderType, ERagdollBoneID boneID = ERagdollBoneID.Unknown)
		{
			if (sourceBone != null)
			{
				for (int i = 0; i < BoneSetups.Count; i++)
				{
					if (BoneSetups[i].SourceBone == sourceBone)
					{
						return BoneSetups[i];
					}
				}
			}
			RagdollChainBone ragdollChainBone = new RagdollChainBone();
			ragdollChainBone.BoneID = boneID;
			ragdollChainBone.SourceBone = sourceBone;
			ragdollChainBone.BaseColliderSetup.ColliderType = colliderType;
			BoneSetups.Add(ragdollChainBone);
			return ragdollChainBone;
		}

		public void Setup_GatherChildBones()
		{
			if (BoneSetups.Count <= 0 || BoneSetups[0].SourceBone == null)
			{
				return;
			}
			Transform transform = BoneSetups[0].SourceBone;
			while (transform != null)
			{
				Transform continousChildTransform = SkeletonRecognize.GetContinousChildTransform(transform);
				if (!(continousChildTransform == null))
				{
					AddNewBone(continousChildTransform);
					transform = continousChildTransform;
					continue;
				}
				break;
			}
		}

		public RagdollChainBone GetBone(int index)
		{
			if (BoneSetups.Count == 0)
			{
				return null;
			}
			if (index >= BoneSetups.Count)
			{
				return LastBone;
			}
			return BoneSetups[index];
		}

		public int GetIndex(RagdollChainBone bone)
		{
			for (int i = 0; i < BoneSetups.Count; i++)
			{
				if (BoneSetups[i] == bone)
				{
					return i;
				}
			}
			return -1;
		}

		public RagdollChainBone GetParent(RagdollChainBone bone)
		{
			RagdollChainBone result = null;
			for (int i = 0; i < BoneSetups.Count - 1; i++)
			{
				if (BoneSetups[i + 1] == bone)
				{
					result = BoneSetups[i];
					break;
				}
			}
			return result;
		}

		public bool ContainsAnimatorBoneTransform(Transform checkBone)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				if (boneSetup.SourceBone == checkBone)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsAnimatorBoneTransform(string boneName)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				if (boneSetup.SourceBone.name == boneName)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsDummyBoneTransform(Transform checkBone)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				if (boneSetup.PhysicalDummyBone == checkBone)
				{
					return true;
				}
			}
			return false;
		}

		public float CalculateLength()
		{
			float num = 0f;
			Transform transform = null;
			for (int i = 0; i < BoneSetups.Count; i++)
			{
				if (!(BoneSetups[i].SourceBone == null))
				{
					if ((bool)transform)
					{
						num += Vector3.Distance(transform.position, BoneSetups[i].SourceBone.position);
					}
					transform = BoneSetups[i].SourceBone;
				}
			}
			return num;
		}

		public Transform GenerateDummyLimb(RagdollHandler handler, bool generateLostParents = true)
		{
			if (DummyParentObject != null)
			{
				return DummyParentObject;
			}
			Transform parent = null;
			for (int i = 0; i < BoneSetups.Count; i++)
			{
				BoneSetups[i].GenerateDummyBone(RagdollHandler.CreateTransform(BoneSetups[i].SourceBone.name, handler.RagdollDummyLayer));
				RagdollHandler.SetCoordsLike(BoneSetups[i].PhysicalDummyBone, BoneSetups[i].SourceBone);
				BoneSetups[i].PhysicalDummyBone.SetParent(parent, worldPositionStays: true);
				parent = BoneSetups[i].PhysicalDummyBone;
				if (!generateLostParents || i >= BoneSetups.Count - 1)
				{
					continue;
				}
				RagdollChainBone ragdollChainBone = BoneSetups[i + 1];
				if (ragdollChainBone.SourceBone.parent == BoneSetups[i].SourceBone)
				{
					continue;
				}
				Transform parent2 = ragdollChainBone.SourceBone.parent;
				List<RagdollChainBone.InBetweenBone> list = new List<RagdollChainBone.InBetweenBone>();
				while (parent2 != null && parent2 != BoneSetups[i].SourceBone)
				{
					if (!handler.skeletonFillExtraBones.TryGetValue(parent2, out var value))
					{
						value = new RagdollChainBone.InBetweenBone();
						value.SourceBone = parent2;
						value.DummyBone = RagdollHandler.CreateTransform(parent2);
						value.DummyBone.gameObject.layer = handler.RagdollDummyLayer;
						value.DummyBone.name += ":InBetween";
						handler.skeletonFillExtraBones.Add(parent2, value);
					}
					list.Add(value);
					parent2 = parent2.parent;
				}
				list[list.Count - 1].AssignParent(BoneSetups[i].PhysicalDummyBone);
				for (int num = list.Count - 2; num >= 0; num--)
				{
					list[num].AssignParent(list[num + 1].DummyBone);
				}
				BoneSetups[i].SetInBetweenBones(list);
				parent = list[0].DummyBone;
			}
			DummyParentObject = BoneSetups[0].PhysicalDummyBone;
			if (ChainType == ERagdollChainType.Core)
			{
				BoneSetups[0].PhysicalDummyBone.SetParent(handler.Dummy_Container, worldPositionStays: true);
				return DummyParentObject;
			}
			RagdollChainBone ragdollChainBone2 = handler.DummyStructure_FindConnectionBone(this);
			RagdollChainBone ragdollChainBone3 = handler.GetChain(ERagdollChainType.Core, null).BoneSetups[0];
			if (ragdollChainBone2 == null)
			{
				Debug.Log("[Ragdoll Animator] Can't find connection bone for " + ChainName + " in the " + handler.ParentObject.name + " Ragdoll Dummy! (" + ChainType.ToString() + ")");
			}
			else
			{
				ConnectionBone = ragdollChainBone2;
				if (ragdollChainBone2.SourceBone == BoneSetups[0].SourceBone.parent || ragdollChainBone2 == ragdollChainBone3)
				{
					DummyParentObject.SetParent(ragdollChainBone2.PhysicalDummyBone, worldPositionStays: true);
				}
				else
				{
					List<RagdollChainBone.InBetweenBone> list2 = new List<RagdollChainBone.InBetweenBone>();
					Transform parent3 = BoneSetups[0].SourceBone.parent;
					while (parent3 != ragdollChainBone2.SourceBone && parent3 != null)
					{
						if (!handler.skeletonFillExtraBones.TryGetValue(parent3, out var value2))
						{
							value2 = new RagdollChainBone.InBetweenBone();
							value2.SourceBone = parent3;
							value2.DummyBone = RagdollHandler.CreateTransform(parent3);
							value2.DummyBone.gameObject.layer = handler.RagdollDummyLayer;
							value2.DummyBone.name += ":Connection";
							handler.skeletonFillExtraBones.Add(parent3, value2);
						}
						list2.Add(value2);
						parent3 = parent3.parent;
					}
					list2.Reverse();
					list2[0].AssignParent(ragdollChainBone2.PhysicalDummyBone);
					for (int j = 1; j < list2.Count; j++)
					{
						list2[j].AssignParent(list2[j - 1].DummyBone);
					}
					DummyParentObject.SetParent(list2[list2.Count - 1].DummyBone, worldPositionStays: true);
					ParentConnectionBones = list2;
				}
			}
			return DummyParentObject;
		}

		internal float GetAverageStepSizeOfTheChain()
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 1; i < BoneSetups.Count; i++)
			{
				if (!(BoneSetups[i - 1].SourceBone == null) && !(BoneSetups[i].SourceBone == null))
				{
					float num3 = Vector3.Distance(BoneSetups[i - 1].SourceBone.position, BoneSetups[i].SourceBone.position);
					num += num3;
					num2 += 1f;
				}
			}
			if (num < 0.001f)
			{
				return 0.05f;
			}
			return num / num2;
		}

		public void RefreshRagdollComponents(bool addOnSource = false)
		{
			bool isFallingOrSleep = ParentHandler.IsFallingOrSleep;
			for (int i = 0; i < BoneSetups.Count; i++)
			{
				RagdollChainBone ragdollChainBone = BoneSetups[i];
				ragdollChainBone.RefreshRigidbody(ParentHandler, this, addOnSource);
				ragdollChainBone.RefreshCollider(this, isFallingOrSleep, addOnSource);
				ragdollChainBone.RefreshJoint(this, isFallingOrSleep, addOnSource, playmodeRefresh: false);
			}
		}

		public void RefreshJointsParentingDefault(RagdollChainBone parentBone)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				if (boneSetup.Joint == null)
				{
					break;
				}
				if (parentBone != null)
				{
					boneSetup.Joint.connectedBody = parentBone.GameRigidbody;
					boneSetup.InitialConnectedBody = parentBone.GameRigidbody;
				}
				parentBone = boneSetup;
			}
		}

		public void RefreshBonesParentBoneVariable(RagdollChainBone parentBone)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.SetParentBone(parentBone);
				parentBone = boneSetup;
			}
		}

		public void DetachBones(RagdollHandler handler)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				if (boneSetup.Joint == null)
				{
					return;
				}
				boneSetup.DetachParent = boneSetup.PhysicalDummyBone.parent;
			}
			if (!Detach || playmodeDetached)
			{
				return;
			}
			foreach (RagdollChainBone boneSetup2 in BoneSetups)
			{
				if (boneSetup2.Joint == null)
				{
					return;
				}
				boneSetup2.PhysicalDummyBone.transform.SetParent(handler.Dummy_Container, worldPositionStays: true);
			}
			playmodeDetached = true;
		}

		public void RefreshJointsParentingWithInBetweenBones(RagdollChainBone parentBone)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				if (boneSetup.Joint == null)
				{
					break;
				}
				Rigidbody component = boneSetup.PhysicalDummyBone.parent.GetComponent<Rigidbody>();
				if ((bool)component)
				{
					boneSetup.Joint.connectedBody = component;
				}
				if (boneSetup.Joint.connectedBody == null && parentBone != null)
				{
					boneSetup.Joint.connectedBody = parentBone.GameRigidbody;
				}
				parentBone = boneSetup;
			}
		}

		public RagdollBonesChain GetSymmetryChainByType()
		{
			if (ParentHandler == null)
			{
				return null;
			}
			RagdollBonesChain result = null;
			if (ChainType == ERagdollChainType.RightArm)
			{
				result = ParentHandler.GetChain(ERagdollChainType.LeftArm);
			}
			else if (ChainType == ERagdollChainType.LeftArm)
			{
				result = ParentHandler.GetChain(ERagdollChainType.RightArm);
			}
			else if (ChainType == ERagdollChainType.RightLeg)
			{
				result = ParentHandler.GetChain(ERagdollChainType.LeftLeg);
			}
			else if (ChainType == ERagdollChainType.LeftLeg)
			{
				result = ParentHandler.GetChain(ERagdollChainType.RightLeg);
			}
			return result;
		}

		public RagdollChainBone GetSymmetryTo(RagdollChainBone bone)
		{
			if (ParentHandler == null)
			{
				return null;
			}
			RagdollBonesChain chain = ParentHandler.GetChain(bone);
			if (chain == null)
			{
				return null;
			}
			int index = chain.GetIndex(bone);
			RagdollBonesChain ragdollBonesChain = FindSymmetryChainTo(ParentHandler, chain);
			if (ragdollBonesChain == null)
			{
				return null;
			}
			if (ragdollBonesChain.BoneSetups.ContainsIndex(index, true))
			{
				return ragdollBonesChain.BoneSetups[index];
			}
			return null;
		}

		public static RagdollBonesChain FindSymmetryChainTo(RagdollHandler handler, RagdollBonesChain chain)
		{
			if (chain == null)
			{
				return null;
			}
			if (handler == null)
			{
				return null;
			}
			if (chain.BoneSetups.Count == 0)
			{
				return null;
			}
			Transform baseTransform = handler.GetBaseTransform();
			if (baseTransform == null)
			{
				return null;
			}
			Transform sourceBone = chain.GetBone(0).SourceBone;
			if (sourceBone == null)
			{
				return null;
			}
			RagdollBonesChain result = null;
			float num = float.MaxValue;
			foreach (RagdollBonesChain chain2 in handler.Chains)
			{
				if (chain2 == chain || !chain2.ChainType.IsSameMainType(chain.ChainType) || chain2.BoneSetups.Count == 0 || chain2.GetBone(0) == null)
				{
					continue;
				}
				Transform sourceBone2 = chain2.GetBone(0).SourceBone;
				if (!(sourceBone2 == null))
				{
					float num2 = Vector3.Distance(sourceBone2.position, sourceBone.position);
					if (num2 < num && Mathf.Sign(baseTransform.InverseTransformPoint(sourceBone2.position).x) != Mathf.Sign(baseTransform.InverseTransformPoint(sourceBone.position).x))
					{
						num = num2;
						result = chain2;
					}
				}
			}
			return result;
		}

		public bool HasSymmetryTo(RagdollChainBone bone)
		{
			return GetSymmetryTo(bone) != null;
		}

		public bool IsTypeRelatedWith(RagdollBonesChain ragdollBonesChain)
		{
			if (ChainType.IsLeg() && ragdollBonesChain.ChainType.IsLeg())
			{
				return true;
			}
			if (ChainType.IsArm() && ragdollBonesChain.ChainType.IsArm())
			{
				return true;
			}
			if (ChainType == ragdollBonesChain.ChainType)
			{
				return true;
			}
			return false;
		}

		public void Calibrate()
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.BoneProcessor.Calibrate();
			}
		}

		public void CalibrateJustRotation()
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.BoneProcessor.CalibrateRotation();
			}
		}

		public void ApplyPhysicalRotationsToTheSkeleton(float finalBlend)
		{
			finalBlend = GetBlend(finalBlend);
			foreach (RagdollBoneProcessor runtimeBoneProcessor in RuntimeBoneProcessors)
			{
				runtimeBoneProcessor.ApplyPhysicalRotationToTheBone(finalBlend);
			}
		}

		public float GetBlend(float baseBlend)
		{
			if (OverrideBlend > 0f)
			{
				return OverrideBlend;
			}
			return baseBlend * ChainBlend;
		}

		public void ApplyPhysicalPositionToTheSkeleton(float finalBlend)
		{
			finalBlend = GetBlend(finalBlend);
			foreach (RagdollBoneProcessor runtimeBoneProcessor in RuntimeBoneProcessors)
			{
				runtimeBoneProcessor.ApplyPhysicalPositionToTheBone(finalBlend);
			}
		}

		public void CaptureAnimator()
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.BoneProcessor.CaptureAnimatorPose();
			}
		}

		public void ConfigureJointsAnchors()
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.ConfigureJointAnchors();
			}
		}

		public void User_ForceOverrideAllBonesBlendFor(float duration, float transitionTime = 0.1f, float targetOverrideBlend = 1f)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.User_ForceOverrideBlendFor(ParentHandler, duration, transitionTime, targetOverrideBlend);
			}
		}

		public void User_ResetOverrideBlends()
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.User_ForceStopOverrideBlend(ParentHandler);
			}
		}

		public void TryIdentifyBoneIDs(bool changeOnlyUnknowns = false)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.TryIdentifyBoneID(this, changeOnlyUnknowns);
			}
		}

		public void StoreCalibrationPose()
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.StoreCalibrationPose();
			}
		}

		public void RestoreCalibrationPose()
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				boneSetup.RestoreCalibrationPose();
			}
		}

		public void IgnoreCollisionsWith(Collider coll, bool ignore)
		{
			foreach (RagdollChainBone boneSetup in BoneSetups)
			{
				foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
				{
					collider.IgnoreCollisionWith(coll, ignore);
				}
			}
		}

		internal void DefineConnectionBone(RagdollHandler ragdollHandler)
		{
			ConnectionBone = ragdollHandler.DummyStructure_FindConnectionBone(this);
		}
	}
}
