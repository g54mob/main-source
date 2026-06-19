using InControl;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
	public TextMeshProUGUI nameText;

	public TextMeshProUGUI descriptionText;

	public TextMeshProUGUI fullBoxText;

	private RectTransform tooltipRect;

	private Vector3[] tooltipCorners = new Vector3[4];

	private Vector3 tooltipOffset = new Vector3(0f, 80f, 0f);

	private string hiddenName = "????";

	private FloraManager floraManagerRef;

	private DogGutsManager dogGutsManagerRef;

	public void SetItem(InventoryItem itemRef, bool unlocked = true)
	{
		SetItem(itemRef.itemNameLocalized, itemRef.itemDescriptionLocalized, unlocked);
	}

	public void SetItem(RoomCustomizationObject itemRef, bool unlocked = true)
	{
		SetItem(itemRef.GetName(), itemRef.GetDescription(), unlocked);
	}

	public void SetItem(GutFloraResource floraRef, bool unlocked = true)
	{
		if (floraManagerRef == null)
		{
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			floraManagerRef = registrationScript.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
			dogGutsManagerRef = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		}
		string floraPath = dogGutsManagerRef.floraNameToPathDict[floraRef.gutFloraName];
		FloraUnlockInfo unlockInfoForFloraPath = floraManagerRef.GetUnlockInfoForFloraPath(floraPath);
		string text = "";
		for (int i = 0; i < unlockInfoForFloraPath.floraEffects.Count; i++)
		{
			string text2 = GutFloraMutations.GetReadableNameForMutationEffect(unlockInfoForFloraPath.floraEffects[i]);
			if (!unlocked || !unlockInfoForFloraPath.floraEffectDiscoveries.Contains(unlockInfoForFloraPath.floraEffects[i]))
			{
				text2 = TextUtil.GetHiddenString(text2);
			}
			text = text + text2 + "\n";
		}
		SetItem(floraRef.floraNameLocalized, text, unlocked);
	}

	public void SetItem(DogPersonalityTrait traitRef)
	{
		SetItem(traitRef.traitName, traitRef.traitDescription, unlocked: true);
	}

	public void SetFullBoxText(string newText)
	{
		if (fullBoxText == null)
		{
			Debug.LogError("Attempting to set Full Box Text on tooltip without this object assigned: " + base.gameObject);
			return;
		}
		fullBoxText.text = newText;
		fullBoxText.gameObject.SetActive(value: true);
		nameText.text = "";
		descriptionText.text = "";
	}

	public void SetItem(string newNameText, string newDescriptionText, bool unlocked)
	{
		if (unlocked)
		{
			nameText.text = newNameText;
		}
		else
		{
			nameText.text = hiddenName;
		}
		descriptionText.text = newDescriptionText;
		if (fullBoxText != null)
		{
			fullBoxText.gameObject.SetActive(value: false);
		}
	}

	public void HoverBehavior()
	{
		if (tooltipRect == null)
		{
			tooltipRect = GetComponent<RectTransform>();
		}
		Vector3 position = new Vector3(InputManager.MouseProvider.GetPosition().x, InputManager.MouseProvider.GetPosition().y, 0f) + tooltipOffset;
		base.transform.position = position;
		float num = 0f;
		float num2 = Screen.width;
		float num3 = Screen.height;
		tooltipRect.GetWorldCorners(tooltipCorners);
		if (tooltipCorners[0].x < num)
		{
			position.x += num - tooltipCorners[0].x;
		}
		else if (tooltipCorners[3].x > num2)
		{
			position.x -= tooltipCorners[3].x - num2;
		}
		if (tooltipCorners[1].y > num3)
		{
			position.y -= tooltipCorners[1].y - num3;
		}
		base.transform.position = position;
	}
}
