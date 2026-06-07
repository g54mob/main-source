using System.Collections;

namespace CustomEditorUtility
{
	public class EditorCoroutine
	{
		private readonly IEnumerator routine;

		public static EditorCoroutine start(IEnumerator _routine)
		{
			EditorCoroutine editorCoroutine = new EditorCoroutine(_routine);
			editorCoroutine.start();
			return editorCoroutine;
		}

		private EditorCoroutine(IEnumerator _routine)
		{
			routine = _routine;
		}

		private void start()
		{
		}

		public void stop()
		{
		}

		private void update()
		{
		}
	}
}
