using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Renderer Material")]
	[Category("Renderers/Renderer Material")]
	[Image(typeof(IconSkinMesh), ColorTheme.Type.Yellow)]
	[Description("A reference to the main Material instance of a Renderer component")]
	[Keywords(new string[] { "Material", "Shader" })]
	public class GetMaterialRendererInstance : PropertyTypeGetMaterial
	{
		[SerializeField]
		private PropertyGetGameObject m_Renderer = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetInteger m_Index = new PropertyGetInteger(new GetDecimalConstantZero());

		public override string String => $"{m_Renderer} Material";

		public override Material Get(Args args)
		{
			Renderer renderer = m_Renderer.Get<Renderer>(args);
			int num = (int)m_Index.Get(args);
			if (!(renderer != null))
			{
				return null;
			}
			return renderer.materials[num];
		}

		public static PropertyGetMaterial Create()
		{
			return new PropertyGetMaterial(new GetMaterialRendererInstance());
		}
	}
}
