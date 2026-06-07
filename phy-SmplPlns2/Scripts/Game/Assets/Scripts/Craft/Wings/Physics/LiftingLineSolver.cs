using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.MeshGen;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using MathNet.Numerics.LinearAlgebra;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public class LiftingLineSolver : IDisposable
	{
		public struct TrailingVortex
		{
			public float3 asymptotePos;

			public float asymptotePower;

			public float asymptoteRadius;

			public float lifetime;

			public float motionRate;

			public float3 sourcePos;

			public float sourcePower;

			public float sourceRadius;

			public readonly void Extract(float age, out float3 pos, out float power, out float radius)
			{
				float t = 1f - math.exp(-1.5f * age);
				pos = math.lerp(sourcePos, asymptotePos, t);
				power = math.lerp(sourcePower, asymptotePower, t);
				radius = math.lerp(sourceRadius, asymptoteRadius, t);
			}

			public void Transform(float4x4 matrix)
			{
				sourcePos = math.transform(matrix, sourcePos);
				asymptotePos = math.transform(matrix, asymptotePos);
			}

			public void Translate(float3 vec)
			{
				sourcePos += vec;
				asymptotePos += vec;
			}
		}

		[BurstCompile]
		private struct LiftingLineSolveJob : IJob
		{
			public NativeArray<SliceAeroData> AeroData;

			public NativeArray<float> Circulation;

			[ReadOnly]
			public int MaxIterations;

			[ReadOnly]
			public int NumFourierTerms;

			[ReadOnly]
			public NativeArray<SlicePolar> Polars;

			[ReadOnly]
			public NativeArray<float> PrecomputedMatrix;

			[ReadOnly]
			public float Relaxation;

			[ReadOnly]
			public NativeArray<SliceData> SliceData;

			public NativeReference<TrailingVortex> Vortex;

			[ReadOnly]
			public NativeArray<WingInputData> WingData;

			[ReadOnly]
			public NativeArray<float> AtmoPressure;

			[ReadOnly]
			public NativeArray<float> AtmoTemperature;

			[ReadOnly]
			public NativeArray<float> AtmoDewPoint;

			[ReadOnly]
			public NativeArray<float> AtmoAltitude;

			public void Execute()
			{
				int length = AeroData.Length;
				int numFourierTerms = NumFourierTerms;
				NativeArray<float> nativeArray = new NativeArray<float>(numFourierTerms, Allocator.Temp);
				float spanStart = SliceData[0].spanPosition;
				ref NativeArray<SliceData> sliceData = ref SliceData;
				float num = sliceData[sliceData.Length - 1].spanPosition - spanStart;
				float invSpan = 1f / num;
				for (int i = 0; i < numFourierTerms; i++)
				{
					Circulation[i] = (math.isnan(Circulation[i]) ? 0f : math.clamp(Circulation[i], -1000f, 1000f));
				}
				float2 cD;
				float2 cM;
				for (int j = 0; j < MaxIterations; j++)
				{
					for (int k = 0; k < nativeArray.Length; k++)
					{
						nativeArray[k] = 0f;
					}
					for (int l = 0; l < length; l++)
					{
						float num2 = Theta(SliceData[l].spanPosition);
						float num3 = 0f;
						for (int m = 0; m < numFourierTerms; m++)
						{
							int num4 = m * 2 + 1;
							num3 += (float)(m + 1) * Circulation[m] * math.sin((float)num4 * num2);
						}
						float effectiveAlpha = AeroData[l].effectiveAlpha;
						float num5 = ((math.abs(math.sin(num2)) <= 0.0001f) ? effectiveAlpha : (num3 / (2f * math.sin(num2))));
						float alpha = effectiveAlpha - num5;
						Polars[l].Sample(alpha, AeroData[l].freeStreamMach, out var cL, out cD, out cM);
						float num6 = math.length(AeroData[l].freeStreamVelocity.yz);
						float num7 = 0.5f * num6 * SliceData[l].chordLength * cL.x / (2f * num * num6);
						int num8 = l * numFourierTerms;
						for (int n = 0; n < numFourierTerms; n++)
						{
							nativeArray[n] += PrecomputedMatrix[num8 + n] * num7;
						}
					}
					for (int num9 = 0; num9 < numFourierTerms; num9++)
					{
						Circulation[num9] = math.lerp(nativeArray[num9], Circulation[num9], Relaxation);
					}
				}
				NativeArray<float> nativeArray2 = new NativeArray<float>(length, Allocator.Temp);
				float2 float5 = 0f;
				for (int num10 = 0; num10 < length; num10++)
				{
					SliceAeroData value = AeroData[num10];
					if (num10 == length - 1)
					{
						value.effectiveAlpha = Polars[num10].alphaZero;
						if (num10 > 0)
						{
							value.effectiveAlpha = math.lerp(value.effectiveAlpha, AeroData[num10 - 1].effectiveAlpha, 0.5f);
						}
					}
					else
					{
						float num11 = Theta(SliceData[num10].spanPosition);
						float num12 = 0f;
						for (int num13 = 0; num13 < numFourierTerms; num13++)
						{
							int num14 = num13 * 2 + 1;
							num12 += (float)(num13 + 1) * Circulation[num13] * math.sin((float)num14 * num11);
						}
						float effectiveAlpha2 = AeroData[num10].effectiveAlpha;
						float num15 = ((math.abs(math.sin(num11)) <= 0.0001f) ? effectiveAlpha2 : (num12 / (2f * math.sin(num11))));
						value.effectiveAlpha -= num15;
					}
					AeroData[num10] = value;
					Polars[num10].Sample(value.effectiveAlpha, AeroData[num10].freeStreamMach, out var cL2, out cM, out cD);
					float num16 = math.length(AeroData[num10].freeStreamVelocity.yz);
					float value2 = 0.5f * num16 * SliceData[num10].chordLength * cL2.x;
					float5 += math.float2(cL2.x, 1f) * (SliceData[num10].chordLength * SliceData[num10].spanWidth);
					nativeArray2[num10] = value2;
				}
				float4 float6 = 0f;
				float4 float7 = 0f;
				float4 float8 = 0f;
				float2 float9 = 0f;
				float2 float10 = 0f;
				for (int num17 = length - 2; num17 >= (length - 2) / 2; num17--)
				{
					float3 panelTipTrailing = SliceData[num17 + 1].panelTipTrailing;
					float3 panelTipTrailing2 = SliceData[num17].panelTipTrailing;
					float3 float11 = 0.5f * (panelTipTrailing2 + panelTipTrailing);
					float num18 = nativeArray2[num17] - nativeArray2[num17 + 1];
					float8 += math.float4(float11 * num18, num18);
					float9 += math.float2(AeroData[num17 + 1].effectiveChordLength, 1f) * SliceData[num17 + 1].spanWidth;
					if (math.abs(float6.w) > math.abs(float7.w))
					{
						float7 = float8;
						float10 = float9;
					}
					if (num17 == length - 2)
					{
						float6 = float8;
					}
				}
				if (float7.w == 0f)
				{
					NoVortex();
					nativeArray2.Dispose();
					return;
				}
				float altitude = WingData[0].altitude;
				int num19 = MathUtils.BinarySearch(AtmoAltitude, altitude);
				float pressure;
				float temperature;
				float dewPoint;
				if (num19 < 0 || num19 >= AtmoAltitude.Length - 1)
				{
					num19 = ((num19 >= 0) ? (AtmoAltitude.Length - 1) : 0);
					pressure = AtmoPressure[num19];
					temperature = AtmoTemperature[num19];
					dewPoint = AtmoDewPoint[num19];
				}
				else
				{
					float t = math.unlerp(AtmoAltitude[num19], AtmoAltitude[num19 + 1], altitude);
					pressure = math.lerp(AtmoPressure[num19], AtmoPressure[num19 + 1], t);
					temperature = math.lerp(AtmoTemperature[num19], AtmoTemperature[num19 + 1], t);
					dewPoint = math.lerp(AtmoDewPoint[num19], AtmoDewPoint[num19 + 1], t);
				}
				float num20 = float10.x / float10.y;
				float num21 = (0.04f + 0.14f * math.abs(float5.x / float5.y)) * num20 * 0.5f;
				float lifetime;
				float asymptotePower = GetTrailPower(num21 * 1.4f, float7.w, out lifetime);
				ref NativeReference<TrailingVortex> vortex = ref Vortex;
				TrailingVortex value3 = default(TrailingVortex);
				ref NativeArray<SliceData> sliceData2 = ref SliceData;
				value3.sourcePos = sliceData2[sliceData2.Length - 1].panelTipTrailing;
				value3.sourceRadius = num21;
				value3.sourcePower = GetTrailPower(num21, float6.w, out var _);
				value3.asymptotePos = float7.xyz / float7.w;
				value3.asymptoteRadius = num21 * 1.4f;
				value3.asymptotePower = asymptotePower;
				value3.lifetime = lifetime;
				value3.motionRate = 5f;
				vortex.Value = value3;
				nativeArray2.Dispose();
				float GetTrailPower(float radius, float circulation, out float reference)
				{
					float num22 = 0.6908f * math.pow(circulation / (MathF.PI * 2f * radius), 2f);
					float num23 = pressure - num22;
					float num24 = temperature * math.pow(num23 / pressure, 0.28571427f);
					reference = (1f + dewPoint - num24) * 0.1f;
					reference = math.min(reference, 2f);
					return 1f - math.smoothstep(dewPoint - 1f, dewPoint + 1f, num24);
				}
				float Theta(float spanPosition)
				{
					return SpanTheta(spanPosition, spanStart, invSpan);
				}
			}

			private void NoVortex()
			{
				ref NativeArray<SliceData> sliceData = ref SliceData;
				float3 panelTipTrailing = sliceData[sliceData.Length - 1].panelTipTrailing;
				Vortex.Value = new TrailingVortex
				{
					asymptotePos = panelTipTrailing,
					sourcePos = panelTipTrailing,
					asymptotePower = 0f,
					asymptoteRadius = 0f,
					lifetime = 0f,
					motionRate = 0f,
					sourcePower = 0f,
					sourceRadius = 0f
				};
			}
		}

		private struct PrecalculateJob : IJob
		{
			public int NumFourierTerms;

			public NativeArray<float> Result;

			[ReadOnly]
			public NativeArray<SliceData> SliceData;

			public readonly void Execute()
			{
				Precalculate(SliceData, Result, NumFourierTerms);
			}
		}

		private class HumidityModel
		{
			public NativeArray<float> Altitude { get; private set; }

			public NativeArray<float> DewPoint { get; private set; }

			public NativeArray<float> Pressure { get; private set; }

			public NativeArray<float> Temperature { get; private set; }

			public NativeArray<float> VMR { get; private set; }

			public HumidityModel()
			{
				TextAsset textAsset = Resources.Load<TextAsset>("Data/Atmosphere/VortexHumidityModel");
				bool flag = false;
				List<(float, float, float, float, float)> list = new List<(float, float, float, float, float)>();
				StringUtility.StringSplitEnumerator enumerator = textAsset.text.SpanSplit('\n').GetEnumerator();
				(float, float, float, float, float) item = default((float, float, float, float, float));
				while (enumerator.MoveNext())
				{
					StringUtility.StringSplitEntry current = enumerator.Current;
					if (!current.Span.IsWhiteSpace())
					{
						if (!flag)
						{
							flag = true;
							continue;
						}
						StringUtility.StringSplitEnumerator<float?> stringSplitEnumerator = current.Span.SpanSplitAsFloats(',');
						stringSplitEnumerator.MoveNext();
						item.Item1 = stringSplitEnumerator.Current.Value.Value;
						stringSplitEnumerator.MoveNext();
						item.Item2 = stringSplitEnumerator.Current.Value.Value;
						stringSplitEnumerator.MoveNext();
						item.Item3 = stringSplitEnumerator.Current.Value.Value;
						stringSplitEnumerator.MoveNext();
						item.Item4 = stringSplitEnumerator.Current.Value.Value;
						stringSplitEnumerator.MoveNext();
						item.Item5 = stringSplitEnumerator.Current.Value.Value;
						list.Add(item);
					}
				}
				list.Sort(((float Altitude, float Pressure, float Temperature, float VMR, float DewPoint) a, (float Altitude, float Pressure, float Temperature, float VMR, float DewPoint) b) => a.Altitude.CompareTo(b.Altitude));
				int count = list.Count;
				NativeArray<float> nativeArray = (Altitude = new NativeArray<float>(count, Allocator.Persistent));
				NativeArray<float> nativeArray3 = (Pressure = new NativeArray<float>(count, Allocator.Persistent));
				NativeArray<float> nativeArray5 = (Temperature = new NativeArray<float>(count, Allocator.Persistent));
				NativeArray<float> nativeArray7 = (VMR = new NativeArray<float>(count, Allocator.Persistent));
				NativeArray<float> nativeArray9 = (DewPoint = new NativeArray<float>(count, Allocator.Persistent));
				for (int num = 0; num < count; num++)
				{
					(float, float, float, float, float) tuple = list[num];
					nativeArray[num] = tuple.Item1;
					nativeArray3[num] = tuple.Item2;
					nativeArray5[num] = tuple.Item3;
					nativeArray7[num] = tuple.Item4;
					nativeArray9[num] = tuple.Item5;
				}
			}

			~HumidityModel()
			{
				Altitude.Dispose();
				Pressure.Dispose();
				Temperature.Dispose();
				VMR.Dispose();
				DewPoint.Dispose();
			}
		}

		private static HumidityModel _humidityModel;

		private readonly int _numSlices;

		private NativeArray<float> _fourierCoefficients;

		private JobHandle? _lastJob;

		private int _numFourierTerms;

		private bool _precomputed;

		private NativeArray<float> _precomputedMatrix;

		private NativeReference<TrailingVortex> _trailingVortex;

		public static int FourierTermsSetting { get; set; } = 8;

		public static int IterationsSetting { get; set; } = 10;

		public static float RelaxationSetting { get; set; } = 0.99f;

		public TrailingVortex? TrailingVortexData { get; private set; }

		private int TargetNumFourier => Math.Max(2, Math.Min(FourierTermsSetting, (_numSlices - 1) / 2 + 1));

		public LiftingLineSolver(int numSlices)
		{
			_numSlices = numSlices;
			_numFourierTerms = FourierTermsSetting;
			AllocateArrays();
			_trailingVortex = new NativeReference<TrailingVortex>(Allocator.Persistent);
			if (_humidityModel == null)
			{
				_humidityModel = new HumidityModel();
			}
		}

		public void Dispose()
		{
			_fourierCoefficients.Dispose();
			_precomputedMatrix.Dispose();
			_trailingVortex.Dispose();
			TrailingVortexData = null;
		}

		public void OnCompleted()
		{
			TrailingVortexData = _trailingVortex.Value;
		}

		public JobHandle Schedule(JobHandle handle, WingPhysicsManager physics)
		{
			if (_numFourierTerms != TargetNumFourier)
			{
				_numFourierTerms = TargetNumFourier;
				if (_lastJob.HasValue)
				{
					_fourierCoefficients.Dispose(_lastJob.Value);
					_precomputedMatrix.Dispose(_lastJob.Value);
				}
				else
				{
					_fourierCoefficients.Dispose();
					_precomputedMatrix.Dispose();
				}
				_precomputed = false;
				AllocateArrays();
			}
			if (!_precomputed)
			{
				JobHandle job = new PrecalculateJob
				{
					NumFourierTerms = _numFourierTerms,
					Result = _precomputedMatrix,
					SliceData = physics.SliceData
				}.Schedule(handle);
				handle = JobHandle.CombineDependencies(handle, job);
				_precomputed = true;
			}
			handle = new LiftingLineSolveJob
			{
				SliceData = physics.SliceData,
				AeroData = physics.SliceAeroData,
				Circulation = _fourierCoefficients,
				MaxIterations = IterationsSetting,
				NumFourierTerms = _numFourierTerms,
				Polars = physics.SlicePolars,
				PrecomputedMatrix = _precomputedMatrix,
				Relaxation = RelaxationSetting,
				Vortex = _trailingVortex,
				WingData = physics.WingInputData,
				AtmoAltitude = _humidityModel.Altitude,
				AtmoDewPoint = _humidityModel.DewPoint,
				AtmoPressure = _humidityModel.Pressure,
				AtmoTemperature = _humidityModel.Temperature
			}.Schedule(handle);
			_lastJob = handle;
			return handle;
		}

		private static void Precalculate(NativeArray<SliceData> sliceData, NativeArray<float> pinv, int fourierTerms)
		{
			Matrix<float> matrix = Matrix<float>.Build.Dense(sliceData.Length, fourierTerms);
			SliceData sliceData2 = sliceData[sliceData.Length - 1];
			float spanPosition = sliceData[0].spanPosition;
			float num = sliceData2.spanPosition - spanPosition;
			float invSpan = 1f / num;
			for (int i = 0; i < sliceData.Length; i++)
			{
				float num2 = SpanTheta(sliceData[i].spanPosition, spanPosition, invSpan);
				for (int j = 0; j < fourierTerms; j++)
				{
					int num3 = j * 2 + 1;
					matrix[i, j] = math.sin((float)num3 * num2);
				}
			}
			Matrix<float> matrix2 = matrix.TransposeThisAndMultiply(matrix).Inverse().TransposeAndMultiply(matrix);
			for (int k = 0; k < sliceData.Length; k++)
			{
				for (int l = 0; l < fourierTerms; l++)
				{
					pinv[k * fourierTerms + l] = matrix2[l, k];
				}
			}
		}

		private static float SpanTheta(float spanPosition, float spanStart, float invSpan)
		{
			float num = math.acos((0f - (spanPosition - spanStart)) * invSpan);
			if (!math.isnan(num))
			{
				return num;
			}
			return 0f;
		}

		private void AllocateArrays()
		{
			_fourierCoefficients = new NativeArray<float>(_numFourierTerms, Allocator.Persistent);
			_precomputedMatrix = new NativeArray<float>(_numSlices * _numFourierTerms, Allocator.Persistent);
		}
	}
}
