using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProceedUI : EntityBehaviourBase
{
	public Image proceedProgressFill;

	public GameObject pressNotice;

	public GameObject readyIndicator;

	public List<GameObject> playerParents;

	public List<Image> playerIcons;

	public Sprite playerHere;

	public Sprite playerGone;

	public EaseUI easeUI;

	private List<PlayersManager.PlayerProceed> _playerProceeds = new List<PlayersManager.PlayerProceed>();

	private bool _active;

	public void Show()
	{
		_active = true;
		easeUI.EaseIn();
	}

	public void Hide()
	{
		if (_active)
		{
			_active = false;
			easeUI.EaseOut();
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (_active)
		{
			pressNotice.SetActive(!NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding());
			readyIndicator.SetActive(NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding());
			_playerProceeds.Clear();
			NetworkAggroManagerBase<PlayersManager>.instance.GetAllPlayerProceeds(_playerProceeds);
			for (int i = 0; i < _playerProceeds.Count; i++)
			{
				PlayerColorManager playerColorManager = _playerProceeds[i].player.GetObject<PlayerColorManager>();
				playerIcons[i].color = playerColorManager.GetPlayerColor(ui: true);
			}
			for (int j = 0; j < playerIcons.Count; j++)
			{
				playerParents[j].SetActive(j < _playerProceeds.Count);
			}
			for (int k = 0; k < _playerProceeds.Count; k++)
			{
				playerIcons[k].sprite = (_playerProceeds[k].isProceeding ? playerHere : playerGone);
			}
			proceedProgressFill.fillAmount = math.remap(0f, 1f, 0.1f, 0.9f, NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue());
		}
	}
}
