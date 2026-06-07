using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TreeNode
	{
		public const int INVALID = -1;

		public const string NAME_CHILDREN = "m_Children";

		[SerializeField]
		private int m_Id;

		[SerializeField]
		private int m_Parent;

		[SerializeField]
		private List<int> m_Children;

		public int Id => m_Id;

		public int Parent
		{
			get
			{
				return m_Parent;
			}
			set
			{
				m_Parent = value;
			}
		}

		public List<int> Children
		{
			get
			{
				return m_Children;
			}
			set
			{
				m_Children = value;
			}
		}

		public TreeNode(int id, int parent)
		{
			m_Id = id;
			m_Parent = parent;
			m_Children = new List<int>();
		}
	}
}
