using Assets.Scripts.Flight.Maps;

namespace Assets.Scripts.Levels
{
	public class LevelSandboxScript : LevelBase
	{
		protected override void OnAwake()
		{
			Map component = base.gameObject.GetComponent<Map>();
			if (component != null && component.DefaultStartLocation != null)
			{
				StartPosition = component.DefaultStartLocation.transform;
				InitialSpeed = component.DefaultStartLocation.InitialSpeed;
				PositionAircraftOnGround = component.DefaultStartLocation.StartOnGround;
			}
		}
	}
}
