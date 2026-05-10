using System;
using UnityEngine;

namespace CTS.UI
{
	public abstract class SelectableSwapData<T> : ScriptableObject where T : UnityEngine.Object
	{
		public void ApplyTo(T obj, ESelectionState selectionState)
		{
			try
			{
				OnAppliedTo(obj, selectionState);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected abstract void OnAppliedTo(T obj, ESelectionState selectionState);
	}
}
