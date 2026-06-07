using System;
using UnityEngine;

namespace UIScripts.UIReferences.LineagePanel
{
	public class LineageElement : MonoBehaviour
	{
		[NonSerialized]
		public RectTransform rt;

		[NonSerialized]
		protected bool hasInit;

		[NonSerialized]
		public float width;

		[NonSerialized]
		public float height;

		private void Awake()
		{
			if (!hasInit)
			{
				Init();
			}
		}

		public virtual void Init()
		{
			hasInit = true;
			rt = GetComponent<RectTransform>();
			Vector2 sizeDelta = rt.sizeDelta;
			width = sizeDelta.x;
			height = sizeDelta.y;
		}

		public void SetActive(bool val)
		{
			base.gameObject.SetActive(val);
		}

		public void SetPosition(Vector2 pos)
		{
			rt.localPosition = pos;
		}
	}
}
