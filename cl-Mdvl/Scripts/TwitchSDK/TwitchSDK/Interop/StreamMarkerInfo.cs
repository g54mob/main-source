using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class StreamMarkerInfo : IMarshallable
	{
		internal readonly int TypeCode = 25655671;

		public string Id;

		public string CreatedAt;

		public string Description;

		public long PositionSeconds;

		public override int GetHashCode()
		{
			return (((13 * 7 + Id.GetHashCode()) * 7 + CreatedAt.GetHashCode()) * 7 + Description.GetHashCode()) * 7 + PositionSeconds.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			StreamMarkerInfo streamMarkerInfo = obj as StreamMarkerInfo;
			if (streamMarkerInfo == null)
			{
				return false;
			}
			if (Id == streamMarkerInfo.Id && CreatedAt == streamMarkerInfo.CreatedAt && Description == streamMarkerInfo.Description)
			{
				return PositionSeconds == streamMarkerInfo.PositionSeconds;
			}
			return false;
		}

		public static bool operator ==(StreamMarkerInfo a, StreamMarkerInfo b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(StreamMarkerInfo a, StreamMarkerInfo b)
		{
			return !(a == b);
		}
	}
}
