using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml.Configuration
{
	public class XmlLayoutConfiguration : ScriptableObject
	{
		public Object XSDFile;

		public Object BaseXSDFile;

		[Tooltip("If this is set to true, then XmlLayout will no longer output a message to the console whenever the XSD file has been updated.")]
		public bool SuppressXSDUpdateMessage;

		[Tooltip("If this is set to true, then you will no longer receive Xml validation errors when using non-standard attributes.")]
		public bool AllowAnyAttribute;

		[Tooltip("If this is set to true, then XmlLayout will check all available assemblies for custom elements and attributes. If false, then only the assembly containing XmlLayout (and any specified by the 'Custom Assembly List' property) will be checked. Note: changing this property may trigger a recompilation.")]
		public bool ComprehensiveCustomElementAndAttributeCheck = true;

		[Tooltip("If 'Comprehensive Custom Element and Attribute Check' is false, then you can specify additional assemblies to check for custom elements and attributes here. Please use the full name for any assembly.")]
		public List<string> CustomAssemblyList = new List<string>();

		[Tooltip("If 'Comprehensive Custom Element and Attribute Check' is true, then you can specify assemblies to exclude here. Partial names are acceptable - assemblies starting with the names specified here will be excluded.")]
		public List<string> AssemblyExcludeList = new List<string>();

		[Tooltip("If this is set to true, then XmlLayout will handle selectable navigation events (such as when the Tab key is pressed).")]
		public bool UseXmlLayoutSelectableNavigation = true;
	}
}
