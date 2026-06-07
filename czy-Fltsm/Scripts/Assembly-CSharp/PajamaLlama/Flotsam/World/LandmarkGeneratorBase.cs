using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public abstract class LandmarkGeneratorBase : ScriptableObject
	{
		public struct Landmark
		{
			public ILandmarkBehaviourProvider LandmarkBehaviourProvider;

			public Vector2 Position;

			public Landmark(ILandmarkBehaviourProvider landmarkBehaviourProvider, Vector2 position)
			{
				LandmarkBehaviourProvider = landmarkBehaviourProvider;
				Position = position;
			}
		}

		public abstract List<Landmark> GeneratedLandmarks { get; }

		public abstract void Run(IRegion region);

		public abstract bool IsValidPosition(Vector2 position);

		public abstract void AddLandmark(ILandmarkBehaviourProvider landmarkBehaviourProvider, Vector2 position);
	}
}
