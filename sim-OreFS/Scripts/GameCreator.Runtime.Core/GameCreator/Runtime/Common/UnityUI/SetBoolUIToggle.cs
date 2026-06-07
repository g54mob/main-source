using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Toggle")]
	[Category("UI/Toggle")]
	[Description("Sets the Toggle component on or off")]
	[Image(typeof(IconUIToggle), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class SetBoolUIToggle : PropertyTypeSetBool
	{
		[SerializeField]
		private PropertyGetGameObject m_Toggle = GetGameObjectInstance.Create();

		public static PropertySetBool Create => new PropertySetBool(new SetBoolUIToggle());

		public override string String => m_Toggle.ToString();

		public override void Set(bool value, Args args)
		{
			GameObject gameObject = m_Toggle.Get(args);
			if (!(gameObject == null))
			{
				Toggle toggle = gameObject.Get<Toggle>();
				if (!(toggle == null))
				{
					toggle.isOn = value;
				}
			}
		}

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
