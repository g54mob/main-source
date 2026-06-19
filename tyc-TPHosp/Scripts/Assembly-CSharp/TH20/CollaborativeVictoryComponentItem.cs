using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborativeVictoryComponentItem : MonoBehaviour
	{
		[SerializeField]
		private Image _radialProgress;

		[SerializeField]
		private GameObject _resultIcon;

		[SerializeField]
		private TooltipSpawner _tooltip;

		private CollaborativeNode _node;

		private IResearchNetworkState _networkState;

		public void Setup(CollaborativeNode node, IResearchNetworkState networkState)
		{
			_node = node;
			_networkState = networkState;
			_tooltip.SetDataProvider(OnTooltip);
		}

		private void OnTooltip(Tooltip tooltip)
		{
			if (_node != null)
			{
				tooltip.Text = string.Format("<b><size=120%>{0}</size></b>\n{1}", _node.Definition.Objective.NameLocalised.Translation, _node.IsCompleted ? "<color=#10CC10>Completed</color>" : "<color=#CC1010>Incomplete</color>");
			}
		}

		public void Refresh()
		{
			if (_node != null)
			{
				int numNodeCompletions = _networkState.GetNumNodeCompletions(_node.NodeID);
				int numCompletionsRequired = _networkState.GetNumCompletionsRequired(_node.NodeID);
				_radialProgress.fillAmount = (float)numNodeCompletions / (float)numCompletionsRequired;
				GameObjectUtils.SetActive(_resultIcon, numNodeCompletions >= numCompletionsRequired);
			}
		}
	}
}
