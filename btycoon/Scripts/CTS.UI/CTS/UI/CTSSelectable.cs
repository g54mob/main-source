using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public static class CTSSelectable
	{
		private static readonly Dictionary<StringKey, ISelectable> _activeButtons = new Dictionary<StringKey, ISelectable>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitStatic()
		{
			_activeButtons.Clear();
		}

		public static void Add(StringKey key, ISelectable controller)
		{
			if (!_activeButtons.TryGetValue(key, out var value) || !value.Component)
			{
				_activeButtons[key] = controller;
			}
		}

		public static void Remove(StringKey key)
		{
			_activeButtons.Remove(key);
		}

		public static bool TryGet(StringKey key, out ISelectable controller)
		{
			return _activeButtons.TryGetValue(key, out controller);
		}

		public static bool TryGet<TSelectable>(StringKey key, out TSelectable outSelectable) where TSelectable : ISelectable
		{
			if (_activeButtons.TryGetValue(key, out var value) && value is TSelectable val)
			{
				outSelectable = val;
				return true;
			}
			outSelectable = default(TSelectable);
			return false;
		}
	}
}
