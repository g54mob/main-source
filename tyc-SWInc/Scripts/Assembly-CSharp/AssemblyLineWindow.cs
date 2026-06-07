using System.Linq;
using UnityEngine;

public class AssemblyLineWindow : MonoBehaviour
{
	public static AssemblyLineWindow Instance;

	public GUIWindow Window;

	public GUIListView List;

	public bool Dirty = true;

	public void Awake()
	{
		Instance = this;
	}

	public void Toggle()
	{
		Window.Toggle();
		if (Window.Shown)
		{
			List.Items = GameSettings.Instance.GetAssemblyLines().OfType<object>().ToList();
		}
	}

	public void Show()
	{
		Window.Show();
		List.Items = GameSettings.Instance.GetAssemblyLines().OfType<object>().ToList();
	}

	public void Update()
	{
		if (Dirty)
		{
			Dirty = false;
			List.Items = GameSettings.Instance.GetAssemblyLines().OfType<object>().ToList();
		}
	}

	public void ToggleAssemblyOverlay()
	{
		if (!DataOverlay.HasActive)
		{
			DataOverlay.Instance.ActivateFunc("AssemblyLines");
		}
		else
		{
			DataOverlay.Instance.ActivateFunc("AssemblyLines".Equals(DataOverlay.Instance.ActiveOverlayName) ? null : "AssemblyLines");
		}
	}
}
