using System.Xml.Linq;

namespace Assets.Scripts.Tutorials
{
	public class TutorialInfo
	{
		public string Name { get; }

		public XElement Xml { get; }

		public TutorialInfo(string name, XElement xml)
		{
			Name = name;
			Xml = xml;
		}
	}
}
