using System.Collections.Generic;
using Client;
using UnityEngine;

namespace Motorways.Views
{
	public class NullDebugRenderSetManager : IDebugRenderSetManager
	{
		public IReadOnlyDictionary<string, DebugRendererSet> RendererSets => null;

		public void Register(MonoBehaviour monoBehaviour)
		{
		}

		public void Unregister(MonoBehaviour monoBehaviour)
		{
		}

		public void RegisterView(IView view)
		{
		}

		public void UnregisterView(IView view)
		{
		}
	}
}
