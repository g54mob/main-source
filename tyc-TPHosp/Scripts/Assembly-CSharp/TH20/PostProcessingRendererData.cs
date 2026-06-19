using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Post Processing Renderer Data", order = 1033)]
	public class PostProcessingRendererData : ScriptableObjectWithID
	{
		[HideInInspector]
		public FogOfWarLevelTextureDefinition FogOfWarDefinition;

		public bool EnableSoftCloudShadows;

		public Texture2D SoftCloudTexture;
	}
}
