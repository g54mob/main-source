using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Computer.Services
{
	public interface IMailService
	{
		Dictionary<string, string> CustomContentKeys { get; }

		Dictionary<string, string> MissionIDs { get; }

		Dictionary<string, GameObject> CustomContentInstances { get; }

		void SendMail(MailObject mailObject);
	}
}
