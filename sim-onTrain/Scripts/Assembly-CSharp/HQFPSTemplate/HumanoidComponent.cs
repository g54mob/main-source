namespace HQFPSTemplate
{
	public class HumanoidComponent : EntityComponent
	{
		private Humanoid m_Humanoid;

		public Humanoid Humanoid
		{
			get
			{
				if (m_Humanoid == null)
				{
					m_Humanoid = GetComponent<Humanoid>();
				}
				if (m_Humanoid == null)
				{
					m_Humanoid = GetComponentInParent<Humanoid>();
				}
				return m_Humanoid;
			}
		}
	}
}
