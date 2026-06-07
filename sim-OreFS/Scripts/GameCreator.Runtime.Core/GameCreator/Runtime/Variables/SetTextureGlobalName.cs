using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the Texture value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetTextureGlobalName : PropertyTypeSetTexture
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueTexture.TYPE_ID);

		public static PropertySetTexture Create => new PropertySetTexture(new SetTextureGlobalName());

		public override string String => m_Variable.ToString();

		public override void Set(Texture value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override Texture Get(Args args)
		{
			return m_Variable.Get(args) as Texture;
		}
	}
}
