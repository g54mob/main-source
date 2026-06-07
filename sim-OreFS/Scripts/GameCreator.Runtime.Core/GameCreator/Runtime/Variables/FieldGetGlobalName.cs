using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class FieldGetGlobalName : TFieldGetVariable
	{
		[SerializeField]
		protected GlobalNameVariables m_Variable;

		[SerializeField]
		protected IdPathString m_Name;

		public FieldGetGlobalName(IdString typeID)
		{
			m_TypeID = typeID;
		}

		public override object Get(Args args)
		{
			if (!(m_Variable != null))
			{
				return null;
			}
			return m_Variable.Get(m_Name.String);
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", (m_Variable != null) ? m_Variable.name : "(none)", string.IsNullOrEmpty(m_Name.String) ? string.Empty : ("[" + m_Name.String + "]"));
		}
	}
}
