using System.Collections.Generic;
using Gh.Tk.Story.Requirements;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story
{
	public abstract class NodeBase : Node
	{
		[SerializeField]
		[HideInInspector]
		private string _id;

		private Dictionary<string, List<RequirementNode>> _requirementNodeCache;

		public string Id => null;

		public void OnCopy()
		{
		}

		protected T GetConnectedNode<T>(string fieldName) where T : Node
		{
			return null;
		}

		protected IEnumerable<T> GetConnectedNodes<T>(string fieldName) where T : Node
		{
			return null;
		}

		protected override void Init()
		{
		}

		protected List<RequirementNode> GetConnectedRequirementNodes(string fieldName)
		{
			return null;
		}

		public void GenerateI18nEntries(string context)
		{
		}

		protected virtual void GenerateI18nEntriesInternal(string context)
		{
		}
	}
}
