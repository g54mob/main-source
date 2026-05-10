using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "Quests/Reward Data (Simple)")]
	public class SimpleRewardData : RewardDataBase
	{
		[field: SerializeField]
		public UIMessageBase Message { get; private set; }

		public override Guid ShowMessage(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			return ShowMessage();
		}

		public override Guid ShowPositiveMessage()
		{
			return ShowMessage();
		}

		public override Guid ShowNeutralMessage()
		{
			return ShowMessage();
		}

		public override Guid ShowNegativeMessage()
		{
			return ShowMessage();
		}

		public override Guid ShowFailMessage()
		{
			return ShowMessage();
		}

		private Guid ShowMessage()
		{
			return CTSSingleton<UIMessage>.Instance.ShowMessage(Message);
		}
	}
}
