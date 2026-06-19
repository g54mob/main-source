using System.Collections.Generic;
using ClockStone;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogGutGUIManager : MonoBehaviour
{
	public Image dogThumbnail;

	public TextMeshProUGUI dogNameText;

	public Image activeFloraPreviewImage;

	public TextMeshProUGUI activeFloraNameText;

	public TextMeshProUGUI activeFloraDescriptionText;

	public Scrollbar scrollRef;

	public GameObject floraInfoPrefab;

	public RectTransform floraInfoTransform;

	public RectTransform sliderAreaTransform;

	public Scrollbar floraEffectsScrollRef;

	public GameObject floraEffectsPrefab;

	public RectTransform floraEffectsTransform;

	public RectTransform floraEffectsSliderAreaTransform;

	public CursorUpdateArea cursorUpdateAreaRef;

	private string gutOpenSound = "gutPanelOpen";

	private string gutCloseSound = "gutPanelClose";

	private string floraSpawnSound = "floraSpawn";

	private string floraDieSound = "floraDie";

	private int infoCount;

	private int effectInfoCount;

	private float floraOffset = 75f;

	private float initialOffset = 50f;

	private float finalFloraOffset = 25f;

	private List<GameObject> allCreatedFloraInfos = new List<GameObject>();

	private List<GameObject> allCreatedFloraEffects = new List<GameObject>();

	private FloraInfo activeFloraInfo;

	private ulong? descriptionScaleKey;

	private ulong activeDogID;

	private DogGut activeDogGut;

	private DogRegistration dogRegRef;

	private FloraManager floraManagerRef;

	private DogGutsManager gutsManagerRef;

	private DogThumbnailController controllerRef;

	private void Update()
	{
		if (activeDogGut.FloraUpdated())
		{
			OnGutFloraUpdate();
		}
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			CloseGUI();
		}
	}

	public void SetDogGut(DogGut newGut)
	{
		if (activeDogGut != null)
		{
			activeDogGut.SetGUIRef(null);
		}
		activeDogGut = newGut;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		floraManagerRef = registrationScript.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
		gutsManagerRef = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		gutsManagerRef.RenderGut(newGut);
		AddAllFloraToGUI();
		activeDogGut.SetGUIRef(this);
		activeDogGut.OnFloraUpdateProcessedByGUI();
	}

	public void SetAssociatedDog(GameObject dog)
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		activeDogID = dogRegRef.GetIDFromDog(dog);
		string gUI_GUT_NAME = ScriptLocalization.GUI.GUI_GUT_NAME;
		int length = gUI_GUT_NAME.IndexOf("[");
		int num = gUI_GUT_NAME.IndexOf("]");
		dogNameText.text = gUI_GUT_NAME.Substring(0, length) + dogRegRef.GetSaveableDogFromDog(dog).dogName + gUI_GUT_NAME.Substring(num + 1);
		dogThumbnail.sprite = dogRegRef.GetDefaultThumbnailForDogID(activeDogID, useCocoonSprite: true, highQuality: true);
	}

	public void SetControllerRef(DogThumbnailController newRef)
	{
		controllerRef = newRef;
	}

	public void OnGUIOpened()
	{
		SFXOverlord.LockInWorldSFX(LockReason.GUT_GUI);
		AudioController.Play(gutOpenSound);
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().SetMuffled();
	}

	public void CloseGUI()
	{
		if (activeDogGut != null)
		{
			activeDogGut.SetGUIRef(null);
		}
		activeDogGut = null;
		controllerRef.CloseGutGUI();
		SFXOverlord.UnlockInWorldSFX(LockReason.GUT_GUI);
		AudioController.Play(gutCloseSound);
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().SetNotMuffled();
	}

	public void OnFloraSpawned()
	{
		if (!(activeDogGut == null))
		{
			AudioController.Play(floraSpawnSound);
		}
	}

	public void OnFloraDestroyed()
	{
		if (!(activeDogGut == null))
		{
			AudioController.Play(floraDieSound);
		}
	}

	private void OnGutFloraUpdate()
	{
		AddAllFloraToGUI(refresh: true);
		activeDogGut.OnFloraUpdateProcessedByGUI();
	}

	private void SwitchGut(GameObject newDog)
	{
		if (!(newDog == null))
		{
			SetAssociatedDog(newDog);
			SetDogGut(newDog.GetComponent<DogGutController>().GetDogGut());
			dogNameText.GetComponent<TextScaleInOnLoad>().RequestScaleIn();
		}
	}

	public void SwitchActiveDogRight()
	{
		List<GameObject> allInWorldOwnedDogs = dogRegRef.GetAllInWorldOwnedDogs();
		for (int i = 0; i < allInWorldOwnedDogs.Count; i++)
		{
			if (!(allInWorldOwnedDogs[i] == null) && dogRegRef.GetIDFromDog(allInWorldOwnedDogs[i]) == activeDogID)
			{
				if (i >= allInWorldOwnedDogs.Count - 1)
				{
					SwitchGut(allInWorldOwnedDogs[0]);
				}
				else
				{
					SwitchGut(allInWorldOwnedDogs[i + 1]);
				}
				break;
			}
		}
	}

	public void SwitchActiveDogLeft()
	{
		List<GameObject> allInWorldOwnedDogs = dogRegRef.GetAllInWorldOwnedDogs();
		for (int i = 0; i < allInWorldOwnedDogs.Count; i++)
		{
			if (dogRegRef.GetIDFromDog(allInWorldOwnedDogs[i]) == activeDogID)
			{
				if (i <= 0)
				{
					SwitchGut(allInWorldOwnedDogs[allInWorldOwnedDogs.Count - 1]);
				}
				else
				{
					SwitchGut(allInWorldOwnedDogs[i - 1]);
				}
				break;
			}
		}
	}

	private void AddAllFloraToGUI(bool refresh = false)
	{
		GutFloraResource gutFloraResource = null;
		if (activeFloraInfo != null)
		{
			gutFloraResource = activeFloraInfo.GetFloraResource();
		}
		infoCount = 0;
		for (int i = 0; i < allCreatedFloraInfos.Count; i++)
		{
			Object.Destroy(allCreatedFloraInfos[i]);
		}
		allCreatedFloraInfos.Clear();
		List<GutFloraBase> allGutFlora = activeDogGut.GetAllGutFlora();
		List<GutFloraResource> list = new List<GutFloraResource>();
		List<GutFloraResource> list2 = new List<GutFloraResource>();
		for (int j = 0; j < allGutFlora.Count; j++)
		{
			if (!allGutFlora[j].IsBoosted() && !list.Contains(allGutFlora[j].GetFloraType()))
			{
				list.Add(allGutFlora[j].GetFloraType());
			}
			if (allGutFlora[j].IsBoosted() && !list2.Contains(allGutFlora[j].GetFloraType()))
			{
				list2.Add(allGutFlora[j].GetFloraType());
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			AddFloraToGUI(list[k], (k == list.Count - 1) ? true : false, refresh);
			if (list2.Contains(list[k]))
			{
				AddFloraToGUI(list[k], (k == list.Count - 1) ? true : false, refresh, boosted: true);
			}
		}
		for (int l = 0; l < list2.Count; l++)
		{
			if (!list.Contains(list2[l]))
			{
				AddFloraToGUI(list2[l], (l == list2.Count - 1) ? true : false, refresh, boosted: true);
			}
		}
		if (!refresh)
		{
			scrollRef.value = 1f;
			if (allCreatedFloraInfos.Count == 0)
			{
				SetActiveFloraInfo(null);
			}
			return;
		}
		bool flag = false;
		for (int m = 0; m < allCreatedFloraInfos.Count; m++)
		{
			if (allCreatedFloraInfos[m].GetComponent<FloraInfo>().GetFloraResource() == gutFloraResource)
			{
				flag = true;
				SetActiveFloraInfo(allCreatedFloraInfos[m].GetComponent<FloraInfo>(), refresh: true);
				break;
			}
		}
		if (!flag)
		{
			if (allCreatedFloraInfos.Count > 0)
			{
				SetActiveFloraInfo(allCreatedFloraInfos[0].GetComponent<FloraInfo>(), refresh: true);
			}
			else
			{
				SetActiveFloraInfo(null, refresh: true);
			}
		}
	}

	private void AddFloraToGUI(GutFloraResource floraType, bool setActive, bool refresh = false, bool boosted = false)
	{
		infoCount++;
		GameObject gameObject = Object.Instantiate(floraInfoPrefab, floraInfoTransform);
		gameObject.transform.localScale = Vector3.one;
		FloraInfo component = gameObject.GetComponent<FloraInfo>();
		component.SetFloraInfo(floraType, this, cursorUpdateAreaRef, boosted);
		if (setActive && !refresh)
		{
			SetActiveFloraInfo(component);
		}
		PositionFloraInfo(gameObject);
		allCreatedFloraInfos.Add(gameObject);
	}

	private void PositionFloraInfo(GameObject obj)
	{
		obj.transform.localPosition = Vector3.zero + Vector3.up * floraOffset * infoCount;
		float num = (float)infoCount * floraOffset + finalFloraOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num);
		floraInfoTransform.anchoredPosition3D = new Vector3(floraInfoTransform.anchoredPosition3D.x, (0f - num) / 2f - initialOffset, 0f);
	}

	private void AddFloraEffectToGUI(string effectName, Rarity effectRarity, bool unlocked)
	{
		effectInfoCount++;
		GameObject gameObject = Object.Instantiate(floraEffectsPrefab, floraEffectsTransform);
		gameObject.transform.localScale = Vector3.one;
		FloraEffect component = gameObject.GetComponent<FloraEffect>();
		component.SetText(effectName, unlocked);
		component.SetRarity(effectRarity, unlocked);
		PositionFloraEffect(gameObject);
		allCreatedFloraEffects.Add(gameObject);
	}

	private void PositionFloraEffect(GameObject obj)
	{
		obj.transform.localPosition = Vector3.zero + Vector3.up * floraOffset * effectInfoCount;
		float num = (float)effectInfoCount * floraOffset + finalFloraOffset;
		floraEffectsSliderAreaTransform.sizeDelta = new Vector2(0f, num);
		floraEffectsTransform.anchoredPosition3D = new Vector3(floraEffectsTransform.anchoredPosition3D.x, (0f - num) / 2f - initialOffset, 0f);
	}

	public void SetActiveFloraInfo(FloraInfo newInfo, bool refresh = false)
	{
		if (!(activeFloraInfo == newInfo) || !(newInfo != null))
		{
			if (activeFloraInfo != null)
			{
				activeFloraInfo.OnSetInactive();
			}
			activeFloraInfo = newInfo;
			if (activeFloraInfo != null)
			{
				activeFloraInfo.OnSetActive();
			}
			DisplayActiveFloraInfo(refresh);
		}
	}

	private void DisplayActiveFloraInfo(bool refresh = false)
	{
		if (activeFloraInfo == null)
		{
			if (descriptionScaleKey.HasValue)
			{
				TextScaleInEffect.RequestEffectEnd(descriptionScaleKey.Value, activeFloraDescriptionText);
			}
			activeFloraNameText.text = "";
			activeFloraDescriptionText.text = "";
			activeFloraPreviewImage.gameObject.SetActive(value: false);
			ClearFloraEffects();
			return;
		}
		activeFloraPreviewImage.gameObject.SetActive(value: true);
		activeFloraNameText.text = activeFloraInfo.GetFloraName();
		activeFloraDescriptionText.text = activeFloraInfo.GetFloraDescription();
		activeFloraPreviewImage.sprite = activeFloraInfo.GetFloraPreviewSprite();
		activeFloraPreviewImage.color = activeFloraInfo.GetFloraTint();
		activeFloraPreviewImage.SetNativeSize();
		if (!refresh)
		{
			activeFloraPreviewImage.GetComponent<InchwormBounce>().RequestBounce();
		}
		if (descriptionScaleKey.HasValue)
		{
			TextScaleInEffect.RequestEffectEnd(descriptionScaleKey.Value, activeFloraDescriptionText);
		}
		if (!refresh)
		{
			descriptionScaleKey = TextScaleInEffect.ScaleInText(activeFloraDescriptionText, null, OnDescriptionTextScaleInFinished);
		}
		AddAllFloraEffectsToGUI(gutsManagerRef.GetPathForFlora(activeFloraInfo.GetFloraResource()), refresh);
	}

	private void ClearFloraEffects()
	{
		effectInfoCount = 0;
		for (int i = 0; i < allCreatedFloraEffects.Count; i++)
		{
			Object.Destroy(allCreatedFloraEffects[i]);
		}
		allCreatedFloraEffects.Clear();
	}

	private void AddAllFloraEffectsToGUI(string floraPath, bool refresh)
	{
		ClearFloraEffects();
		FloraUnlockInfo unlockInfoForFloraPath = floraManagerRef.GetUnlockInfoForFloraPath(floraPath);
		for (int i = 0; i < unlockInfoForFloraPath.floraEffects.Count; i++)
		{
			bool unlocked = unlockInfoForFloraPath.floraEffectDiscoveries.Contains(unlockInfoForFloraPath.floraEffects[i]);
			AddFloraEffectToGUI(GutFloraMutations.GetReadableNameForMutationEffect(unlockInfoForFloraPath.floraEffects[i]), floraManagerRef.GetRarityForFloraPathAndEffect(floraPath, unlockInfoForFloraPath.floraEffects[i]), unlocked);
		}
		if (!refresh)
		{
			floraEffectsScrollRef.value = 1f;
		}
	}

	private void OnDescriptionTextScaleInFinished(ulong key)
	{
		descriptionScaleKey = null;
	}
}
