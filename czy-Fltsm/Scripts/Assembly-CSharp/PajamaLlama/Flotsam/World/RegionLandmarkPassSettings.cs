using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.PajamaLlama;

namespace PajamaLlama.Flotsam.World
{
	[Serializable]
	public class RegionLandmarkPassSettings
	{
		[Serializable]
		internal struct LandmarkBehavioursBySize
		{
			public HandmadeTileGenerator.Landmark.Size Size;

			[SerializeField]
			private LandmarkBehaviour[] _landmarkBehaviours;

			public List<LandmarkBehaviour> _landmarkBehavioursToDistribute;

			public LandmarkBehaviour ReturnLandmarkBehaviour()
			{
				if (_landmarkBehavioursToDistribute == null)
				{
					_landmarkBehavioursToDistribute = new List<LandmarkBehaviour>(_landmarkBehaviours);
				}
				else if (_landmarkBehavioursToDistribute.Count == 0)
				{
					_landmarkBehavioursToDistribute.AddRange(_landmarkBehaviours);
				}
				int index = UnityEngine.Random.Range(0, _landmarkBehavioursToDistribute.Count);
				LandmarkBehaviour result = _landmarkBehavioursToDistribute[index];
				_landmarkBehavioursToDistribute.RemoveAt(index);
				return result;
			}
		}

		[Serializable]
		internal struct Distributer
		{
			public HandmadeTileGenerator.Landmark.ActionFlags ActionFlags;

			[NamedArrayElement(new string[] { "Size" })]
			public LandmarkBehavioursBySize[] LandmarkBehaviours;
		}

		[Serializable]
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		internal struct SalvageableDistributer
		{
		}

		[SerializeField]
		private WorldRegionType _worldRegionType;

		[Tooltip("The amount of m2 per POI patch")]
		[SerializeField]
		private float _density;

		[Tooltip("The amount of variance allowed in the density as a percentage of the given density (e.g. 1 is 100%)")]
		[SerializeField]
		[MinMaxRangeFloat(0.5f, 2f)]
		private RangedFloat _densityVariance;

		[SerializeField]
		private PollutionLevels _pollutionLevels;

		[SerializeField]
		internal Distributer[] _landmarkDistributers;

		[SerializeField]
		internal SalvageableDistributer[] _salvageableLandmarkDistributer;

		[SerializeField]
		private PoissonDiskSamplerWithRegion _sampler;

		[SerializeField]
		private LandmarkBehaviourCollection _landmarkBehaviourCollection;

		public PoissonDiskSamplerWithRegion Sampler => _sampler;

		public void Initialize()
		{
		}

		public bool MatchesRegion(IRegion region)
		{
			if (region.Type == _worldRegionType)
			{
				return (region.PollutionLevel & _pollutionLevels) != 0;
			}
			return false;
		}

		public float ReturnRandomizedDensity()
		{
			return _density * _densityVariance.ReturnRandom();
		}

		public LandmarkBehaviour ReturnLandmarkBehaviour()
		{
			return _landmarkBehaviourCollection.ReturnNext();
		}
	}
}
