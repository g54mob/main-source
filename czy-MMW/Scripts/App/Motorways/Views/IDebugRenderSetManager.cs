using System.Collections.Generic;
using Client;
using UnityEngine;

namespace Motorways.Views
{
	public interface IDebugRenderSetManager
	{
		IReadOnlyDictionary<string, DebugRendererSet> RendererSets { get; }

		void Register(MonoBehaviour monoBehaviour);

		void Unregister(MonoBehaviour monoBehaviour);

		void RegisterView(IView view);

		void UnregisterView(IView view);
	}
}
