using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
	[SerializeField]
	private Jumpscare _jumpscareObject;

	[SerializeField]
	private Transform _lookAtObject;

	[SerializeField]
	private float _duration;

	[SerializeField]
	private float _tweenDuration = 0.1f;

	private GameObject _player;

	private FirstPersonController _playerController;

	private Jumpscare _jumpscare;

	public EventReference jumpscareSound;

	private bool _triggered;

	private float _timeElapsed;

	private void Start()
	{
		if (GetComponent<MeshRenderer>() != null)
		{
			GetComponent<MeshRenderer>().enabled = false;
		}
		_player = GameObject.FindGameObjectWithTag("Player");
		_playerController = _player.GetComponent<FirstPersonController>();
		_jumpscare = _jumpscareObject.GetComponent<Jumpscare>();
	}

	private void Update()
	{
		if (!_triggered)
		{
			return;
		}
		if (_timeElapsed == 0f && _jumpscare.GetType() != typeof(JumpscareSpawn))
		{
			_playerController.playerCamera.transform.DOLookAt(_lookAtObject.transform.position, _tweenDuration);
			_playerController.transform.DOLookAt(_lookAtObject.transform.position, _tweenDuration);
		}
		if (_timeElapsed >= _tweenDuration && _jumpscare.GetType() != typeof(JumpscareSpawn))
		{
			_playerController.playerCamera.transform.DOLookAt(_lookAtObject.transform.position, 0f);
		}
		if (_timeElapsed > _duration)
		{
			if (_jumpscare.GetType() != typeof(JumpscareSpawn) && _jumpscare.GetType() != typeof(UndergroundJumpscare))
			{
				_playerController.EnableInput();
				_player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
			}
			Object.Destroy(base.gameObject);
		}
		_timeElapsed += Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == _player && !_triggered)
		{
			onJumpscareSound();
			_playerController.isWalking = false;
			_triggered = true;
			_playerController.DisableInput();
			_jumpscare.Scare();
			Debug.Log("Jumpscare!");
		}
	}

	private void onJumpscareSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(jumpscareSound);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
