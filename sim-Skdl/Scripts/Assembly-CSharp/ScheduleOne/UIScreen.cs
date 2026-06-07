using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne
{
	public class UIScreen : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Manually assign the UIPanel attached to this screen in editor.")]
		private List<UIPanel> panels;

		[Tooltip("When selected, the input action in the inputDescriptor list will be active")]
		[SerializeField]
		private List<InputDescriptor> inputDescriptors;

		[Tooltip("Each screen support 1 active scroll rect to scroll. You can use uiScreen.ChangeActiveScrollRect(newScrollRect) to change the active scroll rect via script at runtime.")]
		[SerializeField]
		private ScrollRect activeScrollRect;

		[SerializeField]
		[Tooltip("Add this screen to UIScreenManger on Start")]
		private bool addScreenOnStart;

		[Tooltip("Add this screen to UIScreenManger on OnEnable")]
		[SerializeField]
		private bool addScreenOnEnable;

		[Tooltip("Remove this screen from UIScreenManger on OnDisable")]
		[SerializeField]
		private bool removeScreenOnDisable;

		private UIPanel currentSelectedPanel;

		private bool isSelected;

		private bool wasNavPressedLastFrame;

		public bool IsSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public UIPanel CurrentSelectedPanel => null;

		public IReadOnlyList<UIPanel> Panels => null;

		private void Awake()
		{
		}

		protected virtual void OnAwake()
		{
		}

		private void Start()
		{
		}

		protected virtual void OnStarted()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		protected virtual void OnDestroyed()
		{
		}

		protected virtual void Update()
		{
		}

		private void InitScreen()
		{
		}

		public void AddPanel(UIPanel panel)
		{
		}

		public void RemovePanel(UIPanel panel)
		{
		}

		public void ClearPanels()
		{
		}

		public void SetCurrentSelectedPanel(UISelectable overrideSelectable = null, bool scrollToChild = true)
		{
		}

		public void SetCurrentSelectedPanel(UIPanel panel, UISelectable overrideSelectable = null, bool scrollToChild = true)
		{
		}

		private void UpdateScrollbar()
		{
		}

		private void DetectInput()
		{
		}

		private void DetectScreenInputDescriptors()
		{
		}

		internal bool ForceNavigate(Vector2 navDir, Vector2 fromPos)
		{
			return false;
		}

		private bool Navigate(Vector2 navDir, Vector2 fromPos)
		{
			return false;
		}

		public void ChangeActiveScrollRect(ScrollRect newScrollRect)
		{
		}
	}
}
