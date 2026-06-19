using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconAttribute : StatusIcon
	{
		[SerializeField]
		private CharacterAttributes.Type _attribute;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private float _minPulseSpeed;

		[SerializeField]
		private float _maxPulseSpeed;

		private Character _character;

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_character = emitter as Character;
		}

		private void Update()
		{
			if (_character != null)
			{
				AttributeFloat attribute = _character.GetAttributes().GetAttribute((int)_attribute);
				if (attribute != null)
				{
					float t = attribute.Value() / 100f;
					float value = Mathf.Lerp(_maxPulseSpeed, _minPulseSpeed, t);
					_animator.SetFloat("Speed", value);
				}
			}
		}
	}
}
