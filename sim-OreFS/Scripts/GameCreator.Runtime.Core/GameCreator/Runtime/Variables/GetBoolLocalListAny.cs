using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Any Local List Variable")]
	[Category("Variables/Any Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	[Description("Returns true if the Local List Variable has at least one element")]
	public class GetBoolLocalListAny : PropertyTypeGetBool
	{
		[SerializeField]
		private PropertyGetGameObject m_List = new PropertyGetGameObject();

		public override string String => $"Any in {m_List}";

		public override bool Get(Args args)
		{
			LocalListVariables localListVariables = m_List.Get<LocalListVariables>(args);
			return ((localListVariables != null && localListVariables.Count != 0) ? 1 : 0) > (false ? 1 : 0);
		}

		public override bool Get(GameObject gameObject)
		{
			LocalListVariables localListVariables = m_List.Get<LocalListVariables>(gameObject);
			return ((localListVariables != null && localListVariables.Count != 0) ? 1 : 0) > (false ? 1 : 0);
		}
	}
}
