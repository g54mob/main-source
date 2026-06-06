using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	[CreateAssetMenu(fileName = "Region Landmark Pass", menuName = "Flotsam/Procedural Generation/Region Landmark Pass", order = 4)]
	public class RegionLandmarkPass : TileGeneratorPass
	{
		[SerializeField]
		private RegionLandmarkPassSettings[] _settings;

		private RegionLandmarkPassSettings _activeSettings;

		public List<HandmadeTileGenerator.Landmark> GeneratedLandmarks { get; private set; } = new List<HandmadeTileGenerator.Landmark>();

		public override IEnumerator Run(TileGenerator generator, IRegion dataRegion)
		{
			Dictionary<IWorldRegion, TileGeneratorRegion>.Enumerator enumerator = generator.Regions.GetEnumerator();
			InitializeGeneratedNodes(generator.Regions.Count * 16);
			while (enumerator.MoveNext())
			{
				TileGeneratorRegion value = enumerator.Current.Value;
				if (dataRegion == null || value.IsRegion(dataRegion))
				{
					Run(value, generator);
					yield return null;
				}
			}
		}

		private void Run(IRegion region, TileGenerator tileGenerator)
		{
			if (!TryReturnRegionSettings(region, out _activeSettings))
			{
				return;
			}
			float num = region.ReturnSurface();
			Debug.Log($"Running region landmark pass on region with a surface of {num}");
			_activeSettings.Initialize();
			_activeSettings.Sampler.GenerateSamples(region, Mathf.RoundToInt(num / _activeSettings.ReturnRandomizedDensity()));
			foreach (Vector2 sample in _activeSettings.Sampler.Samples)
			{
				AddGeneratedNode(GenerateNode(region, sample), tileGenerator);
			}
		}

		private TileGeneratorNode GenerateNode(IRegion region, Vector2 position)
		{
			TileGeneratorNode tileGeneratorNode = new TileGeneratorNode(position);
			tileGeneratorNode.SetSpawner(new LandmarkSpawner(_activeSettings.ReturnLandmarkBehaviour(), position.Vector3TopDown(), Random.rotation, null));
			if (region is TileGeneratorRegion tileGeneratorRegion)
			{
				tileGeneratorRegion.AddNode(tileGeneratorNode);
			}
			return tileGeneratorNode;
		}

		public bool TryReturnRegionSettings(IRegion region, out RegionLandmarkPassSettings settings)
		{
			using ListPool<RegionLandmarkPassSettings>.List list = ListPool<RegionLandmarkPassSettings>.Get();
			RegionLandmarkPassSettings[] settings2 = _settings;
			foreach (RegionLandmarkPassSettings regionLandmarkPassSettings in settings2)
			{
				if (regionLandmarkPassSettings.MatchesRegion(region))
				{
					list.Add(regionLandmarkPassSettings);
				}
			}
			settings = ((0 < list.Count) ? list[Random.Range(0, list.Count)] : null);
			return settings != null;
		}
	}
}
