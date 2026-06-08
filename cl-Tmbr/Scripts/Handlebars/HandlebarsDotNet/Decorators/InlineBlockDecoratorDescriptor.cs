using System;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Decorators
{
	internal sealed class InlineBlockDecoratorDescriptor : IDecoratorDescriptor<BlockDecoratorOptions>, IDecoratorDescriptor, IDescriptor<BlockDecoratorOptions>
	{
		public PathInfo Name { get; } = "*inline";

		public TemplateDelegate Invoke(in TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments)
		{
			if (arguments.Length != 1)
			{
				throw new HandlebarsRuntimeException("{{*inline}} helper must have exactly one argument");
			}
			BindingContext frame = options.Frame;
			string key = arguments[0] as string;
			if (key == null)
			{
				throw new HandlebarsRuntimeException("Inline argument is not valid");
			}
			TemplateDelegate template = options.OriginalTemplate;
			frame.InlinePartialTemplates.AddOrReplace(in key, (Action<EncodedTextWriter, BindingContext>)delegate(EncodedTextWriter writer, BindingContext c)
			{
				template(in writer, c);
			});
			return function;
		}

		TemplateDelegate IDecoratorDescriptor<BlockDecoratorOptions>.Invoke(in TemplateDelegate function, in BlockDecoratorOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in function, in options, in context, in arguments);
		}
	}
}
