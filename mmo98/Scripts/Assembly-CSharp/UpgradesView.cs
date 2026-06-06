using R3;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesView : MonoBehaviour, IMainView
{
	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private RectTransform contentContainer;

	[SerializeField]
	private RectTransform nodesContainer;

	[SerializeField]
	private RectTransform connectionsContainer;

	[SerializeField]
	private UpgradeNodeVisualizer nodePrefab;

	[SerializeField]
	private UpgradeNodeConnection connectionPrefab;

	[SerializeField]
	private Vector2 gridSize = new Vector2(100f, 100f);

	[SerializeField]
	private float padding = 200f;

	[SerializeField]
	private Vector3 zoomInScale = new Vector3(1f, 1f, 1f);

	[SerializeField]
	private Vector3 zoomOutScale = new Vector3(0.75f, 0.75f, 0.75f);

	[SerializeField]
	private Button zoomButton;

	[SerializeField]
	private GameObject zoomInIcon;

	[SerializeField]
	private GameObject zoomOutIcon;

	private bool _zoomedOut;

	private Observable<Unit> _moneyRefreshStream;

	public void Initialize()
	{
		Initializer.Context(zoomButton).AddListener(delegate
		{
			ZoomToggle(!_zoomedOut);
		}).Invoke(InitializeTree)
			.Invoke(delegate
			{
				ZoomToggle(zoom: false);
			})
			.Invoke(Hide);
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		UI.Registry.taskbar.upgrades.ForcePressed();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		UI.Registry.taskbar.upgrades.Clear();
	}

	private void ZoomToggle(bool zoom)
	{
		_zoomedOut = zoom;
		zoomInIcon.SetActive(_zoomedOut);
		zoomOutIcon.SetActive(!_zoomedOut);
		contentContainer.localScale = (_zoomedOut ? zoomOutScale : zoomInScale);
	}

	private void InitializeTree()
	{
		CalculateBounds(out var minX, out var maxX, out var minY, out var maxY);
		ResizeContentContainer(minX, maxX, minY, maxY);
		foreach (UpgradeNodeData item in CatalogProvider.Upgrades.Collection)
		{
			SpawnNode(item);
			SpawnConnection(item);
		}
		scrollRect.normalizedPosition = new Vector2(0.5f, 0.5f);
	}

	private void CalculateBounds(out int minX, out int maxX, out int minY, out int maxY)
	{
		minX = 0;
		maxX = 0;
		minY = 0;
		maxY = 0;
		foreach (UpgradeNodeData item in CatalogProvider.Upgrades.Collection)
		{
			Vector2Int gridPosition = item.gridPosition;
			if (gridPosition.x < minX)
			{
				minX = gridPosition.x;
			}
			if (gridPosition.x > maxX)
			{
				maxX = gridPosition.x;
			}
			if (gridPosition.y < minY)
			{
				minY = gridPosition.y;
			}
			if (gridPosition.y > maxY)
			{
				maxY = gridPosition.y;
			}
		}
	}

	private void ResizeContentContainer(int minX, int maxX, int minY, int maxY)
	{
		int num = Mathf.Max(Mathf.Abs(minX), Mathf.Abs(maxX));
		int num2 = Mathf.Max(Mathf.Abs(minY), Mathf.Abs(maxY));
		Rect rect = scrollRect.viewport.rect;
		float x = (float)(num * 2) * gridSize.x + padding + rect.width;
		float y = (float)(num2 * 2) * gridSize.y + padding + rect.height;
		contentContainer.sizeDelta = new Vector2(x, y);
		contentContainer.pivot = new Vector2(0.5f, 0.5f);
		contentContainer.anchorMin = new Vector2(0.5f, 0.5f);
		contentContainer.anchorMax = new Vector2(0.5f, 0.5f);
	}

	private void SpawnNode(UpgradeNodeData data)
	{
		UpgradeNodeVisualizer upgradeNodeVisualizer = Object.Instantiate(nodePrefab, nodesContainer);
		upgradeNodeVisualizer.Setup(data);
		upgradeNodeVisualizer.GetComponent<RectTransform>().anchoredPosition = data.GetPosition(gridSize);
		if (data.prerequisite == UpgradeNode.None)
		{
			upgradeNodeVisualizer.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
		}
	}

	private void SpawnConnection(UpgradeNodeData node)
	{
		if (node.prerequisite != UpgradeNode.None)
		{
			UpgradeNodeData upgradeNodeData = node.prerequisite.Data();
			Vector2 position = node.GetPosition(gridSize);
			Vector2 position2 = upgradeNodeData.GetPosition(gridSize);
			Vector2 normalized = (position2 - position).normalized;
			float x = Vector2.Distance(position, position2);
			UpgradeNodeConnection upgradeNodeConnection = Object.Instantiate(connectionPrefab, connectionsContainer);
			upgradeNodeConnection.Setup(upgradeNodeData, node.research);
			RectTransform component = upgradeNodeConnection.GetComponent<RectTransform>();
			component.pivot = new Vector2(0f, 0.5f);
			component.anchoredPosition = position;
			component.localRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(normalized.y, normalized.x) * 57.29578f);
			component.sizeDelta = new Vector2(x, component.sizeDelta.y);
		}
	}
}
