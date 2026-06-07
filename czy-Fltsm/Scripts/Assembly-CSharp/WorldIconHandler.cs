using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldIconHandler : WorldInteractable, IUpdateManagerUpdateTarget
{
	[SerializeField]
	private ChildOffsetter _childOffsetter;

	[SerializeField]
	[Tooltip("Prefab used for displaying icons in-game, for example above a characters head.")]
	private WorldIcon _iconPrefab;

	private List<WorldIcon> _icons = new List<WorldIcon>();

	private bool _isRegisteredToUpdateManager;

	public void UpdateManager_Update(float deltaTime, int frame)
	{
		if (HasActiveOverlay())
		{
			ScaleToCamera();
			FaceCamera();
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		UnregisterFromUpdateManager();
	}

	public void ClearAllIcons()
	{
		foreach (WorldIcon icon in _icons)
		{
			if ((bool)icon)
			{
				icon.gameObject.SetActive(value: false);
			}
		}
		UnregisterFromUpdateManager();
	}

	public void AddIcon(IconProperties properties)
	{
		GetIcon(properties).Initialize(properties);
		if (_childOffsetter != null)
		{
			_childOffsetter.UpdateChildren();
		}
		RegisterToUpdateManager();
	}

	public void AddIcon(PlaceableAlertProperties malfunction)
	{
		if (malfunction.WorldIconProperties == null)
		{
			Debug.LogException(new Exception("Unable to add world icon for malfunction '" + malfunction.name + "', because it is NULL!"));
		}
		else
		{
			AddIcon(malfunction.WorldIconProperties);
		}
	}

	public void RemoveIcon(IconProperties properties)
	{
		foreach (WorldIcon icon in _icons)
		{
			if ((bool)icon && icon.Properties == properties && (bool)icon.gameObject && icon.gameObject.activeSelf)
			{
				icon.gameObject.SetActive(value: false);
				if ((bool)_childOffsetter)
				{
					_childOffsetter.UpdateChildren();
				}
				if (!HasActiveIcons())
				{
					UnregisterFromUpdateManager();
				}
				break;
			}
		}
	}

	private WorldIcon GetIcon(IconProperties iconProperties)
	{
		WorldIcon worldIcon = null;
		int count = _icons.Count;
		while (0 < count--)
		{
			WorldIcon worldIcon2 = _icons[count];
			if (worldIcon2 == null || worldIcon2.gameObject == null)
			{
				_icons.RemoveAt(count);
				continue;
			}
			if (worldIcon2.Properties == iconProperties)
			{
				return worldIcon2;
			}
			if (worldIcon == null && !worldIcon2.gameObject.activeSelf)
			{
				worldIcon = worldIcon2;
			}
		}
		if (worldIcon == null)
		{
			worldIcon = UnityEngine.Object.Instantiate(_iconPrefab, base.transform);
			_icons.Add(worldIcon);
		}
		return worldIcon;
	}

	private void RegisterToUpdateManager()
	{
		if (!_isRegisteredToUpdateManager)
		{
			GameManager.UpdateManager.RegisterUpdateTarget(this);
			_isRegisteredToUpdateManager = true;
		}
	}

	private void UnregisterFromUpdateManager()
	{
		if (_isRegisteredToUpdateManager)
		{
			GameManager.UpdateManager.UnregisterUpdateTarget(this);
			_isRegisteredToUpdateManager = false;
		}
	}

	private bool HasActiveIcons()
	{
		foreach (WorldIcon icon in _icons)
		{
			if ((bool)icon && (bool)icon.gameObject && icon.gameObject.activeSelf)
			{
				return true;
			}
		}
		return false;
	}
}
