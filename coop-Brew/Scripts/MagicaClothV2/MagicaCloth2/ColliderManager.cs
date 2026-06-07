using System;
using System.Collections.Generic;
using System.Text;
using Unity.Collections;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class ColliderManager : IManager, IDisposable, IValid
	{
		public enum ColliderType : byte
		{
			None = 0,
			Sphere = 1,
			CapsuleX_Center = 2,
			CapsuleY_Center = 3,
			CapsuleZ_Center = 4,
			CapsuleX_Start = 5,
			CapsuleY_Start = 6,
			CapsuleZ_Start = 7,
			Plane = 8,
			Box = 9
		}

		public enum SymmetryType : byte
		{
			None = 0,
			X_Symmetry = 1,
			Y_Symmetry = 2,
			Z_Symmetry = 3,
			XYZ_Symmetry = 4
		}

		internal struct WorkData
		{
			public AABB aabb;

			public float2 radius;

			public float3x2 oldPos;

			public float3x2 nextPos;

			public quaternion inverseOldRot;

			public quaternion rot;
		}

		public ExNativeArray<short> teamIdArray;

		public const ushort Flag_Valid = 256;

		public const ushort Flag_Enable = 512;

		public const ushort Flag_Reset = 1024;

		public const ushort Flag_Reverse = 2048;

		public const ushort Flag_Symmetry = 4096;

		public const ushort Flag_SymmetryReverse = 8192;

		public const ushort Flag_ScaleSuspend = 16384;

		public ExNativeArray<ExBitFlag16> flagArray;

		public ExNativeArray<float3> centerArray;

		public ExNativeArray<float3> sizeArray;

		public ExNativeArray<float3> framePositions;

		public ExNativeArray<quaternion> frameRotations;

		public ExNativeArray<float3> frameScales;

		public ExNativeArray<float3> oldFramePositions;

		public ExNativeArray<quaternion> oldFrameRotations;

		public ExNativeArray<float3> nowPositions;

		public ExNativeArray<quaternion> nowRotations;

		public ExNativeArray<float3> oldPositions;

		public ExNativeArray<quaternion> oldRotations;

		public ExNativeArray<int> mainColliderIndices;

		private HashSet<ColliderComponent> colliderSet;

		private bool isValid;

		internal ExNativeArray<WorkData> workDataArray;

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public void Register(ClothProcess cprocess)
		{
		}

		public void Exit(ClothProcess cprocess)
		{
		}

		internal void UpdateColliders(ClothProcess cprocess)
		{
		}

		private void AddCollider(ClothProcess cprocess, ColliderComponent col)
		{
		}

		private void AddColliderInternal(ref TeamManager.TeamData tdata, ClothProcess cprocess, ColliderComponent col, bool isSymmetry)
		{
		}

		internal void RemoveCollider(ColliderComponent col, int teamId)
		{
		}

		private void RemoveColliderInternal(ColliderComponent col, int teamId, bool isSymmetry)
		{
		}

		internal void EnableCollider(ColliderComponent col, int teamId, bool sw)
		{
		}

		internal void EnableTeamCollider(int teamId)
		{
		}

		internal void UpdateParameters(ColliderComponent col, int teamId, bool changeSymmetry)
		{
		}

		internal static void SimulationPreUpdate(DataChunk chunk, ref TeamManager.TeamData tdata, ref InertiaConstraint.CenterData cdata, ref NativeArray<ExBitFlag16> flagArray, ref NativeArray<float3> centerArray, ref NativeArray<float3> framePositions, ref NativeArray<quaternion> frameRotations, ref NativeArray<float3> frameScales, ref NativeArray<float3> oldFramePositions, ref NativeArray<quaternion> oldFrameRotations, ref NativeArray<float3> nowPositions, ref NativeArray<quaternion> nowRotations, ref NativeArray<float3> oldPositions, ref NativeArray<quaternion> oldRotations, ref NativeArray<int> mainColliderIndices, ref NativeArray<float3> transformPositionArray, ref NativeArray<quaternion> transformRotationArray, ref NativeArray<float3> transformScaleArray, ref NativeArray<float3> transformLocalPositionArray, ref NativeArray<quaternion> transformLocalRotationArray, ref NativeArray<float3> transformLocalScaleArray)
		{
		}

		internal static void SimulationStartStep(ref TeamManager.TeamData tdata, ref InertiaConstraint.CenterData cdata, ref NativeArray<ExBitFlag16> flagArray, ref NativeArray<float3> sizeArray, ref NativeArray<float3> framePositions, ref NativeArray<quaternion> frameRotations, ref NativeArray<float3> frameScales, ref NativeArray<float3> oldFramePositions, ref NativeArray<quaternion> oldFrameRotations, ref NativeArray<float3> nowPositions, ref NativeArray<quaternion> nowRotations, ref NativeArray<float3> oldPositions, ref NativeArray<quaternion> oldRotations, ref NativeArray<WorkData> workDataArray)
		{
		}

		internal static void SimulationEndStep(DataChunk chunk, ref TeamManager.TeamData tdata, ref NativeArray<float3> nowPositions, ref NativeArray<quaternion> nowRotations, ref NativeArray<float3> oldPositions, ref NativeArray<quaternion> oldRotations)
		{
		}

		internal static void SimulationPostUpdate(ref TeamManager.TeamData tdata, ref NativeArray<float3> framePositions, ref NativeArray<quaternion> frameRotations, ref NativeArray<float3> oldFramePositions, ref NativeArray<quaternion> oldFrameRotations)
		{
		}

		public void InformationLog(StringBuilder allsb)
		{
		}
	}
}
