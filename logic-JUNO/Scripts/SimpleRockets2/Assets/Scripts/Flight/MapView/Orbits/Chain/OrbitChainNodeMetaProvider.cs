using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain
{
	public class OrbitChainNodeMetaProvider
	{
		public enum TimeDisplayType
		{
			Hours = 0,
			Days = 1,
			DaysIfMoreThanADay = 2
		}

		private LinkedListNode<IChainableOrbit> _chainNode;

		private MapPlayerCraft _craft;

		public double ApoapsisDistance { get; private set; }

		public bool ApoapsisOnVisibleOrbit { get; private set; }

		public float? BurnTime { get; private set; }

		public float? DeltaV { get; private set; }

		public double Eccentricity { get; private set; }

		public double EndTime { get; private set; }

		public double Inclination { get; private set; }

		public MapOrbitLine.DebugInfoType OrbitDebugInfo { get; private set; }

		public double PeriapsisAngle { get; private set; }

		public double PeriapsisDistance { get; private set; }

		public bool PeriapsisOnVisibleOrbit { get; private set; }

		public double Period { get; private set; }

		public string PeriodText { get; private set; }

		public bool PlanetIntersection { get; private set; }

		public double RightAscentionOfAscendingNode { get; private set; }

		public double SemiMajorAxis { get; private set; }

		public double StartTime { get; private set; }

		public double? TimeToNode { get; private set; }

		public string TimeToNodeText { get; private set; }

		public string TransitTimeText { get; private set; }

		public double TrueAnomalyEnd { get; private set; }

		public double TrueAnomalyEndExcludingPlanetIntersection { get; private set; }

		public double TrueAnomalyStart { get; private set; }

		public string TypeDesc { get; private set; }

		public void SetCraft(MapPlayerCraft craft)
		{
			_craft = craft;
			if (craft != null)
			{
				SetNode(((IChainableOrbit)craft).ListNode);
			}
			else
			{
				SetNode(null);
			}
		}

		public void SetNode(LinkedListNode<IChainableOrbit> chainNode)
		{
			_chainNode = chainNode;
			UpdateStaticValues(chainNode);
		}

		public void UpdateDynamicValues()
		{
			if (_chainNode != null)
			{
				IChainableOrbit value = _chainNode.Value;
				TimeToNode = value.TimeToNode;
				if (TimeToNode.HasValue)
				{
					TimeToNodeText = ConvertTimeToText((float)TimeToNode.Value, TimeDisplayType.DaysIfMoreThanADay);
				}
				else
				{
					TimeToNodeText = "n/a";
				}
				try
				{
					IChainableOrbit value2 = _chainNode.Value;
					MapOrbitInfo orbitInfo = value2.OrbitInfo;
					IOrbit orbit = orbitInfo.OrbitNode.Orbit;
					TrueAnomalyEnd = orbitInfo.ValidTrueAnomalyEnd;
					TrueAnomalyEndExcludingPlanetIntersection = orbitInfo.ValidTrueAnomalyEndExcludingPlanetIntersection;
					TrueAnomalyStart = orbitInfo.ValidTrueAnomalyStart;
					PlanetIntersection = orbitInfo.PlanetIntersection != null;
					PeriapsisOnVisibleOrbit = orbitInfo.PeriapsisOnVisibleOrbit;
					ApoapsisOnVisibleOrbit = orbitInfo.ApoapsisOnVisibleOrbit;
					StartTime = orbitInfo.StartTime;
					EndTime = orbitInfo.EndTime;
					TransitTimeText = ConvertTimeToText((float)(EndTime - StartTime), TimeDisplayType.DaysIfMoreThanADay);
					Eccentricity = orbit.Eccentricity;
					ApoapsisDistance = orbit.ApoapsisDistance;
					Inclination = orbit.Inclination;
					PeriapsisDistance = orbit.PeriapsisDistance;
					PeriodText = ConvertTimeToText((float)orbit.Period, TimeDisplayType.DaysIfMoreThanADay);
					PeriapsisAngle = orbit.PeriapsisAngle;
					RightAscentionOfAscendingNode = orbit.RightAscensionOfAscendingNode;
					SemiMajorAxis = orbit.SemiMajorAxis;
					if (_craft.NodeNavigator.AutoBurnInProgress)
					{
						DeltaV = (float)_craft.NodeNavigator.AutoBurnNode.BurnData.DeltaVMagRemaining;
					}
					else if (value2 is ManeuverNodeScript)
					{
						ManeuverNodeScript maneuverNodeScript = value2 as ManeuverNodeScript;
						DeltaV = (float)maneuverNodeScript.GetDeltaVToCompleteManeuver().magnitude;
						BurnTime = (float)maneuverNodeScript.BurnData.BurnDuration;
					}
					else
					{
						DeltaV = null;
						BurnTime = null;
					}
					return;
				}
				catch (Exception)
				{
					Debug.Log("Error obtaining chain node info");
					return;
				}
			}
			TimeToNode = null;
			TimeToNodeText = "n/a";
		}

		private static string ConvertTimeToText(float time, TimeDisplayType displayType)
		{
			if (!double.IsNaN(time))
			{
				float num = time / 86400f;
				if (displayType == TimeDisplayType.Days || (displayType == TimeDisplayType.DaysIfMoreThanADay && num >= 1f))
				{
					if (num >= 1f)
					{
						if (num >= 365f)
						{
							int num2 = (int)num / 365;
							num %= 365f;
							return string.Format("<size=75%>{0:n0} {1}\n{2:n0} {3}</size>", num2, (num2 == 1) ? "year" : "years", num, (num == 1f) ? "day" : "days");
						}
						return string.Format("{0:n0} {1}", num, (num == 1f) ? "day" : "days");
					}
					return $"{num:.0}days";
				}
				int num3 = (int)(time % 86400f);
				int num4 = num3 / 3600;
				int num5 = (num3 - num4 * 60 * 60) / 60;
				int num6 = num3 % 60;
				return $"{num4:00}:{num5:00}:{num6:00}";
			}
			return "NaN";
		}

		private void UpdateStaticValues(LinkedListNode<IChainableOrbit> chainNode)
		{
			if (chainNode != null)
			{
				IChainableOrbit value = chainNode.Value;
				if (value is ManeuverNodeScript)
				{
					TypeDesc = "Burn Node";
				}
				else if (value is SoiExitNodeScript)
				{
					TypeDesc = "Exit Node";
				}
				else if (value is SoiEnterNodeScript)
				{
					TypeDesc = "Enter Node";
				}
				else if (value is MapPlayerCraft)
				{
					TypeDesc = "Craft";
				}
				else
				{
					Debug.Log("Unexpected chain node type");
				}
			}
			else
			{
				TypeDesc = "n/a";
			}
		}
	}
}
