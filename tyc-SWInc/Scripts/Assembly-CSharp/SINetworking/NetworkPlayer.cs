using System;
using System.Collections.Generic;
using UnityEngine;

namespace SINetworking
{
	public class NetworkPlayer : IFormatColorObject
	{
		public enum ReadyStatus
		{
			NotReady = 0,
			Ready = 1,
			ReadyForSync = 2,
			OkayToSave = 3
		}

		public class SendBuffer
		{
			public byte[] Data;

			public int Offset;

			public SendBuffer(byte[] data)
			{
				Data = data;
				Offset = 0;
			}

			public byte[] GetData(int amount)
			{
				if (Offset == 0 && amount == Data.Length)
				{
					return Data;
				}
				byte[] array = new byte[amount];
				for (int i = 0; i < amount; i++)
				{
					array[i] = Data[i + Offset];
				}
				return array;
			}

			public void MoveOffset(int amount)
			{
				if (Offset == 0 && amount == Data.Length)
				{
					Offset = Data.Length;
				}
				else
				{
					Offset += amount;
				}
			}
		}

		public struct DeferredCompanyData
		{
			public uint CompanyID;

			public string CompanyName;

			public double CompanyMoney;

			public byte[] CompanyLogo;
		}

		public string Name;

		public string UniqueID;

		public bool HandshakeComplete;

		public string UniqueIDOverride;

		public string ReconnectionData;

		public object ConnectionObject;

		public uint StartPlot;

		public byte ID = byte.MaxValue;

		public bool Host;

		public bool Self;

		public bool WaitingToJoin;

		public bool Connected = true;

		public bool SendingSave;

		public bool InGame;

		public ReadyStatus Ready;

		public DateTime ReadyTiming;

		public int CurrentHour;

		public float CurrentMinute;

		public float CurrentGameSpeed;

		public float KeepAlive;

		public bool InBuildMode;

		public bool AFK;

		public bool VoteToSkip;

		public uint Sent;

		public uint Received;

		public uint MaxQueued;

		public uint Overhead;

		public uint[] SentPerType;

		public uint[] ReceivedPerType;

		public bool WaitingForReconnection;

		private Texture2D _avatar;

		private bool _avatarInit;

		public float? Ping;

		public DeferredCompanyData DeferredCompany;

		public byte[] CurrentBuffer;

		public int BufferOffset;

		public int BufferLength;

		public List<SendBuffer> SendQueue = new List<SendBuffer>();

		private byte[] _unfinishedBufferSize = new byte[4];

		private int _unfinishedBufferOffset;

		public string ActualUniqueID
		{
			get
			{
				return UniqueIDOverride ?? UniqueID;
			}
		}

		public bool IsReady
		{
			get
			{
				if (Ready != ReadyStatus.NotReady)
				{
					return Ready != ReadyStatus.OkayToSave;
				}
				return false;
			}
		}

		public uint CurrentQueued
		{
			get
			{
				uint num = 0u;
				lock (this)
				{
					for (int i = 0; i < SendQueue.Count; i++)
					{
						num += (uint)(SendQueue[i].Data.Length - SendQueue[i].Offset);
					}
					return num;
				}
			}
		}

		public void ClearAvatar()
		{
			if (_avatar != null)
			{
				UnityEngine.Object.Destroy(_avatar);
			}
			_avatarInit = false;
		}

		public bool TryGetAvatar(out Texture2D tex)
		{
			if (_avatarInit)
			{
				tex = _avatar;
				return true;
			}
			_avatar = (tex = NetworkLayer.Active.GetPlayerAvatar(this, out _avatarInit));
			return _avatarInit;
		}

		public NetworkPlayer(string name, string uniqueID, string connectionData)
		{
			Name = name;
			UniqueID = uniqueID;
			Host = true;
			Self = true;
			ID = 1;
			SentPerType = new uint[136];
			ReceivedPerType = new uint[136];
			ReconnectionData = connectionData;
		}

		public NetworkPlayer(string name, string uniqueID, byte id, string connectionData)
		{
			Name = name;
			UniqueID = uniqueID;
			ID = id;
			Host = false;
			Self = false;
			SentPerType = new uint[136];
			ReceivedPerType = new uint[136];
			ReconnectionData = connectionData;
		}

		public NetworkPlayer(object connectionObject)
		{
			ConnectionObject = connectionObject;
			Host = false;
			Self = false;
			SentPerType = new uint[136];
			ReceivedPerType = new uint[136];
		}

		public void ResetStats()
		{
			Sent = 0u;
			Received = 0u;
			MaxQueued = 0u;
			for (int i = 0; i < SentPerType.Length; i++)
			{
				SentPerType[i] = 0u;
				ReceivedPerType[i] = 0u;
			}
		}

		public void ReceiveData(byte[] data)
		{
			Received += (uint)data.Length;
			for (int i = 0; i < data.Length; i++)
			{
				if (_unfinishedBufferOffset > 0)
				{
					_unfinishedBufferSize[_unfinishedBufferOffset] = data[i];
					_unfinishedBufferOffset++;
					if (_unfinishedBufferOffset == 4)
					{
						_unfinishedBufferOffset = 0;
						BufferLength = BitConverter.ToInt32(_unfinishedBufferSize, 0);
						CurrentBuffer = new byte[BufferLength];
					}
					continue;
				}
				if (BufferLength == 0)
				{
					int num = data.Length - i;
					if (num < 4)
					{
						for (int j = 0; j < num; j++)
						{
							_unfinishedBufferSize[j] = data[i + j];
						}
						_unfinishedBufferOffset = num;
						break;
					}
					BufferLength = BitConverter.ToInt32(data, i);
					CurrentBuffer = new byte[BufferLength];
					i += 3;
					continue;
				}
				CurrentBuffer[BufferOffset] = data[i];
				BufferOffset++;
				if (BufferOffset == BufferLength)
				{
					try
					{
						NetworkMessaging.ReceiveMessage(this, CurrentBuffer);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					BufferOffset = 0;
					BufferLength = 0;
				}
			}
		}

		public override string ToString()
		{
			return string.Concat(Name, " (", ConnectionObject, ")");
		}

		public string GetActualString()
		{
			return Name;
		}

		public string GetGameStatus(bool state)
		{
			string text = "";
			if (state)
			{
				text = GetState();
				if (!string.IsNullOrEmpty(text))
				{
					text = " (" + text + ")";
				}
			}
			if (!Connected)
			{
				return "Offline".Loc();
			}
			return Utilities.HourToTime(CurrentHour, (int)CurrentMinute, Options.AMPM) + text;
		}

		public string GetState()
		{
			if (AFK)
			{
				return "AwayFromKeyboard".Loc();
			}
			if (InBuildMode)
			{
				return "BuildMode".Loc();
			}
			if (CurrentGameSpeed == 0f)
			{
				return "Paused".Loc();
			}
			return "";
		}

		public Company GetPlayerCompany()
		{
			MarketSimulation active = MarketSimulation.Active;
			if (active == null)
			{
				return null;
			}
			return active.GetPlayerCompany(ID);
		}
	}
}
