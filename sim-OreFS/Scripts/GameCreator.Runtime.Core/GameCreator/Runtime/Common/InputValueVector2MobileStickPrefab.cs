using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Custom Stick")]
	[Category("Mobile/Custom Stick")]
	[Description("")]
	[Image(typeof(IconTouchstick), ColorTheme.Type.Blue)]
	[Keywords(new string[] { "Virtual", "Joystick", "Touchstick", "Direction" })]
	public class InputValueVector2MobileStickPrefab : TInputValueVector2MobileStick
	{
		[SerializeField]
		private TouchStickSkin m_Touchstick;

		protected override ITouchStick CreateTouchStick()
		{
			if (!m_Touchstick.HasValue)
			{
				return null;
			}
			return UnityEngine.Object.Instantiate(m_Touchstick.Value).GetComponentInChildren<ITouchStick>();
		}
	}
}
