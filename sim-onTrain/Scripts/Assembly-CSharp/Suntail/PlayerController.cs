using System;
using System.Collections.Generic;
using UnityEngine;

namespace Suntail
{
	public class PlayerController : MonoBehaviour
	{
		[Serializable]
		public class GroundLayer
		{
			public string layerName;

			public Texture2D[] groundTextures;

			public AudioClip[] footstepSounds;
		}

		[Header("Movement")]
		[Tooltip("Basic controller speed")]
		[SerializeField]
		private float walkSpeed;

		[Tooltip("Running controller speed")]
		[SerializeField]
		private float runMultiplier;

		[Tooltip("Force of the jump with which the controller rushes upwards")]
		[SerializeField]
		private float jumpForce;

		[Tooltip("Gravity, pushing down controller when it jumping")]
		[SerializeField]
		private float gravity = -9.81f;

		[Header("Mouse Look")]
		[SerializeField]
		private Camera playerCamera;

		[SerializeField]
		private float mouseSensivity;

		[SerializeField]
		private float mouseVerticalClamp;

		[Header("Keybinds")]
		[SerializeField]
		private KeyCode jumpKey = KeyCode.Space;

		[SerializeField]
		private KeyCode runKey = KeyCode.LeftShift;

		[Header("Footsteps")]
		[Tooltip("Footstep source")]
		[SerializeField]
		private AudioSource footstepSource;

		[Tooltip("Distance for ground texture checker")]
		[SerializeField]
		private float groundCheckDistance = 1f;

		[Tooltip("Footsteps playing rate")]
		[SerializeField]
		[Range(1f, 2f)]
		private float footstepRate = 1f;

		[Tooltip("Footstep rate when player running")]
		[SerializeField]
		[Range(1f, 2f)]
		private float runningFootstepRate = 1.5f;

		[Tooltip("Add textures for this layer and add sounds to be played for this texture")]
		public List<GroundLayer> groundLayers = new List<GroundLayer>();

		private float _horizontalMovement;

		private float _verticalMovement;

		private float _currentSpeed;

		private Vector3 _moveDirection;

		private Vector3 _velocity;

		private CharacterController _characterController;

		private bool _isRunning;

		private float _verticalRotation;

		private float _yAxis;

		private float _xAxis;

		private bool _activeRotation;

		private Terrain _terrain;

		private TerrainData _terrainData;

		private TerrainLayer[] _terrainLayers;

		private AudioClip _previousClip;

		private Texture2D _currentTexture;

		private RaycastHit _groundHit;

		private float _nextFootstep;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			GetTerrainData();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void GetTerrainData()
		{
			if ((bool)Terrain.activeTerrain)
			{
				_terrain = Terrain.activeTerrain;
				_terrainData = _terrain.terrainData;
				_terrainLayers = _terrain.terrainData.terrainLayers;
			}
		}

		private void Update()
		{
			Movement();
			MouseLook();
			GroundChecker();
		}

		private void Movement()
		{
			if (_characterController.isGrounded && _velocity.y < 0f)
			{
				_velocity.y = -2f;
			}
			if (Input.GetKey(jumpKey) && _characterController.isGrounded)
			{
				_velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
			}
			_horizontalMovement = Input.GetAxis("Horizontal");
			_verticalMovement = Input.GetAxis("Vertical");
			_moveDirection = base.transform.forward * _verticalMovement + base.transform.right * _horizontalMovement;
			_isRunning = Input.GetKey(runKey);
			_currentSpeed = walkSpeed * (_isRunning ? runMultiplier : 1f);
			_characterController.Move(_moveDirection * _currentSpeed * Time.deltaTime);
			_velocity.y += gravity * Time.deltaTime;
			_characterController.Move(_velocity * Time.deltaTime);
		}

		private void MouseLook()
		{
			_xAxis = Input.GetAxis("Mouse X");
			_yAxis = Input.GetAxis("Mouse Y");
			_verticalRotation += (0f - _yAxis) * mouseSensivity;
			_verticalRotation = Mathf.Clamp(_verticalRotation, 0f - mouseVerticalClamp, mouseVerticalClamp);
			playerCamera.transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
			base.transform.rotation *= Quaternion.Euler(0f, _xAxis * mouseSensivity, 0f);
		}

		private void FixedUpdate()
		{
			if (_characterController.isGrounded && (_horizontalMovement != 0f || _verticalMovement != 0f))
			{
				float num = (_isRunning ? runningFootstepRate : footstepRate);
				if (_nextFootstep >= 100f)
				{
					PlayFootstep();
					_nextFootstep = 0f;
				}
				_nextFootstep += num * walkSpeed;
			}
		}

		private void GroundChecker()
		{
			if (Physics.Raycast(new Ray(base.transform.position + Vector3.up * 0.1f, Vector3.down), out _groundHit, groundCheckDistance))
			{
				if ((bool)_groundHit.collider.GetComponent<Terrain>())
				{
					_currentTexture = _terrainLayers[GetTerrainTexture(base.transform.position)].diffuseTexture;
				}
				if ((bool)_groundHit.collider.GetComponent<Renderer>())
				{
					_currentTexture = GetRendererTexture();
				}
			}
		}

		private void PlayFootstep()
		{
			for (int i = 0; i < groundLayers.Count; i++)
			{
				for (int j = 0; j < groundLayers[i].groundTextures.Length; j++)
				{
					if (_currentTexture == groundLayers[i].groundTextures[j])
					{
						footstepSource.PlayOneShot(RandomClip(groundLayers[i].footstepSounds));
					}
				}
			}
		}

		private float[] GetTerrainTexturesArray(Vector3 controllerPosition)
		{
			_terrain = Terrain.activeTerrain;
			_terrainData = _terrain.terrainData;
			Vector3 position = _terrain.transform.position;
			int x = (int)((controllerPosition.x - position.x) / _terrainData.size.x * (float)_terrainData.alphamapWidth);
			int y = (int)((controllerPosition.z - position.z) / _terrainData.size.z * (float)_terrainData.alphamapHeight);
			float[,,] alphamaps = _terrainData.GetAlphamaps(x, y, 1, 1);
			float[] array = new float[alphamaps.GetUpperBound(2) + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = alphamaps[0, 0, i];
			}
			return array;
		}

		private int GetTerrainTexture(Vector3 controllerPosition)
		{
			float[] terrainTexturesArray = GetTerrainTexturesArray(controllerPosition);
			float num = 0f;
			int result = 0;
			for (int i = 0; i < terrainTexturesArray.Length; i++)
			{
				if (terrainTexturesArray[i] > num)
				{
					result = i;
					num = terrainTexturesArray[i];
				}
			}
			return result;
		}

		private Texture2D GetRendererTexture()
		{
			return (Texture2D)_groundHit.collider.gameObject.GetComponent<Renderer>().material.mainTexture;
		}

		private AudioClip RandomClip(AudioClip[] clips)
		{
			int num = 2;
			footstepSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
			AudioClip audioClip = clips[UnityEngine.Random.Range(0, clips.Length)];
			while (audioClip == _previousClip && num > 0)
			{
				audioClip = clips[UnityEngine.Random.Range(0, clips.Length)];
				num--;
			}
			_previousClip = audioClip;
			return audioClip;
		}
	}
}
