using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuResearch : SelectMenuRoomItemBase
	{
		[SerializeField]
		private TMP_Text _projectName;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		[SerializeField]
		private DynamicButton _pickupButton;

		[SerializeField]
		private DynamicButton _shelveButton;

		[SerializeField]
		private DynamicButton _sellButton;

		[SerializeField]
		private TooltipSpawner _pickupButtonTooltip;

		[SerializeField]
		private TooltipSpawner _shelveButtonTooltip;

		[SerializeField]
		private TooltipSpawner _sellButtonTooltip;

		private ResearchProject _assignedProject;

		private bool _triggerPickup;

		public override void Setup(RoomItem roomItem, Level level)
		{
			base.Setup(roomItem, level);
			_assignedProject = _roomItem.GetComponent<ResearchProjectComponent>().Project;
			if (_assignedProject == null)
			{
				base.HUD.DestroyMenu(this);
				base.HUD.CreateMenu<ResearchProjectMenu>().Setup(level, roomItem);
				return;
			}
			_shelveButton.gameObject.SetActive(value: true);
			_projectName.text = ScriptLocalization.Menu.Hover_Research_ProjectName_CS.Replace("{[NAME]}", _assignedProject.Definition.NameLocalised.Translation);
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			ResearchManager researchManager = base.Level.ResearchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			if (_pickupButton != null)
			{
				_pickupButton.onPrimaryDown.AddListener(delegate
				{
					_triggerPickup = true;
				});
				_pickupButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_Pickup_CS;
				});
			}
			if (_shelveButton != null)
			{
				_shelveButton.onPrimaryDown.AddListener(ShelveButton);
				_shelveButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_Shelve_CS;
				});
			}
			if (_sellButton != null)
			{
				_sellButton.onPrimaryDown.AddListener(SellButton);
				_sellButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					string newValue = StringUtils.FormatCurrency(_roomItem.SellValue());
					tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_Sell_CS.Replace("{[COST]}", newValue);
				});
			}
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			ResearchManager researchManager = base.Level.ResearchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			base.Destroy();
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem == _roomItem)
			{
				CloseMenu();
			}
		}

		private void OnResearchProjectComplete(ResearchProject researchProject)
		{
			if (researchProject == _assignedProject)
			{
				CloseMenu();
			}
		}

		private void PickupButton()
		{
			base.Level.BuildEvents.StartItemEdit(_roomItem, _roomItem.OwningRoom);
			CloseMenu();
		}

		private void ShelveButton()
		{
			base.Level.ResearchManager.RemoveResearchProject(_assignedProject, _roomItem);
			CloseMenu();
		}

		private void SellButton()
		{
			base.Level.BuildEvents.OnRoomItemSold.InvokeSafe(_roomItem);
			base.Level.BuildEvents.OnRoomItemDestroy.InvokeSafe(_roomItem);
			CloseMenu();
		}

		private void OnSelect(ResearchProject researchProject)
		{
			base.Level.ResearchManager.AssignProject(researchProject, _roomItem);
			CloseMenu();
		}

		protected override void Update()
		{
			base.Update();
			if (_triggerPickup)
			{
				_triggerPickup = false;
				PickupButton();
			}
			if (_assignedProject != null)
			{
				_progressBar.Progress = _assignedProject.ResearchedPoints / _assignedProject.Definition.ResearchPoints;
				_progressBar.LabelText = $"{(int)_assignedProject.ResearchedPoints} / {(int)_assignedProject.Definition.ResearchPoints}";
			}
		}
	}
}
