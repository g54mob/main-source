public class WormRider : Enemy
{
	protected override void SetState(State newState)
	{
		if (base.CurrentState == State.Sleeping && newState == State.Engaging)
		{
			AsciiAnimation component = walkSprite.GetComponent<AsciiAnimation>();
			if (component != null)
			{
				component.ElapsedTime = 0.15f;
			}
		}
		base.SetState(newState);
	}
}
