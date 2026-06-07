using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	internal class GalaxyInstancePINVOKE
	{
		protected class SWIGExceptionHelper
		{
			public delegate void ExceptionDelegate(string message);

			public delegate void ExceptionArgumentDelegate(string message, string paramName);

			private static ExceptionDelegate applicationDelegate;

			private static ExceptionDelegate arithmeticDelegate;

			private static ExceptionDelegate divideByZeroDelegate;

			private static ExceptionDelegate indexOutOfRangeDelegate;

			private static ExceptionDelegate invalidCastDelegate;

			private static ExceptionDelegate invalidOperationDelegate;

			private static ExceptionDelegate ioDelegate;

			private static ExceptionDelegate nullReferenceDelegate;

			private static ExceptionDelegate outOfMemoryDelegate;

			private static ExceptionDelegate overflowDelegate;

			private static ExceptionDelegate systemDelegate;

			private static ExceptionArgumentDelegate argumentDelegate;

			private static ExceptionArgumentDelegate argumentNullDelegate;

			private static ExceptionArgumentDelegate argumentOutOfRangeDelegate;

			static SWIGExceptionHelper()
			{
			}

			[PreserveSig]
			public static extern void SWIGRegisterExceptionCallbacks_GalaxyInstance(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

			[PreserveSig]
			public static extern void SWIGRegisterExceptionCallbacksArgument_GalaxyInstance(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

			private static void SetPendingApplicationException(string message)
			{
			}

			private static void SetPendingArithmeticException(string message)
			{
			}

			private static void SetPendingDivideByZeroException(string message)
			{
			}

			private static void SetPendingIndexOutOfRangeException(string message)
			{
			}

			private static void SetPendingInvalidCastException(string message)
			{
			}

			private static void SetPendingInvalidOperationException(string message)
			{
			}

			private static void SetPendingIOException(string message)
			{
			}

			private static void SetPendingNullReferenceException(string message)
			{
			}

			private static void SetPendingOutOfMemoryException(string message)
			{
			}

			private static void SetPendingOverflowException(string message)
			{
			}

			private static void SetPendingSystemException(string message)
			{
			}

			private static void SetPendingArgumentException(string message, string paramName)
			{
			}

			private static void SetPendingArgumentNullException(string message, string paramName)
			{
			}

			private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
			{
			}
		}

		public class SWIGPendingException
		{
			[ThreadStatic]
			private static Exception pendingException;

			private static int numExceptionsPending;

			public static bool Pending => false;

			public static void Set(Exception e)
			{
			}

			public static Exception Retrieve()
			{
				return null;
			}
		}

		protected class SWIGStringHelper
		{
			public delegate string SWIGStringDelegate(string message);

			private static SWIGStringDelegate stringDelegate;

			static SWIGStringHelper()
			{
			}

			[PreserveSig]
			public static extern void SWIGRegisterStringCallback_GalaxyInstance(SWIGStringDelegate stringDelegate);

			private static string CreateString(string cString)
			{
				return null;
			}
		}

		public class UTF8Marshaler
		{
		}

		protected static SWIGExceptionHelper swigExceptionHelper;

		protected static SWIGStringHelper swigStringHelper;

		static GalaxyInstancePINVOKE()
		{
		}

		[PreserveSig]
		public static extern void delete_IGalaxyListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_IListenerRegistrar(HandleRef jarg1);

		[PreserveSig]
		public static extern void IListenerRegistrar_Register(HandleRef jarg1, int jarg2, HandleRef jarg3);

		[PreserveSig]
		public static extern void IListenerRegistrar_Unregister(HandleRef jarg1, int jarg2, HandleRef jarg3);

		[PreserveSig]
		public static extern IntPtr ListenerRegistrar();

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerGogServicesConnectionState_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerGogServicesConnectionState(HandleRef jarg1);

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerAuth_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerAuth(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerSpecificUserData(HandleRef jarg1);

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerUserStatsAndAchievementsRetrieve_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerUserStatsAndAchievementsRetrieve(HandleRef jarg1);

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerStatsAndAchievementsStore_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerStatsAndAchievementsStore(HandleRef jarg1);

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerAchievementChange_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerAchievementChange(HandleRef jarg1);

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerFileShare_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerFileShare(HandleRef jarg1);

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerSharedFileDownload_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerSharedFileDownload(HandleRef jarg1);

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerFriendList_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerFriendList(HandleRef jarg1);

		[PreserveSig]
		public static extern int GalaxyTypeAwareListenerRichPresenceChange_GetListenerType();

		[PreserveSig]
		public static extern void delete_GalaxyTypeAwareListenerRichPresenceChange(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_IApps(HandleRef jarg1);

		[PreserveSig]
		public static extern bool IApps_IsDlcInstalled(HandleRef jarg1, ulong jarg2);

		[PreserveSig]
		public static extern string IApps_GetCurrentGameLanguage__SWIG_1(HandleRef jarg1);

		[PreserveSig]
		public static extern IntPtr new_IGogServicesConnectionStateListener();

		[PreserveSig]
		public static extern void delete_IGogServicesConnectionStateListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void IGogServicesConnectionStateListener_director_connect(HandleRef jarg1, IGogServicesConnectionStateListener.SwigDelegateIGogServicesConnectionStateListener_0 delegate0);

		[PreserveSig]
		public static extern void delete_IUtils(HandleRef jarg1);

		[PreserveSig]
		public static extern void IUtils_ShowOverlayWithWebPage(HandleRef jarg1, string jarg2);

		[PreserveSig]
		public static extern IntPtr new_IAuthListener();

		[PreserveSig]
		public static extern void delete_IAuthListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void IAuthListener_director_connect(HandleRef jarg1, IAuthListener.SwigDelegateIAuthListener_0 delegate0, IAuthListener.SwigDelegateIAuthListener_1 delegate1, IAuthListener.SwigDelegateIAuthListener_2 delegate2);

		[PreserveSig]
		public static extern IntPtr new_ISpecificUserDataListener();

		[PreserveSig]
		public static extern void delete_ISpecificUserDataListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void ISpecificUserDataListener_director_connect(HandleRef jarg1, ISpecificUserDataListener.SwigDelegateISpecificUserDataListener_0 delegate0);

		[PreserveSig]
		public static extern void delete_IUser(HandleRef jarg1);

		[PreserveSig]
		public static extern bool IUser_SignedIn(HandleRef jarg1);

		[PreserveSig]
		public static extern IntPtr IUser_GetGalaxyID(HandleRef jarg1);

		[PreserveSig]
		public static extern void IUser_SignInCredentials__SWIG_1(HandleRef jarg1, string jarg2, string jarg3);

		[PreserveSig]
		public static extern void IUser_SignInGalaxy__SWIG_2(HandleRef jarg1);

		[PreserveSig]
		public static extern void IUser_SignOut(HandleRef jarg1);

		[PreserveSig]
		public static extern void IUser_RequestUserData__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

		[PreserveSig]
		public static extern string IUser_GetUserData__SWIG_0(HandleRef jarg1, string jarg2, HandleRef jarg3);

		[PreserveSig]
		public static extern void IUser_SetUserData__SWIG_1(HandleRef jarg1, string jarg2, string jarg3);

		[PreserveSig]
		public static extern bool IUser_IsLoggedOn(HandleRef jarg1);

		[PreserveSig]
		public static extern IntPtr new_IFriendListListener();

		[PreserveSig]
		public static extern void delete_IFriendListListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void IFriendListListener_director_connect(HandleRef jarg1, IFriendListListener.SwigDelegateIFriendListListener_0 delegate0, IFriendListListener.SwigDelegateIFriendListListener_1 delegate1);

		[PreserveSig]
		public static extern IntPtr new_IRichPresenceChangeListener();

		[PreserveSig]
		public static extern void delete_IRichPresenceChangeListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void IRichPresenceChangeListener_director_connect(HandleRef jarg1, IRichPresenceChangeListener.SwigDelegateIRichPresenceChangeListener_0 delegate0, IRichPresenceChangeListener.SwigDelegateIRichPresenceChangeListener_1 delegate1);

		[PreserveSig]
		public static extern void delete_IFriends(HandleRef jarg1);

		[PreserveSig]
		public static extern string IFriends_GetPersonaName(HandleRef jarg1);

		[PreserveSig]
		public static extern string IFriends_GetFriendPersonaName(HandleRef jarg1, HandleRef jarg2);

		[PreserveSig]
		public static extern int IFriends_GetFriendPersonaState(HandleRef jarg1, HandleRef jarg2);

		[PreserveSig]
		public static extern uint IFriends_GetFriendCount(HandleRef jarg1);

		[PreserveSig]
		public static extern IntPtr IFriends_GetFriendByIndex(HandleRef jarg1, uint jarg2);

		[PreserveSig]
		public static extern void IFriends_SetRichPresence__SWIG_1(HandleRef jarg1, string jarg2, string jarg3);

		[PreserveSig]
		public static extern IntPtr new_IUserStatsAndAchievementsRetrieveListener();

		[PreserveSig]
		public static extern void delete_IUserStatsAndAchievementsRetrieveListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void IUserStatsAndAchievementsRetrieveListener_director_connect(HandleRef jarg1, IUserStatsAndAchievementsRetrieveListener.SwigDelegateIUserStatsAndAchievementsRetrieveListener_0 delegate0, IUserStatsAndAchievementsRetrieveListener.SwigDelegateIUserStatsAndAchievementsRetrieveListener_1 delegate1);

		[PreserveSig]
		public static extern IntPtr new_IStatsAndAchievementsStoreListener();

		[PreserveSig]
		public static extern void delete_IStatsAndAchievementsStoreListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void IStatsAndAchievementsStoreListener_director_connect(HandleRef jarg1, IStatsAndAchievementsStoreListener.SwigDelegateIStatsAndAchievementsStoreListener_0 delegate0, IStatsAndAchievementsStoreListener.SwigDelegateIStatsAndAchievementsStoreListener_1 delegate1);

		[PreserveSig]
		public static extern IntPtr new_IAchievementChangeListener();

		[PreserveSig]
		public static extern void delete_IAchievementChangeListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void IAchievementChangeListener_director_connect(HandleRef jarg1, IAchievementChangeListener.SwigDelegateIAchievementChangeListener_0 delegate0);

		[PreserveSig]
		public static extern void delete_IStats(HandleRef jarg1);

		[PreserveSig]
		public static extern void IStats_RequestUserStatsAndAchievements__SWIG_2(HandleRef jarg1);

		[PreserveSig]
		public static extern int IStats_GetStatInt__SWIG_1(HandleRef jarg1, string jarg2);

		[PreserveSig]
		public static extern float IStats_GetStatFloat__SWIG_1(HandleRef jarg1, string jarg2);

		[PreserveSig]
		public static extern void IStats_SetStatInt(HandleRef jarg1, string jarg2, int jarg3);

		[PreserveSig]
		public static extern void IStats_SetStatFloat(HandleRef jarg1, string jarg2, float jarg3);

		[PreserveSig]
		public static extern void IStats_GetAchievement__SWIG_1(HandleRef jarg1, string jarg2, ref bool jarg3, ref uint jarg4);

		[PreserveSig]
		public static extern void IStats_SetAchievement(HandleRef jarg1, string jarg2);

		[PreserveSig]
		public static extern void IStats_StoreStatsAndAchievements__SWIG_1(HandleRef jarg1);

		[PreserveSig]
		public static extern void IStats_ResetStatsAndAchievements__SWIG_1(HandleRef jarg1);

		[PreserveSig]
		public static extern string IStats_GetAchievementDisplayName(HandleRef jarg1, string jarg2);

		[PreserveSig]
		public static extern IntPtr new_IFileShareListener();

		[PreserveSig]
		public static extern void delete_IFileShareListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void IFileShareListener_director_connect(HandleRef jarg1, IFileShareListener.SwigDelegateIFileShareListener_0 delegate0, IFileShareListener.SwigDelegateIFileShareListener_1 delegate1);

		[PreserveSig]
		public static extern IntPtr new_ISharedFileDownloadListener();

		[PreserveSig]
		public static extern void delete_ISharedFileDownloadListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void ISharedFileDownloadListener_director_connect(HandleRef jarg1, ISharedFileDownloadListener.SwigDelegateISharedFileDownloadListener_0 delegate0, ISharedFileDownloadListener.SwigDelegateISharedFileDownloadListener_1 delegate1);

		[PreserveSig]
		public static extern void delete_IStorage(HandleRef jarg1);

		[PreserveSig]
		public static extern void IStorage_FileWrite(HandleRef jarg1, string jarg2, byte[] jarg3, uint jarg4);

		[PreserveSig]
		public static extern void IStorage_FileDelete(HandleRef jarg1, string jarg2);

		[PreserveSig]
		public static extern bool IStorage_FileExists(HandleRef jarg1, string jarg2);

		[PreserveSig]
		public static extern uint IStorage_GetFileCount(HandleRef jarg1);

		[PreserveSig]
		public static extern string IStorage_GetFileNameByIndex(HandleRef jarg1, uint jarg2);

		[PreserveSig]
		public static extern void IStorage_FileShare__SWIG_1(HandleRef jarg1, string jarg2);

		[PreserveSig]
		public static extern void IStorage_DownloadSharedFile__SWIG_1(HandleRef jarg1, ulong jarg2);

		[PreserveSig]
		public static extern uint IStorage_GetSharedFileSize(HandleRef jarg1, ulong jarg2);

		[PreserveSig]
		public static extern uint IStorage_SharedFileRead__SWIG_1(HandleRef jarg1, ulong jarg2, byte[] jarg3, uint jarg4);

		[PreserveSig]
		public static extern void IStorage_SharedFileClose(HandleRef jarg1, ulong jarg2);

		[PreserveSig]
		public static extern ulong GalaxyID_UNASSIGNED_VALUE_get();

		[PreserveSig]
		public static extern IntPtr new_GalaxyID__SWIG_1(ulong jarg1);

		[PreserveSig]
		public static extern bool GalaxyID_operator_equals(HandleRef jarg1, HandleRef jarg2);

		[PreserveSig]
		public static extern ulong GalaxyID_ToUint64(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GalaxyID(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalGogServicesConnectionStateListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalAuthListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalUserStatsAndAchievementsRetrieveListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalStatsAndAchievementsStoreListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalAchievementChangeListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalFileShareListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalSharedFileDownloadListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalFriendListListener(HandleRef jarg1);

		[PreserveSig]
		public static extern void delete_GlobalRichPresenceChangeListener(HandleRef jarg1);

		[PreserveSig]
		public static extern IntPtr new_InitParams__SWIG_4(string jarg1, string jarg2);

		[PreserveSig]
		public static extern void delete_InitParams(HandleRef jarg1);

		[PreserveSig]
		public static extern void Init(HandleRef jarg1);

		[PreserveSig]
		public static extern void Shutdown(bool jarg1);

		[PreserveSig]
		public static extern IntPtr User();

		[PreserveSig]
		public static extern IntPtr Friends();

		[PreserveSig]
		public static extern IntPtr Stats();

		[PreserveSig]
		public static extern IntPtr Utils();

		[PreserveSig]
		public static extern IntPtr Apps();

		[PreserveSig]
		public static extern IntPtr Storage();

		[PreserveSig]
		public static extern void ProcessData();

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerGogServicesConnectionState_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerAuth_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerSpecificUserData_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerUserStatsAndAchievementsRetrieve_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerStatsAndAchievementsStore_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerAchievementChange_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerFileShare_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerSharedFileDownload_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerFriendList_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr GalaxyTypeAwareListenerRichPresenceChange_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr IGogServicesConnectionStateListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr IAuthListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr ISpecificUserDataListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr IFriendListListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr IRichPresenceChangeListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr IUserStatsAndAchievementsRetrieveListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr IStatsAndAchievementsStoreListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr IAchievementChangeListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr IFileShareListener_SWIGUpcast(IntPtr jarg1);

		[PreserveSig]
		public static extern IntPtr ISharedFileDownloadListener_SWIGUpcast(IntPtr jarg1);
	}
}
