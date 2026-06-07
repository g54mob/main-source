using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ModApi.CelestialData;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.Material;
using ModApi.Planet.Modifiers.VertexData;
using UnityEngine;

namespace ModApi.Planet
{
	public class TerrainGenerator : ITerrainGenerator, IDisposable
	{
		private List<string> _conditionalSymbols;

		private bool _hasBiomeBasedWaterSettings;

		private bool _hasBiomeModifiersBiomePass;

		private bool _hasBiomeModifiersFinalPass;

		private bool _hasBiomeModifiersHeightFinalPass;

		private bool _hasBiomeModifiersHeightPass;

		private bool _hasBiomeModifiersWaterPass;

		private TerrainGeneratorCacheData _mainThreadCacheData;

		private VertexDataPlanetModifier[][] _terrainBiomeBiomeModifiers;

		private VertexDataPlanetModifier[] _terrainBiomeCommonModifiers;

		private VertexDataPlanetModifier[][] _terrainFinalBiomeModifiers;

		private VertexDataPlanetModifier[] _terrainFinalCommonModifiers;

		private VertexDataPlanetModifier[][] _terrainHeightBiomeModifiers;

		private VertexDataPlanetModifier[] _terrainHeightCommonModifiers;

		private VertexDataPlanetModifier[][] _terrainHeightFinalBiomeModifiers;

		private VertexDataPlanetModifier[] _terrainHeightFinalCommonModifiers;

		private TerrainMaterialModifier _terrainMaterialModifier;

		private List<MaterialRequestedDelegate> _terrainMaterialRequestedCallbacks;

		private VertexDataPlanetModifier[][] _waterBiomeModifiers;

		private VertexDataPlanetModifier[] _waterCommonModifiers;

		private WaterMaterialModifier _waterMaterialModifier;

		private List<MaterialRequestedDelegate> _waterMaterialRequestedCallbacks;

		public int BiomeCount => TerrainData.Biomes.Count;

		public float LegacyHeightMax { get; private set; }

		public float LegacyHeightMin { get; private set; }

		public float SeaLevel => TerrainData.PlanetData.SeaLevel;

		public IPlanetTerrainData TerrainData { get; private set; }

		public TerrainMaterialModifier TerrainMaterialModifier => _terrainMaterialModifier;

		public int TerrainQuadUnpaddedVertexCount { get; private set; }

		public int TerrainQuadVertexCount { get; private set; }

		public WaterMaterialModifier WaterMaterialModifier => _waterMaterialModifier;

		public TerrainGenerator(IPlanetTerrainData terrainData, IEnumerable<string> additionalConditionalSymbols = null, IEnumerable<string> conditionalSymbolsToIgnore = null)
		{
			TerrainData = terrainData;
			int terrainQuadEdgeVertexCount = terrainData.Quality.TerrainQuadEdgeVertexCount;
			TerrainQuadUnpaddedVertexCount = terrainQuadEdgeVertexCount * terrainQuadEdgeVertexCount;
			TerrainQuadVertexCount = (terrainQuadEdgeVertexCount + 2) * (terrainQuadEdgeVertexCount + 2);
			_mainThreadCacheData = TerrainGeneratorCacheData.GetCacheData(terrainData.Biomes.Count, TerrainQuadVertexCount);
			_conditionalSymbols = GetConditionalSymbols(terrainData);
			_conditionalSymbols.AddRange(additionalConditionalSymbols ?? new string[0]);
			_conditionalSymbols.RemoveAll((string x) => conditionalSymbolsToIgnore?.Contains(x) ?? false);
			_conditionalSymbols = new List<string>(_conditionalSymbols.Distinct());
			_hasBiomeBasedWaterSettings = terrainData.Biomes.Any((PlanetBiome x) => !(x.WaterConfig?.UseDefaultConfig ?? true));
			RefreshVertexDataModifiers(terrainData, VertexDataPlanetModifierPassType.Biome, ref _terrainBiomeCommonModifiers, ref _terrainBiomeBiomeModifiers, ref _hasBiomeModifiersBiomePass);
			RefreshVertexDataModifiers(terrainData, VertexDataPlanetModifierPassType.Height, ref _terrainHeightCommonModifiers, ref _terrainHeightBiomeModifiers, ref _hasBiomeModifiersHeightPass);
			RefreshVertexDataModifiers(terrainData, VertexDataPlanetModifierPassType.HeightFinal, ref _terrainHeightFinalCommonModifiers, ref _terrainHeightFinalBiomeModifiers, ref _hasBiomeModifiersHeightFinalPass);
			RefreshVertexDataModifiers(terrainData, VertexDataPlanetModifierPassType.Final, ref _terrainFinalCommonModifiers, ref _terrainFinalBiomeModifiers, ref _hasBiomeModifiersFinalPass);
			RefreshVertexDataModifiers(terrainData, VertexDataPlanetModifierPassType.Water, ref _waterCommonModifiers, ref _waterBiomeModifiers, ref _hasBiomeModifiersWaterPass);
			if (_hasBiomeModifiersBiomePass)
			{
				Debug.LogError("The 'Biome' vertex data pass does not support biome specific modifiers.");
			}
			if (_hasBiomeModifiersHeightFinalPass)
			{
				Debug.LogError("The 'HeightFinal' vertex data pass does not support biome specific modifiers.");
			}
			RefreshMaterialModifiers();
			LegacyRefreshMinMaxHeight();
		}

