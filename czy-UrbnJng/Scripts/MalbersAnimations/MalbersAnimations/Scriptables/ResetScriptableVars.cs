using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Variables/Reset Scriptable Vars")]
	public class ResetScriptableVars : MonoBehaviour
	{
		public bool ResetOnEnable = true;

		public bool ResetOnDisable;

		public List<ScriptableVarReseter> vars;

		private void OnEnable()
		{
			if (ResetOnEnable)
			{
				ResetVars();
			}
		}

		private void OnDisable()
		{
			if (ResetOnDisable)
			{
				ResetVars();
			}
		}

		public virtual void ResetVars()
		{
			foreach (ScriptableVarReseter var in vars)
			{
				var.ResetVar();
			}
		}
	}
}
