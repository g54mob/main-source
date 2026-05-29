using System;

namespace Animancer
{
	public class ExitEvent : Key, IUpdatable, Key.IListItem
	{
		private Action _Callback;

		private AnimancerNode _Node;

		public static void Register(AnimancerNode node, Action callback)
		{
			ExitEvent exitEvent = ObjectPool.Acquire<ExitEvent>();
			exitEvent._Callback = callback;
			exitEvent._Node = node;
			node.Root.RequirePostUpdate(exitEvent);
		}

		public static bool Unregister(AnimancerPlayable animancer)
		{
			for (int num = animancer.PostUpdatableCount - 1; num >= 0; num--)
			{
				if (animancer.GetPostUpdatable(num) is ExitEvent exitEvent)
				{
					animancer.CancelPostUpdate(exitEvent);
					exitEvent.Release();
					return true;
				}
			}
			return false;
		}

		public static bool Unregister(AnimancerNode node)
		{
			AnimancerPlayable root = node.Root;
			for (int num = root.PostUpdatableCount - 1; num >= 0; num--)
			{
				if (root.GetPostUpdatable(num) is ExitEvent exitEvent && exitEvent._Node == node)
				{
					root.CancelPostUpdate(exitEvent);
					exitEvent.Release();
					return true;
				}
			}
			return false;
		}

		void IUpdatable.Update()
		{
			if (!_Node.IsValid() || !(_Node.EffectiveWeight > 0f))
			{
				_Callback();
				_Node.Root.CancelPostUpdate(this);
				Release();
			}
		}

		private void Release()
		{
			_Callback = null;
			_Node = null;
			ObjectPool.Release(this);
		}
	}
}
