using TMPro;
using UnityEngine;

namespace GameCreator.Runtime.Common.UnityUI
{
	[AddComponentMenu("Game Creator/UI/Input Field - TextMeshPro")]
	public class InputFieldTMPPropertyString : TMP_InputField
	{
		[SerializeField]
		private bool m_SetFromSource;

		[SerializeField]
		private PropertySetString m_OnChangeSet = new PropertySetString();

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
			base.text = m_OnChangeSet.Get(m_Args);
		}

		private void OnChangeValue(string value)
		{
			m_OnChangeSet.Set(value, m_Args);
		}
	}
}
