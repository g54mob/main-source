using Pug.UnityExtensions;
using UnityEngine;

public class CombatText : PoolableSimple
{
	public enum NumberColor
	{
		White = 0,
		Red = 1,
		Green = 2,
		Yellow = 3,
		Orange = 4
	}

	[HideInInspector]
	public string textString;

	[HideInInspector]
	public string[] formatFields;

	[HideInInspector]
	public bool localize;

	[HideInInspector]
	public Vector3 textPosition;

	[HideInInspector]
	public NumberColor color;

	[HideInInspector]
	public bool isCrit;

	[HideInInspector]
	public bool randomPosition = true;

	public Color defaultColor = new Color(1f, 1f, 1f, 0.7f);

	public Color hurtPlayerColor = new Color(1f, 0f, 0f, 0.7f);

	public Color healPlayerColor = new Color(0f, 1f, 0f, 0.7f);

	public Color critColor = new Color(0f, 1f, 0f, 0.7f);

	public Color burnColor = new Color(0f, 1f, 0f, 0.7f);

	public PugText text;

	public PugTextEffectFade fadeEffect;

	private TimerSimple durationTimer;

	private TimerSimple fadeTimer;

	public Animator animator;

	private bool isDamageNumber;

	public static void SpawnCombatText(string text, NumberColor color, Vector3 position, bool isDamageNumber, bool isCrit = false, bool localize = false, string[] formatFields = null, bool randomPosition = true)
	{
		if (!Manager.prefs.showDamageNumbers)
		{
			return;
		}
		CombatText freeComponent = Manager.memory.GetFreeComponent<CombatText>(deferOnOccupied: true);
		if (freeComponent != null)
		{
			freeComponent.textString = text;
			freeComponent.formatFields = formatFields;
			freeComponent.localize = localize;
			freeComponent.textPosition = position;
			freeComponent.color = color;
			freeComponent.isCrit = isCrit;
			freeComponent.randomPosition = randomPosition;
			freeComponent.isDamageNumber = isDamageNumber;
			freeComponent.fadeTimer.Stop();
			if (isCrit)
			{
				freeComponent.animator.SetTrigger(750135729);
			}
			else
			{
				freeComponent.animator.SetTrigger(346641107);
			}
			freeComponent.OnOccupied();
			freeComponent.durationTimer.Start(5f / 6f);
		}
	}

	public override void OnOccupied()
	{
		Vector3 vector = new Vector3(0f, 10f, -10f);
		Vector2 vector2 = (randomPosition ? (Random.insideUnitCircle * 0.33f) : new Vector2(0f, 0f));
		Vector3 vector3 = new Vector3(vector2.x, vector2.y, 0f);
		base.transform.position = textPosition + vector + vector3;
		base.transform.position = base.transform.position.RoundToMultiple(0.0625f);
		text.localize = localize;
		text.formatFields = ((formatFields == null) ? new string[0] : formatFields);
		if (isDamageNumber)
		{
			text.SetDefaultFont(TextManager.FontFace.thinTiny);
		}
		else
		{
			text.SetDefaultFont(TextManager.FontFace.thinSmall);
		}
		text.Render(textString, rewindEffectAnims: true);
		Color color = defaultColor;
		switch (this.color)
		{
		case NumberColor.White:
			color = defaultColor;
			break;
		case NumberColor.Red:
			color = hurtPlayerColor;
			break;
		case NumberColor.Green:
			color = healPlayerColor;
			break;
		case NumberColor.Yellow:
			color = critColor;
			break;
		case NumberColor.Orange:
			color = burnColor;
			break;
		}
		text.SetTempColor(color);
	}

	private void LateUpdate()
	{
		if (durationTimer.isRunning && durationTimer.isTimerElapsed)
		{
			durationTimer.Stop();
			StartFadeOut();
		}
		if (fadeTimer.isRunning && fadeTimer.isTimerElapsed)
		{
			fadeTimer.Stop();
			Free();
		}
	}

	public void StartFadeOut()
	{
		fadeEffect.FadeOut();
		fadeTimer.Start(fadeEffect.fadeOutTime);
	}

	public override void OnFree()
	{
		base.OnFree();
		text.transform.position = Vector3.zero;
		text.transform.localScale = Vector3.zero;
	}
}
