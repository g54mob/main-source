using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml
{
	[CreateAssetMenu(fileName = "MyCustomResourceDatabase", menuName = "XmlLayout/Resources/Custom Resource Database")]
	public class XmlLayoutCustomResourceDatabase : ScriptableObject
	{
		[Tooltip("This value will be pre-pended to all asset paths in this database. If 'Monitor Containing Folder' and 'Automatically Remove Entries' are set, then modifying this value will automatically update all entry paths to match.")]
		public string PathPrefix = string.Empty;

		public bool MonitorContainingFolder;

		public List<string> folders = new List<string>();

		public bool AutomaticallyRemoveEntries;

		public List<XmlLayoutResourceEntry> entries = new List<XmlLayoutResourceEntry>();

		public virtual void AddEntry(string path, Object resource)
		{
			entries.Add(new XmlLayoutResourceEntry
			{
				path = path,
				resource = resource
			});
		}
	}
}
