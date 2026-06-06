using System.Collections.Generic;
using PajamaLlama.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class AnimationTools : MonoBehaviour
{
	public class RigEvent : UnityEvent<DrifterRigItemEvent>
	{
	}

	public class RigTypeEvent : UnityEvent<DrifterRigEventType>
	{
	}

	[SerializeField]
	[FormerlySerializedAs("_chest")]
	private Transform _chestSocket;

	[SerializeField]
	[FormerlySerializedAs("_leftHand")]
	private Transform _leftHandSocket;

	[SerializeField]
	[FormerlySerializedAs("_rightHand")]
	private Transform _rightHandSocket;

	[SerializeField]
	private Transform _leftFloaterSocket;

	[SerializeField]
	private Transform _rightFloaterSocket;

	[SerializeField]
	private Transform _leftHipSocket;

	[SerializeField]
	private Transform _rightHipSocket;

	private Agent _agent;

	private GameObject _backpack;

	private GameObject _leftHandPrefab;

	private GameObject _leftHandInstance;

	private GameObject _rightHandPrefab;

	private GameObject _rightHandInstance;

	private GameObject _leftFloaterPrefab;

	private GameObject _leftFloaterInstance;

	private GameObject _rightFloaterPrefab;

	private GameObject _rightFloaterInstance;

	private GameObject _leftHipPrefab;

	private GameObject _leftHipInstance;

	private GameObject _rightHipPrefab;

	private GameObject _rightHipInstance;

	private static Dictionary<GameObject, List<GameObject>> _toolInstances = new Dictionary<GameObject, List<GameObject>>();

	public RigEvent DrifterRigEvent { get; private set; } = new RigEvent();

	public RigTypeEvent DrifterRigTypeEvent { get; private set; } = new RigTypeEvent();

	public void Initialize(Agent agent)
	{
		_agent = agent;
		if (_agent != null)
		{
			_backpack = Object.Instantiate(_agent.Properties.BackpackPrefab).gameObject;
			_backpack.transform.SetParent(_chestSocket, worldPositionStays: true);
			_backpack.transform.localPosition = Vector3.zero;
			_backpack.transform.localRotation = Quaternion.identity;
			_backpack.SetActive(value: false);
			_agent.Inventory.InventoryUpdatedEvent.AddListener(CheckForBackpack);
		}
	}

	private void OnDestroy()
	{
		if (_agent != null)
		{
			_agent.Inventory.InventoryUpdatedEvent.RemoveListener(CheckForBackpack);
		}
	}

	public void CheckForBackpack()
	{
		if (_backpack == null)
		{
			return;
		}
		Activity currentActivity = _agent.CurrentActivity;
		if ((uint)(currentActivity - 5) <= 1u)
		{
			Navigator navigator = _agent.ReturnNavigator();
			if (navigator.Terrain == Navigator.TerrainType.Construction || navigator.Terrain == Navigator.TerrainType.UnityNavMesh)
			{
				_backpack.SetActive(value: false);
				return;
			}
		}
		_backpack.SetActive(0 < _agent.Inventory.ReturnCount());
	}

	public void ClearAnimationTools()
	{
		ClearLeftHand();
		ClearRightHand();
		ClearLeftFloater();
		ClearRightFloater();
		ClearLeftHip();
		ClearRightHip();
	}

	private void SetSocket(Object toolToSet, Transform socket, ref GameObject currentTool, ref GameObject currentToolInstance)
	{
		if (!(toolToSet == currentTool))
		{
			if (currentToolInstance != null)
			{
				ReleaseToolInstance(currentTool, currentToolInstance);
			}
			currentTool = toolToSet as GameObject;
			if ((bool)currentTool)
			{
				currentToolInstance = ReturnToolInstance(currentTool);
				Transform obj = currentToolInstance.transform;
				obj.SetParent(socket);
				obj.CopyLocalPositionRotationAndScale(currentTool.transform);
			}
			else
			{
				currentToolInstance = currentTool;
			}
		}
	}

	public void OnDrifterRigItemEvent(DrifterRigItemEvent evt)
	{
		evt.Dispatch(this);
	}

	public void OnDrifterRigEvent(DrifterRigEventType evt)
	{
		evt.Dispatch(this);
	}

	public void SetLeftHand(Object socketFiller)
	{
		SetSocket(socketFiller, _leftHandSocket, ref _leftHandPrefab, ref _leftHandInstance);
	}

	public void ClearLeftHand()
	{
		ReleaseToolInstance(_leftHandPrefab, _leftHandInstance);
		_leftHandPrefab = null;
		_leftHandInstance = null;
	}

	public void SetRightHand(Object socketFiller)
	{
		SetSocket(socketFiller, _rightHandSocket, ref _rightHandPrefab, ref _rightHandInstance);
	}

	public void ClearRightHand()
	{
		ReleaseToolInstance(_rightHandPrefab, _rightHandInstance);
		_rightHandPrefab = null;
		_rightHandInstance = null;
	}

	public void SetLeftFloater(Object socketFiller)
	{
		SetSocket(socketFiller, _leftFloaterSocket, ref _leftFloaterPrefab, ref _leftFloaterInstance);
	}

	public void ClearLeftFloater()
	{
		ReleaseToolInstance(_leftFloaterPrefab, _leftFloaterInstance);
		_leftFloaterPrefab = null;
		_leftFloaterInstance = null;
	}

	public void SetRightFloater(Object socketFiller)
	{
		SetSocket(socketFiller, _rightFloaterSocket, ref _rightFloaterPrefab, ref _rightFloaterInstance);
	}

	public void ClearRightFloater()
	{
		ReleaseToolInstance(_rightFloaterPrefab, _rightFloaterInstance);
		_rightFloaterPrefab = null;
		_rightFloaterInstance = null;
	}

	public void SetLeftHip(Object socketFiller)
	{
		SetSocket(socketFiller, _leftHipSocket, ref _leftHipPrefab, ref _leftHipInstance);
	}

	public void ClearLeftHip()
	{
		ReleaseToolInstance(_leftHipPrefab, _leftHipInstance);
		_leftHipPrefab = null;
		_leftHipInstance = null;
	}

	public void SetRightHip(Object socketFiller)
	{
		SetSocket(socketFiller, _rightHipSocket, ref _rightHipPrefab, ref _rightHipInstance);
	}

	public void ClearRightHip()
	{
		ReleaseToolInstance(_rightHipPrefab, _rightHipInstance);
		_rightHipPrefab = null;
		_rightHipInstance = null;
	}

	private GameObject ReturnToolInstance(GameObject prefab)
	{
		GameObject gameObject = null;
		if (_toolInstances.TryGetValue(prefab, out var value) && 0 < value.Count)
		{
			while (0 < value.Count)
			{
				int index = value.Count - 1;
				gameObject = value[index];
				value.RemoveAt(index);
				if ((bool)gameObject)
				{
					break;
				}
			}
		}
		if (gameObject == null)
		{
			gameObject = Object.Instantiate(prefab);
		}
		gameObject.SetActive(value: true);
		return gameObject;
	}

	private void ReleaseToolInstance(GameObject prefab, GameObject instance)
	{
		if ((bool)instance)
		{
			instance.SetActive(value: false);
			if (_toolInstances.TryGetValue(prefab, out var value))
			{
				value.Add(instance);
				return;
			}
			_toolInstances.Add(prefab, new List<GameObject> { instance });
		}
	}
}
