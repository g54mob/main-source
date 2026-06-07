using System;
using System.Collections.Generic;
using System.Linq;
using PajamaLlama.Debugs;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using UnityEngine;

[DisallowMultipleComponent]
public class HierarchicalNodeMarker : MonoBehaviour
{
	[Tooltip("Diameter of this marker.")]
	public float Diameter = 1f;

	[Tooltip("Range for this marker to connect with neighbors.")]
	public float Range = 2f;

	[Header("Debugging")]
	[Tooltip("Display debug info.")]
	[SerializeField]
	private bool _debug;

	[SerializeField]
	private Graph.Type _debugGraphs = Graph.Type.Constructions;

	private Agent _idlingAgent;

	public HierarchicalNodeMarker Parent { get; private set; }

	public HierarchicalNodeMarker[] Children { get; private set; }

	public List<HierarchicalNodeMarker> Neighbors { get; private set; } = new List<HierarchicalNodeMarker>(32);

	public HierarchicalNode Node { get; private set; }

	public Construction Construction { get; set; }

	public bool DoDebug => _debug;

	public bool ReservedForIdling { get; set; }

	public bool IsFree
	{
		get
		{
			if (_idlingAgent == null)
			{
				return !ReservedForIdling;
			}
			return false;
		}
	}

	public bool IsOutOfBounds { get; set; }

	private void Awake()
	{
		if ((bool)base.transform.parent)
		{
			Parent = base.transform.parent.GetComponentInParent<HierarchicalNodeMarker>();
		}
		Children = GetComponentsInChildren<HierarchicalNodeMarker>();
	}

	private void OnDestroy()
	{
		if (Node != null)
		{
			RemoveFromConstructionGraph();
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (!_debug)
		{
			return;
		}
		Gizmos.DrawSphere(base.transform.position, 0.1f);
		Gizmos.DrawWireSphere(base.transform.position, Range);
		if (Node == null || Node.Neighbors == null)
		{
			return;
		}
		foreach (PathfindingNode neighbor in Node.Neighbors)
		{
			if (neighbor.Graph.TypesMatch(_debugGraphs))
			{
				Gizmos.color = Color.green;
				Gizmos.DrawLine(base.transform.position, neighbor.RootPosition);
				if (neighbor is GridNode gridNode)
				{
					Gizmos.color = new Color(0.5f, 0f, 0f);
					gridNode.DrawGizmo();
				}
			}
		}
	}

	public void SetParent(HierarchicalNodeMarker parent)
	{
		if ((bool)Parent)
		{
			Debug.LogException(new Exception($"HierarchicalNodeMarker parent '{Parent}' is override with '{parent}'."));
		}
		Parent = parent;
	}

	public bool AddToConstructionGraph(bool logWarning = true)
	{
		if (base.gameObject.scene.name == null || string.IsNullOrEmpty(base.gameObject.scene.name))
		{
			Debug.LogErrorFormat("HierarchicalNodeMarker '{0}' is not instanced and can therfeore not be added to the construction graph. This is a bug!", this.HierarchyPathToString());
			return false;
		}
		if (Node == null)
		{
			if ((bool)Parent && Parent.Node != null)
			{
				Parent.Node.AddChild(this);
			}
			else
			{
				GameManager.GraphManager.ConstructionGraph.AddNode(this);
			}
			GameEventDispatcher.Dispatch(GameEventType.ConstructionGraphUpdated);
		}
		else if (logWarning)
		{
			Debug.LogWarningFormat("Unable to add HierarchicalNodeMarker '{0}' to the construction graph as it was already added!", this.HierarchyPathToString());
		}
		return true;
	}

	public void SetNode(HierarchicalNode node)
	{
		Node = node;
	}

	public void RemoveFromConstructionGraph()
	{
		if (Node != null)
		{
			if (GameManager.GraphManager.ConstructionGraph.RemoveNode(Node))
			{
				Node = null;
				GameEventDispatcher.Dispatch(GameEventType.ConstructionGraphUpdated);
			}
			else if (base.gameObject.scene.isLoaded)
			{
				Debug.LogError("Unable to remove HierarchicalNodeMarker.Node from construction graph!");
			}
		}
	}

	public static HierarchicalNodeMarker Instantiate(Vector3 localPosition = default(Vector3), Transform parent = null, string name = "HierarchicalMarker")
	{
		HierarchicalNodeMarker hierarchicalNodeMarker = UnityEngine.Object.Instantiate(GameManager.Settings.BuildableSettings.HierarchicalNodeMarkerPrefab, parent);
		hierarchicalNodeMarker.transform.localPosition = localPosition;
		return hierarchicalNodeMarker;
	}

	public void SetNeighbors()
	{
		if (base.transform.parent == null)
		{
			return;
		}
		Neighbors.Clear();
		List<HierarchicalNodeMarker> list = base.transform.parent.GetComponentsInChildren<HierarchicalNodeMarker>().ToList();
		list.RemoveAll((HierarchicalNodeMarker candidate) => candidate == this || candidate.transform.parent != base.transform.parent);
		for (int num = 0; num < list.Count; num++)
		{
			if (!(list[num].transform.parent == base.transform) && !(Vector3.Distance(base.transform.position, list[num].transform.position) > Range))
			{
				Neighbors.Add(list[num]);
			}
		}
		Debugger.Log($"Found {Neighbors.Count} neighbors.");
	}

	public void SetIdlingAgent(Agent agent)
	{
		if (_idlingAgent != null && _idlingAgent != agent)
		{
			if (_idlingAgent.Assignment == null)
			{
				PushIdlingAgentAway();
			}
			else
			{
				RemoveIdlingAgent(_idlingAgent);
			}
		}
		_idlingAgent = agent;
		ReservedForIdling = false;
	}

	public void RemoveIdlingAgent(Agent agent)
	{
		if (_idlingAgent != null && _idlingAgent == agent)
		{
			_idlingAgent = null;
			ReservedForIdling = false;
		}
	}

	public void PushIdlingAgentAway()
	{
		if (_idlingAgent != null)
		{
			_idlingAgent.MoveToFreeNode(this);
			RemoveIdlingAgent(_idlingAgent);
		}
	}

	public bool IsInRange(Vector3 position, float range)
	{
		if (base.transform.position.IsInRange(position, range * 0.95f))
		{
			return true;
		}
		return false;
	}

	public void SetPenalty(int penalty)
	{
		Node?.SetPenalty(penalty);
	}

	public void ClearPenalty()
	{
		Node?.ClearPenalty();
	}

	public HierarchicalNodeMarker ReturnChildClosestToPoint(Vector3 point)
	{
		int num = Children.Length;
		if (Children == null || num == 0)
		{
			return this;
		}
		float num2 = float.MaxValue;
		HierarchicalNodeMarker result = null;
		for (int i = 0; i < num; i++)
		{
			HierarchicalNodeMarker hierarchicalNodeMarker = Children[i];
			float num3 = Vector3.Distance(point, hierarchicalNodeMarker.transform.position);
			if (num3 < num2)
			{
				num2 = num3;
				result = hierarchicalNodeMarker;
			}
		}
		return result;
	}
}
