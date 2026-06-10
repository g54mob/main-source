using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class StreamInfo : IMarshallable
	{
		internal readonly int TypeCode = -903042935;

		public string Id;

		public string UserId;

		public string UserLogin;

		public string UserName;

		public string GameId;

		public string GameName;

		public string Type;

		public string Title;

		public long ViewerCount;

		public string StartedAt;

		public string Language;

		public string ThumbnailUrl;

		public string[] Tags;

		public bool IsMature;

		public override int GetHashCode()
		{
			return (((((((((((((13 * 7 + Id.GetHashCode()) * 7 + UserId.GetHashCode()) * 7 + UserLogin.GetHashCode()) * 7 + UserName.GetHashCode()) * 7 + GameId.GetHashCode()) * 7 + GameName.GetHashCode()) * 7 + Type.GetHashCode()) * 7 + Title.GetHashCode()) * 7 + ViewerCount.GetHashCode()) * 7 + StartedAt.GetHashCode()) * 7 + Language.GetHashCode()) * 7 + ThumbnailUrl.GetHashCode()) * 7 + Tags.GetHashCode()) * 7 + IsMature.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			StreamInfo streamInfo = obj as StreamInfo;
			if (streamInfo == null)
			{
				return false;
			}
			if (Id == streamInfo.Id && UserId == streamInfo.UserId && UserLogin == streamInfo.UserLogin && UserName == streamInfo.UserName && GameId == streamInfo.GameId && GameName == streamInfo.GameName && Type == streamInfo.Type && Title == streamInfo.Title && ViewerCount == streamInfo.ViewerCount && StartedAt == streamInfo.StartedAt && Language == streamInfo.Language && ThumbnailUrl == streamInfo.ThumbnailUrl && Tags == streamInfo.Tags)
			{
				return IsMature == streamInfo.IsMature;
			}
			return false;
		}

		public static bool operator ==(StreamInfo a, StreamInfo b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(StreamInfo a, StreamInfo b)
		{
			return !(a == b);
		}
	}
}
