using System.Collections;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class JumpscareTriggerSpawn : MonoBehaviour
{
	[Header("Jumpscare Variables")]
	[SerializeField]
	private Jumpscare _jumpscareObject;

	[SerializeField]
	private float _durationUntilTalk;

	[SerializeField]
	private float _tweenDuration = 0.1f;

	public EventReference jumpscareSound;

	private GameObject _player;

	private FirstPersonController _playerController;

	private Jumpscare _jumpscare;

	private Transform _jumpscareFacePoint;

	private bool _triggered;

	private void Start()
	{
		if (GetComponent<MeshRenderer>() != null)
		{
			GetComponent<MeshRenderer>().enabled = false;
		}
		_player = GameObject.FindGameObjectWithTag("Player");
		_playerController = _player.GetComponent<FirstPersonController>();
		_jumpscare = _jumpscareObject.GetComponent<Jumpscare>();
		_jumpscareFacePoint = _jumpscare.transform.Find("FacePoint");
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == _player && !_triggered)
		{
			_playerController.isWalking = false;
			TriggerJumpscare();
			OnJumpscareSound();
			base.transform.GetComponent<Collider>().enabled = false;
		}
	}

	private void TriggerJumpscare()
	{
		_player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		if (!_triggered)
		{
			_triggered = true;
			_playerController.DisableInput();
			_jumpscare.Scare();
			StartCoroutine(StartJumpscare());
			Debug.Log("Jumpscare!");
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

	private void OnJumpscareSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(jumpscareSound);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
