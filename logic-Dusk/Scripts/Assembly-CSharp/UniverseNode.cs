using System.Collections.Generic;
using UnityEngine;

public class UniverseNode
{
	public class ConnectionEdge
	{
		public enum EdgeTypeEnum
		{
			Short = 0,
			Long = 1
		}

		private UniverseNode _parentNode;

		private UniverseNode _childNode;

		public int InternalID { get; set; }

		public string GroupKey
		{
			get
			{
				return string.Format("GXE_{0}", InternalID);
			}
		}

		public EdgeTypeEnum edgeType { get; private set; }

		public UniverseNode parentNode
		{
			get
			{
				return _parentNode;
			}
			private set
			{
				_parentNode = value;
				if (value != null)
				{
					UniverseSaveFile.Save(GroupKey, "P", value.GroupKey);
				}
				else
				{
					UniverseSaveFile.Clear(GroupKey, "P");
				}
			}
		}

		public UniverseNode childNode
		{
			get
			{
				return _childNode;
			}
			private set
			{
				_childNode = value;
				if (value != null)
				{
					UniverseSaveFile.Save(GroupKey, "C", value.GroupKey);
				}
				else
				{
					UniverseSaveFile.Clear(GroupKey, "C");
				}
			}
		}

		public GameObject edgeLine { get; private set; }

		public bool IsEnabledConditional { get; set; }

		public bool IsEnabled
		{
			get
			{
				return UniverseSaveFile.Get(GroupKey, "ENABLED", false);
			}
			set
			{
				UniverseSaveFile.Save(GroupKey, "ENABLED", value);
			}
		}

		public ConnectionEdge(EdgeTypeEnum edgeType, UniverseNode parentNode, UniverseNode childNode, int internalID)
		{
			InternalID = internalID;
			this.edgeType = edgeType;
			this.parentNode = parentNode;
			this.childNode = childNode;
		}

		~ConnectionEdge()
		{
			edgeLine = null;
		}

		public void Show()
		{
			if (parentNode.gameObject != null && childNode.gameObject != null && (parentNode.IsEnabled || parentNode.IsVisitedConditional) && (IsEnabled || IsEnabledConditional || ((parentNode.IsVisitedConditional || parentNode.IsVisitedConditionalFake) && (childNode.IsVisitedConditional || childNode.IsVisitedConditionalFake))))
			{
				if (edgeLine == null)
				{
					RefreshEdge();
				}
				edgeLine.SetActive(true);
				parentNode.Show();
			}
		}

		public void Hide()
		{
			if (edgeLine != null)
			{
				edgeLine.SetActive(false);
			}
			edgeLine = null;
		}

		public UniverseNode GetOtherNode(UniverseNode node)
		{
			if (childNode != null && childNode == node)
			{
				return parentNode;
			}
			if (parentNode != null && parentNode == node)
			{
				return childNode;
			}
			return null;
		}

		public bool EdgeConnectsToNode(UniverseNode otherNode)
		{
			if (childNode != null && childNode == otherNode)
			{
				return true;
			}
			if (parentNode != null && parentNode == otherNode)
			{
				return true;
			}
			return false;
		}

		private void RefreshEdge()
		{
			if (!(edgeLine == null))
			{
				return;
			}
			if (parentNode.gameObject != null && childNode.gameObject != null)
			{
				edgeLine = Object.Instantiate(UniverseMapManager.connectionLinePrefab);
				Vector3 position = parentNode.gameObject.transform.position;
				position.z += 2f;
				((LineRenderer)edgeLine.GetComponent<Renderer>()).SetPosition(0, position);
				position = childNode.gameObject.transform.position;
				position.z += 2f;
				((LineRenderer)edgeLine.GetComponent<Renderer>()).SetPosition(1, position);
				if (edgeType == EdgeTypeEnum.Short)
				{
					if (ShortLineMat != null)
					{
						edgeLine.GetComponent<Renderer>().material = ShortLineMat;
					}
				}
				else if (LongLineMat != null)
				{
					edgeLine.GetComponent<Renderer>().material = LongLineMat;
				}
				Color color = edgeLine.GetComponent<Renderer>().material.color;
				color.a *= 0.95f;
				edgeLine.GetComponent<Renderer>().material.color = color;
			}
			else
			{
				int num = 0;
				num++;
			}
		}

