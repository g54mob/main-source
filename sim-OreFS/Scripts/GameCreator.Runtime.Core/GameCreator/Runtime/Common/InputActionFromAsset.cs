using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class InputActionFromAsset
	{
		[SerializeField]
		private InputActionAsset m_InputAsset;

		[SerializeField]
		private string m_ActionMap;

		[SerializeField]
		private string m_Action;

		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction != null)
				{
					return m_InputAction;
				}
				if (m_InputAsset == null)
				{
					Debug.LogError("Input Action Asset not found");
					return null;
				}
				if (string.IsNullOrEmpty(m_ActionMap))
				{
					m_InputAction = m_InputAsset.FindAction(m_Action);
					return m_InputAction;
				}
				InputActionMap inputActionMap = m_InputAsset.FindActionMap(m_ActionMap);
				if (inputActionMap != null)
				{
					m_InputAction = inputActionMap.FindAction(m_Action);
					return m_InputAction;
				}
				Debug.LogErrorFormat("Unable to find Input Action for asset: {0}. Map: {1} and Action: {2}", (m_InputAsset != null) ? m_InputAsset.name : "(null)", m_ActionMap, m_Action);
				return null;
			}
		}

		public override string ToString()
		{
			if (!(m_InputAsset != null))
			{
				return "(none)";
			}
			return m_InputAsset.name;
		}
	}
}
