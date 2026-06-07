using System;
using System.Collections.Generic;
using FIMSpace.AnimationTools;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public static class RagdollHandlerUtilities
	{
		public static void AddCollidersOnTheCharacterBones(RagdollHandler handler)
		{
			bool isFallingOrSleep = handler.IsFallingOrSleep;
			foreach (RagdollBonesChain chain in handler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.RefreshCollider(chain, isFallingOrSleep, onSource: true);
				}
			}
		}

		public static void AddPhysicsComponentsOnTheCharacterBones(RagdollHandler handler)
		{
			bool isFallingOrSleep = handler.IsFallingOrSleep;
			foreach (RagdollBonesChain chain in handler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.RefreshJoint(chain, isFallingOrSleep, onSource: true, playmodeRefresh: false);
					boneSetup.RefreshRigidbody(handler, chain, onSource: true);
				}
			}
			Transform sourceBone = handler.GetChain(ERagdollChainType.Core).BoneSetups[0].SourceBone;
			ConfigurableJoint component = sourceBone.GetComponent<ConfigurableJoint>();
			RagdollHandler.SetConfigurableJointMotionLock(component, ConfigurableJointMotion.Free);
			RagdollHandler.SetConfigurableJointAngularMotionLock(component, ConfigurableJointMotion.Free);
			foreach (RagdollBonesChain chain2 in handler.Chains)
			{
				foreach (RagdollChainBone boneSetup2 in chain2.BoneSetups)
				{
					if (boneSetup2.SourceBone == sourceBone)
					{
						continue;
					}
					ConfigurableJoint component2 = boneSetup2.SourceBone.GetComponent<ConfigurableJoint>();
					if (component2 == null)
					{
						continue;
					}
					Rigidbody rigidbody = null;
					Transform parent = boneSetup2.SourceBone.parent;
					while (parent != null && parent != sourceBone.parent)
					{
						rigidbody = parent.GetComponent<Rigidbody>();
						if ((bool)rigidbody)
						{
							break;
						}
						parent = parent.parent;
					}
					if ((bool)rigidbody)
					{
						component2.connectedBody = rigidbody;
					}
				}
			}
		}

		public static void FindAndRemoveJointAndRigidbodyComponentsOnTheCharacterBones(RagdollHandler handler, bool log = false)
		{
			int num = 0;
			foreach (RagdollBonesChain chain in handler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					Joint component = boneSetup.SourceBone.GetComponent<Joint>();
					if ((bool)component)
					{
						DestroyObject(component);
						num++;
					}
					Rigidbody component2 = boneSetup.SourceBone.GetComponent<Rigidbody>();
					if ((bool)component2)
					{
						DestroyObject(component2);
						num++;
					}
				}
			}
			if (log)
			{
				if (num == 0)
				{
					Debug.Log("[Ragdoll Animator 2] Not found any joint or rigidbody to remove.");
				}
				else
				{
					Debug.Log("[Ragdoll Animator 2] Removed " + num + " components on the source skeleton.");
				}
			}
		}

		public static void FindAndRemoveAllPhysicalComponentsOnTheCharacterBones(RagdollHandler handler, bool log = false)
		{
			int num = 0;
			foreach (RagdollBonesChain chain in handler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					Collider component = boneSetup.SourceBone.GetComponent<Collider>();
					if ((bool)component)
					{
						DestroyObject(component);
						num++;
					}
					component = boneSetup.SourceBone.GetComponentInChildren<Collider>();
					if ((bool)component)
					{
						DestroyObject(component);
						num++;
					}
				}
			}
			if (log)
			{
				if (num == 0)
				{
					Debug.Log("[Ragdoll Animator 2] Not found any skeleton collider to remove.");
				}
				else
				{
					Debug.Log("[Ragdoll Animator 2] Removed " + num + " colliders on the source skeleton.");
				}
			}
			FindAndRemoveJointAndRigidbodyComponentsOnTheCharacterBones(handler);
		}

		public static void FindBonesCollidersInSourceBonesAndAssignAsReferenceCollidersIfFound(RagdollHandler handler, bool setAsOther, bool log = false)
		{
			int num = 0;
			foreach (RagdollBonesChain chain in handler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					Collider component = boneSetup.SourceBone.GetComponent<Collider>();
					if ((bool)component)
					{
						if (setAsOther)
						{
							boneSetup.BaseColliderSetup.ColliderType = RagdollChainBone.EColliderType.Other;
						}
						boneSetup.BaseColliderSetup.OtherReference = component;
						boneSetup.BaseColliderSetup.CopySettingsFromColliderComponent(component);
						num++;
					}
				}
			}
			if (log)
			{
				if (num == 0)
				{
					Debug.Log("[Ragdoll Animator 2] Not found any skeleton collider to assign as target dummy bone collider.");
				}
				else
				{
					Debug.Log("[Ragdoll Animator 2] Found " + num + " colliders on the source skeleton. Assigned as target dummy bone colliders.");
				}
			}
		}

		public static void CalculateInertiaTensor(Rigidbody rigidbody)
		{
			Vector3 localScale = rigidbody.transform.localScale;
			float mass = rigidbody.mass;
			float x = mass / 12f * (localScale.y * localScale.y + localScale.z * localScale.z);
			float y = mass / 12f * (localScale.x * localScale.x + localScale.z * localScale.z);
			float z = mass / 12f * (localScale.x * localScale.x + localScale.y * localScale.y);
			rigidbody.inertiaTensor = new Vector3(x, y, z);
			rigidbody.inertiaTensorRotation = rigidbody.transform.rotation;
		}

		public static void DragRigidbodyTowards(this Rigidbody rigidbody, Vector3 worldPosition, float power)
		{
			float num = power;
			float num2 = 0f;
			if (num > 1f)
			{
				num = 1f;
				num2 = power - 1f;
			}
			float value = Time.fixedDeltaTime * (50f - num2 * 49f);
			value = Mathf.Clamp(value, 0.005f, 1f);
			Vector3 position = rigidbody.position;
			Vector3 b = (worldPosition - position) / value * 10f;
			if (rigidbody.useGravity)
			{
				b -= Physics.gravity * Time.fixedDeltaTime;
			}
			rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, b, num);
		}

		public static void RotateRigidbodyTowards(this Rigidbody rigidbody, Quaternion worldRotation, float power, float overallLerp = 1f)
		{
			if (!(overallLerp <= 0f))
			{
				float num = power;
				float num2 = 0f;
				if (num > 1f)
				{
					num = 1f;
					num2 = power - 1f;
				}
				float value = Time.fixedDeltaTime * (50f - num2 * 49f);
				value = Mathf.Clamp(value, 0.005f, 1f);
				Vector3 b = rigidbody.rotation.QToAngularVelocity(worldRotation, 45f / value);
				rigidbody.angularVelocity = Vector3.Slerp(rigidbody.angularVelocity, b, num * overallLerp);
			}
		}

		public static void AddRigidbodyForceToMoveTowards(this Rigidbody rigidbody, Vector3 worldPosition, float forceMultiply)
		{
			rigidbody.AddForce(rigidbody.GetVelocityToMoveTowards(worldPosition, forceMultiply), ForceMode.VelocityChange);
		}

		public static Vector3 GetVelocityToMoveTowards(this Rigidbody rigidbody, Vector3 worldPosition, float forceMultiply)
		{
			Vector3 vector = (worldPosition - rigidbody.worldCenterOfMass) / Time.fixedDeltaTime;
			if (rigidbody.useGravity)
			{
				vector -= Physics.gravity * Time.fixedDeltaTime;
			}
			vector *= forceMultiply;
			return vector - rigidbody.velocity;
		}

		public static void AddAccelerationTowardsWorldPosition(Rigidbody rigidbody, Vector3 targetPosition, Vector3 lastestPositionDelta, float power, float fixedDelta)
		{
			rigidbody.AddForce(GetAccelerationToMoveTowards(rigidbody, targetPosition - rigidbody.worldCenterOfMass, lastestPositionDelta, power, fixedDelta), ForceMode.Acceleration);
		}

		public static void AddAccelerationTowardsWorldPositionDiff(Rigidbody rigidbody, Vector3 positionDifference, Vector3 lastestPositionDelta, float power, float fixedDelta, float overallMultiplier = 1f)
		{
			rigidbody.AddForce(GetAccelerationToMoveTowards(rigidbody, positionDifference, lastestPositionDelta, power, fixedDelta) * overallMultiplier, ForceMode.Acceleration);
		}

		public static Vector3 GetAccelerationToMoveTowards(Rigidbody rigidbody, Vector3 positionDifference, Vector3 lastestPositionDelta, float power, float fixedDelta)
		{
			float num = rigidbody.mass * (0.05f + 0.85f * power) / (fixedDelta * fixedDelta);
			float num2 = (0.55f + 0.325f * power) * (2f * Mathf.Sqrt(num * rigidbody.mass));
			Vector3 vector = rigidbody.velocity - lastestPositionDelta;
			return num / rigidbody.mass * positionDifference - num2 / rigidbody.mass * vector;
		}

		public static void AddRigidbodyTorqueToRotateTowards(this Rigidbody rigidbody, Quaternion worldRotation, float forceMultiply)
		{
			float num = Quaternion.Angle(rigidbody.rotation, worldRotation);
			Vector3 vector = Vector3.Cross(rigidbody.rotation * Vector3.up, worldRotation * Vector3.up);
			Vector3 torque = Vector3.Normalize(Vector3.Cross(rigidbody.rotation * Vector3.forward, worldRotation * Vector3.forward) + vector) * num * (MathF.PI / 180f);
			torque *= forceMultiply;
			torque /= Time.fixedDeltaTime;
			torque -= rigidbody.angularVelocity;
			rigidbody.AddTorque(torque, ForceMode.VelocityChange);
		}

		public static void AdjustColliderBasingOnStartEndPosition(Vector3 start, Vector3 end, Transform bone, Collider collider, float radius)
		{
			Vector3 vector = end - start;
			Vector3 normalized = vector.normalized;
			float magnitude = bone.InverseTransformVector(vector).magnitude;
			Vector3 position = Vector3.LerpUnclamped(end, start, 0.5f);
			Vector3 axis = bone.InverseTransformVector(normalized);
			axis = FVectorMethods.ChooseDominantAxis(axis);
			if (collider is BoxCollider)
			{
				BoxCollider obj = collider as BoxCollider;
				obj.size = Vector3.one * (radius * 1.5f);
				obj.center = bone.InverseTransformPoint(position);
			}
			else if (collider is CapsuleCollider)
			{
				CapsuleCollider capsuleCollider = collider as CapsuleCollider;
				capsuleCollider.height = magnitude;
				capsuleCollider.center = bone.InverseTransformPoint(position);
				capsuleCollider.radius = Mathf.Min(magnitude, radius);
				if (capsuleCollider.height / 2f < capsuleCollider.radius)
				{
					capsuleCollider.height = capsuleCollider.radius * 2f;
				}
			}
			AdjustColliderDirectionParams(collider, axis, magnitude);
		}

		public static void AdjustColliderDirectionParams(Collider collider, Vector3 colliderDir, float diffLocalMagn)
		{
			if (collider is BoxCollider)
			{
				BoxCollider boxCollider = collider as BoxCollider;
				if (colliderDir.x > 0.1f || colliderDir.x < -0.1f)
				{
					boxCollider.size = new Vector3(diffLocalMagn, boxCollider.size.y, boxCollider.size.z);
				}
				if (colliderDir.y > 0.1f || colliderDir.y < -0.1f)
				{
					boxCollider.size = new Vector3(boxCollider.size.x, diffLocalMagn, boxCollider.size.z);
				}
				if (colliderDir.z > 0.1f || colliderDir.z < -0.1f)
				{
					boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y, diffLocalMagn);
				}
			}
			else if (collider is CapsuleCollider)
			{
				CapsuleCollider capsuleCollider = collider as CapsuleCollider;
				if (colliderDir.x > 0.1f || colliderDir.x < -0.1f)
				{
					capsuleCollider.direction = 0;
				}
				if (colliderDir.y > 0.1f || colliderDir.y < -0.1f)
				{
					capsuleCollider.direction = 1;
				}
				if (colliderDir.z > 0.1f || colliderDir.z < -0.1f)
				{
					capsuleCollider.direction = 2;
				}
			}
		}

		public static void SetMaxLinearVelocityU2022(this Rigidbody rigidbody, float maxLinearVelocity)
		{
			rigidbody.maxLinearVelocity = maxLinearVelocity;
		}

		public static T GetOrGenerate<T>(Transform t) where T : Component
		{
			T val = t.GetComponent<T>();
			if (val == null)
			{
				val = t.gameObject.AddComponent<T>();
			}
			return val;
		}

		public static void DestroyComponent<T>(Transform t) where T : Component
		{
			T component = t.GetComponent<T>();
			if (component != null)
			{
				DestroyObject(component);
			}
		}

		public static bool LayerMaskContains(LayerMask layerMask, int layer)
		{
			return (int)layerMask == ((int)layerMask | (1 << layer));
		}

		public static void SwitchKinematic(Rigidbody rigidbody, bool restore = false)
		{
			if (rigidbody.isKinematic == restore)
			{
				if (restore)
				{
					rigidbody.isKinematic = false;
					return;
				}
				rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
				rigidbody.isKinematic = true;
			}
		}

		public static void SwitchKinematicAndProjection(Rigidbody rigidbody, IRagdollAnimator2HandlerOwner handler, bool restore = false, ConfigurableJoint joint = null)
		{
			if (rigidbody.isKinematic != restore)
			{
				return;
			}
			if (joint == null)
			{
				joint = rigidbody.transform.GetComponent<ConfigurableJoint>();
			}
			if (restore)
			{
				rigidbody.isKinematic = false;
				if (joint != null && handler != null && handler.GetRagdollHandler != null)
				{
					joint.enablePreprocessing = handler.GetRagdollHandler.PreProcessing;
					joint.projectionMode = handler.GetRagdollHandler.ProjectionMode;
				}
				return;
			}
			rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
			rigidbody.isKinematic = true;
			if (joint != null && handler != null && handler.GetRagdollHandler != null)
			{
				joint.enablePreprocessing = true;
				joint.projectionMode = JointProjectionMode.PositionAndRotation;
			}
		}

		public static void DestroyObject(UnityEngine.Object obj)
		{
			if (!(obj == null))
			{
				UnityEngine.Object.Destroy(obj);
			}
		}

		public static void User_FadeMusclesPower(this IRagdollAnimator2HandlerOwner iHandler, float targetMusclesForce = 0f, float duration = 0.75f, float delay = 0f, bool disableMecanimAtEnd = false)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.Caller == null)
			{
				Debug.Log("[Ragdoll Animator 2] No Caller Behaviour Assigned, can't run Coroutine!");
				return;
			}
			if (getRagdollHandler._Coro_FadeMuscles != null)
			{
				getRagdollHandler.Caller.StopCoroutine(getRagdollHandler._Coro_FadeMuscles);
			}
			getRagdollHandler._Coro_FadeMuscles = getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_FadeMusclesPower(targetMusclesForce, duration, delay, disableMecanimAtEnd));
		}

		public static void User_FadeMusclesPowerMultiplicator(this IRagdollAnimator2HandlerOwner iHandler, float targetMusclesMultiply = 0f, float duration = 0.75f, float delay = 0f)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.Caller == null)
			{
				Debug.Log("[Ragdoll Animator 2] No Caller Behaviour Assigned, can't run Coroutine!");
				return;
			}
			if (getRagdollHandler._Coro_FadeMusclesMul != null)
			{
				getRagdollHandler.Caller.StopCoroutine(getRagdollHandler._Coro_FadeMusclesMul);
			}
			getRagdollHandler._Coro_FadeMusclesMul = getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_FadeMusclesPowerMultiplicator(targetMusclesMultiply, duration, delay));
		}

		public static void User_DisableMecanimAfter(this IRagdollAnimator2HandlerOwner iHandler, float delay)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.Mecanim == null)
			{
				return;
			}
			if (getRagdollHandler.Caller == null)
			{
				Debug.Log("[Ragdoll Animator 2] No Caller Behaviour Assigned, can't run Coroutine!");
				return;
			}
			getRagdollHandler._Coro_FadeMuscles = getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_CallAfter(delay, delegate
			{
				iHandler.GetRagdollHandler.Calibrate = true;
				iHandler.GetRagdollHandler.StoreCalibrationPose();
				iHandler.GetRagdollHandler.Mecanim.enabled = false;
			}));
		}

		public static void User_TransitionMusclesPowerMultiplier(this IRagdollAnimator2HandlerOwner iHandler, float to, float delta)
		{
			iHandler.GetRagdollHandler.musclesPowerMultiplier = Mathf.MoveTowards(iHandler.GetRagdollHandler.musclesPowerMultiplier, to, delta);
		}

		public static Collider User_GetNearestRagdollColliderToPosition(this IRagdollAnimator2HandlerOwner iHandler, Vector3 pos, bool fast = true, ERagdollChainType? justChain = null)
		{
			return iHandler.User_GetNearestRagdollBoneControllerToPosition(pos, fast, justChain).MainBoneCollider;
		}

		public static Rigidbody User_GetNearestRagdollRigidbodyToPosition(this IRagdollAnimator2HandlerOwner iHandler, Vector3 pos, bool fast = true, ERagdollChainType? justChain = null)
		{
			return iHandler.User_GetNearestRagdollBoneControllerToPosition(pos, fast, justChain).GameRigidbody;
		}

		public static Transform User_GetNearestAnimatorTransformBoneToPosition(this IRagdollAnimator2HandlerOwner iHandler, Vector3 pos, bool fast = true, ERagdollChainType? justChain = null)
		{
			return iHandler.User_GetNearestRagdollBoneControllerToPosition(pos, fast, justChain).SourceBone;
		}

		public static Transform User_GetNearestPhysicalTransformBoneToPosition(this IRagdollAnimator2HandlerOwner iHandler, Vector3 pos, bool fast = true, ERagdollChainType? justChain = null)
		{
			return iHandler.User_GetNearestRagdollBoneControllerToPosition(pos, fast, justChain).PhysicalDummyBone;
		}

		public static RagdollChainBone User_GetNearestRagdollBoneControllerToPosition(this IRagdollAnimator2HandlerOwner iHandler, Vector3 pos, bool fast = true, ERagdollChainType? justChain = null)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (fast)
			{
				RagdollChainBone nearestB = null;
				float nearestDist = float.MaxValue;
				if (justChain.HasValue)
				{
					foreach (RagdollChainBone boneSetup in getRagdollHandler.GetChain(justChain.Value).BoneSetups)
					{
						float sqrMagnitude = (pos - boneSetup.GameRigidbody.worldCenterOfMass).sqrMagnitude;
						if (sqrMagnitude < nearestDist)
						{
							nearestDist = sqrMagnitude;
							nearestB = boneSetup;
						}
					}
				}
				else
				{
					getRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
					{
						float sqrMagnitude3 = (pos - bone.GameRigidbody.worldCenterOfMass).sqrMagnitude;
						if (sqrMagnitude3 < nearestDist)
						{
							nearestDist = sqrMagnitude3;
							nearestB = bone;
						}
					});
				}
				return nearestB;
			}
			RagdollChainBone nearestB2 = null;
			float nearestDist2 = float.MaxValue;
			if (justChain.HasValue)
			{
				foreach (RagdollChainBone boneSetup2 in getRagdollHandler.GetChain(justChain.Value).BoneSetups)
				{
					float sqrMagnitude2 = (pos - nearestB2.MainBoneCollider.ClosestPoint(pos)).sqrMagnitude;
					if (sqrMagnitude2 < nearestDist2)
					{
						nearestDist2 = sqrMagnitude2;
						nearestB2 = boneSetup2;
					}
				}
			}
			else
			{
				getRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
				{
					float sqrMagnitude3 = (pos - nearestB2.MainBoneCollider.ClosestPoint(pos)).sqrMagnitude;
					if (sqrMagnitude3 < nearestDist2)
					{
						nearestDist2 = sqrMagnitude3;
						nearestB2 = bone;
					}
				});
			}
			return nearestB2;
		}

		public static void User_ChangeAllCollidersPhysicMaterial(this IRagdollAnimator2HandlerOwner iHandler, PhysicMaterial targetMaterial)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (!getRagdollHandler.DummyWasGenerated)
			{
				return;
			}
			foreach (RagdollBonesChain chain in getRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.ApplyPhysicMaterial(targetMaterial);
				}
			}
		}

		public static void User_FreezeAndDestroyRagdollDummy(this IRagdollAnimator2HandlerOwner iHandler, bool disableAnimator = true)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (disableAnimator && (bool)getRagdollHandler.Mecanim)
			{
				getRagdollHandler.Mecanim.enabled = false;
			}
			getRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.SourceBone.SetPositionAndRotation(bone.PhysicalDummyBone.position, bone.PhysicalDummyBone.rotation);
			});
			getRagdollHandler.disableUpdating = true;
			getRagdollHandler.AnimatingMode = RagdollHandler.EAnimatingMode.Off;
			getRagdollHandler.OnDisable();
			UnityEngine.Object.Destroy(getRagdollHandler.Dummy_Container.gameObject);
		}

		public static List<Rigidbody> User_GetAllRigidbodies(this IRagdollAnimator2HandlerOwner iHandler)
		{
			List<Rigidbody> rigs = new List<Rigidbody>();
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				rigs.Add(bone.GameRigidbody);
			});
			return rigs;
		}

		public static List<RagdollChainBone> User_GetAllRagdollDummyBoneSetups(this IRagdollAnimator2HandlerOwner iHandler)
		{
			List<RagdollChainBone> bones = new List<RagdollChainBone>();
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bones.Add(bone);
			});
			return bones;
		}

		public static void User_UpdateRigidbodyParametersForAllBones(this IRagdollAnimator2HandlerOwner iHandler)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (!getRagdollHandler.DummyWasGenerated)
			{
				return;
			}
			foreach (RagdollBonesChain chain in getRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.RefreshRigidbody(getRagdollHandler, chain, onSource: false);
				}
			}
		}

		public static void User_UpdateColliderParametersForAllBones(this IRagdollAnimator2HandlerOwner iHandler)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (!getRagdollHandler.DummyWasGenerated)
			{
				return;
			}
			bool isFallingOrSleep = getRagdollHandler.IsFallingOrSleep;
			foreach (RagdollBonesChain chain in getRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.RefreshCollider(chain, isFallingOrSleep, onSource: false);
				}
			}
			if (getRagdollHandler.WasInitialized)
			{
				getRagdollHandler.EnsureCollisionsIgnoreSetup();
			}
		}

		public static void User_UpdatePhysicsParametersForAllBones(this IRagdollAnimator2HandlerOwner iHandler)
		{
			if (!iHandler.GetRagdollHandler.DummyWasGenerated)
			{
				return;
			}
			bool isFallingOrSleep = iHandler.GetRagdollHandler.IsFallingOrSleep;
			foreach (RagdollBonesChain chain in iHandler.GetRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.RefreshJoint(chain, isFallingOrSleep, onSource: false, playmodeRefresh: true);
				}
			}
		}

		public static void User_UpdateLayersAfterManualChanges(this IRagdollAnimator2HandlerOwner iHandler)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			getRagdollHandler.Dummy_Container.gameObject.layer = getRagdollHandler.RagdollDummyLayer;
			foreach (RagdollBonesChain chain in getRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.GameRigidbody.gameObject.layer = getRagdollHandler.RagdollDummyLayer;
					foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
					{
						collider.GameCollider.gameObject.layer = getRagdollHandler.RagdollDummyLayer;
					}
				}
				if (chain.ParentConnectionBones == null)
				{
					continue;
				}
				foreach (RagdollChainBone.InBetweenBone parentConnectionBone in chain.ParentConnectionBones)
				{
					parentConnectionBone.DummyBone.gameObject.layer = getRagdollHandler.RagdollDummyLayer;
				}
			}
			if (getRagdollHandler.skeletonFillExtraBonesList == null)
			{
				return;
			}
			foreach (RagdollChainBone.InBetweenBone skeletonFillExtraBones in getRagdollHandler.skeletonFillExtraBonesList)
			{
				skeletonFillExtraBones.DummyBone.gameObject.layer = getRagdollHandler.RagdollDummyLayer;
			}
		}

		public static void User_UpdateAllBonesParametersAfterManualChanges(this IRagdollAnimator2HandlerOwner iHandler)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			getRagdollHandler.User_UpdateColliderParametersForAllBones();
			getRagdollHandler.User_UpdateRigidbodyParametersForAllBones();
			getRagdollHandler.User_UpdatePhysicsParametersForAllBones();
			if (getRagdollHandler.WasInitialized)
			{
				getRagdollHandler.User_UpdateJointsPlayParameters(reset: true);
			}
		}

		public static void User_Teleport(this IRagdollAnimator2HandlerOwner iHandler, Vector3? worldPosition = null, Quaternion? worldRotation = null)
		{
			RagdollHandler handler = iHandler.GetRagdollHandler;
			RagdollChainBone getAnchorBoneController = handler.GetAnchorBoneController;
			if (!worldPosition.HasValue && !worldRotation.HasValue)
			{
				handler.User_SetAllKinematic();
				handler.Caller.StartCoroutine(handler._IE_CallAfter(0f, delegate
				{
					handler.User_SetAllKinematic(kinematic: false);
					handler.User_UpdateAllBonesParametersAfterManualChanges();
				}, 1));
				return;
			}
			handler.User_SetAllKinematic();
			if (worldPosition.HasValue)
			{
				handler.GetBaseTransform().position = worldPosition.Value;
				getAnchorBoneController.GameRigidbody.position = worldPosition.Value - getAnchorBoneController.SourceBone.TransformVector(handler.anchorToRootLocal);
			}
			if (worldRotation.HasValue)
			{
				handler.GetBaseTransform().rotation = worldRotation.Value;
			}
			handler.Caller.StartCoroutine(handler._IE_CallAfter(0f, delegate
			{
				handler.User_SetAllKinematic(kinematic: false);
				handler.User_UpdateAllBonesParametersAfterManualChanges();
			}, 1));
			handler.Caller.StartCoroutine(handler._IE_CallForFixedFrames(delegate
			{
				handler.User_SetAllVelocity(Vector3.zero);
				handler.User_ResetAngularVelocityForAllBones();
			}, 2));
		}

		public static void User_WarpRefresh(this IRagdollAnimator2HandlerOwner iHandler, int frames = 3)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_RefreshBonesAfterTeleport(frames));
			getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_RefreshBonesAfterTeleportFixed(frames));
		}

		public static Vector3 User_GetStoredAnchorRootOffset(this IRagdollAnimator2HandlerOwner iHandler)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.anchorToRootLocal == Vector3.zero)
			{
				return getRagdollHandler.BaseTransform.position;
			}
			return getRagdollHandler.GetAnchorBoneController.PhysicalDummyBone.TransformPoint(getRagdollHandler.anchorToRootLocal);
		}

		public static Quaternion User_GetStoredAnchorRootOffsetRot(this IRagdollAnimator2HandlerOwner iHandler)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.anchorToRootLocalRot == Quaternion.identity)
			{
				return getRagdollHandler.BaseTransform.rotation;
			}
			return getRagdollHandler.GetAnchorBoneController.PhysicalDummyBone.rotation.QToWorld(getRagdollHandler.anchorToRootLocalRot);
		}

		public static Vector3 User_BoneWorldForward(this IRagdollAnimator2HandlerOwner iHandler, RagdollChainBone bone)
		{
			return iHandler.GetRagdollHandler.GetAnchorBoneController.GameRigidbody.rotation * bone.LocalForward;
		}

		public static Vector3 User_BoneWorldUp(this IRagdollAnimator2HandlerOwner iHandler, RagdollChainBone bone)
		{
			return iHandler.GetRagdollHandler.GetAnchorBoneController.GameRigidbody.rotation * bone.LocalUp;
		}

		public static Vector3 User_BoneWorldRight(this IRagdollAnimator2HandlerOwner iHandler, RagdollChainBone bone)
		{
			return iHandler.GetRagdollHandler.GetAnchorBoneController.GameRigidbody.rotation * bone.LocalRight;
		}

		public static Bounds User_GetRagdollBonesStateBounds(this IRagdollAnimator2HandlerOwner iHandler, bool fast = true)
		{
			Bounds result = new Bounds(iHandler.GetRagdollHandler.GetAnchorBoneController.PhysicalDummyBone.position, new Vector3(0f, 0f, 0f));
			foreach (RagdollBonesChain chain in iHandler.GetRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
					{
						result.Encapsulate(collider.GameCollider.bounds);
					}
				}
			}
			return result;
		}

		public static Vector3 User_GetPosition_BottomCenter(this IRagdollAnimator2HandlerOwner iHandler)
		{
			Bounds bounds = iHandler.User_GetRagdollBonesStateBounds();
			Vector3 center = bounds.center;
			center.y = bounds.min.y;
			return center;
		}

		public static Vector3 User_GetPosition_Center(this IRagdollAnimator2HandlerOwner iHandler)
		{
			return iHandler.User_GetRagdollBonesStateBounds().center;
		}

		public static Vector3 User_GetPosition_AnchorBottom(this IRagdollAnimator2HandlerOwner iHandler)
		{
			Bounds bounds = iHandler.GetRagdollHandler.GetAnchorBoneController.MainBoneCollider.bounds;
			Vector3 center = bounds.center;
			center.y = bounds.min.y;
			return center;
		}

		public static Vector3 User_GetPosition_AnchorCenter(this IRagdollAnimator2HandlerOwner iHandler)
		{
			return iHandler.GetRagdollHandler.GetAnchorBoneController.MainBoneCollider.bounds.center;
		}

		public static Vector3 User_GetPosition_HipsToFoot(this IRagdollAnimator2HandlerOwner iHandler)
		{
			Bounds bounds = iHandler.User_GetRagdollBonesStateBounds();
			Vector3 result = iHandler.User_GetStoredAnchorRootOffset();
			result.y = bounds.min.y;
			return result;
		}

		public static Vector3 User_GetPosition_FeetMiddle(this IRagdollAnimator2HandlerOwner iHandler)
		{
			Vector3 vector = iHandler.User_GetStoredAnchorRootOffset();
			foreach (RagdollBonesChain chain in iHandler.GetRagdollHandler.Chains)
			{
				if (chain.ChainType.IsLeg())
				{
					vector = Vector3.LerpUnclamped(vector, chain.BoneSetups[chain.BoneSetups.Count - 1].PhysicalDummyBone.position, 0.5f);
				}
			}
			return vector;
		}

		public static Quaternion User_GetMappedRotationHipsToLegsMiddle(this IRagdollAnimator2HandlerOwner iHandler, Vector3? up = null, bool checkIfOnBack = true)
		{
			RagdollChainBone getAnchorBoneController = iHandler.GetRagdollHandler.GetAnchorBoneController;
			Vector3 vector = Vector3.up;
			if (up.HasValue)
			{
				vector = up.Value;
			}
			if (checkIfOnBack)
			{
				if (iHandler.User_IsOnBack(canBeNone: false, vector))
				{
					return Quaternion.LookRotation(Vector3.ProjectOnPlane(-(getAnchorBoneController.PhysicalDummyBone.position - iHandler.User_GetPosition_FeetMiddle()), vector), vector);
				}
				return Quaternion.LookRotation(Vector3.ProjectOnPlane(getAnchorBoneController.PhysicalDummyBone.position - iHandler.User_GetPosition_FeetMiddle(), vector), vector);
			}
			return Quaternion.LookRotation(Vector3.ProjectOnPlane(getAnchorBoneController.PhysicalDummyBone.position - iHandler.User_GetPosition_FeetMiddle(), vector), vector);
		}

		public static Quaternion User_GetMappedRotationHipsToHead(this IRagdollAnimator2HandlerOwner iHandler, Vector3? up = null, bool checkIfOnBack = true)
		{
			RagdollChainBone getAnchorBoneController = iHandler.GetRagdollHandler.GetAnchorBoneController;
			Vector3 vector = Vector3.up;
			if (up.HasValue)
			{
				vector = up.Value;
			}
			RagdollChainBone bone = iHandler.GetRagdollHandler.GetChain(ERagdollChainType.Core).GetBone(1000);
			if (checkIfOnBack)
			{
				if (iHandler.User_IsOnBack(canBeNone: false, vector))
				{
					return Quaternion.LookRotation(Vector3.ProjectOnPlane(-(bone.PhysicalDummyBone.position - getAnchorBoneController.PhysicalDummyBone.position), vector), vector);
				}
				return Quaternion.LookRotation(Vector3.ProjectOnPlane(bone.PhysicalDummyBone.position - getAnchorBoneController.PhysicalDummyBone.position, vector), vector);
			}
			return Quaternion.LookRotation(Vector3.ProjectOnPlane(bone.PhysicalDummyBone.position - getAnchorBoneController.PhysicalDummyBone.position, vector), vector);
		}

		public static Quaternion User_GetRotation_Mapped(this IRagdollAnimator2HandlerOwner iHandler, Vector3 up)
		{
			RagdollChainBone getAnchorBoneController = iHandler.GetRagdollHandler.GetAnchorBoneController;
			Vector3 vector = iHandler.User_BoneWorldForward(getAnchorBoneController);
			float num = Vector3.Dot(vector, up);
			if (num > 0.6f)
			{
				return iHandler.User_GetMappedRotationHipsToLegsMiddle(up);
			}
			if (num < -0.6f)
			{
				return iHandler.User_GetMappedRotationHipsToLegsMiddle(up);
			}
			return Quaternion.LookRotation(Vector3.ProjectOnPlane(getAnchorBoneController.PhysicalDummyBone.transform.rotation * vector, up), up);
		}

		public static Quaternion User_GetRotation_MappedFor(this IRagdollAnimator2HandlerOwner iHandler, ERagdollGetUpType getupType, Vector3 up)
		{
			RagdollChainBone getAnchorBoneController = iHandler.GetRagdollHandler.GetAnchorBoneController;
			Vector3 vector = iHandler.User_BoneWorldUp(getAnchorBoneController);
			return Quaternion.LookRotation(Vector3.ProjectOnPlane(getAnchorBoneController.PhysicalDummyBone.rotation * ((getupType == ERagdollGetUpType.FromBack) ? (-vector) : vector), up), up);
		}

		public static Vector3 User_GetAverageDirectionOf(this IRagdollAnimator2HandlerOwner iHandler, RagdollBonesChain chain, RagdollChainBone.ECapsuleDirection axis)
		{
			Vector3 zero = Vector3.zero;
			switch (axis)
			{
			case RagdollChainBone.ECapsuleDirection.X:
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					zero += iHandler.User_BoneWorldRight(boneSetup);
				}
				break;
			case RagdollChainBone.ECapsuleDirection.Y:
				foreach (RagdollChainBone boneSetup2 in chain.BoneSetups)
				{
					zero += iHandler.User_BoneWorldUp(boneSetup2);
				}
				break;
			case RagdollChainBone.ECapsuleDirection.Z:
				foreach (RagdollChainBone boneSetup3 in chain.BoneSetups)
				{
					zero += iHandler.User_BoneWorldForward(boneSetup3);
				}
				break;
			}
			return (zero / chain.BoneSetups.Count).normalized;
		}

		public static bool User_GetUpByRotationPossible(this IRagdollAnimator2HandlerOwner iHandler, bool canBeNone = false, Vector3? up = null)
		{
			return iHandler.User_CanGetUpByRotation(canBeNone, up) != ERagdollGetUpType.None;
		}

		public static bool User_IsOnBack(this IRagdollAnimator2HandlerOwner iHandler, bool canBeNone = false, Vector3? up = null)
		{
			return iHandler.User_CanGetUpByRotation(canBeNone, up) == ERagdollGetUpType.FromBack;
		}

		public static float User_CoreLowTranslationFactor(this IRagdollAnimator2HandlerOwner iHandler, float averageTranslationMagnitude)
		{
			return Mathf.InverseLerp(0.1f, 4E-05f, averageTranslationMagnitude);
		}

		public static ERagdollGetUpType User_CanGetUpByRotation(this IRagdollAnimator2HandlerOwner iHandler, bool canBeNone = false, Vector3? worldUp = null, bool includeLeftRightSide = false, float tolerance = 0.5f, bool? quadroped = null)
		{
			Vector3 rhs = ((!worldUp.HasValue) ? Vector3.up : worldUp.Value);
			RagdollBonesChain chain = iHandler.GetRagdollHandler.GetChain(ERagdollChainType.Core);
			if (!quadroped.HasValue)
			{
				quadroped = !iHandler.GetRagdollHandler.IsHumanoid;
			}
			float num = ((quadroped != true) ? Vector3.Dot(iHandler.User_GetAverageDirectionOf(chain, RagdollChainBone.ECapsuleDirection.Z), rhs) : Vector3.Dot(-iHandler.User_GetAverageDirectionOf(chain, RagdollChainBone.ECapsuleDirection.Y), rhs));
			if (canBeNone)
			{
				if (num > tolerance)
				{
					return ERagdollGetUpType.FromBack;
				}
				if (num < 0f - tolerance)
				{
					return ERagdollGetUpType.FromFacedown;
				}
				if (includeLeftRightSide)
				{
					return iHandler.User_LayingOnSide(worldUp);
				}
			}
			else
			{
				if (num >= 0f)
				{
					return ERagdollGetUpType.FromBack;
				}
				if (num < 0f)
				{
					return ERagdollGetUpType.FromFacedown;
				}
			}
			return ERagdollGetUpType.None;
		}

		public static ERagdollGetUpType User_LayingOnSide(this IRagdollAnimator2HandlerOwner iHandler, Vector3? worldUp = null, bool canBeNone = true, float tolerance = 0.35f)
		{
			Vector3 rhs = ((!worldUp.HasValue) ? Vector3.up : worldUp.Value);
			float num = Vector3.Dot(iHandler.User_GetAverageDirectionOf(iHandler.GetRagdollHandler.GetChain(ERagdollChainType.Core), RagdollChainBone.ECapsuleDirection.X), rhs);
			if (canBeNone)
			{
				if (num > tolerance)
				{
					return ERagdollGetUpType.FromLeftSide;
				}
				if (num < 0f - tolerance)
				{
					return ERagdollGetUpType.FromRightSide;
				}
			}
			else
			{
				if (num >= 0f)
				{
					return ERagdollGetUpType.FromLeftSide;
				}
				if (num < 0f)
				{
					return ERagdollGetUpType.FromRightSide;
				}
			}
			return ERagdollGetUpType.None;
		}

		public static RaycastHit User_ProbeGroundBelowAnchorBone(this IRagdollAnimator2HandlerOwner iHandler, LayerMask groundMask, float? distance = null, Vector3? worldUp = null)
		{
			return iHandler.GetRagdollHandler.ProbeGroundBelowHips(groundMask, distance, worldUp);
		}

		public static RaycastHit User_ProbeGroundBelowHips(this IRagdollAnimator2HandlerOwner iHandler, LayerMask mask, float distance = 10f, Vector3? worldUp = null)
		{
			return iHandler.GetRagdollHandler.ProbeGroundBelowHips(mask, distance, worldUp);
		}

		public static RaycastHit User_ProbeGroundBelow(this IRagdollAnimator2HandlerOwner iHandler, RagdollChainBone bone, LayerMask mask, float distance = 10f, Vector3? worldUp = null)
		{
			return iHandler.GetRagdollHandler.ProbeGroundBelow(bone, mask, distance, worldUp);
		}

		public static void User_TransitionToStandingMode(this IRagdollAnimator2HandlerOwner iHandler, float transitionDuration, float blendToAnimatorFor = 0.6f, float animatorTransitionDelay = 0.1f, float freezeSourceAnimatedHips = 0f, float delay = 0f, bool isOnLegsRestoreCall = false)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.standUpCoroutine != null)
			{
				getRagdollHandler.Caller.StopCoroutine(getRagdollHandler.standUpCoroutine);
			}
			getRagdollHandler.standUpCoroutine = getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_TransitionToStandingMode(transitionDuration, blendToAnimatorFor, animatorTransitionDelay, freezeSourceAnimatedHips, delay, isOnLegsRestoreCall));
		}

		public static void User_TransitionToStandingMode(this IRagdollAnimator2HandlerOwner iHandler, float transitionDuration = 0.8f, float delay = 0f)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.AnimatingMode != RagdollHandler.EAnimatingMode.Standing)
			{
				if (getRagdollHandler.standUpCoroutine != null)
				{
					getRagdollHandler.Caller.StopCoroutine(getRagdollHandler.standUpCoroutine);
				}
				getRagdollHandler.standUpCoroutine = getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_TransitionToStandingMode(transitionDuration, 0f, 0f, delay));
			}
		}

		public static RagdollChainBone User_GetBoneSetupByHumanoidBone(this IRagdollAnimator2HandlerOwner iHandler, HumanBodyBones bone)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if ((bool)getRagdollHandler.Mecanim && getRagdollHandler.Mecanim.isHuman)
			{
				RagdollChainBone ragdollChainBone = getRagdollHandler.DictionaryGetBoneSetupBySourceBone(getRagdollHandler.Mecanim.GetBoneTransform(bone));
				if (ragdollChainBone == null)
				{
					ragdollChainBone = getRagdollHandler.DictionaryGetBoneSetupBySourceBone(getRagdollHandler.Mecanim.GetBoneTransform(bone).parent);
				}
				if (ragdollChainBone == null)
				{
					ragdollChainBone = getRagdollHandler.DictionaryGetBoneSetupBySourceBone(getRagdollHandler.Mecanim.GetBoneTransform(bone).parent.parent);
				}
				if (ragdollChainBone == null)
				{
					ragdollChainBone = getRagdollHandler.DictionaryGetBoneSetupBySourceBone(SkeletonRecognize.GetContinousChildTransform(getRagdollHandler.Mecanim.GetBoneTransform(bone)));
				}
				return ragdollChainBone;
			}
			Debug.Log("[Ragdoll Animator 2] Get controller bone for non humanoid not implemented yet");
			return null;
		}

		public static RagdollChainBone User_GetBoneSetupByBoneID(this IRagdollAnimator2HandlerOwner iHandler, ERagdollBoneID id)
		{
			return iHandler.GetRagdollHandler.DictionaryGetBoneSetupByBoneID(id);
		}

		public static RagdollChainBone User_GetBoneSetupBySourceAnimatorBone(this IRagdollAnimator2HandlerOwner iHandler, Transform skeletonBone)
		{
			return iHandler.GetRagdollHandler.DictionaryGetBoneSetupBySourceBone(skeletonBone);
		}

		public static RagdollChainBone User_GetBoneSetupByBoneName(this IRagdollAnimator2HandlerOwner iHandler, string name)
		{
			return iHandler.GetRagdollHandler.DictionaryGetBoneControllerBySourceBoneName(name);
		}

		public static RagdollChainBone User_GetBoneSetupByDummyBone(this IRagdollAnimator2HandlerOwner iHandler, Transform ragdollDummyTransform)
		{
			return iHandler.GetRagdollHandler.DictionaryGetBoneControllerByRagdollBone(ragdollDummyTransform);
		}

		public static Transform User_GetPhysicalBoneBySourceBone(this IRagdollAnimator2HandlerOwner iHandler, Transform sourceAnimatorBone)
		{
			if (iHandler.GetRagdollHandler.animatorTransformBoneDictionary.TryGetValue(sourceAnimatorBone, out var value))
			{
				return value.PhysicalDummyBone;
			}
			return null;
		}

		public static Transform User_GetSourceBoneByPhysicalBone(this IRagdollAnimator2HandlerOwner iHandler, Transform physicalBoneTransform)
		{
			if (iHandler.GetRagdollHandler.physicalTransformBoneDictionary.TryGetValue(physicalBoneTransform, out var value))
			{
				return value.SourceBone;
			}
			return null;
		}

		public static void User_ForceMatchPhysicalBonesWithAnimator(this IRagdollAnimator2HandlerOwner iHandler, bool syncPositions = false)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			getRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone b)
			{
				b.GameRigidbody.rotation = b.SourceBone.rotation;
				b.GameRigidbody.transform.rotation = b.SourceBone.rotation;
			});
			if (syncPositions)
			{
				getRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone b)
				{
					b.GameRigidbody.position = b.SourceBone.position;
					b.GameRigidbody.transform.position = b.SourceBone.position;
				});
			}
			getRagdollHandler.CallOnAllInBetweenBones(delegate(RagdollChainBone.InBetweenBone b)
			{
				b.DummyBone.rotation = b.SourceBone.rotation;
			});
		}

		public static void User_SwitchFallState(this IRagdollAnimator2HandlerOwner iHandler, RagdollHandler.EAnimatingMode state)
		{
			iHandler.GetRagdollHandler.AnimatingMode = state;
		}

		public static void User_SwitchFallState(this IRagdollAnimator2HandlerOwner iHandler, bool standing = false)
		{
			iHandler.GetRagdollHandler.AnimatingMode = (standing ? RagdollHandler.EAnimatingMode.Standing : RagdollHandler.EAnimatingMode.Falling);
		}

		public static void User_AddBoneImpact(this IRagdollAnimator2HandlerOwner iHandler, RagdollChainBone bone, Vector3 velocity, float duration, ForceMode forceMode = ForceMode.Impulse, float delay = 0f, int waitFixedFrames = 0)
		{
			if (!(bone.GameRigidbody == null))
			{
				iHandler.User_AddRigidbodyImpact(bone.GameRigidbody, velocity, duration, forceMode, delay, waitFixedFrames);
			}
		}

		public static void User_AddRigidbodyImpact(this IRagdollAnimator2HandlerOwner iHandler, Rigidbody rigb, Vector3 velocity, float duration, ForceMode forceMode = ForceMode.Impulse, float delay = 0f, int waitFixedFrames = 0)
		{
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.Caller == null && (delay > 0f || duration > 0f))
			{
				Debug.Log("[Ragdoll Animator 2] No Caller Behaviour Assigned, can't run Coroutine!");
			}
			else if (duration <= 0f)
			{
				if (delay > 0f || waitFixedFrames > 0)
				{
					getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_CallAfter(delay, delegate
					{
						ApplyLimbImpact(rigb, velocity, forceMode);
					}, waitFixedFrames));
				}
				else
				{
					ApplyLimbImpact(rigb, velocity, forceMode);
				}
			}
			else
			{
				getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_SetPhysicalImpact(rigb, velocity, duration, forceMode, delay, waitFixedFrames));
			}
		}

		public static void User_AddChainImpact(this IRagdollAnimator2HandlerOwner iHandler, RagdollBonesChain chain, Vector3 velocity, float duration, ForceMode forceMode = ForceMode.Impulse)
		{
			if (chain == null)
			{
				return;
			}
			if (duration <= 0f)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					iHandler.User_AddRigidbodyImpact(boneSetup.GameRigidbody, velocity, duration, forceMode);
				}
				return;
			}
			RagdollHandler getRagdollHandler = iHandler.GetRagdollHandler;
			if (getRagdollHandler.Caller == null)
			{
				Debug.Log("[Ragdoll Animator 2] No Caller Behaviour Assigned, can't run Coroutine!");
			}
			else
			{
				getRagdollHandler.Caller.StartCoroutine(getRagdollHandler._IE_SetChainPhysicalImpact(chain, velocity, duration, forceMode));
			}
		}

		public static void User_AddChainImpact(this IRagdollAnimator2HandlerOwner iHandler, ERagdollChainType chain, Vector3 velocity, float duration, ForceMode forceMode = ForceMode.Impulse)
		{
			iHandler.User_AddChainImpact(iHandler.GetRagdollHandler.GetChain(chain), velocity, duration, forceMode);
		}

		public static void User_AddAllBonesImpact(this IRagdollAnimator2HandlerOwner iHandler, Vector3 velocity, float impactDuration = 0f, ForceMode mode = ForceMode.Impulse, float delay = 0f, int waitExtraFixedSteps = 0)
		{
			RagdollHandler handler = iHandler.GetRagdollHandler;
			if (delay > 0f)
			{
				handler.Caller.StartCoroutine(handler._IE_CallAfter(delay, delegate
				{
					handler.User_AddAllBonesImpact(velocity, impactDuration, mode);
				}, waitExtraFixedSteps));
			}
			else
			{
				handler.User_AddAllImpact(velocity, impactDuration, mode);
			}
		}

		public static void User_SetAllBonesVelocity(this IRagdollAnimator2HandlerOwner iHandler, Vector3 velocity, float delay = 0f, int waitExtraFixedSteps = 0)
		{
			RagdollHandler handler = iHandler.GetRagdollHandler;
			if (delay > 0f)
			{
				handler.Caller.StartCoroutine(handler._IE_CallAfter(delay, delegate
				{
					handler.User_SetAllVelocity(velocity);
				}, waitExtraFixedSteps));
			}
			else
			{
				handler.User_SetAllVelocity(velocity);
			}
		}

		public static void User_SetAllKinematic(this IRagdollAnimator2HandlerOwner iHandler, bool kinematic = true)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.isKinematic = kinematic;
			});
			iHandler.GetRagdollHandler.CallOnAllInBetweenBones(delegate(RagdollChainBone.InBetweenBone bone)
			{
				if ((bool)bone.rigidbody)
				{
					bone.rigidbody.isKinematic = kinematic;
				}
			});
		}

		public static void User_SwitchAllBonesUseGravity(this IRagdollAnimator2HandlerOwner iHandler, bool useGravity = true)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.useGravity = useGravity;
			});
		}

		public static void User_SwitchAllBonesMaxVelocity(this IRagdollAnimator2HandlerOwner iHandler, float MaxVelocity = 0f)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.maxLinearVelocity = MaxVelocity;
			});
		}

		public static void User_ChangeAllRigidbodiesDrag(this IRagdollAnimator2HandlerOwner iHandler, float drag = 0f)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.drag = drag;
			});
		}

		public static void User_ChangeAllRigidbodiesAngularDrag(this IRagdollAnimator2HandlerOwner iHandler, float drag = 0f)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.angularDrag = drag;
			});
		}

		public static void User_AddAllImpact(this IRagdollAnimator2HandlerOwner iHandler, Vector3 force, float duration, ForceMode mode)
		{
			RagdollHandler handler = iHandler.GetRagdollHandler;
			handler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				handler.User_AddRigidbodyImpact(bone.GameRigidbody, force, duration, mode);
			});
		}

		public static void User_SetAllVelocity(this IRagdollAnimator2HandlerOwner iHandler, Vector3 worldVelocity)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.velocity = worldVelocity;
			});
		}

		public static void User_ResetAngularVelocityForAllBones(this IRagdollAnimator2HandlerOwner iHandler)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.angularVelocity = Vector3.zero;
			});
		}

		public static void User_SetAllAngularSpeedLimit(this IRagdollAnimator2HandlerOwner iHandler, float angularSpeedLimit)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.maxAngularVelocity = angularSpeedLimit;
			});
		}

		public static void User_SetAllIterpolation(this IRagdollAnimator2HandlerOwner iHandler, RigidbodyInterpolation interpolation)
		{
			iHandler.GetRagdollHandler.CallOnAllRagdollBones(delegate(RagdollChainBone bone)
			{
				bone.GameRigidbody.interpolation = interpolation;
			});
		}

		internal static void ApplyLimbImpact(Rigidbody rigidbody, Vector3 powerDirection, ForceMode forceMode = ForceMode.Impulse)
		{
			rigidbody.AddForce(powerDirection, forceMode);
		}

		public static void User_SetPhysicalTorqueOnRigidbody(this IRagdollAnimator2HandlerOwner iHandler, Rigidbody limb, Vector3 rotationPower, float duration, bool relativeSpace = false, ForceMode forceMode = ForceMode.Impulse, bool deltaScale = false)
		{
			if (deltaScale && Time.fixedDeltaTime > 0f)
			{
				rotationPower /= Time.fixedDeltaTime;
			}
			if (duration <= 0f)
			{
				if (relativeSpace)
				{
					limb.AddRelativeTorque(rotationPower, forceMode);
				}
				else
				{
					limb.AddTorque(rotationPower, forceMode);
				}
			}
			else
			{
				iHandler.GetRagdollHandler.Caller.StartCoroutine(iHandler.GetRagdollHandler._IE_SetPhysicalTorque(limb, rotationPower, duration, relativeSpace, forceMode));
			}
		}

		public static void User_SetAllPhysicalTorque(this IRagdollAnimator2HandlerOwner iHandler, Vector3 localEuler, float duration, bool relativeSpace = false, Transform localOf = null, Vector3? power = null, ForceMode force = ForceMode.Impulse)
		{
			Quaternion localRotation = Quaternion.Euler(localEuler);
			if (localOf != null)
			{
				localRotation = localOf.rotation.QToWorld(localRotation);
			}
			Vector3 vector = FEngineering.WrapVector(localRotation.eulerAngles);
			if (power.HasValue)
			{
				vector = Vector3.Scale(vector, power.Value);
			}
			iHandler.GetRagdollHandler.Caller.StartCoroutine(iHandler.GetRagdollHandler._IE_SetPhysicalTorque(vector, duration, relativeSpace, force));
		}

		public static void User_SetPhysicalTorque(this IRagdollAnimator2HandlerOwner iHandler, Rigidbody rigidbody, Vector3 localEuler, float duration, bool relativeSpace = false, Transform localOf = null, Vector3? power = null, ForceMode force = ForceMode.Impulse)
		{
			Quaternion localRotation = Quaternion.Euler(localEuler);
			if ((bool)localOf)
			{
				localRotation = localOf.rotation.QToWorld(localRotation);
			}
			Vector3 vector = FEngineering.WrapVector(localRotation.eulerAngles);
			if (power.HasValue)
			{
				vector = Vector3.Scale(vector, power.Value);
			}
			iHandler.GetRagdollHandler.Caller.StartCoroutine(iHandler.GetRagdollHandler._IE_SetPhysicalTorque(rigidbody, vector, duration, relativeSpace, force));
		}

		public static Vector3 User_GetAllBonesMaxVelocity(this IRagdollAnimator2HandlerOwner iHandler)
		{
			Vector3 result = Vector3.zero;
			foreach (RagdollBonesChain chain in iHandler.GetRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (boneSetup.GameRigidbody.velocity.sqrMagnitude > result.sqrMagnitude)
					{
						result = boneSetup.GameRigidbody.velocity;
					}
				}
			}
			return result;
		}

		public static Vector3 User_GetChainBonesAverageTranslation(this IRagdollAnimator2HandlerOwner iHandler, ERagdollChainType chainType)
		{
			RagdollBonesChain chain = iHandler.GetRagdollHandler.GetChain(chainType);
			if (chain == null)
			{
				return Vector3.zero;
			}
			Vector3 zero = Vector3.zero;
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				zero += boneSetup.BoneProcessor.AverageTranslationDataRequest();
			}
			return zero / chain.BoneSetups.Count;
		}

		public static float User_GetChainBonesAverageAngularVelocity(this IRagdollAnimator2HandlerOwner iHandler, ERagdollChainType chainType)
		{
			RagdollBonesChain chain = iHandler.GetRagdollHandler.GetChain(chainType);
			if (chain == null)
			{
				return 0f;
			}
			float num = 0f;
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				num += boneSetup.BoneProcessor.AverageAngularityDataRequest();
			}
			return num / (float)chain.BoneSetups.Count;
		}

		public static Vector3 User_GetChainBonesVelocity(this IRagdollAnimator2HandlerOwner iHandler, ERagdollChainType chainType, bool average = true)
		{
			RagdollBonesChain chain = iHandler.GetRagdollHandler.GetChain(chainType);
			if (chain == null)
			{
				return Vector3.zero;
			}
			Vector3 zero = Vector3.zero;
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				zero += boneSetup.GameRigidbody.velocity;
			}
			if (!average)
			{
				return zero;
			}
			return zero / chain.BoneSetups.Count;
		}

		public static Vector3 User_GetChainAngularVelocity(this IRagdollAnimator2HandlerOwner iHandler, ERagdollChainType chainType, bool average = true)
		{
			RagdollBonesChain chain = iHandler.GetRagdollHandler.GetChain(chainType);
			if (chain == null)
			{
				return Vector3.zero;
			}
			Vector3 zero = Vector3.zero;
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				zero += boneSetup.GameRigidbody.angularVelocity;
			}
			if (!average)
			{
				return zero;
			}
			return zero / chain.BoneSetups.Count;
		}

		public static void User_FallImpact(this IRagdollAnimator2HandlerOwner iHandler, Vector3 impactDirection, float power, float impactDuration = 0.15f, float bodyPushPower = 1f, Rigidbody hittedBone = null)
		{
			iHandler.User_SwitchFallState();
			iHandler.User_AddAllBonesImpact(impactDirection * bodyPushPower, impactDuration, ForceMode.Acceleration);
			if ((bool)hittedBone)
			{
				iHandler.User_AddRigidbodyImpact(hittedBone, impactDirection * power, impactDuration, ForceMode.VelocityChange);
			}
		}
	}
}
