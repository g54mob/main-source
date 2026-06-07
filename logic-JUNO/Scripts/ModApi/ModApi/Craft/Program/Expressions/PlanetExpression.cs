using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Flight.Sim;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class PlanetExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private string _op;

		private string _opLower;

		private ExpressionResult _result;

		public override bool IsBoolean => false;

		public PlanetExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			if (_opLower == null)
			{
				_opLower = _op?.ToLower();
			}
			switch (_opLower)
			{
			case "tolatlongagl":
				_result.VectorValue = context.Craft.ConvertPlanetPositionToLatLongAgl(GetExpression(0).Evaluate(context).VectorValue);
				break;
			case "tolatlongasl":
				_result.VectorValue = context.Craft.ConvertPlanetPositionToLatLongAsl(GetExpression(0).Evaluate(context).VectorValue);
				break;
			case "toposition":
				_result.VectorValue = context.Craft.ConvertLatLongAglToPlanetPosition(GetExpression(0).Evaluate(context).VectorValue);
				break;
			case "topositionoversea":
				_result.VectorValue = context.Craft.ConvertLatLongAslToPlanetPosition(GetExpression(0).Evaluate(context).VectorValue);
				break;
			case "mass":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.PlanetData.Mass;
				});
				break;
			case "radius":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.PlanetData.Radius;
				});
				break;
			case "hasterrain":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.BoolValue = p.PlanetData.HasTerrainPhysics;
				});
				break;
			case "atmospheredensity":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.PlanetData.AtmosphereData.SurfaceAirDensity;
				});
				break;
			case "atmosphereheight":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.PlanetData.AtmosphereData.Height;
				});
				break;
			case "atmospherescale":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.PlanetData.AtmosphereData.ScaleHeight;
				});
				break;
			case "soiradius":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.SphereOfInfluence;
				});
				break;
			case "solarposition":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.VectorValue = p.SolarPosition;
				});
				break;
			case "childplanets":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					List<ExpressionListItem> listForModification = r.GetListForModification();
					listForModification.Clear();
					ExpressionListItem[] collection = ((IEnumerable<IPlanetNode>)p.ChildPlanets).Select((Func<IPlanetNode, ExpressionListItem>)((IPlanetNode x) => x.Name)).ToArray();
					listForModification.AddRange(collection);
					r.OnListModified();
				});
				break;
			case "crafts":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					List<ExpressionListItem> listForModification = r.GetListForModification();
					listForModification.Clear();
					foreach (INode dynamicNode in p.DynamicNodes)
					{
						if (dynamicNode is ICraftNode craftNode)
						{
							listForModification.Add(craftNode.Name);
						}
					}
					r.OnListModified();
				});
				break;
			case "craftids":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					List<ExpressionListItem> listForModification = r.GetListForModification();
					listForModification.Clear();
					foreach (INode dynamicNode2 in p.DynamicNodes)
					{
						if (dynamicNode2 is ICraftNode craftNode)
						{
							listForModification.Add(craftNode.NodeId);
						}
					}
					r.OnListModified();
				});
				break;
			case "parent":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.TextValue = ((p.Parent == null) ? string.Empty : p.Parent.Name);
				});
				break;
			case "structures":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					List<ExpressionListItem> listForModification = r.GetListForModification();
					listForModification.Clear();
					foreach (INode dynamicNode3 in p.DynamicNodes)
					{
						if (dynamicNode3 is IStructureNode structureNode)
						{
							listForModification.Add(structureNode.Name);
						}
					}
					r.OnListModified();
				});
				break;
			case "day":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = 6.2831854820251465 / p.PlanetData.AngularVelocity;
				});
				break;
			case "year":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.Period;
				});
				break;
			case "velocity":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.VectorValue = p.Orbit.Velocity;
				});
				break;
			case "apoapsis":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.VectorValue = p.Orbit.Apoapsis;
				});
				break;
			case "periapsis":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.VectorValue = p.Orbit.Periapsis;
				});
				break;
			case "period":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.Period;
				});
				break;
			case "apoapsistime":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.GetTimeToApoapsis();
				});
				break;
			case "periapsistime":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.GetTimeToPeriapsis();
				});
				break;
			case "inclination":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.Inclination;
				});
				break;
			case "eccentricity":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.Eccentricity;
				});
				break;
			case "meananomaly":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.MeanAnomaly;
				});
				break;
			case "meanmotion":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.MeanMotion;
				});
				break;
			case "periapsisargument":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.PeriapsisAngle;
				});
				break;
			case "rightascension":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.RightAscensionOfAscendingNode;
				});
				break;
			case "trueanomaly":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.TrueAnomaly;
				});
				break;
			case "semimajoraxis":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.SemiMajorAxis;
				});
				break;
			case "semiminoraxis":
				Evaluate(context, delegate(IPlanetNode p, ExpressionResult r)
				{
					r.NumberValue = p.Orbit.SemiMinorAxis;
				});
				break;
			}
			return _result;
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			return new List<ListItemInfo>
			{
				new ListItemInfo("mass", "Mass", "The mass of the planet in kilograms.", ListItemInfoType.Number),
				new ListItemInfo("radius", "Radius", "The radius of the planet in meters.", ListItemInfoType.Number),
				new ListItemInfo("hasTerrain", "Solid Ground", "Whether the planet has solid ground or not.", ListItemInfoType.Bool),
				new ListItemInfo("atmosphereDensity", "Surface Air Density", "The density of the atmosphere at sea level in kg per cubic meter.", ListItemInfoType.Number),
				new ListItemInfo("atmosphereHeight", "Atmosphere Height", "The height of the atmosphere in meters.", ListItemInfoType.Number),
				new ListItemInfo("atmosphereScale", "Atmosphere Scale Height", "A function of how quick the atmosphere fades out.", ListItemInfoType.Number),
				new ListItemInfo("soiradius", "SOI radius", "The radius of the sphere of influence in meters.", ListItemInfoType.Number),
				new ListItemInfo("solarPosition", "Solar Position", "The position of the planet relative to the sun.", ListItemInfoType.Vector),
				new ListItemInfo("childPlanets", "Child Planets", "The list of names of planet's children planets.", ListItemInfoType.List),
				new ListItemInfo("crafts", "Crafts", "The list of names of crafts inside the SOI of the planet.", ListItemInfoType.List),
				new ListItemInfo("craftids", "Craft IDs", "The list of IDs of crafts inside the SOI of the planet.", ListItemInfoType.List),
				new ListItemInfo("parent", "Parent", "The name of the planet's parent.", ListItemInfoType.Text),
				new ListItemInfo("structures", "Structures", "The list of names of structures on the planet.", ListItemInfoType.List),
				new ListItemInfo("day", "Length of day", "The time in seconds it takes for the planet to do a full rotation around itself.", ListItemInfoType.Number),
				new ListItemInfo("year", "Length of year", "The time in seconds it takes for the planet to do a full rotation around its parent.", ListItemInfoType.Number),
				new ListItemInfo("velocity", "Velocity", "The velocity vector.", ListItemInfoType.Vector),
				new ListItemInfo("apoapsis", "Orbit Apoapsis", "A vector indicating the apoapsis position in meters.", ListItemInfoType.Vector),
				new ListItemInfo("periapsis", "Orbit Periapsis", "A vector indicating the periapsis position in meters.", ListItemInfoType.Vector),
				new ListItemInfo("period", "Orbit Period", "The period of the planet's orbit in seconds.", ListItemInfoType.Number),
				new ListItemInfo("apoapsistime", "Orbit Apoapsis Time", "The time left for the planet to reach its apoapsis in seconds.", ListItemInfoType.Number),
				new ListItemInfo("periapsistime", "Orbit Periapsis Time", "The time left for the planet to reach its periapsis in seconds.", ListItemInfoType.Number),
				new ListItemInfo("inclination", "Orbit Inclination", "The inclination of the planet's orbit.", ListItemInfoType.Radians),
				new ListItemInfo("eccentricity", "Orbit Eccentricity", "The eccentricity of the planet's orbit.", ListItemInfoType.Number),
				new ListItemInfo("meananomaly", "Orbit Mean Anomaly", "The mean anomaly of the planet's orbit.", ListItemInfoType.Radians),
				new ListItemInfo("meanmotion", "Orbit Mean Motion", "The mean motion of the planet's orbit.", ListItemInfoType.Number),
				new ListItemInfo("periapsisargument", "Orbit Periapsis Argument", "The argument of the periapsis of the planet's orbit.", ListItemInfoType.Radians),
				new ListItemInfo("rightascension", "Orbit Right Ascension", "The right ascension node of the planet's orbit.", ListItemInfoType.Radians),
				new ListItemInfo("trueanomaly", "Orbit True Anomaly", "The true anomaly of the planet's orbit.", ListItemInfoType.Radians),
				new ListItemInfo("semimajoraxis", "Orbit Semi Major Axis", "The length of the semi major axis of the planet's orbit in meters.", ListItemInfoType.Number),
				new ListItemInfo("semiminoraxis", "Orbit Semi Minor Axis", "The length of the semi minor axis of the planet's orbit in meters.", ListItemInfoType.Number)
			};
		}

		public override string GetListValue(string listId)
		{
			return _op;
		}

		public override void SetListValue(string listId, string value)
		{
			_op = value;
		}

		private void Evaluate(IThreadContext context, Action<IPlanetNode, ExpressionResult> action)
		{
			string textValue = GetExpression(0).Evaluate(context).TextValue;
			IPlanetNode planet = context.Craft.GetPlanet(textValue);
			if (planet != null)
			{
				action(planet, _result);
			}
			else
			{
				_result.NumberValue = 0.0;
			}
		}
	}
}
