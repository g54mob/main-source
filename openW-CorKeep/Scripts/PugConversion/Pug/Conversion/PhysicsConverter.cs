using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;
using Unity.Physics.GraphicsIntegration;
using UnityEngine;

namespace Pug.Conversion
{
	public class PhysicsConverter : Converter
	{
		private static readonly Type[] UnsupportedComponentTypes = new Type[12]
		{
			typeof(Rigidbody),
			typeof(UnityEngine.Collider),
			typeof(UnityEngine.BoxCollider),
			typeof(UnityEngine.CapsuleCollider),
			typeof(UnityEngine.MeshCollider),
			typeof(UnityEngine.SphereCollider),
			typeof(CharacterJoint),
			typeof(ConfigurableJoint),
			typeof(FixedJoint),
			typeof(HingeJoint),
			typeof(UnityEngine.Joint),
			typeof(SpringJoint)
		};

		public unsafe override void Convert(GameObject authoring)
		{
			for (int i = 0; i < UnsupportedComponentTypes.Length; i++)
			{
				Type type = UnsupportedComponentTypes[i];
				if (authoring.TryGetComponent(type, out var _))
				{
					Debug.LogWarning("Unsupported component type " + type.Name + " found on " + authoring.name + ".");
				}
			}
			PhysicsShapeAuthoring[] components = authoring.GetComponents<PhysicsShapeAuthoring>();
			MassProperties massProperties = MassProperties.UnitSphere;
			if (components.Length != 0)
			{
				if (authoring.transform.localToWorldMatrix.lossyScale != Vector3.one)
				{
					Debug.LogWarning("The scale on " + authoring.name + " will not propagate to the associated collider(s).");
				}
				BlobAssetReference<Unity.Physics.Collider> blobAssetReference = CreateColliderFromShapes(components);
				if (blobAssetReference != BlobAssetReference<Unity.Physics.Collider>.Null)
				{
					massProperties = blobAssetReference.Value.MassProperties;
					if (blobAssetReference.Value.Type == ColliderType.Compound)
					{
						EnsureHasBuffer<PhysicsColliderKeyEntityPair>();
						CompoundCollider* unsafePtr = (CompoundCollider*)blobAssetReference.GetUnsafePtr();
						for (int j = 0; j < unsafePtr->NumChildren; j++)
						{
							AddToBuffer(new PhysicsColliderKeyEntityPair
							{
								Entity = unsafePtr->Children[j].Entity,
								Key = new ColliderKey(unsafePtr->NumColliderKeyBits, (uint)j)
							});
						}
					}
					AddComponentData(new PhysicsCollider
					{
						Value = blobAssetReference
					});
					AddComponentData(default(DisablePhysicsCollider), componentIsEnabled: false);
					if (!TryGetActiveComponent<PhysicsBodyAuthoring>(authoring, out var _))
					{
						AddSharedComponentData(default(PhysicsWorldIndex));
					}
				}
			}
			if (!TryGetActiveComponent<PhysicsBodyAuthoring>(authoring, out var component3))
			{
				return;
			}
			AddSharedComponentData(new PhysicsWorldIndex(component3.WorldIndex));
			if (!component3.CustomTags.Equals(CustomPhysicsBodyTags.Nothing))
			{
				AddComponentData(new PhysicsCustomTags
				{
					Value = component3.CustomTags.Value
				});
			}
			if (component3.MotionType == BodyMotionType.Static)
			{
				return;
			}
			if (component3.OverrideDefaultMassDistribution)
			{
				massProperties.MassDistribution = component3.CustomMassDistribution;
				massProperties.AngularExpansionFactor += math.length(massProperties.MassDistribution.Transform.pos - component3.CustomMassDistribution.Transform.pos);
			}
			AddComponentData((component3.MotionType == BodyMotionType.Dynamic) ? PhysicsMass.CreateDynamic(massProperties, component3.Mass) : PhysicsMass.CreateKinematic(massProperties));
			PhysicsVelocity physicsVelocity = new PhysicsVelocity
			{
				Linear = component3.InitialLinearVelocity,
				Angular = component3.InitialAngularVelocity
			};
			AddComponentData(physicsVelocity);
			if (component3.MotionType == BodyMotionType.Dynamic)
			{
				AddComponentData(new PhysicsDamping
				{
					Linear = component3.LinearDamping,
					Angular = component3.AngularDamping
				});
				if ((double)math.abs(component3.GravityFactor - 1f) > 0.0001)
				{
					AddComponentData(new PhysicsGravityFactor
					{
						Value = component3.GravityFactor
					});
				}
			}
			else if (component3.MotionType == BodyMotionType.Kinematic)
			{
				AddComponentData(new PhysicsGravityFactor
				{
					Value = 0f
				});
			}
			if (component3.Smoothing != BodySmoothing.None)
			{
				AddComponentData(default(PhysicsGraphicalSmoothing));
				if (component3.Smoothing == BodySmoothing.Interpolation)
				{
					AddComponentData(new PhysicsGraphicalInterpolationBuffer
					{
						PreviousTransform = Math.DecomposeRigidBodyTransform((float4x4)component3.transform.localToWorldMatrix),
						PreviousVelocity = physicsVelocity
					});
				}
			}
		}

