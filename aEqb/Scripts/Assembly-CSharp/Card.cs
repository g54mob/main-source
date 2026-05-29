using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
	public bool inPlay;

	public TMP_Text txt;

	public Image img;

	public string card_txt;

	public string card_txt_cn;

	public string cost;

	public MiniGameManager gm;

	public int sumCost;

	public int energy;

	public int maxenergy;

	public CardType cardType = CardType.Building;

	public int special_num;

	public Image backImg;

	private float shine_time;

	public bool Match(string cost)
	{
		if (gm.selected_dice.Count == 0)
		{
			gm.SetMessage("No dice selected.", "未选择骰子");
			return false;
		}
		if (cost == "")
		{
			return true;
		}
		int[] array = new int[20];
		int[] array2 = new int[20];
		for (int i = 1; i < 20; i++)
		{
			array2[i] = 0;
		}
		foreach (Dice item in gm.selected_dice)
		{
			array2[item.val]++;
		}
		for (int j = 1; j <= 6; j++)
		{
			for (int k = 1; k <= 6; k++)
			{
				for (int l = 1; l <= 6; l++)
				{
					for (int m = 1; m <= 6; m++)
					{
						for (int n = 1; n < 20; n++)
						{
							array[n] = 0;
						}
						for (int num = 0; num < cost.Length; num++)
						{
							if (cost[num] == '1')
							{
								array[1]++;
							}
							if (cost[num] == '2')
							{
								array[2]++;
							}
							if (cost[num] == '3')
							{
								array[3]++;
							}
							if (cost[num] == '4')
							{
								array[4]++;
							}
							if (cost[num] == '5')
							{
								array[5]++;
							}
							if (cost[num] == '6')
							{
								array[6]++;
							}
							if (cost[num] == 'a')
							{
								array[j]++;
							}
							if (cost[num] == 'b')
							{
								array[j + 1]++;
							}
							if (cost[num] == 'c')
							{
								array[j + 2]++;
							}
							if (cost[num] == 'd')
							{
								array[j + 3]++;
							}
							if (cost[num] == 'e')
							{
								array[j + 4]++;
							}
							if (cost[num] == 'f')
							{
								array[j + 5]++;
							}
							if (cost[num] == 'x')
							{
								array[k]++;
							}
							if (cost[num] == 'y')
							{
								array[l]++;
							}
							if (cost[num] == 'z')
							{
								array[m]++;
							}
						}
						bool flag = true;
						for (int num2 = 1; num2 < 20; num2++)
						{
							if (array[num2] != array2[num2])
							{
								flag = false;
							}
						}
						if (flag)
						{
							return true;
						}
					}
				}
			}
		}
		gm.SetMessage("Selected dice don't match requirement.", "所选骰子不符合要求");
		return false;
	}

	public void Click()
	{
		if (gm.state != MiniGameState.Action)
		{
			return;
		}
		if (!inPlay)
		{
			BuyCard();
			return;
		}
		if (energy == 0 && maxenergy > 0)
		{
			gm.SetMessage("Card exhausted.", "卡牌已耗竭。");
		}
		if (maxenergy == 0)
		{
			gm.SetMessage("This card doesn't have a click ability.", "这张牌没有点击能力。");
		}
		if (energy > 0 && maxenergy > 0)
		{
			Activate();
		}
	}

	public void RClick()
	{
		if (gm.state == MiniGameState.Action && !inPlay && cardType == CardType.Building)
		{
			if (gm.ability.Contains("Observatory"))
			{
				gm.mod++;
				Object.FindObjectOfType<Observatory>().Shine();
			}
			gm.mod++;
			gm.blueprint.Remove(this);
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		gm = Object.FindObjectOfType<MiniGameManager>();
		img = GetComponentInChildren<Image>();
		txt = GetComponentInChildren<TMP_Text>();
		img.GetComponent<ImageClickHandler>().linked_card = this;
		CardSetUp();
		energy = maxenergy;
		if (gm.language == 0)
		{
			txt.text = card_txt;
		}
		else
		{
			txt.text = card_txt_cn;
		}
		txt.fontSizeMax = Screen.height / 40;
		if (gm.language == 2)
		{
			txt.text = gm.gm.ToChineseTraditional(txt.text);
		}
		if (cardType == CardType.Basic)
		{
			GetComponentInChildren<Image>().color = Color.white;
		}
		else if (cardType == CardType.Building)
		{
			GetComponentInChildren<Image>().color = new Color(0.9f, 0.9f, 1f);
		}
		else if (cardType == CardType.Project)
		{
			GetComponentInChildren<Image>().color = new Color(1f, 1f, 0.9f);
		}
		GameObject gameObject = Object.Instantiate(gm.card_back);
		gameObject.transform.SetParent(base.transform);
		backImg = gameObject.GetComponent<Image>();
		gameObject.transform.localScale = new Vector3(0.98f, 0.98f, 1f);
		gameObject.transform.SetAsFirstSibling();
		backImg.color = new Color(0f, 0f, 0f, 0f);
	}

	public void SetText(string en, string ch)
	{
		if (gm.language == 0)
		{
			txt.text = en;
		}
		if (gm.language == 1)
		{
			txt.text = ch;
		}
		if (gm.language == 2)
		{
			txt.text = gm.gm.ToChineseTraditional(ch);
		}
		card_txt = en;
		card_txt_cn = ch;
	}

	private void Update()
	{
		if (inPlay)
		{
			if (energy > 0)
			{
				backImg.color = new Color(0f, 1f, 0f, 0.5f);
			}
			else if (energy == 0 && maxenergy > 0)
			{
				backImg.color = new Color(0f, 0f, 0f, 0f);
			}
			else if (Time.fixedTime - shine_time < 1f)
			{
				float num = Time.fixedTime - shine_time;
				backImg.color = new Color(1f, 0f, 1f, 1f - num);
			}
			else
			{
				backImg.color = new Color(0f, 0f, 0f, 0f);
			}
		}
	}

	public void Shine()
	{
		shine_time = Time.fixedTime;
	}

	public void BuyCard()
	{
		if (Match(cost))
		{
			if (sumCost != 0 && !MatchSum(sumCost, "="))
			{
				gm.SetMessage("Dice sum doens't match requirement.", "骰子总和不符合要求");
				return;
			}
			if (!SpecialCost())
			{
				gm.SetMessage("Selected dice don't match requirement.", "所选骰子不符合要求");
				return;
			}
			gm.SetMessage("Select dice, then select card to activate or purchase.", "选择骰子，然后选择启动或者购买的卡牌。");
			gm.PlayCard(this);
			EnterPlay();
			gm.RemoveSelectedDice();
		}
	}

	public bool MatchSum(int sum, string type)
	{
		int num = 0;
		foreach (Dice item in gm.selected_dice)
		{
			num += item.val;
		}
		return type switch
		{
			"=" => num == sum, 
			"<=" => num <= sum, 
			">=" => num >= sum, 
			_ => false, 
		};
	}

	public void Prepare()
	{
		Debug.Log("Pre");
		Debug.Log(maxenergy);
		if (maxenergy > 0)
		{
			energy = maxenergy;
		}
		StartOfTurn();
	}

	public virtual void StartOfTurn()
	{
	}

	public virtual void CardSetUp()
	{
	}

	public virtual void Activate()
	{
	}

	public virtual void EnterPlay()
	{
	}

	public virtual void EndOfTurn()
	{
	}

	public virtual bool SpecialCost()
	{
		return true;
	}

	public virtual void WhenReroll()
	{
	}
}
