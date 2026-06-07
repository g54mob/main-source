using System.Linq;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace Utility
{
	public struct GenesBucketPoint
	{
		public ushort[] data;

		public float min;

		public float max;

		public const int N = 20;

		public const int ByteSize = 48;

		public ushort this[int i]
		{
			get
			{
				return data[i];
			}
			set
			{
				data[i] = value;
			}
		}

		public GenesBucketPoint(BibiteGenes[] genes, int gene)
		{
			GeneSetting geneSetting = BibiteEditorSettings.SettingOfGene(gene);
			float span = geneSetting.span;
			float minValue = geneSetting.minValue;
			data = new ushort[20];
			if (genes.Length < 1)
			{
				min = geneSetting.minValue;
				max = geneSetting.maxValue;
				return;
			}
			min = genes.Min((BibiteGenes g) => g.genes[gene]);
			max = genes.Max((BibiteGenes g) => g.genes[gene]);
			min = minValue + span * Mathf.Floor(100f * (min - minValue) / span) / 100f;
			max = minValue + span * Mathf.Ceil(100f * (max - minValue) / span) / 100f;
			float num = (float)Mathf.Max(1, Mathf.CeilToInt(5f * (max - min) / span)) / 5f * span;
			min = Mathf.Min(min, geneSetting.maxValue - num);
			max = Mathf.Max(max, geneSetting.minValue + num);
			foreach (BibiteGenes bibiteGenes in genes)
			{
				int num3 = Mathf.FloorToInt(20f * (bibiteGenes.genes[gene] - min) / num);
				if (num3 >= 20)
				{
					num3 = 19;
				}
				data[num3]++;
			}
		}

		public GenesBucketPoint(int n)
		{
			data = new ushort[20];
			min = 0f;
			max = 1f;
		}
	}
}
