using System.Collections.Generic;
using UnityEngine;

public class HideableUIElement : MonoBehaviour
{
	public static List<HideableUIElement> Canvases;

	public List<CanvasGroup> HideableElements;

	public bool Shown;

	public void SetShown(bool shown)
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
