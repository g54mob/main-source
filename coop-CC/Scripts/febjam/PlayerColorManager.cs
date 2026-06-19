using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

public class PlayerColorManager : EntityBehaviourBase
{
	private static int MAINCOLORID = Shader.PropertyToID("_MainColor");

	private static int NICKFLASHID = Shader.PropertyToID("_nickFlash");

	private static int FLASHINGID = Shader.PropertyToID("_flashing");

	public List<ColorChoice> playerColors;

	public List<ColorChoice> playerUIColors;

	public List<Renderer> playerRendersToUpdate;

	public List<Renderer> vehicleRendersToUpdate;

	public int activePlayerColorIndex;

	private float _flash;

	public PlayerColorManagerNetwork playerColorManagerNetwork;

	public Color currentColor => playerColors[activePlayerColorIndex].color;

	protected override void OnEntityCreated()
	{
		if (!GameUtil.isReady)
		{
			activePlayerColorIndex = SaveManager.data.GetColorIndex();
		}
	}

	public Color GetPlayerColor(bool ui)
	{
		if (!ui)
		{
			return playerColors[activePlayerColorIndex].color;
		}
		return playerUIColors[activePlayerColorIndex].color;
	}

	protected override void OnUpdatePresentation()
	{
		if ((object)playerColorManagerNetwork != null)
		{
			activePlayerColorIndex = playerColorManagerNetwork.activePlayerColorIndex;
		}
		UpdateRenderers();
	}

	public void UpdateRenderers()
	{
		Color color = playerColors[activePlayerColorIndex].color;
		if (_flash > 0f)
		{
			_flash -= Time.deltaTime * 4f;
			_flash = Mathf.Clamp01(_flash);
		}
		foreach (Renderer item in playerRendersToUpdate)
		{
			item.SetPropertyBlockColor(MAINCOLORID, color);
			item.SetPropertyBlockFloat(NICKFLASHID, _flash);
			if (base.entity.TryGetObject<PlayerStress>(out var obj))
			{
				item.SetPropertyBlockFloat(FLASHINGID, obj.syncInvulnerable ? 1f : 0f);
			}
		}
		foreach (Renderer item2 in vehicleRendersToUpdate)
		{
			item2.SetPropertyBlockColor(MAINCOLORID, color);
			item2.SetPropertyBlockFloat(NICKFLASHID, _flash);
			if (base.entity.TryGetObject<PlayerStress>(out var obj2))
			{
				item2.SetPropertyBlockFloat(FLASHINGID, obj2.syncInvulnerable ? 1f : 0f);
			}
		}
	}

	public void Flash()
	{
		_flash = 1f;
	}
}
