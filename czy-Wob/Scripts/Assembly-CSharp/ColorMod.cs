using System;
using UnityEngine;

[Serializable]
public class ColorMod
{
	public Color newColor;

	public Color newEmissionColor;

	public bool body;

	public bool legs;

	public bool noseEars;

	public bool pattern;

	public void ApplyMod(MasterDogGene masterGene)
	{
		MutateTowardsColor(masterGene, newColor, newEmissionColor, body, legs, noseEars, pattern);
	}

	public static void MutateTowardsColor(MasterDogGene dogGene, Color chosenColor, Color chosenEmissionColor, bool mutateBody, bool mutateLegs, bool mutateNoseEars, bool mutatePattern)
	{
		DogLooks component = dogGene.GetComponent<DogLooks>();
		if (mutateBody)
		{
			Material defaultBodyMaterial = component.GetDefaultBodyMaterial();
			int length = dogGene.GetGeneString(GeneticProperty.BodyColorRPlus).Length;
			int length2 = dogGene.GetGeneString(GeneticProperty.BodyEmissionColorRPlus).Length;
			UpdateDogColorGene(dogGene, defaultBodyMaterial, chosenColor, chosenEmissionColor, length, length2, component.BodyMatColorRMin, component.BodyMatColorRMax, component.BodyMatColorGMin, component.BodyMatColorGMax, component.BodyMatColorBMin, component.BodyMatColorBMax, component.BodyMatEmissionColorRMin, component.BodyMatEmissionColorRMax, component.BodyMatEmissionColorGMin, component.BodyMatEmissionColorGMax, component.BodyMatEmissionColorBMin, component.BodyMatEmissionColorBMax, body: true);
		}
		if (mutateLegs)
		{
			Material defaultLegMaterial = component.GetDefaultLegMaterial();
			int length3 = dogGene.GetGeneString(GeneticProperty.LegColorRPlus).Length;
			int length4 = dogGene.GetGeneString(GeneticProperty.LegEmissionColorRPlus).Length;
			UpdateDogColorGene(dogGene, defaultLegMaterial, chosenColor, chosenEmissionColor, length3, length4, component.LegMatColorRMin, component.LegMatColorRMax, component.LegMatColorGMin, component.LegMatColorGMax, component.LegMatColorBMin, component.LegMatColorBMax, component.LegMatEmissionColorRMin, component.LegMatEmissionColorRMax, component.LegMatEmissionColorGMin, component.LegMatEmissionColorGMax, component.LegMatEmissionColorBMin, component.LegMatEmissionColorBMax, body: false, legs: true);
		}
		if (mutateNoseEars)
		{
			Material defaultNoseEarMaterial = component.GetDefaultNoseEarMaterial();
			int length5 = dogGene.GetGeneString(GeneticProperty.NoseEarColorRPlus).Length;
			int length6 = dogGene.GetGeneString(GeneticProperty.NoseEarEmissionColorRPlus).Length;
			UpdateDogColorGene(dogGene, defaultNoseEarMaterial, chosenColor, chosenEmissionColor, length5, length6, component.NoseEarMatColorRMin, component.NoseEarMatColorRMax, component.NoseEarMatColorGMin, component.NoseEarMatColorGMax, component.NoseEarMatColorBMin, component.NoseEarMatColorBMax, component.NoseEarMatEmissionColorRMin, component.NoseEarMatEmissionColorRMax, component.NoseEarMatEmissionColorGMin, component.NoseEarMatEmissionColorGMax, component.NoseEarMatEmissionColorBMin, component.NoseEarMatEmissionColorBMax, body: false, legs: false, noseEars: true);
		}
		if (mutatePattern)
		{
			Material material = component.GetBodyPatternMaterial();
			if (material == null)
			{
				material = component.GetDefaultBodyPatternMaterial();
			}
			int length7 = dogGene.GetGeneString(GeneticProperty.PatternColorRPlus).Length;
			UpdateDogColorGene(dogGene, material, chosenColor, chosenEmissionColor, length7, length7, component.BodyPatternMatColorRMin, component.BodyPatternMatColorRMax, component.BodyPatternMatColorGMin, component.BodyPatternMatColorGMax, component.BodyPatternMatColorBMin, component.BodyPatternMatColorBMax, component.BodyPatternMatEmissionColorRMin, component.BodyPatternMatEmissionColorRMax, component.BodyPatternMatEmissionColorGMin, component.BodyPatternMatEmissionColorGMax, component.BodyPatternMatEmissionColorBMin, component.BodyPatternMatEmissionColorBMax, body: false, legs: false, noseEars: false, pattern: true);
		}
	}