		public void DestroyObjects()
		{
			if (edgeLine != null)
			{
				Object.Destroy(edgeLine);
			}
			edgeLine = null;
		}

		public override string ToString()
		{
			return string.Format("Parent: {0} ({1}), Child: {2} ({3}) - Enabled: {4}", parentNode.name, parentNode.InternalID, childNode.name, childNode.InternalID, IsEnabled);
		}
	}

	public static Material ShortLineMat;

	public static Material LongLineMat;

	private UniverseConstelation _constellation;

	private bool _isSelected;

	private bool _isEnabled;

	private List<UniverseNode> childrenShortNodes = new List<UniverseNode>();

	private List<UniverseNode> childrenLongNodes = new List<UniverseNode>();

	public static List<KeyCode> usedKeys { get; set; }

	public int InternalID { get; set; }

	public string GroupKey
	{
		get
		{
			return string.Format("GX_{0}", InternalID);
		}
	}

	public GameObject gameObject { get; set; }

	public UniverseNodeObject nodeObject { get; private set; }

	public UniverseNode parent { get; set; }

	public UniverseConstelation constelationTemp { get; set; }

	public UniverseConstelation constellation
	{
		get
		{
			return _constellation;
		}
		set
		{
			_constellation = value;
			if (value != null)
			{
				UniverseSaveFile.Save(GroupKey, "P", value.GroupKey);
			}
			else
			{
				UniverseSaveFile.Clear(GroupKey, "P");
			}
		}
	}

	public int Depth { get; set; }

	public string name { get; set; }

	public int numberOfShort { get; set; }

	public int numberOfLong { get; set; }

	public Vector3 pos { get; set; }

