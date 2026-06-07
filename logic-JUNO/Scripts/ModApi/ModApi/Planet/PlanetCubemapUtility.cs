using System;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ModApi.CelestialData;
using ModApi.Common;
using ModApi.Common.Extensions;
using ModApi.Common.Jobs;
using ModApi.Settings;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace ModApi.Planet
{
	public static class PlanetCubemapUtility
	{
		[BurstCompile(CompileSynchronously = true)]
		private struct ConvertColorTextureToByteArrayJob : IJob
		{
			[WriteOnly]
			public NativeArray<byte> Bytes;

			[ReadOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float4> ColorData;

			[ReadOnly]
			public float4 MaxColor;

			[ReadOnly]
			public int Size;

			public void Execute()
			{
				int num = 0;
				int num2 = 0;
				int length = Bytes.Length;
				while (num2 < length)
				{
					float4 float5 = math.clamp(math.round(ColorData[num++] / MaxColor * 255f), 0, 255);
					Bytes[num2++] = (byte)float5.x;
					Bytes[num2++] = (byte)float5.y;
					Bytes[num2++] = (byte)float5.z;
					Bytes[num2++] = (byte)float5.w;
				}
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct ConvertNormalTextureToByteArrayJob : IJob
		{
			[WriteOnly]
			public NativeArray<byte> Bytes;

			[ReadOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float4> Normals;

			[ReadOnly]
			public int Size;

			public void Execute()
			{
				float4 float5 = new float4(127f, 127f, 127f, 127f);
				int num = 0;
				int num2 = 0;
				int length = Bytes.Length;
				while (num2 < length)
				{
					float4 a = Normals[num++];
					float4 float6 = math.mad(a, float5, float5);
					Bytes[num2++] = (byte)float6.x;
					Bytes[num2++] = (byte)float6.y;
					Bytes[num2++] = (byte)float6.z;
					Bytes[num2++] = (byte)math.round(math.lerp(0f, 255f, a.w));
				}
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct DownsampleJob : IJob
		{
			[ReadOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float4> ColorData;

			[WriteOnly]
			public NativeArray<float4> DownsampledColorData;

			[ReadOnly]
			public int Size;

			public void Execute()
			{
				int num = Size * 2;
				int num2 = 0;
				int num3 = Size * Size;
				int num4 = 0;
				while (num4 < num3)
				{
					float4 float5 = ColorData[num2];
					float4 float6 = ColorData[num2 + num];
					num2++;
					float4 float7 = ColorData[num2];
					float4 float8 = ColorData[num2 + num];
					num2++;
					DownsampledColorData[num4] = (float5 + float6 + float7 + float8) * 0.25f;
					num4++;
					if (num4 % Size == 0)
					{
						num2 += num;
					}
				}
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct DownsampleNormalsJob : IJob
		{
			[WriteOnly]
			public NativeArray<float4> DownsampledNormals;

			[ReadOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float4> Normals;

			[ReadOnly]
			public int Size;

			public void Execute()
			{
				int num = Size * 2;
				int num2 = 0;
				int num3 = 0;
				int num4 = Size * Size;
				while (num3 < num4)
				{
					float4 obj = Normals[num2];
					float4 float5 = Normals[num2 + num];
					num2++;
					float4 float6 = Normals[num2];
					float4 float7 = Normals[num2 + num];
					num2++;
					float4 float8 = (obj + float5 + float6 + float7) * 0.25f;
					DownsampledNormals[num3] = new float4(math.normalize(float8.xyz), float8.w);
					num3++;
					if (num3 % Size == 0)
					{
						num2 += num;
					}
				}
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct GenerateNormalsJob : IJob
		{
			[ReadOnly]
			public double HeightMin;

			[ReadOnly]
			public double HeightRange;

			[ReadOnly]
			public NativeArray<double3> HeightSamples;

			[WriteOnly]
			public NativeArray<float4> Normals;

			[ReadOnly]
			public int Size;

			public void Execute()
			{
				int num = Size + 2;
				int num2 = 0;
				int num3 = 0;
				for (int i = -1; i <= Size; i++)
				{
					for (int j = -1; j <= Size; j++)
					{
						if (j >= 0 && j < Size && i >= 0 && i < Size)
						{
							double3 y = HeightSamples[num2 + 1] - HeightSamples[num2 - 1];
							double3 double5 = math.normalize(math.cross(HeightSamples[num2 + num] - HeightSamples[num2 - num], y));
							double num4 = (math.length(HeightSamples[num2]) - HeightMin) * HeightRange;
							Normals[num3++] = new float4((float)double5.x, (float)double5.y, (float)double5.z, (float)num4);
						}
						num2++;
					}
				}
			}
		}

		public static readonly string[] CubemapFileSuffixes;

		private const int EquirectangularMapDownsampleIterations = 2;

		private const int EquirectangularMapHeight = 1024;

		private const int EquirectangularMapWidth = 2048;

		private static readonly float[] ByteToFloat;

		private static readonly bool CompressCubemaps;

		static PlanetCubemapUtility()
		{
			CubemapFileSuffixes = new string[6] { "-xp.rgba32", "-xn.rgba32", "-yp.rgba32", "-yn.rgba32", "-zp.rgba32", "-zn.rgba32" };
			CompressCubemaps = true;
			ByteToFloat = new float[256];
			for (int i = 0; i < 256; i++)
			{
				ByteToFloat[i] = (float)i / 255f;
			}
		}

		public static void CreateCubemaps(IPlanetData planet)
		{
			TerrainQualitySettings.CubemapQualitySettings cubemapSettings = ModApi.Common.Game.Instance.Settings.Quality.Terrain.CubemapSettings;
			int maxSize = cubemapSettings.MaxSize;
			int generationDownsampleCount = cubemapSettings.GenerationDownsampleCount;
			CreateCubemaps(planet, maxSize, generationDownsampleCount, cubemapSettings.NormalMapsEnabled, cubemapSettings.NormalCliffColorEnabled);
		}

		public static void CreateCubemaps(IPlanetData planet, int size, int downsampleIterations, bool normalMaps, bool cliffs)
		{
			CreateCubemaps(planet, null, size, downsampleIterations, normalMaps, cliffs);
		}

		public static void CreateCubemaps(IPlanetData planet, TerrainGenerator terrainGenerator, int size, int downsampleIterations, bool normalMaps, bool cliffs)
		{
			Debug.Log($"Generating Cubemaps for '{planet.Name}' at size {size}. Thread Is Background: {Thread.CurrentThread.IsBackground}");
			bool flag = planet.TerrainData != null;
			IPlanetTerrainData planetTerrainData = (flag ? planet.TerrainData : planet.LoadTerrainData());
			planetTerrainData.Initialize();
			bool flag2 = terrainGenerator == null;
			if (terrainGenerator == null)
			{
				terrainGenerator = CreateTerrainGeneratorForCubemaps(planetTerrainData);
			}
			double radius = planet.Radius;
			bool hasWater = planet.HasWater;
			double num = ((planet.QuadSphereActivationDistance > 0.0) ? planet.QuadSphereActivationDistance : (radius * 2.0));
			double num2 = ((planet.QuadSphereTransitionDistance > 0.0) ? planet.QuadSphereTransitionDistance : (radius * 2.0));
			float waterSmoothness = (hasWater ? terrainGenerator.WaterMaterialModifier.GetSpecularity((float)(num + num2)) : 0f);
			bool flag3 = normalMaps && !planet.UniformHeight;
			Task[] array = new Task[6];
			NativeArray<double3>[] array2 = new NativeArray<double3>[6];
			MinMaxValue[][] array3 = new MinMaxValue[6][];
			NativeArray<float4>[] colorMaxValues = new NativeArray<float4>[6];
			NativeArray<float4>[][] colorData = new NativeArray<float4>[6][];
			for (int i = 0; i < 6; i++)
			{
				array2[i] = new NativeArray<double3>((size + 2) * (size + 2), Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				array3[i] = new MinMaxValue[size];
				colorMaxValues[i] = new NativeArray<float4>(size, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				colorData[i] = new NativeArray<float4>[downsampleIterations];
				for (int j = 0; j < downsampleIterations; j++)
				{
					int num3 = size / (int)System.Math.Pow(2.0, j);
					colorData[i][j] = new NativeArray<float4>(num3 * num3, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				}
			}
			for (int k = 0; k < 6; k++)
			{
				int face = k;
				NativeArray<double3> heights = array2[k];
				MinMaxValue[] heightRange = array3[k];
				if (cliffs)
				{
					array[k] = Task.Run(delegate
					{
						GenerateCubemapFaceHeightData(face, size, heights, heightRange, terrainGenerator, hasWater);
					});
					continue;
				}
				NativeArray<float4> colorMax = colorMaxValues[k];
				NativeArray<float4> colors = colorData[k][0];
				array[k] = Task.Run(delegate
				{
					GenerateCubemapFaceData(face, size, heights, heightRange, colors, colorMax, terrainGenerator, hasWater, waterSmoothness);
				});
			}
			Task.WaitAll(array);
			NativeArray<byte>[] byteArrays = new NativeArray<byte>[6];
			float4 maxColor = new float4(1f, 1f, 1f, 1f);
			if (!cliffs)
			{
				ProcessColors();
			}
			float x = array3.Min((MinMaxValue[] f) => f.Min((MinMaxValue v) => v.MinValue));
			float y = array3.Max((MinMaxValue[] f) => f.Max((MinMaxValue v) => v.MaxValue));
			Vector2 vector = new Vector2(x, y);
			if (flag3)
			{
				double heightMin = terrainGenerator.TerrainData.PlanetData.Radius + (double)vector.x;
				double heightRange2 = 1.0 / (double)(vector.y - vector.x);
				NativeArray<JobHandle> jobs = new NativeArray<JobHandle>(6, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				for (int num4 = 0; num4 < 6; num4++)
				{
					GenerateNormalsJob jobData = new GenerateNormalsJob
					{
						Size = size,
						HeightMin = heightMin,
						HeightRange = heightRange2,
						HeightSamples = array2[num4],
						Normals = colorData[num4][0]
					};
					jobs[num4] = jobData.Schedule();
				}
				JobHandle.CompleteAll(jobs);
				jobs.Dispose();
				for (int num5 = 0; num5 < downsampleIterations; num5++)
				{
					int num6 = size / (int)System.Math.Pow(2.0, num5);
					ManagedActionJob[] array4 = new ManagedActionJob[6];
					NativeArray<JobHandle> jobs2 = new NativeArray<JobHandle>(6, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					for (int num7 = 0; num7 < 6; num7++)
					{
						NativeArray<float4>[] array5 = colorData[num7];
						NativeArray<byte> bytes = (byteArrays[num7] = new NativeArray<byte>(num6 * num6 * 4, Allocator.Persistent));
						string fileName = GetBaseFileName(PlanetCubemapType.Normal, num6) + CubemapFileSuffixes[num7];
						JobHandle dependsOn = default(JobHandle);
						if (num5 > 0)
						{
							dependsOn = new DownsampleNormalsJob
							{
								Normals = array5[num5 - 1],
								DownsampledNormals = array5[num5],
								Size = num6
							}.Schedule(dependsOn);
						}
						dependsOn = new ConvertNormalTextureToByteArrayJob
						{
							Bytes = bytes,
							Normals = array5[num5],
							Size = num6
						}.Schedule(dependsOn);
						array4[num7] = new ManagedActionJob(delegate
						{
							planet.GeneratedData.SaveFile(fileName, bytes, CompressCubemaps);
						});
						dependsOn = array4[num7].Schedule(dependsOn);
						jobs2[num7] = dependsOn;
					}
					JobHandle.CompleteAll(jobs2);
					jobs2.Dispose();
					array4.Foreach(delegate(ManagedActionJob managedActionJob)
					{
						managedActionJob.Dispose();
					});
					byteArrays.Foreach(delegate(NativeArray<byte> nativeArray)
					{
						nativeArray.Dispose();
					});
				}
			}
			if (cliffs)
			{
				for (int num8 = 0; num8 < 6; num8++)
				{
					int face2 = num8;
					NativeArray<float4> colorMax2 = colorMaxValues[num8];
					NativeArray<float4> colors2 = colorData[num8][0];
					array[num8] = Task.Run(delegate
					{
						GenerateCubemapFaceCliffedData(face2, size, colors2, colorMax2, terrainGenerator, hasWater, waterSmoothness);
					});
				}
				Task.WaitAll(array);
				ProcessColors();
			}
			PlanetCubemapData planetCubemapData = new PlanetCubemapData();
			planetCubemapData.MinHeight = vector.x;
			planetCubemapData.MaxHeight = vector.y;
			planetCubemapData.MaxColor = maxColor.xyz;
			planetCubemapData.Save(planet);
			if (flag2)
			{
				terrainGenerator.Dispose();
			}
			for (int num9 = 0; num9 < 6; num9++)
			{
				colorMaxValues[num9].Dispose();
				array2[num9].Dispose();
				for (int num10 = 0; num10 < downsampleIterations; num10++)
				{
					colorData[num9][num10].Dispose();
				}
			}
			if (!flag)
			{
				planet.UnloadTerrainData();
			}
			GC.Collect();
			void ProcessColors()
			{
				for (int l = 0; l < 6; l++)
				{
					foreach (float4 item in colorMaxValues[l])
					{
						maxColor = math.max(item, maxColor);
					}
				}
				_ = new byte[size * size * 4];
				for (int m = 0; m < downsampleIterations; m++)
				{
					int num11 = size / (int)System.Math.Pow(2.0, m);
					ManagedActionJob[] array6 = new ManagedActionJob[6];
					NativeArray<JobHandle> jobs3 = new NativeArray<JobHandle>(6, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					for (int n = 0; n < 6; n++)
					{
						NativeArray<float4>[] array7 = colorData[n];
						NativeArray<byte> bytes2 = (byteArrays[n] = new NativeArray<byte>(num11 * num11 * 4, Allocator.Persistent));
						string fileName2 = GetBaseFileName(PlanetCubemapType.Color, num11) + CubemapFileSuffixes[n];
						JobHandle dependsOn2 = default(JobHandle);
						if (m > 0)
						{
							dependsOn2 = new DownsampleJob
							{
								ColorData = array7[m - 1],
								DownsampledColorData = array7[m],
								Size = num11
							}.Schedule();
						}
						dependsOn2 = new ConvertColorTextureToByteArrayJob
						{
							Bytes = bytes2,
							ColorData = array7[m],
							MaxColor = maxColor,
							Size = num11
						}.Schedule(dependsOn2);
						array6[n] = new ManagedActionJob(delegate
						{
							planet.GeneratedData.SaveFile(fileName2, bytes2, CompressCubemaps);
						});
						dependsOn2 = array6[n].Schedule(dependsOn2);
						jobs3[n] = dependsOn2;
					}
					JobHandle.CompleteAll(jobs3);
					jobs3.Dispose();
					array6.Foreach(delegate(ManagedActionJob managedActionJob)
					{
						managedActionJob.Dispose();
					});
					byteArrays.Foreach(delegate(NativeArray<byte> nativeArray)
					{
						nativeArray.Dispose();
					});
				}
			}
		}

		public static IEnumerator CreateCubemapsAsync(IPlanetData planet)
		{
			bool terrainDataLoaded = planet.TerrainData != null;
			IPlanetTerrainData planetTerrainData = (terrainDataLoaded ? planet.TerrainData : planet.LoadTerrainData());
			planetTerrainData.Initialize();
			TerrainGenerator terrainGenerator = CreateTerrainGeneratorForCubemaps(planetTerrainData);
			TerrainQualitySettings.CubemapQualitySettings settings = ModApi.Common.Game.Instance.Settings.Quality.Terrain.CubemapSettings;
			int size = settings.MaxSize;
			int downsampleIterations = settings.GenerationDownsampleCount;
			Task createCubemapsTask = Task.Run(delegate
			{
				try
				{
					CreateCubemaps(planet, terrainGenerator, size, downsampleIterations, settings.NormalMapsEnabled, settings.NormalCliffColorEnabled);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			});
			yield return new WaitUntil(() => createCubemapsTask.IsCompleted);
			terrainGenerator.Dispose();
			if (!terrainDataLoaded)
			{
				planet.UnloadTerrainData();
			}
		}

		public static void CreateEquirectangularMap(IPlanetData planet, float brightnessAdjustment = 0f)
		{
			CreateEquirectangularMap(planet, 2048, 1024, 2, brightnessAdjustment);
		}

		public static Texture2D[] CreateEquirectangularMap(IPlanetData planet, int width, int height, int downsampleIterations, float brightnessAdjustment, float lighting = 1f, bool saveMaps = true)
		{
			Debug.Log("Generating Equirectangular Maps for '" + planet.Name + "'");
			bool flag = planet.TerrainData != null;
			IPlanetTerrainData obj = (flag ? planet.TerrainData : planet.LoadTerrainData());
			obj.Initialize();
			TerrainGenerator terrainGenerator = new TerrainGenerator(obj, new string[1] { "EQUIRECTANGULARMAP" });
			bool hasWater = planet.HasWater;
			float num = (hasWater ? terrainGenerator.SeaLevel : 0f);
			Texture2D[] array = new Texture2D[downsampleIterations + 1];
			NativeArray<Color32>[] array2 = new NativeArray<Color32>[downsampleIterations + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Texture2D(width / (int)System.Math.Pow(2.0, i), height / (int)System.Math.Pow(2.0, i), TextureFormat.RGBA32, mipChain: false);
				array2[i] = array[i].GetRawTextureData<Color32>();
			}
			double[] array3 = new double[width * height];
			TerrainGeneratorCacheData cacheData = TerrainGeneratorCacheData.GetCacheData(terrainGenerator.BiomeCount, terrainGenerator.TerrainQuadVertexCount);
			for (int j = 0; j < height; j++)
			{
				for (int k = 0; k < width; k++)
				{
					double num2 = (double)k / (double)width * (System.Math.PI * 2.0) - System.Math.PI;
					double d = (double)j / (double)height * System.Math.PI - System.Math.PI / 2.0;
					Vector3d normalized = new Vector3d(Mathd.Cos(d) * Mathd.Sin(0.0 - num2), Mathd.Sin(d), Mathd.Cos(d) * Mathd.Cos(0.0 - num2)).normalized;
					PlanetVertexData planetVertexData = terrainGenerator.GetVertexData(VertexDataRequestType.HeightAndBiomeData, normalized, normalized, cacheData);
					if (hasWater && planetVertexData.Height < (double)num)
					{
						planetVertexData = terrainGenerator.GetVertexDataWaterPass(cacheData);
					}
					planetVertexData.Color.a = 1f;
					if (brightnessAdjustment != 0f)
					{
						Color.RGBToHSV(planetVertexData.Color, out var H, out var S, out var V);
						planetVertexData.Color = Color.HSVToRGB(H, S, V + brightnessAdjustment, hdr: false);
					}
					int num3 = j * width + k;
					array2[0][num3] = planetVertexData.Color;
					array3[num3] = planetVertexData.Height;
				}
			}
			cacheData.ReturnToPool();
			if (lighting > 0f)
			{
				float num4 = Mathf.LerpUnclamped(0f, 2.5f, lighting);
				Vector3d normalized2 = new Vector3d(num4, 1f, num4).normalized;
				double num5 = 1.0 / normalized2.y;
				for (int l = 0; l < height; l++)
				{
					double num6 = Mathd.Cos(((double)l / (double)height * 2.0 - 1.0) * System.Math.PI / 2.0) * planet.Radius;
					double num7 = System.Math.PI * num6 * 2.0 / (double)width;
					double num8 = System.Math.PI * planet.Radius / (double)height;
					for (int m = 0; m < width; m++)
					{
						double a = (hasWater ? ((double)terrainGenerator.SeaLevel) : (0.0 - planet.Radius));
						Vector3d vector3d = new Vector3d(0.0 - num7, Mathd.Max(a, array3[GetWrappedIndex(width, height, m - 1, l)]), 0.0);
						Vector3d vector3d2 = new Vector3d(num7, Mathd.Max(a, array3[GetWrappedIndex(width, height, m + 1, l)]), 0.0);
						Vector3d vector3d3 = new Vector3d(0.0, Mathd.Max(a, array3[GetWrappedIndex(width, height, m, l - 1)]), 0.0 - num8);
						Vector3d vector3d4 = new Vector3d(0.0, Mathd.Max(a, array3[GetWrappedIndex(width, height, m, l + 1)]), num8);
						double num9 = Vector3d.Dot(Vector3d.Cross((vector3d3 - vector3d4).normalized, (vector3d - vector3d2).normalized), normalized2);
						int wrappedIndex = GetWrappedIndex(width, height, m, l);
						Color color = array2[0][wrappedIndex];
						color *= (float)(num9 * num5);
						color.a = 1f;
						array2[0][wrappedIndex] = color;
					}
				}
			}
			for (int n = 1; n < array.Length; n++)
			{
				DownSample(width / (int)System.Math.Pow(2.0, n), height / (int)System.Math.Pow(2.0, n), array2[n - 1], array2[n]);
			}
			if (saveMaps)
			{
				for (int num10 = 0; num10 < array.Length; num10++)
				{
					int num11 = width / (int)System.Math.Pow(2.0, num10);
					int num12 = height / (int)System.Math.Pow(2.0, num10);
					planet.GeneratedData.SaveTextureAsPng($"Equirectangular_{num11}x{num12}.png", array[num10]);
				}
			}
			terrainGenerator.Dispose();
			if (!flag)
			{
				planet.UnloadTerrainData();
			}
			GC.Collect();
			return array;
		}

		public static TerrainGenerator CreateTerrainGeneratorForCubemaps(IPlanetTerrainData terrainData)
		{
			return new TerrainGenerator(terrainData, new string[1] { "CUBEMAP" });
		}

		public static bool Exists(IPlanetData planetData, PlanetCubemapType type, int size)
		{
			CelestialDatabaseGeneratedData generatedData = planetData.GeneratedData;
			string baseFileName = GetBaseFileName(type, size);
			bool flag = true;
			if (type == PlanetCubemapType.Normal)
			{
				flag = PlanetCubemapData.Exists(planetData);
			}
			return generatedData.FileExists(baseFileName + CubemapFileSuffixes[0]) && generatedData.FileExists(baseFileName + CubemapFileSuffixes[1]) && generatedData.FileExists(baseFileName + CubemapFileSuffixes[2]) && generatedData.FileExists(baseFileName + CubemapFileSuffixes[3]) && generatedData.FileExists(baseFileName + CubemapFileSuffixes[4]) && generatedData.FileExists(baseFileName + CubemapFileSuffixes[5]) && flag;
		}

		public static bool Exists(IPlanetData planetData)
		{
			TerrainQualitySettings.CubemapQualitySettings cubemapSettings = ModApi.Common.Game.Instance.Settings.Quality.Terrain.CubemapSettings;
			bool flag = cubemapSettings.NormalMapsEnabled && !planetData.UniformHeight;
			if (Exists(planetData, PlanetCubemapType.Color, cubemapSettings.MaxSize))
			{
				if (flag)
				{
					return Exists(planetData, PlanetCubemapType.Normal, cubemapSettings.MaxSize);
				}
				return true;
			}
			return false;
		}

		public static bool ExistsEquirectangular(IPlanetData planet)
		{
			int num = 2048;
			int num2 = 1024;
			for (int i = 0; i < 2; i++)
			{
				if (!planet.GeneratedData.FileExists($"Equirectangular_{num}x{num2}.png"))
				{
					return false;
				}
				num /= 2;
				num2 /= 2;
			}
			return true;
		}

		public static string GetBaseFileName(PlanetCubemapType type, int size)
		{
			string arg = ((type == PlanetCubemapType.Color) ? "color" : "normal");
			return $"{arg}-{size}";
		}

		public static PlanetCubemapData GetCubemapData(IPlanetData planet, bool create)
		{
			if (!PlanetCubemapData.Exists(planet))
			{
				if (!create)
				{
					return PlanetCubemapData.GetDefault();
				}
				CreateCubemaps(planet);
			}
			return PlanetCubemapData.Load(planet) ?? PlanetCubemapData.GetDefault();
		}

		public static Cubemap LoadCubemap(IPlanetData planet, PlanetCubemapType type, int size, bool create)
		{
			TerrainQualitySettings.CubemapQualitySettings cubemapSettings = ModApi.Common.Game.Instance.QualitySettings.Terrain.CubemapSettings;
			if (type == PlanetCubemapType.Normal && (!cubemapSettings.NormalMapsEnabled || planet.UniformHeight))
			{
				return null;
			}
			if (!Exists(planet, type, size))
			{
				if (!create)
				{
					return null;
				}
				CreateCubemaps(planet);
			}
			string baseFileName = GetBaseFileName(type, size);
			TextureFormat textureFormat = (true ? TextureFormat.RGBA32 : TextureFormat.RGB24);
			Cubemap cubemap = new Cubemap(size, textureFormat, mipChain: true);
			cubemap.name = $"PlanetCubemap_{type}_{planet.Name}_{size}";
			NativeArray<Color32> data = new NativeArray<Color32>(size * size, Allocator.Temp);
			for (int i = 0; i < 6; i++)
			{
				planet.GeneratedData.LoadFileAsColor32(baseFileName + CubemapFileSuffixes[i], data, CompressCubemaps);
				cubemap.SetPixelData(data, 0, (CubemapFace)i);
			}
			cubemap.Apply(updateMipmaps: true, makeNoLongerReadable: true);
			data.Dispose();
			return cubemap;
		}

		public static IEnumerator LoadCubemapsCoroutine(IPlanetData planet, int size, Action<Cubemap, Cubemap> onCubemapsLoaded)
		{
			if (!Exists(planet, PlanetCubemapType.Color, size))
			{
				CreateCubemaps(planet);
			}
			string baseFileName = GetBaseFileName(PlanetCubemapType.Color, size);
			TextureFormat format = (true ? TextureFormat.RGBA32 : TextureFormat.RGB24);
			Cubemap cubemapColor = new Cubemap(size, format, mipChain: true)
			{
				name = $"PlanetCubemap_{PlanetCubemapType.Color}_{planet.Name}_{size}"
			};
			NativeArray<Color32> data = new NativeArray<Color32>(size * size, Allocator.Persistent);
			int f = 0;
			while (f < 6)
			{
				ManagedActionJob loadFileJob = new ManagedActionJob(delegate
				{
					planet.GeneratedData.LoadFileAsColor32(baseFileName + CubemapFileSuffixes[f], data, CompressCubemaps);
				});
				JobHandle loadFileJobHandle = loadFileJob.Schedule();
				yield return new WaitUntil(() => loadFileJobHandle.IsCompleted);
				loadFileJobHandle.Complete();
				loadFileJob.Dispose();
				cubemapColor.SetPixelData(data, 0, (CubemapFace)f);
				int num = f + 1;
				f = num;
			}
			cubemapColor.Apply(updateMipmaps: true, makeNoLongerReadable: true);
			if (!ModApi.Common.Game.Instance.QualitySettings.Terrain.CubemapSettings.NormalMapsEnabled || planet.UniformHeight)
			{
				data.Dispose();
				onCubemapsLoaded(cubemapColor, null);
				yield break;
			}
			if (!Exists(planet, PlanetCubemapType.Normal, size))
			{
				CreateCubemaps(planet);
			}
			baseFileName = GetBaseFileName(PlanetCubemapType.Normal, size);
			Cubemap cubemapNormals = new Cubemap(size, format, mipChain: true)
			{
				name = $"PlanetCubemap_{PlanetCubemapType.Normal}_{planet.Name}_{size}"
			};
			int f2 = 0;
			while (f2 < 6)
			{
				ManagedActionJob loadFileJob = new ManagedActionJob(delegate
				{
					planet.GeneratedData.LoadFileAsColor32(baseFileName + CubemapFileSuffixes[f2], data, CompressCubemaps);
				});
				JobHandle loadFileJobHandle2 = loadFileJob.Schedule();
				yield return new WaitUntil(() => loadFileJobHandle2.IsCompleted);
				loadFileJobHandle2.Complete();
				loadFileJob.Dispose();
				cubemapNormals.SetPixelData(data, 0, (CubemapFace)f2);
				int num = f2 + 1;
				f2 = num;
			}
			cubemapNormals.Apply(updateMipmaps: true, makeNoLongerReadable: true);
			data.Dispose();
			onCubemapsLoaded(cubemapColor, cubemapNormals);
		}

		private static void DownSample(int targetWidth, int targetHeight, NativeArray<Color32> source, NativeArray<Color32> target)
		{
			int num = targetWidth * 2;
			int num2 = 0;
			int num3 = 0;
			int num4 = 1;
			int num5 = num;
			int num6 = num + 1;
			Color32 value = new Color32(0, 0, 0, 0);
			for (int i = 0; i < targetHeight; i++)
			{
				for (int j = 0; j < targetWidth; j++)
				{
					Color32 color = source[num3];
					Color32 color2 = source[num4];
					Color32 color3 = source[num5];
					Color32 color4 = source[num6];
					value.r = (byte)((color.r + color2.r + color3.r + color4.r) / 4);
					value.g = (byte)((color.g + color2.g + color3.g + color4.g) / 4);
					value.b = (byte)((color.b + color2.b + color3.b + color4.b) / 4);
					value.a = (byte)((color.a + color2.a + color3.a + color4.a) / 4);
					target[num2++] = value;
					num3 += 2;
					num4 += 2;
					num5 += 2;
					num6 += 2;
				}
				num3 += num;
				num4 += num;
				num5 += num;
				num6 += num;
			}
		}

		private static void GenerateCubemapFaceCliffedData(int faceIndex, int size, NativeArray<float4> colorData, NativeArray<float4> colorMax, ITerrainGenerator terrainGenerator, bool hasWater, float waterSmoothness)
		{
			CubemapFace face = (CubemapFace)faceIndex;
			int num = 4;
			Task[] array = new Task[num];
			int num2 = size / num;
			if (num2 * num != size)
			{
				num2++;
			}
			int num3 = -1;
			for (int i = 0; i < num; i++)
			{
				int yStart = num3;
				int yEnd = ((i == num - 1) ? size : (yStart + num2 + ((i != 0) ? (-1) : 0)));
				num3 = yEnd + 1;
				array[i] = Task.Run(delegate
				{
					GenerateCubemapsCliffedSegment(yStart, yEnd, size, face, terrainGenerator, hasWater, waterSmoothness, colorData, colorMax);
				});
			}
			Task.WaitAll(array);
		}

		private static void GenerateCubemapFaceData(int faceIndex, int size, NativeArray<double3> heightSamples, MinMaxValue[] heightRanges, NativeArray<float4> colorData, NativeArray<float4> colorMax, ITerrainGenerator terrainGenerator, bool hasWater, float waterSmoothness)
		{
			CubemapFace face = (CubemapFace)faceIndex;
			double radius = terrainGenerator.TerrainData.PlanetData.Radius;
			int num = 4;
			Task[] array = new Task[num];
			int num2 = size / num;
			if (num2 * num != size)
			{
				num2++;
			}
			int num3 = -1;
			for (int i = 0; i < num; i++)
			{
				int yStart = num3;
				int yEnd = ((i == num - 1) ? size : (yStart + num2 + ((i != 0) ? (-1) : 0)));
				num3 = yEnd + 1;
				array[i] = Task.Run(delegate
				{
					GenerateCubemapsSegment(yStart, yEnd, size, face, terrainGenerator, radius, hasWater, waterSmoothness, heightSamples, heightRanges, colorData, colorMax);
				});
			}
			Task.WaitAll(array);
		}

		private static void GenerateCubemapFaceHeightData(int faceIndex, int size, NativeArray<double3> heightSamples, MinMaxValue[] heightRanges, ITerrainGenerator terrainGenerator, bool hasWater)
		{
			CubemapFace face = (CubemapFace)faceIndex;
			double radius = terrainGenerator.TerrainData.PlanetData.Radius;
			int num = 4;
			Task[] array = new Task[num];
			int num2 = size / num;
			if (num2 * num != size)
			{
				num2++;
			}
			int num3 = -1;
			for (int i = 0; i < num; i++)
			{
				int yStart = num3;
				int yEnd = ((i == num - 1) ? size : (yStart + num2 + ((i != 0) ? (-1) : 0)));
				num3 = yEnd + 1;
				array[i] = Task.Run(delegate
				{
					GenerateCubemapsHeightSegment(yStart, yEnd, size, face, terrainGenerator, radius, hasWater, heightSamples, heightRanges);
				});
			}
			Task.WaitAll(array);
		}

		private static void GenerateCubemapsCliffedSegment(int yStart, int yEnd, int size, CubemapFace face, ITerrainGenerator terrainGenerator, bool hasWater, float waterSmoothness, NativeArray<float4> colors, NativeArray<float4> colorMax)
		{
			double num = 1.0 / ((double)size * 0.5);
			float num2 = (hasWater ? terrainGenerator.SeaLevel : 0f);
			TerrainGeneratorCacheData cacheData = TerrainGeneratorCacheData.GetCacheData(terrainGenerator.BiomeCount, terrainGenerator.TerrainQuadVertexCount);
			int num3 = (size + 2) * (yStart + 1);
			int index = ((yStart != -1) ? (yStart * size) : 0);
			for (int i = yStart; i <= yEnd; i++)
			{
				bool flag = i == -1 || i == size;
				float4 float5 = new float4(float.MinValue, float.MinValue, float.MinValue, 1f);
				double v = (double)i * num - 1.0;
				for (int j = -1; j <= size; j++)
				{
					double u = (double)j * num - 1.0;
					double3 double5 = Utility.CubemapTextureCoordinatesToDirection(face, u, v).ToDouble3();
					if (!flag && j != -1 && j != size)
					{
						double3 double6 = new double3(colors[index].xyz);
						PlanetVertexData planetVertexData = terrainGenerator.GetVertexData(VertexDataRequestType.HeightAndBiomeData, double5, double6, cacheData);
						if (hasWater && planetVertexData.Height < (double)num2)
						{
							planetVertexData = terrainGenerator.GetVertexDataWaterPass(cacheData);
							planetVertexData.Smoothness *= waterSmoothness;
						}
						float w = ((planetVertexData.Emissiveness >= 0.05f) ? ((1f - planetVertexData.Emissiveness) * (4f / 51f)) : (planetVertexData.Smoothness * 0.5019608f + 0.49803922f));
						float4 float6 = new float4(planetVertexData.Color.r, planetVertexData.Color.g, planetVertexData.Color.b, w);
						float5 = math.max(float5, float6);
						colors[index++] = float6;
					}
					num3++;
				}
				if (!flag)
				{
					colorMax[i] = float5;
				}
			}
			cacheData.ReturnToPool();
		}

		private static void GenerateCubemapsHeightSegment(int yStart, int yEnd, int size, CubemapFace face, ITerrainGenerator terrainGenerator, double radius, bool hasWater, NativeArray<double3> heightSamples, MinMaxValue[] heightRanges)
		{
			double num = 1.0 / ((double)size * 0.5);
			float num2 = (hasWater ? terrainGenerator.SeaLevel : 0f);
			TerrainGeneratorCacheData cacheData = TerrainGeneratorCacheData.GetCacheData(terrainGenerator.BiomeCount, terrainGenerator.TerrainQuadVertexCount);
			int num3 = (size + 2) * (yStart + 1);
			for (int i = yStart; i <= yEnd; i++)
			{
				bool flag = i == -1 || i == size;
				double num4 = double.MaxValue;
				double num5 = double.MinValue;
				double v = (double)i * num - 1.0;
				for (int j = -1; j <= size; j++)
				{
					double u = (double)j * num - 1.0;
					double3 double5 = Utility.CubemapTextureCoordinatesToDirection(face, u, v).ToDouble3();
					double num6 = terrainGenerator.GetHeight(double5, cacheData);
					if (hasWater && num6 < (double)num2)
					{
						num6 = num2;
					}
					num4 = ((num6 < num4) ? num6 : num4);
					num5 = ((num6 > num5) ? num6 : num5);
					heightSamples[num3] = double5 * (num6 + radius);
					num3++;
				}
				if (!flag)
				{
					heightRanges[i] = new MinMaxValue((float)num4, (float)num5);
				}
			}
			cacheData.ReturnToPool();
		}

		private static void GenerateCubemapsSegment(int yStart, int yEnd, int size, CubemapFace face, ITerrainGenerator terrainGenerator, double radius, bool hasWater, float waterSmoothness, NativeArray<double3> heightSamples, MinMaxValue[] heightRanges, NativeArray<float4> colors, NativeArray<float4> colorMax)
		{
			double num = 1.0 / ((double)size * 0.5);
			float num2 = (hasWater ? terrainGenerator.SeaLevel : 0f);
			TerrainGeneratorCacheData cacheData = TerrainGeneratorCacheData.GetCacheData(terrainGenerator.BiomeCount, terrainGenerator.TerrainQuadVertexCount);
			int num3 = (size + 2) * (yStart + 1);
			int num4 = ((yStart != -1) ? (yStart * size) : 0);
			for (int i = yStart; i <= yEnd; i++)
			{
				bool flag = i == -1 || i == size;
				double num5 = double.MaxValue;
				double num6 = double.MinValue;
				float4 float5 = new float4(float.MinValue, float.MinValue, float.MinValue, 1f);
				double v = (double)i * num - 1.0;
				for (int j = -1; j <= size; j++)
				{
					double u = (double)j * num - 1.0;
					double3 double5 = Utility.CubemapTextureCoordinatesToDirection(face, u, v).ToDouble3();
					if (flag || j == -1 || j == size)
					{
						double num7 = terrainGenerator.GetHeight(double5, cacheData);
						if (hasWater && num7 < (double)num2)
						{
							num7 = num2;
						}
						heightSamples[num3] = double5 * (num7 + radius);
					}
					else
					{
						PlanetVertexData planetVertexData = terrainGenerator.GetVertexData(VertexDataRequestType.HeightAndBiomeData, double5, double5, cacheData);
						double num8 = planetVertexData.Height;
						if (hasWater && num8 < (double)num2)
						{
							planetVertexData = terrainGenerator.GetVertexDataWaterPass(cacheData);
							planetVertexData.Smoothness *= waterSmoothness;
							num8 = num2;
						}
						float w = ((planetVertexData.Emissiveness >= 0.05f) ? ((1f - planetVertexData.Emissiveness) * (4f / 51f)) : (planetVertexData.Smoothness * 0.5019608f + 0.49803922f));
						float4 float6 = new float4(planetVertexData.Color.r, planetVertexData.Color.g, planetVertexData.Color.b, w);
						num5 = ((num8 < num5) ? num8 : num5);
						num6 = ((num8 > num6) ? num8 : num6);
						float5 = math.max(float5, float6);
						colors[num4++] = float6;
						heightSamples[num3] = double5 * (num8 + radius);
					}
					num3++;
				}
				if (!flag)
				{
					heightRanges[i] = new MinMaxValue((float)num5, (float)num6);
					colorMax[i] = float5;
				}
			}
			cacheData.ReturnToPool();
		}

		private static int GetWrappedIndex(int width, int height, int x, int y)
		{
			if (x < 0)
			{
				x += width;
			}
			else if (x >= width)
			{
				x -= width;
			}
			if (y < 0)
			{
				y += height;
			}
			else if (y >= height)
			{
				y -= height;
			}
			return y * width + x;
		}
	}
}
