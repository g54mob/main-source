using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Count of Local List Variable")]
	[Category("Variables/Count of Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns the amount of elements of a Local List Variable")]
	public class GetDecimalLocalListLength : PropertyTypeGetDecimal
	{
		[SerializeField]
		private PropertyGetGameObject m_List = new PropertyGetGameObject();

		public override string String => $"{m_List} Length";

		public override double Get(Args args)
		{
			LocalListVariables localListVariables = m_List.Get<LocalListVariables>(args);
			return (localListVariables != null) ? localListVariables.Count : 0;
		}

		public override double Get(GameObject gameObject)
		{
			LocalListVariables localListVariables = m_List.Get<LocalListVariables>(gameObject);
			return (localListVariables != null) ? localListVariables.Count : 0;
		}
	}
}
