using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class RoomCustomisationMenuData : MonoBehaviour
	{
		public GameObject RowPrefab;

		public GraphicRaycaster GraphicRaycaster;

		public DynamicButton CloseButton;

		public Table Table;

		public RectTransform PanelRectTransform;

		public DynamicButton UGCButton;

		public Button LeftCycleButton;

		public Button RightCycleButton;

		public TMP_Text RoomNameText;

		[Header("Staff Tabs")]
		public DynamicButton WallButton;

		public DynamicButton FloorButton;

		public ButtonAnimator WallButtonAnimator;

		public ButtonAnimator FloorButtonAnimator;

		[Header("Apply All Button")]
		public DynamicButton ApplyToAllButton;

		public ButtonAnimator ApplyToAllButtonAnimator;

		[Header("Default Row")]
		public LocalisedString DefaultRowName;

		public Sprite DefaultWallIcon;

		public Sprite DefaultFloorIcon;
	}
}
