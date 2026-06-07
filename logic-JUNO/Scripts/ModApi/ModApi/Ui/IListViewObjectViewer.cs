using UnityEngine;

namespace ModApi.Ui
{
	public interface IListViewObjectViewer
	{
		bool DestroyWhenFinished { get; set; }

		void OnDrag(Vector2 delta);

		void OnEndDrag();

		void PreviewObject(GameObject previewObject, float delay = 0f, bool destroyWhenFinished = true, Vector3? containerRotation = null);
	}
}
