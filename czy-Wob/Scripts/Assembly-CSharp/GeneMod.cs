using System;
using UnityEngine;

[Serializable]
public class GeneMod
{
	public GeneticProperty geneticProperty;

	public float newValue;

	public bool absolute;

	public void ApplyMod(MasterDogGene masterGene)
	{
		if (masterGene.IsGeneticPropertyLooped(geneticProperty))
		{
			ApplyModLooped(masterGene);
			return;
		}
		GeneValue geneValues = masterGene.GetGeneValues(geneticProperty);
		string geneString = masterGene.GetGeneString(geneticProperty);
		float value = newValue;
		if (!absolute)
		{
			value = geneValues.GetValue() + newValue;
		}
		value = Mathf.Clamp(value, geneValues.GetMinValue(), geneValues.GetMaxValue());
		string geneSequenceFromValues = MathUtil.GetGeneSequenceFromValues(value, geneValues.GetMinValue(), geneValues.GetMaxValue(), geneString.Length);
		masterGene.UpdateGeneString(geneticProperty, geneSequenceFromValues);
	}

	private void ApplyModLooped(MasterDogGene masterGene)
	{
		LoopedGeneHolder loopedGeneHolder = masterGene.GetLoopedGeneHolder(geneticProperty);
		int length = loopedGeneHolder.GetRawGene().Length;
		string text = "";
		if (loopedGeneHolder.IsDiscrete())
		{
			int length2 = masterGene.GetGeneString(geneticProperty).Length;
			float num = (float)length2 / (float)length;
			if (length == length2)
			{
				text = MathUtil.GetGeneSequenceFromValues(0f, 0f, 1f, length);
			}
			else
			{
				text = MathUtil.GetGeneSequenceFromValues(0f, 0f, 1f, length - length2);
				int startIndex = Mathf.Min(Mathf.FloorToInt(newValue / num) * length2, length - length2);
				float num2 = newValue % num;
				float neededVal = num2 / num;
				if (num2 == 0f && newValue != 0f)
				{
					neededVal = 1f;
				}
				string geneSequenceFromValues = MathUtil.GetGeneSequenceFromValues(neededVal, 0f, 1f, length2);
				text = text.Insert(startIndex, geneSequenceFromValues);
			}
		}
		else
		{
			text = MathUtil.GetGeneSequenceFromValues(newValue, 0f, 1f, length);
		}
		masterGene.UpdateGeneString(geneticProperty, text);
	}
}
