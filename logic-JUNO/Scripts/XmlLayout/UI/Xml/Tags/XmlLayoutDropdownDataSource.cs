using UnityEngine;

namespace UI.Xml.Tags
{
	public class XmlLayoutDropdownDataSource : XmlElementDataSource
	{
		[SerializeField]
		public string OptionsDataSource;

		public XmlLayoutDropdownDataSource(string dataSource, XmlElement xmlElement, string optionsDataSource)
			: base(dataSource, xmlElement)
		{
			OptionsDataSource = optionsDataSource;
		}

		public override bool Matches(string dataSource, string additionalDataSource = null)
		{
			if (!(DataSource == dataSource))
			{
				return OptionsDataSource == additionalDataSource;
			}
			return true;
		}
	}
}
