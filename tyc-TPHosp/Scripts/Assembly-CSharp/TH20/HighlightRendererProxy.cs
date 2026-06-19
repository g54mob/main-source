using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class HighlightRendererProxy
	{
		private static HighlightRendererProxy _instance;

		private readonly ResourceRequest _configResourceRequest;

		private HighlightRendererResources _resources;

		private float _alpha;

		private readonly List<Renderer> _renderers = new List<Renderer>();

		public static HighlightRendererProxy Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new HighlightRendererProxy();
				}
				return _instance;
			}
		}

		public HighlightRendererResources Resources
		{
			get
			{
				if (_resources == null && _configResourceRequest.isDone)
				{
					_resources = _configResourceRequest.asset as HighlightRendererResources;
				}
				return _resources;
			}
		}

		public float Alpha
		{
			get
			{
				return _alpha;
			}
			set
			{
				_alpha = Mathf.Clamp01(value);
			}
		}

		public static void Destroy()
		{
			_instance = null;
		}

		private HighlightRendererProxy()
		{
			_configResourceRequest = UnityEngine.Resources.LoadAsync<HighlightRendererResources>("Highlight Renderer Resources");
		}

		public void Clear()
		{
			_renderers.Clear();
			_alpha = 0f;
		}

		public void Register(Renderer gameObject)
		{
			_renderers.Add(gameObject);
		}

		public void Register(List<Renderer> renderers)
		{
			_renderers.AddRange(renderers);
		}

		public void Unregister(Renderer renderer)
		{
			_renderers.Remove(renderer);
		}

		public bool AreEqual(Renderer renderer)
		{
			if (_renderers.Count == 1)
			{
				return _renderers[0] == renderer;
			}
			return false;
		}

		public bool AreEqual(List<Renderer> renderers)
		{
			return _renderers.AreEqual(renderers);
		}

		public void GetRenderers(List<Renderer> renderers)
		{
			renderers.AddRange(_renderers);
		}
	}
}
