using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconQueuePosition : StatusIcon
	{
		private Character _character;

		[SerializeField]
		private TMP_Text _queuePositionText;

		public static string GoingToRoomStatusIconString = "...";

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_character = emitter as Character;
			Update();
		}

		private void Update()
		{
			SetQueuePositionText();
		}

		private void SetQueuePositionText()
		{
			int queuePosition = _character.GetQueuePosition();
			if (queuePosition != -1)
			{
				_queuePositionText.text = $"{queuePosition + 1}";
			}
			else if (_character.RoomCalledInto != null)
			{
				_queuePositionText.text = GoingToRoomStatusIconString;
			}
		}

		public override bool HasTimedOut()
		{
			if (!ShouldShowQueueStatusIcon())
			{
				return true;
			}
			return base.HasTimedOut();
		}

		private bool ShouldShowQueueStatusIcon()
		{
			if (_character.GetQueuePosition() <= -1)
			{
				return _character.RoomCalledInto != null;
			}
			return true;
		}
	}
}
