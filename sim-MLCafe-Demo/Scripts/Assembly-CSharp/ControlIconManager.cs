using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlIconManager : MonoBehaviour
{
	[SerializeField]
	private ControlIconComponent leftClickControl;

	[SerializeField]
	private ControlIconComponent rightClickControl;

	[SerializeField]
	private ControlIconComponent scrollControl;

	private static ControlIconManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Object.Destroy(this);
		}
	}

	private void Start()
	{
		SceneManager.activeSceneChanged += delegate
		{
			HideAllForced();
		};
		StartCoroutine(DelayedHide());
	}

	private IEnumerator DelayedHide()
	{
		yield return new WaitForSeconds(0.05f);
		leftClickControl.HideForced();
		rightClickControl.HideForced();
		scrollControl.HideForced();
	}

	public static bool IsValid()
	{
		return instance != null;
	}

	public static bool IsShowingControls()
	{
		if (!GetLeftClickControl().IsVisible() && !GetRightClickControl().IsVisible())
		{
			return GetScrollControl().IsVisible();
		}
		return true;
	}

	public static void Validate()
	{
		if (instance == null)
		{
			instance = Object.FindFirstObjectByType<ControlIconManager>();
		}
	}

	public static ControlIconComponent GetLeftClickControl()
	{
		return instance.leftClickControl;
	}

	public static ControlIconComponent GetRightClickControl()
	{
		return instance.rightClickControl;
	}

	public static ControlIconComponent GetScrollControl()
	{
		return instance.scrollControl;
	}

	public static void HideAll()
	{
		if (PreviewSystem.IsPreviewing())
		{
			GetRightClickControl().HideControl();
			return;
		}
		GetLeftClickControl().HideControl();
		GetRightClickControl().HideControl();
		GetScrollControl().HideControl();
	}

	public static void HideAllForced()
	{
		GetLeftClickControl().HideForced();
		GetRightClickControl().HideForced();
		GetScrollControl().HideForced();
	}
}
