using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Coherence.Cloud
{
	public sealed class LoginOperation : CloudOperation<PlayerAccount, LoginOperationError>
	{
		public IReadOnlyList<string> LobbyIds => null;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IReadOnlyList<KeyValuePair<string, string>> KeyValuePairStoreState => null;

		internal LoginOperation(Task<PlayerAccount> task)
			: base((Task<PlayerAccount>)null)
		{
		}

		public new LoginOperation ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public LoginOperation ContinueWith([DisallowNull] Action<LoginOperation> action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public new LoginOperation OnSuccess([DisallowNull] Action<PlayerAccount> action)
		{
			return null;
		}

		public new LoginOperation OnFail([DisallowNull] Action<LoginOperationError> action)
		{
			return null;
		}

		public new TaskAwaiter<LoginOperation> GetAwaiter()
		{
			return default(TaskAwaiter<LoginOperation>);
		}

		internal override LoginOperationError CreateError([DisallowNull] Exception exception, object args = null)
		{
			return null;
		}
	}
}
