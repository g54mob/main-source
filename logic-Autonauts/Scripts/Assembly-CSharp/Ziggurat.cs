using SimpleJSON;
using UnityEngine;

public class Ziggurat : LinkedSystemConverter
{
	private new enum State
	{
		Idle = 0,
		Incinerating = 1,
		Total = 2
	}

	private new State m_State;

	private new float m_StateTimer;

	private PlaySound m_PlaySound;

	private new Transform m_IngredientsRoot;

	private MyParticles m_Particles;

	private int m_ObjectUID;

	public override void Restart()
	{
		base.Restart();
		if (!ObjectTypeList.m_Loading)
		{
			CollectionManager.Instance.AddCollectable("Ziggurat", this);
		}
		SetDimensions(new TileCoord(-3, -6), new TileCoord(3, 0), new TileCoord(0, 1));
		SetSpawnPoint(new TileCoord(0, -1));
		SetState(State.Idle);
		HideSpawnModel();
		m_PulleySide = 1;
	}

	protected new void Awake()
	{
		base.Awake();
	}

	public override void PostCreate()
	{
		base.PostCreate();
		m_IngredientsRoot = m_ModelRoot.transform.Find("IngredientsPoint");
	}

	public override void StopUsing(bool AndDestroy = true)
	{
		DestroyTarget();
		base.StopUsing(AndDestroy);
	}

	private void DestroyTarget()
	{
		if (m_ObjectUID != 0)
		{
			BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(m_ObjectUID, false);
			if ((bool)objectFromUniqueID)
			{
				objectFromUniqueID.StopUsing();
			}
			m_ObjectUID = 0;
		}
	}

	public override void Load(JSONNode Node)
	{
		base.Load(Node);
		CollectionManager.Instance.AddCollectable("Ziggurat", this);
	}

	private void StartAddAnimal(AFO Info)
	{
		Info.m_Object.SendAction(new ActionInfo(ActionType.BeingHeld, m_TileCoord, this));
		Info.m_Object.GetComponent<Savable>().SetIsSavable(false);
		m_ObjectUID = Info.m_Object.m_UniqueID;
		Info.m_Object.transform.position = m_IngredientsRoot.position;
		int resultEnergyRequired = GetResultEnergyRequired();
		((LinkedSystemMechanical)m_LinkedSystem).UseEnergy(resultEnergyRequired);
	}

	private void EndAddAnimal(AFO Info)
	{
		Actionable actionable = Info.m_Object;
		if ((bool)actionable)
		{
			actionable.transform.rotation = base.transform.rotation;
		}
		SetState(State.Incinerating);
	}

	public override ActionType GetActionFromObject(AFO Info)
	{
		Info.m_StartAction = StartAddAnimal;
		Info.m_EndAction = EndAddAnimal;
		Info.m_FarmerState = Farmer.State.Adding;
		if (m_State != State.Idle)
		{
			return ActionType.Fail;
		}
		if (!CanAcceptIngredient(Info.m_ObjectType))
		{
			return ActionType.Fail;
		}
		if (m_LinkedSystem == null)
		{
			return ActionType.Fail;
		}
		int resultEnergyRequired = GetResultEnergyRequired();
		if (!((LinkedSystemMechanical)m_LinkedSystem).GetIsEnergyAvailable(resultEnergyRequired))
		{
			return ActionType.Fail;
		}
		return ActionType.AddResource;
	}

	public override bool CanAcceptIngredient(ObjectType NewType)
	{
		if (NewType == ObjectType.Folk)
		{
			if (!QuestManager.Instance.GetIsLastLevelActive())
			{
				return true;
			}
			return false;
		}
		if (Animal.GetIsTypeAnimal(NewType) || NewType == ObjectType.BeesNest)
		{
			return true;
		}
		return base.CanAcceptIngredient(NewType);
	}

	private void SetState(State NewState)
	{
		State state = m_State;
		if (state == State.Incinerating)
		{
			StopIncinerating();
		}
		m_State = NewState;
		m_StateTimer = 0f;
		state = m_State;
		if (state == State.Incinerating)
		{
			StartIncinerating();
		}
	}

	private void StartIncinerating()
	{
		m_PlaySound = AudioManager.Instance.StartEvent("BuildingZigguratTransform", this, true);
		m_Particles = ParticlesManager.Instance.CreateParticles("ZigguratTransform", m_IngredientsRoot.position + new Vector3(0f, 1f, 0f), Quaternion.Euler(-90f, 0f, 0f));
	}

	private void UpdateIncineratingAnimation()
	{
	}

	private void StopIncinerating()
	{
		m_Particles.Stop();
		ParticlesManager.Instance.DestroyParticles(m_Particles, true);
		AudioManager.Instance.StopEvent(m_PlaySound);
		AudioManager.Instance.StartEvent("BuildingZigguratDone", this);
	}

	private void UpdateIncinerating()
	{
		UpdateIncineratingAnimation();
		if (m_StateTimer > m_BaseConversionDelay)
		{
			m_StateTimer = 0f;
			m_ModelRoot.transform.localScale = new Vector3(1f, 1f, 1f);
			DestroyTarget();
			BaseClass baseClass = ObjectTypeList.Instance.CreateObjectFromIdentifier(ObjectType.AnimalBird, m_IngredientsRoot.position, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
			baseClass.WorldCreated();
			baseClass.GetComponent<AnimalBird>().FlyOutOfWorld();
			SetState(State.Idle);
		}
	}

	protected new void Update()
	{
		UpdatePulley();
		State state = m_State;
		if (state == State.Incinerating)
		{
			UpdateIncinerating();
		}
		m_StateTimer += TimeManager.Instance.m_NormalDelta;
	}
}
