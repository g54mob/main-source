using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Renderer Color")]
	[Category("Materials/Renderer Color")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Yellow)]
	[Description("Returns the Renderer's material color")]
	public class GetColorMaterialsRenderer : PropertyTypeGetColor
	{
		[SerializeField]
		protected PropertyGetGameObject m_Renderer = GetGameObjectInstance.Create();

		public override string String => $"{m_Renderer} Material Color";

		public override Color Get(Args args)
		{
			GameObject gameObject = m_Renderer.Get(args);
			if (gameObject == null)
			{
				return default(Color);
			}
			Renderer renderer = gameObject.Get<Renderer>();
			if (renderer == null)
			{
				return default(Color);
			}
			Material material = renderer.material;
			if (!(material != null))
			{
				return default(Color);
			}
			return material.color;
		}

		public GetColorMaterialsRenderer()
		{
		}

		public GetColorMaterialsRenderer(GameObject gameObject)
			: this()
		{
			m_Renderer = GetGameObjectInstance.Create(gameObject);
		}

		public static PropertyGetColor Create(GameObject gameObject)
		{
			return new PropertyGetColor(new GetColorMaterialsRenderer(gameObject));
		}
	}
}
