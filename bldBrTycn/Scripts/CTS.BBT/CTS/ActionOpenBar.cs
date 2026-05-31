using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionOpenBar : InstantAction
	{
		[SerializeField]
		private bool _open = true;

		protected override bool PlayAction(ActionSequence sequence)
		{
			CTSSingleton<LevelParameters>.Instance.SetOpened(_open);
			return true;
		}
	}
}
