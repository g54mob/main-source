using System.Collections.Generic;
using Newtonsoft.Json;

namespace DV.UI.Manual
{
	public class ManualTreeNode
	{
		[JsonProperty]
		public string type;

		[JsonProperty]
		public string key;

		[JsonProperty]
		public List<ManualTreeNode> children = new List<ManualTreeNode>();

		public ManualTreeNode previousNode;

		public ManualTreeNode nextNode;

		public ManualTreeNode parent;

		public readonly ManualPageDisplayData displayData = new ManualPageDisplayData();

		public List<int> MaximumNodesAtDepth { get; private set; } = new List<int>();

		public bool IsLeaf => type != "category";

		public static ManualTreeNode FromJson(string json)
		{
			return JsonConvert.DeserializeObject<ManualTreeNode>(json);
		}

		public ManualTreeNode FindNodeByKey(string key)
		{
			if (this.key == key)
			{
				return this;
			}
			foreach (ManualTreeNode child in children)
			{
				ManualTreeNode manualTreeNode = child.FindNodeByKey(key);
				if (manualTreeNode != null)
				{
					return manualTreeNode;
				}
			}
			return null;
		}

		public int GetDepth()
		{
			if (parent != null)
			{
				return parent.GetDepth() + 1;
			}
			return -1;
		}
	}
}
