using UnityEngine;
using UnityEngine.UI;

public class TechTreePanelEdge : MonoBehaviour
{
	[SerializeField]
	private Image[] _visualElements;

	[SerializeField]
	private Color _color;

	public TechTreePanelNode StartNode { get; private set; }

	public TechTreePanelNode EndNode { get; private set; }

	public Vector2 Vector { get; private set; }

	private void OnValidate()
	{
		_visualElements = GetComponentsInChildren<Image>();
		SetColor(_color);
	}

	public void Initialize(TechTreePanelNode startNode, TechTreePanelNode endNode)
	{
		StartNode = startNode;
		EndNode = endNode;
		RectTransform obj = base.transform as RectTransform;
		Vector = endNode.EdgeEnd - startNode.EdgeStart;
		obj.anchoredPosition = startNode.EdgeStart;
		obj.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Vector.magnitude);
		obj.rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.right, Vector));
		startNode.EnableEdgeStartVisual();
		base.gameObject.SetActive(value: true);
	}

	public void SetColor(Color color)
	{
		Image[] visualElements = _visualElements;
		for (int i = 0; i < visualElements.Length; i++)
		{
			visualElements[i].color = color;
		}
	}
}
