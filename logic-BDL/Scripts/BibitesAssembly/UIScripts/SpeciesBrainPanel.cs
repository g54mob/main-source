using System.Collections.Generic;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UIScripts.UIPanels;
using UnityEngine;
using Utility;

namespace UIScripts
{
	public class SpeciesBrainPanel : BrainPanelCommon
	{
		protected Species targetSpecies;

		private Species comparedSpecies;

		[SerializeField]
		protected GameObject parentSpeciesButton;

		[SerializeField]
		protected GameObject parentSpeciesNone;

		[SerializeField]
		protected TextMeshProUGUI parentSpeciesName;

		[SerializeField]
		protected FloatValueTextHandle comparedDistance;

		public override BibitePanels PanelIndex { get; }

		public override void InitPanel()
		{
			base.InitPanel();
			nodesPool = new ItemDictPool<int, UINeuron>(nodePrefab, nodeHolder, 75)
			{
				actionOnCreate = delegate(UINeuron neuron)
				{
					neuron.showValueOnHover = false;
				}
			};
		}

		public void SelectSpecies(Species species)
		{
			ResetState();
			targetSpecies = species;
			if (targetSpecies != null)
			{
				UpdateName();
				targetSpecies.onSpeciesChange.AddListener(UpdateName);
				Species parentSpecies = targetSpecies.parentSpecies;
				if (parentSpecies == null)
				{
					brainDistance.gameObject.SetActive(value: false);
					parentSpeciesButton.SetActive(value: false);
					parentSpeciesNone.SetActive(value: true);
				}
				else
				{
					brainDistance.gameObject.SetActive(value: true);
					parentSpeciesButton.SetActive(value: true);
					parentSpeciesNone.SetActive(value: false);
					parentSpeciesName.text = parentSpecies.name;
				}
				FillPanel();
			}
		}

		public override void FillPanel()
		{
			Species parentSpecies = targetSpecies.parentSpecies;
			NEATBrain.Node[] nodes = targetSpecies.template.nodes;
			NEATBrain.Synaps[] synapses = targetSpecies.template.synapses;
			if (parentSpecies != null)
			{
				brainDistance.UpdateValue(targetSpecies.BrainDistanceToIndividual(parentSpecies.template.nodes, parentSpecies.template.synapses) / GlobalLineageManager.usedSpeciesSpan);
			}
			for (int i = 0; i < nodes.Length; i++)
			{
				NEATBrain.Node node = nodes[i];
				node.NIn = (node.NOut = 0);
				nodes[i] = node;
			}
			NEATBrain.Synaps[] array = synapses;
			for (int j = 0; j < array.Length; j++)
			{
				NEATBrain.Synaps synaps = array[j];
				NEATBrain.Node node2 = nodes[synaps.NodeIn];
				NEATBrain.Node node3 = nodes[synaps.NodeOut];
				node2.NOut++;
				node3.NIn++;
				nodes[synaps.NodeIn] = node2;
				nodes[synaps.NodeOut] = node3;
			}
			FillBrainPanel(nodes, synapses, targetSpecies.template.nodeAnchors);
			nodesPool.ForEachActive(delegate(UINeuron n)
			{
				n.ShowOverDesc(UserSettings.ShowNodeNames.val);
			});
		}

		public void SaveNodePositions()
		{
			Dictionary<long, Vector2> dict = targetSpecies.template.nodeAnchors;
			Vector2 step = new Vector2(holderRT.rect.width, stepI);
			nodesPool.ForEachActive(delegate(UINeuron n)
			{
				if (n.index < NEATBrain.NInputs)
				{
					step.y = stepI;
				}
				else if (n.index < NEATBrain.NInputs + NEATBrain.NOutputs)
				{
					step.y = stepO;
					if (n.node.NIn == 0)
					{
						return;
					}
				}
				else
				{
					step.y = 0f - (height + nG * stepG);
				}
				dict[n.inov] = n.transform.localPosition / step;
			});
		}

		public void ResetNodePositions()
		{
			targetSpecies.template.nodeAnchors.Clear();
			SelectSpecies(targetSpecies);
		}

		public void UpdateCompared(Species toCompare)
		{
			comparedSpecies = toCompare;
			if (UserSettings.showBrainDifferences.val)
			{
				CallShowDifferences();
			}
		}

		protected override void CallShowDifferences()
		{
			bool flag = comparedSpecies == null;
			comparedDistance.gameObject.SetActive(!flag);
			if (!flag)
			{
				comparedDistance.UpdateValue(targetSpecies.BrainDistanceToIndividual(comparedSpecies.template.nodes, comparedSpecies.template.synapses));
				if (UserSettings.showBrainDifferences.val)
				{
					ShowDifferences(comparedSpecies.BrainDifferencesToIndividual(targetSpecies.template.nodes, targetSpecies.template.synapses));
				}
			}
		}

		public override void ResetState()
		{
			targetSpecies?.onSpeciesChange.RemoveListener(UpdateName);
			base.ResetState();
		}

		private void UpdateName()
		{
			speciesName.text = targetSpecies.name;
		}
	}
}
