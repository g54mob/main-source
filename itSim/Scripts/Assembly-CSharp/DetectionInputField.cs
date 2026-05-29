using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectionInputField : MonoBehaviour
{
	public ComputerStation computerStation;

	public List<TMP_InputField> countFieldFocused;

	public List<AppTerminalSelectable> countAppTerminalSelectable;

	public ButtonInformationByDevice buttonInformationByDevice;

	private void OnValidate()
	{
	}

	public void Changed()
	{
	}
}
