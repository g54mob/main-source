using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabletDetectionInputField : MonoBehaviour
{
	public List<TMP_InputField> countFieldFocused;

	public RectTransform CanvasUserUI;

	public ButtonInformationByDevice buttonInformationByDevice;

	private void OnValidate()
	{
	}

	public void Changed()
	{
	}
}
