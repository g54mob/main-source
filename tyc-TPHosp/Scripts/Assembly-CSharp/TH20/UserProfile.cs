#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MessagePack;
using MessagePack.Resolvers;

namespace TH20
{
	public class UserProfile
	{
		private readonly UserProfileData _profileData;

		public bool IsSandboxUnlocked
		{
			get
			{
				return _profileData.IsSandboxUnlocked;
			}
			set
			{
				_profileData.IsSandboxUnlocked = value;
				SaveToFile();
			}
		}

		public bool HasSeenSandboxCutscene
		{
			get
			{
				return _profileData.HasSeenSandboxCutscene;
			}
			set
			{
				_profileData.HasSeenSandboxCutscene = value;
				SaveToFile();
			}
		}

		public bool IsCollaborativeProjectsUnlocked
		{
			get
			{
				return _profileData.IsCollaborativeProjectsUnlocked;
			}
			set
			{
				_profileData.IsCollaborativeProjectsUnlocked = value;
				SaveToFile();
			}
		}

		public bool HasSeenCollaborativeProjectCutscene
		{
			get
			{
				return _profileData.HasSeenCollaborativeProjectCutscene;
			}
			set
			{
				_profileData.HasSeenCollaborativeProjectCutscene = value;
				SaveToFile();
			}
		}

		public SuperBugRewardRecord SuperBugRewardRecord
		{
			get
			{
				return _profileData.SuperBugRewardRecord;
			}
			set
			{
				ProfileData.SuperBugRewardRecord = value;
				SaveToFile();
			}
		}

		public List<string> PrimeGamingEntitlements
		{
			get
			{
				return _profileData.PrimeGamingEntitlements;
			}
			set
			{
				if (ProfileData.PrimeGamingEntitlements == null || value.Count > ProfileData.PrimeGamingEntitlements.Count)
				{
					ProfileData.PrimeGamingEntitlements = value;
					SaveToFile();
				}
			}
		}

		public string PrimeGamingRefreshToken
		{
			get
			{
				return _profileData.PrimeGamingRefreshToken;
			}
			set
			{
				ProfileData.PrimeGamingRefreshToken = value;
				SaveToFile();
			}
		}

		public List<string>[] PrimeGamingKudoshIDsClaimed
		{
			get
			{
				return _profileData.PrimeGamingKudoshIDsClaimed;
			}
			set
			{
				ProfileData.PrimeGamingKudoshIDsClaimed = value;
				SaveToFile();
			}
		}

		public ulong FGWPUserID
		{
			get
			{
				return _profileData.FGWPUserID;
			}
			set
			{
				ProfileData.FGWPUserID = value;
				SaveToFile();
			}
		}

		public UserProfileData ProfileData => _profileData;

		public static string UserProfileFilePath => Path.Combine(PlatformFileManager.CloudDirectory, "user_profile.sav");

		public bool SetSuperBugReward(int superBugId, CollaborativeNode.VictoryNodeType victoryType)
		{
			bool result = false;
			if (ProfileData.SuperBugRewardRecord != null)
			{
				result = ProfileData.SuperBugRewardRecord.SetReward(superBugId, victoryType);
				SaveToFile();
			}
			return result;
		}

		public bool HasSuperBugReward(int superBugId, CollaborativeNode.VictoryNodeType victoryType)
		{
			bool result = false;
			if (ProfileData.SuperBugRewardRecord != null)
			{
				result = ProfileData.SuperBugRewardRecord.HasReward(superBugId, victoryType);
			}
			return result;
		}

		private UserProfile(UserProfileData profileData)
		{
			_profileData = profileData;
		}

		private UserProfile()
		{
			_profileData = new UserProfileData();
		}

