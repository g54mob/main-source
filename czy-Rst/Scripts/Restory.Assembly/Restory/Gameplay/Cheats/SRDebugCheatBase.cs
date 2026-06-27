using System;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	[DefaultExecutionOrder(50000)]
	public abstract class SRDebugCheatBase : IInitializable, IDisposable
	{
		void IInitializable.Initialize()
		{
			SRDebug.Instance.AddOptionContainer(this);
			Init();
		}

		void IDisposable.Dispose()
		{
			SRDebug.Instance?.RemoveOptionContainer(this);
			CleanUp();
		}

		protected virtual void Init()
		{
		}

		protected virtual void CleanUp()
		{
		}
	}
}
