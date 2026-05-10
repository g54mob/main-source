using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
	[SerializeField]
	private List<CanvasScaler> canvases;

	private List<Vector2> startResolutions;

	private void Start()
	{
		startResolutions = canvases.Select((CanvasScaler c) => c.referenceResolution).ToList();
		SetScale("UI size");
		OptionHolder.OnOptionChanged += SetScale;
	}

	private void SetScale(string option)
	{
		if (option == "UI size")
		{
			float y = OptionHolder.GetFloat("UI size");
			for (int i = 0; i < canvases.Count; i++)
			{
				canvases[i].referenceResolution = startResolutions[i] / new Vector2(1f, y);
			}
		}
	}
}
