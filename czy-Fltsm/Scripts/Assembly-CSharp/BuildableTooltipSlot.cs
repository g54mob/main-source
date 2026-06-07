using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildableTooltipSlot : MonoBehaviour
{
	[Header("Components")]
	[Tooltip("Counter")]
	[SerializeField]
	private TextMeshProUGUI _counter;

	[Tooltip("Background image component.")]
	[SerializeField]
	protected Image _backgroundImage;

	[Header("Colors")]
	[SerializeField]
	[Tooltip("Color for valid requirements.")]
	protected Color _validTextColor = new Color(50f, 50f, 50f);

	[SerializeField]
	[Tooltip("Color for invalid requirements.")]
	protected Color _invalidTextColor = new Color(241f, 103f, 85f);

	private Color _defaultColor;

	protected TextMeshProUGUI Counter => _counter;

	protected virtual void Awake()
	{
		if (_counter == null)
		{
			_counter = GetComponentInChildren<TextMeshProUGUI>();
		}
		if ((bool)_counter)
		{
			_defaultColor = _counter.color;
		}
	}

	public virtual void UpdateSlot()
	{
	}

	public virtual void OverrideColor(bool validColor)
	{
		if (!(_counter == null))
		{
			if (validColor)
			{
				_counter.color = _validTextColor;
			}
			else
			{
				_counter.color = _invalidTextColor;
			}
		}
	}

	public void ResetColor()
	{
		if (!(_counter == null))
		{
			_counter.color = _defaultColor;
		}
	}
}
