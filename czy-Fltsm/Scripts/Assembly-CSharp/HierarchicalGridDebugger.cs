using UnityEngine;

public class HierarchicalGridDebugger : MonoBehaviour
{
	[SerializeField]
	private GameplaySettings _gameplaySettings;

	[SerializeField]
	private RectTransform _gridParent;

	[SerializeField]
	private HierarchicalGridNodeUI _nodePrefab;

	private HierarchicalGrid _hierarchicalGrid;

	private void Awake()
	{
		_hierarchicalGrid = new HierarchicalGrid(_gameplaySettings.MapRadius);
		_gridParent.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _hierarchicalGrid.Size.x);
		_gridParent.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _hierarchicalGrid.Size.y);
		int length = _hierarchicalGrid.Nodes.GetLength(0);
		int length2 = _hierarchicalGrid.Nodes.GetLength(1);
		for (int i = 0; i < length2; i++)
		{
			for (int j = 0; j < length; j++)
			{
				Object.Instantiate(_nodePrefab, _gridParent).Initialize(_hierarchicalGrid.Nodes[j, i]);
			}
		}
	}
}
