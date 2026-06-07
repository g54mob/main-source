using System.Collections.Generic;
using System.Text;
using Assets.Source.Player;
using Assets.Source.World.Frames;
using LightJson;
using UnityEngine;

namespace Assets.Source.World
{
	public class WorldMap : IJsonSource
	{
		public static readonly Vector2Int[] Directions = new Vector2Int[4]
		{
			Vector2Int.up,
			Vector2Int.down,
			Vector2Int.left,
			Vector2Int.right
		};

		public const int StartingAreaSize = 8;

		public const byte TerrainWater = 0;

		public const byte TerrainMountains = 1;

		public const byte TerrainField = 2;

		public const byte TerrainSand = 3;

		public const byte TerrainSteppe = 4;

		public const byte TerrainSwamp = 5;

		public const byte TerrainRocks = 6;

		public const byte TerrainForest = 7;

		public const byte TerrainCity = 8;

		public const byte TerrainRuins = 9;

		public const byte TerrainUnexplored = byte.MaxValue;

		public const int TerrainBlockSize = 16;

		public Vector2 CameraPosition;

		public float CameraZoom;

		public int Seed;

		public Vector2Int GlitchLocation;

		private Dictionary<Vector2Int, byte[,]> _terrain = new Dictionary<Vector2Int, byte[,]>();

		private Dictionary<Vector2Int, WorldFrame> _frames = new Dictionary<Vector2Int, WorldFrame>();

		private FastNoiseLite _baseNoise;

		private FastNoiseLite _detailNoise;

		private FastNoiseLite _tempNoise;

		private FastNoiseLite _cityNoise;

		public static WorldMap Current => GamePlayer.Current.Map;

		public IEnumerable<WorldFrame> Frames => _frames.Values;

		public IEnumerable<KeyValuePair<Vector2Int, byte[,]>> TerrainBlocks => _terrain;

		public void AddFrame(WorldFrame frame, Vector2Int? pos = null)
		{
			if (pos.HasValue)
			{
				frame.UpdatePosition(pos.Value);
			}
			_frames[frame.Position] = frame;
			frame.IsPlaced = true;
			frame.OnAddFrame();
		}

		public void UpdatePlacementBonus()
		{
			UpdatePlacementBonus<WorldFrame>();
		}

		public void UpdatePlacementBonus<T>() where T : WorldFrame
		{
			foreach (T frame in GetFrames<T>())
			{
				frame.UpdatePlacementBonus();
			}
			WorldFrame.UpdatePlacementBonusAchievement();
		}

		public void RemoveFrame(WorldFrame frame)
		{
			_frames.Remove(frame.Position);
			frame.IsPlaced = false;
			if (frame.Construction == null)
			{
				frame.OnDeconstructionCompleted();
			}
			if ((bool)frame.ActiveFrame)
			{
				Object.Destroy(frame.ActiveFrame.gameObject);
			}
			WorldOverview.Instance?.OnCellRemoved(frame);
			foreach (WorldFrame adjacentFrame in frame.GetAdjacentFrames())
			{
				adjacentFrame.UpdatePlacementBonus(frame);
			}
			WorldFrame.UpdatePlacementBonusAchievement();
		}

		public WorldFrame GetFrame(Vector2Int pos)
		{
			if (_frames.TryGetValue(pos, out var value))
			{
				return value;
			}
			return null;
		}

		public void CreateGlitchedFrame()
		{
			SeededRandom seededRandom = new SeedGenerator().Add(Seed).Add("GlitchedFrame").CreateRandom();
			int num = 0;
			Vector2Int vector2Int;
			do
			{
				Vector2 normalized = new Vector2(seededRandom.RandomRange(-1f, 1f), seededRandom.RandomRange(-1f, 1f)).normalized;
				float num2 = seededRandom.RandomRange(50, 80);
				vector2Int = new Vector2Int(Mathf.RoundToInt(normalized.x * num2), Mathf.RoundToInt(normalized.y * num2));
				num++;
			}
			while (GetTerrain(vector2Int, createNew: false) != byte.MaxValue && num < 50);
			GlitchLocation = vector2Int;
		}

