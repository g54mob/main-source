using System.Collections.Generic;
using UnityEngine;

namespace JUTPS.InputEvents
{
	public class CustomInputEvents : MonoBehaviour
	{
		[Header("Actions")]
		public List<InputEvent> Actions = new List<InputEvent>();

		private void OnEnable()
		{
			foreach (InputEvent action in Actions)
			{
				action.SetupListeners();
			}
		}

		private void OnDisable()
		{
			foreach (InputEvent action in Actions)
			{
				action.RemoveListeners();
			}
		}
	}
}
