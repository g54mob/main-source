using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : Menu
{
	public List<Module> previewModules;

	public PerkDisplay previewPerk;

	public UIButton[] characterSelectButtons;

	public UIButton startButton;

	public SpriteRenderer difficultyText;

	public Sprite[] difficultyDescriptions;

	public SpriteRenderer menuItems;

	public SpriteRenderer difficultyNum;

	public UIButton prevDiff;

	public UIButton nextDiff;

	public Sprite[] lockedChracterSprites;

	private int difficulty;

	public GameObject diffBG;

	private int character;

	public static List<List<Module.Name>> startingKits = new List<List<Module.Name>>
	{
		new List<Module.Name>
		{
			Module.Name.Horizontal,
			Module.Name.Sword,
			Module.Name.Vertical
		},
		new List<Module.Name>
		{
			Module.Name.Bolt,
			Module.Name.ManaPot
		},
		new List<Module.Name>
		{
			Module.Name.Sword,
			Module.Name.Sword
		}
	};

	public static List<Perks.Type> startingPerks = new List<Perks.Type>
	{
		Perks.Type.Fortified,
		Perks.Type.Intellect,
		Perks.Type.Goblinized
	};

	public SpriteRenderer classSprite;

	public GameObject randomModuleObj;

	public SpriteRenderer select;

	public Sprite[] selectSprites;

	public Sprite lockedNextDiff;

	public Sprite nextDiffSprite;

	public SaveManager.GameSave saveData => Dungeon.Instance.saveManager.saveData;

	private void Start()
	{
		menuItems.sprite = Dungeon.Instance.currentLocale.newGameItems;
		startButton.SetSprite(Dungeon.Instance.currentLocale.newGameStart);
		difficulty = saveData.currDifficulty;
		character = saveData.currCharacter;
		CheckUnlocks();
		ChangeDifficulty(0, silent: true);
		ChangeCharacter(character, silent: true);
	}

	private void CheckUnlocks()
	{
		int num = 0;
		UIButton[] array = characterSelectButtons;
		foreach (UIButton uIButton in array)
		{
			if (num == 0)
			{
				num++;
				continue;
			}
			if (saveData.charUnlocks[num] && !Dungeon.Instance.demo)
			{
				num++;
				continue;
			}
			uIButton.locked = true;
			uIButton.bg.sprite = lockedChracterSprites[num];
			num++;
		}
	}

	public override void BounceButton(UIButton b, int f = 2, bool silent = false)
	{
		if (f == 1)
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f, 0.8f);
		}
		else
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.9f, 0.5f);
		}
		base.BounceButton(b, f, silent);
	}

	private void Update()
	{
		select.sortingOrder = characterSelectButtons[character].bg.sortingOrder + 1;
		select.transform.localPosition = new Vector3(0f, -0.0625f);
	}

	public void ChangeCharacter(int x, bool silent = false)
	{
		if (!saveData.charUnlocks[x])
		{
			return;
		}
		if (Dungeon.Instance.demo)
		{
			x = 0;
		}
		character = x;
		select.transform.parent = characterSelectButtons[x].transform;
		select.transform.position = base.transform.position;
		if (silent)
		{
			select.transform.position += new Vector3(0f, -0.0625f);
		}
		select.sprite = selectSprites[x];
		classSprite.sprite = Dungeon.Instance.currentLocale.newGameClasses[x];
		if (!silent)
		{
			StartCoroutine(jump(classSprite.gameObject));
		}
		foreach (Module previewModule in previewModules)
		{
			Object.Destroy(previewModule.gameObject);
		}
		previewModules.Clear();
		int num = 0;
		foreach (Module.Name item in startingKits[character])
		{
			Module component = Object.Instantiate((character == 2) ? randomModuleObj : Dungeon.Instance.moduleObjects[(int)item]).GetComponent<Module>();
			if (!Dungeon.Instance.saveData.collection.Contains(component.name))
			{
				Dungeon.Instance.saveData.collection.Add(component.name);
			}
			component.SetPreview();
			previewModules.Add(component);
			component.transform.parent = base.transform;
			if (startingKits[character].Count == 2)
			{
				component.transform.localPosition = new Vector3(4.875f + (float)num * 56f / 16f, 2.3125f, 0f);
			}
			else
			{
				component.transform.localPosition = new Vector3(3.125f + (float)num * 56f / 16f, 2.3125f, 0f);
			}
			component.transform.localScale = Vector3.zero;
			if (!silent)
			{
				StartCoroutine(jump(component.gameObject));
			}
			num++;
		}
		previewPerk.Set(startingPerks[character]);
		if (!silent)
		{
			StartCoroutine(jump(previewPerk.gameObject));
		}
		if (saveData.currCharacter != character)
		{
			saveData.currCharacter = character;
			Dungeon.Instance.saveManager.SaveGame();
		}
	}

	public void ChangeDifficulty(int x, bool silent = false)
	{
		difficulty = Mathf.Clamp(difficulty + x, 0, 4);
		difficultyText.sprite = Dungeon.Instance.currentLocale.newGameDifficultyDesc[difficulty];
		difficultyNum.sprite = Dungeon.Instance.currentLocale.newGameDifficultyTitle[difficulty];
		nextDiff.transform.localScale = Vector3.one;
		nextDiff.locked = false;
		nextDiff.bg.sprite = nextDiffSprite;
		prevDiff.transform.localScale = Vector3.one;
		if (difficulty == 4 || difficulty >= saveData.maxDiffUnlock)
		{
			nextDiff.transform.localScale = Vector3.zero;
			if (difficulty < 4)
			{
				nextDiff.transform.localScale = Vector3.one;
				nextDiff.bg.sprite = lockedNextDiff;
				nextDiff.locked = true;
			}
		}
		if (difficulty == 0)
		{
			prevDiff.transform.localScale = Vector3.zero;
		}
		if (!silent)
		{
			StartCoroutine(jump(diffBG, 1));
		}
		if (saveData.currDifficulty != difficulty)
		{
			saveData.currDifficulty = difficulty;
			Dungeon.Instance.saveManager.SaveGame();
		}
	}

	private IEnumerator jump(GameObject b, int f = 2)
	{
		bool sorter = true;
		if (Dungeon.Instance.mainmenu.anim != Mainmenu.animState.None)
		{
			sorter = false;
		}
		if (sorter)
		{
			SpriteRenderer[] componentsInChildren = b.GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].sortingOrder += 10;
			}
		}
		for (int j = 0; j < f; j++)
		{
			b.transform.localPosition += new Vector3(0f, 0.0625f);
			yield return AnimationManager.WaitUI(1);
		}
		for (int j = 0; j < f; j++)
		{
			yield return AnimationManager.WaitUI(1);
			b.transform.localPosition -= new Vector3(0f, 0.0625f);
		}
		if (sorter)
		{
			SpriteRenderer[] componentsInChildren = b.GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].sortingOrder += -10;
			}
		}
	}
}
