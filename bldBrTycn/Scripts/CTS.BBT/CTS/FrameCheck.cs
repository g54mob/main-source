using System;
using CTS.Core;
using CTS.Utilities;

namespace CTS
{
	public class FrameCheck : EventCheck, ILateUpdatable
	{
		public FrameCheck(Func<bool> func)
			: base(func)
		{
		}

		public static implicit operator FrameCheck(Func<bool> func)
		{
			return new FrameCheck(func);
		}

		protected override void RegisterTick()
		{
			UpdateSpreader.AddLateUpdate(this);
		}

		protected override void UnregisterTick()
		{
			UpdateSpreader.RemoveLateUpdate(this);
		}

		public void OnLateUpdate()
		{
			OnTick();
		}
	}
	public class FrameCheck<TArg> : EventCheck<TArg>, ILateUpdatable
	{
		public FrameCheck(Func<TArg, bool> func)
			: base(func)
		{
		}

		public static implicit operator FrameCheck<TArg>(Func<TArg, bool> func)
		{
			return new FrameCheck<TArg>(func);
		}

		protected override void RegisterTick()
		{
			UpdateSpreader.AddLateUpdate(this);
		}

		protected override void UnregisterTick()
		{
			UpdateSpreader.RemoveLateUpdate(this);
		}

		public void OnLateUpdate()
		{
			OnTick();
		}
	}
	public class FrameCheck<TArg1, TArg2> : EventCheck<TArg1, TArg2>, ILateUpdatable
	{
		public FrameCheck(Func<TArg1, TArg2, bool> func)
			: base(func)
		{
		}

		public static implicit operator FrameCheck<TArg1, TArg2>(Func<TArg1, TArg2, bool> func)
		{
			return new FrameCheck<TArg1, TArg2>(func);
		}

		protected override void RegisterTick()
		{
			UpdateSpreader.AddLateUpdate(this);
		}

		protected override void UnregisterTick()
		{
			UpdateSpreader.RemoveLateUpdate(this);
		}

		public void OnLateUpdate()
		{
			OnTick();
		}
	}
}
