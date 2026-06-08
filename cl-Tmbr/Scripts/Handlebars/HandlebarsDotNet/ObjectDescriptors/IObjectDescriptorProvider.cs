using System;

namespace HandlebarsDotNet.ObjectDescriptors
{
	public interface IObjectDescriptorProvider
	{
		bool TryGetDescriptor(Type type, out ObjectDescriptor value);
	}
}
