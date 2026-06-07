using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class FieldGetGlobalList : TFieldGetVariable
	{
		[SerializeField]
		protected GlobalListVariables m_Variable;

		[SerializeReference]
		protected TListGetPick m_Select = new GetPickFirst();

		public FieldGetGlobalList(IdString typeID)
		{
			m_TypeID = typeID;
		}

		public override object Get(Args args)
		{
			if (!(m_Variable != null))
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
