using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.Village.Map;

[FVSerializableKey("RaidPointsFactor", "")]
public abstract class RaidPointsFactor : IFVSerializable, IDisposable
{
	private float currentPoints;

	public float MaxPoints { get; protected set; }

	public float CurrentPoints
	{
		get
		{
			return currentPoints;
		}
		set
		{
			currentPoints = value;
			this.OnPointsChanged?.Invoke();
		}
	}

	protected VillageMap Map { get; private set; }

	public string LocalizedNamePlayer => MonoSingleton<LocalizationController>.Instance.GetText(NamePlayerTextKey);

	public string LocalizedNameEnemy => MonoSingleton<LocalizationController>.Instance.GetText(NameEnemyTextKey);

	protected abstract string NamePlayerTextKey { get; }

	protected abstract string NameEnemyTextKey { get; }

	public event Action OnPointsChanged;

	private RaidPointsFactor()
	{
	}

	protected RaidPointsFactor(ActiveRaidInfo raid)
		: this()
	{
		Map = raid.Map;
	}

	public virtual void Dispose()
	{
		Map = null;
		this.OnPointsChanged = null;
	}

	public virtual void InitAfterLoad()
	{
	}

	public virtual void Serialize(FVSerializer serializer)
	{
		serializer.Write("maxPoints", MaxPoints);
		serializer.Write("currentPoints", currentPoints);
		serializer.Write("map", Map);
	}

	public RaidPointsFactor(FVDeserializer deserializer)
		: this()
	{
		MaxPoints = deserializer.ReadFloat("maxPoints");
		currentPoints = deserializer.ReadFloat("currentPoints");
		Map = deserializer.ReadObject<VillageMap>("map");
	}
}
