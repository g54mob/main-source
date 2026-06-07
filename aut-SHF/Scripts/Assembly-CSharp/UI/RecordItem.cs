using System;
using System.Collections.Generic;
using Battle;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class RecordItem : MonoBehaviour
	{
		[Serializable]
		private struct StateSprite
		{
			public eClearState state;

			public Sprite sprite;
		}

		[Header("Item")]
		public Image masterIcon;

		public GameObject ascensionObj;

		public TMP_Text ascensionLevelText;

		public Image resultImage;

		public GameObject resultEndlessImage;

		public Image scoreImage;

		public TMP_Text scoreText;

		public TMP_Text finalWaveText;

		public TMP_Text playEndTimeText;

		public TMP_Text versionText;

		public GameObject challengeTitleObj;

		public TMP_Text challengeTitleText;

		public GameObject favoriteIconObj;

		[Header("UsedUnits")]
		public RectTransform usedUnitsParent;

		public ChoiceMenuButtonBase usedUnitPrefab;

		[Header("ResultImage")]
		[SerializeField]
		private List<StateSprite> stateSprites;

		private int _index;

		private string _filePath;

		private UnityAction<string> onClickAction;

		private UnityAction<RecordItem> switchFavoriteAction;

		private bool isFavorite => false;

		public string filePath => null;

		public int index => 0;

		public void Init(int index, bool isFavorite, eWriterId writer, int ascension, eClearState clearState, int finalWave, eLuggage[] usedUnits, DateTime playEndTime, string version, string filePath, eChallengeId challengeId, int score, bool isEndless, UnityAction<string> onClickAction, UnityAction<RecordItem> switchFavoriteAction)
		{
		}

		public void OnClickItem()
		{
		}

		public void OnClickFavorite()
		{
		}

		public void SwitchFavorite(bool isOn)
		{
		}

		public bool IsMatchPath(string path)
		{
			return false;
		}
	}
}
