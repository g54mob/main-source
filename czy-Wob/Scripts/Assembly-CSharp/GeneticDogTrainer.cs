using System.Collections.Generic;
using UnityEngine;

public class GeneticDogTrainer : MonoBehaviour
{
	public enum TrainingMode
	{
		Restore = 0,
		Walk = 1
	}

	public TrainingMode trainingMode;

	public string defaultSeed = "0";

	public GameObject dogPenPrefab;

	public float roundDuration = 2f;

	public float mutationRate = 0.001f;

	public float crossoverRate = 0.7f;

	public int pensPerRow = 5;

	public int numberOfRows = 11;

	public float penWidth = 15f;

	public float penLength = 15f;

	public List<Material> platformMaterialList = new List<Material>();

	public bool ascendGoodBoys = true;

	private float defaultDogPenY;

	private string dogPenSpawnerName = "Spawner";

	private string dogPenFacingName = "FacingObject";

	private GeneBase currentlyTrainedGene;

	private List<GameObject> dogPenList;

	private List<GameObject> dogList;

	private List<string> geneticInfo;

	private float currentRoundDuration;

	private int currentRound;

	private float alltimeBestScore = -1000f;

	private string alltimeBestGenome = "";

	private DogRegistration dogRegRef;

	private void Start()
	{
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		SetGeneInfo();
		InitializeDogPens();
		List<string> startingGenes = GetStartingGenes();
		StartNewRound(startingGenes);
	}

	private void Update()
	{
		dogList.Remove(null);
		currentRoundDuration += Time.deltaTime;
		if (currentRoundDuration >= roundDuration)
		{
			EndRound();
			return;
		}
		UpdatePenPositions();
		currentlyTrainedGene.Update();
	}

	public float GetCurrentRoundDuration()
	{
		return currentRoundDuration;
	}

	public List<GameObject> GetDogList()
	{
		return dogList;
	}

	private void SetGeneInfo()
	{
		if (trainingMode == TrainingMode.Restore)
		{
			currentlyTrainedGene = new DogRestoreGene(this);
		}
		else if (trainingMode == TrainingMode.Walk)
		{
			currentlyTrainedGene = new DogWalkGene(this);
		}
	}

	private void InitializeDogPens()
	{
		dogPenList = new List<GameObject>();
		for (int i = 0; i < pensPerRow * numberOfRows; i++)
		{
			GameObject gameObject = Object.Instantiate(dogPenPrefab, base.transform.position, base.transform.rotation);
			gameObject.transform.SetParent(base.transform);
			if (platformMaterialList.Count > 0)
			{
				for (int j = 0; j < gameObject.transform.childCount; j++)
				{
					gameObject.transform.GetChild(j).GetComponent<Renderer>().material = platformMaterialList[i % platformMaterialList.Count];
				}
			}
			float x = penWidth * (float)(i % pensPerRow);
			float z = penLength * (float)(i / pensPerRow);
			gameObject.transform.localPosition = Vector3.zero + new Vector3(x, 0f, z);
			gameObject.transform.Find(dogPenSpawnerName).GetComponent<Renderer>().enabled = false;
			Transform transform = gameObject.transform.Find(dogPenFacingName);
			if (transform != null)
			{
				transform.GetComponent<Renderer>().enabled = false;
			}
			dogPenList.Add(gameObject);
		}
	}

