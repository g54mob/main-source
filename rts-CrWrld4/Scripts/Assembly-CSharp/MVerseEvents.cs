using System.Collections.Generic;
using UnityEngine;

public class MVerseEvents
{
	public struct FrameEvent
	{
		[SerializeField]
		public byte frameRate;

		[SerializeField]
		public float distributeEnergy;

		[SerializeField]
		public float distributeAC;

		[SerializeField]
		public float distributeArg;

		[SerializeField]
		public float distributeLiftic;

		public FrameEvent(byte frameRate, float distributeEnergy, float distributeAC, float distributeArg, float distributeLiftic)
		{
			this.frameRate = 0;
			this.distributeEnergy = 0f;
			this.distributeAC = 0f;
			this.distributeArg = 0f;
			this.distributeLiftic = 0f;
		}
	}

	public struct DamageDigitalisEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public int amt;

		[SerializeField]
		public short r;

		public DamageDigitalisEvent(short cellX, short cellY, int amt, short r)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.amt = 0;
			this.r = 0;
		}
	}

	public struct DamageCreeperEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public int count;

		[SerializeField]
		public int maxDist;

		[SerializeField]
		public int amt;

		[SerializeField]
		public bool followTerrain;

		public DamageCreeperEvent(short cellX, short cellY, int count, int maxDist, int amt, bool followTerrain)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.count = 0;
			this.maxDist = 0;
			this.amt = 0;
			this.followTerrain = false;
		}
	}

	public struct AddCreeperEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public int amt;

		[SerializeField]
		public bool allowCrossOver;

		[SerializeField]
		public bool zeroExisting;

		[SerializeField]
		public bool includeCrystal;

		[SerializeField]
		public bool progressive;

		public AddCreeperEvent(short cellX, short cellY, int amt, bool allowCrossOver, bool zeroExisting, bool includeCrystal, bool progressive)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.amt = 0;
			this.allowCrossOver = false;
			this.zeroExisting = false;
			this.includeCrystal = false;
			this.progressive = false;
		}
	}

	public struct Add2CreeperEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public long amt;

		[SerializeField]
		public long cap;

		public Add2CreeperEvent(short cellX, short cellY, long amt, long cap)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.amt = 0L;
			this.cap = 0L;
		}
	}

	public struct Add3CreeperEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public int amt;

		public Add3CreeperEvent(short cellX, short cellY, int amt)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.amt = 0;
		}
	}

	public struct SetCreeperEvent
	{
		[SerializeField]
		public int amt;

		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public bool dontlower;

		public SetCreeperEvent(int amt, short cellX, short cellY, bool dontlower)
		{
			this.amt = 0;
			this.cellX = 0;
			this.cellY = 0;
			this.dontlower = false;
		}
	}

	public struct SetCreeperStainEvent
	{
		[SerializeField]
		public int amt;

		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		public SetCreeperStainEvent(int amt, short cellX, short cellY)
		{
			this.amt = 0;
			this.cellX = 0;
			this.cellY = 0;
		}
	}

	public struct ApplyRunningCreeperEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public int val;

		[SerializeField]
		public int weight;

		[SerializeField]
		public bool onlyLower;

		public ApplyRunningCreeperEvent(short cellX, short cellY, int val, int weight, bool onlyLower)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.val = 0;
			this.weight = 0;
			this.onlyLower = false;
		}
	}

	public struct SetTerrainEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public byte height;

		[SerializeField]
		public bool notifyUnits;

		public SetTerrainEvent(short cellX, short cellY, byte height, bool notifyUnits)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.height = 0;
			this.notifyUnits = false;
		}
	}

	public struct TerraformAddIndicatorEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public byte height;

		[SerializeField]
		public bool allowVoid;

		public TerraformAddIndicatorEvent(short cellX, short cellY, byte height, bool allowVoid)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.height = 0;
			this.allowVoid = false;
		}
	}

	public struct TerraformRemoveIndicatorEvent
	{
		[SerializeField]
		public short cellX;

		[SerializeField]
		public short cellY;

		[SerializeField]
		public bool allowVoid;

		public TerraformRemoveIndicatorEvent(short cellX, short cellY, bool allowVoid)
		{
			this.cellX = 0;
			this.cellY = 0;
			this.allowVoid = false;
		}
	}

	private List<DamageDigitalisEvent> damageDigitalisEvents;

	private List<DamageCreeperEvent> damageCreeperEvents;

	private List<AddCreeperEvent> addCreeperEvents;

	private List<Add2CreeperEvent> add2CreeperEvents;

	private List<Add3CreeperEvent> add3CreeperEvents;

	private List<SetCreeperEvent> setCreeperEvents;

	private List<SetCreeperStainEvent> setCreeperStainEvents;

	private List<ApplyRunningCreeperEvent> applyRunningCreeperEvents;

	private List<SetTerrainEvent> setTerrainEvents;

	private List<TerraformAddIndicatorEvent> terraformAddIndicatorEvents;

	private List<TerraformRemoveIndicatorEvent> terraformRemoveIndicatorEvents;

	private float timeSinceLastSend;

	private float MAX_TIME;

	private int MAX_EVENTS;

	public void AddAddCreeperEvent(short cellX, short cellY, int amt, bool allowCrossOver, bool zeroExisting, bool includeCrystal, bool progressive)
	{
	}

	public void AddAdd2CreeperEvent(short cellX, short cellY, long amt, long cap)
	{
	}

	public void AddAdd3CreeperEvent(short cellX, short cellY, int amt)
	{
	}

	public void AddDamageDigitalisEvent(short cellX, short cellY, int amt, short r)
	{
	}

	public void AddDamageCreeperEvent(short cellX, short cellY, int count, int maxDist, int amt, bool followTerrain)
	{
	}

	public void AddSetCreeperEvent(int amt, short cellX, short cellY, bool dontlower)
	{
	}

	public void AddSetCreeperStainEvent(int amt, short cellX, short cellY)
	{
	}

	public void AddApplyRunningCreeperEvent(short cellX, short cellY, int val, int weight, bool onlyLower)
	{
	}

	public void AddSetTerrainEvent(short cellX, short cellY, byte height, bool notifyUnits)
	{
	}

	public void AddTerraformAddIndicatorEvent(short cellX, short cellY, byte height, bool allowVoid)
	{
	}

	public void AddTerraformRemoveIndicatorEvent(short cellX, short cellY, bool allowVoid)
	{
	}

	private void SendAddCreeperEvents()
	{
	}

	private void SendAdd2CreeperEvents()
	{
	}

	private void SendAdd3CreeperEvents()
	{
	}

	private void SendDamageDigitalisEvents()
	{
	}

	private void SendDamageCreeperEvents()
	{
	}

	private void SendSetCreeperEvents()
	{
	}

	private void SendSetCreeperStainEvents()
	{
	}

	private void SendApplyRunningCreeperEvents()
	{
	}

	private void SendSetTerrainEvents()
	{
	}

	private void SendTerraformAddIndicatorEvents()
	{
	}

	private void SendTerraformRemoveIndicatorEvents()
	{
	}

	public void ApplyDamageDigitalisEvents(List<DamageDigitalisEvent> damageDigitalisEvents)
	{
	}

	public void ApplyDamageCreeperEvents(List<DamageCreeperEvent> damageCreeperEvents)
	{
	}

	public void ApplyAddCreeperEvents(List<AddCreeperEvent> addCreeperEvents)
	{
	}

	public void ApplyAdd2CreeperEvents(List<Add2CreeperEvent> add2CreeperEvents)
	{
	}

	public void ApplyAdd3CreeperEvents(List<Add3CreeperEvent> add3CreeperEvents)
	{
	}

	public void ApplySetCreeperEvents(List<SetCreeperEvent> setCreeperEvents)
	{
	}

	public void ApplySetCreeperStainEvents(List<SetCreeperStainEvent> setCreeperStainEvents)
	{
	}

	public void ApplyApplyRunningCreeperEventsEvents(List<ApplyRunningCreeperEvent> applyRunningCreeperEvents)
	{
	}

	public void ApplySetTerrainEvents(List<SetTerrainEvent> setTerrainEvents)
	{
	}

	public void ApplyTerraformAddIndicatorEvents(List<TerraformAddIndicatorEvent> terraformAddIndicatorEvents)
	{
	}

	public void ApplyTerraformRemoveIndicatorEvents(List<TerraformRemoveIndicatorEvent> terraformRemoveIndicatorEvents)
	{
	}

	public void Update()
	{
	}
}
