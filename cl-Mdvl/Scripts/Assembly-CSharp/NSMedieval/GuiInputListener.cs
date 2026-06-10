using System.Collections.Generic;
using System.Linq;
using NSMedieval.Components;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSMedieval
{
	public class GuiInputListener : InputListener
	{
		private static int layerUi;

		private static readonly List<RaycastResult> RaycastResults = new List<RaycastResult>();

		private bool stopEventPropagation;

		private bool isDownOverGui;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			RaycastResults.Clear();
			layerUi = 0;
		}

		public GuiInputListener()
			: base(InputListenerType.Gui)
		{
			layerUi = LayerMask.NameToLayer("UI");
		}

		public static bool IsMouseOverGui()
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = Input.mousePosition;
			RaycastResults.Clear();
			EventSystem.current.RaycastAll(pointerEventData, RaycastResults);
			return RaycastResults.Any((RaycastResult item) => item.gameObject.layer == layerUi);
		}

		public override void Begin()
		{
			stopEventPropagation = false;
			base.Begin();
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			isDownOverGui = IsMouseOverGui();
			if (isDownOverGui)
			{
				stopEventPropagation = true;
			}
			base.MouseButtonDown(button, position);
		}

		public override void MouseButtonUp(int button, Vector3 position)
		{
			if (isDownOverGui)
			{
				stopEventPropagation = true;
			}
			base.MouseButtonUp(button, position);
		}

		public override void MouseFullClick(int button, Vector3 position)
		{
			if (isDownOverGui)
			{
				stopEventPropagation = true;
			}
			base.MouseFullClick(button, position);
		}

		public override void Update()
		{
			if (IsStopEventPropagation() && !(Time.deltaTime <= 0.0001f))
			{
				stopEventPropagation = IsMouseOverGui();
				base.Update();
			}
		}

		public override bool IsStopEventPropagation()
		{
			return stopEventPropagation;
		}
	}
}
