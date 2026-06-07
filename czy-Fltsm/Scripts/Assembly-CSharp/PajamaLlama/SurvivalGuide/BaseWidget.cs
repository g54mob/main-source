using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	public abstract class BaseWidget : MonoBehaviour
	{
		internal abstract class BaseParameters
		{
		}

		public string ID = "";

		internal abstract void Initialize(BaseParameters parameters);

		internal abstract BaseParameters CreateParameters(Dictionary<string, object> parameters);

		internal bool Equals(string id)
		{
			return ID.Equals(id, StringComparison.OrdinalIgnoreCase);
		}
	}
}
