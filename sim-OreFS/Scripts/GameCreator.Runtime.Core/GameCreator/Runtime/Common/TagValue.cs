using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TagValue
	{
		[SerializeField]
		private string m_Value = "Untagged";

		public string Value => m_Value;

		public override string ToString()
		{
			return m_Value;
		}
	}
}
