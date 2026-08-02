using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-400)]
public class bl_Compass : MonoBehaviour
{
	[Serializable]
	public enum CompassType
	{
		Horizontal = 0,
		Vertical = 1
	}

	[Header("SETTINGS")]
	public CompassType m_CompassType;

	[SerializeField]
	private bool FadeEdges = true;

	[Range(0.1f, 5f)]
	public float Space = 2f;

	[Range(0.1f, 1f)]
	public float FadeAmount = 0.5f;

	[Range(1f, 10f)]
	public int UpdateRate = 1;

	[SerializeField]
	private AnimationCurve FadeCurve;

	[Header("REFERENCES")]
	[SerializeField]
	private Transform Panel;

	[SerializeField]
	private GameObject MarkPrefab;

	[SerializeField]
	private Text DegreeText;

	[SerializeField]
	private TextMeshProUGUI DegreeTextTMP;

	[SerializeField]
	private RectTransform[] UIDregres;

	private float CircularRadious = 114f;

	private CanvasGroup[] Alphas;

	public Transform CameraView;

	public List<CompassMark> Marks = new List<CompassMark>();

	private int currentFrame = -1;

	private Vector3 cameraAngle;

	private readonly Vector3 FarForward = Vector3.forward * 100000f;

	private bool isSubscribed;

	public Camera playerCamera;

	public float Angle { get; set; }

	private void Awake()
	{
		Alphas = new CanvasGroup[UIDregres.Length];
		for (int i = 0; i < UIDregres.Length; i++)
		{
			Alphas[i] = UIDregres[i].GetComponent<CanvasGroup>();
		}
		SubscribeToEvents(subscribe: true);
	}

	private void OnEnable()
	{
		SubscribeToEvents(subscribe: true);
		StartCoroutine(Loop());
	}

	private void OnDisable()
	{
		SubscribeToEvents(subscribe: false);
		StopAllCoroutines();
	}

	private void SubscribeToEvents(bool subscribe)
	{
		if (subscribe)
		{
			if (!isSubscribed)
			{
				CompassMarkEvent.CompassMarkAction = (Action<CompassMark>)Delegate.Combine(CompassMarkEvent.CompassMarkAction, new Action<CompassMark>(OnMarkEvent));
				CompassMarkEvent.ChangeCompassCameraAction = (Action<Transform>)Delegate.Combine(CompassMarkEvent.ChangeCompassCameraAction, new Action<Transform>(OnChangeCamera));
				CompassMarkEvent.ActionDestroyMark = (Action<Transform>)Delegate.Combine(CompassMarkEvent.ActionDestroyMark, new Action<Transform>(OnDestroyMark));
				CompassMarkEvent.ActionShowMark = (Action<Transform, bool>)Delegate.Combine(CompassMarkEvent.ActionShowMark, new Action<Transform, bool>(OnShowMark));
				isSubscribed = true;
			}
		}
		else if (isSubscribed)
		{
			CompassMarkEvent.CompassMarkAction = (Action<CompassMark>)Delegate.Remove(CompassMarkEvent.CompassMarkAction, new Action<CompassMark>(OnMarkEvent));
			CompassMarkEvent.ChangeCompassCameraAction = (Action<Transform>)Delegate.Remove(CompassMarkEvent.ChangeCompassCameraAction, new Action<Transform>(OnChangeCamera));
			CompassMarkEvent.ActionDestroyMark = (Action<Transform>)Delegate.Remove(CompassMarkEvent.ActionDestroyMark, new Action<Transform>(OnDestroyMark));
			CompassMarkEvent.ActionShowMark = (Action<Transform, bool>)Delegate.Remove(CompassMarkEvent.ActionShowMark, new Action<Transform, bool>(OnShowMark));
			isSubscribed = false;
		}
	}

	private IEnumerator Loop()
	{
		while (true)
		{
			if (CameraView != null)
			{
				OnUpdate();
			}
			yield return null;
		}
	}

