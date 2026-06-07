using UnityEngine;

namespace App.Data
{
	public class User
	{
		public string KeyName;

		public int StartAudienceMin;

		public int StartAudienceMax;

		public int StartAudience;

		public int LeaveMin;

		public int LeaveMax;

		public int daysOfInterest;

		public int InterestMin;

		public int InterestMax;

		public int CallMin;

		public int CallMax;

		public int RewardMin;

		public int RewardMax;

		public int RewardChanceMin;

		public int RewardChanceMax;

		public int RefundPercentage;

		public int DeleteUsersLeaveMin;

		public int DeleteUsersLeaveMax;

		public int DeleteUsers;

		public int CallUsersMin;

		public int CallUsersMax;

		public int Callusers;

		public User()
		{
		}

		public User(User u)
		{
			KeyName = u.KeyName;
			StartAudienceMin = u.StartAudienceMin;
			StartAudienceMax = u.StartAudienceMax;
			StartAudience = Random.Range(StartAudienceMin, StartAudienceMax);
			LeaveMin = u.LeaveMin;
			LeaveMax = u.LeaveMax;
			InterestMin = u.InterestMin;
			InterestMax = u.InterestMax;
			daysOfInterest = Random.Range(InterestMin, InterestMax);
			CallMin = u.CallMin;
			CallMax = u.CallMax;
			RewardMin = u.RewardMin;
			RewardMax = u.RewardMax;
			RewardChanceMin = u.RewardChanceMin;
			RewardChanceMax = u.RewardChanceMax;
			daysOfInterest = Random.Range(InterestMin, InterestMax);
			DeleteUsersLeaveMax = u.DeleteUsersLeaveMax;
			DeleteUsersLeaveMin = u.DeleteUsersLeaveMin;
			DeleteUsers = Random.Range(DeleteUsersLeaveMin, DeleteUsersLeaveMax);
			CallUsersMin = u.CallUsersMin;
			CallUsersMax = u.CallUsersMax;
			Callusers = Random.Range(CallUsersMin, CallUsersMax);
		}
	}
}
