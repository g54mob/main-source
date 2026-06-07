namespace Assets.Scripts.Flight.MapView.Orbits
{
	public interface IOrbitInteractionEventRecipient
	{
		OrbitInteractionScript.OrbitInteractionDelegate OnHoverEnter { get; }

		OrbitInteractionScript.OrbitInteractionDelegate OnHoverExit { get; }

		OrbitInteractionScript.OrbitInteractionDelegate OnHoverStay { get; }
	}
}
