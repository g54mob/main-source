using System;
using DV.Utils;
using UnityEngine;

namespace DV.UI.ContextMenu
{
	public class HUDTurntableContextMenuProvider : AHUDTurntableProvider
	{
		private readonly Vector2 LOCAL_SCREEN_POS = new Vector2(0.5f, 0.95f);

		private const float HEIGHT_OFFSET = 5f;

		private const float DISTANCE_MIN = 7f;

		private const float DISTANCE_FADEOUT_INV = 0.2f;

		public AnimationCurve popupAnimation;

		public float popupLength;

		public float popupHeightMult;

		public HUDTurntableContextMenu menu;

		private TurntableControlKeyboardInput currentTurntable;

		private float timeSinceTurntableChanged;

		[NonSerialized]
		public SimpleHoverable simpleHoverable;

		private void Awake()
		{
			simpleHoverable = menu.GetComponent<SimpleHoverable>();
		}

		private void OnEnable()
		{
			menu.SetProvider(this);
		}

		public void TurntableChanged(TurntableControlKeyboardInput turntable)
		{
			if ((bool)currentTurntable)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.TurntableContextMenu, on: false);
			}
			currentTurntable = turntable;
			if ((bool)currentTurntable)
			{
				timeSinceTurntableChanged = 0f;
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.TurntableContextMenu, on: true);
				menu.UpdatePosition();
			}
		}

		public override void Move(bool right)
		{
			currentTurntable.Move(right ? 1 : (-1));
		}

		public override Vector2 GetScreenCoords()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if (!activeCamera)
			{
				return Vector2.zero;
			}
			timeSinceTurntableChanged += Time.unscaledDeltaTime;
			float time = Mathf.Clamp01(timeSinceTurntableChanged / popupLength);
			float num = 5f + popupAnimation.Evaluate(time) * popupHeightMult;
			Vector3 vector = currentTurntable.interactionAreaTrigger.transform.position + Vector3.up * num;
			Vector3 vector2 = activeCamera.WorldToViewportPoint(vector);
			float num2 = Vector3.Distance(activeCamera.transform.position, vector);
			vector2 = Vector2.Lerp(LOCAL_SCREEN_POS, vector2, (num2 - 7f) * 0.2f);
			return vector2;
		}
	}
}
