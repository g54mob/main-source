using Data.FeatureFlags.Validators;
using Events;
using NaughtyAttributes;
using UnityEngine;

namespace Presentation.Enablers
{
	public class ValidatorEnabler : MonoBehaviour
	{
		private enum Target
		{
			GameObject = 0,
			MonoBehaviour = 1
		}

		[SerializeField]
		[Required(null)]
		private FeatureFlagValidator _validator;

		[SerializeField]
		private bool _disableWhenEnabled;

		[SerializeField]
		private Target _target;

		[ShowIf("InspectorShowTargetMonoBehaviour")]
		[SerializeField]
		private MonoBehaviour _targetMonoBehaviour;

		[SerializeField]
		private bool _reEvaluateOnLevelLoad;

		[ShowIf("_reEvaluateOnLevelLoad")]
		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		private bool InspectorShowTargetMonoBehaviour => _target == Target.MonoBehaviour;

		private void Awake()
		{
			Evaluate();
			if (_reEvaluateOnLevelLoad)
			{
				_finishedLoadingSaveEvent.Register(Evaluate);
			}
		}

		private void OnDestroy()
		{
			if (_reEvaluateOnLevelLoad)
			{
				_finishedLoadingSaveEvent.UnRegister(Evaluate);
			}
		}

		private void Evaluate()
		{
			if (!(_validator == null))
			{
				bool flag = _validator.IsEnabledFeatureFlag();
				if (_disableWhenEnabled)
				{
					flag = !flag;
				}
				if (_target == Target.GameObject)
				{
					base.gameObject.SetActive(flag);
				}
				else if (_target == Target.MonoBehaviour)
				{
					_targetMonoBehaviour.enabled = flag;
				}
			}
		}
	}
}
