using System;
using System.IO;
using UnityEngine;

namespace Simulator.Menus
{
	public class UI_LoadFile : UI_SaveAndLoadBaseFile
	{
		[Header("UI Components")]
		[SerializeField]
		private NavButton m_deleteButton;

		public event Action<FileInfo> OnDeleteButtonClickEvent;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_deleteButton.Button.onClick.AddListener(OnDeleteButtonClick);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_deleteButton.Button.onClick.RemoveListener(OnDeleteButtonClick);
		}

		private void OnDeleteButtonClick()
		{
			this.OnDeleteButtonClickEvent?.Invoke(base.Info.fileInfo);
		}
	}
}
