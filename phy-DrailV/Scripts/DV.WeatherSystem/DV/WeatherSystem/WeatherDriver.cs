using System;
using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.Utils;
using DelaunatorSharp;
using Newtonsoft.Json.Linq;
using THOR;
using UnityEngine;

namespace DV.WeatherSystem
{
	public class WeatherDriver : SingletonBehaviour<WeatherDriver>
	{
		private class WeatherNode : IPoint
		{
			public Weather24hPresetSO Preset;

			public Vector2 Coord;

			public double X
			{
				get
				{
					return Coord.x;
				}
				set
				{
					Coord.x = (float)value;
				}
			}

			public double Y
			{
				get
				{
					return Coord.y;
				}
				set
				{
					Coord.y = (float)value;
				}
			}

			public WeatherNode(Weather24hPresetSO preset)
			{
				Preset = preset;
				float num = 0f;
				float num2 = 0f;
				if (preset.snapshots.Count > 0)
				{
					for (int i = 0; i < preset.snapshots.Count; i++)
					{
						num += preset.snapshots[i].OverallFogDensity;
						num2 += preset.snapshots[i].cloudCoverage;
					}
					num /= (float)preset.snapshots.Count;
					num2 /= (float)preset.snapshots.Count;
				}
				Coord = new Vector2(num, num2);
			}
		}

		private class WeatherTriangle
		{
			public readonly WeatherNode[] Points;

			public Rect BoundingBox;

			public WeatherTriangle(WeatherNode a, WeatherNode b, WeatherNode c)
			{
				Points = new WeatherNode[3] { a, b, c };
				BoundingBox.xMin = Mathf.Min(a.Coord.x, b.Coord.x, c.Coord.x);
				BoundingBox.yMin = Mathf.Min(a.Coord.y, b.Coord.y, c.Coord.y);
				BoundingBox.xMax = Mathf.Max(a.Coord.x, b.Coord.x, c.Coord.x);
				BoundingBox.yMax = Mathf.Max(a.Coord.y, b.Coord.y, c.Coord.y);
			}

			public WeatherNode GetClosest(Vector2 point)
			{
				int num = 0;
				float num2 = (point - Points[num].Coord).sqrMagnitude;
				for (int i = 1; i < 3; i++)
				{
					float sqrMagnitude = (point - Points[i].Coord).sqrMagnitude;
					if (sqrMagnitude < num2)
					{
						num2 = sqrMagnitude;
						num = i;
					}
				}
				return Points[num];
			}
		}

		private const int TIME_JUMP_SIM_STEPS = 36;

		private const float TIME_JUMP_SIM_HOUR_INTERVAL = 0.25f;

		private const float DAY_START_TIME = 5f / 24f;

		private const float DAY_END_TIME = 0.875f;

		[Header("Weather cycle")]
		public float fogCycle = 5f;

		public float cloudCycle = 5f;

		public float windCycle = 5f;

		public float speedMultiplier = 1f;

		public float fogAmplitude = 1f;

		public float cloudAmplitude = 1f;

		[Header("Rain")]
		public Vector2 rainRangeStart = new Vector2(0.5f, 0.5f);

		public Vector2 rainRangeMax = new Vector2(0.75f, 0.75f);

		public float rainFogWeight = 0.5f;

		public float rainCloudWeight = 0.5f;

		public float rainCycle = 5f;

		public float rainNoiseAmplitude = 0.25f;

		public float dryingLengthMin = 2f;

		public float dryingLengthMax = 8f;

		[Header("Thunder")]
		public Vector2 thunderRangeStart = new Vector2(0.5f, 0.5f);

		public Vector2 thunderRangeMax = new Vector2(0.75f, 0.75f);

		public float thunderCycle = 5f;

		public float thunderNoiseAmplitude = 0.25f;

		public float thunderMaxValue = 0.6f;

		[Header("Fog bump")]
		public bool enableFogBump = true;

		public float fogBumpStart = 5.5f;

		public float fogBumpEnd = 6.5f;

		public float fogBumpAmplitude = 0.15f;

		[Header("Fog zones")]
		public float fogZoneTransitionLength = 25f;

		public bool useGlobalZoneTransition;

		public float globalZoneLow = 500f;

		public float globalZoneHigh = 1000f;

		[Header("Midpoints")]
		public bool fogUseMedian = true;

		public bool cloudsUseMedian = true;

		[Header("Relax/repulse")]
		public int repulseIterations = 10;

		public float repulseForce = 0.02f;

		[Header("Volumetric")]
		public AnimationCurve volumetricnessInFog;

		[Header("Debug")]
		public bool showVisualization;

		public bool overridePoint;

		public Vector2 overriddenPoint = new Vector2(0.5f, 0.5f);

		public bool applyFogBumpToOverride;

		public Weather24hPresetSO presetOverride;

		public bool alwaysUpdateNodes;

		public const string TOD_SAVE_KEY = "OADate";

		private const string WEATHER_OFFSET = "WeatherOffset";

		private const string WETNESS_KEY = "Wetness";

