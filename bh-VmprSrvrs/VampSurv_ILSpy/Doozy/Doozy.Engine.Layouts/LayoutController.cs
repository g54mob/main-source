using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Layouts;

public class LayoutController : MonoBehaviour
{
	private const bool DEFAULT_NEEDS_REBUILD = true;

	public bool NeedsRebuild;

	private float m_lastRebuildTime;

	private LayoutGroup m_layoutGroup;

	private RectTransform m_rectTransform;

	public LayoutGroup Layout
	{
		get
		{
			LayoutGroup layoutGroup = m_layoutGroup;
			if ((object)m_layoutGroup == null || ((UnityEngine.Object)layoutGroup).m_CachedPtr == (IntPtr)0)
			{
				UpdateReference();
				m_rectTransform = null;
			}
			return m_layoutGroup;
		}
		set
		{
			m_layoutGroup = value;
			m_rectTransform = null;
		}
	}

	public RectTransform RectTransform
	{
		get
		{
			RectTransform rectTransform = m_rectTransform;
			if ((object)m_rectTransform == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
			{
				LayoutGroup layout = Layout;
				if ((object)layout == null || ((UnityEngine.Object)layout).m_CachedPtr == (IntPtr)0)
				{
					return null;
				}
				LayoutGroup layout2 = Layout;
				if ((object)layout2 == null)
				{
					return (RectTransform)(object)new NullReferenceException();
				}
				RectTransform component = layout2.GetComponent<RectTransform>();
				m_rectTransform = component;
			}
			return m_rectTransform;
		}
	}

	private void Reset()
	{
		UpdateReference();
		NeedsRebuild = true;
	}

	private void Awake()
	{
		RectTransform rectTransform = RectTransform;
		bool flag2;
		if ((object)rectTransform != null)
		{
			bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
			flag2 = !flag;
		}
		else
		{
			flag2 = false;
		}
		base.enabled = flag2;
		NeedsRebuild = true;
		Rebuild();
	}

	private void Update()
	{
		Rebuild();
	}

	public void DisableLayoutGroup()
	{
		LayoutGroup layout = Layout;
		if ((object)layout != null && ((UnityEngine.Object)layout).m_CachedPtr != (IntPtr)0)
		{
			LayoutGroup layout2 = Layout;
			layout2.enabled = false;
		}
	}

	public void EnableLayoutGroup()
	{
		LayoutGroup layout = Layout;
		if ((object)layout != null && ((UnityEngine.Object)layout).m_CachedPtr != (IntPtr)0)
		{
			LayoutGroup layout2 = Layout;
			layout2.enabled = true;
		}
	}

	public void Rebuild(bool forced = false)
	{
		//IL_012e: Expected O, but got F4
		//IL_0162: Expected O, but got F4
		RectTransform rectTransform = RectTransform;
		if ((object)rectTransform == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		float num = default(float);
		if (NeedsRebuild)
		{
			object obj = Time.unscaledTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C450DEh\"");
			if (m_lastRebuildTime == num)
			{
				NeedsRebuild = false;
			}
		}
		if (!forced)
		{
			if (NeedsRebuild == forced)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45B60");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C45157h\"");
			if (m_lastRebuildTime != num)
			{
				return;
			}
		}
		RectTransform rectTransform2 = RectTransform;
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform2);
		NeedsRebuild = false;
		object obj2 = Time.unscaledTime;
		m_lastRebuildTime = num;
	}

	private void UpdateReference()
	{
		LayoutGroup layoutGroup = m_layoutGroup;
		if ((object)m_layoutGroup == null || ((UnityEngine.Object)layoutGroup).m_CachedPtr == (IntPtr)0)
		{
			LayoutGroup component = GetComponent<LayoutGroup>();
			m_layoutGroup = component;
		}
	}

	public LayoutController()
	{
		//IL_0020: Expected I, but got O
		NeedsRebuild = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
