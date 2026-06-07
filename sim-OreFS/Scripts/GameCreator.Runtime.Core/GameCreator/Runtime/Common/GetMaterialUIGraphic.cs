using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Graphic Material")]
	[Category("UI/Graphic Material")]
	[Image(typeof(IconUIImage), ColorTheme.Type.TextLight)]
	[Description("A reference to the main Material instance of a Graphic (Image or Text) component")]
	[Keywords(new string[] { "Material", "Shader", "Image", "Text" })]
	public class GetMaterialUIGraphic : PropertyTypeGetMaterial
	{
		[SerializeField]
		private PropertyGetGameObject m_Graphic = GetGameObjectInstance.Create();

		public override string String => $"{m_Graphic} Material";

		public override Material Get(Args args)
		{
			Graphic graphic = m_Graphic.Get<Graphic>(args);
			if (!(graphic != null))
			{
				return null;
			}
			return graphic.material;
		}

		public static PropertyGetMaterial Create()
		{
			return new PropertyGetMaterial(new GetMaterialRendererShared());
		}
	}
}
