using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI.ScenarioEditor;
using UnityEngine;

namespace NSMedieval.UI
{
	public class CharacterAppearanceEdit : MonoBehaviour
	{
		[SerializeField]
		private ButtonLayoutItemView hairColorButton;

		[SerializeField]
		private ButtonLayoutItemView hairTypeButton;

		[SerializeField]
		private ButtonLayoutItemView facialHairTypeButton;

		[SerializeField]
		private ButtonLayoutItemView headTypeButton;

		[SerializeField]
		private ButtonLayoutItemView skinColorButton;

		[SerializeField]
		private ButtonLayoutItemView genderButton;

		[SerializeField]
		private GameObject[] facialHairGroup;

		private CharacterEditController EditController => MonoSingleton<CharacterEditController>.Instance;

		private void Start()
		{
			hairColorButton.Button.onClick.AddListener(OnHairColorClick);
			hairTypeButton.Button.onClick.AddListener(OnHairTypeClick);
			facialHairTypeButton.Button.onClick.AddListener(OnFacialHairClick);
			headTypeButton.Button.onClick.AddListener(OnHeadTypeClick);
			skinColorButton.Button.onClick.AddListener(OnSkinColorClick);
			genderButton.Button.onClick.AddListener(OnGenderClick);
		}

		private void OnEnable()
		{
			CharacterEditController editController = EditController;
			editController.CharacterUpdatedAction = (Action)Delegate.Combine(editController.CharacterUpdatedAction, new Action(OnCharacterUpdated));
			CharacterEditController editController2 = EditController;
			editController2.SelectedWorkerChangedAction = (Action)Delegate.Combine(editController2.SelectedWorkerChangedAction, new Action(OnCharacterUpdated));
			OnCharacterUpdated();
		}

		private void OnDisable()
		{
			if (MonoSingleton<CharacterEditController>.IsInstantiated())
			{
				CharacterEditController editController = EditController;
				editController.CharacterUpdatedAction = (Action)Delegate.Remove(editController.CharacterUpdatedAction, new Action(OnCharacterUpdated));
				CharacterEditController editController2 = EditController;
				editController2.SelectedWorkerChangedAction = (Action)Delegate.Remove(editController2.SelectedWorkerChangedAction, new Action(OnCharacterUpdated));
			}
		}

		private void OnCharacterUpdated()
		{
			HumanoidInstance selectedHumanoid = EditController.SelectedHumanoid;
			if (selectedHumanoid != null)
			{
				OnSkinColorChanged(selectedHumanoid.GetCharacterInfo().PhysicalLook.GetSkinColor());
				OnHairColorChanged(selectedHumanoid.GetCharacterInfo().PhysicalLook.GetHairColor());
				genderButton.TextObject.SetText(MonoSingleton<LocalizationController>.Instance.GetText("gender_" + selectedHumanoid.Info.BodyType.ToString().ToLower()));
				hairTypeButton.TextObject.SetText(MonoSingleton<LocalizationController>.Instance.GetText(selectedHumanoid.GetCharacterInfo().PhysicalLook.GetHairType()));
				headTypeButton.TextObject.SetText(MonoSingleton<LocalizationController>.Instance.GetText(selectedHumanoid.GetCharacterInfo().PhysicalLook.GetHeadType()));
				GameObject[] array = facialHairGroup;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(selectedHumanoid.GetCharacterInfo().BodyType == BodyType.Male);
				}
				string facialHairType = selectedHumanoid.GetCharacterInfo().PhysicalLook.GetFacialHairType();
				string key = ((facialHairType.Equals(string.Empty) || facialHairType.Equals("none")) ? "keycode_None" : facialHairType);
				facialHairTypeButton.TextObject.SetText(MonoSingleton<LocalizationController>.Instance.GetText(key));
			}
		}

