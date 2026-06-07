using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class FieldSetLocalName : TFieldSetVariable
	{
		[SerializeReference]
		protected PropertyGetGameObject m_Variable = new PropertyGetGameObject();

		[SerializeField]
		protected IdPathString m_Name;

		public FieldSetLocalName(IdString typeID)
		{
			m_TypeID = typeID;
		}

		public override void Set(object value, Args args)
		{
			m_Variable.Get<LocalNameVariables>(args).Set(m_Name.String, value);
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
