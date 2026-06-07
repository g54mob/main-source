using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class ColorTheme
	{
		public enum Type
		{
			Background = 0,
			TextNormal = 1,
			TextLight = 2,
			White = 3,
			Black = 4,
			Light = 5,
			Gray = 6,
			Dark = 7,
			Red = 8,
			Green = 9,
			Blue = 10,
			Yellow = 11,
			Purple = 12,
			Pink = 13,
			Teal = 14
		}

		private readonly struct Colors
		{
			[field: NonSerialized]
			public Color DarkColor { get; }

			[field: NonSerialized]
			public Color LightColor { get; }

			public Color Color => LightColor;

			public Colors(string hexLight, string hexDark)
			{
				LightColor = ColorUtils.Parse(hexLight);
				DarkColor = ColorUtils.Parse(hexDark);
			}
		}

		private const int COLOR_COUNT = 7;

		private const int COLOR_OFFSET = 8;

		private static readonly Dictionary<Type, Colors> Data = new Dictionary<Type, Colors>
		{
			{
				Type.Background,
				new Colors("#c2c2c2", "#383838")
			},
			{
				Type.TextNormal,
				new Colors("#090909", "#ffffff")
			},
			{
				Type.TextLight,
				new Colors("#565656", "#AAAAAA")
			},
			{
				Type.White,
				new Colors("#ffffff", "#ffffff")
			},
			{
				Type.Black,
				new Colors("#000000", "#000000")
			},
			{
				Type.Light,
				new Colors("#f0f0f0", "#f6f6f6")
			},
			{
				Type.Gray,
				new Colors("#535353", "#c2c2c2")
			},
			{
				Type.Dark,
				new Colors("#313131", "#1e1e1e")
			},
			{
				Type.Red,
				new Colors("#9f251a", "#e9754c")
			},
			{
				Type.Green,
				new Colors("#43793b", "#c2f771")
			},
			{
				Type.Blue,
				new Colors("#2c6cc3", "#87d8f6")
			},
			{
				Type.Yellow,
				new Colors("#c09431", "#f1c437")
			},
			{
				Type.Purple,
				new Colors("#6040af", "#a692e9")
			},
			{
				Type.Pink,
				new Colors("#bd377c", "#d790d4")
			},
			{
				Type.Teal,
				new Colors("#347480", "#a2f7e4")
			}
		};

		public static Color Get(Type type)
		{
			return Data[type].Color;
		}

		public static Color GetDarker(Type type)
		{
			Color.RGBToHSV(Data[type].Color, out var H, out var S, out var V);
			return Color.HSVToRGB(H, S, V - 0.15f);
		}

		public static Color GetLighter(Type type)
		{
			Color.RGBToHSV(Data[type].Color, out var H, out var S, out var V);
			return Color.HSVToRGB(H, S, V + 0.15f);
		}

		public static Color ColorFromHash(int hash)
		{
			return Get((Type)(Math.Abs(hash) % 7 + 8));
		}

		public static Color GetDarkTheme(Type type)
		{
			return Data[type].DarkColor;
		}

		public static Color GetLightTheme(Type type)
		{
			return Data[type].LightColor;
		}
	}
}
