namespace FractureField.Drones
{
	public class HammerDrone : Drone
	{
		public override DroneType Type => default(DroneType);

		public override float MoveSpeedModifier => 0f;

		public override float HitSpeedModifier => 0f;

		public override float DamageModifier => 0f;
	}
}
