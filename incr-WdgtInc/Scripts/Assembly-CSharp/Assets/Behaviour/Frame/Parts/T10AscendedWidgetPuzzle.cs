using Assets.Source.World;
using TMPro;
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

		[SerializeField]
		private Collider2D _startCollider;

		[SerializeField]
		private TMP_Text _startText;

		public bool PuzzleActive;

		private float _spawnTimer = 2f;

		private ActiveWorldFrame _parent;

		[field: SerializeField]
		public T10AscendedWidgetRocket Rocket { get; private set; }

		public bool SpaceshipActive { get; private set; }

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void OnEnable()
		{
			_startCollider.enabled = true;
			PuzzleActive = false;
			_startText.gameObject.SetActive(value: true);
		}

		public void OnMouseUpAsButton()
		{
			_startCollider.enabled = false;
			PuzzleActive = true;
			_startText.gameObject.SetActive(value: false);
		}

		private void Update()
		{
			if (SpaceshipActive && PuzzleActive)
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
			_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T10AscendedWidgetWarning");
			_spawnTimer += 1f;
		}

		public void SetSpaceshipActive(bool active)
		{
			SpaceshipActive = active;
		}
	}
}
