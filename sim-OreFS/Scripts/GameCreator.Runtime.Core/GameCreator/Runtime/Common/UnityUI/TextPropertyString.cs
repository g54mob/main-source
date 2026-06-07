using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[AddComponentMenu("Game Creator/UI/Text")]
	public class TextPropertyString : Text
	{
		[SerializeField]
		private PropertyGetString m_Value = new PropertyGetString();

		private Args m_Args;

		protected override void Start()
		{
			base.Start();
			if (Application.isPlaying)
			{
				m_Args = new Args(base.gameObject);
			}
		}

		private void LateUpdate()
		{
			string text = m_Value.Get(m_Args);
			if (text != this.text)
			{
				this.text = text;
			}
		}
	}
}
