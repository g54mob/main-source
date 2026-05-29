using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
	public bool testMode;

	public MiniGameState state;

	public int maxDice = 4;

	public int mod;

	public int round;

	public int max_round;

	public int vp;

	public int maxProject = 3;

	public GameObject card_back;

	public GameObject help_panel;

	public GameObject dice_prefab;

	public GridLayoutGroup blueprint_layout;

	public GridLayoutGroup project_layout;

	public GridLayoutGroup colony_layout;

	public GridLayoutGroup dice_layout;

	public GridLayoutGroup dice_preserve_layout;

	public List<Dice> dice;

	public List<Dice> preserved_dice;

	public List<Dice> selected_dice;

	public List<Card> played_card;

	public List<Card> blueprint;

	public List<Card> project;

	public List<GameObject> blueprint_deck;

	public List<GameObject> blueprint_deck0;

	public List<GameObject> project_deck;

	public List<GameObject> headquarter_deck;

	public int cardPurchase_cnt;

	public TMP_Text game_info_txt;

	public string message = "Welcome to Mars";

	public int language;

	public TMP_Text mod_txt;

	public GameObject mod_power;

	public List<string> ability;

	public GlobalManager gm;

	private void Start()
	{
		gm = Object.FindObjectOfType<GlobalManager>();
		if (gm != null)
		{
			language = gm.setting.language;
			if (gm.setting.language == 3)
			{
				language = 0;
			}
		}
		if (testMode)
		{
			maxDice = 10;
			mod = 100;
			max_round = 100;
		}
		mod_power.gameObject.SetActive(value: false);
		blueprint_deck.Clear();
		headquarter_deck.Clear();
		project_deck.Clear();
		GameObject[] array = Resources.LoadAll<GameObject>("MiniGame/Blueprint");
		foreach (GameObject item in array)
		{
			blueprint_deck.Add(item);
		}
		array = Resources.LoadAll<GameObject>("MiniGame/Head");
		foreach (GameObject item2 in array)
		{
			headquarter_deck.Add(item2);
		}
		array = Resources.LoadAll<GameObject>("MiniGame/Project");
		foreach (GameObject item3 in array)
		{
			project_deck.Add(item3);
		}
		SetMessage("Mini Game: A must-have for a programming game.", "小游戏：编程游戏的必需品。");
		help_panel.SetActive(value: false);
		blueprint_deck0 = new List<GameObject>();
		foreach (GameObject item4 in blueprint_deck)
		{
			blueprint_deck0.Add(item4);
		}
	}

	public void SetMessage(string en, string zh)
	{
		if (language == 0)
		{
			message = en;
		}
		else
		{
			message = zh;
		}
	}

	private void Update()
	{
		if (language == 0)
		{
			game_info_txt.text = "Pangu Project: The Dice Game\nRound: " + round + "/" + max_round + "   Score: " + vp + "\n<u><link=pass>Pass</link></u>     <u><link=rules>Rules</link></u>     <u><link=quit>Quit</link></u>\n" + message;
		}
		else
		{
			game_info_txt.text = "盘古计划：骰子游戏\n回合: " + round + "/" + max_round + "   得分: " + vp + "\n<u><link=pass>结束回合</link></u>     <u><link=rules>规则</link></u>     <u><link=quit>退出</link></u>\n" + message;
			if (language == 2)
			{
				game_info_txt.text = gm.ToChineseTraditional(game_info_txt.text);
			}
		}
		mod_txt.text = mod.ToString();
		if (state == MiniGameState.BeforeGame)
		{
			if (language == 0)
			{
				game_info_txt.text = "Pangu Project: The Dice Game\n\n<u><link=newgame>New Game</link></u>     <u><link=rules>Rules</link></u>     <u><link=quit>Quit</link></u>\n" + message;
			}
			else
			{
				game_info_txt.text = "盘古计划：骰子游戏\n\n<u><link=newgame>新游戏</link></u>     <u><link=rules>规则</link></u>     <u><link=quit>退出</link></u>\n" + message;
			}
			if (language == 2)
			{
				game_info_txt.text = gm.ToChineseTraditional(game_info_txt.text);
			}
		}
		if (state == MiniGameState.GameStart)
		{
			state = MiniGameState.Prepare;
		}
		else if (state == MiniGameState.Prepare)
		{
			RoundStart();
			state = MiniGameState.Action;
			SetMessage("Select dice, then select card to activate or purchase.", "选择骰子，然后选择启动或者购买的卡牌。");
		}
		if (state == MiniGameState.EndGame)
		{
			if (project.Count == 0)
			{
				SetMessage("All projects completed. You win.", "已建设所有计划。你赢了。");
			}
			else if (project.Count == 1)
			{
				SetMessage("Game over. 1 project remains.", "游戏结束。剩余1个计划。");
			}
			else if (project.Count == 2)
			{
				SetMessage("Game over. 2 projects remain.", "游戏结束。剩余2个计划。");
			}
			else if (project.Count == 3)
			{
				SetMessage("Game over. 3 projects remain.", "游戏结束。剩余3个计划。");
			}
			if (language == 0)
			{
				game_info_txt.text = "Pangu Project: The Dice Game\nRound: " + (round - 1) + "/" + max_round + "   Score: " + vp + "\n<u><link=newgame>New Game</link></u>     <u><link=rules>Rules</link></u>     <u><link=quit>Quit</link></u>\n" + message;
			}
			else
			{
				game_info_txt.text = "盘古计划：骰子游戏\n回合: " + (round - 1) + "/" + max_round + "   得分: " + vp + "\n<u><link=newgame>新游戏</link></u>     <u><link=rules>规则</link></u>     <u><link=quit>退出</link></u>\n" + message;
			}
			if (language == 2)
			{
				game_info_txt.text = gm.ToChineseTraditional(game_info_txt.text);
			}
		}
		if (help_panel.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
		{
			help_panel.SetActive(value: false);
		}
	}

	public void AddBlueprint()
	{
		if (blueprint.Count > 10)
		{
			mod++;
			return;
		}
		if (ability.Contains("University"))
		{
			Object.FindObjectOfType<University>().special_num++;
			Object.FindObjectOfType<University>().Shine();
		}
		int index = Random.Range(0, blueprint_deck.Count);
		GameObject obj = Object.Instantiate(blueprint_deck[index]);
		blueprint_deck.Remove(blueprint_deck[index]);
		Card component = obj.GetComponent<Card>();
		obj.transform.SetParent(blueprint_layout.transform);
		blueprint.Add(component);
		component.inPlay = false;
	}

	public void DrawProject()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < maxProject; i++)
		{
			int num;
			do
			{
				num = Random.Range(0, project_deck.Count);
			}
			while (list.Contains(num));
			list.Add(num);
			GameObject obj = Object.Instantiate(project_deck[num]);
			Card component = obj.GetComponent<Card>();
			obj.transform.SetParent(project_layout.transform);
			project.Add(component);
			component.inPlay = false;
		}
	}

	public void NewGame()
	{
		Card[] array = Object.FindObjectsOfType<Card>();
		for (int i = 0; i < array.Length; i++)
		{
			Object.Destroy(array[i].gameObject);
		}
		Dice[] array2 = Object.FindObjectsOfType<Dice>();
		for (int i = 0; i < array2.Length; i++)
		{
			Object.Destroy(array2[i].gameObject);
		}
		played_card.Clear();
		project.Clear();
		blueprint.Clear();
		dice.Clear();
		preserved_dice.Clear();
		blueprint_deck = new List<GameObject>();
		foreach (GameObject item in blueprint_deck0)
		{
			blueprint_deck.Add(item);
		}
		foreach (GameObject item2 in headquarter_deck)
		{
			Card component = Object.Instantiate(item2).GetComponent<Card>();
			component.transform.SetParent(colony_layout.transform);
			component.inPlay = true;
			played_card.Add(component);
		}
		round = 1;
		mod = 0;
		maxDice = 4;
		vp = 0;
		state = MiniGameState.GameStart;
		mod_power.gameObject.SetActive(value: true);
		AddBlueprint();
		AddBlueprint();
		AddBlueprint();
		DrawProject();
		if (testMode)
		{
			maxDice = 10;
			mod = 100;
			max_round = 100;
		}
		ability = new List<string>();
	}

	public void RoundStart()
	{
		for (int i = 0; i < maxDice; i++)
		{
			GenerateDice(0, DiceType.Basic, preserve: false);
		}
		foreach (Card item in played_card)
		{
			item.Prepare();
		}
		AddBlueprint();
		cardPurchase_cnt = 0;
	}

	public void GenerateDice(int val, DiceType tt, bool preserve)
	{
		if (val > 6)
		{
			val = 6;
		}
		if (val < 0)
		{
			val = 0;
		}
		GameObject gameObject = Object.Instantiate(dice_prefab);
		Dice component = gameObject.GetComponent<Dice>();
		if (preserve)
		{
			gameObject.transform.SetParent(dice_preserve_layout.transform);
			preserved_dice.Add(component);
		}
		else
		{
			gameObject.transform.SetParent(dice_layout.transform);
			dice.Add(component);
		}
		component.diceType = tt;
		component.val = val;
		component.isPreserved = preserve;
		if (val == 0)
		{
			component.Reroll();
		}
	}

	public void RoundEnd()
	{
		if (state != MiniGameState.Action)
		{
			return;
		}
		foreach (Card item in played_card)
		{
			item.EndOfTurn();
		}
		foreach (Dice die in dice)
		{
			Object.Destroy(die.gameObject);
		}
		dice.Clear();
		foreach (Dice item2 in preserved_dice)
		{
			item2.Select(s: false);
		}
		selected_dice.Clear();
		round++;
		state = MiniGameState.Prepare;
		if (round <= max_round && project.Count != 0)
		{
			return;
		}
		state = MiniGameState.EndGame;
		if (project.Count == 0)
		{
			Debug.Log("Unlock Pangu!");
			gm.steamManager.UnlockAchievements("pangu");
			if (vp >= 40)
			{
				gm.steamManager.UnlockAchievements("pangu40");
			}
		}
	}

	public void RemoveSelectedDice()
	{
		foreach (Dice item in selected_dice)
		{
			if (ability.Contains("recycling") && item.diceType == DiceType.Wild)
			{
				Object.FindObjectOfType<Recycling>().special_num++;
				Object.FindObjectOfType<Recycling>().Shine();
			}
			if (item.isPreserved)
			{
				preserved_dice.Remove(item);
			}
			else
			{
				dice.Remove(item);
			}
			Object.Destroy(item.gameObject);
		}
		selected_dice.Clear();
	}

	public void UnselectAllDice()
	{
		foreach (Dice die in dice)
		{
			if (die.select)
			{
				die.Select(s: false);
			}
		}
		foreach (Dice item in preserved_dice)
		{
			if (item.select)
			{
				item.Select(s: false);
			}
		}
	}

	public void PlayCard(Card c)
	{
		c.transform.parent = colony_layout.transform;
		c.inPlay = true;
		if (blueprint.Contains(c))
		{
			vp++;
		}
		else
		{
			vp += (max_round - round) * 3 + 4;
		}
		blueprint.Remove(c);
		project.Remove(c);
		played_card.Add(c);
		cardPurchase_cnt++;
	}

	public void ShowRules()
	{
		if (gm.setting.language == 0)
		{
			gm.OpenPDF("PanguProject.pdf");
		}
		else if (gm.setting.language == 1)
		{
			gm.OpenPDF("Pangu_CHS.pdf");
		}
		else if (gm.setting.language == 2)
		{
			gm.OpenPDF("Pangu_CHT.pdf");
		}
	}

	public void Quit()
	{
		SceneManager.LoadScene(0);
	}

	public void WhenReroll()
	{
		foreach (Card item in played_card)
		{
			item.WhenReroll();
		}
	}

	public void Plus()
	{
		if (state == MiniGameState.Action)
		{
			if (selected_dice.Count != 1)
			{
				SetMessage("Select exactly 1 die to modify value.", "修改点数时必须恰好选择一个骰子");
			}
			else
			{
				selected_dice[0].Plus();
			}
		}
	}

	public void Minus()
	{
		if (state == MiniGameState.Action)
		{
			if (selected_dice.Count != 1)
			{
				SetMessage("Select exactly 1 die to modify value.", "修改点数时必须恰好选择一个骰子");
			}
			else
			{
				selected_dice[0].Minus();
			}
		}
	}
}
