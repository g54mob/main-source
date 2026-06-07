using System;
using UI;
using UI.Apps;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultiTool : MonoBehaviour
{
	public enum LogType
	{
		Info = 0,
		Warning = 1,
		Error = 2
	}

	public DraggablePanel panel;

	public Cable cable;

	private ModuleId selectedModule;

	[NonSerialized]
	[HideInInspector]
	public MultitoolService[] services;

	public MultitoolProjector projector;

	public MultitoolPrinter printer;

	public UIMultitoolManager uiManager;

	public UIMessageManager uiMessageManager;

	[NonSerialized]
	[HideInInspector]
	public MultitoolConsoleService console;

	[NonSerialized]
	[HideInInspector]
	public MultitoolInspectorService inspector;

	[NonSerialized]
	[HideInInspector]
	public MultitoolColorPickerService colorPicker;

	[NonSerialized]
	[HideInInspector]
	public EventSystem eventSystem;

	public static MultiTool instance;

	public bool isConnected => false;

	public T GetService<T>() where T : MultitoolService
	{
		return null;
	}

	private void InitServices()
	{
	}

	public virtual void Init()
	{
	}

	public Module GetSelectedModule()
	{
		return null;
	}

	private void SetSelectedModule(ModuleId moduleId)
	{
	}

	public void LogMessageToConsole(LogType logType, string message)
	{
	}

	protected virtual void Update()
	{
	}

	protected virtual void LateUpdate()
	{
	}

	public virtual void OnGadgetTurnOn()
	{
	}

	public virtual void OnGadgetTurnOff()
	{
	}

	public virtual void OnSetGadget(Gadget gadget)
	{
	}

	public virtual void OnGadgetEndEdit(Gadget gadget)
	{
	}

	public virtual void OnAppStart(MultiToolAppInfo appInfo)
	{
	}

	public virtual void OnAppStop(MultiToolAppInfo appInfo)
	{
	}

	public virtual void OnPanelOpen()
	{
	}

	public virtual void OnPanelClose()
	{
	}

	protected virtual void OnSelectedModule()
	{
	}

	public virtual void OnSolderModule(Module module)
	{
	}

	public virtual void OnUnsolderModule(Module module)
	{
	}

	public static void ErrorBeep()
	{
	}

	public static void Beep()
	{
	}

	public bool IsDeskEmpty()
	{
		return false;
	}

	public virtual void OnSelectModule(ModuleId id)
	{
	}
}
