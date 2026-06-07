using ManagementScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UIScripts.UIPanels;
using UnityEngine;
using Utility;

namespace UIScripts
{
	public class BibiteStatsPanel : BibitePanel
	{
		[Header("Species and Tags References")]
		public TextMeshProUGUI speciesText;

		public TMP_InputField tagInputField;

		public GameObject tagTextHolder;

		public TextMeshProUGUI tagText;

		public GameObject traitsSection;

		public GameObject isRadTag;

		public GameObject isRainTag;

		public GameObject isSourceTag;

		public GameObject isKillerTag;

		[Header("Buttons References")]
		public GameObject layButton;

		public GameObject parentsLine;

		public GameObject parent2Button;

		[Header("Bibite Stats References")]
		public GameObject bibiteStatsSection;

		public FloatValueTextHandle bibiteGenerationText;

		public FloatValueTextHandle bibiteLengthText;

		public FloatValueTextHandle bibiteSizeText;

		public FloatValueTextHandle massText;

		public FloatValueTextHandle speedText;

		public FloatValueTextHandle timeAliveText;

		public FloatValueTextHandle travelledText;

		public FloatValueTextHandle eggsLaidText;

		public FloatValueTextHandle aliveChildrenText;

		public FloatValueTextHandle bibitesBittenText;

		public FloatValueTextHandle damageDealtText;

		public FloatValueTextHandle timesAttackedText;

		public FloatValueTextHandle damageReceivedText;

		[Header("Eggs References")]
		public GameObject eggStatsSection;

		public FloatValueTextHandle sizeEggText;

		public FloatValueTextHandle massEggText;

		public FloatValueTextHandle totalEggEnergyText;

		public FloatValueTextHandle eggGenerationText;

		public ValueSliderHandle progressSlider;

		public ValueSliderHandle storedEnergySlider;

		private BibiteBody body;

		private BibiteGenes genes;

		private BibiteMouth mouth;

		private BibiteEggLayingOrgan eggLayer;

		private EggHatching hatching;

		private const int Spacing = 26;

		public override BibitePanels PanelIndex => BibitePanels.StatsPanel;

		public override void FillPanel()
		{
			body = bibite.GetComponent<BibiteBody>();
			mouth = body?.mouth;
			eggLayer = body?.eggLayer;
			genes = bibite.GetComponent<BibiteGenes>();
			hatching = bibite.GetComponent<EggHatching>();
			if (genes.species != null && !string.IsNullOrEmpty(genes.species.name))
			{
				speciesText.text = genes.species.name;
			}
			else
			{
				speciesText.text = "None";
			}
			if (genes.speciesTag != null && string.IsNullOrEmpty(genes.speciesTag))
			{
				tagText.text = "None";
			}
			else
			{
				tagText.text = genes.speciesTag;
				tagInputField.text = genes.speciesTag;
			}
			bool active = genes.isRad || genes.isRain || genes.isSource || genes.isKiller;
			traitsSection.SetActive(active);
			isRadTag.SetActive(genes.isRad);
			isRainTag.SetActive(genes.isRain);
			isSourceTag.SetActive(genes.isSource);
			isKillerTag.SetActive(genes.isKiller);
			bool flag = hatching != null;
			bibiteStatsSection.SetActive(!flag);
			eggStatsSection.SetActive(flag);
			layButton.SetActive(!flag && !ChallengeManager.isChallenge);
			parentsLine.SetActive(genes.parent1 != null);
			parent2Button.SetActive(genes.parent2 != null);
			if (flag)
			{
				progressSlider.InitSliderHandle(hatching.hatchTime);
				storedEnergySlider.InitSliderHandle(hatching.energy);
			}
			UpdatePanel();
		}

		public override void ResetState()
		{
			body = null;
			genes = null;
			hatching = null;
		}

		public void EditSpeciesTag()
		{
			tagInputField.gameObject.SetActive(value: true);
			tagTextHolder.SetActive(value: false);
			tagInputField.Select();
			tagInputField.ActivateInputField();
			tagInputField.text = genes.speciesTag;
			UserControl.SetKeyboardBlockFromSource("SpeciesTagEdit", block: true);
		}

