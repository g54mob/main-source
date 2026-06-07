using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ElasticEase : EasingFunctionBase
	{
		public static DependencyProperty OscillationsProperty => null;

		public static DependencyProperty SpringinessProperty => null;

		public int Oscillations
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Springiness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static ElasticEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ElasticEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ElasticEase obj)
		{
			return default(HandleRef);
		}

		public ElasticEase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
