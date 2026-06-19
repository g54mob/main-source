using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.Assets.Code.Game.Characters
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HordePatientComponent : EntityTickComponent
	{
		[SerializeField]
		private CharacterModifier[] _movementSpeedModifier;

		private Character _character;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
			if (_character.ModifiersComponent != null)
			{
				_character.ModifiersComponent.AddModifiers(_movementSpeedModifier);
			}
		}

		public override void Tick()
		{
			base.Tick();
			if (!(_character is Patient) || _character.RoomUsing != null)
			{
				Destroy();
			}
		}

		public override void Destroy()
		{
			if (_character.ModifiersComponent != null)
			{
				_character.ModifiersComponent.RemoveModifiers(_movementSpeedModifier);
			}
			base.Destroy();
		}
	}
}
