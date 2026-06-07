using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using ModApi.Craft.Parts.Styles;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Styles
{
	public class PartStyle : IPartStyle
	{
		private Dictionary<string, string> _data;

		private List<PartTextureStyle> _textures;

		public IReadOnlyDictionary<string, string> Data { get; private set; }

		public string DisplayName { get; private set; }

		public bool Hidden { get; private set; }

		public string Id { get; private set; }

		public bool Invalid { get; private set; }

		public string PartId { get; private set; }

		public int SubpartIndex { get; private set; }

		public IReadOnlyList<IPartTextureStyle> Textures { get; private set; }

		public PartStyle(string id, string partId, int subpartIndex, string displayName, Dictionary<string, string> data, List<PartTextureStyle> textureStyles, bool invalid, bool hidden)
		{
			Id = id;
			PartId = partId;
			SubpartIndex = subpartIndex;
			DisplayName = displayName;
			Dictionary<string, string> obj = data ?? new Dictionary<string, string>(0);
			Dictionary<string, string> data2 = obj;
			_data = obj;
			Data = data2;
			Textures = (_textures = textureStyles ?? new List<PartTextureStyle>(0));
			Invalid = invalid;
			Hidden = hidden;
		}

		public T GetData<T>(string key, T defaultValue, bool logErrors = true)
		{
			if (!_data.TryGetValue(key, out var value))
			{
				if (logErrors)
				{
					Debug.LogError($"Could not find style data '{key}' for style '{Id}' on part '{PartId}' and subpart '{SubpartIndex}'.");
				}
				return defaultValue;
			}
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
			if (!converter.CanConvertFrom(typeof(string)))
			{
				if (logErrors)
				{
					Debug.LogError("Could not convert value '" + value + "' with data key '" + key + "' to type '" + typeof(T).FullName + "' " + $"for style '{Id}' on part '{PartId}' and subpart '{SubpartIndex}'.");
				}
				return defaultValue;
			}
			return (T)converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);
		}

		internal PartStyle CloneWithSharedData(string styleIdAndDisplayName, bool invalid)
		{
			return new PartStyle(styleIdAndDisplayName, PartId, SubpartIndex, styleIdAndDisplayName, _data, _textures, invalid, Hidden);
		}

		internal void Update(string displayName, Dictionary<string, string> data, List<PartTextureStyle> textureStyles)
		{
			if (DisplayName != displayName && !string.IsNullOrWhiteSpace(displayName))
			{
				Debug.Log($"Overriding display name for part style '{Id}' on part '{PartId}' ({SubpartIndex}). '{DisplayName}' --> '{displayName}'");
				DisplayName = displayName;
			}
			foreach (string key in data.Keys)
			{
				if (_data.ContainsKey(key))
				{
					if (_data[key] != data[key])
					{
						Debug.Log($"Overriding data item '{key}' for part style '{Id}' on part '{PartId}' ({SubpartIndex}). '{_data[key]}' --> '{data[key]}'");
						_data[key] = data[key];
					}
				}
				else
				{
					_data.Add(key, data[key]);
				}
			}
			foreach (PartTextureStyle textureStyle in textureStyles)
			{
				if (!_textures.Contains(textureStyle))
				{
					_textures.Add(textureStyle);
				}
			}
		}
	}
}
