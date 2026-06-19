using UnityEngine;

public class GeneBase
{
	protected int geneSize = -1;

	protected GeneticDogTrainer.TrainingMode trainingMode;

	protected bool geneAppraisalStarted;

	public int GeneSize => geneSize;

	public GeneticDogTrainer.TrainingMode TrainingMode => trainingMode;

	public virtual void Update()
	{
	}

	public virtual void ResetGeneAppraisal()
	{
		geneAppraisalStarted = false;
	}

	public virtual void OnRoundEnded()
	{
	}

	public virtual string GenerateRandomGene()
	{
		string text = "";
		for (int i = 0; i < GeneSize; i++)
		{
			text = ((!(Random.value >= 0.5f)) ? (text + "1") : (text + "0"));
		}
		return text;
	}
}
