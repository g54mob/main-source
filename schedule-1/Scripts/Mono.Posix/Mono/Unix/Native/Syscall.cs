using System;
using System.Runtime.InteropServices;

namespace Mono.Unix.Native
{
	[CLSCompliant(false)]
	public sealed class Syscall : Stdlib
	{
		private struct _pollfd
		{
			public int fd;

			public short events;

			public short revents;
		}

		internal static object readdir_lock;

		public static readonly int AT_FDCWD;

		internal static object fstab_lock;

		internal static object grp_lock;

		internal static object pwd_lock;

		private static object signal_lock;

		public static readonly int L_ctermid;

		public static readonly int L_cuserid;

		internal static object getlogin_lock;

		public static readonly IntPtr MAP_FAILED;

		public static readonly long UTIME_NOW;

		public static readonly long UTIME_OMIT;

		private static object tty_lock;

		internal static object usershell_lock;

		[PreserveSig]
		private static extern int get_at_fdcwd();

		[PreserveSig]
		private static extern int _L_ctermid();

		[PreserveSig]
		private static extern int _L_cuserid();

		[PreserveSig]
		private static extern int sys_poll([In][Out] _pollfd[] ufds, uint nfds, int timeout);

		public static int poll(Pollfd[] fds, uint nfds, int timeout)
		{
			return 0;
		}

		[PreserveSig]
		private static extern long get_utime_now();

		[PreserveSig]
		private static extern long get_utime_omit();
	}
}
