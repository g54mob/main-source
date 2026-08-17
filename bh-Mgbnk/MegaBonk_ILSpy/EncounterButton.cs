using System;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncounterButton : MyButton
{
	public GameObject rarityContainer;

	public Image background;

	public Image selectedOverlay;

	public RawImage iconBorder;

	public RawImage iconBackground;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_rarity;

	public int index;

	private EncounterUi encounterUi;

	private bool canAccept = true;

	private string cantAcceptReason;

	public void Init(EncounterUi encounterUi, int index)
	{
		this.encounterUi = encounterUi;
		this.index = index;
	}

	public unsafe void SetOffer(EncounterOffer offer, bool showRarity)
	{
		//IL_00b2: Expected O, but got Ref
		//IL_00d9: Expected O, but got Ref
		//IL_00ff: Expected O, but got Ref
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected Ref, but got Unknown
		StopHover();
		GameObject gameObject = rarityContainer.gameObject;
		gameObject.SetActive(showRarity);
		if (!showRarity)
		{
			GameObject gameObject2 = rarityContainer.gameObject;
			gameObject2.SetActive(value: false);
		}
		else
		{
			string rarity = LocalizationUtility.GetRarity(offer.rarity);
			t_rarity.text = rarity;
			Color color = MyColorUtility.RarityToColor(offer.rarity);
			float num = default(float);
			iconBorder.color = (Color)(&num);
			Color rarityColorBackground = MyColorUtility.GetRarityColorBackground(offer.rarity);
			iconBackground.color = (Color)(&num);
			Color rarityColorBackground2 = MyColorUtility.GetRarityColorBackground(offer.rarity);
			background.color = (Color)(&num);
		}
		string effectsDescription = offer.GetEffectsDescription();
		t_description.text = effectsDescription;
		bool flag = offer.CanAccept(out *(string*)(this + 168));
		canAccept = flag;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 256 Invalid \"Jump target not found in method: 0x18054D650\"");
		throw new NullReferenceException();
	}

	private void TimeoutButton(float time)
	{
		Button component = GetComponent<Button>();
		component.interactable = false;
		Invoke("EnableButton", time);
	}

	private void EnableButton()
	{
		Button component = GetComponent<Button>();
		component.interactable = true;
	}

	public unsafe void SetDeclineOffer(int numOffers)
	{
		//IL_003b: Expected O, but got Ref
		GameObject gameObject = rarityContainer.gameObject;
		gameObject.SetActive(value: false);
		Color color = MyColorUtility.StringToColor(MyColorUtility.negativeColorString);
		object obj = default(object);
		background.color = (Color)(&obj);
		string localizedString = LocalizationUtility.GetLocalizedString("Game_Ui", "IGNORE_OFFERS");
		bool flag = localizedString == null;
		string text = "";
		if (!flag)
		{
			text = localizedString;
		}
		t_description.text = text;
		TimeoutButton(0.5f);
	}

	public override void StartHover()
	{
		isHovering = true;
		selectedOverlay.enabled = true;
	}

	public override void StopHover()
	{
		isHovering = false;
		selectedOverlay.enabled = false;
	}

	protected unsafe override void OnClick()
	{
		//IL_0066: Expected O, but got Ref
		//IL_0066: Expected O, but got Ref
		if (canAccept)
		{
			encounterUi.ChooseOffer(index);
			return;
		}
		AlwaysUi instance = AlwaysUi.Instance;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		object obj2 = default(object);
		float desiredScale = default(float);
		instance.UiTextPopup.SetText(cantAcceptReason, (Vector3)(&obj), (Color)(&obj2), desiredScale);
	}

	public EncounterButton()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
