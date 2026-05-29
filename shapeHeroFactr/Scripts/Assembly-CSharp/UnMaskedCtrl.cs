using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Coffee.UIExtensions;
using Libs;
using UnityEngine;

public class UnMaskedCtrl : SingletonMonoBehaviour<UnMaskedCtrl>
{
	public record ManualUnMask(Vector3 position, Vector2? sizeDelta)
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public Vector3 position { get; set; }

		public Vector2? sizeDelta { get; set; }

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(ManualUnMask? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected ManualUnMask(ManualUnMask original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out Vector3 position, out Vector2? sizeDelta)
		{
			position = default(Vector3);
			sizeDelta = null;
		}
	}

	[SerializeField]
	private CanvasGroup unMaskGroup;

	[SerializeField]
	private UnmaskRaycastFilter raycastFilter;

	[SerializeField]
	private Unmask unmaskPrefab;

	[SerializeField]
	private float animationStartScale;

	[SerializeField]
	private float duration;

	private List<Unmask> _unmasks;

	private List<UnmaskRaycastFilter> _raycastFilters;

	public bool IsEnableUnMask => false;

	private void Awake()
	{
	}

	public void UseUnmask(params RectTransform[] fitRects)
	{
	}

	public void UseUnmask(params ManualUnMask[] manualParams)
	{
	}

	private Unmask CreateUnmask()
	{
		return null;
	}

	public void ClearAllUnMasks()
	{
	}

	public void SwitchDisplayUnMask(bool on)
	{
	}
}
