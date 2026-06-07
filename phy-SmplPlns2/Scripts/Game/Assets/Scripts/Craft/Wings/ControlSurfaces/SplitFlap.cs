using System;
using System.Collections.Generic;
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
	internal class SplitFlap : ControlSurface
	{
		[BurstCompile]
		private struct ColliderJob : IJob
		{
			public NativeList<float3> collider;

			public DetailData data;

			public void Execute()
			{
				collider.Add(in data.tipPos);
				for (int i = 0; i < 4; i++)
				{
					float3 float5 = default(float3);
					math.sincos((float)i * (MathF.PI / 3f), out float5.z, out float5.y);
					collider.Add(float5 * data.hingeRadius + data.hingeCenter);
				}
			}
		}

		[BurstCompile]
		private struct CrossSectionJob : IJob
		{
			public NativeSlice<DetailData> details;

			public float globalHingeRadius;

			public float2 range;

			public int region;

			public float2 startPos;

			public CrossSection surface1;

			public CrossSection wing;

			public void Execute()
			{
				float t = math.unlerp(range.x, range.y, wing.SpanPosition);
				float num = wing.MeshToSliceChord(math.lerp(startPos.x, startPos.y, t));
				float num2 = globalHingeRadius / wing.Scale;
				NativeAirfoil.ReadOnly airfoil = wing.Airfoil;
				CrossSection surface = surface1;
				bool isStrake = region == -1;
				SectionPatch wingPatch = new SectionPatch(wing, -0.5f, num, SurfaceLocation.BottomSurface, Allocator.Temp);
				if (!wingPatch.Valid)
				{
					return;
				}
				LoopCutout? cutout = wing.GetCutout(-0.5f, num - num2, SurfaceLocation.BottomSurface);
				if (!cutout.HasValue)
				{
					return;
				}
				LoopCutout valueOrDefault = cutout.GetValueOrDefault();
				float smallRibStart = math.lerp(-0.5f, num, 1f / 3f);
				float largeRibStart = math.lerp(-0.5f, num, 2f / 3f);
				int ribStage = 0;
				float2 position = wingPatch.Cutout.StartPoint.Position;
				for (int i = 0; i < wingPatch.Cutout.Length; i++)
				{
					Point point = wingPatch.Cutout[i];
					float wingThickness = ThicknessAbove(point.Position);
					if (point.Position.x < num - num2)
					{
						UpdateRib(position, point.Position);
						surface.Points.Add(new Point(point.Position + math.float2(0f, GetCSThickness(wingThickness))));
						position = point.Position;
					}
					wingPatch.Patch.Add(new Point(point.Position + math.float2(0f, GetWingIndentThicknessAtPoint(wingThickness))));
				}
				UpdateRib(position, valueOrDefault.EndPoint.Position);
				float wingThickness2 = ThicknessAbove(wingPatch.Cutout.EndPoint.Position);
				wingPatch.Patch.Add(new Point(wingPatch.Cutout.EndPoint.Position + math.float2(0f, GetWingIndentThicknessAtPoint(wingThickness2)), smooth: false));
				wingPatch.Patch.Add(in wingPatch.Cutout.EndPoint);
				wingThickness2 = ThicknessAbove(valueOrDefault.EndPoint.Position);
				float2 float5 = valueOrDefault.EndPoint.Position + math.float2(0f, GetCSThickness(wingThickness2));
				surface.Points.Add(new Point(float5, smooth: false));
				surface.Points.AsArray().Reverse();
				Point value = wingPatch.Cutout.StartPoint;
				value.IsSmooth = false;
				surface.Points.Add(in value);
				surface.Points.Add(wingPatch.Cutout, includeEnds: false, resetMeshRefs: true, -1, -1);
				surface.Points.Add(in valueOrDefault.EndPoint);
				float2 float6 = (float5 + valueOrDefault.EndPoint.Position) * 0.5f;
				surface.Points.Arc(float6, MathF.PI, 0f, float5.y - float6.y, 6, includeEnds: false);
				if (!isStrake)
				{
					float5 = valueOrDefault.EndPoint.Position + math.float2(0f, GetStrakeThicknessAtPoint(ThicknessAbove(valueOrDefault.EndPoint.Position)));
					float6 = (float5 + valueOrDefault.EndPoint.Position) * 0.5f;
				}
				wingPatch.ApplyAndDispose();
				details[0] = new DetailData
				{
					hingeCenter = wing.SliceToMeshPos(float6),
					hingeRadius = (float5.y - float6.y) * wing.Scale,
					tipPos = wing.SliceToMeshPos(valueOrDefault.StartPoint.Position)
				};
				float GetCSThickness(float wingThickness3)
				{
					if (isStrake)
					{
						return GetStrakeThicknessAtPoint(wingThickness3);
					}
					return ribStage switch
					{
						1 => GetSmallRibThicknessAtPoint(wingThickness3), 
						3 => GetLargeRibThicknessAtPoint(wingThickness3), 
						_ => GetSkinThicknessAtPoint(wingThickness3), 
					};
				}
				void MakePoint(float2 p, float h, bool proportional = false)
				{
					surface.Points.Add(new Point(p + math.float2(0f, h), smooth: false, proportional));
				}
				float ThicknessAbove(float2 pt)
				{
					return airfoil.SampleTop(pt.x) - pt.y;
				}
				void UpdateRib(float2 from, float2 to)
				{
					if (ribStage != 4 && !(to.x < smallRibStart))
					{
						if (ribStage == 0)
						{
							ribStage = 1;
							float2 float7 = Interp(smallRibStart);
							float wingThickness3 = ThicknessAbove(float7);
							WingPoint(float7, wingThickness3);
							if (isStrake)
							{
								MakePoint(float7, GetStrakeThicknessAtPoint(wingThickness3));
							}
							else
							{
								MakePoint(float7, GetSkinThicknessAtPoint(wingThickness3), proportional: true);
								MakePoint(float7, GetSmallRibThicknessAtPoint(wingThickness3), proportional: true);
							}
						}
						if (!(to.x < smallRibStart + 0.004f))
						{
							if (ribStage == 1)
							{
								ribStage = 2;
								float2 float8 = Interp(smallRibStart + 0.004f);
								float wingThickness4 = ThicknessAbove(float8);
								WingPoint(float8, wingThickness4);
								if (isStrake)
								{
									MakePoint(float8, GetStrakeThicknessAtPoint(wingThickness4));
								}
								else
								{
									MakePoint(float8, GetSmallRibThicknessAtPoint(wingThickness4), proportional: true);
									MakePoint(float8, GetSkinThicknessAtPoint(wingThickness4), proportional: true);
								}
							}
							if (!(to.x < largeRibStart))
							{
								if (ribStage == 2)
								{
									ribStage = 3;
									float2 float9 = Interp(largeRibStart);
									float wingThickness5 = ThicknessAbove(float9);
									WingPoint(float9, wingThickness5);
									if (isStrake)
									{
										MakePoint(float9, GetStrakeThicknessAtPoint(wingThickness5));
									}
									else
									{
										MakePoint(float9, GetSkinThicknessAtPoint(wingThickness5), proportional: true);
										MakePoint(float9, GetLargeRibThicknessAtPoint(wingThickness5), proportional: true);
									}
								}
								if (!(to.x < largeRibStart + 0.004f) && ribStage == 3)
								{
									ribStage = 4;
									float2 float10 = Interp(largeRibStart + 0.004f);
									float wingThickness6 = ThicknessAbove(float10);
									WingPoint(float10, wingThickness6);
									if (isStrake)
									{
										MakePoint(float10, GetStrakeThicknessAtPoint(wingThickness6));
									}
									else
									{
										MakePoint(float10, GetLargeRibThicknessAtPoint(wingThickness6), proportional: true);
										MakePoint(float10, GetSkinThicknessAtPoint(wingThickness6), proportional: true);
									}
								}
							}
						}
					}
					float2 Interp(float x)
					{
						return math.float2(x, math.lerp(from.y, to.y, math.unlerp(from.x, to.x, x)));
					}
				}
				void WingPoint(float2 p, float wingThickness3)
				{
					wingPatch.Patch.Add(new Point(p + math.float2(0f, GetWingIndentThicknessAtPoint(wingThickness3))));
				}
			}
		}

		private struct DetailData
		{
			public float3 hingeCenter;

			public float hingeRadius;

			public float3 tipPos;
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

		private const float LargeRibPosition = 2f / 3f;

		private const float RibLength = 0.004f;

		private const float SmallRibPosition = 1f / 3f;

		private const float StrakesPerChordLength = 5f;

		private const float StrakeWidthChordRelative = 0.01f;

		private const float WingIndentThicknessNominal = 0.02f;

		private static MeshDefinition[] _meshDefinitions = new MeshDefinition[1]
		{
			new MeshDefinition(hasCollider: true)
		};

		private NativeArray<DetailData> _details;

		private float _hingeRadius;

		private float2 _startPos;

		public override SurfaceLocation Location => SurfaceLocation.TrailingEdge;

		public override MeshDefinition[] MeshDefinitions => _meshDefinitions;

		public override void AllocateNativeData(int sliceCount)
		{
			_details = new NativeArray<DetailData>(sliceCount, Allocator.TempJob);
		}

		public override bool ApplyToColliders(NativeList<float3> mainCollider, Span<NativeList<float3>> surfaceColliders, int sliceIndex)
		{
			new ColliderJob
			{
				collider = surfaceColliders[0],
				data = _details[sliceIndex]
			}.Run();
			return false;
		}

		public override void ApplyToCrossSections(ControlSurfaceSectionInput i)
		{
			NativeSlice<DetailData> details = _details.Slice(i.SliceIndex, 1);
			new CrossSectionJob
			{
				wing = i.Wing,
				surface1 = i.SurfaceSections[0],
				range = Range,
				startPos = _startPos,
				globalHingeRadius = _hingeRadius,
				details = details,
				region = i.RegionIndex
			}.Run();
			i.Meshes[base.MeshIndexOffset].SetPivot(details[0].hingeCenter);
		}

		public override void FreeNativeData()
		{
			_details.Dispose();
		}

		public override IControlSurfaceRuntimeData GetRuntimeData(bool wingFlipped)
		{
			return new RuntimeData
			{
				MaxDeflection = math.radians(-40f)
			};
		}

		public override void Init(XElement xml)
		{
			base.Init(xml);
			float2? float5 = xml.Float2Attribute("startPos");
			if (!float5.HasValue)
			{
				throw new ArgumentException($"hingePos attribute missing: {xml}");
			}
			_startPos = float5.Value;
		}

		public override void PrePass(ReadOnlySpan<WingSlice> inSlices, NativeList<SurfaceRegion.Slice> regions)
		{
			float num = float.PositiveInfinity;
			float num2 = 0f;
			for (int i = 0; i < inSlices.Length; i++)
			{
				num = math.min(num, inSlices[i].Scale);
				if (i != 0)
				{
					num2 += (inSlices[i].SpanPosition - inSlices[i - 1].SpanPosition) * 0.5f * (inSlices[i].Scale + inSlices[i - 1].Scale);
				}
			}
			_hingeRadius = num * 0.02f * 0.5f;
			float spanPosition = inSlices[0].SpanPosition;
			float spanPosition2 = inSlices[inSlices.Length - 1].SpanPosition;
			float num3 = spanPosition2 - spanPosition;
			float num4 = num2 / num3;
			float num5 = 0.01f * num4;
			num3 -= num5 * 2f;
			float num6 = num3 * num3 / num2;
			int num7 = (int)(5f * num6);
			float num8 = num3 / (float)(num7 + 1);
			regions.Add(new SurfaceRegion.Slice(SurfaceRegion.SliceType.StartRegion, this, spanPosition + num5, 0));
			float num9 = num5 * 0.5f;
			for (int j = 0; j < num7; j++)
			{
				float num10 = spanPosition + num5 + (float)(j + 1) * num8;
				regions.Add(new SurfaceRegion.Slice(SurfaceRegion.SliceType.EndRegion, this, num10 - num9, 0));
				regions.Add(new SurfaceRegion.Slice(SurfaceRegion.SliceType.StartRegion, this, num10 + num9, 0));
			}
			regions.Add(new SurfaceRegion.Slice(SurfaceRegion.SliceType.EndRegion, this, spanPosition2 - num5, 0));
		}

		private static float GetLargeRibThicknessAtPoint(float wingThickness)
		{
			return math.min(0.5f * wingThickness, 0.016f);
		}

		private static float GetSkinThicknessAtPoint(float wingThickness)
		{
			return math.min(0.2f * wingThickness, 0.006f);
		}

		private static float GetSmallRibThicknessAtPoint(float wingThickness)
		{
			return math.min(0.5f * wingThickness, 0.012f);
		}

		private static float GetStrakeThicknessAtPoint(float wingThickness)
		{
			return math.min(0.5f * wingThickness, 0.02f);
		}

		private static float GetWingIndentThicknessAtPoint(float wingThickness)
		{
			return math.min(0.5f * wingThickness, 0.02f);
		}
	}
}
