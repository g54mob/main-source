using System;
using System.Runtime.CompilerServices;

namespace VisualDesignCafe.Nature
{
	public static class QualitySettings
	{
		public class InteractionQuality
		{
			public const int DefaultResolution = 1024;

			public bool Enabled { get; set; }

			public int Resolution { get; set; }

			public float Accuracy { get; set; }

			public float TrailPopupSpeed { get; set; }

			public event Action<InteractionQuality> Changed
			{
				[CompilerGenerated]
				add
				{
				}
				[CompilerGenerated]
				remove
				{
				}
			}

			public void Apply()
			{
			}
		}

		public enum MaterialQuality
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		public class GraphicsQuality
		{
			public MaterialQuality MaterialQuality { get; set; }

			public event Action<GraphicsQuality> Changed
			{
				[CompilerGenerated]
				add
				{
				}
				[CompilerGenerated]
				remove
				{
				}
			}

			public void Apply()
			{
			}
		}

		public class OverlayQuality
		{
			public const int DefaultResolution = 2048;

			public bool Enabled { get; set; }

			public int Resolution { get; set; }

			public float Accuracy { get; set; }

			public event Action<OverlayQuality> Changed
			{
				[CompilerGenerated]
				add
				{
				}
				[CompilerGenerated]
				remove
				{
				}
			}

			public void Apply()
			{
			}
		}

		public static readonly InteractionQuality Interaction;

		public static readonly GraphicsQuality Graphics;

		public static readonly OverlayQuality Overlay;

		public static void Apply()
		{
		}
	}
}
