using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool qZfvGEZNTEuEuxrIYaHicwApcXyl;

		private bool fSHdeYIzGvHEccMagAXEgefMjXbiA;

		private int KjrBBzjjJWMijsVwJGfzfVcgArYWb;

		private ControllerType FHHqpHICfRrjYzaZOfxGJuaReWmv;

		private int JJTApEccBgIfJOWwHYEPwbJOOnbjA;

		private int vlkuJZhmXHevbDAiidanqGRLxfgM;

		private int IivbOkDQcOAAlqQyUHxNgzuYjPMT;

		private ControllerElementType QoNNWCBWhstwCjczWDBfosWZEUNR;

		private int MToyChcGWGmeBbeiJGjHlICtSgbd;

		private KeyCode PbCOhxlQRBbrGiRFIpZTeKPbNoms;

		private ModifierKeyFlags ckQxpADOjVaaMJciryKJvIwODZeCA;

		private int WtxqRhyewFhRCZexgGgTPAkliDAd;

		public bool isConflict
		{
			get
			{
				return qZfvGEZNTEuEuxrIYaHicwApcXyl;
			}
			internal set
			{
				qZfvGEZNTEuEuxrIYaHicwApcXyl = flag;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return fSHdeYIzGvHEccMagAXEgefMjXbiA;
			}
			internal set
			{
				fSHdeYIzGvHEccMagAXEgefMjXbiA = flag;
			}
		}

		public int playerId
		{
			get
			{
				return KjrBBzjjJWMijsVwJGfzfVcgArYWb;
			}
			internal set
			{
				KjrBBzjjJWMijsVwJGfzfVcgArYWb = kjrBBzjjJWMijsVwJGfzfVcgArYWb;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return FHHqpHICfRrjYzaZOfxGJuaReWmv;
			}
			internal set
			{
				FHHqpHICfRrjYzaZOfxGJuaReWmv = fHHqpHICfRrjYzaZOfxGJuaReWmv;
			}
		}

		public int controllerId
		{
			get
			{
				return JJTApEccBgIfJOWwHYEPwbJOOnbjA;
			}
			internal set
			{
				JJTApEccBgIfJOWwHYEPwbJOOnbjA = jJTApEccBgIfJOWwHYEPwbJOOnbjA;
			}
		}

		public int controllerMapId
		{
			get
			{
				return vlkuJZhmXHevbDAiidanqGRLxfgM;
			}
			internal set
			{
				vlkuJZhmXHevbDAiidanqGRLxfgM = num;
			}
		}

		public int elementMapId
		{
			get
			{
				return IivbOkDQcOAAlqQyUHxNgzuYjPMT;
			}
			internal set
			{
				IivbOkDQcOAAlqQyUHxNgzuYjPMT = iivbOkDQcOAAlqQyUHxNgzuYjPMT;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return QoNNWCBWhstwCjczWDBfosWZEUNR;
			}
			internal set
			{
				QoNNWCBWhstwCjczWDBfosWZEUNR = qoNNWCBWhstwCjczWDBfosWZEUNR;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return MToyChcGWGmeBbeiJGjHlICtSgbd;
			}
			internal set
			{
				MToyChcGWGmeBbeiJGjHlICtSgbd = mToyChcGWGmeBbeiJGjHlICtSgbd;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return PbCOhxlQRBbrGiRFIpZTeKPbNoms;
			}
			internal set
			{
				PbCOhxlQRBbrGiRFIpZTeKPbNoms = pbCOhxlQRBbrGiRFIpZTeKPbNoms;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return ckQxpADOjVaaMJciryKJvIwODZeCA;
			}
			internal set
			{
				ckQxpADOjVaaMJciryKJvIwODZeCA = modifierKeyFlags;
			}
		}

		public int actionId
		{
			get
			{
				return WtxqRhyewFhRCZexgGgTPAkliDAd;
			}
			internal set
			{
				WtxqRhyewFhRCZexgGgTPAkliDAd = wtxqRhyewFhRCZexgGgTPAkliDAd;
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
				return ReInput.players.GetPlayer(KjrBBzjjJWMijsVwJGfzfVcgArYWb);
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
				return ReInput.mapping.GetAction(WtxqRhyewFhRCZexgGgTPAkliDAd);
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
				return ReInput.controllers.GetController(FHHqpHICfRrjYzaZOfxGJuaReWmv, JJTApEccBgIfJOWwHYEPwbJOOnbjA);
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
				return player.controllers.maps.GetMap(FHHqpHICfRrjYzaZOfxGJuaReWmv, JJTApEccBgIfJOWwHYEPwbJOOnbjA, vlkuJZhmXHevbDAiidanqGRLxfgM);
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
				return controller.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd);
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
				return controllerMap.GetElementMap(IivbOkDQcOAAlqQyUHxNgzuYjPMT);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (FHHqpHICfRrjYzaZOfxGJuaReWmv == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(PbCOhxlQRBbrGiRFIpZTeKPbNoms, ckQxpADOjVaaMJciryKJvIwODZeCA);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.name;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
		{
			qZfvGEZNTEuEuxrIYaHicwApcXyl = P_0;
			fSHdeYIzGvHEccMagAXEgefMjXbiA = P_1;
			KjrBBzjjJWMijsVwJGfzfVcgArYWb = P_2;
			FHHqpHICfRrjYzaZOfxGJuaReWmv = P_3;
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_4;
			vlkuJZhmXHevbDAiidanqGRLxfgM = P_5;
			IivbOkDQcOAAlqQyUHxNgzuYjPMT = P_6;
			WtxqRhyewFhRCZexgGgTPAkliDAd = P_7;
			QoNNWCBWhstwCjczWDBfosWZEUNR = P_8;
			MToyChcGWGmeBbeiJGjHlICtSgbd = P_9;
			PbCOhxlQRBbrGiRFIpZTeKPbNoms = P_10;
			ckQxpADOjVaaMJciryKJvIwODZeCA = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			qZfvGEZNTEuEuxrIYaHicwApcXyl = P_0.qZfvGEZNTEuEuxrIYaHicwApcXyl;
			fSHdeYIzGvHEccMagAXEgefMjXbiA = P_0.fSHdeYIzGvHEccMagAXEgefMjXbiA;
			KjrBBzjjJWMijsVwJGfzfVcgArYWb = P_0.KjrBBzjjJWMijsVwJGfzfVcgArYWb;
			FHHqpHICfRrjYzaZOfxGJuaReWmv = P_0.FHHqpHICfRrjYzaZOfxGJuaReWmv;
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_0.JJTApEccBgIfJOWwHYEPwbJOOnbjA;
			vlkuJZhmXHevbDAiidanqGRLxfgM = P_0.vlkuJZhmXHevbDAiidanqGRLxfgM;
			IivbOkDQcOAAlqQyUHxNgzuYjPMT = P_0.IivbOkDQcOAAlqQyUHxNgzuYjPMT;
			WtxqRhyewFhRCZexgGgTPAkliDAd = P_0.WtxqRhyewFhRCZexgGgTPAkliDAd;
			QoNNWCBWhstwCjczWDBfosWZEUNR = P_0.QoNNWCBWhstwCjczWDBfosWZEUNR;
			MToyChcGWGmeBbeiJGjHlICtSgbd = P_0.MToyChcGWGmeBbeiJGjHlICtSgbd;
			PbCOhxlQRBbrGiRFIpZTeKPbNoms = P_0.PbCOhxlQRBbrGiRFIpZTeKPbNoms;
			ckQxpADOjVaaMJciryKJvIwODZeCA = P_0.ckQxpADOjVaaMJciryKJvIwODZeCA;
		}
	}
}
