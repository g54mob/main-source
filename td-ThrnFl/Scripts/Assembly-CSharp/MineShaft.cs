using System.Collections.Generic;
using UnityEngine;

public class MineShaft : IncomeModifyer, ISaveLoad
{
	public int incomeReductionPerTurn = 1;

	public int minimumIncome = 1;

	public Equippable sustainableMiningPerk;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int minimumIncomeWithSustainableMining = 3;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public int resetIncomeSustainableMining = 6;

	private PlayerManager playerManager;

	public Transform mineEntrance;

	[SerializeField]
	private float mineEnterDistance = 3f;

	[SerializeField]
	private float mineEnterAngleDotProd = 0.8f;

	[SerializeField]
	private float playerEnterTimerMax = 0.75f;

	[SerializeField]
	private float cooldownAfterTeleport = 1f;

	private float playerEnterTimer;

	public static List<MineShaft> allMineShafts = new List<MineShaft>();

	private BuildSlot myBuildSlot;

	private float cooldown;

	private int loadedIncomeDecreaseLevel;

	private int currentIncomeDecreaseLevel;

	private bool initialized;

	public BuildSlot MyBuildSlot => myBuildSlot;

	public void SetCooldown(float _cooldown)
	{
		cooldown = _cooldown;
	}

	private void Initialize()
	{
		if (!initialized)
		{
			myBuildSlot = GetComponent<BuildSlot>();
			myBuildSlot.Interactor.IncomeModifiers.Add(this);
			initialized = true;
		}
	}

	private void Start()
	{
		playerManager = PlayerManager.Instance;
		if (!initialized)
		{
			Initialize();
		}
		playerEnterTimer = playerEnterTimerMax;
		if (!allMineShafts.Contains(this))
		{
			allMineShafts.Add(this);
		}
		for (int num = allMineShafts.Count - 1; num >= 0; num--)
		{
			if (allMineShafts[num] == null)
			{
				allMineShafts.RemoveAt(num);
			}
		}
		SortAllMineShafts();
	}

	private void SortAllMineShafts()
	{
		allMineShafts.Sort(delegate(MineShaft mineShaft1, MineShaft mineShaft2)
		{
			Vector3 position = mineShaft1.gameObject.transform.position;
			Vector3 position2 = mineShaft2.gameObject.transform.position;
			int num = position.z.CompareTo(position2.z);
			if (num != 0)
			{
				return num;
			}
			int num2 = position.x.CompareTo(position2.x);
			return (num2 != 0) ? num2 : position.y.CompareTo(position2.y);
		});
	}

	public static MineShaft FindNextMineShaftAfter(int _i)
	{
		for (int num = (_i + 1) % allMineShafts.Count; num != _i; num = (num + 1) % allMineShafts.Count)
		{
			MineShaft mineShaft = allMineShafts[num];
			if (mineShaft.MyBuildSlot.Level > 0 && mineShaft.buildingInteractor.buildingHP.TaggedObj.Tags.Contains(TagManager.ETag.AUTO_Alive))
			{
				return mineShaft;
			}
		}
		return null;
	}

	private void Update()
	{
		cooldown -= Time.deltaTime;
		if (MyBuildSlot.Level <= 0 || !buildingInteractor.buildingHP.TaggedObj.Tags.Contains(TagManager.ETag.AUTO_Alive) || cooldown > 0f)
		{
			return;
		}
		bool flag = false;
		PlayerMovement[] registeredPlayers = playerManager.RegisteredPlayers;
		foreach (PlayerMovement playerMovement in registeredPlayers)
		{
			if (!((mineEntrance.position - playerMovement.transform.position).magnitude < mineEnterDistance) || !(Vector3.Dot(mineEntrance.localToWorldMatrix.MultiplyVector(new Vector3(0f, 0f, 1f)).normalized, playerMovement.Velocity.normalized) > mineEnterAngleDotProd))
			{
				continue;
			}
			playerEnterTimer -= Time.deltaTime;
			flag = true;
			if (playerEnterTimer <= 0f)
			{
				MineShaft mineShaft = FindNextMineShaftAfter(allMineShafts.IndexOf(this));
				if ((bool)mineShaft)
				{
					Vector3 position = mineShaft.transform.position;
					position += mineShaft.mineEntrance.localToWorldMatrix.MultiplyVector(new Vector3(0f, 0f, -1f));
					playerMovement.TeleportTo(position);
					mineShaft.SetCooldown(cooldownAfterTeleport);
					SetCooldown(cooldownAfterTeleport);
				}
			}
		}
		if (!flag)
		{
			playerEnterTimer = playerEnterTimerMax;
		}
	}

	public override void OnDawn()
	{
		DecreaseIncome();
	}

	private void DecreaseIncome()
	{
		if (myBuildSlot.Level <= 0)
		{
			return;
		}
		if (buildingInteractor.KnockedOutTonight)
		{
			if (PerkManager.IsEquipped(sustainableMiningPerk))
			{
				currentIncomeDecreaseLevel = 0;
				loadedIncomeDecreaseLevel = 0;
				myBuildSlot.GoldIncome = resetIncomeSustainableMining;
			}
		}
		else
		{
			currentIncomeDecreaseLevel++;
			SetIncome();
		}
	}

	private void ForceDecreaseIncome()
	{
		currentIncomeDecreaseLevel++;
		SetIncome();
	}

	private void SetIncome()
	{
		if (PerkManager.IsEquipped(sustainableMiningPerk))
		{
			myBuildSlot.GoldIncome = Mathf.Max(myBuildSlot.GoldIncome - incomeReductionPerTurn, minimumIncomeWithSustainableMining);
		}
		else
		{
			myBuildSlot.GoldIncome = Mathf.Max(myBuildSlot.GoldIncome - incomeReductionPerTurn, minimumIncome);
		}
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		if (!initialized)
		{
			Initialize();
		}
		loadedIncomeDecreaseLevel = 0;
		MatchSaveLoadHandler.TryLoadValue(guid, "currentIncomeDecreaseLevel", ref loadedIncomeDecreaseLevel);
		myBuildSlot.OnAfterDelayedLoadFinished.AddListener(ExecuteDelayedLoad);
	}

	private void ExecuteDelayedLoad()
	{
		if (!initialized)
		{
			Initialize();
		}
		for (int i = 0; i < loadedIncomeDecreaseLevel; i++)
		{
			ForceDecreaseIncome();
		}
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "currentIncomeDecreaseLevel", currentIncomeDecreaseLevel);
	}
}