	private List<string> GetStartingGenes()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < dogPenList.Count; i++)
		{
			if (defaultSeed.Length < 2)
			{
				list.Add(currentlyTrainedGene.GenerateRandomGene());
			}
			else
			{
				list.Add(defaultSeed);
			}
		}
		return list;
	}

	private void StartNewRound(List<string> newGeneticInfo)
	{
		geneticInfo = newGeneticInfo;
		ResetPens();
		currentlyTrainedGene.ResetGeneAppraisal();
		currentRound++;
		currentRoundDuration = 0f;
		dogList = new List<GameObject>();
		for (int i = 0; i < dogPenList.Count; i++)
		{
			Transform transform = dogPenList[i].transform.Find(dogPenSpawnerName);
			dogRegRef.RequestNewDog(transform.position, transform.localRotation, null, null, manualDog: false, DogCreationCallback, playerOwned: false, useBaseGeneWithoutMutation: true, timeslice: false);
		}
	}

	private void DogCreationCallback(GameObject newDog)
	{
		if (!(newDog == null))
		{
			dogList.Add(newDog);
			int index = dogList.Count - 1;
			Transform newFacingObj = dogPenList[index].transform.Find(dogPenFacingName);
			newDog.GetComponent<DogGeneManager>().SetInitialTrainedPosition();
			newDog.GetComponent<LegController>().FreezeMotion();
			newDog.GetComponent<DogLooks>().UseUnmutatedBaseGenome();
			newDog.GetComponent<WalkController>().SetTrainingMode();
			newDog.GetComponent<WalkController>().turningEnabled = false;
			newDog.GetComponent<WalkController>().SetFacingTarget(newFacingObj);
			newDog.GetComponent<DogGeneManager>().SetCurrentlyTrainedGene(trainingMode, geneticInfo[index]);
			newDog.transform.parent = dogPenList[index].transform;
		}
	}

	private void EndRound()
	{
		currentlyTrainedGene.OnRoundEnded();
		ScoreDogGenetics(dogList);
		FindBestScore();
		List<string> newGeneticInfo = BreedDogs(dogList);
		MutateGeneticInfo(ref newGeneticInfo);
		for (int i = 0; i < dogList.Count; i++)
		{
			Object.Destroy(dogList[i]);
		}
		dogList.Clear();
		StartNewRound(newGeneticInfo);
	}

	private void FindBestScore()
	{
		float num = -10000f;
		string text = "";
		for (int i = 0; i < dogList.Count; i++)
		{
			float score = dogList[i].GetComponent<DogGeneManager>().GetScore();
			if (score > num)
			{
				num = score;
				text = dogList[i].GetComponent<DogGeneManager>().GetTrainedGenome();
			}
		}
		MonoBehaviour.print("Round: " + currentRound + " Best Score: " + num);
		if (num > alltimeBestScore)
		{
			alltimeBestScore = num;
			alltimeBestGenome = text;
			MonoBehaviour.print("All Time Best Score: " + alltimeBestScore + " All Time Best Genome: " + alltimeBestGenome);
		}
	}

	private void ScoreDogGenetics(List<GameObject> dogList)
	{
		for (int i = 0; i < dogList.Count; i++)
		{
			if (!(dogList[i] == null))
			{
				dogList[i].GetComponent<DogGeneManager>().CalculateScore();
			}
		}
	}

	private List<string> BreedDogs(List<GameObject> dogList)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < dogList.Count; i++)
		{
			GameObject weightedRandomDog = GetWeightedRandomDog(dogList);
			GameObject weightedRandomDog2 = GetWeightedRandomDog(dogList, weightedRandomDog);
			list.Add(CombineGeneticInfo(weightedRandomDog.GetComponent<DogGeneManager>().GetTrainedGenome(), weightedRandomDog2.GetComponent<DogGeneManager>().GetTrainedGenome()));
		}
		return list;
	}

	private string CombineGeneticInfo(string genomeA, string genomeB)
	{
		if (Random.Range(0f, 1f) <= crossoverRate)
		{
			return CrossoverGenomes(genomeA, genomeB);
		}
		return genomeA;
	}

	private string CrossoverGenomes(string a, string b)
	{
		return MasterDogGene.CrossoverGenes(a, b);
	}

	private GameObject GetWeightedRandomDog(List<GameObject> dogList, GameObject dogToAvoid = null)
	{
		float num = 0f;
		GameObject result = dogList[0];
		for (int i = 1; i < dogList.Count; i++)
		{
			GameObject gameObject = dogList[i];
			if (!(gameObject == dogToAvoid))
			{
				float score = gameObject.GetComponent<DogGeneManager>().GetScore();
				if (Random.Range(0f, score + num) >= num)
				{
					result = gameObject;
				}
				num += score;
			}
		}
		return result;
	}

	private void MutateGeneticInfo(ref List<string> geneticInfo)
	{
		for (int i = 0; i < geneticInfo.Count; i++)
		{
			string text = geneticInfo[i];
			string text2 = "";
			int length = text.Length;
			for (int j = 0; j < length; j++)
			{
				if (Random.Range(0f, 1f) <= mutationRate)
				{
					int num = int.Parse(new string(text[j], 1));
					string text3 = text2;
					int num2 = (num ^= 1);
					text2 = text3 + num2;
				}
				else
				{
					text2 += text[j];
				}
			}
			geneticInfo[i] = text2;
		}
	}

	private void ResetPens()
	{
		for (int i = 0; i < dogPenList.Count; i++)
		{
			Vector3 position = dogPenList[i].transform.position;
			dogPenList[i].transform.position = new Vector3(position.x, defaultDogPenY, position.z);
		}
	}

	private void UpdatePenPositions()
	{
		if (ascendGoodBoys)
		{
			MonoBehaviour.print("Ascension functionality is broken. Please either fix it or turn it off");
		}
	}
}
