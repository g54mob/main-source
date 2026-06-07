using System.Collections;
using TMPro;
using UnityEngine;

public class UIButton : MonoBehaviour
{
	public enum func
	{
		StartRound = 0,
		ToggleShop = 1,
		ToggleBoard = 2,
		MainmenuStart = 3,
		MainmenuOptions = 4,
		PerkSelect = 5,
		ShopReroll = 6,
		PauseGame = 7,
		UnpauseGame = 8,
		ResetScene = 9,
		ToggleFullscreen = 10,
		IncrementResolution = 11,
		Quit = 12,
		IncrementSFX = 13,
		EndlessMode = 14,
		ShopLock = 15,
		MainmenuState = 16,
		StartGame = 17,
		StartDifficulty = 18,
		StartCharacterSelect = 19,
		CollectionPage = 20,
		Credits = 21,
		Wishlist = 22,
		PerkSkip = 23,
		DPS = 24,
		ContinueRun = 25,
		AbandonRun = 26,
		ApplyResolution = 27,
		RevertResolution = 28,
		LanguageMenu = 29,
		SetLanguage = 30,
		Discord = 31,
		ToggleBank = 32,
		ToggleState = 33
	}

	public enum ColorPreset
	{
		grey = 0,
		black = 1
	}

	public AudioClip[] sounds;

	public SpriteRenderer bg;

	public TMP_Text text;

	public SpriteRenderer icon;

	public func f;

	public MonoBehaviour owner;

	public int data;

	public float floatData;

	public bool bounce;

	public bool menuBounce;

	public bool locked;

	private Vector2 buttonSize;

	public Dungeon dungeon => Dungeon.Instance;

	public BoxCollider2D hitbox => GetComponent<BoxCollider2D>();

	public void SetSprite(Sprite s)
	{
		bg.sprite = s;
	}

	private void Start()
	{
		buttonSize = GetComponent<BoxCollider2D>().size;
	}

	public void SetColor(ColorPreset c)
	{
		switch (c)
		{
		case ColorPreset.grey:
			SetColor(new Color(0.37f, 0.37f, 0.37f));
			break;
		case ColorPreset.black:
			SetColor(new Color(0.23f, 0.23f, 0.23f));
			break;
		}
	}

	public void SetColor(Color c)
	{
		Color.RGBToHSV(c, out var H, out var S, out var V);
		bg.color = c;
		icon.color = Color.HSVToRGB(H, S, V + 0.25f);
		text.color = Color.HSVToRGB(H, S, V + 0.25f);
	}

	public void Quit()
	{
		dungeon.mainmenu.QuitGame();
	}

	public void EndlessMode()
	{
		dungeon.StartEndless();
	}

	public void ToggleFullscreen()
	{
	}

	public void IncrementResolution()
	{
		owner.GetComponent<SettingsMenu>().IncrementResolution(1);
	}

	public void IncrementSFX()
	{
	}

	public void StartRound()
	{
		dungeon.StartRound();
	}

	public void ToggleShop()
	{
		dungeon.ToggleShop();
	}

	public void ToggleBank()
	{
		dungeon.ToggleBank();
	}

	public void ToggleState()
	{
		dungeon.ToggleState();
	}

	public void PerkSelect()
	{
		dungeon.perks.Select((Perks.Type)data, (int)floatData);
	}

	public void ShopReroll()
	{
		dungeon.shop.Restock(first: false);
	}

	public void ShopLock()
	{
		dungeon.shop.ToggleLock();
	}

	public void UnpauseGame()
	{
		dungeon.Unpause();
	}

	public void PauseGame()
	{
		dungeon.Pause();
	}

	public void ResetScene()
	{
		dungeon.ResetScene(data == 1);
	}

	public void MainmenuState()
	{
		owner.GetComponent<Mainmenu>().SetState((Mainmenu.State)data);
	}

	public void StartGame()
	{
		dungeon.mainmenu.StartGame();
	}

	public void Credits()
	{
		SteamManager.Jilsen();
	}

	public void Wishlist()
	{
		SteamManager.Wishlist();
	}

	public void Discord()
	{
		Application.OpenURL("https://discord.gg/UGcCn5D6XX");
	}

	public void PerkSkip()
	{
		dungeon.perks.Skip();
	}

	public void DPS()
	{
	}

	public void ContinueRun()
	{
		dungeon.mainmenu.StartGame(cont: true);
	}

	public void AbandonRun()
	{
		dungeon.mainmenu.AbandonRun();
	}

	public void StartDifficulty()
	{
		if (locked)
		{
			OnMouseEnter();
		}
		else
		{
			owner.GetComponent<StartMenu>().ChangeDifficulty(data);
		}
	}

	public void CollectionPage()
	{
		owner.GetComponent<CollectionMenu>().ChangePage(data);
	}

	public void StartCharacterSelect()
	{
		if (locked)
		{
			OnMouseEnter();
		}
		else
		{
			owner.GetComponent<StartMenu>().ChangeCharacter(data);
		}
	}

	public void ApplyResolution()
	{
		dungeon.mainmenu.ApplyRes();
	}

	public void RevertResolution()
	{
		dungeon.mainmenu.RevertRes();
	}

	public void LanguageMenu()
	{
		dungeon.mainmenu.ShowLangButtons();
	}

