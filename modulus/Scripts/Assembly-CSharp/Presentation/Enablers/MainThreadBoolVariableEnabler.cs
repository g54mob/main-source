using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Variables;
using NaughtyAttributes;
using Presentation.UI.Buttons;
using UnityEngine;

namespace Presentation.Enablers
{
	public class MainThreadBoolVariableEnabler : MonoBehaviour
	{
		private enum Target
		{
			GameObject = 0,
			MonoBehaviour = 1,
			ButtonInteractable = 2,
			Other = 3,
			MaterialAnimation = 4
		}

		private enum Condition
		{
			And = 0,
			Or = 1,
			AndNot = 2
		}

		[SerializeField]
		private MainThreadBoolVariableSO _boolVariable;

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

		[ShowIf("InspectorShowMaterialAnim")]
		[SerializeField]
		private Material _materialReference;

		[ShowIf("InspectorShowMaterialAnim")]
		[SerializeField]
		private List<MeshRenderer> _affectedRenderers = new List<MeshRenderer>();

		[Header("Additional Conditions")]
		[SerializeField]
		private SerializedDictionary<Condition, MainThreadBoolVariableSO> _conditions = new SerializedDictionary<Condition, MainThreadBoolVariableSO>();

		private static readonly int StartTime = Shader.PropertyToID("_startTime");

		private static readonly int ToggleVariable = Shader.PropertyToID("_toggleVariable");

		private Material _instancedMaterial;

		private bool _previousBoolValue;

		private bool InspectorShowTargetMonoBehaviour => _target == Target.MonoBehaviour;

		private bool InspectorShowTargetButton => _target == Target.ButtonInteractable;

		private bool InspectorShowOtherTarget => _target == Target.Other;

		private bool InspectorShowMaterialAnim => _target == Target.MaterialAnimation;

		private void Awake()
		{
			if (_target == Target.MaterialAnimation)
			{
				_instancedMaterial = Object.Instantiate(_materialReference);
				foreach (MeshRenderer affectedRenderer in _affectedRenderers)
				{
					affectedRenderer.material = _instancedMaterial;
				}
				_instancedMaterial.SetFloat(ToggleVariable, 0f);
				_instancedMaterial.SetFloat(StartTime, float.MaxValue);
			}
			_boolVariable.ValueChanged.RegisterMainThread(OnBoolVariableChanged);
			foreach (MainThreadBoolVariableSO value in _conditions.Values)
			{
				value.ValueChanged.RegisterMainThread(OnBoolVariableChanged);
			}
			_previousBoolValue = !_boolVariable.Value;
			OnBoolVariableChanged(_boolVariable.Value);
		}

		private void OnDestroy()
		{
			_boolVariable.ValueChanged.UnRegisterMainThread(OnBoolVariableChanged);
			foreach (MainThreadBoolVariableSO value in _conditions.Values)
			{
				value.ValueChanged.UnRegisterMainThread(OnBoolVariableChanged);
			}
		}

		private void OnBoolVariableChanged(bool _)
		{
			bool boolWithExtraConditions = GetBoolWithExtraConditions(_boolVariable.Value);
			bool flag = (_disableWhenEnabled ? (!boolWithExtraConditions) : boolWithExtraConditions);
			if (flag != _previousBoolValue)
			{
				_previousBoolValue = flag;
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
				case Target.MaterialAnimation:
					_instancedMaterial.SetFloat(ToggleVariable, flag ? 1f : 0f);
					_instancedMaterial.SetFloat(StartTime, Time.time);
					break;
				}
			}
		}

		private bool GetBoolWithExtraConditions(bool mainValue)
		{
			bool flag = mainValue;
			bool flag2 = false;
			bool flag3 = true;
			foreach (KeyValuePair<Condition, MainThreadBoolVariableSO> condition in _conditions)
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
				case Condition.AndNot:
					flag3 = flag3 && !value;
					break;
				}
			}
			bool flag4 = flag && flag3;
			if (_conditions.ContainsKey(Condition.Or))
			{
				flag4 = flag4 || flag2;
			}
			return flag4;
		}
	}
}
