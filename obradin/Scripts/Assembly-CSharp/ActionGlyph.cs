using UnityEngine;
using UnityEngine.UI;

public class ActionGlyph : MonoBehaviour
{
	public enum Start
	{
		Off = 0,
		On = 1,
		Flashing = 2
	}

	private enum Display
	{
		None = 0,
		Text = 1,
		Icon = 2
	}

	public string actionId;

	public Text text;

	public Image icon;

	public SpriteLib spriteLib;

	public Start start = Start.On;

	[Readonly]
	public ActionGlyphNotifier notifier;

	[Readonly]
	public Image textBorderImage;

	[Readonly]
	public LayoutGroup layoutGroup;

	[Readonly]
	public RectOffset defaultTextPadding;

	private float enableTime;

	private RInput.ActionDecoder actionDecoder;

	private int actionIndex;

	private Display display
	{
		set
		{
			text.gameObject.SetActive(value == Display.Text);
			icon.gameObject.SetActive(value == Display.Icon);
			if (textBorderImage != null)
			{
				textBorderImage.enabled = value == Display.Text;
			}
			if (layoutGroup != null)
			{
				layoutGroup.padding = ((value != Display.Text) ? new RectOffset(0, 0, 0, 0) : defaultTextPadding);
			}
		}
	}

	private bool visible
	{
		get
		{
			if (notifier != null && notifier.IsActive(actionIndex))
			{
				float startTime = notifier.GetStartTime(actionIndex);
				float num = Clock.active.time - startTime;
				return num % 0.25f < 0.125f;
			}
			if (start == Start.Off)
			{
				return false;
			}
			if (start == Start.Flashing)
			{
				float num2 = Clock.active.time - enableTime;
				return num2 % 1f > 0.5f;
			}
			return true;
		}
	}

	private void OnEnable()
	{
		enableTime = Clock.active.time;
		Refresh();
		if (start == Start.On)
		{
			display = ((!(icon.sprite != null)) ? Display.Text : Display.Icon);
		}
		else
		{
			display = Display.None;
		}
	}

	private void Update()
	{
		if (actionDecoder.actionId != actionId)
		{
			actionDecoder = new RInput.ActionDecoder(actionId);
			actionIndex = RInput.GetActionIndex(actionId);
		}
		if (visible)
		{
			if (actionDecoder.CheckChanged())
			{
				Refresh();
			}
			display = ((!(icon.sprite != null)) ? Display.Text : Display.Icon);
		}
		else
		{
			display = Display.None;
		}
	}

	public void AbortNotify()
	{
		if (start == Start.Off)
		{
			display = Display.None;
		}
	}

	public void Refresh()
	{
		if (actionDecoder == null || actionDecoder.actionId != actionId)
		{
			actionDecoder = new RInput.ActionDecoder(actionId);
			actionIndex = RInput.GetActionIndex(actionId);
		}
		string text = actionDecoder.name;
		Sprite sprite = spriteLib.Find(text);
		icon.sprite = sprite;
		this.text.text = text;
	}

	public void ResetEnableTime()
	{
		enableTime = Clock.active.time;
	}
}
