using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModApi.Planet.Modifiers.VertexData;

namespace ModApi.Planet.Modifiers.Profiling
{
	public class PlanetModifierProfiler
	{
		private readonly object _lock = new object();

		private Dictionary<ModifierProfilerKey, ModifierProfilerData> _data;

		private long _totalExecutionCount;

		private double _totalTime;

		public PlanetModifierProfiler(IPlanetTerrainData terrainData)
		{
			_data = new Dictionary<ModifierProfilerKey, ModifierProfilerData>();
			RegisterModifiers(terrainData.Modifiers);
			foreach (PlanetBiome biome in terrainData.Biomes)
			{
				RegisterModifiers(biome.Modifiers);
			}
		}

		public void BeginProfile(PlanetModifierProfilerThread thread, VertexDataPlanetModifier modifier, int executionCount)
		{
			ModifierProfilerKey? profilerKey = modifier.ProfilerKey;
			if (!profilerKey.HasValue)
			{
				thread.CurrentModifier = null;
				return;
			}
			ModifierProfilerData value = null;
			lock (_lock)
			{
				if (!_data.TryGetValue(profilerKey.Value, out value))
				{
					return;
				}
				value.ExecutionCount += executionCount;
				_totalExecutionCount += executionCount;
			}
			thread.CurrentModifier = value;
			thread.Stopwatch.Restart();
		}

		public void EndProfile(PlanetModifierProfilerThread thread)
		{
			if (thread.CurrentModifier == null)
			{
				return;
			}
			thread.Stopwatch.Stop();
			double totalMilliseconds = thread.Stopwatch.Elapsed.TotalMilliseconds;
			lock (_lock)
			{
				thread.CurrentModifier.ExecutionTime += totalMilliseconds;
				_totalTime += totalMilliseconds;
			}
		}

		public void GenerateReport(PlanetTerrainDataScript terrainData)
		{
			GenerateReport(terrainData.Modifiers);
			foreach (PlanetBiome biome in terrainData.Biomes)
			{
				GenerateReport(biome.Modifiers);
			}
			LogReport(terrainData);
		}

		private void GenerateReport(IEnumerable<PlanetModifier> modifiers)
		{
			foreach (PlanetModifier modifier in modifiers)
			{
				if (modifier is VertexDataPlanetModifier vertexDataPlanetModifier)
				{
					ModifierProfilerKey key = new ModifierProfilerKey(vertexDataPlanetModifier);
					if (_data.TryGetValue(key, out var value) && value.ExecutionCount > 0)
					{
						vertexDataPlanetModifier.ProfilerResults = new ModifierPerformanceData(_totalExecutionCount, _totalTime, value.ExecutionCount, value.ExecutionTime);
					}
					else
					{
						vertexDataPlanetModifier.ProfilerResults = null;
					}
				}
			}
		}

		private void LogReport(PlanetTerrainDataScript terrainData)
		{
			StringBuilder sb = new StringBuilder();
			Action<VertexDataPlanetModifierPassType, int> logModifiers = delegate(VertexDataPlanetModifierPassType pass, int biome)
			{
				List<VertexDataPlanetModifier> list;
				if (biome == -1)
				{
					list = (from x in terrainData.Modifiers.OfType<VertexDataPlanetModifier>()
						where x.Pass == pass && x.ProfilerResults != null
						select x).ToList();
					if (list.Count > 0)
					{
						sb.AppendLine($"{pass}");
					}
				}
				else
				{
					list = (from x in terrainData.Biomes[biome].Modifiers.OfType<VertexDataPlanetModifier>()
						where x.Pass == pass && x.ProfilerResults != null
						select x).ToList();
					if (list.Count > 0)
					{
						sb.AppendLine($"{pass} (Biomes) - {terrainData.Biomes[biome].Name}");
					}
				}
				foreach (VertexDataPlanetModifier item in list)
				{
					ModifierPerformanceData profilerResults = item.ProfilerResults;
					string text = ((item.Name.Length > 24) ? item.Name.Remove(24) : item.Name).PadRight(26);
					string text2 = (profilerResults.ExecutionTimePercentage.ToString("F2") + "%").PadLeft(8);
					string text3 = (profilerResults.ExecutionCountPercentage.ToString("F2") + "%").PadLeft(8);
					string text4 = (profilerResults.AverageExecutionTimeNanoSeconds.ToString("F2") + "ns").PadLeft(12);
					string text5 = ((long)profilerResults.TotalExecutionTimeNanoSeconds + "ns").PadLeft(16);
					sb.AppendLine("  " + text + text2 + text3 + text5 + text4);
				}
			};
			Action<VertexDataPlanetModifierPassType> action = delegate(VertexDataPlanetModifierPassType pass)
			{
				logModifiers(pass, -1);
			};
			Action<VertexDataPlanetModifierPassType> action2 = delegate(VertexDataPlanetModifierPassType pass)
			{
				for (int i = 0; i < terrainData.Biomes.Count; i++)
				{
					logModifiers(pass, i);
				}
			};
			sb.AppendLine("Modifier Profiler Result - " + terrainData.PlanetData.Name + " - " + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
			action(VertexDataPlanetModifierPassType.Biome);
			action(VertexDataPlanetModifierPassType.Height);
			action2(VertexDataPlanetModifierPassType.Height);
			action(VertexDataPlanetModifierPassType.HeightFinal);
			action(VertexDataPlanetModifierPassType.Final);
			action2(VertexDataPlanetModifierPassType.Final);
			action(VertexDataPlanetModifierPassType.Water);
			action2(VertexDataPlanetModifierPassType.Water);
		}

		private void RegisterModifiers(IEnumerable<PlanetModifier> modifiers)
		{
			foreach (PlanetModifier modifier in modifiers)
			{
				if (modifier is VertexDataPlanetModifier { Pass: not VertexDataPlanetModifierPassType.Water } vertexDataPlanetModifier)
				{
					ModifierProfilerKey modifierProfilerKey = new ModifierProfilerKey(vertexDataPlanetModifier);
					vertexDataPlanetModifier.ProfilerKey = modifierProfilerKey;
					_data[modifierProfilerKey] = new ModifierProfilerData(modifierProfilerKey);
				}
			}
		}
	}
}
