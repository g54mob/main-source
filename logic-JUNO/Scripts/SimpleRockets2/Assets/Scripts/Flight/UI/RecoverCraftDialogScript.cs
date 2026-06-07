using System;
using Assets.Scripts.Ui;
using ModApi.Math;
using ModApi.Ui;
using UI.Xml;

namespace Assets.Scripts.Flight.UI
{
	public class RecoverCraftDialogScript : StatsDialogScript
	{
		public Action CraftDestroyed { get; set; }

		public Action CraftRecovered { get; set; }

		public Action OnRetryClicked { get; set; }

		public static RecoverCraftDialogScript Create(CraftRecovery recovery, bool showRetryButton = false)
		{
			RecoverCraftDialogScript recoverCraftDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/StatsDialog", null, delegate(RecoverCraftDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
			recoverCraftDialogScript.ShowRecovery(recovery, showRetryButton);
			return recoverCraftDialogScript;
		}

		private void ShowRecovery(CraftRecovery recovery, bool showRetryButton)
		{
			ClearStats();
			if (showRetryButton)
			{
				SetButtonText(base.ButtonLeft, "RETRY / UNDO");
				base.ButtonLeft.AddOnClickEvent(delegate
				{
					Close();
					OnRetryClicked?.Invoke();
				});
				base.ButtonLeft.Tooltip = "There's no penalty for trying again. If you didn't complete any contracts or milestones, this is the recommended option.";
			}
			else
			{
				base.ButtonLeft.SetActive(active: false);
			}
			SetButtonText(base.ButtonCenter, "DESTROY CRAFT");
			base.ButtonCenter.AddClass("btn-danger");
			base.ButtonCenter.Tooltip = "Recommended if don't need this craft anymore, but not recommended if there are atronauts on board!";
			SetButtonText(base.ButtonRight, "RECOVER CRAFT");
			base.ButtonRight.Tooltip = "Recover money from this craft's parts. Recommended unless it will cost money, but always recommended if there are astronauts on board.";
			base.ButtonCenter.AddOnClickEvent(delegate
			{
				Close();
				CraftDestroyed?.Invoke();
			});
			base.ButtonRight.AddOnClickEvent(delegate
			{
				Close();
				recovery.RecoverCraft();
				CraftRecovered?.Invoke();
			});
			_headerText.text = "RECOVER CRAFT";
			XmlElement buttonRight = base.ButtonRight;
			XmlElement buttonCenter = base.ButtonCenter;
			string empty = string.Empty;
			if (recovery.CanRecover)
			{
				buttonRight.SetActive(active: true);
				if (recovery.TotalPrice > 0f)
				{
					buttonCenter.SetActive(active: false);
					AddStat("Recovery Bonus", "<color=#00b7ed>" + Units.GetMoneyString((long)recovery.TotalPrice) + "</color>");
					empty = "Would you like to recover this craft?";
				}
				else
				{
					buttonCenter.SetActive(active: true);
					if (recovery.NumAstronauts > 0)
					{
						empty = "Would you like to recover this craft? It's going to cost money, but there are astronauts onboard!";
					}
					else
					{
						empty = "It's going to cost money to recover this craft, so it's best to just destroy it.";
						buttonRight.SetActive(active: false);
					}
					AddStat("Recovery Cost", "<color=#e7515a>" + Units.GetMoneyString(-(long)recovery.TotalPrice) + "</color>");
				}
				AddStat("Recoverable Parts", recovery.NumParts.ToString());
				AddStat("Recovery Location", recovery.ClosestLocation.Name);
				AddStat("Recovery Distance", Units.GetDistanceString((float)recovery.ClosestDistance));
				if (recovery.NumAstronauts > 0)
				{
					AddStat("Astronauts Onboard", recovery.NumAstronauts.ToString());
				}
			}
			else
			{
				if (recovery.IsDestroyed)
				{
					empty = "This craft cannot be recovered because it is destroyed. Would you like to save this flight and exit?";
					buttonCenter.RemoveClass("btn-danger");
					buttonCenter.SetText("SAVE FLIGHT");
				}
				else
				{
					empty = recovery.FailMessage + "\n\nWould you like to destroy this craft instead?";
				}
				buttonCenter.SetActive(active: true);
				buttonRight.SetActive(active: false);
			}
			if (base.ButtonCancel.gameObject.activeSelf && base.ButtonLeft.gameObject.activeSelf && base.ButtonCenter.gameObject.activeSelf && base.ButtonRight.gameObject.activeSelf)
			{
				SetButtonText(base.ButtonLeft, "RETRY");
				SetButtonText(buttonCenter, "DESTROY");
				SetButtonText(buttonRight, "RECOVER");
			}
			if (Game.InFlightScene && showRetryButton)
			{
				empty += "\n\nIf you're not happy with what you accomplished this flight, then it might be best to Retry / Undo instead.";
			}
			_statsHeader.text = empty;
		}
	}
}
