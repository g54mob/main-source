using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelShark
{
	public class TooltipManager : MonoBehaviour
	{
		public Camera guiCamera;

		public RectTransform matchRotationTo;

		public bool tooltipsEnabled;

		public bool touchSupport;

		public float tooltipDelay;

		public float fadeDuration;

		public bool overflowProtection;

		public PositionBounds positionBounds;

		private static TooltipManager instance;

		private bool isInitialized;

		public Canvas GuiCanvas { get; private set; }

		public string TextFieldDelimiter => null;

		public static TooltipManager Instance => null;

		private Canvas RootCanvas { get; set; }

		public GameObject TooltipContainer { get; private set; }

		private GameObject TooltipContainerNoAngle { get; set; }

		public Dictionary<TooltipStyle, Tooltip> Tooltips { get; private set; }

		public Tooltip BlockingTooltip { get; set; }

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void Initialize()
		{
		}

		private GameObject CreateTooltipContainer(string containerName)
		{
			return null;
		}

		public void ResetTooltipRotation()
		{
		}

		public void SetTextAndSize(TooltipTrigger trigger)
		{
		}

		public IEnumerator Show(TooltipTrigger trigger)
		{
			return null;
		}

		public void HideAll()
		{
		}

		public List<TooltipStyle> VisibleTooltips()
		{
			return null;
		}
	}
}
