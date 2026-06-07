using TMPro;
using UnityEngine;

public class MultitoolInspectorContainerPopup : MonoBehaviour
{
	public TextMeshProUGUI title;

	public Transform linesRoot;

	public MultitoolInspectorService inspector;

	public GameObject lineElement;

	private LayoutHelper<MultitoolInspectorLine> layout;

	private MultitoolInspectorLine line;

	private void Awake()
	{
	}

	public void Show(MultitoolInspectorLine line)
	{
	}

	public void Hide()
	{
	}
}
