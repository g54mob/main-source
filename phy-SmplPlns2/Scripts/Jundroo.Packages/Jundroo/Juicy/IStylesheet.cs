using System.Xml.Linq;

namespace Jundroo.Juicy
{
	public interface IStylesheet
	{
		WidgetStyle GetStyle(string name);

		void ProcessConstants(XElement element);
	}
}
