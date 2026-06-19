using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class HoverText : MonoBehaviour
{
	[SerializeField]
	private List<TextMeshProUGUI> _text;

	public List<string> TextRequests;

	[SerializeField]
	private CanvasGroup _canvasGroup;

	private Tween _tween;

	[SerializeField]
	private float _fadeDuration;

	private int _disabledStacks;

	public static HoverText Instance { get; private set; }

	public void AddDisableStack()
	{
	}

	public void RemoveDisableStack()
	{
	}

	public void Initiate()
	{
	}

	public void AddTextRequest(string text)
	{
	}

	public void AddPriorityTextRequest(string text)
	{
	}

	public void RemoveTextRequest(string text)
	{
	}

	public void Evaluate()
	{
	}
}
