using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Graphic")]
	[Category("UI/Graphic")]
	[Description("Sets the Graphic's Material value")]
	[Image(typeof(IconUIImage), ColorTheme.Type.TextLight)]
	public class SetMaterialUIGraphic : PropertyTypeSetMaterial
	{
		[SerializeField]
		private PropertyGetGameObject m_Graphic = GetGameObjectInstance.Create();

		public static PropertySetMaterial Create => new PropertySetMaterial(new SetMaterialUIGraphic());

		public override string String => m_Graphic.ToString();

		public override void Set(Material value, Args args)
		{
			Graphic graphic = m_Graphic.Get<Graphic>(args);
			if (!(graphic == null))
			{
				graphic.material = value;
			}
		}

		public override Material Get(Args args)
		{
			Graphic graphic = m_Graphic.Get<Graphic>(args);
			if (!(graphic != null))
			{
				return null;
			}
			return graphic.material;
		}
	}
}
