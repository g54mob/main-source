using Assets.Source.Player;
using Assets.Source.UI;
using UnityEngine;

public class TechTreeRoot : TraversableView
{
	[SerializeField]
	private Transform _nodesParent;

	[SerializeField]
	private TechTreeNode _nodePrefab;

	[SerializeField]
	private LineRenderer _linePrefab;

	[SerializeField]
	private float _minY;

	[SerializeField]
	private float _maxY;

	public TechTreeNode IronTutorialNode { get; private set; }

	private void Start()
	{
		_boundsMin = new Vector2(0f, _minY);
		_boundsMax = new Vector2(5f, _maxY);
		base.Position = new Vector2(base.Position.x, GamePlayer.Current.TechCameraPosition);
		foreach (TechNode node in TechNode.Nodes)
		{
			if (node.Hidden)
			{
				continue;
			}
			TechTreeNode techTreeNode = Object.Instantiate(_nodePrefab, _nodesParent);
			techTreeNode.Node = node;
			Vector2Int position = node.Position;
			techTreeNode.transform.localPosition = new Vector3(position.x * 2, position.y * 2, 0f);
			if (node.Identifier == "t1u_iron_smelter_auto")
			{
				IronTutorialNode = techTreeNode;
			}
			if (node.Previous != null)
			{
				Vector2Int position2 = node.Previous.Position;
				LineRenderer lineRenderer = Object.Instantiate(_linePrefab, _nodesParent);
				if (node.ConnectionType == TechConnectionType.Normal)
				{
					lineRenderer.SetPositions(new Vector3[3]
					{
						new Vector3(position.x * 2, position.y * 2, 1f),
						new Vector3(position2.x * 2, position.y * 2, 1f),
						new Vector3(position2.x * 2, position2.y * 2, 1f)
					});
				}
				else if (node.ConnectionType == TechConnectionType.Inverted)
				{
					lineRenderer.SetPositions(new Vector3[3]
					{
						new Vector3(position.x * 2, position.y * 2, 1f),
						new Vector3(position.x * 2, position2.y * 2, 1f),
						new Vector3(position2.x * 2, position2.y * 2, 1f)
					});
				}
				else
				{
					float y = (float)(position.y * 2) - 1.1f;
					lineRenderer.positionCount = 4;
					lineRenderer.SetPositions(new Vector3[4]
					{
						new Vector3(position.x * 2, position.y * 2, 1f),
						new Vector3(position.x * 2, y, 1f),
						new Vector3(position2.x * 2, y, 1f),
						new Vector3(position2.x * 2, position2.y * 2, 1f)
					});
				}
			}
		}
	}

	protected override void Update()
	{
		_checkScroll(2, checkNoHover: false);
		_checkScroll(1, checkNoHover: true);
		_checkScroll(0, checkNoHover: true);
		GamePlayer.Current.TechCameraPosition = base.Position.y;
		float num = base.Position.y;
		if (!_scrollButton.HasValue && PlayerControls.CanWASDMove())
		{
			float y = PlayerControls.TraversalDelta.y;
			if (y != 0f)
			{
				num += y * Time.deltaTime * 10f;
			}
		}
		float mouseScroll = PlayerControls.MouseScroll;
		if (mouseScroll != 0f && !UIHelper.IsMouseOverUi)
		{
			num += mouseScroll * 2f;
		}
		if (_scrollButton.HasValue)
		{
			Vector2 mousePosition = PlayerControls.MousePosition;
			float num2 = Camera.main.orthographicSize * 2f;
			float num3 = (float)Screen.height / num2;
			num -= new Vector2((mousePosition.x - _scrollMouse.x) / num3, (mousePosition.y - _scrollMouse.y) / num3).y;
			_scrollMouse = mousePosition;
		}
		base.Position = new Vector2(base.Position.x, num);
	}

	protected override void _checkScroll(int button, bool checkNoHover)
	{
		if (button != 1)
		{
			base._checkScroll(button, checkNoHover);
		}
	}
}
