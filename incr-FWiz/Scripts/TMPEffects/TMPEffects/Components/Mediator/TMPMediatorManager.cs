using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TMPEffects.Components.Mediator
{
	internal static class TMPMediatorManager
	{
		public static Dictionary<GameObject, (TMPMediator, List<object>)> mediators;

		public static void Subscribe(TMP_Text text, object obj)
		{
		}

		public static void Unsubscribe(TMP_Text text, object obj)
		{
		}

		public static TMPMediator GetMediator(TMP_Text text)
		{
			return null;
		}

		public static bool TryGetMediator(TMP_Text text, out TMPMediator mediator)
		{
			mediator = null;
			return false;
		}
	}
}
