using System;
using Controllers;
using Kitchen.NetworkSupport;
using MessagePack;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct PlayerInfo
	{
		[Key(1)]
		public int ID;

		[Key(2)]
		public ConnectionType Connection;

		[Key(3)]
		public SourceIdentifier Identifier;

		[Key(4)]
		public string Username;

		[Key(5)]
		public PlayerProfile Profile;

		[Key(6)]
		public float JoinProgress;

		[Key(7)]
		public int Index;

		[Key(9)]
		public bool IsReportedDisconnectedByServer;

		[IgnoreMember]
		public bool HasAppliedBindings;

		[IgnoreMember]
		public bool HasProfile => Profile.IsRealProfile;

		[IgnoreMember]
		public bool IsLocalUser => Identifier == InputSourceIdentifier.Identifier;

		[IgnoreMember]
		public string Name
		{
			get
			{
				if (!HasProfile)
				{
					return Username;
				}
				return Profile.Name;
			}
		}

		[IgnoreMember]
		public bool IsJoining => JoinProgress > -0.5f;

		[IgnoreMember]
		public string PrimaryName
		{
			get
			{
				if (!IsLocalUser)
				{
					return Profile.Name;
				}
				if (PlatformSettings.OnlyUseSingleNames)
				{
					return Username;
				}
				return Profile.Name;
			}
		}

		[IgnoreMember]
		public string SecondaryName
		{
			get
			{
				if (!PlatformSettings.OnlyUseSingleNames)
				{
					return Username;
				}
				if (IsLocalUser)
				{
					return Platform.Current.GetInfoString(InputSourceIdentifier.Default.GetPlatformUser(ID));
				}
				return "";
			}
		}

		public void UpdateFromRemote(PlayerInfo remote_update)
		{
			Connection = remote_update.Connection;
			JoinProgress = remote_update.JoinProgress;
			Index = remote_update.Index;
			IsReportedDisconnectedByServer = false;
		}

		public void RemovedByRemote()
		{
			IsReportedDisconnectedByServer = true;
		}

		public static PlayerInfo Default(int id)
		{
			PlatformUser platformUser = InputSourceIdentifier.Default.GetPlatformUser(id);
			return new PlayerInfo
			{
				ID = id,
				Connection = ConnectionType.Local,
				Identifier = InputSourceIdentifier.Identifier,
				Username = Platform.Current.GetDisplayName(platformUser),
				Profile = PlayerProfile.Default,
				JoinProgress = 0f
			};
		}

		public string ColouredNameString()
		{
			string text = ColorUtility.ToHtmlStringRGB(Profile.Colour);
			return "<color=#" + text + ">" + Name + "</color>";
		}

		public bool IsChangedFrom(PlayerInfo other)
		{
			if (!IsNonJoiningProgressChangedFrom(other))
			{
				return Math.Abs(JoinProgress - other.JoinProgress) > 0.001f;
			}
			return true;
		}

		public bool IsNonJoiningProgressChangedFrom(PlayerInfo other)
		{
			if (ID == other.ID && Connection == other.Connection && !(Identifier != other.Identifier) && !(Username != other.Username) && !(Profile != other.Profile))
			{
				return Index != other.Index;
			}
			return true;
		}
	}
}
