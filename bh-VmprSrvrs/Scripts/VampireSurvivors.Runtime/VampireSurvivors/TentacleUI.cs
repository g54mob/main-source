using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.UI;

namespace VampireSurvivors
{
	public class TentacleUI : MonoBehaviour
	{
		public float maxAngle;

		public float speed;

		public GameObject TentaclePrefab;

		public RectTransform Anchor;

		public int Tentaclindex;

		public RectTransform Ring;

		public List<GameObject> Decorations;

		private float _currentTime;

		private GameObject _tentaclette;

		private Vector3 _startRotation;

		private bool isRoot;

		private int depth;

		private List<Tween> _tweens;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void Toggle(ArcanaMainSelectionPage.ArcanaMode mode)
		{
		}

		private void Hide()
		{
		}

		public void InstantHide()
		{
		}

		private void Show()
		{
		}

		public void Initialize()
		{
		}

		private void Update()
		{
		}

		public TentacleUI AddSegment()
		{
			return null;
		}

		public void SetStats(float _speed, float _maxAngle, int _depth)
		{
		}
	}
}
