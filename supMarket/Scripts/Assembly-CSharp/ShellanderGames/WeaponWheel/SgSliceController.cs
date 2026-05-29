using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShellanderGames.WeaponWheel
{
	public class SgSliceController : MonoBehaviour
	{
		[Tooltip("Set by weapon wheel. It's not recommended to edit it manually.")]
		public int sliceIndex;

		[Tooltip("Optional item/weapon name. Will be passed in Weapon Wheel Events.")]
		public string sliceName;

		[Tooltip("Update these by pressing the \"Find\" button after graphic creation.")]
		public SgSelectable[] graphicSelectables;

		[Tooltip("Set by weapon wheel. It's not recommended to edit it manually.")]
		public SgCircleSlice[] circleSlices;

		[Tooltip("Set by weapon wheel. It's not recommended to edit it manually.")]
		public SgSliceBorder[] sliceBorders;

		[Tooltip("Set by weapon wheel. It's not recommended to edit it manually.")]
		public RectTransform centerPoint;

		public TMP_Text createdText;

		[HideInInspector]
		public bool canBeHighlighted;

		private bool m_IsHighlighted;

		private bool m_IsPrioritized;

		private RectTransform m_RectTransform;

		private SgWeaponWheel m_WeaponWheel;

		private SgCircleSlice m_MainCircleSlice;

		private bool m_MouseEnterIsScheduled;

		private bool m_MouseExitIsScheduled;

		private bool m_MouseClickIsScheduled;

		public Vector2 CenterPoint => default(Vector2);

		public bool IsHighlighted => false;

		public bool IsPrioritized => false;

		public RectTransform RectTransform => null;

		private SgWeaponWheel WeaponWheel => null;

		private SgCircleSlice MainCircleSlice => null;

		private void Start()
		{
		}

		public void ResetInputHandling()
		{
		}

		public void SetupMouseListening()
		{
		}

		private void MouseEnter(BaseEventData tmp)
		{
		}

		private void MouseExit(BaseEventData tmp)
		{
		}

		private void MouseClick(BaseEventData tmp)
		{
		}

		private void ExecuteMouseEnter()
		{
		}

		private void ExecuteMouseExit()
		{
		}

		private void ExecuteMouseClick()
		{
		}

		public void AddIcon()
		{
		}

		public void AddText()
		{
		}

		public void AddTextMeshPro()
		{
		}

		public void Select()
		{
		}

		public void SetHighlighted(bool highlighted, bool forceImmediate)
		{
		}

		public void SetPrioritized(bool prioritized)
		{
		}

		private void ExecuteScheduledMouseEvents()
		{
		}

		public void RefreshContentSelectables()
		{
		}
	}
}
