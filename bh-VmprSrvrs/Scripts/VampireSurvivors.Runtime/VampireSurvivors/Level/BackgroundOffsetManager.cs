using UnityEngine;

namespace VampireSurvivors.Level
{
	public class BackgroundOffsetManager : GameMonoBehaviour
	{
		[SerializeField]
		private float _edgeOffset;

		private Camera _mainCamera;

		private Bounds _backgroundBounds;

		private Bounds _camBounds;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void CalculateBounds()
		{
		}

		private void OffsetBackgroundTiles()
		{
		}
	}
}
