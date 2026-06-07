using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class LogicSplitter : DronePart, IHasEventKeyHub
	{
		[HideInInspector]
		public new EventKeyHub KeyEventHub { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			KeyEventHub = base.gameObject.AddComponent<EventKeyHub>();
		}
	}
}
