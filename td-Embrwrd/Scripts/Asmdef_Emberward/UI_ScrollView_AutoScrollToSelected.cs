using UnityEngine;
using UnityEngine.UI;

public class UI_ScrollView_AutoScrollToSelected : MonoBehaviour
{
	[Header("Scroll Settings")]
	[SerializeField]
	private float scrollSpeed;

	[Header("Dead Zone (0~1, 底部=0, 頂部=1)")]
	[Range(0f, 1f)]
	public float centerMin;

	[Range(0f, 1f)]
	public float centerMax;

	private ScrollRect scrollRect;

	private RectTransform viewportRect;

	private RectTransform contentRect;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void EnsureVisible(RectTransform target)
	{
	}
}
