using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO.Implementation.API;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.API.Requests;
using UnityEngine;

namespace ModIO.Implementation
{
	internal static class ModIOUnityImplementation
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShutdown_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Action shutdownComplete;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CShutdownTask_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			private TaskAwaiter _003C_003Eu__1;

			private Dictionary<TaskCompletionSource<bool>, Task>.Enumerator _003Cenumerator_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__2;

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
		private struct _003CIsAuthenticated_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<UserObject>> _003C_003Eu__1;

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
		private struct _003CIsAuthenticated_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CRequestEmailAuthToken_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public string emailaddress;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CRequestEmailAuthToken_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public string emailaddress;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CSubmitEmailSecurityCode_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public string securityCode;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private Result _003Cresult_003E5__3;

			private TaskAwaiter<ResultAnd<AccessTokenObject>> _003C_003Eu__1;

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
		private struct _003CSubmitEmailSecurityCode_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public string securityCode;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CGetTermsOfUse_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<TermsOfUse>> _003C_003Et__builder;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private WebRequestConfig _003Cconfig_003E5__3;

			private TermsOfUse _003CtermsOfUse_003E5__4;

			private TaskAwaiter<ResultAnd<TermsObject>> _003C_003Eu__1;

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
		private struct _003CGetTermsOfUse_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<TermsOfUse>> callback;

			private TaskAwaiter<ResultAnd<TermsOfUse>> _003C_003Eu__1;

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
		private struct _003CAuthenticateUser_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public string emailAddress;

			public AuthenticationServiceProvider serviceProvider;

			public string data;

			public TermsHash? hash;

			public string nonce;

			public OculusDevice? device;

			public string userId;

			public PlayStationEnvironment environment;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private Result _003Cresult_003E5__3;

			private TaskAwaiter<ResultAnd<AccessTokenObject>> _003C_003Eu__1;

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
		private struct _003CAuthenticateUser_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public string data;

			public AuthenticationServiceProvider serviceProvider;

			public string emailAddress;

			public TermsHash? hash;

			public string nonce;

			public OculusDevice? device;

			public string userId;

			public PlayStationEnvironment environment;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CBeginWssAuthentication_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ExternalAuthenticationToken>> callback;

			private TaskAwaiter<ResultAnd<ExternalAuthenticationToken>> _003C_003Eu__1;

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
		private struct _003CBeginWssAuthentication_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ExternalAuthenticationToken>> _003C_003Et__builder;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<ExternalAuthenticationToken>> _003C_003Eu__1;

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
		private struct _003CGetGameTags_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<TagCategory[]>> _003C_003Et__builder;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TagCategory[] _003Ctags_003E5__3;

			private TaskAwaiter<ResultAnd<GetGameTags.ResponseSchema>> _003C_003Eu__1;

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
		private struct _003CGetGameTags_003Ed__37 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<TagCategory[]>> callback;

			private TaskAwaiter<ResultAnd<TagCategory[]>> _003C_003Eu__1;

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
		private struct _003CGetMods_003Ed__38 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModPage>> _003C_003Et__builder;

			public SearchFilter filter;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private ModPage _003Cpage_003E5__3;

			private TaskAwaiter<ResultAnd<GetMods.ResponseSchema>> _003C_003Eu__1;

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
		private struct _003CGetMods_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ModPage>> callback;

			public SearchFilter filter;

			private TaskAwaiter<ResultAnd<ModPage>> _003C_003Eu__1;

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
		private struct _003CGetModComments_003Ed__40 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<CommentPage>> _003C_003Et__builder;

			public ModId modId;

			public SearchFilter filter;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private CommentPage _003Cpage_003E5__3;

			private WebRequestConfig _003Cconfig_003E5__4;

			private TaskAwaiter<ResultAnd<GetModComments.ResponseSchema>> _003C_003Eu__1;

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
		private struct _003CGetModComments_003Ed__41 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<CommentPage>> callback;

			public ModId modId;

			public SearchFilter filter;

			private TaskAwaiter<ResultAnd<CommentPage>> _003C_003Eu__1;

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
		private struct _003CGetMod_003Ed__42 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModProfile>> _003C_003Et__builder;

			public long id;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private ModProfile _003Cprofile_003E5__3;

			private TaskAwaiter<ResultAnd<ModObject>> _003C_003Eu__1;

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
		private struct _003CGetMod_003Ed__43 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ModProfile>> callback;

			public long id;

