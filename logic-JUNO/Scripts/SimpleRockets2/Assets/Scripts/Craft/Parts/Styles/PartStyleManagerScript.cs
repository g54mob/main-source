using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft.Parts.Styles;
using ModApi.Settings;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Styles
{
	public class PartStyleManagerScript : MonoBehaviour, IPartStyleManager
	{
		public enum PartTexturePlatformType
		{
			Standalone = 0,
			Android = 1,
			iOS = 2
		}

		public enum PartTextureSize
		{
			_256 = 0x100,
			_512 = 0x200,
			_1024 = 0x400
		}

		private class PartStyleSet
		{
			private List<PartStyle> _invalidStyles;

			private Dictionary<string, PartStyle> _styleMap;

			private List<PartStyle> _styles;

			public IReadOnlyList<IPartStyle> InvalidStyles { get; private set; }

			public string PartId { get; private set; }

			public IReadOnlyList<IPartStyle> Styles { get; private set; }

			public int SubpartIndex { get; private set; }

			public PartStyleSet(string partId, int subpartIndex)
			{
				PartId = partId;
				SubpartIndex = subpartIndex;
				Styles = (_styles = new List<PartStyle>());
				InvalidStyles = (_invalidStyles = new List<PartStyle>());
				_styleMap = new Dictionary<string, PartStyle>();
			}

			public void Add(PartStyle style)
			{
				if (_styleMap.ContainsKey(style.Id))
				{
					Debug.LogError($"Style set for part '{PartId}' ({SubpartIndex}) already contains a style with id '{style.Id}'.");
					return;
				}
				_styleMap.Add(style.Id, style);
				if (style.Invalid)
				{
					_invalidStyles.Add(style);
				}
				else
				{
					_styles.Add(style);
				}
			}

			public PartStyle GetStyle(string styleId)
			{
				_styleMap.TryGetValue(styleId ?? string.Empty, out var value);
				return value;
			}
		}

		private class TextureInfo
		{
			public string Id { get; private set; }

			public int Index { get; private set; }

			public ILoadedMod Mod { get; private set; }

			public string Path { get; set; }

			public TextureInfo(string id, string path, int index, ILoadedMod mod)
			{
				Id = id;
				Path = path;
				Index = index;
				Mod = mod;
			}
		}

		private const string TextureResourcesRootPath = "Craft/Parts/Textures/";

		private static IReadOnlyList<IPartStyle> _emptyPartStyleList = new List<IPartStyle>(0);

		private static IReadOnlyList<IPartTextureStyle> _emptyPartTextureStyleList = new List<IPartTextureStyle>(0);

		private CraftQualitySettings _craftQualitySettings;

		private Dictionary<string, TextureInfo> _detailTextures;

		[SerializeField]
		private PartTextureSize _detailTextureSize;

		[SerializeField]
		private PartTextureSize _normalMapTextureSize;

		private Dictionary<string, TextureInfo> _normalTextures;

		private Dictionary<string, List<PartStyleSet>> _partStyles;

		[SerializeField]
		private bool _supportsModTextures;

		private bool _textureArraysNeedRebuilt;

		[SerializeField]
		private PartTexturePlatformType _texturePlatform;

		private Dictionary<string, PartTextureStyle> _textureStyles;

		public static string DefaultDetailTextureId => "DefaultDetail";

		public static string DefaultNormalMapTextureId => "DefaultNormal";

		public IPartStyle DefaultStyle { get; private set; }

		public IPartTextureStyle DefaultTextureStyle { get; private set; }

		public Texture2DArray DetailTextures { get; private set; }

		public bool DetailTexturesEnabled { get; private set; }

		public PartTextureSize DetailTextureSize
		{
			get
			{
				return _detailTextureSize;
			}
			private set
			{
				_detailTextureSize = value;
			}
		}

		public bool EditorMode { get; private set; }

		public bool ModTexturesLoaded { get; private set; }

		public bool NormalMapsEnabled { get; private set; }

		public Texture2DArray NormalMapTextures { get; private set; }

		public PartTextureSize NormalMapTextureSize
		{
			get
			{
				return _normalMapTextureSize;
			}
			private set
			{
				_normalMapTextureSize = value;
			}
		}

		public bool RuntimeCreation { get; private set; }

		public bool SupportsModTextures
		{
			get
			{
				return _supportsModTextures;
			}
			private set
			{
				_supportsModTextures = value;
			}
		}

		public PartTexturePlatformType TexturePlatform
		{
			get
			{
				return _texturePlatform;
			}
			private set
			{
				_texturePlatform = value;
			}
		}

		public event EventHandler TextureArraysChanged;

		public static PartStyleManagerScript Create(GameObject parent)
		{
			PartStyleManagerScript partStyleManagerScript = new GameObject("PartStyleManager").AddComponent<PartStyleManagerScript>();
			if (parent != null)
			{
				partStyleManagerScript.transform.SetParent(parent.transform);
			}
			partStyleManagerScript.Initialize();
			return partStyleManagerScript;
		}

		public int GetDetailTextureIndex(string textureId)
		{
			if (!_detailTextures.TryGetValue(textureId, out var value))
			{
				this.LogError("Unable to find detail texture with ID '" + textureId + "'.");
				return 0;
			}
			return value.Index;
		}

		public int GetNormalMapTextureIndex(string textureId)
		{
			if (!_normalTextures.TryGetValue(textureId, out var value))
			{
				this.LogError("Unable to find normal map texture with ID '" + textureId + "'.");
				return 0;
			}
			return value.Index;
		}

		public IPartStyle GetStyle(string partId, int subpartIndex, string styleId)
		{
			IPartStyle partStyle = null;
			PartStyleSet styleSet = GetStyleSet(partId, subpartIndex);
			if (styleSet != null)
			{
				partStyle = ((!((styleId ?? string.Empty) == string.Empty)) ? styleSet.GetStyle(styleId) : ((styleSet.Styles.Count > 0) ? styleSet.Styles[0] : null));
			}
			return partStyle ?? CreateMissingStyle(partId, subpartIndex, styleId);
		}

		public IReadOnlyList<IPartStyle> GetStyles(string partId, int subpartIndex)
		{
			PartStyleSet styleSet = GetStyleSet(partId, subpartIndex);
			if (styleSet != null)
			{
				return styleSet.Styles;
			}
			return _emptyPartStyleList;
		}

		public IPartTextureStyle GetTextureStyle(string id)
		{
			if (id == null)
			{
				id = string.Empty;
			}
			if (!_textureStyles.TryGetValue(id, out var value))
			{
				int num = id.IndexOf(',');
				if (num >= 0)
				{
					string text = id.Substring(0, num);
					string text2 = id.Substring(num);
					if (!_detailTextures.ContainsKey(text))
					{
						Debug.Log("Unable to find part detail texture '" + text + "' for custom style '" + id + "'");
						text = null;
					}
					if (!_normalTextures.ContainsKey(text2))
					{
						Debug.Log("Unable to find part normal map texture '" + text2 + "' for custom style '" + id + "'");
						text2 = null;
					}
					if (text != null || text2 != null)
					{
						return new PartTextureStyle("custom", "Custom", PartTextureStyleOptions.Default, text, text2);
					}
				}
			}
			return value;
		}

		public IReadOnlyList<IPartTextureStyle> GetTextureStyles(string partId, int subpartIndex, string styleId)
		{
			IPartStyle style = GetStyle(partId, subpartIndex, styleId);
			if (style != null)
			{
				return style.Textures;
			}
			return _emptyPartTextureStyleList;
		}

		public void LoadPartStyleExtensions(string xml)
		{
			foreach (XElement item in XDocument.Parse(xml).Root.Elements("PartStyleExtension"))
			{
				string text = (string)item.Attribute("partId");
				int? num = (int?)item.Attribute("subpartIndex");
				string text2 = (string)item.Attribute("styleId");
				if (string.IsNullOrWhiteSpace(text))
				{
					Debug.LogError("Unable to load part style extension because the part type ID could not be found.");
					continue;
				}
				if (!num.HasValue)
				{
					Debug.LogError("Unable to load part style extension for part '" + text + "' because the subpart index could not be found.");
					continue;
				}
				if (string.IsNullOrWhiteSpace(text2))
				{
					Debug.LogError($"Unable to load part style extension for part '{text}' (subpart '{num}') because the style ID could not be found.");
					continue;
				}
				Dictionary<string, string> data = new Dictionary<string, string>(0);
				List<PartTextureStyle> list = new List<PartTextureStyle>();
				foreach (XElement item2 in item.Elements("TextureStyles").Elements("TextureStyle"))
				{
					string key = (string)item2.Attribute("id");
					if (_textureStyles.TryGetValue(key, out var value))
					{
						list.Add(value);
					}
					else
					{
						this.LogError("Unable to find a texture style for part style '" + (text2 ?? "null") + ". " + string.Format("PartId: {0}, SubpartIndex: {1}", text ?? "null", num));
					}
				}
				if (list.Count > 0)
				{
					LoadStyle(text2, text, num.Value, string.Empty, data, list, isStyleExtension: true, hidden: false);
				}
			}
		}

		public void LoadPartStyles(string partId, XElement styleXml)
		{
			foreach (XElement item in styleXml.Elements("SubpartStyles"))
			{
				LoadStyleSet(partId, item);
			}
		}

		public void LoadTextureStyles(string xml, ILoadedMod mod)
		{
			if (mod != null && !SupportsModTextures)
			{
				Debug.LogWarning("Cannot load part textures for mod '" + mod.ModInfo.Name + "' because this device does not support them.");
				return;
			}
			int num = 0;
			foreach (XElement item in XDocument.Parse(xml).Elements("TextureStyles").Elements("TextureStyle"))
			{
				LoadTextureStyle(item, mod);
				num++;
			}
			if (num > 0)
			{
				_textureArraysNeedRebuilt = true;
				if (mod != null)
				{
					ModTexturesLoaded = true;
				}
			}
		}

		[ContextMenu("Rebuild Texture Arrays")]
		public void RebuildTextureArrays()
		{
			UnloadTextureArrays();
			if (DetailTexturesEnabled)
			{
				DetailTextures = CreateTextureArray(_detailTextures, DefaultDetailTextureId, DetailTextureSize);
				DetailTextures.name = "PartTextureArray_Details";
			}
			if (NormalMapsEnabled)
			{
				NormalMapTextures = CreateTextureArray(_normalTextures, DefaultNormalMapTextureId, NormalMapTextureSize);
				NormalMapTextures.name = "PartTextureArray_Normals";
			}
			_textureArraysNeedRebuilt = false;
			this.TextureArraysChanged?.Invoke(this, EventArgs.Empty);
		}

		public void RebuildTextureArraysIfNecessary()
		{
			if (_textureArraysNeedRebuilt)
			{
				RebuildTextureArrays();
			}
		}

		public void UpdateTextureSettings(PartTexturePlatformType platform, PartTextureSize detailSize, PartTextureSize normalMapSize)
		{
			TexturePlatform = platform;
			DetailTextureSize = detailSize;
			NormalMapTextureSize = normalMapSize;
			_textureArraysNeedRebuilt = true;
		}

		protected virtual void OnDestroy()
		{
			_craftQualitySettings.NormalMaps.Changed -= OnTextureQualityChanged;
			_craftQualitySettings.DetailTextures.Changed -= OnTextureQualityChanged;
		}

		private void ApplyQualitySettings()
		{
			UpdateQualitySettings();
			RebuildTextureArrays();
		}

		private IPartStyle CreateMissingStyle(string partId, int subpartIndex, string styleId)
		{
			if (styleId == null)
			{
				styleId = string.Empty;
			}
			this.LogWarning($"Could not find part style '{styleId}' for part '{partId}' ({subpartIndex}).");
			if (!_partStyles.TryGetValue(partId, out var value))
			{
				value = new List<PartStyleSet>(Math.Max(3, subpartIndex));
				_partStyles.Add(partId, value);
			}
			while (value.Count <= subpartIndex)
			{
				value.Add(new PartStyleSet(partId, subpartIndex));
			}
			PartStyleSet partStyleSet = value[subpartIndex];
			PartStyle partStyle = ((styleId == string.Empty) ? ((PartStyle)DefaultStyle).CloneWithSharedData("Default", invalid: false) : ((partStyleSet.Styles.Count <= 0) ? ((PartStyle)DefaultStyle).CloneWithSharedData(styleId, invalid: true) : ((PartStyle)partStyleSet.Styles[0]).CloneWithSharedData(styleId, invalid: true)));
			partStyleSet.Add(partStyle);
			return partStyle;
		}

		private Texture2DArray CreateTextureArray(IReadOnlyDictionary<string, TextureInfo> textures, string defaultId, PartTextureSize textureSize)
		{
			if (!SystemInfo.supports2DArrayTextures)
			{
				Debug.LogError("Texture arrays are not supported on this platform.");
				return null;
			}
			RuntimeCreation = EditorMode || (SupportsModTextures && (ModTexturesLoaded || Device.IsUnityEditor));
			Texture2DArray texture2DArray;
			if (RuntimeCreation)
			{
				if (!textures.TryGetValue(defaultId, out var value))
				{
					this.LogError("Default texture for texture array could not be found. Id: " + defaultId);
					return null;
				}
				Texture2D texture2D = LoadTexture(value);
				if (texture2D == null)
				{
					this.LogError("Default texture for texture array could not be loaded: " + value.Path);
					return null;
				}
				texture2DArray = new Texture2DArray((int)textureSize, (int)textureSize, textures.Count, texture2D.format, mipChain: true, linear: true);
				texture2DArray.Apply(updateMipmaps: false, makeNoLongerReadable: true);
				foreach (TextureInfo value2 in textures.Values)
				{
					Texture2D texture2D2 = LoadTexture(value2);
					if (texture2D2 == null)
					{
						this.LogError("Unable to load texture '" + value2.Id + "' at path '" + value2.Path + "'. It will be skipped.");
					}
					else
					{
						Thread.Sleep(10);
						UpdateTextureArray(texture2DArray, texture2D2, value2, textureSize);
						UnloadTexture(texture2D2, value2);
					}
				}
			}
			else
			{
				string arg = ((defaultId == DefaultDetailTextureId) ? "Detail" : "NormalMap");
				string path = string.Format("{0}Part{1}Textures_{2}", "Craft/Parts/Textures/", arg, (int)textureSize);
				IResourceLoader resourceLoader;
				if (!EditorMode)
				{
					resourceLoader = Game.Instance.ResourceLoader;
				}
				else
				{
					IResourceLoader resourceLoader2 = new ResourceLoader();
					resourceLoader = resourceLoader2;
				}
				texture2DArray = resourceLoader.Load<Texture2DArray>(path);
			}
			return texture2DArray;
		}

		private PartStyleSet GetStyleSet(string partId, int subpartIndex)
		{
			if (!_partStyles.TryGetValue(partId, out var value))
			{
				return null;
			}
			if (subpartIndex >= value.Count)
			{
				return null;
			}
			return value[subpartIndex];
		}

		private void Initialize()
		{
			EditorMode = Device.IsUnityEditor && !Application.isPlaying;
			_textureStyles = new Dictionary<string, PartTextureStyle>();
			_partStyles = new Dictionary<string, List<PartStyleSet>>();
			_detailTextures = new Dictionary<string, TextureInfo>();
			_normalTextures = new Dictionary<string, TextureInfo>();
			SupportsModTextures = SystemInfo.copyTextureSupport.HasFlag(CopyTextureSupport.Basic);
			_craftQualitySettings = (EditorMode ? null : Game.Instance.QualitySettings.Crafts);
			UpdateQualitySettings();
			if (!EditorMode)
			{
				_craftQualitySettings.NormalMaps.Changed += OnTextureQualityChanged;
				_craftQualitySettings.DetailTextures.Changed += OnTextureQualityChanged;
			}
			LoadDefaultStyles();
			LoadStockTextureStyles();
		}

		private void LoadDefaultStyles()
		{
			PartTextureStyle partTextureStyle = LoadTextureStyle("Default", "None", PartTextureStyleOptions.Default, DefaultDetailTextureId, DefaultNormalMapTextureId, "Craft/Parts/Textures/Detail/" + DefaultDetailTextureId, "Craft/Parts/Textures/Normal/" + DefaultNormalMapTextureId, null);
			DefaultStyle = LoadStyle("Default", string.Empty, 0, "Default", null, new List<PartTextureStyle> { partTextureStyle }, isStyleExtension: false, hidden: false);
			DefaultTextureStyle = partTextureStyle;
		}

		private void LoadStockTextureStyles()
		{
			IResourceLoader resourceLoader;
			if (!EditorMode)
			{
				resourceLoader = Game.Instance.ResourceLoader;
			}
			else
			{
				IResourceLoader resourceLoader2 = new ResourceLoader();
				resourceLoader = resourceLoader2;
			}
			string xml = resourceLoader.LoadText("Craft/Parts/Textures/TextureStyles");
			LoadTextureStyles(xml, null);
		}

		private PartStyle LoadStyle(string styleId, string partId, int subpartIndex, string displayName, Dictionary<string, string> data, List<PartTextureStyle> textureStyles, bool isStyleExtension, bool hidden)
		{
			PartStyle partStyle = null;
			try
			{
				if (!_partStyles.TryGetValue(partId, out var value))
				{
					if (isStyleExtension)
					{
						this.LogError("Unable to find a part style set for part '" + partId + "'.");
						return null;
					}
					value = new List<PartStyleSet>(Math.Max(3, subpartIndex));
					_partStyles.Add(partId, value);
				}
				while (value.Count <= subpartIndex)
				{
					value.Add(new PartStyleSet(partId, subpartIndex));
				}
				PartStyleSet partStyleSet = value[subpartIndex];
				partStyle = partStyleSet.GetStyle(styleId);
				if (partStyle != null)
				{
					if (isStyleExtension)
					{
						displayName = partStyle.DisplayName;
					}
					partStyle.Update(displayName, data, textureStyles);
				}
				else
				{
					if (isStyleExtension)
					{
						this.LogError(string.Format("Unable to find a part style '{0}'. PartId: {1}, SubpartIndex: {2}", styleId, partId ?? "null", subpartIndex));
						return null;
					}
					partStyle = new PartStyle(styleId, partId, subpartIndex, displayName, data, textureStyles, invalid: false, hidden);
					partStyleSet.Add(partStyle);
				}
			}
			catch (Exception exception)
			{
				this.LogException(exception, string.Format("Unable to load style '{0}. PartId: {1}, SubpartIndex: {2}", styleId ?? "null", partId ?? "null", subpartIndex));
			}
			return partStyle;
		}

		private void LoadStyleSet(string partId, XElement xml)
		{
			int num = (int)xml.Attribute("subpartIndex");
			foreach (XElement item in xml.Elements("Style"))
			{
				string text = (string)item.Attribute("id");
				string displayName = (string)item.Attribute("displayName");
				bool valueOrDefault = (bool?)item.Attribute("hidden") == true;
				try
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					foreach (XElement item2 in item.Elements("Data").Elements("DataItem"))
					{
						string text2 = (string)item2.Attribute("key");
						string value = (string)item2.Attribute("value");
						try
						{
							dictionary.Add(text2, value);
						}
						catch (Exception exception)
						{
							string message = "Unable to load style data with key '" + (text2 ?? "null") + "'. " + string.Format("PartId: {0}, SubpartIndex: {1}, StyleId: {2}", partId ?? "null", num, text ?? "null");
							this.LogException(exception, message);
						}
					}
					List<PartTextureStyle> list = new List<PartTextureStyle>();
					foreach (XElement item3 in item.Elements("TextureStyles").Elements("TextureStyle"))
					{
						string key = (string)item3.Attribute("id");
						if (_textureStyles.TryGetValue(key, out var value2))
						{
							list.Add(value2);
						}
						else
						{
							this.LogError("Unable to find a texture style for part style '" + (text ?? "null") + ". " + string.Format("PartId: {0}, SubpartIndex: {1}", partId ?? "null", num));
						}
					}
					LoadStyle(text, partId, num, displayName, dictionary, list, isStyleExtension: false, valueOrDefault);
				}
				catch (Exception exception2)
				{
					this.LogException(exception2, string.Format("Unable to load style '{0}. PartId: {1}, SubpartIndex: {2}", text ?? "null", partId ?? "null", num));
				}
			}
		}

		private Texture2D LoadTexture(TextureInfo texture)
		{
			if (texture.Mod == null)
			{
				IResourceLoader resourceLoader;
				if (!EditorMode)
				{
					resourceLoader = Game.Instance.ResourceLoader;
				}
				else
				{
					IResourceLoader resourceLoader2 = new ResourceLoader();
					resourceLoader = resourceLoader2;
				}
				return resourceLoader.LoadTexture(texture.Path);
			}
			return texture.Mod.ResourceLoader.LoadAsset<Texture2D>(texture.Path);
		}

		private PartTextureStyle LoadTextureStyle(XElement xml, ILoadedMod mod)
		{
			string id = (string)xml.Attribute("id");
			string displayName = (string)xml.Attribute("displayName");
			PartTextureStyleOptions options = (PartTextureStyleOptions)(int)xml.Attribute("options");
			string text = (string)xml.Attribute("detailId");
			string text2 = (string)xml.Attribute("normalMapId");
			string detailPath = (string)xml.Attribute("detailPath");
			string normalPath = (string)xml.Attribute("normalMapPath");
			if (string.IsNullOrWhiteSpace(text))
			{
				text = DefaultDetailTextureId;
				detailPath = "Craft/Parts/Textures/Detail/" + DefaultDetailTextureId;
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				text2 = DefaultNormalMapTextureId;
				normalPath = "Craft/Parts/Textures/Normal/" + DefaultNormalMapTextureId;
			}
			return LoadTextureStyle(id, displayName, options, text, text2, detailPath, normalPath, mod);
		}

		private PartTextureStyle LoadTextureStyle(string id, string displayName, PartTextureStyleOptions options, string detailId, string normalId, string detailPath, string normalPath, ILoadedMod mod)
		{
			if (!_detailTextures.TryGetValue(detailId, out var value))
			{
				value = new TextureInfo(detailId, detailPath, _detailTextures.Count, mod);
				_detailTextures.Add(detailId, value);
			}
			else if (value.Path != detailPath)
			{
				Debug.Log("Detail texture for style '" + id + "' already exists. Existing texture will be replaced. Old path: " + value.Path + ", New path: " + detailPath);
				_detailTextures[detailId] = new TextureInfo(detailId, detailPath, value.Index, mod);
			}
			if (!_normalTextures.TryGetValue(normalId, out var value2))
			{
				value2 = new TextureInfo(normalId, normalPath, _normalTextures.Count, mod);
				_normalTextures.Add(normalId, value2);
			}
			else if (value2.Path != normalPath)
			{
				Debug.Log("Normal Map texture for style '" + id + "' already exists. Existing texture will be replaced. Old path: " + value2.Path + ", New path: " + normalPath);
				_normalTextures[normalId] = new TextureInfo(normalId, normalPath, value2.Index, mod);
			}
			if (_textureStyles.TryGetValue(id, out var value3))
			{
				value3.Update(displayName, options, detailId, normalId);
			}
			else
			{
				value3 = new PartTextureStyle(id, displayName, options, detailId, normalId);
				_textureStyles.Add(id, value3);
			}
			return value3;
		}

		private void OnTextureQualityChanged(object sender, EventArgs e)
		{
			ApplyQualitySettings();
		}

		private void UnloadTexture(Texture2D texture, TextureInfo info)
		{
			Resources.UnloadAsset(texture);
		}

		private void UnloadTextureArrays()
		{
			if (DetailTextures != null)
			{
				if (RuntimeCreation)
				{
					if (!EditorMode)
					{
						UnityEngine.Object.Destroy(DetailTextures);
					}
				}
				else
				{
					Resources.UnloadAsset(DetailTextures);
				}
				DetailTextures = null;
			}
			if (!(NormalMapTextures != null))
			{
				return;
			}
			if (RuntimeCreation)
			{
				if (!EditorMode)
				{
					UnityEngine.Object.Destroy(NormalMapTextures);
				}
			}
			else
			{
				Resources.UnloadAsset(NormalMapTextures);
			}
			NormalMapTextures = null;
		}

		private void UpdateQualitySettings()
		{
			DetailTexturesEnabled = true;
			NormalMapsEnabled = true;
			DetailTextureSize = PartTextureSize._1024;
			NormalMapTextureSize = PartTextureSize._1024;
			TexturePlatform = PartTexturePlatformType.Standalone;
			if (!EditorMode)
			{
				switch (_craftQualitySettings.DetailTextures.Value)
				{
				case CraftQualitySettings.DetailTextureQuality.High:
					DetailTextureSize = PartTextureSize._1024;
					break;
				case CraftQualitySettings.DetailTextureQuality.Medium:
					DetailTextureSize = PartTextureSize._512;
					break;
				case CraftQualitySettings.DetailTextureQuality.Low:
					DetailTextureSize = PartTextureSize._256;
					break;
				default:
					DetailTexturesEnabled = false;
					break;
				}
				switch (_craftQualitySettings.NormalMaps.Value)
				{
				case CraftQualitySettings.NormalMapQuality.High:
					NormalMapTextureSize = PartTextureSize._1024;
					break;
				case CraftQualitySettings.NormalMapQuality.Medium:
					NormalMapTextureSize = PartTextureSize._512;
					break;
				case CraftQualitySettings.NormalMapQuality.Low:
					NormalMapTextureSize = PartTextureSize._256;
					break;
				default:
					NormalMapsEnabled = false;
					break;
				}
				if (Device.IsAndroidBuild)
				{
					TexturePlatform = PartTexturePlatformType.Android;
				}
				else if (Device.IsIosBuild)
				{
					TexturePlatform = PartTexturePlatformType.iOS;
				}
				else
				{
					TexturePlatform = PartTexturePlatformType.Standalone;
				}
			}
		}

		private void UpdateTextureArray(Texture2DArray array, Texture2D texture, TextureInfo info, PartTextureSize size)
		{
			try
			{
				if (texture.format != array.format)
				{
					this.LogError("Unable to update the texture array for texture '" + info.Id + "' at path '" + info.Path + "'. The texture format does not match. " + $"Texture Format: {texture.format},  Texture Array Format: {array.format}");
					return;
				}
				if (texture.width != 1024 || texture.height != 1024)
				{
					throw new ArgumentException($"Texture '{Path.GetFileName(info.Path)}' from the mod '{info.Mod?.ModInfo?.Name}' has an invalid size of {texture.width}x{texture.height}. It needs to be 1024x1024.");
				}
				int num = size switch
				{
					PartTextureSize._512 => 1, 
					PartTextureSize._1024 => 0, 
					_ => 2, 
				};
				for (int i = num; i < texture.mipmapCount; i++)
				{
					Graphics.CopyTexture(texture, 0, i, array, info.Index, i - num);
				}
			}
			catch (Exception exception)
			{
				this.LogException(exception, "Unable to update the texture array for texture '" + info.Id + "' at path '" + info.Path + "'. It will be skipped.");
			}
		}
	}
}
