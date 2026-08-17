using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI;

public class IngameStatsPanel : MonoBehaviour
{
	private List<StatItemUI> _StatObjects;

	private SignalBus _signalBus;

	private GameSessionData _session;

	private DataManager _dataManager;

	private bool _hasInitialized;

	private List<TextMeshProUGUI> _statTextLines;

	private void Construct(SignalBus signalBus, GameSessionData session, DataManager data)
	{
		_session = session;
		_signalBus = signalBus;
		_dataManager = data;
	}

	public unsafe void OnEnable()
	{
		//IL_0f0b: Expected I4, but got I8
		//IL_02a5: Expected O, but got I4
		//IL_02ad: Expected O, but got Ref
		//IL_010e: Expected O, but got Ref
		GameSessionData session = _session;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = session._activeCharacter;
		if ((object)session._activeCharacter == null || ((UnityEngine.Object)activeCharacter).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (!_hasInitialized)
		{
			Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
			List<TextMeshProUGUI> statTextLines = _statTextLines;
			int version = statTextLines._version + 1;
			statTextLines._version = version;
			statTextLines._size = 0;
			if (statTextLines._size > 0)
			{
				Array.Clear(statTextLines._items, 0, statTextLines._size);
			}
			List<StatItemUI>.Enumerator enumerator = default(List<StatItemUI>.Enumerator);
			if (enumerator.MoveNext())
			{
				StatItemUI statItemUI = null;
				List<StatItemUI>.Enumerator enumerator2 = (List<StatItemUI>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			_hasInitialized = true;
		}
		GameSessionData session2 = _session;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = session2._activeCharacter;
		PlayerModifierStats playerStats = activeCharacter2._playerStats;
		List<StatItemUI>.Enumerator enumerator3 = default(List<StatItemUI>.Enumerator);
		if (enumerator3.MoveNext())
		{
			object obj = 0;
			List<StatItemUI>.Enumerator enumerator4 = (List<StatItemUI>.Enumerator)(&enumerator3);
			throw new NullReferenceException();
		}
		TextAutoSizeHelper.UpdateTextSizes(_statTextLines, -1);
	}

	public IngameStatsPanel()
	{
		List<StatItemUI> statObjects = new List<StatItemUI>();
		_StatObjects = statObjects;
		List<TextMeshProUGUI> statTextLines = new List<TextMeshProUGUI>();
		_statTextLines = statTextLines;
	}
}
