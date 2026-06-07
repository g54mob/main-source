using System;
using System.IO;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Research
{
	public class TechItem
	{
		public enum TechItemIconType
		{
			File = 1,
			Resource = 2
		}

		public const string DefaultValue = "false";

		private Sprite _iconSprite;

		private Texture2D _iconTexture;

		public string Description { get; set; }

		public string DesignerPartName
		{
			get
			{
				if (Id.StartsWith("Part."))
				{
					return Id.Substring("Part.".Length);
				}
				return null;
			}
		}

		public string DisplayValue { get; }

		public string IconPath { get; set; }

		public TechItemIconType IconType { get; set; }

		public string Id { get; }

		public string InitialValue { get; set; }

		public string NameText { get; }

		public bool ValidationEnabled { get; set; } = true;

		public string ValueFormat { get; }

		public bool Visible { get; set; }

		public TechItem(XElement xml)
		{
			Id = xml.GetStringAttribute("id");
			NameText = xml.GetStringAttribute("name");
			DisplayValue = xml.GetStringAttribute("displayValue");
			ValueFormat = xml.GetStringAttribute("valueFormat");
			Description = xml.GetStringAttribute("description");
			Visible = xml.GetBoolAttribute("visible", defaultValue: true);
			IconType = TechItemIconType.Resource;
			InitialValue = xml.GetStringAttribute("value", "false");
		}

		public TechItem(string id, string displayFormat)
		{
			Id = id;
			NameText = displayFormat;
			IconType = TechItemIconType.Resource;
			InitialValue = "false";
		}

		public Sprite GetIcon()
		{
			if (_iconSprite == null)
			{
				LoadIcon();
			}
			return _iconSprite;
		}

		private void LoadIcon()
		{
			try
			{
				if (IconType == TechItemIconType.Resource)
				{
					if (string.IsNullOrWhiteSpace(IconPath))
					{
						Debug.LogError("Unable to load tech item icon '" + (NameText ?? string.Empty) + "' because the icon resource path was not specified.");
						return;
					}
					UnityEngine.Object obj = Game.Instance.ResourceLoader.Load<UnityEngine.Object>(IconPath);
					if (obj == null)
					{
						Debug.LogError("Unable to load tech item icon '" + (NameText ?? string.Empty) + "' because the icon resource could not be found at path '" + IconPath + "'.");
					}
					else if (obj is Texture2D texture2D)
					{
						_iconTexture = texture2D;
						_iconSprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
					}
					else if (obj is Sprite iconSprite)
					{
						_iconSprite = iconSprite;
					}
					else
					{
						Debug.LogError("Unable to load tech item icon '" + (NameText ?? string.Empty) + "' because the icon resource at path '" + IconPath + "' was not a Sprite or Texture2D.");
					}
				}
				else
				{
					string iconPath = IconPath;
					byte[] data = File.ReadAllBytes(iconPath);
					_iconTexture = new Texture2D(1, 1, TextureFormat.ARGB32, mipChain: false, linear: false);
					_iconTexture.wrapMode = TextureWrapMode.Clamp;
					_iconTexture.LoadImage(data, markNonReadable: true);
					_iconSprite = Sprite.Create(_iconTexture, new Rect(0f, 0f, _iconTexture.width, _iconTexture.height), new Vector2(0.5f, 0.5f), 100f);
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(iconPath);
					_iconTexture.name = "TechItemTexture_" + fileNameWithoutExtension;
					_iconSprite.name = "TechItemSprite_" + fileNameWithoutExtension;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Unable to load tech item icon '" + (NameText ?? string.Empty) + "'.");
				_iconSprite = null;
			}
		}
	}
}
