using System;
using System.Collections.Generic;
using UnityEngine;

public class DogRestoreGene : GeneBase
{
	private GeneticDogTrainer activeTrainer;

	protected InputSimulator inputSimulator;

	private float restoreInputDuration;

	private float waitDuration;

	public DogRestoreGene(GeneticDogTrainer trainer)
	{
		geneSize = 54;
		trainingMode = GeneticDogTrainer.TrainingMode.Restore;
		activeTrainer = trainer;
		inputSimulator = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InputSimulator>(GlobalObject.INPUT_SIMULATOR);
	}

	public override void Update()
	{
		base.Update();
		SimulateRoundInput();
	}

	public override void OnRoundEnded()
	{
		base.OnRoundEnded();
		inputSimulator.ClearInput();
	}

	private void SimulateRoundInput()
	{
		if (activeTrainer.GetCurrentRoundDuration() < waitDuration || !(activeTrainer.GetCurrentRoundDuration() > restoreInputDuration))
		{
			return;
		}
		inputSimulator.ClearInput();
		if (!geneAppraisalStarted)
		{
			geneAppraisalStarted = true;
			List<GameObject> dogList = activeTrainer.GetDogList();
			for (int i = 0; i < dogList.Count; i++)
			{
				dogList[i].GetComponent<DogGeneManager>().StartGeneAppraisal();
			}
		}
	}

	public static AnimationCurve CreateAnimationCurveFromGeneSequence(string sequence)
	{
		AnimationCurve curve = new AnimationCurve();
		curve.AddKey(0f, 0f);
		curve.AddKey(2f, 0f);
		AddKey(ref curve, 0.5f, sequence.Substring(0, 6));
		AddKey(ref curve, 1f, sequence.Substring(6, 6));
		AddKey(ref curve, 1.5f, sequence.Substring(12, 6));
		curve.postWrapMode = WrapMode.Loop;
		return curve;
	}

	private static void AddKey(ref AnimationCurve curve, float time, string sequence)
	{
		int multiplierFromGeneSequence = GetMultiplierFromGeneSequence(sequence.Substring(0, 2));
		if (multiplierFromGeneSequence != -1)
		{
			curve.AddKey(time, GetFloatFromGeneSequence(sequence.Substring(2, 4), multiplierFromGeneSequence));
		}
	}

	private static float GetFloatFromGeneSequence(string sequence, int baseMultiplier)
	{
		return Convert.ToInt64(sequence, 2) * baseMultiplier;
	}

	private static int GetMultiplierFromGeneSequence(string sequence)
	{
		switch (sequence)
		{
		case "00":
			return 0;
		case "01":
			return 50;
		case "10":
			return 75;
		default:
			return -1;
		}
	}
}
