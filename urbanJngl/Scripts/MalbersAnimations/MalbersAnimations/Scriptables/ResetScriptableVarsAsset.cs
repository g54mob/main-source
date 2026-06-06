using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Collections/Scriptable Variables Set", order = 1000)]
	public class ResetScriptableVarsAsset : ScriptableObject
	{
		public List<ScriptableVarReseter> vars;

		public virtual void Restart()
		{
			foreach (ScriptableVarReseter var in vars)
			{
				var.ResetVar();
			}
		}
	}
}
