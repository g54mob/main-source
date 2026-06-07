using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class RepositoryInformation : IDisposable
{
	[CompilerGenerated]
	private sealed class _003Cget_Log_003Ed__14 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public RepositoryInformation _003C_003E4__this;

		private int _003Cskip_003E5__2;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003Cget_Log_003Ed__14(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private bool _disposed;

	private readonly Process _gitProcess;

	public string CommitHash => null;

	public string CommitShortHash => null;

	public string BranchName => null;

	public string TrackedBranchName => null;

	public bool HasUnpushedCommits => false;

	public bool HasUncommittedChanges => false;

	public IEnumerable<string> Log
	{
		[IteratorStateMachine(typeof(_003Cget_Log_003Ed__14))]
		get
		{
			return null;
		}
	}

	private bool IsGitRepository => false;

	public static RepositoryInformation GetRepositoryInformationForPath(string path, string gitPath = null)
	{
		return null;
	}

	public void Dispose()
	{
	}

	private RepositoryInformation(string path, string gitPath)
	{
	}

	private string RunCommand(string args)
	{
		return null;
	}
}
