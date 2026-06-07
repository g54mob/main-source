using UnityEngine;

public class HintController : MonoBehaviour
{
	[Header("Viewport Hints")]
	public GameObject viewportHintGameobject;

	public GameObject[] viewportHints;

	public bool viewportHintsComplete;

	private int viewportHintId;

	private string viewportHintPrefKey;

	[Header("Add Component Hint")]
	public GameObject addCompHintGameobject;

	private string addCompHintPrefKey;

	[Header("Transform Handle Hint")]
	public GameObject transformHintGameobject;

	public RectTransform transformHintTransform;

	private string transformHintPrefKey;

	[Header("Wire Method Hint")]
	public GameObject toolHintCanvasGameObject;

	public GameObject wireMethodHintGameObject;

	public RectTransform wireMethodHintTransform;

	public RectTransform wireMethodTransform;

	public string wireMethodHintPrefKey;

	[Header("Property Hint")]
	public GameObject propertyHintGameObject;

	public RectTransform propertyHintTransform;

	public RectTransform propertyTransform;

	public string propertyHintPrefKey;

	private static HintController inst { get; set; }

	private void Start()
	{
	}

	public void ViewportHintAccept()
	{
	}

	public void AddCompHintAccept()
	{
	}

	public static void TransformHint(Vector3 position)
	{
	}

	public void TransformHintAccept()
	{
	}

	public static void ToolHint()
	{
	}

	public void WireMethodHintAccept()
	{
	}

	public void PropertyHintAccept()
	{
	}
}
