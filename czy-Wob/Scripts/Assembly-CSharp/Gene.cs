using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class Gene
{
	public GeneticVersion version;

	public string key;

	public string readableName;

	public LocalizedString localizedName;

	public string testName;

	public int length = 10;

	public int loopCount = 2;

	public float superMutationValueAddition;

	public GeneType geneType;

	public GeneCategory geneCategory;

	public GeneSwapCategory geneSwapCategory;

	public AnimationCurve customCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public bool plusMinus;

	public bool startAtLowestValue;

	public bool applyMinusPropertyToStartingGene;

	public bool discrete = true;

	public bool dynamicLoopCount;
}
