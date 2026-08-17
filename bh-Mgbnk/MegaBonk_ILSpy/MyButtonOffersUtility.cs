using Assets.Scripts.Actors.Player;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonOffersUtility : MyButton
{
	public TextMeshProUGUI t_amount;

	public TextMeshProUGUI t_price;

	public GameObject disbaledOverlay;

	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	private bool colorInited;

	private bool cantAfford;

	private float refreshedAtTime;

	private unsafe void SetColor(Color c)
	{
		//IL_013a: Expected O, but got Ref
		//IL_0040: Expected O, but got F4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00bb: Expected O, but got F4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		if (!colorInited)
		{
			Color color = background.color;
			defaultColor = (Color)color.r;
			float num = 0f - color.r;
			colorInited = true;
			object obj2 = default(object);
			object obj = 0 - obj2;
			float num2 = num * 0.2f;
			float num3 = (float)obj * 0.2f;
			float num4 = num2 + color.r;
			float num5 = num3 + (float)obj2;
			hoverColor = (Color)num4;
			object obj3 = 0 - obj2;
			float num6 = (float)obj3 * 0.2f;
			float num7 = num6 + (float)obj2;
			float num8 = 1f - (float)obj2;
			float num9 = num8 * 0.2f;
			float num10 = num9 + (float)obj2;
		}
		object obj4 = default(object);
		background.color = (Color)(&obj4);
	}

	public void Enable()
	{
		disbaledOverlay.SetActive(value: false);
		Button button = GetButton();
		button.interactable = true;
	}

	public void Disable()
	{
		disbaledOverlay.SetActive(value: true);
		Button button = GetButton();
		button.interactable = true;
	}

	public unsafe override void StartHover()
	{
		//IL_000b: Expected O, but got Ref
		//IL_001f: Expected O, but got Ref
		Color color = default(Color);
		SetColor((Color)(&color));
		background.color = (Color)(&color);
		isHovering = true;
	}

	public unsafe override void StopHover()
	{
		//IL_000b: Expected O, but got Ref
		//IL_001f: Expected O, but got Ref
		Color color = default(Color);
		SetColor((Color)(&color));
		background.color = (Color)(&color);
		isHovering = false;
	}

	protected unsafe override void OnClick()
	{
		//IL_00ab: Expected O, but got Ref
		//IL_00ab: Expected O, but got Ref
		if (cantAfford)
		{
			float time = Time.time;
			if (refreshedAtTime < time)
			{
				AlwaysUi instance = AlwaysUi.Instance;
				string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "CANT_AFFORD");
				Transform transform = base.transform;
				Vector3 position = transform.position;
				Transform transform2 = base.transform;
				Vector3 position2 = transform2.position;
				object obj = default(object);
				object obj2 = default(object);
				float desiredScale = default(float);
				instance.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), desiredScale);
			}
		}
	}

	public void SetAmount(int n, int price)
	{
		//IL_000d: Expected I, but got O
		//IL_00c6: Invalid comparison between I4 and F4
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		TextMeshProUGUI textMeshProUGUI = t_amount;
		int num = default(int);
		string text = num.ToString();
		nint num2 = (nint)textMeshProUGUI;
		textMeshProUGUI.text = text;
		if (price > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"<sprite name=gold> {arg}";
			t_price.text = text2;
		}
		else
		{
			t_price.text = "";
		}
		bool flag;
		int num3;
		if (num <= 0)
		{
			flag = false;
			num3 = num;
		}
		else
		{
			num3 = num;
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			bool flag2 = (float)price < inventory._003Cgold_003Ek__BackingField;
			object obj = price - inventory._003Cgold_003Ek__BackingField;
			bool flag3 = obj == null;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			flag = flag5 & flag4;
		}
		cantAfford = flag;
		GameObject gameObject;
		bool active;
		if (num3 > 0 && !flag)
		{
			gameObject = disbaledOverlay;
			active = false;
		}
		else
		{
			gameObject = disbaledOverlay;
			active = true;
		}
		gameObject.SetActive(active);
		Button button = GetButton();
		button.interactable = true;
		int num4 = num ^ num;
		int num5 = num & num4;
		bool flag6 = num5 < 0;
		bool flag7 = num < 0;
		bool flag8 = num == 0;
		bool flag9 = flag7 == flag6;
		bool flag10 = !flag8;
		bool flag11 = flag10 & flag9;
		t_price.enabled = flag11;
		float time = Time.time;
		refreshedAtTime = time;
	}

	public MyButtonOffersUtility()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
