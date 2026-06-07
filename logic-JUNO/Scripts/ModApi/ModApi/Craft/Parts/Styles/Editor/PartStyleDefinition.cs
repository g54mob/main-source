using System;
using System.Collections.Generic;
using UnityEngine;

namespace ModApi.Craft.Parts.Styles.Editor
{
	[Serializable]
	public class PartStyleDefinition
	{
		[SerializeField]
		[Tooltip("A collection of data values that can be associated with this part style. These are the values that correspond to the keys defined on the part style set.")]
		private List<string> _dataValues;

		[SerializeField]
		[Tooltip("The display name for the style. This will show up in the part style spinner in the part properties flyout.")]
		private string _displayName;

		[SerializeField]
		[Tooltip("If selected then the style will be hidden in the designer from selection.")]
		private bool _hidden;

		[SerializeField]
		[Tooltip("The ID of the part style. This should be unique between all styles for a given part's subpart.")]
		private string _id;

		[SerializeField]
		[Tooltip("The collection of textures that are available for this part style.")]
		private List<PartTextureStyleDefinition> _textures;

		public List<string> DataValues => _dataValues;

		public string DisplayName => _displayName;

		public bool Hidden => _hidden;

		public string Id => _id;

		public List<PartTextureStyleDefinition> Textures => _textures;

		public static PartStyleDefinition Create(string id, string displayName, bool hidden)
		{
			return new PartStyleDefinition
			{
				_id = id,
				_displayName = displayName,
				_hidden = hidden,
				_dataValues = new List<string>(),
				_textures = new List<PartTextureStyleDefinition>()
			};
		}
	}
}
