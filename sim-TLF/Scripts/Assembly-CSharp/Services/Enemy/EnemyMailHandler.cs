using System.Collections.Generic;
using Computer.Services;
using Data;
using Loxodon.Framework.Contexts;
using Michsky.DreamOS;
using UI.HUD.Assistant;

namespace Services.Enemy
{
	public class EnemyMailHandler
	{
		private List<EnemyMail> _enemyMails = new List<EnemyMail>
		{
			new EnemyMail("Don't forget about your loand and abandoned job.")
			{
				LoyaltyValue = 25f
			},
			new EnemyMail("Stop doing stuff you doing or someone gonna be hurt soon. We track you.")
			{
				LoyaltyValue = 65f
			},
			new EnemyMail("Wait us in your squre. We take what's ours")
			{
				LoyaltyValue = 95f
			}
		};

		private readonly IMailService _mailService;

		private readonly ILoyaltyService _loyaltyService;

		private readonly MailManager _mailManager;

		private AssistantPopupViewModel _assistantPopupViewModel;

		public EnemyMailHandler(IMailService mailService, ILoyaltyService loyaltyService, MailManager mailManager)
		{
			_mailService = mailService;
			_loyaltyService = loyaltyService;
			_mailManager = mailManager;
			_assistantPopupViewModel = Context.GetApplicationContext().GetService<AssistantPopupViewModel>();
			_loyaltyService.StressValueChanged += OnStressValueChanged;
		}

		private void OnStressValueChanged(float stress)
		{
			foreach (EnemyMail enemyMail in _enemyMails)
			{
				if (stress >= enemyMail.LoyaltyValue && !HasEmail(enemyMail.Mail))
				{
					_assistantPopupViewModel.Appear();
					_assistantPopupViewModel.SetSpeechBubbleVisible(value: true);
					_assistantPopupViewModel.SetSpeechBubbleText("You've just recieved new email. Go chek it until it's too late...");
					_mailService.SendMail(enemyMail.Mail);
				}
			}
		}

		private bool HasEmail(MailObject mail)
		{
			foreach (MailManager.MailAsset mail2 in _mailManager.mailList)
			{
				if (mail2.itemTitle == mail.Title && mail2.mailAsset.mailContent == mail.MailContent)
				{
					return true;
				}
			}
			return false;
		}
	}
}
