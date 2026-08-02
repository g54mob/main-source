using System;
using System.Runtime.CompilerServices;
using Rhizomatic.Pooling;

namespace GRP
{
	public class PartHandle : PoolObject
	{
		[NonSerialized]
		public PartView partView;

		public Part part;

		public float minSize => 0f;

		public float maxSize => 0f;

		public event Action onRendered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Setup()
		{
		}

		protected virtual void OnRender()
		{
		}

		protected override void OnPooled()
		{
		}

		public void _Setup(PartView partView)
		{
		}

		public void _OnRender()
		{
		}

		public void BuildHandle(AxisHandle handle, Func<HandleBuildOptions> getOp, bool dontUndo = false)
		{
		}
	}
	public class PartHandle<TPart> : PartHandle where TPart : Part
	{
		public new TPart part => null;
	}
	public class PartHandle<TPart, TPartView> : PartHandle where TPart : Part where TPartView : PartView
	{
		public new TPart part => null;

		public new TPartView partView => null;
	}
}
