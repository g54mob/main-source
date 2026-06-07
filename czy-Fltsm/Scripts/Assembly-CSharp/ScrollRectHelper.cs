using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollRectHelper : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Snap the scroll rect to the set value on enabling it.")]
	private bool _snapToValueOnEnable = true;

	[SerializeField]
	[Tooltip("Value to snap scroll rect to.")]
	[Range(0f, 1f)]
	private float _snapValue;

	private ScrollRect _scrollRect;

	private bool _snapInUpdate;

	private void Awake()
	{
		_scrollRect = GetComponentInChildren<ScrollRect>();
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
		if (_snapToValueOnEnable)
		{
			_snapInUpdate = true;
		}
	}

	private void LateUpdate()
	{
		if (_snapInUpdate)
		{
			_scrollRect.verticalScrollbar.value = _snapValue;
			_snapInUpdate = false;
		}
	}
}
