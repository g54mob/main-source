using TMPro;
using UnityEngine;

public class UITooltipText : UITooltipContent
{
	[SerializeField]
	protected TMP_Text _text;

	protected float _spacing;

	public override float Height => _text.preferredHeight + _spacing;

	public override float Spacing => _spacing;

	public TMP_Text Text => _text;

	public void SetText(string text, int size, float margin)
	{
		_text.text = text;
		_text.fontSize = size;
		_spacing = margin;
	}
}
