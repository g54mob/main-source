using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class RectSizeLimiter : UIBehaviour, ILayoutSelfController, ILayoutController
{
	[Header("Main Settings")]
	[SerializeField]
	public RectTransform mainContent;

	[SerializeField]
	private Vector2 m_maxSize = Vector2.zero;

	[SerializeField]
	private Vector2 m_minSize = Vector2.zero;

	[Header("Child Viewport Control Height Settings")]
	[SerializeField]
	private bool controlViewport;

	[SerializeField]
	private RectTransform viewport;

	[SerializeField]
	private LayoutElement viewportLayoutElement;

	[SerializeField]
	private RectTransform viewportContent;

	private DrivenRectTransformTracker m_Tracker;

	private bool _isDirty;

	private float _lastPreferredHeight = -1f;

	public Vector2 maxSize
	{
		get
		{
			return m_maxSize;
		}
		set
		{
			if (m_maxSize != value)
			{
				m_maxSize = value;
				SetDirty();
			}
		}
	}

	public Vector2 minSize
	{
		get
		{
			return m_minSize;
		}
		set
		{
			if (m_minSize != value)
			{
				m_minSize = value;
				SetDirty();
			}
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		_isDirty = true;
		SetDirty();
	}

	protected override void OnDisable()
	{
		m_Tracker.Clear();
		LayoutRebuilder.MarkLayoutForRebuild(mainContent);
		base.OnDisable();
	}

	protected void SetDirty()
	{
		if (IsActive())
		{
			_isDirty = true;
			LayoutRebuilder.MarkLayoutForRebuild(mainContent);
		}
	}

	public void MarkDirty()
	{
		_isDirty = true;
	}

	public void SetLayoutHorizontal()
	{
		if (m_maxSize.x > 0f && mainContent.rect.width > m_maxSize.x)
		{
			mainContent.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxSize.x);
			m_Tracker.Add(this, mainContent, DrivenTransformProperties.SizeDeltaX);
		}
		if (m_minSize.x > 0f && mainContent.rect.width < m_minSize.x)
		{
			mainContent.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, minSize.x);
			m_Tracker.Add(this, mainContent, DrivenTransformProperties.SizeDeltaX);
		}
	}

	private void LateUpdate()
	{
		if (controlViewport && _isDirty)
		{
			_isDirty = false;
			ForceRebuildLayoutRecursive(mainContent);
			float num = (mainContent.rect.height - viewport.rect.height) / m_maxSize.y;
			float num2 = m_maxSize.y * (1f - num);
			float num3 = ((!(viewportContent.rect.height > num2)) ? viewportContent.rect.height : num2);
			if (!Mathf.Approximately(num3, _lastPreferredHeight))
			{
				_lastPreferredHeight = num3;
				viewportLayoutElement.preferredHeight = num3;
				ForceRebuildLayoutRecursive(mainContent);
			}
		}
	}

	public void SetLayoutVertical()
	{
		if (m_maxSize.y > 0f && mainContent.rect.height > m_maxSize.y)
		{
			mainContent.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, maxSize.y);
			m_Tracker.Add(this, mainContent, DrivenTransformProperties.SizeDeltaY);
		}
		if (m_minSize.y > 0f && mainContent.rect.height < m_minSize.y)
		{
			mainContent.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, minSize.y);
			m_Tracker.Add(this, mainContent, DrivenTransformProperties.SizeDeltaY);
		}
	}

	private void ForceRebuildLayoutRecursive(RectTransform rectTransform)
	{
		if (rectTransform == null)
		{
			return;
		}
		for (int i = 0; i < rectTransform.childCount; i++)
		{
			RectTransform rectTransform2 = rectTransform.GetChild(i) as RectTransform;
			if (rectTransform2 != null && rectTransform2.gameObject.activeSelf)
			{
				ForceRebuildLayoutRecursive(rectTransform2);
			}
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
	}
}
