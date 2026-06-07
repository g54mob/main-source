using UnityEngine;
using UnityEngine.UI;

public class HoverTooltip : MonoBehaviour
{
	public Character character;

	public GameObject tooltip;

	public Canvas canvas;

	public TooltipLog log;

	public int length;

	public int width;

	private float secondsCount = -1f;

	private float timeShown = -1f;

	private bool beingShown;

	private string tooltipMessage;

	private Text tooltipText;

	private float x;

	private float y;

	private float modx;

	private float mody;

	private float fixedX;

	private float fixedY;

	private RectTransform tooltipRect;

	public int curstate;

	public bool tutorialMode;

	public Image tutorialKeys;

	public Sprite both;

	public Sprite both2;

	public Sprite backOnly;

	public Sprite backOnly2;

	public Sprite advanceOnly;

	public Sprite advanceOnly2;

	public PlayerTime tutorialLoopTime = new PlayerTime();

	public float loopTime()
	{
		return 1f;
	}

	public void Awake()
	{
		tooltipText = tooltip.GetComponentInChildren<Text>();
		tooltipRect = tooltip.GetComponent<RectTransform>();
		tooltip.SetActive(value: false);
		secondsCount = -1f;
	}

	public void Start()
	{
	}

	public void Update()
	{
		if (character.settings.tutorialState < 0 || character.settings.tutorialState > 30)
		{
			return;
		}
		tutorialLoopTime.advanceTime(Time.deltaTime);
		if (tutorialLoopTime.totalseconds >= 1.0)
		{
			tutorialLoopTime.reset();
		}
		if (character.settings.tutorialState == 0 || character.settings.tutorialState == 11 || character.settings.tutorialState == 16 || character.settings.tutorialState == 26)
		{
			if (tutorialLoopTime.totalseconds <= 0.5)
			{
				if (tutorialKeys.sprite != advanceOnly)
				{
					tutorialKeys.sprite = advanceOnly;
				}
			}
			else if (tutorialKeys.sprite != advanceOnly2)
			{
				tutorialKeys.sprite = advanceOnly2;
			}
		}
		else if (character.settings.tutorialState == 9 || character.settings.tutorialState == 14 || character.settings.tutorialState == 25 || character.settings.tutorialState == 30)
		{
			if (tutorialLoopTime.totalseconds <= 0.5)
			{
				if (tutorialKeys.sprite != backOnly)
				{
					tutorialKeys.sprite = backOnly;
				}
			}
			else if (tutorialKeys.sprite != backOnly2)
			{
				tutorialKeys.sprite = backOnly2;
			}
		}
		else if (tutorialLoopTime.totalseconds <= 0.5)
		{
			if (tutorialKeys.sprite != both)
			{
				tutorialKeys.sprite = both;
			}
		}
		else if (tutorialKeys.sprite != both2)
		{
			tutorialKeys.sprite = both2;
		}
	}

	public void showTooltip(string message)
	{
		if (character.settings.tutorialState >= 0)
		{
			return;
		}
		tutorialKeys.gameObject.SetActive(value: false);
		if (character.settings.tooltipsOn && !(secondsCount >= 0f))
		{
			if (!beingShown)
			{
				beingShown = true;
				tooltip.SetActive(value: true);
				tooltipText.transform.SetAsLastSibling();
				tooltipText.text = message;
				InvokeRepeating("updateTooltip", 0f, 0.02f);
			}
			else
			{
				tooltipText.text = message;
			}
		}
	}

	public void showOverrideTooltip(string message)
	{
		if (character.settings.tutorialState >= 0)
		{
			return;
		}
		tutorialKeys.gameObject.SetActive(value: false);
		if (!(secondsCount >= 0f))
		{
			if (!beingShown)
			{
				beingShown = true;
				tooltip.SetActive(value: true);
				tooltipText.transform.SetAsLastSibling();
				tooltipText.text = message;
				InvokeRepeating("updateTooltip", 0f, 0.02f);
			}
			else
			{
				tooltipText.text = message;
			}
		}
	}

	public void showTutorialTooltip(string message)
	{
		tutorialKeys.gameObject.SetActive(value: true);
		if (secondsCount >= 0f)
		{
			secondsCount = -1f;
			beingShown = false;
		}
		if (!beingShown)
		{
			beingShown = true;
			tooltip.SetActive(value: true);
			tooltipText.transform.SetAsLastSibling();
			tooltipText.text = message;
			InvokeRepeating("updateTooltip", 0f, 0.02f);
		}
		else
		{
			tooltipText.text = message;
		}
	}

