using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Craft.Parts.Styles.Editor
{
	public class PartStyleExtension : ScriptableObject
	{
		[SerializeField]
		[Tooltip("The part type ID of the part style being extended.")]
		private string _partId;

		[SerializeField]
		[Tooltip("The subpart index of the part style being extended.")]
		private int _subpartIndex;

		[SerializeField]
		[Tooltip("The style ID of the part style being extended.")]
		private string _styleId;

		[SerializeField]
		[Tooltip("The collection of texture style to be added to the part style.")]
		private List<PartTextureStyleDefinition> _textureStyles;

		public string PartId => _partId;

		public string StyleId => _styleId;

		public int SubpartIndex => _subpartIndex;

		public List<PartTextureStyleDefinition> TextureStyles => _textureStyles;

		public XElement CreateXml()
		{
			if (_textureStyles == null || _textureStyles.Count == 0)
			{
				return null;
			}
			return new XElement("PartStyleExtension", new XAttribute("partId", _partId), new XAttribute("subpartIndex", _subpartIndex), new XAttribute("styleId", _styleId), new XElement("TextureStyles", from x in _textureStyles
				where x.Id != null
				select new XElement("TextureStyle", new XAttribute("id", x.Id))));
		}
	}
}
