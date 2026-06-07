using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors
{
	public class TreasureInfoPanel : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI Name;

		[SerializeField]
		private TextMeshProUGUI Description;

		[SerializeField]
		private TextMeshProUGUI Page;

		[SerializeField]
		private TextMeshProUGUI Level;

		[SerializeField]
		private TextMeshProUGUI AdditionalInfo;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Image _Background;

		private List<TreasurePrizeTypePair> _rewards;

		private int _prizeIndex;

		private DataManager _data;

		private GameSessionData _session;

		private Sequence _tween;

		private float _baseScale;

		[Inject]
		private void Construct(DataManager data, GameSessionData session)
		{
		}

		private void Start()
		{
		}

		public void Initialize(List<TreasurePrizeTypePair> prizes)
		{
		}

		public void Reset()
		{
		}

		private void StartCycle()
		{
		}

		private void ShowFirst()
		{
		}

		private void SetData()
		{
		}
	}
}
