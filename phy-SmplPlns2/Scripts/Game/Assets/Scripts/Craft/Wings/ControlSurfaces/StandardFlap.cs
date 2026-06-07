using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	internal class StandardFlap : TrailingFlapBase
	{
		[BurstCompile]
		private struct ColliderJob : IJob
		{
			[ReadOnly]
			public DetailData details;

			public NativeList<float3> mainCollider;

			public NativeList<float3> surfaceCollider;

			public void Execute()
			{
				for (int i = 0; i < mainCollider.Length; i++)
				{
					float3 value = mainCollider[i];
					if (value.z < details.hingeCentre.z)
					{
						surfaceCollider.Add(in value);
						mainCollider.RemoveAtSwapBack(i--);
					}
					else if (value.z <= details.trailingTop.z || value.z <= details.trailingBottom.z)
					{
						mainCollider.RemoveAtSwapBack(i--);
					}
				}
				if (mainCollider.Length == 0)
				{
					surfaceCollider.Clear();
					return;
				}
				mainCollider.Add(in details.trailingTop);
				mainCollider.Add(in details.trailingBottom);
				for (int j = 0; j < 6; j++)
				{
					math.sincos(MathF.PI * (float)j / 5f, out var s, out var c);
					surfaceCollider.Add(details.hingeCentre + math.float3(0f, c, s) * details.arcRadius);
				}
			}
		}

		[BurstCompile]
		private struct CrossSectionJob : IJob
		{
			public NativeSlice<DetailData> details;

			public HingeData hingeData;

			public float2 range;

			public int regionIndex;

			public float2 startPos;

			public CrossSection surface;

			public CrossSection wing;

			public void Execute()
			{
				float t = math.unlerp(range.x, range.y, wing.SpanPosition);
				float pos = math.lerp(startPos.x, startPos.y, t);
				float num = wing.MeshToSliceChord(pos);
				SectionPatch sectionPatch = new SectionPatch(wing, num, num, SurfaceLocation.TrailingEdge, Allocator.Temp);
				if (!sectionPatch.Valid)
				{
					return;
				}
				float num2 = (sectionPatch.Cutout.StartPoint.Position.y - sectionPatch.Cutout.EndPoint.Position.y) * 0.5f;
				float num3 = num - num2 * 0.3f;
				NativeList<Point> points = surface.Points;
				LoopCutout? cutout = wing.GetCutout(num3, num3, SurfaceLocation.TrailingEdge);
				if (!cutout.HasValue)
				{
					return;
				}
				LoopCutout valueOrDefault = cutout.GetValueOrDefault();
				ref Point startPoint = ref valueOrDefault.StartPoint;
				ref Point endPoint = ref valueOrDefault.EndPoint;
				startPoint.IsSmooth = false;
				endPoint.IsSmooth = false;
				endPoint.JoinProportionally = true;
				points.Add(valueOrDefault, includeEnds: true, resetMeshRefs: true, -1, -1);
				float num4 = (startPoint.Position.y - endPoint.Position.y) * 0.5f;
				float2 float5 = (startPoint.Position + endPoint.Position) * 0.5f;
				if (regionIndex == 0 || regionIndex == 1)
				{
					float num5 = 0.006f * ((regionIndex == 0) ? hingeData.hinge1Scale : hingeData.hinge2Scale);
					float num6 = 0f - math.acos(num5 / num4);
					float num7 = -MathF.PI - num6;
					int num8 = math.max((int)((num6 - num7) * 3f), 3);
					float2 float6 = default(float2);
					for (int i = 0; i < num8; i++)
					{
						math.sincos(math.lerp(num7, num6, (float)i / (float)(num8 - 1)), out float6.x, out float6.y);
						float6 = float6 * num5 + float5;
						points.Add(new Point(float6, smooth: true, proportional: true));
					}
				}
				else
				{
					for (int num9 = 8; num9 > 0; num9--)
					{
						float x = (float)num9 * MathF.PI / 9f;
						float2 position = default(float2);
						math.sincos(x, out position.x, out position.y);
						position *= num4;
						position += float5;
						points.Add(new Point(position, smooth: true, proportional: true));
					}
				}
				sectionPatch.Patch.Add(in sectionPatch.Cutout.StartPoint);
				float num10 = float5.x + 1.2f * num4;
				float2 position2 = sectionPatch.Cutout.StartPoint.Position;
				float2 float7 = position2 - float5;
				float2 float8 = math.float2(float7.y, 0f - float7.x);
				if (float8.x == 0f)
				{
					float8 = math.float2(1f, 0f);
				}
				float num11 = (num10 - position2.x) / float8.x;
				float2 position3 = position2 + num11 * float8;
				sectionPatch.Patch.Add(new Point(position3, smooth: false, proportional: true));
				position2 = sectionPatch.Cutout.EndPoint.Position;
				float7 = position2 - float5;
				float8 = math.float2(float7.y, 0f - float7.x);
				if (float8.x == 0f)
				{
					float8 = math.float2(1f, 0f);
				}
				num11 = (num10 - position2.x) / float8.x;
				float2 position4 = position2 + num11 * float8;
				sectionPatch.Patch.Add(new Point(position4, smooth: false, proportional: true));
				sectionPatch.Patch.Add(in sectionPatch.Cutout.EndPoint);
				sectionPatch.ApplyAndDispose();
				details[0] = new DetailData
				{
					insideTop = wing.SliceToMeshPos(position3),
					insideBottom = wing.SliceToMeshPos(position4),
					trailingTop = wing.SliceToMeshPos(sectionPatch.Cutout.StartPoint.Position),
					trailingBottom = wing.SliceToMeshPos(sectionPatch.Cutout.EndPoint.Position),
					hingeCentre = wing.SliceToMeshPos(float5),
					up = wing.Up,
					spanPosition = wing.SpanPosition,
					arcRadius = num4 * wing.Scale
				};
			}
		}

		private struct DetailData : IInterpolatedData<DetailData>
		{
			public float arcRadius;

			public float3 hingeCentre;

			public float3 insideBottom;

			public float3 insideTop;

			public float3 spanDirection;

			public float3 up;

			public float spanPosition;

			public float3 trailingBottom;

			public float3 trailingTop;

			public readonly float Position => spanPosition;

			public DetailData Interpolate(DetailData b, float pos)
			{
				float t = math.unlerp(spanPosition, b.spanPosition, pos);
				return new DetailData
				{
					spanPosition = pos,
					hingeCentre = math.lerp(hingeCentre, b.hingeCentre, t),
					insideTop = math.lerp(insideTop, b.insideTop, t),
					insideBottom = math.lerp(insideBottom, b.insideBottom, t),
					trailingTop = math.lerp(trailingTop, b.trailingTop, t),
					trailingBottom = math.lerp(trailingBottom, b.trailingBottom, t),
					spanDirection = math.normalizesafe(b.hingeCentre - hingeCentre),
					up = up
				};
			}
		}

		private struct HingeData
		{
			public float2 hinge1Range;

			public float hinge1Scale;

			public float2 hinge2Range;

			public float hinge2Scale;
		}

		[BurstCompile]
		private struct PostPassJob : IJob
		{
			public HingeData hingeData;

			public NativeMesh mesh;

			public NativeArray<DetailData> outputData;

			private const int ArcPoints = 12;

			public void Execute()
			{
				NativeArray<DetailData> interpolated = new NativeArray<DetailData>(4, Allocator.Temp);
				float2 ranges = GetRanges(hingeData.hinge1Range);
				interpolated[0] = new DetailData
				{
					spanPosition = ranges.x
				};
				interpolated[1] = new DetailData
				{
					spanPosition = ranges.y
				};
				ranges = GetRanges(hingeData.hinge2Range);
				interpolated[2] = new DetailData
				{
					spanPosition = ranges.x
				};
				interpolated[3] = new DetailData
				{
					spanPosition = ranges.y
				};
				interpolated.InterpolateFrom(outputData);
				DoHinge(hingeData.hinge1Scale, interpolated[0], interpolated[1]);
				DoHinge(hingeData.hinge2Scale, interpolated[2], interpolated[3]);
				interpolated.Dispose();
			}

			private static float2 GetRanges(float2 originalRange)
			{
				float num = (originalRange.x + originalRange.y) * 0.5f;
				float num2 = originalRange.y - num;
				num2 *= 0.6f;
				return math.float2(num - num2, num + num2);
			}

			private static float2 ToLocal(float3 pt, in DetailData data)
			{
				pt -= data.hingeCentre;
				return math.float2(pt.z, math.dot(pt, data.up));
			}

			private static float3 ToWing(float2 local, in DetailData data)
			{
				float3 result = data.hingeCentre + data.up * local.y;
				result.z += local.x;
				return result;
			}

			private int AddVerts(NativeArray<float2> points, in DetailData data)
			{
				int length = mesh.Vertices.Length;
				for (int i = 0; i < points.Length; i++)
				{
					mesh.Vert(ToWing(points[i], in data));
				}
				return length;
			}

			private void DoHinge(float scale, DetailData a, DetailData b)
			{
				float radius = 0.006f * scale;
				NativeArray<float2> nativeArray = new NativeArray<float2>(14, Allocator.Temp);
				NativeArray<float2> nativeArray2 = new NativeArray<float2>(14, Allocator.Temp);
				DoOutline(nativeArray, radius, ToLocal(a.hingeCentre, in a), ToLocal(a.insideTop, in a), ToLocal(a.insideBottom, in a));
				DoOutline(nativeArray2, radius, ToLocal(b.hingeCentre, in b), ToLocal(b.insideTop, in b), ToLocal(b.insideBottom, in b));
				int indexOffset = AddVerts(nativeArray, in a);
				Triangulator.TriangulatorJob.Triangulate(nativeArray, mesh.Triangles, indexOffset, reversed: true, allowReverse: false);
				int indexOffset2 = AddVerts(nativeArray2, in b);
				Triangulator.TriangulatorJob.Triangulate(nativeArray2, mesh.Triangles, indexOffset2, reversed: false, allowReverse: false);
				Geometry.LineBuilder lineBuilder = new Geometry.LineBuilder(mesh);
				for (int num = nativeArray.Length - 1; num >= 0; num--)
				{
					lineBuilder.AddSegment(ToWing(nativeArray[num], in a), ToWing(nativeArray2[num], in b));
				}
			}

			private readonly void DoOutline(NativeArray<float2> points, float radius, float2 centre, float2 start, float2 end)
			{
				points[0] = start;
				points[points.Length - 1] = end;
				float2 x = start - centre;
				float start2 = math.atan(x.x / x.y) - math.acos(radius / math.length(x));
				x = end - centre;
				float end2 = math.atan(x.y / x.x) - math.acos((0f - radius) / math.length(x));
				for (int i = 0; i < 12; i++)
				{
					math.sincos(math.lerp(start2, end2, (float)i / 11f), out x.x, out x.y);
					points[i + 1] = centre + x * radius;
				}
			}
		}

		[BurstCompile]
		private struct RuntimeData : IControlSurfaceRuntimeData
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal unsafe delegate void UpdateFunction_00005A95_0024PostfixBurstDelegate(ref ControlSurfaceRuntimeArgs args, void* data);

			internal static class UpdateFunction_00005A95_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<UpdateFunction_00005A95_0024PostfixBurstDelegate>(UpdateFunction).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(ref ControlSurfaceRuntimeArgs args, void* data)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref ControlSurfaceRuntimeArgs, void*, void>)functionPointer)(ref args, data);
							return;
						}
					}
					UpdateFunction_0024BurstManaged(ref args, data);
				}
			}

			public float MaxDeflection;

			public float2 Range;

			public float2 StartPos;

			public readonly int InputCount => 1;

			public readonly void GetInputRanges(Span<float2> ranges)
			{
				ranges[0] = math.float2(-1f, 1f);
			}

			unsafe readonly ControlSurfaceRuntimeUpdateFunction IControlSurfaceRuntimeData.GetUpdateFunction(List<IntPtr> mallocPtrs)
			{
				return ControlSurfaceRuntimeUpdateFunction.Create(BurstCompiler.CompileFunctionPointer<ControlSurfaceRuntimeUpdateFunction.RuntimeUpdateDelegate>(UpdateFunction), this, mallocPtrs);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(ControlSurfaceRuntimeUpdateFunction.RuntimeUpdateDelegate))]
			private unsafe static void UpdateFunction(ref ControlSurfaceRuntimeArgs args, void* data)
			{
				UpdateFunction_00005A95_0024BurstDirectCall.Invoke(ref args, data);
			}

			private readonly void Update(ref ControlSurfaceRuntimeArgs args)
			{
				float num = args.controls[0] * MaxDeflection;
				args.transforms[0] = RigidTransform.AxisAngle(math.right(), 0f - num);
				ref readonly StandardPhysicsFunctions.FlapPhysics instance = ref StandardPhysicsFunctions.FlapPhysics.Instance;
				for (int i = 0; i < args.SliceCount; i++)
				{
					SliceData data = args.sliceData[i];
					SliceAeroData aero = args.sliceAero[i];
					SlicePolar value = args.slicePolar[i];
					float coverage = args.Coverage(i);
					float t = math.unlerp(Range.x, Range.y, data.spanPosition);
					float num2 = (math.lerp(StartPos.x, StartPos.y, t) - data.ZRange.y) / data.chordLength;
					instance.PlainFlapPhysics(num, num2, coverage, in data, in aero, out var liftIncrement, out var clMaxIncrement);
					value.ApplyLiftIncrement(liftIncrement);
					value.ApplyCLMaxIncrement(clMaxIncrement);
					float liftLocation = StandardPhysicsFunctions.ComputePlainSplitFlapIncrementalLoadPressureLocation(num2);
					value.ApplyFlapMoment(liftIncrement, liftLocation);
					args.slicePolar[i] = value;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal unsafe static void UpdateFunction_0024BurstManaged(ref ControlSurfaceRuntimeArgs args, void* data)
			{
				((RuntimeData*)data)->Update(ref args);
			}
		}

		private const float HingeGapScale = 0.6f;

		private const float HingeOuterRadius = 0.006f;

		private const float HingeSlotThickness = 0.006f;

		private static MeshDefinition[] _meshDefinitions = new MeshDefinition[1]
		{
			new MeshDefinition(hasCollider: true)
		};

		private NativeArray<DetailData> _detailSource;

		private HingeData _hingeData;

		private float _maxDeflection;

		public override MeshDefinition[] MeshDefinitions => _meshDefinitions;

		public override void AllocateNativeData(int sliceCount)
		{
			_detailSource = new NativeArray<DetailData>(sliceCount, Allocator.TempJob);
		}

		public override bool ApplyToColliders(NativeList<float3> mainCollider, Span<NativeList<float3>> surfaceColliders, int sliceIndex)
		{
			new ColliderJob
			{
				mainCollider = mainCollider,
				surfaceCollider = surfaceColliders[0],
				details = _detailSource[sliceIndex]
			}.Run();
			return surfaceColliders[0].Length != 0;
		}

		public override void ApplyToCrossSections(ControlSurfaceSectionInput i)
		{
			NativeSlice<DetailData> details = _detailSource.Slice(i.SliceIndex);
			new CrossSectionJob
			{
				wing = i.Wing,
				surface = i.SurfaceSections[0],
				range = Range,
				startPos = base.StartPos,
				details = details,
				regionIndex = i.RegionIndex,
				hingeData = _hingeData
			}.Run();
			i.Meshes[base.MeshIndexOffset].SetPivot(details[0].hingeCentre);
		}

		public override void CopySettingsTo(ControlSurface dest)
		{
			base.CopySettingsTo(dest);
			(dest as StandardFlap)._maxDeflection = _maxDeflection;
		}

		public override void FreeNativeData()
		{
			_detailSource.Dispose();
		}

		public override IControlSurfaceRuntimeData GetRuntimeData(bool wingFlipped)
		{
			return new RuntimeData
			{
				MaxDeflection = math.radians(_maxDeflection),
				StartPos = base.StartPos,
				Range = Range
			};
		}

		public override void Init(XElement xml)
		{
			base.Init(xml);
			_maxDeflection = xml.GetFloatAttribute("maxDeflection", 30f);
		}

		public override void PostPass(MeshBuilder[] meshes)
		{
			if (meshes[0] != null)
			{
				new PostPassJob
				{
					outputData = _detailSource,
					mesh = meshes[0],
					hingeData = _hingeData
				}.Run();
			}
		}

		public override void PrePass(ReadOnlySpan<WingSlice> inSlices, NativeList<SurfaceRegion.Slice> regions)
		{
			WingSlice wingSlice = inSlices[0];
			WingSlice wingSlice2 = inSlices[inSlices.Length - 1];
			float num = math.min((wingSlice.Scale + wingSlice2.Scale) * 0.5f * 0.006f, (wingSlice2.SpanPosition - wingSlice.SpanPosition) * 0.1f) * 0.5f;
			float num2 = math.lerp(wingSlice.SpanPosition, wingSlice2.SpanPosition, 0.25f);
			float num3 = math.lerp(wingSlice.SpanPosition, wingSlice2.SpanPosition, 0.75f);
			_hingeData = new HingeData
			{
				hinge1Range = math.float2(num2 - num, num2 + num),
				hinge2Range = math.float2(num3 - num, num3 + num),
				hinge1Scale = math.lerp(wingSlice.Scale, wingSlice2.Scale, 0.25f),
				hinge2Scale = math.lerp(wingSlice.Scale, wingSlice2.Scale, 0.75f)
			};
			regions.AddRegion(this, _hingeData.hinge1Range.x, _hingeData.hinge1Range.y, 0);
			regions.AddRegion(this, _hingeData.hinge2Range.x, _hingeData.hinge2Range.y, 1);
		}

		public override void SaveToXml(XElement xml)
		{
			base.SaveToXml(xml);
			xml.SetAttributeValue("maxDeflection", _maxDeflection);
		}
	}
}
