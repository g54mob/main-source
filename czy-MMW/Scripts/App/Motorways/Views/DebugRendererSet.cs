using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways.Views
{
	public class DebugRendererSet
	{
		public readonly string id;

		private readonly Dictionary<string, List<Renderer>> _registeredRenderers = new Dictionary<string, List<Renderer>>();

		private readonly Dictionary<string, bool> _isMutedStatus = new Dictionary<string, bool>();

		public IReadOnlyCollection<string> RendererNames => _isMutedStatus.Keys.ToList();

		public bool AllRenderersMuted
		{
			get
			{
				foreach (bool value in _isMutedStatus.Values)
				{
					if (!value)
					{
						return false;
					}
				}
				return true;
			}
		}

		public DebugRendererSet(string id)
		{
			this.id = id;
		}

		public bool AreRenderersWithNameMuted(string name)
		{
			if (_isMutedStatus.TryGetValue(name, out var value))
			{
				return value;
			}
			return false;
		}

		private void AddRenderer(Renderer renderer, MonoBehaviour source)
		{
			string rendererName = GetRendererName(renderer, source);
			if (_registeredRenderers.TryGetValue(rendererName, out var value))
			{
				if (!value.Contains(renderer))
				{
					value.Add(renderer);
				}
			}
			else
			{
				_isMutedStatus.Add(rendererName, !renderer.enabled);
				_registeredRenderers.Add(rendererName, new List<Renderer> { renderer });
			}
		}

		private string GetRendererName(Renderer renderer, MonoBehaviour source)
		{
			string text = renderer.name;
			if (source is RoadView && text.Contains("Road #"))
			{
				text = "Road";
			}
			return text;
		}

		public void RemoveRenderer(Renderer renderer, MonoBehaviour source)
		{
			string rendererName = GetRendererName(renderer, source);
			if (_registeredRenderers.TryGetValue(rendererName, out var value))
			{
				value.Remove(renderer);
			}
		}

		public void RemoveRenderers(ICollection<Renderer> renderers, MonoBehaviour source)
		{
			foreach (Renderer renderer in renderers)
			{
				RemoveRenderer(renderer, source);
			}
		}

		public void AddRenderers(ICollection<Renderer> renderers, MonoBehaviour source)
		{
			foreach (Renderer renderer in renderers)
			{
				AddRenderer(renderer, source);
			}
		}

		public void SetAllRenderersMuted(bool isMuted)
		{
			foreach (string key in _isMutedStatus.Keys)
			{
				_isMutedStatus[key] = isMuted;
				if (!_registeredRenderers.TryGetValue(key, out var value))
				{
					continue;
				}
				foreach (Renderer item in value)
				{
					item.enabled = !isMuted;
				}
			}
		}

		public void SetRendersWithNameMuted(string name, bool isMuted)
		{
			if (!_isMutedStatus.ContainsKey(name))
			{
				return;
			}
			_isMutedStatus[name] = isMuted;
			if (!_registeredRenderers.TryGetValue(name, out var value))
			{
				return;
			}
			foreach (Renderer item in value)
			{
				item.enabled = !isMuted;
			}
		}
	}
}
