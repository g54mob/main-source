using System.Collections.Generic;
using UnityEngine;
using VRTK.Highlighters;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactors/VRTK_ControllerHighlighter")]
	public class VRTK_ControllerHighlighter : MonoBehaviour
	{
		[Header("General Settings")]
		[Tooltip("The amount of time to take to transition to the set highlight colour.")]
		public float transitionDuration;

		[Header("Controller Highlight")]
		[Tooltip("The colour to set the entire controller highlight colour to.")]
		public Color highlightController = Color.clear;

		[Header("Element Highlights")]
		[Tooltip("The colour to set the body highlight colour to.")]
		public Color highlightBody = Color.clear;

		[Tooltip("The colour to set the trigger highlight colour to.")]
		public Color highlightTrigger = Color.clear;

		[Tooltip("The colour to set the grip highlight colour to.")]
		public Color highlightGrip = Color.clear;

		[Tooltip("The colour to set the touchpad highlight colour to.")]
		public Color highlightTouchpad = Color.clear;

		[Tooltip("The colour to set the touchpad two highlight colour to.")]
		public Color highlightTouchpadTwo = Color.clear;

		[Tooltip("The colour to set the button one highlight colour to.")]
		public Color highlightButtonOne = Color.clear;

		[Tooltip("The colour to set the button two highlight colour to.")]
		public Color highlightButtonTwo = Color.clear;

		[Tooltip("The colour to set the system menu highlight colour to.")]
		public Color highlightSystemMenu = Color.clear;

		[Tooltip("The colour to set the start menu highlight colour to.")]
		public Color highlightStartMenu = Color.clear;

		[Header("Custom Settings")]
		[Tooltip("A collection of strings that determine the path to the controller model sub elements for identifying the model parts at runtime. If the paths are left empty they will default to the model element paths of the selected SDK Bridge.")]
		public VRTK_ControllerModelElementPaths modelElementPaths = new VRTK_ControllerModelElementPaths();

		[Tooltip("A collection of highlighter overrides for each controller model sub element. If no highlighter override is given then highlighter on the Controller game object is used.")]
		public VRTK_ControllerElementHighlighters elementHighlighterOverrides = new VRTK_ControllerElementHighlighters();

		[Tooltip("An optional GameObject to specify which controller to apply the script methods to. If this is left blank then this script is required to be placed on a controller script alias GameObject and it will use the Actual Controller GameObject linked to the controller script alias.")]
		public GameObject controllerAlias;

		[Tooltip("An optional GameObject to specifiy where the controller models are. If this is left blank then the controller Model Alias object will be used.")]
		public GameObject modelContainer;

		[Tooltip("An optional Highlighter to use when highlighting the controller element. If this is left blank, then the first active highlighter on the same GameObject will be used, if one isn't found then a Material Color Swap Highlighter will be created at runtime.")]
		public VRTK_BaseHighlighter controllerHighlighter;

		protected bool controllerHighlighted;

		protected Dictionary<string, Transform> cachedElements = new Dictionary<string, Transform>();

		protected Dictionary<string, object> highlighterOptions = new Dictionary<string, object>();

		protected VRTK_BaseHighlighter baseHighlighter;

		protected bool autoHighlighter;

		protected bool trackedControllerReady;

		protected Color lastHighlightController;

		protected Color lastHighlightBody;

		protected Color lastHighlightTrigger;

		protected Color lastHighlightGrip;

		protected Color lastHighlightTouchpad;

		protected Color lastHighlightTouchpadTwo;

		protected Color lastHighlightButtonOne;

		protected Color lastHighlightButtonTwo;

		protected Color lastHighlightSystemMenu;

		protected Color lastHighlightStartMenu;

		protected SDK_BaseController.ControllerElements[] bodyElements = new SDK_BaseController.ControllerElements[1] { SDK_BaseController.ControllerElements.Body };

		protected SDK_BaseController.ControllerElements[] triggerElements = new SDK_BaseController.ControllerElements[1] { SDK_BaseController.ControllerElements.Trigger };

		protected SDK_BaseController.ControllerElements[] gripElements = new SDK_BaseController.ControllerElements[2]
		{
			SDK_BaseController.ControllerElements.GripLeft,
			SDK_BaseController.ControllerElements.GripRight
		};

		protected SDK_BaseController.ControllerElements[] touchpadElements = new SDK_BaseController.ControllerElements[1] { SDK_BaseController.ControllerElements.Touchpad };

		protected SDK_BaseController.ControllerElements[] touchpadTwoElements = new SDK_BaseController.ControllerElements[1] { SDK_BaseController.ControllerElements.TouchpadTwo };

		protected SDK_BaseController.ControllerElements[] buttonOneElements = new SDK_BaseController.ControllerElements[1] { SDK_BaseController.ControllerElements.ButtonOne };

		protected SDK_BaseController.ControllerElements[] buttonTwoElements = new SDK_BaseController.ControllerElements[1] { SDK_BaseController.ControllerElements.ButtonTwo };

		protected SDK_BaseController.ControllerElements[] systemMenuElements = new SDK_BaseController.ControllerElements[1] { SDK_BaseController.ControllerElements.SystemMenu };

		protected SDK_BaseController.ControllerElements[] startMenuElements = new SDK_BaseController.ControllerElements[1] { SDK_BaseController.ControllerElements.StartMenu };

		protected GameObject scriptControllerAlias;

		protected GameObject actualController;

		protected GameObject actualModelContainer;

		protected VRTK_TrackedController trackedController;

		public virtual void ConfigureControllerPaths()
		{
			cachedElements.Clear();
			modelElementPaths.bodyModelPath = GetElementPath(modelElementPaths.bodyModelPath, SDK_BaseController.ControllerElements.Body);
			modelElementPaths.triggerModelPath = GetElementPath(modelElementPaths.triggerModelPath, SDK_BaseController.ControllerElements.Trigger);
			modelElementPaths.leftGripModelPath = GetElementPath(modelElementPaths.leftGripModelPath, SDK_BaseController.ControllerElements.GripLeft);
			modelElementPaths.rightGripModelPath = GetElementPath(modelElementPaths.rightGripModelPath, SDK_BaseController.ControllerElements.GripRight);
			modelElementPaths.touchpadModelPath = GetElementPath(modelElementPaths.touchpadModelPath, SDK_BaseController.ControllerElements.Touchpad);
			modelElementPaths.touchpadTwoModelPath = GetElementPath(modelElementPaths.touchpadTwoModelPath, SDK_BaseController.ControllerElements.TouchpadTwo);
			modelElementPaths.buttonOneModelPath = GetElementPath(modelElementPaths.buttonOneModelPath, SDK_BaseController.ControllerElements.ButtonOne);
			modelElementPaths.buttonTwoModelPath = GetElementPath(modelElementPaths.buttonTwoModelPath, SDK_BaseController.ControllerElements.ButtonTwo);
			modelElementPaths.systemMenuModelPath = GetElementPath(modelElementPaths.systemMenuModelPath, SDK_BaseController.ControllerElements.SystemMenu);
			modelElementPaths.startMenuModelPath = GetElementPath(modelElementPaths.startMenuModelPath, SDK_BaseController.ControllerElements.StartMenu);
		}

		public virtual void PopulateHighlighters()
		{
			if (actualController != null)
			{
				highlighterOptions.Clear();
				VRTK_SharedMethods.AddDictionaryValue(highlighterOptions, "resetMainTexture", true, overwriteExisting: true);
				autoHighlighter = false;
				baseHighlighter = GetValidHighlighter();
				if (baseHighlighter == null)
				{
					autoHighlighter = true;
					baseHighlighter = actualController.AddComponent<VRTK_MaterialColorSwapHighlighter>();
				}
				SDK_BaseController.ControllerHand controllerHand = VRTK_DeviceFinder.GetControllerHand(actualController);
				baseHighlighter.Initialise(null, actualController, highlighterOptions);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.ButtonOne, controllerHand)), baseHighlighter, elementHighlighterOverrides.buttonOne);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.ButtonTwo, controllerHand)), baseHighlighter, elementHighlighterOverrides.buttonTwo);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.Body, controllerHand)), baseHighlighter, elementHighlighterOverrides.body);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.GripLeft, controllerHand)), baseHighlighter, elementHighlighterOverrides.gripLeft);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.GripRight, controllerHand)), baseHighlighter, elementHighlighterOverrides.gripRight);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.StartMenu, controllerHand)), baseHighlighter, elementHighlighterOverrides.startMenu);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.SystemMenu, controllerHand)), baseHighlighter, elementHighlighterOverrides.systemMenu);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.Touchpad, controllerHand)), baseHighlighter, elementHighlighterOverrides.touchpad);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.TouchpadTwo, controllerHand)), baseHighlighter, elementHighlighterOverrides.touchpadTwo);
				AddHighlighterToElement(GetElementTransform(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.Trigger, controllerHand)), baseHighlighter, elementHighlighterOverrides.trigger);
			}
		}

		public virtual void HighlightController(Color color, float fadeDuration = 0f)
		{
			HighlightElement(SDK_BaseController.ControllerElements.ButtonOne, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.ButtonTwo, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.Body, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.GripLeft, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.GripRight, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.StartMenu, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.SystemMenu, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.Touchpad, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.TouchpadTwo, color, fadeDuration);
			HighlightElement(SDK_BaseController.ControllerElements.Trigger, color, fadeDuration);
			controllerHighlighted = true;
			highlightController = color;
			lastHighlightController = color;
		}

		public virtual void UnhighlightController()
		{
			controllerHighlighted = false;
			highlightController = Color.clear;
			lastHighlightController = Color.clear;
			UnhighlightElement(SDK_BaseController.ControllerElements.ButtonOne);
			UnhighlightElement(SDK_BaseController.ControllerElements.ButtonTwo);
			UnhighlightElement(SDK_BaseController.ControllerElements.Body);
			UnhighlightElement(SDK_BaseController.ControllerElements.GripLeft);
			UnhighlightElement(SDK_BaseController.ControllerElements.GripRight);
			UnhighlightElement(SDK_BaseController.ControllerElements.StartMenu);
			UnhighlightElement(SDK_BaseController.ControllerElements.SystemMenu);
			UnhighlightElement(SDK_BaseController.ControllerElements.Touchpad);
			UnhighlightElement(SDK_BaseController.ControllerElements.TouchpadTwo);
			UnhighlightElement(SDK_BaseController.ControllerElements.Trigger);
		}

		public virtual void HighlightElement(SDK_BaseController.ControllerElements elementType, Color color, float fadeDuration = 0f)
		{
			Transform elementTransform = GetElementTransform(GetPathForControllerElement(elementType));
			if (elementTransform != null)
			{
				VRTK_ObjectAppearance.HighlightObject(elementTransform.gameObject, color, fadeDuration);
				SetColourParameter(elementType, color);
			}
		}

		public virtual void UnhighlightElement(SDK_BaseController.ControllerElements elementType)
		{
			if (!controllerHighlighted)
			{
				Transform elementTransform = GetElementTransform(GetPathForControllerElement(elementType));
				if (elementTransform != null)
				{
					VRTK_ObjectAppearance.UnhighlightObject(elementTransform.gameObject);
					SetColourParameter(elementType, Color.clear);
				}
			}
			else if (highlightController != Color.clear && GetColourParameter(elementType) != highlightController)
			{
				HighlightElement(elementType, highlightController);
			}
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			scriptControllerAlias = ((controllerAlias != null) ? controllerAlias : base.gameObject);
			actualController = VRTK_DeviceFinder.GetActualController(scriptControllerAlias);
			if (actualController != null)
			{
				trackedController = actualController.GetComponent<VRTK_TrackedController>();
				if (trackedController != null)
				{
					trackedController.ControllerModelAvailable += DoControllerModelAvailable;
				}
				if (trackedControllerReady)
				{
					ControllerAvailable();
				}
			}
			else
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_ControllerHighlighter", "Controller Alias GameObject", "controllerAlias", "the same"));
			}
		}

		protected virtual void OnDisable()
		{
			if (trackedController != null)
			{
				trackedController.ControllerModelAvailable -= DoControllerModelAvailable;
			}
			if (autoHighlighter && baseHighlighter != null)
			{
				Object.Destroy(baseHighlighter);
			}
			actualController = null;
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			ToggleControllerState();
			ToggleHighlightState(highlightBody, ref lastHighlightBody, bodyElements);
			ToggleHighlightState(highlightTrigger, ref lastHighlightTrigger, triggerElements);
			ToggleHighlightState(highlightGrip, ref lastHighlightGrip, gripElements);
			ToggleHighlightState(highlightTouchpad, ref lastHighlightTouchpad, touchpadElements);
			ToggleHighlightState(highlightTouchpadTwo, ref lastHighlightTouchpadTwo, touchpadTwoElements);
			ToggleHighlightState(highlightButtonOne, ref lastHighlightButtonOne, buttonOneElements);
			ToggleHighlightState(highlightButtonTwo, ref lastHighlightButtonTwo, buttonTwoElements);
			ToggleHighlightState(highlightSystemMenu, ref lastHighlightSystemMenu, systemMenuElements);
			ToggleHighlightState(highlightStartMenu, ref lastHighlightStartMenu, startMenuElements);
		}

		protected virtual void DoControllerModelAvailable(object sender, VRTKTrackedControllerEventArgs e)
		{
			trackedControllerReady = true;
			ControllerAvailable();
		}

		protected virtual void ControllerAvailable()
		{
			if (GetValidHighlighter() != baseHighlighter)
			{
				baseHighlighter = null;
			}
			ConfigureControllerPaths();
			actualModelContainer = ((modelContainer != null) ? modelContainer : VRTK_DeviceFinder.GetModelAliasController(actualController));
			PopulateHighlighters();
			ResetLastHighlights();
		}

		protected virtual void ResetLastHighlights()
		{
			lastHighlightController = Color.clear;
			lastHighlightBody = Color.clear;
			lastHighlightTrigger = Color.clear;
			lastHighlightGrip = Color.clear;
			lastHighlightTouchpad = Color.clear;
			lastHighlightTouchpadTwo = Color.clear;
			lastHighlightButtonOne = Color.clear;
			lastHighlightButtonTwo = Color.clear;
			lastHighlightSystemMenu = Color.clear;
			lastHighlightStartMenu = Color.clear;
		}

		protected virtual void SetColourParameter(SDK_BaseController.ControllerElements element, Color color)
		{
			color = ((color == Color.clear && highlightController != Color.clear) ? highlightController : color);
			switch (element)
			{
			case SDK_BaseController.ControllerElements.Body:
				highlightBody = color;
				lastHighlightBody = color;
				break;
			case SDK_BaseController.ControllerElements.Trigger:
				highlightTrigger = color;
				lastHighlightTrigger = color;
				break;
			case SDK_BaseController.ControllerElements.GripLeft:
			case SDK_BaseController.ControllerElements.GripRight:
				highlightGrip = color;
				lastHighlightGrip = color;
				break;
			case SDK_BaseController.ControllerElements.Touchpad:
				highlightTouchpad = color;
				lastHighlightTouchpad = color;
				break;
			case SDK_BaseController.ControllerElements.TouchpadTwo:
				highlightTouchpadTwo = color;
				lastHighlightTouchpadTwo = color;
				break;
			case SDK_BaseController.ControllerElements.ButtonOne:
				highlightButtonOne = color;
				lastHighlightButtonOne = color;
				break;
			case SDK_BaseController.ControllerElements.ButtonTwo:
				highlightButtonTwo = color;
				lastHighlightButtonTwo = color;
				break;
			case SDK_BaseController.ControllerElements.SystemMenu:
				highlightSystemMenu = color;
				lastHighlightSystemMenu = color;
				break;
			case SDK_BaseController.ControllerElements.StartMenu:
				highlightStartMenu = color;
				lastHighlightStartMenu = color;
				break;
			}
		}

		protected virtual Color GetColourParameter(SDK_BaseController.ControllerElements element)
		{
			switch (element)
			{
			case SDK_BaseController.ControllerElements.Body:
				return highlightBody;
			case SDK_BaseController.ControllerElements.Trigger:
				return highlightTrigger;
			case SDK_BaseController.ControllerElements.GripLeft:
			case SDK_BaseController.ControllerElements.GripRight:
				return highlightGrip;
			case SDK_BaseController.ControllerElements.Touchpad:
				return highlightTouchpad;
			case SDK_BaseController.ControllerElements.TouchpadTwo:
				return highlightTouchpadTwo;
			case SDK_BaseController.ControllerElements.ButtonOne:
				return highlightButtonOne;
			case SDK_BaseController.ControllerElements.ButtonTwo:
				return highlightButtonTwo;
			case SDK_BaseController.ControllerElements.SystemMenu:
				return highlightSystemMenu;
			case SDK_BaseController.ControllerElements.StartMenu:
				return highlightStartMenu;
			default:
				return Color.clear;
			}
		}

		protected virtual void ToggleControllerState()
		{
			if (highlightController != lastHighlightController)
			{
				if (highlightController == Color.clear)
				{
					UnhighlightController();
				}
				else
				{
					HighlightController(highlightController, transitionDuration);
				}
			}
		}

		protected virtual void ToggleHighlightState(Color currentColor, ref Color lastColorState, SDK_BaseController.ControllerElements[] elements)
		{
			if (!(currentColor != lastColorState))
			{
				return;
			}
			if (currentColor == Color.clear)
			{
				for (int i = 0; i < elements.Length; i++)
				{
					UnhighlightElement(elements[i]);
				}
			}
			else
			{
				for (int j = 0; j < elements.Length; j++)
				{
					HighlightElement(elements[j], currentColor, transitionDuration);
				}
			}
			lastColorState = currentColor;
		}

		protected virtual void AddHighlighterToElement(Transform element, VRTK_BaseHighlighter parentHighlighter, VRTK_BaseHighlighter overrideHighlighter)
		{
			if (element != null)
			{
				VRTK_BaseHighlighter component = element.GetComponent<VRTK_BaseHighlighter>();
				if (component != null)
				{
					Object.Destroy(component);
				}
				((VRTK_BaseHighlighter)VRTK_SharedMethods.CloneComponent((overrideHighlighter != null) ? overrideHighlighter : parentHighlighter, element.gameObject)).Initialise(null, element.gameObject, highlighterOptions);
			}
		}

		protected virtual string GetElementPath(string currentPath, SDK_BaseController.ControllerElements elementType)
		{
			SDK_BaseController.ControllerHand controllerHand = VRTK_DeviceFinder.GetControllerHand(actualController);
			string controllerElementPath = VRTK_SDK_Bridge.GetControllerElementPath(elementType, controllerHand);
			if (!(currentPath.Trim() == "") || controllerElementPath == null)
			{
				return currentPath.Trim();
			}
			return controllerElementPath;
		}

		protected virtual string GetPathForControllerElement(SDK_BaseController.ControllerElements controllerElement)
		{
			switch (controllerElement)
			{
			case SDK_BaseController.ControllerElements.Body:
				return modelElementPaths.bodyModelPath;
			case SDK_BaseController.ControllerElements.Trigger:
				return modelElementPaths.triggerModelPath;
			case SDK_BaseController.ControllerElements.GripLeft:
				return modelElementPaths.leftGripModelPath;
			case SDK_BaseController.ControllerElements.GripRight:
				return modelElementPaths.rightGripModelPath;
			case SDK_BaseController.ControllerElements.Touchpad:
				return modelElementPaths.touchpadModelPath;
			case SDK_BaseController.ControllerElements.TouchpadTwo:
				return modelElementPaths.touchpadTwoModelPath;
			case SDK_BaseController.ControllerElements.ButtonOne:
				return modelElementPaths.buttonOneModelPath;
			case SDK_BaseController.ControllerElements.ButtonTwo:
				return modelElementPaths.buttonTwoModelPath;
			case SDK_BaseController.ControllerElements.SystemMenu:
				return modelElementPaths.systemMenuModelPath;
			case SDK_BaseController.ControllerElements.StartMenu:
				return modelElementPaths.startMenuModelPath;
			default:
				return "";
			}
		}

		protected virtual Transform GetElementTransform(string path)
		{
			if (path == null)
			{
				return null;
			}
			if (actualModelContainer == null && VRTK_SharedMethods.GetDictionaryValue(cachedElements, path) == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.SDK_OBJECT_NOT_FOUND, "Controller Model", "Controller SDK"));
				return null;
			}
			return VRTK_SharedMethods.GetDictionaryValue(cachedElements, path, actualModelContainer.transform.Find(path), setMissingKey: true);
		}

		protected virtual void ToggleHighlightAlias(bool state, string transformPath, Color? highlight, float duration = 0f)
		{
			Transform elementTransform = GetElementTransform(transformPath);
			if ((bool)elementTransform)
			{
				if (state)
				{
					VRTK_ObjectAppearance.HighlightObject(elementTransform.gameObject, highlight ?? new Color?(Color.white), duration);
				}
				else
				{
					VRTK_ObjectAppearance.UnhighlightObject(elementTransform.gameObject);
				}
			}
		}

		protected virtual VRTK_BaseHighlighter GetValidHighlighter()
		{
			if (!(controllerHighlighter != null))
			{
				return VRTK_BaseHighlighter.GetActiveHighlighter(actualController);
			}
			return controllerHighlighter;
		}
	}
}
