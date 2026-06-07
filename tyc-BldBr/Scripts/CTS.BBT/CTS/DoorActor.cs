using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Emotes;
using UnityEngine;

namespace CTS
{
	public class DoorActor : CTSBehaviour, IContextActor
	{
		[SerializeField]
		private Sprite _lockSprite;

		[SerializeField]
		private float _spriteSize = 25f;

		[Inject(false)]
		private BuildableDoor _door;

		[Inject(false)]
		private ContextualActions _contextualActions;

		[Inject(false)]
		private BoxCollider _collider;

		private Emote _currentEmote;

		private static ContextualActionOpenBar _openBarAction = new ContextualActionOpenBar();

		public ContextActorData ContextActorData { get; } = new ContextActorData();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_door.EntranceValueChanged += OnDoorSetAsEntrance;
			LevelParameters.OnBarOpenedStatusChanged += OnBarOpen;
			OnBarOpen(CTSSingleton<LevelParameters>.Instance.IsOpen);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_door.EntranceValueChanged -= OnDoorSetAsEntrance;
			LevelParameters.OnBarOpenedStatusChanged -= OnBarOpen;
		}

		private void OnDoorSetAsEntrance(bool isEntrance)
		{
			OnBarOpen(CTSSingleton<LevelParameters>.Instance.IsOpen);
			if (isEntrance)
			{
				_contextualActions.Actions.Remove(_openBarAction);
				_contextualActions.Actions.Add(_openBarAction);
			}
			else
			{
				_contextualActions.Actions.Remove(_openBarAction);
			}
		}

		private void OnBarOpen(bool value)
		{
		}
	}
}
