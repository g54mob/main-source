using System.Collections.Generic;
using Dissonance;
using UnityEngine;

public class PerPlayerVolumeUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private DissonanceComms comms;

	[SerializeField]
	private Transform listRoot;

	[SerializeField]
	private PerPlayerVolumeRow rowPrefab;

	private readonly Dictionary<string, PerPlayerVolumeRow> _rows = new Dictionary<string, PerPlayerVolumeRow>();

	private void Awake()
	{
		if (!comms)
		{
			comms = Object.FindObjectOfType<DissonanceComms>(includeInactive: true);
		}
	}

	private void OnEnable()
	{
		if (comms == null)
		{
			Debug.LogError("[PerPlayerVolumeUI] No DissonanceComms found.");
			base.enabled = false;
		}
		else
		{
			BuildInitial();
			comms.OnPlayerJoinedSession += OnPlayerJoined;
			comms.OnPlayerLeftSession += OnPlayerLeft;
		}
	}

	private void OnDisable()
	{
		if (comms != null)
		{
			comms.OnPlayerJoinedSession -= OnPlayerJoined;
			comms.OnPlayerLeftSession -= OnPlayerLeft;
		}
		foreach (KeyValuePair<string, PerPlayerVolumeRow> row in _rows)
		{
			if ((bool)row.Value)
			{
				Object.Destroy(row.Value.gameObject);
			}
		}
		_rows.Clear();
	}

	private void BuildInitial()
	{
		foreach (VoicePlayerState player in comms.Players)
		{
			if (!(player.Name == comms.LocalPlayerName))
			{
				AddRow(player);
			}
		}
	}

	private void OnPlayerJoined(VoicePlayerState player)
	{
		if (!(player.Name == comms.LocalPlayerName))
		{
			AddRow(player);
		}
	}

	private void OnPlayerLeft(VoicePlayerState player)
	{
		if (_rows.TryGetValue(player.Name, out var value) && value != null)
		{
			Object.Destroy(value.gameObject);
		}
		_rows.Remove(player.Name);
	}

	private void AddRow(VoicePlayerState player)
	{
		if (!_rows.ContainsKey(player.Name))
		{
			PerPlayerVolumeRow perPlayerVolumeRow = Object.Instantiate(rowPrefab, listRoot);
			perPlayerVolumeRow.Init(player);
			_rows[player.Name] = perPlayerVolumeRow;
		}
	}
}
