using System;

namespace SuperTiled2Unity
{
	[Serializable]
	public class CustomProperty
	{
		public string m_Name;

		public string m_Type;

		public string m_Value;

		public bool IsEmpty => false;
	}
}
