using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HackUIController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Slider slider;

	public Button addButton;

	public Button removeButton;

	public Button nextMilestoneButton;

	public Text hackNameText;

	public Text levelText;

	public Text res3AllocatedText;

	public Text res3HeadingText;

	public Image icon;

	public Image fill;

	public InputField target;

	public GameObject pod;

	public int id;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void refresh()
	{
		if (character.menuID == 52)
		{
			if (id < 0 || id >= character.hacks.hacks.Count)
			{
				pod.SetActive(value: false);
				return;
			}
			if (id == 15 && !character.hacksController.endHackAvailable())
			{
				pod.SetActive(value: false);
				return;
			}
			pod.SetActive(value: true);
			updateBar();
			updateIcon();
			updateText();
			updateInput();
			updateButtons();
		}
	}

	public void add()
	{
		character.hacksController.addR3(id, character.input.energyMagicInput);
		updateRes3Allocated();
	}

	public void remove()
	{
		character.hacksController.removeR3(id, character.input.energyMagicInput);
		updateRes3Allocated();
	}

	public void parseInput()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			long num = 0L;
			try
			{
				num = long.Parse(target.text);
			}
			catch (Exception)
			{
				num = 0L;
			}
			if (num < -1)
			{
				num = -1L;
			}
			if (num > character.hacksController.hardCapLevel(id))
			{
				num = character.hacksController.hardCapLevel(id);
			}
			character.hacks.hacks[id].target = num;
			updateInput();
		}
	}

	public void updateBar()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			slider.value = character.hacks.hacks[id].progress;
		}
	}

	public void updateBarColour()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			fill.color = character.hacksController.barColors[id];
		}
	}

	public void updateButtons()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			if (id == 15)
			{
				addButton.gameObject.SetActive(value: false);
				removeButton.gameObject.SetActive(value: false);
				target.gameObject.SetActive(value: false);
			}
			else
			{
				addButton.gameObject.SetActive(value: true);
				removeButton.gameObject.SetActive(value: true);
				target.gameObject.SetActive(value: true);
			}
			nextMilestoneButton.gameObject.SetActive(value: true);
		}
	}

	public void updateText()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			if (id == 15)
			{
				hackNameText.text = character.hacksController.properties[id].hackName;
				res3HeadingText.text = "3Dn&9K;Y-#nU Allocated";
				res3AllocatedText.text = "eeeeeeeeeeeeeeeeeeeeeeeeeee";
				levelText.text = "69";
			}
			else
			{
				hackNameText.text = character.hacksController.properties[id].hackName;
				res3HeadingText.text = character.res3.res3Name + " Allocated";
				res3AllocatedText.text = character.display(character.hacks.hacks[id].res3);
				levelText.text = character.display(character.hacks.hacks[id].level);
			}
		}
	}

	public void updateLevel()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			levelText.text = character.display(character.hacks.hacks[id].level);
		}
	}

	public void updateRes3Allocated()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			res3AllocatedText.text = character.display(character.hacks.hacks[id].res3);
		}
	}

	public void updateInput()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			target.text = character.hacks.hacks[id].target.ToString();
		}
	}

	public void updateIcon()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			icon.sprite = character.hacksController.hackIcons[id];
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	public void showTooltip()
	{
		character.hacksController.showTooltip(id);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		character.hacksController.hideTooltip(id);
	}

	public void setToNextMilestone()
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			character.hacksController.setToNextMilestone(id);
			updateInput();
		}
	}
}
