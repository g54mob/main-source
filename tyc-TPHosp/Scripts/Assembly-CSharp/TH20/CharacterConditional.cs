using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class CharacterConditional : Conditional
	{
		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Character")]
		private SharedCharacterRef _character;

		protected Character Character => _character.IsValid() ? _character.Get : null;

		protected Character CharacterUnsafe
		{
			get
			{
				if (!_character.IsValid())
				{
					return null;
				}
				return _character.Get;
			}
		}
	}
}
