using System.Collections.Generic;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffMenuRowBase : MonoBehaviour
	{
		[Header("UI")]
		[SerializeField]
		protected DynamicButton RowButton;

		[SerializeField]
		protected ButtonAnimator RowButtonAnimator;

		[Header("Type")]
		[SerializeField]
		protected Image TypeIcon;

		[Header("Name")]
		[SerializeField]
		protected TMP_Text NameText;

		[Header("Level")]
		[SerializeField]
		protected StarIcons StarIcons;

		[SerializeField]
		private TooltipSpawner[] _tooltipSpawner = new TooltipSpawner[5];

		[Header("Qualifications")]
		[SerializeField]
		protected QualificationIcons QualificationIcons;

		[Header("RowHighlight")]
		[SerializeField]
		protected Image _rowBackground;

		[SerializeField]
		protected Sprite _rowAlternateBackground;

		private Sprite _rowMainBackground;

		public Staff Staff { get; private set; }

		protected Level Level { get; private set; }

		protected StaffMenu StaffMenu { get; private set; }

		public DynamicButton Button => RowButton;

		public ButtonAnimator ButtonAnimator => RowButtonAnimator;

		public virtual void Setup(Staff staff, List<JobDescription> jobs, StaffMenu staffMenu)
		{
			Staff = staff;
			StaffMenu = staffMenu;
			if (Staff != null && Level == null)
			{
				Level = Staff.Level;
			}
			if (_rowMainBackground == null)
			{
				_rowMainBackground = _rowBackground.sprite;
			}
			Button.onPrimaryDown.AddListener(OnRowButtonClick);
			Button.onSecondaryDown.AddListener(OnRowRightClicked);
			StarIcons.OnPromoteClicked = delegate
			{
				OnRowButtonClick();
				staff.ShowReadyForPromotionMessage(immediately: true);
			};
			StarIcons.OnRowClicked = delegate
			{
				OnRowButtonClick();
			};
			TooltipSpawner[] tooltipSpawner = _tooltipSpawner;
			for (int num = 0; num < tooltipSpawner.Length; num++)
			{
				tooltipSpawner[num].SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = GameStringUtils.GetStaffRankTooltip(Staff);
				});
			}
		}

		public virtual void OnDestroy()
		{
		}

		private void OnRowButtonClick()
		{
			Level.BuildEvents.OnCursorSelectObject.InvokeSafe(Staff);
		}

		private void OnRowRightClicked()
		{
			if (Staff.CanPickup())
			{
				Level.CharacterEvents.OnStaffPickup.InvokeSafe(Staff, null);
			}
		}

		public virtual void Refresh(bool instant = false)
		{
			if (Staff == null)
			{
				NameText.text = string.Empty;
				return;
			}
			NameText.text = Staff.Name;
			if (Staff.RankDefinition != null)
			{
				StarIcons.SetLevel(Staff.Rank, Staff.IsReadyForPromotion, Staff.XP.Value() / Staff.RankDefinition.MaximumXP);
			}
			QualificationIcons.UpdateFrom(Staff.Qualifications, Staff.MaxQualifications, Level.CharacterManager.StaffMembers);
		}

		public virtual void SetRowBackground(int rowNum)
		{
			if ((bool)_rowBackground)
			{
				_rowBackground.sprite = ((rowNum % 2 == 1) ? _rowAlternateBackground : _rowMainBackground);
			}
		}

		public void SetTypeSprite(Sprite typeSprite)
		{
			if ((bool)TypeIcon)
			{
				TypeIcon.sprite = typeSprite;
			}
		}

		protected void Update()
		{
			Refresh();
		}
	}
}
