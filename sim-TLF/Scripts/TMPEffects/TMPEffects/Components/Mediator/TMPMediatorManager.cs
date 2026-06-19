using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TMPEffects.Components.Mediator
{
	internal static class TMPMediatorManager
	{
		public static Dictionary<GameObject, (TMPMediator, List<object>)> mediators = new Dictionary<GameObject, (TMPMediator, List<object>)>();

		public static void Subscribe(TMP_Text text, object obj)
		{
			if (!mediators.ContainsKey(text.gameObject))
			{
				TMPMediator item = new TMPMediator(text);
				List<object> item2 = new List<object> { obj };
				mediators.Add(text.gameObject, (item, item2));
			}
			else
			{
				List<object> item2 = mediators[text.gameObject].Item2;
				if (!item2.Contains(obj))
				{
					item2.Add(obj);
				}
			}
		}

		public static void Unsubscribe(TMP_Text text, object obj)
		{
			if (mediators.TryGetValue(text.gameObject, out var value))
			{
				value.Item2.Remove(obj);
				if (value.Item2.Count == 0)
				{
					mediators.Remove(text.gameObject);
					value.Item1.Dispose();
				}
			}
		}

		public static TMPMediator GetMediator(TMP_Text text)
		{
			return mediators[text.gameObject].Item1;
		}

		public static bool TryGetMediator(TMP_Text text, out TMPMediator mediator)
		{
			mediator = null;
			if (!mediators.TryGetValue(text.gameObject, out var value))
			{
				return false;
			}
			(mediator, _) = value;
			return true;
		}
	}
}
