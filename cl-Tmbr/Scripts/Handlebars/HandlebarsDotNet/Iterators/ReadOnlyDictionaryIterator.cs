using System.Collections.Generic;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet.Iterators
{
	public sealed class ReadOnlyDictionaryIterator<TDictionary, TKey, TValue> : IIterator where TDictionary : class, IReadOnlyDictionary<TKey, TValue>
	{
		public void Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			using BindingContext bindingContext = context.CreateFrame();
			IteratorValues iteratorValues = new IteratorValues(bindingContext);
			BlockParamsValues blockParamsValues = new BlockParamsValues(bindingContext, blockParamsVariables);
			blockParamsValues.CreateProperty(0, out var index);
			blockParamsValues.CreateProperty(1, out var index2);
			TDictionary val = (TDictionary)input;
			using IEnumerator<KeyValuePair<TKey, TValue>> enumerator = val.GetEnumerator();
			iteratorValues.First = BoxedValues.True;
			iteratorValues.Last = BoxedValues.False;
			int num = 0;
			int num2 = val.Count - 1;
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current.Key;
				object value = enumerator.Current.Value;
				iteratorValues.Key = obj;
				if (num == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (num == num2)
				{
					iteratorValues.Last = BoxedValues.True;
				}
				iteratorValues.Index = BoxedValues.Int(num);
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
