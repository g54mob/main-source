using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace Structs
{
	public struct MatterDecayOfArrays
	{
		[NoAlias]
		public NativeArray<float> _amount;

		[NoAlias]
		public NativeArray<float> _decayAmount;

		[NoAlias]
		public NativeArray<float> _freshTimeRemaining;

		[NoAlias]
		public NativeArray<float> _decayRate;

		private int _length;

		private int _count;

		private bool _disposed;

		public int Length => _length;

		public int Count
		{
			get
			{
				return _count;
			}
			set
			{
				_count = value;
			}
		}

		public bool Disposed => _disposed;

		public MatterDecayOfArrays(int initialCapacity)
		{
			_amount = new NativeArray<float>(initialCapacity, Allocator.Persistent);
			_decayAmount = new NativeArray<float>(initialCapacity, Allocator.Persistent);
			_freshTimeRemaining = new NativeArray<float>(initialCapacity, Allocator.Persistent);
			_decayRate = new NativeArray<float>(initialCapacity, Allocator.Persistent);
			_length = initialCapacity;
			_count = 0;
			_disposed = false;
		}

		public void Dispose()
		{
			_amount.Dispose();
			_decayAmount.Dispose();
			_freshTimeRemaining.Dispose();
			_decayRate.Dispose();
			_disposed = true;
		}

		public void Process(int i, float deltaTime, out bool remove, out float toRemove)
		{
			_freshTimeRemaining[i] -= deltaTime;
			_decayAmount[i] += math.select(deltaTime * _decayRate[i], 0f, _freshTimeRemaining[i] > 0f);
			remove = _decayAmount[i] / _amount[i] > 0.05f;
			toRemove = math.min(_decayAmount[i], _amount[i] + 1E-06f);
			_decayAmount[i] = math.select(_decayAmount[i], 0f, remove);
		}

		public void Upsize()
		{
			int length = Length * 2;
			NativeArray<float> amount = _amount;
			_amount = new NativeArray<float>(length, Allocator.Persistent);
			amount.CopyTo(_amount.GetSubArray(0, Length));
			amount.Dispose();
			amount = _decayAmount;
			_decayAmount = new NativeArray<float>(length, Allocator.Persistent);
			amount.CopyTo(_decayAmount.GetSubArray(0, Length));
			amount.Dispose();
			amount = _freshTimeRemaining;
			_freshTimeRemaining = new NativeArray<float>(length, Allocator.Persistent);
			amount.CopyTo(_freshTimeRemaining.GetSubArray(0, Length));
			amount.Dispose();
			amount = _decayRate;
			_decayRate = new NativeArray<float>(length, Allocator.Persistent);
			amount.CopyTo(_decayRate.GetSubArray(0, Length));
			amount.Dispose();
			_length = length;
		}
	}
}
