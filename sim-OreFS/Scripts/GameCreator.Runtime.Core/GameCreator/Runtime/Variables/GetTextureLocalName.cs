using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the Texture value of a Local Name Variable")]
	public class GetTextureLocalName : PropertyTypeGetTexture
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueTexture.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Texture Get(Args args)
		{
			return m_Variable.Get<Texture>(args);
		}
	}
}
