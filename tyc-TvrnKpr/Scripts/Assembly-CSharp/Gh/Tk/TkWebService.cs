using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GreenbackIntegration;

namespace Gh.Tk
{
	public static class TkWebService
	{
		public class FeedbackResult
		{
			public string msg { get; set; }

			public string[] saveCodes { get; set; }
		}

		public class IfStoryPathReport
		{
			public string StoryId;

			public string SessionId;

			public string ProfileId;

			public StoryDecisionTrackData[] StoryDecisions;

			public string[] DecisionHistory;

			public string ToJsonPayload()
			{
				return null;
			}
		}

		public class StoryDecisionTrackData
		{
			public string ContentHash;

			public string Decision;

			public float SecondsUntilDecision;

			public float VoiceOverCompletionPercentage;
		}

		public sealed class TkWebserviceException : ApplicationException
		{
			public TkWebServiceErrorResponse Response { get; private set; }

			public TkWebserviceException(TkWebServiceErrorResponse response)
			{
			}
		}

		public class TkWebServiceErrorResponse
		{
			public string errorMsg { get; set; }

			public string displayPopupMsg { get; set; }
		}

		public class GreenbackLoginResult
		{
			public string sessionToken { get; set; }

			public string userName { get; set; }

			public string emailHash { get; set; }

			public string greenbackUserIdHash { get; set; }

			public bool newUser { get; set; }

			public string inventoryUrl { get; set; }

			public string discordUser { get; set; }

			public UserPrivileges privileges { get; set; }

			public string contentUnlocks { get; set; }
		}

		[Flags]
		public enum UserPrivileges : sbyte
		{
			Normal = 1,
			Patreon = 2,
			Creator = 4,
			Press = 8,
			Dev = 0x10
		}

		public class ClaimKeyResult
		{
			public ProductKeyType KeyTypeEnum { get; set; }

			public string Content { get; set; }
		}

		public enum ProductKeyType : sbyte
		{
			PrivilegeGrant = 1,
			ContentUnlockGrant = 2
		}

		public enum AiVoice : sbyte
		{
			Informational = 0,
			Narrator = 1,
			Advisor = 2
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCheckIfEmailIsVerified_003Ed__49 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string email;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCheckIsUsernameAvailable_003Ed__68 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GreenbackManager.UsernameAvailableResult> _003C_003Et__builder;

			public string username;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CClaimKey_003Ed__41 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ClaimKeyResult> _003C_003Et__builder;

			public string key;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CClaimReward_003Ed__60 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GreenbackUserInventory> _003C_003Et__builder;

			public string rewardId;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateShareCode_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public Stream stream;

			public ShareCodeType type;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private Stream _003C_003E7__wrap2;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private string _003C_003E7__wrap5;

			private HttpResponseMessage _003Cresponse_003E5__7;

			private HttpContent _003Ccontent_003E5__8;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private ValueTaskAwaiter _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDownloadFile_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<MemoryStream> _003C_003Et__builder;

			public string uri;

			private HttpResponseMessage _003Cresponse_003E5__2;

			private Stream _003CresponseStream_003E5__3;

			private MemoryStream _003CmemoryStream_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<Stream> _003C_003Eu__2;

			private TaskAwaiter _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDownloadFile_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string uri;

			public string target;

			private Stream _003Cresponse_003E5__2;

			private TaskAwaiter<Stream> _003C_003Eu__1;

			private FileStream _003Cstream_003E5__3;

			private TaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetOrSetPlayerInventory_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string sessionTicket;

			public DataStore data;

			private MultipartFormDataContent _003Cpayload_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetSpeechFileTask_003Ed__52 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public AiVoice voice;

			public string content;

			public string style;

			public string targetFile;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private HttpContent _003Cresult_003E5__4;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGrantCards_003Ed__54 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GreenbackUserInventory> _003C_003Et__builder;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLinkToDiscord_003Ed__37 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadFromCloud_003Ed__7<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

			public string url;

			private TaskAwaiter<MemoryStream> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadShareCode_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<(LoadShareCodeResult result, Stream stream)> _003C_003Et__builder;

			public string code;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private HttpContent _003Ccontent_003E5__4;

			private LoadShareCodeResult _003Cresult_003E5__5;

			private TaskAwaiter<string> _003C_003Eu__2;

