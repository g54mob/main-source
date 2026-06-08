using UnityEngine;

public class CommonTabHeader : MonoBehaviour
{
	public DialogButton leftTab;

	public DialogButton rightTab;

	public AsciiString title;

	public string[] tabLabels;

	public int index;

	private int lastIndex = -1;

	public void UpdateTic()
	{
		if (LeftActive())
		{
			leftTab.UpdateTic();
		}
		if (RightActive())
		{
			rightTab.UpdateTic();
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (lastIndex != index)
		{
			lastIndex = index;
			UpdateLabels();
		}
		if (LeftActive())
		{
			leftTab.Draw(r, offsetX, offsetY);
		}
		if (RightActive())
		{
			rightTab.Draw(r, offsetX, offsetY);
		}
		title.Draw(r, offsetX, offsetY);
	}

	private void UpdateLabels()
	{
		int num = index;
		string value = tabLabels[num];
		title.SetValue(value);
		num = (index + 1) % tabLabels.Length;
		value = tabLabels[num];
		rightTab.label.SetValue(value);
		num = (index - 1 + tabLabels.Length) % tabLabels.Length;
		value = tabLabels[num];
		leftTab.label.SetValue(value);
	}

	private bool LeftActive()
	{
		if ((index != 0 || !ProgressFlags.GetFlag("show_weapon_tab")) && index != 1)
		{
			if (index == 2)
			{
				return ProgressFlags.GetFlag("show_inventory_tab");
			}
			return false;
		}
		return true;
	}

	private bool RightActive()
	{
		if ((index != 0 || !ProgressFlags.GetFlag("show_inventory_tab")) && (index != 1 || !ProgressFlags.GetFlag("show_weapon_tab")))
		{
			return index == 2;
		}
		return true;
	}
}
