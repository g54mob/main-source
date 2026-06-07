using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public static class GalaxyInstance
	{
		public class Error : ApplicationException
		{
			public Error(string message)
			{
			}
		}

		public class UnauthorizedAccessError : Error
		{
			public UnauthorizedAccessError(string message)
				: base(null)
			{
			}
		}

		public class InvalidArgumentError : Error
		{
			public InvalidArgumentError(string message)
				: base(null)
			{
			}
		}

		public class InvalidStateError : Error
		{
			public InvalidStateError(string message)
				: base(null)
			{
			}
		}

		public class RuntimeError : Error
		{
			public RuntimeError(string message)
				: base(null)
			{
			}
		}

		private class CustomExceptionHelper
		{
			public delegate void CustomExceptionDelegate(IError.Type type, string message);

			private static CustomExceptionDelegate customDelegate;

			static CustomExceptionHelper()
			{
			}

			[PreserveSig]
			public static extern void CustomExceptionRegisterCallback(CustomExceptionDelegate customCallback);

			private static void SetPendingCustomException(IError.Type type, string message)
			{
			}
		}

		private static CustomExceptionHelper exceptionHelper;

		static GalaxyInstance()
		{
		}

		public static IListenerRegistrar ListenerRegistrar()
		{
			return null;
		}

		public static void Init(InitParams initpParams)
		{
		}

		public static void Shutdown(bool unloadModule)
		{
		}

		public static IUser User()
		{
			return null;
		}

		public static IFriends Friends()
		{
			return null;
		}

		public static IStats Stats()
		{
			return null;
		}

		public static IUtils Utils()
		{
			return null;
		}

		public static IApps Apps()
		{
			return null;
		}

		public static IStorage Storage()
		{
			return null;
		}

		public static void ProcessData()
		{
		}
	}
}
