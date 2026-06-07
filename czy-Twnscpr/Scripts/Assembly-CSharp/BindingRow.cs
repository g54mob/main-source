using System;
using Placemaker.Ui;
using Rewired;
using TMPro;
using UnityEngine;

public class BindingRow : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI actionText;

	[SerializeField]
	private TextMeshProUGUI buttonText;

	[SerializeField]
	private BaseButton baseButton;

	public InputAction action;

	public AxisRange actionRange;

	public ControlBinding.RowVisibilityCategory visibility;

	public void SetAction(InputAction action, AxisRange actionRange, string label, ControlBinding.RowVisibilityCategory visibility)
	{
	}

	public void SetButton(string name, Action<int, int, bool> action, int index, int mapId, bool isAltField)
	{
	}
}
