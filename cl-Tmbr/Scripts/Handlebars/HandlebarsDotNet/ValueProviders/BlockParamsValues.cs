using System.Runtime.CompilerServices;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.ValueProviders
{
	public readonly ref struct BlockParamsValues
	{
		private readonly ChainSegment[] _variables;

		private readonly FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer> _values;

		public object this[in EntryIndex<ChainSegment> index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (_values != null)
				{
					_values[in index] = value;
				}
			}
		}

		public object this[int variableIndex]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (_values != null)
				{
					ChainSegment key = GetVariable(variableIndex);
					if ((object)key != null)
					{
						_values.AddOrReplace(in key, in value, out var _);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BlockParamsValues(BindingContext context, ChainSegment[] variables)
		{
			_variables = variables;
			_values = context?.BlockParamsObject;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CreateProperty(in int variableIndex, out EntryIndex<ChainSegment> index)
		{
			ChainSegment key = GetVariable(variableIndex);
			if ((object)key == null)
			{
				index = new EntryIndex<ChainSegment>(-1, (byte)0);
				return;
			}
			UndefinedBindingResult undefinedBindingResult = UndefinedBindingResult.Create(key);
			FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer> values = _values;
			object value = undefinedBindingResult;
			values.AddOrReplace(in key, in value, out index);
		}

		private ChainSegment GetVariable(int index)
		{
			if (_variables == null || _variables.Length == 0 || index >= _variables.Length)
			{
				return null;
			}
			return _variables[index];
		}
	}
}
