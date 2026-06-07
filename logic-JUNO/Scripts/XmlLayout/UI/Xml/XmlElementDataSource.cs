using System;
using UnityEngine;

namespace UI.Xml
{
	[Serializable]
	public class XmlElementDataSource
	{
		[SerializeField]
		public string DataSource;

		[SerializeField]
		public ViewModelBindingType BindingType;

		[SerializeField]
		public XmlElement XmlElement;

		public XmlElementDataSource()
		{
		}

		public XmlElementDataSource(string dataSource, XmlElement xmlElement)
		{
			string text = dataSource.StripChars('{', '}');
			DataSource = text.StripChars('?', '#');
			XmlElement = xmlElement;
			XmlElement.DataSource = DataSource;
			if (!string.IsNullOrEmpty(DataSource))
			{
				if (text[0] == '?')
				{
					BindingType = ViewModelBindingType.OneWay;
				}
				else
				{
					BindingType = ViewModelBindingType.TwoWay;
				}
			}
		}

		public virtual bool Matches(string dataSource, string additionalDataSource = null)
		{
			return DataSource == dataSource;
		}
	}
}
