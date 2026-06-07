using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class InputMapFromAsset
	{
		[SerializeField]
		private InputActionAsset m_InputAsset;

		[SerializeField]
		private string m_ActionMap;

		[NonSerialized]
		private InputActionMap m_InputMap;

		public InputActionMap InputMap
		{
			get
			{
				if (m_InputMap != null)
				{
					return m_InputMap;
				}
				if (m_InputAsset == null)
				{
					Debug.LogError("Input Map Asset not found");
					return null;
				}
				m_InputMap = m_InputAsset.FindActionMap(m_ActionMap);
				if (m_InputMap != null)
				{
					return m_InputMap;
				}
				Debug.LogErrorFormat("Unable to find Input Map for asset: {0}. Map: {1}", (m_InputAsset != null) ? m_InputAsset.name : "(null)", m_ActionMap);
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
