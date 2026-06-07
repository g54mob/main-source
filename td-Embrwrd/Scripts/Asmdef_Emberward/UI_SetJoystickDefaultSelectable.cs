using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetJoystickDefaultSelectable : MonoBehaviour
{
	[SerializeField]
	private Selectable defaultSelectable;

	[SerializeField]
	private bool restrictControlScheme;

	[SerializeField]
	private eControlScheme controlScheme;

	[SerializeField]
	private List<Selectable> list_FallbackSelectables;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}
}