		public void Dispose()
		{
			_mainThreadCacheData?.ReturnToPool();
			_mainThreadCacheData = null;
		}

		public TerrainGeneratorCacheData GetCacheData()
		{
			return TerrainGeneratorCacheData.GetCacheData(BiomeCount, TerrainQuadVertexCount);
		}

		public double GetHeight(Vector3d normalizedPosition)
		{
			TerrainGeneratorCacheData terrainGeneratorCacheData = ((_mainThreadCacheData.ThreadId == Thread.CurrentThread.ManagedThreadId) ? null : TerrainGeneratorCacheData.GetCacheData(BiomeCount, TerrainQuadVertexCount));
			try
			{
				return GetVertexDataBiomeAndHeightPass(normalizedPosition, 0, terrainGeneratorCacheData ?? _mainThreadCacheData).Height;
			}
			finally
			{
				terrainGeneratorCacheData?.ReturnToPool();
			}
		}

		public double GetHeight(Vector3d normalizedPosition, TerrainGeneratorCacheData cacheData)
		{
			return GetVertexDataBiomeAndHeightPass(normalizedPosition, 0, cacheData).Height;
		}

		public QuadMeshDataFlags GetRequiredTerrainMeshData()
		{
			QuadMeshDataFlags quadMeshDataFlags = QuadMeshDataFlags.None;
			foreach (PlanetModifier modifier in TerrainData.Modifiers)
			{
				quadMeshDataFlags |= modifier.GetRequiredTerrainMeshData();
			}
			return quadMeshDataFlags;
		}

		public QuadMeshDataFlags GetRequiredWaterMeshData()
		{
			QuadMeshDataFlags quadMeshDataFlags = QuadMeshDataFlags.None;
			foreach (PlanetModifier modifier in TerrainData.Modifiers)
			{
				quadMeshDataFlags |= modifier.GetRequiredWaterMeshData();
			}
			return quadMeshDataFlags;
		}

