using System.Collections.Generic;
using System.Linq;
using Client;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways.Views
{
	public class DebugRenderSetManager : IDebugRenderSetManager
	{
		private readonly Dictionary<string, DebugRendererSet> _registeredRendererSet = new Dictionary<string, DebugRendererSet>();

		public IReadOnlyDictionary<string, DebugRendererSet> RendererSets => _registeredRendererSet;

		public void Register(MonoBehaviour monoBehaviour)
		{
			Renderer[] renderers = GetRenderers(monoBehaviour);
			if (renderers.Length != 0)
			{
				GetOrCreateRenderSet(GetName(monoBehaviour)).AddRenderers(renderers, monoBehaviour);
			}
		}

		public void Unregister(MonoBehaviour monoBehaviour)
		{
			Renderer[] renderers = GetRenderers(monoBehaviour);
			if (renderers.Length != 0)
			{
				GetOrCreateRenderSet(GetName(monoBehaviour)).RemoveRenderers(renderers, monoBehaviour);
			}
		}

		public void RegisterView(IView view)
		{
			if (view is MonoBehaviour monoBehaviour)
			{
				Register(monoBehaviour);
			}
		}

		public void UnregisterView(IView view)
		{
			if (view is MonoBehaviour monoBehaviour)
			{
				Unregister(monoBehaviour);
			}
		}

		private string GetName<T>(T monoBehaviour) where T : MonoBehaviour
		{
			if (!(monoBehaviour is CityDefinition { name: var name }))
			{
				return monoBehaviour.GetType().Name;
			}
			return name;
		}

		private DebugRendererSet GetOrCreateRenderSet(string id)
		{
			if (_registeredRendererSet.TryGetValue(id, out var value))
			{
				return value;
			}
			value = new DebugRendererSet(id);
			_registeredRendererSet.Add(id, value);
			return value;
		}

		private Renderer[] GetRenderers(MonoBehaviour monoBehaviour)
		{
			Renderer[] array = monoBehaviour.GetComponentsInChildren<Renderer>();
			if (monoBehaviour is CityDefinition)
			{
				array = array.Where((Renderer renderer) => !(renderer is TilemapRenderer)).ToArray();
			}
			return array;
		}
	}
}
