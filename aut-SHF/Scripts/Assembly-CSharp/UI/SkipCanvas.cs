using System;
using UnityEngine;

namespace UI
{
	public class SkipCanvas : MonoBehaviour
	{
		public Action SkipAction;

		private InputActionController _input;

		private bool _waitSkip;

		private void Update()
		{
		}

		public void StartWaitSkip(Action skipAction)
		{
		}

		public void FinishWaitSkip()
		{
		}
	}
}
