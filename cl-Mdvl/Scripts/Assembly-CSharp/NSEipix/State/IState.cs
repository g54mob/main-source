using System;
using System.Collections.Generic;

namespace NSEipix.State
{
	public interface IState<T>
	{
		List<Type> TransitionIn();

		void Enter(T owner);

		void Update(T owner);

		void Exit(T owner);
	}
}
