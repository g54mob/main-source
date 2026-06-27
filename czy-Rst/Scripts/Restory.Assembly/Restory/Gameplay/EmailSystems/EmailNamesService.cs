using System;
using System.Collections.Generic;
using Restory.Data.Email;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.EmailSystems
{
	public sealed class EmailNamesService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		[SerializeField]
		private EmailNamesCollection emailNamesCollection;

		private readonly List<EmailContact> unusedEmailContacts = new List<EmailContact>();

		private readonly List<EmailContact> usedEmailContacts = new List<EmailContact>();

		public IReadOnlyList<EmailContact> EmailContacts => emailNamesCollection.EmailContacts;

		public EmailContact GetRandomEmailContact()
		{
			int count = unusedEmailContacts.Count;
			if (count == 0)
			{
				RefillContactsList();
				count = unusedEmailContacts.Count;
			}
			int index = UnityEngine.Random.Range(0, count);
			EmailContact emailContact = unusedEmailContacts[index];
			unusedEmailContacts.Remove(emailContact);
			usedEmailContacts.Add(emailContact);
			return emailContact;
		}

		private void RefillContactsList()
		{
			unusedEmailContacts.Clear();
			usedEmailContacts.Clear();
			unusedEmailContacts.AddRange(emailNamesCollection.EmailContacts);
		}

		public object CaptureState()
		{
			try
			{
				return new EmailNamesServiceSaveData
				{
					UsedContacts = usedEmailContacts.ToArray()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				EmailNamesServiceSaveData emailNamesServiceSaveData = DataMigrationWizard.Migrate<EmailNamesServiceSaveData>(state, base.gameObject);
				usedEmailContacts.Clear();
				usedEmailContacts.AddRange(emailNamesServiceSaveData.UsedContacts);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			foreach (EmailContact emailContact in emailNamesCollection.EmailContacts)
			{
				if (!unusedEmailContacts.Contains(emailContact) && !usedEmailContacts.Contains(emailContact))
				{
					unusedEmailContacts.Add(emailContact);
				}
			}
		}
	}
}
