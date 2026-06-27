using System.Collections;
using UnityEngine;

namespace Restory.Infrastructure.ProjectServices
{
	public interface ICoroutineRunner
	{
		Coroutine Run(IEnumerator coroutine);

		void Stop(Coroutine coroutine);
	}
}
