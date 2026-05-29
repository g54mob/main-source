using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Computer.Shopping
{
	public class ToolsViewer : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_firstSelected;

		[SerializeField]
		private GamePadUIPanel m_parentPanel;

		[SerializeField]
		private GamepadSelectableParent m_selectableParent;

		[SerializeField]
		private List<GamepadUISelectable> m_selectables;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}
	}
}
