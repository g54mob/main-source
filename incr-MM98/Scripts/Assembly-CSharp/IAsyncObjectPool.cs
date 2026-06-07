using System.Threading;
using Cysharp.Threading.Tasks;

public interface IAsyncObjectPool<T>
{
	UniTask<T> RentAsync(CancellationToken cancellationToken);

	void Return(T instance);
}
