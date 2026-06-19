using System.Collections.Generic;
using UnityEngine;

public class DogGeneManager : MonoBehaviour
{
	public string restoreGenomeSeed = "0";

	public string walkGenomeSeed = "0";

	public GameObject bodyFront;

	public GameObject bodyBack;

	public List<GameObject> legs;

	public string restoreGenome = "0";

	public string walkGenome = "0";

	private bool canAppraiseGenes;

	private Vector3 defaultPos;

	private Vector3 defaultRot;

	private Vector3 averagePos;

	private Vector3 averageRot;

	private float averagedWobbliness;

	private float averageLegRot;

	private int framesCounted;

	private float defaultX;

	private float farthestDistanceWalked;

	private Transform bodyTransform;

	private float zRotPenaltyBoundLower = 100f;

	private float zRotPenaltyBoundUpper = 260f;

	private bool hasTippedOver;

	private float currentScore;

	private bool initialized;

	private GeneticDogTrainer.TrainingMode trainingMode;

	public void Initialize()
	{
		averagePos = GetFrameAveragePos();
		averageRot = GetFrameAverageRot();
		defaultPos = averagePos;
		defaultRot = averageRot;
		averagedWobbliness = 1f;
		averageLegRot = 0f;
		if (restoreGenomeSeed != "0")
		{
			SetRestoreGenome(restoreGenomeSeed);
		}
		if (walkGenomeSeed != "0")
		{
			SetWalkGenome(walkGenomeSeed);
		}
		initialized = true;
	}

	private void Update()
	{
		if (initialized && canAppraiseGenes)
		{
			UpdateWobbliness();
			UpdateRestoration();
			CheckUprightStatus();
			if (trainingMode == GeneticDogTrainer.TrainingMode.Walk)
			{
				UpdateWalkDistance();
			}
			UpdateScore();
		}
	}

	public void StartGeneAppraisal()
	{
		canAppraiseGenes = true;
		GetComponent<LegController>().UnfreezeMotion();
	}

	public void SetCurrentlyTrainedGene(GeneticDogTrainer.TrainingMode trainingMode, string sequence)
	{
		this.trainingMode = trainingMode;
		SetTrainedGenome(sequence);
	}

	public void SetInitialTrainedPosition()
	{
		bodyTransform = base.transform.Find("Holder_Body").Find("Body_Front");
		defaultX = bodyTransform.position.x;
		if (trainingMode == GeneticDogTrainer.TrainingMode.Restore)
		{
			base.transform.Rotate(new Vector3(180f, 0f, 0f));
			base.transform.localPosition += new Vector3(0f, 2f, 1f);
		}
		else
		{
			_ = trainingMode;
			_ = 1;
		}
	}

	private void SetTrainedGenome(string genome)
	{
		if (trainingMode == GeneticDogTrainer.TrainingMode.Restore)
		{
			SetRestoreGenome(genome);
		}
		else if (trainingMode == GeneticDogTrainer.TrainingMode.Walk)
		{
			SetWalkGenome(genome);
		}
	}

	public string GetTrainedGenome()
	{
		if (trainingMode == GeneticDogTrainer.TrainingMode.Restore)
		{
			return GetRestoreGenome();
		}
		if (trainingMode == GeneticDogTrainer.TrainingMode.Walk)
		{
			return GetWalkGenome();
		}
		return "";
	}

	public void SetRestoreGenome(string restoreGenome)
	{
		this.restoreGenome = restoreGenome;
	}

	public string GetRestoreGenome()
	{
		return restoreGenome;
	}

	private void SetWalkGenome(string walkGenome)
	{
		this.walkGenome = walkGenome;
		ApplyWalkGenomeToDog();
	}

	public string GetWalkGenome()
	{
		return walkGenome;
	}

