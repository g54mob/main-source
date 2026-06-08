using System;
using System.Collections.Generic;

namespace HandlebarsDotNet.Features
{
	internal class WarmUpFeatureFactory : IFeatureFactory
	{
		private readonly HashSet<Type> _types;

		public WarmUpFeatureFactory(HashSet<Type> types)
		{
			_types = types;
		}

		public IFeature CreateFeature()
		{
			return new WarmUpFeature(_types);
		}
	}
}
