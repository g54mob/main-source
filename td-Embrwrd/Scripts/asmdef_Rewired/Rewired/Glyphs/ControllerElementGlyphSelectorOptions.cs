using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Glyphs
{
	[Serializable]
	public class ControllerElementGlyphSelectorOptions
	{
		[Serializable]
		public struct ControllerSelector
		{
			[Tooltip("The controller type of the Controller.")]
			[SerializeField]
			private ControllerType _controllerType;

			[SerializeField]
			[Tooltip("The hardware type GUID of the Controller. This value is used to identify recognized Controllers.")]
			private string _hardwareTypeGuid;

			[SerializeField]
			[Tooltip("The hardware identifier of the Controller. This is used primarily by Unknown Controllers to identify the controller using various information gathered from the controller. This value varies depending on the platform, input source in use, and the device.")]
			private string _hardwareIdentifier;

			[Tooltip("The list of Controller Map selectors. This provides necessary information about the Controller Maps to load.")]
			[SerializeField]
			private List<ControllerMapSelector> _controllerMapSelectors;

			[NonSerialized]
			private bool _isHardwareTypeGuidCached;

			[NonSerialized]
			private Guid _hardwareTypeGuidCache;

			public ControllerType controllerType
			{
				get
				{
					return default(ControllerType);
				}
				set
				{
				}
			}

			public Guid hardwareTypeGuid
			{
				get
				{
					return default(Guid);
				}
				set
				{
				}
			}

			public string hardwareIdentifier
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public List<ControllerMapSelector> controllerMapSelectors
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			private void UpdateHardwareTypeGuidCache()
			{
			}
		}

		[Serializable]
		public struct ControllerMapSelector
		{
			[Tooltip("The Controller Map Category name.")]
			[SerializeField]
			private string _mapCategoryName;

			[Tooltip("The Controller Map Layout name.")]
			[SerializeField]
			private string _layoutName;

			private const string errorMessage_notInitializedMemberAccess = "Rewired: Rewired must be initialized before accessing ";

			public string mapCategoryName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string layoutName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public int mapCategoryId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			private static string errorMessage_notInitialized_mapCategoryId => null;

			private static string errorMessage_notInitialized_layoutId => null;

			private static string errorMessage_invalidMapCategoryId => null;

			private static string errorMessage_invalidLayoutId => null;

			public int GetLayoutId(ControllerType controllerType)
			{
				return 0;
			}

			public void SetLayoutId(ControllerType controllerType, int layoutId)
			{
			}
		}

		private static readonly ControllerElementType[] s_defaultControllerElementTypeOrder;

		[Tooltip("Determines if the Player's last active controller is used for glyph selection.")]
		[SerializeField]
		private bool _useLastActiveController;

		[Tooltip("If enabled, results will be returned only for the first controller found that has at least one matching binding. This only has an effect on the result list returned when doing manual result selection or when selecting a result index greater than 0.This prevents results from being returned from multiple different devices, for example, when trying to get the second result from a single controller, excluding any other controllers such as the default controller. Note that Keyboard and Mouse are considered a single controller for the purposes of the glyph system.")]
		[SerializeField]
		private bool _useFirstControllerResults;

		[Tooltip("Controller type priority. First in list corresponds to highest priority. This determines which controller types take precedence when displaying glyphs. If use last active controller is enabled, the active controller will always take priority, however, if there is no last active controller, selection will fall back based on this priority. In addition, keyboard and mouse are treated as a single controller for the purposes of glyph handling, so to prioritze keyboard over mouse or vice versa, the one that is lower in the list will take precedence.")]
		[SerializeField]
		private ControllerType[] _controllerTypeOrder;

		[Tooltip("Controller element type priority. First in list corresponds to highest priority. This determines which controller element types take precedence when displaying glyphs.")]
		[SerializeField]
		private ControllerElementType[] _controllerElementTypeOrder;

		[Tooltip("If enabled, the default controllers will be used if no matching mappings are found in the Player for other controllers. The purpose of this is to allow glyphs to be displayed for a controller that is not connected. Controllers will be evaluated in the order in which they appear in the list.")]
		[SerializeField]
		private bool _useDefaultControllers;

		[Tooltip("Determines which controller will be used if no matching mappings are found in the Player for other controllers. The purpose of this is to allow glyphs to be displayed for a controller that is not connected. Use Default Controllers must be enabled for this to have any effect. Controllers will be evaluated in the order in which they appear in the list.\n\nFor recognized controllers, set only the Controller Type and the Hardware Type Guid, do not specify a Hardware Identifier which is only useful for unrecognized controllers and differs based on the platform and input source in use. The Hardware Type Guid of recognized controllers can be found in the Hardware Joystick Map controller definition located at Rewired/Internal/Data/Controllers/HardwareMaps/Joysticks/ or in the exported controllers CSV file which can be found in the glyphs documentation.")]
		[SerializeField]
		private List<ControllerSelector> _defaultControllers;

		[NonSerialized]
		private Predicate<ActionElementMap> _isActionElementMapAllowedHandler;

		private static ControllerElementGlyphSelectorOptions s_defaultOptions;

		public bool useLastActiveController
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useFirstControllerResults
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ControllerType[] controllerTypeOrder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ControllerElementType[] controllerElementTypeOrder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool useDefaultControllers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<ControllerSelector> defaultControllers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Predicate<ActionElementMap> isActionElementMapAllowedHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static ControllerElementGlyphSelectorOptions defaultOptions
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual bool TryGetControllerTypeOrder(int index, out ControllerType controllerType)
		{
			controllerType = default(ControllerType);
			return false;
		}
	}
}
