using MoreMountains.Feedbacks;
using UnityEngine;

public class Plant : MonoBehaviour
{
	public PlantBed parentPlantBed;

	public BerryGrower[] berryGrowers;

	[SerializeField]
	private MMF_Player feedback_Growing;

	private void Awake()
	{
		parentPlantBed = GetComponentInParent<PlantBed>();
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
		base.transform.localScale = Vector3.zero;
		feedback_Growing?.ResetFeedbacks();
		feedback_Growing?.RestoreInitialValues();
		feedback_Growing?.PlayFeedbacks();
		AddGrowthDelayOffsetsToGrowers();
	}

	private void Update()
	{
		if (!(parentPlantBed.currentBerryProfile == null) && parentPlantBed.currentBerryProfile.tier != -1)
		{
			BerryGrower[] array = berryGrowers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].HandleGrowth();
			}
		}
	}

	public void ChangeBerryType(BerryProfile _newBerry)
	{
		BerryGrower[] array = berryGrowers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SelectNewBerryToGrow(_newBerry);
		}
	}

	public void AddGrowthDelayOffsetsToGrowers()
	{
		if (berryGrowers.Length > 1)
		{
			float num = parentPlantBed.currentBerryProfile.growthMaxTime / PlayerStats.Singleton.berryGrowthRate_Multiplier / (float)berryGrowers.Length;
			for (int i = 0; i < berryGrowers.Length; i++)
			{
				berryGrowers[i].delayBeforeGrowing = num * (float)i;
			}
		}
	}

	public void HaltProductionForOurGrowers()
	{
	}
}
