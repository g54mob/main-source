using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dice : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Button btn_plus;

	public Button btn_minus;

	public Image back;

	public Image front;

	public int val;

	public TMP_Text txt;

	public bool select;

	public DiceType diceType;

	public bool isPreserved;

	public MiniGameManager gm;

	private void Start()
	{
		gm = Object.FindObjectOfType<MiniGameManager>();
	}

	private void Update()
	{
		base.transform.localScale = new Vector2(1f, 1f);
		txt.text = val.ToString();
		if (select)
		{
			back.color = Color.black;
		}
		else
		{
			back.color = new Color(0f, 0f, 0f, 0f);
		}
		if (diceType == DiceType.Basic)
		{
			front.color = Color.white;
		}
		if (diceType == DiceType.Fixed)
		{
			front.color = Color.grey;
		}
		if (diceType == DiceType.Wild)
		{
			front.color = Color.yellow;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			Select(!select);
		}
		if (eventData.button != PointerEventData.InputButton.Right)
		{
			return;
		}
		if (select)
		{
			if (gm.selected_dice.Count > 1)
			{
				gm.UnselectAllDice();
				Select(s: true);
			}
			else
			{
				Select(s: false);
			}
		}
		else
		{
			gm.UnselectAllDice();
			Select(s: true);
		}
	}

	public void Select(bool s)
	{
		if (select != s)
		{
			select = s;
			if (select)
			{
				gm.selected_dice.Add(this);
			}
			else
			{
				gm.selected_dice.Remove(this);
			}
		}
	}

	public void Reroll()
	{
		int num;
		do
		{
			num = Random.Range(1, 7);
		}
		while (num == val);
		val = num;
	}

	public void Roll()
	{
		val = Random.Range(1, 7);
	}

	public void SetValue(int newval)
	{
		val = newval;
	}

	public void Plus()
	{
		if (diceType != DiceType.Wild)
		{
			if (gm.mod <= 0)
			{
				gm.SetMessage("Out of M.O.D.", "M.O.D.耗尽");
			}
			else if (val != 6)
			{
				val++;
				gm.mod--;
			}
			else if (val == 6 && gm.ability.Contains("Shuttle"))
			{
				val = 1;
				gm.mod--;
				Object.FindObjectOfType<Shuttle>().Shine();
			}
		}
		else if (val != 6)
		{
			val++;
		}
		else if (val == 6 && gm.ability.Contains("Shuttle"))
		{
			val = 1;
			Object.FindObjectOfType<Shuttle>().Shine();
		}
	}

	public void Minus()
	{
		if (diceType != DiceType.Wild)
		{
			if (gm.mod <= 0)
			{
				gm.SetMessage("Out of M.O.D.", "M.O.D.耗尽");
			}
			else if (val != 1)
			{
				val--;
				gm.mod--;
			}
			else if (val == 1 && gm.ability.Contains("Shuttle"))
			{
				val = 6;
				gm.mod--;
				Object.FindObjectOfType<Shuttle>().Shine();
			}
		}
		else if (val != 1)
		{
			val--;
		}
		else if (val == 1 && gm.ability.Contains("Shuttle"))
		{
			val = 6;
			Object.FindObjectOfType<Shuttle>().Shine();
		}
	}
}
