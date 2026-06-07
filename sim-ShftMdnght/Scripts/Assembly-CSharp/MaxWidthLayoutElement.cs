using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class MaxWidthLayoutElement : MonoBehaviour, ILayoutElement
{
	[Min(0f)]
	public float maxWidth = 120f;

	private LayoutElement _le;

	public float minHeight
	{
		get
		{
			if (!(_le != null))
			{
				return -1f;
			}
			return _le.minHeight;
		}
	}

	public float preferredHeight
	{
		get
		{
			if (!(_le != null))
			{
				return -1f;
			}
			return _le.preferredHeight;
		}
	}

	public float flexibleHeight
	{
		get
		{
			if (!(_le != null))
			{
				return -1f;
			}
			return _le.flexibleHeight;
		}
	}

	public float minWidth
	{
		get
		{
			if (!(_le != null))
			{
				return -1f;
			}
			return _le.minWidth;
		}
	}

	public float preferredWidth
	{
		get
		{
			if (!(_le != null))
			{
				return -1f;
			}
			return _le.preferredWidth;
		}
	}

	public float flexibleWidth
	{
		get
		{
			if (!(_le != null))
			{
				return -1f;
			}
			return _le.flexibleWidth;
		}
	}

	public int layoutPriority => 1;

	private void Awake()
	{
		_le = GetComponent<LayoutElement>();
		if (_le == null)
		{
			_le = base.gameObject.AddComponent<LayoutElement>();
		}
		Apply();
	}

	private void OnEnable()
	{
		Apply();
	}

	private void OnValidate()
	{
		Apply();
	}

	private void Apply()
	{
		if (_le == null)
		{
			_le = GetComponent<LayoutElement>();
		}
		if (!(_le == null))
		{
			_le.preferredWidth = maxWidth;
			if (_le.flexibleWidth <= 0f)
			{
				_le.flexibleWidth = 1f;
			}
			LayoutRebuilder.MarkLayoutForRebuild((RectTransform)base.transform.parent);
		}
	}

	public void CalculateLayoutInputHorizontal()
	{
	}

	public void CalculateLayoutInputVertical()
	{
	}
}
