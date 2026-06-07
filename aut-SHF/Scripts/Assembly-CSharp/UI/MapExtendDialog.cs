using System.Collections.Generic;
using Factory.FieldData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class MapExtendDialog : BaseDialog
	{
		private static MapExtendDialog _instance;

		private bool enableEscape;

		public Image[] arrowsR;

		public Image[] arrowsU;

		public Image[] arrowsL;

		public Image[] arrowsD;

		public Image resourceWindow;

		public List<MapExtendDialogIcon> icons;

		[SerializeField]
		private List<GameObject> _mapExtendCursor;

		public Button skipButton;

		private bool _isSelected;

		private int _selectedItemNumber;

		private const float GridToUiRate = 14.4f;

		public eMapExtension cursorArea;

		public bool ViewerMode { get; private set; }

		public static Vector3Int? GridPos { get; set; }

		public static MapExtendDialog I => null;

		public static Vector3 GetGridPosToUIPos(Vector3 gridPos)
		{
			return default(Vector3);
		}

		public static Vector3 GetGridPosToUIPos(Vector2 gridPos)
		{
			return default(Vector3);
		}

		private void Awake()
		{
		}

		private void ArrowsSetupPosition()
		{
		}

		private void ArrowsEnable(bool enable)
		{
		}

		private void ExtendCursorEnable()
		{
		}

		public void OverflowCursor(int direction)
		{
		}

		private void Inactive()
		{
		}

		private void Active()
		{
		}

		private void ActiveSkipButton()
		{
		}

		private void OnDestroy()
		{
		}

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		public override void Back()
		{
		}

		private void Update()
		{
		}

		public void SelectedArea(int number)
		{
		}

		public void OnAreaDecide()
		{
		}

		public void OnPressCancel()
		{
		}

		private void ExecuteExtend(eMapExtension area)
		{
		}

		private void EnableIcon(int i, int delay, eMachine resourcesMachine)
		{
		}

		private void DisableIcon(int i)
		{
		}

		private void FinishTrialMessage()
		{
		}

		public override void PushEscape()
		{
		}
	}
}
