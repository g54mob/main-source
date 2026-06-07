using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters
{
	public class SoiEnterNodeScript : SoiEncounterNodeScript
	{
		private IChainNodeList _chainList;

		private IChainNodeSelection _chainNodeSelection;

		private IIocContainer _ioc;

		private IMapOptions _mapOptions;

		public OrbitAnalyser.SoiEnterInfo EncounterInfo { get; private set; } = new OrbitAnalyser.SoiEnterInfo();

		public static SoiEnterNodeScript Create(ICraftContext craftContext, LinkedListNode<IChainableOrbit> listNode, MapOrbitLine orbitLine, OrbitAnalyser.SoiEnterInfo enterInfo, double trueAnomalyOnPrevious)
		{
			SoiEnterNodeScript soiEnterNodeScript = OrbitChainNodeScript.Create<SoiEnterNodeScript>(craftContext, GetName(orbitLine.OrbitInfo), listNode, orbitLine, trueAnomalyOnPrevious);
			soiEnterNodeScript.Initialize(orbitLine.Ioc, craftContext, enterInfo);
			return soiEnterNodeScript;
		}

		public override void CheckForIncompatibleState()
		{
			base.CheckForIncompatibleState();
			if (!OrbitAnalyser.IsEncounterCompatible(base.ListNode.Previous.Value.OrbitInfo.OrbitNode, EncounterInfo.NodeB))
			{
				_chainList.Remove(base.ListNode, deleteChildren: false, destroy: true, NodeListChangeCategory.Normal);
			}
		}

		protected override bool OnPreviousNodeOrbitChanged(IOrbit precedingOrbit)
		{
			bool flag = base.OnPreviousNodeOrbitChanged(precedingOrbit);
			if (flag)
			{
				bool flag2 = false;
				MapOrbitInfo orbitInfo = base.ListNode.Previous.Value.OrbitInfo;
				ClosestEncounterSearchOptions search = new ClosestEncounterSearchOptions(_ioc, orbitInfo.OrbitNode, EncounterInfo.NodeB);
				search.DebugDescription = (OrbitChainNodeScript.ShouldShowDebug(_chainNodeSelection, base.ListNode.Value) ? "SoiEnterVerifyEncounterStillExists" : null);
				OrbitAnalyser.SoiEnterInfo closestEncounterInfo = OrbitAnalyser.GetClosestEncounterInfo(search);
				if (closestEncounterInfo != null && closestEncounterInfo.EncounterOccurred)
				{
					if (orbitInfo.PlanetIntersection == null || orbitInfo.PlanetIntersection.Time > closestEncounterInfo.PointA.Time)
					{
						IOrbitNode orbitNode = base.OrbitInfo.OrbitNode;
						_ = orbitNode.Parent;
						IOrbitPoint pointA = closestEncounterInfo.PointA;
						IOrbitPoint pointB = closestEncounterInfo.PointB;
						orbitNode.Parent.SetStateVectors(pointB.Position, pointB.Velocity, closestEncounterInfo.Time);
						orbitNode.SetStateVectors(pointA.Position - pointB.Position, pointA.Velocity - pointB.Velocity, closestEncounterInfo.Time);
						OnTrueAnomalyOnPreviousOrbitChanged(pointA.TrueAnomaly);
						base.OrbitInfo.UpdateOrbit(orbitNode.Orbit);
					}
					else
					{
						flag2 = true;
					}
				}
				else
				{
					flag2 = true;
				}
				if (flag2)
				{
					_chainList.Remove(base.ListNode, deleteChildren: false, destroy: true, NodeListChangeCategory.Normal);
					flag = false;
				}
			}
			return flag;
		}

		private static string GetName(MapOrbitInfo orbitInfo)
		{
			return $"SoiEnterNode->{orbitInfo.OrbitNode.Parent.PlanetData.Name}";
		}

		private void Initialize(IIocContainer ioc, ICraftContext craftContext, OrbitAnalyser.SoiEnterInfo encounterInfo)
		{
			_ioc = ioc;
			EncounterInfo.Initialize(encounterInfo);
			_chainList = ioc.Resolve<IChainNodeList>(craftContext);
			_chainNodeSelection = ioc.Resolve<IChainNodeSelection>(craftContext);
			_mapOptions = ioc.Resolve<IMapOptions>();
		}
	}
}
