public class SDemoControl
{
	public enum State
	{
		Kill = 0,
		Playing = 1,
		Paused = 2
	}

	public State m_State = State.Playing;

	public SelfAnimation.SelfAnimType m_SelfAnimType;
}
