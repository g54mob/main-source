using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class CarScript : Writeable, IHasSpeed
{
	public Light[] Lights;

	public Light[] BrakeLights;

	public AudioSource AudioComp;

	private AudioSource SFX;

	public bool Parked;

	public bool AudioE = true;

	public bool LightsE = true;

	public bool IsBike;

	public bool CanDestroy;

	public bool FireFighter;

	public bool LogoDirty;

	public bool Ghost;

	public float Speed;

	public float CurrentSpeed;

	public float LastSpeed;

	public float Delay;

	public float ExtraTime;

	public int CarIdx;

	public List<IHasSpeed> WaitingFor = new List<IHasSpeed>();

	public int Capacity;

	public RoadNode Target;

	public Renderer[] CarRender;

	public Renderer[] Logos;

	[NonSerialized]
	public Company LogoCompany;

	public MaterialPropertyBlock MatBlock;

	public Renderer[] AllRenders;

	public Transform[] LeftWheels;

	public Transform[] RightWheels;

	public CarSpawn[] SpawnPoints;

	public int LastX;

	public int LastY;

	public Renderer[] Wheels;

	[NonSerialized]
	public byte OwnerPlayer;

	public int[] ValidWheelHubs = new int[16]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11, 12, 13, 14, 15
	};

	private bool _lastVisible = true;

	[NonSerialized]
	private uint _deserializedLogo;

	[ContextMenu("Fix lights")]
	public void FixLights()
	{
		List<Light> list = Lights.ToList();
		List<Light> list2 = new List<Light>();
		for (int i = 0; i < list.Count; i++)
		{
			Light light = list[i];
			if (light.color.r > light.color.g)
			{
				list2.Add(light);
				list.RemoveAt(i);
				i--;
			}
		}
		Lights = list.ToArray();
		BrakeLights = list2.ToArray();
	}

	public void Reset()
	{
		WaitingFor.Clear();
		Parked = false;
		AudioE = true;
		LightsE = true;
		CanDestroy = true;
		LogoDirty = false;
		Ghost = false;
		Target = null;
		OwnerPlayer = 0;
		CurrentSpeed = 0f;
		LogoCompany = null;
		Logos.ForEachEnum(delegate(Renderer x)
		{
			x.gameObject.SetActive(false);
		});
		UpdateEmission(0f);
		if (!IsBike)
		{
			for (int num = 0; num < Lights.Length; num++)
			{
				Lights[num].enabled = true;
			}
		}
		for (int num2 = 0; num2 < SpawnPoints.Length; num2++)
		{
			SpawnPoints[num2].Reset();
		}
		UpdateVisibility(true, true);
		NormalCar component = GetComponent<NormalCar>();
		if (component != null)
		{
			component.Reset();
		}
		BusScript component2 = GetComponent<BusScript>();
		if (component2 != null)
		{
			component2.Reset();
		}
		BikeScript component3 = GetComponent<BikeScript>();
		if (component3 != null)
		{
			component3.Reset();
		}
	}

	public void UpdateColor(Color color)
	{
		MatBlock.SetColor("_Color1", color);
		for (int i = 0; i < CarRender.Length; i++)
		{
			CarRender[i].SetPropertyBlock(MatBlock);
		}
	}

	public Color GetColor()
	{
		return MatBlock.GetColor("_Color1");
	}

	public void UpdateEmission(float emish)
	{
		MatBlock.SetFloat("_Emission", emish);
		for (int i = 0; i < CarRender.Length; i++)
		{
			CarRender[i].SetPropertyBlock(MatBlock);
		}
	}

	public void Init()
	{
		bool flag = true;
		NormalCar component = GetComponent<NormalCar>();
		if (component != null)
		{
			flag = false;
			component.Init();
		}
		BusScript component2 = GetComponent<BusScript>();
		if (component2 != null)
		{
			component2.Init();
		}
		BikeScript component3 = GetComponent<BikeScript>();
		if (component3 != null)
		{
			component3.Init();
		}
		if (!IsBike)
		{
			for (int i = 0; i < Lights.Length; i++)
			{
				Lights[i].enabled = false;
			}
		}
		TimeOfDay.Instance.canSkip = TimeOfDay.Instance.CanSkip();
		if (flag)
		{
			InitWheels();
		}
		InitLogo();
	}

	public void InitLogo()
	{
		if (LogoCompany != null)
		{
			if (!SelectorController.Instance.DoneLoading)
			{
				LogoDirty = true;
				return;
			}
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetVector("_Offset", LogoController.Instance.GetLogoRect(LogoCompany, true).ToVector());
			for (int i = 0; i < Logos.Length; i++)
			{
				Logos[i].SetPropertyBlock(materialPropertyBlock);
				Logos[i].gameObject.SetActive(true);
			}
		}
		LogoDirty = false;
	}

	public void InitWheels(int hub = -1)
	{
		if (Wheels.Length != 0)
		{
			if (hub < 0)
			{
				hub = ValidWheelHubs.GetRandom();
			}
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetVector("_UV", new Vector4((float)(hub % 4) * 0.25f, 1f - (float)(hub / 4) * 0.25f, 1f, 1f));
			for (int i = 0; i < Wheels.Length; i++)
			{
				Wheels[i].SetPropertyBlock(materialPropertyBlock);
			}
		}
	}

	public void DestroyEvent()
	{
		NormalCar component = GetComponent<NormalCar>();
		if (component != null)
		{
			component.DestroyEvent();
		}
		BikeScript component2 = GetComponent<BikeScript>();
		if (component2 != null)
		{
			component2.DestroyEvent();
		}
		CarSpawn[] spawnPoints = SpawnPoints;
		foreach (CarSpawn carSpawn in spawnPoints)
		{
			foreach (Actor occupant in carSpawn.Occupants)
			{
				if (occupant.MyCar == this)
				{
					occupant.MyCar = null;
				}
			}
			carSpawn.Occupants.Clear();
		}
	}

	private void Awake()
	{
		MatBlock = new MaterialPropertyBlock();
		for (int i = 0; i < CarRender.Length; i++)
		{
			CarRender[i].SetPropertyBlock(MatBlock);
		}
		if (!IsBike)
		{
			AudioSource[] componentsInChildren = GetComponentsInChildren<AudioSource>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].volume = 1f;
			}
			AudioComp = componentsInChildren[0];
			SFX = componentsInChildren[1];
			for (int k = 0; k < Lights.Length; k++)
			{
				Lights[k].enabled = false;
			}
			UpdateEmission(0f);
		}
		for (int l = 0; l < SpawnPoints.Length; l++)
		{
			SpawnPoints[l].ID = l;
			SpawnPoints[l].Parent = this;
		}
	}

	public bool AllDoorsClosed()
	{
		CarSpawn[] spawnPoints = SpawnPoints;
		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if (spawnPoints[i].OpenAmount > 0f)
			{
				return false;
			}
		}
		return true;
	}

	public void PlaySFX(AudioClip clip)
	{
		SFX.PlayOneShot(clip);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.gameObject.activeInHierarchy)
		{
			return;
		}
		if (other.tag.Equals("Carstop"))
		{
			CarScript component = other.transform.parent.GetComponent<CarScript>();
			if (!component.WaitingFor.Contains(this) && (!component.Parked || component.FireFighter))
			{
				WaitingFor.Add(component);
			}
			return;
		}
		Rigidbody attachedRigidbody = other.attachedRigidbody;
		Actor actor = ((attachedRigidbody != null) ? attachedRigidbody.GetComponent<Actor>() : null);
		if (actor != null && actor.isActiveAndEnabled && actor.currentRoom.Outside && actor.AItype != AI.AIType.Security && !actor.Biking && !GameSettings.Instance.sActorManager.ReadyForHome.Contains(actor))
		{
			WaitingFor.Add(actor);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag.Equals("Carstop"))
		{
			CarScript component = other.transform.parent.GetComponent<CarScript>();
			WaitingFor.Remove(component);
			return;
		}
		Rigidbody attachedRigidbody = other.attachedRigidbody;
		Actor actor = ((attachedRigidbody != null) ? attachedRigidbody.GetComponent<Actor>() : null);
		if (actor != null)
		{
			WaitingFor.Remove(actor);
		}
	}

	public float GetMaxSpeed(float angle)
	{
		if (WaitingFor.Count == 0)
		{
			return 0f;
		}
		int num = 0;
		float num2 = float.MaxValue;
		for (int i = 0; i < WaitingFor.Count; i++)
		{
			GameObject gameObject = WaitingFor[i].GetGameObject();
			if (gameObject == null || !gameObject.activeInHierarchy)
			{
				WaitingFor.RemoveAt(i);
				i--;
			}
			else
			{
				num++;
				num2 = Mathf.Min(WaitingFor[i].GetSpeed(angle), num2);
			}
		}
		if (num <= 0)
		{
			return 0f;
		}
		return num2;
	}

	private void OnDestroy()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			RoadManager.Instance.Cars.Remove(this);
			HashSet<CarScript> value;
			if (RoadManager.Instance.CachedCars.TryGetValue(CarIdx, out value))
			{
				value.Remove(this);
			}
			TimeOfDay.Instance.canSkip = TimeOfDay.Instance.CanSkip();
		}
	}

	public Actor FirstActor()
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			foreach (Actor occupant in SpawnPoints[i].Occupants)
			{
				if (occupant != null)
				{
					return occupant;
				}
			}
		}
		return null;
	}

	public IEnumerable<Actor> GetOccupantsNotNull()
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			foreach (Actor occupant in SpawnPoints[i].Occupants)
			{
				if (occupant != null)
				{
					yield return occupant;
				}
			}
		}
	}

	public bool ContainsOccupant(Actor x)
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			if (SpawnPoints[i].Occupants.Contains(x))
			{
				return true;
			}
		}
		return false;
	}

	public bool AnyOccupants()
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			if (SpawnPoints[i].Occupants.Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	public bool AnyLiveOccupants(bool checkActive = false)
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			foreach (Actor occupant in SpawnPoints[i].Occupants)
			{
				if (occupant != null && (!checkActive || occupant.isActiveAndEnabled))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void ClearOccupants()
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			SpawnPoints[i].Occupants.Clear();
		}
	}

	public bool AnyDeadOccupants(bool includeParent = true)
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			foreach (Actor occupant in SpawnPoints[i].Occupants)
			{
				if (occupant != null && (includeParent || occupant.AItype != AI.AIType.Parent) && !occupant.isActiveAndEnabled)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsSpawning()
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			if (SpawnPoints[i].isSpawning)
			{
				return true;
			}
		}
		return false;
	}

	public CarSpawn AddOccupant(Actor actor, bool goingOut)
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			CarSpawn carSpawn = SpawnPoints[i];
			if (((goingOut && carSpawn.CanGoOut) || (!goingOut && carSpawn.CanGoIn)) && carSpawn.Occupants.Count < carSpawn.Capacity)
			{
				carSpawn.Occupants.Add(actor);
				actor.DriveTime = SDateTime.Now();
				if (Delay > 0f)
				{
					actor.DriveTime += SDateTime.GetMinutes(Delay);
				}
				if (ExtraTime > 0f)
				{
					actor.DriveTime -= SDateTime.GetMinutes(ExtraTime);
				}
				return carSpawn;
			}
		}
		return null;
	}

	public CarSpawn ForceAddOccupant(Actor actor)
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			CarSpawn carSpawn = SpawnPoints[i];
			if (carSpawn.Occupants.Count < carSpawn.Capacity)
			{
				carSpawn.Occupants.Add(actor);
				return carSpawn;
			}
		}
		return null;
	}

	public void ForEachOccupant(Action<Actor> action)
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			foreach (Actor occupant in SpawnPoints[i].Occupants)
			{
				if (occupant != null)
				{
					action(occupant);
				}
			}
		}
	}

	public IEnumerable<Actor> GetOccupants()
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			foreach (Actor occupant in SpawnPoints[i].Occupants)
			{
				yield return occupant;
			}
		}
	}

	public void BindOccupants()
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			foreach (Actor occupant in SpawnPoints[i].Occupants)
			{
				if (!(occupant != null) || (!(occupant.MyCar != this) && occupant.CarSpawnID == i))
				{
					continue;
				}
				if (occupant.MyCar != null)
				{
					if (occupant.CarSpawnID < occupant.MyCar.SpawnPoints.Length)
					{
						if (occupant.MyCar.SpawnPoints[occupant.CarSpawnID] != SpawnPoints[i])
						{
							occupant.MyCar.SpawnPoints[occupant.CarSpawnID].Occupants.Remove(occupant);
						}
					}
					else
					{
						for (int j = 0; j < occupant.MyCar.SpawnPoints.Length; j++)
						{
							CarSpawn carSpawn = occupant.MyCar.SpawnPoints[j];
							if (carSpawn.Occupants != SpawnPoints[i].Occupants)
							{
								carSpawn.Occupants.Remove(occupant);
							}
						}
					}
				}
				occupant.MyCar = this;
				occupant.CarSpawnID = i;
			}
		}
	}

	public void BeginSpawn()
	{
		StartCoroutine(SpawnActors());
	}

	private IEnumerator SpawnActors()
	{
		for (int i = 0; i < SpawnPoints.Length; i++)
		{
			if (SpawnPoints[i].Occupants.Count > 0 && SpawnPoints[i].CanGoOut)
			{
				SpawnPoints[i].BeginSpawn();
				while (GameSettings.GameSpeed == 0f)
				{
					yield return new WaitForSeconds(0.1f);
				}
				yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 1f) / GameSettings.GameSpeed);
			}
		}
	}

	private void UpdateVisibility(bool visible, bool force = false)
	{
		if (_lastVisible != visible || force)
		{
			_lastVisible = visible;
			for (int i = 0; i < AllRenders.Length; i++)
			{
				AllRenders[i].enabled = visible;
			}
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (LogoDirty)
		{
			InitLogo();
		}
		UpdateVisibility(GameSettings.Instance.ActiveFloor >= 0 && base.transform.position.y <= (float)(GameSettings.Instance.ActiveFloor / 2 * 4) + 3.99f);
		if (GameSettings.GameSpeed > 0f)
		{
			if (!IsBike)
			{
				Vector3 position = base.transform.position;
				int num = Mathf.FloorToInt(position.x / RoadManager.Instance.RoadSize);
				int num2 = Mathf.FloorToInt(position.z / RoadManager.Instance.RoadSize);
				if (num != LastX || num2 != LastY)
				{
					RoadSegment segment = RoadManager.Instance.GetSegment(num, num2, Mathf.FloorToInt((position.y + 2f) / 4f));
					if (segment != null)
					{
						segment.AddTraffic();
					}
					LastX = num;
					LastY = num2;
				}
			}
			if (Delay > 0f)
			{
				Delay -= Time.deltaTime * GameSettings.GameSpeed;
			}
			if (!Mathf.Approximately(CurrentSpeed, 0f))
			{
				Quaternion quaternion = Quaternion.Euler(0f, 0f, Time.deltaTime * GameSettings.GameSpeed * CurrentSpeed * 159f);
				Quaternion quaternion2 = Quaternion.Euler(0f, 0f, (0f - Time.deltaTime) * GameSettings.GameSpeed * CurrentSpeed * 159f);
				for (int i = 0; i < RightWheels.Length; i++)
				{
					RightWheels[i].transform.rotation *= quaternion;
				}
				for (int j = 0; j < LeftWheels.Length; j++)
				{
					LeftWheels[j].transform.rotation *= quaternion2;
				}
			}
			if (!Parked && WaitingFor.Count > 0)
			{
				for (int k = 0; k < WaitingFor.Count; k++)
				{
					bool flag = false;
					IHasSpeed hasSpeed = WaitingFor[k];
					GameObject gameObject = hasSpeed.GetGameObject();
					if (hasSpeed == null || gameObject == null || !gameObject.activeInHierarchy)
					{
						flag = true;
					}
					if (!flag)
					{
						CarScript carScript = hasSpeed as CarScript;
						if (carScript != null && carScript.Parked && !carScript.FireFighter)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						Actor actor = hasSpeed as Actor;
						if (actor != null && (!actor.isActiveAndEnabled || !actor.currentRoom.Outside))
						{
							flag = true;
						}
					}
					if (flag)
					{
						WaitingFor.RemoveAt(k);
						k--;
					}
				}
			}
		}
		if (!IsBike)
		{
			if (AudioComp.isPlaying && (GameSettings.GameSpeed == 0f || !AudioE))
			{
				AudioComp.Pause();
			}
			if (!AudioComp.isPlaying && GameSettings.GameSpeed > 0f && AudioE)
			{
				AudioComp.Play();
			}
			if (AudioComp.isPlaying)
			{
				AudioMixerGroup outputAudioMixerGroup = ((GameSettings.Instance.sRoomManager.CameraRoom == GameSettings.Instance.sRoomManager.Outside) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
				AudioComp.outputAudioMixerGroup = outputAudioMixerGroup;
				AudioComp.pitch = 0.9f + CurrentSpeed / Speed * 0.3f;
				SFX.outputAudioMixerGroup = outputAudioMixerGroup;
				AudioComp.volume = Mathf.Lerp(AudioComp.volume, (AudioE && GameSettings.GameSpeed > 0f) ? (3f / (float)HUD.Instance.GameSpeed / 3f) : 0f, Time.deltaTime * GameSettings.GameSpeed * 10f);
			}
		}
		int hour = TimeOfDay.Instance.Hour;
		bool flag2 = CurrentSpeed <= 0f || LastSpeed > CurrentSpeed;
		LastSpeed = CurrentSpeed;
		if (IsBike)
		{
			return;
		}
		if (flag2 && LightsE && GameSettings.Instance.ActiveFloor >= 0)
		{
			if (!BrakeLights[0].enabled)
			{
				for (int l = 0; l < BrakeLights.Length; l++)
				{
					BrakeLights[l].enabled = true;
				}
			}
		}
		else if (BrakeLights[0].enabled)
		{
			for (int m = 0; m < BrakeLights.Length; m++)
			{
				BrakeLights[m].enabled = false;
			}
		}
		if ((hour > 19 || hour < 7) && LightsE && GameSettings.Instance.ActiveFloor >= 0)
		{
			if (!Lights[0].enabled)
			{
				UpdateEmission(1f);
				for (int n = 0; n < Lights.Length; n++)
				{
					Lights[n].enabled = true;
				}
			}
		}
		else if (Lights[0].enabled)
		{
			UpdateEmission(0f);
			for (int num3 = 0; num3 < Lights.Length; num3++)
			{
				Lights[num3].enabled = false;
			}
		}
	}

	public override string WriteName()
	{
		return "Car";
	}

	public override void PostDeserialize()
	{
		LogoCompany = MarketSimulation.Active.GetCompany(_deserializedLogo);
		InitLogo();
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		base.transform.SetPositionAndRotation(dictionary.Get("position", new SVector3(0f, 0f, 0f)), dictionary.Get("rotation", new SVector3(0f, 0f, 0f, 1f)));
		if (dictionary.Contains("Actors"))
		{
			foreach (Actor item in (from x in dictionary.Get("Actors", new List<uint>())
				select (Actor)GetDeserializedObject(x)).ToHashSet())
			{
				ForceAddOccupant(item);
			}
		}
		List<KeyValuePair<int, uint>> list = dictionary.Get("Occupants", new List<KeyValuePair<int, uint>>());
		for (int num = 0; num < list.Count; num++)
		{
			KeyValuePair<int, uint> keyValuePair = list[num];
			Actor actor = GetDeserializedObject(keyValuePair.Value) as Actor;
			if (actor != null)
			{
				SpawnPoints[keyValuePair.Key].Occupants.Add(actor);
			}
		}
		CurrentSpeed = dictionary.Get("CurrentSpeed", 0f);
		Parked = dictionary.Get("Parked", false);
		AudioE = dictionary.Get("AudioE", true);
		LightsE = dictionary.Get("LightsE", true);
		CanDestroy = dictionary.Get("CanDestroy", false);
		_deserializedLogo = dictionary.Get("LogoCompany", 0u);
		NormalCar component = GetComponent<NormalCar>();
		if (component != null && !component.Deserialize(dictionary))
		{
			DestroyGO();
			return null;
		}
		BusScript component2 = GetComponent<BusScript>();
		if (component2 != null)
		{
			component2.Deserialize(dictionary);
		}
		BikeScript component3 = GetComponent<BikeScript>();
		if (component3 != null)
		{
			component3.Deserialize(dictionary);
		}
		if (FireFighter)
		{
			GetComponent<FireTruck>().Deserialize(dictionary);
		}
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["position"] = (SVector3)base.transform.position;
		dictionary["rotation"] = (SVector3)base.transform.rotation;
		if (mode.Is(GameReader.NewLoadMode.Full))
		{
			dictionary["Occupants"] = SpawnPoints.SelectMany((CarSpawn x) => x.Occupants.Select((Actor y) => new KeyValuePair<int, uint>(x.ID, y.DID))).ToList();
		}
		dictionary["CurrentSpeed"] = CurrentSpeed;
		dictionary["Parked"] = Parked;
		dictionary["AudioE"] = AudioE;
		dictionary["LightsE"] = LightsE;
		dictionary["CanDestroy"] = CanDestroy;
		dictionary["CarIdx"] = CarIdx;
		dictionary["LogoCompany"] = ((LogoCompany != null) ? LogoCompany.ID : 0u);
		NormalCar component = GetComponent<NormalCar>();
		if (component != null)
		{
			component.Serialize(dictionary);
		}
		BusScript component2 = GetComponent<BusScript>();
		if (component2 != null)
		{
			component2.Serialize(dictionary);
		}
		BikeScript component3 = GetComponent<BikeScript>();
		if (component3 != null)
		{
			component3.Serialize(dictionary);
		}
		if (FireFighter)
		{
			GetComponent<FireTruck>().Serialize(dictionary);
		}
	}

	public GameObject GetGameObject()
	{
		if (!(this == null))
		{
			return base.gameObject;
		}
		return null;
	}

	public float GetAngle()
	{
		float x = base.transform.forward.x;
		float magnitude = base.transform.forward.magnitude;
		return Mathf.Acos(x / magnitude);
	}

	public float GetSpeed(float angle)
	{
		if (Mathf.Abs(angle - GetAngle()) < (float)Math.PI / 8f)
		{
			return CurrentSpeed - 0.05f;
		}
		return 0f;
	}

	public void ResetColor()
	{
		NormalCar component = GetComponent<NormalCar>();
		if (component != null)
		{
			component.MyColor = component.Colors.GetRandom();
			UpdateColor(component.MyColor);
		}
	}
}
