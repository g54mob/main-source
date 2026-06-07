using System.Collections.Generic;
using UnityEngine;

namespace Gh
{
	public class DisableScriptsWhenEnabled : MonoBehaviour
	{
		public List<MonoBehaviour> scriptsDisabledOnEnable;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
