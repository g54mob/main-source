using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;
using ModApi.Ioc;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters
{
	public class SoiExitNodeScript : SoiEncounterNodeScript
	{
		private IChainNodeList _chainNodeList;

		public static SoiExitNodeScript Create(ICraftContext craftContext, LinkedListNode<IChainableOrbit> listNode, MapOrbitLine orbitLine, double trueAnomalyOnPrevious)
		{
			SoiExitNodeScript soiExitNodeScript = OrbitChainNodeScript.Create<SoiExitNodeScript>(craftContext, GetName(orbitLine.OrbitInfo), listNode, orbitLine, trueAnomalyOnPrevious);
			soiExitNodeScript.Initialize(orbitLine.Ioc, craftContext);
			return soiExitNodeScript;
		}

		public static OrbitAnalyser.SoiExitInfo GenerateExitInfo(SoiExitNodeScript exitNode)
		{
			IChainableOrbit chainableOrbit = exitNode.ListNode.Previous?.Value;
			if (chainableOrbit == null)
			{
				return null;
			}
			return OrbitAnalyser.GetSoiExitInfo(chainableOrbit.OrbitInfo);
		}

		protected override bool OnPreviousNodeOrbitChanged(IOrbit precedingOrbit)
		{
			bool flag = base.OnPreviousNodeOrbitChanged(precedingOrbit);
			if (flag)
			{
				OrbitAnalyser.SoiExitInfo soiExitInfo = GenerateExitInfo(this);
				if (soiExitInfo != null)
				{
					IPlanetNode parent = base.OrbitInfo.OrbitNode.Parent;
					if (MapUtils.SamePlanet(parent, soiExitInfo.NodeB as PlanetNode))
					{
						if (parent is SoiEncounterPlanetSimNode)
						{
							IOrbitPoint pointB = soiExitInfo.PointB;
							parent.SetStateVectors(pointB.Position, pointB.Velocity, soiExitInfo.Time);
						}
						OnTrueAnomalyOnPreviousOrbitChanged(soiExitInfo.PointA.TrueAnomaly);
						IOrbit newOrbit = OrbitChainNodeScript.CreatePredictedExitSoiOrbit(soiExitInfo);
						base.OrbitInfo.UpdateOrbit(newOrbit);
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					_chainNodeList.Remove(base.ListNode, deleteChildren: false, destroy: true, NodeListChangeCategory.Normal);
				}
			}
			return flag;
		}

		private static string GetName(MapOrbitInfo orbitInfo)
		{
			return $"SoiExitNode->{orbitInfo.OrbitNode.Parent.PlanetData.Name}";
		}

		private void Initialize(IIocContainer ioc, ICraftContext craftContext)
		{
			_chainNodeList = ioc.Resolve<IChainNodeList>(craftContext);
		}
	}
}
