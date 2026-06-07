using System;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	public static class PSXRenderQueue
	{
		public enum Priority
		{
			BackgroundOpaque = 1000,
			BackgroundOpaqueAlphaTest = 1450,
			BackgroundOpaqueLast = 1500,
			BackgroundTransparentFirst = 1501,
			BackgroundTransparent = 1601,
			BackgroundTransparentLast = 1701,
			MainOpaque = 2000,
			MainOpaqueAlphaTest = 2450,
			MainOpaqueLast = 2500,
			MainTransparentFirst = 2900,
			MainTransparent = 3000,
			MainTransparentLast = 3100,
			UIOverlayOpaque = 4000,
			UIOverlayOpaqueAlphaTest = 4450,
			UIOverlayOpaqueLast = 4500,
			UIOverlayTransparentFirst = 4501,
			UIOverlayTransparent = 4601,
			UIOverlayTransparentLast = 4701
		}

		public enum RenderQueueType
		{
			BackgroundOpaque = 0,
			BackgroundTransparent = 1,
			MainOpaque = 2,
			MainTransparent = 3,
			UIOverlayOpaque = 4,
			UIOverlayTransparent = 5,
			Unknown = 6
		}

		private const int k_TransparentPriorityQueueRange = 100;

		public static readonly RenderQueueRange k_RenderQueue_BackgroundOpaqueNoAlphaTest = new RenderQueueRange
		{
			lowerBound = 1000,
			upperBound = 1449
		};

		public static readonly RenderQueueRange k_RenderQueue_BackgroundAlphaTest = new RenderQueueRange
		{
			lowerBound = 1450,
			upperBound = 1500
		};

		public static readonly RenderQueueRange k_RenderQueue_BackgroundAllOpaque = new RenderQueueRange
		{
			lowerBound = 1000,
			upperBound = 1500
		};

		public static readonly RenderQueueRange k_RenderQueue_BackgroundTransparent = new RenderQueueRange
		{
			lowerBound = 1501,
			upperBound = 1701
		};

		public static readonly RenderQueueRange k_RenderQueue_MainOpaqueNoAlphaTest = new RenderQueueRange
		{
			lowerBound = 2000,
			upperBound = 2449
		};

		public static readonly RenderQueueRange k_RenderQueue_MainAlphaTest = new RenderQueueRange
		{
			lowerBound = 2450,
			upperBound = 2500
		};

		public static readonly RenderQueueRange k_RenderQueue_MainAllOpaque = new RenderQueueRange
		{
			lowerBound = 2000,
			upperBound = 2500
		};

		public static readonly RenderQueueRange k_RenderQueue_MainTransparent = new RenderQueueRange
		{
			lowerBound = 2900,
			upperBound = 3100
		};

		public static readonly RenderQueueRange k_RenderQueue_UIOverlayOpaqueNoAlphaTest = new RenderQueueRange
		{
			lowerBound = 4000,
			upperBound = 4449
		};

		public static readonly RenderQueueRange k_RenderQueue_UIOverlayAlphaTest = new RenderQueueRange
		{
			lowerBound = 4450,
			upperBound = 4500
		};

		public static readonly RenderQueueRange k_RenderQueue_UIOverlayAllOpaque = new RenderQueueRange
		{
			lowerBound = 4000,
			upperBound = 4500
		};

		public static readonly RenderQueueRange k_RenderQueue_UIOverlayTransparent = new RenderQueueRange
		{
			lowerBound = 4501,
			upperBound = 4701
		};

		public static readonly RenderQueueRange k_RenderQueue_All = new RenderQueueRange
		{
			lowerBound = 0,
			upperBound = 5000
		};

		public static bool Contains(this RenderQueueRange range, int value)
		{
			if (range.lowerBound <= value)
			{
				return value <= range.upperBound;
			}
			return false;
		}

		public static int Clamps(this RenderQueueRange range, int value)
		{
			return Math.Max(range.lowerBound, Math.Min(value, range.upperBound));
		}

		public static RenderQueueType GetTypeByRenderQueueValue(int renderQueue)
		{
			if (k_RenderQueue_BackgroundAllOpaque.Contains(renderQueue))
			{
				return RenderQueueType.BackgroundOpaque;
			}
			if (k_RenderQueue_BackgroundTransparent.Contains(renderQueue))
			{
				return RenderQueueType.BackgroundTransparent;
			}
			if (k_RenderQueue_MainAllOpaque.Contains(renderQueue))
			{
				return RenderQueueType.MainOpaque;
			}
			if (k_RenderQueue_MainTransparent.Contains(renderQueue))
			{
				return RenderQueueType.MainTransparent;
			}
			if (k_RenderQueue_UIOverlayAllOpaque.Contains(renderQueue))
			{
				return RenderQueueType.UIOverlayOpaque;
			}
			if (k_RenderQueue_UIOverlayTransparent.Contains(renderQueue))
			{
				return RenderQueueType.UIOverlayTransparent;
			}
			return RenderQueueType.Unknown;
		}

		public static int ChangeType(RenderQueueType targetType, int offset = 0, bool alphaClip = false)
		{
			if (offset < -100 || offset > 100)
			{
				throw new ArgumentException("Out of bounds offset, was " + offset);
			}
			switch (targetType)
			{
			case RenderQueueType.BackgroundOpaque:
				if (!alphaClip)
				{
					return 1000;
				}
				return 1450;
			case RenderQueueType.BackgroundTransparent:
				return 1601 + offset;
			case RenderQueueType.MainOpaque:
				if (!alphaClip)
				{
					return 2000;
				}
				return 2450;
			case RenderQueueType.MainTransparent:
				return 3000 + offset;
			case RenderQueueType.UIOverlayOpaque:
				if (!alphaClip)
				{
					return 4000;
				}
				return 4450;
			case RenderQueueType.UIOverlayTransparent:
				return 4601 + offset;
			default:
				throw new ArgumentException("Unknown RenderQueueType, was " + targetType);
			}
		}
	}
}
