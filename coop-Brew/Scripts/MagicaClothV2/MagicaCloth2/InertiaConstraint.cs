using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace MagicaCloth2
{
	public class InertiaConstraint : IDisposable
	{
		public enum TeleportMode
		{
			None = 0,
			Reset = 1,
			Keep = 2
		}

		[Serializable]
		public class SerializeData : IDataValidate
		{
			public Transform anchor;

			[Range(0f, 1f)]
			public float anchorInertia;

			[FormerlySerializedAs("movementInertia")]
			[Range(0f, 1f)]
			public float worldInertia;

			[Range(0f, 1f)]
			public float movementInertiaSmoothing;

			public CheckSliderSerializeData movementSpeedLimit;

			public CheckSliderSerializeData rotationSpeedLimit;

			[Range(0f, 1f)]
			public float localInertia;

			public CheckSliderSerializeData localMovementSpeedLimit;

			public CheckSliderSerializeData localRotationSpeedLimit;

			[Range(0f, 1f)]
			public float depthInertia;

			[Range(0f, 1f)]
			public float centrifualAcceleration;

			public CheckSliderSerializeData particleSpeedLimit;

			public TeleportMode teleportMode;

			public float teleportDistance;

			public float teleportRotation;

			public SerializeData Clone()
			{
				return null;
			}

			public void DataValidate()
			{
			}
		}

		public struct InertiaConstraintParams
		{
			public float anchorInertia;

			public float worldInertia;

			public float movementInertiaSmoothing;

			public float movementSpeedLimit;

			public float rotationSpeedLimit;

			public float localInertia;

			public float localMovementSpeedLimit;

			public float localRotationSpeedLimit;

			public float depthInertia;

			public float centrifualAcceleration;

			public float particleSpeedLimit;

			public TeleportMode teleportMode;

			public float teleportDistance;

			public float teleportRotation;

			public void Convert(SerializeData sdata)
			{
			}
		}

		[Serializable]
		public struct CenterData
		{
			public float3 anchorPosition;

			public quaternion anchorRotation;

			public float3 oldAnchorPosition;

			public quaternion oldAnchorRotation;

			public float3 anchorComponentLocalPosition;

			public int centerTransformIndex;

			public float3 componentWorldPosition;

			public quaternion componentWorldRotation;

			public float3 componentWorldScale;

			public float3 oldComponentWorldPosition;

			public quaternion oldComponentWorldRotation;

			public float3 oldComponentWorldScale;

			public float3 frameComponentShiftVector;

			public quaternion frameComponentShiftRotation;

			public float frameMovingSpeed;

			public float3 frameMovingDirection;

			public float3 frameWorldPosition;

			public quaternion frameWorldRotation;

			public float3 frameWorldScale;

			public float3 frameLocalPosition;

			public float3 oldFrameWorldPosition;

			public quaternion oldFrameWorldRotation;

			public float3 oldFrameWorldScale;

			public float3 nowWorldPosition;

			public quaternion nowWorldRotation;

			public float3 oldWorldPosition;

			public quaternion oldWorldRotation;

			public float stepMoveInertiaRatio;

			public float stepRotationInertiaRatio;

			public float3 stepVector;

			public quaternion stepRotation;

			public float3 inertiaVector;

			public quaternion inertiaRotation;

			public float stepMovingSpeed;

			public float3 stepMovingDirection;

			public float angularVelocity;

			public float3 rotationAxis;

			public float3 initLocalGravityDirection;

			public float3 smoothingVelocity;

			public float4x4 negativeScaleMatrix;

			internal void Initialize()
			{
			}
		}

		[Serializable]
		public class ConstraintData
		{
			public ResultCode result;

			public CenterData centerData;

			public float3 initLocalGravityDirection;
		}

		internal ExNativeArray<ushort> fixedArray;

		public void Dispose()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static ConstraintData CreateData(VirtualMesh proxyMesh, in ClothParameters parameters)
		{
			return null;
		}

		internal void Register(ClothProcess cprocess)
		{
		}

		internal void Exit(ClothProcess cprocess)
		{
		}
	}
}
