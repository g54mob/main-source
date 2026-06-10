using System;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[RequireComponent(typeof(Image))]
	[AddComponentMenu(null)]
	public class UIImageHelper : MonoBehaviour
	{
		[Serializable]
		private class State
		{
			[SerializeField]
			public Color color;

			public void Set(Image image)
			{
			}
		}

		[SerializeField]
		private State enabledState;

		[SerializeField]
		private State disabledState;

		private bool currentState;

		public void SetEnabledState(bool newState)
		{
		}

		public void SetEnabledStateColor(Color color)
		{
		}

		public void SetDisabledStateColor(Color color)
		{
		}

		public void Refresh()
		{
		}
	}
}
