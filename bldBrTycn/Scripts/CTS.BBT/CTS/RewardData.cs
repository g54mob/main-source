using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "Quests/Reward Data")]
	public class RewardData : RewardDataBase
	{
		[field: SerializeField]
		public UIMessageBase PositiveMessage { get; private set; }

		[field: SerializeField]
		public UIMessageBase NeutralMessage { get; private set; }

		[field: SerializeField]
		public UIMessageBase NegativeMessage { get; private set; }

		[field: SerializeField]
		public UIMessageBase FailMessage { get; private set; }

		public override Guid ShowMessage(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			return dialogueScore switch
			{
				LastDialogueHelper.EDialogueScore.Neutral => ShowNeutralMessage(), 
				LastDialogueHelper.EDialogueScore.Positive => ShowPositiveMessage(), 
				LastDialogueHelper.EDialogueScore.Negative => ShowNegativeMessage(), 
				_ => throw new ArgumentOutOfRangeException("dialogueScore", dialogueScore, null), 
			};
		}

		public override Guid ShowPositiveMessage()
		{
			return CTSSingleton<UIMessage>.Instance.ShowMessage(PositiveMessage);
		}

		public override Guid ShowNeutralMessage()
		{
			return CTSSingleton<UIMessage>.Instance.ShowMessage(NeutralMessage);
		}

		public override Guid ShowNegativeMessage()
		{
			return CTSSingleton<UIMessage>.Instance.ShowMessage(NegativeMessage);
		}

		public override Guid ShowFailMessage()
		{
			return CTSSingleton<UIMessage>.Instance.ShowMessage(FailMessage);
		}
	}
}
