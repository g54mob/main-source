using System.Collections;
using System.Collections.Generic;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet.Iterators
{
	public sealed class EnumerableIterator<T, TValue> : IIterator where T : IEnumerable<TValue>
	{
		public void Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			using BindingContext bindingContext = context.CreateFrame();
			IteratorValues iteratorValues = new IteratorValues(bindingContext);
			BlockParamsValues blockParamsValues = new BlockParamsValues(bindingContext, blockParamsVariables);
			blockParamsValues.CreateProperty(0, out var index);
			blockParamsValues.CreateProperty(1, out var index2);
			ExtendedEnumerator<TValue, IEnumerator<TValue>> extendedEnumerator = ExtendedEnumerator<TValue>.Create(((T)input/*cast due to .constrained prefix*/).GetEnumerator());
			iteratorValues.First = BoxedValues.True;
			iteratorValues.Last = BoxedValues.False;
			int num = 0;
			while (extendedEnumerator.MoveNext())
			{
				EnumeratorValue<TValue> current = extendedEnumerator.Current;
				object value = current.Value;
				object obj = BoxedValues.Int(num);
				if (num == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (current.IsLast)
				{
					iteratorValues.Last = BoxedValues.True;
				}
				object key = (iteratorValues.Index = obj);
				iteratorValues.Key = key;
				blockParamsValues[in index] = value;
				blockParamsValues[in index2] = obj;
				iteratorValues.Value = value;
				bindingContext.Value = value;
				template(in writer, bindingContext);
				num++;
			}
			if (num == 0)
			{
				bindingContext.Value = context.Value;
				ifEmpty(in writer, bindingContext);
			}
		}

		void IIterator.Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			Iterate(in writer, context, blockParamsVariables, input, template, ifEmpty);
		}
	}
	public sealed class EnumerableIterator<T> : IIterator where T : IEnumerable
	{
		public void Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			using BindingContext bindingContext = context.CreateFrame();
			IteratorValues iteratorValues = new IteratorValues(bindingContext);
			BlockParamsValues blockParamsValues = new BlockParamsValues(bindingContext, blockParamsVariables);
			blockParamsValues.CreateProperty(0, out var index);
			blockParamsValues.CreateProperty(1, out var index2);
			ExtendedEnumerator<object> extendedEnumerator = ExtendedEnumerator<object>.Create(((T)input/*cast due to .constrained prefix*/).GetEnumerator());
			iteratorValues.First = BoxedValues.True;
			iteratorValues.Last = BoxedValues.False;
			int num = 0;
			while (extendedEnumerator.MoveNext())
			{
				EnumeratorValue<object> current = extendedEnumerator.Current;
				object value = current.Value;
				object obj = BoxedValues.Int(num);
				if (num == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (current.IsLast)
				{
					iteratorValues.Last = BoxedValues.True;
				}
				object key = (iteratorValues.Index = obj);
				iteratorValues.Key = key;
				blockParamsValues[in index] = value;
				blockParamsValues[in index2] = obj;
				iteratorValues.Value = value;
				bindingContext.Value = value;
				template(in writer, bindingContext);
				num++;
			}
			if (num == 0)
			{
				bindingContext.Value = context.Value;
				ifEmpty(in writer, bindingContext);
			}
		}

		void IIterator.Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			Iterate(in writer, context, blockParamsVariables, input, template, ifEmpty);
		}
	}
}
