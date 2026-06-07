using System.ComponentModel;
using DV.Common;
using DV.Scenarios.Common;
using Newtonsoft.Json;
using UnityEngine;

namespace DV.Scenarios
{
	public class Scenario : Thing, IScenario, IScenariosThing, IThing, INotifyPropertyChanged
	{
		private bool _randomTrain;

		internal ITrain _train;

		private Vector3 _playerPosition;

		private float _playerRotationY;

		private bool _randomStartingTrackID;

		private string _startingTrackID;

		private bool _reverseTrain;

		private bool _randomDestinationTrackID;

		private string _destinationTrackID;

		private bool _randomTimeOfDay;

		private int _timeOfDay;

		private bool _randomCloudsPercentage;

		private int _cloudsPercentage;

		private bool _randomFogPercentage;

		private int _fogPercentage;

		private bool _randomWetnessPercentage;

		private int _wetnessPercentage;

		private bool _randomRainPercentage;

		private int _rainPercentage;

		private bool _randomLightningPercentage;

		private int _lightningPercentage;

		private int _startingWeatherDuration;

		private bool _randomSeed;

		private string _seed;

		public override string FileExtension => "dvscenario";

		[JsonProperty]
		public bool RandomTrain
		{
			get
			{
				return _randomTrain;
			}
			set
			{
				SetField(ref _randomTrain, value, "RandomTrain");
			}
		}

		[JsonProperty]
		public ITrain Train
		{
			get
			{
				return _train;
			}
			set
			{
				SetField(ref _train, value, "Train");
			}
		}

		[JsonProperty]
		public Vector3 PlayerPosition
		{
			get
			{
				return _playerPosition;
			}
			set
			{
				SetField(ref _playerPosition, value, "PlayerPosition");
			}
		}

		[JsonProperty]
		public float PlayerRotationY
		{
			get
			{
				return _playerRotationY;
			}
			set
			{
				SetField(ref _playerRotationY, value, "PlayerRotationY");
			}
		}

		[JsonProperty]
		public bool RandomStartingTrackID
		{
			get
			{
				return _randomStartingTrackID;
			}
			set
			{
				SetField(ref _randomStartingTrackID, value, "RandomStartingTrackID");
			}
		}

		[JsonProperty]
		public string StartingTrackID
		{
			get
			{
				return _startingTrackID;
			}
			set
			{
				SetField(ref _startingTrackID, value, "StartingTrackID");
			}
		}

		[JsonProperty]
		public bool ReverseTrain
		{
			get
			{
				return _reverseTrain;
			}
			set
			{
				SetField(ref _reverseTrain, value, "ReverseTrain");
			}
		}

		[JsonProperty]
		public bool RandomDestinationTrackID
		{
			get
			{
				return _randomDestinationTrackID;
			}
			set
			{
				SetField(ref _randomDestinationTrackID, value, "RandomDestinationTrackID");
			}
		}

		[JsonProperty]
		public string DestinationTrackID
		{
			get
			{
				return _destinationTrackID;
			}
			set
			{
				SetField(ref _destinationTrackID, value, "DestinationTrackID");
			}
		}

		[JsonProperty]
		public bool RandomTimeOfDay
		{
			get
			{
				return _randomTimeOfDay;
			}
			set
			{
				SetField(ref _randomTimeOfDay, value, "RandomTimeOfDay");
			}
		}

		[JsonProperty]
		public int TimeOfDay
		{
			get
			{
				return _timeOfDay;
			}
			set
			{
				SetField(ref _timeOfDay, value, "TimeOfDay");
			}
		}

		[JsonProperty]
		public bool RandomCloudsPercentage
		{
			get
			{
				return _randomCloudsPercentage;
			}
			set
			{
				SetField(ref _randomCloudsPercentage, value, "RandomCloudsPercentage");
			}
		}

		[JsonProperty]
		public int CloudsPercentage
		{
			get
			{
				return _cloudsPercentage;
			}
			set
			{
				SetField(ref _cloudsPercentage, value, "CloudsPercentage");
			}
		}

		[JsonProperty]
		public bool RandomFogPercentage
		{
			get
			{
				return _randomFogPercentage;
			}
			set
			{
				SetField(ref _randomFogPercentage, value, "RandomFogPercentage");
			}
		}

		[JsonProperty]
		public int FogPercentage
		{
			get
			{
				return _fogPercentage;
			}
			set
			{
				SetField(ref _fogPercentage, value, "FogPercentage");
			}
		}

		[JsonProperty]
		public bool RandomWetnessPercentage
		{
			get
			{
				return _randomWetnessPercentage;
			}
			set
			{
				SetField(ref _randomWetnessPercentage, value, "RandomWetnessPercentage");
			}
		}

		[JsonProperty]
		public int WetnessPercentage
		{
			get
			{
				return _wetnessPercentage;
			}
			set
			{
				SetField(ref _wetnessPercentage, value, "WetnessPercentage");
			}
		}

		[JsonProperty]
		public bool RandomRainPercentage
		{
			get
			{
				return _randomRainPercentage;
			}
			set
			{
				SetField(ref _randomRainPercentage, value, "RandomRainPercentage");
			}
		}

		[JsonProperty]
		public int RainPercentage
		{
			get
			{
				return _rainPercentage;
			}
			set
			{
				SetField(ref _rainPercentage, value, "RainPercentage");
			}
		}

		[JsonProperty]
		public bool RandomLightningPercentage
		{
			get
			{
				return _randomLightningPercentage;
			}
			set
			{
				SetField(ref _randomLightningPercentage, value, "RandomLightningPercentage");
			}
		}

		[JsonProperty]
		public int LightningPercentage
		{
			get
			{
				return _lightningPercentage;
			}
			set
			{
				SetField(ref _lightningPercentage, value, "LightningPercentage");
			}
		}

		[JsonProperty]
		public int StartingWeatherDuration
		{
			get
			{
				return _startingWeatherDuration;
			}
			set
			{
				SetField(ref _startingWeatherDuration, value, "StartingWeatherDuration");
			}
		}

		[JsonProperty]
		public bool RandomSeed
		{
			get
			{
				return _randomSeed;
			}
			set
			{
				SetField(ref _randomSeed, value, "RandomSeed");
			}
		}

		[JsonProperty]
		public string Seed
		{
			get
			{
				return _seed;
			}
			set
			{
				SetField(ref _seed, value, "Seed");
			}
		}
	}
}
