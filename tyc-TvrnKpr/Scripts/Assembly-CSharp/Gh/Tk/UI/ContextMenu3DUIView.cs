using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh.Tk.UI
{
	public class ContextMenu3DUIView : MonoBehaviour
	{
		public bool AutoCloseWhenItemClicked;

		private bool? AutoCloseWhenItemClickedOverride;

		public bool UseMousePosition;

		[SerializeField]
		private GameObject _labelPrefab;

		[SerializeField]
		private GameObject _buttonPrefab;

		[SerializeField]
		private GameObject _selectionButtonPrefab;

		[SerializeField]
		private ContextMenuItemGroup3DUIView _groupPrefab;

		private Dictionary<ContextMenuItem, GameObject> _items;

		public Vector2 mousePadding;

		public Vector2 _backgroundPadding;

		[FormerlySerializedAs("ignoreObjectsForBounds")]
		public List<Renderer> ignoreObjectsForClampBounds;

		public List<Renderer> ignoreObjectsForBackgroundBounds;

		private Animator _animator;

		private const float BASE_Z_INDEX = 52f;

		private const float SUB_Z_OFFSET = 0.2f;

		private const int _maxItemCount = 12;

		private List<Action> _lateActions;

		[SerializeField]
		private Container3DUIView _menuItemContainer;

		[SerializeField]
		private Transform _backgroundTransform;

		private List<Collider> _backgroundColliders;

		[SerializeField]
		private NineSliceMeshScaler _nineSliceMesh;

		[SerializeField]
		private RelativeScaler3DUIView _relativeScaler;

		public ContextMenu3DUIView ParentMenu { get; set; }

		public bool IsOpen => false;

		public bool IsInMenu(ContextMenuItem item)
		{
			return false;
		}

		private void Awake()
		{
		}

		private void OnLanguageChanged(object sender, ValueChangedEventArgs<string> e)
		{
		}

		private void OnDestroy()
		{
		}

		private void OnUITock(object sender, EventArgs e)
		{
		}

		private void OnOpening(IEnumerable<ContextMenuItem> items)
		{
		}

		private void OnOpened(bool? autoCloseWhenItemClickedOverride)
		{
		}

		public bool IsAnimating()
		{
			return false;
		}

		private bool CanOpen()
		{
			return false;
		}

		public void Open(IEnumerable<ContextMenuItem> items, bool? autoCloseWhenItemClickedOverride = null)
		{
		}

		public void Open(IEnumerable<ContextMenuItem> items, Vector3 worldPosition, bool? autoCloseWhenItemClickedOverride = null)
		{
		}

		private void EnsureMaxItemLayout(ref List<ContextMenuItem> items)
		{
		}

		public void Open(IEnumerable<ContextMenuItem> items, Vector3 worldSpaceAnchor, TooltipAlignment alignment, bool? autoCloseWhenItemClickedOverride = null)
		{
		}

		public Bounds? GetMenuBounds()
		{
			return null;
		}

		private void SetPosition(Vector3 parentAnchor, TooltipAlignment alignment)
		{
		}

		public void ReplaceItems(IEnumerable<ContextMenuItem> items)
		{
		}

		private GameObject CreateMenuItem(ContextMenuItem item)
		{
			return null;
		}

		private void UpdateItems(bool forceIsDirty = false)
		{
		}

		public void UpdateBackground()
		{
		}

		public void Close()
		{
		}

		private void OnItemClicked(ContextMenuItem item)
		{
		}

		private bool ShouldAutoCloseOnClick()
		{
			return false;
		}

		private void ExecuteAutoClose()
		{
		}

		private void Update()
		{
		}

		public bool IsHovering()
		{
			return false;
		}

		public bool IsHoveringBackground()
		{
			return false;
		}

		private void LateUpdate()
		{
		}

		public void ShowYesNoContextMenu(string label, Action<bool> callback, ITooltipProvider tooltipSource, string yesLabel = "Yes", string noLabel = "No")
		{
		}
	}
}