	public void showTooltip(string message, float seconds)
	{
		if (character.settings.tutorialState < 0)
		{
			tutorialKeys.gameObject.SetActive(value: false);
			log.AddEvent(message);
			if (character.settings.tooltipsOn && character.settings.timedTooltipsOn)
			{
				CancelInvoke("updateTooltip");
				secondsCount = 0f;
				beingShown = true;
				tooltip.SetActive(value: true);
				timeShown = seconds;
				tooltipText.text = message;
				tooltipText.transform.SetAsLastSibling();
				InvokeRepeating("updateTooltip", 0f, 0.02f);
			}
		}
	}

	public void showOverrideTooltip(string message, float seconds)
	{
		if (character.settings.tutorialState < 0)
		{
			tutorialKeys.gameObject.SetActive(value: false);
			CancelInvoke("updateTooltip");
			log.AddEvent(message);
			if (character.settings.tooltipsOn)
			{
				secondsCount = 0f;
				beingShown = true;
				tooltip.SetActive(value: true);
				timeShown = seconds;
				tooltipText.text = message;
				tooltipText.transform.SetAsLastSibling();
				InvokeRepeating("updateTooltip", 0f, 0.02f);
			}
		}
	}

	public void showTutorialTooltip(string message, float seconds)
	{
		tutorialKeys.gameObject.SetActive(value: true);
		CancelInvoke("updateTooltip");
		log.AddEvent(message);
		secondsCount = 0f;
		beingShown = true;
		tooltip.SetActive(value: true);
		timeShown = seconds;
		tooltipText.text = message;
		tooltipText.transform.SetAsLastSibling();
		InvokeRepeating("updateTooltip", 0f, 0.02f);
	}

	public void showTooltip(string message, float x, float y)
	{
		if (character.settings.tutorialState < 0 && character.settings.tooltipsOn)
		{
			tutorialKeys.gameObject.SetActive(value: false);
			fixedX = x;
			fixedY = y;
			if (!beingShown)
			{
				beingShown = true;
				tooltip.SetActive(value: true);
				tooltipText.transform.SetAsLastSibling();
				tooltipText.text = message;
				InvokeRepeating("updateFixedTooltip", 0f, 0.02f);
			}
			else
			{
				tooltipText.text = message;
			}
		}
	}

	public void hideTooltip()
	{
		if (character.settings.tutorialState < 0 && !(secondsCount >= 0f))
		{
			beingShown = false;
			timeShown = -1f;
			secondsCount = -1f;
			CancelInvoke("updateTooltip");
			CancelInvoke("updateFixedTooltip");
			tooltip.SetActive(value: false);
		}
	}

	public void quickTimedMessage(string message)
	{
		showTooltip(message, 2f);
	}

	public void mediumTimedMessage(string message)
	{
		showTooltip(message, 5f);
	}

	public void hideTutorialTooltip()
	{
		if (!(secondsCount >= 0f))
		{
			beingShown = false;
			timeShown = -1f;
			secondsCount = -1f;
			CancelInvoke("updateTooltip");
			CancelInvoke("updateFixedTooltip");
			tooltip.SetActive(value: false);
		}
	}

	private void updateTooltip()
	{
		if (beingShown)
		{
			UpdateTimerUI();
		}
	}

	private void updateFixedTooltip()
	{
		if (beingShown)
		{
			tooltip.transform.position = new Vector3(fixedX, fixedY);
			return;
		}
		tooltip.transform.position = new Vector3(2000f, 2000f);
		tooltipText.text = "Hi I am a dog";
	}

	public void UpdateTimerUI()
	{
		if (secondsCount >= 0f)
		{
			secondsCount += Time.deltaTime;
			if (secondsCount >= timeShown)
			{
				hideTooltip();
				secondsCount = -1f;
				beingShown = false;
			}
		}
		if (beingShown)
		{
			x = Input.mousePosition.x;
			y = Input.mousePosition.y;
			modx = 10f;
			mody = 10f;
			if (x > (float)Screen.width - tooltipRect.rect.width * canvas.scaleFactor)
			{
				modx = 0f - (tooltipRect.rect.width * canvas.scaleFactor + 10f * canvas.scaleFactor);
			}
			if (y > (float)Screen.height - tooltipRect.rect.height * canvas.scaleFactor)
			{
				mody = 0f - (tooltipRect.rect.height * canvas.scaleFactor + 10f * canvas.scaleFactor);
			}
			tooltip.transform.position = new Vector3(x + modx, y + mody);
		}
		else
		{
			tooltip.transform.position = new Vector3(2000f, 2000f);
			tooltipText.text = "Hi I am a dog";
		}
	}

	public void displayState()
	{
		displayState(character.settings.tutorialState);
	}

	public void restartTutorial()
	{
		character.settings.tutorialState = 0;
		displayState();
	}

