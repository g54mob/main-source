using System;
using UnityEngine;

namespace ModApi.Craft.Parts.Styles.Editor
{
	[Serializable]
	public class PartDefinitionSubpart
	{
		[SerializeField]
		[Tooltip("The display name for the subpart. This may show up in the part properties flyout for configuring part styles.")]
		private string _displayName;

		[SerializeField]
		[Tooltip("The xml name for the subpart. This should be unique between subparts for this part. It is used for saving part style selections to XML.")]
		private string _xmlName;

		[SerializeField]
		[Tooltip("The style set used for this subpart")]
		private PartStyleSetDefinition _styles;

		public string DisplayName => _displayName;

		public PartStyleSetDefinition Styles => _styles;

		public string XmlName => _xmlName;

		public PartDefinitionSubpart(string xmlName, string displayName, PartStyleSetDefinition styleSet)
		{
			_xmlName = xmlName;
			_displayName = displayName;
			_styles = styleSet;
		}
	}
}
