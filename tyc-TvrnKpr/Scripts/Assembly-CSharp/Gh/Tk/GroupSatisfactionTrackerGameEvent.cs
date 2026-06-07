using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class GroupSatisfactionTrackerGameEvent : SimpleNotificationEvent
	{
		public sealed class GroupLeftEventArgs : EventArgs
		{
			public int groupId;

			public int groupSize;

			public bool satisfied;

			public string sourceNodeId;
		}

		private class GroupMemberData : IPersistable
		{
			[PersistenceObjectReference]
			public Patron patron;

			[FormerlySerializedAs("name")]
			public string nameKey;

			public string race;

			public int tier;

			public bool hasArrived;

			public bool hasLeft;

			public string[] nameKeysOfUnfulfilledRequiredNeeds;

			public string[] nameKeysOfFullfilledRequiredNeeds;

			public float satisfaction;

			[JsonIgnore]
			public Func<TooltipData> currentLazyTooltip;

			[JsonIgnore]
			public bool IsInTavern => false;

			public bool IsGoalReached()
			{
				return false;
			}

			public int GetProgress()
			{
				return 0;
			}

			public int GetTotalAmountOfRequirements()
			{
				return 0;
			}

			public int GetAmountOfFulfilledRequirements()
			{
				return 0;
			}

			public Func<TooltipData> GetLazyTooltip()
			{
				return null;
			}

			private static (IAiComponentIsDoneInfo, string)[] GetIsDoneInfos(Patron patron)
			{
				return null;
			}

			public void Refresh()
			{
			}
		}

		private readonly int _groupId;

		private string _descriptionKey;

		private int _groupSize;

		private int _goldBonus;

		private int _numberDespawned;

		private int _progress;

		private List<GroupMemberData> _groupMembers;

		private string _notificationId;

		[JsonIgnore]
		private float _lastUpdate;

		public static event EventHandler<GroupLeftEventArgs> OnGroupLeftTavern
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<GroupLeftEventArgs> OnGroupDidNotVisitTavern
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public static void RaiseOnGroupDidNotVisitTavernEvent(int groupId, int groupSize, bool satisfied, string sourceNodeId)
		{
		}

		private static void ActorDespawned(object sender, EventArgs<Actor> e)
		{
		}

		private static void ActorSpawned(object sender, EventArgs<Actor> e)
		{
		}

		public static GroupSatisfactionTrackerGameEvent GetEventForGroup(int groupId)
		{
			return null;
		}

		protected GroupSatisfactionTrackerGameEvent()
		{
		}

		public GroupSatisfactionTrackerGameEvent(PatronPopulationData leader)
		{
		}

		private void OnGroupMemberSpawned(Patron patron)
		{
		}

		protected override void SetupNotification()
		{
		}

		private string GetGroupTooltip()
		{
			return null;
		}

		public override void OnUpdate()
		{
		}

		private void UpdateNotification(bool forceRefresh = false, bool sendUpdateToUI = true)
		{
		}

		private void OnGroupMemberDespawned(Patron patron)
		{
		}

		public override void LateRestoreState(IDataStore data)
		{
		}
	}
}
