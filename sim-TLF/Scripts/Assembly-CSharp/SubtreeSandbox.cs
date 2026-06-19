using TheKiwiCoder;
using UnityEngine;

public class SubtreeSandbox : MonoBehaviour
{
	[SerializeField]
	private BehaviourTree _testTree;

	private void Awake()
	{
		foreach (Node node in _testTree.nodes)
		{
			Debug.Log(node.description);
		}
	}
}
