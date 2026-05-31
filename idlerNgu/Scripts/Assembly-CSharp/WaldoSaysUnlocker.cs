using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WaldoSaysUnlocker : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Image waldo;

	public GameObject menu;

	public MenuSwapper menuSwapper;

	public int waldoTimer;

	public int currentMenu = -1;

	private float modx;

	private float mody;

	private float transparency = 0.1f;

	public int waldoRate()
	{
		return 1800;
	}

	private void Start()
	{
		InvokeRepeating("updateWaldo", 0f, 1f);
	}

	public void Update()
	{
		if (currentMenu != -1 && character.adventure.waldoFinds < 4 && character.adventure.waldoDefeats > character.adventure.waldoFinds && menu != null && transparency < 0.4f - (float)character.adventure.waldoFinds * 0.05f)
		{
			transparency += Mathf.Min(Time.deltaTime / 900f, 1f);
			waldo.transform.position = new Vector3(menu.transform.GetChild(0).transform.position.x + modx, menu.transform.GetChild(0).transform.position.y + mody);
			waldo.color = new Color(1f, 1f, 1f, transparency);
		}
		else
		{
			waldo.transform.position = new Vector3(-2000f, -200f);
			waldo.color = new Color(1f, 1f, 1f, 0f);
			waldoOff();
		}
	}

	private void updateWaldo()
	{
		if (character.adventure.waldoDefeats > character.adventure.waldoFinds && character.adventure.waldoFinds < 4 && character.adventure.waldoDefeats > character.adventure.waldoFinds)
		{
			waldoTimer++;
			if (waldoTimer % 180 == 0 && character.adventure.waldoFinds < 4)
			{
				attachWaldoToMenu(validMenu());
			}
		}
	}

	public int validMenu()
	{
		int num = Random.Range(0, 40);
		if (num == 1 || num == 2 || num == 17 || num == 24 || num == 27 || (num == 4 && character.bossID < 4) || (num == 5 && character.bossID < 17) || (num == 6 && character.bossID < 37) || (num == 7 && character.bossID < 37) || (num == 18 && character.bossID < 30) || (num == 8 && !character.settings.nguOn) || (num == 37 && !character.settings.nguOn) || (num == 39 && !character.settings.beardsOn))
		{
			return validMenu();
		}
		return num;
	}

	public void attachWaldoToMenu(int menuID)
	{
		modx = Random.Range(-200f, 200f);
		mody = Random.Range(-200f, 200f);
		currentMenu = menuID;
		menu = menuSwapper.allMenus[menuID];
		transparency = 0.2f - (float)character.adventure.waldoFinds * 0.05f;
	}

	public void waldoOff()
	{
		currentMenu = -1;
		transparency = 0.1f;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("clicked!");
		character.adventure.waldoFinds++;
		switch (character.adventure.waldoFinds)
		{
		case 1:
			tooltip.showOverrideTooltip("Dammit, you found me! Fine, let's have another fight!", 5f);
			break;
		case 2:
			tooltip.showOverrideTooltip("You found me again?! GRR, now you're making me MAD! Fight me!", 5f);
			break;
		case 3:
			tooltip.showOverrideTooltip("How do you keep finding me??! You're really cheesing me off! I'm gonna teach you a lesson this time - a Lesson in PAIN!", 5f);
			break;
		case 4:
			tooltip.showOverrideTooltip("THAT DOES IT!!! I'm not holding back! Let's settle this once and for all!", 5f);
			break;
		}
	}
}
