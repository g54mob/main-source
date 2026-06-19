using UnityEngine;

namespace TH20
{
	public class RoomItemRendererInstance
	{
		public Renderer Renderer;

		public MaterialPropertyBlock OriginalPropertyBlock;

		public MaterialPropertyBlock ValuePropertyBlock;

		public MaterialPropertyBlock EditPropertyBlock;

		public Material[] OriginalMaterials;

		public Material[] ValidMaterials;

		public Material[] SellMaterials;

		public bool IgnoreHighlight;
	}
}
