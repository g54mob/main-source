using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.Sim.Orbital.Interfaces;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public static class OrbitAnalyser
	{
		public delegate void OnEachEncounterCheckCallback(IOrbitNode nodeA, IOrbitNode nodeB, bool encounterFound, SoiEnterInfo encounterInfo);

		public delegate void OnEachExitParentCheckCallback(IOrbitNode parentNode, IOrbitNode childNode, bool childLeftParent);

		public delegate void OnEachIntersectParentCheckCallback(IOrbitNode parentNode, IOrbitNode childNode, bool childIntersectedParent);

		public delegate void SoiEnterSearchPointHandler(IOrbitPoint pointA, IOrbitPoint pointB, double distFromSoi, double nextEa, double eaStep, int iterationIndex);

		private struct EncounterSearchSegment
		{
			public static EncounterSearchSegment NaN = new EncounterSearchSegment(double.NaN, double.NaN);

			public double EndNu { get; set; }

			public double StartNu { get; set; }

			public EncounterSearchSegment(double startNu, double endNu)
			{
				StartNu = startNu;
				EndNu = endNu;
			}

			public static EncounterSearchSegment GetSegment(EncounterSearchSegment validRange, EncounterSearchSegment requestedRange)
			{
				if (validRange.IsNaN() || requestedRange.IsNaN())
				{
					return NaN;
				}
				if (validRange.IsWholeOrbit())
				{
					return requestedRange;
				}
				if (requestedRange.IsWholeOrbit())
				{
					return validRange;
				}
				if (requestedRange.Contains(validRange.StartNu, exclusiveEnd: true))
				{
					if (requestedRange.Contains(validRange.EndNu, exclusiveEnd: false))
					{
						return validRange;
					}
					return new EncounterSearchSegment(validRange.StartNu, requestedRange.EndNu);
				}
				if (validRange.Contains(requestedRange.StartNu, exclusiveEnd: true))
				{
					if (validRange.Contains(requestedRange.EndNu, exclusiveEnd: false))
					{
						return requestedRange;
					}
					return new EncounterSearchSegment(requestedRange.StartNu, validRange.EndNu);
				}
				return NaN;
			}

			public static EncounterSearchSegment GetSegment(EncounterSearchSegment validRange, EncounterSearchSegment requestedRange1, EncounterSearchSegment requestedRange2)
			{
				if (validRange.IsNaN())
				{
					return NaN;
				}
				if (requestedRange1.IsNaN())
				{
					if (requestedRange2.IsNaN())
					{
						return NaN;
					}
					return GetSegment(validRange, requestedRange2);
				}
				if (requestedRange2.IsNaN())
				{
					return GetSegment(validRange, requestedRange1);
				}
				double num = requestedRange1.EndNu + ((validRange.StartNu > requestedRange1.EndNu) ? (Math.PI * 2.0) : 0.0) - validRange.StartNu;
				double num2 = requestedRange2.EndNu + ((validRange.StartNu > requestedRange2.EndNu) ? (Math.PI * 2.0) : 0.0) - validRange.StartNu;
				bool num3 = Utilities.CompareDoubles(num, 0.0, 4E-12);
				bool flag = Utilities.CompareDoubles(num2, 0.0, 4E-12);
				if (num3)
				{
					return GetSegment(validRange, requestedRange2);
				}
				if (flag)
				{
					return GetSegment(validRange, requestedRange1);
				}
				EncounterSearchSegment requestedRange3 = ((num < num2) ? requestedRange1 : requestedRange2);
				return GetSegment(validRange, requestedRange3);
			}

			public EncounterSearchSegment AdvanceStart(double newStartNu)
			{
				if (double.IsNaN(newStartNu))
				{
					return NaN;
				}
				if (IsWholeOrbit() || Contains(newStartNu, exclusiveEnd: true))
				{
					return new EncounterSearchSegment(newStartNu, EndNu);
				}
				return NaN;
			}

			public bool Contains(double nu, bool exclusiveEnd)
			{
				if (StartNu >= EndNu)
				{
					if (exclusiveEnd)
					{
						if (!(nu >= StartNu))
						{
							return Utilities.CompareDoublesLt(nu, EndNu, 4E-12);
						}
						return true;
					}
					if (!(nu >= StartNu))
					{
						return nu <= EndNu;
					}
					return true;
				}
				if (exclusiveEnd)
				{
					if (StartNu <= nu)
					{
						return Utilities.CompareDoublesLt(nu, EndNu, 4E-12);
					}
					return false;
				}
				if (StartNu <= nu)
				{
					return nu <= EndNu;
				}
				return false;
			}

			public bool IsNaN()
			{
				if (!double.IsNaN(StartNu))
				{
					return double.IsNaN(EndNu);
				}
				return true;
			}

			public bool IsWholeOrbit()
			{
				return Utilities.CompareDoubles(StartNu.AsZeroTo2PI(), EndNu.AsZeroTo2PI(), 4E-12);
			}
		}

		public abstract class EncounterInfo
		{
			public IOrbitNode NodeA { get; private set; }

			public IOrbitNode NodeB { get; private set; }

			public IOrbitPoint PointA { get; private set; } = new OrbitPoint();

			public IOrbitPoint PointB { get; private set; } = new OrbitPoint();

			public double Time => PointA.Time;

			public virtual void Initialize(IOrbitNode nodeA, IOrbitNode nodeB, IOrbitPoint pointA, IOrbitPoint pointB)
			{
				NodeA = nodeA;
				NodeB = nodeB;
				PointA.Set(pointA);
				PointB.Set(pointB);
			}
		}

		public class SoiEnterInfo : EncounterInfo
		{
			public double Distance { get; private set; }

			public bool EncounterOccurred { get; private set; }

			public override void Initialize(IOrbitNode nodeA, IOrbitNode nodeB, IOrbitPoint pointA, IOrbitPoint pointB)
			{
				base.Initialize(nodeA, nodeB, pointA, pointB);
				InitializeInternal();
			}

			public void Initialize(SoiEnterInfo soiEnterInfo)
			{
				Initialize(soiEnterInfo.NodeA, soiEnterInfo.NodeB, soiEnterInfo.PointA, soiEnterInfo.PointB);
				InitializeInternal();
			}

			private void InitializeInternal()
			{
				Distance = (base.PointA.Position - base.PointB.Position).magnitude;
				EncounterOccurred = Distance < base.NodeA.SphereOfInfluence + base.NodeB.SphereOfInfluence;
			}
		}

		public class SoiExitInfo : EncounterInfo
		{
			public override void Initialize(IOrbitNode nodeA, IOrbitNode nodeB, IOrbitPoint escapePointA, IOrbitPoint escapePointB)
			{
				base.Initialize(nodeA, nodeB, escapePointA, escapePointB);
			}

			public void Initialize(SoiExitInfo soiExitInfo)
			{
				Initialize(soiExitInfo.NodeA, soiExitInfo.NodeB, soiExitInfo.PointA, soiExitInfo.PointB);
			}
		}

		public const double BinarySearchTargetStepDistanceSoiFactor = 10.0;

		public const double SoiEpsilon = 250.0;

		public static bool AnyChildrenLeavesParentSoi(IPlanetNode rootNode, OnEachExitParentCheckCallback callback)
		{
			bool flag = false;
			foreach (IPlanetNode childPlanet in rootNode.ChildPlanets)
			{
				bool flag2 = ChildLeavesParentSoi(rootNode, childPlanet);
				if (flag2 && !flag)
				{
					flag = true;
					if (callback == null)
					{
						break;
					}
				}
				callback?.Invoke(rootNode, childPlanet, flag2);
				if (AnyChildrenLeavesParentSoi(childPlanet, callback))
				{
					flag = true;
				}
			}
			return flag;
		}

		public static bool AnyChildrenSoiIntersectsParent(IPlanetNode rootNode, OnEachIntersectParentCheckCallback callback)
		{
			bool flag = false;
			foreach (IPlanetNode childPlanet in rootNode.ChildPlanets)
			{
				bool flag2 = ChildSoiIntersectsParent(rootNode, childPlanet);
				if (flag2 && !flag)
				{
					flag = true;
					if (callback == null)
					{
						break;
					}
				}
				callback?.Invoke(rootNode, childPlanet, flag2);
				if (AnyChildrenSoiIntersectsParent(childPlanet, callback))
				{
					flag = true;
				}
			}
			return flag;
		}

		public static SoiEnterInfo BinarySearch(IOrbitNode nodeA, IOrbitNode nodeB, double startNu, double endNu, double targetStepDistance, out double finalStep, string debugDescription, bool debugRightSide)
		{
			IOrbit orbit = nodeA.Orbit;
			OrbitMath.GetEaIterators(orbit, startNu, endNu, out var startEa, out var endEa);
			double angleBetween = OrbitMath.GetAngleBetween(startEa, endEa, nodeA.Orbit.Eccentricity, treatSameAsOnePeriod: true);
			int num = 0;
			double num2 = angleBetween * 0.5;
			double num3 = 0.0;
			double num4 = startEa + num2 * 1.0;
			IOrbitPoint orbitPoint = null;
			IOrbitPoint orbitPoint2 = null;
			double num5 = targetStepDistance * targetStepDistance;
			Vector3d vector3d = OrbitMath.GetPointAtEccentricAnomaly(orbit, num4).Position;
			do
			{
				num2 *= 0.5;
				double num6 = num4 + num2 * 1.0;
				IOrbitPoint pointAtEccentricAnomaly = OrbitMath.GetPointAtEccentricAnomaly(orbit, num6);
				IOrbitPoint pointAtTime = OrbitMath.GetPointAtTime(nodeB.Orbit, pointAtEccentricAnomaly.Time);
				double sqrMagnitude = (pointAtEccentricAnomaly.Position - pointAtTime.Position).sqrMagnitude;
				double num7 = num4 + num2 * -1.0;
				IOrbitPoint pointAtEccentricAnomaly2 = OrbitMath.GetPointAtEccentricAnomaly(orbit, num7);
				IOrbitPoint pointAtTime2 = OrbitMath.GetPointAtTime(nodeB.Orbit, pointAtEccentricAnomaly2.Time);
				double sqrMagnitude2 = (pointAtEccentricAnomaly2.Position - pointAtTime2.Position).sqrMagnitude;
				if (sqrMagnitude < sqrMagnitude2)
				{
					num4 = num6;
					orbitPoint = pointAtEccentricAnomaly;
					orbitPoint2 = pointAtTime;
				}
				else
				{
					num4 = num7;
					orbitPoint = pointAtEccentricAnomaly2;
					orbitPoint2 = pointAtTime2;
				}
				if (++num > 100)
				{
					break;
				}
				Vector3d position = orbitPoint.Position;
				num3 = (position - vector3d).sqrMagnitude;
				vector3d = position;
				if (debugDescription != null)
				{
					string arg = (debugRightSide ? "BinaryDrilldownRight_" : "BinaryDrilldownLeft_");
					Color color = new Color(1f, 0.5f, 0f);
					Color color2 = (debugRightSide ? Color.yellow : color);
					MapUtils.DrawDebugBall(nodeA.Parent, orbitPoint, $"{debugDescription}_A_{arg}_{num}", color2);
					MapUtils.DrawDebugBall(nodeB.Parent, orbitPoint2, $"{debugDescription}_B_{arg}_{num}", color2);
				}
			}
			while (num3 >= num5);
			IOrbitPoint pointAtEccentricAnomaly3 = OrbitMath.GetPointAtEccentricAnomaly(orbit, num4);
			IOrbitPoint pointAtTime3 = OrbitMath.GetPointAtTime(nodeB.Orbit, pointAtEccentricAnomaly3.Time);
			SoiEnterInfo result = OrbitMath.SoiEnterInfoPool.Get(nodeA, nodeB, pointAtEccentricAnomaly3, pointAtTime3);
			finalStep = num2;
			return result;
		}

		public static bool CheckForNodeEncounters(IReadOnlyList<IOrbitNode> nodes, double numYearsToCheck, int maxPeriods, OnEachEncounterCheckCallback callback, IIocContainer ioc, double soiEntryLocalMinimaModifier)
		{
			bool result = false;
			List<IOrbitNode> list = nodes.ToList();
			while (list.Count() > 0)
			{
				IOrbitNode orbitNode = list.FirstOrDefault();
				if (orbitNode != null && orbitNode.Orbit != null)
				{
					IOrbit orbit = orbitNode.Orbit;
					foreach (IOrbitNode node in nodes)
					{
						if (node == orbitNode || node.Parent != orbitNode.Parent)
						{
							continue;
						}
						ClosestEncounterSearchOptions search = new ClosestEncounterSearchOptions(ioc, orbitNode, node);
						search.LocalMinimaModifier = soiEntryLocalMinimaModifier;
						bool flag = false;
						SoiEnterInfo soiEnterInfo = null;
						double num = orbit.Time + orbit.Period + numYearsToCheck * 31536000.0;
						double num2 = orbit.Time;
						int num3 = 0;
						while (num2 < num && num3 < maxPeriods)
						{
							search.TimeToStartSearch = num2;
							soiEnterInfo = GetClosestEncounterInfo(search);
							if (soiEnterInfo != null && soiEnterInfo.EncounterOccurred)
							{
								flag = true;
								break;
							}
							num2 += orbit.Period;
							num3++;
						}
						callback?.Invoke(orbitNode, node, flag, soiEnterInfo);
						if (flag)
						{
							result = true;
						}
					}
				}
				list.Remove(orbitNode);
			}
			return result;
		}

		public static bool ChildLeavesParentSoi(IPlanetNode parent, IPlanetNode child)
		{
			return parent.SphereOfInfluenceExitDistance <= child.Orbit.ApoapsisDistance + child.SphereOfInfluenceExitDistance;
		}

		public static bool ChildSoiIntersectsParent(IPlanetNode parent, IPlanetNode child)
		{
			return child.Orbit.PeriapsisDistance - parent.PlanetData.Radius < child.SphereOfInfluence;
		}

		public static void GetAncestorsWithCommonParents(IOrbitNode nodeA, IOrbitNode nodeB, out IOrbitNode nodeAWithCommonParent, out IOrbitNode nodeBWithCommonParent)
		{
			nodeAWithCommonParent = nodeA;
			nodeBWithCommonParent = nodeB;
			if (nodeA.Parent != nodeB.Parent)
			{
				if (nodeA.NestedDepth > nodeB.NestedDepth)
				{
					nodeAWithCommonParent = nodeA.GetNodeAtDepth(nodeB.NestedDepth);
				}
				else if (nodeA.NestedDepth < nodeB.NestedDepth)
				{
					nodeBWithCommonParent = nodeB.GetNodeAtDepth(nodeA.NestedDepth);
				}
				while (nodeAWithCommonParent.Parent != nodeBWithCommonParent.Parent)
				{
					nodeAWithCommonParent = nodeAWithCommonParent.Parent;
					nodeBWithCommonParent = nodeBWithCommonParent.Parent;
				}
			}
		}

		public static void GetAscendingDescendingNodes(IOrbit orbitA, IOrbit orbitB, out IOrbitPoint ascending, out IOrbitPoint descending)
		{
			GetAscendingDescendingNodes(orbitA, orbitB, out ascending, out descending, out var _);
		}

		public static void GetAscendingDescendingNodes(IOrbit orbitA, IOrbit orbitB, out IOrbitPoint ascending, out IOrbitPoint descending, out Vector3d planeIntersection)
		{
			planeIntersection = Vector3d.Cross(orbitA.AngularMomentum, orbitB.AngularMomentum).normalized;
			double num = ((Vector3d.Dot(planeIntersection, orbitA.OrbitalPlaneRight.normalized) > 0.0) ? 1 : (-1));
			double num2 = Vector3d.SignedAngleRad(orbitA.EccentricityVector.normalized, planeIntersection * num, orbitA.AngularMomentum.normalized);
			if (num2 > 0.0)
			{
				num2 += Math.PI;
			}
			num2 = Math.Abs(num2);
			ascending = OrbitMath.GetPointAtTrueAnomaly(orbitA, num2);
			descending = OrbitMath.GetPointAtTrueAnomaly(orbitA, num2 + Math.PI);
		}

		public static void GetAscendingDescendingNodes(IOrbit orbitA, IOrbit orbitB, double trueAnomalyStart, double trueAnomalyEnd, out double? trueAnomalyAscending, out double? trueAnomalyDescending)
		{
			Vector3d normalized = Vector3d.Cross(orbitA.AngularMomentum, orbitB.AngularMomentum).normalized;
			double num = ((Vector3d.Dot(normalized, orbitA.OrbitalPlaneRight.normalized) > 0.0) ? 1 : (-1));
			double num2 = Vector3d.SignedAngleRad(orbitA.EccentricityVector.normalized, normalized, orbitA.AngularMomentum.normalized);
			if (num < 0.0)
			{
				num2 = Math.PI * 2.0 - num2;
			}
			trueAnomalyAscending = Math.Abs(num2).AsZeroTo2PI();
			trueAnomalyDescending = (trueAnomalyAscending.Value + Math.PI).AsZeroTo2PI();
			EncounterSearchSegment requestedRange = new EncounterSearchSegment(trueAnomalyStart, trueAnomalyEnd);
			if (orbitA.Eccentricity > 1.0)
			{
				requestedRange = EncounterSearchSegment.GetSegment(new EncounterSearchSegment(orbitA.TrueAnomaly, orbitA.TrueAnomalyAtApoapsis), requestedRange);
			}
			if (!requestedRange.Contains(trueAnomalyAscending.Value, exclusiveEnd: false))
			{
				trueAnomalyAscending = null;
			}
			if (!requestedRange.Contains(trueAnomalyDescending.Value, exclusiveEnd: false))
			{
				trueAnomalyDescending = null;
			}
		}

		public static SoiEnterInfo GetClosestEncounterInfo(ClosestEncounterSearchOptions search)
		{
			IOrbitNode nodeA = search.NodeA;
			IOrbitNode nodeB = search.NodeB;
			if (!IsEncounterCompatible(nodeA, nodeB))
			{
				return null;
			}
			EncounterSearchSegment naN = EncounterSearchSegment.NaN;
			EncounterSearchSegment encounterSearchSegment = EncounterSearchSegment.NaN;
			EncounterSearchSegment encounterSearchSegment2 = EncounterSearchSegment.NaN;
			EncounterSearchSegment encounterSearchSegment3 = new EncounterSearchSegment(search.StartNu, search.EndNu);
			if (nodeA.Orbit.Eccentricity > 1.0)
			{
				encounterSearchSegment3 = EncounterSearchSegment.GetSegment(new EncounterSearchSegment(nodeA.Orbit.TrueAnomaly, nodeA.Orbit.TrueAnomalyAtApoapsis), encounterSearchSegment3);
			}
			if (search.SearchSpace == ClosestEncounterSearchSpace.WholeOrbit)
			{
				double trueAnomaly = nodeA.Orbit.TrueAnomaly;
				naN = EncounterSearchSegment.GetSegment(encounterSearchSegment3, new EncounterSearchSegment(trueAnomaly, trueAnomaly));
			}
			else
			{
				GetPossibleCaptureRanges(nodeA.Orbit, nodeB.Orbit, nodeA.SphereOfInfluence, nodeB.SphereOfInfluence, out var startNuAFirst, out var endNuAFirst, out var startNuASecond, out var endNuASecond);
				EncounterSearchSegment requestedRange = new EncounterSearchSegment(startNuAFirst, endNuAFirst);
				EncounterSearchSegment requestedRange2 = new EncounterSearchSegment(startNuASecond, endNuASecond);
				if (requestedRange.IsNaN() && requestedRange2.IsNaN())
				{
					if (search.SearchSpace != ClosestEncounterSearchSpace.PossibleCaptureRangesOrWholeOrbit)
					{
						return null;
					}
					requestedRange = new EncounterSearchSegment(nodeA.Orbit.TrueAnomaly, nodeA.Orbit.TrueAnomaly);
				}
				naN = EncounterSearchSegment.GetSegment(encounterSearchSegment3, requestedRange, requestedRange2);
				encounterSearchSegment = EncounterSearchSegment.GetSegment(encounterSearchSegment3.AdvanceStart(naN.EndNu), requestedRange, requestedRange2);
				encounterSearchSegment2 = EncounterSearchSegment.GetSegment(encounterSearchSegment3.AdvanceStart(encounterSearchSegment.EndNu), requestedRange, requestedRange2);
			}
			SoiEnterInfo soiEnterInfo = null;
			SoiEnterInfo soiEnterInfo2 = null;
			SoiEnterInfo soiEnterInfo3 = null;
			if (!naN.IsNaN())
			{
				soiEnterInfo = GetClosestEncounterInfoRanged(search, naN.StartNu, naN.EndNu, AddDebugDesc(search.DebugDescription, "Segment1_"));
			}
			if ((soiEnterInfo == null || !soiEnterInfo.EncounterOccurred) && !encounterSearchSegment.IsNaN())
			{
				soiEnterInfo2 = GetClosestEncounterInfoRanged(search, encounterSearchSegment.StartNu, encounterSearchSegment.EndNu, AddDebugDesc(search.DebugDescription, "Segment2_"));
			}
			if ((soiEnterInfo == null || !soiEnterInfo.EncounterOccurred) && (soiEnterInfo2 == null || !soiEnterInfo2.EncounterOccurred) && !encounterSearchSegment2.IsNaN())
			{
				soiEnterInfo3 = GetClosestEncounterInfoRanged(search, encounterSearchSegment2.StartNu, encounterSearchSegment2.EndNu, AddDebugDesc(search.DebugDescription, "Segment3_"));
			}
			SoiEnterInfo soiEnterInfo4 = null;
			if (soiEnterInfo != null)
			{
				soiEnterInfo4 = soiEnterInfo;
				if (soiEnterInfo2 != null)
				{
					soiEnterInfo4 = ((soiEnterInfo.Distance < soiEnterInfo2.Distance) ? soiEnterInfo : soiEnterInfo2);
					if (soiEnterInfo3 != null)
					{
						soiEnterInfo4 = ((soiEnterInfo4.Distance < soiEnterInfo3.Distance) ? soiEnterInfo4 : soiEnterInfo3);
					}
				}
			}
			return soiEnterInfo4;
		}

		public static SoiEnterInfo GetClosestEncounterInfoExhaustive(IOrbitNode nodeA, IOrbitNode nodeB, double timeToStartSearch, double yearsToSearch, double timeStep = 1.0)
		{
			SoiEnterInfo result = null;
			double num = yearsToSearch * 365.0 * 24.0 * 60.0 * 60.0;
			double num2 = timeToStartSearch + num;
			IOrbit orbit = nodeA.Orbit;
			IOrbit orbit2 = nodeB.Orbit;
			for (double num3 = timeToStartSearch; num3 < num2; num3 += timeStep)
			{
				IOrbitPoint pointAtTime = OrbitMath.GetPointAtTime(orbit, num3);
				IOrbitPoint pointAtTime2 = OrbitMath.GetPointAtTime(orbit2, num3);
				SoiEnterInfo soiEnterInfo = OrbitMath.SoiEnterInfoPool.Get(nodeA, nodeB, pointAtTime, pointAtTime2);
				if (soiEnterInfo.EncounterOccurred)
				{
					result = soiEnterInfo;
					break;
				}
			}
			return result;
		}

		public static SoiEnterInfo GetClosestEncounterInfoRanged(ClosestEncounterSearchOptions search, double startNu, double endNu, string debugDescription)
		{
			IOrbitNode nodeA = search.NodeA;
			IOrbitNode nodeB = search.NodeB;
			SoiEnterInfo result = null;
			if (search.MapOptions.Targeting.UseBinarySearch)
			{
				if (!double.IsNaN(startNu))
				{
					double num = OrbitMath.GetAngleBetween(startNu, endNu, nodeA.Orbit.Eccentricity, treatSameAsOnePeriod: true) * 0.5;
					double num2 = startNu + num;
					double num3 = num2;
					double num4 = num2;
					if (debugDescription != null)
					{
						MapUtils.DrawDebugBall(nodeA.Parent, OrbitMath.GetPointAtTrueAnomaly(nodeA.Orbit, startNu), debugDescription + "_startPossibleEncounterSearchRight", Color.green);
						MapUtils.DrawDebugBall(nodeA.Parent, OrbitMath.GetPointAtTrueAnomaly(nodeA.Orbit, num3), debugDescription + "_endPossibleEncounterSearchRight", Color.red);
						MapUtils.DrawDebugBall(nodeA.Parent, OrbitMath.GetPointAtTrueAnomaly(nodeA.Orbit, num4), debugDescription + "_startPossibleEncounterSearchLeft", Color.green);
						MapUtils.DrawDebugBall(nodeA.Parent, OrbitMath.GetPointAtTrueAnomaly(nodeA.Orbit, endNu), debugDescription + "_endPossibleEncounterSearchLeft", Color.red);
					}
					double binarySearchTargetDistance = search.BinarySearchTargetDistance;
					double finalStep;
					SoiEnterInfo soiEnterInfo = BinarySearch(nodeA, nodeB, startNu, num3, binarySearchTargetDistance, out finalStep, debugDescription, debugRightSide: true);
					double finalStep2;
					SoiEnterInfo soiEnterInfo2 = BinarySearch(nodeA, nodeB, num4, endNu, binarySearchTargetDistance, out finalStep2, debugDescription, debugRightSide: false);
					result = ((!(soiEnterInfo.Distance < soiEnterInfo2.Distance)) ? soiEnterInfo2 : soiEnterInfo);
				}
			}
			else if (!double.IsNaN(startNu))
			{
				if (debugDescription != null)
				{
					MapUtils.DrawDebugBall(nodeA.Parent, OrbitMath.GetPointAtTrueAnomaly(nodeA.Orbit, startNu), debugDescription + "_startPossibleEncounterSearch", Color.green);
					MapUtils.DrawDebugBall(nodeA.Parent, OrbitMath.GetPointAtTrueAnomaly(nodeA.Orbit, endNu), debugDescription + "_endPossibleEncounterSearch", Color.red);
				}
				double num5 = double.MaxValue;
				bool flag = false;
				bool flag2 = false;
				IOrbitPoint closestPointA = null;
				IOrbitPoint closestPointB = null;
				IOrbitPoint orbitPoint = null;
				IOrbitPoint orbitPoint2 = null;
				IOrbitPoint orbitPoint3 = null;
				IOrbitPoint pointBPriorToClosest = null;
				IOrbitPoint pointAAfterClosest = null;
				IOrbitPoint pointBAfterClosest = null;
				OrbitMath.GetEaIterators(nodeA.Orbit, startNu, endNu, out var startEa, out var endEa);
				double num6 = 4.0 * search.LocalMinimaModifier;
				double eaStep = Math.PI * 2.0 / num6;
				double num7 = nodeA.SphereOfInfluence * nodeA.SphereOfInfluence + nodeB.SphereOfInfluence * nodeB.SphereOfInfluence;
				IOrbitPoint orbitPoint4 = null;
				bool flag3 = search.TimeToStartSearch != nodeA.Orbit.Time;
				if (flag3)
				{
					orbitPoint4 = nodeA.GetCurrentPoint();
					IOrbitPoint pointAtTime = nodeA.GetPointAtTime(search.TimeToStartSearch);
					nodeA.SetStateVectors(pointAtTime.Position, pointAtTime.Velocity, pointAtTime.Time);
				}
				int num8 = 0;
				IOrbitIterator iterator = OrbitMath.IteratorPool.GetIterator(nodeA.Orbit, startEa, endEa, eaStep);
				IOrbitPoint point;
				while (iterator.TryGetNext(out point))
				{
					double time = point.Time;
					IOrbitPoint pointAtTime2 = OrbitMath.GetPointAtTime(nodeB.Orbit, time);
					double sqrMagnitude = (point.Position - pointAtTime2.Position).sqrMagnitude;
					if (flag)
					{
						pointAAfterClosest = point;
						pointBAfterClosest = pointAtTime2;
						flag = false;
					}
					if (sqrMagnitude < num5)
					{
						num5 = sqrMagnitude;
						closestPointA = point;
						closestPointB = pointAtTime2;
						flag = true;
						orbitPoint3 = orbitPoint;
						pointBPriorToClosest = orbitPoint2;
						pointAAfterClosest = null;
						pointBAfterClosest = null;
					}
					orbitPoint = point;
					orbitPoint2 = pointAtTime2;
					if (sqrMagnitude < num7)
					{
						flag2 = true;
						break;
					}
					if (debugDescription != null)
					{
						MapUtils.DrawDebugBall(nodeA.Parent, point, debugDescription + $"_enterClosestA_{num8}", Color.blue);
						MapUtils.DrawDebugBall(nodeB.Parent, pointAtTime2, debugDescription + $"_enterClosestB_{num8}", Color.blue);
					}
					num8++;
				}
				if (closestPointA != null)
				{
					if (!flag2)
					{
						eaStep = IncreaseClosestPointPrecision(nodeA, nodeB, search.BinarySearchTargetDistance, ref closestPointA, ref closestPointB, orbitPoint3, pointBPriorToClosest, pointAAfterClosest, pointBAfterClosest, debugDescription);
						num5 = (closestPointA.Position - closestPointB.Position).sqrMagnitude;
						flag2 = num5 < num7;
					}
					if (flag2)
					{
						SeparatePointsToSoiIntersect(nodeA.Orbit, nodeB.Orbit, nodeA.SphereOfInfluence, nodeB.SphereOfInfluence, closestPointA, closestPointB, orbitPoint3, Mathd.Sqrt(num5), null, out closestPointA, out closestPointB);
					}
					result = OrbitMath.SoiEnterInfoPool.Get(nodeA, nodeB, closestPointA, closestPointB);
				}
				if (flag3)
				{
					nodeA.SetStateVectors(orbitPoint4.Position, orbitPoint4.Velocity, orbitPoint4.Time);
				}
			}
			return result;
		}

		public static float GetMaxValidationTime(IReadOnlyList<IOrbitNode> nodes, double numYearsToCheck, int maxPeriods, IIocContainer ioc, double soiEntryLocalMinimaModifier)
		{
			double num = 0.0;
			float num2 = 0f;
			int num3 = 0;
			List<IOrbitNode> list = nodes.ToList();
			while (list.Count() > 0)
			{
				IOrbitNode orbitNode = list.FirstOrDefault();
				if (orbitNode != null && orbitNode.Orbit != null)
				{
					_ = orbitNode.Orbit;
					foreach (IOrbitNode node in nodes)
					{
						if (node != orbitNode && node.Parent == orbitNode.Parent)
						{
							ClosestEncounterSearchOptions search = new ClosestEncounterSearchOptions(ioc, orbitNode, node);
							search.SearchSpace = ClosestEncounterSearchSpace.WholeOrbit;
							search.LocalMinimaModifier = soiEntryLocalMinimaModifier;
							SoiEnterInfo closestEncounterInfo = GetClosestEncounterInfo(search);
							if (closestEncounterInfo == null || !closestEncounterInfo.EncounterOccurred)
							{
								float realtimeSinceStartup = Time.realtimeSinceStartup;
								GetClosestEncounterInfo(search);
								num3++;
								num += (double)(Time.realtimeSinceStartup - realtimeSinceStartup);
							}
							num2 += Mathf.Min((float)(numYearsToCheck * 31536000.0 / orbitNode.Orbit.Period), maxPeriods);
						}
					}
				}
				list.Remove(orbitNode);
			}
			return (float)(num / (double)num3 * (double)num2);
		}

		public static bool GetNuRange(IOrbit orbit, double startDist, double endDist, bool ascent, out double startNu, out double endNu)
		{
			double? num = ((startDist == orbit.ApoapsisDistance) ? new double?(orbit.TrueAnomalyAtApoapsis) : ((startDist != orbit.PeriapsisDistance) ? OrbitMath.GetTrueAnomalyAtDistance(orbit.Eccentricity, startDist, orbit.SemiMajorAxis, orbit.TrueAnomalyAtApoapsis, orbit.ApoapsisDistance, orbit.PeriapsisDistance, ascent) : new double?(0.0)));
			double? num2 = ((endDist == orbit.ApoapsisDistance) ? new double?(orbit.TrueAnomalyAtApoapsis) : ((endDist != orbit.PeriapsisDistance) ? OrbitMath.GetTrueAnomalyAtDistance(orbit.Eccentricity, endDist, orbit.SemiMajorAxis, orbit.TrueAnomalyAtApoapsis, orbit.ApoapsisDistance, orbit.PeriapsisDistance, ascent) : new double?(0.0)));
			if (!num.HasValue || !num2.HasValue)
			{
				startNu = (endNu = double.NaN);
				return false;
			}
			startNu = num.Value;
			endNu = num2.Value;
			return true;
		}

		public static bool GetOverlapDistances(IOrbit orbitA, IOrbit orbitB, double bodyASoi, double bodyBSoi, out double startDist, out double endDist)
		{
			if (IsEncounterPossible(orbitA, orbitB, bodyASoi, bodyBSoi))
			{
				double max = ((orbitA.Eccentricity > 1.0) ? double.PositiveInfinity : orbitA.ApoapsisDistance);
				double num = ((orbitB.Eccentricity > 1.0) ? double.PositiveInfinity : orbitB.ApoapsisDistance);
				startDist = Mathd.Clamp(orbitB.PeriapsisDistance - (bodyASoi + bodyBSoi), orbitA.PeriapsisDistance, double.PositiveInfinity);
				endDist = Mathd.Clamp(num + bodyASoi + bodyBSoi, 0.0, max);
				return true;
			}
			startDist = (endDist = double.NaN);
			return false;
		}

		public static bool GetPossibleCaptureRanges(IOrbit orbitA, IOrbit orbitB, double bodyASoi, double bodyBSoi, out double startNuAFirst, out double endNuAFirst, out double startNuASecond, out double endNuASecond)
		{
			bool flag = IsEncounterPossible(orbitA, orbitB, bodyASoi, bodyBSoi);
			if (flag)
			{
				startNuAFirst = (endNuAFirst = orbitA.TrueAnomaly);
				startNuASecond = (endNuASecond = double.NaN);
				if (GetOverlapDistances(orbitA, orbitB, bodyASoi, bodyBSoi, out var startDist, out var endDist))
				{
					if (startDist == orbitA.PeriapsisDistance && endDist == orbitA.ApoapsisDistance)
					{
						startNuAFirst = (endNuAFirst = 0.0);
						startNuASecond = (endNuASecond = double.NaN);
					}
					else if (GetNuRange(orbitA, startDist, endDist, ascent: true, out startNuAFirst, out endNuAFirst) && GetNuRange(orbitA, endDist, startDist, ascent: false, out startNuASecond, out endNuASecond))
					{
					}
				}
			}
			else
			{
				startNuAFirst = (endNuAFirst = (startNuASecond = (endNuASecond = double.NaN)));
				flag = false;
			}
			return flag;
		}

		public static double GetSizeToSoiRatio(IOrbit orbitA, IOrbit orbitB, double orbitASoi, double orbitBSoi)
		{
			return (orbitA.ApoapsisDistanceEffective + orbitB.ApoapsisDistanceEffective) / (orbitASoi + orbitBSoi);
		}

		public static SoiEnterInfo GetSoiEnterInfo(IIocContainer ioc, IOrbitNode orbitNode, double endNu, double localMinimaModifier, string debugDescription)
		{
			IPlanetNode parent = orbitNode.Parent;
			SoiEnterInfo soiEnterInfo = null;
			for (int i = 0; i < parent.ChildPlanets.Count; i++)
			{
				IPlanetNode planetNode = parent.ChildPlanets[i];
				if (planetNode != orbitNode)
				{
					ClosestEncounterSearchOptions search = new ClosestEncounterSearchOptions(ioc, orbitNode, planetNode);
					search.EndNu = endNu;
					search.LocalMinimaModifier = localMinimaModifier;
					search.DebugDescription = debugDescription;
					SoiEnterInfo closestEncounterInfo = GetClosestEncounterInfo(search);
					if (closestEncounterInfo != null && closestEncounterInfo.EncounterOccurred && (soiEnterInfo == null || closestEncounterInfo.Time < soiEnterInfo.Time))
					{
						soiEnterInfo = closestEncounterInfo;
					}
				}
			}
			return soiEnterInfo;
		}

		public static SoiExitInfo GetSoiExitInfo(MapOrbitInfo orbitInfo)
		{
			SoiExitInfo result = null;
			IOrbitNode orbitNode = orbitInfo.OrbitNode;
			IPlanetNode parent = orbitNode.Parent.Parent;
			if (parent != null)
			{
				IOrbitPoint orbitPoint = null;
				IOrbitPoint orbitPoint2 = null;
				double? num = null;
				if (orbitNode.NodeExitsSoi)
				{
					IPlanetNode parent2 = orbitNode.Parent;
					orbitPoint = OrbitMath.GetEscapePoint(orbitNode.Orbit, parent2.SphereOfInfluenceExitDistance);
					if (orbitPoint != null)
					{
						num = orbitPoint.Time;
						if (parent.Orbit != null)
						{
							orbitPoint2 = OrbitMath.GetPointAtTime(parent.Orbit, num.Value);
						}
						else
						{
							orbitPoint2 = OrbitMath.PointsPool.Get();
							orbitPoint2.Set(parent.Position, parent.Velocity, 0.0, 0.0, num.Value);
						}
					}
				}
				if (orbitPoint != null && (orbitInfo.PlanetIntersection == null || orbitInfo.PlanetIntersection.Time > orbitPoint.Time))
				{
					result = OrbitMath.SoiExitInfoPool.Get(orbitNode, parent, orbitPoint, orbitPoint2);
				}
			}
			return result;
		}

		public static bool IsEncounterCompatible(IOrbitNode nodeA, IOrbitNode nodeB)
		{
			bool result = true;
			if (!MapUtils.SamePlanet(nodeA.Parent, nodeB.Parent))
			{
				result = false;
			}
			return result;
		}

		public static bool IsEncounterLocked(IOrbit orbitA, IOrbit orbitB, double orbitASoi, double orbitBSoi)
		{
			return GetSizeToSoiRatio(orbitA, orbitB, orbitASoi, orbitBSoi) < 1.0;
		}

		public static bool IsEncounterPossible(IOrbitNode nodeA, IOrbitNode nodeB)
		{
			bool flag = true;
			flag = IsEncounterCompatible(nodeA, nodeB);
			if (flag)
			{
				double num = nodeA.SphereOfInfluence + nodeB.SphereOfInfluence;
				GetAscendingDescendingNodes(nodeA.Orbit, nodeB.Orbit, out var ascending, out var descending);
				GetAscendingDescendingNodes(nodeB.Orbit, nodeA.Orbit, out var ascending2, out var descending2);
				flag = (ascending.Position - ascending2.Position).magnitude <= num || (descending.Position - descending2.Position).magnitude <= num || (ascending.Position - descending2.Position).magnitude <= num || (ascending2.Position - descending.Position).magnitude <= num;
			}
			return flag;
		}

		public static bool IsEncounterPossible(IOrbit orbitA, IOrbit orbitB, double orbitASoi, double orbitBSoi)
		{
			bool num = orbitA.ApoapsisDistanceEffective + orbitASoi > orbitB.PeriapsisDistance - orbitBSoi;
			bool flag = orbitA.PeriapsisDistance - orbitASoi < orbitB.ApoapsisDistanceEffective + orbitBSoi;
			return num && flag;
		}

		public static void SeparatePointsToSoiIntersect(IOrbit orbitA, IOrbit orbitB, double bodyASoi, double bodyBSoi, IOrbitPoint startPointA, IOrbitPoint startPointB, IOrbitPoint pointAOutside, double distanceBetweenStartPoints, SoiEnterSearchPointHandler perSearchPointAction, out IOrbitPoint pointAOnSoi, out IOrbitPoint pointBOnSoi)
		{
			double num = double.NaN;
			double num2 = bodyASoi + bodyBSoi;
			_ = (orbitA.Position - OrbitMath.GetPointAtTime(orbitB, orbitA.Time).Position).magnitude;
			double num3 = -1.0;
			double num4 = startPointA.EccentricAnomaly;
			pointAOnSoi = (pointBOnSoi = null);
			int num5 = 0;
			IOrbitIterator iterator = OrbitMath.IteratorPool.GetIterator(orbitA);
			bool flag = false;
			bool flag2 = false;
			while (!flag2 && num5 <= 100)
			{
				pointAOnSoi = iterator.GetAt(num4);
				pointBOnSoi = OrbitMath.GetPointAtTime(orbitB, pointAOnSoi.Time);
				num = (pointAOnSoi.Position - pointBOnSoi.Position).magnitude - num2;
				if (num < 0.0 && Mathd.Abs(num) < 250.0)
				{
					flag2 = true;
				}
				else
				{
					if (num > 0.0)
					{
						num4 -= num3;
						num3 *= 0.5;
						flag = true;
					}
					else if (flag)
					{
						num3 *= 0.5;
						flag = false;
					}
					num4 += num3;
				}
				perSearchPointAction?.Invoke(pointAOnSoi, pointBOnSoi, num, num4, num3, num5);
				if (double.IsNaN(num3))
				{
					Debug.LogError("eaStep is NaN");
					return;
				}
				num5++;
			}
			_ = 100;
		}

		private static string AddDebugDesc(string input, string addition)
		{
			if (input == null)
			{
				return null;
			}
			return input + addition;
		}

		private static double IncreaseClosestPointPrecision(IOrbitNode nodeA, IOrbitNode nodeB, double binarySearchTargetDistance, ref IOrbitPoint closestPointA, ref IOrbitPoint closestPointB, IOrbitPoint pointAPriorToClosest, IOrbitPoint pointBPriorToClosest, IOrbitPoint pointAAfterClosest, IOrbitPoint pointBAfterClosest, string debugDescription)
		{
			if (!Debug.isDebugBuild || pointAPriorToClosest == null)
			{
			}
			double finalStep = double.NaN;
			double finalStep2 = double.NaN;
			SoiEnterInfo soiEnterInfo = null;
			if (pointAPriorToClosest != null)
			{
				double trueAnomaly = pointAPriorToClosest.TrueAnomaly;
				double trueAnomaly2 = closestPointA.TrueAnomaly;
				soiEnterInfo = BinarySearch(nodeA, nodeB, trueAnomaly, trueAnomaly2, binarySearchTargetDistance, out finalStep, AddDebugDesc(debugDescription, "_increaseClosestPrior_"), debugRightSide: false);
			}
			SoiEnterInfo soiEnterInfo2 = null;
			if (pointAAfterClosest != null)
			{
				double trueAnomaly3 = closestPointA.TrueAnomaly;
				double trueAnomaly4 = pointAAfterClosest.TrueAnomaly;
				soiEnterInfo2 = BinarySearch(nodeA, nodeB, trueAnomaly3, trueAnomaly4, binarySearchTargetDistance, out finalStep2, AddDebugDesc(debugDescription, "_increaseClosestAfter_"), debugRightSide: true);
			}
			SoiEnterInfo soiEnterInfo3;
			double result;
			if (soiEnterInfo != null && soiEnterInfo2 != null)
			{
				if (soiEnterInfo.Distance < soiEnterInfo2.Distance)
				{
					soiEnterInfo3 = soiEnterInfo;
					result = finalStep;
				}
				else
				{
					soiEnterInfo3 = soiEnterInfo2;
					result = finalStep2;
				}
			}
			else if (soiEnterInfo != null)
			{
				soiEnterInfo3 = soiEnterInfo;
				result = finalStep;
			}
			else
			{
				soiEnterInfo3 = soiEnterInfo2;
				result = finalStep2;
			}
			closestPointA = soiEnterInfo3.PointA;
			closestPointB = soiEnterInfo3.PointB;
			return result;
		}

		private static bool SeparatePointsIsOnNearSide(IOrbitPoint pointAInside, IOrbitPoint pointBInside, IOrbitPoint pointAOutsideBefore)
		{
			double magnitude = (pointBInside.Position - pointAOutsideBefore.Position).magnitude;
			return (pointAInside.Position - pointAOutsideBefore.Position).magnitude < magnitude;
		}
	}
}
