using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class WelcomeRepository : TRepository<WelcomeRepository>
	{
		public const string REPOSITORY_ID = "core.welcome";

		[SerializeField]
		private bool m_OpenOnStartup = true;

		[SerializeField]
		private WelcomeData m_WelcomeData;

		public override string RepositoryID => "core.welcome";

		public bool OpenOnStartup => m_OpenOnStartup;

		public WelcomeData WelcomeData
		{
			get
			{
				return m_WelcomeData;
			}
			set
			{
				m_WelcomeData = value;
			}
		}
	}
}
