using UnityEngine;
using UnityEngine.UI;

public class Examiner : MonoBehaviour
{
	private enum State
	{
		Off = 0,
		Showing = 1,
		Hiding = 2
	}

	private class Reveal
	{
		public float pulseT;

		public float sketchT;

		private float delayTime;

		private float revealTime;

		private const float kPulseHold = 2f;

		public void Reset()
		{
			delayTime = 0f;
			revealTime = 0f;
			pulseT = 0f;
			sketchT = 0f;
		}

		public void Show(float dt)
		{
			if (delayTime < 0f)
			{
				delayTime += dt;
				pulseT = 0f;
				sketchT = 0f;
			}
			else
			{
				revealTime += dt;
				pulseT = Util.SmoothStepEdges(0f, 0.25f, revealTime) - Util.SmoothStepEdges(2f, 3f, revealTime);
				sketchT = Util.LerpScale(revealTime, 1f, 2f, 0f, 1f);
			}
		}

		public bool Hide(float dt)
		{
			pulseT = Mathf.Max(0f, pulseT - 2f * dt);
			sketchT = Mathf.Max(0f, sketchT - 3f * dt);
			return pulseT > 0f || sketchT > 0f;
		}
	}

	public Canvas canvas;

	public Camera mainCamera;

	public Image sketchImage;

	public Image faceImage;

	public Image vignetteImage;

	public OneBit oneBit;

	public HelpIris helpIris;

	private Face curFace;

	private Face nextFace;

	private FaceLib faceLib;

	private GameObject focusGo;

	private RectTransform sketchRt;

	private Vector2 canvasSize;

	private FaceLib.Face uiFace;

	private Stater<State> stater;

	private Reveal reveal = new Reveal();

	public Face face
	{
		set
		{
			nextFace = value;
		}
	}

	private void Start()
	{
		faceLib = FaceLib.Load();
		sketchRt = sketchImage.GetComponent<RectTransform>();
		canvasSize = new Vector2(Resolution.bufferW, Resolution.bufferH);
		Book.bootRequest.examiningFaceId = null;
		canvas.worldCamera.gameObject.SetActive(false);
		stater = new Stater<State>("Examiner");
		stater.AddState(State.Off).AddFunc(StaterFunc.ENTER(delegate
		{
			oneBit.linedSettings.examine = false;
			if (focusGo != null)
			{
				focusGo.SetActive(false);
				focusGo = null;
			}
			canvas.gameObject.SetActive(false);
			Util.ClearRenderTexture(canvas.worldCamera.targetTexture, Color.black);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (nextFace != null)
			{
				curFace = nextFace;
				stater.Go(State.Showing);
			}
		}))
			.AddFunc(StaterFunc.AT_STEP(0.1f, delegate
			{
				Book.bootRequest.examiningFaceId = null;
			}));
		stater.AddState(State.Showing).SetDurations(0f).AddFunc(StaterFunc.ENTER(delegate
		{
			oneBit.linedSettings.examine = true;
			Util.ClearRenderTexture(canvas.worldCamera.targetTexture, Color.black);
			canvas.gameObject.SetActive(true);
			reveal.Reset();
			uiFace = faceLib.Find(curFace.crewId);
			Rect textureRect = uiFace.spriteHi.textureRect;
			faceImage.sprite = uiFace.spriteHi;
			Book.bootRequest.examiningFaceId = curFace.crewId;
			faceImage.material.SetVector("_TextureRect", new Vector4(textureRect.x / (float)uiFace.spriteHi.texture.width, textureRect.y / (float)uiFace.spriteHi.texture.height, textureRect.xMax / (float)uiFace.spriteHi.texture.width, textureRect.yMax / (float)uiFace.spriteHi.texture.height));
			bool flag = BookContent.GetClueStatus(curFace.crewId) == BookContent.ClueStatus.NotYet;
			faceImage.material.SetFloat("_BlurStep", (!flag) ? 0f : 1f);
			RectTransform component = faceImage.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(uiFace.sketchRect.x, sketchRt.sizeDelta.y - uiFace.sketchRect.y);
			component.sizeDelta = uiFace.sketchRect.size;
			focusGo = curFace.focusGo;
			if (focusGo != null)
			{
				focusGo.SetActive(true);
			}
		}))
			.AddFunc(StaterFunc.STEP(delegate
			{
				reveal.Show(Clock.play.deltaTime);
				UpdateForCurFace();
				if (curFace != nextFace)
				{
					stater.Go(State.Hiding);
				}
				if (SaveData.it.HaveVisitedThisManyMoments(3))
				{
					helpIris.Charge(HelpIris.Kind.ZoomBook);
				}
			}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				helpIris.Zero(HelpIris.Kind.ZoomBook);
			}));
		stater.AddState(State.Hiding).AddFunc(StaterFunc.STEP(delegate
		{
			if (!reveal.Hide(Clock.play.deltaTime))
			{
				stater.Go(State.Off);
			}
			UpdateForCurFace();
		}));
		stater.Go(State.Off, true);
	}

	private void Update()
	{
		stater.Step(Clock.play.deltaTime);
		if (canvas.gameObject.activeInHierarchy)
		{
			canvas.worldCamera.Render();
		}
	}

	private void UpdateForCurFace()
	{
		Vector3 vector = mainCamera.WorldToViewportPoint(curFace.worldOrigin);
		Vector2 vector2 = new Vector2(0.75f + 0.1f * Util.LerpScale(vector.x, 0f, 1f, -1f, 1f), 0.5f + 0.1f * Util.LerpScale(vector.y, 0f, 1f, -1f, 1f));
		float num = (float)Resolution.bufferW * 0.15f / uiFace.sketchRect.width;
		Vector2 anchoredPosition = new Vector2(canvasSize.x * vector2.x - num * uiFace.sketchRect.center.x, canvasSize.y * vector2.y + num * uiFace.sketchRect.center.y);
		anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, 0f - (sketchRt.sizeDelta.x * num - canvasSize.x), 0f);
		anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, canvasSize.y, sketchRt.sizeDelta.y * num);
		anchoredPosition.x = Mathf.Round((float)Resolution.bufferW * anchoredPosition.x / canvasSize.x) * canvasSize.x / (float)Resolution.bufferW;
		anchoredPosition.y = Mathf.Round((float)Resolution.bufferH * anchoredPosition.y / canvasSize.y) * canvasSize.y / (float)Resolution.bufferH;
		sketchRt.localScale = num * Vector3.one;
		sketchRt.anchoredPosition = anchoredPosition;
		RectTransform component = vignetteImage.GetComponent<RectTransform>();
		component.position = canvas.transform.localToWorldMatrix.MultiplyPoint(Vector3.zero);
		component.localScale = 1f / num * Vector3.one;
		oneBit.linedSettings.examineReveal = new Vector3(reveal.pulseT, Util.PowInv(reveal.sketchT, 2f));
		oneBit.linedSettings.examineDitherOffset = new Vector2((0f - anchoredPosition.x) / (float)Resolution.bufferW, (0f - anchoredPosition.y) / (float)Resolution.bufferH);
	}
}
