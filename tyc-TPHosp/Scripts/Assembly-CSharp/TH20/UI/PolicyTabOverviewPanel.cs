using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PolicyTabOverviewPanel : OverviewMenuTabPanel
	{
		[SerializeField]
		private Slider _sliderDiagnosisThreshold;

		[SerializeField]
		private TMP_Text _textDiagnosisThreshold;

		[SerializeField]
		private Slider _sliderQueueWarningLength;

		[SerializeField]
		private TMP_Text _textQueueWarningLength;

		[SerializeField]
		private Toggle _toggleAutoSendTreatment;

		[SerializeField]
		private Toggle _toggleStaffLeaveRooms;

		[SerializeField]
		private Toggle _toggleStaffTrainingRequests;

		[SerializeField]
		private Toggle _toggleStaffPromotions;

		[SerializeField]
		private DynamicButton _buttonReset;

		private HospitalPolicy _policy;

		private HospitalPolicy.ConfigData _config;

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			_policy = theTabRoot.TheOverviewMenu.TheLevel.HospitalPolicy;
			_config = _policy.Config;
			Setup();
			_buttonReset.onPrimaryDown.AddListener(delegate
			{
				_policy.Reset();
				Setup();
			});
		}

		private void Setup()
		{
			SetupSlider(_sliderDiagnosisThreshold, _config.DiagnosisCertaintyMin, _config.DiagnosisCertaintyMax, _policy.DiagnosisCertainty, delegate(float v)
			{
				_policy.DiagnosisCertainty = v;
				_textDiagnosisThreshold.text = StringUtils.FormatPercentageValue(v / 100f);
			});
			SetupSlider(_sliderQueueWarningLength, _config.QueueWarningMin, _config.QueueWarningMax, _policy.QueueWarningLength, delegate(float v)
			{
				_policy.QueueWarningLength = (int)v;
				_textQueueWarningLength.text = StringUtils.FormatNumber((int)v);
			});
			SetupToggle(_toggleAutoSendTreatment, _policy.AutoSendForTreatment, delegate(bool b)
			{
				_policy.AutoSendForTreatment = b;
			});
			SetupToggle(_toggleStaffLeaveRooms, _policy.StaffLeaveRooms, delegate(bool b)
			{
				_policy.StaffLeaveRooms = b;
			});
			SetupToggle(_toggleStaffTrainingRequests, _policy.StaffTrainingRequests, delegate(bool b)
			{
				_policy.StaffTrainingRequests = b;
			});
			SetupToggle(_toggleStaffPromotions, _policy.StaffPromotion, delegate(bool b)
			{
				_policy.StaffPromotion = b;
			});
		}

		private void SetupToggle(Toggle toggle, bool value, Action<bool> onChanged)
		{
			toggle.onValueChanged.RemoveAllListeners();
			toggle.onValueChanged.AddListener(onChanged.Invoke);
			toggle.isOn = value;
		}

		private void SetupSlider(Slider slider, float min, float max, float value, Action<float> onChanged)
		{
			slider.onValueChanged.RemoveAllListeners();
			slider.onValueChanged.AddListener(onChanged.Invoke);
			slider.minValue = min;
			slider.maxValue = max;
			slider.value = value;
		}

		private void OnDestroy()
		{
			if (!_policy.StaffPromotion)
			{
				return;
			}
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				staffMember.AutoPromote();
			}
		}
	}
}
