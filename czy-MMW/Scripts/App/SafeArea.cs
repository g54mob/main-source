using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
	private RectTransform _panel;

	private Rect _lastSafeArea = new Rect(0f, 0f, 0f, 0f);

	[SerializeField]
	private bool _conformX = true;

	[SerializeField]
	private bool _conformY = true;

	private void OnEnable()
	{
		_panel = GetComponent<RectTransform>();
		if (_panel == null)
		{
			ScreenStack.Log.Error("Cannot apply safe area - no RectTransform found on " + base.name);
			Object.Destroy(base.gameObject);
		}
		Refresh();
	}

	public void Update()
	{
		Refresh();
	}

	private void Refresh()
	{
		Rect safeArea = GetSafeArea();
		if (safeArea != _lastSafeArea)
		{
			ApplySafeArea(safeArea);
		}
	}

	private Rect GetSafeArea()
	{
		return Screen.safeArea;
	}

	private void ApplySafeArea(Rect r)
	{
		_lastSafeArea = r;
		if (!_conformX)
		{
			r.x = 0f;
			r.width = Screen.width;
		}
		if (!_conformY)
		{
			r.y = 0f;
			r.height = Screen.height;
		}
		Vector2 position = r.position;
		Vector2 anchorMax = r.position + r.size;
		position.x /= Screen.width;
		position.y /= Screen.height;
		anchorMax.x /= Screen.width;
		anchorMax.y /= Screen.height;
		_panel.anchorMin = position;
		_panel.anchorMax = anchorMax;
		ScreenStack.Log.Info("New safe area applied to {0}: x={1}, y={2}, w={3}, h={4} on full extents w={5}, h={6}", base.name, r.x, r.y, r.width, r.height, Screen.width, Screen.height);
	}
}
