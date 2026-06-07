using UnityEngine;

namespace DV.Booklets.Rendered
{
	[DisallowMultipleComponent]
	public class RuntimeRenderedStaticTextureBooklet : RenderedTexturesBooklet
	{
		public bool worldSpecific;

		public string renderPrefabName;

		public LevelInfo.WorldSpecificPrefabs worldSpecificPrefab;

		private void Awake()
		{
			if (worldSpecific)
			{
				GameObject gameObject = LevelInfo.GetWorldSpecificPrefab(worldSpecificPrefab);
				renderPrefabName = ((gameObject == null) ? null : gameObject.name);
			}
			if (string.IsNullOrEmpty(renderPrefabName))
			{
				Debug.LogError("RuntimeRenderedStaticTextureBooklet: Unexpected state: renderPrefabName not set. Destroying self", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				BookletCreator_StaticRenderBooklet.Render(base.gameObject, renderPrefabName);
			}
		}
	}
}
