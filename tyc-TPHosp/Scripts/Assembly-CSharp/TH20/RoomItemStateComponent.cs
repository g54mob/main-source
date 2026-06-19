using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemStateComponent : EntityComponent
	{
		[SerializeField]
		private SharedInstance<RoomItemState> _initialState;

		private RoomItem _item;

		private RoomItemState _currentState;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_item = GetOwner<RoomItem>();
			if (_initialState.NotNull())
			{
				SetState(_initialState.Instance);
			}
		}

		public void SetState(RoomItemState state)
		{
			if (state != _currentState)
			{
				_currentState = state;
				if (_currentState != null)
				{
					_currentState.OnActive(_item);
				}
			}
		}

		public bool IsInState(RoomItemState state)
		{
			return _currentState == state;
		}
	}
}
