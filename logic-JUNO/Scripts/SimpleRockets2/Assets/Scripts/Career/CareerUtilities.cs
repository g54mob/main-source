using System.Xml.Linq;

namespace Assets.Scripts.Career
{
	public static class CareerUtilities
	{
		public static string GetExpressionString(XElement xml, string attributeName)
		{
			return xml.Attribute(attributeName)?.Value?.Replace(" AND ", " & ")?.Replace(" OR ", " | ");
		}
	}
}
