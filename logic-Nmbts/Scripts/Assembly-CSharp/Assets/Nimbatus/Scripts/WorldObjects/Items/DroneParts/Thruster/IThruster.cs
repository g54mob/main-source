namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster
{
	public interface IThruster
	{
		bool IsThrusterAlive();

		float GetCurrentThrust();

		void SetCurrentThrust(float thrust);
	}
}