			private TaskAwaiter<ResultAnd<ModProfile>> _003C_003Eu__1;

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
		private struct _003CGetModDependencies_003Ed__44 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModDependencies[]>> _003C_003Et__builder;

			public ModId modId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private ModDependencies[] _003CmodDependencies_003E5__3;

			private TaskAwaiter<ResultAnd<GetModDependencies.ResponseSchema>> _003C_003Eu__1;

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
		private struct _003CGetModDependencies_003Ed__45 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ModDependencies[]>> callback;

			public ModId modId;

			private TaskAwaiter<ResultAnd<ModDependencies[]>> _003C_003Eu__1;

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
		private struct _003CGetCurrentUserRatings_003Ed__46 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<Rating[]>> _003C_003Et__builder;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private Rating[] _003Cratings_003E5__3;

			private TaskAwaiter<ResultAnd<RatingObject[]>> _003C_003Eu__1;

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
		private struct _003CGetCurrentUserRatings_003Ed__47 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<Rating[]>> callback;

			private TaskAwaiter<ResultAnd<Rating[]>> _003C_003Eu__1;

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
		private struct _003CGetCurrentUserRatingFor_003Ed__48 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModRating>> _003C_003Et__builder;

			public ModId modId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private Result _003Cresult_003E5__3;

			private ModRating _003Crating_003E5__4;

			private TaskAwaiter<ResultAnd<Rating[]>> _003C_003Eu__1;

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
		private struct _003CGetCurrentUserRatingFor_003Ed__49 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ModRating>> callback;

			public ModId modId;

			private TaskAwaiter<ResultAnd<ModRating>> _003C_003Eu__1;

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
		private struct _003CFetchUpdates_003Ed__52 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CFetchUpdates_003Ed__53 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CAddDependenciesToMod_003Ed__59 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			public ICollection<ModId> dependencies;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CAddDependenciesToMod_003Ed__60 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ICollection<ModId> dependencies;

			public ModId modId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CRemoveDependenciesFromMod_003Ed__61 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			public ICollection<ModId> dependencies;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CRemoveDependenciesFromMod_003Ed__62 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ICollection<ModId> dependencies;

			public ModId modId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CAddModRating_003Ed__63 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModId modId;

			public ModRating modRating;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<MessageObject>> _003C_003Eu__1;

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
		private struct _003CAddModRating_003Ed__64 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			public ModRating rating;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CGetCurrentUser_003Ed__65 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<UserProfile>> _003C_003Et__builder;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private UserProfile _003CuserProfile_003E5__3;

			private TaskAwaiter<ResultAnd<UserObject>> _003C_003Eu__1;

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
		private struct _003CGetCurrentUser_003Ed__66 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<UserProfile>> callback;

			private TaskAwaiter<ResultAnd<UserProfile>> _003C_003Eu__1;

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
		private struct _003CUnsubscribeFrom_003Ed__67 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModId modId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<MessageObject>> _003C_003Eu__1;

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
		private struct _003CUnsubscribeFrom_003Ed__70 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CSubscribeTo_003Ed__71 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModId modId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<ModObject>> _003C_003Eu__1;

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
		private struct _003CSubscribeTo_003Ed__72 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CGetUserSubscriptions_003Ed__73 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModPage>> _003C_003Et__builder;

			public SearchFilter filter;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private ModPage _003Cpage_003E5__3;

			private TaskAwaiter<ResultAnd<GetUserSubscriptions.ResponseSchema>> _003C_003Eu__1;

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
		private struct _003CMuteUser_003Ed__79 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public long userId;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CUnmuteUser_003Ed__80 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public long userId;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CMuteUser_003Ed__81 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public long userId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CUnmuteUser_003Ed__82 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public long userId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CDownloadTexture_003Ed__83 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<Texture2D>> _003C_003Et__builder;

			public DownloadReference downloadReference;

			private Texture2D _003Ctexture_003E5__2;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

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
		private struct _003CGetImage_003Ed__84 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<byte[]>> _003C_003Et__builder;

			public DownloadReference downloadReference;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

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
		private struct _003CDownloadImage_003Ed__85 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<byte[]>> _003C_003Et__builder;

			public DownloadReference downloadReference;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private byte[] _003Cimage_003E5__3;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

			private ModIOFileStream _003C_003E7__wrap3;

			private TaskAwaiter<Result> _003C_003Eu__2;

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
		private struct _003CDownloadTexture_003Ed__86 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<Texture2D>> callback;

			public DownloadReference downloadReference;

