using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class CharacterAction : Action
	{
		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Character")]
		private SharedCharacterRef _character;

		protected new CharacterBehaviorTree Owner
		{
			get
			{
				CharacterBehaviorTree obj = (CharacterBehaviorTree)base.Owner;
				if (!obj)
				{
					throw new Debug.AssertException("Trying to access character tree from an character action that isn't owned by a character behavior tree");
				}
				return obj;
			}
		}

		protected Character Character => CharacterUnsafe;

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

		public virtual void RestoreFromSave()
		{
		}
	}
}
