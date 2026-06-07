using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.StaffHiring
{
	public class StaffHiringDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private List<Button3DUIView> _closeButtons;

		[SerializeField]
		private Button3DUIView _advertiseButton;

		[SerializeField]
		private Button3DUIView _nextButton;

		[SerializeField]
		private Button3DUIView _previousButton;

		[SerializeField]
		public StaffHireButton Cost;

		public TextMeshProI18n PageIndicator;

		private int _currentIndex;

		private string _previousStaffCsvsHash;

		[SerializeField]
		private StaffHireElement _staffHireElement;

		[SerializeField]
		private Transform _noApplicantAvailable;

		private bool _hiringAllowed;

		private GameObject[] _advertiseFluffVariations;

		protected override void Awake()
		{
		}

		private int GetRecruitmentEventCount()
		{
			return 0;
		}

		private string GetRecruitmentEventHash()
		{
			return null;
		}

		private void UpdateAdvertiseButtonFluffContent()
		{
		}

		private int GetAdvertiseCost()
		{
			return 0;
		}

		protected void Start()
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		private void OnCostClicked(object sender, EventArgs e)
		{
		}

		private void AdvertiseButtonClicked()
		{
		}

		private void OnTavernMoneyChanged(object sender, EventArgs<int> e)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private List<Staff> GetOrderedStaff()
		{
			return null;
		}

		private void Refresh(bool resetIndexIfDataChanged = true)
		{
		}
	}
}
