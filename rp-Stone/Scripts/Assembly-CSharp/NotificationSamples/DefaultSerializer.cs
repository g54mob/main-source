using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NotificationSamples
{
	public class DefaultSerializer : IPendingNotificationsSerializer
	{
		private const byte Version = 1;

		private readonly string filename;

		public DefaultSerializer(string filename)
		{
			this.filename = filename;
		}

		public void Serialize(IList<PendingNotification> notifications)
		{
			try
			{
				using FileStream output = new FileStream(filename, FileMode.Create);
				using BinaryWriter binaryWriter = new BinaryWriter(output);
				binaryWriter.Write((byte)1);
				binaryWriter.Write(notifications.Count);
				foreach (PendingNotification notification2 in notifications)
				{
					IGameNotification notification = notification2.Notification;
					binaryWriter.Write(notification.Id.HasValue);
					if (notification.Id.HasValue)
					{
						binaryWriter.Write(notification.Id.Value);
					}
					binaryWriter.Write(notification.Title ?? "");
					binaryWriter.Write(notification.Body ?? "");
					binaryWriter.Write(notification.Subtitle ?? "");
					binaryWriter.Write(notification.Group ?? "");
					binaryWriter.Write(notification.Data ?? "");
					binaryWriter.Write(notification.BadgeNumber.HasValue);
					if (notification.BadgeNumber.HasValue)
					{
						binaryWriter.Write(notification.BadgeNumber.Value);
					}
					binaryWriter.Write(notification.DeliveryTime.Value.Ticks);
					binaryWriter.Write(notification.LargeIcon ?? "");
					binaryWriter.Write(notification.SmallIcon ?? "");
				}
				binaryWriter.Flush();
			}
			catch (IOException exception)
			{
				Debug.LogException(exception);
			}
		}

		public IList<IGameNotification> Deserialize(IGameNotificationsPlatform platform)
		{
			if (!File.Exists(filename))
			{
				return null;
			}
			try
			{
				using FileStream input = new FileStream(filename, FileMode.Open);
				using BinaryReader binaryReader = new BinaryReader(input);
				byte b = binaryReader.ReadByte();
				int num = binaryReader.ReadInt32();
				List<IGameNotification> list = new List<IGameNotification>(num);
				for (int i = 0; i < num; i++)
				{
					IGameNotification gameNotification = platform.CreateNotification();
					if (binaryReader.ReadBoolean())
					{
						gameNotification.Id = binaryReader.ReadInt32();
					}
					gameNotification.Title = binaryReader.ReadString();
					gameNotification.Body = binaryReader.ReadString();
					gameNotification.Subtitle = binaryReader.ReadString();
					gameNotification.Group = binaryReader.ReadString();
					if (b > 0)
					{
						gameNotification.Data = binaryReader.ReadString();
					}
					if (binaryReader.ReadBoolean())
					{
						gameNotification.BadgeNumber = binaryReader.ReadInt32();
					}
					gameNotification.DeliveryTime = new DateTime(binaryReader.ReadInt64(), DateTimeKind.Local);
					gameNotification.LargeIcon = binaryReader.ReadString();
					gameNotification.SmallIcon = binaryReader.ReadString();
					list.Add(gameNotification);
				}
				return list;
			}
			catch (IOException exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}
	}
}
