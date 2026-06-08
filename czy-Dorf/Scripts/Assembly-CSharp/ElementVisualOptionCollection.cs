using System;
using System.Collections.Generic;

[Serializable]
public class ElementVisualOptionCollection
{
	public float displayProbability = 1f;

	public List<ColorSet> defaultColors;

	public List<ElementVisualOption> visualOptions;

	public ElementVisualOptionCollection()
	{
		defaultColors = new List<ColorSet>();
		visualOptions = new List<ElementVisualOption>();
	}
}
