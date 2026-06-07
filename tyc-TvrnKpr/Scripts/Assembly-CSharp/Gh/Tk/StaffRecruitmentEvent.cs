using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class StaffRecruitmentEvent : GameEvent
	{
		private const float _recruitmentPoolRefresh = 5f;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private List<Staff> _generatedStaff;

		[PersistenceOptIn]
		private bool _autoRefresh;

		private static readonly Tuple<int, float>[] _dislikeRoleAmountChancesInPercent;

		static StaffRecruitmentEvent()
		{
		}

		private static void StaffHiredChangedEvent(object sender, EventArgs e)
		{
		}

		private static void Tavern_StarRatingChangedEvent(object sender, EventArgs<float> e)
		{
		}

		private StaffRecruitmentEvent()
		{
		}

		public StaffRecruitmentEvent(bool autoRefresh, int poolSize)
		{
		}

		public StaffRecruitmentEvent(Staff[] staff)
		{
		}

		public static Staff GenerateStaffMember(int seed, int tavernStars, string race = null, string gender = null)
		{
			return null;
		}

		public static Staff GenerateStaff(StaffData staffData, int seed = -1)
		{
			return null;
		}

		private static void AddDislikeRoleTraits(IEnumerable<StaffSkill> allSkills, Staff staff)
		{
		}

		public override void Trigger()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
