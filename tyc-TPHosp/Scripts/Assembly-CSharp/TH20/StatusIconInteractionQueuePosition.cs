using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconInteractionQueuePosition : StatusIcon
	{
		private Character _character;

		[SerializeField]
		private TMP_Text _queuePositionText;

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
			HoverMenuRoomItem hoverMenuRoomItem = _level.HUD.FindMenu<HoverMenuRoomItem>(includeInactive: false);
			if (!(hoverMenuRoomItem != null))
			{
				return;
			}
			RoomItem item = hoverMenuRoomItem.Item;
			if (item == null)
			{
				return;
			}
			int num = -1;
			foreach (ObjectInteraction interaction in item.Interactions)
			{
				int queuePosition = interaction.GetQueuePosition(_character, includeInterator: true);
				if (queuePosition != -1)
				{
					num = queuePosition;
				}
			}
			if (num != -1)
			{
				_queuePositionText.text = $"{num + 1}";
			}
		}
	}
}
