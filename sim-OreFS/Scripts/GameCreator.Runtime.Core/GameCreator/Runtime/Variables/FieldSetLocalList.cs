using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class FieldSetLocalList : TFieldSetVariable
	{
		[SerializeField]
		protected PropertyGetGameObject m_Variable = new PropertyGetGameObject();

		[SerializeReference]
		protected TListSetPick m_Select = new SetPickFirst();

		public FieldSetLocalList(IdString typeID)
		{
			m_TypeID = typeID;
		}

		public override void Set(object value, Args args)
		{
			LocalListVariables localListVariables = m_Variable.Get<LocalListVariables>(args);
			if (localListVariables != null)
			{
				localListVariables.Set(m_Select, value, args);
			}
		}

		public override object Get(Args args)
		{
			LocalListVariables localListVariables = m_Variable.Get<LocalListVariables>(args);
			if (!(localListVariables != null))
			{
				return null;
			}
			return localListVariables.Get(m_Select, args);
		}

		public override string ToString()
		{
			return $"{m_Variable}[{m_Select}]";
		}
	}
}