		private const string STARTING_WEATHER_START_KEY = "StartingWeatherTransitionStart";

		private const string STARTING_WEATHER_END_KEY = "StartingWeatherTransitionEnd";

		private const string STARTING_WEATHER_X_KEY = "StartingWeatherX";

		private const string STARTING_WEATHER_Y_KEY = "StartingWeatherY";

		private const string STARTING_WEATHER_RAIN_KEY = "StartingWeatherRain";

		private const string STARTING_WEATHER_THUNDER_KEY = "StartingWeatherThunder";

		private const string STARTING_WEATHER_WETNESS_KEY = "StartingWeatherWetness";

		private const string OVERRIDES_KEY = "Overrides";

		public WeatherPresetManager manager;

		public WeatherPackSO pack;

		public TOD_Animation todAnimation;

		public float weatherSeed;

		[NonSerialized]
		public float? speedMultiplierOverride;

		private List<WeatherNode> weatherNodes;

		private List<WeatherTriangle> weatherTriangles;

		private bool wasRainOverridden;

		private bool wasWetnessOverridden;

		private WeatherStateChungus s_ = new WeatherStateChungus(0f, 0f, 0f, 0f, 0f, new Vector2(0.5f, 0.5f), null, new WeatherSnapshot(), new WeatherSnapshot(), startingWeatherEnabled: false, 0f, 0f, Vector2.zero);

		private WeatherSnapshot cameraSubjectiveSnapshot = new WeatherSnapshot();

		private Weather24hPresetSO lastOverride;

		private float oldRainValue;

		private Vector3 viewPosition = Vector3.zero;

		private WeatherGameParams gameParams;

		private WeatherSnapshot _tempSnapshot_low = new WeatherSnapshot();

		private WeatherSnapshot _tempSnapshot_high = new WeatherSnapshot();

		private WeatherSnapshot _tempSnapshotA_low = new WeatherSnapshot();

		private WeatherSnapshot _tempSnapshotB_low = new WeatherSnapshot();

		private WeatherSnapshot _tempSnapshotA_high = new WeatherSnapshot();

		private WeatherSnapshot _tempSnapshotB_high = new WeatherSnapshot();

		public WeatherPackSO Pack
		{
			get
			{
				return pack;
			}
			set
			{
				pack = value;
			}
		}

		public WeatherStateChungus CurrentChungusState => s_;

		public WeatherSnapshot CameraSubjectiveSnapshot => cameraSubjectiveSnapshot;

		public Weather24hPresetSO CurrentPreset => s_.closestPreset;

		public OverridableValue<float> RainValue => s_.rainValue;

		public OverridableValue<float> WetnessValue => s_.wetnessValue;

		public OverridableValue<float> ThunderValue => s_.thunderValue;

		public OverridableValue<float> WindDirection => s_.windDirection;

		public OverridableValue<float> TimeOfDayHours => manager.TimeOfDayHours;

		public OverridableValue<float> DayLengthInMinutes => manager.DayLengthInMinutes;

		public OverridableValue<float> WeatherPointX => s_.noisePointX;

		public OverridableValue<float> WeatherPointY => s_.noisePointY;

		public bool IsLightningFlashing
		{
			get
			{
				if (!(THOR_Thunderstorm.instance != null))
				{
					return false;
				}
				return THOR_Thunderstorm.instance.lightIsActive;
			}
		}

		public OverridableValue<float> WindSpeed => todAnimation.WindSpeed;

		public bool IsDay => Mathf.Repeat(ManagedDateTime, 1f).IsInRange(5f / 24f, 0.875f);

		public bool IsRaining => (float)RainValue > 0f;

		public float ManagedDateTime => GetLinearTime(manager.DateTime);

		public float GlobalSunIntensityFactor => ComputeGlobalSunIntensityFactor(manager.timeOfDay, s_.currentLow.OverallFogginess);

		public bool IsPresetOverridden => presetOverride != null;

		public event Action OnRainStart;

		public event Action OnRainStop;

		public event Action OnDataLoaded;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Initialize()
		{
			base.Initialize();
			if (weatherSeed == 0f)
			{
				weatherSeed = UnityEngine.Random.Range(0f, 1000f);
			}
			if (pack == null)
			{
				Debug.LogWarning("WeatherDriver doesn't have a weather pack assigned, disabling self");
				base.enabled = false;
				return;
			}
			if (pack.presets.Length == 0)
			{
				Debug.LogWarning("WeatherDriver assigned weather pack has no presets, disabling self");
				base.enabled = false;
				return;
			}
			pack.Validate();
			ComputeWeatherNodes();
			lastOverride = presetOverride;
			UpdateWeather(ManagedDateTime);
			UpdateWetnessDeltaTime(0f);
			if ((bool)todAnimation)
			{
				todAnimation.WindDegrees = WindDirection;
			}
			manager.TimeJump += OnTimeJump;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			manager.TimeJump -= OnTimeJump;
			if (gameParams != null)
			{
				gameParams.DayLengthChanged -= OnGameParamsDayLengthChanged;
			}
		}

