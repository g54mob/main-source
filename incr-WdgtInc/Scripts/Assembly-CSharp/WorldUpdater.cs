using System.Collections;
using System.Collections.Generic;
using Assets.Source.Player;
using Assets.Source.World;
using UnityEngine;

public class WorldUpdater : MonoBehaviour
{
	private float _autoUpgradeTimer;

	private void Start()
	{
	}

	private void Update()
	{
		if (GamePlayer.Current == null)
		{
			return;
		}
		GamePlayer.Current.Update(Time.deltaTime);
		WorldMap.Current.Update(Time.deltaTime);
		_autoUpgradeTimer -= Time.deltaTime;
		if (_autoUpgradeTimer < 0f)
		{
			_autoUpgradeTimer = GamePlayer.AutoUpgradeTime;
			if (GamePlayer.Current.DoAutoUpgrade && GamePlayer.Current.HasTech(GamePlayer.AutoUpgradeTech))
			{
				StartCoroutine(_doAutoUpgradeCycle());
			}
		}
	}

	private IEnumerator _doAutoUpgradeCycle()
	{
		List<WorldFrame> list = new List<WorldFrame>(WorldMap.Current.Frames);
		int perFrame = Mathf.CeilToInt((float)list.Count * Time.deltaTime / GamePlayer.AutoUpgradeTime);
		int count = 0;
		foreach (WorldFrame item in list)
		{
			if (!item.IsPlaced || item.Construction != null)
			{
				continue;
			}
			for (int i = 0; i < item.AutoWorkerMax; i++)
			{
				if (item.GetAutoWorker(i) == null && GamePlayer.Current.HasCost(item.GetAutoWorkerCost(), 4))
				{
					item.PurchaseAutoWorker(new WorldAnchor(WorldAnchorType.AutoWorker, i));
					yield break;
				}
			}
			foreach (FrameUpgrade availableUpgrade in item.GetAvailableUpgrades())
			{
				if (!item.HasUpgrade(availableUpgrade) && availableUpgrade.IsAvailable && item.GetUpgradeConstruction(availableUpgrade) == null && GamePlayer.Current.HasCost(availableUpgrade.GetCost(), 4))
				{
					item.PurchaseUpgrade(new WorldAnchor(WorldAnchorType.Upgrade, availableUpgrade.FrameOrdinal));
					yield break;
				}
			}
			count++;
			if (count == perFrame)
			{
				count = 0;
				yield return null;
			}
		}
	}
}
