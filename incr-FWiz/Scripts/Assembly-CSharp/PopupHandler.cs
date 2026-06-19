using System.Collections.Generic;
using UnityEngine;

public class PopupHandler : MonoBehaviour
{
	[SerializeField]
	private Transform _popupsParent;

	[SerializeField]
	private List<Popup> _popupPrefabs;

	private Stack<Popup> _activePopups;

	private bool _isLockingPlayerActions;

	private bool _isBlankingPlayerActions;

	private bool _shown;

	public static PopupHandler Instance { get; private set; }

	public bool Shown => false;

	public void Initiate()
	{
	}

	public void ShowPopup(object obj, Transform tooltipParent = null)
	{
	}

	public void EndDominantPopup()
	{
	}

	public void SetShown()
	{
	}
}
