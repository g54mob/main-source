using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.FlightObjects;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Structures
{
	public class NetworkTriggerStateScript : MonoBehaviour, INetworkStateReceiver
	{
		private INetworkedArea _area;

		private Coroutine _closeCoroutine;

		[SerializeField]
		private float _closeDelay = 5f;

		private HashSet<Collider> _collidersInside = new HashSet<Collider>();

		private int _nextCleanupFrame;

		[SerializeField]
		private int _stateEntered = 1;

		[SerializeField]
		private int _stateExited;

		private INetworkStateRegistry _stateRegistry;

		[SerializeField]
		private MonoBehaviour[] _targets;

		public int ReceiverId { get; private set; }

		public void SetState(int state, bool initialValue)
		{
			MonoBehaviour[] targets = _targets;
			foreach (MonoBehaviour monoBehaviour in targets)
			{
				if (monoBehaviour is INetworkTriggerStateTarget networkTriggerStateTarget)
				{
					networkTriggerStateTarget.SetState(state, initialValue);
				}
				else
				{
					Debug.LogError("Target does not implement INetworkTriggerStateTarget", monoBehaviour.gameObject);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			_stateRegistry.Unregister(this);
			if (_closeCoroutine != null)
			{
				StopCoroutine(_closeCoroutine);
				_closeCoroutine = null;
			}
		}

		protected void OnTriggerEnter(Collider other)
		{
			_collidersInside.Add(other);
			if (_area.IsOwner)
			{
				_stateRegistry.SetState(this, _stateEntered);
			}
			if (_closeCoroutine != null)
			{
				StopCoroutine(_closeCoroutine);
				_closeCoroutine = null;
			}
		}

		protected void OnTriggerExit(Collider other)
		{
			if (Time.frameCount > _nextCleanupFrame)
			{
				_nextCleanupFrame = Time.frameCount + 300;
				RemoveDestroyedColliders();
			}
			_collidersInside.Remove(other);
			if (_collidersInside.Count == 0 && _area.IsOwner)
			{
				_closeCoroutine = StartCoroutine(CloseAfterDelay(_closeDelay));
			}
		}

		protected virtual void Start()
		{
			_area = GetComponentInParent<INetworkedArea>();
			_stateRegistry = FlightSceneScript.Instance.NetworkStateRegistry;
			ReceiverId = _stateRegistry.Register(this, Utilities.GetFullObjectHierarchy(base.transform));
		}

		private IEnumerator CloseAfterDelay(float delay)
		{
			yield return new WaitForSeconds(delay);
			_stateRegistry.SetState(this, _stateExited);
			_closeCoroutine = null;
		}

		private void RemoveDestroyedColliders()
		{
			List<Collider> list = null;
			foreach (Collider item in _collidersInside)
			{
				if (item == null || item.gameObject == null)
				{
					if (list == null)
					{
						list = new List<Collider>();
					}
					list.Add(item);
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (Collider item2 in list)
			{
				_collidersInside.Remove(item2);
			}
		}
	}
}
