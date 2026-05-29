using System;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public interface ISelectable : ILockable
	{
		Component Component { get; }

		Transform Transform { get; }

		ESelectionState CurrentState { get; }

		event Action<ESelectionState> SelectionStateChanged;

		event Action Pressed;
	}
}
