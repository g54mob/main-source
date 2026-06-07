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
	public class FowlerFlap : TrailingFlapBase
	{
		[BurstCompile]
		private struct CrossSectionJob : IJob
		{
			public CrossSection cs;

			[WriteOnly]
			public NativeSlice<DetailData> details;

			[ReadOnly]
			public GenerationData generationData;

			[ReadOnly]
			public int region;

			[ReadOnly]
			public float spanPosition;

			[ReadOnly]
			public float2 startPos;

			public CrossSection wing;

			public readonly float2 AirfoilSurfaces(float x)
			{
				return math.float2(wing.Airfoil.SampleTop(x), wing.Airfoil.SampleBottom(x));
			}

			public void Execute()
			{
				float pos = math.lerp(startPos.x, startPos.y, spanPosition);
				float num = generationData.extensionDistance / wing.Scale;
				float num2 = wing.MeshToSliceChord(pos);
				float num3 = num2 - num;
				SectionPatch sectionPatch = new SectionPatch(wing, num3, num2, SurfaceLocation.TrailingEdge, Allocator.Temp);
				if (!sectionPatch.Valid)
				{
					return;
				}
				sectionPatch.Patch.Add(sectionPatch.Cutout.StartPoint.Sharp());
				float2 float5 = AirfoilSurfaces(num2);
				float num4 = math.lerp(float5.x, float5.y, 0.21f);
				float y = float5.y;
				float2 float6 = math.float2(num2, 0.5f * (num4 + y));
				float num5 = 0.5f * (num4 - y);
				cs.Points.Arc(float6, MathF.PI, 0f, num5, 8, includeEnds: true);
				int length = cs.Points.Length;
				cs.Points.Length += 7;
				for (int i = 0; i < 3; i++)
				{
					float num6 = math.lerp(-0.5f, num2, (float)(i + 1) / 4f);
					float2 float7 = AirfoilSurfaces(num6);
					cs.Points[length + (2 - i)] = new Point(math.float2(num6, math.lerp(float7.x, float7.y, 0.21f)));
					cs.Points[length + 4 + i] = new Point(math.float2(num6, float7.y));
					if (num6 > num3)
					{
						sectionPatch.Patch.Add(new Point(math.float2(num6, math.lerp(float7.x, float7.y, 0.2f))));
					}
				}
				cs.Points[length + 3] = new Point(math.float2(-0.5f, cs.Airfoil.SampleTop(-0.5f)), smooth: false);
				float x = num2 + num5 * 1.1f;
				float2 float8 = AirfoilSurfaces(x);
				sectionPatch.Patch.Add(new Point(math.float2(x, math.lerp(float8.x, float8.y, 0.2f)), smooth: false));
				sectionPatch.Patch.Add(new Point(math.float2(x, math.lerp(float8.x, float8.y, 0.95f)), smooth: false));
				sectionPatch.Patch.Add(sectionPatch.Cutout.EndPoint.Sharp());
				sectionPatch.ApplyAndDispose();
				DetailData value = new DetailData
				{
					pivot = wing.SliceToMeshPos(float6),
					spanPosition = spanPosition,
					up = wing.Up,
					forward = math.forward(),
					cutPosTop = wing.SliceToMeshPos(sectionPatch.Cutout.StartPoint.Position),
					cutPosBottom = wing.SliceToMeshPos(sectionPatch.Cutout.EndPoint.Position)
				};
				float3 x2 = default(float3);
				float3 float9 = default(float3);
				for (int j = 0; j < 3; j++)
				{
					x2[j] = 0.5f * (float)j * generationData.extensionDistance;
					float x3 = float6.x - 0.5f * (float)j * num;
					float2 float10 = AirfoilSurfaces(x3);
					float9[j] = math.lerp(float10.x, float10.y, 0.21f);
				}
				float9 -= float9.x;
				value.extensionPath = MathUtils.Quadratic.Fit(x2, float9 * wing.Scale);
				details[0] = value;
			}
		}

		[BurstCompile]
		private struct ColliderGenJob : IJob
		{
			[ReadOnly]
			public DetailData details;

			public NativeList<float3> mainCollider;

			public NativeList<float3> surfaceCollider;

			public void Execute()
			{
				float3 value = details.cutPosTop;
				float3 value2 = details.cutPosBottom;
				Plane plane = new Plane(math.cross(value - value2, math.cross(details.up, details.forward)), value);
				for (int i = 0; i < mainCollider.Length; i++)
				{
					float3 value3 = mainCollider[i];
					if (plane.IsAbove(value3))
					{
						mainCollider.RemoveAtSwapBack(i--);
						surfaceCollider.Add(in value3);
					}
				}
				mainCollider.Add(in value);
				mainCollider.Add(in value2);
				surfaceCollider.Add(in value);
				surfaceCollider.Add(in value2);
			}
		}

		private struct DetailData : IInterpolatedData<DetailData>
		{
			public MathUtils.Quadratic extensionPath;

			public float3 forward;

			public float3 pivot;

			public float spanPosition;

			public float3 up;

			public float3 cutPosTop;

			public float3 cutPosBottom;

			public readonly float Position => spanPosition;

			public DetailData(float spanPosition)
			{
				this.spanPosition = spanPosition;
				pivot = 0f;
				up = 0f;
				forward = 0f;
				extensionPath = default(MathUtils.Quadratic);
				cutPosTop = default(float3);
				cutPosBottom = default(float3);
			}

			public DetailData Interpolate(DetailData other, float pos)
			{
				float t = math.unlerp(spanPosition, other.spanPosition, pos);
				return new DetailData
				{
					pivot = math.lerp(pivot, other.pivot, t),
					up = math.lerp(up, other.up, t),
					forward = math.lerp(forward, other.forward, t),
					spanPosition = pos,
					extensionPath = new MathUtils.Quadratic
					{
						coefficients = math.lerp(extensionPath.coefficients, other.extensionPath.coefficients, t)
					},
					cutPosTop = math.lerp(cutPosTop, other.cutPosTop, t),
					cutPosBottom = math.lerp(cutPosBottom, other.cutPosBottom, t)
				};
			}
		}

		private struct ExtensionCurve
		{
			public MathUtils.Quadratic heightCurve;

			public float3 motionFwdVector;

			public float3 motionUpVector;

			public ExtensionCurve(DetailData details)
			{
				heightCurve = details.extensionPath;
				motionUpVector = details.up;
				motionFwdVector = details.forward;
			}

			public readonly float3 SampleOffset(float x)
			{
				return motionUpVector * heightCurve[x] - motionFwdVector * x;
			}
		}

		private struct GenerationData
		{
			public float extensionDistance;
		}

		[BurstCompile]
		private struct RuntimeData : IControlSurfaceRuntimeData
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal unsafe delegate void UpdateFunction_00005A2E_0024PostfixBurstDelegate(ref ControlSurfaceRuntimeArgs args, void* data);

			internal static class UpdateFunction_00005A2E_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<UpdateFunction_00005A2E_0024PostfixBurstDelegate>(UpdateFunction).Value;
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

			public float maxDeflection;

			public float maxExtension;

			public float2 range;

			public ExtensionCurve rootExtensionCurve;

			public float2 startPos;

			public float3 rootPosWingspace;

			public float3 tipPosWingspace;

			public ExtensionCurve tipExtensionCurve;

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
				UpdateFunction_00005A2E_0024BurstDirectCall.Invoke(ref args, data);
			}

			private void Update(ref ControlSurfaceRuntimeArgs args)
			{
				float num = args.controls[0];
				float num2 = math.saturate(num / 0.8f) * maxExtension;
				float num3 = math.saturate(math.unlerp(0.6f, 1f, num)) * maxDeflection;
				float3 float5 = rootExtensionCurve.SampleOffset(num2);
				float3 obj = tipExtensionCurve.SampleOffset(num2);
				MathUtils.Linear gradient = rootExtensionCurve.heightCurve.Gradient;
				float num4 = math.atan(gradient[num2]) - math.atan(gradient[0f]);
				float num5 = num3 - num4;
				float3 float6 = math.normalize(obj + tipPosWingspace - float5 - rootPosWingspace);
				float3 float7 = math.cross(math.forward(), float6);
				quaternion a = quaternion.LookRotation(math.cross(float6, float7), float7);
				args.transforms[0] = math.mul(args.inverseBaseTransforms[0], new RigidTransform
				{
					pos = float5 + rootPosWingspace,
					rot = math.mul(a, quaternion.AxisAngle(math.left(), num5))
				});
				ref readonly StandardPhysicsFunctions.FlapPhysics instance = ref StandardPhysicsFunctions.FlapPhysics.Instance;
				for (int i = 0; i < args.SliceCount; i++)
				{
					SliceData data = args.sliceData[i];
					SliceAeroData aero = args.sliceAero[i];
					SlicePolar value = args.slicePolar[i];
					float num6 = args.Coverage(i);
					aero.effectiveChordLength += num2 * num6;
					float t = math.unlerp(range.x, range.y, data.spanPosition);
					float num7 = (math.lerp(startPos.x, startPos.y, t) - data.ZRange.y) / data.chordLength;
					instance.PlainFlapPhysics(num5, num7, num6, in data, in aero, out var liftIncrement, out var clMaxIncrement);
					value.ApplyLiftIncrement(liftIncrement);
					value.ApplyCLMaxIncrement(clMaxIncrement);
					float chordExtensionRatio = 1f + num2 * num6 / data.chordLength;
					float liftLocation = StandardPhysicsFunctions.ComputePlainSplitFlapIncrementalLoadPressureLocation(num7);
					value.ApplyFlapMoment(liftIncrement, liftLocation, chordExtensionRatio);
					args.sliceAero[i] = aero;
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

		private static MeshDefinition[] _meshDefinitions = new MeshDefinition[1]
		{
			new MeshDefinition(hasCollider: true)
		};

		private NativeArray<DetailData> _details;

		private GenerationData _generationData;

		private float _maxDeflection;

		private RuntimeData _runtimeData;

		public override MeshDefinition[] MeshDefinitions => _meshDefinitions;

		public override void AllocateNativeData(int sliceCount)
		{
			_details = new NativeArray<DetailData>(sliceCount, Allocator.TempJob);
		}

		public override void ApplyToCrossSections(ControlSurfaceSectionInput input)
		{
			float spanPosition = math.unlerp(Range.x, Range.y, input.Wing.SpanPosition);
			new CrossSectionJob
			{
				wing = input.Wing,
				cs = input.SurfaceSections[0],
				startPos = base.StartPos,
				spanPosition = spanPosition,
				details = _details.Slice(input.SliceIndex, 1),
				region = input.RegionIndex,
				generationData = _generationData
			}.Run();
			if (input.SliceIndex == 0 || input.SliceIndex == _details.Length - 1)
			{
				DetailData detailData = _details[input.SliceIndex];
				input.Meshes[base.MeshIndexOffset].SetPivot(detailData.pivot);
			}
		}

		public override void CopySettingsTo(ControlSurface dest)
		{
			base.CopySettingsTo(dest);
			(dest as FowlerFlap)._maxDeflection = _maxDeflection;
		}

		public override void FreeNativeData()
		{
			_details.Dispose();
		}

		public override IControlSurfaceRuntimeData GetRuntimeData(bool wingFlipped)
		{
			RuntimeData runtimeData = _runtimeData;
			if (wingFlipped)
			{
				runtimeData.rootPosWingspace.y = 0f - runtimeData.rootPosWingspace.y;
				runtimeData.tipPosWingspace.y = 0f - runtimeData.tipPosWingspace.y;
			}
			return runtimeData;
		}

		public override void Init(XElement xml)
		{
			base.Init(xml);
			_maxDeflection = DataIO.ParseFloat(xml.Attribute("maxDeflection")?.Value, 40f);
		}

		public override void PostPass(MeshBuilder[] meshes)
		{
			_ = meshes[base.MeshIndexOffset].InverseTransform;
			_runtimeData.rootExtensionCurve = new ExtensionCurve(_details[0]);
			ref RuntimeData runtimeData = ref _runtimeData;
			ref NativeArray<DetailData> details = ref _details;
			runtimeData.tipExtensionCurve = new ExtensionCurve(details[details.Length - 1]);
			_runtimeData.rootPosWingspace = _details[0].pivot;
			ref RuntimeData runtimeData2 = ref _runtimeData;
			ref NativeArray<DetailData> details2 = ref _details;
			runtimeData2.tipPosWingspace = details2[details2.Length - 1].pivot;
		}

		public override void PrePass(ReadOnlySpan<WingSlice> inSlices, NativeList<SurfaceRegion.Slice> regions)
		{
			float x = 0f;
			float num = float.PositiveInfinity;
			for (int i = 0; i < inSlices.Length; i++)
			{
				WingSlice wingSlice = inSlices[i];
				float end = wingSlice.Position.z + -0.5f * wingSlice.Scale;
				float t = math.unlerp(Range.x, Range.y, wingSlice.SpanPosition);
				float num2 = math.lerp(base.StartPos.x, base.StartPos.y, t);
				x = math.max(x, num2 - math.lerp(num2, end, 0.6f));
				num = math.min(num, num2 - math.lerp(num2, end, 0.8f));
			}
			float num3 = math.max(0f, math.min(x, num));
			_runtimeData.maxExtension = num3;
			_runtimeData.maxDeflection = math.radians(_maxDeflection);
			_runtimeData.range = Range;
			_runtimeData.startPos = base.StartPos;
			_generationData = new GenerationData
			{
				extensionDistance = num3
			};
		}

		public override void SaveToXml(XElement xml)
		{
			base.SaveToXml(xml);
			xml.SetAttributeValue("maxDeflection", DataIO.ToString(_maxDeflection));
		}

		public override bool ApplyToColliders(NativeList<float3> mainCollider, Span<NativeList<float3>> surfaceColliders, int sliceIndex)
		{
			new ColliderGenJob
			{
				details = _details[sliceIndex],
				mainCollider = mainCollider,
				surfaceCollider = surfaceColliders[0]
			}.Run();
			return surfaceColliders[0].Length != 0;
		}
	}
}
