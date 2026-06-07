using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
	private static ToolTip tt_inst;

	[Header("Params")]
	public Vector2 pointOffset;

	public RectTransform rectTransform;

	public Canvas textCanvas;

	public Canvas boxCanvas;

	public Text text;

	public float delay;

	public float duration;

	private float delayT;

	private float durationT;

	private bool delayActive;

	private bool durationActive;

	private string str;

	public static ToolTip Inst => null;

	private void Awake()
	{
	}

	public static void ButtonHighlighted(string str)
	{
	}

	public static void Hide()
	{
	}

	private void _ButtonHighlighted(string str)
	{
	}

	private void _Display()
	{
	}

	private void _Hide()
	{
	}

	private void Update()
	{
	}
}
