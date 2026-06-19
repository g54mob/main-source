using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffTabOverviewPanel : OverviewMenuTabPanel
	{
		[SerializeField]
		private Color[] _colourRange;

		[SerializeField]
		private Slider[] _worklifeBalanceSliders;

		[SerializeField]
		private GameObject _speechBubble;

		[SerializeField]
		private float _speechBubbleDisplayTime = 20f;

		private GameObject _advisorPortraitSceneObject;

		private AdvisorPortraitScene _advisorPortraitScene;

		private float _speechBubbleDisplayTimer;

		public bool AdvisorVisible
		{
			private get
			{
				if (_advisorPortraitSceneObject != null)
				{
					return _advisorPortraitSceneObject.activeSelf;
				}
				return false;
			}
			set
			{
				if (value)
				{
					_advisorPortraitScene.ShowAdvisorModel();
				}
				else
				{
					_advisorPortraitScene.PopDownAdvisor();
				}
			}
		}

		protected override void Update()
		{
			base.Update();
			_speechBubbleDisplayTimer -= Time.unscaledDeltaTime;
			_speechBubble.SetActive(_speechBubbleDisplayTimer > 0f);
			Vector3 mousePosition = Input.mousePosition;
			for (int i = 0; i < _worklifeBalanceSliders.Length; i++)
			{
				if (RectTransformUtility.RectangleContainsScreenPoint(_worklifeBalanceSliders[i].GetComponent<RectTransform>(), mousePosition))
				{
					DisplayBreakPolicy(StaffDefinition.AllTypes[i]);
				}
			}
		}

		public override void UpdateProgressBars()
		{
			base.UpdateProgressBars();
			PanelItemProgressBar[] progressBars = _progressBars;
			for (int i = 0; i < progressBars.Length; i++)
			{
				progressBars[i].CheckUpdateProgressBarWidth();
			}
		}

		protected override void Refresh()
		{
			base.Refresh();
			PanelItemProgressBar[] progressBars = _progressBars;
			for (int i = 0; i < progressBars.Length; i++)
			{
				progressBars[i].ApplyColourRange(_colourRange);
			}
		}

		public void SetupAdvisor(AdvisorPortraitScene _theAdvisorPortraitScene)
		{
			_advisorPortraitScene = _theAdvisorPortraitScene;
			_advisorPortraitSceneObject = _advisorPortraitScene.gameObject;
		}

		public void ResetAdvisor()
		{
			if ((bool)_advisorPortraitScene)
			{
				_advisorPortraitScene.HideAdvisorModel();
			}
		}

		public void SetupBreakSliders(WorkLifeBalanceManager workLifeBalanceManager)
		{
			for (int i = 0; i < _worklifeBalanceSliders.Length; i++)
			{
				Slider obj = _worklifeBalanceSliders[i];
				StaffDefinition.Type staffType = StaffDefinition.AllTypes[i];
				WorkLifeBalanceManager.BalanceData balanceData = workLifeBalanceManager.GetBalanceData(staffType, -1);
				obj.value = balanceData.Value;
				obj.onValueChanged.AddListener(delegate(float newValue)
				{
					workLifeBalanceManager.SetWorkLifeBalance(staffType, -1, newValue);
					DisplayBreakPolicy(staffType);
				});
			}
		}

		private void DisplayBreakPolicy(StaffDefinition.Type staffType)
		{
			PanelItemInfoMessage[] infoMessages = _infoMessages;
			for (int i = 0; i < infoMessages.Length; i++)
			{
				if (infoMessages[i].MessageSource is InfoMessageSourceStaffBreak infoMessageSourceStaffBreak)
				{
					infoMessageSourceStaffBreak.StaffType = staffType;
				}
			}
			Refresh();
			_speechBubbleDisplayTimer = _speechBubbleDisplayTime;
		}
	}
}
