using UnityEngine;

namespace tripolygon.UModeler
{
	public interface IModelerEngine
	{
		Object selectedObject { get; }

		GameObject[] selectedGameObjects { get; }

		ElementSet selectedElements { get; }

		Camera currentCamera { get; }

		void DrawDotCap(Vector3 pos, Quaternion rot, float size);

		void DrawAALine(float width, Vector3 p0, Vector3 p1);

		void DisplayPolygonSelectionOverlay();

		void SerializePropertyField(string propertyName, Object values, string name = null);

		void SerializePropertyFields(Object values);

		Texture2D LoadImage(string path);
	}
}