		private void OnHairColorClick()
		{
			List<string> hairColor = Repository<HumanAppearanceRepository, HumanAppearance>.Instance.GetByID("default").HairColor;
			List<ListPopupItemData> list = new List<ListPopupItemData>();
			foreach (string color in hairColor)
			{
				list.Add(ListPopupItemData.CreateInstance(color, color, delegate
				{
					EditController.SetHairColor(color);
				}));
			}
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.GetCharacterInfo().PhysicalLook.GetHairColor() };
			ListPopupData data = ListPopupData.CreateInstance(MonoSingleton<LocalizationController>.Instance.GetText("character_hair_colour"), list, selectedId, EditController.SelectedHumanoid, ListPopupItemType.HairColor);
			EditController.NotifyShowAppearancePopupList(data);
		}

		private void OnHairTypeClick()
		{
			List<ListPopupItemData> list = new List<ListPopupItemData>();
			List<string> possibleBodyParts = EditController.GetPossibleBodyParts("hairs");
			if (possibleBodyParts != null)
			{
				foreach (string type in possibleBodyParts)
				{
					list.Add(ListPopupItemData.CreateInstance(type, MonoSingleton<LocalizationController>.Instance.GetText(type), delegate
					{
						EditController.SetHairType(type);
					}));
				}
			}
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.GetCharacterInfo().PhysicalLook.GetHairType() };
			ListPopupData data = ListPopupData.CreateInstance(MonoSingleton<LocalizationController>.Instance.GetText("character_hair_type"), list, selectedId, EditController.SelectedHumanoid, ListPopupItemType.HairType);
			EditController.NotifyShowAppearancePopupList(data);
		}

		private void OnFacialHairClick()
		{
			List<StringStringPair> list = new List<StringStringPair>
			{
				new StringStringPair("none", "general_none")
			};
			foreach (string possibleBodyPart in EditController.GetPossibleBodyParts("moustaches"))
			{
				list.Add(new StringStringPair("moustaches", possibleBodyPart));
			}
			foreach (string possibleBodyPart2 in EditController.GetPossibleBodyParts("beards"))
			{
				list.Add(new StringStringPair("beards", possibleBodyPart2));
			}
			List<ListPopupItemData> list2 = new List<ListPopupItemData>();
			foreach (StringStringPair pair in list)
			{
				list2.Add(ListPopupItemData.CreateInstance(pair.Value, MonoSingleton<LocalizationController>.Instance.GetText(pair.Value), delegate
				{
					EditController.SetFacialHairType(pair);
				}));
			}
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.GetCharacterInfo().PhysicalLook.GetFacialHairType() };
			ListPopupData data = ListPopupData.CreateInstance(MonoSingleton<LocalizationController>.Instance.GetText("character_facial_hair_type"), list2, selectedId, EditController.SelectedHumanoid, ListPopupItemType.FacialHairType);
			EditController.NotifyShowAppearancePopupList(data);
		}

		private void OnHeadTypeClick()
		{
			List<ListPopupItemData> list = new List<ListPopupItemData>();
			List<string> possibleBodyParts = EditController.GetPossibleBodyParts("heads");
			if (possibleBodyParts != null)
			{
				foreach (string type in possibleBodyParts)
				{
					list.Add(ListPopupItemData.CreateInstance(type, MonoSingleton<LocalizationController>.Instance.GetText(type), delegate
					{
						EditController.SetHeadType(type);
					}));
				}
			}
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.GetCharacterInfo().PhysicalLook.GetHeadType() };
			ListPopupData data = ListPopupData.CreateInstance(MonoSingleton<LocalizationController>.Instance.GetText("character_head_type"), list, selectedId, EditController.SelectedHumanoid, ListPopupItemType.HeadType);
			EditController.NotifyShowAppearancePopupList(data);
		}

		private void OnSkinColorClick()
		{
			List<string> skinColor = Repository<HumanAppearanceRepository, HumanAppearance>.Instance.GetByID("default").SkinColor;
			List<ListPopupItemData> list = new List<ListPopupItemData>();
			foreach (string color in skinColor)
			{
				list.Add(ListPopupItemData.CreateInstance(color, color, delegate
				{
					EditController.SetSkinColor(color);
				}));
			}
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.GetCharacterInfo().PhysicalLook.GetSkinColor() };
			ListPopupData data = ListPopupData.CreateInstance(MonoSingleton<LocalizationController>.Instance.GetText("character_skin_colour"), list, selectedId, EditController.SelectedHumanoid, ListPopupItemType.SkinColor);
			EditController.NotifyShowAppearancePopupList(data);
		}

		private void OnGenderClick()
		{
			List<ListPopupItemData> listItems = (from s in Enum.GetNames(typeof(BodyType))
				where !s.Equals("None")
				select ListPopupItemData.CreateInstance(s, MonoSingleton<LocalizationController>.Instance.GetText("gender_" + s.ToLower()), delegate
				{
					EditController.SetGender(s);
				})).ToList();
			List<string> selectedId = new List<string> { EditController.SelectedHumanoid.Info.BodyType.ToString() };
			ListPopupData data = ListPopupData.CreateInstance(MonoSingleton<LocalizationController>.Instance.GetText("character_gender"), listItems, selectedId, EditController.SelectedHumanoid);
			EditController.NotifyShowPopupList(data);
		}

		private void OnSkinColorChanged(string colorHex)
		{
			ColorUtility.TryParseHtmlString(colorHex, out var color);
			skinColorButton.GetComponent<ButtonLayoutItemView>().ImageObject.color = color;
		}

		private void OnHairColorChanged(string colorHex)
		{
			ColorUtility.TryParseHtmlString(colorHex, out var color);
			hairColorButton.GetComponent<ButtonLayoutItemView>().ImageObject.color = color;
		}
	}
}
