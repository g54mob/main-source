using UnityEngine;

public abstract class DVGUIWindow : MonoBehaviour
{
	private Rect windowRect = new Rect(20f, 100f, 250f, 0f);

	private int id;

	protected abstract string title { get; }

	private void Awake()
	{
		id = Random.Range(0, int.MaxValue);
	}

	private void OnGUI()
	{
		GUI.skin = DVGUI.skin;
		windowRect = GUILayout.Window(id, windowRect, GUIWindow, title);
	}

	private void GUIWindow(int id)
	{
		Window();
		GUI.DragWindow();
	}

	protected abstract void Window();
}