		public static UserProfile LoadOrCreateNew(App app)
		{
			UserProfile userProfile = LoadUserProfileFile(UserProfileFilePath);
			if (userProfile == null)
			{
				Logging.Info(LogChannels.UserProfile, "We did not load a user profile, so created a new one!");
				userProfile = new UserProfile();
			}
			if (!userProfile.IsSandboxUnlocked)
			{
				for (int i = 0; i < 3; i++)
				{
					MetagameSaveHeader metagameSaveHeaderForSlot = app.SaveSystem.GetMetagameSaveHeaderForSlot(i);
					if (metagameSaveHeaderForSlot != null && (metagameSaveHeaderForSlot.IsSandboxUnlocked || metagameSaveHeaderForSlot.TotalStars >= 7))
					{
						userProfile.IsSandboxUnlocked = true;
						break;
					}
				}
			}
			if (userProfile.PrimeGamingEntitlements == null)
			{
				userProfile.PrimeGamingEntitlements = new List<string>();
			}
			if (userProfile.PrimeGamingKudoshIDsClaimed == null || userProfile.PrimeGamingKudoshIDsClaimed.Length < 3 || userProfile.PrimeGamingKudoshIDsClaimed.Contains(null))
			{
				userProfile.PrimeGamingKudoshIDsClaimed = new List<string>[3];
				for (int j = 0; j < 3; j++)
				{
					userProfile.PrimeGamingKudoshIDsClaimed[j] = new List<string>();
				}
			}
			return userProfile;
		}

		private static UserProfile LoadUserProfileFile(string path)
		{
			Logging.Info(LogChannels.UserProfile, "Attempting to load the UserProfileData from {0}", path);
			if (!PlatformFileManager.FileExists(path))
			{
				Logging.Info(LogChannels.UserProfile, "No user profile file exists yet");
				return null;
			}
			if (!PlatformFileManager.Load(path, out var reader))
			{
				return null;
			}
			using (reader)
			{
				byte[] bytes;
				try
				{
					bytes = reader.ReadBytes((int)reader.BaseStream.Length);
				}
				catch (Exception ex)
				{
					Logging.Error(LogChannels.UserProfile, "An exception occured wile reading user profile into binary! Exception {0}", ex.Message);
					return null;
				}
				try
				{
					UserProfile result = new UserProfile(MessagePackSerializer.Deserialize<UserProfileData>(bytes, StandardResolverAllowPrivate.Instance));
					Logging.Info(LogChannels.UserProfile, "Loaded UserProfileData successfully");
					return result;
				}
				catch (Exception ex2)
				{
					Logging.Error(LogChannels.UserProfile, "An exception occured wile deserialising user profile! Exception {0}", ex2.Message);
					return null;
				}
			}
		}

		public void SaveToFile()
		{
			if (!OnlineManager.RequiresLogOn())
			{
				SaveToFile(this);
			}
		}

		public static void SaveToFile(UserProfile profile)
		{
			string userProfileFilePath = UserProfileFilePath;
			Logging.Info(LogChannels.UserProfile, "Attempting to save the UserProfileData to {0}", userProfileFilePath);
			try
			{
				byte[] compressedData = MessagePackSerializer.Serialize(profile._profileData, StandardResolverAllowPrivate.Instance);
				Action<BinaryWriter> writeAction = delegate(BinaryWriter binaryWriter)
				{
					binaryWriter.Write(compressedData);
				};
				PlatformFileManager.Save(userProfileFilePath, writeAction, useBackups: false);
				Logging.Info(LogChannels.UserProfile, "Saved UserProfileData successfully");
			}
			catch (IOException ex)
			{
				Logging.Error(LogChannels.UserProfile, "Failed to serialise user profile with IO exception; aborting save. Errors: {0}", ex);
			}
			catch (Exception ex2)
			{
				Logging.Error(LogChannels.UserProfile, "Failed to serialise user profile; aborting save. Errors: {0}", ex2);
			}
		}

		public bool PrimeEntitlementClaimed(string entitlementId)
		{
			return _profileData.PrimeGamingEntitlements.Contains(entitlementId);
		}
	}
}
