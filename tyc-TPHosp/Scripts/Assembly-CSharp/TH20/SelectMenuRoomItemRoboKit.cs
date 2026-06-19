using System;
using FullInspector;
using I2.Loc;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SelectMenuRoomItemRoboKit : SelectMenuRoomItem
	{
		[SerializeField]
		private DynamicButton[] _kitButtons;

		[SerializeField]
		private Image[] _kitButtonImages;

		private RoomItemRoboKitComponent _roboKitComponent;

		public override void Setup(RoomItem roomItem, Level level)
		{
			base.Setup(roomItem, level);
			_roboKitComponent = _roomItem.GetComponent<RoomItemRoboKitComponent>();
			int num = 0;
			FinanceManager financeManager = level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			UpdateAllButtonsSelectability();
			SharedInstance<RoboJanitorDefinition>[] janitorDefinitions = _roboKitComponent.JanitorDefinitions;
			foreach (SharedInstance<RoboJanitorDefinition> sharedInstance in janitorDefinitions)
			{
				DynamicButton obj = _kitButtons[num];
				Image image = _kitButtonImages[num];
				RoboJanitorDefinition instance = sharedInstance.Instance;
				TooltipSpawner component = obj.GetComponent<TooltipSpawner>();
				obj.GetComponent<ButtonAnimator>();
				image.overrideSprite = instance._icon;
				obj.onPrimaryDown.AddListener(delegate
				{
					if (_roboKitComponent.SpawnAllowed(instance))
					{
						_roboKitComponent.SelectJanitor(instance);
						CloseMenu();
					}
				});
				if (component != null)
				{
					component.SetDataProvider(delegate(Tooltip tooltip)
					{
						string translation = instance.JobDescription.Translation;
						bool num3 = _roboKitComponent.CanAfford(instance);
						bool flag = _roboKitComponent.LimitReached(instance);
						translation += "\n";
						if (!num3)
						{
							translation += "<color=red>";
						}
						translation += ScriptLocalization.Tooltip.SelectMenuRoomItem_RoboKitJobCost_CS.Replace("{[COST]}", StringUtils.FormatCurrency(instance.UpfrontCost));
						if (!num3)
						{
							translation += "</color>";
						}
						if (flag)
						{
							translation += "\n";
							translation += "<color=red>";
							translation += ScriptLocalization.Tooltip.SelectMenuRoomItem_RoboKitJobLimitReached_CS;
							translation += "</color>";
						}
						tooltip.Text = translation;
					});
				}
				num++;
			}
			for (int num2 = num; num2 < _kitButtons.Length; num2++)
			{
				GameObjectUtils.SetActive(_kitButtons[num2].gameObject, isActive: false);
			}
		}

		public override void CloseMenu()
		{
			int num = 0;
			SharedInstance<RoboJanitorDefinition>[] janitorDefinitions = _roboKitComponent.JanitorDefinitions;
			for (int i = 0; i < janitorDefinitions.Length; i++)
			{
				_ = janitorDefinitions[i];
				_kitButtons[num].onPrimaryDown.RemoveAllListeners();
				num++;
			}
			FinanceManager financeManager = base.Level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			base.CloseMenu();
		}

		private void OnBalanceUpdated(int newBalance)
		{
			UpdateAllButtonsSelectability();
		}

		private void UpdateAllButtonsSelectability()
		{
			int num = 0;
			SharedInstance<RoboJanitorDefinition>[] janitorDefinitions = _roboKitComponent.JanitorDefinitions;
			foreach (SharedInstance<RoboJanitorDefinition> sharedInstance in janitorDefinitions)
			{
				DynamicButton obj = _kitButtons[num];
				Image image = _kitButtonImages[num];
				RoboJanitorDefinition instance = sharedInstance.Instance;
				ButtonAnimator component = obj.GetComponent<ButtonAnimator>();
				bool flag = (obj.interactable = _roboKitComponent.SpawnAllowed(instance));
				if (component != null)
				{
					component.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				}
				if (image != null)
				{
					image.color = (flag ? Color.white : Color.gray);
				}
				num++;
			}
		}
	}
}