			private TaskAwaiter<ResultAnd<Texture2D>> _003C_003Eu__1;

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
		private struct _003CDownloadImage_003Ed__87 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<byte[]>> callback;

			public DownloadReference downloadReference;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

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
		private struct _003CReport_003Ed__88 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public Report report;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<MessageObject>> _003C_003Eu__1;

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
		private struct _003CReport_003Ed__89 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public Report report;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CCreateModProfile_003Ed__91 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModId>> _003C_003Et__builder;

			public CreationToken token;

			public ModProfileDetails modDetails;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private ModId _003CmodId_003E5__3;

			private TaskAwaiter<ResultAnd<ModObject>> _003C_003Eu__1;

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
		private struct _003CCreateModProfile_003Ed__92 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ModId>> callback;

			public CreationToken token;

			public ModProfileDetails modDetails;

			private TaskAwaiter<ResultAnd<ModId>> _003C_003Eu__1;

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
		private struct _003CEditModProfile_003Ed__93 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModProfileDetails modDetails;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CEditModProfile_003Ed__94 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModProfileDetails modDetails;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CDeleteTags_003Ed__95 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			public string[] tags;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CDeleteTags_003Ed__96 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModId modId;

			public string[] tags;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<MessageObject>> _003C_003Eu__1;

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
		private struct _003CAddModComment_003Ed__97 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModComment>> _003C_003Et__builder;

			public ModId modId;

			public CommentDetails commentDetails;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<ModCommentObject>> _003C_003Eu__1;

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
		private struct _003CAddModComment_003Ed__98 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ModComment>> callback;

			public ModId modId;

			public CommentDetails commentDetails;

			private TaskAwaiter<ResultAnd<ModComment>> _003C_003Eu__1;

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
		private struct _003CUpdateModComment_003Ed__99 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModComment>> _003C_003Et__builder;

			public ModId modId;

			public string content;

			public long commentId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<ModCommentObject>> _003C_003Eu__1;

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
		private struct _003CUpdateModComment_003Ed__100 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ModComment>> callback;

			public ModId modId;

			public string content;

			public long commentId;

			private TaskAwaiter<ResultAnd<ModComment>> _003C_003Eu__1;

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
		private struct _003CDeleteModComment_003Ed__101 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModId modId;

			public long commentId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<ModCommentObject>> _003C_003Eu__1;

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
		private struct _003CDeleteModComment_003Ed__102 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			public long commentId;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CAddTags_003Ed__103 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			public string[] tags;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CAddTags_003Ed__104 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModId modId;

			public string[] tags;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<MessageObject>> _003C_003Eu__1;

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
		private struct _003CUploadModMedia_003Ed__106 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModProfileDetails modProfileDetails;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<WebRequestConfig>> _003C_003Eu__1;

			private TaskAwaiter<ResultAnd<ModMediaObject>> _003C_003Eu__2;

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
		private struct _003CUploadModfile_003Ed__107 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModfileDetails modfile;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<ResultAnd<MemoryStream>> _003C_003Eu__1;

			private TaskAwaiter<WebRequestConfig> _003C_003Eu__2;

			private TaskAwaiter<ResultAnd<ModfileObject>> _003C_003Eu__3;

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
		private struct _003CUploadModMedia_003Ed__108 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModProfileDetails modProfileDetails;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CUploadModfile_003Ed__109 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModfileDetails modfile;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CArchiveModProfile_003Ed__110 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ModId modId;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CArchiveModProfile_003Ed__111 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<Result> callback;

			public ModId modId;

			private TaskAwaiter<Result> _003C_003Eu__1;

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
		private struct _003CGetCurrentUserCreations_003Ed__115 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ModPage>> _003C_003Et__builder;

			public SearchFilter filter;

			private TaskCompletionSource<bool> _003CcallbackConfirmation_003E5__2;

			private ModPage _003Cpage_003E5__3;

			private WebRequestConfig _003Cconfig_003E5__4;

			private int _003Coffset_003E5__5;

			private TaskAwaiter<ResultAnd<GetCurrentUserCreations.ResponseSchema>> _003C_003Eu__1;

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
		private struct _003CGetCurrentUserCreations_003Ed__116 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Action<ResultAnd<ModPage>> callback;

			public SearchFilter filter;

			private TaskAwaiter<ResultAnd<ModPage>> _003C_003Eu__1;

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

		private static ProgressHandle currentUploadHandle;

