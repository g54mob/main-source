using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using __Project__.Scripts.BakeryWorker;

namespace __Project__.Scripts.Computer.Management.Hiring_Tab
{
	public class BakerItem : MonoBehaviour
	{
		[SerializeField]
		private BakerSO m_BakerSetup;

		[Header("Components")]
		[SerializeField]
		private LocalizeStringEvent m_BakerName;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedDailyWageText;

		[SerializeField]
		private TMP_Text m_DailyWageText;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedHiringCostText;

		[SerializeField]
		private TMP_Text m_HiringCostText;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedOvenObjectiveText;

		[SerializeField]
		private TMP_Text m_OvenObjectiveText;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedBakeryDisplayObjectiveText;

		[SerializeField]
		private TMP_Text m_BakeryDisplayObjectiveText;

		[SerializeField]
		private Button m_HireButton;

		[SerializeField]
		private Button m_FireButton;

		[Header("Colors")]
		[SerializeField]
		private Color m_CompletedRequirementColor;

		[SerializeField]
		private Color m_IncompletedRequirementColor;

		[SerializeField]
		private int m_OvenFurnitureId;

		[SerializeField]
		private List<int> m_BakerFurnitureIds;

		private bool m_Hired;

		private bool IsOvenCountEnough => false;

		private bool IsBakeryDisplayCountEnough => false;

		public bool Hired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int BakerId => 0;

		public float HiringCost => 0f;

		public string OvenObjectiveText => null;

		public string BakeryDisplayObjectiveText => null;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		public void Hire()
		{
		}

		public void Fire()
		{
		}

		public void SwitchForGamepad()
		{
		}

		private void Setup()
		{
		}

		private void UpdateOvenObjective(Oven oven)
		{
		}

		private void UpdateBakeryDisplayObjective(Display display)
		{
		}

		private void MoneyChanged(float _amount, MoneyManager.TransitionType _type)
		{
		}
	}
}