		private void Start()
		{
			Transform obj = THOR_Thunderstorm.instance.transform;
			obj.parent = null;
			obj.localScale = Vector3.one;
			obj.position = Vector3.zero;
		}

		public void SetGameParams(WeatherGameParams paramsToSet)
		{
			if (gameParams != null)
			{
				gameParams.DayLengthChanged -= OnGameParamsDayLengthChanged;
			}
			gameParams = paramsToSet;
			if (gameParams != null)
			{
				OnGameParamsDayLengthChanged();
				gameParams.DayLengthChanged += OnGameParamsDayLengthChanged;
			}
		}

		public void SetStartingWeather(DateTime startingWeatherExpiration, TimeSpan startingWeatherFadeout, Vector2 startingWeatherPoint, float startingWeatherRain, float startingWeatherThunder, float startingWeatherWetness)
		{
			s_.startingWeatherEnabled = true;
			s_.startingWeatherTransitionStart = GetLinearTime(startingWeatherExpiration);
			s_.startingWeatherTransitionEnd = ((startingWeatherExpiration == DateTime.MaxValue) ? (s_.startingWeatherTransitionStart + 1f) : GetLinearTime(startingWeatherExpiration + startingWeatherFadeout));
			s_.startingWeatherNoisePoint = startingWeatherPoint;
			s_.startingWeatherRain = startingWeatherRain;
			s_.startingWeatherThunder = startingWeatherThunder;
			s_.startingWeatherWetness = startingWeatherWetness;
		}

		public void ResetStartingWeather()
		{
			s_.startingWeatherEnabled = false;
			s_.startingWeatherTransitionStart = (s_.startingWeatherTransitionEnd = 0f);
			s_.startingWeatherNoisePoint = Vector2.zero;
			s_.startingWeatherRain = (s_.startingWeatherThunder = (s_.startingWeatherWetness = 0f));
		}

		private void OnGameParamsDayLengthChanged()
		{
			manager.DayLengthInMinutes.RealValue = gameParams.DayLengthInMinutes;
		}

		public static float GetLinearTime(DateTime dateTime)
		{
			return (float)(dateTime - new DateTime(2000, 1, 1)).TotalDays;
		}

		public void SimulateWeatherToTime(float dateTime, ref WeatherStateChungus state)
		{
			state.dateTime = dateTime;
			float num = speedMultiplier;
			if (gameParams != null)
			{
				num *= gameParams.SpeedModifier;
			}
			if (speedMultiplierOverride.HasValue)
			{
				num = speedMultiplierOverride.Value * (gameParams?.SpeedModifier ?? 1f);
			}
			if (overridePoint)
			{
				state.noisePointX.EngageOverride(overriddenPoint.x);
				state.noisePointY.EngageOverride(overriddenPoint.y);
			}
			else if (presetOverride != null)
			{
				WeatherNode weatherNode = null;
				for (int i = 0; i < weatherNodes.Count; i++)
				{
					if (weatherNodes[i].Preset == presetOverride)
					{
						weatherNode = weatherNodes[i];
						break;
					}
				}
				if (weatherNode != null)
				{
					state.noisePointX.EngageOverride(weatherNode.Coord.x);
					state.noisePointY.EngageOverride(weatherNode.Coord.y);
				}
			}
			else
			{
				state.noisePointX.RealValue = 0.5f + fogAmplitude * (Mathf.PerlinNoise(state.dateTime * fogCycle * num, weatherSeed) - 0.5f);
				state.noisePointY.RealValue = 0.5f + cloudAmplitude * (Mathf.PerlinNoise(weatherSeed, state.dateTime * cloudCycle * num) - 0.5f);
				state.noisePointX.RealValue = Mathf.Lerp(state.noisePoint.x, state.startingWeatherNoisePoint.x, state.StartingWeatherFactor);
				state.noisePointY.RealValue = Mathf.Lerp(state.noisePoint.y, state.startingWeatherNoisePoint.y, state.StartingWeatherFactor);
			}
			float num2 = Mathf.Repeat(state.dateTime, 1f);
			if (enableFogBump && (!overridePoint || applyFogBumpToOverride) && num > 0f)
			{
				float value = num2 * 24f;
				float num3 = Mathf.InverseLerp(fogBumpStart, fogBumpEnd, value);
				state.noisePointX.RealValue += (Mathf.Sin((num3 - 0.25f) * (float)Math.PI * 2f) * 0.5f + 0.5f) * fogBumpAmplitude * (1f - state.StartingWeatherFactor);
			}
			state.noisePointX.CurrentValue = Mathf.Clamp(state.noisePointX.CurrentValue, 0.01f, 0.99f);
			state.noisePointY.CurrentValue = Mathf.Clamp(state.noisePointY.CurrentValue, 0.01f, 0.99f);
			state.windDirection.RealValue = Mathf.Repeat(Mathf.PerlinNoise(state.dateTime * windCycle * num, weatherSeed + 100f) * 360f, 360f);
			float num4 = Mathf.InverseLerp(rainRangeStart.x, rainRangeMax.x, state.noisePoint.x);
			float num5 = Mathf.InverseLerp(rainRangeStart.y, rainRangeMax.y, state.noisePoint.y);
			state.rainValue.RealValue = ((gameParams != null && !gameParams.RainAllowed) ? 0f : Mathf.Clamp01((num4 * rainFogWeight + num5 * rainCloudWeight) * (1f + (Mathf.PerlinNoise(state.dateTime * rainCycle * num, weatherSeed + 150f) - 0.5f) * rainNoiseAmplitude)));
			state.rainValue.RealValue = Mathf.Lerp(state.rainValue.RealValue, state.startingWeatherRain, state.StartingWeatherFactor);
			float a = Mathf.InverseLerp(thunderRangeStart.x, thunderRangeMax.x, state.noisePoint.x);
			float b = Mathf.InverseLerp(thunderRangeStart.y, thunderRangeMax.y, state.noisePoint.y);
			state.thunderValue.RealValue = ((gameParams != null && !gameParams.ThunderAllowed) ? 0f : (thunderMaxValue * Mathf.Clamp01(Mathf.Min(a, b) * (1f + (Mathf.PerlinNoise(state.dateTime * thunderCycle * num, weatherSeed + 250f) - 0.5f) * thunderNoiseAmplitude))));
			state.thunderValue.RealValue = Mathf.Lerp(state.thunderValue.RealValue, state.startingWeatherThunder, state.StartingWeatherFactor);
			if (state.currentLow == null)
			{
				state.currentLow = new WeatherSnapshot();
			}
			if (state.currentHigh == null)
			{
				state.currentHigh = new WeatherSnapshot();
			}
			if (presetOverride == null)
			{
				(WeatherTriangle triangle, Vector3 baryPoint) triangleForPoint = GetTriangleForPoint(state.noisePoint);
				WeatherTriangle item = triangleForPoint.triangle;
				Vector3 item2 = triangleForPoint.baryPoint;
				state.closestPreset = item.GetClosest(state.noisePoint).Preset;
				InterpolateInTriangle(item, item2, num2, state.currentLow, state.currentHigh);
			}
			else
			{
				state.closestPreset = presetOverride;
				var (weatherSnapshot, weatherSnapshot2) = presetOverride.GetPairForTime(num2);
				var (weatherSnapshot3, weatherSnapshot4) = presetOverride.HighZoneOrDefault.GetPairForTime(num2);
				WeatherSnapshotLerp.Lerp(weatherSnapshot, weatherSnapshot2, WeatherPresetLerp.InverseLerpTime(weatherSnapshot.startTime, weatherSnapshot2.startTime, num2), state.currentLow);
				WeatherSnapshotLerp.Lerp(weatherSnapshot3, weatherSnapshot4, WeatherPresetLerp.InverseLerpTime(weatherSnapshot3.startTime, weatherSnapshot4.startTime, num2), state.currentHigh);
			}
		}

