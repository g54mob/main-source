using System;
using System.Collections.Generic;
using UnityEngine;

public class DogWalkGene : GeneBase
{
	private GeneticDogTrainer activeTrainer;

	protected InputSimulator inputSimulator;

	private List<KeyCode> simulatedInput = new List<KeyCode>();

	private float waitDuration = 3f;

	public DogWalkGene(GeneticDogTrainer trainer)
	{
		geneSize = 128;
		trainingMode = GeneticDogTrainer.TrainingMode.Walk;
		activeTrainer = trainer;
		inputSimulator = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InputSimulator>(GlobalObject.INPUT_SIMULATOR);
		simulatedInput.Add(KeyBindings.WALK_KEY);
	}

	public override void Update()
	{
		base.Update();
		if (activeTrainer.GetCurrentRoundDuration() < waitDuration)
		{
			return;
		}
		if (!geneAppraisalStarted)
		{
			geneAppraisalStarted = true;
			List<GameObject> dogList = activeTrainer.GetDogList();
			for (int i = 0; i < dogList.Count; i++)
			{
				dogList[i].GetComponent<DogGeneManager>().StartGeneAppraisal();
			}
		}
		if (geneAppraisalStarted)
		{
			inputSimulator.SimulateInputList(simulatedInput);
		}
	}

	public override void OnRoundEnded()
	{
		base.OnRoundEnded();
		inputSimulator.ClearInput();
	}

	public static float CreateJiggleMultiplierFromGeneSequence(string sequence)
	{
		return MathUtil.GetFloatFromGeneSequence(sequence, 0.7f, 1f);
	}

	public static float CreateSmallMultiplierFromGeneSequence(string sequence)
	{
		return MathUtil.GetFloatFromGeneSequence(sequence, 0f, 0.3f);
	}

	public static float CreateBigMultiplierFromGeneSequence(string sequence)
	{
		return MathUtil.GetFloatFromGeneSequence(sequence, 1f, 1.3f);
	}

	public static AnimationCurve CreatePrimerAnimationCurve()
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(0f, 0f);
		animationCurve.AddKey(0.25f, -100f);
		return animationCurve;
	}

	public static AnimationCurve CreateAnimationCurveFromGeneSequence(string sequence, float multiplier = 1f, float additionalNegativeMultiplier = 1f)
	{
		int num = 8;
		AnimationCurve curve = new AnimationCurve();
		float time = 0f;
		curve.AddKey(time, 0f);
		time = 1f;
		curve.AddKey(time, 0f);
		time = 0.25f;
		AddKey(ref curve, time, sequence.Substring(0, num), multiplier, additionalNegativeMultiplier);
		time = 0.5f;
		AddKey(ref curve, time, sequence.Substring(num, num), multiplier, additionalNegativeMultiplier);
		time = 0.75f;
		AddKey(ref curve, time, sequence.Substring(num * 2, num), multiplier, additionalNegativeMultiplier);
		curve.postWrapMode = WrapMode.Loop;
		return curve;
	}

	private static float WrapTime(float time, float max)
	{
		while (time > max)
		{
			time -= max;
		}
		return time;
	}

	private static void AddKey(ref AnimationCurve curve, float time, string sequence, float multiplier = 1f, float additionalNegativeMultiplier = 1f)
	{
		float num = GetMultiplierFromGeneSequence(sequence.Substring(0, 3)) * multiplier;
		if (sequence[3] == '0')
		{
			num *= 0f - additionalNegativeMultiplier;
		}
		curve.AddKey(time, GetFloatFromGeneSequence(sequence.Substring(4, 4), num));
	}

	private static float GetFloatFromGeneSequence(string sequence, float baseMultiplier)
	{
		return (float)Convert.ToInt64(sequence, 2) * baseMultiplier;
	}

	private static float GetMultiplierFromGeneSequence(string sequence)
	{
		return MathUtil.GetFloatFromGeneSequence(sequence, 0f, 42f);
	}
}
