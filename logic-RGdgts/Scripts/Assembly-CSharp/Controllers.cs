using System.Collections.Generic;
using UnityEngine;

public class Controllers : MonoBehaviour
{
	public static DebugToolsController debugToolsController;

	public static InputController inputController;

	public static DocumentationController documentationController;

	public static RetroNativeCore retroNativeCore;

	public static SceneController sceneController;

	public static InteractionController interactionController;

	public static ArchiveController archiveController;

	public static SamplesController samplesController;

	public static PaletteController paletteController;

	public static BuiltinAssetsController builtinAssetsController;

	public static LibsController libsController;

	public static GadgetPrefsController gadgetPrefsController;

	public static GameplayController gameplayController;

	public static List<Controller> controllers;

	private void Awake()
	{
	}

	private void Init<T>(ref T controller) where T : Controller
	{
	}

	public static void OnLevelLoaded(object storage = null)
	{
	}

	public static void OnLevelSaved(object storage)
	{
	}

	private void OnApplicationQuit()
	{
	}
}