		public void UpdateSpeciesTag()
		{
			string text = tagInputField.text;
			tagInputField.gameObject.SetActive(value: false);
			tagTextHolder.SetActive(value: true);
			if (!string.IsNullOrEmpty(genes.speciesTag))
			{
				if (body != null)
				{
					TagsManager.instance.RemoveFromTag(body, genes.speciesTag);
				}
				else
				{
					TagsManager.instance.RemoveFromTag(hatching, genes.speciesTag);
				}
			}
			tagText.text = text;
			genes.speciesTag = text;
			if (!string.IsNullOrEmpty(genes.speciesTag))
			{
				if (body != null)
				{
					TagsManager.instance.AddToTag(body, genes.speciesTag);
				}
				else
				{
					TagsManager.instance.AddToTag(hatching, genes.speciesTag);
				}
			}
			UserControl.SetKeyboardBlockFromSource("SpeciesTagEdit", block: false);
		}

		public void KillCurrentBibite()
		{
			if (!(bibite == null))
			{
				if (body != null)
				{
					body.Die();
				}
				if (hatching != null)
				{
					hatching.Abort();
				}
			}
		}

		public void LayEggFromCurrentBibite()
		{
			if (bibite.CompareTag("bibite"))
			{
				eggLayer.LayEgg();
			}
		}

		public void SaveCurrentBibite()
		{
			if (!(bibite == null))
			{
				SaveController.Instance.SaveBibiteOrEgg(bibite);
			}
		}

		public void EditBibite()
		{
			BibiteTemplate bibiteToEdit = new BibiteTemplate(body);
			BibiteTemplateSelectorPanel.instance.OpenForBibiteEditor(bibiteToEdit);
		}

		public void SelectParent(bool first = true)
		{
			GameObject gameObject = (first ? genes.parent1 : genes.parent2);
			if (!(gameObject == null))
			{
				UserControl.Instance.SelectTarget(gameObject);
			}
		}

		protected override void UpdatePanel()
		{
			if (base.gameObject.activeSelf)
			{
				if (hatching != null)
				{
					UpdateEggStats();
				}
				else if (body != null)
				{
					UpdateBibiteStats();
				}
			}
		}

		public void UpdateBibiteStats()
		{
			bibiteGenerationText.UpdateValue(genes.generation);
			bibiteLengthText.UpdateValue(body.bodyLength);
			bibiteSizeText.UpdateValue(body.realBodyArea);
			massText.UpdateValue(body.mass);
			speedText.UpdateValue(body.move.SignedVelocity);
			timeAliveText.UpdateValue(body.clock.timeAlive);
			travelledText.UpdateValue(body.move.totalTravel);
			eggsLaidText.UpdateValue(eggLayer.nEggsLaid);
			aliveChildrenText.UpdateValue(eggLayer.children.Count);
			bibitesBittenText.UpdateValue(mouth.bibitesBitten);
			damageDealtText.UpdateValue(mouth.totalDamageDealt);
			timesAttackedText.UpdateValue(body.timesAttacked);
			damageReceivedText.UpdateValue(body.totalDamageSuffered);
		}

		public void UpdateEggStats()
		{
			eggGenerationText.UpdateValue(genes.generation);
			sizeEggText.UpdateValue(hatching.eggArea);
			massEggText.UpdateValue(hatching.eggMass);
			totalEggEnergyText.UpdateValue(hatching.energy);
			progressSlider.UpdateValue(hatching.hatchProgress);
			storedEnergySlider.UpdateValue(hatching.freeEnergy);
		}

		public void SelectRandomChild()
		{
			if (eggLayer != null && eggLayer.children.Count > 0)
			{
				UserControl.Instance.SelectTarget(eggLayer.children[Random.Range(0, eggLayer.children.Count)].gameObject);
			}
		}
	}
}
