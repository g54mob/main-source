namespace HQFPSTemplate
{
	public abstract class PlayerComponent : EntityComponent
	{
		private Player m_Player;

		public Player Player
		{
			get
			{
				if (!m_Player)
				{
					m_Player = GetComponent<Player>();
				}
				if (!m_Player)
				{
					m_Player = GetComponentInParent<Player>();
				}
				if (!m_Player)
				{
					m_Player = GetComponentInChildren<Player>();
				}
				return m_Player;
			}
		}
	}
}
