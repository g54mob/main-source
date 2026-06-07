using System;
using ToolBuddy.Pooling.Collections;

namespace FluffyUnderware.Curvy.Generator
{
	public class CGData : IDisposable
	{
		private bool disposed;

		public string Name;

		public virtual int Count => 0;

		protected virtual bool Dispose(bool disposing)
		{
			return false;
		}

		public void Dispose()
		{
		}

		~CGData()
		{
		}

		public static implicit operator bool(CGData a)
		{
			return false;
		}

		public virtual T Clone<T>() where T : CGData
		{
			return null;
		}

		protected int getGenericFIndex(SubArray<float> FMapArray, float fValue, out float frag)
		{
			frag = default(float);
			return 0;
		}
	}
}