	public bool IsVisible { get; private set; }

	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			_isSelected = value;
			if (nodeObject != null)
			{
				nodeObject.Refresh();
			}
		}
	}

	public bool IsVisitedConditionalFake { get; set; }

	public bool IsVisitedConditional { get; set; }

	public bool IsVisited
	{
		get
		{
			return UniverseSaveFile.Get(GroupKey, "VISITED", false);
		}
		set
		{
			if (value)
			{
				if (!UniverseSaveFile.Get(GroupKey, "VISITED", false))
				{
					UniverseSaveFile.Save(GroupKey, "VISITED", value);
				}
			}
			else
			{
				UniverseSaveFile.Save(GroupKey, "VISITED", value);
			}
			if (value)
			{
				if (edgeToParent != null && edgeToParent.parentNode.IsVisited)
				{
					IsEnabled = true;
					edgeToParent.parentNode.IsEnabled = true;
				}
				foreach (UniverseNode childrenShortNode in childrenShortNodes)
				{
					if (childrenShortNode.IsVisited)
					{
						if (!childrenShortNode.IsEnabled)
						{
							IsEnabled = true;
							childrenShortNode.IsEnabled = true;
						}
						else
						{
							IsEnabled = true;
						}
					}
				}
				{
					foreach (UniverseNode childrenLongNode in childrenLongNodes)
					{
						if (childrenLongNode.IsVisited)
						{
							if (!childrenLongNode.IsEnabled)
							{
								IsEnabled = true;
								childrenLongNode.IsEnabled = true;
							}
							else
							{
								IsEnabled = true;
							}
						}
					}
					return;
				}
			}
			IsVisitedConditional = false;
			IsEnabled = false;
		}
	}

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			_isEnabled = value;
			if (value)
			{
				UniverseMapManager.HasData = true;
			}
		}
	}

	public ConnectionEdge edgeToParent { get; set; }

	public int CountNodes
	{
		get
		{
			return CountShortConnectedNodes + CountLongConnectedNodes + ((parent != null) ? 1 : 0);
		}
	}

	public int CountChildrenNodes
	{
		get
		{
			return CountShortConnectedNodes + CountLongConnectedNodes;
		}
	}

	public int CountShortConnectedNodes
	{
		get
		{
			return childrenShortNodes.Count;
		}
	}

	public int CountLongConnectedNodes
	{
		get
		{
			return childrenLongNodes.Count;
		}
	}

	public int NumberOfFreeShortConnections
	{
		get
		{
			return numberOfShort - CountShortConnectedNodes;
		}
	}

	public int NumberOfFreeLongConnections
	{
		get
		{
			return numberOfLong - CountLongConnectedNodes;
		}
	}

	~UniverseNode()
	{
		gameObject = null;
	}

	public void Show()
	{
		if (!IsEnabled && !IsVisitedConditional)
		{
			return;
		}
		if (gameObject == null)
		{
			gameObject = (GameObject)Object.Instantiate(UniverseMapManager.universeNodePrefab, pos, Quaternion.identity);
			nodeObject = gameObject.GetComponent<UniverseNodeObject>();
			nodeObject.node = this;
			nodeObject.Refresh();
		}
		bool flag = false;
		int num = 0;
		int num2 = 100;
		do
		{
			num = Random.Range(97, 123);
			if (!usedKeys.Contains((KeyCode)num))
			{
				usedKeys.Add((KeyCode)num);
				flag = true;
			}
			else
			{
				num2--;
			}
		}
		while (!flag && num2 > 0);
		nodeObject.SetShortcutKey((KeyCode)num);
		gameObject.SetActive(true);
		if (edgeToParent != null)
		{
			edgeToParent.Show();
		}
		IsVisible = true;
	}

	public void Hide()
	{
		if (gameObject != null)
		{
			gameObject.SetActive(false);
		}
		if (edgeToParent != null)
		{
			edgeToParent.Hide();
		}
		IsVisible = false;
	}

	public ConnectionEdge GetEdgeToOtherNode(UniverseNode otherNode)
	{
		if (edgeToParent != null && edgeToParent.EdgeConnectsToNode(otherNode))
		{
			return edgeToParent;
		}
		if (otherNode.edgeToParent != null && otherNode.edgeToParent.EdgeConnectsToNode(this))
		{
			return otherNode.edgeToParent;
		}
		return null;
	}

	public ConnectionEdge GetConditionalEdge()
	{
		if (edgeToParent != null && edgeToParent.IsEnabledConditional)
		{
			return edgeToParent;
		}
		if (parent != null && parent.edgeToParent != null && parent.edgeToParent.IsEnabledConditional)
		{
			return parent.edgeToParent;
		}
		return null;
	}

	public void ClearConditionalyEnabledEdges()
	{
		if (edgeToParent != null && edgeToParent.IsEnabledConditional)
		{
			edgeToParent.IsEnabledConditional = false;
		}
		if (parent != null && parent.edgeToParent != null && parent.edgeToParent.IsEnabledConditional)
		{
			parent.edgeToParent.IsEnabledConditional = false;
		}
	}

	public void AddChildNodeShort(UniverseNode child, int edgeInternalID)
	{
		child.Depth = Depth + 1;
		childrenShortNodes.Add(child);
		child.edgeToParent = new ConnectionEdge(ConnectionEdge.EdgeTypeEnum.Short, this, child, edgeInternalID);
		CommonChild(child);
	}

	public void AddChildNodeLong(UniverseNode child, int edgeInternalID)
	{
		child.Depth = 0;
		childrenLongNodes.Add(child);
		child.edgeToParent = new ConnectionEdge(ConnectionEdge.EdgeTypeEnum.Long, this, child, edgeInternalID);
		CommonChild(child);
	}

	private void CommonChild(UniverseNode child)
	{
		child.parent = this;
	}

	public void DestroyObjects()
	{
		if (gameObject != null)
		{
			Object.Destroy(gameObject);
		}
		gameObject = null;
		if (edgeToParent != null)
		{
			edgeToParent.DestroyObjects();
		}
		edgeToParent = null;
	}

	public List<UniverseNode> GetAllConnectionNodes()
	{
		List<UniverseNode> list = new List<UniverseNode>();
		if (parent != null)
		{
			list.Add(parent);
		}
		list.AddRange(GetAllChildrenNodes());
		return list;
	}

	public List<UniverseNode> GetAllChildrenNodes()
	{
		List<UniverseNode> list = new List<UniverseNode>();
		list.AddRange(childrenShortNodes);
		list.AddRange(childrenLongNodes);
		return list;
	}

	public override string ToString()
	{
		return string.Format("{0} ( {1} ) - {2}:{3}", name, InternalID, numberOfShort, numberOfLong);
	}
}
