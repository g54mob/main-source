using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.Profiling;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	public abstract class VertexDataPlanetModifier : PlanetModifier
	{
		private class ModifierBenchmarkItem
		{
			public VertexDataPlanetModifier Modifier { get; private set; }

			public string Name { get; private set; }

			public double Percentage { get; set; }

			public Stopwatch Stopwatch { get; private set; }

			public double TotalTime { get; set; }

			public ModifierBenchmarkItem(VertexDataPlanetModifier modifier, string name)
			{
				Modifier = modifier;
				Name = name;
				Stopwatch = new Stopwatch();
			}
		}

		private static Dictionary<Type, List<(FieldInfo Field, DataSlotAttribute Attribute)>> _dataSlotsCache = new Dictionary<Type, List<(FieldInfo, DataSlotAttribute)>>();

		public abstract VertexDataPlanetModifierPassType Pass { get; }

		public ModifierProfilerKey? ProfilerKey { get; set; }

		public ModifierPerformanceData ProfilerResults { get; set; }

		public virtual VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[1] { Pass };

		public abstract VertexDataType VertexDataType { get; }

		protected VertexDataPlanetModifier()
			: base(PlanetModifierType.VertexData)
		{
		}

		[ContextMenu("Benchmark VertexDataPlanetModifiers")]
		public void BenchmarkVertexDataPlanetModifiers()
		{
			PlanetTerrainDataScript componentInParent = GetComponentInParent<PlanetTerrainDataScript>();
			if (componentInParent == null)
			{
				UnityEngine.Debug.LogError("Unable to find the PlanetTerrainDataScript");
				return;
			}
			if (!componentInParent.Initialized)
			{
				UnityEngine.Debug.LogError("The benchmark cannot be run without modifiers being initialized first. Try running in play mode if you are not already doing so.");
				return;
			}
			PlanetDataScript componentInParent2 = GetComponentInParent<PlanetDataScript>();
			string text = ((componentInParent2 != null) ? componentInParent2.Name : string.Empty);
			List<ModifierBenchmarkItem> list = (from x in componentInParent.GetComponentsInChildren<VertexDataPlanetModifier>(includeInactive: false)
				select new ModifierBenchmarkItem(x, Utilities.GetObjectHierarchy<PlanetTerrainDataScript>(x.gameObject))).ToList();
			PlanetVertexDataInput planetVertexDataInput = new PlanetVertexDataInput();
			PlanetVertexData planetVertexData = new PlanetVertexData(TerrainGeneratorCacheData.GetCacheData(1, 1089));
			for (int num = 0; num < 264; num++)
			{
				for (int num2 = 0; num2 < 264; num2++)
				{
					planetVertexDataInput.Position = new Vector3d(Mathd.Lerp(-1.0, 1.0, (double)num / 264.0), Mathd.Lerp(-1.0, 1.0, (double)num2 / 264.0), 1.0).normalized;
					foreach (ModifierBenchmarkItem item in list)
					{
						item.Stopwatch.Start();
						item.Modifier.GetVertexData(planetVertexDataInput, planetVertexData);
						item.Stopwatch.Stop();
					}
				}
			}
			planetVertexData.CacheData.ReturnToPool();
			double num3 = list.Sum((ModifierBenchmarkItem x) => x.Stopwatch.Elapsed.TotalMilliseconds);
			double num4 = num3 / 69696.0;
			double num5 = num4 * 1089.0;
			foreach (ModifierBenchmarkItem item2 in list)
			{
				item2.TotalTime = item2.Stopwatch.Elapsed.TotalMilliseconds;
				item2.Percentage = item2.TotalTime / num3 * 100.0;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Total Benchmark Time: {0,8:F4}   Avg Per Vertex: {1,8:F4}   Avg Per Quad: {2,8:F4}      {3}{4}", num3, num4, num5, text, Environment.NewLine);
			foreach (ModifierBenchmarkItem item3 in list)
			{
				stringBuilder.AppendFormat("{0,8:F4}  ({1,5:F2}%)  {2}{3}", item3.TotalTime, item3.Percentage, item3.Name, Environment.NewLine);
			}
			UnityEngine.Debug.Log(stringBuilder.ToString());
		}

		public List<DataSlotField> GetDataSlots()
		{
			if (this is IDataSlotConfiguration dataSlotConfiguration)
			{
				List<DataSlotField> list = new List<DataSlotField>();
				dataSlotConfiguration.GetDataSlots(list);
				return list;
			}
			Type type = GetType();
			if (!_dataSlotsCache.TryGetValue(type, out List<(FieldInfo, DataSlotAttribute)> value))
			{
				value = new List<(FieldInfo, DataSlotAttribute)>();
				_dataSlotsCache[type] = value;
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					DataSlotAttribute customAttribute = fieldInfo.GetCustomAttribute<DataSlotAttribute>();
					if (customAttribute != null)
					{
						value.Add((fieldInfo, customAttribute));
					}
				}
			}
			return value.Select<(FieldInfo, DataSlotAttribute), DataSlotField>(((FieldInfo Field, DataSlotAttribute Attribute) x) => new DataSlotField(this, x.Attribute, x.Field)).ToList();
		}

		public abstract void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data);

		public abstract void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data);

		public virtual bool IsSupported()
		{
			return true;
		}

		public virtual Vector2d LegacyGetMinMaxHeight(Vector2d minMaxHeight)
		{
			return minMaxHeight;
		}

		public virtual void SetPass(VertexDataPlanetModifierPassType pass, PlanetBiome biome)
		{
			if (pass != Pass)
			{
				throw new ArgumentException($"Modifier {base.Name} does not support the '{pass}' pass");
			}
		}

		public bool SupportsVertexDataType(VertexDataType vertexDataType)
		{
			return (VertexDataType & vertexDataType) != 0;
		}
	}
}
