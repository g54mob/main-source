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
	internal class BrakeFlap : TrailingFlapBase
	{
		[BurstCompile]
		private struct ColliderJob : IJob
		{
			public DetailData details;

			public NativeList<float3> mainCollider;

			public NativeList<float3> surfaceCollider;

			readonly void IJob.Execute()
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
				float num = math.distance(details.trailingTop, details.hingeCentre);
				for (int j = 0; j < 6; j++)
				{
					math.sincos(MathF.PI * (float)j / 5f, out var s, out var c);
					surfaceCollider.Add(details.hingeCentre + math.float3(0f, c, s) * num);
				}
			}
		}

		[BurstCompile]
		private struct CrossSectionJob : IJob
		{
			[ReadOnly]
			public NativeAirfoil Airfoil;

			public CrossSection BottomPanel;

			public NativeSlice<DetailData> Details;

			[WriteOnly]
			public NativeArray<float3> Pivots;

			[ReadOnly]
			public PrePassData PrePassData;

			[ReadOnly]
			public int Region;

			[ReadOnly]
			public float2 Span;

			[ReadOnly]
			public float2 StartPos;

			public CrossSection Stub;

			public CrossSection TopPanel;

			public CrossSection Wing;

			public void Execute()
			{
				float t = math.unlerp(Span.x, Span.y, Wing.SpanPosition);
				float num = Wing.MeshToSliceChord(math.lerp(StartPos.x, StartPos.y, t));
				SectionPatch sectionPatch = new SectionPatch(Wing, num, num, SurfaceLocation.TrailingEdge, Allocator.Temp);
				if (!sectionPatch.Valid)
				{
					return;
				}
				float num2 = sectionPatch.Cutout.StartPoint.Position.y - sectionPatch.Cutout.EndPoint.Position.y;
				float num3 = num - 0.15f * num2;
				float2 float5 = TopSurf(num3);
				float2 float6 = BottomSurf(num3);
				float2 float7 = 0.5f * (float5 + float6);
				float num4 = float5.y - float7.y;
				float num5 = num3 - 1.5f * num4;
				float num6 = num5;
				Details[0] = new DetailData
				{
					position = Wing.SpanPosition,
					hingeCentre = Wing.SliceToMeshPos(float7),
					trailingTop = Wing.SliceToMeshPos(sectionPatch.Cutout.StartPoint.Position),
					trailingBottom = Wing.SliceToMeshPos(sectionPatch.Cutout.EndPoint.Position)
				};
				if (Region == 0)
				{
					float y = (num5 - -0.5f) * 0.5f;
					float num7 = math.min(PrePassData.targetDipLength / Wing.Scale, y);
					num5 -= num7 * (1f + PrePassData.GetDip(Wing.SpanPosition));
				}
				Pivots[0] = Wing.SliceToMeshPos(float7);
				sectionPatch.Patch.Add(sectionPatch.Cutout.StartPoint.Sharp());
				float x = float7.x + 1.2f * num4;
				float num8 = Airfoil.SampleTop(x);
				float num9 = Airfoil.SampleBottom(x);
				float num10 = (num8 - num9) * 0.1f;
				sectionPatch.Patch.Add(new Point(math.float2(x, num8 - num10), smooth: false));
				sectionPatch.Patch.Add(new Point(math.float2(x, num9 + num10), smooth: false));
				sectionPatch.Patch.Add(sectionPatch.Cutout.EndPoint.Sharp());
				Stub.Points.Arc(float7, MathF.PI, 0f, num4, 10, includeEnds: true);
				LoopCutout? cutout = Wing.GetCutout(num3, num5, SurfaceLocation.TopSurface);
				if (cutout.HasValue)
				{
					Stub.Points.Add(cutout.Value, includeEnds: false, resetMeshRefs: true, -1, -1);
					Stub.Points.Add(cutout.Value.EndPoint.Sharp());
				}
				cutout = Wing.GetCutout(num5, num3, SurfaceLocation.BottomSurface);
				if (cutout.HasValue)
				{
					Stub.Points.Add(cutout.Value.StartPoint.Sharp());
					Stub.Points.Add(cutout.Value, includeEnds: false, resetMeshRefs: true, -1, -1);
				}
				TopPanel.Points.Add(new Point(TopSurf(num5), smooth: false));
				for (int i = 1; i < 5; i++)
				{
					float t2 = (float)i / 5f;
					float num11 = math.lerp(num6, -0.5f, t2);
					if (num11 < num5)
					{
						TopPanel.Points.Add(new Point(TopSurf(num11)));
					}
				}
				TopPanel.Points.Add(new Point(math.float2(-0.5f, 0f), smooth: false));
				for (int j = 1; j < 5; j++)
				{
					float t3 = (float)j / 5f;
					float num12 = math.lerp(-0.5f, num6, t3);
					if (num12 < num5)
					{
						float top = Airfoil.SampleTop(num12);
						float bottom = Airfoil.SampleBottom(num12);
						TopPanel.Points.Add(new Point(math.float2(num12, PanelInside(top, bottom, isTop: true))));
					}
				}
				TopPanel.Points.Add(new Point(math.float2(num5, PanelInside(Airfoil.SampleTop(num5), Airfoil.SampleBottom(num5), isTop: true)), smooth: false));
				ref NativeArray<float3> pivots = ref Pivots;
				ref CrossSection wing = ref Wing;
				float2 position = TopPanel.Points[0].Position;
				ref NativeList<Point> points = ref TopPanel.Points;
				pivots[1] = wing.SliceToMeshPos(math.lerp(position, points[points.Length - 1].Position, 0.5f));
				BottomPanel.Points.Add(new Point(math.float2(num5, PanelInside(Airfoil.SampleTop(num5), Airfoil.SampleBottom(num5), isTop: false)), smooth: false));
				for (int k = 0; k < 5; k++)
				{
					float t4 = (float)k / 5f;
					float num13 = math.lerp(num6, -0.5f, t4);
					if (num13 < num5)
					{
						float top2 = Airfoil.SampleTop(num13);
						float bottom2 = Airfoil.SampleBottom(num13);
						BottomPanel.Points.Add(new Point(math.float2(num13, PanelInside(top2, bottom2, isTop: false)), k != 0));
					}
				}
				BottomPanel.Points.Add(new Point(BottomSurf(-0.5f), smooth: false));
				for (int l = 1; l < 5; l++)
				{
					float t5 = (float)l / 5f;
					float num14 = math.lerp(-0.5f, num6, t5);
					if (num14 < num5)
					{
						BottomPanel.Points.Add(new Point(BottomSurf(num14)));
					}
				}
				BottomPanel.Points.Add(new Point(BottomSurf(num5), smooth: false));
				ref NativeArray<float3> pivots2 = ref Pivots;
				ref CrossSection wing2 = ref Wing;
				float2 position2 = BottomPanel.Points[0].Position;
				ref NativeList<Point> points2 = ref BottomPanel.Points;
				pivots2[2] = wing2.SliceToMeshPos(math.lerp(position2, points2[points2.Length - 1].Position, 0.5f));
				sectionPatch.ApplyAndDispose();
				static float PanelInside(float num15, float num16, bool isTop)
				{
					float y2 = 0.5f * (num15 + num16);
					if (!isTop)
					{
						return math.min(num16 + 0.005f, y2);
					}
					return math.max(num15 - 0.005f, y2);
				}
			}

			private float2 BottomSurf(float x)
			{
				return math.float2(x, Airfoil.SampleBottom(x));
			}

			private float2 TopSurf(float x)
			{
				return math.float2(x, Airfoil.SampleTop(x));
			}
		}

		private struct DetailData : IInterpolatedData<DetailData>
		{
			public float3 hingeCentre;

			public float position;

			public float3 trailingBottom;

			public float3 trailingTop;

			public readonly float Position => position;

			public DetailData Interpolate(DetailData other, float pos)
			{
				return new DetailData
				{
					position = pos,
					hingeCentre = math.lerp(hingeCentre, other.hingeCentre, pos),
					trailingBottom = math.lerp(trailingBottom, other.trailingBottom, pos),
					trailingTop = math.lerp(trailingTop, other.trailingTop, pos)
				};
			}
		}

		private struct PrePassData
		{
			public float targetDipLength;

			private unsafe fixed float _tapers[12];

			public unsafe static ref float2 Taper(PrePassData* pt, int index)
			{
				if (index < 0 || index >= 6)
				{
					throw new IndexOutOfRangeException();
				}
				return ref *(float2*)((byte*)pt->_tapers + (nint)index * (nint)sizeof(float2));
			}

			public unsafe float GetDip(float pos)
			{
				PrePassData prePassData = this;
				for (int i = 0; i < 6; i++)
				{
					float2 float5 = *(float2*)(prePassData._tapers + i * 2);
					bool flag = i % 2 == 0;
					if (pos <= float5.x)
					{
						if (!flag)
						{
							return 1f;
						}
						return 0f;
					}
					if (pos < float5.y)
					{
						float num = math.unlerp(float5.x, float5.y, pos);
						if (!flag)
						{
							return 1f - num;
						}
						return num;
					}
				}
				return 0f;
			}
		}

		[BurstCompile]
		private struct RuntimeData : IControlSurfaceRuntimeData
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal unsafe delegate void UpdateFunction_000059BD_0024PostfixBurstDelegate(ref ControlSurfaceRuntimeArgs args, void* data);

			internal static class UpdateFunction_000059BD_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<UpdateFunction_000059BD_0024PostfixBurstDelegate>(UpdateFunction).Value;
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

			public float MaxBrakeDeflectionBottom;

			public float MaxBrakeDeflectionTop;

			public float MaxFlapDeflection;

			public float BrakeDeflectionSpeed;

			public float CurrentBrakeDeflection;

			public float2 Range;

			public float2 StartPos;

			public readonly int InputCount => 2;

			public readonly void GetInputRanges(Span<float2> ranges)
			{
				ranges[0] = math.float2(-1f, 1f);
				ranges[1] = math.float2(0f, 1f);
			}

			unsafe ControlSurfaceRuntimeUpdateFunction IControlSurfaceRuntimeData.GetUpdateFunction(List<IntPtr> mallocPtrs)
			{
				return ControlSurfaceRuntimeUpdateFunction.Create(BurstCompiler.CompileFunctionPointer<ControlSurfaceRuntimeUpdateFunction.RuntimeUpdateDelegate>(UpdateFunction), this, mallocPtrs);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(ControlSurfaceRuntimeUpdateFunction.RuntimeUpdateDelegate))]
			private unsafe static void UpdateFunction(ref ControlSurfaceRuntimeArgs args, void* data)
			{
				UpdateFunction_000059BD_0024BurstDirectCall.Invoke(ref args, data);
			}

			private void Update(ref ControlSurfaceRuntimeArgs args)
			{
				float num = args.dt * BrakeDeflectionSpeed;
				CurrentBrakeDeflection = math.clamp(args.controls[1], CurrentBrakeDeflection - num, CurrentBrakeDeflection + num);
				float num2 = args.controls[0] * MaxFlapDeflection;
				float num3 = CurrentBrakeDeflection * MaxBrakeDeflectionTop;
				float num4 = CurrentBrakeDeflection * MaxBrakeDeflectionBottom;
				num2 += 0.6f * (num4 - num3);
				args.transforms[0] = RigidTransform.AxisAngle(math.right(), 0f - num2);
				args.transforms[1] = RigidTransform.AxisAngle(math.right(), num3);
				args.transforms[2] = RigidTransform.AxisAngle(math.right(), 0f - num4);
				ref readonly StandardPhysicsFunctions.FlapPhysics instance = ref StandardPhysicsFunctions.FlapPhysics.Instance;
				for (int i = 0; i < args.SliceCount; i++)
				{
					SliceData data = args.sliceData[i];
					SliceAeroData aero = args.sliceAero[i];
					SlicePolar value = args.slicePolar[i];
					float coverage = args.Coverage(i);
					float t = math.unlerp(Range.x, Range.y, data.spanPosition);
					float num5 = math.lerp(StartPos.x, StartPos.y, t) - data.ZRange.y;
					float num6 = num5 / data.chordLength;
					instance.PlainFlapPhysics(num2, num6, coverage, in data, in aero, out var liftIncrement, out var clMaxIncrement);
					value.ApplyLiftIncrement(liftIncrement);
					value.ApplyCLMaxIncrement(clMaxIncrement);
					float liftLocation = StandardPhysicsFunctions.ComputePlainSplitFlapIncrementalLoadPressureLocation(num6);
					value.ApplyFlapMoment(liftIncrement, liftLocation);
					float num7 = math.sin(0.5f * (num4 + num3));
					float num8 = math.sin(0.5f * (MaxBrakeDeflectionTop + MaxBrakeDeflectionBottom));
					value.liftGradient *= 1f - math.clamp(num6, 1f, 0.9f) * math.sqrt(math.saturate(num7 / num8));
					value.dragCurve.zeroLiftDrag += 1.4f * math.sqrt(num7 / num8) * num5;
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

		private const int XmlVersion = 2;

		private static MeshDefinition[] _meshDefinitions = new MeshDefinition[3]
		{
			new MeshDefinition(hasCollider: true),
			new MeshDefinition(hasCollider: false, 0),
			new MeshDefinition(hasCollider: false, 0)
		};

		private NativeArray<DetailData> _detailData;

		private float _maxBrakeDeflectionBottom;

		private float _maxBrakeDeflectionTop;

		private float _maxFlapDeflection;

		private float _brakeDeflectionSpeed;

		private PrePassData _prePassData;

		public override MeshDefinition[] MeshDefinitions => _meshDefinitions;

		public override void AllocateNativeData(int sliceCount)
		{
			_detailData = new NativeArray<DetailData>(sliceCount, Allocator.TempJob);
		}

		public override bool ApplyToColliders(NativeList<float3> mainCollider, Span<NativeList<float3>> surfaceColliders, int sliceIndex)
		{
			new ColliderJob
			{
				mainCollider = mainCollider,
				surfaceCollider = surfaceColliders[0],
				details = _detailData[sliceIndex]
			}.Run();
			return true;
		}

		public override void ApplyToCrossSections(ControlSurfaceSectionInput i)
		{
			using NativeArray<float3> pivots = new NativeArray<float3>(3, Allocator.TempJob);
			new CrossSectionJob
			{
				Wing = i.Wing,
				Stub = i.SurfaceSections[0],
				TopPanel = i.SurfaceSections[1],
				BottomPanel = i.SurfaceSections[2],
				Span = Range,
				StartPos = base.StartPos,
				Airfoil = i.Airfoil,
				Pivots = pivots,
				PrePassData = _prePassData,
				Region = i.RegionIndex,
				Details = _detailData.Slice(i.SliceIndex, 1)
			}.Run();
			for (int j = 0; j < pivots.Length; j++)
			{
				i.Meshes[base.MeshIndexOffset + j].SetPivot(pivots[j]);
			}
		}

		public override void CopySettingsTo(ControlSurface dest)
		{
			base.CopySettingsTo(dest);
			BrakeFlap obj = (BrakeFlap)dest;
			obj._maxFlapDeflection = _maxFlapDeflection;
			obj._maxBrakeDeflectionBottom = _maxBrakeDeflectionBottom;
			obj._maxBrakeDeflectionTop = _maxBrakeDeflectionTop;
			obj._brakeDeflectionSpeed = _brakeDeflectionSpeed;
		}

		public override void FreeNativeData()
		{
			_detailData.DisposeIfCreated();
		}

		public override IControlSurfaceRuntimeData GetRuntimeData(bool wingFlipped)
		{
			return new RuntimeData
			{
				MaxFlapDeflection = math.radians(_maxFlapDeflection),
				MaxBrakeDeflectionTop = math.radians(_maxBrakeDeflectionTop),
				MaxBrakeDeflectionBottom = math.radians(_maxBrakeDeflectionBottom),
				Range = Range,
				StartPos = base.StartPos,
				BrakeDeflectionSpeed = _brakeDeflectionSpeed,
				CurrentBrakeDeflection = 0f
			};
		}

		public override void Init(XElement xml)
		{
			base.Init(xml);
			int intAttribute = xml.GetIntAttribute("version", 1);
			_maxFlapDeflection = xml.GetFloatAttribute("flapDeflection", 30f);
			_maxBrakeDeflectionTop = xml.GetFloatAttribute("brakeDeflectionTop", 80f);
			_maxBrakeDeflectionBottom = xml.GetFloatAttribute("brakeDeflectionBottom", 80f);
			_brakeDeflectionSpeed = xml.GetFloatAttribute("brakeDeflectionSpeed", 0.8f);
			if (intAttribute < 2 && _maxBrakeDeflectionTop == 90f)
			{
				_maxBrakeDeflectionTop = 80f;
			}
		}

		public unsafe override void PrePass(ReadOnlySpan<WingSlice> inSlices, NativeList<SurfaceRegion.Slice> regions)
		{
			float num = Range.y - Range.x;
			float num2 = 0f;
			for (int i = 1; i < inSlices.Length; i++)
			{
				num2 += (inSlices[i].Scale + inSlices[i - 1].Scale) * 0.5f * (inSlices[i].SpanPosition - inSlices[i - 1].SpanPosition);
			}
			num2 /= num;
			float hingeWidth = math.min(num2 * 0.06f, num * 0.125f);
			float innerHingeWidth = hingeWidth * 0.3f;
			float num3 = hingeWidth * 0.35f;
			PrePassData prePassData = new PrePassData
			{
				targetDipLength = num3
			};
			PrePassData* ppt = &prePassData;
			int i2 = 0;
			float start = innerHingeWidth;
			float end = innerHingeWidth + num3;
			AddSlice(SurfaceRegion.SliceType.StartRegion, start);
			AddSlice(SurfaceRegion.SliceType.Slice, end);
			PrePassData.Taper(ppt, i2++) = math.float2(start, end) + Range.x;
			DoHinge(num * 0.3f);
			DoHinge(num * 0.7f);
			start = num - (innerHingeWidth + num3);
			end = num - innerHingeWidth;
			AddSlice(SurfaceRegion.SliceType.Slice, start);
			AddSlice(SurfaceRegion.SliceType.EndRegion, end);
			PrePassData.Taper(ppt, i2++) = math.float2(start, end) + Range.x;
			_prePassData = prePassData;
			void AddSlice(SurfaceRegion.SliceType type, float pos)
			{
				regions.Add(new SurfaceRegion.Slice(type, this, pos + Range.x, 0));
			}
			unsafe void DoHinge(float hingePos)
			{
				start = hingePos - hingeWidth * 0.5f;
				end = hingePos - innerHingeWidth * 0.5f;
				AddSlice(SurfaceRegion.SliceType.Slice, start);
				AddSlice(SurfaceRegion.SliceType.EndRegion, end);
				PrePassData.Taper(ppt, i2++) = math.float2(start, end) + Range.x;
				start = hingePos + innerHingeWidth * 0.5f;
				end = hingePos + hingeWidth * 0.5f;
				AddSlice(SurfaceRegion.SliceType.StartRegion, start);
				AddSlice(SurfaceRegion.SliceType.Slice, end);
				PrePassData.Taper(ppt, i2++) = math.float2(start, end) + Range.x;
			}
		}

		public override void SaveToXml(XElement xml)
		{
			base.SaveToXml(xml);
			xml.SetAttributeValue("version", 2);
			xml.SetAttributeValue("flapDeflection", DataIO.ToString(_maxFlapDeflection));
			xml.SetAttributeValue("brakeDeflectionTop", DataIO.ToString(_maxBrakeDeflectionTop));
			xml.SetAttributeValue("brakeDeflectionBottom", DataIO.ToString(_maxBrakeDeflectionBottom));
			xml.SetAttributeValue("brakeDeflectionSpeed", DataIO.ToString(_brakeDeflectionSpeed));
		}
	}
}
