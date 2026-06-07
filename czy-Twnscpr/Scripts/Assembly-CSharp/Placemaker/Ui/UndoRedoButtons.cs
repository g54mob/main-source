using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class UndoRedoButtons : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private TMP_Text undoSteps;

		[SerializeField]
		private TMP_Text redoSteps;

		[SerializeField]
		private BaseButton undoButton;

		[SerializeField]
		private BaseButton redoButton;

		[SerializeField]
		private bool isUndoDown;

		[SerializeField]
		private bool isRedoDown;

		private Action undoDown;

		private Action redoDown;

		private float undoDownTime;

		private float redoDownTime;

		private const float initialDelay = 1f;

		private bool hasUndone;

		private bool hasRedone;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void OnQueueChange(int undoCount, int redoCount)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_Undo()
		{
		}

		public void Button_Redo()
		{
		}

		private void Update()
		{
		}
	}
}
