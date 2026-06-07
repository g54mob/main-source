using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public abstract class LandmarkClusterGeneratorBase : ScriptableObject
	{
		public LandmarkGeneratorBase LandmarkGenerator { get; private set; }

		public List<LandmarkGeneratorBase.Landmark> GeneratedLandmarks { get; private set; } = new List<LandmarkGeneratorBase.Landmark>();

		public void Initialize(LandmarkGeneratorBase landmarkGenerator)
		{
			LandmarkGenerator = landmarkGenerator;
		}

		public abstract void Run<T>(IRegion region, List<T> clusters) where T : ILandmarkCluster;

		protected void AddLandmark(ILandmarkBehaviourProvider landmarkBehaviourProvider, Vector2 position)
		{
			GeneratedLandmarks.Add(new LandmarkGeneratorBase.Landmark(landmarkBehaviourProvider, position));
			LandmarkGenerator.AddLandmark(landmarkBehaviourProvider, position);
		}

		public bool IsValidPosition(ILandmarkBehaviourProvider landmarkBehaviourProvider, Vector2 position)
		{
			if (!LandmarkGenerator.IsValidPosition(position))
			{
				return false;
			}
			foreach (LandmarkGeneratorBase.Landmark generatedLandmark in GeneratedLandmarks)
			{
				if (Vector2.Distance(generatedLandmark.Position, position) < generatedLandmark.LandmarkBehaviourProvider.Radius + landmarkBehaviourProvider.Radius)
				{
					return false;
				}
			}
			return true;
		}
	}
}
