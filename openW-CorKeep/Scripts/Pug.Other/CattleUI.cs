using System;
using System.Linq;
using UnityEngine;

public class CattleUI : UIelement
{
	public enum CattleStatus
	{
		Hungry = 0,
		MediumHungry = 1,
		Full = 2
	}

	public GameObject root;

	public PugText statusText;

	public TextInputField inputField;

	public PugText AuthorText;

	private float inputFieldWasSetTimer;

	private string cattleName = "";

	private string profanityFilteredCattleName = "";

	private bool pendingProfanityCheck;

	public BreedStateToggle breedingStateToggle;

	private const string cattleStatusTerm = "CattleStatus/";

	private const string cattleStatusWithNameTerm = "CattleStatus/Name";

	private static readonly ObjectCategoryTag[] ObjectCategoryTags = Enum.GetValues(typeof(ObjectCategoryTag)).Cast<ObjectCategoryTag>().ToArray();

	public override bool isShowing => root.activeInHierarchy;

	private Cattle activeCattle
	{
		get
		{
			if (!(Manager.main.player != null))
			{
				return null;
			}
			return Manager.main.player.activeCattle;
		}
	}

	private void Awake()
	{
		root.SetActive(value: false);
	}

	public void ShowUI()
	{
		UpdateStatusText();
		UpdateNameText(force: true);
		root.SetActive(value: true);
		LateUpdate();
		if (activeCattle.IsBreedingAvailable())
		{
			breedingStateToggle.gameObject.SetActive(value: true);
			breedingStateToggle.SetState(activeCattle.IsBreedingDisabled() ? 1 : 0);
		}
		else
		{
			breedingStateToggle.gameObject.SetActive(value: false);
		}
	}

	public void HideUI()
	{
		root.SetActive(value: false);
		inputFieldWasSetTimer = 0f;
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		UpdateNameText();
		UpdateStatusText();
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}

	private void UpdateStatusText()
	{
		Cattle cattle = activeCattle;
		if (cattle == null)
		{
			return;
		}
		if (!cattle.entityExist || cattle.isHidden)
		{
			cattle = null;
			return;
		}
		CattleStatus cattleStatus = CattleStatus.MediumHungry;
		ObjectDataCD objectData = cattle.objectData;
		int amount = objectData.amount;
		int num = 1;
		ObjectID objectID = objectData.objectID;
		if (PugDatabase.HasComponent<EatStateCD>(objectID))
		{
			num = PugDatabase.GetComponent<EatStateCD>(objectID).maxFoodUntilFull;
		}
		if (amount <= 1)
		{
			cattleStatus = CattleStatus.Hungry;
		}
		if (amount >= num)
		{
			cattleStatus = CattleStatus.Full;
		}
		string text = cattleStatus.ToString();
		if (cattleStatus == CattleStatus.Hungry)
		{
			text += GetTagCattleEats();
		}
		if (cattle.isBaby && (cattleStatus == CattleStatus.MediumHungry || cattleStatus == CattleStatus.Full))
		{
			text += "Baby";
		}
		if (string.IsNullOrEmpty(profanityFilteredCattleName))
		{
			statusText.formatFields = null;
			statusText.Render("CattleStatus/" + text);
		}
		else
		{
			statusText.formatFields = new string[1] { profanityFilteredCattleName };
			statusText.Render("CattleStatus/Name" + text);
		}
	}

	private ObjectCategoryTag GetTagCattleEats()
	{
		Cattle cattle = activeCattle;
		if (cattle == null)
		{
			return ObjectCategoryTag.None;
		}
		ObjectID objectID = cattle.objectData.objectID;
		if (PugDatabase.HasComponent<BehaviourTagsCD>(objectID))
		{
			BehaviourTagsCD component = PugDatabase.GetComponent<BehaviourTagsCD>(objectID);
			ObjectCategoryTag[] objectCategoryTags = ObjectCategoryTags;
			foreach (ObjectCategoryTag result in objectCategoryTags)
			{
				if (ObjectCategoryTagsCD.HasTag(component.eatsTagsBitMask, result))
				{
					return result;
				}
			}
		}
		return ObjectCategoryTag.None;
	}

	public void SetName()
	{
		PlayerController player = Manager.main.player;
		if (player == null || player.activeCattle == null)
		{
			return;
		}
		pendingProfanityCheck = true;
		Cattle activeCattle = player.activeCattle;
		string newCattleName = (cattleName = inputField.pugText.GetText());
		Manager.platform.parentalControlManager.RestrictInput(newCattleName, delegate(string filteredName)
		{
			if (!(newCattleName != cattleName) && !(activeCattle == null))
			{
				player.playerCommandSystem.SetName(activeCattle.entity, filteredName);
				inputFieldWasSetTimer = 1f;
				pendingProfanityCheck = false;
				profanityFilteredCattleName = filteredName;
			}
		});
	}

	private void UpdateNameText(bool force = false)
	{
		Cattle cattle = activeCattle;
		if (cattle == null || pendingProfanityCheck)
		{
			return;
		}
		if (inputFieldWasSetTimer > 0f)
		{
			inputFieldWasSetTimer -= Time.deltaTime;
		}
		else
		{
			if (inputField.inputIsActive)
			{
				return;
			}
			string newCattleName = cattle.GetName();
			if (cattleName == newCattleName && !force)
			{
				return;
			}
			cattleName = newCattleName;
			inputField.SetInputText("...");
			pendingProfanityCheck = true;
			Manager.platform.parentalControlManager.RestrictInput(newCattleName, delegate(string filteredName)
			{
				if (!(newCattleName != cattleName) && !(activeCattle == null))
				{
					inputField.SetInputText(filteredName ?? "");
					pendingProfanityCheck = false;
					profanityFilteredCattleName = filteredName;
				}
			});
		}
	}

	public void SetBreedState()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && !(player.activeCattle == null))
		{
			player.playerCommandSystem.SetCattleBreedable(player.activeCattle.entity, breedingStateToggle.stateIndex);
		}
	}
}
