using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Data.FactoryFloor.Islands
{
	public class IslandData
	{
		private Guid _id;

		private readonly string _name;

		private Vector2Int _size = Vector2Int.one;

		private Vector3Int _position = Vector3Int.zero;

		private readonly Texture2D _texture2D;

		private int _rotation;

		private Vector2 _worldSize;

		public Texture2D Texture2D => _texture2D;

		public Vector3Int Position => _position;

		public int Rotation => _rotation;

		public Guid Id => _id;

		public string Name => _name;

		public Vector2Int Size => _size;

		public Vector2 WorldSize => _worldSize;

		public IslandData(string name, Guid id, Vector2Int size)
		{
			_texture2D = CreateTexture(size, EnvironmentColorIDs.Default);
			_size = size;
			_name = name;
			_id = id;
		}

		public IslandData(IslandData islandData)
		{
			Texture2D texture2D = new Texture2D(islandData.Texture2D.width, islandData.Texture2D.height, TextureFormat.RGBA32, mipChain: false, linear: true)
			{
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Clamp
			};
			texture2D.SetPixels32(islandData.Texture2D.GetPixels32());
			texture2D.Apply();
			_texture2D = texture2D;
			_size = islandData.Size;
			_name = islandData.Name;
			NewId();
		}

		public void InitializeIsland(Vector3Int position, int rotation, float gridCellSize)
		{
			_position = position;
			_worldSize = (Vector2)_size * gridCellSize;
			_rotation = rotation;
		}

		private static Texture2D CreateTexture(Vector2Int size, Color32 color)
		{
			Texture2D texture2D = new Texture2D(size.x, size.y, TextureFormat.RGBA32, mipChain: false, linear: true)
			{
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Clamp
			};
			Color32[] array = new Color32[size.x * size.y];
			for (int i = 0; i < size.x; i++)
			{
				for (int j = 0; j < size.y; j++)
				{
					array[i + j * size.x] = color;
				}
			}
			texture2D.SetPixels32(array);
			texture2D.Apply();
			return texture2D;
		}

		public bool PaintTexture(Vector3Int worldPosition, Color32 color, out Color32 previousColor)
		{
			if (TryGetPixelPos(worldPosition, out var texturePosition))
			{
				previousColor = Texture2D.GetPixel(texturePosition.x, texturePosition.y);
				SetTexturePixel(new Vector2Int(texturePosition.x, texturePosition.y), color);
				return true;
			}
			previousColor = default(Color32);
			return false;
		}

		public Dictionary<Vector3Int, Color32> GetTexturePixels(List<Vector3Int> worldPositions)
		{
			List<Vector2Int> list = CollectionPool<List<Vector2Int>, Vector2Int>.Get();
			foreach (Vector3Int worldPosition in worldPositions)
			{
				if (TryGetPixelPos(worldPosition, out var texturePosition))
				{
					list.Add(texturePosition);
				}
			}
			List<Color32> list2 = CollectionPool<List<Color32>, Color32>.Get();
			GetTexturePixels(list, list2);
			Dictionary<Vector3Int, Color32> dictionary = new Dictionary<Vector3Int, Color32>();
			for (int i = 0; i < list2.Count; i++)
			{
				dictionary.Add(worldPositions[i], list2[i]);
			}
			CollectionPool<List<Color32>, Color32>.Release(list2);
			return dictionary;
		}

		public bool IsGrass(Vector3Int tileWorldPosition)
		{
			if (TryGetPixel(tileWorldPosition, out var resultPixel))
			{
				return EnvironmentColorIDs.IsGrass(resultPixel);
			}
			return false;
		}

		public bool IsTile(Vector3Int tileWorldPosition)
		{
			if (TryGetPixel(tileWorldPosition, out var resultPixel))
			{
				return EnvironmentColorIDs.IsTile(resultPixel);
			}
			return false;
		}

		public bool TryGetPixel(Vector3Int tileWorldPosition, out Color32 resultPixel)
		{
			if (TryGetPixelPos(tileWorldPosition, out var texturePosition) && !IsOutOfBounds(texturePosition))
			{
				resultPixel = Texture2D.GetPixel(texturePosition.x, texturePosition.y);
				return true;
			}
			resultPixel = EnvironmentColorIDs.Default;
			return false;
		}

		private bool TryGetPixelPos(Vector3Int tileWorldPosition, out Vector2Int texturePosition)
		{
			Vector3Int vector3Int = tileWorldPosition - _position;
			Vector3 vector = Quaternion.Euler(0f, -_rotation, 0f) * vector3Int + new Vector3(Size.x / 2, 0f, Size.y / 2);
			Vector2Int vector2Int = new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.z));
			int num = (_rotation % 360 + 360) % 360;
			if (num == 270 || num == 180)
			{
				vector2Int.y--;
			}
			if (num == 90 || num == 180)
			{
				vector2Int.x--;
			}
			texturePosition = vector2Int;
			if (vector.x >= (float)Size.x || vector.x < 0f)
			{
				return false;
			}
			if (vector.z >= (float)Size.y || vector.z < 0f)
			{
				return false;
			}
			return true;
		}

		public void PaintTexture(Dictionary<Vector3Int, Color32> positionsToPaint)
		{
			Dictionary<Vector2Int, Color32> dictionary = CollectionPool<Dictionary<Vector2Int, Color32>, KeyValuePair<Vector2Int, Color32>>.Get();
			foreach (KeyValuePair<Vector3Int, Color32> item in positionsToPaint)
			{
				if (TryGetPixelPos(item.Key, out var texturePosition))
				{
					dictionary.TryAdd(texturePosition, item.Value);
				}
			}
			SetTexturePixels(dictionary);
			Texture2D.Apply();
		}

		private void SetTexturePixel(Vector2Int pos, Color32 color)
		{
			Color32[] pixels = Texture2D.GetPixels32();
			List<int> modifiedPixelIndex = CollectionPool<List<int>, int>.Get();
			if (TryUpdateModifiedPixel(pos, color, pixels, modifiedPixelIndex))
			{
				UpdateTextureFromModified(modifiedPixelIndex, pixels);
			}
		}

		private bool TryUpdateModifiedPixel(Vector2Int pos, Color32 color, Color32[] texturePixels, List<int> modifiedPixelIndex)
		{
			if (IsOutOfBounds(pos))
			{
				return false;
			}
			int num = pos.x + pos.y * Size.x;
			Color32 currentPixel = texturePixels[num];
			if (currentPixel.Equals(color))
			{
				return false;
			}
			UpdateModifiedPixel(pos, color, currentPixel, texturePixels, num, modifiedPixelIndex);
			return true;
		}

		private void SetTexturePixels(Dictionary<Vector2Int, Color32> positionsToPaint)
		{
			Color32[] pixels = Texture2D.GetPixels32();
			List<int> modifiedPixelIndex = CollectionPool<List<int>, int>.Get();
			foreach (KeyValuePair<Vector2Int, Color32> item in positionsToPaint)
			{
				TryUpdateModifiedPixel(item.Key, item.Value, pixels, modifiedPixelIndex);
			}
			UpdateTextureFromModified(modifiedPixelIndex, pixels);
		}

		private void GetTexturePixels(List<Vector2Int> positions, List<Color32> pixels)
		{
			Color32[] pixels2 = Texture2D.GetPixels32();
			foreach (Vector2Int position in positions)
			{
				if (!IsOutOfBounds(position))
				{
					int num = position.x + position.y * Size.x;
					pixels.Add(pixels2[num]);
				}
			}
		}

		private void UpdateModifiedPixel(Vector2Int pos, Color32 newColor, Color32 currentPixel, Color32[] texturePixels, int currentIndex, List<int> modifiedPixelIndex)
		{
			bool flag = EnvironmentColorIDs.IsGrass(newColor);
			bool flag2 = EnvironmentColorIDs.IsGrass(currentPixel);
			bool num = EnvironmentColorIDs.IsRegularHeight(newColor);
			texturePixels[currentIndex] = newColor;
			if (num && !flag)
			{
				modifiedPixelIndex.Add(currentIndex);
			}
			if (!(flag || flag2))
			{
				return;
			}
			foreach (int item in GetNeighboursToUpdate(pos.x, pos.y, texturePixels))
			{
				modifiedPixelIndex.Add(item);
			}
		}

		private bool IsOutOfBounds(Vector2Int pos)
		{
			if (pos.x < Size.x && pos.y < Size.y && pos.x >= 0)
			{
				return pos.y < 0;
			}
			return true;
		}

		private void UpdateTextureFromModified(List<int> modifiedPixelIndex, Color32[] texturePixels)
		{
			foreach (int item in modifiedPixelIndex)
			{
				if (!isGrass(item, item))
				{
					bool up = isGrass(item, item + Size.x);
					bool right = isGrass(item, item + 1);
					bool down = isGrass(item, item - Size.x);
					bool left = isGrass(item, item - 1);
					bool upR = isGrass(item, item + 1 + Size.x);
					bool downR = isGrass(item, item + 1 - Size.x);
					bool downL = isGrass(item, item - 1 - Size.x);
					bool upL = isGrass(item, item - 1 + Size.x);
					texturePixels[item].g = (byte)EnvironmentColorIDs.GetRotatedTile(up, right, down, left, upR, downR, downL, upL);
				}
			}
			Texture2D.SetPixels32(texturePixels);
			Texture2D.Apply();
			bool isGrass(int previousIndex, int index)
			{
				if (index < 0 || index >= texturePixels.Length)
				{
					return false;
				}
				int num = index % Size.x;
				int num2 = previousIndex % Size.x;
				if (Mathf.Floor(num / Size.x) != Mathf.Floor(num2 / Size.x))
				{
					return false;
				}
				return EnvironmentColorIDs.IsGrass(texturePixels[index]);
			}
		}

		private IEnumerable<int> GetNeighboursToUpdate(int x, int y, Color32[] texturePixels)
		{
			bool outOfBoundXPos = false;
			bool outOfBoundYPos = false;
			bool outOfBoundXNeg = false;
			bool outOfBoundYNeg = false;
			if (x + 1 >= Size.x)
			{
				outOfBoundXPos = true;
			}
			if (x - 1 < 0)
			{
				outOfBoundXNeg = true;
			}
			if (y + 1 >= Size.y)
			{
				outOfBoundYPos = true;
			}
			if (y - 1 < 0)
			{
				outOfBoundYNeg = true;
			}
			Color32 color = EnvironmentColorIDs.Default;
			Color32 color2 = (outOfBoundYPos ? color : texturePixels[x + (y + 1) * Size.x]);
			Color32 rightNeighbour = (outOfBoundXPos ? color : texturePixels[x + 1 + y * Size.x]);
			Color32 downNeighbour = (outOfBoundYNeg ? color : texturePixels[x + (y - 1) * Size.x]);
			Color32 leftNeighbour = (outOfBoundXNeg ? color : texturePixels[x - 1 + y * Size.x]);
			bool isGrass = EnvironmentColorIDs.IsGrass(color2);
			bool right = EnvironmentColorIDs.IsGrass(rightNeighbour);
			bool down = EnvironmentColorIDs.IsGrass(downNeighbour);
			bool left = EnvironmentColorIDs.IsGrass(leftNeighbour);
			Color32 upRightNeighbour = ((outOfBoundXPos || outOfBoundYPos) ? color : texturePixels[x + 1 + (y + 1) * Size.x]);
			Color32 downRightNeighbour = ((outOfBoundXPos || outOfBoundYNeg) ? color : texturePixels[x + 1 + (y - 1) * Size.x]);
			Color32 downLeftNeighbour = ((outOfBoundXNeg || outOfBoundYNeg) ? color : texturePixels[x - 1 + (y - 1) * Size.x]);
			Color32 upLeftNeighbour = ((outOfBoundXNeg || outOfBoundYPos) ? color : texturePixels[x - 1 + (y + 1) * Size.x]);
			bool upR = EnvironmentColorIDs.IsGrass(upRightNeighbour);
			bool downR = EnvironmentColorIDs.IsGrass(downRightNeighbour);
			bool downL = EnvironmentColorIDs.IsGrass(downLeftNeighbour);
			bool upL = EnvironmentColorIDs.IsGrass(upLeftNeighbour);
			if (ShouldUpdate(isGrass, color2, !outOfBoundYPos))
			{
				yield return x + (y + 1) * Size.x;
			}
			if (ShouldUpdate(right, rightNeighbour, !outOfBoundXPos))
			{
				yield return x + 1 + y * Size.x;
			}
			if (ShouldUpdate(down, downNeighbour, !outOfBoundYNeg))
			{
				yield return x + (y - 1) * Size.x;
			}
			if (ShouldUpdate(left, leftNeighbour, !outOfBoundXNeg))
			{
				yield return x - 1 + y * Size.x;
			}
			if (ShouldUpdate(upR, upRightNeighbour, !outOfBoundXPos && !outOfBoundYPos))
			{
				yield return x + 1 + (y + 1) * Size.x;
			}
			if (ShouldUpdate(downR, downRightNeighbour, !outOfBoundXPos && !outOfBoundYNeg))
			{
				yield return x + 1 + (y - 1) * Size.x;
			}
			if (ShouldUpdate(downL, downLeftNeighbour, !outOfBoundXNeg && !outOfBoundYNeg))
			{
				yield return x - 1 + (y - 1) * Size.x;
			}
			if (ShouldUpdate(upL, upLeftNeighbour, !outOfBoundXNeg && !outOfBoundYPos))
			{
				yield return x - 1 + (y + 1) * Size.x;
			}
			static bool ShouldUpdate(bool flag, Color32 neighbor, bool inBounds)
			{
				if (!flag && inBounds)
				{
					return EnvironmentColorIDs.IsRegularHeight(neighbor);
				}
				return false;
			}
		}

		public Color32[] GetFloorTextureToArray()
		{
			return _texture2D.GetPixels32();
		}

		public void SetTexturePixels(Color32[] floorTextureColors)
		{
			_texture2D.SetPixels32(floorTextureColors);
			_texture2D.Apply();
		}

		public void NewId()
		{
			_id = Guid.NewGuid();
		}
	}
}
