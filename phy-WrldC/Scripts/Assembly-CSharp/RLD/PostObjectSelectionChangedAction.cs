namespace RLD
{
	public class PostObjectSelectionChangedAction : IUndoRedoAction
	{
		private ObjectSelectionSnapshot _preChangeSnapshot;

		private ObjectSelectionSnapshot _postChangeSnapshot;

		public ObjectSelectionSnapshot PreChangeSnapshot => _preChangeSnapshot;

		public ObjectSelectionSnapshot PostChangeSnapshot => _postChangeSnapshot;

		public PostObjectSelectionChangedAction(ObjectSelectionSnapshot preChangeSnapshot, ObjectSelectionSnapshot postChangeSnapshot)
		{
			_preChangeSnapshot = preChangeSnapshot;
			_postChangeSnapshot = postChangeSnapshot;
		}

		public void Execute()
		{
			if (_preChangeSnapshot != null && _postChangeSnapshot != null)
			{
				MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
			}
		}

		public void Undo()
		{
		}

		public void Redo()
		{
		}

		public void OnRemovedFromUndoRedoStack()
		{
		}
	}
}
