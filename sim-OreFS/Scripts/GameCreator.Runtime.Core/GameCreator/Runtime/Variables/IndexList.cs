using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class IndexList : TList<IndexVariable>
	{
		[SerializeField]
		private IdString m_TypeID = ValueNull.TYPE_ID;

		public IdString TypeID => m_TypeID;

		public IndexList()
		{
		}

		public IndexList(IdString typeID)
			: this()
		{
			m_TypeID = typeID;
		}

		public IndexList(IdString typeID, params IndexVariable[] variables)
			: base(variables)
		{
			m_TypeID = typeID;
		}
	}
}
