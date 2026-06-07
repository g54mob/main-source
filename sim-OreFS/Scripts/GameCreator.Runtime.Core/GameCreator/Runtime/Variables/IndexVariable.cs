using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class IndexVariable : TVariable
	{
		public override string Title => $"{m_Value}";

		public override TVariable Copy => new IndexVariable
		{
			m_Value = m_Value.Copy
		};

		public IndexVariable()
		{
		}

		public IndexVariable(IdString typeID)
			: base(typeID)
		{
		}

		public IndexVariable(TValue value)
			: this()
		{
			m_Value = value;
		}
	}
}
