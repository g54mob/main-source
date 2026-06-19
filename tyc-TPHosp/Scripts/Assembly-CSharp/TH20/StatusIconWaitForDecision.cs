using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconWaitForDecision : StatusIcon
	{
		private Character _character;

		[SerializeField]
		private TMP_Text _timeText;

		[SerializeField]
		private Image _iconImage;

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_character = emitter as Character;
		}

		private void Update()
		{
			WaitForRoomToBeBuiltComponent component = _character.GetComponent<WaitForRoomToBeBuiltComponent>();
			if (component == null)
			{
				return;
			}
			_timeText.text = $"{(int)component.Time}";
			if (!(_iconImage != null))
			{
				return;
			}
			List<RoomDefinition.Type> roomTypes = component.RoomTypes;
			Patient patient = _character as Patient;
			if (roomTypes.Count > 1 && patient != null)
			{
				_iconImage.overrideSprite = patient.Definition.MoreDiagnosisIcon;
				return;
			}
			SharedInstance<RoomDefinition>[] rooms = _level.Metagame.RoomDatabase.Instance.Rooms;
			for (int i = 0; i < rooms.Length; i++)
			{
				RoomDefinition instance = rooms[i].Instance;
				if (roomTypes.Contains(instance._type))
				{
					_iconImage.overrideSprite = instance._icon;
					break;
				}
			}
		}

		public override bool HasTimedOut()
		{
			if (_character.GetComponent<WaitForRoomToBeBuiltComponent>() == null)
			{
				return true;
			}
			return base.HasTimedOut();
		}
	}
}