		private void UpdateWeather(float dateTime)
		{
			SimulateWeatherToTime(dateTime, ref s_);
			if ((float)RainValue != 0f && oldRainValue == 0f)
			{
				this.OnRainStart?.Invoke();
			}
			else if ((float)RainValue == 0f && oldRainValue != 0f)
			{
				this.OnRainStop?.Invoke();
			}
			oldRainValue = RainValue;
			if ((bool)THOR_Thunderstorm.instance)
			{
				THOR_Thunderstorm.instance.probability = ThunderValue;
			}
			RainRipples.rainAmount = RainValue;
			RainRipples.wetness = WetnessValue;
		}

		private static (Vector2 min, Vector2 max, Vector2 avg, Vector2 med) ComputeRanges(List<WeatherNode> nodes)
		{
			Vector2 zero = Vector2.zero;
			List<float> list = new List<float>();
			List<float> list2 = new List<float>();
			Vector2 coord;
			Vector2 item = (coord = nodes[0].Coord);
			for (int i = 0; i < nodes.Count; i++)
			{
				item.x = Mathf.Min(item.x, nodes[i].Coord.x);
				item.y = Mathf.Min(item.y, nodes[i].Coord.y);
				coord.x = Mathf.Max(coord.x, nodes[i].Coord.x);
				coord.y = Mathf.Max(coord.y, nodes[i].Coord.y);
				list.Add(nodes[i].Coord.x);
				list2.Add(nodes[i].Coord.y);
				zero += nodes[i].Coord;
			}
			zero /= (float)nodes.Count;
			list.Sort();
			list2.Sort();
			Vector2 item2 = default(Vector2);
			if (list.Count % 2 == 0)
			{
				item2.x = (list[list.Count / 2 - 1] + list[list.Count / 2]) * 0.5f;
				item2.y = (list2[list2.Count / 2 - 1] + list2[list2.Count / 2]) * 0.5f;
			}
			else
			{
				item2.x = list[list.Count / 2];
				item2.y = list2[list2.Count / 2];
			}
			return (min: item, max: coord, avg: zero, med: item2);
		}

