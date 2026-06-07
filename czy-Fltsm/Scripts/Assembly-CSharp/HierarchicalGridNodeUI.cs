using UnityEngine;
using UnityEngine.UI;

public class HierarchicalGridNodeUI : MonoBehaviour
{
	[SerializeField]
	private HierarchicalGridLeafNodeUI _leafNodePrefab;

	[SerializeField]
	private Image _border;

	public RectTransform RectTransform { get; private set; }

	private void Awake()
	{
		RectTransform = base.transform as RectTransform;
	}

	public void Initialize(HierarchicalGridNode node)
	{
		base.gameObject.SetActive(value: true);
		int num = _leafNodePrefab.Size * node.Size;
		RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
		RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
		RectTransform.anchoredPosition = node.Position;
		_border.color = Color.black;
	}
}