		public Material GetTerrainMaterial(IQuadSphereQuad quad)
		{
			Material material = _terrainMaterialModifier.GetMaterial(quad);
			if (_terrainMaterialRequestedCallbacks != null)
			{
				foreach (MaterialRequestedDelegate terrainMaterialRequestedCallback in _terrainMaterialRequestedCallbacks)
				{
					try
					{
						material = terrainMaterialRequestedCallback(material);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			return material;
		}

		public PlanetVertexData GetVertexData(VertexDataRequestType type, Vector3d normalizedPosition, Vector3d? normal = null, TerrainGeneratorCacheData cacheData = null)
		{
			if (cacheData == null)
			{
				cacheData = _mainThreadCacheData;
			}
			PlanetVertexData planetVertexData = cacheData.VertexDataResults[0];
			planetVertexData.Reset();
			PlanetVertexDataInput vertexDataInput = cacheData.VertexDataInput;
			vertexDataInput.Position = normalizedPosition;
			vertexDataInput.Normal = normal ?? normalizedPosition;
			UpdateVertexDataBiomePass(cacheData, vertexDataInput, planetVertexData);
			UpdateVertexDataHeightPass(cacheData, vertexDataInput, planetVertexData);
			if (type == VertexDataRequestType.HeightData)
			{
				return planetVertexData;
			}
			UpdateVertexDataFinalPass(cacheData, vertexDataInput, planetVertexData);
			if (type == VertexDataRequestType.HeightAndBiomeData)
			{
				return planetVertexData;
			}
			UpdateVertexDataWaterPass(cacheData, vertexDataInput, planetVertexData);
			return planetVertexData;
		}

		public PlanetVertexData GetVertexDataBiomeAndHeightPass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			PlanetVertexData planetVertexData = cacheData.VertexDataResults[quadVertexIndex];
			planetVertexData.Reset();
			PlanetVertexDataInput vertexDataInput = cacheData.VertexDataInput;
			vertexDataInput.Position = normalizedPosition;
			UpdateVertexDataBiomePass(cacheData, vertexDataInput, planetVertexData);
			UpdateVertexDataHeightPass(cacheData, vertexDataInput, planetVertexData);
			return planetVertexData;
		}

		public void GetVertexDataBiomeAndHeightPass(PlanetVertexDataInput[] inputs, TerrainGeneratorCacheData cacheData)
		{
			PlanetVertexData[] vertexDataResults = cacheData.VertexDataResults;
			int num = vertexDataResults.Length;
			for (int i = 0; i < num; i++)
			{
				vertexDataResults[i].Reset();
			}
			UpdateVertexDataBiomePass(cacheData, inputs, vertexDataResults);
			UpdateVertexDataHeightPass(cacheData, inputs, vertexDataResults);
		}

		public PlanetVertexData GetVertexDataBiomePass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			if (cacheData == null)
			{
				cacheData = _mainThreadCacheData;
			}
			PlanetVertexData planetVertexData = cacheData.VertexDataResults[quadVertexIndex];
			planetVertexData.Reset();
			PlanetVertexDataInput vertexDataInput = cacheData.VertexDataInput;
			vertexDataInput.Position = normalizedPosition;
			UpdateVertexDataBiomePass(cacheData, vertexDataInput, planetVertexData);
			return planetVertexData;
		}

		public PlanetVertexData GetVertexDataFinalPass(Vector3d normalizedPosition, Vector3d normal, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			if (cacheData == null)
			{
				cacheData = _mainThreadCacheData;
			}
			PlanetVertexDataInput vertexDataInput = cacheData.VertexDataInput;
			vertexDataInput.Position = normalizedPosition;
			vertexDataInput.Normal = normal;
			PlanetVertexData planetVertexData = cacheData.VertexDataResults[quadVertexIndex];
			UpdateVertexDataFinalPass(cacheData, vertexDataInput, planetVertexData);
			return planetVertexData;
		}

		public void GetVertexDataFinalPass(PlanetVertexDataInput[] inputs, TerrainGeneratorCacheData cacheData)
		{
			UpdateVertexDataFinalPass(cacheData, inputs, cacheData.VertexDataResults);
		}

		public PlanetVertexData GetVertexDataHeightPass(Vector3d normalizedPosition, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			if (cacheData == null)
			{
				cacheData = _mainThreadCacheData;
			}
			PlanetVertexDataInput vertexDataInput = cacheData.VertexDataInput;
			vertexDataInput.Position = normalizedPosition;
			PlanetVertexData planetVertexData = cacheData.VertexDataResults[quadVertexIndex];
			UpdateVertexDataHeightPass(cacheData, vertexDataInput, planetVertexData);
			return planetVertexData;
		}

		public PlanetVertexData GetVertexDataWaterPass(TerrainGeneratorCacheData cacheData = null)
		{
			if (cacheData == null)
			{
				cacheData = _mainThreadCacheData;
			}
			PlanetVertexDataInput vertexDataInput = cacheData.VertexDataInput;
			PlanetVertexData planetVertexData = cacheData.VertexDataResults[0];
			UpdateVertexDataWaterPass(cacheData, vertexDataInput, planetVertexData);
			return planetVertexData;
		}

		public PlanetVertexData GetVertexDataWaterPass(Vector3d normalizedPosition, Vector3d normal, int quadVertexIndex, TerrainGeneratorCacheData cacheData)
		{
			if (cacheData == null)
			{
				cacheData = _mainThreadCacheData;
			}
			PlanetVertexDataInput vertexDataInput = cacheData.VertexDataInput;
			vertexDataInput.Position = normalizedPosition;
			vertexDataInput.Normal = normal;
			PlanetVertexData planetVertexData = cacheData.VertexDataResults[quadVertexIndex];
			UpdateVertexDataWaterPass(cacheData, vertexDataInput, planetVertexData);
			return planetVertexData;
		}

		public Material GetWaterMaterial(IQuadSphereQuad quad)
		{
			Material material = _waterMaterialModifier?.GetMaterial(quad);
			if (_waterMaterialRequestedCallbacks != null)
			{
				foreach (MaterialRequestedDelegate waterMaterialRequestedCallback in _waterMaterialRequestedCallbacks)
				{
					try
					{
						material = waterMaterialRequestedCallback(material);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			return material;
		}

		public void InitializeQuadSphere(IQuadSphere quadSphere)
		{
			_terrainMaterialModifier.InitializeQuadSphere(quadSphere);
			_waterMaterialModifier?.InitializeQuadSphere(quadSphere);
		}

		public void RegisterTerrainMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
			if (_terrainMaterialRequestedCallbacks == null)
			{
				_terrainMaterialRequestedCallbacks = new List<MaterialRequestedDelegate>();
			}
			_terrainMaterialRequestedCallbacks.Add(materialRequestedCallback);
		}

		public void RegisterWaterMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
			if (_waterMaterialRequestedCallbacks == null)
			{
				_waterMaterialRequestedCallbacks = new List<MaterialRequestedDelegate>();
			}
			_waterMaterialRequestedCallbacks.Add(materialRequestedCallback);
		}

		public void UnregisterTerrainMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
			_terrainMaterialRequestedCallbacks?.Remove(materialRequestedCallback);
		}

		public void UnregisterWaterMaterialRequestedCallback(MaterialRequestedDelegate materialRequestedCallback)
		{
			_waterMaterialRequestedCallbacks?.Remove(materialRequestedCallback);
		}

		private static void RemoveModifierFromArray(ref VertexDataPlanetModifier[] array, int index)
		{
			List<VertexDataPlanetModifier> list = array.ToList();
			list.RemoveAt(index);
			array = list.ToArray();
		}

		private List<string> GetConditionalSymbols(IPlanetTerrainData terrainData)
		{
			CelestialBodyFileData fileData = terrainData.PlanetData.FileData;
			Func<IBrushCubemapModifier, bool> hasBrushCubemap = (IBrushCubemapModifier m) => m.MapId != null && fileData.GetSupportFile(m.MapId) != null;
			List<string> list = new List<string>(terrainData.ConditionalSymbols);
			list.AddRange((from m in terrainData.Modifiers.OfType<IBrushCubemapModifier>().Where(hasBrushCubemap)
				select m.MapId).ToList());
			list.AddRange(terrainData.Biomes.SelectMany((PlanetBiome b) => from m in b.Modifiers.OfType<IBrushCubemapModifier>().Where(hasBrushCubemap)
				select m.MapId));
			return list;
		}

		private VertexDataPlanetModifier[] GetVertexDataModifiers(IEnumerable<PlanetModifier> modifiers, VertexDataPlanetModifierPassType pass)
		{
			return (from VertexDataPlanetModifier x in from x in modifiers
					where x.ModifierType == PlanetModifierType.VertexData && x.isActiveAndEnabled
					where !x.DisabledWithSymbols.Any((string y) => _conditionalSymbols.Contains(y))
					where x.EnabledWithSymbols.Count == 0 || x.EnabledWithSymbols.All((string y) => _conditionalSymbols.Contains(y))
					select x
				where x.Pass == pass
				where x.IsSupported()
				select x).ToArray();
		}

		private void LegacyRefreshMinMaxHeight()
		{
			LegacyHeightMin = float.MaxValue;
			LegacyHeightMax = float.MinValue;
			bool flag = false;
			Vector2d vector2d = Vector2d.zero;
			VertexDataPlanetModifier[] terrainBiomeCommonModifiers = _terrainBiomeCommonModifiers;
			foreach (VertexDataPlanetModifier obj in terrainBiomeCommonModifiers)
			{
				flag = true;
				vector2d = obj.LegacyGetMinMaxHeight(vector2d);
			}
			terrainBiomeCommonModifiers = _terrainHeightCommonModifiers;
			foreach (VertexDataPlanetModifier obj2 in terrainBiomeCommonModifiers)
			{
				flag = true;
				vector2d = obj2.LegacyGetMinMaxHeight(vector2d);
			}
			VertexDataPlanetModifier[][] terrainHeightBiomeModifiers = _terrainHeightBiomeModifiers;
			foreach (VertexDataPlanetModifier[] obj3 in terrainHeightBiomeModifiers)
			{
				flag = true;
				Vector2d minMaxHeight = vector2d;
				terrainBiomeCommonModifiers = obj3;
				for (int j = 0; j < terrainBiomeCommonModifiers.Length; j++)
				{
					minMaxHeight = terrainBiomeCommonModifiers[j].LegacyGetMinMaxHeight(minMaxHeight);
				}
				LegacyHeightMin = Mathf.Min(LegacyHeightMin, (float)minMaxHeight.x);
				LegacyHeightMax = Mathf.Max(LegacyHeightMax, (float)minMaxHeight.y);
			}
			terrainBiomeCommonModifiers = _terrainHeightFinalCommonModifiers;
			foreach (VertexDataPlanetModifier obj4 in terrainBiomeCommonModifiers)
			{
				flag = true;
				vector2d = obj4.LegacyGetMinMaxHeight(vector2d);
			}
			if (!flag)
			{
				LegacyHeightMin = 0f;
				LegacyHeightMax = 0f;
			}
		}

		private void LogModifierError(string error, VertexDataPlanetModifier modifier, Exception exception)
		{
			Debug.LogException(exception);
			Debug.LogError(error, modifier);
			if (Game.InPlanetStudioScene && _mainThreadCacheData.ThreadId == Thread.CurrentThread.ManagedThreadId)
			{
				Game.Instance.UserInterface.CreateErrorDialog(error);
			}
		}

		private void RefreshMaterialModifiers()
		{
			PlanetTerrainDataScript planetTerrainDataScript = (PlanetTerrainDataScript)TerrainData;
			_terrainMaterialModifier = TerrainData.Modifiers.Where((PlanetModifier x) => x.ModifierType == PlanetModifierType.TerrainMaterial && x.gameObject.activeInHierarchy).FirstOrDefault() as TerrainMaterialModifier;
			if (_terrainMaterialModifier == null)
			{
				_terrainMaterialModifier = new GameObject("TerrainMaterialModifier").AddComponent<TerrainMaterialModifier>();
				_terrainMaterialModifier.transform.SetParent(planetTerrainDataScript.transform, worldPositionStays: false);
				_terrainMaterialModifier.Initialize(planetTerrainDataScript);
				planetTerrainDataScript.Modifiers.Add(_terrainMaterialModifier);
			}
			if (TerrainData.PlanetData.HasWater)
			{
				_waterMaterialModifier = planetTerrainDataScript.GetWaterMaterialModifier();
				if (_waterMaterialModifier == null)
				{
					_waterMaterialModifier = planetTerrainDataScript.CreateWaterMaterialModifier();
					_waterMaterialModifier.Initialize(planetTerrainDataScript);
				}
			}
		}

		private void RefreshVertexDataModifiers(IPlanetTerrainData terrainData, VertexDataPlanetModifierPassType pass, ref VertexDataPlanetModifier[] commonModifiers, ref VertexDataPlanetModifier[][] biomeModifiers, ref bool hasBiomeModifiers)
		{
			commonModifiers = GetVertexDataModifiers(terrainData.Modifiers, pass);
			biomeModifiers = new VertexDataPlanetModifier[terrainData.Biomes.Count][];
			for (int i = 0; i < terrainData.Biomes.Count; i++)
			{
				PlanetBiome planetBiome = terrainData.Biomes[i];
				VertexDataPlanetModifier[] vertexDataModifiers = GetVertexDataModifiers(planetBiome.Modifiers, pass);
				if (vertexDataModifiers.Length != 0)
				{
					hasBiomeModifiers = true;
				}
				biomeModifiers[i] = vertexDataModifiers;
			}
		}

		private void UpdateVertexDataBiomePass(TerrainGeneratorCacheData cacheData, PlanetVertexDataInput[] inputs, PlanetVertexData[] outputs)
		{
			int num = outputs.Length;
			for (int i = 0; i < _terrainBiomeCommonModifiers.Length; i++)
			{
				VertexDataPlanetModifier vertexDataPlanetModifier = _terrainBiomeCommonModifiers[i];
				try
				{
					cacheData.ModifierProfiler?.BeginProfile(cacheData.ModifierProfilerThread, vertexDataPlanetModifier, num);
					for (int j = 0; j < num; j++)
					{
						vertexDataPlanetModifier.GetVertexData(inputs[j], outputs[j]);
					}
					cacheData.ModifierProfiler?.EndProfile(cacheData.ModifierProfilerThread);
				}
				catch (Exception exception)
				{
					RemoveModifierFromArray(ref _terrainBiomeCommonModifiers, i);
					i--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier.Name + "' (in 'Biome' pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier, exception);
				}
			}
		}

		private void UpdateVertexDataBiomePass(TerrainGeneratorCacheData cacheData, PlanetVertexDataInput input, PlanetVertexData output)
		{
			for (int i = 0; i < _terrainBiomeCommonModifiers.Length; i++)
			{
				try
				{
					_terrainBiomeCommonModifiers[i].GetVertexData(input, output);
				}
				catch (Exception exception)
				{
					VertexDataPlanetModifier vertexDataPlanetModifier = _terrainBiomeCommonModifiers[i];
					RemoveModifierFromArray(ref _terrainBiomeCommonModifiers, i);
					i--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier.Name + "' (in 'Biome' pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier, exception);
				}
			}
		}

		private void UpdateVertexDataFinalPass(TerrainGeneratorCacheData cacheData, PlanetVertexDataInput input, PlanetVertexData output)
		{
			for (int i = 0; i < _terrainFinalCommonModifiers.Length; i++)
			{
				try
				{
					_terrainFinalCommonModifiers[i].GetVertexData(input, output);
				}
				catch (Exception exception)
				{
					VertexDataPlanetModifier vertexDataPlanetModifier = _terrainFinalCommonModifiers[i];
					RemoveModifierFromArray(ref _terrainFinalCommonModifiers, i);
					i--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier.Name + "' (in 'Final' common pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier, exception);
				}
			}
			if (!_hasBiomeModifiersFinalPass)
			{
				return;
			}
			PlanetVertexBiomeData[] biomes = output.Biomes;
			for (int j = 0; j < biomes.Length; j++)
			{
				float strength = biomes[j].Strength;
				if (!(strength > 0f))
				{
					continue;
				}
				PlanetBiomeVertexData biomeVertexData = cacheData.BiomeVertexData;
				biomeVertexData.BiomeIndex = j;
				biomeVertexData.BiomeStrength = strength;
				biomeVertexData.CommonData = output;
				biomeVertexData.Height = 0.0;
				biomeVertexData.Color = Color.clear;
				biomeVertexData.ResetCustomData();
				VertexDataPlanetModifier[] array = _terrainFinalBiomeModifiers[j];
				for (int k = 0; k < array.Length; k++)
				{
					try
					{
						array[k].GetVertexData(input, biomeVertexData);
					}
					catch (Exception exception2)
					{
						VertexDataPlanetModifier vertexDataPlanetModifier2 = array[k];
						RemoveModifierFromArray(ref array, k);
						_terrainFinalBiomeModifiers[j] = array;
						k--;
						LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier2.Name + "' (in 'Final' biome pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier2, exception2);
					}
				}
				output.Color += biomeVertexData.Color * strength;
				output.ApplyCustomDataBiomeResults(biomeVertexData);
			}
		}

		private void UpdateVertexDataFinalPass(TerrainGeneratorCacheData cacheData, PlanetVertexDataInput[] inputs, PlanetVertexData[] outputs)
		{
			int num = outputs.Length;
			for (int i = 0; i < _terrainFinalCommonModifiers.Length; i++)
			{
				VertexDataPlanetModifier vertexDataPlanetModifier = _terrainFinalCommonModifiers[i];
				try
				{
					cacheData.ModifierProfiler?.BeginProfile(cacheData.ModifierProfilerThread, vertexDataPlanetModifier, TerrainQuadUnpaddedVertexCount);
					for (int j = 0; j < num; j++)
					{
						PlanetVertexData planetVertexData = outputs[j];
						if (!planetVertexData.OnPaddedQuadEdge)
						{
							vertexDataPlanetModifier.GetVertexData(inputs[j], planetVertexData);
						}
					}
					cacheData.ModifierProfiler?.EndProfile(cacheData.ModifierProfilerThread);
				}
				catch (Exception exception)
				{
					RemoveModifierFromArray(ref _terrainFinalCommonModifiers, i);
					i--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier.Name + "' (in 'Final' common pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier, exception);
				}
			}
			if (!_hasBiomeModifiersFinalPass)
			{
				return;
			}
			PlanetBiomeVertexData[] biomeVertexDataResults = cacheData.BiomeVertexDataResults;
			int biomeCount = cacheData.BiomeCount;
			for (int k = 0; k < biomeCount; k++)
			{
				int num2 = 0;
				for (int l = 0; l < num; l++)
				{
					PlanetVertexData planetVertexData2 = outputs[l];
					if (!planetVertexData2.OnPaddedQuadEdge)
					{
						PlanetBiomeVertexData planetBiomeVertexData = biomeVertexDataResults[l];
						planetBiomeVertexData.BiomeStrength = planetVertexData2.Biomes[k].Strength;
						if (planetBiomeVertexData.BiomeStrength > 0f)
						{
							planetBiomeVertexData.BiomeIndex = k;
							planetBiomeVertexData.Color.r = 0f;
							planetBiomeVertexData.Color.g = 0f;
							planetBiomeVertexData.Color.b = 0f;
							planetBiomeVertexData.Color.a = 0f;
							num2++;
						}
					}
				}
				if (num2 == 0)
				{
					continue;
				}
				VertexDataPlanetModifier[] array = _terrainFinalBiomeModifiers[k];
				int num3 = array.Length;
				for (int m = 0; m < num3; m++)
				{
					VertexDataPlanetModifier vertexDataPlanetModifier2 = array[m];
					try
					{
						cacheData.ModifierProfiler?.BeginProfile(cacheData.ModifierProfilerThread, vertexDataPlanetModifier2, num2);
						for (int n = 0; n < num; n++)
						{
							if (!outputs[n].OnPaddedQuadEdge)
							{
								PlanetBiomeVertexData planetBiomeVertexData2 = biomeVertexDataResults[n];
								if (planetBiomeVertexData2.BiomeStrength > 0f)
								{
									vertexDataPlanetModifier2.GetVertexData(inputs[n], planetBiomeVertexData2);
								}
							}
						}
						cacheData.ModifierProfiler?.EndProfile(cacheData.ModifierProfilerThread);
					}
					catch (Exception exception2)
					{
						RemoveModifierFromArray(ref array, m);
						_terrainFinalBiomeModifiers[k] = array;
						num3--;
						m--;
						LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier2.Name + "' (in 'Final' biome pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier2, exception2);
					}
				}
				for (int num4 = 0; num4 < num; num4++)
				{
					PlanetVertexData planetVertexData3 = outputs[num4];
					if (!planetVertexData3.OnPaddedQuadEdge)
					{
						PlanetBiomeVertexData planetBiomeVertexData3 = biomeVertexDataResults[num4];
						if (planetBiomeVertexData3.BiomeStrength > 0f)
						{
							planetVertexData3.Color += planetBiomeVertexData3.Color * planetBiomeVertexData3.BiomeStrength;
						}
					}
				}
			}
		}

		private void UpdateVertexDataHeightPass(TerrainGeneratorCacheData cacheData, PlanetVertexDataInput[] inputs, PlanetVertexData[] outputs)
		{
			int num = outputs.Length;
			for (int i = 0; i < _terrainHeightCommonModifiers.Length; i++)
			{
				VertexDataPlanetModifier vertexDataPlanetModifier = _terrainHeightCommonModifiers[i];
				try
				{
					cacheData.ModifierProfiler?.BeginProfile(cacheData.ModifierProfilerThread, vertexDataPlanetModifier, num);
					for (int j = 0; j < num; j++)
					{
						vertexDataPlanetModifier.GetVertexData(inputs[j], outputs[j]);
					}
					cacheData.ModifierProfiler?.EndProfile(cacheData.ModifierProfilerThread);
				}
				catch (Exception exception)
				{
					RemoveModifierFromArray(ref _terrainHeightCommonModifiers, i);
					i--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier.Name + "' (in 'Height' common pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier, exception);
				}
			}
			if (_hasBiomeModifiersHeightPass)
			{
				PlanetBiomeVertexData[] biomeVertexDataResults = cacheData.BiomeVertexDataResults;
				int biomeCount = cacheData.BiomeCount;
				for (int k = 0; k < biomeCount; k++)
				{
					int num2 = 0;
					for (int l = 0; l < num; l++)
					{
						PlanetBiomeVertexData planetBiomeVertexData = biomeVertexDataResults[l];
						planetBiomeVertexData.BiomeStrength = outputs[l].Biomes[k].Strength;
						if (planetBiomeVertexData.BiomeStrength > 0f)
						{
							planetBiomeVertexData.BiomeIndex = k;
							planetBiomeVertexData.Height = 0.0;
							planetBiomeVertexData.Color.r = 0f;
							planetBiomeVertexData.Color.g = 0f;
							planetBiomeVertexData.Color.b = 0f;
							planetBiomeVertexData.Color.a = 0f;
							planetBiomeVertexData.ResetCustomData();
							num2++;
						}
						if (k == 0)
						{
							planetBiomeVertexData.HeightTotal = 0.0;
						}
					}
					if (num2 == 0)
					{
						continue;
					}
					VertexDataPlanetModifier[] array = _terrainHeightBiomeModifiers[k];
					int num3 = array.Length;
					for (int m = 0; m < num3; m++)
					{
						VertexDataPlanetModifier vertexDataPlanetModifier2 = array[m];
						try
						{
							cacheData.ModifierProfiler?.BeginProfile(cacheData.ModifierProfilerThread, vertexDataPlanetModifier2, num2);
							for (int n = 0; n < num; n++)
							{
								PlanetBiomeVertexData planetBiomeVertexData2 = biomeVertexDataResults[n];
								if (planetBiomeVertexData2.BiomeStrength > 0f)
								{
									vertexDataPlanetModifier2.GetVertexData(inputs[n], planetBiomeVertexData2);
								}
							}
							cacheData.ModifierProfiler?.EndProfile(cacheData.ModifierProfilerThread);
						}
						catch (Exception exception2)
						{
							RemoveModifierFromArray(ref array, m);
							_terrainHeightBiomeModifiers[k] = array;
							num3--;
							m--;
							LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier2.Name + "' (in 'Height' biome pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier2, exception2);
						}
					}
					for (int num4 = 0; num4 < num; num4++)
					{
						PlanetBiomeVertexData planetBiomeVertexData3 = biomeVertexDataResults[num4];
						if (planetBiomeVertexData3.BiomeStrength > 0f)
						{
							planetBiomeVertexData3.HeightTotal += planetBiomeVertexData3.Height * (double)planetBiomeVertexData3.BiomeStrength;
							outputs[num4].Color += planetBiomeVertexData3.Color * planetBiomeVertexData3.BiomeStrength;
							outputs[num4].ApplyCustomDataBiomeResults(planetBiomeVertexData3);
						}
					}
				}
				for (int num5 = 0; num5 < num; num5++)
				{
					outputs[num5].Height += biomeVertexDataResults[num5].HeightTotal;
				}
			}
			for (int num6 = 0; num6 < _terrainHeightFinalCommonModifiers.Length; num6++)
			{
				VertexDataPlanetModifier vertexDataPlanetModifier3 = _terrainHeightFinalCommonModifiers[num6];
				try
				{
					cacheData.ModifierProfiler?.BeginProfile(cacheData.ModifierProfilerThread, vertexDataPlanetModifier3, num);
					for (int num7 = 0; num7 < num; num7++)
					{
						vertexDataPlanetModifier3.GetVertexData(inputs[num7], outputs[num7]);
					}
					cacheData.ModifierProfiler?.EndProfile(cacheData.ModifierProfilerThread);
				}
				catch (Exception exception3)
				{
					RemoveModifierFromArray(ref _terrainHeightFinalCommonModifiers, num6);
					num6--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier3.Name + "' (in 'HeightFinal' common pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier3, exception3);
				}
			}
		}

		private void UpdateVertexDataHeightPass(TerrainGeneratorCacheData cacheData, PlanetVertexDataInput input, PlanetVertexData output)
		{
			for (int i = 0; i < _terrainHeightCommonModifiers.Length; i++)
			{
				try
				{
					_terrainHeightCommonModifiers[i].GetVertexData(input, output);
				}
				catch (Exception exception)
				{
					VertexDataPlanetModifier vertexDataPlanetModifier = _terrainHeightCommonModifiers[i];
					RemoveModifierFromArray(ref _terrainHeightCommonModifiers, i);
					i--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier.Name + "' (in 'Height' common pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier, exception);
				}
			}
			if (_hasBiomeModifiersHeightPass)
			{
				double num = 0.0;
				PlanetVertexBiomeData[] biomes = output.Biomes;
				for (int j = 0; j < biomes.Length; j++)
				{
					float strength = biomes[j].Strength;
					if (!(strength > 0f))
					{
						continue;
					}
					PlanetBiomeVertexData biomeVertexData = cacheData.BiomeVertexData;
					biomeVertexData.BiomeIndex = j;
					biomeVertexData.BiomeStrength = strength;
					biomeVertexData.CommonData = output;
					biomeVertexData.Height = 0.0;
					biomeVertexData.Color = Color.clear;
					biomeVertexData.ResetCustomData();
					VertexDataPlanetModifier[] array = _terrainHeightBiomeModifiers[j];
					for (int k = 0; k < array.Length; k++)
					{
						try
						{
							array[k].GetVertexData(input, biomeVertexData);
						}
						catch (Exception exception2)
						{
							VertexDataPlanetModifier vertexDataPlanetModifier2 = array[k];
							RemoveModifierFromArray(ref array, k);
							_terrainHeightBiomeModifiers[j] = array;
							k--;
							LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier2.Name + "' (in 'Height' biome pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier2, exception2);
						}
					}
					num += biomeVertexData.Height * (double)strength;
					output.Color += biomeVertexData.Color * strength;
					output.ApplyCustomDataBiomeResults(biomeVertexData);
				}
				output.Height += num;
			}
			for (int l = 0; l < _terrainHeightFinalCommonModifiers.Length; l++)
			{
				try
				{
					_terrainHeightFinalCommonModifiers[l].GetVertexData(input, output);
				}
				catch (Exception exception3)
				{
					VertexDataPlanetModifier vertexDataPlanetModifier3 = _terrainHeightFinalCommonModifiers[l];
					RemoveModifierFromArray(ref _terrainHeightFinalCommonModifiers, l);
					l--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier3.Name + "' (in 'HeightFinal' common pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier3, exception3);
				}
			}
		}

		private void UpdateVertexDataWaterPass(TerrainGeneratorCacheData cacheData, PlanetVertexDataInput input, PlanetVertexData output)
		{
			PlanetVertexBiomeData[] biomes = output.Biomes;
			float seaLevel = SeaLevel;
			double num = ((output.Height >= (double)seaLevel) ? 0.0 : ((double)seaLevel - output.Height));
			if (_hasBiomeBasedWaterSettings)
			{
				output.Color = Color.clear;
				output.Emissiveness = 0f;
				output.Metallicness = 0f;
				output.Smoothness = 0f;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				float num6 = 0f;
				float num7 = 0f;
				Color? color = null;
				foreach (PlanetVertexBiomeData planetVertexBiomeData in biomes)
				{
					float strength = planetVertexBiomeData.Strength;
					if (!(strength > 0f))
					{
						continue;
					}
					PlanetWaterConfig waterConfig = TerrainData.Biomes[planetVertexBiomeData.BiomeIndex].WaterConfig;
					bool useDefaultConfig = waterConfig.UseDefaultConfig;
					if (useDefaultConfig && color.HasValue)
					{
						output.Color += color.Value * strength;
					}
					else
					{
						double num8 = ((num >= waterConfig.WaterColorGradientMaxDepth) ? 1.0 : (num / waterConfig.WaterColorGradientMaxDepth));
						Color color2 = waterConfig.WaterColorGradientLinear.Evaluate((float)num8);
						if (useDefaultConfig)
						{
							color = color2;
						}
						output.Color += color2 * strength;
					}
					output.Emissiveness += waterConfig.Emissiveness * strength;
					output.Metallicness += waterConfig.Metallicness * strength;
					output.Smoothness += waterConfig.Smoothness * strength;
					num2 += (float)waterConfig.WaveAmplitudeScale * strength;
					num3 += (float)waterConfig.TransparencyDepthScale * strength;
					num4 += (float)waterConfig.TransparencyStrength * strength;
					num5 += (float)waterConfig.ReflectionStrength * strength;
					num6 += (float)waterConfig.FoamStrength * strength;
					num7 += (float)waterConfig.TextureStrength * strength;
				}
				output.WaveAmplitudeScale = (byte)num2;
				output.TransparencyDepthScale = (byte)num3;
				output.TransparencyStrength = (byte)num4;
				output.ReflectionStrength = (byte)num5;
				output.FoamStrength = (byte)num6;
				output.TextureStrength = (byte)num7;
			}
			else
			{
				PlanetWaterConfig waterConfigDefault = TerrainData.WaterConfigDefault;
				double num9 = ((num >= waterConfigDefault.WaterColorGradientMaxDepth) ? 1.0 : (num / waterConfigDefault.WaterColorGradientMaxDepth));
				output.Color = waterConfigDefault.WaterColorGradientLinear.Evaluate((float)num9);
				output.Emissiveness = waterConfigDefault.Emissiveness;
				output.Metallicness = waterConfigDefault.Metallicness;
				output.Smoothness = waterConfigDefault.Smoothness;
				output.WaveAmplitudeScale = (byte)waterConfigDefault.WaveAmplitudeScale;
				output.TransparencyDepthScale = (byte)waterConfigDefault.TransparencyDepthScale;
				output.TransparencyStrength = (byte)waterConfigDefault.TransparencyStrength;
				output.ReflectionStrength = (byte)waterConfigDefault.ReflectionStrength;
				output.FoamStrength = (byte)waterConfigDefault.FoamStrength;
				output.TextureStrength = (byte)waterConfigDefault.TextureStrength;
			}
			for (int j = 0; j < _waterCommonModifiers.Length; j++)
			{
				try
				{
					_waterCommonModifiers[j].GetVertexData(input, output);
				}
				catch (Exception exception)
				{
					VertexDataPlanetModifier vertexDataPlanetModifier = _waterCommonModifiers[j];
					RemoveModifierFromArray(ref _waterCommonModifiers, j);
					j--;
					LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier.Name + "' (in 'Water' common pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier, exception);
				}
			}
			if (!_hasBiomeModifiersWaterPass)
			{
				return;
			}
			Color color3 = output.Color;
			output.Color = Color.clear;
			for (int k = 0; k < biomes.Length; k++)
			{
				float strength2 = biomes[k].Strength;
				if (!(strength2 > 0f))
				{
					continue;
				}
				PlanetBiomeVertexData biomeVertexData = cacheData.BiomeVertexData;
				biomeVertexData.BiomeIndex = k;
				biomeVertexData.CommonData = output;
				biomeVertexData.Height = output.Height;
				biomeVertexData.Color = color3;
				VertexDataPlanetModifier[] array = _waterBiomeModifiers[k];
				for (int l = 0; l < array.Length; l++)
				{
					try
					{
						array[l].GetVertexData(input, biomeVertexData);
					}
					catch (Exception exception2)
					{
						VertexDataPlanetModifier vertexDataPlanetModifier2 = array[l];
						RemoveModifierFromArray(ref array, l);
						_waterBiomeModifiers[k] = array;
						l--;
						LogModifierError("An error occurred running vertex data modifier '" + vertexDataPlanetModifier2.Name + "' (in 'Water' biome pass). The modifier will be skipped in future attempts.", vertexDataPlanetModifier2, exception2);
					}
				}
				output.Color += biomeVertexData.Color * strength2;
			}
		}
	}
}