	public void displayState(int state)
	{
		if (character.settings.tutorialOffForever)
		{
			character.settings.tutorialState = -1;
			tutorialMode = false;
			return;
		}
		tutorialKeys.gameObject.SetActive(value: true);
		tutorialMode = true;
		switch (state)
		{
		case 0:
			showTutorialTooltip("Hey there, whoever you are! Glad you decided to check out NGU. I'm somethingggg, the guy who made this game. People call me 4G for short. You can use the left and right arrows on your keyboard to navigate/spam through this little tutorial. Anyways, let's begin!\n\n(Use the arrow keys to navigate through this tutorial!)");
			tutorialKeys.sprite = advanceOnly;
			break;
		case 1:
			showTutorialTooltip("So, your main goal in NGU? Get really friggin' powerful, and defeat all the strange Bosses that oppose you! To the left you can see your two main stats, Attack and Defense. They start at 100, but they'll grow real fast in just a sec.");
			tutorialKeys.sprite = both;
			break;
		case 2:
			showTutorialTooltip("In the top left is also your Energy. You generate Energy every time that green bar fills, until you hit the cap, which is 500 for now. And Energy will be key to raising those Attack and Defense numbers.");
			break;
		case 3:
			showTutorialTooltip("The big section is where the main action of the game is. Right now you have the Basic Training menu open, which is how you can raise your attack and defense (shocker). To train, you assign your Energy to a task! Go ahead and click the '+' button by 'Idle Attack' and see what happens.");
			break;
		case 4:
			showTutorialTooltip("If you did it right, the bar should be filling, and your Attack should be going up now. Pat yourself on the back. Not too low, that's just weird. If you click the - button you can take that energy out, and put it somewhere else.");
			break;
		case 5:
			showTutorialTooltip("In the top left Energy display, your 'Idle Energy' is how much Energy you haven't assigned anywhere and is sitting around being a lazy piece of crap. Your 'Energy Cap' is the sum of all your Energy, idle or assigned somewhere.");
			break;
		case 6:
			showTutorialTooltip("When you click the + button to assign Energy to a task, the game will attempt to assign Energy equal to the input number at the top section. Clicking those weird buttons at the top will change the amount stored in input, and you can enter a custom number into the bar yourself.");
			break;
		case 7:
			showTutorialTooltip("While being a glass cannon is cool, you probably want some Defense too. So, you'll need to train the 'Block' skill on the Basic Training menu too. If all of your Energy is allocated in Idle Attack, you'll have remove some.");
			break;
		case 8:
			showTutorialTooltip("When your stats are high enough, go check out the Fight Boss menu, and you can put your power to the test. Starting with a very vicious foe... a small piece of fluff.");
			tutorialKeys.sprite = both;
			break;
		case 9:
			showTutorialTooltip("I'm gonna go make a sandwich now, so keep training and defeat the first boss. I'll be back then!", 4f);
			tutorialMode = false;
			character.settings.tutorialState = -1;
			tutorialKeys.sprite = backOnly;
			break;
		case 11:
			showTutorialTooltip("Oh hey cool, you squished the fluff. In more important news this is a fantastic sandwich! Smoked ham and turkey with swiss cheese and honey dijon sauce on a ciabatta bun. Yum.\n\n(Use the arrow keys to navigate through this tutorial!)");
			tutorialKeys.sprite = advanceOnly;
			break;
		case 12:
			showTutorialTooltip("So killing bosses brings a few important rewards: First off, you gain EXP. EXP is used to buy permanent powers in the Spend EXP menu, which also just unlocked. You should see a fancy yellow button in the bottom left.");
			tutorialKeys.sprite = both;
			break;
		case 13:
			showTutorialTooltip("There's a lot of stuff you can buy with EXP, but don't get overwhelmed! My PROTIP to you would be to buy the special offers to increase the speed the Energy bar fills. I did specifically code them for newbies like you to buy... but no pressure.");
			tutorialKeys.sprite = both;
			break;
		case 14:
			showTutorialTooltip("Defeat the next couple bosses and I'll bug ya again. 4G, over and out!", 4f);
			tutorialMode = false;
			character.settings.tutorialState = -1;
			tutorialKeys.sprite = backOnly;
			break;
		case 16:
			showTutorialTooltip("Hi hello 4G again. So you killed the mouse? I guess that means it's time to add some rockin' new gameplay your way. First off, you unlocked ADVENTURE. Think 'crappy RPG within the game', you'll fight stuff and loot other stuff. The training skills you unlock become moves you can use in Adventure to defeat enemies!\n\n(Use the arrow keys to navigate through this tutorial!)");
			tutorialKeys.sprite = advanceOnly;
			break;
		case 17:
			showTutorialTooltip("Enemies will spawn randomly every few seconds when you move out of the Safe Zone. Fighting enemies in Adventure will drop gear, which you can equip in the snazzy new INVENTORY menu you also unlocked! Equipment can help boost your stats in Adventure and your main Attack/Defense stats, and later, provide special awesome bonuses!");
			tutorialKeys.sprite = both;
			break;
		case 18:
			showTutorialTooltip("To start, you only have the training zone unlocked. Defeating higher numbered bosses will eventually unlock new Adventure zones to play in, and get better gear to slap on!\n\nALSO: Boss enemies in Adventure have a chance to drop EXP! EXP is good.");
			break;
		case 19:
			showTutorialTooltip("You've also unlocked REBIRTHS, which needs some explanation.");
			break;
		case 20:
			showTutorialTooltip("Eventually, you're going to hit a point where it takes forever to grow stronger. If you rebirth, you'll reset most of your progress in each menu, and the bosses will reset. However, in return your NUMBER will grow. NUMBER is... well, it's a number. Your Attack and Defense get multiplied by NUMBER, and your NUMBER can get ridiculously big.");
			break;
		case 21:
			showTutorialTooltip("Like, stupidly big.");
			break;
		case 22:
			showTutorialTooltip("Like, past 'your momma' jokes big.");
			break;
		case 23:
			showTutorialTooltip("So, any time progress feels slow, it's probably time to rebirth, and reset some progress to get your number up! You can try rebirthing now if you want but if you wait longer, your NUMBER will grow even bigger! Rebirth time is a big factor to the size of your NUMBER, up until 60 minutes. You can check how long your rebirth has been going in the stats menu.");
			break;
		case 24:
			showTutorialTooltip("When you rebirth, bosses also respawn. With a high enough NUMBER, you can defeat the higher numbered bosses, which will award EXP every time they are defeated!");
			tutorialKeys.sprite = both;
			break;
		case 25:
			showTutorialTooltip("Get to boss 17 and you'll unlock another thing! See ya! -4G", 3f);
			tutorialMode = false;
			character.settings.tutorialState = -1;
			tutorialKeys.sprite = backOnly;
			break;
		case 26:
			showTutorialTooltip("Hi hello 4G here. Hows' it going? I see you're getting a hang of the whole 'Kill bosses, Rebirth' mechanic, plus I bet you have a lot more Energy to play with. Or maybe not, I dunno. Anyways, I unlocked the AUGMENTATION menu for you to play with.\n\n(Use the arrow keys to navigate through this tutorial!)");
			tutorialKeys.sprite = advanceOnly;
			break;
		case 27:
			showTutorialTooltip("Augments are a new way to allocate your Energy and get some bitchin' stat boosts as well. They also use the gold you've started to collect from Adventure! Augments can multiply your stats by a really huge factor and jump your power up a few Bosses or even more.");
			tutorialKeys.sprite = both;
			break;
		case 28:
			showTutorialTooltip("Augments work much the same way as training; You assign Energy to levelup augments; the more Energy assigned, the faster it goes. Each level takes a longer than the last, level 2 is 2x as long as level 1, level 3 is 3x as long, etc.");
			break;
		case 29:
			showTutorialTooltip("Oh, and the upgrades? They'll come later, and raise the stat boosting ability of augments to crazy heights.\n\nJust one more thing: If you ever find yourself confused on how a menu works, look for the 'WTF Do I Do' Button! It'll take you to a page that explains that feature better.");
			tutorialKeys.sprite = both;
			break;
		case 30:
			showTutorialTooltip("Anyways that's it for Augments! 4G, blasting off again!", 5f);
			character.settings.tutorialState = -1;
			tutorialMode = false;
			tutorialKeys.sprite = backOnly;
			break;
		default:
			hideTutorialTooltip();
			character.settings.tutorialState = -1;
			tutorialMode = false;
			break;
		}
	}

	public void advance()
	{
		character.settings.tutorialState++;
		displayState();
	}

	public void back()
	{
		if (character.settings.tutorialState != 0 && character.settings.tutorialState != 11 && character.settings.tutorialState != 16 && character.settings.tutorialState != 26)
		{
			character.settings.tutorialState--;
			displayState();
		}
	}

	public void startTutorial()
	{
		character.firstTimePlaying = false;
		tutorialMode = true;
		character.settings.tutorialState = 0;
		displayState();
	}

	public void startFirstBoss()
	{
		tutorialMode = true;
		character.settings.tutorialState = 11;
		displayState();
	}

	public void startAdventure()
	{
		tutorialMode = true;
		character.settings.tutorialState = 16;
		character.itemInfo.makeLevelledLoot(77, 4);
		character.itemInfo.makeLoot(1);
		character.itemInfo.makeLoot(14);
		character.itemInfo.makeLoot(27);
		displayState();
	}

	public void startAugments()
	{
		tutorialMode = true;
		character.settings.tutorialState = 26;
		displayState();
	}

	public void offForever()
	{
		character.settings.tutorialOffForever = true;
		character.settings.tutorialState = -1;
		displayState();
	}
}
