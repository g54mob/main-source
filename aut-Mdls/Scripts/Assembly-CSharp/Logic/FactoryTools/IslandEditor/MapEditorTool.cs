using UnityEngine;

namespace Logic.FactoryTools.IslandEditor
{
	public abstract class MapEditorTool : ScriptableObject
	{
		[Header("General")]
		[SerializeField]
		protected SetCursorEvent _setCursorEvent;

		[SerializeField]
		protected Texture2D _cursorTexture;

		[SerializeField]
		protected Vector2 _cursorOffset;

		[SerializeField]
		protected string _cursorText;

		public abstract void UpdateTool(Vector3Int position);

		public abstract void OnActionIntent(Vector3Int position);

		public abstract void DoAction(Vector3Int position);

		public abstract void CancelAction();

		public abstract void Rotate(int angle);

		public abstract void Mirror();

		public virtual void SelectTool(EmptyIslandEditorData emptyIslandEditorData = null)
		{
			if (_setCursorEvent != null)
			{
				_setCursorEvent.Fire((_cursorTexture, _cursorText, _cursorOffset));
			}
		}
	}
}
