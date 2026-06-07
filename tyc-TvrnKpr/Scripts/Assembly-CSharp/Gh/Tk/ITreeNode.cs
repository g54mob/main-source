using System.Collections.Generic;

namespace Gh.Tk
{
	public interface ITreeNode
	{
		string LabelKey { get; set; }

		bool IsSelected { get; set; }

		List<ITreeNode> GetChildren();

		void AddChild(ITreeNode node);

		bool IsEqual(ITreeNode node);

		int GetNodeIndex(ITreeNode treeNode);

		void SetNodeIndex(ITreeNode treeNode, int index);
	}
}
