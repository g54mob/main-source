using UnityEngine;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors
{
	public class EnemyOnlineDebugger : MonoBehaviour
	{
		public Material material;

		private LineRenderer _errorLineRenderer;

		private LineRenderer _velocityLineRenderer;

		private EnemyController _enemy;

		private SpriteRenderer _enemyRenderer;

		private Vector3 _latestRemotePosition;

		private bool _init;

		public static bool EnableDebugPosition { get; set; }

		public static bool EnableDebugAuthority { get; set; }

		private void Start()
		{
		}

		private void InitEnemy()
		{
		}

		private bool IsSynced()
		{
			return false;
		}

		private void OnDisable()
		{
		}

		private void DisableLineRenderers()
		{
		}

		private void OnNetworkSampleReceived(object positionSample, bool stopped, long _)
		{
		}

		private LineRenderer CreateLineRenderer(string goName, Color color)
		{
			return null;
		}

		private void LateUpdate()
		{
		}

		private void SetPositionCount(LineRenderer renderer)
		{
		}
	}
}
