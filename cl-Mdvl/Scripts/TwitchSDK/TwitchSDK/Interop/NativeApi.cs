using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	internal class NativeApi
	{
		public const string DllName = "R66_core";

		[DllImport("R66_core")]
		public static extern void R66Api_GetAuthState(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_GetAuthenticationInfo(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_LogOut(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_GetMyUserInfo(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_GetUserInfoById(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_GetUserInfoByLoginName(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_GetMyStreamInfo(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_QueryStreams(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_CheckUserSubscription(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_CreateClip(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_CreateStreamMarker(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_CreatePoll(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_WaitForPollUpdate(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_EndPoll(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_UnsubscribeFromPoll(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_CreatePrediction(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_WaitForPredictionUpdate(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_EndPrediction(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_UnsubscribeFromPrediction(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_ModifyChannelInformation(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_GetBitsLeaderboard(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_ReplaceCustomRewards(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_ResolveCustomReward(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_SubscribeToEventStream(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_WaitForChannelSubscribeEvent(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_WaitForChannelFollowEvent(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_WaitForChannelCheerEvent(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_WaitForCustomRewardEvent(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_WaitForHypeTrainEvent(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_WaitForChannelRaidEvent(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_CloseEventStream(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern void R66Api_PrepareShutdown(IntPtr api, IntPtr p, Types.MarshallableTaskCallback cb, IntPtr pl);

		[DllImport("R66_core")]
		public static extern IntPtr ProxyPAL_new(IntPtr parent, PlatformAbstractionLayer.PALCall impl);

		[DllImport("R66_core")]
		public static extern void ProxyPAL_Dispose(IntPtr pal);

		[DllImport("R66_core")]
		public static extern IntPtr R66Api_new(IntPtr pal, [MarshalAs(UnmanagedType.LPWStr)] string clientId, [MarshalAs(UnmanagedType.Bool)] bool useEventSubProxy);

		[DllImport("R66_core")]
		public static extern IntPtr R66Api_Dispose(IntPtr pal);

		[DllImport("R66_core")]
		public static extern IntPtr R66_GetVersion();
	}
}
