using System.Collections.Generic;
using System.Linq;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.ValueProviders;

namespace HandlebarsDotNet.Iterators
{
	public sealed class DynamicObjectIterator : IIterator
	{
		private readonly ObjectDescriptor _descriptor;

		public DynamicObjectIterator(ObjectDescriptor descriptor)
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
			ExtendedEnumerator<ChainSegment, IEnumerator<ChainSegment>> extendedEnumerator = ExtendedEnumerator<ChainSegment>.Create(_descriptor.GetProperties(_descriptor, input).Cast<ChainSegment>().GetEnumerator());
			iteratorValues.First = BoxedValues.True;
			iteratorValues.Last = BoxedValues.False;
			int num = 0;
			ObjectAccessor objectAccessor = new ObjectAccessor(input, _descriptor);
			while (extendedEnumerator.MoveNext())
			{
				EnumeratorValue<ChainSegment> current = extendedEnumerator.Current;
				ChainSegment chainSegment = (ChainSegment)(iteratorValues.Key = current.Value);
				if (num == 1)
				{
					iteratorValues.First = BoxedValues.False;
				}
				if (current.IsLast)
				{
					iteratorValues.Last = BoxedValues.True;
				}
				iteratorValues.Index = BoxedValues.Int(num);
				object value2 = (blockParamsValues[in index] = objectAccessor[chainSegment]);
				blockParamsValues[in index2] = chainSegment;
				iteratorValues.Value = value2;
				bindingContext.Value = value2;
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
