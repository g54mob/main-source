using Data.FeatureFlags.Validators;
using NaughtyAttributes;
using Presentation.UI.Buttons;
using UnityEngine;

namespace Presentation.Enablers
{
	public class FeatureFlagsEnabler : MonoBehaviour
	{
		private enum Target
		{
			GameObject = 0,
			MonoBehaviour = 1,
			ButtonInteractable = 2
		}

		[SerializeField]
		private FeatureFlagValidator _validator;

		[SerializeField]
		private bool _disableWhenEnabled;

		[SerializeField]
		private Target _target;

		[ShowIf("InspectorShowTargetMonoBehaviour")]
		[SerializeField]
		private MonoBehaviour _targetMonoBehaviour;

		[ShowIf("InspectorShowTargetButton")]
		[SerializeField]
		private ButtonEnabler _targetButton;

		private bool InspectorShowTargetMonoBehaviour => _target == Target.MonoBehaviour;

		private bool InspectorShowTargetButton => _target == Target.ButtonInteractable;

		private void Awake()
		{
			if (!(_validator == null) && base.gameObject.activeSelf && ((_disableWhenEnabled && _validator.IsEnabledFeatureFlag()) || (!_disableWhenEnabled && !_validator.IsEnabledFeatureFlag())))
			{
				switch (_target)
				{
				case Target.GameObject:
					base.gameObject.SetActive(value: false);
					break;
				case Target.MonoBehaviour:
					_targetMonoBehaviour.enabled = false;
					break;
				case Target.ButtonInteractable:
					_targetButton.Interactable = false;
					break;
				}
			}
		}
	}
}
