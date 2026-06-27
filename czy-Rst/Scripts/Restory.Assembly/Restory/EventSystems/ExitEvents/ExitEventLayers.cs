using System.Collections.Generic;
using UnityEngine;

namespace Restory.EventSystems.ExitEvents
{
	public class ExitEventLayers
	{
		private class Layer
		{
			private readonly List<IExitEventHandler> items = new List<IExitEventHandler>();

			public void Add(IExitEventHandler exitHandler)
			{
				items.Add(exitHandler);
			}

			public bool TryTakeLast(out IExitEventHandler lastItem)
			{
				if (items.Count == 0)
				{
					lastItem = null;
					return false;
				}
				List<IExitEventHandler> list = items;
				lastItem = list[list.Count - 1];
				items.RemoveAt(items.Count - 1);
				return true;
			}

			public bool TryRemove(IExitEventHandler exitHandler)
			{
				return items.Remove(exitHandler);
			}
		}

		private readonly List<Layer> layers = new List<Layer>();

		public void AddHandler(IExitEventHandler handler, int layerOrder)
		{
			GetOrCreateLayer(layerOrder).Add(handler);
		}

		public void RemoveHandler(IExitEventHandler handler, int layerOrder)
		{
			if (!layers[layerOrder].TryRemove(handler))
			{
				Debug.LogError("Failed to find and remove handler " + handler.ID + " from layers");
			}
		}

		public bool TryTakeLastHandler(out IExitEventHandler lastHandler)
		{
			for (int num = layers.Count - 1; num >= 0; num--)
			{
				if (layers[num].TryTakeLast(out lastHandler))
				{
					return true;
				}
			}
			lastHandler = null;
			return false;
		}

		private Layer GetOrCreateLayer(int layerOrder)
		{
			if (layerOrder >= layers.Count)
			{
				for (int i = layers.Count; i <= layerOrder; i++)
				{
					layers.Add(new Layer());
				}
			}
			return layers[layerOrder];
		}
	}
}
