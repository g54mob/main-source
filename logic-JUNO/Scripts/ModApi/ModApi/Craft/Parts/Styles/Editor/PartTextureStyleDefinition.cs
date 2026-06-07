using System;
using System.Xml.Linq;
using ModApi.Common.Attributes;
using UnityEngine;

namespace ModApi.Craft.Parts.Styles.Editor
{
	[CreateAssetMenu(fileName = "New Part Texture Style", menuName = "SimpleRockets 2/Parts/Part Texture Style")]
	public class PartTextureStyleDefinition : ScriptableObject
	{
		[SerializeField]
		[Tooltip("The unique ID of the texture. This should be unique between all part textures.")]
		private string _id;

		[SerializeField]
		[Tooltip("The display name of the texture. This will show up in the part properties flyout when selecting a texture for a part.")]
		private string _displayName;

		[SerializeField]
		[Tooltip("The detail texture for this texture style. This should point to a texture here: Assets/Content/Craft/Parts/Textures/Detail/'.Detail textures should be a base gray color (0.5). Areas lighter than 0.5 will lighten the part color and areas less that 0.5 will darken it.")]
		private Texture2D _detailTexture;

		[SerializeField]
		[Tooltip("The normal map texture for this texture style. This should point to a texture here: Assets/Content/Craft/Parts/Textures/Normal/'.")]
		private Texture2D _normalMapTexture;

		[SerializeField]
		[EnumFlagButtons]
		[Tooltip("The options available to this texture style.")]
		private PartTextureStyleOptions _options;

		public Texture2D DetailTexture => _detailTexture;

		public string DisplayName => _displayName;

		public string Id => _id;

		public Texture2D NormalMapTexture => _normalMapTexture;

		public PartTextureStyleOptions Options => _options;

		public XElement CreateXml()
		{
			if (Id == null)
			{
				return null;
			}
			string text = null;
			if (DetailTexture != null)
			{
				string text2 = (Project.IsEditorModProject ? "Assets/Content/Craft/Parts/Textures/Detail/" : "Craft/Parts/Textures/Detail/");
				text = (Project.IsEditorModProject ? AssetDatabase.GetAssetPath(DetailTexture) : AssetDatabase.GetAssetResourcesPath(DetailTexture));
				if (!text.StartsWith(text2, StringComparison.Ordinal))
				{
					Debug.LogError("Detail texture '" + DetailTexture.name + "' for texture style '" + Id + "' is not located in detail texture folder '" + text2 + "'. Its actual location is '" + text + "'.", this);
				}
			}
			string text3 = null;
			if (NormalMapTexture != null)
			{
				string text4 = (Project.IsEditorModProject ? "Assets/Content/Craft/Parts/Textures/Normal/" : "Craft/Parts/Textures/Normal/");
				text3 = (Project.IsEditorModProject ? AssetDatabase.GetAssetPath(NormalMapTexture) : AssetDatabase.GetAssetResourcesPath(NormalMapTexture));
				if (!text3.StartsWith(text4, StringComparison.Ordinal))
				{
					Debug.LogError("Normal map texture '" + NormalMapTexture.name + "' for texture style '" + Id + "' is not located in normal map texture folder '" + text4 + "'. Its actual location is '" + text3 + "'.", this);
				}
			}
			return new XElement("TextureStyle", new XAttribute("id", Id), new XAttribute("displayName", DisplayName ?? Id), new XAttribute("options", (int)Options), (DetailTexture == null) ? null : new XAttribute("detailId", DetailTexture.name), (NormalMapTexture == null) ? null : new XAttribute("normalMapId", NormalMapTexture.name), (text == null) ? null : new XAttribute("detailPath", text), (text3 == null) ? null : new XAttribute("normalMapPath", text3));
		}
	}
}
