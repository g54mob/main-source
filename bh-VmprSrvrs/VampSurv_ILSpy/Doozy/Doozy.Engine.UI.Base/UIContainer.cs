using System;
using Cpp2ILInjected;
using Doozy.Engine.Extensions;
using Doozy.Engine.UI.Animation;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.UI.Base;

[Serializable]
public class UIContainer
{
	public const bool DEFAULT_DISABLE_CANVAS = true;

	public const bool DEFAULT_DISABLE_GAME_OBJECT = true;

	public const bool DEFAULT_DISABLE_GRAPHIC_RAYCASTER = true;

	public const bool DEFAULT_ENABLED = true;

	public Canvas Canvas;

	public CanvasGroup CanvasGroup;

	public bool DisableCanvas;

	public bool DisableGameObject;

	public bool DisableGraphicRaycaster;

	public bool Enabled;

	public GraphicRaycaster GraphicRaycaster;

	public RectTransform RectTransform;

	public float StartAlpha;

	public Vector3 StartPosition;

	public Vector3 StartRotation;

	public Vector3 StartScale;

	public UIContainer()
	{
		//IL_0029: Expected I, but got O
		//IL_0064: Expected I, but got O
		//IL_009a: Expected I, but got O
		DisableCanvas = true;
		StartAlpha = 1f;
		nint num = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num2 = 0;
		StartPosition = UIAnimator.DEFAULT_START_POSITION;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num4 = 0;
		StartRotation = UIAnimator.DEFAULT_START_ROTATION;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v4 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
		_ = 0;
		nint num5 = (nint)typeof(UIAnimator);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v7 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
		nint num6 = 0;
		StartScale = UIAnimator.DEFAULT_START_SCALE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+20]");
		_ = 0;
		Reset();
	}

	public virtual void Disable()
	{
		RectTransform rectTransform = RectTransform;
		if ((object)RectTransform == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (DisableGameObject)
		{
			GameObject gameObject = RectTransform.gameObject;
			gameObject.SetActive(value: false);
		}
		if (DisableCanvas)
		{
			Canvas.enabled = false;
			if (DisableGraphicRaycaster)
			{
				GraphicRaycaster.enabled = false;
			}
		}
	}

	public virtual void Enable()
	{
		if (Enabled)
		{
			RectTransform rectTransform = RectTransform;
			if ((object)RectTransform != null && ((UnityEngine.Object)rectTransform).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject = RectTransform.gameObject;
				gameObject.SetActive(value: true);
				Canvas.enabled = true;
				GraphicRaycaster.enabled = true;
			}
		}
	}

	public void FullScreen(bool resetScaleToOne)
	{
		RectTransform rectTransform = RectTransform;
		if ((object)RectTransform != null && ((UnityEngine.Object)rectTransform).m_CachedPtr != (IntPtr)0)
		{
			RectTransformExtensions.FullScreen(RectTransform, resetScaleToOne);
		}
	}

	public virtual void Init()
	{
		//IL_0362: Expected O, but got I4
		RectTransform rectTransform = RectTransform;
		if ((object)RectTransform == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Canvas canvas = Canvas;
		if ((object)Canvas == null || ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = RectTransform.gameObject;
			Canvas component = gameObject.GetComponent<Canvas>();
			Canvas = component;
			Canvas canvas2 = Canvas;
			if ((object)Canvas == null || ((UnityEngine.Object)canvas2).m_CachedPtr == (IntPtr)0)
			{
				GameObject gameObject2 = RectTransform.gameObject;
				Canvas canvas3 = gameObject2.AddComponent<Canvas>();
				Canvas = canvas3;
			}
		}
		GraphicRaycaster graphicRaycaster = GraphicRaycaster;
		if ((object)GraphicRaycaster == null || ((UnityEngine.Object)graphicRaycaster).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject3 = RectTransform.gameObject;
			GraphicRaycaster component2 = gameObject3.GetComponent<GraphicRaycaster>();
			GraphicRaycaster = component2;
			GraphicRaycaster graphicRaycaster2 = GraphicRaycaster;
			if ((object)GraphicRaycaster == null || ((UnityEngine.Object)graphicRaycaster2).m_CachedPtr == (IntPtr)0)
			{
				GameObject gameObject4 = RectTransform.gameObject;
				GraphicRaycaster graphicRaycaster3 = gameObject4.AddComponent<GraphicRaycaster>();
				GraphicRaycaster = graphicRaycaster3;
			}
		}
		CanvasGroup canvasGroup = CanvasGroup;
		if ((object)CanvasGroup == null || ((UnityEngine.Object)canvasGroup).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject5 = RectTransform.gameObject;
			CanvasGroup component3 = gameObject5.GetComponent<CanvasGroup>();
			CanvasGroup = component3;
			CanvasGroup canvasGroup2 = CanvasGroup;
			if ((object)CanvasGroup == null || ((UnityEngine.Object)canvasGroup2).m_CachedPtr == (IntPtr)0)
			{
				GameObject gameObject6 = RectTransform.gameObject;
				CanvasGroup canvasGroup3 = gameObject6.AddComponent<CanvasGroup>();
				CanvasGroup = canvasGroup3;
			}
		}
		if (Canvas.enabled && DisableCanvas)
		{
			Canvas.enabled = false;
		}
		bool enabled = GraphicRaycaster.enabled;
		object obj = DisableGraphicRaycaster & enabled;
		if (obj != null)
		{
			GraphicRaycaster.enabled = false;
		}
		if (Enabled)
		{
			UpdateStartValues();
		}
		else
		{
			Disable();
		}
	}

	public virtual void Reset()
	{
		DisableCanvas = true;
	}

	public virtual void ResetAlpha()
	{
		CanvasGroup component = RectTransform.GetComponent<CanvasGroup>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			CanvasGroup component2 = RectTransform.GetComponent<CanvasGroup>();
			component2.alpha = StartAlpha;
		}
	}

	public unsafe virtual void ResetPosition()
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		RectTransform.anchoredPosition3D = (Vector3)(&obj);
	}

	public unsafe virtual void ResetRotation()
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		RectTransform.localEulerAngles = (Vector3)(&obj);
	}

	public virtual void ResetScale()
	{
		RectTransform rectTransform = RectTransform;
		bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref value);
	}

	public virtual void ResetToStartValues()
	{
		RectTransform rectTransform = RectTransform;
		if ((object)RectTransform != null && ((UnityEngine.Object)rectTransform).m_CachedPtr != (IntPtr)0)
		{
			UIAnimator.ResetCanvasGroup(RectTransform);
			ResetPosition();
			ResetRotation();
			ResetScale();
			ResetAlpha();
		}
	}

	public virtual void UpdateStartAlpha()
	{
		CanvasGroup component = RectTransform.GetComponent<CanvasGroup>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			CanvasGroup component2 = RectTransform.GetComponent<CanvasGroup>();
			float alpha = component2.alpha;
			StartAlpha = alpha;
		}
		else
		{
			StartAlpha = 1f;
		}
	}

	public virtual void UpdateStartPosition()
	{
		//IL_001e: Expected O, but got F4
		Vector3 anchoredPosition3D = RectTransform.anchoredPosition3D;
		StartPosition = (Vector3)anchoredPosition3D.x;
		_ = anchoredPosition3D.z;
	}

	public virtual void UpdateStartRotation()
	{
		//IL_001e: Expected O, but got F4
		Vector3 localEulerAngles = RectTransform.localEulerAngles;
		StartRotation = (Vector3)localEulerAngles.x;
		_ = localEulerAngles.z;
	}

	public virtual void UpdateStartScale()
	{
		RectTransform rectTransform = RectTransform;
		bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Vector3 ret);
		StartScale = ret;
		_ = 0;
	}

	public virtual void UpdateStartValues()
	{
		RectTransform rectTransform = RectTransform;
		if ((object)RectTransform != null && ((UnityEngine.Object)rectTransform).m_CachedPtr != (IntPtr)0)
		{
			UpdateStartPosition();
			UpdateStartRotation();
			UpdateStartScale();
			UpdateStartAlpha();
		}
	}
}
