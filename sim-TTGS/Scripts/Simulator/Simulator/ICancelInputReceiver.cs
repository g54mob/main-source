using System.Collections.Generic;

namespace Simulator
{
	public interface ICancelInputReceiver
	{
		private static ICancelInputReceiver _current;

		private static Stack<ICancelInputReceiver> _stack;

		void OnCancel();

		static void SetCurrent(ICancelInputReceiver receiver)
		{
			_stack.Clear();
			_current = receiver;
		}

		static void Stack(ICancelInputReceiver receiver)
		{
			_stack.Push(_current);
			_current = receiver;
		}

		static void PopCurrent()
		{
			_stack.TryPop(out _current);
		}

		static bool HasCurrent(out ICancelInputReceiver receiver)
		{
			receiver = _current;
			return receiver != null;
		}

		static ICancelInputReceiver()
		{
			_stack = new Stack<ICancelInputReceiver>();
		}
	}
}
