using System;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class LinenSelectionButton3DUIView : Button3DUIView
	{
		private GameItem _linen;

		[SerializeField]
		private Transform _previewTransform;

		public TextMeshProI18n Text;

		public override bool IsBlocked => false;

		public Room Room { get; private set; }

		protected override void Awake()
		{
		}

		private bool IsLinenSelectionEnabled()
		{
			return false;
		}

		public void SetSelectedLinen(GameItemTemplate newLinenTemplate)
		{
		}

		public void SetData(Room room)
		{
		}

		private void OnLinenTypeChanged(object sender, EventArgs e)
		{
		}

		private void UpdateSelectedLinen()
		{
		}

		protected override void OnClickedInternal()
		{
		}
	}
}