	private void OnUpdate()
	{
		if (!(CameraView == null))
		{
			currentFrame = (currentFrame + 1) % UpdateRate;
			if (currentFrame == 0)
			{
				CalCulateAngle();
				ControlledUI();
				ControlledMarks();
			}
		}
	}

	private void CalCulateAngle()
	{
		if (CameraView == null)
		{
			CameraView = playerCamera.transform;
		}
		cameraAngle = CameraView.forward;
		cameraAngle.y = 0f;
		Angle = Vector3.Angle(FarForward, cameraAngle);
		float num = Angle;
		if (Vector3.Cross(FarForward, cameraAngle).y < 0f)
		{
			Angle = 0f - Angle;
			num = 360f - num;
		}
		if (DegreeText != null)
		{
			DegreeText.text = num.ToString("F0");
		}
		if (DegreeTextTMP != null)
		{
			DegreeTextTMP.text = num.ToString("F0");
		}
	}

	private void ControlledUI()
	{
		RectTransform rectTransform = null;
		float num = 360 / UIDregres.Length;
		int num2 = 1;
		float num3 = 180f * (1f - FadeAmount);
		float num4 = 0f;
		for (int i = 0; i < UIDregres.Length; i++)
		{
			rectTransform = UIDregres[i];
			if (rectTransform == null)
			{
				continue;
			}
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			int num5 = UIDregres.Length / 2;
			float num6 = 0f;
			if (i > num5)
			{
				num6 = (0f - num) * (float)num2 + (0f - Angle);
				if (FadeEdges)
				{
					num4 = 1f - Mathf.Abs(num6) / num3;
					num4 = FadeCurve.Evaluate(num4);
					Alphas[i].alpha = num4;
				}
				if (num6 < -180f)
				{
					num6 += 360f;
					if (FadeEdges)
					{
						num4 = 1f - num6 / num3;
						num4 = FadeCurve.Evaluate(num4);
						Alphas[i].alpha = num4;
					}
				}
				num2++;
			}
			else
			{
				num6 = num * (float)i + (0f - Angle);
				if (FadeEdges)
				{
					num4 = 1f - Mathf.Abs(num6) / num3;
					num4 = FadeCurve.Evaluate(num4);
					Alphas[i].alpha = num4;
				}
				if (num6 > 180f)
				{
					num6 -= 360f;
					if (FadeEdges)
					{
						num4 = 1f - Mathf.Abs(num6) / num3;
						num4 = FadeCurve.Evaluate(num4);
						Alphas[i].alpha = num4;
					}
				}
			}
			if (m_CompassType == CompassType.Horizontal)
			{
				anchoredPosition.x = num6;
			}
			else if (m_CompassType == CompassType.Vertical)
			{
				anchoredPosition.y = num6;
			}
			rectTransform.anchoredPosition = anchoredPosition * Space;
		}
	}

	private void CircularUI()
	{
		RectTransform rectTransform = null;
		float num = 360 / UIDregres.Length;
		int num2 = 1;
		for (int i = 0; i < UIDregres.Length; i++)
		{
			rectTransform = UIDregres[i];
			if (!(rectTransform == null))
			{
				Vector2 anchoredPosition = rectTransform.anchoredPosition;
				float num3 = UIDregres.Length / 2;
				float num4 = 0f;
				if ((float)i > num3)
				{
					num4 = ((0f - num) * (float)num2 + (0f - (Angle + 90f))) / (CircularRadious * 0.5f);
					num2++;
				}
				else
				{
					num4 = (num * (float)i + (0f - (Angle + 90f))) / (CircularRadious * 0.5f);
				}
				num4 *= -1f;
				anchoredPosition.x = CircularRadious * Mathf.Cos(num4);
				anchoredPosition.y = CircularRadious * Mathf.Sin(num4);
				rectTransform.anchoredPosition = anchoredPosition * Space;
			}
		}
	}

