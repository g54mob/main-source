using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Procedural
{
	[Serializable]
	public class TileGeneratorRegionPOIPass : IRegionPass
	{
		[SerializeField]
		private RegionPointOfInterestPass _pass;

		[SerializeField]
		private bool _skipStartingRegion;

		private TileGenerator _tileGenerator;

		private RegionPointOfInterestPass _passInstance;

		public int SpawnCount
		{
			get
			{
				if (!_passInstance)
				{
					return 0;
				}
				return _passInstance.SpawnCount;
			}
		}

		public void Initialize(TileGenerator tileGenerator)
		{
			_tileGenerator = tileGenerator;
			_passInstance = UnityEngine.Object.Instantiate(_pass);
			_passInstance.Initialize(tileGenerator);
		}

		public bool InitializeRegion(TileGeneratorRegion region)
		{
			return _passInstance.InitializeRegion(region);
		}

		public void Run(RegionPassGroup regionPasses, TileGeneratorRegion region)
		{
			if (!_skipStartingRegion || !_tileGenerator.IsStartingTile || !region.ReturnContainsPosition(_tileGenerator.StartPosition))
			{
				_passInstance.Run(regionPasses, region);
			}
		}

		public void Uninitialize()
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(_passInstance);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(_passInstance);
			}
			_passInstance = null;
		}
	}
}
