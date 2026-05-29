using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T10AscendedWidgetPuzzle : MonoBehaviour
	{
		[SerializeField]
		private T10AscendedWidgetObstacle _obstaclePrefab;

		[SerializeField]
		private float _spawnPosMin;

		[SerializeField]
		private float _spawnPosMax;

		private float _spawnTimer = 2f;

		private ActiveWorldFrame _parent;

		[field: SerializeField]
		public T10AscendedWidgetRocket Rocket { get; private set; }

		public bool PuzzleActive { get; private set; }

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void Update()
		{
			if (PuzzleActive)
			{
				_spawnTimer -= Time.deltaTime;
				if (_spawnTimer < 0f)
				{
					float x = SeededRandom.Global.RandomRange(_spawnPosMin, _spawnPosMax);
					Object.Instantiate(_obstaclePrefab, base.transform).transform.localPosition = new Vector3(x, 5.44f, -0.1f);
					_spawnTimer = SeededRandom.Global.RandomRange(1f, 2f);
				}
			}
		}

		public void ObstacleScored(T10AscendedWidgetObstacle obj)
		{
			UISounds.CraftStep();
			_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
		}

		public void ObstacleImpact(T10AscendedWidgetObstacle obj)
		{
			_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Ascension interrupted!");
			_spawnTimer += 1f;
		}

		public void SetPuzzleActive(bool active)
		{
			PuzzleActive = active;
		}
	}
}