		private static Dictionary<TaskCompletionSource<bool>, Task> openCallbacks_dictionary;

		private static Dictionary<string, Task<ResultAnd<byte[]>>> onGoingImageDownloads;

		private static Task shutdownOperation;

		internal static OpenCallbacks openCallbacks;

		internal static bool isInitialized;

		public static bool shuttingDown;

		private static bool autoInitializePlugin;

		private static bool autoInitializePluginSet;

		public static bool AutoInitializePlugin
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsInitialized(out Result result)
		{
			result = default(Result);
			return false;
		}

		public static bool IsAuthenticatedSessionValid(out Result result)
		{
			result = default(Result);
			return false;
		}

		public static bool IsValidEmail(string emailaddress, out Result result)
		{
			result = default(Result);
			return false;
		}

		private static bool IsSearchFilterValid(SearchFilter filter, out Result result)
		{
			result = default(Result);
			return false;
		}

		public static bool IsRateLimited(out Result result)
		{
			result = default(Result);
			return false;
		}

		public static bool AreSettingsValid(out Result result)
		{
			result = default(Result);
			return false;
		}

		public static void SetLoggingDelegate(LogMessageDelegate loggingDelegate)
		{
		}

		public static Result InitializeForUser(string userProfileIdentifier, ServerSettings serverSettings, BuildSettings buildSettings)
		{
			return default(Result);
		}

		public static Result InitializeForUser(string userProfileIdentifier)
		{
			return default(Result);
		}

