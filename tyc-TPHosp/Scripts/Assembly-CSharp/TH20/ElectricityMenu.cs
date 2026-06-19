using System.Collections.Generic;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ElectricityMenu : AnimatedMenuBase
	{
		[SerializeField]
		private DynamicButton _tabButtonExpand;

		[SerializeField]
		private DynamicButton _tabButtonClose;

		[SerializeField]
		private GameObject _modPanel;

		[SerializeField]
		private ElectricityAssignmentItem _assignmentPrefab;

		[SerializeField]
		private TMP_Text _energyOutputText;

		[SerializeField]
		private ProgressBarMaskable _energyOutputProgressBar;

		[SerializeField]
		private TMP_Text _roomUsageText;

		[SerializeField]
		private ProgressBarMaskable _roomUsageProgressBar;

		[SerializeField]
		private TooltipSpawner _roomUsageTextTooltip;

		[SerializeField]
		private TooltipSpawner _roomUsageBarTooltip;

		private ChallengeElectricity _challenge;

		private bool _modPanelActive;

		private readonly List<ElectricityAssignmentItem> _assignmentItems = new List<ElectricityAssignmentItem>();

		private void Start()
		{
		}

		public void Setup(ChallengeElectricity challenge)
		{
			_challenge = challenge;
			_tabButtonExpand.interactable = true;
			_tabButtonExpand.onPrimaryDown.AddListener(OnTabButtonPressed);
			_tabButtonClose.interactable = false;
			_tabButtonClose.onPrimaryDown.AddListener(OnTabButtonPressed);
			GameObjectUtils.SetActive(_tabButtonClose.gameObject, isActive: false);
			_challenge.OnAllocatedElectricityChanged.AddListener(OnElectricityChanged);
			_challenge.OnTotalElectricityChanged.AddListener(OnElectricityChanged);
			_challenge.OnRoomListChanged.AddListener(OnRoomStatusChange);
			_challenge.OnRoomAllocationChanged.AddListener(OnRoomStatusChange);
			GameObjectUtils.SetActive(_modPanel, isActive: false);
			_assignmentItems.Clear();
			foreach (ChallengeElectricityConfig.ElectricityTypeEntry activeAssignment in _challenge.Config.ActiveAssignments)
			{
				if (activeAssignment.Type != ChallengeElectricity.ElectricityType.Rooms && activeAssignment.Enabled)
				{
					ElectricityAssignmentItem electricityAssignmentItem = Object.Instantiate(_assignmentPrefab, _modPanel.transform);
					if (electricityAssignmentItem != null)
					{
						electricityAssignmentItem.Setup(this, _challenge, activeAssignment);
						_assignmentItems.Add(electricityAssignmentItem);
					}
				}
			}
			if (_roomUsageTextTooltip != null)
			{
				_roomUsageTextTooltip.SetDataProvider(TooltipDataProvider);
			}
			if (_roomUsageBarTooltip != null)
			{
				_roomUsageBarTooltip.SetDataProvider(TooltipDataProvider);
			}
			OnElectricityChanged();
			OnRoomStatusChange();
		}

		protected override void Update()
		{
			base.Update();
		}

		private void OnTabButtonPressed()
		{
			if (_modPanelActive)
			{
				_modPanelActive = false;
				GameObjectUtils.SetActive(_modPanel, isActive: false);
				_tabButtonClose.interactable = false;
				GameObjectUtils.SetActive(_tabButtonClose.gameObject, isActive: false);
				_tabButtonExpand.interactable = true;
				GameObjectUtils.SetActive(_tabButtonExpand.gameObject, isActive: true);
			}
			else
			{
				_modPanelActive = true;
				GameObjectUtils.SetActive(_modPanel, isActive: true);
				_tabButtonClose.interactable = true;
				GameObjectUtils.SetActive(_tabButtonClose.gameObject, isActive: true);
				_tabButtonExpand.interactable = false;
				GameObjectUtils.SetActive(_tabButtonExpand.gameObject, isActive: false);
			}
		}

		private void OnRoomStatusChange()
		{
			int electricityAllocation = _challenge.GetElectricityAllocation(ChallengeElectricity.ElectricityType.Rooms);
			int totalRooms = _challenge.TotalRooms;
			_roomUsageText.text = StringUtils.FormatInteger(electricityAllocation) + "/" + StringUtils.FormatInteger(totalRooms);
			if (totalRooms > 0)
			{
				_roomUsageProgressBar.SetProgressSmooth((float)electricityAllocation / (float)totalRooms);
			}
			else
			{
				_roomUsageProgressBar.SetProgressSmooth(1f);
			}
		}

		private void OnElectricityChanged()
		{
			_energyOutputText.text = StringUtils.FormatInteger(_challenge.AllocatedElectricity) + "/" + StringUtils.FormatInteger(_challenge.TotalElectricity);
			if (_challenge.TotalElectricity > 0)
			{
				_energyOutputProgressBar.SetProgressSmooth((float)_challenge.AllocatedElectricity / (float)_challenge.TotalElectricity);
			}
			else
			{
				_energyOutputProgressBar.SetProgressSmooth(1f);
			}
		}

		private void TooltipDataProvider(Tooltip tooltip)
		{
			if (_challenge != null)
			{
				tooltip.Text = _challenge.Config.RoomUsageTooltip.Translation;
			}
		}

		public void Suspend()
		{
			if (_modPanelActive)
			{
				OnTabButtonPressed();
			}
			GameObjectUtils.SetActive(_tabButtonExpand.gameObject, isActive: false);
		}

		public void Restore()
		{
			GameObjectUtils.SetActive(_tabButtonExpand.gameObject, isActive: true);
		}

		public override void Destroy()
		{
			_tabButtonExpand.onPrimaryDown.RemoveListener(OnTabButtonPressed);
			if (_challenge == null)
			{
				return;
			}
			_challenge.OnAllocatedElectricityChanged.RemoveListener(OnElectricityChanged);
			_challenge.OnTotalElectricityChanged.RemoveListener(OnElectricityChanged);
			_challenge.OnRoomListChanged.RemoveListener(OnRoomStatusChange);
			_challenge.OnRoomAllocationChanged.RemoveListener(OnRoomStatusChange);
			foreach (ElectricityAssignmentItem assignmentItem in _assignmentItems)
			{
				if (assignmentItem != null)
				{
					assignmentItem.Destroy();
				}
			}
		}
	}
}
