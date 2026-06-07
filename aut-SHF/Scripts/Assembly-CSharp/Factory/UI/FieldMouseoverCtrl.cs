using Factory.FieldData;
using Libs;
using TMPro;
using UnityEngine;

namespace Factory.UI
{
	public class FieldMouseoverCtrl : SingletonMonoBehaviour<FieldMouseoverCtrl>
	{
		public enum State
		{
			Close = 0,
			Wait = 1,
			Prepare = 2,
			Open = 3,
			SettingPrepare = 4,
			Setting = 5
		}

		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private FieldMouseoverWindowCtrl windowCtrl;

		[SerializeField]
		private FieldMouseoverSettingWindowCtrl settingWindowCtrl;

		private Transform windowTransform;

		[Header("UIのオフセット位置")]
		public Vector2 pivot;

		[SerializeField]
		private State state;

		private int openCounter;

		private Vector3Int? cursorGridPos;

		private Vector3Int preCursorGridPos;

		private bool alwaysMode;

		private bool dontOpen;

		private bool reserveOpenSettingWindow;

		private bool reserveCloseSettingWindow;

		private eMachine preMapMachine;

		private StructureGroupID preMapGid;

		private bool isOpenWindow;

		private Vector3 mousePosition;

		private eMachine showMachine;

		private bool IsSettingMode => false;

		private void Awake()
		{
		}

		private void SetActiveMainWindow(bool enable)
		{
		}

		private void SetActiveSettingWindow(bool enable)
		{
		}

		private void Update()
		{
		}

		public void UpdateMousePosition(Vector3 pos)
		{
		}

		public void UpdateGridRect(Vector2IntBundle cursorGridRect)
		{
		}

		public void SetAlwaysMode(bool always, bool dontOp)
		{
		}

		public void OpenSettingWindow(Vector2IntBundle cursorGridRect)
		{
		}

		public void OnCloseSettingWindow()
		{
		}

		private void ShowMachineDescription(eMachine machine)
		{
		}

		private void HideMachineDescription()
		{
		}
	}
}
