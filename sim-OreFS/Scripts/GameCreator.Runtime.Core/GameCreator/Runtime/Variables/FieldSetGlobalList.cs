using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class FieldSetGlobalList : TFieldSetVariable
	{
		[SerializeField]
		protected GlobalListVariables m_Variable;

		[SerializeReference]
		protected TListSetPick m_Select = new SetPickFirst();

		public FieldSetGlobalList(IdString typeID)
		{
			m_TypeID = typeID;
		}

		public override void Set(object value, Args args)
		{
			if (!(m_Variable == null))
			{
				m_Variable.Set(m_Select, value, args);
			}
		}

		public override object Get(Args args)
		{
			if (m_Variable == null)
			{
				return null;
			}
			return m_Variable.Get(m_Select, args);
		}

		public override string ToString()
		{
			if (!(m_Variable != null))
			{
				return "(none)";
			}
			return $"{m_Variable.name}[{m_Select}]";
		}
	}
}
