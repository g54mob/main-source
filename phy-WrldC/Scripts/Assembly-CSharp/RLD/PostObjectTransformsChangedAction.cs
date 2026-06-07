using System.Collections.Generic;

namespace RLD
{
	public class PostObjectTransformsChangedAction : IUndoRedoAction
	{
		private List<LocalTransformSnapshot> _preChangeTransformSnapshots = new List<LocalTransformSnapshot>();

		private List<LocalTransformSnapshot> _postChangeTransformSnapshots = new List<LocalTransformSnapshot>();

		public PostObjectTransformsChangedAction(List<LocalTransformSnapshot> preChangeTransformSnapshots, List<LocalTransformSnapshot> postChangeTransformSnapshots)
		{
			_preChangeTransformSnapshots = new List<LocalTransformSnapshot>(preChangeTransformSnapshots);
			_postChangeTransformSnapshots = new List<LocalTransformSnapshot>(postChangeTransformSnapshots);
		}

		public void Execute()
		{
			MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
		}

		public void Undo()
		{
			foreach (LocalTransformSnapshot preChangeTransformSnapshot in _preChangeTransformSnapshots)
			{
				preChangeTransformSnapshot.Apply();
			}
		}

		public void Redo()
		{
			foreach (LocalTransformSnapshot postChangeTransformSnapshot in _postChangeTransformSnapshots)
			{
				postChangeTransformSnapshot.Apply();
			}
		}

		public void OnRemovedFromUndoRedoStack()
		{
		}
	}
}
