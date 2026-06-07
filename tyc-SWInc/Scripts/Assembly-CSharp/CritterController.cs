using System;
using System.Collections.Generic;
using UnityEngine;

public class CritterController : MonoBehaviour
{
	[Serializable]
	public struct Variant
	{
		public int Index;

		public int[] Textures;

		public Vector2 Scale;

		public float OptionalMeshChance;

		public int Max;

		public int Min;

		public void Apply(ICritter critter)
		{
			if (Textures != null && Textures.Length != 0)
			{
				critter.ApplyTexture((Textures.Length == 1) ? Textures[0] : Textures.GetRandom());
			}
			critter.GetGameObject().transform.localScale = critter.InitialScale * UnityEngine.Random.Range(Scale.x, Scale.y);
			critter.SetOptionalMesh(OptionalMeshChance > 0f && (OptionalMeshChance >= 1f || UnityEngine.Random.value < OptionalMeshChance));
			critter.CurrentVariant = Index;
		}
	}

	public GameObject[] CritterTypes;

	[NonSerialized]
	private List<ICritter> CritterPool = new List<ICritter>();

	[NonSerialized]
	private List<ICritter> ActiveCritters = new List<ICritter>();

	public float SpawnCountDown = 5f;

	[NonSerialized]
	private float MaxCountDown;

	public static CritterController Instance;

	private bool IsActive = true;

	private static List<Variant> _variantCache = new List<Variant>();

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		MaxCountDown = SpawnCountDown;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public ICritter[] GetActiveCritters()
	{
		return ActiveCritters.ToArray();
	}

	public void PopulateCritter(GameData.ClimateType cli, GameData.EnvironmentType env)
	{
		for (int i = 0; i < CritterTypes.Length; i++)
		{
			List<ICritter> list = new List<ICritter>();
			int count = CritterTypes[i].GetComponent<ICritter>().GetCount(env, cli);
			for (int j = 0; j < count; j++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(CritterTypes[i]);
				obj.SetActive(false);
				ICritter component = obj.GetComponent<ICritter>();
				CritterPool.Add(component);
				list.Add(component);
			}
			for (int k = 0; k < list.Count; k++)
			{
				list[k].InitGroup(list);
			}
		}
	}

	public static bool ShouldGoHome(ICritter c)
	{
		float temperature = TimeOfDay.Instance.Temperature;
		float lightLevel = TimeOfDay.LightLevel;
		if (!(temperature < c.OptimalMinWeather()) && !(temperature > c.OptimalMaxWeather()) && !(lightLevel < c.OptimalMinLight()))
		{
			return lightLevel > c.OptimalMaxLight();
		}
		return true;
	}

	public void ActivateAll(bool activate)
	{
		for (int i = 0; i < ActiveCritters.Count; i++)
		{
			ActiveCritters[i].SetVisible(activate);
		}
	}

	public void StyleCritter(ICritter critter)
	{
		if (critter.Variants != null && critter.Variants.Length != 0)
		{
			if (critter.Variants.Any((Variant x) => x.Min > 0))
			{
				_variantCache.Clear();
				int[] array = new int[critter.Variants.Length];
				foreach (ICritter item2 in critter.GetGroup())
				{
					if (item2 != critter && item2.GetGameObject().activeSelf)
					{
						array[item2.CurrentVariant]++;
					}
				}
				for (int num = 0; num < critter.Variants.Length; num++)
				{
					Variant item = critter.Variants[num];
					if (item.Min > 0 && array[num] < item.Min)
					{
						_variantCache.Clear();
						_variantCache.Add(item);
						break;
					}
					if (item.Max == 0 || array[num] < item.Max)
					{
						_variantCache.Add(item);
					}
				}
				if (_variantCache.Count > 0)
				{
					_variantCache.GetRandom().Apply(critter);
				}
				else
				{
					critter.Variants.GetRandom().Apply(critter);
				}
				_variantCache.Clear();
			}
			else
			{
				critter.Variants.GetRandom().Apply(critter);
			}
		}
		else
		{
			if (critter.TextureCount > 1)
			{
				critter.ApplyTexture(UnityEngine.Random.Range(0, critter.TextureCount));
			}
			critter.SetOptionalMesh(UnityEngine.Random.value > 0.5f);
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		SpawnCountDown -= Time.deltaTime * GameSettings.GameSpeed;
		if (SpawnCountDown < 0f)
		{
			SpawnCountDown = MaxCountDown;
			float temperature = TimeOfDay.Instance.Temperature;
			float lightLevel = TimeOfDay.LightLevel;
			int num = UnityEngine.Random.Range(0, CritterPool.Count);
			for (int i = 0; i < CritterPool.Count; i++)
			{
				int index = (i + num) % CritterPool.Count;
				ICritter critter = CritterPool[index];
				if (temperature >= critter.OptimalMinWeather() && temperature <= critter.OptimalMaxWeather() && lightLevel >= critter.OptimalMinLight() && lightLevel <= critter.OptimalMaxLight() && critter.ResetPlace())
				{
					critter.GetGameObject().SetActive(true);
					StyleCritter(critter);
					critter.Spawn();
					critter.SetVisible(IsActive);
					CritterPool.RemoveAt(index);
					ActiveCritters.Add(critter);
					break;
				}
			}
		}
		if (GameSettings.Instance.ActiveFloor > -1 != IsActive)
		{
			IsActive = GameSettings.Instance.ActiveFloor > -1;
			ActivateAll(IsActive);
		}
		if (!IsActive)
		{
			return;
		}
		for (int j = 0; j < ActiveCritters.Count; j++)
		{
			ICritter critter2 = ActiveCritters[j];
			if (critter2.ShouldUpdate())
			{
				if (critter2.ShouldDestroy(true))
				{
					critter2.GetGameObject().SetActive(false);
					CritterPool.Add(critter2);
					ActiveCritters.RemoveAt(j);
					j--;
				}
				else
				{
					critter2.UpdateMe();
				}
			}
			else if (critter2.ShouldDestroy(false))
			{
				critter2.GetGameObject().SetActive(false);
				CritterPool.Add(critter2);
				ActiveCritters.RemoveAt(j);
				j--;
			}
		}
	}
}
