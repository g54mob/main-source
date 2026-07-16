using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FreeCamTool
{
	public class FreeCamTool : MonoBehaviour
	{
		[Header("Free Cam Tool Inputs")]
		[Header(" 6 - Toggle On / Off \n 7 - Set Start Pos \n 8 - Set End Pos  \n 9 - Start Cinematic Tween \n 0 - Switch Cam Rig Input ")]
		[Header(" WASD - Move \n Q / E - Up / Down \n Shift - Speed Up  \n RMB - Look ")]
		[Header(" Num 1 - moveTime - 1 \n Num 4 - moveTime + 1 \n Num 2 - moveSpeed - 1 \n Num 5 - moveSpeed + 1 \n Num 6 - Cancel Cinematic Shot")]
		[Header(" 1 - Cinematic shot Ease linear \n 2 - Cinematic shot Ease in out quint \n 3 - Cinematic shot Ease in out cubic")]
		[Header("In Refs")]
		public CinemachineVirtualCameraBase vCam;

		public Transform cam;

		public Transform startPos;

		public Transform endPos;

		[Header("FreeCam Settings")]
		public float moveSpeed = 10f;

		public float fastSpeedMultiplier = 3f;

		public float lookSensitivity = 2f;

		public bool requireRightClickToLook = true;

		public LeanTweenType ease;

		public LeanTweenType ease1;

		public LeanTweenType ease2;

		public LeanTweenType ease3;

		[Header("Cinematic Settings")]
		public float moveTime = 3f;

		[Header("Spawn Settings")]
		public Vector3 startRotation = Vector3.zero;

		[Header("Inputs")]
		[SerializeField]
		private InputActionMap inputMap;

		[Header("Debug")]
		[SerializeField]
		private bool receivedInput;

		[SerializeField]
		private Vector3 camStartPos;

		[SerializeField]
		private Vector3 camStartRot;

		private bool isActive;

		private float yaw;

		private float pitch;

		public bool freeCamInput;

		private void Start()
		{
			cam.gameObject.SetActive(value: false);
		}

		private void Awake()
		{
			inputMap.Enable();
			inputMap.actions[0].started += On0Pressed;
			inputMap.actions[0].canceled += On0Pressed;
			inputMap.actions[1].started += On1Pressed;
			inputMap.actions[1].canceled += On1Pressed;
			inputMap.actions[2].started += On2Pressed;
			inputMap.actions[2].canceled += On2Pressed;
			inputMap.actions[3].started += On3Pressed;
			inputMap.actions[3].canceled += On3Pressed;
			inputMap.actions[4].started += On4Pressed;
			inputMap.actions[4].canceled += On4Pressed;
			inputMap.actions[5].started += On5Pressed;
			inputMap.actions[5].canceled += On5Pressed;
			inputMap.actions[6].started += On6Pressed;
			inputMap.actions[6].canceled += On6Pressed;
			inputMap.actions[7].started += On7Pressed;
			inputMap.actions[7].canceled += On7Pressed;
			inputMap.actions[8].started += On8Pressed;
			inputMap.actions[8].canceled += On8Pressed;
			inputMap.actions[9].started += On9Pressed;
			inputMap.actions[9].canceled += On9Pressed;
			inputMap.actions[10].started += OnNum0Pressed;
			inputMap.actions[10].canceled += OnNum0Pressed;
			inputMap.actions[11].started += OnNum1Pressed;
			inputMap.actions[11].canceled += OnNum1Pressed;
			inputMap.actions[12].started += OnNum2Pressed;
			inputMap.actions[12].canceled += OnNum2Pressed;
			inputMap.actions[13].started += OnNum3Pressed;
			inputMap.actions[13].canceled += OnNum3Pressed;
			inputMap.actions[14].started += OnNum4Pressed;
			inputMap.actions[14].canceled += OnNum4Pressed;
			inputMap.actions[15].started += OnNum5Pressed;
			inputMap.actions[15].canceled += OnNum5Pressed;
			inputMap.actions[16].started += OnNum6Pressed;
			inputMap.actions[16].canceled += OnNum6Pressed;
		}

		private void Update()
		{
			if (isActive)
			{
				HandleMovement();
				HandleLook();
			}
		}

		public void SetStartPos()
		{
			startPos.SetParent(cam);
			startPos.position = cam.position;
			startPos.SetParent(cam.parent);
		}

		public void SetEndPosPos()
		{
			endPos.SetParent(cam);
			endPos.position = cam.position;
			endPos.SetParent(cam.parent);
		}

		public void StartCinematicShot()
		{
			if (cam.gameObject.activeInHierarchy)
			{
				StartCoroutine(CinematicShot());
			}
		}

		public void CancelCinematicShot()
		{
			StopAllCoroutines();
			LeanTween.cancel(cam.gameObject);
			vCam.LookAt = null;
			ResetCamRot();
		}

		private IEnumerator CinematicShot()
		{
			cam.position = startPos.position;
			yield return new WaitForSeconds(0.5f);
			MoveTo(cam.gameObject, endPos);
			yield return new WaitForSeconds(moveTime + 0.2f);
			vCam.LookAt = null;
			yield return new WaitForEndOfFrame();
			ResetCamRot();
		}

		private void ResetCamRot()
		{
			Quaternion rotation = cam.rotation;
			cam.rotation = Quaternion.identity;
			vCam.transform.rotation = Quaternion.identity;
			cam.rotation = rotation;
		}

		public void ActivateFreeCam()
		{
			Camera camera = GlobalReferences.GetCameraController().GetCamera();
			camStartPos = camera.transform.localPosition;
			camStartRot = camera.transform.localEulerAngles;
			cam.eulerAngles = startRotation;
			yaw = cam.eulerAngles.y;
			pitch = cam.eulerAngles.x;
			isActive = true;
			cam.gameObject.SetActive(value: true);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		public void DeactivateFreeCam()
		{
			isActive = false;
			cam.gameObject.SetActive(value: false);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Camera camera = GlobalReferences.GetCameraController().GetCamera();
			camera.transform.localPosition = camStartPos;
			camera.transform.localEulerAngles = camStartRot;
		}

		private void HandleMovement()
		{
			if (freeCamInput)
			{
				float num = moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? fastSpeedMultiplier : 1f);
				Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), (Input.GetKey(KeyCode.E) ? 1 : 0) - (Input.GetKey(KeyCode.Q) ? 1 : 0), Input.GetAxis("Vertical"));
				cam.Translate(vector * (num * Time.unscaledDeltaTime), Space.Self);
			}
		}

		private void HandleLook()
		{
			if (freeCamInput && (!requireRightClickToLook || Input.GetMouseButton(1)))
			{
				float num = Input.GetAxis("Mouse X") * lookSensitivity;
				float num2 = Input.GetAxis("Mouse Y") * lookSensitivity;
				yaw += num;
				pitch -= num2;
				pitch = Mathf.Clamp(pitch, -90f, 90f);
				cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(pitch, yaw, 0f), 5f * Time.deltaTime);
			}
		}

		private void MoveTo(GameObject go, Transform pos)
		{
			LeanTween.cancel(go);
			LeanTween.move(go, pos.position, moveTime).setEase(ease).setIgnoreTimeScale(useUnScaledTime: true);
		}

		private void ToggleFreeCam()
		{
			if (cam.gameObject.activeSelf)
			{
				DeactivateFreeCam();
			}
			else
			{
				ActivateFreeCam();
			}
		}

		public void On0Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				freeCamInput = !freeCamInput;
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On1Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				ease = ease1;
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On2Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				ease = ease2;
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On3Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				ease = ease3;
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On4Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On5Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On6Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				ToggleFreeCam();
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On7Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				SetStartPos();
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On8Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				SetEndPosPos();
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void On9Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				StartCinematicShot();
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void OnNum0Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void OnNum1Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				if (moveTime > 1f)
				{
					moveTime -= 1f;
				}
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void OnNum2Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				if (moveSpeed > 1f)
				{
					moveSpeed -= 1f;
				}
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void OnNum3Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void OnNum4Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				if (moveTime < 20f)
				{
					moveTime += 1f;
				}
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void OnNum5Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				if (moveSpeed < 20f)
				{
					moveSpeed += 1f;
				}
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}

		public void OnNum6Pressed(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (receivedInput)
				{
					return;
				}
				receivedInput = true;
				CancelCinematicShot();
			}
			if (context.canceled)
			{
				receivedInput = false;
			}
		}
	}
}