	private static void UpdateDogColorGene(MasterDogGene dogGene, Material defaultMaterial, Color neededColor, Color neededEmissionColor, int colorGeneLen, int eColorGeneLen, float minR, float maxR, float minG, float maxG, float minB, float maxB, float minER, float maxER, float minEG, float maxEG, float minEB, float maxEB, bool body = false, bool legs = false, bool noseEars = false, bool pattern = false)
	{
		Color color = defaultMaterial.color;
		Color color2 = defaultMaterial.GetColor("_EmissionColor");
		float neededPlus = 0f;
		float neededMinus = 0f;
		float neededPlus2 = 0f;
		float neededMinus2 = 0f;
		float neededPlus3 = 0f;
		float neededMinus3 = 0f;
		float neededPlus4 = 0f;
		float neededMinus4 = color2.r;
		float neededPlus5 = 0f;
		float neededMinus5 = color2.g;
		float neededPlus6 = 0f;
		float neededMinus6 = color2.b;
		SetNeededColors(neededColor.r - color.r, ref neededPlus, ref neededMinus);
		SetNeededColors(neededColor.g - color.g, ref neededPlus2, ref neededMinus2);
		SetNeededColors(neededColor.b - color.b, ref neededPlus3, ref neededMinus3);
		SetNeededColors(neededEmissionColor.r - color2.r, ref neededPlus4, ref neededMinus4);
		SetNeededColors(neededEmissionColor.g - color2.g, ref neededPlus5, ref neededMinus5);
		SetNeededColors(neededEmissionColor.b - color2.b, ref neededPlus6, ref neededMinus6);
		string geneSequenceFromValues = MathUtil.GetGeneSequenceFromValues(neededPlus, 0f, maxR, colorGeneLen);
		string geneSequenceFromValues2 = MathUtil.GetGeneSequenceFromValues(neededMinus, 0f, minR, colorGeneLen);
		string geneSequenceFromValues3 = MathUtil.GetGeneSequenceFromValues(neededPlus2, 0f, maxG, colorGeneLen);
		string geneSequenceFromValues4 = MathUtil.GetGeneSequenceFromValues(neededMinus2, 0f, minG, colorGeneLen);
		string geneSequenceFromValues5 = MathUtil.GetGeneSequenceFromValues(neededPlus3, 0f, maxB, colorGeneLen);
		string geneSequenceFromValues6 = MathUtil.GetGeneSequenceFromValues(neededMinus3, 0f, minB, colorGeneLen);
		string geneSequenceFromValues7 = MathUtil.GetGeneSequenceFromValues(neededPlus4, 0f, maxER, eColorGeneLen);
		string geneSequenceFromValues8 = MathUtil.GetGeneSequenceFromValues(neededMinus4, 0f, minER, eColorGeneLen);
		string geneSequenceFromValues9 = MathUtil.GetGeneSequenceFromValues(neededPlus5, 0f, maxEG, eColorGeneLen);
		string geneSequenceFromValues10 = MathUtil.GetGeneSequenceFromValues(neededMinus5, 0f, minEG, eColorGeneLen);
		string geneSequenceFromValues11 = MathUtil.GetGeneSequenceFromValues(neededPlus6, 0f, maxEB, eColorGeneLen);
		string geneSequenceFromValues12 = MathUtil.GetGeneSequenceFromValues(neededMinus6, 0f, minEB, eColorGeneLen);
		if (body)
		{
			dogGene.UpdateGeneString(GeneticProperty.BodyColorRPlus, geneSequenceFromValues);
			dogGene.UpdateGeneString(GeneticProperty.BodyColorRMinus, geneSequenceFromValues2);
			dogGene.UpdateGeneString(GeneticProperty.BodyColorGPlus, geneSequenceFromValues3);
			dogGene.UpdateGeneString(GeneticProperty.BodyColorGMinus, geneSequenceFromValues4);
			dogGene.UpdateGeneString(GeneticProperty.BodyColorBPlus, geneSequenceFromValues5);
			dogGene.UpdateGeneString(GeneticProperty.BodyColorBMinus, geneSequenceFromValues6);
			dogGene.UpdateGeneString(GeneticProperty.BodyEmissionColorRPlus, geneSequenceFromValues7);
			dogGene.UpdateGeneString(GeneticProperty.BodyEmissionColorRMinus, geneSequenceFromValues8);
			dogGene.UpdateGeneString(GeneticProperty.BodyEmissionColorGPlus, geneSequenceFromValues9);
			dogGene.UpdateGeneString(GeneticProperty.BodyEmissionColorGMinus, geneSequenceFromValues10);
			dogGene.UpdateGeneString(GeneticProperty.BodyEmissionColorBPlus, geneSequenceFromValues11);
			dogGene.UpdateGeneString(GeneticProperty.BodyEmissionColorBMinus, geneSequenceFromValues12);
		}
		if (legs)
		{
			dogGene.UpdateGeneString(GeneticProperty.LegColorRPlus, geneSequenceFromValues);
			dogGene.UpdateGeneString(GeneticProperty.LegColorRMinus, geneSequenceFromValues2);
			dogGene.UpdateGeneString(GeneticProperty.LegColorGPlus, geneSequenceFromValues3);
			dogGene.UpdateGeneString(GeneticProperty.LegColorGMinus, geneSequenceFromValues4);
			dogGene.UpdateGeneString(GeneticProperty.LegColorBPlus, geneSequenceFromValues5);
			dogGene.UpdateGeneString(GeneticProperty.LegColorBMinus, geneSequenceFromValues6);
			dogGene.UpdateGeneString(GeneticProperty.LegEmissionColorRPlus, geneSequenceFromValues7);
			dogGene.UpdateGeneString(GeneticProperty.LegEmissionColorRMinus, geneSequenceFromValues8);
			dogGene.UpdateGeneString(GeneticProperty.LegEmissionColorGPlus, geneSequenceFromValues9);
			dogGene.UpdateGeneString(GeneticProperty.LegEmissionColorGMinus, geneSequenceFromValues10);
			dogGene.UpdateGeneString(GeneticProperty.LegEmissionColorBPlus, geneSequenceFromValues11);
			dogGene.UpdateGeneString(GeneticProperty.LegEmissionColorBMinus, geneSequenceFromValues12);
		}
		if (noseEars)
		{
			dogGene.UpdateGeneString(GeneticProperty.NoseEarColorRPlus, geneSequenceFromValues);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarColorRMinus, geneSequenceFromValues2);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarColorGPlus, geneSequenceFromValues3);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarColorGMinus, geneSequenceFromValues4);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarColorBPlus, geneSequenceFromValues5);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarColorBMinus, geneSequenceFromValues6);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarEmissionColorRPlus, geneSequenceFromValues7);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarEmissionColorRMinus, geneSequenceFromValues8);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarEmissionColorGPlus, geneSequenceFromValues9);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarEmissionColorGMinus, geneSequenceFromValues10);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarEmissionColorBPlus, geneSequenceFromValues11);
			dogGene.UpdateGeneString(GeneticProperty.NoseEarEmissionColorBMinus, geneSequenceFromValues12);
		}
		if (pattern)
		{
			dogGene.UpdateGeneString(GeneticProperty.PatternColorRPlus, geneSequenceFromValues);
			dogGene.UpdateGeneString(GeneticProperty.PatternColorRMinus, geneSequenceFromValues2);
			dogGene.UpdateGeneString(GeneticProperty.PatternColorGPlus, geneSequenceFromValues3);
			dogGene.UpdateGeneString(GeneticProperty.PatternColorGMinus, geneSequenceFromValues4);
			dogGene.UpdateGeneString(GeneticProperty.PatternColorBPlus, geneSequenceFromValues5);
			dogGene.UpdateGeneString(GeneticProperty.PatternColorBMinus, geneSequenceFromValues6);
			dogGene.UpdateGeneString(GeneticProperty.PatternEmissionColorRPlus, geneSequenceFromValues7);
			dogGene.UpdateGeneString(GeneticProperty.PatternEmissionColorRMinus, geneSequenceFromValues8);
			dogGene.UpdateGeneString(GeneticProperty.PatternEmissionColorGPlus, geneSequenceFromValues9);
			dogGene.UpdateGeneString(GeneticProperty.PatternEmissionColorGMinus, geneSequenceFromValues10);
			dogGene.UpdateGeneString(GeneticProperty.PatternEmissionColorBPlus, geneSequenceFromValues11);
			dogGene.UpdateGeneString(GeneticProperty.PatternEmissionColorBMinus, geneSequenceFromValues12);
		}
	}

	private static void SetNeededColors(float colorDiff, ref float neededPlus, ref float neededMinus)
	{
		if (colorDiff > 0f)
		{
			neededMinus = 0f;
			neededPlus = colorDiff;
		}
		else
		{
			neededPlus = 0f;
			neededMinus = 0f - colorDiff;
		}
	}
}