	private void ApplyWalkGenomeToDog()
	{
		int num = 1;
		int num2 = 0;
		float additionalNegativeMultiplier = 2f;
		int num3 = 24;
		List<AnimationCurve> list = new List<AnimationCurve>();
		for (int i = 0; i < num; i++)
		{
			float multiplier = DogWalkGene.CreateSmallMultiplierFromGeneSequence(walkGenome.Substring(num2, 2));
			num2 += 2;
			list.Add(DogWalkGene.CreateAnimationCurveFromGeneSequence(walkGenome.Substring(num2, num3), multiplier));
			num2 += num3;
			multiplier = DogWalkGene.CreateSmallMultiplierFromGeneSequence(walkGenome.Substring(num2, 2));
			num2 += 2;
			list.Add(DogWalkGene.CreateAnimationCurveFromGeneSequence(walkGenome.Substring(num2, num3), multiplier));
			num2 += num3;
			multiplier = DogWalkGene.CreateBigMultiplierFromGeneSequence(walkGenome.Substring(num2, 2));
			num2 += 2;
			list.Add(DogWalkGene.CreateAnimationCurveFromGeneSequence(walkGenome.Substring(num2, num3), multiplier, additionalNegativeMultiplier));
			num2 += num3;
		}
		AnimationCurve fZ = DogWalkGene.CreateAnimationCurveFromGeneSequence(walkGenome.Substring(num2, num3));
		num2 += num3;
		AnimationCurve bZ = DogWalkGene.CreateAnimationCurveFromGeneSequence(walkGenome.Substring(num2, num3));
		num2 += num3;
		float jiggleMultiplier = DogWalkGene.CreateJiggleMultiplierFromGeneSequence(walkGenome.Substring(num2, 2));
		num2 += 2;
		GetComponent<WalkController>().UpdateWalkingCurves(list, fZ, bZ, jiggleMultiplier);
	}

	private Vector3 GetFrameAveragePos()
	{
		return (bodyFront.transform.position + bodyBack.transform.position) / 2f;
	}

	private Vector3 GetFrameAverageRot()
	{
		return (bodyFront.transform.localEulerAngles + bodyBack.transform.localEulerAngles) / 2f;
	}

	private void UpdateWobbliness()
	{
		averagePos = (GetFrameAveragePos() + averagePos) / 2f;
		averageRot = (GetFrameAverageRot() + averageRot) / 2f;
		averagedWobbliness = (averagedWobbliness + (Vector3.Distance(averagePos, defaultPos) + Vector3.Distance(averageRot, defaultRot))) / 2f;
	}

	private void UpdateRestoration()
	{
		framesCounted++;
		float num = 0f;
		for (int i = 0; i < legs.Count; i++)
		{
			num += legs[i].GetComponent<RotationRestore>().GetDistanceFromTargetRotation();
		}
		num /= (float)legs.Count;
		if (num < 180f)
		{
			num *= 0.5f;
		}
		if (num < 10f)
		{
			num *= 0.1f;
		}
		averageLegRot += (num - averageLegRot) / (float)framesCounted;
	}

	private void UpdateWalkDistance()
	{
		float num = Mathf.Max(0f, (bodyTransform.position.x - defaultX) * -1f);
		if (num > farthestDistanceWalked)
		{
			farthestDistanceWalked = num;
		}
	}

	private void CheckUprightStatus()
	{
		if (!hasTippedOver)
		{
			float num = MathUtil.Mod(bodyTransform.localEulerAngles.z, 360f);
			if (num > zRotPenaltyBoundLower && num < zRotPenaltyBoundUpper)
			{
				hasTippedOver = true;
				currentScore /= 2f;
			}
		}
	}

	private void UpdateScore()
	{
		CalculateScore();
	}

	public void CalculateScore()
	{
		if (trainingMode == GeneticDogTrainer.TrainingMode.Restore)
		{
			if (averageLegRot == 0f)
			{
				currentScore = float.PositiveInfinity;
			}
			else
			{
				currentScore = 1f / averageLegRot;
			}
		}
		else if (trainingMode == GeneticDogTrainer.TrainingMode.Walk && !hasTippedOver)
		{
			currentScore = farthestDistanceWalked * 0.001f;
		}
	}

	public float GetScore()
	{
		return currentScore;
	}
}