	private void ControlledMarks()
	{
		float num = 180f * (1f - FadeAmount);
		for (int i = 0; i < Marks.Count; i++)
		{
			CompassMark compassMark = Marks[i];
			if (compassMark == null)
			{
				continue;
			}
			if (compassMark.Target == null || compassMark.MarkUI == null)
			{
				Marks.RemoveAt(i);
			}
			else if (compassMark.MarkUI.gameObject.activeSelf)
			{
				Vector2 anchoredPosition = compassMark.MarkUI.anchoredPosition;
				Vector3 rhs = compassMark.Target.position - CameraView.position;
				rhs.y = 0f;
				rhs.Normalize();
				Vector3 forward = CameraView.forward;
				float num2 = Vector3.Dot(forward, rhs);
				Vector3 vector = Vector3.Cross(forward, rhs);
				float num3 = (1f - num2) * 90f;
				if (FadeEdges)
				{
					float time = 1f - num3 / num;
					time = FadeCurve.Evaluate(time);
					compassMark.Alpha.alpha = time;
				}
				if (vector.y < 0f)
				{
					num3 = 0f - num3;
				}
				if (m_CompassType == CompassType.Horizontal)
				{
					anchoredPosition.x = num3;
				}
				else if (m_CompassType == CompassType.Vertical)
				{
					anchoredPosition.y = num3;
				}
				compassMark.MarkUI.anchoredPosition = anchoredPosition * Space;
			}
		}
	}

	public void ShowMark(bool show, Transform Target)
	{
		CompassMark targetMark = GetTargetMark(Target);
		if (targetMark == null)
		{
			Debug.Log("This transform doesn't have any mark created.");
		}
		else
		{
			targetMark.MarkUI.gameObject.SetActive(show);
		}
	}

	private void OnMarkEvent(CompassMark mark)
	{
		if (!(MarkPrefab == null) && !(Panel == null) && !Marks.Exists((CompassMark x) => x.Target == mark.Target))
		{
			CompassMark compassMark = new CompassMark();
			compassMark.Icon = mark.Icon;
			compassMark.IconColor = mark.IconColor;
			compassMark.Target = mark.Target;
			GameObject gameObject = UnityEngine.Object.Instantiate(MarkPrefab);
			gameObject.transform.SetParent(Panel, worldPositionStays: false);
			compassMark.Alpha = gameObject.GetComponent<CanvasGroup>();
			Image component = gameObject.GetComponent<Image>();
			component.sprite = mark.Icon;
			component.color = mark.IconColor;
			compassMark.MarkUI = gameObject.GetComponent<RectTransform>();
			Marks.Add(compassMark);
		}
	}

	private void OnDestroyMark(Transform target)
	{
		if (Marks.Exists((CompassMark x) => x.Target == target))
		{
			int index = Marks.FindIndex((CompassMark x) => x.Target == target);
			UnityEngine.Object.Destroy(Marks[index].MarkUI);
			Marks.RemoveAt(index);
		}
		else
		{
			Debug.LogWarning("This target: " + target.name + " doesn't have a mark.");
		}
	}

	private void OnShowMark(Transform target, bool show)
	{
		if (Marks.Exists((CompassMark x) => x.Target == target))
		{
			int index = Marks.FindIndex((CompassMark x) => x.Target == target);
			Marks[index].MarkUI.gameObject.SetActive(show);
		}
		else
		{
			Debug.LogWarning("This target: " + target.name + " doesn't have a mark.");
		}
	}

	private void OnChangeCamera(Transform camera)
	{
		CameraView = camera;
	}

	public CompassMark GetTargetMark(Transform target)
	{
		if (Marks.Exists((CompassMark x) => x.Target == target))
		{
			return Marks.Find((CompassMark x) => x.Target == target);
		}
		return null;
	}

	[ContextMenu("Set")]
	private void Set()
	{
		Alphas = new CanvasGroup[UIDregres.Length];
		for (int i = 0; i < UIDregres.Length; i++)
		{
			Alphas[i] = UIDregres[i].GetComponent<CanvasGroup>();
		}
		OnUpdate();
	}
}