		[AsyncStateMachine(typeof(_003CShutdown_003Ed__21))]
		public static Task Shutdown(Action shutdownComplete)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CShutdownTask_003Ed__22))]
		private static Task ShutdownTask()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CIsAuthenticated_003Ed__23))]
		public static Task<Result> IsAuthenticated()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CIsAuthenticated_003Ed__24))]
		public static void IsAuthenticated(Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CRequestEmailAuthToken_003Ed__25))]
		public static Task<Result> RequestEmailAuthToken(string emailaddress)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRequestEmailAuthToken_003Ed__26))]
		public static void RequestEmailAuthToken(string emailaddress, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CSubmitEmailSecurityCode_003Ed__27))]
		public static Task<Result> SubmitEmailSecurityCode(string securityCode)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSubmitEmailSecurityCode_003Ed__28))]
		public static void SubmitEmailSecurityCode(string securityCode, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CGetTermsOfUse_003Ed__29))]
		public static Task<ResultAnd<TermsOfUse>> GetTermsOfUse()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetTermsOfUse_003Ed__30))]
		public static void GetTermsOfUse(Action<ResultAnd<TermsOfUse>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CAuthenticateUser_003Ed__31))]
		public static Task<Result> AuthenticateUser(string data, AuthenticationServiceProvider serviceProvider, string emailAddress, TermsHash? hash, string nonce, OculusDevice? device, string userId, PlayStationEnvironment environment)
		{
			return null;
		}

		private static void SetUserPortal(AuthenticationServiceProvider serviceProvider)
		{
		}

		[AsyncStateMachine(typeof(_003CAuthenticateUser_003Ed__33))]
		public static void AuthenticateUser(string data, AuthenticationServiceProvider serviceProvider, string emailAddress, TermsHash? hash, string nonce, OculusDevice? device, string userId, PlayStationEnvironment environment, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CBeginWssAuthentication_003Ed__34))]
		public static void BeginWssAuthentication(Action<ResultAnd<ExternalAuthenticationToken>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CBeginWssAuthentication_003Ed__35))]
		public static Task<ResultAnd<ExternalAuthenticationToken>> BeginWssAuthentication()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetGameTags_003Ed__36))]
		public static Task<ResultAnd<TagCategory[]>> GetGameTags()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetGameTags_003Ed__37))]
		public static void GetGameTags(Action<ResultAnd<TagCategory[]>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CGetMods_003Ed__38))]
		public static Task<ResultAnd<ModPage>> GetMods(SearchFilter filter)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetMods_003Ed__39))]
		public static void GetMods(SearchFilter filter, Action<ResultAnd<ModPage>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CGetModComments_003Ed__40))]
		public static Task<ResultAnd<CommentPage>> GetModComments(ModId modId, SearchFilter filter)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetModComments_003Ed__41))]
		public static void GetModComments(ModId modId, SearchFilter filter, Action<ResultAnd<CommentPage>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CGetMod_003Ed__42))]
		public static Task<ResultAnd<ModProfile>> GetMod(long id)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetMod_003Ed__43))]
		public static Task GetMod(long id, Action<ResultAnd<ModProfile>> callback)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetModDependencies_003Ed__44))]
		public static Task<ResultAnd<ModDependencies[]>> GetModDependencies(ModId modId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetModDependencies_003Ed__45))]
		public static void GetModDependencies(ModId modId, Action<ResultAnd<ModDependencies[]>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUserRatings_003Ed__46))]
		public static Task<ResultAnd<Rating[]>> GetCurrentUserRatings()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUserRatings_003Ed__47))]
		public static void GetCurrentUserRatings(Action<ResultAnd<Rating[]>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUserRatingFor_003Ed__48))]
		public static Task<ResultAnd<ModRating>> GetCurrentUserRatingFor(ModId modId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUserRatingFor_003Ed__49))]
		public static void GetCurrentUserRatingFor(ModId modId, Action<ResultAnd<ModRating>> callback)
		{
		}

		public static Result EnableModManagement(ModManagementEventDelegate modManagementEventDelegate)
		{
			return default(Result);
		}

		public static Result DisableModManagement()
		{
			return default(Result);
		}

		[AsyncStateMachine(typeof(_003CFetchUpdates_003Ed__52))]
		public static Task<Result> FetchUpdates()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CFetchUpdates_003Ed__53))]
		public static Task FetchUpdates(Action<Result> callback)
		{
			return null;
		}

		public static bool IsModManagementBusy()
		{
			return false;
		}

		public static Result ForceUninstallMod(ModId modId)
		{
			return default(Result);
		}

		public static ProgressHandle GetCurrentModManagementOperation()
		{
			return null;
		}

		public static bool EnableMod(ModId modId)
		{
			return false;
		}

		public static bool DisableMod(ModId modId)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CAddDependenciesToMod_003Ed__59))]
		public static void AddDependenciesToMod(ModId modId, ICollection<ModId> dependencies, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CAddDependenciesToMod_003Ed__60))]
		public static Task<Result> AddDependenciesToMod(ModId modId, ICollection<ModId> dependencies)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRemoveDependenciesFromMod_003Ed__61))]
		public static void RemoveDependenciesFromMod(ModId modId, ICollection<ModId> dependencies, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CRemoveDependenciesFromMod_003Ed__62))]
		public static Task<Result> RemoveDependenciesFromMod(ModId modId, ICollection<ModId> dependencies)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAddModRating_003Ed__63))]
		public static Task<Result> AddModRating(ModId modId, ModRating modRating)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAddModRating_003Ed__64))]
		public static void AddModRating(ModId modId, ModRating rating, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUser_003Ed__65))]
		public static Task<ResultAnd<UserProfile>> GetCurrentUser()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUser_003Ed__66))]
		public static Task GetCurrentUser(Action<ResultAnd<UserProfile>> callback)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUnsubscribeFrom_003Ed__67))]
		public static Task<Result> UnsubscribeFrom(ModId modId)
		{
			return null;
		}

		private static bool ShouldAbortDueToDownloading(ModId modId)
		{
			return false;
		}

		private static bool ShouldAbortDueToInstalling(ModId modId)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CUnsubscribeFrom_003Ed__70))]
		public static void UnsubscribeFrom(ModId modId, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CSubscribeTo_003Ed__71))]
		public static Task<Result> SubscribeTo(ModId modId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSubscribeTo_003Ed__72))]
		public static void SubscribeTo(ModId modId, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CGetUserSubscriptions_003Ed__73))]
		public static Task<ResultAnd<ModPage>> GetUserSubscriptions(SearchFilter filter)
		{
			return null;
		}

		public static SubscribedMod[] GetSubscribedMods(out Result result)
		{
			result = default(Result);
			return null;
		}

		public static InstalledMod[] GetInstalledMods(out Result result)
		{
			result = default(Result);
			return null;
		}

		public static UserInstalledMod[] GetInstalledModsForUser(out Result result, bool includeDisabledMods)
		{
			result = default(Result);
			return null;
		}

		internal static UserInstalledMod[] FilterInstalledModsIntoUserInstalledMods(long userId, bool includeDisabledMods, params InstalledMod[] mods)
		{
			return null;
		}

		public static Result RemoveUserData()
		{
			return default(Result);
		}

		[AsyncStateMachine(typeof(_003CMuteUser_003Ed__79))]
		public static void MuteUser(long userId, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CUnmuteUser_003Ed__80))]
		public static void UnmuteUser(long userId, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CMuteUser_003Ed__81))]
		public static Task<Result> MuteUser(long userId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUnmuteUser_003Ed__82))]
		public static Task<Result> UnmuteUser(long userId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDownloadTexture_003Ed__83))]
		public static Task<ResultAnd<Texture2D>> DownloadTexture(DownloadReference downloadReference)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetImage_003Ed__84))]
		public static Task<ResultAnd<byte[]>> GetImage(DownloadReference downloadReference)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDownloadImage_003Ed__85))]
		private static Task<ResultAnd<byte[]>> DownloadImage(DownloadReference downloadReference)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDownloadTexture_003Ed__86))]
		public static void DownloadTexture(DownloadReference downloadReference, Action<ResultAnd<Texture2D>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CDownloadImage_003Ed__87))]
		public static void DownloadImage(DownloadReference downloadReference, Action<ResultAnd<byte[]>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CReport_003Ed__88))]
		public static Task<Result> Report(Report report)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReport_003Ed__89))]
		public static void Report(Report report, Action<Result> callback)
		{
		}

		public static CreationToken GenerateCreationToken()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCreateModProfile_003Ed__91))]
		public static Task<ResultAnd<ModId>> CreateModProfile(CreationToken token, ModProfileDetails modDetails)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCreateModProfile_003Ed__92))]
		public static void CreateModProfile(CreationToken token, ModProfileDetails modDetails, Action<ResultAnd<ModId>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CEditModProfile_003Ed__93))]
		public static Task<Result> EditModProfile(ModProfileDetails modDetails)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CEditModProfile_003Ed__94))]
		public static void EditModProfile(ModProfileDetails modDetails, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CDeleteTags_003Ed__95))]
		public static void DeleteTags(ModId modId, string[] tags, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CDeleteTags_003Ed__96))]
		public static Task<Result> DeleteTags(ModId modId, string[] tags)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAddModComment_003Ed__97))]
		public static Task<ResultAnd<ModComment>> AddModComment(ModId modId, CommentDetails commentDetails)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAddModComment_003Ed__98))]
		public static void AddModComment(ModId modId, CommentDetails commentDetails, Action<ResultAnd<ModComment>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CUpdateModComment_003Ed__99))]
		public static Task<ResultAnd<ModComment>> UpdateModComment(ModId modId, string content, long commentId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUpdateModComment_003Ed__100))]
		public static void UpdateModComment(ModId modId, string content, long commentId, Action<ResultAnd<ModComment>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CDeleteModComment_003Ed__101))]
		public static Task<Result> DeleteModComment(ModId modId, long commentId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDeleteModComment_003Ed__102))]
		public static void DeleteModComment(ModId modId, long commentId, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CAddTags_003Ed__103))]
		public static void AddTags(ModId modId, string[] tags, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CAddTags_003Ed__104))]
		public static Task<Result> AddTags(ModId modId, string[] tags)
		{
			return null;
		}

		public static ProgressHandle GetCurrentUploadHandle()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUploadModMedia_003Ed__106))]
		public static Task<Result> UploadModMedia(ModProfileDetails modProfileDetails)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUploadModfile_003Ed__107))]
		public static Task<Result> UploadModfile(ModfileDetails modfile)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUploadModMedia_003Ed__108))]
		public static void UploadModMedia(ModProfileDetails modProfileDetails, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CUploadModfile_003Ed__109))]
		public static void UploadModfile(ModfileDetails modfile, Action<Result> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CArchiveModProfile_003Ed__110))]
		public static Task<Result> ArchiveModProfile(ModId modId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CArchiveModProfile_003Ed__111))]
		public static void ArchiveModProfile(ModId modId, Action<Result> callback)
		{
		}

		private static bool IsModfileDetailsValid(ModfileDetails modfile, out Result result)
		{
			result = default(Result);
			return false;
		}

		private static bool IsModProfileDetailsValid(ModProfileDetails modDetails, out Result result)
		{
			result = default(Result);
			return false;
		}

		private static bool IsModProfileDetailsValidForEdit(ModProfileDetails modDetails, out Result result)
		{
			result = default(Result);
			return false;
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUserCreations_003Ed__115))]
		public static Task<ResultAnd<ModPage>> GetCurrentUserCreations(SearchFilter filter)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUserCreations_003Ed__116))]
		public static void GetCurrentUserCreations(SearchFilter filter, Action<ResultAnd<ModPage>> callback)
		{
		}
	}
}
