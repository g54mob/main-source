using System.Collections;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class FancyLetterNotificationUI : StarAwardNotificationUI
	{
		[SerializeField]
		private RawImage _letterRenderTargetImage;

		[SerializeField]
		private GameObject _letterAndEnvelopePrefab;

		[SerializeField]
		private GameObject _letterAndEnvelopeExtraFancyPrefab;

		[SerializeField]
		private Transform _dialogueContainer;

		[SerializeField]
		private Localize _remixRankText;

		[SerializeField]
		private string[] _remixRankStrings;

		private GameObject _cameraInstance;

		private Camera _camera;

		private GameObject _letterAndEnvelopeInstance;

		private RenderTexture _letterRenderTexture;

		private static float cCameraAndLetterOffsetY = 20f;

		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			level.App.StartCoroutine(WaitToShowUI());
			NotificationObjectiveComplete notificationObjectiveComplete = (NotificationObjectiveComplete)message;
			_letterRenderTexture = new RenderTexture(1024, 1024, 24, RenderTextureFormat.ARGBHalf);
			_cameraInstance = new GameObject("FancyLetterCamera", typeof(Camera));
			_camera = _cameraInstance.GetComponent<Camera>();
			_camera.targetTexture = _letterRenderTexture;
			_camera.allowHDR = true;
			_camera.allowMSAA = true;
			_camera.useOcclusionCulling = true;
			_camera.aspect = 1f;
			_camera.clearFlags = CameraClearFlags.Color;
			_camera.backgroundColor = new Color(0.5f, 0.5f, 0.5f, 0f);
			_camera.renderingPath = RenderingPath.Forward;
			_camera.cullingMask = 1 << LayerMask.NameToLayer("Metagame");
			_cameraInstance.transform.localPosition = new Vector3(0f, cCameraAndLetterOffsetY + 10f, 0f);
			_letterRenderTargetImage.texture = _letterRenderTexture;
			_letterAndEnvelopeInstance = Object.Instantiate(notificationObjectiveComplete.IsFinalReward ? _letterAndEnvelopeExtraFancyPrefab : _letterAndEnvelopePrefab);
			_letterAndEnvelopeInstance.transform.localPosition = new Vector3(0f, cCameraAndLetterOffsetY + 10.08f, 1.78f);
			_letterAndEnvelopeInstance.transform.eulerAngles = new Vector3(0f, 180f, 0f);
			if (_remixRankText != null)
			{
				int num = Random.Range(0, _remixRankStrings.Length - 1);
				_remixRankText.SetTerm(_remixRankStrings[num]);
			}
			_dialogueContainer.gameObject.SetActive(value: false);
		}

		private IEnumerator WaitToShowUI()
		{
			yield return new WaitForSecondsRealtime(1f);
			if (!(this == null) && base.isActiveAndEnabled)
			{
				AudioManager.Instance.Play("StarLetterOpen");
				AudioManager.Instance.Play("StarLetterSting");
				yield return new WaitForSecondsRealtime(1f);
				if (!(this == null) && base.isActiveAndEnabled)
				{
					_dialogueContainer.gameObject.SetActive(value: true);
				}
			}
		}

		private void OnDestroy()
		{
			Object.Destroy(_cameraInstance);
			Object.Destroy(_letterAndEnvelopeInstance);
			Object.Destroy(_letterRenderTexture);
		}
	}
}
