using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Compiler
{
	internal static class Iterator
	{
		public static void Iterate(BindingContext context, EncodedTextWriter writer, ChainSegment[] blockParamsVariables, object target, TemplateDelegate template, TemplateDelegate ifEmpty)
		{
			if (!HandlebarsUtils.IsTruthy(target))
			{
				using (BindingContext context2 = context.CreateFrame(context.Value))
				{
					ifEmpty(in writer, context2);
					return;
				}
			}
			if (!ObjectDescriptor.TryCreate(target, out var descriptor))
			{
				throw new HandlebarsRuntimeException($"Cannot create ObjectDescriptor for type {descriptor.DescribedType}");
			}
			if (descriptor.Iterator == null)
			{
				throw new HandlebarsRuntimeException($"Type {descriptor.DescribedType} does not support iteration");
			}
			descriptor.Iterator.Iterate(in writer, context, blockParamsVariables, target, template, ifEmpty);
		}
	}
}
