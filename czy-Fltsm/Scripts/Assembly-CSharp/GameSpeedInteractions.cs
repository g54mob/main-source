using System;
using UnityEngine;

public class GameSpeedInteractions : MonoBehaviour
{
	[Serializable]
	private struct GameSpeedInteractable
	{
		public GameSpeed GameSpeed;

		public UIInteractable Interactable;
	}

	[SerializeField]
	private GameSpeedInteractable[] _gameSpeedInteractables;

	public void Decrease()
	{
		if (TryGetCurrentIndex(out var i))
		{
			_gameSpeedInteractables.GetValueClamped(--i).Interactable.Interact();
		}
	}

	public void Increase()
	{
		if (TryGetCurrentIndex(out var i))
		{
			_gameSpeedInteractables.GetValueClamped(++i).Interactable.Interact();
		}
	}

	private bool TryGetCurrentIndex(out int i)
	{
		for (i = 0; i < _gameSpeedInteractables.Length; i++)
		{
			if (_gameSpeedInteractables[i].GameSpeed == GameSpeedManager.GameSpeed)
			{
				return true;
			}
		}
		return false;
	}
}
