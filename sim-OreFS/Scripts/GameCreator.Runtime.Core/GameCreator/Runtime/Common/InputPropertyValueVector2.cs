using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class InputPropertyValueVector2 : TInputProperty
	{
		[SerializeReference]
		private TInputValueVector2 m_Input;

		protected override TInput Input => m_Input;

		public InputPropertyValueVector2()
		{
			m_Input = new InputValueVector2None();
		}

		public InputPropertyValueVector2(TInputValueVector2 input)
		{
			m_Input = input;
		}

		public Vector2 Read()
		{
			return m_Input.Read();
		}

		public override string ToString()
		{
			return Input.ToString();
		}
	}
}
