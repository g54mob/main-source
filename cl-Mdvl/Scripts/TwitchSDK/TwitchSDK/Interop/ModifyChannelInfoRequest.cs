using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class ModifyChannelInfoRequest : IMarshallable
	{
		internal readonly int TypeCode = -1414041357;

		public string GameId;

		public string Language;

		public string Title;

		public int Delay;

		public string[] Tags;

		public bool ForceUpdateTags;

		public override int GetHashCode()
		{
			return (((((13 * 7 + GameId.GetHashCode()) * 7 + Language.GetHashCode()) * 7 + Title.GetHashCode()) * 7 + Delay.GetHashCode()) * 7 + Tags.GetHashCode()) * 7 + ForceUpdateTags.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ModifyChannelInfoRequest modifyChannelInfoRequest = obj as ModifyChannelInfoRequest;
			if (modifyChannelInfoRequest == null)
			{
				return false;
			}
			if (GameId == modifyChannelInfoRequest.GameId && Language == modifyChannelInfoRequest.Language && Title == modifyChannelInfoRequest.Title && Delay == modifyChannelInfoRequest.Delay && Tags == modifyChannelInfoRequest.Tags)
			{
				return ForceUpdateTags == modifyChannelInfoRequest.ForceUpdateTags;
			}
			return false;
		}

		public static bool operator ==(ModifyChannelInfoRequest a, ModifyChannelInfoRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(ModifyChannelInfoRequest a, ModifyChannelInfoRequest b)
		{
			return !(a == b);
		}
	}
}
