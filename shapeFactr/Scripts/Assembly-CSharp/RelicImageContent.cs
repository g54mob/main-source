using System;
using System.Collections.Generic;
using DG.Tweening;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class RelicImageContent : SingletonMonoBehaviour<RelicImageContent>
{
	[Serializable]
	private class OrdealItemSet
	{
		public eLastBattleKey key;

		public string animationName;

		public OrdealCursorItem item;
	}

	[Serializable]
	public struct RelicRarityFrame
	{
		public eRelicRarity rarity;

		public Sprite frame;

		public string color;

		public LocalizedString rarityLocalizeText;
	}

	public RelicContentItem relicImagePrefab;

	public RectTransform relicParent;

	public RectTransform tipTransform;

	[SerializeField]
	private Image relicIcon;

	[SerializeField]
	private Image relicFrame;

	[SerializeField]
	private TMP_Text relicRarityName;

	[SerializeField]
	private TMP_Text relicName;

	[SerializeField]
	private TMP_Text relicDesc;

	[SerializeField]
	private List<RelicRarityFrame> rarityFrames;

	[SerializeField]
	private Vector2 hovorUIOffset;

	[SerializeField]
	private Vector2 tweenOffset;

	[SerializeField]
	private float useRelicAlpha;

	[Header("試練系")]
	[SerializeField]
	private List<OrdealItemSet> ordealCursorItems;

	[SerializeField]
	private Transform ordealNormalLayout;

	[SerializeField]
	private Transform ordealPadMenuLayout;

	[SerializeField]
	private SkeletonGraphicController spineAnimation;

	[SerializeField]
	private float flyEffectDuration;

	[SerializeField]
	private float scaleUpDuration;

	[SerializeField]
	private float aftertasteDuration;

	[SerializeField]
	private float overImageScale;

	private int _lastFocusObjID;

	private float _detailWindowHalfWidth;

	private float _buttonHalfWidth;

	private UISetting _uiSetting;

	private Tween _tween;

	private Tween _delayTween;

	private string _blessingText;

	private string _curseText;

	private List<RelicContentItem> _relicItems;

	public HorizontalLayoutGroup relicLayoutGroup;

	public int defaultLayoutMaxCount;

	public int relicImageSize;

	public int defaultLayoutSpacing;

	private bool isInitialized;

	private void Awake()
	{
	}

	public RelicRarityFrame GetRarityFrame(eRelicRarity rarity)
	{
		return default(RelicRarityFrame);
	}

	public void Init()
	{
	}

	public void CreateRelic(string archiveId)
	{
	}

	public void CheckUseRelicItem()
	{
	}

	private void DisplayDetail(GameObject target, string title, string subTitle, string desc, string iconPath, Sprite frameSprite = null)
	{
	}

	public Sequence PlayGetOrdealAnimation(eLastBattleKey key, GameObject fromObj = null)
	{
		return null;
	}

	private OrdealItemSet GetOrdealImage(eLastBattleKey key)
	{
		return null;
	}

	public void SwitchNormalLayout()
	{
	}

	public void SwitchPadMenuLayout()
	{
	}

	public void SelectOrdealAction(eLastBattleKey key, GameObject target)
	{
	}

	public void DeSelectOrdealAction()
	{
	}
}
