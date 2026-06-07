using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool JxWpmtxXnxrHVKSlgydtyxZFjJcj;

		private int dxyHpSMFwFgLVqzeCUcaIjWmfsqY;

		private int DbhbKwhJvRZENnONksIkLooDmtZgA;

		private string NkZBeQODVSnPeZtEHTglCMCdRRii;

		private ControllerType sYsgmTABiwwiJFddOPcDutOuIWFAA;

		private ControllerElementType NRJUfAywUMpUabKunzlQFtWUvoVi;

		private int ZUwcdGZkXWhalJUypDdlNBOxOIDd;

		private Pole GMvQKDZMhccBBlOnOWScsQDfahRiA;

		private string OMgRWEWZLitZffmmSvnCvOIHiBPG;

		private int sxFnhfxChVfIEKwbpoZwFBPutTcIA;

		private KeyCode MRygdCFjthcYtQGtTbhHekWUFWFxA;

		public bool success
		{
			get
			{
				return JxWpmtxXnxrHVKSlgydtyxZFjJcj;
			}
			internal set
			{
				JxWpmtxXnxrHVKSlgydtyxZFjJcj = jxWpmtxXnxrHVKSlgydtyxZFjJcj;
			}
		}

		public int playerId
		{
			get
			{
				return dxyHpSMFwFgLVqzeCUcaIjWmfsqY;
			}
			internal set
			{
				dxyHpSMFwFgLVqzeCUcaIjWmfsqY = num;
			}
		}

		public int controllerId
		{
			get
			{
				return DbhbKwhJvRZENnONksIkLooDmtZgA;
			}
			internal set
			{
				DbhbKwhJvRZENnONksIkLooDmtZgA = dbhbKwhJvRZENnONksIkLooDmtZgA;
			}
		}

		public string controllerName
		{
			get
			{
				return NkZBeQODVSnPeZtEHTglCMCdRRii;
			}
			internal set
			{
				NkZBeQODVSnPeZtEHTglCMCdRRii = nkZBeQODVSnPeZtEHTglCMCdRRii;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return sYsgmTABiwwiJFddOPcDutOuIWFAA;
			}
			internal set
			{
				sYsgmTABiwwiJFddOPcDutOuIWFAA = controllerType;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return NRJUfAywUMpUabKunzlQFtWUvoVi;
			}
			internal set
			{
				NRJUfAywUMpUabKunzlQFtWUvoVi = nRJUfAywUMpUabKunzlQFtWUvoVi;
			}
		}

		public int elementIndex
		{
			get
			{
				return ZUwcdGZkXWhalJUypDdlNBOxOIDd;
			}
			internal set
			{
				ZUwcdGZkXWhalJUypDdlNBOxOIDd = zUwcdGZkXWhalJUypDdlNBOxOIDd;
			}
		}

		public Pole axisPole
		{
			get
			{
				return GMvQKDZMhccBBlOnOWScsQDfahRiA;
			}
			internal set
			{
				GMvQKDZMhccBBlOnOWScsQDfahRiA = gMvQKDZMhccBBlOnOWScsQDfahRiA;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return OMgRWEWZLitZffmmSvnCvOIHiBPG;
			}
			internal set
			{
				OMgRWEWZLitZffmmSvnCvOIHiBPG = oMgRWEWZLitZffmmSvnCvOIHiBPG;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return sxFnhfxChVfIEKwbpoZwFBPutTcIA;
			}
			internal set
			{
				sxFnhfxChVfIEKwbpoZwFBPutTcIA = num;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return MRygdCFjthcYtQGtTbhHekWUFWFxA;
			}
			internal set
			{
				MRygdCFjthcYtQGtTbhHekWUFWFxA = mRygdCFjthcYtQGtTbhHekWUFWFxA;
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
				if (!ReInput.yLMToaDqIzfOcDAFApituELqzLeNA.nsNbeqOeAlsDNXrOqYDyFGYaXFSi(dxyHpSMFwFgLVqzeCUcaIjWmfsqY))
				{
					return null;
				}
				return ReInput.yLMToaDqIzfOcDAFApituELqzLeNA.brhNoQGyqbXIjYOSldNMHSkKJjCd(dxyHpSMFwFgLVqzeCUcaIjWmfsqY);
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
				return ReInput.controllers.GetController(sYsgmTABiwwiJFddOPcDutOuIWFAA, DbhbKwhJvRZENnONksIkLooDmtZgA);
			}
		}

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return controller?.GetElementIdentifierById(sxFnhfxChVfIEKwbpoZwFBPutTcIA);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
		{
			JxWpmtxXnxrHVKSlgydtyxZFjJcj = P_0;
			dxyHpSMFwFgLVqzeCUcaIjWmfsqY = P_1;
			DbhbKwhJvRZENnONksIkLooDmtZgA = P_2;
			NkZBeQODVSnPeZtEHTglCMCdRRii = P_3;
			sYsgmTABiwwiJFddOPcDutOuIWFAA = P_4;
			NRJUfAywUMpUabKunzlQFtWUvoVi = P_5;
			ZUwcdGZkXWhalJUypDdlNBOxOIDd = P_6;
			GMvQKDZMhccBBlOnOWScsQDfahRiA = P_7;
			OMgRWEWZLitZffmmSvnCvOIHiBPG = P_8;
			sxFnhfxChVfIEKwbpoZwFBPutTcIA = P_9;
			MRygdCFjthcYtQGtTbhHekWUFWFxA = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			JxWpmtxXnxrHVKSlgydtyxZFjJcj = P_0.JxWpmtxXnxrHVKSlgydtyxZFjJcj;
			dxyHpSMFwFgLVqzeCUcaIjWmfsqY = P_0.dxyHpSMFwFgLVqzeCUcaIjWmfsqY;
			DbhbKwhJvRZENnONksIkLooDmtZgA = P_0.DbhbKwhJvRZENnONksIkLooDmtZgA;
			NkZBeQODVSnPeZtEHTglCMCdRRii = P_0.NkZBeQODVSnPeZtEHTglCMCdRRii;
			sYsgmTABiwwiJFddOPcDutOuIWFAA = P_0.sYsgmTABiwwiJFddOPcDutOuIWFAA;
			NRJUfAywUMpUabKunzlQFtWUvoVi = P_0.NRJUfAywUMpUabKunzlQFtWUvoVi;
			ZUwcdGZkXWhalJUypDdlNBOxOIDd = P_0.ZUwcdGZkXWhalJUypDdlNBOxOIDd;
			GMvQKDZMhccBBlOnOWScsQDfahRiA = P_0.GMvQKDZMhccBBlOnOWScsQDfahRiA;
			OMgRWEWZLitZffmmSvnCvOIHiBPG = P_0.OMgRWEWZLitZffmmSvnCvOIHiBPG;
			sxFnhfxChVfIEKwbpoZwFBPutTcIA = P_0.sxFnhfxChVfIEKwbpoZwFBPutTcIA;
			MRygdCFjthcYtQGtTbhHekWUFWFxA = P_0.MRygdCFjthcYtQGtTbhHekWUFWFxA;
		}

		internal static ControllerPollingInfo mWifMPEIlKJzBSUffHpDICVvtEhtA()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
