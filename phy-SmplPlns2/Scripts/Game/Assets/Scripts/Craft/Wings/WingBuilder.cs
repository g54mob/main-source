using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.Airfoils;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Craft.Wings.Physics;
using Assets.Scripts.Craft.Wings.Runtime;
using Jundroo.Common.Extensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Wings
{
	public static class WingBuilder
	{
		[BurstCompile]
		private struct TransferMeshIDsJob : IJob
		{
			[ReadOnly]
			public NativeArray<Point> TransferFrom;

			public NativeArray<Point> TransferTo;

			public NativeArray<int> TempBuffer;

			public void Execute()
			{
				int length = TempBuffer.Length;
				for (int i = 0; i < TransferTo.Length; i++)
				{
					int sharedPointID = TransferTo[i].SharedPointID;
					if (sharedPointID >= 0 && sharedPointID < length)
					{
						TempBuffer[sharedPointID] = i;
					}
				}
				for (int j = 0; j < TransferFrom.Length; j++)
				{
					Point point = TransferFrom[j];
					int sharedPointID2 = point.SharedPointID;
					if (sharedPointID2 >= 0 && sharedPointID2 < length)
					{
						int index = TempBuffer[sharedPointID2];
						Point value = TransferTo[index];
						value.MeshIndexA = point.MeshIndexA;
						value.MeshIndexB = point.MeshIndexB;
						TransferTo[index] = value;
					}
				}
			}
		}

		private struct SetMeshIDsJob : IJobFor
		{
			public NativeArray<Point> points;

			public void Execute(int index)
			{
				Point value = points[index];
				value.SharedPointID = (short)index;
				points[index] = value;
			}
		}

		[BurstCompile]
		private struct CalculateSliceAreaJob : IJob
		{
			public float Scale;

			[ReadOnly]
			public NativeArray<Point> points;

			[WriteOnly]
			public NativeArray<float4> res;

			void IJob.Execute()
			{
				float num = 0f;
				float2 float5 = 0f;
				float num2 = 0f;
				ref NativeArray<Point> reference = ref points;
				float2 position = reference[reference.Length - 1].Position;
				for (int i = 0; i < points.Length; i++)
				{
					float2 float6 = position;
					position = points[i].Position;
					num2 += math.length(position - float6);
					float2 float7 = 0.5f * (position + float6);
					float num3 = float7.y * (position.x - float6.x);
					num += num3;
					float5 += num3 * float7;
				}
				res[0] = math.float4(float5 / num, math.abs(num) * Scale, num2) * Scale;
			}
		}

		public const float SameSliceEpsilon = 0.001f;

		public static WingBuildOutput Generate(WingBuilderInput input)
		{
			WingSlice[] slices = InterpolateUserInput(input.inputSlices, input.surfaces).ToArray();
			return GenerateMesh(input, slices);
		}

		public static WingRuntimeOutput Generate(WingBuilderInput input, int? physicsSamples)
		{
			WingSlice[] slices = InterpolateUserInput(input.inputSlices, input.surfaces).ToArray();
			WingBuildOutput buildOutput = GenerateMesh(input, slices);
			return GenerateRuntimeData(slices, physicsSamples, input.flipped, input.surfaces, buildOutput);
		}

		public static (float3 Position, float Scale) GetInterpolatedSliceParams(float spanPos, ReadOnlySpan<WingSlice> slices)
		{
			for (int i = 0; i < slices.Length; i++)
			{
				WingSlice wingSlice = slices[i];
				if (wingSlice.SpanPosition >= spanPos)
				{
					if (i == 0)
					{
						return (Position: wingSlice.Position, Scale: wingSlice.Scale);
					}
					WingSlice wingSlice2 = slices[i - 1];
					float t = math.unlerp(wingSlice2.SpanPosition, wingSlice.SpanPosition, spanPos);
					return (Position: math.lerp(wingSlice2.Position, wingSlice.Position, t), Scale: math.lerp(wingSlice2.Scale, wingSlice.Scale, t));
				}
			}
			return (Position: slices[slices.Length - 1].Position, Scale: slices[slices.Length - 1].Scale);
		}

		public static (float Offset, float Scale) GetInterpolatedSlice(float spanPos, IList<InputWingSlice> slices)
		{
			float? num = null;
			float? num2 = null;
			float? num3 = null;
			float? num4 = null;
			float? num5 = null;
			float? num6 = null;
			for (int i = 0; i < slices.Count; i++)
			{
				InputWingSlice inputWingSlice = slices[i];
				if (inputWingSlice.UseOffset && !num.HasValue)
				{
					if (inputWingSlice.ApproximatelyEqualPosition(spanPos))
					{
						num = inputWingSlice.Offset;
					}
					else if (!(inputWingSlice.Position < spanPos))
					{
						num = ((!num2.HasValue) ? new float?(inputWingSlice.Offset) : new float?(math.remap(num3.Value, inputWingSlice.Position, num2.Value, inputWingSlice.Offset, spanPos)));
					}
					else
					{
						num2 = inputWingSlice.Offset;
						num3 = inputWingSlice.Position;
					}
				}
				if (inputWingSlice.UseScale && !num4.HasValue)
				{
					if (inputWingSlice.ApproximatelyEqualPosition(spanPos))
					{
						num4 = inputWingSlice.Scale;
					}
					else if (inputWingSlice.Position < spanPos)
					{
						num5 = inputWingSlice.Scale;
						num6 = inputWingSlice.Position;
					}
					else
					{
						num4 = ((!num5.HasValue) ? new float?(inputWingSlice.Scale) : new float?(math.remap(num6.Value, inputWingSlice.Position, num5.Value, inputWingSlice.Scale, spanPos)));
					}
				}
			}
			float? num7 = num;
			if (!num7.HasValue)
			{
				num = num2;
			}
			num7 = num4;
			if (!num7.HasValue)
			{
				num4 = num5;
			}
			return (Offset: num.Value, Scale: num4.Value);
		}

		public static void InterpolateScale(int index, IList<InputWingSlice> slices)
		{
			InputWingSlice inputWingSlice = null;
			InputWingSlice inputWingSlice2 = null;
			for (int num = index - 1; num >= 0; num--)
			{
				if (slices[num].UseScale)
				{
					inputWingSlice = slices[num];
				}
			}
			for (int i = index + 1; i < slices.Count; i++)
			{
				if (slices[i].UseScale)
				{
					inputWingSlice2 = slices[i];
				}
			}
			if (inputWingSlice != null)
			{
				if (inputWingSlice2 == null)
				{
					slices[index].Scale = inputWingSlice.Scale;
				}
				else
				{
					slices[index].Scale = math.remap(inputWingSlice.Position, inputWingSlice2.Position, inputWingSlice.Scale, inputWingSlice2.Scale, slices[index].Position);
				}
			}
		}

		public static void InterpolateOffset(int index, IList<InputWingSlice> slices)
		{
			InputWingSlice inputWingSlice = null;
			InputWingSlice inputWingSlice2 = null;
			for (int num = index - 1; num >= 0; num--)
			{
				if (slices[num].UseOffset)
				{
					inputWingSlice = slices[num];
				}
			}
			for (int i = index + 1; i < slices.Count; i++)
			{
				if (slices[i].UseOffset)
				{
					inputWingSlice2 = slices[i];
				}
			}
			if (inputWingSlice != null)
			{
				if (inputWingSlice2 == null)
				{
					slices[index].Offset = inputWingSlice.Offset;
				}
				else
				{
					slices[index].Offset = math.remap(inputWingSlice.Position, inputWingSlice2.Position, inputWingSlice.Offset, inputWingSlice2.Offset, slices[index].Position);
				}
			}
		}

		public static void InterpolateAllOffsetScale(IList<InputWingSlice> slices)
		{
			InputWingSlice inputWingSlice = slices[0];
			inputWingSlice.UseOffset = true;
			inputWingSlice.UseScale = true;
			InputWingSlice inputWingSlice2 = slices[slices.Count - 1];
			inputWingSlice2.UseOffset = true;
			inputWingSlice2.UseScale = true;
			bool flag = false;
			for (int i = 1; i < slices.Count; i++)
			{
				InputWingSlice inputWingSlice3 = slices[i];
				if (inputWingSlice3.UseOffset)
				{
					if (flag)
					{
						inputWingSlice2 = inputWingSlice3;
						int num = i - 1;
						while (slices[num] != inputWingSlice)
						{
							slices[num].Offset = math.remap(inputWingSlice.Position, inputWingSlice2.Position, inputWingSlice.Offset, inputWingSlice2.Offset, slices[num].Position);
							num--;
						}
					}
					inputWingSlice = inputWingSlice3;
					flag = false;
				}
				else
				{
					flag = true;
				}
			}
			inputWingSlice = slices[0];
			flag = false;
			for (int j = 1; j < slices.Count; j++)
			{
				InputWingSlice inputWingSlice4 = slices[j];
				if (inputWingSlice4.UseScale)
				{
					if (flag)
					{
						inputWingSlice2 = inputWingSlice4;
						int num2 = j - 1;
						while (slices[num2] != inputWingSlice)
						{
							slices[num2].Scale = math.remap(inputWingSlice.Position, inputWingSlice2.Position, inputWingSlice.Scale, inputWingSlice2.Scale, slices[num2].Position);
							num2--;
						}
					}
					inputWingSlice = inputWingSlice4;
					flag = false;
				}
				else
				{
					flag = true;
				}
			}
		}

		private static int PickPhysicsSamples(WingSlice[] slices)
		{
			if (slices.Length < 2)
			{
				return 4;
			}
			float num = 0f;
			WingSlice wingSlice = slices[0];
			for (int i = 1; i < slices.Length; i++)
			{
				WingSlice wingSlice2 = slices[i];
				num += (wingSlice2.SpanPosition - wingSlice.SpanPosition) * 0.5f * (wingSlice2.Scale + wingSlice.Scale);
				wingSlice = wingSlice2;
			}
			float num2 = wingSlice.SpanPosition * wingSlice.SpanPosition / num;
			if (math.isnan(num2))
			{
				return 4;
			}
			return math.clamp((int)math.ceil(num2 * 9f) + 1, 2, 32);
		}

		private static WingRuntimeOutput GenerateRuntimeData(WingSlice[] slices, int? physicsSamples, bool flipped, ControlSurface[] surfaces, WingBuildOutput buildOutput)
		{
			if (slices.Length < 2)
			{
				throw new ArgumentException($"Cannot create physics data with {slices.Length} slices.");
			}
			int num = physicsSamples ?? PickPhysicsSamples(slices);
			NativeArray<SliceData> physicsSlices = new NativeArray<SliceData>(num, Allocator.Persistent);
			List<IntPtr> mallocPtrs = new List<IntPtr>();
			float num2 = slices[^1].SpanPosition / (float)num;
			WingSlice wingSlice = slices[0];
			WingSlice wingSlice2 = slices[1];
			int num3 = 1;
			for (int i = 0; i < num; i++)
			{
				float num4 = num2 * ((float)i + 0.5f);
				while (wingSlice2.SpanPosition < num4 && num3 < slices.Length - 1)
				{
					num3++;
					wingSlice = wingSlice2;
					wingSlice2 = slices[num3];
				}
				float t = math.unlerp(wingSlice.SpanPosition, wingSlice2.SpanPosition, num4);
				float num5 = math.lerp(wingSlice.Scale, wingSlice2.Scale, t);
				float3 quarterChordPos = math.lerp(wingSlice.Position, wingSlice2.Position, t);
				float3 up = wingSlice.Up;
				quarterChordPos.z += num5 * 0.25f;
				IAirfoil airfoil = ((wingSlice.Airfoil != wingSlice2.Airfoil) ? InterpolatedAirfoil.GetInterpolated(wingSlice.Airfoil, wingSlice2.Airfoil, t) : wingSlice.Airfoil);
				up.y = (flipped ? (0f - up.y) : up.y);
				quarterChordPos.y = (flipped ? (0f - quarterChordPos.y) : quarterChordPos.y);
				physicsSlices[i] = new SliceData
				{
					spanPosition = num4,
					spanWidth = num2,
					quarterChordPos = quarterChordPos,
					chordLength = num5,
					airfoilRight = math.float3(up.y, 0f - up.x, 0f),
					airfoilUp = up,
					airfoilForward = math.float3(0f, 0f, 1f),
					airfoil = airfoil.GetRuntimeAirfoil(mallocPtrs),
					standardAirfoilParams = StandardPhysicsFunctions.ComputeStandardAirfoilParameters(airfoil)
				};
			}
			wingSlice = slices[0];
			wingSlice2 = slices[1];
			num3 = 1;
			for (int j = 0; j < num + 1; j++)
			{
				float num6 = num2 * (float)j;
				while (wingSlice2.SpanPosition < num6 && num3 < slices.Length - 1)
				{
					num3++;
					wingSlice = wingSlice2;
					wingSlice2 = slices[num3];
				}
				float3 float5;
				float3 float6;
				if (num6 == wingSlice.SpanPosition)
				{
					(float5, float6) = wingSlice.Edges;
				}
				else
				{
					float t2 = math.unlerp(wingSlice.SpanPosition, wingSlice2.SpanPosition, num6);
					(float3 Leading, float3 Trailing) edges = wingSlice.Edges;
					float3 item = edges.Leading;
					float3 item2 = edges.Trailing;
					(float3 Leading, float3 Trailing) edges2 = wingSlice2.Edges;
					float3 item3 = edges2.Leading;
					float3 item4 = edges2.Trailing;
					float5 = math.lerp(item, item3, t2);
					float6 = math.lerp(item2, item4, t2);
				}
				if (j != 0)
				{
					SliceData value = physicsSlices[j - 1];
					value.panelTipLeading = float5;
					value.panelTipTrailing = float6;
					physicsSlices[j - 1] = value;
				}
				if (j != num)
				{
					SliceData value2 = physicsSlices[j];
					value2.panelRootLeading = float5;
					value2.panelRootTrailing = float6;
					physicsSlices[j] = value2;
				}
			}
			Transform[] array = new Transform[buildOutput.MeshObjects.Length - 1];
			for (int k = 1; k < buildOutput.MeshObjects.Length; k++)
			{
				array[k - 1] = buildOutput.MeshObjects[k].transform;
			}
			return new WingRuntimeOutput
			{
				MeshOutput = buildOutput,
				ControlSurfaceTransforms = array,
				PhysicsSlices = physicsSlices,
				MallocPtrs = mallocPtrs,
				IsFlipped = flipped,
				ControlSurfaces = surfaces
			};
		}

		private static WingBuildOutput GenerateMesh(WingBuilderInput input, WingSlice[] slices)
		{
			bool[] csValid = new bool[input.surfaces.Length];
			for (int i = 0; i < input.surfaces.Length; i++)
			{
				ControlSurface controlSurface = input.surfaces[i];
				string text = controlSurface.Validate(slices);
				if (text != null)
				{
					text = $"Surfaces[{i}] ({controlSurface}) failed validation: {text}";
					if (input.ThrowOnValidationFail)
					{
						throw new ControlSurfaceValidationException(text);
					}
					Debug.LogWarning(text);
				}
				csValid[i] = text == null;
			}
			int num = 1;
			for (int j = 0; j < input.surfaces.Length; j++)
			{
				ControlSurface controlSurface2 = input.surfaces[j];
				if (csValid[j])
				{
					controlSurface2.MeshIndexOffset = num;
					num += controlSurface2.MeshCount;
				}
				else
				{
					controlSurface2.MeshIndexOffset = -1;
				}
			}
			bool num2 = input.getPartMeshRenderers == null;
			MeshBuilder[] meshes = new MeshBuilder[num];
			if (num2)
			{
				int num3 = 0;
				MeshFilter[] componentsInDirectChildren = input.parent.GetComponentsInDirectChildren<MeshFilter>();
				if (!input.HideMainMesh)
				{
					FindOrCreateRenderers(input.parent, 1, 0, meshes.AsSpan(0..((meshes.Length != 0) ? 1 : 0)), componentsInDirectChildren, in input, destroyExcess: false);
					num3++;
				}
				for (int k = 0; k < input.surfaces.Length; k++)
				{
					if (csValid[k])
					{
						ControlSurface controlSurface3 = input.surfaces[k];
						Span<MeshBuilder> builders = meshes.AsSpan(controlSurface3.MeshIndexOffset..(controlSurface3.MeshIndexOffset + controlSurface3.MeshCount));
						if (input.surfaceParentTransforms != null && input.surfaceParentTransforms[k] != null)
						{
							FindOrCreateRenderers(input.surfaceParentTransforms[k], controlSurface3.MeshCount, controlSurface3.MeshIndexOffset, builders, in input, destroyExcess: true);
							continue;
						}
						Span<MeshFilter> usableExistingFilters = componentsInDirectChildren.AsSpan(Math.Min(num3, componentsInDirectChildren.Length));
						FindOrCreateRenderers(input.parent, controlSurface3.MeshCount, controlSurface3.MeshIndexOffset, builders, usableExistingFilters, in input, destroyExcess: false);
						num3 += controlSurface3.MeshCount;
					}
				}
				for (int l = num3; l < componentsInDirectChildren.Length; l++)
				{
					MeshFilter meshFilter = componentsInDirectChildren[l];
					input.onDestroyRenderer?.Invoke(meshFilter.GetComponent<MeshRenderer>());
					DestroyMesh(meshFilter);
				}
			}
			else
			{
				if (!input.HideMainMesh && meshes.Length != 0)
				{
					ProceduralPartMeshRenderer[] array = input.getPartMeshRenderers(1, null);
					meshes[0] = new MeshBuilder(array[0]);
				}
				for (int m = 0; m < input.surfaces.Length; m++)
				{
					if (csValid[m])
					{
						ControlSurface controlSurface4 = input.surfaces[m];
						meshes.AsSpan(controlSurface4.MeshIndexOffset..(controlSurface4.MeshIndexOffset + controlSurface4.MeshCount));
						ProceduralPartMeshRenderer[] array2 = input.getPartMeshRenderers(controlSurface4.MeshCount, m);
						for (int n = 0; n < controlSurface4.MeshCount; n++)
						{
							meshes[controlSurface4.MeshIndexOffset + n] = new MeshBuilder(array2[n]);
						}
					}
				}
			}
			for (int num4 = 0; num4 < num; num4++)
			{
				meshes[num4]?.Prepare();
			}
			ColliderGenerator[] colliderGenerators = new ColliderGenerator[meshes.Length];
			if (!input.HideMainMesh)
			{
				colliderGenerators[0] = new ColliderGenerator(meshes[0].Object);
			}
			NativeList<float3> a = new NativeList<float3>(Allocator.TempJob);
			NativeList<float3>[] colliderSlices = new NativeList<float3>[meshes.Length];
			colliderSlices[0] = new NativeList<float3>(Allocator.TempJob);
			for (int num5 = 0; num5 < input.surfaces.Length; num5++)
			{
				if (!csValid[num5])
				{
					continue;
				}
				ControlSurface controlSurface5 = input.surfaces[num5];
				for (int num6 = 0; num6 < controlSurface5.MeshCount; num6++)
				{
					if (controlSurface5.MeshDefinitions[num6].HasCollider)
					{
						int num7 = num6 + controlSurface5.MeshIndexOffset;
						colliderGenerators[num7] = new ColliderGenerator(meshes[num7].Object);
						colliderSlices[num7] = new NativeList<float3>(Allocator.TempJob);
					}
				}
			}
			WingBuildOutput output = default(WingBuildOutput);
			output.MassPropertiesOutput = new MassPropertiesOutput[meshes.Length];
			NativeList<SurfaceRegion.Slice> nativeList = new NativeList<SurfaceRegion.Slice>(Allocator.TempJob);
			Span<WingSlice> span = new Span<WingSlice>(slices);
			for (int num8 = 0; num8 < input.surfaces.Length; num8++)
			{
				if (csValid[num8])
				{
					int length = nativeList.Length;
					ControlSurface controlSurface6 = input.surfaces[num8];
					controlSurface6.PrePass(span.Slice(controlSurface6.SectionOffset, controlSurface6.SectionCount), nativeList);
					int num9 = controlSurface6.SectionCount;
					for (int num10 = length; num10 < nativeList.Length; num10++)
					{
						int num11 = num9;
						num9 = num11 + nativeList[num10].Type switch
						{
							SurfaceRegion.SliceType.StartRegion => 2, 
							SurfaceRegion.SliceType.EndRegion => 2, 
							SurfaceRegion.SliceType.Slice => 1, 
							_ => 0, 
						};
					}
					controlSurface6.AllocateNativeData(num9);
				}
			}
			if (nativeList.Length > 0)
			{
				nativeList.Sort(nativeList[0]);
			}
			int num12 = 0;
			int num13 = 0;
			float num14 = 0f;
			for (int num15 = 0; num15 < nativeList.Length; num15++)
			{
				SurfaceRegion.Slice value = nativeList[num15];
				float spanPosition = value.SpanPosition;
				while (num14 < spanPosition)
				{
					num12 = num13++;
					num14 = slices[num13].SpanPosition;
				}
				value.InterpolateFrom(slices[num12], slices[num13]);
				nativeList[num15] = value;
			}
			uint num16 = 0u;
			CrossSection[] b = new CrossSection[num];
			CrossSection[] b2 = new CrossSection[num];
			CrossSection[] a2 = new CrossSection[num];
			AllocatePointLists(b, Allocator.TempJob);
			AllocatePointLists(b2, Allocator.TempJob);
			AllocatePointLists(a2, Allocator.TempJob);
			NativeAirfoil nativeAirfoil = default(NativeAirfoil);
			NativeAirfoil nativeAirfoil2 = default(NativeAirfoil);
			NativeAirfoil airfoil = default(NativeAirfoil);
			float num17 = 0f;
			float num18 = 0f;
			float num19 = 0f;
			MassPropertiesOutput massPropertiesOutput = default(MassPropertiesOutput);
			for (int num20 = slices.Length - 2; num20 >= 0; num20--)
			{
				WingSlice wingSlice = slices[num20];
				WingSlice wingSlice2 = slices[num20 + 1];
				float num21 = math.distance(wingSlice.Position.xy, wingSlice2.Position.xy);
				float centreT;
				float num22 = CalculateStructuralMassOfSection(wingSlice.Scale, wingSlice2.Scale, num21, num19, out centreT);
				float3 start = wingSlice.Position + math.float3(0f, 0f, 0.25f * wingSlice.Scale);
				float3 end = wingSlice2.Position + math.float3(0f, 0f, 0.25f * wingSlice2.Scale);
				float3 float5 = math.lerp(start, end, centreT);
				massPropertiesOutput.CentreOfMass += num22 * float5;
				massPropertiesOutput.Mass += num22;
				float num23 = 0.5f * (wingSlice.Scale + wingSlice2.Scale) * num21;
				num19 += num23;
			}
			output.MassPropertiesOutput[0] = massPropertiesOutput;
			int[] surfSliceIdx = new int[input.surfaces.Length];
			int[] regionIndices = new int[input.surfaces.Length];
			Array.Fill(regionIndices, -1);
			int num24 = 0;
			for (int num25 = 0; num25 < slices.Length; num25++)
			{
				WingSlice slice = slices[num25];
				bool flag = num25 == slices.Length - 1;
				colliderSlices[0].Clear();
				NativeAirfoil nativeAirfoil3 = nativeAirfoil2;
				NativeAirfoil nativeAirfoil4 = nativeAirfoil;
				nativeAirfoil = nativeAirfoil3;
				nativeAirfoil2 = nativeAirfoil4;
				num18 = num17;
				num17 = slice.SpanPosition;
				nativeAirfoil.EnsureCapacity(slice.ChordSamples, Allocator.TempJob);
				slice.Airfoil.GenerateCrossSection(ref nativeAirfoil, slice.ChordSamples);
				if (num25 != 0)
				{
					for (; num24 < nativeList.Length && nativeList[num24].SpanPosition < slice.SpanPosition; num24++)
					{
						SurfaceRegion.Slice ss = nativeList[num24];
						ControlSurface cs = input.surfaces[ss.ControlSurface];
						b[0].SpanPosition = ss.SpanPosition;
						b[0].Position = ss.Position;
						b[0].Up = ss.Up;
						b[0].Scale = ss.Scale;
						b[0].IsSmoothed = true;
						float t = math.unlerp(num18, num17, ss.SpanPosition);
						airfoil.InterpolateFrom(nativeAirfoil2, nativeAirfoil, t, Allocator.TempJob);
						airfoil.RenderTo(ref b[0]);
						switch (ss.Type)
						{
						case SurfaceRegion.SliceType.Slice:
							ApplyCSOnly(b, ss.RegionIndex, airfoil);
							JoinSurfaceSections(a2, b);
							input.DebugCollector?.AddRegionSlice(b, cs, ss, WingDebugInfo.RegionSliceDebugInfo.Part.Single);
							SwapSurfaceSections(b, a2);
							ClearCrossSections(b);
							break;
						case SurfaceRegion.SliceType.StartRegion:
							CloneSection(in b[0], ref b2[0]);
							ApplyCSOnly(b, -1, airfoil);
							JoinSurfaceSections(a2, b);
							TransferMeshIDs(b, b2);
							ApplyCSOnly(b2, ss.RegionIndex, airfoil);
							SealSurfaceSections(b, b2);
							input.DebugCollector?.AddRegionSlice(b, cs, ss, WingDebugInfo.RegionSliceDebugInfo.Part.PreChange);
							input.DebugCollector?.AddRegionSlice(b2, cs, ss, WingDebugInfo.RegionSliceDebugInfo.Part.PostChange);
							SwapSurfaceSections(b2, a2);
							ClearCrossSections(b2);
							ClearCrossSections(b);
							if (regionIndices[ss.ControlSurface] != -1)
							{
								Debug.LogWarning($"Overlapping regions in surface {ss.ControlSurface} ({cs})", input.parent);
							}
							regionIndices[ss.ControlSurface] = ss.RegionIndex;
							break;
						case SurfaceRegion.SliceType.EndRegion:
							SetSharedMeshIDs(b);
							CloneSection(in b[0], ref b2[0]);
							ApplyCSOnly(b, ss.RegionIndex, airfoil);
							JoinSurfaceSections(a2, b);
							TransferMeshIDs(b, b2);
							ApplyCSOnly(b2, -1, airfoil);
							input.DebugCollector?.AddRegionSlice(b, cs, ss, WingDebugInfo.RegionSliceDebugInfo.Part.PreChange);
							input.DebugCollector?.AddRegionSlice(b2, cs, ss, WingDebugInfo.RegionSliceDebugInfo.Part.PostChange);
							SealSurfaceSections(b, b2);
							SwapSurfaceSections(b2, a2);
							ClearCrossSections(b2);
							ClearCrossSections(b);
							regionIndices[ss.ControlSurface] = -1;
							break;
						}
						void ApplyCSOnly(CrossSection[] sections, int region, NativeAirfoil airfoil2)
						{
							for (int num42 = cs.MeshIndexOffset; num42 < cs.MeshIndexOffset + cs.MeshCount; num42++)
							{
								sections[num42].CopySettingsFrom(sections[0]);
							}
							cs.ApplyToCrossSections(new ControlSurfaceSectionInput(sections[0], new Span<CrossSection>(sections).Slice(cs.MeshIndexOffset, cs.MeshCount), airfoil2, meshes, surfSliceIdx[ss.ControlSurface]++, region));
						}
						void JoinSurfaceSections(CrossSection[] root, CrossSection[] tip)
						{
							for (int num42 = cs.MeshIndexOffset; num42 < cs.MeshIndexOffset + cs.MeshCount; num42++)
							{
								if (root[num42].HasPoints && tip[num42].HasPoints)
								{
									CalculateSectionMassAndFuel(in root[num42], in tip[num42], ref output.MassPropertiesOutput[num42]);
									SectionJoiner.Join(root[num42], tip[num42], meshes[num42]);
								}
							}
						}
						void SealSurfaceSections(CrossSection[] root, CrossSection[] tip)
						{
							for (int num42 = cs.MeshIndexOffset; num42 < cs.MeshIndexOffset + cs.MeshCount; num42++)
							{
								if (root[num42].HasPoints && tip[num42].HasPoints)
								{
									SealCrossSections(root[num42], tip[num42], meshes[num42]);
								}
							}
						}
						void SwapSurfaceSections(CrossSection[] array6, CrossSection[] array7)
						{
							for (int num42 = cs.MeshIndexOffset; num42 < cs.MeshIndexOffset + cs.MeshCount; num42++)
							{
								Utils.Swap(ref array6[num42], ref array7[num42]);
							}
						}
					}
				}
				nativeAirfoil.RenderTo(ref b[0]);
				slice.Airfoil.GenerateCollider(colliderSlices[0], slice.ColliderSamples, slice.Position, slice.Up, slice.Scale);
				b[0].SpanPosition = slice.SpanPosition;
				b[0].Position = slice.Position;
				b[0].Up = slice.Up;
				b[0].Scale = slice.Scale;
				b[0].IsSmoothed = slice.SmoothJoin;
				if (num25 == 0)
				{
					ApplyCSMask(slice.ControlSurfaceMask, input.surfaces, b);
					FillCrossSections(b, reverse: true, meshes);
					input.DebugCollector?.AddFullSlice(slice, WingDebugInfo.SliceDebugInfo.SliceType.Normal, b);
					Utils.Swap(ref b, ref a2);
					ClearCrossSections(b);
					ApplyCSColliders(slice.ControlSurfaceMask);
					ApplyMainCollider();
				}
				else
				{
					if (flag)
					{
						ApplyCSMask(num16, input.surfaces, b);
						if (num25 != 0)
						{
							JoinCrossSectionArrays(a2, b, meshes, output.MassPropertiesOutput);
						}
						if (input.WingtipStyle == null)
						{
							FillCrossSections(b, reverse: false, meshes);
						}
						input.DebugCollector?.AddFullSlice(slice, WingDebugInfo.SliceDebugInfo.SliceType.Normal, b);
						ApplyCSColliders(num16);
						ApplyMainCollider();
						break;
					}
					uint mask = slice.ControlSurfaceMask & num16;
					ApplyCSMask(mask, input.surfaces, b);
					ApplyCSColliders(mask);
					SetSharedMeshIDs(b);
					if (num16 != slice.ControlSurfaceMask)
					{
						CloneSections(b, b2);
						a.Length = colliderSlices[0].Length;
						a.CopyFrom(in colliderSlices[0]);
						uint num26 = num16 & ~slice.ControlSurfaceMask;
						uint num27 = slice.ControlSurfaceMask & ~num16;
						ApplyCSMask(num26, input.surfaces, b);
						JoinCrossSectionArrays(a2, b, meshes, output.MassPropertiesOutput);
						input.DebugCollector?.AddFullSlice(slice, WingDebugInfo.SliceDebugInfo.SliceType.PreCS, b);
						TransferMeshIDs(b, b2);
						ApplyCSMask(num27, input.surfaces, b2);
						input.DebugCollector?.AddFullSlice(slice, WingDebugInfo.SliceDebugInfo.SliceType.PostCS, b2);
						SealCrossSections(b[0], b2[0], meshes[0]);
						bool num28 = ApplyCSColliders(num26);
						ApplyMainCollider();
						Utils.Swap(ref a, ref colliderSlices[0]);
						a.Clear();
						if (num28 | ApplyCSColliders(num27))
						{
							ApplyMainCollider();
						}
						else
						{
							colliderSlices[0].Clear();
						}
						uint num29 = num27;
						uint num30 = num26;
						for (int num31 = 0; num31 < 32; num31++)
						{
							uint num32 = (uint)(1 << num31);
							if ((num32 & num29) != 0)
							{
								FillCSCrossSections(input.surfaces[num31], b2, reverse: true, meshes);
							}
							else if ((num32 & num30) != 0)
							{
								FillCSCrossSections(input.surfaces[num31], b, reverse: false, meshes);
							}
							else if (num32 >= num29 && num32 >= num30)
							{
								break;
							}
						}
						Utils.Swap(ref a2, ref b2);
						ClearCrossSections(b);
						ClearCrossSections(b2);
					}
					else
					{
						JoinCrossSectionArrays(a2, b, meshes, output.MassPropertiesOutput);
						Utils.Swap(ref a2, ref b);
						ClearCrossSections(b);
						ApplyMainCollider();
					}
				}
				num16 = slice.ControlSurfaceMask;
				bool ApplyCSColliders(uint mask2)
				{
					return GenerateSurfaceColliders(input.surfaces, colliderGenerators, colliderSlices, mask2, surfSliceIdx, slice.SpanPosition, slice);
				}
				void ApplyMainCollider()
				{
					colliderGenerators[0]?.AddPoints(colliderSlices[0].AsArray(), slice);
					colliderSlices[0].Clear();
				}
			}
			if (input.WingtipStyle != null)
			{
				_ = ref a2[0];
				uint controlSurfaceMask = input.WingtipStyle.GetControlSurfaceMask(num16);
				controlSurfaceMask &= num16;
				CrossSection[] array3;
				if (controlSurfaceMask == num16)
				{
					array3 = b;
				}
				else
				{
					array3 = a2;
					nativeAirfoil.RenderTo(ref array3[0]);
				}
				WingSlice wingSlice3 = slices[^1];
				WingSlice wingSlice4 = slices[^2];
				float num33 = 1f / (wingSlice3.SpanPosition - wingSlice4.SpanPosition);
				input.WingtipStyle.GeometryPass(new WingTipStyle.InputData
				{
					CenterGradient = (wingSlice3.Position.z - wingSlice4.Position.z) * num33,
					ScaleGradient = (wingSlice3.Scale - wingSlice4.Scale) * num33,
					ControlSurfaceMask = controlSurfaceMask
				}, array3, meshes, input.surfaces);
			}
			FreePointLists(b);
			FreePointLists(b2);
			FreePointLists(a2);
			nativeList.Dispose();
			a.Dispose();
			nativeAirfoil.Dispose();
			nativeAirfoil2.Dispose();
			airfoil.Dispose();
			for (int num34 = 0; num34 < colliderGenerators.Length; num34++)
			{
				colliderGenerators[num34]?.StartBuild(meshes[num34].InverseTransform, input.flipped);
				Extensions.DisposeIfCreated(ref colliderSlices[num34]);
			}
			int num35 = (input.HideMainMesh ? 1 : 0);
			for (int num36 = 0; num36 < input.surfaces.Length; num36++)
			{
				if (csValid[num36])
				{
					input.surfaces[num36].PostPass(meshes);
					input.surfaces[num36].FreeNativeData();
				}
			}
			for (int num37 = 0; num37 < output.MassPropertiesOutput.Length; num37++)
			{
				MassPropertiesOutput massPropertiesOutput2 = output.MassPropertiesOutput[num37];
				massPropertiesOutput2.CentreOfMass /= massPropertiesOutput2.Mass;
				massPropertiesOutput2.FuelVolumeCentroid /= massPropertiesOutput2.FuelVolume;
				if (input.flipped)
				{
					massPropertiesOutput2.FuelVolumeCentroid.y = 0f - massPropertiesOutput2.FuelVolumeCentroid.y;
					massPropertiesOutput2.CentreOfMass.y -= massPropertiesOutput2.CentreOfMass.y;
				}
				output.MassPropertiesOutput[num37] = massPropertiesOutput2;
			}
			MeshBuilder.ApplyMeshData(meshes, debugOut: false, input.flipped);
			output.ControlSurfaceRootPoses = new RigidTransform[input.surfaces.Length];
			for (int num38 = 0; num38 < input.surfaces.Length; num38++)
			{
				ControlSurface controlSurface7 = input.surfaces[num38];
				if (controlSurface7.MeshCount < 1 || !csValid[num38])
				{
					output.ControlSurfaceRootPoses[num38] = RigidTransform.identity;
					continue;
				}
				Transform transform = null;
				RigidTransform rigidTransform = RigidTransform.identity;
				if (input.surfaceParentTransforms != null)
				{
					transform = input.surfaceParentTransforms[num38];
				}
				else
				{
					output.ControlSurfaceRootPoses[num38] = rigidTransform;
				}
				if (transform == null)
				{
					transform = input.parent;
				}
				for (int num39 = 0; num39 < controlSurface7.MeshCount; num39++)
				{
					MeshBuilder meshBuilder = meshes[num39 + controlSurface7.MeshIndexOffset];
					RigidTransform rt;
					if (num39 == 0 && input.surfaceParentTransforms != null)
					{
						rigidTransform = meshBuilder.InverseTransform;
						rt = RigidTransform.identity;
						output.ControlSurfaceRootPoses[num38] = ApplyFlip(meshBuilder.Transform);
					}
					else
					{
						rt = math.mul(rigidTransform, meshBuilder.Transform);
					}
					int? parent = controlSurface7.MeshDefinitions[num39].Parent;
					if (parent.HasValue)
					{
						MeshBuilder meshBuilder2 = meshes[parent.Value + controlSurface7.MeshIndexOffset];
						meshBuilder.Object.transform.SetParent(meshBuilder2.Object.transform);
						RigidTransform rt2 = math.mul(meshBuilder2.InverseTransform, meshBuilder.Transform);
						meshBuilder.Object.transform.SetLocalRigidTransform(ApplyFlip(rt2));
					}
					else
					{
						meshBuilder.Object.transform.SetParent(transform);
						meshBuilder.Object.transform.SetLocalRigidTransform(ApplyFlip(rt));
					}
				}
			}
			List<ColliderInfo>[] array4 = new List<ColliderInfo>[colliderGenerators.Length];
			for (int num40 = 0; num40 < colliderGenerators.Length; num40++)
			{
				colliderGenerators[num40]?.CompleteBuild();
				array4[num40] = colliderGenerators[num40]?.Colliders;
			}
			GameObject[] array5 = new GameObject[meshes.Length];
			for (int num41 = num35; num41 < array5.Length; num41++)
			{
				array5[num41] = meshes[num41].Object;
			}
			output.MeshObjects = array5;
			output.Colliders = array4;
			return output;
			void ApplyCSMask(uint num44, ControlSurface[] surfaces, CrossSection[] sections)
			{
				Span<CrossSection> span2 = new Span<CrossSection>(sections);
				for (int num42 = 0; num42 < 32; num42++)
				{
					uint num43 = (uint)(1 << num42);
					if (num43 > num44)
					{
						break;
					}
					if ((num44 & num43) != 0 && csValid[num42])
					{
						ControlSurface controlSurface8 = surfaces[num42];
						for (int num45 = 0; num45 < controlSurface8.MeshCount; num45++)
						{
							int num46 = controlSurface8.MeshIndexOffset + num45;
							sections[num46].CopySettingsFrom(sections[0]);
							if (colliderGenerators[num46] != null)
							{
								colliderSlices[num46].Clear();
							}
						}
						controlSurface8.ApplyToCrossSections(new ControlSurfaceSectionInput(sections[0], span2.Slice(controlSurface8.MeshIndexOffset, controlSurface8.MeshCount), nativeAirfoil, meshes, surfSliceIdx[num42]++, regionIndices[num42]));
					}
				}
			}
			RigidTransform ApplyFlip(RigidTransform rigidTransform2)
			{
				if (input.flipped)
				{
					return MathUtils.GetTransformInMirroredYSpace(rigidTransform2);
				}
				return rigidTransform2;
			}
		}

		private static void CalculateSectionMassAndFuel(in CrossSection root, in CrossSection tip, ref MassPropertiesOutput massProperties)
		{
			float3 x = tip.Position - root.Position;
			x.z = 0f;
			float num = math.length(x);
			if (!(num <= 0f))
			{
				float4 float5;
				float4 float6;
				using (NativeArray<float4> res = new NativeArray<float4>(1, Allocator.TempJob))
				{
					new CalculateSliceAreaJob
					{
						points = root.Points.AsArray(),
						res = res,
						Scale = root.Scale
					}.Run();
					float5 = res[0];
					new CalculateSliceAreaJob
					{
						points = tip.Points.AsArray(),
						res = res,
						Scale = tip.Scale
					}.Run();
					float6 = res[0];
				}
				float3 float7 = root.SliceToMeshPos(float5.xy);
				float3 float8 = tip.SliceToMeshPos(float6.xy);
				float num2 = 0.5f * num * (float5.z + float6.z);
				float3 float9 = 0.5f * num * (float7 * float5.z + float8 * float6.z);
				float centreT;
				float num3 = CalculateSkinMassOfSection(root.Scale, tip.Scale, float5.w, float6.w, num, out centreT);
				float3 float10 = math.lerp(root.Position, tip.Position, centreT);
				massProperties.CentreOfMass += num3 * float10;
				massProperties.Mass += num3;
				massProperties.FuelVolume += 0.75f * num2;
				massProperties.FuelVolumeCentroid += 0.75f * float9;
			}
		}

		private static void FindOrCreateRenderers(Transform parent, int count, int meshBaseIndex, Span<MeshBuilder> builders, in WingBuilderInput input, bool destroyExcess)
		{
			FindOrCreateRenderers(parent, count, meshBaseIndex, builders, parent.GetComponentsInDirectChildren<MeshFilter>(), in input, destroyExcess);
		}

		private static void FindOrCreateRenderers(Transform parent, int count, int meshBaseIndex, Span<MeshBuilder> builders, Span<MeshFilter> usableExistingFilters, in WingBuilderInput input, bool destroyExcess)
		{
			int i = 0;
			Span<MeshFilter> span = usableExistingFilters;
			for (int j = 0; j < span.Length; j++)
			{
				MeshFilter meshFilter = span[j];
				if (i < count)
				{
					builders[i] = new MeshBuilder(meshFilter);
					i++;
				}
				else if (destroyExcess)
				{
					input.onDestroyRenderer?.Invoke(meshFilter.GetComponent<MeshRenderer>());
					DestroyMesh(meshFilter);
				}
			}
			for (; i < count; i++)
			{
				int num = meshBaseIndex + i;
				GameObject gameObject = new GameObject($"Mesh-{num}");
				gameObject.transform.SetParent(parent, worldPositionStays: false);
				MeshFilter meshFilter2 = gameObject.AddComponent<MeshFilter>();
				MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
				meshRenderer.shadowCastingMode = ShadowCastingMode.On;
				input.onCreateRenderer?.Invoke(meshRenderer, num);
				Mesh mesh = (meshFilter2.sharedMesh = new Mesh());
				mesh.name = $"WingMesh Mesh-{num}";
				builders[i] = new MeshBuilder(meshFilter2);
			}
		}

		private static void DestroyMesh(MeshFilter filter)
		{
			UnityEngine.Object.Destroy(filter.sharedMesh);
			UnityEngine.Object.Destroy(filter.gameObject);
		}

		private static List<WingSlice> InterpolateUserInput(InputWingSlice[] inputSlices, ControlSurface[] surfaces)
		{
			if (inputSlices.Length < 2)
			{
				throw new ArgumentException("Wing must have at least 2 slices");
			}
			int num = inputSlices.Length - 1;
			if (inputSlices[0].Airfoil == null)
			{
				throw new ArgumentException("Wing must have defined airfoil at root");
			}
			string name = null;
			for (int num2 = num; num2 >= 0; num2--)
			{
				if (inputSlices[num2].Airfoil != null)
				{
					name = inputSlices[num2].Airfoil;
					break;
				}
			}
			List<WingSlice> result = new List<WingSlice>();
			inputSlices[0].UseOffset = true;
			inputSlices[0].UseScale = true;
			inputSlices[num].UseOffset = true;
			inputSlices[num].UseScale = true;
			int num3 = 0;
			float position = inputSlices[0].Position;
			float num4 = inputSlices[0].Offset;
			int num5 = FindNextOffset(0, inputSlices);
			float position2 = inputSlices[num5].Position;
			float offset = inputSlices[num5].Offset;
			int num6 = 0;
			float2 float5 = math.float2(inputSlices[0].Position, inputSlices[0].Scale);
			int num7 = FindNextScale(0, inputSlices);
			float2 float6 = math.float2(inputSlices[num7].Position, inputSlices[num7].Scale);
			float num8 = 0f;
			float3 float7 = 0f;
			float num9 = 0f;
			float3 float8 = math.up();
			float3 float9 = math.right();
			for (int i = 0; i < inputSlices.Length; i++)
			{
				WingSlice wingSlice = new WingSlice();
				InputWingSlice inputWingSlice = inputSlices[i];
				wingSlice.SpanPosition = inputWingSlice.Position;
				wingSlice.SmoothJoin = inputWingSlice.IsSmoothJoin;
				wingSlice.ChordSamples = inputWingSlice.ChordSamples;
				wingSlice.ColliderSamples = inputWingSlice.ColliderSamples;
				wingSlice.SupportsControlSurfaces = true;
				wingSlice.Position = float7 + float9 * (wingSlice.SpanPosition - num8);
				wingSlice.SpanVec = float9;
				if (!string.IsNullOrEmpty(inputWingSlice.Airfoil))
				{
					wingSlice.Airfoil = AirfoilRegistry.ParseAirfoil(inputWingSlice.Airfoil);
				}
				else if (i == num)
				{
					wingSlice.Airfoil = AirfoilRegistry.ParseAirfoil(name);
				}
				if (i == num3)
				{
					wingSlice.Position.z = num4;
				}
				else if (i == num5)
				{
					wingSlice.Position.z = offset;
					if (i != inputSlices.Length - 1)
					{
						num4 = offset;
						num3 = num5;
						num5 = FindNextOffset(i, inputSlices);
						position2 = inputSlices[num5].Position;
						offset = inputSlices[num5].Offset;
					}
				}
				else
				{
					wingSlice.Position.z = math.lerp(num4, offset, math.unlerp(position, position2, inputWingSlice.Position));
				}
				if (i == num6)
				{
					wingSlice.Scale = float5.y;
				}
				else if (i == num7)
				{
					wingSlice.Scale = float6.y;
					if (i != inputSlices.Length - 1)
					{
						float5 = float6;
						num6 = num7;
						num7 = FindNextScale(i, inputSlices);
						float6 = math.float2(inputSlices[num7].Position, inputSlices[num7].Scale);
					}
				}
				else
				{
					wingSlice.Scale = math.lerp(float5.y, float6.y, math.unlerp(float5.x, float6.x, inputWingSlice.Position));
				}
				if (inputWingSlice.Bend != 0f)
				{
					float num10 = 0.3f * wingSlice.Scale * math.sign(inputWingSlice.Bend) * inputWingSlice.BendRadiusMultiplier;
					int num11 = (int)math.ceil(math.abs(inputWingSlice.Bend) / 5f);
					float num12 = inputWingSlice.Bend / (float)num11;
					math.sincos(math.radians(num12), out var s, out var c);
					float num13 = num10 * (1f - c);
					float num14 = num10 * s;
					float num15 = num10 * math.radians(num12);
					float num16 = 0f;
					float num17 = 0f;
					if (i + 1 < inputSlices.Length)
					{
						InputWingSlice inputWingSlice2 = inputSlices[i + 1];
						float num18 = (inputWingSlice2.UseScale ? inputWingSlice2.Scale : math.lerp(float5.y, float6.y, math.unlerp(float5.x, float6.x, inputWingSlice2.Position)));
						float num19 = (inputWingSlice2.UseOffset ? inputWingSlice2.Offset : math.lerp(num4, offset, math.unlerp(position, position2, inputWingSlice2.Position)));
						float num20 = inputWingSlice2.Position - inputWingSlice.Position + num10 * math.radians(inputWingSlice.Bend);
						num16 = (num18 - wingSlice.Scale) / num20;
						num17 = (num19 - wingSlice.Position.z) / num20;
					}
					for (int j = 0; j < num11; j++)
					{
						WingSlice wingSlice2 = new WingSlice(wingSlice)
						{
							SmoothJoin = true,
							ControlSurfaceMask = 0u,
							Up = float8,
							SpanVec = float9,
							SupportsControlSurfaces = false
						};
						result.Add(wingSlice2);
						if (j == 0)
						{
							inputWingSlice.LastDerivedSliceRoot = wingSlice2;
						}
						wingSlice.Position += num13 * float8 + num14 * float9;
						wingSlice.Scale += num16 * num15;
						wingSlice.Position.z += num17 * num15;
						math.sincos(math.radians(num9 + num12 * (float)(j + 1)), out var s2, out var c2);
						float9 = math.float3(c2, s2, 0f);
						float8 = math.float3(0f - s2, c2, 0f);
					}
					num9 += inputWingSlice.Bend;
				}
				else
				{
					inputWingSlice.LastDerivedSliceRoot = wingSlice;
				}
				wingSlice.Up = float8;
				wingSlice.SpanVec = float9;
				inputWingSlice.LastDerivedSliceTip = wingSlice;
				result.Add(wingSlice);
				float7 = wingSlice.Position;
				num8 = wingSlice.SpanPosition;
			}
			if (surfaces.Length >= 32)
			{
				throw new ArgumentException("Too many control surfaces. Limit is 32 - refactor CS mask to use ulong to raise this to 64.");
			}
			for (int k = 0; k < surfaces.Length; k++)
			{
				ControlSurface controlSurface = surfaces[k];
				controlSurface.SurfaceId = (byte)k;
				int item = GetSliceAtPosition(controlSurface.Range.x).Index;
				int item2 = GetSliceAtPosition(controlSurface.Range.y).Index;
				for (int l = item; l < item2; l++)
				{
					result[l].AddSurface(controlSurface);
				}
				controlSurface.SectionOffset = -1;
				controlSurface.SectionCount = 1;
			}
			uint num21 = 0u;
			uint num22 = 0u;
			foreach (WingSlice item3 in result)
			{
				if (!item3.SupportsControlSurfaces)
				{
					item3.ControlSurfaceMask = 0u;
				}
				item3.ControlSurfaceMask &= ~num21;
				num21 |= num22 & ~item3.ControlSurfaceMask;
				num22 = item3.ControlSurfaceMask;
			}
			for (short num23 = 0; num23 < result.Count; num23++)
			{
				uint controlSurfaceMask = result[num23].ControlSurfaceMask;
				if (controlSurfaceMask != 0)
				{
					for (int m = 0; m < surfaces.Length; m++)
					{
						uint num24 = (uint)(1 << m);
						if (num24 > controlSurfaceMask)
						{
							break;
						}
						if ((num24 & controlSurfaceMask) != 0)
						{
							ControlSurface controlSurface2 = surfaces[m];
							if (controlSurface2.SectionOffset == -1)
							{
								controlSurface2.SectionOffset = num23;
							}
							controlSurface2.SectionCount++;
						}
					}
				}
			}
			IAirfoil airfoil = result[0].Airfoil;
			float spanPosition = result[0].SpanPosition;
			IAirfoil airfoil2 = airfoil;
			float num25 = spanPosition;
			if (airfoil == null)
			{
				throw new ArgumentException("The first wing slice must have a defined airfoil");
			}
			for (int n = 0; n < result.Count; n++)
			{
				WingSlice wingSlice3 = result[n];
				if (wingSlice3.Airfoil == airfoil)
				{
					continue;
				}
				if (wingSlice3.Airfoil != null)
				{
					airfoil = wingSlice3.Airfoil;
					spanPosition = wingSlice3.SpanPosition;
					continue;
				}
				if (airfoil2 == null)
				{
					wingSlice3.Airfoil = airfoil;
					continue;
				}
				float spanPosition2 = wingSlice3.SpanPosition;
				if (spanPosition2 >= num25)
				{
					int num26 = FindNextAirfoil(n, result);
					if (num26 == -1)
					{
						airfoil2 = null;
						wingSlice3.Airfoil = airfoil;
						continue;
					}
					airfoil2 = result[num26].Airfoil;
					num25 = result[num26].SpanPosition;
				}
				float proportion = math.unlerp(spanPosition, num25, spanPosition2);
				wingSlice3.Airfoil = new InterpolatedAirfoil(airfoil, airfoil2, proportion);
			}
			return result;
			(WingSlice Slice, int Index) GetSliceAtPosition(float pos)
			{
				if (result.Count < 2)
				{
					throw new ArgumentException("Cannot interpolate a slice when there is less than 2 slices.");
				}
				WingSlice wingSlice4 = null;
				WingSlice wingSlice5 = null;
				int num27 = 0;
				for (int num28 = 0; num28 < result.Count; num28++)
				{
					WingSlice wingSlice6 = result[num28];
					if (Mathf.Approximately(wingSlice6.SpanPosition, pos))
					{
						return (Slice: wingSlice6, Index: num28);
					}
					if (wingSlice6.SpanPosition <= pos)
					{
						wingSlice4 = wingSlice6;
					}
					if (wingSlice6.SpanPosition >= pos)
					{
						wingSlice5 = wingSlice6;
						num27 = num28;
						break;
					}
				}
				if (wingSlice4 == null || wingSlice5 == null)
				{
					throw new ArgumentException("Attempted to create an interpolated slice out of current range");
				}
				if (wingSlice4 == wingSlice5)
				{
					return (Slice: wingSlice5, Index: num27);
				}
				float t = math.unlerp(wingSlice4.SpanPosition, wingSlice5.SpanPosition, pos);
				IAirfoil airfoil3 = ((wingSlice4.Airfoil != wingSlice5.Airfoil) ? null : wingSlice4.Airfoil);
				if (math.any(wingSlice4.Up != wingSlice5.Up))
				{
					Debug.LogWarning($"Interpolated slice has varying up vector: undefined behaviour (slice at {pos}, vectors: [{wingSlice4.Up}, {wingSlice5.Up}])");
				}
				WingSlice wingSlice7 = new WingSlice
				{
					Airfoil = airfoil3,
					SpanPosition = pos,
					Position = math.lerp(wingSlice4.Position, wingSlice5.Position, t),
					Up = wingSlice4.Up,
					SpanVec = wingSlice4.SpanVec,
					Scale = math.lerp(wingSlice4.Scale, wingSlice5.Scale, t),
					ControlSurfaceMask = wingSlice4.ControlSurfaceMask,
					SupportsControlSurfaces = wingSlice4.SupportsControlSurfaces,
					SmoothJoin = true,
					ChordSamples = Mathf.RoundToInt(Mathf.Lerp(wingSlice4.ChordSamples, wingSlice5.ChordSamples, t)),
					ColliderSamples = Mathf.RoundToInt(Mathf.Lerp(wingSlice4.ColliderSamples, wingSlice5.ColliderSamples, t))
				};
				result.Insert(num27, wingSlice7);
				return (Slice: wingSlice7, Index: num27);
			}
		}

		private static void AllocatePointLists(CrossSection[] sections, Allocator allocator)
		{
			for (int i = 0; i < sections.Length; i++)
			{
				sections[i].Points = new NativeList<Point>((i == 0) ? 32 : 8, allocator);
			}
		}

		private static void FreePointLists(CrossSection[] sections)
		{
			for (int i = 0; i < sections.Length; i++)
			{
				if (sections[i].Points.IsCreated)
				{
					sections[i].Points.Dispose();
				}
				sections[i].Points = default(NativeList<Point>);
			}
		}

		private static void ClearCrossSections(CrossSection[] sections)
		{
			for (int i = 0; i < sections.Length; i++)
			{
				sections[i].Clear();
			}
		}

		private static void SetSharedMeshIDs(CrossSection[] sections)
		{
			for (int i = 0; i < sections.Length; i++)
			{
				CrossSection crossSection = sections[i];
				NativeList<Point> points = crossSection.Points;
				if (points.Length != 0)
				{
					IJobForExtensions.Run(new SetMeshIDsJob
					{
						points = points.AsArray()
					}, points.Length);
					crossSection.MaxSharedPointId = points.Length - 1;
					sections[i] = crossSection;
				}
			}
		}

		private static void TransferMeshIDs(CrossSection[] from, CrossSection[] to)
		{
			NativeArray<int> tempBuffer = default(NativeArray<int>);
			try
			{
				for (int i = 0; i < from.Length; i++)
				{
					CrossSection crossSection = from[i];
					CrossSection crossSection2 = to[i];
					if (math.min(crossSection.Points.Length, crossSection2.Points.Length) == 0)
					{
						continue;
					}
					if (!tempBuffer.IsCreated || tempBuffer.Length < crossSection2.MaxSharedPointId + 1)
					{
						if (tempBuffer.IsCreated)
						{
							tempBuffer.Dispose();
						}
						tempBuffer = new NativeArray<int>(crossSection2.MaxSharedPointId + 1, Allocator.TempJob);
					}
					new TransferMeshIDsJob
					{
						TransferFrom = crossSection.Points.AsArray(),
						TransferTo = crossSection2.Points.AsArray(),
						TempBuffer = tempBuffer
					}.Run();
				}
			}
			finally
			{
				if (tempBuffer.IsCreated)
				{
					tempBuffer.Dispose();
				}
			}
		}

		private static void CloneSections(CrossSection[] from, CrossSection[] to)
		{
			int num = from.Length;
			if (num > to.Length)
			{
				num = to.Length;
			}
			for (int i = 0; i < num; i++)
			{
				CloneSection(in from[i], ref to[i]);
			}
		}

		private static void CloneSection(in CrossSection from, ref CrossSection to)
		{
			NativeList<Point> points = to.Points;
			points.Clear();
			points.CopyFrom(in from.Points);
			to = from;
			to.Points = points;
		}

		private static void FillCrossSection(CrossSection section, MeshBuilder mesh, bool reverse)
		{
			if (section.Points.Length != 0)
			{
				NativeList<Vertex> vertices = mesh.Vertices;
				int length = vertices.Length;
				vertices.EnsureFreeCapacity(section.Points.Length);
				for (int i = 0; i < section.Points.Length; i++)
				{
					vertices.Add(new Vertex(section.GetMeshPosition(section.Points[i])));
				}
				Triangulator.Triangulate(section.Points.AsArray(), mesh.Triangles, reverse, length);
			}
		}

		private static void FillCrossSections(CrossSection[] sections, bool reverse, MeshBuilder[] meshes)
		{
			for (int i = 0; i < sections.Length; i++)
			{
				if (meshes[i] != null)
				{
					FillCrossSection(sections[i], meshes[i], reverse);
				}
			}
		}

		private static void FillCSCrossSections(ControlSurface surface, CrossSection[] sections, bool reverse, MeshBuilder[] meshes)
		{
			if (surface.MeshIndexOffset >= 0)
			{
				for (int i = surface.MeshIndexOffset; i < surface.MeshIndexOffset + surface.MeshCount; i++)
				{
					FillCrossSection(sections[i], meshes[i], reverse);
				}
			}
		}

		private static bool GenerateSurfaceColliders(ControlSurface[] surfaces, ColliderGenerator[] generators, NativeList<float3>[] buffers, uint mask, int[] sliceIdx, float xPos, WingSlice slice)
		{
			bool flag = false;
			for (int i = 0; i < surfaces.Length; i++)
			{
				uint num = (uint)(1 << i);
				if (num > mask)
				{
					break;
				}
				if ((num & mask) == 0)
				{
					continue;
				}
				Span<NativeList<float3>> span = buffers;
				ControlSurface controlSurface = surfaces[i];
				if (controlSurface.MeshIndexOffset < 0)
				{
					continue;
				}
				flag |= controlSurface.ApplyToColliders(buffers[0], span.Slice(controlSurface.MeshIndexOffset, controlSurface.MeshCount), sliceIdx[i] - 1);
				int num2 = 0;
				int num3 = controlSurface.MeshIndexOffset;
				while (num2 < controlSurface.MeshCount)
				{
					if (generators[num3] != null && buffers[num3].Length != 0)
					{
						generators[num3].AddPoints(buffers[num3].AsArray(), slice);
						buffers[num3].Clear();
					}
					num2++;
					num3++;
				}
			}
			return flag;
		}

		private static void SealCrossSections(CrossSection sectionA, CrossSection sectionB, MeshBuilder mesh)
		{
			if (mesh != null)
			{
				SectionSealer.SealSections(sectionA, sectionB, mesh);
			}
		}

		private static int FindNextAirfoil(int current, List<WingSlice> inputSlices)
		{
			for (current++; current < inputSlices.Count; current++)
			{
				if (inputSlices[current].Airfoil != null)
				{
					return current;
				}
			}
			return -1;
		}

		private static int FindNextOffset(int current, InputWingSlice[] inputSlices)
		{
			current++;
			while (current < inputSlices.Length && !inputSlices[current].UseOffset)
			{
				current++;
			}
			return current;
		}

		private static int FindNextScale(int current, InputWingSlice[] inputSlices)
		{
			current++;
			while (current < inputSlices.Length && !inputSlices[current].UseScale)
			{
				current++;
			}
			return current;
		}

		private static float CalculateSkinMassOfSection(float rootSize, float tipSize, float rootPerimeter, float tipPerimeter, float length, out float centreT)
		{
			centreT = (rootPerimeter * rootSize + rootPerimeter * tipSize + tipPerimeter * rootSize + 3f * tipPerimeter * tipSize) / (4f * rootPerimeter * rootSize + 2f * rootPerimeter * tipSize + 2f * tipPerimeter * rootSize + 4f * tipPerimeter * tipSize);
			return 1f / 6f * (rootPerimeter * (2f * rootSize + tipSize) + tipPerimeter * (rootSize + 2f * tipSize)) * length * 0.9f;
		}

		private static float CalculateStructuralMassOfSection(float rootSize, float tipSize, float length, float areaTipwards, out float centreT)
		{
			float result = 7.5f * length * (length * rootSize / 6f + length * tipSize / 3f + areaTipwards);
			centreT = (length * (rootSize + 3f * tipSize) + 12f * areaTipwards) / (4f * (length * (rootSize + 2f * tipSize) + 6f * areaTipwards));
			return result;
		}

		private static void JoinCrossSectionArrays(CrossSection[] root, CrossSection[] tip, MeshBuilder[] meshes, MassPropertiesOutput[] massProperties)
		{
			if (root.Length != meshes.Length || tip.Length != meshes.Length)
			{
				Debug.LogError("JoinCrossSectionArrays: wrong array length");
				return;
			}
			for (int i = 0; i < root.Length; i++)
			{
				if (meshes[i] != null && root[i].HasPoints && tip[i].HasPoints)
				{
					CalculateSectionMassAndFuel(in root[i], in tip[i], ref massProperties[i]);
					SectionJoiner.Join(root[i], tip[i], meshes[i]);
				}
			}
		}
	}
}
