using System.Collections;
using System.Collections.Generic;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet.Iterators
{
	public class ListIterator<T, TValue> : IIterator where T : IList<TValue>
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
			int i = 0;
			int num = count - 1;
			for (; i < count; i++)
			{
				object value = val[i];
				object obj = BoxedValues.Int(i);
				if (i == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (i == num)
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
			}
			if (i == 0)
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
	public sealed class ListIterator<T> : IIterator where T : IList
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
			int i = 0;
			int num = count - 1;
			for (; i < count; i++)
			{
				object value = val[i];
				object obj = BoxedValues.Int(i);
				if (i == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (i == num)
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
			}
			if (i == 0)
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
