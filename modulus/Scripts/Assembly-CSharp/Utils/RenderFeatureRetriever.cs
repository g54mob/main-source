using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Utils
{
	[CreateAssetMenu(menuName = "Utils/RenderFeatureRetriever", fileName = "RenderFeatureRetriever", order = 0)]
	public class RenderFeatureRetriever : ScriptableObject
	{
		[SerializeField]
		private UniversalRendererData _universalRendererDataLow;

		[SerializeField]
		private UniversalRendererData _universalRendererDataMedium;

		[SerializeField]
		private UniversalRendererData _universalRendererDataHigh;

		public List<ScriptableRendererFeature> GetRenderFeaturesFromName(string name)
		{
			List<ScriptableRendererFeature> list = new List<ScriptableRendererFeature>();
			foreach (ScriptableRendererFeature rendererFeature in _universalRendererDataHigh.rendererFeatures)
			{
				if (rendererFeature.name == name)
				{
					list.Add(rendererFeature);
					break;
				}
			}
			foreach (ScriptableRendererFeature rendererFeature2 in _universalRendererDataMedium.rendererFeatures)
			{
				if ((object)rendererFeature2 != null)
				{
					ScriptableRendererFeature scriptableRendererFeature = rendererFeature2;
					if (scriptableRendererFeature.name == name)
					{
						list.Add(scriptableRendererFeature);
						break;
					}
				}
			}
			foreach (ScriptableRendererFeature rendererFeature3 in _universalRendererDataLow.rendererFeatures)
			{
				if ((object)rendererFeature3 != null)
				{
					ScriptableRendererFeature scriptableRendererFeature2 = rendererFeature3;
					if (scriptableRendererFeature2.name == name)
					{
						list.Add(scriptableRendererFeature2);
						break;
					}
				}
			}
			return list;
		}
	}
}
