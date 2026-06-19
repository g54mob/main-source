using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class WorldSpaceManager : MonoBehaviour
	{
		public enum PositionMode
		{
			Local = 0,
			World = 1
		}

		public List<AudioSource> audioSources = new List<AudioSource>();

		public Camera mainCamera;

		public Camera projectorCam;

		[SerializeField]
		private RawImage rendererImage;

		[SerializeField]
		private Transform enterMount;

		[SerializeField]
		private Canvas osCanvas;

		[SerializeField]
		private PressKeyEvent pressKeyEvent;

		public bool requiresOpening = true;

		public bool autoGetIn;

		[SerializeField]
		private bool warmComponents;

		[SerializeField]
		private bool setCursorState = true;

		[SerializeField]
		private bool useMipMap;

		[SerializeField]
		private bool dynamicRTSize = true;

		[SerializeField]
		private int rtWidth = 1920;

		[SerializeField]
		private int rtHeight = 1080;

		public string playerTag = "Player";

		public InputAction getInKey = new InputAction();

		public InputAction getOutKey = new InputAction();

		[Range(1f, 10f)]
		public float audioBlendSpeed = 3f;

		[Range(0.1f, 4f)]
		public float transitionTime = 1f;

		public AnimationCurve transitionCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public PositionMode positionMode;

		public UnityEvent onTriggerEnter = new UnityEvent();

		public UnityEvent onTriggerExit = new UnityEvent();

		public UnityEvent onEnter = new UnityEvent();

		public UnityEvent onEnterEnd = new UnityEvent();

		public UnityEvent onExit = new UnityEvent();

		public UnityEvent onExitEnd = new UnityEvent();

		[HideInInspector]
		public RenderTexture uiRT;

		[HideInInspector]
		public int selectedTagIndex;

		[HideInInspector]
		public bool isInSystem;

		private bool isInTrigger;

		private bool takenLocalRootPos;

		private CanvasGroup osCG;

		private Quaternion camRotHelper;

		private Vector3 targetRootPos = new Vector3(0f, 0f, 0f);

		private void Awake()
		{
			if (dynamicRTSize)
			{
				uiRT = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.RGB111110Float);
			}
			else
			{
				uiRT = new RenderTexture(rtWidth, rtHeight, 24, RenderTextureFormat.RGB111110Float);
			}
			uiRT.useMipMap = useMipMap;
			if (projectorCam == null)
			{
				Debug.LogError("<b>[DreamOS]</b> Projector Camera is missing.");
				return;
			}
			projectorCam.targetTexture = uiRT;
			projectorCam.enabled = true;
			if (rendererImage != null)
			{
				rendererImage.texture = uiRT;
			}
			else
			{
				Debug.LogWarning("<b>[DreamOS]</b> Renderer Image is missing. The system will work but won't be rendered in 3D.");
			}
			osCG = osCanvas.GetComponent<CanvasGroup>();
			osCG.interactable = false;
			osCG.blocksRaycasts = false;
			if (pressKeyEvent != null)
			{
				pressKeyEvent.enabled = false;
			}
			if (mainCamera == null)
			{
				mainCamera = Camera.main;
			}
		}

		private void Start()
		{
			if (warmComponents && requiresOpening)
			{
				Invoke("WarmComponentsHelper", 0.5f);
			}
			else if (requiresOpening)
			{
				osCanvas.gameObject.SetActive(value: false);
			}
		}

		private void OnEnable()
		{
			getInKey.Enable();
			getOutKey.Enable();
		}

		private void OnDisable()
		{
			getInKey.Disable();
			getOutKey.Disable();
		}

		private void Update()
		{
			if (!isInSystem && getInKey.triggered)
			{
				TransitionInHelper();
			}
			else if (!isInTrigger && isInSystem && getOutKey.triggered)
			{
				TransitionOutHelper();
			}
		}

		public void GetIn()
		{
			if (Time.timeScale != 0f)
			{
				isInTrigger = true;
				TransitionInHelper();
			}
		}

		public void GetOut()
		{
			TransitionOutHelper();
		}

		private void TransitionInHelper()
		{
			if (isInTrigger && !isInSystem)
			{
				onEnter.Invoke();
				onTriggerExit.Invoke();
				osCG.interactable = true;
				osCG.blocksRaycasts = true;
				if (pressKeyEvent != null)
				{
					pressKeyEvent.enabled = true;
				}
				if (positionMode == PositionMode.World)
				{
					targetRootPos = mainCamera.transform.position;
				}
				else if (positionMode == PositionMode.Local && !takenLocalRootPos)
				{
					targetRootPos = mainCamera.transform.localPosition;
					takenLocalRootPos = true;
				}
				camRotHelper = mainCamera.transform.localRotation;
				isInTrigger = false;
				osCanvas.gameObject.SetActive(value: true);
				if (setCursorState)
				{
					Cursor.visible = true;
					Cursor.lockState = CursorLockMode.None;
				}
				StopCoroutine("CameraTransitionIn");
				StartCoroutine("CameraTransitionIn");
				if (audioSources.Count != 0)
				{
					StopCoroutine("BlendAudioSources2D");
					StartCoroutine("BlendAudioSources2D");
				}
			}
		}

		private void TransitionOutHelper()
		{
			onExit.Invoke();
			onTriggerEnter.Invoke();
			osCG.interactable = false;
			osCG.blocksRaycasts = false;
			if (pressKeyEvent != null)
			{
				pressKeyEvent.enabled = false;
			}
			projectorCam.enabled = true;
			osCanvas.renderMode = RenderMode.ScreenSpaceCamera;
			if (setCursorState)
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Confined;
			}
			StopCoroutine("CameraTransitionOut");
			StartCoroutine("CameraTransitionOut");
			if (audioSources.Count != 0)
			{
				StopCoroutine("BlendAudioSources3D");
				StartCoroutine("BlendAudioSources3D");
			}
		}

		private void WarmComponentsHelper()
		{
			osCanvas.gameObject.SetActive(value: false);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == playerTag)
			{
				isInTrigger = true;
				onTriggerEnter.Invoke();
				if (autoGetIn)
				{
					TransitionInHelper();
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag == playerTag)
			{
				isInTrigger = false;
				onTriggerExit.Invoke();
			}
		}

		private IEnumerator CameraTransitionIn()
		{
			StopCoroutine("CameraTransitionOut");
			float elapsedTime = 0f;
			Vector3 startingPos = mainCamera.transform.position;
			Quaternion startingRot = mainCamera.transform.rotation;
			while (elapsedTime < transitionTime)
			{
				mainCamera.transform.position = Vector3.Lerp(startingPos, enterMount.position, transitionCurve.Evaluate(elapsedTime / transitionTime));
				mainCamera.transform.rotation = Quaternion.Slerp(startingRot, enterMount.rotation, transitionCurve.Evaluate(elapsedTime / transitionTime));
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			mainCamera.transform.position = enterMount.position;
			mainCamera.transform.rotation = enterMount.rotation;
			osCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			projectorCam.enabled = false;
			isInSystem = true;
			onEnterEnd.Invoke();
		}

		private IEnumerator CameraTransitionOut()
		{
			StopCoroutine("CameraTransitionIn");
			float elapsedTime = 0f;
			Vector3 startingPos = mainCamera.transform.localPosition;
			Quaternion startingRot = mainCamera.transform.localRotation;
			while (elapsedTime < transitionTime)
			{
				mainCamera.transform.localPosition = Vector3.Lerp(startingPos, targetRootPos, transitionCurve.Evaluate(elapsedTime / transitionTime));
				mainCamera.transform.localRotation = Quaternion.Slerp(startingRot, camRotHelper, transitionCurve.Evaluate(elapsedTime / transitionTime));
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			mainCamera.transform.localPosition = targetRootPos;
			mainCamera.transform.localRotation = camRotHelper;
			isInSystem = false;
			isInTrigger = true;
			onExitEnd.Invoke();
		}

		private IEnumerator BlendAudioSources2D()
		{
			StopCoroutine("BlendAudioSources3D");
			float elapsedTime = 0f;
			float startinPoint = audioSources[0].spatialBlend;
			while ((double)audioSources[0].spatialBlend > 0.01)
			{
				foreach (AudioSource audioSource in audioSources)
				{
					if (!(audioSource == null))
					{
						audioSource.spatialBlend = Mathf.Lerp(startinPoint, 0f, elapsedTime * audioBlendSpeed);
					}
				}
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			foreach (AudioSource audioSource2 in audioSources)
			{
				audioSource2.spatialBlend = 0f;
			}
		}

		private IEnumerator BlendAudioSources3D()
		{
			StopCoroutine("BlendAudioSources2D");
			float elapsedTime = 0f;
			float startinPoint = audioSources[0].spatialBlend;
			while ((double)audioSources[0].spatialBlend < 0.99)
			{
				foreach (AudioSource audioSource in audioSources)
				{
					if (!(audioSource == null))
					{
						audioSource.spatialBlend = Mathf.Lerp(startinPoint, 1f, elapsedTime * audioBlendSpeed);
					}
				}
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			foreach (AudioSource audioSource2 in audioSources)
			{
				audioSource2.spatialBlend = 1f;
			}
		}
	}
}
