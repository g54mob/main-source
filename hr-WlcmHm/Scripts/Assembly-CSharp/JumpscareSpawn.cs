using UnityEngine;

public class JumpscareSpawn : Jumpscare
{
	[SerializeField]
	private float _distanceFromPlayer;

	private NPCBaseController _dialogue;

	private GameObject _player;

	private FirstPersonController _playerController;

	[HideInInspector]
	public bool _isPlaced;

	private bool _triggered;

	private void Start()
	{
		base.gameObject.SetActive(value: false);
		_player = GameObject.FindGameObjectWithTag("Player");
		_playerController = _player.GetComponent<FirstPersonController>();
		_dialogue = base.gameObject.GetComponent<NPCBaseController>();
	}

	private void Update()
	{
		if (_triggered && !_isPlaced)
		{
			base.gameObject.transform.position = _player.transform.position - _player.transform.forward * _distanceFromPlayer;
			if (Physics.Raycast(new Ray(base.gameObject.transform.position, Vector3.down), out var hitInfo))
			{
				_ = base.gameObject.GetComponent<Collider>().bounds.extents;
				Debug.Log(hitInfo.point);
				base.gameObject.transform.position = hitInfo.point;
				Debug.Log(base.transform.position.y);
			}
			Vector3 forward = _player.transform.position - base.gameObject.transform.position;
			forward.y = 0f;
			base.gameObject.transform.rotation = Quaternion.LookRotation(forward);
			_isPlaced = true;
		}
	}

	public override void Scare()
	{
		base.gameObject.SetActive(value: true);
		_triggered = true;
	}
}
