using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class MapMarker : MapVisual, ISelectable
	{
		public float height;

		public float heightTime;

		public float yRot;

		public float rotTime;

		[SerializeField]
		[HideInInspector]
		protected List<GameObject> _currentSelectionHighlights;

		[SerializeField]
		private bool _suppressInfoPanel;

		public string Id { get; private set; }

		public new bool IsVisible { get; protected set; }

		public GameObject Model { get; set; }

		public GameObject Glow { get; set; }

		public ObservableCollection<ContextMenuItem> ContextMenuItems { get; private set; }

		bool ISelectable.IsSelected
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public bool SuppressInfoPanel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected virtual void SetupIdleAnimation()
		{
		}

		public override void OnLevelChanged()
		{
		}

		public virtual void ShowVisual()
		{
		}

		public virtual void HideVisual()
		{
		}

		public override void OnClicked()
		{
		}

		public virtual bool CanSelect()
		{
			return false;
		}

		public virtual void AddHighlight(Color? color = null)
		{
		}

		public virtual void RemoveHighlight()
		{
		}
	}
}
