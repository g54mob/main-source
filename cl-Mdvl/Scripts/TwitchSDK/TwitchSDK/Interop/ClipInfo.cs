using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class ClipInfo : IMarshallable
	{
		internal readonly int TypeCode = 374164541;

		public string Id;

		public string Url;

		public string EmbedUrl;

		public string CreatedAt;

		public string ThumbnailUrl;

		public int Duration;

		public override int GetHashCode()
		{
			return (((((13 * 7 + Id.GetHashCode()) * 7 + Url.GetHashCode()) * 7 + EmbedUrl.GetHashCode()) * 7 + CreatedAt.GetHashCode()) * 7 + ThumbnailUrl.GetHashCode()) * 7 + Duration.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ClipInfo clipInfo = obj as ClipInfo;
			if (clipInfo == null)
			{
				return false;
			}
			if (Id == clipInfo.Id && Url == clipInfo.Url && EmbedUrl == clipInfo.EmbedUrl && CreatedAt == clipInfo.CreatedAt && ThumbnailUrl == clipInfo.ThumbnailUrl)
			{
				return Duration == clipInfo.Duration;
			}
			return false;
		}

		public static bool operator ==(ClipInfo a, ClipInfo b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(ClipInfo a, ClipInfo b)
		{
			return !(a == b);
		}
	}
}
