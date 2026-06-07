using System;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Ui
{
	public class BuildUserInterfaceXmlRequest
	{
		private Action<IXmlLayoutController> _onLayoutRebuilt;

		private XDocument _xdoc;

		private string _xml;

		public Action<IXmlLayoutController> OnLayoutRebuilt => _onLayoutRebuilt;

		public string UserInterfaceId { get; }

		public string Xml
		{
			get
			{
				if (_xdoc != null)
				{
					_xml = _xdoc.ToString(SaveOptions.DisableFormatting);
					_xdoc = null;
				}
				return _xml;
			}
			set
			{
				_xdoc = null;
				_xml = value;
			}
		}

		public XDocument XmlDocument
		{
			get
			{
				if (_xdoc == null)
				{
					_xdoc = XDocument.Parse(_xml);
					_xml = null;
				}
				return _xdoc;
			}
			set
			{
				_xdoc = value;
				_xml = null;
			}
		}

		private BuildUserInterfaceXmlRequest(string id, string xml)
		{
			UserInterfaceId = id ?? string.Empty;
			_xml = xml;
		}

		public static BuildUserInterfaceXmlRequest CreateFromResource(string xmlPath, string userInterfaceId = null)
		{
			TextAsset resource = Game.Instance.UserInterface.ResourceDatabase.GetResource<TextAsset>(xmlPath);
			if (resource == null)
			{
				throw new Exception("UI XML not found at path: " + xmlPath);
			}
			return new BuildUserInterfaceXmlRequest(userInterfaceId ?? xmlPath, resource.text);
		}

		public static BuildUserInterfaceXmlRequest CreateFromXml(string xml, string userInterfaceId = null)
		{
			return new BuildUserInterfaceXmlRequest(userInterfaceId, xml);
		}

		public void AddOnLayoutRebuiltAction(Action<IXmlLayoutController> onLayoutRebuilt)
		{
			_onLayoutRebuilt = (Action<IXmlLayoutController>)Delegate.Combine(_onLayoutRebuilt, onLayoutRebuilt);
		}
	}
}
