using Battle;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public class ScoreSetting : ScriptableObject
	{
		[Label("アセンションボーナス")]
		public float ascesionIncrease;

		private void OnValidate()
		{
		}
	}
}
