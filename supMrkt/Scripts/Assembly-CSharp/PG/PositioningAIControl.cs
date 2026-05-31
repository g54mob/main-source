using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(CarController))]
	public class PositioningAIControl : BaseAIControl
	{
		public AIPath AIPath;

		protected float SpeedLimit;

		public float ProgressDistance { get; set; }

		public AIPath.RoutePoint ProgressPoint { get; private set; }

		public bool Finished => false;

		public override void Start()
		{
		}

		protected override void FixedUpdate()
		{
		}
	}
}
