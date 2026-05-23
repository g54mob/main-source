using System;
using System.Collections;
using System.Collections.Generic;
using MPUIKIT;
using UnityEngine;

public class ETMapChoiceDisplay : MonoBehaviour
{
	[Serializable]
	public class MapIcon
	{
		public string mapName;

		public Sprite icon;
	}

	public ThronefallUIElement confirmButton;

	public TFUIEquippable weapon;

	public TFUIEquippable perkTFUIPrefab;

	public Transform perkGroup;

	public MPImage mapPreviewImage;

	public List<MapIcon> mapIcons = new List<MapIcon>();

	public Color imageUnselectedCol;

	public Color outlineSelectedCol;

	public Color outlineUnselectedCol;

	public AnimationCurve scaleAnimationCurve;

	public float animationTime = 0.3f;

	public float targetScale = 1.15f;

	private MapChoice data;

	private ETChoicePickScreen target;

	[HideInInspector]
	public TFUIEquippable[] currentPerkTFUIs;

	public MapChoice Data => data;

	public void SetData(MapChoice choice, ETChoicePickScreen target)
	{
		this.target = target;
		data = choice;
		foreach (Transform item in perkGroup)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		weapon.SetData(data.containedWeapon, loadoutIsFixed: false, overrideShow: true);
		currentPerkTFUIs = new TFUIEquippable[data.containedPerks.Count];
		for (int i = 0; i < data.containedPerks.Count; i++)
		{
			currentPerkTFUIs[i] = UnityEngine.Object.Instantiate(perkTFUIPrefab, perkGroup);
			currentPerkTFUIs[i].SetDataEternalTrials(data.containedPerks[i]);
		}
		confirmButton.onApply.AddListener(Confirm);
		foreach (MapIcon mapIcon in mapIcons)
		{
			if (mapIcon.mapName == data.mapName)
			{
				mapPreviewImage.sprite = mapIcon.icon;
				break;
			}
		}
	}

	public void Confirm()
	{
		target.ConfirmChoice(data);
	}

	public void Select()
	{
		StopAllCoroutines();
		StartCoroutine(ScaleAnimation(base.transform.localScale, Vector3.one * targetScale, animationTime));
		confirmButton.gameObject.SetActive(value: true);
		weapon.Pick();
		TFUIEquippable[] array = currentPerkTFUIs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Pick();
		}
		mapPreviewImage.color = Color.white;
		mapPreviewImage.OutlineColor = outlineSelectedCol;
	}

	public void Unselect()
	{
		StopAllCoroutines();
		StartCoroutine(ScaleAnimation(base.transform.localScale, Vector3.one, animationTime));
		base.transform.localScale = Vector3.one;
		confirmButton.HardStateSet(ThronefallUIElement.SelectionState.Default);
		confirmButton.gameObject.SetActive(value: false);
		weapon.UnPick();
		TFUIEquippable[] array = currentPerkTFUIs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UnPick();
		}
		mapPreviewImage.color = imageUnselectedCol;
		mapPreviewImage.OutlineColor = outlineUnselectedCol;
	}

	private IEnumerator ScaleAnimation(Vector3 startScale, Vector3 targetScale, float time)
	{
		base.transform.localScale = startScale;
		float clock = 0f;
		while (clock <= time)
		{
			clock += Time.unscaledDeltaTime;
			base.transform.localScale = Vector3.LerpUnclamped(startScale, targetScale, scaleAnimationCurve.Evaluate(Mathf.InverseLerp(0f, time, clock)));
			yield return null;
		}
		base.transform.localScale = targetScale;
	}
}
