using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public interface ILandmarkCluster
	{
		Vector2 Position { get; }

		int Count { get; }

		void Add(ILandmarkBehaviourProvider landmarkBehaviourProvider, Vector2 position);
	}
}
