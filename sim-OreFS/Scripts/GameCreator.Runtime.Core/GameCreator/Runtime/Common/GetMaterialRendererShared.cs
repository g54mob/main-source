using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Renderer Shared Material")]
	[Category("Renderers/Renderer Shared Material")]
	[Image(typeof(IconSkinMesh), ColorTheme.Type.Blue)]
	[Description("A reference to the main Shared Material instance of a Renderer component")]
	[Keywords(new string[] { "Material", "Shader" })]
	public class GetMaterialRendererShared : PropertyTypeGetMaterial
	{
		[SerializeField]
		private PropertyGetGameObject m_Renderer = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetInteger m_Index = new PropertyGetInteger(new GetDecimalConstantZero());

		public override string String => $"{m_Renderer} Shared Material";

		public override Material Get(Args args)
		{
			Renderer renderer = m_Renderer.Get<Renderer>(args);
			int num = (int)m_Index.Get(args);
			if (!(renderer != null))
			{
				return null;
			}
			return renderer.sharedMaterials[num];
		}

		public static PropertyGetMaterial Create()
		{
			return new PropertyGetMaterial(new GetMaterialRendererShared());
		}
	}
}
