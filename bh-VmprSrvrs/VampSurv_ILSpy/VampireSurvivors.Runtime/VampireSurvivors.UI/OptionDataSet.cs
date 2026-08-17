using UnityEngine;

namespace VampireSurvivors.UI;

public class OptionDataSet(string title, string info, Sprite icon = null)
{
	public string Title = title;

	public string Info = info;

	public Sprite Icon = icon;
}
