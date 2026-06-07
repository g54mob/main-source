using System;
using System.Collections.Generic;
using DG.Tweening;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class PatronSatisfactionChart : MonoBehaviour
	{
		protected class ModelCacheItem
		{
			public string prefabKey;

			public bool isInUse;

			public GameObject model;

			public CharacterColors characterColors;

			public ModelCacheItem(string prefabKey, bool isInUse, GameObject model, CharacterColors characterColors)
			{
			}
		}

		public class ChartItem
		{
			public int percentage;

			public float timeStamp;

			public PatronData patron;

			public SatisfactionStatBase.SatisfactionStatLog log;

			public GameObject model;

			public bool isPositioned;

			public bool nudgedUp;

			public ChartItem(float timeStamp, PatronData patron, SatisfactionStatBase.SatisfactionStatLog log)
			{
			}
		}

		public GameObject averageIndicator;

		[SerializeField]
		protected TextMeshProI18n _averageTextElement;

		private SimpleTooltipProviderBehaviour _averageIndicatorToolTipProvider;

		[Header("category switch translation")]
		public Ease translationEase;

		public float translationEaseDuration;

		[Header("new model drop animation")]
		public Ease dropEase;

		[Tooltip("for when models are hidden")]
		public Ease dropReverseEase;

		public float dropDuration;

		public float dropDistance;

		[Header("overall animation timing")]
		public float sequenceDurationIn;

		public float sequenceDurationOut;

		public float firstOpenDelay;

		public Vector3 pawnOffset;

		public float pawnScaleFactor;

		public Vector3 pawnRotationOffset;

		private bool _wasClosed;

		private List<ChartItem> _data;

		public Dictionary<string, int> averageSatisfactionByCategory;

		private string _currentCategory;

		private Sequence _showDataSequence;

		protected int _satisfactionTextNumber;

		private GameObject cursor;

		private int _gridWidth;

		private int _gridHeight;

		private List<(float xPos, Action animation)> _animations;

		protected List<ModelCacheItem> _models;

		[SerializeField]
		private GameObject _modelWrapperPrefab;

		protected virtual int AverageSatisfactionTextNumber
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		public void Close()
		{
		}

		public void Refresh(string category, List<int> tiers)
		{
		}

		public Sequence PlayCloseAnimations(ShowHideAnimationSpeed speed)
		{
			return null;
		}

		private void ShowData()
		{
		}

		private void UpdateAverageIndicatorPosition(int satisfaction)
		{
		}

		private void PositionOnGrid(ChartItem item)
		{
		}

		protected virtual GameObject GetModel(PatronData data)
		{
			return null;
		}
	}
}
