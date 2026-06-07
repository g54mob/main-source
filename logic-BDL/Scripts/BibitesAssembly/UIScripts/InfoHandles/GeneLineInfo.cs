using System;
using ManagementScripts;
using SettingScripts;
using TMPro;
using UnityEngine;

namespace UIScripts.InfoHandles
{
	public class GeneLineInfo : MonoBehaviour
	{
		private GeneSetting gene;

		[SerializeField]
		private TextMeshProUGUI geneName;

		[SerializeField]
		private TooltipTrigger geneDescription;

		[SerializeField]
		private FloatValueTextHandle geneValue;

		[SerializeField]
		private FloatValueTextHandle parentDifference;

		[SerializeField]
		private TooltipTrigger parentDifferenceHelper;

		[NonSerialized]
		public float contributionToSpeciation;

		private string differenceTitle = "Difference from target";

		private static float speciesGeneticSpan => GlobalLineageManager.usedSpeciesSpan;

		public void Init(GeneSetting geneSetting)
		{
			gene = geneSetting;
			geneName.text = geneSetting.Name + ": ";
			geneDescription.UpdateText(geneSetting.Name, geneSetting.HelperText);
			parentDifference.alwaysShowSign = true;
		}

		public void SetTitle(string val)
		{
			differenceTitle = val;
		}

		public void SetFontSize(float val)
		{
			geneName.fontSize = val;
			geneValue.text.fontSize = val;
			parentDifference.text.fontSize = val;
		}

		public void SetGene(float[] genes, float[] comparedGenes)
		{
			int num = (int)gene.gene;
			float num2 = genes[num];
			geneValue.UpdateValue(num2);
			if (comparedGenes == null || Mathf.Approximately(num2, comparedGenes[num]))
			{
				parentDifference.text.text = "";
				contributionToSpeciation = 0f;
				return;
			}
			float num3 = comparedGenes[num];
			float num4 = num2 - num3;
			contributionToSpeciation = Mathf.Abs(num4) / gene.maxValue / speciesGeneticSpan;
			parentDifference.UpdateValue(num2 - num3, check: false);
			parentDifferenceHelper.UpdateText(differenceTitle, $"Flat difference : {num2 - num3:F3}\n\rRelative difference : {100f * num4 / num3:F1}%\n\rSpan difference : {num4 / gene.maxValue:F3}\n\rContribution to speciation : {100f * contributionToSpeciation:F1}%");
		}

		public void UpdateDifferenceColor(float maxDifference)
		{
			if (!(maxDifference <= 0f))
			{
				float t = Mathf.Pow(contributionToSpeciation / maxDifference, 0.5f);
				parentDifference.text.color = new Color(0f, 0f, 0f, Mathf.Lerp(0.15f, 1f, t));
			}
		}
	}
}
