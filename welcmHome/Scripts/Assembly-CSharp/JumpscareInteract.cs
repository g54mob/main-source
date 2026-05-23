using System.Collections;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class JumpscareInteract : MonoBehaviour, IInteractable
{
	[Header("Jumpscare Type")]
	[SerializeField]
	private bool barnGates;

	[SerializeField]
	private bool leaderRoom;

	[Header("Jumpscare Variables")]
	[SerializeField]
	private Jumpscare _jumpscareObject;

	[SerializeField]
	private float _durationUntilTalk;

	[SerializeField]
	private float _tweenDuration = 0.1f;

	[SerializeField]
	private GameObject Monolouge;

	[SerializeField]
	private string actionName;

	public EventReference jumpscareSound;

	private bool _hasActivatedJumpscare;

	private GameObject _player;

	private FirstPersonController _playerController;

	private Jumpscare _jumpscare;

	private Transform _jumpscareFacePoint;

	private bool _triggered;

	private float _timeElapsed;

	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
		_playerController = _player.GetComponent<FirstPersonController>();
		_jumpscare = _jumpscareObject.GetComponent<Jumpscare>();
		_jumpscareFacePoint = _jumpscare.transform.Find("FacePoint");
		_hasActivatedJumpscare = _player.GetComponentInChildren<StaticStateManager>().getHasActivatedGateJumpsscare();
	}

	private void Update()
	{
	}

	private void TriggerJumpscare()
	{
		if (!_triggered)
		{
			_player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			PlayInteractSound();
			_triggered = true;
			_playerController.DisableInput();
			_jumpscare.Scare();
			StartCoroutine(StartJumpscare());
			Debug.Log("Jumpscare!");
		}
	}

	public void Interact()
	{
		if (leaderRoom && InventoryManager.Instance.inventoryItems.Contains("Leader Room Key"))
		{
			TriggerJumpscare();
		}
		else if (barnGates && !_hasActivatedJumpscare)
		{
			_player.GetComponentInChildren<StaticStateManager>().setHasActivatedGateJumpsscare(s: true);
			_hasActivatedJumpscare = true;
			TriggerJumpscare();
		}
		else if (barnGates && _hasActivatedJumpscare)
		{
			Monolouge.GetComponent<LookScript>().Interact();
		}
	}

	private IEnumerator StartJumpscare()
	{
		yield return new WaitForSeconds(0.2f);
		if (_jumpscare.GetComponent<JumpscareSpawn>()._isPlaced)
		{
			if (_jumpscare.GetType() == typeof(JumpscareSpawn))
			{
				_jumpscare.transform.GetComponent<CapsuleCollider>().enabled = false;
				Vector3 normalized = (_jumpscareFacePoint.position - _playerController.transform.position).normalized;
				normalized.y = 0f;
				Quaternion endValue = Quaternion.LookRotation(normalized);
				_playerController.transform.DORotateQuaternion(endValue, _tweenDuration);
				Vector3 normalized2 = (_jumpscareFacePoint.position - _playerController.playerCamera.transform.position).normalized;
				normalized2.y = 0f;
				Quaternion endValue2 = Quaternion.LookRotation(normalized2);
				_playerController.playerCamera.transform.DORotateQuaternion(endValue2, _tweenDuration);
			}
			yield return new WaitForSeconds(_durationUntilTalk);
			_jumpscare.transform.GetComponent<CapsuleCollider>().enabled = true;
			_jumpscare.transform.GetComponent<NPCBaseController>().Interact();
			yield return 0;
		}
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}

	public string GetActionName()
	{
		return actionName;
	}

	public string GetName()
	{
		return " ";
	}

	public void PlayInteractSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(jumpscareSound);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	public string GetActionType()
	{
		return "Press";
	}
}
