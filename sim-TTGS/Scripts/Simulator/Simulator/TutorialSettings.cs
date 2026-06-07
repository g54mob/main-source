using Dhs5.Utility.Settings;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	[Settings("General/Tutorial", Scope.Project)]
	public class TutorialSettings : CustomSettings<TutorialSettings>
	{
		[Header("References")]
		[SerializeField]
		private TutorialData m_order;

		[SerializeField]
		private TutorialData m_painting;

		[SerializeField]
		private TutorialData m_reserve;

		[SerializeField]
		private TutorialData m_cleaning;

		[SerializeField]
		private TutorialData m_employees;

		public static TutorialData Order => CustomSettings<TutorialSettings>.I.m_order;

		public static TutorialData Painting => CustomSettings<TutorialSettings>.I.m_painting;

		public static TutorialData Reserve => CustomSettings<TutorialSettings>.I.m_reserve;

		public static TutorialData Cleaning => CustomSettings<TutorialSettings>.I.m_cleaning;

		public static TutorialData Employees => CustomSettings<TutorialSettings>.I.m_employees;
	}
}
