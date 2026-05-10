using System;
using UnityEngine;

namespace CTS
{
	public abstract class RewardDataBase : ScriptableObject
	{
		public abstract Guid ShowMessage(LastDialogueHelper.EDialogueScore dialogueScore);

		public abstract Guid ShowPositiveMessage();

		public abstract Guid ShowNeutralMessage();

		public abstract Guid ShowNegativeMessage();

		public abstract Guid ShowFailMessage();
	}
}
