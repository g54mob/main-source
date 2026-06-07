using UnityEngine;

public class PathingDevToolsNode : MonoBehaviour
{
	[SerializeField]
	private Color _constructionGraphColor = Color.cyan;

	[SerializeField]
	private Color _watersurfaceGraphColor = Color.magenta;

	[SerializeField]
	private Color _nextColor = Color.green;

	[SerializeField]
	private Color _passedColor = Color.black;

	private PathfinderPath _path;

	private PathfindingNode _node;

	private void LateUpdate()
	{
		if (_path.Nodes.Contains(_node))
		{
			base.transform.position = _node.RootPosition;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void Initialize(PathfinderPath path, PathfindingNode node)
	{
		_path = path;
		_node = node;
		base.transform.position = node.RootPosition;
	}
}
