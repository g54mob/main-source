using System;
using I2.Loc;
using PajamaLlama.Flotsam.Morale;
using PajamaLlama.Fltsm;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Acid Gass Morale Effect")]
public class AcidGassMoraleEfect : MoraleEffect
{
	[Serializable]
	private struct ModifierDrifterCount
	{
		public int DrifterCount;

		public int Modifier;
	}

	[Serializable]
	public class PersistentData : BasePersistentData
	{
		public bool IsActive;

		public float Time;

		public PersistentData(AcidGassMoraleEfect effect)
			: base(effect)
		{
			IsActive = effect._isActive;
			Time = 0f;
		}
	}

	[Tooltip("The index indicates the morale penlaty, the value is the number of agents with the acid gass disease needed to trigger the morale penalty")]
	[SerializeField]
	private ModifierDrifterCount[] _modifierDrifterCounts;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	private Sprite _icon;

	private bool _isActive;

	private int _count;

	private int _modifier;

	public override void Initialize(Agent agent, MoraleEffect properties)
	{
		base.Initialize(agent, properties);
		GameEventDispatcher.AddListener(GameEventType.DiseasesUpdated, OnDiseaseUpdated);
		OnDiseaseUpdated();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.AddListener(GameEventType.DiseasesUpdated, OnDiseaseUpdated);
	}

	public new void Activate()
	{
		_isActive = true;
		base.Activate();
	}

	protected override void Deactivate()
	{
		_isActive = false;
		base.Deactivate();
	}

	public void OnEncounter(Agent agent)
	{
	}

	private void OnDiseaseUpdated(GameEvent gameEvent = null)
	{
		if (_agent.Community == null)
		{
			return;
		}
		_count = 0;
		foreach (Agent agent in _agent.Community.Agents)
		{
			Pollution pollution = agent.Vitals.Pollution;
			if (pollution.CurrentDisease is AcidGass && (pollution.CurrentDiseaseMedPod == null || pollution.CurrentDiseaseMedPod.OccupyingPatient != agent))
			{
				_count++;
			}
		}
		_modifier = 0;
		for (int i = 0; i < _modifierDrifterCounts.Length; i++)
		{
			ModifierDrifterCount modifierDrifterCount = _modifierDrifterCounts[i];
			if (modifierDrifterCount.DrifterCount > _count)
			{
				break;
			}
			_modifier = modifierDrifterCount.Modifier;
		}
		if (0 < _modifier)
		{
			if (!_isActive)
			{
				Activate();
			}
		}
		else if (_isActive)
		{
			Deactivate();
		}
	}

	public override bool IsActive()
	{
		return _isActive;
	}

	public override string ReturnDescription()
	{
		return _description;
	}

	public override int ReturnModifier()
	{
		return -_modifier;
	}

	public override BasePersistentData ReturnPersistentData()
	{
		return new PersistentData(this);
	}

	public override Sprite ReturnSprite()
	{
		return _icon;
	}

	public override bool TryReturnAttributeEffect(out DrifterAttributesEffect effect)
	{
		effect = null;
		return false;
	}

	public override void Restore(BasePersistentData persistentData)
	{
		OnDiseaseUpdated();
	}
}
