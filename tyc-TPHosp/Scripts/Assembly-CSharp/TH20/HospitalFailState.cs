using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalFailState : MustCallDestroy
	{
		private readonly Level _level;

		private bool _warningIssued;

		private bool _enabled = true;

		public void SetEnabled(bool enabled)
		{
			_enabled = enabled;
		}

		public HospitalFailState(Level level)
		{
			_level = level;
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
		}

		public override void Destroy()
		{
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			base.Destroy();
		}

		private void OnBalanceUpdated(int balance)
		{
			if (_enabled)
			{
				if (!_warningIssued && balance <= _level.Config.FailStateBalanceWarning)
				{
					IssueWarningLetter();
				}
				if (balance <= _level.Config.FailStateBalanceGameOver && !DebugVars.DisableBankruptcyFailure.Value)
				{
					IssueForeclosureLetter();
				}
				if (balance > _level.Config.FailStateBalanceWarning)
				{
					IssueWarningCancelled();
				}
			}
		}

		private void IssueWarningLetter()
		{
			_warningIssued = true;
			NotificationDynamicMessage notificationDynamicMessage = new NotificationDynamicMessage(_level.Notifications.MessageDefinitions.FailStateWarning.Instance, null, _level);
			notificationDynamicMessage.FuncGetMessage = (Func<string>)Delegate.Combine(notificationDynamicMessage.FuncGetMessage, (Func<string>)(() => LocalisedString.Replace(ScriptLocalization.Notification.FailStateWarning_Message_CS, new SubPair[2]
			{
				new SubPair("{[WARNING]}", StringUtils.FormatCurrency(_level.Config.FailStateBalanceWarning)),
				new SubPair("{[GAMEOVER]}", StringUtils.FormatCurrency(_level.Config.FailStateBalanceGameOver))
			})));
			_level.Notifications.OpenPopup(notificationDynamicMessage);
		}

		private void IssueWarningCancelled()
		{
			_warningIssued = false;
		}

		private void IssueForeclosureLetter()
		{
			NotificationDynamicMessage notificationDynamicMessage = new NotificationDynamicMessage(_level.Notifications.MessageDefinitions.FailStateGameOver.Instance, delegate(int response)
			{
				if (response == 0)
				{
					_level.MetagameMap.Open();
				}
				else
				{
					_level.App.FadeOut(1f, Color.white, delegate
					{
						_level.App.LoadLevel(_level.Config, null, ignoreSave: false);
					});
				}
			}, _level);
			notificationDynamicMessage.FuncGetMessage = (Func<string>)Delegate.Combine(notificationDynamicMessage.FuncGetMessage, (Func<string>)(() => LocalisedString.Replace(ScriptLocalization.Notification.FailStateGameOver_Message_CS, new SubPair[2]
			{
				new SubPair("{[WARNING]}", StringUtils.FormatCurrency(_level.Config.FailStateBalanceWarning)),
				new SubPair("{[GAMEOVER]}", StringUtils.FormatCurrency(_level.Config.FailStateBalanceGameOver))
			})));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			_level.Notifications.OpenPopup(notificationDynamicMessage);
		}
	}
}
