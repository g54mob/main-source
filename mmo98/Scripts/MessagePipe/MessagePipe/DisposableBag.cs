using System;

namespace MessagePipe
{
	public static class DisposableBag
	{
		private sealed class NthDisposable : IDisposable
		{
			private bool disposed;

			private readonly IDisposable[] disposables;

			public NthDisposable(IDisposable[] disposables)
			{
				this.disposables = disposables;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					IDisposable[] array = disposables;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].Dispose();
					}
				}
			}
		}

		private sealed class Disposable1 : IDisposable
		{
			private bool disposed;

			private readonly IDisposable disposable1;

			public Disposable1(IDisposable disposable1)
			{
				this.disposable1 = disposable1;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					disposable1.Dispose();
				}
			}
		}

		private sealed class Disposable2 : IDisposable
		{
			private bool disposed;

			private readonly IDisposable disposable1;

			private readonly IDisposable disposable2;

			public Disposable2(IDisposable disposable1, IDisposable disposable2)
			{
				this.disposable1 = disposable1;
				this.disposable2 = disposable2;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					disposable1.Dispose();
					disposable2.Dispose();
				}
			}
		}

		private sealed class Disposable3 : IDisposable
		{
			private bool disposed;

			private readonly IDisposable disposable1;

			private readonly IDisposable disposable2;

			private readonly IDisposable disposable3;

			public Disposable3(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3)
			{
				this.disposable1 = disposable1;
				this.disposable2 = disposable2;
				this.disposable3 = disposable3;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					disposable1.Dispose();
					disposable2.Dispose();
					disposable3.Dispose();
				}
			}
		}

		private sealed class Disposable4 : IDisposable
		{
			private bool disposed;

			private readonly IDisposable disposable1;

			private readonly IDisposable disposable2;

			private readonly IDisposable disposable3;

			private readonly IDisposable disposable4;

			public Disposable4(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4)
			{
				this.disposable1 = disposable1;
				this.disposable2 = disposable2;
				this.disposable3 = disposable3;
				this.disposable4 = disposable4;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					disposable1.Dispose();
					disposable2.Dispose();
					disposable3.Dispose();
					disposable4.Dispose();
				}
			}
		}

		private sealed class Disposable5 : IDisposable
		{
			private bool disposed;

			private readonly IDisposable disposable1;

			private readonly IDisposable disposable2;

			private readonly IDisposable disposable3;

			private readonly IDisposable disposable4;

			private readonly IDisposable disposable5;

			public Disposable5(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5)
			{
				this.disposable1 = disposable1;
				this.disposable2 = disposable2;
				this.disposable3 = disposable3;
				this.disposable4 = disposable4;
				this.disposable5 = disposable5;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					disposable1.Dispose();
					disposable2.Dispose();
					disposable3.Dispose();
					disposable4.Dispose();
					disposable5.Dispose();
				}
			}
		}

		private sealed class Disposable6 : IDisposable
		{
			private bool disposed;

			private readonly IDisposable disposable1;

			private readonly IDisposable disposable2;

			private readonly IDisposable disposable3;

			private readonly IDisposable disposable4;

			private readonly IDisposable disposable5;

			private readonly IDisposable disposable6;

			public Disposable6(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6)
			{
				this.disposable1 = disposable1;
				this.disposable2 = disposable2;
				this.disposable3 = disposable3;
				this.disposable4 = disposable4;
				this.disposable5 = disposable5;
				this.disposable6 = disposable6;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					disposable1.Dispose();
					disposable2.Dispose();
					disposable3.Dispose();
					disposable4.Dispose();
					disposable5.Dispose();
					disposable6.Dispose();
				}
			}
		}

		private sealed class Disposable7 : IDisposable
		{
			private bool disposed;

			private readonly IDisposable disposable1;

			private readonly IDisposable disposable2;

			private readonly IDisposable disposable3;

			private readonly IDisposable disposable4;

			private readonly IDisposable disposable5;

			private readonly IDisposable disposable6;

			private readonly IDisposable disposable7;

			public Disposable7(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6, IDisposable disposable7)
			{
				this.disposable1 = disposable1;
				this.disposable2 = disposable2;
				this.disposable3 = disposable3;
				this.disposable4 = disposable4;
				this.disposable5 = disposable5;
				this.disposable6 = disposable6;
				this.disposable7 = disposable7;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					disposable1.Dispose();
					disposable2.Dispose();
					disposable3.Dispose();
					disposable4.Dispose();
					disposable5.Dispose();
					disposable6.Dispose();
					disposable7.Dispose();
				}
			}
		}

		public static IDisposable Empty => EmptyDisposable.Instance;

		public static IDisposable Create(params IDisposable[] disposables)
		{
			return new NthDisposable(disposables);
		}

		public static SingleAssignmentDisposable CreateSingleAssignment()
		{
			return new SingleAssignmentDisposable();
		}

		public static CancellationTokenDisposable CreateCancellation()
		{
			return new CancellationTokenDisposable();
		}

		public static DisposableBagBuilder CreateBuilder()
		{
			return new DisposableBagBuilder();
		}

		public static DisposableBagBuilder CreateBuilder(int initialCapacity)
		{
			return new DisposableBagBuilder(initialCapacity);
		}

		public static void AddTo(this IDisposable disposable, DisposableBagBuilder disposableBag)
		{
			disposableBag.Add(disposable);
		}

		public static SingleAssignmentDisposable SetTo(this IDisposable disposable, SingleAssignmentDisposable singleAssignmentDisposable)
		{
			singleAssignmentDisposable.Disposable = disposable;
			return singleAssignmentDisposable;
		}

		public static IDisposable Create(IDisposable disposable1)
		{
			return new Disposable1(disposable1);
		}

		public static IDisposable Create(IDisposable disposable1, IDisposable disposable2)
		{
			return new Disposable2(disposable1, disposable2);
		}

		public static IDisposable Create(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3)
		{
			return new Disposable3(disposable1, disposable2, disposable3);
		}

		public static IDisposable Create(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4)
		{
			return new Disposable4(disposable1, disposable2, disposable3, disposable4);
		}

		public static IDisposable Create(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5)
		{
			return new Disposable5(disposable1, disposable2, disposable3, disposable4, disposable5);
		}

		public static IDisposable Create(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6)
		{
			return new Disposable6(disposable1, disposable2, disposable3, disposable4, disposable5, disposable6);
		}

		public static IDisposable Create(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6, IDisposable disposable7)
		{
			return new Disposable7(disposable1, disposable2, disposable3, disposable4, disposable5, disposable6, disposable7);
		}
	}
}
