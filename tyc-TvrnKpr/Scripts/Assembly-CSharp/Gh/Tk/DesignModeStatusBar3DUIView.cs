using System;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class DesignModeStatusBar3DUIView : ShowHideAnimation3DUIView
	{
		[SerializeField]
		private Button3DUIView _freeCameraButton;

		[SerializeField]
		private TextMeshProI18n _name;

		[SerializeField]
		private GameObject _detailsParent;

		[SerializeField]
		private TextMeshPro _cost;

		[SerializeField]
		private TextMeshProI18n _totalCount;

		[SerializeField]
		private TextMeshProI18n _uniqueCount;

		[SerializeField]
		private Button3DUIView _directorsButton;

		private GameObject _model;

		private GameObjectX _gox;

		private GameObjectX Gox
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void Refresh()
		{
		}

		public override void Open(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Closed()
		{
		}

		private void OnNameChanged(object obj, EventArgs args)
		{
		}

		private void RefreshGoxName()
		{
		}
	}
}
