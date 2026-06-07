using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Threading;
using R3.Internal;

namespace R3
{
	public ref struct DisposableBuilder
	{
		private IDisposable? disposable1;

		private IDisposable? disposable2;

		private IDisposable? disposable3;

		private IDisposable? disposable4;

		private IDisposable? disposable5;

		private IDisposable? disposable6;

		private IDisposable? disposable7;

		private IDisposable? disposable8;

		private IDisposable[]? disposables;

		private int count;

		public DisposableBuilder()
		{
			disposable1 = null;
			disposable2 = null;
			disposable3 = null;
			disposable4 = null;
			disposable5 = null;
			disposable6 = null;
			disposable7 = null;
			disposable8 = null;
			disposables = null;
			count = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(IDisposable disposable)
		{
			ThrowHelper.ThrowArgumentNullIfNull(disposable, "disposable");
			ThrowHelper.ThrowObjectDisposedIf(count == -1, typeof(DisposableBuilder));
			switch (count)
			{
			case 0:
				disposable1 = disposable;
				break;
			case 1:
				disposable2 = disposable;
				break;
			case 2:
				disposable3 = disposable;
				break;
			case 3:
				disposable4 = disposable;
				break;
			case 4:
				disposable5 = disposable;
				break;
			case 5:
				disposable6 = disposable;
				break;
			case 6:
				disposable7 = disposable;
				break;
			case 7:
				disposable8 = disposable;
				break;
			default:
				AddToArray(disposable);
				break;
			}
			count++;
		}

		private void AddToArray(IDisposable disposable)
		{
			if (count == 8)
			{
				IDisposable[] array = ArrayPool<IDisposable>.Shared.Rent(16);
				array[8] = disposable;
				array[0] = disposable1;
				array[1] = disposable2;
				array[2] = disposable3;
				array[3] = disposable4;
				array[4] = disposable5;
				array[5] = disposable6;
				array[6] = disposable7;
				array[7] = disposable8;
				disposable1 = (disposable2 = (disposable3 = (disposable4 = (disposable5 = (disposable6 = (disposable7 = (disposable8 = null)))))));
				disposables = array;
			}
			else
			{
				if (disposables.Length == count)
				{
					IDisposable[] destinationArray = ArrayPool<IDisposable>.Shared.Rent(count * 2);
					Array.Copy(disposables, destinationArray, disposables.Length);
					ArrayPool<IDisposable>.Shared.Return(disposables, clearArray: true);
					disposables = destinationArray;
				}
				disposables[count] = disposable;
			}
		}

		public IDisposable Build()
		{
			ThrowHelper.ThrowObjectDisposedIf(count == -1, typeof(DisposableBuilder));
			IDisposable result = count switch
			{
				0 => Disposable.Empty, 
				1 => disposable1, 
				2 => new CombinedDisposable2(disposable1, disposable2), 
				3 => new CombinedDisposable3(disposable1, disposable2, disposable3), 
				4 => new CombinedDisposable4(disposable1, disposable2, disposable3, disposable4), 
				5 => new CombinedDisposable5(disposable1, disposable2, disposable3, disposable4, disposable5), 
				6 => new CombinedDisposable6(disposable1, disposable2, disposable3, disposable4, disposable5, disposable6), 
				7 => new CombinedDisposable7(disposable1, disposable2, disposable3, disposable4, disposable5, disposable6, disposable7), 
				8 => new CombinedDisposable8(disposable1, disposable2, disposable3, disposable4, disposable5, disposable6, disposable7, disposable8), 
				_ => new CombinedDisposable(disposables.AsSpan(0, count).ToArray()), 
			};
			Dispose();
			return result;
		}

		public CancellationTokenRegistration RegisterTo(CancellationToken cancellationToken)
		{
			return Build().RegisterTo(cancellationToken);
		}

		public void Dispose()
		{
			if (count != -1)
			{
				disposable1 = (disposable2 = (disposable3 = (disposable4 = (disposable5 = (disposable6 = (disposable7 = (disposable8 = null)))))));
				if (disposables != null)
				{
					ArrayPool<IDisposable>.Shared.Return(disposables, clearArray: true);
				}
				count = -1;
			}
		}
	}
}
