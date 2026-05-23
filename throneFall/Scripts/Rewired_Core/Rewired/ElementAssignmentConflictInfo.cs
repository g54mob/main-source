using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool oCOiswxdLOCJCgWCPMiamVgVHLKDA;

		private bool wCEXXfFwAkTxsltpXqHeVpeOdlBm;

		private int IvsFLgRmHnJvumHCKlfJtfXSIAr;

		private ControllerType nEDZcHkDYENDruoliIaxclDdJsEV;

		private int cmKNykAhZqfnHwzbOHtnXtPiNSIM;

		private int LaglcejzbAuDIcGprBraEviNpXkM;

		private int GdyiagcBLwGPcORVBjCzKbQGwXLZ;

		private ControllerElementType TpgJsLMguUKIHPlqZDASHtXSyEowA;

		private int EEyzcXdkkSxlhKeNGTTdBOYUXKLj;

		private KeyCode ZnrcPATeYccabcsHQlPtYtFqDgpf;

		private ModifierKeyFlags ZTFuivXtMZauVzVgenvOAbkOfUng;

		private int HfifQOJjsudpKEdMEumdKwbunBYo;

		public bool isConflict
		{
			get
			{
				return oCOiswxdLOCJCgWCPMiamVgVHLKDA;
			}
			internal set
			{
				oCOiswxdLOCJCgWCPMiamVgVHLKDA = flag;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return wCEXXfFwAkTxsltpXqHeVpeOdlBm;
			}
			internal set
			{
				wCEXXfFwAkTxsltpXqHeVpeOdlBm = flag;
			}
		}

		public int playerId
		{
			get
			{
				return IvsFLgRmHnJvumHCKlfJtfXSIAr;
			}
			internal set
			{
				IvsFLgRmHnJvumHCKlfJtfXSIAr = ivsFLgRmHnJvumHCKlfJtfXSIAr;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return nEDZcHkDYENDruoliIaxclDdJsEV;
			}
			internal set
			{
				nEDZcHkDYENDruoliIaxclDdJsEV = controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				return cmKNykAhZqfnHwzbOHtnXtPiNSIM;
			}
			internal set
			{
				cmKNykAhZqfnHwzbOHtnXtPiNSIM = num;
			}
		}

		public int controllerMapId
		{
			get
			{
				return LaglcejzbAuDIcGprBraEviNpXkM;
			}
			internal set
			{
				LaglcejzbAuDIcGprBraEviNpXkM = laglcejzbAuDIcGprBraEviNpXkM;
			}
		}

		public int elementMapId
		{
			get
			{
				return GdyiagcBLwGPcORVBjCzKbQGwXLZ;
			}
			internal set
			{
				GdyiagcBLwGPcORVBjCzKbQGwXLZ = gdyiagcBLwGPcORVBjCzKbQGwXLZ;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return TpgJsLMguUKIHPlqZDASHtXSyEowA;
			}
			internal set
			{
				TpgJsLMguUKIHPlqZDASHtXSyEowA = tpgJsLMguUKIHPlqZDASHtXSyEowA;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return EEyzcXdkkSxlhKeNGTTdBOYUXKLj;
			}
			internal set
			{
				EEyzcXdkkSxlhKeNGTTdBOYUXKLj = eEyzcXdkkSxlhKeNGTTdBOYUXKLj;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return ZnrcPATeYccabcsHQlPtYtFqDgpf;
			}
			internal set
			{
				ZnrcPATeYccabcsHQlPtYtFqDgpf = znrcPATeYccabcsHQlPtYtFqDgpf;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return ZTFuivXtMZauVzVgenvOAbkOfUng;
			}
			internal set
			{
				ZTFuivXtMZauVzVgenvOAbkOfUng = zTFuivXtMZauVzVgenvOAbkOfUng;
			}
		}

		public int actionId
		{
			get
			{
				return HfifQOJjsudpKEdMEumdKwbunBYo;
			}
			internal set
			{
				HfifQOJjsudpKEdMEumdKwbunBYo = hfifQOJjsudpKEdMEumdKwbunBYo;
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(IvsFLgRmHnJvumHCKlfJtfXSIAr);
			}
		}

		public InputAction action
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.mapping.GetAction(HfifQOJjsudpKEdMEumdKwbunBYo);
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(nEDZcHkDYENDruoliIaxclDdJsEV, cmKNykAhZqfnHwzbOHtnXtPiNSIM);
			}
		}

		public ControllerMap controllerMap
		{
			get
			{
				if (player == null)
				{
					return null;
				}
				return player.controllers.maps.GetMap(nEDZcHkDYENDruoliIaxclDdJsEV, cmKNykAhZqfnHwzbOHtnXtPiNSIM, LaglcejzbAuDIcGprBraEviNpXkM);
			}
		}

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(EEyzcXdkkSxlhKeNGTTdBOYUXKLj);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (controllerMap == null)
				{
					return null;
				}
				return controllerMap.GetElementMap(GdyiagcBLwGPcORVBjCzKbQGwXLZ);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (nEDZcHkDYENDruoliIaxclDdJsEV == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(ZnrcPATeYccabcsHQlPtYtFqDgpf, ZTFuivXtMZauVzVgenvOAbkOfUng);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(EEyzcXdkkSxlhKeNGTTdBOYUXKLj);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
		{
			oCOiswxdLOCJCgWCPMiamVgVHLKDA = P_0;
			wCEXXfFwAkTxsltpXqHeVpeOdlBm = P_1;
			IvsFLgRmHnJvumHCKlfJtfXSIAr = P_2;
			nEDZcHkDYENDruoliIaxclDdJsEV = P_3;
			cmKNykAhZqfnHwzbOHtnXtPiNSIM = P_4;
			LaglcejzbAuDIcGprBraEviNpXkM = P_5;
			GdyiagcBLwGPcORVBjCzKbQGwXLZ = P_6;
			HfifQOJjsudpKEdMEumdKwbunBYo = P_7;
			TpgJsLMguUKIHPlqZDASHtXSyEowA = P_8;
			EEyzcXdkkSxlhKeNGTTdBOYUXKLj = P_9;
			ZnrcPATeYccabcsHQlPtYtFqDgpf = P_10;
			ZTFuivXtMZauVzVgenvOAbkOfUng = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			oCOiswxdLOCJCgWCPMiamVgVHLKDA = P_0.oCOiswxdLOCJCgWCPMiamVgVHLKDA;
			wCEXXfFwAkTxsltpXqHeVpeOdlBm = P_0.wCEXXfFwAkTxsltpXqHeVpeOdlBm;
			IvsFLgRmHnJvumHCKlfJtfXSIAr = P_0.IvsFLgRmHnJvumHCKlfJtfXSIAr;
			nEDZcHkDYENDruoliIaxclDdJsEV = P_0.nEDZcHkDYENDruoliIaxclDdJsEV;
			cmKNykAhZqfnHwzbOHtnXtPiNSIM = P_0.cmKNykAhZqfnHwzbOHtnXtPiNSIM;
			LaglcejzbAuDIcGprBraEviNpXkM = P_0.LaglcejzbAuDIcGprBraEviNpXkM;
			GdyiagcBLwGPcORVBjCzKbQGwXLZ = P_0.GdyiagcBLwGPcORVBjCzKbQGwXLZ;
			HfifQOJjsudpKEdMEumdKwbunBYo = P_0.HfifQOJjsudpKEdMEumdKwbunBYo;
			TpgJsLMguUKIHPlqZDASHtXSyEowA = P_0.TpgJsLMguUKIHPlqZDASHtXSyEowA;
			EEyzcXdkkSxlhKeNGTTdBOYUXKLj = P_0.EEyzcXdkkSxlhKeNGTTdBOYUXKLj;
			ZnrcPATeYccabcsHQlPtYtFqDgpf = P_0.ZnrcPATeYccabcsHQlPtYtFqDgpf;
			ZTFuivXtMZauVzVgenvOAbkOfUng = P_0.ZTFuivXtMZauVzVgenvOAbkOfUng;
		}
	}
}
