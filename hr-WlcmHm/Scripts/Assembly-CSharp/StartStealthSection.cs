using DG.Tweening;
using UnityEngine;

public class StartStealthSection : MonoBehaviour
{
	[SerializeField]
	private Transform _lookAtObject;

	[SerializeField]
	private float _duration;

	[SerializeField]
	private float _tweenDuration = 0.1f;

	private GameObject _player;

	private FirstPersonController _playerController;

	public GameObject deactivatePart1Leader;

	public GameObject activatePart2Leader;

	public GameObject destroyKillBox;

	public GameObject destroyKillBox2;

	public KillDoorController killDoorController;

	private bool _triggered;

	private float _timeElapsed;

	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
		_playerController = _player.GetComponent<FirstPersonController>();
	}

	private void Update()
	{
		if (_triggered)
		{
			if (_timeElapsed == 0f)
			{
				_playerController.playerCamera.transform.DOLookAt(_lookAtObject.transform.position, _tweenDuration);
				_playerController.transform.DOLookAt(_lookAtObject.transform.position, _tweenDuration);
			}
			if (_timeElapsed >= _tweenDuration)
			{
				_playerController.playerCamera.transform.DOLookAt(_lookAtObject.transform.position, 0f);
			}
			if (_timeElapsed > _duration)
			{
				_playerController.EnableInput();
				Object.Destroy(base.gameObject);
			}
			_timeElapsed += Time.deltaTime;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == _player && !_triggered)
		{
			killDoorController.magicNr = -9999;
			deactivatePart1Leader.gameObject.SetActive(value: false);
			activatePart2Leader.gameObject.SetActive(value: true);
			destroyKillBox.gameObject.SetActive(value: false);
			destroyKillBox2.gameObject.SetActive(value: false);
			_triggered = true;
			_playerController.isWalking = false;
			_playerController.DisableInput();
			Debug.Log("Jumpscare!");
		}
	}
}
