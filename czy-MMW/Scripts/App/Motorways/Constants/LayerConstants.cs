using UnityEngine;

namespace Motorways.Constants
{
	public static class LayerConstants
	{
		public static readonly int DefaultLayerId = LayerMask.NameToLayer("Default");

		public static readonly int OverlayLayerId = LayerMask.NameToLayer("Overlay");

		public static readonly int UILayerId = LayerMask.NameToLayer("UI");

		public static readonly int ShadowMask = LayerMask.GetMask("Shadow");

		public static readonly int MotorwayMask = LayerMask.GetMask("Motorway");

		private static string HeadlightLayerName = "Headlight";

		public static readonly int HeadlightMask = LayerMask.GetMask(HeadlightLayerName);

		public static readonly int HeadlightLayerId = LayerMask.GetMask(HeadlightLayerName);

		private static string HeadlightOcclusionLayerName = "HeadlightOcclusion";

		public static readonly int HeadlightOcclusionLayerMask = LayerMask.GetMask(HeadlightOcclusionLayerName);

		public static readonly int HeadlightOcclusionLayerId = LayerMask.NameToLayer(HeadlightOcclusionLayerName);

		private static string HeadlightOcclusionMountainLayerName = "HeadlightOcclusionMountain";

		public static readonly int HeadlightOcclusionMountainLayerNameLayerMask = LayerMask.GetMask(HeadlightOcclusionMountainLayerName);
	}
}
