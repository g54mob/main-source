using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Renderer Shared Material")]
	[Category("Renderers/Renderer Shared Material")]
	[Image(typeof(IconSkinMesh), ColorTheme.Type.Blue)]
	[Description("The Material shared instance associated with a Renderer component")]
	public class SetMaterialRendererShared : PropertyTypeSetMaterial
	{
		[SerializeField]
		private PropertyGetGameObject m_Renderer = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetInteger m_Index = new PropertyGetInteger(new GetDecimalConstantZero());

		public override string String => m_Renderer.ToString();

		public override void Set(Material value, Args args)
		{
			Renderer renderer = m_Renderer.Get<Renderer>(args);
			if (!(renderer == null))
			{
				int num = (int)m_Index.Get(args);
				Material[] sharedMaterials = renderer.sharedMaterials;
				sharedMaterials[num] = value;
				renderer.sharedMaterials = sharedMaterials;
			}
		}

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
	}
}
