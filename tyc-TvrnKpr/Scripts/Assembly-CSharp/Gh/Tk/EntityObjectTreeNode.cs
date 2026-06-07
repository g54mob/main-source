using System.Collections.Generic;

namespace Gh.Tk
{
	public class EntityObjectTreeNode : ITreeNode
	{
		public readonly EntityObject EntityObject;

		private readonly List<ITreeNode> _children;

		private bool _isSelected;

		public string LabelKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public EntityObjectTreeNode(EntityObject entityObject)
		{
		}

		public List<ITreeNode> GetChildren()
		{
			return null;
		}

		public void AddChild(ITreeNode node)
		{
		}

		private void AddChildInternal(EntityObject newChild)
		{
		}

		public bool IsEqual(ITreeNode node)
		{
			return false;
		}

		public int GetNodeIndex(ITreeNode treeNode)
		{
			return 0;
		}

		public void SetNodeIndex(ITreeNode treeNode, int index)
		{
		}
	}
}
