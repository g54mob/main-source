using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class MessageQueue
	{
		private List<INetworkData> UpToDateMessages = new List<INetworkData>();

		private List<INetworkData> Messages = new List<INetworkData>();

		private Dictionary<MessageIdentifier, IRollUp> SeenIdentifiers = new Dictionary<MessageIdentifier, IRollUp>();

		private Dictionary<MessageIdentifier, INetworkData> RolledUpMessages = new Dictionary<MessageIdentifier, INetworkData>();

		public int Count => Messages.Count;

		public void Add(INetworkData message)
		{
			Messages.Add(message);
		}

		public void Clear()
		{
			Messages.Clear();
		}

		public void RemoveCount(int parts_sent)
		{
			Messages.RemoveRange(0, parts_sent);
		}

		public List<INetworkData> GetAllMessages()
		{
			return Messages;
		}

		public List<INetworkData> RollUpMessages()
		{
			RolledUpMessages.Clear();
			UpToDateMessages.Clear();
			bool flag = false;
			foreach (INetworkData message in Messages)
			{
				INetworkData value;
				if (!message.GetRollUp(out var identifier, out var roll_up))
				{
					UpToDateMessages.Add(message);
					if (flag)
					{
						Debug.LogWarning(" -> Not rolled up");
					}
				}
				else if (RolledUpMessages.TryGetValue(identifier, out value))
				{
					if (roll_up is IRollUpCombine rollUpCombine)
					{
						value.GetRollUp(out var _, out var roll_up2);
						if (!rollUpCombine.CombineWith(roll_up2))
						{
							UpToDateMessages.Add(value);
							RolledUpMessages[identifier] = message;
							if (flag)
							{
								Debug.LogWarning(" -> Unable to roll up, sending previous and continuing");
							}
						}
						else
						{
							message.SetRollUp(rollUpCombine);
							RolledUpMessages[identifier] = message;
							if (flag)
							{
								Debug.LogWarning(" -> Rolled up successfully");
							}
						}
					}
					else
					{
						RolledUpMessages[identifier] = message;
						if (flag)
						{
							Debug.LogWarning(" -> Replacement roll up used");
						}
					}
				}
				else
				{
					RolledUpMessages[identifier] = message;
					if (flag)
					{
						Debug.LogWarning(" -> First of type");
					}
				}
			}
			foreach (KeyValuePair<MessageIdentifier, INetworkData> rolledUpMessage in RolledUpMessages)
			{
				UpToDateMessages.Add(rolledUpMessage.Value);
			}
			float unscaledTime = Time.unscaledTime;
			float num = Messages.Count - UpToDateMessages.Count;
			StatTracker.Main.Report(StatType.NetworkFilteredPacketCount, unscaledTime, num);
			StatTracker.Main.Report(StatType.NetworkFilteredPacketRatio, unscaledTime, num / (float)Messages.Count);
			return UpToDateMessages;
		}
	}
}
