using System.Xml.Linq;

namespace ModApi.Craft.Program
{
	public interface IProgramSerializer
	{
		FlightProgram DeserializeFlightProgram(XElement programXml);

		XElement SerializeFlightProgram(FlightProgram program);
	}
}
