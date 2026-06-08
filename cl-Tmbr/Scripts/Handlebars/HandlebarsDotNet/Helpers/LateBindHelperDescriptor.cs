using System;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Helpers
{
	public sealed class LateBindHelperDescriptor : IHelperDescriptor<HelperOptions>, IHelperDescriptor, IDescriptor<HelperOptions>
	{
		public PathInfo Name { get; }

		public LateBindHelperDescriptor(string name)
		{
			Name = name;
		}

		public object Invoke(in HelperOptions options, in Context context, in Arguments arguments)
		{
			BindingContext frame = options.Frame;
			if (options.Frame.Helpers.TryGetValue((string)Name, out var value))
			{
				return value.Invoke(in options, in context, in arguments);
			}
			ICompiledHandlebarsConfiguration configuration = options.Frame.Configuration;
			ObservableList<IHelperResolver> observableList = (ObservableList<IHelperResolver>)configuration.HelperResolvers;
			if (observableList.Count != 0)
			{
				Type targetType = ((arguments.Length > 0) ? arguments[0].GetType() : null);
				for (int i = 0; i < observableList.Count; i++)
				{
					if (observableList[i].TryResolveHelper(Name, targetType, out var helper))
					{
						return helper.Invoke(in options, in context, in arguments);
					}
				}
			}
			object obj = PathResolver.ResolvePath(frame, Name);
			if (!(obj is UndefinedBindingResult))
			{
				return obj;
			}
			return configuration.Helpers[(PathInfoLight)"helperMissing"].Value.Invoke(in options, in context, in arguments);
		}

		public void Invoke(in EncodedTextWriter output, in HelperOptions options, in Context context, in Arguments arguments)
		{
			output.Write(Invoke(in options, in context, in arguments));
		}

		object IHelperDescriptor<HelperOptions>.Invoke(in HelperOptions options, in Context context, in Arguments arguments)
		{
			return Invoke(in options, in context, in arguments);
		}

		void IHelperDescriptor<HelperOptions>.Invoke(in EncodedTextWriter output, in HelperOptions options, in Context context, in Arguments arguments)
		{
			Invoke(in output, in options, in context, in arguments);
		}
	}
}
