using DV.Booklets.Rendered;
using DV.RenderTextureSystem;
using DV.RenderTextureSystem.BookletRender;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator_StaticRenderBooklet
	{
		public static GameObject Create(string prefabName, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return (GameObject)Object.Instantiate(Resources.Load(prefabName, typeof(GameObject)), position, rotation, parent);
		}

		public static RenderedTexturesBase Render(GameObject existingBooklet, string renderPrefabName)
		{
			StaticTextureRenderBase component = ((GameObject)Object.Instantiate(Resources.Load(renderPrefabName, typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<StaticTextureRenderBase>();
			RenderedTexturesBase component2 = existingBooklet.GetComponent<RenderedTexturesBase>();
			component2.RegisterTexturesGeneratedEvent(component);
			component.GenerateStaticPagesTextures();
			return component2;
		}
	}
}
