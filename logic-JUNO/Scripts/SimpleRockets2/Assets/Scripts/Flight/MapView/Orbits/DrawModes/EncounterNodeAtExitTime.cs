using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes
{
	public class EncounterNodeAtExitTime : DrawMode
	{
		private HybridTime _hybridTime;

		public override ModeType Mode => ModeType.EncounterNodeAtExitTime;

		public override bool UpdateReferencePerPoint => false;

		public EncounterNodeAtExitTime()
		{
			_hybridTime = new HybridTime();
		}

		public override IPlanetNode GetReferenceNode(MapOrbitInfo orbitInfo)
		{
			return orbitInfo.OrbitNode.Parent;
		}

		public override void UpdateReferenceNode(ref DrawModeReferenceInfo refnfo, MapOrbitInfo orbitInfo, double pointTime)
		{
			if (orbitInfo.ChainNode != null)
			{
				LinkedListNode<IChainableOrbit> linkedListNode = orbitInfo.ChainNode.ListNode;
				do
				{
					linkedListNode = linkedListNode.Next;
				}
				while (linkedListNode != null && linkedListNode.Value is ManeuverNodeScript);
				SoiExitNodeScript soiExitNodeScript = ((linkedListNode != null && linkedListNode.Value is SoiExitNodeScript) ? (linkedListNode.Value as SoiExitNodeScript) : null);
				if (soiExitNodeScript != null)
				{
					refnfo.ReferenceNode = GetReferenceNode(orbitInfo);
					refnfo.ReferenceNodeTime = soiExitNodeScript.OrbitInfo.OrbitNode.Orbit.Time;
					refnfo.ReferenceNodeParentTime = base.GameTime.Time;
				}
				else
				{
					_hybridTime.UpdateReferenceNode(ref refnfo, orbitInfo, pointTime);
				}
			}
			else
			{
				_hybridTime.UpdateReferenceNode(ref refnfo, orbitInfo, pointTime);
			}
		}
	}
}
