using System.Collections;
using UnityEngine;

public class DebugPathfinder : MonoBehaviour
{
	public enum SetupStages
	{
		None = 0,
		SelectNavigator = 1,
		SelectTarget = 2
	}

	public Vector3 NodeVisualOffset = new Vector3(0f, 0f, 0f);

	public Vector3 HandleOffset = new Vector3(0f, 1f, 0f);

	public bool DrawOpenNodes = true;

	public bool DrawClosedNode = true;

	public bool DrawQueryPath = true;

	public bool DrawDebugPath;

	[Header("Path Setup")]
	public LayerMask NavigatorMask = 768;

	public LayerMask TargetMask = 69632;

	private IEnumerator _debugRoutine;

	private PathfindingQueryBase _debugQuery;

	private bool _moveNextNode;

	private Collider _collider;

	private Navigator _mouseNavigator;

	private RaycastHit _mouseNavigatorHit;

	private Target _mouseTarget;

	private RaycastHit _mouseTargetHit;

	public SetupStages SetupStage { get; private set; }

	public Navigator Navigator { get; private set; }

	public Target Target { get; private set; }

	public PathfindingNode TargetNode { get; private set; }

	public PathfindingNodeData SelectedNode { get; private set; }

	public bool IsDebugging => _debugRoutine != null;

	private void Awake()
	{
		_collider = new GameObject().AddComponent<BoxCollider>();
		_collider.transform.SetParent(base.transform);
		_collider.name = "Gizmo Collider";
	}

	public void SetupNavigatorTargetQuery()
	{
	}

	public void DebugQuery(PathfindingQueryBase query)
	{
		StartDebugRoutine(DebugQueryRoutine(query));
	}

	private IEnumerator DebugQueryRoutine(PathfindingQueryBase query)
	{
		if (!query.Execute(-1, async: false))
		{
			yield break;
		}
		_debugQuery = query;
		if (query is PathQuery pathQuery)
		{
			TargetNode = pathQuery.TargetNode;
		}
		while (query.ProcessNextNode())
		{
			_moveNextNode = false;
			while (!_moveNextNode)
			{
				yield return null;
			}
		}
	}

	private void StartDebugRoutine(IEnumerator debugRoutine)
	{
		StopDebugRoutine();
		_debugRoutine = debugRoutine;
		StartCoroutine(_debugRoutine);
	}

	private void StopDebugRoutine()
	{
		if (_debugRoutine != null)
		{
			StopCoroutine(_debugRoutine);
		}
		_debugQuery = null;
	}
}
