using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Computer.Management.Hiring_Tab
{
	public class HiringTab : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_firstSelected;

		[SerializeField]
		private GamePadUIPanel m_parentPanel;

		[SerializeField]
		private GamepadSelectableParent m_selectableParent;

		[SerializeField]
		private List<GamepadUISelectable> m_selectables;

		[SerializeField]
		private GameObject m_BakerParent;

		[SerializeField]
		private GameObject m_IceCreamParent;

		[SerializeField]
		private RectTransform m_ParentContentTransform;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		public void SetDLCNeighbourhoods()
		{
		}
	}
}
