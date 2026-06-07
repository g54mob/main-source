using Newtonsoft.Json.Linq;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using Utility;

namespace ScriptHelpers
{
	public static class BibiteUpdater
	{
		public static int[] to06a15GenesMap = new int[34]
		{
			0, 1, 2, 3, 4, 5, 6, 7, -1, -1,
			8, 9, 10, 11, 12, 13, 14, 15, 16, -1,
			17, 18, 19, 20, 21, 22, 23, 24, 25, 26,
			27, 28, 33, 34
		};

		public static bool UpdateTemplateToPresentVersion(BibiteTemplate template, JToken json, bool isSaved)
		{
			if (template.updated)
			{
				return true;
			}
			bool flag = false;
			Version version = Version.Parse(template.version);
			template.genes = UpdateGenesToPresentVersion(template.genes, version, isSaved ? json["genes"]["genes"] : json["genes"], Version.Parse(template.version) < Version.Parse("0.6a1"), isSaved);
			return BrainUpdater.UpdateTemplateToPresentVersion(template) || flag;
		}

		public static float[] UpdateGenesToPresentVersion(float[] genes, Version from, JToken genesJson, bool geneRemapingNecessary = true, bool isSaved = false)
		{
			if (from < Version.Parse("0.6a7") && geneRemapingNecessary)
			{
				genes[28] = BibiteEditorSettings.SettingOfGene(BibiteGenes.Genes.EyeOffset).DefaultValue;
				genes[29] = BibiteEditorSettings.SettingOfGene(BibiteGenes.Genes.StomachWAG).DefaultValue;
				genes[30] = BibiteEditorSettings.SettingOfGene(BibiteGenes.Genes.WombWAG).DefaultValue;
				genes[31] = BibiteEditorSettings.SettingOfGene(BibiteGenes.Genes.FatWAG).DefaultValue;
				genes[32] = BibiteEditorSettings.SettingOfGene(BibiteGenes.Genes.FatStorageThreshold).DefaultValue;
				genes[33] = BibiteEditorSettings.SettingOfGene(BibiteGenes.Genes.FatStorageDeadband).DefaultValue;
			}
			if (from < Version.Parse("0.6a15"))
			{
				float num = ((from < Version.Parse("0.6a1") && !isSaved) ? genes[8] : (genesJson["Strength"]?.ToObject<float>() ?? 5f));
				float num2 = ((from < Version.Parse("0.6a1") && !isSaved) ? genes[9] : (genesJson["Defence"]?.ToObject<float>() ?? 0f));
				float[] array;
				if (geneRemapingNecessary && !isSaved)
				{
					array = new float[BibiteGenes.NGene];
					int num3 = to06a15GenesMap.Length;
					for (int i = 0; i < num3; i++)
					{
						if (to06a15GenesMap[i] >= 0)
						{
							array[to06a15GenesMap[i]] = genes[i];
						}
					}
				}
				else
				{
					array = genes;
				}
				array[28] *= 2.5f;
				array[27] *= 2.5f;
				array[26] *= 2.5f;
				array[31] = 0f;
				array[29] = 0f;
				array[32] = 0f;
				array[30] = 0f;
				float num4 = BibiteGenes.TotalOrganWAG(array);
				float num5 = Mathf.Min(0.01f, Mathf.Pow(num / 35f, 2f));
				float num6 = Mathf.Pow(num2 / 35f, 2f);
				float num7 = 0.05f;
				float num8 = 0.1f;
				float num9 = 1f - num5 - num6 - num7 - num8;
				array[31] = num4 * num5 / num9;
				array[29] = num4 * num6 / num9;
				array[32] = num4 * num7 / num9;
				array[30] = num4 * num8 / num9;
				genes = array;
			}
			return genes;
		}
	}
}
