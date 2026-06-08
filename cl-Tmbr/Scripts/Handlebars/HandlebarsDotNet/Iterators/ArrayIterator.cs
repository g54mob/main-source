using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet.Iterators
{
	public sealed class ArrayIterator<T> : IIterator
	{
		public void Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			using BindingContext bindingContext = context.CreateFrame();
			IteratorValues iteratorValues = new IteratorValues(bindingContext);
			BlockParamsValues blockParamsValues = new BlockParamsValues(bindingContext, blockParamsVariables);
			blockParamsValues.CreateProperty(0, out var index);
			blockParamsValues.CreateProperty(1, out var index2);
			T[] array = (T[])input;
			int num = array.Length;
			iteratorValues.First = BoxedValues.True;
			iteratorValues.Last = BoxedValues.False;
			int i = 0;
			int num2 = num - 1;
			for (; i < num; i++)
			{
				object value = array[i];
				object obj = BoxedValues.Int(i);
				if (i == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (i == num2)
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
