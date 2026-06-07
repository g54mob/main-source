using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class InputPropertyValueFloat : TInputProperty
	{
		[SerializeReference]
		private TInputValueFloat m_Input;

		protected override TInput Input => m_Input;

		public InputPropertyValueFloat()
		{
			m_Input = new InputValueFloatNone();
		}

		public InputPropertyValueFloat(TInputValueFloat input)
		{
			m_Input = input;
		}

		public float Read()
		{
			return m_Input.Read();
		}

		public override string ToString()
		{
			return Input.ToString();
		}
	}
}