			private TaskAwaiter<MemoryStream> _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoginToGreenback_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GreenbackLoginResult> _003C_003Et__builder;

			public string appId;

			public string appVersion;

			public bool earnRewards;

			public string[] pendingRewardIds;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CMarkRewardAsUnpacked_003Ed__58 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GreenbackUserInventory> _003C_003Et__builder;

			public List<string> rewardIds;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReportIfStoryChoicesInternal_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public IfStoryPathReport report;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReportShareCodeContent_003Ed__62 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string code;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReportStats_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public Func<string> getJson;

			public string profileId;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CResetRewards_003Ed__56 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GreenbackUserInventory> _003C_003Et__builder;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CResolveCreatorNames_003Ed__70 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GreenbackManager.CreatorNameData[]> _003C_003Et__builder;

			public string[] toFetch;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendCrashReport_003Ed__64 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public CrashHelper.CrashInfo crashInfo;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendFeedback_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string fromEmail;

			public string subject;

			public string appVersion;

			public string feeling;

			public string body;

			public string base64Image;

			public string base64ExtendedInfo;

			public (string name, Stream stream)[] saveFiles;

			public (string name, string saveCode)[] saveCodes;

			public string route;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSetUsername_003Ed__66 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string username;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSubmitPlaystreamEvents_003Ed__47 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string json;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSubscribeToNewsletter_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string email;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnlinkDiscord_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUpdateEmail_003Ed__45 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string email;

			private MultipartFormDataContent _003Cdata_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpContent _003Ccontent_003E5__4;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private static readonly HttpClient _client;

		private static string _greenbackSessionTicket;

		public static bool SendFeedbackToMainTrelloBoard
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal static string GetFunctionUrl(string function)
		{
			return null;
		}

		public static void CreateShareCode(Func<Stream> getStream, ShareCodeType type, Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CCreateShareCode_003Ed__3))]
		private static Task<string> CreateShareCode(Stream stream, ShareCodeType type)
		{
			return null;
		}

