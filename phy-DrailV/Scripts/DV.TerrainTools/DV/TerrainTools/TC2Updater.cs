using TerrainComposer2;
using UnityEngine;

namespace DV.TerrainTools
{
	[ExecuteInEditMode]
	public class TC2Updater : MonoBehaviour
	{
		public Vector2 limitRect = new Vector2(120f, 120f);

		public Rect GetRectWorldspace()
		{
			Vector2 vector = new Vector2(base.transform.position.x, base.transform.position.z);
			return new Rect(vector.x - limitRect.x / 2f, vector.y - limitRect.y / 2f, limitRect.x, limitRect.y);
		}

		public Rect GetRect01()
		{
			Rect rectWorldspace = GetRectWorldspace();
			float num = TC_Area2D.current.bounds.size.x * (float)TC_Area2D.current.currentTerrainArea.tiles.x;
			float num2 = TC_Area2D.current.bounds.size.z * (float)TC_Area2D.current.currentTerrainArea.tiles.y;
			float num3 = rectWorldspace.x - TC_Area2D.current.currentTerrainArea.transform.position.x + num / 2f;
			return new Rect(y: (rectWorldspace.y - TC_Area2D.current.currentTerrainArea.transform.position.z + num2 / 2f) / num2, x: num3 / num, width: rectWorldspace.width / num, height: rectWorldspace.height / num2);
		}

		public void Regenerate(bool force)
		{
			Rect rect = GetRect01();
			if (force)
			{
				TC_Generate.instance.Generate(instantGenerate: false, rect);
			}
			else
			{
				TC.AutoGenerate(rect);
			}
		}

		[ContextMenu("Regenerate now")]
		private void RegenerateNow()
		{
			Regenerate(force: true);
		}
	}
}
