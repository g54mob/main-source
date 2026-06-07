using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScheduleOne.Graffiti
{
	public class Drawing
	{
		private class DrawData
		{
			public List<DrawPixels> DrawPixels;

			public void Add(DrawPixels drawPixels)
			{
			}

			public bool IsEmpty()
			{
				return false;
			}

			public void Clear()
			{
			}
		}

		private class DrawPixels
		{
			public int BottomLeftX;

			public int BottomLeftY;

			public int BlockWidth;

			public Color[] Colors;

			public DrawPixels(int bottomLeftX, int bottomLeftY, int blockWidth, Color[] colors)
			{
			}
		}

		private List<SprayStroke> strokes;

		private Texture2DArray _historyTextureArray;

		private int[] PaintedPixelHistory;

		private int[] _strokeHistory;

		private const int MAX_UNDO_STATES = 10;

		public Action onTextureChanged;

		private int _width { get; set; }

		private int _height { get; set; }

		public int TextureWidth => 0;

		public int TextureHeight => 0;

		public Texture2D OutputTexture { get; private set; }

		public int StrokeCount => 0;

		public int PaintedPixelCount { get; set; }

		public int HistoryIndex { get; private set; }

		public int HistoryCount { get; private set; }

		public List<SprayStroke> GetStrokes()
		{
			return null;
		}

		public Drawing(int width, int height, bool initPixels)
		{
		}

		public Drawing GetCopy()
		{
			return null;
		}

		public void DrawPaintedPixel(PixelData data, bool applyTexture)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Color LerpUnclampedFast(Color a, Color b, float t)
		{
			return default(Color);
		}

		private void ApplyTexture()
		{
		}

		private bool IsCoordinateInBounds(int x, int y)
		{
			return false;
		}

		public void AddStroke(SprayStroke stroke)
		{
		}

		public void AddStrokes(List<SprayStroke> newStrokes)
		{
		}

		public bool CanUndo()
		{
			return false;
		}

		public void Undo()
		{
		}

		public void CacheDrawing()
		{
		}

		public void RestoreFromCache()
		{
		}

		public void AddTextureToHistory(bool saveToCache = false)
		{
		}
	}
}
