using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Variables;
using NaughtyAttributes;
using Presentation.UI.Buttons;
using UnityEngine;

namespace Presentation.Enablers
{
	public class BoolVariableEnabler : MonoBehaviour
	{
		private enum Target
		{
			GameObject = 0,
			MonoBehaviour = 1,
			ButtonInteractable = 2,
			Other = 3
		}

		private enum Condition
		{
			And = 0,
			Or = 1,
			AndNot = 2,
			OrNot = 3
		}

		[SerializeField]
		private BoolVariableSO _boolVariable;

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

		[ShowIf("InspectorShowOtherTarget")]
		[SerializeField]
		private GameObject _otherTarget;

		[Header("Additional Conditions")]
		[SerializeField]
		private SerializedDictionary<Condition, BoolVariableSO> _conditions = new SerializedDictionary<Condition, BoolVariableSO>();

		private bool InspectorShowTargetMonoBehaviour => _target == Target.MonoBehaviour;

		private bool InspectorShowTargetButton => _target == Target.ButtonInteractable;

		private bool InspectorShowOtherTarget => _target == Target.Other;

		private void Awake()
		{
			_boolVariable.ValueChanged += OnBoolVariableChanged;
			foreach (BoolVariableSO value in _conditions.Values)
			{
				value.ValueChanged += OnBoolVariableChanged;
			}
			OnBoolVariableChanged(_boolVariable.Value);
		}

		private void OnDestroy()
		{
			_boolVariable.ValueChanged -= OnBoolVariableChanged;
			foreach (BoolVariableSO value in _conditions.Values)
			{
				value.ValueChanged -= OnBoolVariableChanged;
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void Recaluate()
		{
			OnBoolVariableChanged(_: false);
		}

		private void OnBoolVariableChanged(bool _)
		{
			bool boolWithExtraConditions = GetBoolWithExtraConditions(_boolVariable.Value);
			bool flag = (_disableWhenEnabled ? (!boolWithExtraConditions) : boolWithExtraConditions);
			switch (_target)
			{
			case Target.GameObject:
				base.gameObject.SetActive(flag);
				break;
			case Target.MonoBehaviour:
				_targetMonoBehaviour.enabled = flag;
				break;
			case Target.ButtonInteractable:
				_targetButton.Interactable = flag;
				break;
			case Target.Other:
				_otherTarget.SetActive(flag);
				break;
			}
		}

		private bool GetBoolWithExtraConditions(bool mainValue)
		{
			bool flag = mainValue;
			bool flag2 = false;
			foreach (KeyValuePair<Condition, BoolVariableSO> condition in _conditions)
			{
				bool value = condition.Value.Value;
				switch (condition.Key)
				{
				case Condition.And:
					flag = flag && value;
					break;
				case Condition.Or:
					flag2 = flag2 || value;
					break;
				case Condition.OrNot:
					flag2 = flag2 || !value;
					break;
				case Condition.AndNot:
					flag = flag && !value;
					break;
				}
			}
			if (_conditions.ContainsKey(Condition.Or))
			{
				flag = flag || flag2;
			}
			return flag;
		}
	}
}
