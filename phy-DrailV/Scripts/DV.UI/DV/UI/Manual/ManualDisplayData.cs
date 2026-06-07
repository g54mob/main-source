using System.Collections.Generic;
using UnityEngine;

namespace DV.UI.Manual
{
	public class ManualDisplayData
	{
		public string wikiUrlPrefix;

		public string langCode;

		public ManualTreeNode root;

		public int percentTranslated;

		public ManualDisplayData(ManualMetadata metadata, ManualStrings langStrings, ManualStrings fallbackEnglishStrings)
		{
			wikiUrlPrefix = metadata.wikiUrlPrefix;
			langCode = langStrings.code;
			root = metadata.tree;
			percentTranslated = ((langCode == "en") ? 100 : metadata.langs[langCode].percentTranslated);
			CopyDataToTreeNodes(root, null, langStrings, fallbackEnglishStrings);
			CalculatePreviousNext(root);
		}

		private void CopyDataToTreeNodes(ManualTreeNode node, ManualTreeNode parentNode, ManualStrings langStrings, ManualStrings fallbackEnglishStrings)
		{
			string key = node.key + "/title";
			string key2 = node.key + "/content";
			node.parent = parentNode;
			ManualPageDisplayData displayData = node.displayData;
			if (langStrings.strings.TryGetValue(key, out var value))
			{
				displayData.title = value;
			}
			else
			{
				displayData.title = fallbackEnglishStrings.strings[key];
			}
			if (displayData.title.StartsWith("Category:"))
			{
				displayData.title = displayData.title.Replace("Category:", "");
			}
			if (langStrings.strings.TryGetValue(key2, out var value2))
			{
				displayData.content = value2;
				displayData.exists = true;
				displayData.usedFallback = false;
			}
			else
			{
				displayData.content = fallbackEnglishStrings.strings[key2];
				displayData.exists = false;
				displayData.usedFallback = true;
			}
			if (langStrings.meta.TryGetValue(node.key, out var value3))
			{
				displayData.stats = value3;
			}
			else
			{
				displayData.stats = new TranslationStats();
			}
			foreach (ManualTreeNode child in node.children)
			{
				CopyDataToTreeNodes(child, node, langStrings, fallbackEnglishStrings);
			}
		}

		private void CalculatePreviousNext(ManualTreeNode node)
		{
			List<ManualTreeNode> traversed = new List<ManualTreeNode>();
			Traverse(node);
			for (int i = 0; i < traversed.Count; i++)
			{
				traversed[i].previousNode = ((i == 0) ? traversed[traversed.Count - 1] : traversed[i - 1]);
				traversed[i].nextNode = ((i == traversed.Count - 1) ? traversed[0] : traversed[i + 1]);
			}
			void Traverse(ManualTreeNode n)
			{
				if (n.IsLeaf)
				{
					traversed.Add(n);
					return;
				}
				foreach (ManualTreeNode child in n.children)
				{
					Traverse(child);
				}
			}
		}

		private static void CalculateMaximumNodesAtDepth(ManualTreeNode node)
		{
			if (node.IsLeaf)
			{
				return;
			}
			int num = node.GetDepth() + 1;
			while (node.MaximumNodesAtDepth.Count <= num)
			{
				node.MaximumNodesAtDepth.Add(0);
			}
			node.MaximumNodesAtDepth[num] = Mathf.Max(node.children.Count, node.MaximumNodesAtDepth[num]);
			foreach (ManualTreeNode child in node.children)
			{
				CalculateMaximumNodesAtDepth(child);
			}
		}
	}
}