		public static void LoadShareCode(string code, Action<(LoadShareCodeResult result, Stream stream)> success, Action<string> fail)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadShareCode_003Ed__5))]
		private static Task<(LoadShareCodeResult, Stream)> LoadShareCode(string code)
		{
			return null;
		}

		public static void LoadCloudInventory<T>(string url, Action<T> success, Action<string> fail)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadFromCloud_003Ed__7<>))]
		private static Task<T> LoadFromCloud<T>(string url)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDownloadFile_003Ed__8))]
		private static Task<MemoryStream> DownloadFile(string uri)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDownloadFile_003Ed__9))]
		private static Task<string> DownloadFile(string uri, string target)
		{
			return null;
		}

		public static void SendFeedback(FeedbackSavePackage package, Action<FeedbackResult> successCallback, Action<string> failCallback)
		{
		}

		private static void ExecuteBackgroundTask<T>(Func<T> task, Action<T> successCallback, Action<string> errorCallback)
		{
		}

		[AsyncStateMachine(typeof(_003CSendFeedback_003Ed__16))]
		private static Task<string> SendFeedback(string appVersion, string fromEmail, string subject, string feeling, string body, string base64Image, string base64ExtendedInfo, (string name, Stream stream)[] saveFiles, (string name, string saveCode)[] saveCodes, string route = "tk")
		{
			return null;
		}

		public static void ReportIfStoryChoices(IfStoryPathReport report)
		{
		}

		[AsyncStateMachine(typeof(_003CReportIfStoryChoicesInternal_003Ed__18))]
		private static Task<string> ReportIfStoryChoicesInternal(IfStoryPathReport report)
		{
			return null;
		}

		private static void CheckResponse(HttpResponseMessage response)
		{
		}

		public static void ReportStats(string profileId, Func<string> GetJson, Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CReportStats_003Ed__25))]
		private static Task<string> ReportStats(string profileId, Func<string> getJson)
		{
			return null;
		}

		public static void SubscribeToNewsletter(string email, Action<string> callback, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CSubscribeToNewsletter_003Ed__27))]
		private static Task<string> SubscribeToNewsletter(string email)
		{
			return null;
		}

		public static void SetPlayerInventory(string sessionTicket, DataStore inventory, Action<string> success, Action<string> error)
		{
		}

		public static void GetPlayerInventory(string sessionTicket, Action<DataStore> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CGetOrSetPlayerInventory_003Ed__30))]
		private static Task<string> GetOrSetPlayerInventory(string sessionTicket, DataStore data = null)
		{
			return null;
		}

		public static void LoginToGreenback(Action<GreenbackLoginResult> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CLoginToGreenback_003Ed__35))]
		private static Task<GreenbackLoginResult> LoginToGreenback(string appId, string appVersion, string[] pendingRewardIds, bool earnRewards)
		{
			return null;
		}

		public static void LinkToDiscord(Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CLinkToDiscord_003Ed__37))]
		private static Task<string> LinkToDiscord()
		{
			return null;
		}

		public static void UnlinkDiscord(Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CUnlinkDiscord_003Ed__39))]
		private static Task<string> UnlinkDiscord()
		{
			return null;
		}

		public static void ClaimKey(string key, Action<ClaimKeyResult> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CClaimKey_003Ed__41))]
		private static Task<ClaimKeyResult> ClaimKey(string key)
		{
			return null;
		}

		public static void UpdateEmail(string email, Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CUpdateEmail_003Ed__45))]
		private static Task<string> UpdateEmail(string email)
		{
			return null;
		}

		public static void SubmitPlaystreamEvents(string json, Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CSubmitPlaystreamEvents_003Ed__47))]
		private static Task<string> SubmitPlaystreamEvents(string json)
		{
			return null;
		}

		public static void CheckIfEmailIsVerified(string email, Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CCheckIfEmailIsVerified_003Ed__49))]
		private static Task<string> CheckIfEmailIsVerified(string email)
		{
			return null;
		}

		public static void GetSpeechFile(string content, AiVoice voice, string style, Action<string> callback, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CGetSpeechFileTask_003Ed__52))]
		private static Task<string> GetSpeechFileTask(string content, AiVoice voice, string style, string targetFile)
		{
			return null;
		}

		public static void GrantCards(Action<GreenbackUserInventory> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CGrantCards_003Ed__54))]
		private static Task<GreenbackUserInventory> GrantCards()
		{
			return null;
		}

		public static void ResetRewards(Action<GreenbackUserInventory> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CResetRewards_003Ed__56))]
		private static Task<GreenbackUserInventory> ResetRewards()
		{
			return null;
		}

		public static void MarkRewardAsUnpacked(List<string> rewardIds, Action<GreenbackUserInventory> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CMarkRewardAsUnpacked_003Ed__58))]
		private static Task<GreenbackUserInventory> MarkRewardAsUnpacked(List<string> rewardIds)
		{
			return null;
		}

		public static void ClaimReward(string rewardId, Action<GreenbackUserInventory> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CClaimReward_003Ed__60))]
		private static Task<GreenbackUserInventory> ClaimReward(string rewardId)
		{
			return null;
		}

		public static void ReportShareCodeContent(string templateSourceShareCode, Action success, Action<string> failed)
		{
		}

		[AsyncStateMachine(typeof(_003CReportShareCodeContent_003Ed__62))]
		private static Task<string> ReportShareCodeContent(string code)
		{
			return null;
		}

		public static void SendCrashReport(CrashHelper.CrashInfo crashInfo, Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CSendCrashReport_003Ed__64))]
		public static Task<string> SendCrashReport(CrashHelper.CrashInfo crashInfo)
		{
			return null;
		}

		public static void SetUsername(string username, Action<string> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CSetUsername_003Ed__66))]
		private static Task<string> SetUsername(string username)
		{
			return null;
		}

		public static void CheckIsUsernameAvailable(string username, Action<GreenbackManager.UsernameAvailableResult> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CCheckIsUsernameAvailable_003Ed__68))]
		private static Task<GreenbackManager.UsernameAvailableResult> CheckIsUsernameAvailable(string username)
		{
			return null;
		}

		public static void ResolveCreatorNames(string[] toFetch, Action<GreenbackManager.CreatorNameData[]> success, Action<string> error)
		{
		}

		[AsyncStateMachine(typeof(_003CResolveCreatorNames_003Ed__70))]
		private static Task<GreenbackManager.CreatorNameData[]> ResolveCreatorNames(string[] toFetch)
		{
			return null;
		}
	}
}
