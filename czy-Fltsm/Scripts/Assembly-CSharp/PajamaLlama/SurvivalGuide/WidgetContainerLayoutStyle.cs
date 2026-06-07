using System;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	[Serializable]
	public class WidgetContainerLayoutStyle
	{
		public string ID;

		public GameObject Prefab;

		internal bool Equals(string id)
		{
			return ID.Equals(id, StringComparison.OrdinalIgnoreCase);
		}
	}
}
