using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class OutlineRendererCollection : RendererCollection
	{
		private readonly List<EOutline> _activeOutlines = new List<EOutline>();

		public override void SetRenderer(Renderer rend)
		{
			Outlines outInstance = null;
			if (_activeOutlines.Count > 0 && MonoSingleton<Outlines>.TryGetInstance(out outInstance))
			{
				foreach (EOutline activeOutline in _activeOutlines)
				{
					outInstance.Data[activeOutline].Remove(rendererList);
				}
			}
			base.SetRenderer(rend);
			if (_activeOutlines.Count <= 0 || !outInstance)
			{
				return;
			}
			foreach (EOutline activeOutline2 in _activeOutlines)
			{
				outInstance.Data[activeOutline2].Add(rendererList);
			}
		}

		public override void SetRenderers(IEnumerable<Renderer> renderers)
		{
			Outlines outInstance = null;
			if (_activeOutlines.Count > 0 && MonoSingleton<Outlines>.TryGetInstance(out outInstance))
			{
				foreach (EOutline activeOutline in _activeOutlines)
				{
					outInstance.Data[activeOutline].Remove(rendererList);
				}
			}
			base.SetRenderers(renderers);
			if (_activeOutlines.Count <= 0 || !outInstance)
			{
				return;
			}
			foreach (EOutline activeOutline2 in _activeOutlines)
			{
				outInstance.Data[activeOutline2].Add(rendererList);
			}
		}

		public override void AddRenderer(Renderer rend)
		{
			if (_activeOutlines.Count > 0 && MonoSingleton<Outlines>.TryGetInstance(out var outInstance))
			{
				foreach (EOutline activeOutline in _activeOutlines)
				{
					outInstance.Data[activeOutline].Add(rend);
				}
			}
			base.AddRenderer(rend);
		}

		public override void RemoveRenderer(Renderer rend)
		{
			if (_activeOutlines.Count > 0 && MonoSingleton<Outlines>.TryGetInstance(out var outInstance))
			{
				foreach (EOutline activeOutline in _activeOutlines)
				{
					outInstance.Data[activeOutline].Remove(rend);
				}
			}
			base.RemoveRenderer(rend);
		}

		public override void AddRenderers(IList<Renderer> renderers)
		{
			if (_activeOutlines.Count > 0 && MonoSingleton<Outlines>.TryGetInstance(out var outInstance))
			{
				foreach (EOutline activeOutline in _activeOutlines)
				{
					outInstance.Data[activeOutline].Add(renderers);
				}
			}
			base.AddRenderers(renderers);
		}

		public override void RemoveRenderers(IList<Renderer> renderers)
		{
			if (_activeOutlines.Count > 0 && MonoSingleton<Outlines>.TryGetInstance(out var outInstance))
			{
				foreach (EOutline activeOutline in _activeOutlines)
				{
					outInstance.Data[activeOutline].Remove(renderers);
				}
			}
			base.RemoveRenderers(renderers);
		}

		public void SetOutlineActive(EOutline outline, bool active)
		{
			if (active)
			{
				EnableOutline(outline);
			}
			else
			{
				DisableOutline(outline);
			}
		}

		public void EnableOutline(EOutline outline)
		{
			if (!_activeOutlines.Contains(outline))
			{
				_activeOutlines.Add(outline);
				if (MonoSingleton<Outlines>.TryGetInstance(out var outInstance))
				{
					outInstance.Data[outline].Add(rendererList);
				}
			}
		}

		public void DisableOutline(EOutline outline)
		{
			if (_activeOutlines.Contains(outline))
			{
				_activeOutlines.Remove(outline);
				if (MonoSingleton<Outlines>.TryGetInstance(out var outInstance))
				{
					outInstance.Data[outline].Remove(rendererList);
				}
			}
		}

		protected override void OnDisabled()
		{
			for (int num = _activeOutlines.Count - 1; num >= 0; num--)
			{
				DisableOutline(_activeOutlines[num]);
			}
			base.OnDisabled();
		}
	}
}
