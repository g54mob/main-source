using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class InputPropertyButton : TInputProperty
	{
		[SerializeReference]
		private TInputButton m_Input;

		protected override TInput Input => m_Input;

		public InputPropertyButton()
		{
			m_Input = new InputButtonNone();
		}

		public InputPropertyButton(TInputButton input)
		{
			m_Input = input;
		}

		public void RegisterStart(Action callback)
		{
			m_Input.EventStart -= callback;
			m_Input.EventStart += callback;
		}

		public void RegisterCancel(Action callback)
		{
			m_Input.EventCancel -= callback;
			m_Input.EventCancel += callback;
		}

		public void RegisterPerform(Action callback)
		{
			m_Input.EventPerform -= callback;
			m_Input.EventPerform += callback;
		}

		public void ForgetStart(Action callback)
		{
			m_Input.EventStart -= callback;
		}

		public void ForgetCancel(Action callback)
		{
			m_Input.EventCancel -= callback;
		}

		public void ForgetPerform(Action callback)
		{
			m_Input.EventPerform -= callback;
		}

		public override string ToString()
		{
			return Input.ToString();
		}
	}
}
