using System.Collections;
using UnityEngine;

public class PanelSwatchesColor : MonoBehaviour
{
	private Panel panel;

	private void Awake()
	{
		panel = Panel.SetTarget(base.transform);
		Panel.CreateComponent("color", "color", new Hashtable());
		Panel.CreateComponent("hex", "input", new Hashtable
		{
			{ "label", "Color" },
			{ "value", "#FFFFFF" }
		});
		EventManager.StartListening("ChangeSwatch", DisplayUpdate);
	}

	public void SelectedTab()
	{
		DisplayUpdate();
	}

	private void DisplayUpdate()
	{
		if (!(Swatches.swatch == null))
		{
			panel.SetValue("color", Swatches.swatch.color);
			HexUpdate();
		}
	}

	private void HexUpdate()
	{
		panel.SetValue("hex", "#" + Global.Hex(Swatches.swatch.color));
	}

	private void colorUpdate(Color c)
	{
		if (!(Swatches.swatch == null))
		{
			Swatches.swatch.color = c;
			Swatches.UpdateMaterials();
			HexUpdate();
		}
	}

	private void colorSet(Color c)
	{
		if (!(Swatches.swatch == null))
		{
			Swatches.SetColor(c);
			Swatches.UpdateMaterials();
		}
	}

	private void hexUpdate(string n)
	{
		if (!(Swatches.swatch == null))
		{
			Swatches.SetColor(Global.Hex(n));
			Swatches.UpdateMaterials();
			DisplayUpdate();
		}
	}
}
