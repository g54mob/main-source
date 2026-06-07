using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.UIPanels;
using UnityEngine;
using Utility;

namespace UIScripts
{
	public class BrainPanel : BrainPanelCommon
	{
		[Header("Object References")]
		private Species species;

		private NEATBrain brain;

		public override BibitePanels PanelIndex => BibitePanels.BrainPanel;

		public override void InitPanel()
		{
			base.InitPanel();
			nodesPool = new ItemDictPool<int, UINeuron>(nodePrefab, nodeHolder, 75);
			UserSettings.ShowNodeNames.OnValueChange.AddListener(ToggleOverDesc);
		}

		public override void FillPanel()
		{
			brain = bibite.GetComponent<NEATBrain>();
			species = bibite.GetComponent<BibiteGenes>().species;
			species.onSpeciesChange.AddListener(UpdateName);
			UpdateName();
			NEATBrain.Node[] nodes = brain.Nodes;
			NEATBrain.Synaps[] synapses = brain.Synapses;
			brainDistance.UpdateValue(species.BrainDistanceToIndividual(nodes, synapses) / GlobalLineageManager.usedSpeciesSpan);
			FillBrainPanel(nodes, synapses, species.template.nodeAnchors);
			nodesPool.ForEachActive(delegate(UINeuron n)
			{
				n.ShowOverDesc(UserSettings.ShowNodeNames.val);
			});
		}

		protected override void CallShowDifferences()
		{
			if (UserSettings.showBrainDifferences.val)
			{
				ShowDifferences(species.BrainDifferencesToIndividual(brain.Nodes, brain.Synapses));
			}
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			ToggleOverDesc(UserSettings.ShowNodeNames.val);
		}

		private void ToggleOverDesc(bool val)
		{
			nodesPool.ForEachActive(delegate(UINeuron n)
			{
				n.ShowOverDesc(val);
			});
		}

		public override void ResetState()
		{
			species?.onSpeciesChange.RemoveListener(UpdateName);
			base.ResetState();
		}

		private void UpdateName()
		{
			speciesName.text = species.name;
		}

		protected override void UpdatePanel()
		{
			base.UpdatePanel();
			nodesPool.ForEachActive(delegate(UINeuron n)
			{
				n.SetValue(brain.Nodes[n.index].Value);
			});
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			UserSettings.ShowNodeNames.OnValueChange.RemoveListener(ToggleOverDesc);
		}
	}
}