		public void LazyLoadTerrain(Vector2Int pos)
		{
			int num = Mathf.FloorToInt((float)pos.x / 16f);
			int num2 = Mathf.FloorToInt((float)pos.y / 16f);
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					GetTerrainBlock(i + num, j + num2);
				}
			}
		}

		public void SetTerrain(Vector2Int pos, byte tile, bool redraw = true)
		{
			int num = Mathf.FloorToInt((float)pos.x / 16f);
			int num2 = Mathf.FloorToInt((float)pos.y / 16f);
			int num3 = (pos.x % 16 + 16) % 16;
			int num4 = (pos.y % 16 + 16) % 16;
			byte[,] terrainBlock = GetTerrainBlock(num, num2);
			terrainBlock[num3, num4] = tile;
			if (redraw && (bool)WorldOverview.Instance && (bool)WorldOverview.Instance.Terrain)
			{
				WorldOverview.Instance.Terrain.ShowBlock(new Vector2Int(num, num2), terrainBlock);
			}
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					GetFrame(new Vector2Int(pos.x + i, pos.y + j))?.UpdatePlacementBonus();
				}
			}
		}

		public byte GetTerrain(Vector2Int pos, bool createNew = true)
		{
			int blockX = Mathf.FloorToInt((float)pos.x / 16f);
			int blockY = Mathf.FloorToInt((float)pos.y / 16f);
			int num = (pos.x % 16 + 16) % 16;
			int num2 = (pos.y % 16 + 16) % 16;
			byte[,] terrainBlock = GetTerrainBlock(blockX, blockY, createNew);
			if (terrainBlock == null)
			{
				return byte.MaxValue;
			}
			return terrainBlock[num, num2];
		}

		public byte[,] GetTerrainBlock(int blockX, int blockY, bool createNew = true)
		{
			Vector2Int vector2Int = new Vector2Int(blockX, blockY);
			if (!_terrain.TryGetValue(vector2Int, out var value) && createNew)
			{
				value = CreateTerrain(vector2Int.x, vector2Int.y);
				_terrain.Add(vector2Int, value);
				int num = Mathf.FloorToInt((float)GlitchLocation.x / 16f);
				int num2 = Mathf.FloorToInt((float)GlitchLocation.y / 16f);
				if (num == blockX && num2 == blockY && !GamePlayer.Current.GlitchFrameInteracted)
				{
					for (int i = -1; i <= 1; i++)
					{
						for (int j = -1; j <= 1; j++)
						{
							SetTerrain(new Vector2Int(GlitchLocation.x - i, GlitchLocation.y - j), 9, redraw: false);
						}
					}
					GlitchedFrame frame = new GlitchedFrame();
					AddFrame(frame, GlitchLocation);
					WorldOverview.Instance.AddCell(frame);
				}
				if ((bool)WorldOverview.Instance && (bool)WorldOverview.Instance.Terrain)
				{
					WorldOverview.Instance.Terrain.ShowBlock(vector2Int, value);
				}
			}
			return value;
		}

		public T GetFrame<T>() where T : WorldFrame
		{
			foreach (WorldFrame value in _frames.Values)
			{
				if (value is T result)
				{
					return result;
				}
			}
			return null;
		}

		public IEnumerable<T> GetFrames<T>() where T : WorldFrame
		{
			foreach (WorldFrame value in _frames.Values)
			{
				if (value is T val)
				{
					yield return val;
				}
			}
		}

		public int GetFrameCount(string type, bool includeUnderConstruction = true)
		{
			int num = 0;
			foreach (WorldFrame frame in Frames)
			{
				if (frame.Identifier == type && (includeUnderConstruction || frame.Construction == null))
				{
					num++;
				}
			}
			return num;
		}

		public bool CanBuildAtPosition(Vector2Int pos, WorldFrame frame)
		{
			if (GetFrame(pos) != null)
			{
				return false;
			}
			byte terrain = GetTerrain(pos, createNew: false);
			if (terrain == 0 || terrain == 1 || terrain == byte.MaxValue)
			{
				return false;
			}
			if (!frame.IsValidPlacement(this, pos))
			{
				return false;
			}
			return true;
		}

		public void Update(float delta)
		{
			T1GlitchedFrame.UpdateReagents();
			foreach (WorldFrame value in _frames.Values)
			{
				value.Update(delta);
			}
		}

		public byte[,] CreateTerrain(int blockX, int blockY)
		{
			if (_baseNoise == null)
			{
				_baseNoise = new FastNoiseLite();
				_baseNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
				_baseNoise.SetSeed(Seed * 2);
				_detailNoise = new FastNoiseLite();
				_detailNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
				_detailNoise.SetSeed(Seed * 3);
				_tempNoise = new FastNoiseLite();
				_tempNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
				_tempNoise.SetSeed(Seed * 4);
				_cityNoise = new FastNoiseLite();
				_cityNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
				_cityNoise.SetSeed(Seed * 5);
			}
			byte[,] array = new byte[16, 16];
			int num = blockX * 16;
			int num2 = blockY * 16;
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					int num3 = i + num;
					int num4 = j + num2;
					float num5 = _baseNoise.GetNoise((float)num3 * 8f, (float)num4 * 8f) * 0.3f + _detailNoise.GetNoise(num3 * 2, num4 * 2) * 0.7f;
					byte b;
					if (num5 < -0.4f)
					{
						b = 0;
					}
					else if (num5 < -0.3f)
					{
						b = 3;
					}
					else if (num5 > 0.6f)
					{
						b = 1;
					}
					else if (num5 > 0.5f)
					{
						b = 6;
					}
					else
					{
						float num6 = _baseNoise.GetNoise((float)num3 * 8f, (float)num4 * 8f) * 0.3f + _tempNoise.GetNoise(num3, num4) * 0.7f;
						b = (byte)((num6 > 0.6f) ? 3 : ((num6 > 0.2f) ? 4 : ((!(num6 > -0.2f)) ? 5 : 2)));
					}
					if (b != 0 && b != 1)
					{
						float num7 = _baseNoise.GetNoise((float)num3 * 8f, (float)num4 * 8f) * 0.3f + _cityNoise.GetNoise(num3 * 2, num4 * 2) * 0.7f;
						if (num7 > 0.8f)
						{
							b = 8;
						}
						else if (num7 < -0.8f)
						{
							b = 9;
						}
						else if (num7 > -0.2f && num7 < 0.2f && (b == 5 || b == 2))
						{
							b = 7;
						}
					}
					array[i, j] = b;
				}
			}
			return array;
		}

		public bool HasStartingArea()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					byte terrain = GetTerrain(new Vector2Int(i, j));
					if (terrain == 0 || terrain == 1)
					{
						return false;
					}
				}
			}
			return true;
		}

		public List<Vector2Int> GetTileArea(Vector2Int start)
		{
			byte terrain = GetTerrain(start);
			List<Vector2Int> list = new List<Vector2Int> { start };
			HashSet<Vector2Int> hashSet = new HashSet<Vector2Int> { start };
			Queue<Vector2Int> queue = new Queue<Vector2Int>();
			queue.Enqueue(start);
			do
			{
				Vector2Int vector2Int = queue.Dequeue();
				for (int i = 0; i < Directions.Length; i++)
				{
					Vector2Int vector2Int2 = vector2Int + Directions[i];
					if (!hashSet.Contains(vector2Int2))
					{
						hashSet.Add(vector2Int2);
						byte terrain2 = GetTerrain(vector2Int2);
						if (terrain2 == terrain || (terrain == 9 && terrain2 == 8) || (terrain == 8 && terrain2 == 9))
						{
							list.Add(vector2Int2);
							queue.Enqueue(vector2Int2);
						}
					}
					hashSet.Add(vector2Int2);
				}
			}
			while (queue.Count > 0);
			return list;
		}

		public void ExpandCityBuilder()
		{
			T8CityBuilder t8CityBuilder = SeededRandom.Global.Choose(new List<T8CityBuilder>(GetFrames<T8CityBuilder>()));
			byte terrain = GetTerrain(t8CityBuilder.Position);
			SeededRandom global = SeededRandom.Global;
			if (terrain != 8 && terrain != 9)
			{
				SetTerrain(t8CityBuilder.Position, 8);
			}
			List<Vector2Int> tileArea = GetTileArea(t8CityBuilder.Position);
			int num = 0;
			while (num < 100)
			{
				num++;
				Vector2Int pos = global.Choose(tileArea) + global.Choose(Directions);
				byte terrain2 = GetTerrain(pos);
				if (terrain2 != 8 && terrain2 != 9 && (num >= 50 || (terrain2 != 0 && terrain2 != 1)))
				{
					SetTerrain(pos, 8);
					break;
				}
			}
		}

		public JsonValue ToJson()
		{
			JsonArray jsonArray = new JsonArray();
			foreach (WorldFrame frame in Frames)
			{
				jsonArray.Add(frame.ToJson());
			}
			JsonArray jsonArray2 = new JsonArray();
			foreach (KeyValuePair<Vector2Int, byte[,]> terrainBlock in TerrainBlocks)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						stringBuilder.Append(terrainBlock.Value[i, j]);
					}
				}
				jsonArray2.Add(new JsonObject
				{
					{
						"X",
						terrainBlock.Key.x
					},
					{
						"Y",
						terrainBlock.Key.y
					},
					{
						"Tiles",
						stringBuilder.ToString()
					}
				});
			}
			return new JsonObject
			{
				{ "Frames", jsonArray },
				{ "Terrain", jsonArray2 },
				{ "CameraX", CameraPosition.x },
				{ "CameraY", CameraPosition.y },
				{ "CameraZoom", CameraZoom },
				{ "Seed", Seed },
				{ "GlitchX", GlitchLocation.x },
				{ "GlitchY", GlitchLocation.y }
			};
		}

		public static WorldMap FromJson(JsonValue val)
		{
			WorldMap worldMap = new WorldMap
			{
				CameraPosition = new Vector2((float)val["CameraX"].AsNumber, (float)val["CameraY"].AsNumber),
				CameraZoom = (float)val["CameraZoom"].AsNumber,
				Seed = val["Seed"],
				GlitchLocation = new Vector2Int(val["GlitchX"], val["GlitchY"])
			};
			if (worldMap.Seed == 0)
			{
				worldMap.Seed = (int)SeededRandom.Global.RandomInt();
			}
			foreach (JsonValue item in val["Frames"].AsJsonArray)
			{
				worldMap.AddFrame(WorldFrame.FromJson(item));
			}
			JsonValue jsonValue = val["Terrain"];
			if (jsonValue.IsJsonArray)
			{
				foreach (JsonValue item2 in jsonValue.AsJsonArray)
				{
					char[] array = item2["Tiles"].AsString.ToCharArray();
					byte[,] array2 = new byte[16, 16];
					int num = 0;
					for (int i = 0; i < 16; i++)
					{
						for (int j = 0; j < 16; j++)
						{
							array2[i, j] = (byte)(array[num] - 48);
							num++;
						}
					}
					worldMap._terrain.Add(new Vector2Int(item2["X"], item2["Y"]), array2);
				}
			}
			return worldMap;
		}
	}
}
