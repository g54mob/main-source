using System;
using UnityEngine;

namespace UI.Xml
{
	[Serializable]
	public class XmlLayoutResourceEntry
	{
		[SerializeField]
		public string path;

		[SerializeField]
		public UnityEngine.Object resource;
	}
}
