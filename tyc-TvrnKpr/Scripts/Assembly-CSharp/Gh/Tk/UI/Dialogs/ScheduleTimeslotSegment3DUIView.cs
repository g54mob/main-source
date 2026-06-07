using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class ScheduleTimeslotSegment3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private float _collapseSize;

		[SerializeField]
		private Container3DUIView _iconsContainer;

		[SerializeField]
		private BoxColliderResizer _iconContainerColliderResizer;

		private Dictionary<string, GameObject> _icons;

		[SerializeField]
		private BoxCollider _iconColliderTemplate;

		[SerializeField]
		private TextMeshProI18n _labelText;

		[SerializeField]
		private Container3DUIView _contentContainer;

		[SerializeField]
		private Transform _bottomCap;

		private Vector3 _defaultContentPosition;

		private static readonly Vector3 CONTENT_OFFSET;

		[SerializeField]
		private Transform _backgroundTransform;

		[SerializeField]
		private SpriteRenderer _backgroundSpriteRenderer;

		[SerializeField]
		private BoxCollider _collider;

		private int _hour;

		public override bool IsPressed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SlotOption Option { get; private set; }

		public event EventHandler<SlotOptionEventArgs> SegmentHovered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void ShowContent(bool show, bool offsetForGroup, bool showBottomCap)
		{
		}

		protected override void Awake()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		public override void OnHovering()
		{
		}

		public void SetSize(float size)
		{
		}

		public void ClearData()
		{
		}

		public void SetData(int hour, SlotOption option, ScheduleTimeSlot timeSlot)
		{
		}
	}
}
