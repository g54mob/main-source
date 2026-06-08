using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet.Iterators
{
	public sealed class ObjectIterator : IIterator
	{
		private readonly ObjectDescriptor _descriptor;

		public ObjectIterator(ObjectDescriptor descriptor)
		{
			_descriptor = descriptor;
		}

		public void Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			using BindingContext bindingContext = context.CreateFrame();
			IteratorValues iteratorValues = new IteratorValues(bindingContext);
			BlockParamsValues blockParamsValues = new BlockParamsValues(bindingContext, blockParamsVariables);
			blockParamsValues.CreateProperty(0, out var index);
			blockParamsValues.CreateProperty(1, out var index2);
			ChainSegment[] array = (ChainSegment[])_descriptor.GetProperties(_descriptor, input);
			iteratorValues.First = BoxedValues.True;
			iteratorValues.Last = BoxedValues.False;
			int i = 0;
			int num = array.Length - 1;
			ObjectAccessor objectAccessor = new ObjectAccessor(input, _descriptor);
			for (; i < array.Length; i++)
			{
				ChainSegment chainSegment = (ChainSegment)(iteratorValues.Key = array[i]);
				if (i == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (i == num)
				{
					iteratorValues.Last = BoxedValues.True;
				}
				iteratorValues.Index = BoxedValues.Int(i);
				object value = (blockParamsValues[in index] = objectAccessor[chainSegment]);
				blockParamsValues[in index2] = chainSegment;
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
