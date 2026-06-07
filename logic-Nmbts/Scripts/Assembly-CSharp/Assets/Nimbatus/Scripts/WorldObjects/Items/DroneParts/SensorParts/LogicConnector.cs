using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class LogicConnector : DronePart, IHasEventKeyHub
	{
		[HideInInspector]
		public new EventKeyHub KeyEventHub
		{
			get
			{
				return RootDrone.RootDronePart.KeyEventHub;
			}
		}
	}
}
