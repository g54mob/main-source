using System.Collections;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval
{
	public class CameraVisuals : MonoSingleton<CameraVisuals>
	{
		[SerializeField]
		private float groundOffset = 0.2f;

		[Header("Visuals")]
		[SerializeField]
		private GameObject cameraDot;

		[SerializeField]
		private GameObject cameraLock;

		[SerializeField]
		private GameObject cameraTranslateArrows;

		[SerializeField]
		private GameObject cameraRotateArrows;

		[SerializeField]
		private GameObject layerOffsetCylinder;

		[SerializeField]
		private float lerpDampening = 1f;

		[SerializeField]
		private float clickIndicatorShowDelay = 0.05f;

		private bool rightClickCountdownStarted;

		private float rightClickTimeHeld;

		private bool showVisualsAfterRightClickHeld;

		private bool isAimMoving;

		private bool middleClickCountdownStarted;

		private float middleClickTimeHeld;

		private bool showVisualsAfterMiddleClickHeld;

		private bool isAimRotating;

		private readonly float cameraTranslationTolerance = 5E-05f;

		private readonly float distanceTolerance = 0.01f;

		private float lerpTolerance = 0.01f;

		private int currentLayer;

		private int targetLayer;

		private int startLayer;

		private bool lerping;

		private Coroutine translateDelayTimer;

		private Coroutine rotateDelayTimer;

		private Coroutine dotDelayTimer;

		private float translateArrowHideTime;

		private float rotateArrowHideTime;

		private float zoomDotHideTime;

		private bool subscribed;

		private bool isAbleToChangeLerpSpeed = true;

		private float lerpSpeed;

		[SerializeField]
		private Animator dotAnimator;

		[SerializeField]
		private Animator lockAnimator;

		private Vector3 initDotScale;

		private bool afterJump;

		public bool Lerping => lerping;

		public Animator LockAnimator => lockAnimator;

		public float LerpSpeed => CalculateLerpSpeed();

		public GameObject CameraDot => cameraDot;

		public void ResetVisuals()
		{
			cameraDot.SetActive(value: false);
			cameraLock.SetActive(value: false);
			cameraTranslateArrows.SetActive(value: false);
			cameraRotateArrows.SetActive(value: false);
		}

		public void OnRightClickShowVisuals()
		{
			rightClickTimeHeld = 0f;
			rightClickCountdownStarted = true;
		}

		public void OnHideTranslateVisuals()
		{
			rightClickTimeHeld = 0f;
			rightClickCountdownStarted = false;
			showVisualsAfterRightClickHeld = false;
			isAimMoving = false;
			if (translateDelayTimer != null)
			{
				StopCoroutine(translateDelayTimer);
			}
			if (dotDelayTimer != null)
			{
				StopCoroutine(dotDelayTimer);
			}
			translateDelayTimer = StartCoroutine(CoroutineTranslateDelayTimer());
			dotDelayTimer = StartCoroutine(CoroutineDotDelayTimer());
		}

		public void OnMiddleClickShowVisuals()
		{
			middleClickTimeHeld = 0f;
			middleClickCountdownStarted = true;
		}

		public void OnHideRotateVisuals()
		{
			middleClickTimeHeld = 0f;
			middleClickCountdownStarted = false;
			showVisualsAfterMiddleClickHeld = false;
			isAimRotating = false;
			if (rotateDelayTimer != null)
			{
				StopCoroutine(rotateDelayTimer);
			}
			if (dotDelayTimer != null)
			{
				StopCoroutine(dotDelayTimer);
			}
			rotateDelayTimer = StartCoroutine(CoroutineRotateDelayTimer());
			dotDelayTimer = StartCoroutine(CoroutineDotDelayTimer());
		}

		private void Update()
		{
			if (rightClickCountdownStarted)
			{
				rightClickTimeHeld += Time.unscaledDeltaTime;
				if (rightClickTimeHeld >= clickIndicatorShowDelay)
				{
					rightClickCountdownStarted = false;
					showVisualsAfterRightClickHeld = true;
				}
			}
			if (middleClickCountdownStarted)
			{
				middleClickTimeHeld += Time.unscaledDeltaTime;
				if (middleClickTimeHeld >= clickIndicatorShowDelay)
				{
					middleClickCountdownStarted = false;
					showVisualsAfterMiddleClickHeld = true;
				}
			}
			if (showVisualsAfterRightClickHeld && !isAimMoving)
			{
				if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraVisuals && MonoSingleton<RtsCamera>.Instance.TargetToFollow == null)
				{
					cameraDot.SetActive(value: true);
					cameraLock.SetActive(value: true);
					layerOffsetCylinder.SetActive(value: true);
					cameraTranslateArrows.SetActive(value: true);
				}
				SetPosition();
			}
			if (showVisualsAfterMiddleClickHeld && !isAimRotating)
			{
				if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraVisuals && MonoSingleton<RtsCamera>.Instance.TargetToFollow == null)
				{
					cameraDot.SetActive(value: true);
					cameraLock.SetActive(value: true);
					layerOffsetCylinder.SetActive(value: true);
					cameraRotateArrows.SetActive(value: true);
				}
				SetPosition();
			}
		}

		private void StopAllVisualCoroutines()
		{
			if (translateDelayTimer != null)
			{
				StopCoroutine(translateDelayTimer);
			}
			if (dotDelayTimer != null)
			{
				StopCoroutine(dotDelayTimer);
			}
			if (rotateDelayTimer != null)
			{
				StopCoroutine(rotateDelayTimer);
			}
		}

		private float CalculateLerpSpeed()
		{
			if (!isAbleToChangeLerpSpeed)
			{
				return lerpSpeed;
			}
			if (startLayer - targetLayer == 0)
			{
				return 1f;
			}
			isAbleToChangeLerpSpeed = false;
			float num = 1f + 0.2f * (float)Mathf.Abs(startLayer - targetLayer);
			lerpSpeed = num * lerpDampening * (float)World.MapBlockHeight / (float)Mathf.Abs(startLayer - targetLayer);
			SetLerpTolerance();
			return lerpSpeed;
		}

		private void SetLerpTolerance()
		{
			lerpTolerance = 0.01f / lerpSpeed;
		}

		private void Start()
		{
			MonoSingleton<GlobalSaveController>.Instance.OnGlobalSaveUpdate += SetupCameraVisuals;
			MonoSingleton<OptionsController>.Instance.CameraVisualsDurationChangedEvent += UpdateCameraVisualsDurationTime;
			MonoSingleton<RtsCamera>.Instance.LockedLayerChangedEvent += SetLockedPosition;
			ResetVisuals();
			initDotScale = cameraDot.transform.localScale;
		}

		private void UpdateCameraVisualsDurationTime()
		{
			float cameraVisualsDurationTime = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraVisualsDurationTime;
			translateArrowHideTime = cameraVisualsDurationTime * 0.15f;
			rotateArrowHideTime = cameraVisualsDurationTime * 0.15f;
			zoomDotHideTime = cameraVisualsDurationTime * 0.6f;
		}

		public void SetupCameraVisuals()
		{
			if (!subscribed)
			{
				MonoSingleton<RtsCamera>.Instance.CameraUpdateEvent += OnUpdateCameraVisuals;
				subscribed = true;
				UpdateCameraVisualsDurationTime();
			}
		}

		private void OnUpdateCameraVisuals()
		{
			currentLayer = Mathf.FloorToInt(MonoSingleton<RtsCamera>.Instance.DesiredPosition.y);
			targetLayer = Mathf.RoundToInt(MonoSingleton<RtsCamera>.Instance.AimHeight);
			ChangeLayerCheck();
			OnCameraTranslating();
			OnCameraRotation();
			OnCameraZoom();
			OnCameraLerp();
			CoyoteTimeVisuals();
		}

		private void OnCameraTranslating()
		{
			isAimMoving = false;
			if (MonoSingleton<RtsCamera>.Instance.Jumping)
			{
				afterJump = true;
				return;
			}
			if (afterJump)
			{
				base.transform.position = MonoSingleton<RtsCamera>.Instance.CurrentPosition;
			}
			if (Mathf.Abs(MonoSingleton<RtsCamera>.Instance.CurrentPosition.x - MonoSingleton<RtsCamera>.Instance.DesiredPosition.x) <= cameraTranslationTolerance && Mathf.Abs(MonoSingleton<RtsCamera>.Instance.CurrentPosition.z - MonoSingleton<RtsCamera>.Instance.DesiredPosition.z) <= cameraTranslationTolerance)
			{
				if (afterJump)
				{
					afterJump = false;
					StopAllVisualCoroutines();
				}
			}
			else
			{
				if (afterJump)
				{
					return;
				}
				if (!showVisualsAfterRightClickHeld)
				{
					if (translateDelayTimer != null)
					{
						StopCoroutine(translateDelayTimer);
					}
					if (dotDelayTimer != null)
					{
						StopCoroutine(dotDelayTimer);
					}
					translateDelayTimer = StartCoroutine(CoroutineTranslateDelayTimer());
					dotDelayTimer = StartCoroutine(CoroutineDotDelayTimer());
				}
				isAimMoving = true;
				if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraVisuals && MonoSingleton<RtsCamera>.Instance.TargetToFollow == null)
				{
					cameraDot.SetActive(value: true);
					cameraLock.SetActive(value: true);
					layerOffsetCylinder.SetActive(value: true);
					cameraTranslateArrows.SetActive(value: true);
				}
				SetPosition();
			}
		}

		private void SetLockedPosition()
		{
			int lockedLayerIndex = MonoSingleton<RtsCamera>.Instance.LockedLayerIndex;
			base.transform.position = new Vector3(MonoSingleton<RtsCamera>.Instance.CurrentPosition.x, (float)(lockedLayerIndex * World.MapBlockHeight) + groundOffset, MonoSingleton<RtsCamera>.Instance.CurrentPosition.z);
		}

		private void SetPosition()
		{
			if (!lerping)
			{
				float num = MonoSingleton<RtsCamera>.Instance.DesiredPosition.y - MonoSingleton<RtsCamera>.Instance.Settings.LookAtHeightOffset;
				base.transform.position = new Vector3(MonoSingleton<RtsCamera>.Instance.CurrentPosition.x, num + groundOffset, MonoSingleton<RtsCamera>.Instance.CurrentPosition.z);
				currentLayer = Mathf.RoundToInt(num);
				Shader.SetGlobalFloat("_CameraYPosition", base.transform.position.y);
				Shader.SetGlobalFloat("_CameraZoomDistance", MonoSingleton<RtsCamera>.Instance.GetCameraData().Height);
			}
		}

		private void OnCameraLerp()
		{
			if (lerping)
			{
				float num = MonoSingleton<RtsCamera>.Instance.CurrentPosition.y - MonoSingleton<RtsCamera>.Instance.Settings.LookAtHeightOffset + groundOffset;
				base.transform.position = new Vector3(MonoSingleton<RtsCamera>.Instance.CurrentPosition.x, num, MonoSingleton<RtsCamera>.Instance.CurrentPosition.z);
				if (!(Mathf.Abs(num - groundOffset - (float)targetLayer) >= lerpTolerance))
				{
					Shader.SetGlobalFloat("_CameraYPosition", base.transform.position.y);
					lerping = false;
					isAbleToChangeLerpSpeed = true;
					currentLayer = targetLayer;
					dotAnimator.SetTrigger("CoyoteTimeReady");
				}
			}
		}

		private void OnCameraRotation()
		{
			isAimRotating = false;
			float num = Mathf.Abs(MonoSingleton<RtsCamera>.Instance.CurrentRotation - MonoSingleton<RtsCamera>.Instance.DesiredRotation);
			if (num >= 360f)
			{
				num -= 360f;
			}
			if (num <= distanceTolerance)
			{
				return;
			}
			if (!showVisualsAfterMiddleClickHeld)
			{
				if (rotateDelayTimer != null)
				{
					StopCoroutine(rotateDelayTimer);
				}
				if (dotDelayTimer != null)
				{
					StopCoroutine(dotDelayTimer);
				}
				rotateDelayTimer = StartCoroutine(CoroutineRotateDelayTimer());
				dotDelayTimer = StartCoroutine(CoroutineDotDelayTimer());
			}
			isAimRotating = true;
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraVisuals && MonoSingleton<RtsCamera>.Instance.TargetToFollow == null)
			{
				cameraRotateArrows.SetActive(value: true);
				cameraDot.SetActive(value: true);
			}
			SetPosition();
		}

		private void OnCameraZoom()
		{
			if (!(Mathf.Abs(MonoSingleton<RtsCamera>.Instance.GetCameraData().Height - MonoSingleton<RtsCamera>.Instance.DesiredHeight) <= distanceTolerance))
			{
				if (dotDelayTimer != null)
				{
					StopCoroutine(dotDelayTimer);
				}
				if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraVisuals && MonoSingleton<RtsCamera>.Instance.TargetToFollow == null)
				{
					cameraDot.SetActive(value: true);
					cameraLock.SetActive(value: true);
					layerOffsetCylinder.SetActive(value: true);
				}
				dotDelayTimer = StartCoroutine(CoroutineDotDelayTimer());
				SetPosition();
			}
		}

		private void ChangeLayerCheck()
		{
			if (MonoSingleton<RtsCamera>.Instance.ShouldCameraMoveToTargetLayer() && Mathf.Abs(targetLayer - currentLayer) >= 1 && !lerping)
			{
				lerping = true;
				startLayer = currentLayer;
			}
		}

		private IEnumerator CoroutineTranslateDelayTimer()
		{
			yield return new WaitForSecondsRealtime(translateArrowHideTime);
			cameraTranslateArrows.SetActive(value: false);
		}

		private IEnumerator CoroutineRotateDelayTimer()
		{
			yield return new WaitForSecondsRealtime(rotateArrowHideTime);
			cameraRotateArrows.SetActive(value: false);
		}

		private IEnumerator CoroutineDotDelayTimer()
		{
			yield return new WaitForSecondsRealtime(zoomDotHideTime);
			cameraDot.transform.localScale = initDotScale;
			cameraDot.SetActive(value: false);
			cameraLock.SetActive(value: false);
			layerOffsetCylinder.SetActive(value: false);
		}

		private void CoyoteTimeVisuals()
		{
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraVisuals || !(MonoSingleton<RtsCamera>.Instance.TargetToFollow != null))
			{
				Vector3 localScale = new Vector3
				{
					x = 0.2f,
					z = 0.2f,
					y = 0.01f + (base.transform.position.y - (float)targetLayer) / 2f
				};
				layerOffsetCylinder.transform.localScale = localScale;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				MonoSingleton<GlobalSaveController>.Instance.OnGlobalSaveUpdate -= SetupCameraVisuals;
			}
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.CameraVisualsDurationChangedEvent -= UpdateCameraVisualsDurationTime;
			}
			if (MonoSingleton<RtsCamera>.IsInstantiated())
			{
				MonoSingleton<RtsCamera>.Instance.LockedLayerChangedEvent -= SetLockedPosition;
			}
		}
	}
}
