using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class TranscendBuilding : LinkedSystemConverter
{
	private new enum State
	{
		Idle = 0,
		Transcending = 1,
		Total = 2
	}

	private new State m_State;

	private new float m_StateTimer;

	private MyParticles m_Particles;

	private int m_ObjectUID;

	private List<Folk> m_Folk;

	public TranscendEffect m_TranscendEffect;

	private MeshRenderer[] m_Renderer;

	private Material m_TranscendMaterial;

	private float m_GlowPulseTimer;

	private float m_GlowTimer;

	private bool m_CompleteAnimation;

	private float m_CompleteAnimationGlow;

	private bool m_CompleteConvert;

	private float m_CompleteConvertTimer;

	private bool m_ConfettiActive;

	private int[] m_ConfettiCount;

	private MyParticles[] m_Confetti;

	private MyParticles m_Fireworks;

	private int m_FireworksCount;

	private int m_FireworksSubCount;

	public override void Restart()
	{
		base.Restart();
		SetDimensions(new TileCoord(-2, -2), new TileCoord(2, 2), new TileCoord(0, 3));
		SetSpawnPoint(new TileCoord(0, 2));
		SetState(State.Idle);
		HideSpawnModel();
		m_PulleySide = 1;
		m_Folk = new List<Folk>();
	}

	protected new void Awake()
	{
		base.Awake();
	}

	public override void PostCreate()
	{
		base.PostCreate();
		m_IngredientsRoot = base.transform;
		if ((bool)m_ModelRoot.transform.Find("IngredientsPoint"))
		{
			m_IngredientsRoot = m_ModelRoot.transform.Find("IngredientsPoint");
		}
		m_Renderer = new MeshRenderer[4];
		for (int i = 0; i < 4; i++)
		{
			m_Renderer[i] = ObjectUtils.FindDeepChild(m_ModelRoot.transform, "Cone.00" + (i + 1)).GetComponent<MeshRenderer>();
		}
		m_TranscendEffect = ObjectTypeList.Instance.CreateObjectFromIdentifier(ObjectType.TranscendEffect, m_IngredientsRoot.transform.position, Quaternion.identity).GetComponent<TranscendEffect>();
		m_TranscendEffect.transform.SetParent(m_IngredientsRoot);
		if ((bool)CollectionManager.Instance)
		{
			CollectionManager.Instance.AddCollectable("TranscendBuilding", this);
		}
	}

	public override void StopUsing(bool AndDestroy = true)
	{
		if (AndDestroy)
		{
			m_TranscendEffect.StopUsing(AndDestroy);
		}
		base.StopUsing(AndDestroy);
	}

	public override void Save(JSONNode Node)
	{
		base.Save(Node);
		JSONArray jSONArray = (JSONArray)(Node["Folk"] = new JSONArray());
		int num = 0;
		for (int i = 0; i < m_Folk.Count; i++)
		{
			if ((bool)m_Folk[i])
			{
				JSONNode jSONNode2 = new JSONObject();
				string saveNameFromIdentifier = ObjectTypeList.Instance.GetSaveNameFromIdentifier(m_Folk[i].GetComponent<BaseClass>().m_TypeIdentifier);
				JSONUtils.Set(jSONNode2, "ID", saveNameFromIdentifier);
				m_Folk[i].GetComponent<Savable>().Save(jSONNode2);
				jSONArray[num] = jSONNode2;
				num++;
			}
		}
	}

	public override void Load(JSONNode Node)
	{
		base.Load(Node);
		JSONArray asArray = Node["Folk"].AsArray;
		for (int i = 0; i < asArray.Count; i++)
		{
			JSONNode asObject = asArray[i].AsObject;
			int asInt = JSONUtils.GetAsInt(asObject, "UID", -1);
			BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(asInt, false);
			if (objectFromUniqueID != null && objectFromUniqueID.GetComponent<TileCoordObject>().m_Plot != null)
			{
				objectFromUniqueID.StopUsing();
			}
			if (ObjectTypeList.Instance.GetObjectFromUniqueID(asInt, false) == null)
			{
				BaseClass baseClass = ObjectTypeList.Instance.CreateObjectFromSaveName(asObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				if ((bool)baseClass)
				{
					baseClass.GetComponent<Savable>().Load(asObject);
					Folk component = baseClass.GetComponent<Folk>();
					component.SendAction(new ActionInfo(ActionType.BeingHeld, m_TileCoord, this));
					component.GetComponent<Savable>().SetIsSavable(false);
					component.gameObject.SetActive(false);
					m_Folk.Add(component);
				}
			}
		}
	}

	public override object GetActionInfo(GetActionInfo Info)
	{
		GetAction action = Info.m_Action;
		if (action == GetAction.IsDuplicatable)
		{
			return false;
		}
		return base.GetActionInfo(Info);
	}

	private void StartAddFolk(AFO Info)
	{
		Info.m_Object.SendAction(new ActionInfo(ActionType.BeingHeld, m_TileCoord, this));
		Info.m_Object.GetComponent<Savable>().SetIsSavable(false);
		m_ObjectUID = Info.m_Object.m_UniqueID;
		Info.m_Object.transform.position = m_IngredientsRoot.position;
		int resultEnergyRequired = GetResultEnergyRequired();
		((LinkedSystemMechanical)m_LinkedSystem).UseEnergy(resultEnergyRequired);
	}

	private void EndAddFolk(AFO Info)
	{
		Actionable actionable = Info.m_Object;
		if ((bool)actionable)
		{
			actionable.transform.rotation = base.transform.rotation;
			actionable.gameObject.SetActive(false);
			actionable.GetComponent<Folk>().SetTier(7);
			FolkManager.Instance.UpdateFolkTiers();
			Evolution.SetLastLevelSeen(7);
			m_Folk.Add(actionable.GetComponent<Folk>());
		}
		SetState(State.Transcending);
	}

	private void AbortAddFolk(AFO Info)
	{
		Info.m_Object.SendAction(new ActionInfo(ActionType.Dropped, m_TileCoord, this));
		Info.m_Object.GetComponent<Savable>().SetIsSavable(true);
	}

	public override ActionType GetActionFromObject(AFO Info)
	{
		Info.m_StartAction = StartAddFolk;
		Info.m_EndAction = EndAddFolk;
		Info.m_AbortAction = AbortAddFolk;
		Info.m_FarmerState = Farmer.State.Adding;
		if (m_State != State.Idle)
		{
			return ActionType.Fail;
		}
		if (Info.m_ObjectType != ObjectType.Folk)
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

	private void SetState(State NewState)
	{
		State state = m_State;
		if (state == State.Transcending)
		{
			StopTranscending();
		}
		m_State = NewState;
		m_StateTimer = 0f;
		state = m_State;
		if (state == State.Transcending)
		{
			StartTranscending();
		}
	}

	private void StartTranscending()
	{
		m_TranscendEffect.StartEffect();
	}

	private void StopTranscending()
	{
		m_TranscendEffect.StopEffect();
		AudioManager.Instance.StartEvent("BuildingZigguratDone", this);
	}

	private void UpdateTranscending()
	{
		if (m_StateTimer > m_BaseConversionDelay)
		{
			m_StateTimer = 0f;
			m_ModelRoot.transform.localScale = new Vector3(1f, 1f, 1f);
			SetState(State.Idle);
		}
	}

	public void StartCompleteAnimation()
	{
		m_CompleteAnimation = true;
		m_CompleteAnimationGlow = 0f;
	}

	public void TriggerConversionAnimation()
	{
		m_CompleteConvert = true;
		m_CompleteConvertTimer = 0f;
	}

	public void UpdateCompleteAnimation()
	{
		if (!m_CompleteConvert)
		{
			return;
		}
		float completeConvertTimer = m_CompleteConvertTimer;
		m_CompleteConvertTimer += TimeManager.Instance.m_NormalDelta;
		if (m_CompleteConvertTimer >= 1f && completeConvertTimer < 1f)
		{
			AudioManager.Instance.StartEvent("TranscendBuildingConvert", this);
		}
		if (m_CompleteConvertTimer < 1.25f)
		{
			float num = (m_CompleteConvertTimer - 1f) / 0.25f;
			if (num < 0f)
			{
				num = 0f;
			}
			m_CompleteAnimationGlow = 2.5f * num;
		}
		else if (m_CompleteConvertTimer < 2.25f)
		{
			m_CompleteAnimationGlow = 2.5f;
		}
		else if (m_CompleteConvertTimer < 3.25f)
		{
			float num2 = 1f - (m_CompleteConvertTimer - 2.25f) / 1f;
			m_CompleteAnimationGlow = 1f + 1.5f * num2;
		}
		else
		{
			m_CompleteAnimationGlow = 1f;
		}
	}

	private void UpdateGlow()
	{
		if (m_Blueprint)
		{
			return;
		}
		float transcendPercent = FolkManager.Instance.GetTranscendPercent();
		float num = 0f;
		float num2 = 0.5f;
		if (m_CompleteAnimation)
		{
			UpdateCompleteAnimation();
			num = m_CompleteAnimationGlow;
		}
		else if (QuestManager.Instance.GetQuestComplete(Quest.ID.AcademyColonisation8))
		{
			num = 1f;
		}
		else if (transcendPercent != 0f)
		{
			if (!SettingsManager.Instance.m_FlashiesEnabled)
			{
				num = transcendPercent * 1f;
			}
			else
			{
				m_GlowPulseTimer += TimeManager.Instance.m_NormalDelta;
				float num3 = 1.5f - transcendPercent * 1f;
				if (m_GlowPulseTimer > num3)
				{
					m_GlowPulseTimer = 0f;
					m_GlowTimer = num2;
				}
			}
		}
		if (m_GlowTimer > 0f)
		{
			m_GlowTimer -= TimeManager.Instance.m_NormalDelta;
			float num4 = m_GlowTimer / num2;
			float num5 = transcendPercent * 2f;
			num = 0f + num4 * num5;
		}
		MaterialManager.Instance.m_MaterialTranscend.EnableKeyword("_EMISSION");
		MaterialManager.Instance.m_MaterialTranscend.SetColor("_EmissionColor", new Color(1f, 0.85f, 0f) * num);
		for (int i = 0; i < 4; i++)
		{
			Material[] sharedMaterials = m_Renderer[i].sharedMaterials;
			for (int j = 0; j < sharedMaterials.Length; j++)
			{
				if (sharedMaterials[j] == MaterialManager.Instance.m_MaterialBuilding)
				{
					sharedMaterials[j] = MaterialManager.Instance.m_MaterialTranscend;
				}
			}
			m_Renderer[i].sharedMaterials = sharedMaterials;
		}
	}

	protected new void Update()
	{
		UpdatePulley();
		State state = m_State;
		if (state == State.Transcending)
		{
			UpdateTranscending();
		}
		m_StateTimer += TimeManager.Instance.m_NormalDelta;
		UpdateConfetti();
		UpdateGlow();
	}

	public void CreateConfetti()
	{
		m_ConfettiActive = true;
		m_Confetti = new MyParticles[4];
		m_ConfettiCount = new int[4];
		ParticleSystem.MainModule main;
		for (int i = 0; i < 4; i++)
		{
			m_Confetti[i] = ParticlesManager.Instance.CreateParticles("Confetti/Prefabs/Cannon with Ribbon/Confetti Cannon Ribbon - Heart", default(Vector3), Quaternion.identity);
			m_Confetti[i].transform.SetParent(base.transform);
			float x = 8f - 5.3333335f * (float)i;
			m_Confetti[i].transform.localPosition = new Vector3(x, 0f, -7.5f);
			m_Confetti[i].transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
			m_ConfettiCount[i] = 0;
			main = m_Confetti[i].m_Particles.main;
			main.startDelay = 0.5f * (float)i;
		}
		m_Fireworks = ParticlesManager.Instance.CreateParticles("Fireworks/Prefabs/Fireworks", default(Vector3), Quaternion.identity);
		m_Fireworks.transform.SetParent(base.transform);
		m_Fireworks.transform.localPosition = new Vector3(0f, 0f, 0f);
		m_Fireworks.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
		main = m_Fireworks.m_Particles.main;
		main.startDelay = 2f;
		m_FireworksCount = 0;
		m_FireworksSubCount = 0;
	}

	public void StopConfetti()
	{
		for (int i = 0; i < 4; i++)
		{
			ParticlesManager.Instance.DestroyParticles(m_Confetti[i], true);
			m_Confetti[i].Stop();
		}
		ParticlesManager.Instance.DestroyParticles(m_Fireworks, true);
		m_Fireworks.Stop();
		m_ConfettiActive = false;
	}

	public void UpdateConfetti()
	{
		if (!m_ConfettiActive)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			if (m_ConfettiCount[i] < m_Confetti[i].m_Particles.particleCount)
			{
				AudioManager.Instance.StartEventAmbient("Confetti", m_Confetti[i].gameObject);
			}
			m_ConfettiCount[i] = m_Confetti[i].m_Particles.particleCount;
		}
		if (m_FireworksCount < m_Fireworks.m_Particles.particleCount)
		{
			AudioManager.Instance.StartEventAmbient("FireworkLaunch", m_Fireworks.gameObject);
		}
		m_FireworksCount = m_Fireworks.m_Particles.particleCount;
		if (m_FireworksSubCount < m_Fireworks.m_Particles.subEmitters.GetSubEmitterSystem(1).particleCount)
		{
			AudioManager.Instance.StartEventAmbient("FireworkExplode", m_Fireworks.gameObject);
		}
		m_FireworksSubCount = m_Fireworks.m_Particles.subEmitters.GetSubEmitterSystem(1).particleCount;
	}
}
