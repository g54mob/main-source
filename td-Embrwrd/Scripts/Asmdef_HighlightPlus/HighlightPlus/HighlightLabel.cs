using System;
using TMPro;
using UnityEngine;

namespace HighlightPlus
{
	[ExecuteAlways]
	public class HighlightLabel : MonoBehaviour
	{
		public Camera cam;

		[NonSerialized]
		public Transform target;

		[NonSerialized]
		public Vector3 localPosition;

		[NonSerialized]
		public Vector3 worldOffset;

		[NonSerialized]
		public bool isVisible;

		[NonSerialized]
		public LabelAlignment labelAlignment;

		public GameObject labelPrefab;

		internal bool isPooled;

		private TextMeshProUGUI text;

		private RectTransform panel;

		private CanvasGroup canvasGroup;

		public virtual float alpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual Color textColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public virtual string textLabel
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual float textSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public virtual void ReturnToPool()
		{
		}

		public virtual void SetPosition(Transform target, Vector3 localPosition, Vector3 worldOffset)
		{
		}

		public virtual void UpdatePosition()
		{
		}

		public virtual void Show()
		{
		}

		public virtual void Hide()
		{
		}

		public virtual void Release()
		{
		}
	}
}
