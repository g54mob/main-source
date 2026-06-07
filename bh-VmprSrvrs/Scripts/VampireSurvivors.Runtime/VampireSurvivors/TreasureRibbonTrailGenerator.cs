using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

namespace VampireSurvivors
{
	public class TreasureRibbonTrailGenerator : MonoBehaviour
	{
		[SerializeField]
		private float _Scale;

		[SerializeField]
		private List<Vector2> _Points;

		[SerializeField]
		private GameObject _TrailPrefab;

		[SerializeField]
		private List<Vector2> _Ribbon3Points;

		[SerializeField]
		private GameObject _RibbonTrailPrefab;

		[SerializeField]
		private RectTransform _Reels3StartPosition;

		[SerializeField]
		private RectTransform ReelsIconsContainer;

		private List<SplineComputer> _spawnedCurves;

		private List<GameObject> _trails;

		private List<SplineComputer> _spawnedReelCurves;

		private List<GameObject> _reelTrails;

		private List<GameObject> _reelTrails3;

		private void Awake()
		{
		}

		private float GetCameraRTScale()
		{
			return 0f;
		}

		public void MakeRibbons()
		{
		}

		public void MakeRibbons3()
		{
		}

		private void GenerateReelCurves()
		{
		}

		public void ClearExisting()
		{
		}

		public void Play(float duration, float delay, int playCount, int howMany)
		{
		}

		public void PlayReelTrails(float duration, float delay, int playCount)
		{
		}

		private void SetTexture()
		{
		}

		private void OnDisable()
		{
		}

		public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
		{
			return default(Vector3);
		}

		public Vector2 RotateVectorByDegrees(Vector2 vec2, float degrees)
		{
			return default(Vector2);
		}
	}
}
