using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public sealed class TouchController : CustomController
	{
		[SerializeField]
		[CustomObfuscation]
		private bool _disableMouseInputWhenEnabled;

		[CustomObfuscation]
		[SerializeField]
		private bool _useCustomController;

		[NonSerialized]
		private bool _originalMouseState;

		public bool disableMouseInputWhenEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useCustomController
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[CustomObfuscation]
		private TouchController()
		{
		}

		[CustomObfuscation]
		internal override void OnDisable()
		{
		}

		internal override bool vTErMpFqqbrJIuisyHNZEKHQiIJk()
		{
			return false;
		}

		[CustomObfuscation]
		internal override bool GetUseCustomController()
		{
			return false;
		}

		[CustomObfuscation]
		internal override void SetUseCustomController(bool value)
		{
		}

		private void SetMouseState(bool restoreOriginal)
		{
		}

		private void OnSetProperty()
		{
		}

		private bool CheckIsRewiredReady()
		{
			return false;
		}
	}
}
