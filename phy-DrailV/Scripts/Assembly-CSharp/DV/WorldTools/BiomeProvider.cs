using System;
using System.IO;
using System.Text;
using DV.Utils;
using UnityEngine;

namespace DV.WorldTools
{
	public class BiomeProvider : SingletonBehaviour<BiomeProvider>
	{
		[Header("Debug")]
		public bool showBiomeStats;

		private LevelInfo _lastLevelInfo;

		private byte[] _map;

		private int _size;

		private Biome _centralBiome;

		private float cellToWorld = 1f;

		private float worldToCell = 1f;

		private static readonly Biome[] Biomes = (Biome[])Enum.GetValues(typeof(Biome));

		private static readonly int BiomeCount = Biomes.Length;

		private Vector3[] biomeDirection = new Vector3[BiomeCount];

		private float[] biomeDirectionWeight = new float[BiomeCount];

		private float[] biomeVolume = new float[BiomeCount];

		private int[] biomeCount = new int[BiomeCount];

		private StringBuilder sb = new StringBuilder();

		public Vector3[] BiomeDirection => biomeDirection;

		public float[] BiomeVolume => biomeVolume;

		public Biome CurrentBiome => _centralBiome;

		public new static string AllowAutoCreate()
		{
			return "[BiomeProvider]";
		}

		protected override void Initialize()
		{
			CheckInit();
		}

		private void Start()
		{
			CheckInit();
		}

		private void CheckInit()
		{
			if (_map != null)
			{
				return;
			}
			if (_lastLevelInfo == null)
			{
				_lastLevelInfo = SingletonBehaviour<LevelInfo>.Instance;
			}
			if (_lastLevelInfo != null && !string.IsNullOrEmpty(_lastLevelInfo.biomeMapName))
			{
				try
				{
					_map = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "w3", _lastLevelInfo.biomeMapName));
					_size = Mathf.RoundToInt(Mathf.Sqrt(_map.Length));
					worldToCell = (float)_size / _lastLevelInfo.worldSize.x;
					cellToWorld = 1f / worldToCell;
					return;
				}
				catch (Exception exception)
				{
					Debug.LogError("Couldn't load biome map (" + Path.Combine(Application.streamingAssetsPath, "w3", _lastLevelInfo.biomeMapName) + ")");
					Debug.LogException(exception);
					_map = null;
					_size = 0;
					return;
				}
			}
			_map = null;
			_size = 0;
		}

		public Biome GetSample(int x, int y)
		{
			if (_size == 0)
			{
				return Biome.Meadow;
			}
			if (_map.Length == 0)
			{
				return Biome.Meadow;
			}
			x = Mathf.Abs(x) % _size;
			y = _size - Mathf.Abs(y) % _size - 1;
			return (Biome)_map[y * _size + x];
		}

		public Biome GetPointSample(Vector3 position, bool usingWorldShift = true)
		{
			if (_size == 0)
			{
				return Biome.Meadow;
			}
			if (usingWorldShift)
			{
				position -= WorldMover.currentMove;
			}
			position *= worldToCell;
			return GetSample(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.z));
		}

		private void LateUpdate()
		{
			for (int i = 0; i < BiomeCount; i++)
			{
				biomeDirection[i] = Vector3.zero;
				biomeDirectionWeight[i] = 0f;
				biomeVolume[i] = 0f;
				biomeCount[i] = 0;
			}
			if (!(PlayerManager.ActiveCamera != null))
			{
				return;
			}
			Vector3 position = PlayerManager.ActiveCamera.transform.position;
			int num = Mathf.FloorToInt((position.x - WorldMover.currentMove.x) * worldToCell);
			int num2 = Mathf.FloorToInt((position.z - WorldMover.currentMove.z) * worldToCell);
			Vector3 vector = position - (new Vector3((float)num * cellToWorld, 0f, (float)num2 * cellToWorld) + WorldMover.currentMove);
			vector.y = 0f;
			int num3 = 5;
			for (int j = num2 - num3; j <= num2 + num3; j++)
			{
				for (int k = num - num3; k <= num + num3; k++)
				{
					Biome sample = GetSample(k, j);
					biomeCount[(uint)sample]++;
					Vector3 vector2 = new Vector3((float)k * cellToWorld, 0f, (float)j * cellToWorld);
					vector2 += WorldMover.currentMove;
					vector2 += vector;
					vector2.y = Mathf.Max(Mathf.Min(position.y, LevelInfo.WaterLevel), HeightMapProvider.GetPointSample(vector2) + 1f);
					Vector3 vector3 = vector2 - position;
					Vector3 vector4 = vector3;
					vector4.y = 0f;
					float num4 = Mathf.Max(0f, (float)num3 * cellToWorld - vector4.magnitude);
					biomeDirectionWeight[(uint)sample] += num4;
					biomeDirection[(uint)sample] += vector3 * num4;
					if (k == num && j == num2)
					{
						_centralBiome = sample;
					}
				}
			}
			int num5 = (num3 * 2 + 1) * (num3 * 2 + 1);
			for (int l = 0; l < BiomeCount; l++)
			{
				if (biomeCount[l] > 0 && biomeDirectionWeight[l] > 0f)
				{
					biomeDirection[l] /= biomeDirectionWeight[l];
				}
				biomeVolume[l] = (float)biomeCount[l] / (float)num5;
			}
		}

		private void OnGUI()
		{
			if (!showBiomeStats || !(PlayerManager.ActiveCamera != null))
			{
				return;
			}
			sb.Clear();
			for (int i = 0; i < BiomeCount; i++)
			{
				if (biomeVolume[i] > 0f)
				{
					sb.AppendLine($"{(int)(biomeVolume[i] * 100f)}% {Biomes[i]} @ {biomeDirection[i]}");
				}
			}
			GUI.Label(new Rect(10f, 10f, 500f, 500f), sb.ToString());
		}
	}
}
