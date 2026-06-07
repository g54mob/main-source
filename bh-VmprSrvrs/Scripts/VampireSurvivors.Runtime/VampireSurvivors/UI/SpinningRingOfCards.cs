using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class SpinningRingOfCards : MonoBehaviour
	{
		[SerializeField]
		private int _Amount;

		[SerializeField]
		private float _Radius;

		[SerializeField]
		private float _Scale;

		[SerializeField]
		private float _Speed;

		[SerializeField]
		private float _Duration;

		[SerializeField]
		private GameObject _ArcanaCard;

		[SerializeField]
		private int _arcanaIndexMin;

		[SerializeField]
		private int _arcanaIndexMax;

		[SerializeField]
		private string _backFrameName;

		[SerializeField]
		private bool _ignoreDarkana;

		public float _X;

		public float _Y;

		private SignalBus _signalBus;

		private DataManager _data;

		private Dictionary<ArcanaType, ArcanaData> _arcanaData;

		private List<ArcanaType> _arcanaList;

		private List<GameObject> _spawned;

		private Sequence _flushSeq;

		[Inject]
		private void Construct(SignalBus signalBus, DataManager data, PlayerOptions player)
		{
		}

		private void Start()
		{
		}

		public void DefaultInit()
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Initialize(int amount, float radius, float speed, float scale, float duration)
		{
		}

		private ArcanaType GetRandomArcana()
		{
			return default(ArcanaType);
		}

		private void Flush()
		{
		}
	}
}
