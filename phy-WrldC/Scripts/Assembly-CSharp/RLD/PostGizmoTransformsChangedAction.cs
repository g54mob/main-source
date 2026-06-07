using System.Collections.Generic;

namespace RLD
{
	public class PostGizmoTransformsChangedAction : IUndoRedoAction
	{
		private List<LocalGizmoTransformSnapshot> _preChangeTransformSnapshots = new List<LocalGizmoTransformSnapshot>();

		private List<LocalGizmoTransformSnapshot> _postChangeTransformSnapshots = new List<LocalGizmoTransformSnapshot>();

		public PostGizmoTransformsChangedAction(List<LocalGizmoTransformSnapshot> preChangeTransformSnapshots, List<LocalGizmoTransformSnapshot> postChangeTransformSnapshots)
		{
			_preChangeTransformSnapshots = new List<LocalGizmoTransformSnapshot>(preChangeTransformSnapshots);
			_postChangeTransformSnapshots = new List<LocalGizmoTransformSnapshot>(postChangeTransformSnapshots);
		}

		public void Execute()
		{
			MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
		}

		public void Undo()
		{
			foreach (LocalGizmoTransformSnapshot preChangeTransformSnapshot in _preChangeTransformSnapshots)
			{
				preChangeTransformSnapshot.Apply();
			}
		}

		public void Redo()
		{
			foreach (LocalGizmoTransformSnapshot postChangeTransformSnapshot in _postChangeTransformSnapshots)
			{
				postChangeTransformSnapshot.Apply();
			}
		}

		public void OnRemovedFromUndoRedoStack()
		{
		}
	}
}
