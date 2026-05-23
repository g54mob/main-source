using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.Sdk
{
	public class Activity : IDisposable
	{
		internal NativeMethods.Activity self;

		private int disposed_;

		internal Activity(NativeMethods.Activity self, int disposed)
		{
			this.self = self;
			disposed_ = disposed;
		}

		~Activity()
		{
			Dispose();
		}

		public unsafe Activity()
		{
			NativeMethods.__Init();
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.Init(ptr);
			}
			NativeMethods.__OnPostConstruct(this);
		}

		public unsafe void Dispose()
		{
			if (Interlocked.Exchange(ref disposed_, 1) == 0)
			{
				GC.SuppressFinalize(this);
				fixed (NativeMethods.Activity* ptr = &self)
				{
					NativeMethods.Activity.Drop(ptr);
				}
			}
		}

		public unsafe Activity(Activity other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			if (other.disposed_ != 0)
			{
				throw new ObjectDisposedException("other");
			}
			fixed (NativeMethods.Activity* arg = &other.self)
			{
				fixed (NativeMethods.Activity* ptr = &self)
				{
					NativeMethods.Activity.Clone(ptr, arg);
				}
			}
		}

		internal unsafe Activity(NativeMethods.Activity* otherPtr)
		{
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.Clone(ptr, otherPtr);
			}
		}

		public unsafe void AddButton(ActivityButton button)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			fixed (NativeMethods.ActivityButton* button2 = &button.self)
			{
				fixed (NativeMethods.Activity* ptr = &self)
				{
					NativeMethods.Activity.AddButton(ptr, button2);
				}
			}
		}

		public unsafe bool Equals(Activity other)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			bool result;
			fixed (NativeMethods.Activity* other2 = &other.self)
			{
				fixed (NativeMethods.Activity* ptr = &self)
				{
					result = NativeMethods.Activity.Equals(ptr, other2);
				}
			}
			return result;
		}

		public unsafe ActivityButton[] GetButtons()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.Discord_ActivityButtonSpan discord_ActivityButtonSpan = default(NativeMethods.Discord_ActivityButtonSpan);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.GetButtons(ptr, &discord_ActivityButtonSpan);
			}
			ActivityButton[] array = new ActivityButton[(uint)discord_ActivityButtonSpan.size];
			for (int i = 0; i < (int)(uint)discord_ActivityButtonSpan.size; i++)
			{
				array[i] = new ActivityButton(discord_ActivityButtonSpan.ptr[i], 0);
			}
			NativeMethods.Discord_Free(discord_ActivityButtonSpan.ptr);
			return array;
		}

		public unsafe string Name()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.Name(ptr, &discord_String);
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetName(string value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String value2 = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitStringLocal(buf, &num, 1024, &value2, value);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetName(ptr, value2);
			}
			NativeMethods.__FreeLocalString(&value2, owned);
		}

		public unsafe ActivityTypes Type()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			ActivityTypes result;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				result = NativeMethods.Activity.Type(ptr);
			}
			return result;
		}

		public unsafe void SetType(ActivityTypes value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetType(ptr, value);
			}
		}

		public unsafe StatusDisplayTypes? StatusDisplayType()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			bool num;
			StatusDisplayTypes value = default(StatusDisplayTypes);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.StatusDisplayType(ptr, &value);
			}
			if (!num)
			{
				return null;
			}
			return value;
		}

		public unsafe void SetStatusDisplayType(StatusDisplayTypes? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			StatusDisplayTypes valueOrDefault = value.GetValueOrDefault();
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetStatusDisplayType(ptr, value.HasValue ? (&valueOrDefault) : null);
			}
		}

		public unsafe string? State()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.State(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetState(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetState(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? StateUrl()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.StateUrl(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetStateUrl(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetStateUrl(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? Details()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.Details(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetDetails(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetDetails(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe string? DetailsUrl()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool num;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.DetailsUrl(ptr, &discord_String);
			}
			if (!num)
			{
				return null;
			}
			string result = Marshal.PtrToStringUTF8((IntPtr)discord_String.ptr, (int)(uint)discord_String.size);
			NativeMethods.Discord_Free(discord_String.ptr);
			return result;
		}

		public unsafe void SetDetailsUrl(string? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			byte* buf = stackalloc byte[1024];
			int num = 0;
			NativeMethods.Discord_String discord_String = default(NativeMethods.Discord_String);
			bool owned = NativeMethods.__InitNullableStringLocal(buf, &num, 1024, &discord_String, value);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetDetailsUrl(ptr, (value != null) ? (&discord_String) : null);
			}
			NativeMethods.__FreeLocalString(&discord_String, owned);
		}

		public unsafe ulong? ApplicationId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			bool num;
			ulong value = default(ulong);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.ApplicationId(ptr, &value);
			}
			if (!num)
			{
				return null;
			}
			return value;
		}

		public unsafe void SetApplicationId(ulong? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			ulong valueOrDefault = value.GetValueOrDefault();
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetApplicationId(ptr, value.HasValue ? (&valueOrDefault) : null);
			}
		}

		public unsafe ulong? ParentApplicationId()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			bool num;
			ulong value = default(ulong);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.ParentApplicationId(ptr, &value);
			}
			if (!num)
			{
				return null;
			}
			return value;
		}

		public unsafe void SetParentApplicationId(ulong? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			ulong valueOrDefault = value.GetValueOrDefault();
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetParentApplicationId(ptr, value.HasValue ? (&valueOrDefault) : null);
			}
		}

		public unsafe ActivityAssets? Assets()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.ActivityAssets activityAssets = default(NativeMethods.ActivityAssets);
			bool num;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.Assets(ptr, &activityAssets);
			}
			if (!num)
			{
				return null;
			}
			return new ActivityAssets(activityAssets, 0);
		}

		public unsafe void SetAssets(ActivityAssets? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.ActivityAssets activityAssets = value?.self ?? default(NativeMethods.ActivityAssets);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetAssets(ptr, (value != null) ? (&activityAssets) : null);
			}
			if (value != null)
			{
				value.self = activityAssets;
			}
		}

		public unsafe ActivityTimestamps? Timestamps()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.ActivityTimestamps activityTimestamps = default(NativeMethods.ActivityTimestamps);
			bool num;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.Timestamps(ptr, &activityTimestamps);
			}
			if (!num)
			{
				return null;
			}
			return new ActivityTimestamps(activityTimestamps, 0);
		}

		public unsafe void SetTimestamps(ActivityTimestamps? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.ActivityTimestamps activityTimestamps = value?.self ?? default(NativeMethods.ActivityTimestamps);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetTimestamps(ptr, (value != null) ? (&activityTimestamps) : null);
			}
			if (value != null)
			{
				value.self = activityTimestamps;
			}
		}

		public unsafe ActivityParty? Party()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.ActivityParty activityParty = default(NativeMethods.ActivityParty);
			bool num;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.Party(ptr, &activityParty);
			}
			if (!num)
			{
				return null;
			}
			return new ActivityParty(activityParty, 0);
		}

		public unsafe void SetParty(ActivityParty? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.ActivityParty activityParty = value?.self ?? default(NativeMethods.ActivityParty);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetParty(ptr, (value != null) ? (&activityParty) : null);
			}
			if (value != null)
			{
				value.self = activityParty;
			}
		}

		public unsafe ActivitySecrets? Secrets()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.ActivitySecrets activitySecrets = default(NativeMethods.ActivitySecrets);
			bool num;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				num = NativeMethods.Activity.Secrets(ptr, &activitySecrets);
			}
			if (!num)
			{
				return null;
			}
			return new ActivitySecrets(activitySecrets, 0);
		}

		public unsafe void SetSecrets(ActivitySecrets? value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			NativeMethods.ActivitySecrets activitySecrets = value?.self ?? default(NativeMethods.ActivitySecrets);
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetSecrets(ptr, (value != null) ? (&activitySecrets) : null);
			}
			if (value != null)
			{
				value.self = activitySecrets;
			}
		}

		public unsafe ActivityGamePlatforms SupportedPlatforms()
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			ActivityGamePlatforms result;
			fixed (NativeMethods.Activity* ptr = &self)
			{
				result = NativeMethods.Activity.SupportedPlatforms(ptr);
			}
			return result;
		}

		public unsafe void SetSupportedPlatforms(ActivityGamePlatforms value)
		{
			if (disposed_ != 0)
			{
				throw new ObjectDisposedException("Activity");
			}
			fixed (NativeMethods.Activity* ptr = &self)
			{
				NativeMethods.Activity.SetSupportedPlatforms(ptr, value);
			}
		}
	}
}
