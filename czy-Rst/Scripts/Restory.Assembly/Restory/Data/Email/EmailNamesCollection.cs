using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Email
{
	[CreateAssetMenu(menuName = "Restory/Email/EmailNamesCollection", fileName = "EmailNamesCollection")]
	public class EmailNamesCollection : ScriptableObject
	{
		[SerializeField]
		private EmailContact[] entries = new EmailContact[0];

		public IReadOnlyList<EmailContact> EmailContacts => entries;
	}
}
