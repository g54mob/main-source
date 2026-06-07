using TMPro;
using UI.Apps;
using UnityEngine;

public class DebugAppStacktraceService : MultitoolService
{
	public enum Mode
	{
		Error = 0,
		Debug = 1
	}

	public TextMeshProUGUI title;

	public Transform linesRoot;

	private LayoutHelper<Transform> layout;

	private DebugApp debugApp;

	private CPUModule cpu;

	private LuaStacktrace stacktrace;

	private int _depth;

	public int depth => 0;

	public void Show(DebugApp debugApp, CPUModule cpu, LuaStacktrace stacktrace, Mode mode)
	{
	}

	private void Refresh()
	{
	}

	public void Hide()
	{
	}

	private void OnClick(int i)
	{
	}
}
