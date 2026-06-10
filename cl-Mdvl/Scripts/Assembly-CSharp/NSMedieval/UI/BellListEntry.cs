using System;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class BellListEntry : MonoBehaviour
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Button toggleButton;

		[SerializeField]
		private Graphic toggleGraphicCheckmark;

		[SerializeField]
		private SoundButton goToButton;

		[SerializeField]
		private TMP_Text text;

		[NonSerialized]
		private RallyPointMarkerComponentInstance rallyPoint;

		[NonSerialized]
		private BellComponentInstance bell;

		private bool listenerInitialized;

		public Button Toggle => toggleButton;

		public void Init(RallyPointMarkerComponentInstance rallyPoint, BellComponentInstance bell)
		{
			this.bell = bell;
			this.rallyPoint = rallyPoint;
			text.SetText(this.rallyPoint.Name);
			CheckInitListener();
			RefreshCheckbox();
		}

		private void OnDestroy()
		{
			bell = null;
			rallyPoint = null;
		}

		private void CheckInitListener()
		{
			if (listenerInitialized)
			{
				return;
			}
			listenerInitialized = true;
			toggleButton.onClick.AddListener(delegate
			{
				if (bell.IsRallyPointAssigned(rallyPoint))
				{
					bell.RemoveRallyPoint(rallyPoint);
				}
				else
				{
					bell.AssignRallyPoint(rallyPoint);
				}
				RefreshCheckbox();
			});
			goToButton.onClick.AddListener(delegate
			{
				MonoSingleton<RtsCamera>.Instance.JumpTo(rallyPoint.WorldPosition);
				BaseBuildingViewComponent view = rallyPoint.Map.BuildingsManagerMain.GetView(rallyPoint.OwnerBuilding);
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(view);
			});
		}

		public void RefreshCheckbox()
		{
			bool active = bell.IsRallyPointAssigned(rallyPoint);
			toggleGraphicCheckmark.gameObject.SetActive(active);
		}
	}
}
