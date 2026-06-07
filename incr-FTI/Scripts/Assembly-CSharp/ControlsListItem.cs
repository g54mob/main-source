using TMPro;
using UnityEngine;

public class ControlsListItem : MonoBehaviour
{
	public delegate string StringDelegate();

	public TextMeshProUGUI label;

	public LabelButton controlButton;

	public KeyCode mappedInput;

	public bool requiresControl;

	public StringDelegate labelTextDelegate;
}
