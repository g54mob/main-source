using UnityEngine;

public class ScrollRectControllerScroll : MonoBehaviour
{
	[Header("Settings")]
	public bool autoScrollingEnabled;

	public float scrollSpeed;

	[Header("References")]
	private CustomScrollRect scrollRect;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
