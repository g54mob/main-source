using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using AOT;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.Physics;
using Assets.Scripts.Craft.Wings.Runtime;
using Assets.Scripts.Craft.Wings.Utilities;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.ControlSurfaces
{
	public class Slat : EdgeSurfaceBase
	{
		[BurstCompile]
		private struct ColliderJob : IJob
		{
			public DetailData details;

			public NativeList<float3> surface;

			public NativeList<float3> wing;

			void IJob.Execute()
			{
				for (int i = 0; i < wing.Length; i++)
				{
					float3 value = wing[i];
					if (details.ColliderCutPlane.IsAbove(value))
					{
						surface.Add(in value);
						wing.RemoveAtSwapBack(i--);
					}
				}
				wing.Add(in details.BottomEndPoint);
				wing.Add(in details.WingNewLeadingTipPoint);
				wing.Add(in details.TopEndPoint);
				surface.Add(in details.BottomEndPoint);
				surface.Add(in details.TopEndPoint);
			}
		}

		[BurstCompile]
		private struct CrossSectionJob : IJob
		{
			public float3 axis;

			public float deflectionRadians;

			public NativeSlice<DetailData> details;

			public float extension;

			public float2 range;

			public float2 startPos;

			public CrossSection surface;

			public CrossSection wing;

			void IJob.Execute()
			{
				float t = math.unlerp(range.x, range.y, wing.SpanPosition);
				float pos = math.lerp(startPos.x, startPos.y, t);
				float num = wing.MeshToSliceChord(pos);
				float start = math.lerp(num, 0.5f, 0.5f);
				SectionPatch patch = new SectionPatch(wing, start, num, SurfaceLocation.LeadingEdge, Allocator.Temp);
				float2 bezierTipControlPoint;
				if (patch.Valid)
				{
					bezierTipControlPoint = math.float2(math.lerp(start, 0.5f, 0.5f), 0f);
					if (bezierTipControlPoint.x < 0.49f)
					{
						bezierTipControlPoint.y = wing.Airfoil.SampleCamber(bezierTipControlPoint.x);
					}
					patch.Patch.Add(patch.Cutout.StartPoint.Sharp());
					for (int i = 1; i < 11; i++)
					{
						patch.Patch.Add(new Point(SampleInnerWingCurve((float)i * (1f / 11f)), PointFlags.Smooth | PointFlags.JoinProportionally));
					}
					patch.Patch.Add(patch.Cutout.EndPoint.Sharp());
					surface.Points.Add(patch.Cutout.StartPoint.Sharp());
					surface.Points.Add(patch.Cutout, includeEnds: false, resetMeshRefs: true, -1, -1);
					surface.Points.Add(patch.Cutout.EndPoint.Sharp());
					float x = math.lerp(start, 0.5f, 0.3f);
					float2 float5 = math.float2(x, wing.Airfoil.SampleBottom(x) + 0.003f);
					for (int j = 1; j < 11; j++)
					{
						surface.Points.Add(new Point(MathUtils.Bezier(patch.Cutout.EndPoint.Position, bezierTipControlPoint, float5, (float)j * (1f / 11f)), PointFlags.Smooth | PointFlags.JoinProportionally));
					}
					surface.Points.Add(new Point(float5, smooth: false));
					float num2 = extension * math.length(axis.xy) / wing.Scale;
					float x2 = num;
					float y = wing.Airfoil.SampleCamber(x2) - 1.5f * num2;
					float3 float6 = wing.SliceToMeshPos(patch.Cutout.EndPoint.Position);
					float3 float7 = wing.SliceToMeshPos(patch.Cutout.StartPoint.Position);
					float3 c = float6 + math.cross(wing.Up, math.forward());
					details[0] = new DetailData
					{
						Pivot = wing.SliceToMeshPos(math.float2(x2, y)),
						ColliderCutPlane = new Plane(float6, float7, c),
						BottomEndPoint = float7,
						TopEndPoint = float6,
						WingNewLeadingTipPoint = wing.SliceToMeshPos(SampleInnerWingCurve(0.5f))
					};
					patch.ApplyAndDispose();
				}
				float2 SampleInnerWingCurve(float t2)
				{
					return MathUtils.Bezier(patch.Cutout.StartPoint.Position, bezierTipControlPoint, patch.Cutout.EndPoint.Position, t2);
				}
			}
		}

		private struct DetailData
		{
			public float3 BottomEndPoint;

			public Plane ColliderCutPlane;

			public float3 Pivot;

			public float3 TopEndPoint;

			public float3 WingNewLeadingTipPoint;
		}

		[BurstCompile]
		private struct RuntimeData : IControlSurfaceRuntimeData
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal unsafe delegate void UpdateFunction_00005A46_0024PostfixBurstDelegate(ref ControlSurfaceRuntimeArgs args, void* data);

			internal static class UpdateFunction_00005A46_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<UpdateFunction_00005A46_0024PostfixBurstDelegate>(UpdateFunction).Value;
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

			public float MaxDeflectionDegrees;

			public float Extension;

			public float2 Range;

			public float2 StartPos;

			public float3 PivotCentre;

			public float3 PivotAxis;

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
				UpdateFunction_00005A46_0024BurstDirectCall.Invoke(ref args, data);
			}

			private void Update(ref ControlSurfaceRuntimeArgs args)
			{
				float num = MaxDeflectionDegrees * args.controls[0];
				quaternion rotation = quaternion.RotateX(math.radians(num));
				RigidTransform value = new RigidTransform(rotation, 0f);
				args.transforms[0] = value;
				float num2 = Extension * args.controls[0];
				for (int i = 0; i < args.SliceCount; i++)
				{
					SliceData sliceData = args.sliceData[i];
					float num3 = args.Coverage(i);
					float t = math.unlerp(Range.x, Range.y, sliceData.spanPosition);
					float num4 = math.lerp(StartPos.x, StartPos.y, t);
					float3 quarterChordPos = sliceData.quarterChordPos;
					quarterChordPos.z += 0.25f * sliceData.chordLength;
					float num5 = quarterChordPos.z - num4;
					float num6 = sliceData.chordLength + num2;
					float num7 = StandardPhysicsFunctions.FlapPhysics.SampleFig50(num5 / num6);
					float num8 = num6 / sliceData.chordLength;
					float num9 = num7 * num * num8;
					float num10 = StandardPhysicsFunctions.FlapPhysics.SampleFig14(num5 / sliceData.chordLength);
					num10 *= StandardPhysicsFunctions.FlapPhysics.SampleFig15Slat(sliceData.standardAirfoilParams.leadingEdgeRadius);
					num10 *= math.radians(num);
					SliceAeroData value2 = args.sliceAero[i];
					SlicePolar value3 = args.slicePolar[i];
					float num11 = (num6 - sliceData.chordLength) / sliceData.chordLength;
					float num12 = StandardPhysicsFunctions.FlapPhysics.SampleFig36(num5 / num6) * num8 * num8 * num;
					num12 += (0.25f + num11) * num9;
					num12 += value3.zeroLiftMoment * (num8 * num8 - 1f);
					value3.additionalMoment += num12;
					value3.aerodynamicCentre += 0.75f * num8 * (num8 - 1f);
					value3.ApplyLiftIncrement(num9 * num3);
					value3.ApplyCLMaxIncrement(num10 * num3);
					value2.effectiveChordLength *= num8;
					args.sliceAero[i] = value2;
					args.slicePolar[i] = value3;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal unsafe static void UpdateFunction_0024BurstManaged(ref ControlSurfaceRuntimeArgs args, void* data)
			{
				((RuntimeData*)data)->Update(ref args);
			}
		}

		private float _deflectionDegrees = 30f;

		private NativeArray<DetailData> _details;

		private float _extension;

		private float3 _flatAxis;

		private float3 _pivot1;

		private float3 _pivot2;

		public override float DefaultStartPos => 0.3f;

		public override bool IsLeadingEdge => true;

		public override MeshDefinition[] MeshDefinitions { get; } = new MeshDefinition[1]
		{
			new MeshDefinition(hasCollider: true)
		};

		protected override float2 MinMaxChordSize => new float2(0.05f, 0.4f);

		public override void AllocateNativeData(int sliceCount)
		{
			_details = new NativeArray<DetailData>(sliceCount, Allocator.TempJob);
		}

		public override bool ApplyToColliders(NativeList<float3> mainCollider, Span<NativeList<float3>> surfaceColliders, int sliceIndex)
		{
			new ColliderJob
			{
				wing = mainCollider,
				surface = surfaceColliders[0],
				details = _details[sliceIndex]
			}.Run();
			return surfaceColliders[0].Length != 0;
		}

		public override void ApplyToCrossSections(ControlSurfaceSectionInput input)
		{
			new CrossSectionJob
			{
				axis = _flatAxis,
				extension = _extension,
				deflectionRadians = math.radians(30f),
				range = Range,
				startPos = base.StartPos,
				surface = input.SurfaceSections[0],
				wing = input.Wing,
				details = _details.Slice(input.SliceIndex, 1)
			}.Run();
			if (input.SliceIndex == 0 || input.SliceIndex == _details.Length - 1)
			{
				float3 pivot = _details[input.SliceIndex].Pivot;
				input.Meshes[base.MeshIndexOffset].SetPivot(pivot);
				if (input.SliceIndex == 0)
				{
					_pivot1 = pivot;
				}
				else
				{
					_pivot2 = pivot;
				}
			}
		}

		public override void FreeNativeData()
		{
			_details.Dispose();
		}

		public override IControlSurfaceRuntimeData GetRuntimeData(bool wingFlipped)
		{
			RuntimeData runtimeData = new RuntimeData
			{
				MaxDeflectionDegrees = _deflectionDegrees,
				Extension = _extension,
				Range = Range,
				StartPos = base.StartPos,
				PivotCentre = _pivot1,
				PivotAxis = math.normalize(_pivot2 - _pivot1)
			};
			if (wingFlipped)
			{
				runtimeData.PivotCentre.y = 0f - runtimeData.PivotCentre.y;
				runtimeData.PivotAxis.xz = -runtimeData.PivotAxis.xz;
			}
			return runtimeData;
		}

		public override void Init(XElement xml)
		{
			base.Init(xml);
			_deflectionDegrees = xml.GetFloatAttribute("deflectionDegrees", 30f);
		}

		public override void PrePass(ReadOnlySpan<WingSlice> inSlices, NativeList<SurfaceRegion.Slice> regions)
		{
			WingSlice slice = inSlices[0];
			WingSlice slice2 = inSlices[inSlices.Length - 1];
			_extension = math.max(ExtensionAt(slice, base.StartPos.x), ExtensionAt(slice2, base.StartPos.y));
			_flatAxis = math.normalize(AxisAt(slice2, base.StartPos.y) - AxisAt(slice, base.StartPos.x));
			static float3 AxisAt(WingSlice wingSlice, float startPos)
			{
				float3 position = wingSlice.Position;
				float num = wingSlice.MeshToSliceChord(startPos);
				position += wingSlice.Up * wingSlice.Scale * 0.5f * math.csum(wingSlice.Airfoil.SamplePoint(0.5f - num));
				position.z = startPos;
				return position;
			}
			static float ExtensionAt(WingSlice wingSlice, float startPos)
			{
				return (wingSlice.Position.z + 0.5f * wingSlice.Scale - startPos) * 0.5f;
			}
		}

		public override void ResetShape()
		{
			base.ResetShape();
			base.StartPos = 0.3f;
		}

		public override void SaveToXml(XElement xml)
		{
			base.SaveToXml(xml);
			xml.SetAttributeValue("deflectionDegrees", DataIO.ToString(_deflectionDegrees));
		}
	}
}
