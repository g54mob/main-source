using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Data;

namespace ModApi.Craft.Propulsion
{
	public class FuelGrain
	{
		public string Id { get; }

		public ILoadedMod Mod { get; }

		public string Name { get; }

		public UserCurve ThrustCurve { get; }

		public FuelGrain(XElement xml, ILoadedMod mod = null)
		{
			Id = xml.Attribute("id").Value;
			Name = xml.Attribute("name").Value;
			UserCurve userCurve = new UserCurve("thrustCurve", UserCurve.CurveStyle.Smooth, UserCurve.CurveWrapMode.Clamp);
			userCurve.SetKeyframes(xml.Attribute("thrustCurve").Value);
			ThrustCurve = userCurve;
			Mod = mod;
		}
	}
}
