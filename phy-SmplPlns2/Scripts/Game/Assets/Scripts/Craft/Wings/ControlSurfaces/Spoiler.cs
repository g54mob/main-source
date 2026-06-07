using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AOT;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.Physics;
using Assets.Scripts.Craft.Wings.Runtime;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.ControlSurfaces
{
	internal class Spoiler : ControlSurface
	{
		[BurstCompile]
		private struct CrossSectionJob : IJob
		{
			public float hingePos;

			public float length;

			public NativeSlice<DetailData> outputData;

			public CrossSection surface;

			public CrossSection wing;

			public void Execute()
			{
				float start = hingePos + 0.0015f;
				float end = hingePos - length;
				SectionPatch sectionPatch = new SectionPatch(wing, start, end, SurfaceLocation.TopSurface, Allocator.Temp);
				if (sectionPatch.Valid)
				{
					ref Point startPoint = ref sectionPatch.Cutout.StartPoint;
					ref Point endPoint = ref sectionPatch.Cutout.EndPoint;
					startPoint.IsSmooth = false;
					endPoint.IsSmooth = false;
					startPoint.JoinProportionally = true;
					endPoint.JoinProportionally = true;
					Point value = new Point(startPoint.Position + math.float2(0f, -0.005f), smooth: false, proportional: true);
					Point value2 = new Point(endPoint.Position + math.float2(0f, -0.005f), smooth: false, proportional: true);
					sectionPatch.Patch.Add(in startPoint);
					sectionPatch.Patch.Add(in value);
					sectionPatch.Patch.Add(in value2);
					sectionPatch.Patch.Add(in endPoint);
					LoopCutout? cutout = wing.GetCutout(hingePos, end, SurfaceLocation.TopSurface);
					if (cutout.HasValue)
					{
						LoopCutout valueOrDefault = cutout.GetValueOrDefault();
						surface.Points.Add(valueOrDefault, includeEnds: true, resetMeshRefs: true, -1, -1);
						surface.Points.Add(in value2);
						surface.Points.Add(in value);
						sectionPatch.ApplyAndDispose();
						outputData[0] = new DetailData
						{
							hingePos = wing.SliceToMeshPos(valueOrDefault.StartPoint.Position),
							startPos = wing.SliceToMeshPos(startPoint.Position),
							endPos = wing.SliceToMeshPos(endPoint.Position),
							spanPosition = wing.SpanPosition,
							sliceScale = wing.Scale
						};
					}
				}
			}
		}

		private struct DetailData : IInterpolatedData<DetailData>
		{
			public float3 endPos;

			public float3 hingePos;

			public float sliceScale;

			public float spanPosition;

			public float3 startPos;

			public readonly float Position => spanPosition;

			public DetailData Interpolate(DetailData other, float pos)
			{
				float t = math.unlerp(spanPosition, other.spanPosition, pos);
				return new DetailData
				{
					hingePos = math.lerp(hingePos, other.hingePos, t),
					endPos = math.lerp(endPos, other.endPos, t),
					sliceScale = math.lerp(sliceScale, other.sliceScale, t),
					spanPosition = pos
				};
			}
		}

		[BurstCompile]
		private struct PostPassJob : IJob
		{
			public NativeMesh mesh;

			public NativeArray<DetailData> outputData;

			public void Execute()
			{
				NativeArray<DetailData> interpolated = new NativeArray<DetailData>(4, Allocator.Temp);
				float position = outputData[0].Position;
				ref NativeArray<DetailData> reference = ref outputData;
				float position2 = reference[reference.Length - 1].Position;
				interpolated[0] = new DetailData
				{
					spanPosition = math.lerp(position, position2, 0.225f)
				};
				interpolated[1] = new DetailData
				{
					spanPosition = math.lerp(position, position2, 0.275f)
				};
				interpolated[2] = new DetailData
				{
					spanPosition = math.lerp(position, position2, 0.725f)
				};
				interpolated[3] = new DetailData
				{
					spanPosition = math.lerp(position, position2, 0.775f)
				};
				interpolated.InterpolateFrom(outputData);
				float radius = math.lerp(interpolated[1].sliceScale, interpolated[2].sliceScale, 0.5f) * 0.002f;
				Geometry.cylinder(interpolated[0].hingePos, interpolated[1].hingePos, radius).draw(mesh);
				Geometry.cylinder(interpolated[2].hingePos, interpolated[3].hingePos, radius).draw(mesh);
				interpolated.Dispose();
			}
		}

		private struct RuntimeData : IControlSurfaceRuntimeData
		{
			public float MaxDeflection;

			public readonly int InputCount => 1;

			public readonly void GetInputRanges(Span<float2> ranges)
			{
				ranges[0] = math.float2(0f, 1f);
			}

			unsafe readonly ControlSurfaceRuntimeUpdateFunction IControlSurfaceRuntimeData.GetUpdateFunction(List<IntPtr> mallocPtrs)
			{
				return ControlSurfaceRuntimeUpdateFunction.Create(BurstCompiler.CompileFunctionPointer<ControlSurfaceRuntimeUpdateFunction.RuntimeUpdateDelegate>(UpdateFunction), this, mallocPtrs);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(ControlSurfaceRuntimeUpdateFunction.RuntimeUpdateDelegate))]
			private unsafe static void UpdateFunction(ref ControlSurfaceRuntimeArgs args, void* data)
			{
				((RuntimeData*)data)->Update(ref args);
			}

			private void Update(ref ControlSurfaceRuntimeArgs args)
			{
				args.transforms[0] = new RigidTransform
				{
					pos = 0f,
					rot = quaternion.AxisAngle(math.right(), args.controls[0] * MaxDeflection)
				};
			}
		}

		private const float HingeRadius = 0.002f;

		private const float Thickness = 0.005f;

		private static MeshDefinition[] _meshDefinitions = new MeshDefinition[1]
		{
			new MeshDefinition(hasCollider: true)
		};

		private NativeArray<DetailData> _data;

		private float _hingePos;

		private float _length;

		public override SurfaceLocation Location => SurfaceLocation.TopSurface;

		public override MeshDefinition[] MeshDefinitions => _meshDefinitions;

		public override void AllocateNativeData(int sliceCount)
		{
			_data = new NativeArray<DetailData>(sliceCount, Allocator.TempJob);
		}

		public override void CopySettingsTo(ControlSurface dest)
		{
			base.CopySettingsTo(dest);
			Spoiler obj = (Spoiler)dest;
			obj._hingePos = _hingePos;
			obj._length = _length;
		}

		public override bool ApplyToColliders(NativeList<float3> mainCollider, Span<NativeList<float3>> surfaceColliders, int sliceIndex)
		{
			DetailData detailData = _data[sliceIndex];
			NativeList<float3> nativeList = surfaceColliders[0];
			float3 float5 = math.float3(0f, -0.005f * detailData.sliceScale, 0f);
			nativeList.Add(in detailData.startPos);
			nativeList.Add(detailData.startPos + float5);
			nativeList.Add(in detailData.endPos);
			nativeList.Add(detailData.endPos + float5);
			return false;
		}

		public override void ApplyToCrossSections(ControlSurfaceSectionInput i)
		{
			NativeSlice<DetailData> outputData = _data.Slice(i.SliceIndex, 1);
			new CrossSectionJob
			{
				wing = i.Wing,
				surface = i.SurfaceSections[0],
				hingePos = _hingePos,
				length = _length,
				outputData = outputData
			}.Run();
			i.Meshes[base.MeshIndexOffset].SetPivot(outputData[0].hingePos);
		}

		public override void FreeNativeData()
		{
			_data.Dispose();
		}

		public override IControlSurfaceRuntimeData GetRuntimeData(bool wingFlipped)
		{
			return new RuntimeData
			{
				MaxDeflection = math.radians(50f)
			};
		}

		public override void Init(XElement xml)
		{
			base.Init(xml);
			_hingePos = ((float?)xml.Attribute("hingePos")).GetValueOrDefault();
			_length = ((float?)xml.Attribute("length")) ?? 0.15f;
		}

		public override void PostPass(MeshBuilder[] meshes)
		{
			new PostPassJob
			{
				mesh = meshes[0],
				outputData = _data
			}.Run();
		}
	}
}
