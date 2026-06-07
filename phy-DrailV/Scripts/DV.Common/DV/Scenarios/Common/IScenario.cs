using System.ComponentModel;
using DV.Common;
using UnityEngine;

namespace DV.Scenarios.Common
{
	public interface IScenario : IScenariosThing, IThing, INotifyPropertyChanged
	{
		bool RandomTrain { get; set; }

		ITrain Train { get; set; }

		Vector3 PlayerPosition { get; set; }

		float PlayerRotationY { get; set; }

		bool RandomStartingTrackID { get; set; }

		string StartingTrackID { get; set; }

		bool ReverseTrain { get; set; }

		bool RandomDestinationTrackID { get; set; }

		string DestinationTrackID { get; set; }

		bool RandomTimeOfDay { get; set; }

		int TimeOfDay { get; set; }

		bool RandomCloudsPercentage { get; set; }

		int CloudsPercentage { get; set; }

		bool RandomFogPercentage { get; set; }

		int FogPercentage { get; set; }

		bool RandomWetnessPercentage { get; set; }

		int WetnessPercentage { get; set; }

		bool RandomRainPercentage { get; set; }

		int RainPercentage { get; set; }

		bool RandomLightningPercentage { get; set; }

		int LightningPercentage { get; set; }

		int StartingWeatherDuration { get; set; }

		bool RandomSeed { get; set; }

		string Seed { get; set; }
	}
}
