using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Graphic")]
	[Category("UI/Graphic")]
	[Description("Gets the Graphic's component tint color property")]
	[Image(typeof(IconSprite), ColorTheme.Type.TextLight)]
	[HideLabelsInEditor(true)]
	public class GetColorUIGraphic : PropertyTypeGetColor
	{
		[SerializeField]
		private PropertyGetGameObject m_Graphic = GetGameObjectInstance.Create();

		public static PropertyGetColor Create => new PropertyGetColor(new GetColorUIGraphic());

		public override string String => m_Graphic.ToString();

		public override Color Get(Args args)
		{
			GameObject gameObject = m_Graphic.Get(args);
			if (gameObject == null)
			{
				return default(Color);
			}
			Graphic graphic = gameObject.Get<Graphic>();
			if (!(graphic != null))
			{
				return default(Color);
			}
			return graphic.color;
		}
	}
}
