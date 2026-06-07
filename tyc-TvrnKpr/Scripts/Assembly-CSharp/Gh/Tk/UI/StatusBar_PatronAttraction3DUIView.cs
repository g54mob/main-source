using System;
using System.Collections.Generic;
using DG.Tweening;
using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class StatusBar_PatronAttraction3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private Transform _lockedState;

		[SerializeField]
		private Transform _unlockedState;

		[SerializeField]
		private Transform _chart;

		[SerializeField]
		private Transform _background;

		[SerializeField]
		private Transform _arcaneCurtain;

		[SerializeField]
		private Transform _leftClamp;

		[SerializeField]
		private PatronAttractionGauges _attractionGauges;

		public float hourSlotWidth;

		public int _historyHourBuffer;

		public int _futureHours;

		public float _currentClarityHours;

		private bool _isDirty;

		private const int FullBoardLookAheadHours = 48;

		private List<PatronAttractionChart.AttractionChartItem> _data;

		private List<PatronAttractionChart.ModelCacheItem> _models;

		private List<(PatronAttractionChart.AttractionChartItem chartItem, float xPos, Action animation)> _pawnAnimations;

		private Dictionary<int, float> _hourAndYPosDict;

		public GameObject[] pawnPrefabs;

		public Vector3 pawnScale;

		private GameObject _cursor;

		[SerializeField]
		private float _gridHeight;

		[Header("category switch translation")]
		public Ease translationEase;

		public float translationEaseDuration;

		[Header("new model drop animation")]
		public Ease dropEase;

		[Tooltip("for when models are hidden")]
		public Ease dropReverseEase;

		public float dropDuration;

		public float dropDistance;

		public GameObject pawnClarityRevealPrefab;

		public GameObject pawnDissolveParticlePrefab;

		[SerializeField]
		private GameObject _pendingGroupsPip;

		[SerializeField]
		private BaseInteractable3DUIView _pendingGroupInteractable;

		protected override void Start()
		{
		}

		private void OnBoardChanged(object sender, EventArgs e)
		{
		}

		protected override void OnClickedInternal()
		{
		}

		private void UpdateBoard()
		{
		}

		private void UpdateGauges()
		{
		}

		private void UpdateArcaneCurtain()
		{
		}

		private void UpdateBoardBackground()
		{
		}

		private float GetHourPosition(float hour)
		{
			return 0f;
		}

		private void UpdatePawns()
		{
		}

		private GameObject GetModel(PatronAttractionChart.AttractionChartItem data)
		{
			return null;
		}

		private void PositionOnGrid(PatronAttractionChart.AttractionChartItem item)
		{
		}

		private void DropInPawn(PatronAttractionChart.AttractionChartItem item, Vector3 localPosition)
		{
		}

		private void DropOutPawn(GameObject model)
		{
		}

		private void MovePawn(PatronAttractionChart.AttractionChartItem item, Vector3 localPosition)
		{
		}

		private void RevealPawn(PatronAttractionChart.AttractionChartItem item)
		{
		}

		private void DestroyFakePawn(PatronAttractionChart.AttractionChartItem item)
		{
		}

		private void UpdatePendingGroups(IEnumerable<PatronPopulationData> pops)
		{
		}

		private string GetGroupRequestsString()
		{
			return null;
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}
	}
}
