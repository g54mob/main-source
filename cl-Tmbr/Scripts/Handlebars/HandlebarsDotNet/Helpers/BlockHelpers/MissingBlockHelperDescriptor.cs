using System.Collections;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Polyfills;

namespace HandlebarsDotNet.Helpers.BlockHelpers
{
	public sealed class MissingBlockHelperDescriptor : IHelperDescriptor<BlockHelperOptions>, IHelperDescriptor, IDescriptor<BlockHelperOptions>
	{
		private static readonly ChainSegment[] BlockParamsVariables = ArrayEx.Empty<ChainSegment>();

		public PathInfo Name { get; } = "missingBlockHelper";

		public object Invoke(in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			return this.ReturnInvoke(in options, in context, in arguments);
		}

		public void Invoke(in EncodedTextWriter output, in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			if (arguments.Length > 0)
			{
				throw new HandlebarsRuntimeException($"Template references a helper that cannot be resolved. BlockHelper '{options.Name}'");
			}
			BindingContext frame = options.Frame;
			RenderSection(PathResolver.ResolvePath(frame, options.Name), frame, output, options.OriginalTemplate, options.OriginalInverse);
		}

		private static void RenderSection(object value, BindingContext context, EncodedTextWriter writer, TemplateDelegate body, TemplateDelegate inversion)
		{
			int num;
			if (value is bool)
			{
				if ((bool)value)
				{
					body(in writer, context);
					return;
				}
				num = 1;
			}
			else
			{
				if (value == null)
				{
					goto IL_004f;
				}
				num = 2;
			}
			if (!HandlebarsUtils.IsFalsyOrEmpty(value))
			{
				if (num != 1)
				{
					if (num != 2)
					{
						goto IL_004f;
					}
					if (value is string)
					{
						using BindingContext context2 = context.CreateFrame(value);
						body(in writer, context2);
						return;
					}
					if (value is IEnumerable target)
					{
						Iterator.Iterate(context, writer, BlockParamsVariables, target, body, inversion);
						return;
					}
				}
				using BindingContext context3 = context.CreateFrame(value);
				body(in writer, context3);
				return;
			}
			goto IL_004f;
			IL_004f:
			inversion(in writer, context);
		}

		object IHelperDescriptor<BlockHelperOptions>.Invoke(in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in options, in context, in arguments);
		}

		void IHelperDescriptor<BlockHelperOptions>.Invoke(in EncodedTextWriter output, in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			Invoke(in output, in options, in context, in arguments);
		}
	}
}
