using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Planet.Modifiers.Material
{
	[Serializable]
	public class DistanceBlendedTexturesConfiguration
	{
		[Serializable]
		public class DistanceBlendedTextureLevel
		{
			[SerializeField]
			[Tooltip("The texture tiling value for this tile level.")]
			private int _tiling = 1;

			[SerializeField]
			[Tooltip("The texture strength for this tile level.")]
			private float _strength = 1f;

			[SerializeField]
			[Tooltip("A generic data field that may hold an additional value for the tiling level.")]
			private float _data1;

			[SerializeField]
			[Tooltip("A generic data field that may hold an additional value for the tiling level.")]
			private float _data2;

			public float Data1
			{
				get
				{
					return _data1;
				}
				set
				{
					_data1 = value;
				}
			}

			public float Data2
			{
				get
				{
					return _data2;
				}
				set
				{
					_data2 = value;
				}
			}

			public float Strength
			{
				get
				{
					return _strength;
				}
				set
				{
					_strength = value;
				}
			}

			public int Tiling
			{
				get
				{
					return _tiling;
				}
				set
				{
					_tiling = value;
				}
			}

			public DistanceBlendedTextureLevel(int tiling, float strength, float data1 = 0f, float data2 = 0f)
			{
				_tiling = tiling;
				_strength = strength;
				_data1 = data1;
				_data2 = data2;
			}

			public void Update(int tiling, float strength, float data1 = 0f, float data2 = 0f)
			{
				_tiling = tiling;
				_strength = strength;
				_data1 = data1;
				_data2 = data2;
			}
		}

		public const int TileLevelCount = 20;

		[SerializeField]
		[Tooltip("The distance adjustment value that is added to the distance which determines the tiling level. This adjustment is applied after the distance scalar is applied. Example: If the first tiling level lasts until about 100 meters and this adjustment value is -500, then the first tiling level will last until about 600 meters.")]
		private float _distanceAdjustment = 10f;

		[SerializeField]
		[Tooltip("The distance scalar used to adjust the distance at which the levels begin. Doubling this value will cause tiling levels to begin twice as early as normal.")]
		private float _distanceScalar = 1f;

		[SerializeField]
		private DistanceBlendedTextureLevel[] _levels;

		[SerializeField]
		[Range(0f, 20f)]
		[Tooltip("The tiling level at which scaled UV coordinates start being used. If this is set to 3, then tiling levels 1, 2 and 3 will use scaled UV coordinates. The remaining tiling levels will used standard UV coordinates.")]
		private int _scaledUvStartLevel = 8;

		public float DistanceAdjustment
		{
			get
			{
				return _distanceAdjustment;
			}
			set
			{
				_distanceAdjustment = value;
			}
		}

		public float DistanceScalar
		{
			get
			{
				return _distanceScalar;
			}
			set
			{
				_distanceScalar = value;
			}
		}

		public DistanceBlendedTextureLevel[] Levels => _levels;

		public int ScaledUvStartLevel
		{
			get
			{
				return _scaledUvStartLevel;
			}
			set
			{
				_scaledUvStartLevel = value;
			}
		}

		public void CopyFrom(DistanceBlendedTexturesConfiguration tilingConfiguration)
		{
			_distanceAdjustment = tilingConfiguration._distanceAdjustment;
			_distanceScalar = tilingConfiguration._distanceScalar;
			_scaledUvStartLevel = tilingConfiguration._scaledUvStartLevel;
			for (int i = 0; i < _levels.Length; i++)
			{
				_levels[i].Tiling = tilingConfiguration._levels[i].Tiling;
				_levels[i].Strength = tilingConfiguration._levels[i].Strength;
				_levels[i].Data1 = tilingConfiguration._levels[i].Data1;
				_levels[i].Data2 = tilingConfiguration._levels[i].Data2;
			}
		}

		public void GetData(float distance, out Vector4 outputStrengths, out Vector4 outputData)
		{
			float num = (float)System.Math.Log(System.Math.Max(4f, distance * _distanceScalar + _distanceAdjustment), 2.0) - 1f;
			float num2 = (float)System.Math.Min(System.Math.Floor(num), 19.0);
			int num3 = (int)num2 % 2;
			int num4 = 1 - num3;
			int num5 = System.Math.Sign((double)num3 - 0.5);
			int num6 = System.Math.Sign((double)num4 - 0.5);
			float num7 = num2 + (float)num4;
			num2 += (float)num3;
			float num8 = num % 1f;
			float num9 = num8 * (float)num6 + (float)num3;
			float num10 = num8 * (float)num5 + (float)num4;
			DistanceBlendedTextureLevel distanceBlendedTextureLevel = _levels[(int)num7 - 1];
			DistanceBlendedTextureLevel distanceBlendedTextureLevel2 = _levels[(int)num2 - 1];
			outputStrengths = new Vector4(num9 * distanceBlendedTextureLevel.Strength, num10 * distanceBlendedTextureLevel2.Strength, num9, num10);
			outputData = new Vector4(distanceBlendedTextureLevel.Data1, distanceBlendedTextureLevel2.Data1, distanceBlendedTextureLevel.Data2, distanceBlendedTextureLevel2.Data2);
		}

		public Vector4[] GetShaderData(float planetScale)
		{
			Vector4[] array = new Vector4[21];
			array[0] = new Vector4(_distanceScalar, _distanceAdjustment, _scaledUvStartLevel, 0f);
			for (int i = 1; i < array.Length; i++)
			{
				int num = i - 1;
				if (num < _levels.Length)
				{
					DistanceBlendedTextureLevel distanceBlendedTextureLevel = _levels[num];
					array[i] = new Vector4((int)((float)distanceBlendedTextureLevel.Tiling * planetScale), distanceBlendedTextureLevel.Strength, distanceBlendedTextureLevel.Data1, distanceBlendedTextureLevel.Data2);
				}
				else
				{
					array[i] = new Vector4(1f, 1f, 0f, 0f);
				}
			}
			return array;
		}

		public void InitializeLevels()
		{
			if (_levels == null)
			{
				_levels = new DistanceBlendedTextureLevel[20];
				for (int i = 0; i < _levels.Length; i++)
				{
					_levels[i] = new DistanceBlendedTextureLevel(1, 1f);
				}
			}
			else if (_levels.Length != 20)
			{
				DistanceBlendedTextureLevel[] array = new DistanceBlendedTextureLevel[20];
				int j;
				for (j = 0; j < _levels.Length; j++)
				{
					array[j] = _levels[j];
				}
				for (; j < array.Length; j++)
				{
					array[j] = new DistanceBlendedTextureLevel(1, 1f);
				}
				_levels = array;
			}
		}

		public void RestoreXml(XElement xml)
		{
			if (xml == null)
			{
				xml = new XElement("TilingConfig");
			}
			_distanceAdjustment = ((float?)xml.Attribute("distanceAdjustment")) ?? 10f;
			_distanceScalar = ((float?)xml.Attribute("distanceScalar")) ?? 1f;
			_scaledUvStartLevel = ((int?)xml.Attribute("scaledUvStartLevel")) ?? 8;
			_levels = new DistanceBlendedTextureLevel[20];
			List<XElement> list = xml.Elements("TileLevel").ToList();
			for (int i = 0; i < _levels.Length; i++)
			{
				if (i < list.Count)
				{
					_levels[i] = new DistanceBlendedTextureLevel(((int?)list[i].Attribute("tiling")) ?? 1, ((float?)list[i].Attribute("strength")) ?? 1f, ((float?)list[i].Attribute("waveSpeed")).GetValueOrDefault(), ((float?)list[i].Attribute("specularity")).GetValueOrDefault());
				}
				else
				{
					_levels[i] = new DistanceBlendedTextureLevel(1, 1f);
				}
			}
		}

		public XElement SaveXml(XElement xml)
		{
			xml.SetAttributeValue("distanceAdjustment", _distanceAdjustment);
			xml.SetAttributeValue("distanceScalar", _distanceScalar);
			xml.SetAttributeValue("scaledUvStartLevel", _scaledUvStartLevel);
			DistanceBlendedTextureLevel[] levels = _levels;
			foreach (DistanceBlendedTextureLevel distanceBlendedTextureLevel in levels)
			{
				xml.Add(new XElement("TileLevel", new XAttribute("tiling", distanceBlendedTextureLevel.Tiling), new XAttribute("strength", distanceBlendedTextureLevel.Strength), (distanceBlendedTextureLevel.Data1 == 0f) ? null : new XAttribute("waveSpeed", distanceBlendedTextureLevel.Data1), (distanceBlendedTextureLevel.Data2 == 0f) ? null : new XAttribute("specularity", distanceBlendedTextureLevel.Data2)));
			}
			return xml;
		}

		internal void OnAfterDeserialize()
		{
			InitializeLevels();
		}
	}
}
