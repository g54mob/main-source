using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	public sealed class SessionDetails : Handle
	{
		public const int SessiondetailsAttributeApiLatest = 1;

		public const int SessiondetailsCopyinfoApiLatest = 1;

		public const int SessiondetailsCopysessionattributebyindexApiLatest = 1;

		public const int SessiondetailsCopysessionattributebykeyApiLatest = 1;

		public const int SessiondetailsGetsessionattributecountApiLatest = 1;

		public const int SessiondetailsInfoApiLatest = 1;

		public const int SessiondetailsSettingsApiLatest = 2;

		public SessionDetails()
		{
		}

		public SessionDetails(IntPtr innerHandle)
		{
		}

		public Result CopyInfo(SessionDetailsCopyInfoOptions options, out SessionDetailsInfo outSessionInfo)
		{
			outSessionInfo = null;
			return default(Result);
		}

		public Result CopySessionAttributeByIndex(SessionDetailsCopySessionAttributeByIndexOptions options, out SessionDetailsAttribute outSessionAttribute)
		{
			outSessionAttribute = null;
			return default(Result);
		}

		public Result CopySessionAttributeByKey(SessionDetailsCopySessionAttributeByKeyOptions options, out SessionDetailsAttribute outSessionAttribute)
		{
			outSessionAttribute = null;
			return default(Result);
		}

		public uint GetSessionAttributeCount(SessionDetailsGetSessionAttributeCountOptions options)
		{
			return 0u;
		}

		public void Release()
		{
		}

		[PreserveSig]
		internal static extern Result EOS_SessionDetails_CopyInfo(IntPtr handle, IntPtr options, ref IntPtr outSessionInfo);

		[PreserveSig]
		internal static extern Result EOS_SessionDetails_CopySessionAttributeByIndex(IntPtr handle, IntPtr options, ref IntPtr outSessionAttribute);

		[PreserveSig]
		internal static extern Result EOS_SessionDetails_CopySessionAttributeByKey(IntPtr handle, IntPtr options, ref IntPtr outSessionAttribute);

		[PreserveSig]
		internal static extern uint EOS_SessionDetails_GetSessionAttributeCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_SessionDetails_Release(IntPtr sessionHandle);

		[PreserveSig]
		internal static extern void EOS_SessionDetails_Attribute_Release(IntPtr sessionAttribute);

		[PreserveSig]
		internal static extern void EOS_SessionDetails_Info_Release(IntPtr sessionInfo);
	}
}
