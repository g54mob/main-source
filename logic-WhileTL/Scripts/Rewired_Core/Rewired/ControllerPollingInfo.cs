using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool QCczcvCqFbVUMDmvjefGifrevGctA;

		private int KjrBBzjjJWMijsVwJGfzfVcgArYWb;

		private int JJTApEccBgIfJOWwHYEPwbJOOnbjA;

		private string oLDIpbyvUNjVSihXbodQEcORUYWM;

		private ControllerType FHHqpHICfRrjYzaZOfxGJuaReWmv;

		private ControllerElementType QoNNWCBWhstwCjczWDBfosWZEUNR;

		private int UxnXexdLmPFrOAXyWtEwqWmaGYzH;

		private Pole lPCEkofCKXsHUGpkIhSUfmANSojq;

		private string QrYLUFYhZCvlEQOknfEziPsOZsSq;

		private int MToyChcGWGmeBbeiJGjHlICtSgbd;

		private KeyCode NFHegUiJVNbDBGpzJeCATRyhzlNkB;

		public bool success
		{
			get
			{
				return QCczcvCqFbVUMDmvjefGifrevGctA;
			}
			internal set
			{
				QCczcvCqFbVUMDmvjefGifrevGctA = qCczcvCqFbVUMDmvjefGifrevGctA;
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

		public string controllerName
		{
			get
			{
				return oLDIpbyvUNjVSihXbodQEcORUYWM;
			}
			internal set
			{
				oLDIpbyvUNjVSihXbodQEcORUYWM = text;
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

		public int elementIndex
		{
			get
			{
				return UxnXexdLmPFrOAXyWtEwqWmaGYzH;
			}
			internal set
			{
				UxnXexdLmPFrOAXyWtEwqWmaGYzH = uxnXexdLmPFrOAXyWtEwqWmaGYzH;
			}
		}

		public Pole axisPole
		{
			get
			{
				return lPCEkofCKXsHUGpkIhSUfmANSojq;
			}
			internal set
			{
				lPCEkofCKXsHUGpkIhSUfmANSojq = pole;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return QrYLUFYhZCvlEQOknfEziPsOZsSq;
			}
			internal set
			{
				QrYLUFYhZCvlEQOknfEziPsOZsSq = qrYLUFYhZCvlEQOknfEziPsOZsSq;
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

		public KeyCode keyboardKey
		{
			get
			{
				return NFHegUiJVNbDBGpzJeCATRyhzlNkB;
			}
			internal set
			{
				NFHegUiJVNbDBGpzJeCATRyhzlNkB = nFHegUiJVNbDBGpzJeCATRyhzlNkB;
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
				if (!ReInput.ajnOsEopTWvzJZjeDpcpYppqmqOw.cNsfjSDHCdJDCizaZhpZMoHCdftV(KjrBBzjjJWMijsVwJGfzfVcgArYWb))
				{
					return null;
				}
				return ReInput.ajnOsEopTWvzJZjeDpcpYppqmqOw.hwddIeJafOlGvnIklCDUFMkJMsvyB(KjrBBzjjJWMijsVwJGfzfVcgArYWb);
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

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return controller?.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
		{
			QCczcvCqFbVUMDmvjefGifrevGctA = P_0;
			KjrBBzjjJWMijsVwJGfzfVcgArYWb = P_1;
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_2;
			oLDIpbyvUNjVSihXbodQEcORUYWM = P_3;
			FHHqpHICfRrjYzaZOfxGJuaReWmv = P_4;
			QoNNWCBWhstwCjczWDBfosWZEUNR = P_5;
			UxnXexdLmPFrOAXyWtEwqWmaGYzH = P_6;
			lPCEkofCKXsHUGpkIhSUfmANSojq = P_7;
			QrYLUFYhZCvlEQOknfEziPsOZsSq = P_8;
			MToyChcGWGmeBbeiJGjHlICtSgbd = P_9;
			NFHegUiJVNbDBGpzJeCATRyhzlNkB = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			QCczcvCqFbVUMDmvjefGifrevGctA = P_0.QCczcvCqFbVUMDmvjefGifrevGctA;
			KjrBBzjjJWMijsVwJGfzfVcgArYWb = P_0.KjrBBzjjJWMijsVwJGfzfVcgArYWb;
			JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_0.JJTApEccBgIfJOWwHYEPwbJOOnbjA;
			oLDIpbyvUNjVSihXbodQEcORUYWM = P_0.oLDIpbyvUNjVSihXbodQEcORUYWM;
			FHHqpHICfRrjYzaZOfxGJuaReWmv = P_0.FHHqpHICfRrjYzaZOfxGJuaReWmv;
			QoNNWCBWhstwCjczWDBfosWZEUNR = P_0.QoNNWCBWhstwCjczWDBfosWZEUNR;
			UxnXexdLmPFrOAXyWtEwqWmaGYzH = P_0.UxnXexdLmPFrOAXyWtEwqWmaGYzH;
			lPCEkofCKXsHUGpkIhSUfmANSojq = P_0.lPCEkofCKXsHUGpkIhSUfmANSojq;
			QrYLUFYhZCvlEQOknfEziPsOZsSq = P_0.QrYLUFYhZCvlEQOknfEziPsOZsSq;
			MToyChcGWGmeBbeiJGjHlICtSgbd = P_0.MToyChcGWGmeBbeiJGjHlICtSgbd;
			NFHegUiJVNbDBGpzJeCATRyhzlNkB = P_0.NFHegUiJVNbDBGpzJeCATRyhzlNkB;
		}

		internal static ControllerPollingInfo WYxhQFUXiVvjJjdRGGxowZCsqZKV()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
