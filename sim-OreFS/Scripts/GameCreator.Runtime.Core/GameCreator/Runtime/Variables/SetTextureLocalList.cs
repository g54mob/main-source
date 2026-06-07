using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the Texture value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetTextureLocalList : PropertyTypeSetTexture
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueTexture.TYPE_ID);

		public static PropertySetTexture Create => new PropertySetTexture(new SetTextureLocalList());

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
