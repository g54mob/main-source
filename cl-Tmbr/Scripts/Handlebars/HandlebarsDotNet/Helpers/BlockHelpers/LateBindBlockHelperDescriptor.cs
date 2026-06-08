using HandlebarsDotNet.Collections;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers.BlockHelpers
{
	public sealed class LateBindBlockHelperDescriptor : IHelperDescriptor<BlockHelperOptions>, IHelperDescriptor, IDescriptor<BlockHelperOptions>
	{
		public PathInfo Name { get; }

		public LateBindBlockHelperDescriptor(string name)
		{
			Name = name;
		}

		public object Invoke(in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			return this.ReturnInvoke(in options, in context, in arguments);
		}

		public void Invoke(in EncodedTextWriter output, in BlockHelperOptions options, in Context context, in Arguments arguments)
		{
			if (options.Frame.BlockHelpers.TryGetValue((string)Name, out var value))
			{
				value.Invoke(in options, in context, in arguments);
				return;
			}
			ICompiledHandlebarsConfiguration configuration = options.Frame.Configuration;
			ObservableList<IHelperResolver> observableList = (ObservableList<IHelperResolver>)configuration.HelperResolvers;
			if (observableList.Count != 0)
			{
				for (int i = 0; i < observableList.Count; i++)
				{
					if (observableList[i].TryResolveBlockHelper(Name, out var helper))
					{
						helper.Invoke(in output, in options, in context, in arguments);
						return;
					}
				}
			}
			configuration.BlockHelpers[(PathInfoLight)"blockHelperMissing"].Value.Invoke(in output, in options, in context, in arguments);
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
