using System;
using System.Collections.Generic;
using ClockStone;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class Totem : UnitManager
{
	private class ClonePack : IClonePack
	{
		private Dictionary<int, int> ammoWares;

		public ClonePack(Dictionary<int, int> ammoWares)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	private class Beam
	{
		public GameObject beam;

		public GameObject beamStart;

		public GameObject beamEnd;

		public bool fired;

		public bool destroyed;

		public void Destroy()
		{
		}
	}

	public GameObject spinner;

	public GameObject shieldCyl;

	public GameObject monolith;

	private float MIN_SPINNER_HEIGHT;

	private float MAX_SPINNER_HEIGHT;

	private float SPINNER_ROTATE_X;

	private float SPINNER_ROTATE_Y;

	private float SPINNER_ROTATE_Z;

	private AudioObject firingSound;

	private bool _totemComplete;

	private bool ignoreMVerse;

	private static int FIRE_TIME;

	private int hideCounter;

	private int dropShieldTime;

	private int fireTime;

	[NonSerialized]
	public bool firedComplete;

	private bool fired;

	private Beam beam;

	[NonSerialized]
	public bool shieldActivated;

	public bool totemComplete
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override bool unitEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override bool armed
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void SendMVerseData()
	{
	}

	public void ReceiveMVerseData(bool val, float ammo, bool unitEnabled, bool unitArmed)
	{
	}

	private float GetTotemAmmo()
	{
		return 0f;
	}

	private void SetTotemAmmo(float amt)
	{
	}

	public override void ApplyPacket(Packet pm)
	{
	}

	private void SetTotemComplete(bool val)
	{
	}

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public override void Start()
	{
	}

	public void ResetTotem()
	{
	}

	public override void Update()
	{
	}

	private void SetSpinnerPosition(float p)
	{
	}

	public override void GameUpdate()
	{
	}

	private void HandleSound()
	{
	}

	private void UpdateShieldState()
	{
	}

	public void FireBeam()
	{
	}

	private void FireAtRift(Vector3 dp)
	{
	}

	public void ActivateShield(bool value)
	{
	}

	public override void DamageShield()
	{
	}

	private float GetPercentComplete()
	{
		return 0f;
	}

	private void SetDefaultWares()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override void ReadDataLate()
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
