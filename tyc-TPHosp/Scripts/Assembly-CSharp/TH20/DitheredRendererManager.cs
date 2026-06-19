using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class DitheredRendererManager
	{
		private static DitheredRendererManager _instance;

		private readonly List<Renderer> _renderers = new List<Renderer>();

		public static DitheredRendererManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DitheredRendererManager();
				}
				return _instance;
			}
		}

		public List<Renderer> Renderers => _renderers;

		public static void Destroy()
		{
			_instance = null;
		}

		public void Register(Renderer renderer)
		{
			_renderers.AddUnique(renderer);
		}

		public void Unregister(Renderer renderer)
		{
			_renderers.Remove(renderer);
		}
	}
}
