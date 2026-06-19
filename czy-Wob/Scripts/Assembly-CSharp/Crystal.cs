using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Crystal", menuName = "Inventory/Crystal", order = 1)]
public class Crystal : ScriptableObject
{
	public string crystalName;

	public string crystalDescription;

	public Sprite iconSprite;

	public CrystalType crystalType;

	public bool swapLegs;

	public bool swapBody;

	public bool swapHead;

	public bool swapColor;

	private float smallMutationAmount = 10f;

	public string MutateGene(string gene, string geneName, bool discreteLoopedGene)
	{
		switch (crystalType)
		{
		case CrystalType.STANDARD:
			return gene;
		case CrystalType.BIG:
			return MutateBig(gene, geneName, discreteLoopedGene);
		case CrystalType.SMALL:
			return MutateSmall(gene, geneName, discreteLoopedGene);
		case CrystalType.REVERSE:
			return MutateReverse(gene, geneName, discreteLoopedGene);
		case CrystalType.UNSTABLE:
			return MutateUnstable(gene, geneName, discreteLoopedGene);
		case CrystalType.INVERT:
			return MutateInvert(gene, geneName, discreteLoopedGene);
		default:
			Debug.LogError("No MutateGene() implementation found for CrystalType: " + crystalType);
			return gene;
		}
	}

	private string MutateBig(string gene, string geneName, bool discreteLoopedGene)
	{
		if (discreteLoopedGene)
		{
			return gene;
		}
		bool flag = false;
		if (geneName.Contains("Minus"))
		{
			flag = true;
		}
		float floatFromGeneSequence = MathUtil.GetFloatFromGeneSequence(gene, 0f, 100f);
		floatFromGeneSequence = ((!flag) ? (floatFromGeneSequence + smallMutationAmount) : (floatFromGeneSequence - smallMutationAmount));
		floatFromGeneSequence = Mathf.Clamp(floatFromGeneSequence, 0f, 100f);
		return MathUtil.GetGeneSequenceFromValues(floatFromGeneSequence, 0f, 100f, gene.Length);
	}

	private string MutateSmall(string gene, string geneName, bool discreteLoopedGene)
	{
		if (discreteLoopedGene)
		{
			return gene;
		}
		bool flag = false;
		if (geneName.Contains("Minus"))
		{
			flag = true;
		}
		float floatFromGeneSequence = MathUtil.GetFloatFromGeneSequence(gene, 0f, 100f);
		floatFromGeneSequence = ((!flag) ? (floatFromGeneSequence - smallMutationAmount) : (floatFromGeneSequence + smallMutationAmount));
		floatFromGeneSequence = Mathf.Clamp(floatFromGeneSequence, 0f, 100f);
		return MathUtil.GetGeneSequenceFromValues(floatFromGeneSequence, 0f, 100f, gene.Length);
	}

	private string MutateReverse(string gene, string geneName, bool discreteLoopedGene)
	{
		string text = "";
		for (int num = gene.Length - 1; num >= 0; num--)
		{
			text += gene[num];
		}
		return text;
	}

	private string MutateUnstable(string gene, string geneName, bool discreteLoopedGene)
	{
		int num = 0;
		for (int i = 0; i < gene.Length - 1; i += 2)
		{
			num += int.Parse(gene[i].ToString());
			num += int.Parse(gene[i + 1].ToString());
		}
		num *= gene.Length;
		System.Random random = new System.Random(num);
		string text = "";
		for (int j = 0; j < gene.Length; j++)
		{
			text = ((random.Next(0, 10) < 5) ? (text + gene[j]) : ((gene[j] != '0') ? (text + "0") : (text + "1")));
		}
		return text;
	}

	private string MutateInvert(string gene, string geneName, bool discreteLoopedGene)
	{
		string text = "";
		for (int i = 0; i < gene.Length; i++)
		{
			text = ((gene[i] != '0') ? (text + "0") : (text + "1"));
		}
		return text;
	}
}
