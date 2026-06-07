using System.Collections.Generic;
using UnityEngine;

public class SpecializationWindow : MonoBehaviour
{
	public GUIWindow Window;

	public SpecializationChart Chart;

	public void Show(string name, Dictionary<string, int>[] specs, float[] skills)
	{
		if (specs != null)
		{
			Window.NonLocTitle = name;
			Chart.CustomSpecLevels = specs;
			Chart.SkillOverride = skills;
			Chart.ResetContent();
			Window.Show();
		}
	}
}
