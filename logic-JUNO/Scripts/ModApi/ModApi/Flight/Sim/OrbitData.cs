using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Flight.Sim
{
	[Serializable]
	public class OrbitData
	{
		[SerializeField]
		private double _argumentOfPeriapsis;

		[SerializeField]
		private double _eccentricity;

		[SerializeField]
		private double _inclination;

		[SerializeField]
		private bool _prograde;

		[SerializeField]
		private double _rightAscensionOfAscendingNode;

		[SerializeField]
		private double _semiMajorAxis;

		[SerializeField]
		private double _time;

		[SerializeField]
		private double _trueAnomaly;

		public double ArgumentOfPeriapsis
		{
			get
			{
				return _argumentOfPeriapsis;
			}
			set
			{
				_argumentOfPeriapsis = value;
			}
		}

		public double Eccentricity
		{
			get
			{
				return _eccentricity;
			}
			set
			{
				_eccentricity = value;
			}
		}

		public double Inclination
		{
			get
			{
				return _inclination;
			}
			set
			{
				_inclination = value;
			}
		}

		public bool Prograde
		{
			get
			{
				return _prograde;
			}
			set
			{
				_prograde = value;
			}
		}

		public double RightAscensionOfAscendingNode
		{
			get
			{
				return _rightAscensionOfAscendingNode;
			}
			set
			{
				_rightAscensionOfAscendingNode = value;
			}
		}

		public double SemiMajorAxis
		{
			get
			{
				return _semiMajorAxis;
			}
			set
			{
				_semiMajorAxis = value;
			}
		}

		public double Time
		{
			get
			{
				return _time;
			}
			set
			{
				_time = value;
			}
		}

		public double TrueAnomaly
		{
			get
			{
				return _trueAnomaly;
			}
			set
			{
				_trueAnomaly = value;
			}
		}

		public OrbitData(XElement xml)
		{
			ArgumentOfPeriapsis = (double)xml.Attribute("argumentOfPeriapsis");
			Eccentricity = (double)xml.Attribute("eccentricity");
			Inclination = (double)xml.Attribute("inclination");
			Prograde = xml.GetBoolAttribute("prograde");
			RightAscensionOfAscendingNode = (double)xml.Attribute("rightAscensionOfAscendingNode");
			SemiMajorAxis = (double)xml.Attribute("semiMajorAxis");
			XAttribute xAttribute = xml.Attribute("time");
			Time = ((xAttribute != null) ? ((double)xAttribute) : (-1.0));
			TrueAnomaly = (double)xml.Attribute("trueAnomaly");
		}

		public OrbitData()
		{
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Orbit");
			xElement.SetAttributeValue("argumentOfPeriapsis", ArgumentOfPeriapsis);
			xElement.SetAttributeValue("eccentricity", Eccentricity);
			xElement.SetAttributeValue("inclination", Inclination);
			xElement.SetAttributeValue("prograde", Prograde);
			xElement.SetAttributeValue("rightAscensionOfAscendingNode", RightAscensionOfAscendingNode);
			xElement.SetAttributeValue("semiMajorAxis", SemiMajorAxis);
			xElement.SetAttributeValue("time", Time);
			xElement.SetAttributeValue("trueAnomaly", TrueAnomaly);
			return xElement;
		}
	}
}
