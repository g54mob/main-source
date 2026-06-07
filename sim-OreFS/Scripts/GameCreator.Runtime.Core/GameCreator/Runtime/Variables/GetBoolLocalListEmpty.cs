using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Empty Local List Variable")]
	[Category("Variables/Empty Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns true if the Local List Variable is empty")]
	public class GetBoolLocalListEmpty : PropertyTypeGetBool
	{
		[SerializeField]
		private PropertyGetGameObject m_List = new PropertyGetGameObject();

		public override string String => $"{m_List} is Empty";

		public override bool Get(Args args)
		{
			LocalListVariables localListVariables = m_List.Get<LocalListVariables>(args);
			return !(localListVariables != null) || localListVariables.Count == 0;
		}

		public override bool Get(GameObject gameObject)
		{
			LocalListVariables localListVariables = m_List.Get<LocalListVariables>(gameObject);
			return !(localListVariables != null) || localListVariables.Count == 0;
		}
	}
}
