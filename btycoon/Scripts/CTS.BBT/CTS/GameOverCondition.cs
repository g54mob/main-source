using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class GameOverCondition : MonoCondition
	{
		[SerializeField]
		private bool _validWhenGameOver;

		public override bool IsConditionValid()
		{
			if (_validWhenGameOver)
			{
				return GameOver.IsGameOver;
			}
			return !GameOver.IsGameOver;
		}
	}
}
