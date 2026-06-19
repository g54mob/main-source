using System;
using Data;

namespace Services.Enemy
{
	public class EnemyMail
	{
		public MailObject Mail;

		public float LoyaltyValue;

		public EnemyMail(string content)
		{
			Mail = new MailObject
			{
				From = "Sell Coast Group",
				FromName = "P4rty-M4ker",
				Subject = "Loan",
				Date = DateTime.Now.AddYears(100).ToString(),
				Time = DateTime.Now.TimeOfDay.ToString(),
				MailContent = content
			};
		}
	}
}
