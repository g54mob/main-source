using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Renderer Material")]
	[Category("Renderers/Renderer Material")]
	[Image(typeof(IconSkinMesh), ColorTheme.Type.Yellow)]
	[Description("The Material instance associated with a Renderer component")]
	public class SetMaterialRendererInstance : PropertyTypeSetMaterial
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
				Material[] materials = renderer.materials;
				materials[num] = value;
				renderer.materials = materials;
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
			return renderer.materials[num];
		}
	}
}
