using UnityEngine;

namespace ParadoxNotion
{
	public static class LayerUtils
	{
		public static LayerMask CreateFromNames(params string[] layerNames)
		{
			return default(LayerMask);
		}

		public static LayerMask CreateFromNumbers(params int[] layerNumbers)
		{
			return default(LayerMask);
		}

		public static LayerMask LayerNamesToMask(params string[] layerNames)
		{
			return default(LayerMask);
		}

		public static LayerMask LayerNumbersToMask(params int[] layerNumbers)
		{
			return default(LayerMask);
		}

		public static LayerMask Inverse(this LayerMask mask)
		{
			return default(LayerMask);
		}

		public static LayerMask AddToMask(this LayerMask mask, params string[] layerNames)
		{
			return default(LayerMask);
		}

		public static LayerMask RemoveFromMask(this LayerMask mask, params string[] layerNames)
		{
			return default(LayerMask);
		}

		public static bool ContainsAnyLayer(this LayerMask mask, params string[] layerNames)
		{
			return false;
		}

		public static bool ContainsAllLayers(this LayerMask mask, params string[] layerNames)
		{
			return false;
		}

		public static string[] MaskToNames(this LayerMask mask)
		{
			return null;
		}

		public static string MaskToString(this LayerMask mask)
		{
			return null;
		}

		public static string MaskToString(this LayerMask mask, string delimiter)
		{
			return null;
		}
	}
}
