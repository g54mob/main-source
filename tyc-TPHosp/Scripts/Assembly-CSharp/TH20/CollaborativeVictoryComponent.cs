using FullInspector;
using UnityEngine;

namespace TH20
{
	public class CollaborativeVictoryComponent
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private Sprite _networkNodeIcon;

		[SerializeField]
		private Sprite _networkNodeIconIncomplete;

		[SerializeField]
		private SharedInstance<ResearchNodeDefinition> _nodeDefinition;

		public string Name => _name;

		public Sprite NetworkNodeIcon => _networkNodeIcon;

		public Sprite NetworkNodeIconIncomplete => _networkNodeIconIncomplete;

		public ResearchNodeDefinition NodeDefinition => _nodeDefinition.Instance;
	}
}
