using System.Collections;
using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	public class ReverbZoneManualCheck : MonoBehaviour
	{
		private const float INTERVAL = 0.2f;

		private AudioReverbZone _reverbZone;

		private Transform _listenerTransform;

		[SerializeField]
		private Vector3 _extents = Vector3.zero;

		protected void Start()
		{
			_reverbZone = GetComponent<AudioReverbZone>();
			StartCoroutine(CheckListener());
		}

		private IEnumerator CheckListener()
		{
			WaitForSeconds wait = new WaitForSeconds(0.2f * (0.95f + 0.1f * Random.value));
			while (true)
			{
				if (_listenerTransform != null)
				{
					Vector3 vector = base.transform.InverseTransformPoint(_listenerTransform.position);
					_reverbZone.enabled = Mathf.Abs(vector.x) <= _extents.x && Mathf.Abs(vector.y) <= _extents.y && Mathf.Abs(vector.z) <= _extents.z;
				}
				else
				{
					_listenerTransform = FlightSceneScript.Instance.CameraScript.MainCamera.transform;
				}
				yield return wait;
			}
		}
	}
}
