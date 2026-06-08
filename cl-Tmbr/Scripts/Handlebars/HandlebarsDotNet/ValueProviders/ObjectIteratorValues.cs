using System;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.ValueProviders
{
	[Obsolete("Use IteratorValues")]
	public readonly ref struct ObjectIteratorValues
	{
		private readonly FixedSizeDictionary<ChainSegment, object, ChainSegment.ChainSegmentEqualityComparer> _data;

		private readonly EntryIndex<ChainSegment>[] _wellKnownVariables;

		public object Key
		{
			get
			{
				return _data[in _wellKnownVariables[(int)ChainSegment.Key.WellKnownVariable]];
			}
			set
			{
				_data[in _wellKnownVariables[(int)ChainSegment.Key.WellKnownVariable]] = value;
			}
		}

		public object Value
		{
			get
			{
				return _data[in _wellKnownVariables[(int)ChainSegment.Value.WellKnownVariable]];
			}
			set
			{
				_data[in _wellKnownVariables[(int)ChainSegment.Value.WellKnownVariable]] = value;
			}
		}

		public object First
		{
			get
			{
				return _data[in _wellKnownVariables[(int)ChainSegment.First.WellKnownVariable]];
			}
			set
			{
				_data[in _wellKnownVariables[(int)ChainSegment.First.WellKnownVariable]] = value;
			}
		}

		public object Index
		{
			get
			{
				return _data[in _wellKnownVariables[(int)ChainSegment.Index.WellKnownVariable]];
			}
			set
			{
				_data[in _wellKnownVariables[(int)ChainSegment.Index.WellKnownVariable]] = value;
			}
		}

		public object Last
		{
			get
			{
				return _data[in _wellKnownVariables[(int)ChainSegment.Last.WellKnownVariable]];
			}
			set
			{
				_data[in _wellKnownVariables[(int)ChainSegment.Last.WellKnownVariable]] = value;
			}
		}

		public ObjectIteratorValues(BindingContext bindingContext)
		{
			this = default(ObjectIteratorValues);
			_data = bindingContext.ContextDataObject;
			_wellKnownVariables = bindingContext.WellKnownVariables;
			_data.AddOrReplace(ChainSegment.Last, in BoxedValues.False, out _wellKnownVariables[(int)ChainSegment.Last.WellKnownVariable]);
			_data.AddOrReplace(ChainSegment.Key, (object)null, out _wellKnownVariables[(int)ChainSegment.Key.WellKnownVariable]);
			_data.AddOrReplace(ChainSegment.Value, (object)null, out _wellKnownVariables[(int)ChainSegment.Value.WellKnownVariable]);
			_data.AddOrReplace(ChainSegment.First, in BoxedValues.True, out _wellKnownVariables[(int)ChainSegment.First.WellKnownVariable]);
			_data.AddOrReplace(ChainSegment.Index, in BoxedValues.Zero, out _wellKnownVariables[(int)ChainSegment.Index.WellKnownVariable]);
		}
	}
}
