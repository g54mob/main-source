using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using ModApi.Flight.Sim;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Scripts.State;

namespace Assets.Scripts.Menu.ListView
{
	public class ActiveCraftsDetails
	{
		private DetailsPropertyScript _altitude;

		private DetailsPropertyScript _apoapsis;

		private DetailsWidgetGroup _crewGroup;

		private List<DetailsTextScript> _crewText;

		private DetailsPropertyScript _eccentricity;

		private DetailsPropertyScript _inclination;

		private DetailsWidgetGroup _orbitGroup;

		private DetailsPropertyScript _periapsis;

		private DetailsPropertyScript _period;

		private DetailsPropertyScript _planet;

		private DetailsPropertyScript _resumable;

		private DetailsPropertyScript _velocity;

		public bool IsResumable { get; private set; }

		public bool IsPlayerAllowed { get; private set; }

		public ActiveCraftsDetails(ListViewDetailsScript listViewDetails)
		{
			_planet = listViewDetails.Widgets.AddProperty("Planet");
			_velocity = listViewDetails.Widgets.AddProperty("Velocity");
			_altitude = listViewDetails.Widgets.AddProperty("Altitude");
			_resumable = listViewDetails.Widgets.AddProperty("Resumable");
			_orbitGroup = listViewDetails.Widgets.AddGroup();
			_orbitGroup.AddHeader("Orbit");
			_eccentricity = _orbitGroup.AddProperty("Eccentricity");
			_inclination = _orbitGroup.AddProperty("Inclination");
			_apoapsis = _orbitGroup.AddProperty("Apoapsis");
			_periapsis = _orbitGroup.AddProperty("Periapsis");
			_period = _orbitGroup.AddProperty("Period");
			_orbitGroup.Visible = false;
			_crewGroup = listViewDetails.Widgets.AddGroup();
			_crewGroup.AddHeader("Crew");
			_crewText = new List<DetailsTextScript>();
			_crewGroup.Visible = false;
		}

		public void UpdateDetails(ICraftNodeData craftNodeData, SolarSystemDataScript solarSystemData)
		{
			_planet.ValueText = craftNodeData.ParentName;
			_velocity.ValueText = Units.GetVelocityString((int)craftNodeData.Velocity.magnitude);
			IsResumable = craftNodeData.HasCommandPod && craftNodeData.AllowPlayerControl;
			IsPlayerAllowed = craftNodeData.AllowPlayerControl;
			_resumable.ValueText = IsResumable.ToString();
			_crewGroup.Visible = false;
			PlanetDataScript planetData = solarSystemData.GetPlanetData(craftNodeData.ParentName);
			if (craftNodeData.OrbitData != null && !craftNodeData.InContactWithPlanet)
			{
				double num = craftNodeData.Position.magnitude - planetData.Radius;
				_altitude.ValueText = Units.GetDistanceString((float)num);
				OrbitData orbitData = craftNodeData.OrbitData;
				Orbit orbit = new Orbit(craftNodeData.OrbitData, planetData.Mass);
				if (orbitData.Eccentricity <= 1.0 && orbit.ApoapsisDistance > planetData.Radius)
				{
					_apoapsis.ValueText = Units.GetDistanceString((float)orbit.ApoapsisDistance);
				}
				else
				{
					_apoapsis.ValueText = "N/A";
				}
				if (orbit.PeriapsisDistance > planetData.Radius)
				{
					_periapsis.ValueText = Units.GetDistanceString((float)orbit.PeriapsisDistance);
				}
				else
				{
					_periapsis.ValueText = "N/A";
				}
				if (orbit.PeriapsisDistance > planetData.Radius && !double.IsNaN(orbit.Period))
				{
					TimeSpan timeSpan = new TimeSpan(0, 0, (int)orbit.Period);
					if (timeSpan.TotalDays <= 2.0)
					{
						_period.ValueText = $"{timeSpan.TotalHours:n} hours";
					}
					else
					{
						_period.ValueText = $"{timeSpan.TotalDays:n} days";
					}
				}
				else
				{
					_period.ValueText = "N/A";
				}
				_orbitGroup.Visible = true;
				_eccentricity.ValueText = craftNodeData.OrbitData.Eccentricity.ToString("0.00");
				double num2 = craftNodeData.OrbitData.Inclination * 57.29578;
				_inclination.ValueText = num2.ToString("0.00") + "°";
			}
			else
			{
				_orbitGroup.Visible = false;
				_altitude.ValueText = "Ground";
			}
		}

		public void UpdateCrew(List<CrewMember> crewMembers)
		{
			_crewGroup.Visible = crewMembers.Count > 0;
			int num = 0;
			for (num = 0; num < crewMembers.Count; num++)
			{
				while (_crewText.Count <= num)
				{
					_crewText.Add(_crewGroup.AddText(string.Empty));
				}
				CrewMember crewMember = crewMembers[num];
				_crewText[num].gameObject.SetActive(value: true);
				_crewText[num].Text = crewMember.Name;
			}
			for (; num < _crewText.Count; num++)
			{
				_crewText[num].gameObject.SetActive(value: false);
			}
		}
	}
}
