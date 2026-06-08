using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class CollectionGridUpdater : MonoBehaviour
{
	private sealed class _003CUpdateGridLayoutInNextFrame_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CollectionGridUpdater _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CUpdateGridLayoutInNextFrame_003Ed__10(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			CollectionGridUpdater collectionGridUpdater = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				collectionGridUpdater.UpdateGridLayout();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private GridLayoutGroup gridLayoutGroup;

	private RectTransform rectTransform;

	[SerializeField]
	private bool childForceExpandWidth;

	[FormerlySerializedAs("minPadding")]
	[SerializeField]
	private Vector2 minSpacing = new Vector2(10f, 10f);

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private bool debug_callOnUpdate;

	private RectTransform parentRectTransform;

	private void Awake()
	{
		gridLayoutGroup = GetComponent<GridLayoutGroup>();
		rectTransform = GetComponent<RectTransform>();
		parentRectTransform = GetComponentInParent<RectTransform>();
	}

	private void OnEnable()
	{
		StartCoroutine(UpdateGridLayoutInNextFrame());
	}

	private void UpdateGridLayoutFromResolutionChange(Resolution resolution)
	{
		StartCoroutine(UpdateGridLayoutInNextFrame());
	}

	private IEnumerator UpdateGridLayoutInNextFrame()
	{
		return new _003CUpdateGridLayoutInNextFrame_003Ed__10(0)
		{
			_003C_003E4__this = this
		};
	}

	private void Update()
	{
		if (debug_callOnUpdate)
		{
			UpdateGridLayout();
		}
	}

	private void UpdateGridLayout()
	{
		if (childForceExpandWidth)
		{
			float num = rectTransform.rect.width - (float)gridLayoutGroup.padding.left - (float)gridLayoutGroup.padding.right;
			int num2 = Mathf.FloorToInt((num + minSpacing.x) / (gridLayoutGroup.cellSize.x + minSpacing.x));
			float x = (num - (float)num2 * gridLayoutGroup.cellSize.x) / (float)(num2 - 1);
			gridLayoutGroup.spacing = new Vector2(x, gridLayoutGroup.spacing.y);
			LayoutRebuilder.ForceRebuildLayoutImmediate(parentRectTransform);
		}
	}
}
