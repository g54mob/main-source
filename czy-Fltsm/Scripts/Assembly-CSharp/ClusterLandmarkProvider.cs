using System;
using System.Collections.Generic;
using PajamaLlama;
using UnityEngine;

[CreateAssetMenu(fileName = "Cluster Landmark Provider", menuName = "Flotsam/Landmarks/Cluster Landmark Provider")]
public class ClusterLandmarkProvider : ScriptableObject
{
	public struct Landmark
	{
		public ILandmarkBehaviourProvider LandmarkBehaviourProvider;

		public Vector2 Position;
	}

	private interface IEntry
	{
		bool TryGetLandmarkBehaviourCollection(out LandmarkBehaviourCollection landmarkBehaviourCollection);
	}

	[Serializable]
	private struct SingleEntry : IEntry
	{
		[Range(0f, 100f)]
		public float Chance;

		public LandmarkBehaviourCollection LandmarkBehaviourCollection;

		public bool TryGetLandmarkBehaviourCollection(out LandmarkBehaviourCollection landmarkBehaviourCollection)
		{
			if (UnityEngine.Random.value * 100f <= Chance)
			{
				landmarkBehaviourCollection = LandmarkBehaviourCollection;
				return true;
			}
			landmarkBehaviourCollection = null;
			return false;
		}
	}

	[Serializable]
	private struct WeightedListEntry : IEntry
	{
		[Range(0f, 100f)]
		public float Chance;

		public WeightedList<LandmarkBehaviourCollection> WeightedList;

		public bool TryGetLandmarkBehaviourCollection(out LandmarkBehaviourCollection landmarkBehaviourCollection)
		{
			if (UnityEngine.Random.value * 100f <= Chance)
			{
				landmarkBehaviourCollection = WeightedList.ReturnRandom();
				return true;
			}
			landmarkBehaviourCollection = null;
			return false;
		}
	}

	[SerializeReference]
	[InstantiateSerializeReference]
	private IEntry[] _primaryLandmarks;

	[SerializeField]
	private float _spawnRadius = 150f;

	public IEnumerator<ILandmarkBehaviourProvider> GetEnumerator()
	{
		IEntry[] primaryLandmarks = _primaryLandmarks;
		for (int i = 0; i < primaryLandmarks.Length; i++)
		{
			if (primaryLandmarks[i].TryGetLandmarkBehaviourCollection(out var landmarkBehaviourCollection))
			{
				yield return landmarkBehaviourCollection;
			}
		}
	}

	public Vector2 GetRandomSpawnPosition(Vector2 position, ILandmarkBehaviourProvider landmarkBehaviourProvider)
	{
		return position + UnityEngine.Random.insideUnitCircle * (_spawnRadius - landmarkBehaviourProvider.Radius);
	}
}
