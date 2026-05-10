using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class RendererCollection : CTSBehaviour
	{
		[ContextMenuItem("Collect child renderers", "CollectChildRenderers")]
		[SerializeField]
		protected List<Renderer> rendererList = new List<Renderer>();

		private void CollectChildRenderers()
		{
			rendererList = GetComponentsInChildren<Renderer>().ToList();
		}

		public virtual void SetRenderer(Renderer rend)
		{
			rendererList.Clear();
			rendererList.Add(rend);
		}

		public virtual void SetRenderers(IEnumerable<Renderer> renderers)
		{
			rendererList.Clear();
			rendererList.AddRange(renderers);
		}

		public virtual void AddRenderer(Renderer rend)
		{
			if (!rendererList.Contains(rend))
			{
				rendererList.Add(rend);
			}
		}

		public virtual void RemoveRenderer(Renderer rend)
		{
			rendererList.Remove(rend);
		}

		public virtual void AddRenderers(IList<Renderer> renderers)
		{
			RemoveRenderers(renderers);
			rendererList.AddRange(renderers);
		}

		public virtual void RemoveRenderers(IList<Renderer> renderers)
		{
			foreach (Renderer renderer in renderers)
			{
				rendererList.Remove(renderer);
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			for (int num = rendererList.Count - 1; num >= 0; num--)
			{
				Renderer renderer = rendererList[num];
				if ((object)renderer == null)
				{
					rendererList.RemoveAt(num);
				}
				else if (renderer == null)
				{
					RemoveRenderer(renderer);
				}
			}
		}
	}
}