		private WeatherNode FindClosestTo(List<WeatherNode> nodes, Vector2 point)
		{
			WeatherNode result = nodes[0];
			float num = (nodes[0].Coord - point).sqrMagnitude;
			for (int i = 1; i < nodes.Count; i++)
			{
				float sqrMagnitude = (nodes[i].Coord - point).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					result = nodes[i];
					num = sqrMagnitude;
				}
			}
			return result;
		}

		private void ComputeWeatherNodes()
		{
			weatherNodes = new List<WeatherNode>();
			Weather24hPresetSO[] presets = pack.presets;
			foreach (Weather24hPresetSO preset in presets)
			{
				weatherNodes.Add(new WeatherNode(preset));
			}
			(Vector2 min, Vector2 max, Vector2 avg, Vector2 med) tuple = ComputeRanges(weatherNodes);
			Vector2 item = tuple.min;
			Vector2 item2 = tuple.max;
			Vector2 item3 = tuple.avg;
			Vector2 item4 = tuple.med;
			float num = (fogUseMedian ? item4.x : item3.x);
			float num2 = (cloudsUseMedian ? item4.y : item3.y);
			foreach (WeatherNode weatherNode3 in weatherNodes)
			{
				weatherNode3.Coord.x = ((weatherNode3.Coord.x >= num) ? (Mathf.InverseLerp(num, item2.x, weatherNode3.Coord.x) * 0.5f + 0.5f) : (Mathf.InverseLerp(item.x, num, weatherNode3.Coord.x) * 0.5f));
				weatherNode3.Coord.y = ((weatherNode3.Coord.y >= num2) ? (Mathf.InverseLerp(num2, item2.y, weatherNode3.Coord.y) * 0.5f + 0.5f) : (Mathf.InverseLerp(item.y, num2, weatherNode3.Coord.y) * 0.5f));
			}
			for (int j = 0; j < repulseIterations; j++)
			{
				RepulseNodes(weatherNodes, repulseForce);
			}
			foreach (WeatherNode weatherNode4 in weatherNodes)
			{
				if (weatherNode4.Preset.absoluteOffset)
				{
					weatherNode4.Coord = weatherNode4.Preset.manualOffset;
				}
				else
				{
					weatherNode4.Coord += weatherNode4.Preset.manualOffset;
				}
			}
			Vector2[] array = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f)
			};
			foreach (Vector2 vector in array)
			{
				WeatherNode weatherNode = FindClosestTo(weatherNodes, vector);
				if (weatherNode.Coord != vector)
				{
					WeatherNode weatherNode2 = new WeatherNode(weatherNode.Preset);
					weatherNode2.Coord = vector;
					weatherNodes.Add(weatherNode2);
				}
			}
			IPoint[] points = weatherNodes.ToArray();
			Delaunator delaunator = new Delaunator(points);
			weatherTriangles = new List<WeatherTriangle>();
			for (int k = 0; k < delaunator.Triangles.Length; k += 3)
			{
				weatherTriangles.Add(new WeatherTriangle(weatherNodes[delaunator.Triangles[k]], weatherNodes[delaunator.Triangles[k + 1]], weatherNodes[delaunator.Triangles[k + 2]]));
			}
		}

		private void RepulseNodes(List<WeatherNode> nodes, float force)
		{
			Vector2[] array = new Vector2[nodes.Count];
			for (int i = 0; i < nodes.Count - 1; i++)
			{
				for (int j = i + 1; j < nodes.Count; j++)
				{
					Vector2 vector = nodes[j].Coord - nodes[i].Coord;
					float magnitude = vector.magnitude;
					if (!(magnitude <= 0.001f) && !(magnitude > 1f))
					{
						float num = force * Mathf.Pow(1f - magnitude, 3f);
						vector /= magnitude;
						array[i] -= vector * num;
						array[j] += vector * num;
					}
				}
			}
			for (int k = 0; k < nodes.Count; k++)
			{
				nodes[k].Coord.x = Mathf.Clamp01(nodes[k].Coord.x + array[k].x);
				nodes[k].Coord.y = Mathf.Clamp01(nodes[k].Coord.y + array[k].y);
			}
		}

		private (WeatherTriangle triangle, Vector3 baryPoint) GetTriangleForPoint(Vector2 point)
		{
			point.x = Mathf.Clamp01(point.x);
			point.y = Mathf.Clamp01(point.y);
			WeatherTriangle weatherTriangle = weatherTriangles[0];
			Vector3 item = VectorUtils.GetBarycentricCoordinates(point, weatherTriangle.Points[0].Coord, weatherTriangle.Points[1].Coord, weatherTriangle.Points[2].Coord);
			foreach (WeatherTriangle weatherTriangle2 in weatherTriangles)
			{
				if (weatherTriangle2.BoundingBox.Contains(point))
				{
					Vector3 barycentricCoordinates = VectorUtils.GetBarycentricCoordinates(point, weatherTriangle2.Points[0].Coord, weatherTriangle2.Points[1].Coord, weatherTriangle2.Points[2].Coord);
					if (VectorUtils.IsPointInTriangle(barycentricCoordinates))
					{
						return (triangle: weatherTriangle2, baryPoint: barycentricCoordinates);
					}
					weatherTriangle = weatherTriangle2;
					item = barycentricCoordinates;
				}
			}
			return (triangle: weatherTriangle, baryPoint: item);
		}

		private void InterpolateInTriangle(WeatherTriangle triangle, Vector3 bary, float timeOfDay, WeatherSnapshot resultLow = null, WeatherSnapshot resultHigh = null)
		{
			if (resultLow == null)
			{
				resultLow = new WeatherSnapshot();
			}
			if (resultHigh == null)
			{
				resultHigh = new WeatherSnapshot();
			}
			WeatherPresetLerp.Lerp(triangle.Points[0].Preset, triangle.Points[1].Preset, timeOfDay, bary.y / (bary.x + bary.y), highZone: false, _tempSnapshot_low, _tempSnapshotA_low, _tempSnapshotB_low);
			WeatherPresetLerp.Lerp(triangle.Points[0].Preset, triangle.Points[1].Preset, timeOfDay, bary.y / (bary.x + bary.y), highZone: true, _tempSnapshot_high, _tempSnapshotA_high, _tempSnapshotB_high);
			WeatherPresetLerp.Lerp(_tempSnapshot_low, triangle.Points[2].Preset, timeOfDay, bary.z, highZone: false, resultLow, _tempSnapshotB_low);
			WeatherPresetLerp.Lerp(_tempSnapshot_high, triangle.Points[2].Preset, timeOfDay, bary.z, highZone: true, resultHigh, _tempSnapshotB_high);
		}

		public float GetFogZoneFactor(Vector3 position)
		{
			if (useGlobalZoneTransition)
			{
				return Mathf.Clamp01(Mathf.InverseLerp(globalZoneLow, globalZoneHigh, position.y));
			}
			return Mathf.Clamp01(Mathf.InverseLerp(s_.currentLow.fogHeight - fogZoneTransitionLength, s_.currentLow.fogHeight, position.y));
		}

		public float GetLocalFogZoneFactor()
		{
			return GetFogZoneFactor(viewPosition);
		}

		public float GetLocalFogDensity()
		{
			return Mathf.Lerp(s_.currentLow.OverallFogDensity, s_.currentHigh.OverallFogDensity, GetLocalFogZoneFactor());
		}

		public float GetFogDensity(Vector3 position)
		{
			return Mathf.Lerp(s_.currentLow.OverallFogDensity, s_.currentHigh.OverallFogDensity, GetFogZoneFactor(position));
		}

		public float GetVolumetricness(Vector3 position)
		{
			return volumetricnessInFog.Evaluate(GetFogDensity(position));
		}

		public float GetLocalFogginess()
		{
			return Mathf.Lerp(s_.currentLow.OverallFogginess, s_.currentHigh.OverallFogginess, GetLocalFogZoneFactor());
		}

		public float GetFogginess(Vector3 position)
		{
			return Mathf.Lerp(s_.currentLow.OverallFogginess, s_.currentHigh.OverallFogginess, GetFogZoneFactor(position));
		}

		private void OnValidate()
		{
			if (!(pack == null))
			{
				ComputeWeatherNodes();
				UpdateWeather(ManagedDateTime);
			}
		}

		private void OnTimeJump()
		{
			float num = ManagedDateTime - 0.375f;
			s_.wetnessValue.RealValue = 0f;
			for (int i = 0; i < 36; i++)
			{
				float timeOfDay = Mathf.Repeat(num, 1f);
				UpdateWeather(num);
				PositionalUpdate();
				float sunlightFactor = ComputeGlobalSunIntensityFactor(timeOfDay, s_.currentLow.OverallFogginess);
				UpdateWetnessHours(0.25f, sunlightFactor);
				num += 1f / 96f;
			}
		}

		private void Update()
		{
			if (lastOverride != presetOverride)
			{
				lastOverride = presetOverride;
				s_.rainValue.RealValue = 0f;
				s_.wetnessValue.RealValue = 0f;
				s_.thunderValue.RealValue = 0f;
			}
			if ((wasRainOverridden && !s_.rainValue.IsOverridden) || (wasWetnessOverridden && !s_.wetnessValue.IsOverridden))
			{
				OnTimeJump();
			}
			else
			{
				UpdateWeather(ManagedDateTime);
				PositionalUpdate();
				UpdateWetnessDeltaTime(Time.deltaTime);
			}
			wasRainOverridden = s_.rainValue.IsOverridden;
			wasWetnessOverridden = s_.wetnessValue.IsOverridden;
		}

		public void PositionalUpdate()
		{
			if (Camera.main != null)
			{
				viewPosition = Camera.main.transform.position;
			}
			WeatherSnapshotLerp.Lerp(s_.currentLow, s_.currentHigh, GetFogZoneFactor(viewPosition), cameraSubjectiveSnapshot);
			manager.SetSnapshot(cameraSubjectiveSnapshot, CurrentPreset);
			if ((bool)todAnimation)
			{
				todAnimation.WindDegrees = WindDirection;
			}
		}

		private void UpdateWetnessDeltaTime(float deltaTime)
		{
			float num = 1440f / (float)manager.DayLengthInMinutes;
			float hours = deltaTime * num / 3600f;
			UpdateWetnessHours(hours, GlobalSunIntensityFactor);
		}

		private void UpdateWetnessHours(float hours, float sunlightFactor)
		{
			if (s_.wetnessValue.RealValue < s_.rainValue.CurrentValue)
			{
				s_.wetnessValue.RealValue = s_.rainValue.CurrentValue;
			}
			else
			{
				s_.wetnessValue.RealValue = Mathf.Clamp01((float)s_.wetnessValue - hours * (1f / Mathf.Lerp(dryingLengthMax, dryingLengthMin, sunlightFactor)));
			}
			s_.wetnessValue.RealValue = Mathf.Lerp(s_.wetnessValue.RealValue, Mathf.Max(s_.rainValue, s_.startingWeatherWetness), s_.StartingWeatherFactor);
		}

		private float ComputeGlobalSunIntensityFactor(float timeOfDay, float fogginess)
		{
			return Mathf.Sin(Mathf.InverseLerp(5f / 24f, 0.875f, timeOfDay) * (float)Math.PI) * (1f - fogginess * 0.7f);
		}

		public void SetPreset(int presetIndex)
		{
			presetIndex = Mathf.Clamp(presetIndex, 0, pack.presets.Length);
			presetOverride = pack.presets[presetIndex];
		}

		public void SetPreset(Weather24hPresetSO preset)
		{
			presetOverride = preset;
		}

		public void ChangePreset(bool next)
		{
			if (s_.closestPreset == null)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < pack.presets.Length; i++)
			{
				if (pack.presets[i] == s_.closestPreset)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				num = ((!next) ? (num - 1) : (num + 1));
				num %= pack.presets.Length;
				if (num < 0)
				{
					num += pack.presets.Length;
				}
				presetOverride = pack.presets[num];
			}
		}

		public JObject GetSaveData(bool packOverrides)
		{
			JObject jObject = new JObject();
			jObject.SetDouble("OADate", manager.RealDateTime.ToOADate());
			jObject.SetFloat("WeatherOffset", weatherSeed);
			jObject.SetFloat("Wetness", s_.wetnessValue.RealValue);
			if (s_.startingWeatherEnabled)
			{
				jObject.SetFloat("StartingWeatherTransitionStart", s_.startingWeatherTransitionStart);
				jObject.SetFloat("StartingWeatherTransitionEnd", s_.startingWeatherTransitionEnd);
				jObject.SetFloat("StartingWeatherX", s_.startingWeatherNoisePoint.x);
				jObject.SetFloat("StartingWeatherY", s_.startingWeatherNoisePoint.y);
				jObject.SetFloat("StartingWeatherRain", s_.startingWeatherRain);
				jObject.SetFloat("StartingWeatherThunder", s_.startingWeatherThunder);
				jObject.SetFloat("StartingWeatherWetness", s_.startingWeatherWetness);
			}
			if (packOverrides)
			{
				OverridablePreset<WeatherDriver> o = new OverridablePreset<WeatherDriver>(this);
				jObject.SetJObject("Overrides", JObject.FromObject(o));
			}
			return jObject;
		}

		public void LoadSaveData(JObject data, bool useOverrides)
		{
			double? num = data.GetDouble("OADate");
			float? num2 = data.GetFloat("WeatherOffset");
			float? num3 = data.GetFloat("Wetness");
			float? num4 = data.GetFloat("StartingWeatherTransitionStart");
			float? num5 = data.GetFloat("StartingWeatherTransitionEnd");
			float? num6 = data.GetFloat("StartingWeatherX");
			float? num7 = data.GetFloat("StartingWeatherY");
			float? num8 = data.GetFloat("StartingWeatherRain");
			float? num9 = data.GetFloat("StartingWeatherThunder");
			float? num10 = data.GetFloat("StartingWeatherWetness");
			if (num2.HasValue)
			{
				weatherSeed = num2.Value;
			}
			else
			{
				weatherSeed = UnityEngine.Random.Range(0f, 1000f);
			}
			if (num.HasValue)
			{
				manager.todSky.Cycle.RealDateTime = DateTime.FromOADate(num.Value);
			}
			else
			{
				Debug.LogError("Unexpected state: Time and date data is empty");
			}
			if (num3.HasValue)
			{
				s_.wetnessValue.RealValue = num3.Value;
			}
			else
			{
				s_.wetnessValue.RealValue = 0f;
			}
			if (num4.HasValue && num5.HasValue && num6.HasValue && num7.HasValue && num8.HasValue && num9.HasValue && num10.HasValue)
			{
				s_.startingWeatherEnabled = true;
				s_.startingWeatherTransitionStart = num4.Value;
				s_.startingWeatherTransitionEnd = num5.Value;
				s_.startingWeatherNoisePoint = new Vector2(num6.Value, num7.Value);
				s_.startingWeatherRain = num8.Value;
				s_.startingWeatherThunder = num9.Value;
				s_.startingWeatherWetness = num10.Value;
			}
			else
			{
				ResetStartingWeather();
			}
			JObject jObject = data.GetJObject("Overrides");
			if (useOverrides && jObject != null)
			{
				jObject.ToObject<OverridablePreset<WeatherDriver>>().ApplyTo(this);
			}
			else
			{
				BaseOverridablePreset<WeatherDriver>.ClearAllOverridesOn(this);
			}
			this.OnDataLoaded?.Invoke();
		}

		private void OnGUI()
		{
			if (!showVisualization)
			{
				return;
			}
			float num = 300f;
			float num2 = 7f;
			float num3 = 5f;
			float num4 = 3f;
			GUI.BeginGroup(new Rect(new Vector2((float)Screen.width - num, 0f), new Vector2(num, num + 30f)));
			GUI.color = new Color(0f, 0f, 0f, 0.5f);
			GUI.DrawTexture(Rect.MinMaxRect(0f, 0f, num, num), Texture2D.whiteTexture);
			GUI.color = new Color(0f, 0f, 0f, 0.6f);
			GUI.DrawTexture(Rect.MinMaxRect(0f, num, num, num + 20f), Texture2D.whiteTexture);
			GUI.color = new Color(0f, 0f, 1f, 0.75f);
			GUI.DrawTexture(Rect.MinMaxRect(0f, num, num * (float)s_.rainValue, num + 15f), Texture2D.whiteTexture);
			GUI.color = new Color(0f, 0.5f, 1f, 0.75f);
			GUI.DrawTexture(Rect.MinMaxRect(0f, num + 15f, num * (float)s_.wetnessValue, num + 20f), Texture2D.whiteTexture);
			GUI.color = new Color(1f, 1f, 0f, 0.75f);
			GUI.DrawTexture(Rect.MinMaxRect(0f, num + 20f, num * (float)s_.thunderValue, num + 25f), Texture2D.whiteTexture);
			GUI.color = new Color(1f, 0.75f, 0f, 0.75f);
			GUI.DrawTexture(Rect.MinMaxRect(0f, num + 25f, num * GlobalSunIntensityFactor, num + 30f), Texture2D.whiteTexture);
			GUI.color = new Color(0f, 0f, 0.5f, 0.1f);
			GUI.DrawTexture(Rect.MinMaxRect(rainRangeStart.x * num, rainRangeStart.y * num, num, num), Texture2D.whiteTexture);
			GUI.color = new Color(0f, 0f, 1f, 0.1f);
			GUI.DrawTexture(Rect.MinMaxRect(rainRangeMax.x * num, rainRangeMax.y * num, num, num), Texture2D.whiteTexture);
			GUI.color = new Color(0.5f, 0.5f, 0f, 0.1f);
			GUI.DrawTexture(Rect.MinMaxRect(thunderRangeStart.x * num, thunderRangeStart.y * num, num, num), Texture2D.whiteTexture);
			GUI.color = new Color(1f, 1f, 0f, 0.1f);
			GUI.DrawTexture(Rect.MinMaxRect(thunderRangeMax.x * num, thunderRangeMax.y * num, num, num), Texture2D.whiteTexture);
			GUI.color = new Color(1f, 0f, 1f, 0.5f);
			for (int i = 0; i < weatherNodes.Count; i++)
			{
				if (weatherNodes[i].Preset == s_.closestPreset)
				{
					Vector2 vector = weatherNodes[i].Coord * num;
					GUI.DrawTexture(Rect.MinMaxRect(vector.x - num2, vector.y - num2, vector.x + num2, vector.y + num2), Texture2D.whiteTexture);
				}
			}
			GUI.color = new Color(1f, 0f, 0f, 0.5f);
			for (int j = 0; j < weatherNodes.Count; j++)
			{
				Vector2 vector2 = weatherNodes[j].Coord * num;
				GUI.DrawTexture(Rect.MinMaxRect(vector2.x - num3, vector2.y - num3, vector2.x + num3, vector2.y + num3), Texture2D.whiteTexture);
			}
			GUI.color = ((overridePoint && Time.realtimeSinceStartup - Mathf.Floor(Time.realtimeSinceStartup) > 0.5f) ? Color.black : new Color(1f, 1f, 0f, 1f));
			Vector2 vector3 = s_.noisePoint * num;
			GUI.DrawTexture(Rect.MinMaxRect(vector3.x - num4, vector3.y - num4, vector3.x + num4, vector3.y + num4), Texture2D.whiteTexture);
			GUI.color = new Color(1f, 1f, 0.5f, 1f);
			Vector2 mousePosition = Event.current.mousePosition;
			GUI.DrawTexture(Rect.MinMaxRect(mousePosition.x - num4, mousePosition.y - num4, mousePosition.x + num4, mousePosition.y + num4), Texture2D.whiteTexture);
			if (Event.current.type == EventType.MouseDown)
			{
				overridePoint = true;
				overriddenPoint = mousePosition / num;
			}
			if (Event.current.type == EventType.MouseUp && Event.current.button == 1)
			{
				overridePoint = false;
			}
			GUI.EndGroup();
		}
	}
}
