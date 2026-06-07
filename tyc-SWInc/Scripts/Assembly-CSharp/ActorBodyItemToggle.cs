using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActorBodyItemToggle : MonoBehaviour
{
	public Image Back;

	public Image Thumb;

	public GameObject Checkmark;

	public GameObject PatternButton;

	public UnityEvent OnToggled;

	public UnityEvent OnUntoggled;

	public GameObject[] ColorButtons;

	public GUIToolTipper Tip;

	public Image[] Colors;

	public Color Active;

	public Color Inactive;

	[NonSerialized]
	public ActorBodyItem Prefab;

	[NonSerialized]
	public ActorBodyItem ActiveItem;

	private ActorBodyItem.ColorMapping[] _mapping;

	public ActorBodyItem.GenderType Gender;

	public ActorBodyItem.BodyType Type;

	public ActorBodyItem.GUICategory Category;

	public bool IsVoid;

	public bool Mirror;

	public bool Match(ActorBodyItem item)
	{
		if (IsVoid)
		{
			if (Gender == item.Gender)
			{
				if (Type == ActorBodyItem.BodyType.Accessory && (item.Category.Equals("Makeup") || item.Category.Equals("Beard")))
				{
					return true;
				}
				if (Type == item.Type)
				{
					return true;
				}
			}
			return false;
		}
		return Prefab.Match(item);
	}

	public void ShowPatternPanel()
	{
		ActorCustomization.Instance.PatternPanel.Show(this);
	}

	public void Set(ActorBodyItem item, bool mirrored)
	{
		Prefab = item;
		Thumb.sprite = item.Thumbnail;
		if (mirrored)
		{
			Thumb.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		Gender = item.Gender;
		Type = item.Type;
		Mirror = mirrored;
		Category = item.guiCategory;
		_mapping = item.Colormap.Where((ActorBodyItem.ColorMapping x) => !x.ColorName.Equals("Skin")).ToArray();
		if (item.Type == ActorBodyItem.BodyType.Hair)
		{
			_mapping = item.Colormap.Concate(new ActorBodyItem.ColorMapping("Eyebrows", "_Color", "Hair", "Hair")).ToArray();
		}
	}

	public void Set(Sprite sprite, string name, ActorBodyItem.GenderType gender, ActorBodyItem.BodyType type, ActorBodyItem.GUICategory category)
	{
		Thumb.sprite = sprite;
		Gender = gender;
		Type = type;
		Category = category;
		IsVoid = true;
		_mapping = new ActorBodyItem.ColorMapping[0];
		if (type == ActorBodyItem.BodyType.Hair)
		{
			_mapping = new ActorBodyItem.ColorMapping[1]
			{
				new ActorBodyItem.ColorMapping("Eyebrows", "_Color", "Hair", "Hair")
			};
		}
	}

	public void Activate(ActorBodyItem item, bool check)
	{
		ActiveItem = item;
		if (!IsVoid)
		{
			if (Prefab.IsFaceTexture)
			{
				ActorBodyItem actorBodyItem = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
				Colors[0].color = actorBodyItem.GetColor("Skin") * ActorGenerator.Instance.AllSkinColors[actorBodyItem.SkinToneIndex];
				Colors[1].color = actorBodyItem.GetColor("Extra");
			}
			else
			{
				for (int num = 0; num < _mapping.Length; num++)
				{
					if (Prefab.Type == ActorBodyItem.BodyType.Hair && num == _mapping.Length - 1)
					{
						ActorBodyItem actorBodyItem2 = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
						Colors[num].color = actorBodyItem2.GetColor("Hair");
					}
					else if (_mapping[num].ColorName.Equals("Skin"))
					{
						ActorBodyItem actorBodyItem3 = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
						Colors[num].color = actorBodyItem3.GetColor("Skin") * ActorGenerator.Instance.AllSkinColors[actorBodyItem3.SkinToneIndex];
					}
					else
					{
						Colors[num].color = item.GetColorFromSlot(_mapping[num].MaterialSlot);
					}
				}
			}
		}
		else if (Type == ActorBodyItem.BodyType.Accessory)
		{
			ActorBodyItem actorBodyItem4 = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
			Colors[0].color = actorBodyItem4.GetColor("Skin") * ActorGenerator.Instance.AllSkinColors[actorBodyItem4.SkinToneIndex];
		}
		else if (Type == ActorBodyItem.BodyType.Hair)
		{
			ActorBodyItem actorBodyItem5 = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
			Colors[0].color = actorBodyItem5.GetColor("Hair");
		}
		if (check)
		{
			Checkmark.SetActive(true);
			Back.color = Active;
			for (int num2 = 0; num2 < _mapping.Length; num2++)
			{
				if (!_mapping[num2].MaterialSlot.Equals("_Color4") && !_mapping[num2].MaterialSlot.Equals("_Color5") && !_mapping[num2].MaterialSlot.Equals("_Color6"))
				{
					ShowColor(num2);
				}
			}
		}
		PatternButton.SetActive(!IsVoid && Prefab.CanUsePattern);
		CheckPatternMapping();
	}

	public void ShowColor(int i)
	{
		RectTransform component = ColorButtons[i].GetComponent<RectTransform>();
		component.localScale = Vector3.zero;
		component.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic);
		ColorButtons[i].GetComponent<GUIToolTipper>().ToolTipValue = _mapping[i].ColorName;
		ColorButtons[i].SetActive(true);
	}

	public void CheckPatternMapping()
	{
		if (!(ActiveItem != null))
		{
			return;
		}
		for (int i = 0; i < _mapping.Length; i++)
		{
			if (!_mapping[i].MaterialSlot.Equals("_Color4") && !_mapping[i].MaterialSlot.Equals("_Color5") && !_mapping[i].MaterialSlot.Equals("_Color6"))
			{
				continue;
			}
			bool flag = ActiveItem.CanUsePattern && ActiveItem.PatternIndex > 0;
			if (ColorButtons[i].activeSelf != flag)
			{
				if (flag)
				{
					ShowColor(i);
				}
				else
				{
					ColorButtons[i].SetActive(false);
				}
			}
		}
	}

	public void OnColorClick(int i)
	{
		ActorBodyItem.ColorMapping map = _mapping[i];
		HashSet<Color> hashSet = new HashSet<Color>();
		hashSet.Add(Colors[i].color);
		if (map.ColorName.Equals("Skin"))
		{
			ActorCustomization.Instance.SkinTonePanel.SetActive(true);
			ActorCustomization.Instance.SetSkinTone(ActorCustomization.Instance.BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head).SkinToneIndex);
		}
		else if (!IsVoid && Prefab.IsFaceTexture)
		{
			ActorBodyItem actorBodyItem = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem y) => y.Type == ActorBodyItem.BodyType.Head);
			hashSet.Add(actorBodyItem.GetColor("Extra"));
			ActorCustomization.Instance.SkinTonePanel.SetActive(false);
		}
		else
		{
			ActorCustomization.Instance.SkinTonePanel.SetActive(false);
		}
		if (!string.IsNullOrEmpty(map.LogicalCategory))
		{
			foreach (ActorBodyItem bodyItem in ActorCustomization.Instance.BodyItems)
			{
				ActorBodyItem.ColorMapping[] colormap = bodyItem.Colormap;
				foreach (ActorBodyItem.ColorMapping colorMapping in colormap)
				{
					if (map.LogicalCategory.Equals(colorMapping.LogicalCategory))
					{
						hashSet.Add(bodyItem.GetColorFromSlot(colorMapping.MaterialSlot));
					}
				}
			}
		}
		ActorCustomization.Instance.UsingSkinColor = map.ColorName.Equals("Skin") && ActorCustomization.Instance.BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head).SkinToneIndex > 0;
		ActorCustomization.Instance.ShowColorDialog(delegate(Color x)
		{
			if (map.ColorName.Equals("Skin"))
			{
				ActorCustomization.Instance.SetSkinColor(x, 0);
			}
			else
			{
				ActorBodyItem actorBodyItem2 = ((!IsVoid && (Prefab.IsFaceTexture || Prefab.IsFaceMap)) ? ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem y) => y.Type == ActorBodyItem.BodyType.Head) : ActiveItem);
				string materialSlot = map.MaterialSlot;
				if (IsVoid || (actorBodyItem2.Type == ActorBodyItem.BodyType.Hair && i == _mapping.Length - 1))
				{
					actorBodyItem2 = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem y) => y.Type == ActorBodyItem.BodyType.Head);
					materialSlot = actorBodyItem2.GetMapFromColor(map.LogicalCategory).MaterialSlot;
				}
				try
				{
					actorBodyItem2.SetColorDirect(materialSlot, x);
				}
				catch (Exception ex)
				{
					Debug.LogException(new Exception("Error changing color for " + base.name + ":\n" + ex.ToString()));
				}
				ActorCustomization.Instance.SetColor(map.Mapping, x);
			}
			Colors[i].color = x;
			ActorCustomization.Instance.UpdateActiveThumb();
			ActorCustomization.Instance.SaveActiveStyle();
		}, Colors[i].color, hashSet);
	}

	public void Deactivate()
	{
		if (Checkmark.activeSelf)
		{
			Checkmark.SetActive(false);
			Back.color = Inactive;
			for (int i = 0; i < ColorButtons.Length; i++)
			{
				ColorButtons[i].SetActive(false);
			}
		}
		PatternButton.SetActive(false);
	}

	public void OnClick()
	{
		if (Checkmark.activeSelf && (IsVoid || !Prefab.CanDeselect))
		{
			return;
		}
		Checkmark.SetActive(!Checkmark.activeSelf);
		if (Checkmark.activeSelf)
		{
			Back.color = Active;
			for (int i = 0; i < _mapping.Length; i++)
			{
				ShowColor(i);
			}
			OnToggled.Invoke();
		}
		else
		{
			Back.color = Inactive;
			for (int j = 0; j < ColorButtons.Length; j++)
			{
				ColorButtons[j].SetActive(false);
			}
			OnUntoggled.Invoke();
		}
	}
}
