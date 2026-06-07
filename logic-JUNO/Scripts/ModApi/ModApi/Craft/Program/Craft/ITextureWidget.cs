using UnityEngine;

namespace ModApi.Craft.Program.Craft
{
	public interface ITextureWidget
	{
		void DrawBox(int x1, int y1, int x2, int y2, Vector3 c);

		void DrawLine(int x1, int y1, int x2, int y2, Vector3 c);

		void DrawTri(Vector3 x, Vector3 y, Vector3 c);

		Vector3 GetPixel(int x, int y);

		void Initialize(int width, int height);

		void SetPixel(int x, int y, Vector3 c);
	}
}
