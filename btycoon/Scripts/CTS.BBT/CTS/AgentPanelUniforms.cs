using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AgentPanelUniforms : AbsAgentPanel, IRepaint
	{
		[SerializeField]
		private AgentUniformToggle _togglePrefab;

		private List<AgentUniformToggle> _toggles = new List<AgentUniformToggle>();

		public override void SetAgentInfo()
		{
			Repaint();
		}

		public override void ClearAgentInfo()
		{
		}

		public void Repaint()
		{
			foreach (AgentUniformToggle toggle in _toggles)
			{
				if (!WorkerSpawner.SpecificClothes.Contains(toggle.ClothesData))
				{
					toggle.gameObject.SetActive(value: false);
				}
			}
			foreach (CharacterSpecificClothesData specificClothe in WorkerSpawner.SpecificClothes)
			{
				if (!Contains(specificClothe))
				{
					AgentUniformToggle agentUniformToggle = CTSFactory.Instantiate(_togglePrefab, base.transform, instantiateInWorldSpace: false, false);
					agentUniformToggle.SetData(specificClothe);
					agentUniformToggle.gameObject.SetActive(value: true);
					_toggles.Add(agentUniformToggle);
				}
			}
			foreach (AgentUniformToggle toggle2 in _toggles)
			{
				if (toggle2.isActiveAndEnabled)
				{
					toggle2.Repaint();
				}
			}
		}

		public bool Contains(CharacterSpecificClothesData clothe)
		{
			foreach (AgentUniformToggle toggle in _toggles)
			{
				if ((object)clothe == toggle.ClothesData)
				{
					return true;
				}
			}
			return false;
		}
	}
}
