using System.Xml.Linq;
using ModApi.Flight.GameView;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Craft.Program.Craft
{
	public interface IMfdWidget
	{
		Vector2 AnchoredPosition { get; set; }

		Vector2 AnchorMax { get; set; }

		Vector2 AnchorMin { get; set; }

		Vector3 Color { get; set; }

		Vector2 LocalPosition { get; set; }

		float LocalRotation { get; set; }

		string Name { get; }

		float Opacity { get; set; }

		IMfdWidget Parent { get; }

		Vector2 Pivot { get; set; }

		Vector2 Scale { get; set; }

		Vector2 Size { get; set; }

		RectTransform Transform { get; }

		bool Visible { get; set; }

		Vector3 ConvertDisplayToLocal(Vector3 position);

		Vector3 ConvertLocalToDisplay(Vector3 position);

		void Destroy();

		string GetEventHandler(GameViewPointerEventType eventType);

		IGameViewPointerEventHandler HandleGameViewPointerEvent(GameViewPointerEvent pointerEvent);

		void RestoreFromXml(XElement xml);

		void SaveXml(XElement xml);

		void SetAnchor(ElementAlignment alignment);

		void SetEventHandler(GameViewPointerEventType eventType, string messageName, string data);

		void SetParent(IMfdWidget parent, bool worldPositionStays);

		void SetWidgetOrder(IMfdWidget target, bool front);
	}
}
