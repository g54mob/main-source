using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Toggle")]
	[Category("UI/Toggle")]
	[Description("Gets the Toggle component on or off state")]
	[Image(typeof(IconUIToggle), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class GetBoolUIToggle : PropertyTypeGetBool
	{
		[SerializeField]
		private PropertyGetGameObject m_Toggle = GetGameObjectInstance.Create();

		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolUIToggle());

		public override string String => m_Toggle.ToString();

		public override bool Get(Args args)
		{
			GameObject gameObject = m_Toggle.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			Toggle toggle = gameObject.Get<Toggle>();
			if (toggle != null)
			{
				return toggle.isOn;
			}
			return false;
		}
	}
}
