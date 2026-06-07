using System;
using System.Xml.Linq;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public class RoundedTip : WingTipStyle
	{
		[BurstCompile]
		private struct GetMaxInsetJob : IJob
		{
			public CrossSection section;

			public NativeArray<float> maxInset;

			public void Execute()
			{
				NativeArray<float2> nativeArray = new NativeArray<float2>(section.Points.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					nativeArray[i] = section.Points[i].Position;
				}
				float y = SkeletalInsetter.EstimateMaxInset(nativeArray);
				nativeArray.Dispose();
				maxInset[0] = math.max(maxInset[0], y);
			}
		}

		[BurstCompile]
		private struct GeometryJob : IJob
		{
			private struct RoundInsetProvider : SkeletalInsetter.IProfileProvider
			{
				public float4x3 BaseTransform;

				public float LocalScaleGradient;

				public float LocalOffsetGradient;

				public float MaxInset;

				public float SectionScale;

				public float3 SectionUp;

				public float ExtensionScale;

				public readonly float4x3 GetTransform(float inset)
				{
					float num = MaxInset - inset;
					float num2 = math.sqrt(MaxInset * MaxInset - num * num);
					if (math.isnan(num2))
					{
						num2 = MaxInset;
					}
					num2 *= ExtensionScale;
					float x = LocalOffsetGradient * num2;
					float num3 = 1f + LocalScaleGradient * num2;
					float4x3 result = math.mul(BaseTransform, math.float3x3(math.float3(num3, 0f, 0f), math.float3(0f, num3, 0f), math.float3(x, 0f, 1f)));
					result.c2.xyz += num2 * SectionScale * math.cross(SectionUp, math.forward());
					return result;
				}
			}

			[ReadOnly]
			public InputData inputData;

			public CrossSection section;

			public NativeMesh mesh;

			public float stretchFactor;

			public float maxInset;

			public void Execute()
			{
				NativeArray<float2> inPoints = new NativeArray<float2>(section.Points.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				NativeArray<int> meshVertices = new NativeArray<int>(section.Points.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				for (int i = 0; i < inPoints.Length; i++)
				{
					inPoints[i] = section.Points[i].Position;
					meshVertices[i] = section.Points[i].MeshIndexA;
				}
				NativeArray<float> insets = new NativeArray<float>(4, Allocator.Temp);
				float4x3 sliceTransform = section.SliceTransform;
				float localOffsetGradient = inputData.CenterGradient / section.Scale;
				float num = inputData.ScaleGradient / section.Scale;
				if (maxInset / (0f - num) > 0f)
				{
					float num2 = 2f * maxInset;
					float y = (0f - maxInset) / num2;
					num = math.max(num, y);
				}
				for (int j = 0; j < 4; j++)
				{
					float x = (float)(j + 1) * 0.25f * 0.5f * MathF.PI;
					insets[j] = (1f - math.cos(x)) * maxInset;
				}
				RoundInsetProvider profileProvider = new RoundInsetProvider
				{
					BaseTransform = sliceTransform,
					MaxInset = maxInset,
					LocalOffsetGradient = localOffsetGradient,
					LocalScaleGradient = num,
					SectionScale = section.Scale,
					SectionUp = section.Up,
					ExtensionScale = stretchFactor
				};
				SkeletalInsetter.MakeInsetMesh(inPoints, meshVertices, Allocator.Temp, mesh, insets, ref profileProvider);
				inPoints.Dispose();
				meshVertices.Dispose();
			}
		}

		public const string StyleName = "Rounded";

		private float _stretchFactor;

		public RoundedTip(XElement xml)
		{
			_stretchFactor = math.clamp(xml.GetFloatAttribute("stretch", 1f), 0f, 4f);
		}

		public override void SaveToXML(XElement xml)
		{
			xml.SetAttributeValue("style", "Rounded");
			if (_stretchFactor != 1f)
			{
				xml.SetAttributeValue("stretch", _stretchFactor);
			}
		}

		public override void GeometryPass(in InputData input, CrossSection[] sections, MeshBuilder[] meshBuilders, ControlSurface[] controlSurfaces)
		{
			NativeArray<float> maxInset = new NativeArray<float>(1, Allocator.TempJob);
			for (int i = 0; i < sections.Length; i++)
			{
				if (sections[i].HasPoints)
				{
					new GetMaxInsetJob
					{
						section = sections[i],
						maxInset = maxInset
					}.Run();
				}
			}
			float maxInset2 = maxInset[0];
			maxInset.Dispose();
			for (int j = 0; j < sections.Length; j++)
			{
				if (sections[j].HasPoints)
				{
					new GeometryJob
					{
						inputData = input,
						mesh = meshBuilders[j],
						section = sections[j],
						stretchFactor = _stretchFactor,
						maxInset = maxInset2
					}.Run();
				}
			}
		}

		public override uint GetControlSurfaceMask(uint lastSliceMask)
		{
			return lastSliceMask;
		}
	}
}
