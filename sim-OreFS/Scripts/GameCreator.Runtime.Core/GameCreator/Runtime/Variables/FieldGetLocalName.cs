using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class FieldGetLocalName : TFieldGetVariable
	{
		[SerializeReference]
		protected PropertyGetGameObject m_Variable = new PropertyGetGameObject();

		[SerializeField]
		protected IdPathString m_Name;

		public FieldGetLocalName(IdString typeID)
		{
			m_TypeID = typeID;
		}

		public override object Get(Args args)
		{
			LocalNameVariables localNameVariables = m_Variable.Get<LocalNameVariables>(args);
			if (!(localNameVariables != null))
			{
				return null;
			}
			return localNameVariables.Get(m_Name.String);
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", m_Variable, string.IsNullOrEmpty(m_Name.String) ? string.Empty : ("[" + m_Name.String + "]"));
		}
	}
}
