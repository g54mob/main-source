using System;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal sealed class SingleAssignmentDisposable : IDisposable
{
	private readonly object gate;

	private IDisposable current;

	private bool disposed;

	public bool IsDisposed
	{
		get
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			//IL_007d: Expected O, but got I8
			object obj2 = default(object);
			object obj = obj2 + 8;
			if (gate != null)
			{
				Monitor.Enter(gate);
				object obj3 = default(object);
				if (obj3 != null)
				{
					bool flag = gate == null;
					object obj4 = 4294967295L;
					if (flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
						object obj5 = default(object);
						throw obj5;
					}
					Monitor.Exit(gate);
				}
				return disposed;
			}
			ArgumentNullException ex = new ArgumentNullException("obj");
			ex._002Ector("obj");
			throw ex;
		}
	}

	public IDisposable Disposable
	{
		get
		{
			return current;
		}
		set
		{
			//IL_023e: Expected O, but got I4
			//IL_0058: Expected O, but got I8
			//IL_009c: Expected O, but got I8
			//IL_00da: Expected O, but got I8
			//IL_025b: Expected O, but got I4
			object obj = default(object);
			if (obj == null)
			{
				object obj2 = default(object);
				if (obj2 != null)
				{
					object obj5;
					if (obj == null)
					{
						Monitor.Enter(obj2);
						object obj3 = 4294967295L;
						object obj4 = default(object);
						if (!disposed)
						{
							if (value == null)
							{
								if (obj4 != null)
								{
									bool flag = obj2 == null;
									obj5 = 4294967295L;
									if (flag)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
										obj3 = 0;
										object obj6 = default(object);
										throw obj6;
									}
									Monitor.Exit(obj2);
								}
								return;
							}
							current = value;
							obj3 = 4294967295L;
						}
						if (obj4 != null)
						{
							if (obj2 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
								object obj7 = default(object);
								throw obj7;
							}
							Monitor.Exit(obj2);
						}
						if (~(disposed ? 1u : 0u) == 0 && value != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						else if (current != null)
						{
							object obj8 = new InvalidOperationException();
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
							throw obj8;
						}
						return;
					}
					ArgumentException ex = new ArgumentException();
					obj5 = 0;
					throw ex;
				}
				ArgumentNullException ex2 = new ArgumentNullException("obj");
				ex2._002Ector("obj");
				throw ex2;
			}
			Monitor.ThrowLockTakenException();
			throw null;
		}
	}

	public void Dispose()
	{
		//IL_00ff: Expected O, but got I4
		//IL_0071: Expected O, but got I8
		//IL_00a8: Expected O, but got I8
		object obj = default(object);
		if (obj == null)
		{
			object obj2 = default(object);
			if (obj2 != null)
			{
				object obj3;
				if (obj == null)
				{
					Monitor.Enter(obj2);
					bool flag = disposed;
					IDisposable disposable = null;
					obj3 = 4294967295L;
					if (!flag)
					{
						disposed = true;
						disposable = current;
						current = null;
						obj3 = 4294967295L;
					}
					object obj4 = default(object);
					if (obj4 != null)
					{
						if (obj2 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj5 = default(object);
							throw obj5;
						}
						Monitor.Exit(obj2);
					}
					if (disposable != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					return;
				}
				ArgumentException ex = new ArgumentException();
				obj3 = 0;
				throw ex;
			}
			ArgumentNullException ex2 = new ArgumentNullException("obj");
			ex2._002Ector("obj");
			throw ex2;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}

	public SingleAssignmentDisposable()
	{
		object obj = new object();
		gate = obj;
	}
}
