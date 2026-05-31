using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class OutlineData
	{
		[field: SerializeField]
		public bool Enabled { get; private set; } = true;

		[field: SerializeField]
		[field: Range(0f, 0.2f)]
		public float PixelRadius { get; private set; } = 0.1f;

		[field: SerializeField]
		[field: ColorUsage(false, true)]
		public Color Color { get; private set; } = Color.white;

		[field: SerializeField]
		[field: ColorUsage(false, true)]
		public Color ColorEdge { get; private set; } = Color.black;

		[field: SerializeField]
		[field: Range(0.01f, 10f)]
		public float ColorPower { get; private set; } = 1f;

		[field: SerializeField]
		[field: Range(0f, 1f)]
		public float Smoothness { get; private set; } = 1f;

		[field: SerializeField]
		[field: Range(0.01f, 10f)]
		public float Power { get; private set; } = 1f;

		public HashSet<Renderer> Renderers { get; } = new HashSet<Renderer>();

		public void Add(Renderer p_renderer)
		{
			Remove(p_renderer);
			Renderers.Add(p_renderer);
		}

		public void Remove(Renderer p_renderer)
		{
			Renderers.Remove(p_renderer);
		}

		public void Add(IEnumerable<Renderer> p_renderers)
		{
			foreach (Renderer p_renderer in p_renderers)
			{
				Add(p_renderer);
			}
		}

		public void Remove(IEnumerable<Renderer> p_renderers)
		{
			foreach (Renderer p_renderer in p_renderers)
			{
				Remove(p_renderer);
			}
		}
	}
}
