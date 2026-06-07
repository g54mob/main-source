using DV.LCD;
using UnityEngine;

namespace DV.Items.Brick
{
	public class BrickScreen : MonoBehaviour
	{
		public readonly struct BrickBounds
		{
			public readonly int minX;

			public readonly int minY;

			public readonly int maxX;

			public readonly int maxY;

			public (int, int) VerticalLimits => (minY, maxY);

			public (int, int) HorizontalLimits => (minX, maxX);

			public BrickBounds(int minX, int minY, int maxX, int maxY)
			{
				this.minX = minX;
				this.minY = minY;
				this.maxX = maxX;
				this.maxY = maxY;
			}

			public BrickBounds(Vector2Int min, Vector2Int max)
				: this(min.x, min.y, max.x, max.y)
			{
			}

			public void Deconstruct(out int minX, out int minY, out int maxX, out int maxY)
			{
				minX = this.minX;
				minY = this.minY;
				maxX = this.maxX;
				maxY = this.maxY;
			}
		}

		[SerializeField]
		private PixelDisplay display;

		private Texture2D screenTexture;

		private readonly Color32 PIXEL_ON = Color.white;

		private readonly Color32 PIXEL_OFF = Color.clear;

		public readonly Vector2Int resolution = new Vector2Int(128, 128);

		private Vector2Int paddingMin = new Vector2Int(10, 20);

		private Vector2Int paddingMax = new Vector2Int(10, 10);

		private BrickBounds paddedBounds;

		private BrickBounds fullScreenBounds;

		private bool initialized;

		private void Awake()
		{
			if (display == null)
			{
				Debug.LogError("BrickScreen: Display is not assigned!. Brick got bricked!");
				return;
			}
			display.SetResolution(resolution.x, resolution.y);
			display.GetComponent<MeshRenderer>().material.SetVector("_LCDResolution", new Vector4(resolution.x, resolution.y, 0f, 0f));
			paddedBounds = new BrickBounds(paddingMin, resolution - paddingMax - Vector2Int.one);
			fullScreenBounds = new BrickBounds(Vector2Int.zero, resolution - Vector2Int.one);
			initialized = true;
			ClearScreen();
		}

		public BrickBounds GetScreenBounds(bool includePadding)
		{
			if (!includePadding)
			{
				return fullScreenBounds;
			}
			return paddedBounds;
		}

		public void ClearScreen()
		{
			if (initialized)
			{
				display.Clear(PIXEL_OFF);
			}
		}

		public void DrawSprite(BrickSprite brickSprite, Vector2Int spritePosition, bool includePadding = true, bool invertColor = false)
		{
			if (initialized)
			{
				if (brickSprite == null)
				{
					Debug.LogError("BrickScreen: Invalid brick sprite reference!. Brick got bricked!");
					return;
				}
				GetScreenBounds(includePadding).Deconstruct(out var minX, out var minY, out var maxX, out var maxY);
				int a = minX;
				int a2 = minY;
				int num = maxX;
				int num2 = maxY;
				a = Mathf.Max(a, spritePosition.x);
				a2 = Mathf.Max(a2, spritePosition.y);
				num = Mathf.Min(num + 1, spritePosition.x + brickSprite.size.x);
				num2 = Mathf.Min(num2 + 1, spritePosition.y + brickSprite.size.y);
				PixelDisplay.ColorOperator color = (invertColor ? new PixelDisplay.ColorOperator(ColorOperatorInverted) : new PixelDisplay.ColorOperator(ColorOperatorStandard));
				display.Fill(a, a2, num - a, num2 - a2, color);
			}
			void ColorOperatorInverted(int x, int y, ref Color32 pixel)
			{
				pixel.a = (byte)(255 - brickSprite.pixels[x - spritePosition.x + (y - spritePosition.y) * brickSprite.size.x]);
			}
			void ColorOperatorStandard(int x, int y, ref Color32 pixel)
			{
				pixel.a = brickSprite.pixels[x - spritePosition.x + (y - spritePosition.y) * brickSprite.size.x];
			}
		}

		public void DrawLine(Vector2Int a, Vector2Int b, bool includePadding = true)
		{
			int minX;
			int minY;
			int maxX;
			int maxY;
			if (initialized)
			{
				(minX, minY, maxX, maxY) = (BrickBounds)(ref GetScreenBounds(includePadding));
				display.DrawLine(a.x, a.y, b.x, b.y, ColorOperator);
			}
			void ColorOperator(int x, int y, ref Color32 pixel)
			{
				if (x.IsInRange(minX, maxX) && y.IsInRange(minY, maxY))
				{
					pixel = PIXEL_ON;
				}
			}
		}
	}
}
