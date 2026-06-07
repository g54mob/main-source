using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class FieldSetGlobalName : TFieldSetVariable
	{
		[SerializeField]
		protected GlobalNameVariables m_Variable;

		[SerializeField]
		protected IdPathString m_Name;

		public FieldSetGlobalName(IdString typeID)
		{
			m_TypeID = typeID;
		}

		public override void Set(object value, Args args)
		{
			if (!(m_Variable == null))
			{
				m_Variable.Set(m_Name.String, value);
			}
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
