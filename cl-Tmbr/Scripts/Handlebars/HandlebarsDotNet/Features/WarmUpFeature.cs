using System;
using System.Collections.Generic;
using HandlebarsDotNet.ObjectDescriptors;

namespace HandlebarsDotNet.Features
{
	internal class WarmUpFeature : IFeature
	{
		private readonly HashSet<Type> _types;

		public WarmUpFeature(HashSet<Type> types)
		{
			_types = types;
		}

		public void OnCompiling(ICompiledHandlebarsConfiguration configuration)
		{
			ObjectDescriptorFactory current = ObjectDescriptorFactory.Current;
			foreach (Type type in _types)
			{
				current.TryGetDescriptor(type, out var _);
			}
		}

		public void CompilationCompleted()
		{
		}
	}
}
