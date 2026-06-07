using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the Texture value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetTextureLocalName : PropertyTypeSetTexture
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueTexture.TYPE_ID);

		public static PropertySetTexture Create => new PropertySetTexture(new SetTextureLocalName());

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
