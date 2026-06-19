using System;
using System.Collections;
using I2.Loc;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class OpenLetterMenu : MenuBase
	{
		public class Definition : MetagamePostCutsceneEventDefinition
		{
			public GameObject EnvelopePrefab;

			public LocalisedString BodyText;

			public LocalisedString SignatureText;

			public LocalisedString TitleText;

			public bool UseExtraButton;

			public LocalisedString ExtraButtonText;
		}

		[SerializeField]
		private RawImage _letterRenderTargetImage;

		[SerializeField]
		private Localize _titleText;

		[SerializeField]
		private Localize _bodyText;

		[SerializeField]
		private Localize _signatureText;

		[SerializeField]
		private Localize _extraButtonText;

		[SerializeField]
		private DynamicButton _continueButton;

		[SerializeField]
		private DynamicButton _extraButton;

		private GameObject _cameraInstance;

		private Camera _camera;

		private GameObject _letterAndEnvelopeInstance;

		private RenderTexture _letterRenderTexture;

		private bool _useExtraButton;

		private Action _extraButtonAction;

		private static float cCameraAndLetterOffsetY = 20f;

		private void OnEnable()
		{
			_extraButton.onPrimaryDown.AddListener(OnExtraButtonPressed);
		}

		private void OnDisable()
		{
			_extraButton.onPrimaryDown.RemoveListener(OnExtraButtonPressed);
		}

		public void Setup(Definition definition, Action extraButtonAction)
		{
			_titleText.gameObject.SetActive(value: false);
			_bodyText.gameObject.SetActive(value: false);
			_signatureText.gameObject.SetActive(value: false);
			_continueButton.gameObject.SetActive(value: false);
			_extraButton.gameObject.SetActive(value: false);
			StartCoroutine(WaitToShowUI());
			_titleText.SetTerm(definition.TitleText.Term);
			_bodyText.SetTerm(definition.BodyText.Term);
			_signatureText.SetTerm(definition.SignatureText.Term);
			_extraButtonText.SetTerm(definition.ExtraButtonText.Term);
			_useExtraButton = definition.UseExtraButton;
			_extraButtonAction = extraButtonAction;
			_letterRenderTexture = new RenderTexture(1024, 1024, 24, RenderTextureFormat.ARGBHalf);
			_cameraInstance = new GameObject("OpenLetterMenuCamera", typeof(Camera));
			_camera = _cameraInstance.GetComponent<Camera>();
			_camera.targetTexture = _letterRenderTexture;
			_camera.allowHDR = true;
			_camera.allowMSAA = true;
			_camera.useOcclusionCulling = true;
			_camera.aspect = 1f;
			_camera.clearFlags = CameraClearFlags.Color;
			_camera.backgroundColor = new Color(0.5f, 0.5f, 0.5f, 0f);
			_camera.renderingPath = RenderingPath.Forward;
			_camera.cullingMask = 1 << LayerMask.NameToLayer("Metagame Offscreen");
			_cameraInstance.transform.localPosition = new Vector3(0f, cCameraAndLetterOffsetY + 10f, 0f);
			_letterRenderTargetImage.texture = _letterRenderTexture;
			_letterAndEnvelopeInstance = UnityEngine.Object.Instantiate(definition.EnvelopePrefab);
			_letterAndEnvelopeInstance.transform.localPosition = new Vector3(0f, cCameraAndLetterOffsetY + 10.08f, 1.78f);
			_letterAndEnvelopeInstance.transform.eulerAngles = new Vector3(0f, 180f, 0f);
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
					_titleText.gameObject.SetActive(value: true);
					_bodyText.gameObject.SetActive(value: true);
					_signatureText.gameObject.SetActive(value: true);
					yield return new WaitForSecondsRealtime(1f);
					_continueButton.gameObject.SetActive(value: true);
					_extraButton.gameObject.SetActive(_useExtraButton);
				}
			}
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(_cameraInstance);
			UnityEngine.Object.Destroy(_letterAndEnvelopeInstance);
			UnityEngine.Object.Destroy(_letterRenderTexture);
		}

		private void OnExtraButtonPressed()
		{
			if (_extraButtonAction != null)
			{
				_extraButtonAction.InvokeSafe();
			}
		}
	}
}