	public void SetLanguage()
	{
		dungeon.localizationManager.SetLang((SaveManager.Language)data);
	}

	private void OnMouseEnter()
	{
		if (!Application.isFocused)
		{
			return;
		}
		switch (f)
		{
		case func.StartCharacterSelect:
		{
			Vector3 customPos2 = base.transform.position + new Vector3(3.4375f + 51f * (float)data / 16f, 1.6875f, 0f) + new Vector3(-5f, 1.5f);
			(string, string, string) buttonTip2 = dungeon.localizationManager.GetButtonTip(f, data, locked);
			dungeon.tooltip.Set(null, showUpgrade: false, noUpgrade: false, null, buttonTip2.Item1, buttonTip2.Item2, customPos2, force: false, buttonTip2.Item3);
			break;
		}
		case func.StartDifficulty:
			if (locked)
			{
				Vector3 customPos5 = base.transform.position + new Vector3(-4.3125f, 1.5f);
				(string, string, string) buttonTip3 = dungeon.localizationManager.GetButtonTip(f, data, locked);
				dungeon.tooltip.Set(null, showUpgrade: false, noUpgrade: false, null, buttonTip3.Item1, buttonTip3.Item2, customPos5);
			}
			break;
		case func.Credits:
		{
			Vector3 customPos4 = base.transform.position + new Vector3(4.375f, 4.125f);
			string customDesc2 = "Design, GFX, SFX:\n[white]jilsen[/g]\nMusic:\n[white]Kevin Macleod[/g]\nLocalization (JP):\n[white]Pom-Cobbler[/g]";
			dungeon.localizationManager.tooltipEN.Set(null, showUpgrade: false, noUpgrade: false, null, "CREDITS", customDesc2, customPos4);
			break;
		}
		case func.Discord:
		{
			Vector3 customPos3 = base.transform.position + new Vector3(4.375f, 0.5f);
			string customDesc = "For all feedback\nand bug reports";
			dungeon.localizationManager.tooltipEN.Set(null, showUpgrade: false, noUpgrade: false, null, "DISCORD", customDesc, customPos3);
			break;
		}
		case func.ShopLock:
			dungeon.shop.ShowTip(base.transform.position);
			break;
		case func.ToggleState:
			if (dungeon.draggingModule == null)
			{
				(string, string, string) buttonTip = dungeon.localizationManager.GetButtonTip(f, data, locked);
				Vector3 customPos = base.transform.position + new Vector3(3.5625f, -11f / 32f);
				dungeon.tooltip.Set(null, showUpgrade: false, noUpgrade: false, null, buttonTip.Item1, buttonTip.Item2, customPos);
			}
			break;
		case func.DPS:
			dungeon.DPS.ShowDamage(base.transform.position + new Vector3(-4.5f, -0.85f));
			break;
		}
		if (!locked)
		{
			if (bounce)
			{
				Camera.main.GetComponentInChildren<AudioManager>().PlayUI_Randomized(AudioManager.Sound.UI_Button, 1f, 1.2f);
				StartCoroutine(bouncer());
			}
			if (menuBounce)
			{
				owner.GetComponent<Menu>().BounceButton(this, owner.GetComponent<Menu>().defaultButtonBounce);
			}
		}
	}

	private void OnMouseExit()
	{
		switch (f)
		{
		case func.ShopLock:
		case func.StartDifficulty:
		case func.StartCharacterSelect:
		case func.ToggleState:
			dungeon.tooltip.Hide();
			break;
		case func.Credits:
		case func.DPS:
		case func.Discord:
			dungeon.localizationManager.tooltipEN.Hide();
			break;
		default:
			dungeon.board.UnhighlightAll();
			break;
		}
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonUp(1) && f == func.IncrementResolution)
		{
			owner.GetComponent<SettingsMenu>().IncrementResolution(-1);
			owner.GetComponent<Menu>().BounceButton(this, 1);
		}
		if (f == func.PerkSelect)
		{
			dungeon.perks.Highlight((Perks.Type)data);
		}
	}

	private void OnMouseUpAsButton()
	{
		if (bounce && f != func.DPS)
		{
			Camera.main.GetComponentInChildren<AudioManager>().PlayUI_Randomized(AudioManager.Sound.UI_Button, 0.8f, 0.9f);
			StartCoroutine(bigBouncer(0.25f));
		}
		if (menuBounce)
		{
			owner.GetComponent<Menu>().BounceButton(this, 1);
		}
		Invoke(f.ToString(), 0f);
	}

	private IEnumerator bouncer(float amp = 0.1f)
	{
		if (base.name.Contains("perk"))
		{
			amp = 0.05f;
		}
		base.transform.localScale = Vector3.one * (1f + amp);
		dungeon.animationManager.LerpZoom(base.gameObject, Vector3.one, 8f, amp * 1f / 7f, destroy: false, UI: true);
		yield break;
	}

	private IEnumerator bigBouncer(float amp = 0.2f)
	{
		if (f != func.EndlessMode)
		{
			if (base.name.Contains("perk"))
			{
				amp = 0.1f;
			}
			base.transform.localScale = Vector3.one * (1f + amp);
			dungeon.animationManager.LerpZoom(base.gameObject, Vector3.one, 8f, amp * 1f / 7f, destroy: false, UI: true);
		}
		yield break;
	}
}
