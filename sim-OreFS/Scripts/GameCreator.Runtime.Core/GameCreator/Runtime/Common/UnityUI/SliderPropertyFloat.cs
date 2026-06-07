using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[AddComponentMenu("Game Creator/UI/Slider")]
	public class SliderPropertyFloat : Slider
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
			value = (float)m_OnChangeSet.Get(m_Args);
		}

		private void OnChangeValue(float value)
		{
			m_OnChangeSet.Set(value, m_Args);
		}
	}
}
