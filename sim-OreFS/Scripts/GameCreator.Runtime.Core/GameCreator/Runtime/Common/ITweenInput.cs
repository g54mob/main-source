using System;

namespace GameCreator.Runtime.Common
{
	public interface ITweenInput
	{
		int Hash { get; }

		float Duration { get; }

		bool IsFinished { get; }

		bool IsComplete { get; }

		bool IsCanceled { get; }

		event Action<bool> EventFinish;

		bool OnUpdate();

		void OnComplete();

		void OnCancel();
	}
}
