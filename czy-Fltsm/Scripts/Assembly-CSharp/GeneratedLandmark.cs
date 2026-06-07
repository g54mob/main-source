using System;
using UnityEngine;

public class GeneratedLandmark : Landmark
{
	[Serializable]
	private struct GenerationData
	{
		public Transform[] SpawnPoints;

		public LandmarkInteractable[] Interactables;

		public int MinimumSpawnCount;
	}

	[Header("Generation")]
	[SerializeField]
	private GenerationData[] _interactableGenerationData;

	public int Seed { get; private set; }

	public override void Initialize(LandmarkBehaviour behaviour)
	{
		Initialize(behaviour, UnityEngine.Random.Range(-32768, 32767));
	}

	public void Initialize(LandmarkBehaviour behaviour, int seed)
	{
		Seed = seed;
		UnityEngine.Random.State state = UnityEngine.Random.state;
		UnityEngine.Random.InitState(seed);
		GenerationData[] interactableGenerationData = _interactableGenerationData;
		foreach (GenerationData generationData in interactableGenerationData)
		{
			GenerateInteractables(generationData);
		}
		UnityEngine.Random.state = state;
		base.Initialize(behaviour);
	}

	private void GenerateInteractables(GenerationData generationData)
	{
		using ListPool<Transform>.List list = ListPool<Transform>.Get(generationData.SpawnPoints);
		int num = UnityEngine.Random.Range(Mathf.Max(1, generationData.MinimumSpawnCount), list.Count);
		for (int i = 0; i < num; i++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			Transform parent = list[index];
			list.RemoveAt(index);
			LandmarkInteractable landmarkInteractable = UnityEngine.Object.Instantiate(FlotsamGame.Random(generationData.Interactables), parent);
			landmarkInteractable.transform.localPosition = Vector3.zero;
			landmarkInteractable.transform.localRotation = Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.up);
		}
	}
}
