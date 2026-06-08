using System.Runtime.CompilerServices;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.ValueProviders
{
	public readonly ref struct DataValues
	{
		private readonly EntryIndex<ChainSegment>[] _wellKnownVariables;

		private readonly FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer> _data;

		public object this[ChainSegment segment]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				int wellKnownVariable = (int)segment.WellKnownVariable;
				if (segment.WellKnownVariable != WellKnownVariable.None && _wellKnownVariables[wellKnownVariable].IsNotEmpty)
				{
					return _data[in _wellKnownVariables[wellKnownVariable]];
				}
				if (!_data.TryGetValue(in segment, out var value))
				{
					return null;
				}
				return value;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				int wellKnownVariable = (int)segment.WellKnownVariable;
				if (segment.WellKnownVariable != WellKnownVariable.None)
				{
					_data.AddOrReplace(in segment, in value, out _wellKnownVariables[wellKnownVariable]);
				}
				else
				{
					_data.AddOrReplace(in segment, in value, out var _);
				}
			}
		}

		public object this[in EntryIndex<ChainSegment> entryIndex]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _data[in entryIndex];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_data[in entryIndex] = value;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DataValues(BindingContext context)
		{
			_data = context.ContextDataObject;
			_wellKnownVariables = context.WellKnownVariables;
		}

		public T Value<T>(ChainSegment segment)
		{
			return (T)this[segment];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CreateProperty(ChainSegment variable, out EntryIndex<ChainSegment> index)
		{
			UndefinedBindingResult undefinedBindingResult = UndefinedBindingResult.Create(variable);
			FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer> data = _data;
			object value = undefinedBindingResult;
			data.AddOrReplace(in variable, in value, out index);
			if (variable.WellKnownVariable != WellKnownVariable.None)
			{
				_wellKnownVariables[(int)variable.WellKnownVariable] = index;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CreateProperty(ChainSegment variable, object defaultValue, out EntryIndex<ChainSegment> index)
		{
			_data.AddOrReplace(in variable, in defaultValue, out index);
			if (variable.WellKnownVariable != WellKnownVariable.None)
			{
				_wellKnownVariables[(int)variable.WellKnownVariable] = index;
			}
		}
	}
}
