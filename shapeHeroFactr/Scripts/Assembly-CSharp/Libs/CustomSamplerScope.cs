using System;
using UnityEngine;
using UnityEngine.Profiling;

namespace Libs
{
	public sealed class CustomSamplerScope : IDisposable
	{
		private readonly CustomSampler _mSampler;

		public CustomSamplerScope(string name)
		{
		}

		public CustomSamplerScope(string name, UnityEngine.Object targetObject)
		{
		}

		public void Dispose()
		{
		}
	}
}
