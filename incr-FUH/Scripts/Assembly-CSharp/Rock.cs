using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rock : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 2, (int l) => 2, () => true);

		public BaseResearchAttribute CanThrowRightAttribute = new BaseResearchAttribute("CanThrowRight", () => 250, () => true);

		public BaseShardBLevelAttribute CanHaveExtraWorker1Attribute = new BaseShardBLevelAttribute("CanHaveExtraWorker1", 1, (int l) => 1, () => true);

		public BaseMoneyAttribute CanHaveExtraWorker2Attribute = new BaseMoneyAttribute("CanHaveExtraWorker2", () => 15000, () => true);

		public BaseMoneyAttribute CanScafoldingAttribute = new BaseMoneyAttribute("CanScafolding", () => 2500, () => true);

		public BaseShardYLevelAttribute CanHaveMoreOutputAttribute = new BaseShardYLevelAttribute("CanHaveMoreOutput", 3, (int l) => 1, () => true);

		public BaseShardYLevelAttribute CanMakeMediumAttribute = new BaseShardYLevelAttribute("CanMakeMedium", 1, (int l) => 1, () => true);

		public BaseResearchAttribute CanThrowFurtherAttribute = new BaseResearchAttribute("CanThrowFurther", () => 750, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { LevelUpAttribute, CanThrowRightAttribute, CanHaveExtraWorker1Attribute, CanHaveExtraWorker2Attribute, CanScafoldingAttribute, CanHaveMoreOutputAttribute, CanMakeMediumAttribute, CanThrowFurtherAttribute };
		}

		public override bool CanBuild()
		{
			return true;
		}

		public override int MaxBuilding()
		{
			return 999;
		}

		public int YellowShardGiven()
		{
			return GlobalInfo.LevelUpAttribute.Level;
		}
	}

	public GameObject DoorLocation;

	public GameObject OutputLocation;

	public GameObject IdleLocation;

	public GameObject RockImage;

	public GameObject ProgressBar;

	public Sprite Rock0;

	public Sprite Rock1;

	public Sprite Rock2;

	public Sprite Rock3;

	public GameObject Scafolding;

	public CharDisplay PeonDisplay1;

	public CharDisplay PeonDisplay2;

	public CharDisplay PeonDisplay3;

	public CharDisplay PeonDisplay4;

	public GarbageCounter GarbageCounter;

	private float _hitTimer;

	private int Life = 50;

	private int MaxLife = 50;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasScafoldingAttribute = new BaseMoneyAttribute("HasScafolding", () => GameController.Instance.AddPrestigeCountTax(500), () => GlobalInfo.CanScafoldingAttribute.IsEnabled);

	public BaseMoneyLevelAttribute HasThrowFurtherAttribute = new BaseMoneyLevelAttribute("HasThrowFurther", 10, (int l) => GameController.Instance.AddPrestigeCountTax(200 + l * 200), () => GlobalInfo.CanThrowFurtherAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Rock;

	private void Start()
	{
		PeonDisplay1.gameObject.SetActive(value: false);
		PeonDisplay2.gameObject.SetActive(value: false);
		PeonDisplay3.gameObject.SetActive(value: false);
		PeonDisplay4.gameObject.SetActive(value: false);
		PeonDisplay1.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		PeonDisplay1.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		PeonDisplay2.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		PeonDisplay2.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		PeonDisplay3.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		PeonDisplay3.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		PeonDisplay4.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		PeonDisplay4.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		Scafolding.gameObject.SetActive(value: false);
		ProgressBar.SetActive(value: false);
	}

	private void Update()
	{
		if (HasScafoldingAttribute.IsEnabled)
		{
			Scafolding.gameObject.SetActive(value: true);
		}
		else
		{
			Scafolding.gameObject.SetActive(value: false);
		}
		if (GameController.Instance.IsHoleFilled())
		{
			return;
		}
		if (Working.Count > 0 && !GarbageCounter.IsOverLimit)
		{
			_hitTimer += Time.deltaTime;
			if (_hitTimer >= 2f)
			{
				ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_rock_hit, base.transform.position.x);
				ThrowGarbage();
				_hitTimer -= 2f;
			}
		}
		if (Life > 0)
		{
			return;
		}
		ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_rock_destroy, base.transform.position.x);
		if (Workers.Count >= 4 && GlobalInfo.CanMakeMediumAttribute.IsEnabled)
		{
			for (int i = 0; i < 3; i++)
			{
				Garbage garbage = GameController.Instance.GarbageController.Generate(OutputLocation.transform.position, 5, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.Rock, isEvil: false);
				if (HasScafoldingAttribute.IsEnabled && GlobalInfo.CanThrowRightAttribute.IsEnabled)
				{
					garbage.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(1 + 6 * HasThrowFurtherAttribute.Level, 3 + 6 * HasThrowFurtherAttribute.Level), 3f), ForceMode2D.Impulse);
				}
				else
				{
					garbage.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
				}
			}
		}
		else
		{
			for (int j = 0; j < 10; j++)
			{
				Garbage garbage2 = GameController.Instance.GarbageController.Generate(OutputLocation.transform.position, 1, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Rock, isEvil: false);
				if (HasScafoldingAttribute.IsEnabled && GlobalInfo.CanThrowRightAttribute.IsEnabled)
				{
					garbage2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(1 + 6 * HasThrowFurtherAttribute.Level, 3 + 6 * HasThrowFurtherAttribute.Level), 3f), ForceMode2D.Impulse);
				}
				else
				{
					garbage2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
				}
			}
		}
		for (int k = 0; k < GlobalInfo.YellowShardGiven(); k++)
		{
			GameController.Instance.GarbageController.Generate(OutputLocation.transform.position, 1, GarbageInfo.GarbageTypeEnum.ShardYellow, GarbageInfo.CameFromEnum.None, isEvil: false).GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4f), ForceMode2D.Impulse);
		}
		ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.ga_shard_appear, base.transform.position.x);
		ParentColumn.DestroyBuilding(this, 0f, canOutputMedium: false);
		GameController.Instance.ColumnsController.VerifyAndAddNewcolumn();
	}

	private void FixedUpdate()
	{
		if ((double)Life < (double)MaxLife * 0.25)
		{
			RockImage.GetComponent<SpriteRenderer>().sprite = Rock3;
		}
		else if ((double)Life < (double)MaxLife * 0.5)
		{
			RockImage.GetComponent<SpriteRenderer>().sprite = Rock2;
		}
		else if ((double)Life < (double)MaxLife * 0.75)
		{
			RockImage.GetComponent<SpriteRenderer>().sprite = Rock1;
		}
		else
		{
			RockImage.GetComponent<SpriteRenderer>().sprite = Rock0;
		}
	}

	public override float GetStabilityPercentage()
	{
		return 1f;
	}

	public override bool IsUnstable()
	{
		return false;
	}

	public void SetLife(int amount)
	{
		MaxLife = amount;
		Life = MaxLife;
	}

	public int GetCurrentMaxLife()
	{
		return MaxLife;
	}

	public int GetLifeLeft()
	{
		if (Life < 0)
		{
			return 0;
		}
		return Life;
	}

	private void ThrowGarbage()
	{
		int life = Life;
		int num = GetHitAmount() * Working.Count;
		Life -= num;
		RockImage.transform.DOShakePosition(0.1f, new Vector3(0.25f, 0.25f, 0f), 5, 0f);
		int num2 = 0;
		num2 = ((Life / 10 == life / 10) ? (num + GlobalInfo.CanHaveMoreOutputAttribute.Level) : (num + 4 + GlobalInfo.CanHaveMoreOutputAttribute.Level));
		while (num2 > 0)
		{
			if (num2 > 4 && Workers.Count >= 4 && GlobalInfo.CanMakeMediumAttribute.IsEnabled)
			{
				Garbage garbage = GameController.Instance.GarbageController.Generate(OutputLocation.transform.position, 5, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.Rock, isEvil: false);
				if (HasScafoldingAttribute.IsEnabled && GlobalInfo.CanThrowRightAttribute.IsEnabled)
				{
					garbage.ThrowToLocation(new Vector3(base.transform.position.x + 1f + (float)(6 * HasThrowFurtherAttribute.Level) + (float)Random.Range(1, 3), base.transform.position.y));
				}
				else
				{
					garbage.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
				}
				num2 -= 4;
			}
			else
			{
				Garbage garbage2 = GameController.Instance.GarbageController.Generate(OutputLocation.transform.position, 1, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Rock, isEvil: false);
				if (HasScafoldingAttribute.IsEnabled && GlobalInfo.CanThrowRightAttribute.IsEnabled)
				{
					garbage2.ThrowToLocation(new Vector3(base.transform.position.x + 1f + (float)(6 * HasThrowFurtherAttribute.Level) + (float)Random.Range(1, 3), base.transform.position.y));
				}
				else
				{
					garbage2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
				}
				num2--;
			}
		}
	}

	public float GetRockPercentage()
	{
		return (float)Life / (float)MaxLife;
	}

	private int GetHitAmount()
	{
		int num = 1;
		if (GlobalInfo.CanHaveExtraWorker1Attribute.IsEnabled)
		{
			num++;
		}
		if (Training.GlobalInfo.MiningAttribute.Level > 0)
		{
			num += Training.GlobalInfo.MiningAttribute.Level;
		}
		return num;
	}

	public override void EnterBuilding(CharV2 c)
	{
		if (Working.Count == 0)
		{
			_hitTimer = 0f;
		}
		base.EnterBuilding(c);
		if (Working.Count == 0)
		{
			PeonDisplay1.gameObject.SetActive(value: false);
			PeonDisplay2.gameObject.SetActive(value: false);
			PeonDisplay3.gameObject.SetActive(value: false);
			PeonDisplay4.gameObject.SetActive(value: false);
		}
		else if (Working.Count == 1)
		{
			PeonDisplay1.gameObject.SetActive(value: true);
			PeonDisplay2.gameObject.SetActive(value: false);
			PeonDisplay3.gameObject.SetActive(value: false);
			PeonDisplay4.gameObject.SetActive(value: false);
		}
		else if (Working.Count == 2)
		{
			PeonDisplay1.gameObject.SetActive(value: true);
			PeonDisplay2.gameObject.SetActive(value: true);
			PeonDisplay3.gameObject.SetActive(value: false);
			PeonDisplay4.gameObject.SetActive(value: false);
		}
		else if (Working.Count == 3)
		{
			PeonDisplay1.gameObject.SetActive(value: true);
			PeonDisplay2.gameObject.SetActive(value: true);
			PeonDisplay3.gameObject.SetActive(value: true);
			PeonDisplay4.gameObject.SetActive(value: false);
		}
		else if (Working.Count == 4)
		{
			PeonDisplay1.gameObject.SetActive(value: true);
			PeonDisplay2.gameObject.SetActive(value: true);
			PeonDisplay3.gameObject.SetActive(value: true);
			PeonDisplay4.gameObject.SetActive(value: true);
		}
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		if (Working.Count == 0)
		{
			PeonDisplay1.gameObject.SetActive(value: false);
			PeonDisplay2.gameObject.SetActive(value: false);
			PeonDisplay3.gameObject.SetActive(value: false);
			PeonDisplay4.gameObject.SetActive(value: false);
		}
		else if (Working.Count == 1)
		{
			PeonDisplay1.gameObject.SetActive(value: true);
			PeonDisplay2.gameObject.SetActive(value: false);
			PeonDisplay3.gameObject.SetActive(value: false);
			PeonDisplay4.gameObject.SetActive(value: false);
		}
		else if (Working.Count == 2)
		{
			PeonDisplay1.gameObject.SetActive(value: true);
			PeonDisplay2.gameObject.SetActive(value: true);
			PeonDisplay3.gameObject.SetActive(value: false);
			PeonDisplay4.gameObject.SetActive(value: false);
		}
		else if (Working.Count == 3)
		{
			PeonDisplay1.gameObject.SetActive(value: true);
			PeonDisplay2.gameObject.SetActive(value: true);
			PeonDisplay3.gameObject.SetActive(value: true);
			PeonDisplay4.gameObject.SetActive(value: false);
		}
		else if (Working.Count == 4)
		{
			PeonDisplay1.gameObject.SetActive(value: true);
			PeonDisplay2.gameObject.SetActive(value: true);
			PeonDisplay3.gameObject.SetActive(value: true);
			PeonDisplay4.gameObject.SetActive(value: true);
		}
		if (Working.Count == 0)
		{
			_hitTimer = 0f;
		}
	}

	public void BoxClick()
	{
	}

	public override int GetMaximumWorker()
	{
		int num = 1;
		if (GlobalInfo.CanHaveExtraWorker1Attribute.IsEnabled)
		{
			num++;
		}
		if (HasScafoldingAttribute.IsEnabled)
		{
			num++;
			if (GlobalInfo.CanHaveExtraWorker2Attribute.IsEnabled)
			{
				num++;
			}
		}
		return num;
	}

	public override Vector3 GetEnterLocation()
	{
		return DoorLocation.transform.position;
	}

	public void RemoveFlyWorkers()
	{
		for (int num = Working.Count - 1; num >= 0; num--)
		{
			CharV2 charV = Working[num];
			ExitBuilding(charV);
			if ((object)this == null)
			{
				charV.Fly();
			}
		}
		for (int num2 = Workers.Count - 1; num2 >= 0; num2--)
		{
			RemoveWorker(Workers[num2]);
		}
	}

	public override void SetData(Dictionary<string, int> data)
	{
		base.SetData(data);
		if (data.ContainsKey("Life"))
		{
			Life = data["Life"];
		}
		if (data.ContainsKey("MaxLife"))
		{
			MaxLife = data["MaxLife"];
		}
	}

	public override Dictionary<string, int> GetData()
	{
		Dictionary<string, int> data = base.GetData();
		data.Add("Life", Life);
		data.Add("MaxLife", MaxLife);
		return data;
	}

	public override int YellowShardCountWhenDurabilityDown()
	{
		return GlobalInfo.YellowShardGiven();
	}

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute> { HasScafoldingAttribute, HasThrowFurtherAttribute };
	}
}
