using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[AddComponentMenu("Game Creator/UI/Dropdown")]
	public class DropdownPropertyInteger : Dropdown
	{
		[SerializeField]
		private bool m_SetFromSource;

		[SerializeField]
		private PropertySetNumber m_OnChangeSet = new PropertySetNumber();

		private Args m_Args;

		protected override void Start()
		{
			base.Start();
			if (Application.isPlaying)
			{
				m_Args = new Args(base.gameObject);
				if (m_SetFromSource)
				{
					SetValueFromProperty();
				}
				base.onValueChanged.AddListener(OnChangeValue);
			}
		}

		public void SetValueFromProperty()
		{
			base.value = (int)Math.Floor(m_OnChangeSet.Get(m_Args));
		}

		private void OnChangeValue(int index)
		{
			m_OnChangeSet.Set(base.value, m_Args);
		}
	}
}
