using System.Collections.Generic;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet.Iterators
{
	public sealed class ReadOnlyCollectionIterator<T, TValue> : IIterator where T : IReadOnlyCollection<TValue>
	{
		public void Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			using BindingContext bindingContext = context.CreateFrame();
			IteratorValues iteratorValues = new IteratorValues(bindingContext);
			BlockParamsValues blockParamsValues = new BlockParamsValues(bindingContext, blockParamsVariables);
			blockParamsValues.CreateProperty(0, out var index);
			blockParamsValues.CreateProperty(1, out var index2);
			T val = (T)input;
			int count = val.Count;
			iteratorValues.First = BoxedValues.True;
			iteratorValues.Last = BoxedValues.False;
			int num = 0;
			int num2 = count - 1;
			using IEnumerator<TValue> enumerator = val.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object value = enumerator.Current;
				object obj = BoxedValues.Int(num);
				if (num == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (num == num2)
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
