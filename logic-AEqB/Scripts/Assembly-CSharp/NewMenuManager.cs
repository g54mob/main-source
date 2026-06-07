using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMenuManager : MonoBehaviour
{
	public object[] common_functions;

	public object[] task_functions;

	public object[] levels;

	public GlobalManager g;

	public GameObject button;

	public GameObject grid;

	public GameObject[] grids;

	public GameObject grid_row;

	public int[,] test;

	public TMP_Text chapter;

	public TMP_Text display;

	public List<KeyValuePair<string, string>>[] chapter_string;

	public Camera colored_cam;

	public Image[] img_all;

	public TMP_Text[] text_all;

	public TMP_Text[] text_anticolor;

	public TMP_Text title_txt;

	public Scrollbar display_scroll;

	public Image backrect;

	private bool firstframe = true;

	private bool isWorkshop;

	private float dt;

	private int[] level_to_solve = new int[7] { 0, 4, 5, 4, 9, 4, 2 };

	public void DarkTheme(bool isDark)
	{
		Color color;
		Color color2;
		if (isDark)
		{
			color = Color.white;
			color2 = Color.black;
			backrect.gameObject.SetActive(value: true);
		}
		else
		{
			color = Color.black;
			color2 = Color.white;
			backrect.gameObject.SetActive(value: false);
		}
		Image[] array = img_all;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = color2;
		}
		TMP_Text[] array2 = text_all;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].color = color;
		}
	}

	private void Start()
	{
		g = UnityEngine.Object.FindObjectOfType<GlobalManager>();
		if (g == null)
		{
			Debug.Log("hello");
			GameObject gameObject = new GameObject();
			gameObject.AddComponent<GlobalManager>();
			g = gameObject.GetComponent<GlobalManager>();
			g.Load();
			g.Init();
		}
		if (DateTime.Today.Month == 4 && DateTime.Today.Day == 1)
		{
			title_txt.text = "A = B: B One-Instruction Esolbng";
		}
		chapter_string = new List<KeyValuePair<string, string>>[20];
		for (int i = 0; i < 20; i++)
		{
			chapter_string[i] = new List<KeyValuePair<string, string>>();
		}
		foreach (short_level_info level in g.levels)
		{
			chapter_string[level.chapter].Add(new KeyValuePair<string, string>(level.id, level.title_en));
		}
		DarkTheme(g.setting.theme);
		SetLanguage();
		switch (g.setting.fullscreen)
		{
		case 0:
			Screen.fullScreen = true;
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullscreen: true);
			break;
		case 1:
			Screen.fullScreen = false;
			Screen.SetResolution(1280, 720, fullscreen: false);
			break;
		case 2:
			Screen.fullScreen = false;
			Screen.SetResolution(1600, 900, fullscreen: false);
			break;
		}
		display.fontSize = chapter.fontSize;
		g.sandbox = false;
		Canvas.ForceUpdateCanvases();
	}

	private void Update()
	{
		display.fontSize = chapter.fontSize;
		if (firstframe)
		{
			if (g.setting.last_chapter != 0)
			{
				ChangeDisplay(g.setting.last_chapter);
			}
			firstframe = false;
		}
		if (!display.text.Contains("workshop"))
		{
			isWorkshop = false;
		}
		if (isWorkshop)
		{
			if (dt >= 5f)
			{
				dt = 0f;
				g.RefreshWorkshop();
				ChangeDisplay(8);
			}
			dt += Time.deltaTime;
		}
	}

	public void ChangeDisplay(int n)
	{
		string text = "";
		if (n > 10)
		{
			n = 10;
		}
		if (n < 1)
		{
			n = 1;
		}
		isWorkshop = false;
		g.setting.last_chapter = n;
		foreach (KeyValuePair<string, string> item in chapter_string[n])
		{
			string text2 = "";
			int num = 0;
			foreach (short_level_info level in g.levels)
			{
				if (!(item.Key == level.id))
				{
					continue;
				}
				if (g.setting.language == 1)
				{
					text2 = level.title_ch;
					if (level.title_ch == "")
					{
						text2 = level.title_en;
					}
				}
				else if (g.setting.language == 2)
				{
					text2 = level.title_cht;
					if (level.title_cht == "")
					{
						text2 = level.title_en;
					}
				}
				else if (g.setting.language == 3)
				{
					text2 = level.title_jp;
					if (level.title_jp == "")
					{
						text2 = level.title_en;
					}
				}
				else
				{
					text2 = level.title_en;
				}
				num = level.line;
			}
			if (g.solved.Contains(item.Key))
			{
				save_info save_info2 = new save_info("", s: false, -1, ch: false, -1);
				for (int i = 0; i < g.sv.data.Count; i++)
				{
					if (g.sv.data[i].id == item.Key)
					{
						save_info2 = g.sv.data[i];
					}
				}
				text = ((save_info2.challenge_line <= 0) ? (text + "<u><color=#7f7f7f><link=" + item.Key + ">" + text2 + "</link></color></u>\n") : (text + "<u><color=#7f7f7f><link=" + item.Key + ">" + text2 + " (" + save_info2.challenge_line + "/" + num + ")</link></color></u>\n"));
			}
			else
			{
				text = ((!g.sv.story.Contains(item.Key)) ? (text + "<u><link=" + item.Key + ">" + text2 + "</link></u>\n") : (text + "<u><color=#7f7f7f><link=" + item.Key + ">" + text2 + "</link></color></u>\n"));
			}
		}
		if (n == 7)
		{
			if (g.setting.language == 1)
			{
				text += "<u><link=panguproject>盘古计划</link></u>";
			}
			if (g.setting.language == 0)
			{
				text += "<u><link=panguproject>Pangu Project</link></u>";
			}
			if (g.setting.language == 2)
			{
				text += "<u><link=panguproject>盤古計畫</link></u>";
			}
			if (g.setting.language == 3)
			{
				text += "<u><link=panguproject>Pangu Project</link></u>";
			}
		}
		if (n == 8)
		{
			text = "My Custom Levels\n";
			for (int j = 0; j < g.custom_levels.Count; j++)
			{
				if (g.custom_levels[j].output != null && g.custom_levels[j].output.Count != 0)
				{
					text = text + "<u><link=X" + j + ">" + g.custom_levels[j].title_en + "</link></u>\n";
				}
			}
			text += "\nWorkshop Levels\n";
			text += "<u><link=url>https://steamcommunity.com/app/1720850/workshop/</link></u>\n";
			text += "If your subscribed items don't show up here, please relaunch the game.\n\n";
			for (int k = 0; k < g.custom_levels_workshop.Count; k++)
			{
				if (g.custom_levels_workshop[k].output != null && g.custom_levels_workshop[k].output.Count != 0)
				{
					text = text + "<u><link=Y" + k + ">" + g.custom_levels_workshop[k].title_en + "</link></u>\n";
				}
			}
			isWorkshop = true;
		}
		if (n == 9)
		{
			text = "<u><link=editor>New Custom Level</link></u>\n\n";
			for (int l = 0; l < g.custom_levels.Count; l++)
			{
				text = text + "<u><link=Z" + l + ">" + g.custom_levels[l].title_en + "</link></u>\n";
			}
		}
		if (display.text != text)
		{
			display.text = text;
			Canvas.ForceUpdateCanvases();
			display_scroll.value = g.LastScrollPos;
			g.LastScrollPos = 1f;
		}
	}

	public void ShowStory(short_level_info lv)
	{
		g.setting.last_chapter = lv.chapter;
		g.StoryRead(lv.id);
		if (g.setting.language == 1)
		{
			display.text = lv.story_ch + "\n\n<u><link=return>返回</link></u>";
		}
		else if (g.setting.language == 2)
		{
			display.text = lv.story_cht + "\n\n<u><link=return>返回</link></u>";
		}
		else if (g.setting.language == 3)
		{
			display.text = lv.story_jp + "\n\n<u><link=return>戻る</link></u>";
		}
		else
		{
			display.text = lv.story_en + "\n\n<u><link=return>Return</link></u>";
		}
	}

	public void About()
	{
		if (g.setting.language == 1)
		{
			display.text = "本作纯属虚构。与真实人物、组织或者事件的相似之处均属巧合。\n请勿用本游戏提到的编程语言或者其他esolang作为你的编译原理作业，否则后果自负。\n\n开发：没有美术游戏\n\n测试：\n笨蛋⑨ Erzählung. 硫化氢\n落叶子 墨鱼 Morphling\nsevenkplus 水平的忧郁 sky\nTheChickenleg weiyun 香蕉三千\n小大圣 小对对 小汤圆\n星海 牙刷架 游T戏G农A民\n感谢napier(ねーぴあ)和YUPI提供的未预期解\n感谢Bretty Lowey (BrainGoodGames）对盘古计划的建议\n\n灵感来源：\nManufactoria\nQueries 'n Theories\nZachtronics的作品, 特别是TIS-100 和 Shenzhen I/O\n\n盘古计划的灵感来源：\nTo Court the King\nRolling In The Reefs\nYahtzee\nTerraforming Mars\n\n音乐（宣传片）：\nEnvision.mp3 - Kevin MacLeod (incompetech.com)\n\n日语翻译: HAC (@tigerauge0) competor (@GugenTV)\n\n特别感谢：\n编译原理\n自动机理论、语言和计算导论\n清华大学\n一刻馆桌游\n\n相似的项目:\nMarkov Algorithm Online (mao.snuke.org)\nThue\n\n我承诺a=b是一个原创作品。在开发过程中没有参考过相似的项目。\n\n联系方式:\nDiscord: <u><link=url>https://discord.com/invite/UfZuFfeXum</link></u>\nTwitter: <u><link=url>https://twitter.com/artless_games/</link></u>";
		}
		else if (g.setting.language == 2)
		{
			display.text = "本作純屬虛構。與真實人物、組織或者事件的相似之處均屬巧合。\n請勿用本遊戲提到的程式語言或者其他esolang作為你的編譯原理作業，否則後果自負。\n\n開發：沒有美術遊戲\n\n測試：\n笨蛋⑨ Erzählung. 硫化氢\n落叶子 墨鱼 Morphling\nsevenkplus 水平的忧郁 sky\nTheChickenleg weiyun 香蕉三千\n小大圣 小对对 小汤圆\n星海 牙刷架 游T戏G农A民\n感謝napier(ねーぴあ)和YUPI提供的未預期解\n感謝Bretty Lowey (BrainGoodGames）對盤古計畫的建議\n\n靈感來源：\nManufactoria\nQueries 'n Theories\nZachtronics的作品, 特別是TIS-100 和 Shenzhen I/O\n\n盤古計畫的靈感來源：\nTo Court the King\nRolling In The Reefs\nYahtzee\nTerraforming Mars\n\n音樂（宣傳片）：\nEnvision.mp3 - Kevin MacLeod (incompetech.com)\n\n日語翻譯: HAC (@tigerauge0) competor (@GugenTV)\n\n特別感謝：\n編譯原理\n自動機理論、語言和計算導論\n清華大學\n一刻館桌遊\n\n相似的項目:\nMarkov Algorithm Online (mao.snuke.org)\nThue\n\n我承諾a=b是一個原創作品。在開發過程中沒有參考過相似的項目。\n\n聯繫方式:\nDiscord: <u><link=url>https://discord.com/invite/UfZuFfeXum</link></u>\nTwitter: <u><link=url>https://twitter.com/artless_games/</link></u>";
		}
		else if (g.setting.language == 3)
		{
			display.text = "この作品はフィクションです。実在の人物、組織、出来事などとの類似性は、まったくの偶然です。\n\n開發：Artless Games\n\nテスト:\n笨蛋⑨ Erzählung. 硫化氢\n落叶子 墨鱼 Morphling\nsevenkplus 水平的忧郁 sky\nTheChickenleg weiyun 香蕉三千\n小大圣 小对对 小汤圆\n星海 牙刷架 游T戏G农A民\nAnd thank napier(ねーぴあ) and YUPI for their unexpected solutions\nBretty Lowey (BrainGoodGames) for their suggestion to Pangu Project\n\nインスピレーションの源:\nManufactoria\nQueries 'n Theories\nZachtronics' games, notably TIS-100 and Shenzhen I/O\n\nPangu Project is inspired by:\nTo Court the King\nRolling In The Reefs\nYahtzee\nTerraforming Mars\n\n音楽：\nEnvision.mp3 - Kevin MacLeod (incompetech.com)\n\n日本語翻譯: HAC (@tigerauge0) competor (@GugenTV)\n\n以下の方々に感謝します：\nコンパイルの原則\nオートマトン理論、言語と計算概要\n清華大學\nOne Moment Games\n\n同じような項目:\nMarkov Algorithm Online (mao.snuke.org)\nThue\n\na=bはオリジナル作品であることを約束します。開発過程で似たような項目を参考にしたことはありません。\n\n連絡：\nDiscord: <u><link=url>https://discord.com/invite/UfZuFfeXum</link></u>\nTwitter: <u><link=url>https://twitter.com/artless_games/</link></u>";
		}
		else
		{
			display.text = "This is a work of fiction. Any similarity to actual persons, organizations, or events, is purely coincidental.\nDo not try to submit an esolang as your Compiler Principle course project, or you will be responsible for the consequences.\n\nDevelopment: Artless Games\n\nPlaytest：\n笨蛋⑨ Erzählung. 硫化氢\n落叶子 墨鱼 Morphling\nsevenkplus 水平的忧郁 sky\nTheChickenleg weiyun 香蕉三千\n小大圣 小对对 小汤圆\n星海 牙刷架 游T戏G农A民\nAnd thank napier(ねーぴあ) and YUPI for their unexpected solutions\nBretty Lowey (BrainGoodGames) for their suggestion to Pangu Project\n\nInspired by:\nManufactoria\nQueries 'n Theories\nZachtronics' games, notably TIS-100 and Shenzhen I/O\n\nPangu Project is inspired by:\nTo Court the King\nRolling In The Reefs\nYahtzee\nTerraforming Mars\n\nMusic (Trailer):\nEnvision.mp3 - Kevin MacLeod (incompetech.com)\n\nJapanese Translation: HAC (@tigerauge0) competor (@GugenTV)\n\nSpecial Thanks:\nCompilers: Principle, Techniques and Tools\nIntroduction to Automata Theory, Languages, and Computation\nTsinghua University\nOne Moment Games\n\nSimilar Projects:\nMarkov Algorithm Online (mao.snuke.org)\nThue\n\nI promise A=B is an original work. No similar projects were referenced during development.\n\nContact me at:\nDiscord: <u><link=url>https://discord.com/invite/UfZuFfeXum</link></u>\nTwitter: <u><link=url>https://twitter.com/artless_games/</link></u>";
		}
	}

	public void Contact()
	{
		display.text = "Discord: <u><link=url>https://discord.com/invite/UfZuFfeXum</link></u>\nTwitter: <u><link=url>https://twitter.com/artless_games/</link></u>\nBilibili: <u><link=url>https://space.bilibili.com/1237125233</link></u>";
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Setting()
	{
		if (g.setting.language == 1 || g.setting.language == 2)
		{
			string text = "";
			if (g.setting.language == 0)
			{
				text += "语言: <link=en><u>English</u></link> <link=zh>简体中文</link> <link=cht>繁体中文</link> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 2)
			{
				text += "语言: <link=en>English</link> <link=zh>简体中文</link> <u><link=cht>繁体中文</link></u> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 1)
			{
				text += "语言: <link=en>English</link> <u><link=zh>简体中文</link></u> <link=cht>繁体中文</link> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 3)
			{
				text += "语言: <link=en>English</link> <link=zh>简体中文</link> <link=cht>繁体中文</link> <u><link=jp>日本語</link></u>\n";
			}
			text = (g.setting.theme ? (text + "主题: <link=light>亮</link> <link=dark><u>暗</u></link>\n") : (text + "主题: <link=light><u>亮</u></link> <link=dark>暗</link>\n"));
			if (g.setting.saveslot == 0)
			{
				text += "存档槽: <link=save1><u>1</u></link> <link=save2>2</link> <link=save3>3</link>\n";
			}
			if (g.setting.saveslot == 1)
			{
				text += "存档槽: <link=save1>1</link> <link=save2><u>2</u></link> <link=save3>3</link>\n";
			}
			if (g.setting.saveslot == 2)
			{
				text += "存档槽: <link=save1>1</link> <link=save2>2</link> <link=save3><u>3</u></link>\n";
			}
			if (g.setting.fullscreen == 0)
			{
				text += "显示：<link=fullscreen><u>全屏</u></link> <link=windowed>1280*720</link> <link=windowed2>1600*900</link>\n";
			}
			if (g.setting.fullscreen == 1)
			{
				text += "显示：<link=fullscreen>全屏</link> <link=windowed><u>1280*720</u></link> <link=windowed2>1600*900</link>\n";
			}
			if (g.setting.fullscreen == 2)
			{
				text += "显示：<link=fullscreen>全屏</link> <link=windowed>1280*720</link> <link=windowed2><u>1600*900</u></link>\n";
			}
			if (g.setting.language == 2)
			{
				text = g.ToChineseTraditional(text);
			}
			display.text = text;
		}
		else if (g.setting.language == 3)
		{
			string text2 = "";
			if (g.setting.language == 0)
			{
				text2 += "言語: <link=en><u>English</u></link> <link=zh>简体中文</link> <link=cht>繁体中文</link> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 2)
			{
				text2 += "言語: <link=en>English</link> <link=zh>简体中文</link> <u><link=cht>繁体中文</link></u> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 1)
			{
				text2 += "言語: <link=en>English</link> <u><link=zh>简体中文</link></u> <link=cht>繁体中文</link> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 3)
			{
				text2 += "言語: <link=en>English</link> <link=zh>简体中文</link> <link=cht>繁体中文</link> <u><link=jp>日本語</link></u>\n";
			}
			text2 = (g.setting.theme ? (text2 + "テーマ: <link=light>ライト</link> <link=dark><u>ダーク</u></link>\n") : (text2 + "テーマ: <link=light><u>ライト</u></link> <link=dark>ダーク</link>\n"));
			if (g.setting.saveslot == 0)
			{
				text2 += "保存スロット: <link=save1><u>1</u></link> <link=save2>2</link> <link=save3>3</link>\n";
			}
			if (g.setting.saveslot == 1)
			{
				text2 += "保存スロット: <link=save1>1</link> <link=save2><u>2</u></link> <link=save3>3</link>\n";
			}
			if (g.setting.saveslot == 2)
			{
				text2 += "保存スロット: <link=save1>1</link> <link=save2>2</link> <link=save3><u>3</u></link>\n";
			}
			if (g.setting.fullscreen == 0)
			{
				text2 += "解像度：<link=fullscreen><u>全画面</u></link> <link=windowed>1280*720</link> <link=windowed2>1600*900</link>\n";
			}
			if (g.setting.fullscreen == 1)
			{
				text2 += "解像度：<link=fullscreen>全画面</link> <link=windowed><u>1280*720</u></link> <link=windowed2>1600*900</link>\n";
			}
			if (g.setting.fullscreen == 2)
			{
				text2 += "解像度：<link=fullscreen>全画面</link> <link=windowed>1280*720</link> <link=windowed2><u>1600*900</u></link>\n";
			}
			display.text = text2;
		}
		else
		{
			string text3 = "";
			if (g.setting.language == 0)
			{
				text3 += "Language: <link=en><u>English</u></link> <link=zh>简体中文</link> <link=cht>繁体中文</link> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 2)
			{
				text3 += "Language: <link=en>English</link> <link=zh>简体中文</link> <u><link=cht>繁体中文</link></u> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 1)
			{
				text3 += "Language: <link=en>English</link> <u><link=zh>简体中文</link></u> <link=cht>繁体中文</link> <link=jp>日本語</link>\n";
			}
			else if (g.setting.language == 3)
			{
				text3 += "Language: <link=en>English</link> <link=zh>简体中文</link> <link=cht>繁体中文</link> <u><link=jp>日本語</link></u>\n";
			}
			text3 = (g.setting.theme ? (text3 + "Theme: <link=light>Light</link> <link=dark><u>Dark</u></link>\n") : (text3 + "Theme: <link=light><u>Light</u></link> <link=dark>Dark</link>\n"));
			if (g.setting.saveslot == 0)
			{
				text3 += "Save Slot: <link=save1><u>1</u></link> <link=save2>2</link> <link=save3>3</link>\n";
			}
			if (g.setting.saveslot == 1)
			{
				text3 += "Save Slot: <link=save1>1</link> <link=save2><u>2</u></link> <link=save3>3</link>\n";
			}
			if (g.setting.saveslot == 2)
			{
				text3 += "Save Slot: <link=save1>1</link> <link=save2>2</link> <link=save3><u>3</u></link>\n";
			}
			if (g.setting.fullscreen == 0)
			{
				text3 += "Display：<link=fullscreen><u>Fullscreen</u></link> <link=windowed>1280*720</link> <link=windowed2>1600*900</link>\n";
			}
			if (g.setting.fullscreen == 1)
			{
				text3 += "Display：<link=fullscreen>Fullscreen</link> <link=windowed><u>1280*720</u></link> <link=windowed2>1600*900</link>\n";
			}
			if (g.setting.fullscreen == 2)
			{
				text3 += "Display：<link=fullscreen>Fullscreen</link> <link=windowed>1280*720</link> <link=windowed2><u>1600*900</u></link>\n";
			}
			display.text = text3;
		}
		SetLanguage();
	}

	public void SetLanguage()
	{
		string text = "";
		int[] array = new int[10];
		foreach (string item in g.solved)
		{
			if (item[0] == 'c')
			{
				array[item[1] - 48]++;
			}
		}
		for (int i = 1; i <= 6; i++)
		{
			if (array[i - 1] >= level_to_solve[i - 1] || g.isDev)
			{
				if (i == 1)
				{
					text = ((g.setting.language == 1) ? (text + "<link=link1><u>A=B</u></link>\n") : ((g.setting.language == 2) ? (text + "<link=link1><u>A=B</u></link>\n") : ((g.setting.language != 3) ? (text + "<link=link1><u>A=B</u></link>\n") : (text + "<link=link1><u>A=B</u></link>\n"))));
				}
				if (i == 2)
				{
					text = ((g.setting.language == 1) ? (text + "<link=link2><u>关键字</u></link>\n") : ((g.setting.language == 2) ? (text + "<link=link2><u>關鍵字</u></link>\n") : ((g.setting.language != 3) ? (text + "<link=link2><u>Keyword</u></link>\n") : (text + "<link=link2><u>キーワード</u></link>\n"))));
				}
				if (i == 3)
				{
					text = ((g.setting.language == 1) ? (text + "<link=link3><u>首尾</u></link>\n") : ((g.setting.language == 2) ? (text + "<link=link3><u>首尾</u></link>\n") : ((g.setting.language != 3) ? (text + "<link=link3><u>Start and End</u></link>\n") : (text + "<link=link3><u>開始と終了</u></link>\n"))));
				}
				if (i == 4)
				{
					text = ((g.setting.language == 1) ? (text + "<link=link4><u>一次性</u></link>\n") : ((g.setting.language == 2) ? (text + "<link=link4><u>一次性</u></link>\n") : ((g.setting.language != 3) ? (text + "<link=link4><u>Once Upon A Time</u></link>\n") : (text + "<link=link4><u>一回</u></link>\n"))));
				}
				if (i == 5)
				{
					text = ((g.setting.language == 1) ? (text + "<link=link5><u>数学</u></link>\n") : ((g.setting.language == 2) ? (text + "<link=link5><u>數學</u></link>\n") : ((g.setting.language != 3) ? (text + "<link=link5><u>Math</u></link>\n") : (text + "<link=link5><u>数学</u></link>\n"))));
				}
				if (i == 6)
				{
					text = ((g.setting.language != 1) ? ((g.setting.language != 2) ? ((g.setting.language != 3) ? (text + "<link=link6><u>Aftermath</u></link>\n") : (text + "<link=link6><u>後日談</u></link>\n")) : (text + "<link=link6><u>後日談</u></link>\n")) : (text + "<link=link6><u>后日谈</u></link>\n"));
				}
			}
			else
			{
				text += "\n";
			}
		}
		text += "\n";
		text = ((g.setting.language == 1) ? (text + "<link=minigame><u>小游戏</u></link>\n<link=sandbox><u>沙盒</u></link>\n<link=editor_menu><u>关卡编辑器</u></link>\n<link=custom><u>自制关卡</u></link>\n\n<link=setting><u>设置</u></link>\n<link=about><u>关于本游戏</u></link>\n<link=quit><u>退出</u></link>") : ((g.setting.language == 2) ? (text + "<link=minigame><u>小遊戲</u></link>\n<link=sandbox><u>沙箱</u></link>\n<link=editor_menu><u>編輯器</u></link>\n<link=custom><u>自製關卡</u></link>\n\n<link=setting><u>設置</u></link>\n<link=about><u>關於本遊戲</u></link>\n<link=quit><u>退出</u></link>") : ((g.setting.language != 3) ? (text + "<link=minigame><u>Mini Game</u></link>\n<link=sandbox><u>Sandbox</u></link>\n<link=editor_menu><u>Level Editor</u></link>\n<link=custom><u>Custom Levels</u></link>\n\n<link=setting><u>Settings</u></link>\n<link=about><u>About This Game</u></link>\n<link=quit><u>Quit</u></link>") : (text + "<link=minigame><u>Mini Game</u></link>\n<link=sandbox><u>Sandbox</u></link>\n<link=editor_menu><u>Level Editor</u></link>\n<link=custom><u>Custom Levels</u></link>\n\n<link=setting><u>設定</u></link>\n<link=about><u>このゲームについて</u></link>\n<link=quit><u>終了</u></link>"))));
		chapter.text = text;
	}

	public void LoadLevel(string s)
	{
		foreach (short_level_info level in g.levels)
		{
			if (level.id == s)
			{
				if (level.story_en != "")
				{
					ShowStory(level);
				}
				else
				{
					g.ChooseLevel(level);
				}
			}
		}
	}

	public void ChangeLanguage(int language)
	{
		Setting();
		SetLanguage();
	}

	public void Pangu()
	{
		SceneManager.LoadScene(2);
	}
}
