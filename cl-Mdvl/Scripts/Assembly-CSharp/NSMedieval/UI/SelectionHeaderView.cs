using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Manager;
using NSMedieval.Map;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SelectionHeaderView : UIView
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private SoundButton cameraFollowButton;

		[SerializeField]
		private SoundButton goToLayerButton;

		[SerializeField]
		private SoundButton selectNextButton;

		private string objectType;

		private void Start()
		{
			closeButton.onClick.AddListener(OnCloseButtonClick);
			cameraFollowButton.onClick.AddListener(OnCameraFollowButtonClick);
			goToLayerButton.onClick.AddListener(OnGotoLayerButtonClick);
			selectNextButton.onClick.AddListener(OnSelectNextButtonClick);
		}

		public void InitializeHeader(InfoPanelHeader header)
		{
			if (header != null)
			{
				objectType = header.ObjectType;
				title.SetText(header.ObjectName);
			}
		}

		private void OnCloseButtonClick()
		{
			MonoSingleton<UIController>.Instance.CloseSelectionPanel();
		}

		private void OnCameraFollowButtonClick()
		{
			if (MonoSingleton<UIController>.IsInstantiated() && MonoSingleton<SelectableObjectManager>.Instance.GetFirstSelected(out var selected))
			{
				base.CameraFollowAction(selected.transform);
			}
		}

		private void OnSelectNextButtonClick()
		{
			MonoSingleton<UIController>.Instance.SelectNextObject();
		}

		private void OnGotoLayerButtonClick()
		{
			if (MonoSingleton<SelectableObjectManager>.Instance.GetFirstSelected(out var selected))
			{
				Vector3 position = selected.transform.position;
				base.CameraCenterAction(position, arg2: false);
				MonoSingleton<World>.Instance.JumpToLayer(GridUtils.GetGridPosition(position));
			}
		}
	}
}
