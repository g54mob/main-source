using UnityEngine;

public class ToggleButton : DialogButton
{
	public Color offLabelColor = ColorConstants.lightGrey;

	public EdgeSymbols offEdgeSymbols;

	private Color defaultLabelColor;

	private EdgeSymbols defaultEdgeSymbols;

	private bool _isOn = true;

	public bool isOn
	{
		get
		{
			return _isOn;
		}
		set
		{
			_isOn = value;
			UpdateContents();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		defaultLabelColor = label.color;
		defaultEdgeSymbols = new EdgeSymbols();
		defaultEdgeSymbols.CopyFrom(edgeSymbols);
	}

	private void UpdateContents()
	{
		if (isOn)
		{
			label.color = defaultLabelColor;
			edgeSymbols.CopyFrom(defaultEdgeSymbols);
		}
		else
		{
			label.color = offLabelColor;
			edgeSymbols.CopyFrom(offEdgeSymbols);
		}
	}

	protected override void FireOnPressed()
	{
		isOn = !isOn;
		base.FireOnPressed();
	}
}
