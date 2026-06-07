using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class FieldGetLocalList : TFieldGetVariable
	{
		[SerializeField]
		protected PropertyGetGameObject m_Variable = new PropertyGetGameObject();

		[SerializeReference]
		protected TListGetPick m_Select = new GetPickFirst();

		public FieldGetLocalList(IdString typeID)
		{
			m_TypeID = typeID;
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
			if (m_Variable == null)
			{
				return "(none)";
			}
			return $"{m_Variable}[{m_Select}]";
		}
	}
}
