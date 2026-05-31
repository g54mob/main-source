using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using _Code.Characters;

namespace _Code.Rooms
{
	public sealed class CharacterRoomObjectView : ARoomObjectView<ERoomPeopleState>
	{
		[SerializeField]
		private ERoomPeopleState _startState;

		[SerializeField]
		private Material _corpseShader;

		private bool _isGigaDisabled;

		[field: SerializeField]
		public CharacterSOData Data { get; private set; }

		protected override RoomObjectState<ERoomPeopleState>[] States => null;

		protected override ERoomPeopleState StartState => default(ERoomPeopleState);

		public bool IsButtonActive => false;

		public event Action<CharacterRoomObjectView, bool> DialogStarted
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

		protected override void Awake()
		{
		}

		private void TryStartDialog()
		{
		}

		public void MakeCorpse()
		{
		}

		public override void Activate()
		{
		}

		public void GigaDeactivate()
		{
		}

		public void EnableButton()
		{
		}

		public void DisableButton()
		{
		}
	}
}
