using System.Collections;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Cameras;
using UnityEngine;

namespace Assets.Scripts.Environment.Terrain
{
	public class TerrainTunnelingPreventionScript : MonoBehaviour
	{
		public delegate void OnDepenetratedHandler(Vector3 hitNormal);

		private static readonly WaitForFixedUpdate _WaitForFixedUpdate = new WaitForFixedUpdate();

		private RaycastHit _hit;

		private Vector3? _lastPosition;

		private OnDepenetratedHandler _onDepenetrated;

		public PartScript Part { get; private set; }

		public static TerrainTunnelingPreventionScript Create(PartScript partScript, GameObject parent, OnDepenetratedHandler onDepenetrated)
		{
			TerrainTunnelingPreventionScript terrainTunnelingPreventionScript = parent.AddComponent<TerrainTunnelingPreventionScript>();
			terrainTunnelingPreventionScript.Initialize(partScript, onDepenetrated);
			return terrainTunnelingPreventionScript;
		}

		protected virtual void OnDestroy()
		{
			if ((object)FloatingOriginScript.Instance != null)
			{
				FloatingOriginScript.Instance.Repositioned -= OnFloatingOriginRepositioned;
			}
		}

		protected virtual IEnumerator PostFixedUpdate()
		{
			while (true)
			{
				yield return _WaitForFixedUpdate;
				CheckForTerrainPenetration();
			}
		}

		protected virtual void Start()
		{
			FloatingOriginScript.Instance.Repositioned += OnFloatingOriginRepositioned;
			CameraManagerScript.Instance.enabled = false;
			StartCoroutine(PostFixedUpdate());
			CameraManagerScript.Instance.enabled = true;
		}

		private void CheckForTerrainPenetration()
		{
			IRigidBody rigidBody = Part.Body.RigidBody;
			if (_lastPosition.HasValue && !rigidBody.IsSleeping())
			{
				Physics.SyncTransforms();
				Vector3 vector = rigidBody.position - _lastPosition.Value;
				float magnitude = vector.magnitude;
				if (magnitude > 0.01f)
				{
					Vector3 direction = vector / magnitude;
					if (Physics.Raycast(_lastPosition.Value, direction, out _hit, magnitude, 1048576, QueryTriggerInteraction.Ignore))
					{
						Vector3 vector2 = _hit.point - rigidBody.position;
						float num = Mathf.Max(Mathf.Min(vector2.magnitude * 0.5f, 1f), 0.01f);
						rigidBody.position += vector2 + vector2.normalized * num;
						rigidBody.velocity *= 0.5f;
						_onDepenetrated?.Invoke(_hit.normal);
					}
				}
			}
			_lastPosition = rigidBody.position;
		}

		private void Initialize(PartScript partScript, OnDepenetratedHandler onDepenetrated)
		{
			Part = partScript;
			_onDepenetrated = onDepenetrated;
		}

		private void OnFloatingOriginRepositioned(object sender, FloatingOriginUpdatedEventArgs e)
		{
			if (_lastPosition.HasValue)
			{
				if (PositionUtility.MovingCraftToNewLocation)
				{
					_lastPosition = null;
				}
				else
				{
					_lastPosition = Part.transform.position;
				}
			}
		}
	}
}