		private BlobAssetReference<Unity.Physics.Collider> CreateColliderFromShapes(PhysicsShapeAuthoring[] shapes)
		{
			List<CompoundCollider.ColliderBlobInstance> list = new List<CompoundCollider.ColliderBlobInstance>();
			foreach (PhysicsShapeAuthoring physicsShapeAuthoring in shapes)
			{
				if (physicsShapeAuthoring.enabled)
				{
					CompoundCollider.ColliderBlobInstance item = new CompoundCollider.ColliderBlobInstance
					{
						Entity = base.PrimaryEntity,
						CompoundFromChild = RigidTransform.identity
					};
					EulerAngles orientation2;
					switch (physicsShapeAuthoring.ShapeType)
					{
					case ShapeType.Box:
					{
						BoxGeometry boxProperties = physicsShapeAuthoring.GetBoxProperties(out orientation2);
						item.Collider = Unity.Physics.BoxCollider.Create(boxProperties, physicsShapeAuthoring.GetFilter(), physicsShapeAuthoring.GetMaterial());
						break;
					}
					case ShapeType.Capsule:
					{
						CapsuleGeometry geometry = physicsShapeAuthoring.GetCapsuleProperties().ToRuntime();
						item.Collider = Unity.Physics.CapsuleCollider.Create(geometry, physicsShapeAuthoring.GetFilter(), physicsShapeAuthoring.GetMaterial());
						break;
					}
					case ShapeType.Cylinder:
					{
						CylinderGeometry cylinderProperties = physicsShapeAuthoring.GetCylinderProperties(out orientation2);
						item.Collider = CylinderCollider.Create(cylinderProperties, physicsShapeAuthoring.GetFilter(), physicsShapeAuthoring.GetMaterial());
						break;
					}
					case ShapeType.Sphere:
					{
						quaternion orientation;
						SphereGeometry sphereProperties = physicsShapeAuthoring.GetSphereProperties(out orientation);
						item.Collider = Unity.Physics.SphereCollider.Create(sphereProperties, physicsShapeAuthoring.GetFilter(), physicsShapeAuthoring.GetMaterial());
						break;
					}
					default:
						throw new NotImplementedException($"Conversion of {physicsShapeAuthoring.ShapeType} is not supported.");
					}
					base.BlobAssetStore.TryAdd(ref item.Collider);
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				return BlobAssetReference<Unity.Physics.Collider>.Null;
			}
			if (list.Count == 1)
			{
				return list[0].Collider;
			}
			NativeArray<CompoundCollider.ColliderBlobInstance> children = new NativeArray<CompoundCollider.ColliderBlobInstance>(list.Count, Allocator.Temp);
			for (int j = 0; j < list.Count; j++)
			{
				children[j] = list[j];
			}
			BlobAssetReference<Unity.Physics.Collider> blobAsset = CompoundCollider.Create(children);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			return blobAsset;
		}
	}
}
