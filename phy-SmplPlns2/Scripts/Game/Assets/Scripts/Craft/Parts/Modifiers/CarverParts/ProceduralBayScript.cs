using System;
using Assets.Scripts.Bindings.Manifold;
using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	[BurstCompile]
	public class ProceduralBayScript : SimpleProcedrualMeshModifierBaseScript
	{
		[BurstCompile]
		private struct GetDoorHingeJob : IJob
		{
			public NativeReference<float3> hingePos;

			public NativeMesh inputMesh;

			public bool leftSide;

			public ulong materialMask;

			public float3 scale;

			public void Execute()
			{
				NativeMesh nativeMesh = inputMesh;
				NativeArray<int> nativeArray = nativeMesh.Triangles.AsArray().Reinterpret<int>(12);
				float num = (leftSide ? (-1f) : 1f);
				float3 value = float.NaN;
				float num2 = MathF.PI;
				float3 float5 = math.float3(leftSide ? scale.x : (0f - scale.x), scale.y, 0f) * 0.5f;
				for (int i = 0; i < nativeMesh.Runs.Length; i++)
				{
					NativeMesh.TriangleRun triangleRun = nativeMesh.Runs[i];
					if ((materialMask & (ulong)(1L << triangleRun.MaterialId)) == 0L)
					{
						continue;
					}
					int num3 = ((i == nativeMesh.Runs.Length - 1) ? nativeArray.Length : (nativeMesh.Runs[i + 1].StartTriangles * 3));
					for (int j = triangleRun.StartTriangles * 3; j < num3; j++)
					{
						float3 float6 = nativeMesh.Vertices[nativeArray[j]].position - float5;
						float x = math.atan2(float6.x, float6.y);
						if (math.sign(x) == num && math.abs(x) < num2)
						{
							value = float6;
							num2 = math.abs(x);
						}
					}
				}
				hingePos.Value = value;
			}
		}

		private float _currentAngle;

		private RigidTransform _doorBaseRigidTransform;

		private float3? _doorHingePos;

		private Transform _doorTransform;

		public new ProceduralBayData Data { get; private set; }

		public override bool ModifiesColliders => true;

		public void Initialize(ProceduralBayData data)
		{
			Data = data;
			Initialize((MeshModifierBaseData)data);
		}

		protected override Manifold<Vertex> Apply(MeshModifyContext ctx, Allocator allocator, ref Manifold<Vertex> colliderOut)
		{
			Manifold<Vertex> result = ctx.Target.Subtract(allocator, ctx.SourceInTargetSpace);
			colliderOut = ctx.TargetCollider?.Subtract(allocator, ctx.SourceInTargetSpace);
			if (Data.DoorStyle == DoorStyle.SingleLeft || Data.DoorStyle == DoorStyle.SingleRight)
			{
				using Manifold<Vertex> manifold = ctx.ThinManifoldInModifierSpace.Intersect(Allocator.Temp, ctx.SourceInModifierSpace);
				ctx.EmitLocalMeshPart(manifold, 0, ulong.MaxValue);
			}
			return result;
		}

		protected override void PostProcessMesh(int index, NativeMesh mesh, CollectedRenderer renderer)
		{
			if (Data.DoorStyle == DoorStyle.SingleLeft || Data.DoorStyle == DoorStyle.SingleRight)
			{
				using (NativeReference<float3> hingePos = new NativeReference<float3>(Allocator.TempJob))
				{
					new GetDoorHingeJob
					{
						inputMesh = mesh,
						hingePos = hingePos,
						leftSide = (Data.DoorStyle == DoorStyle.SingleLeft),
						materialMask = 1uL
					}.Run();
					float3 value = hingePos.Value;
					_doorHingePos = (math.any(math.isnan(value)) ? ((float3?)null) : new float3?(value));
					_doorTransform = renderer.renderer.Transform;
					_doorBaseRigidTransform = RigidTransform.identity;
					return;
				}
			}
			_doorTransform = null;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			base.RegisterUpdateMethods(in registrar);
			registrar.RegisterLateUpdate(OnLateUpdateDesigner, CraftUpdateFlags.DesignerDefault);
		}

		private void OnLateUpdateDesigner(in CraftUpdateFrameData frameData)
		{
			if (_doorTransform != null && _doorHingePos.HasValue)
			{
				float target = (Data.StartOpen ? 110f : 0f);
				_currentAngle = Mathf.MoveTowards(_currentAngle, target, Time.deltaTime * 110f * 2f);
				float num = Mathf.SmoothStep(0f, 110f, _currentAngle / 110f);
				num = ((Data.DoorStyle == DoorStyle.SingleLeft) ? (0f - num) : num);
				_doorTransform.SetLocalRigidTransform(_doorBaseRigidTransform.RotateAround(quaternion.AxisAngle(math.forward(), math.radians(num)), _doorHingePos.Value));
			}
		}
	}
}
