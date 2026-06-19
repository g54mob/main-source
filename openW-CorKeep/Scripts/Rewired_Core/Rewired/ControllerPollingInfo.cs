using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool eiGQYPVInyqgnWCPuNpihcUjudnA;

		private int YIDsdUqHLiAuaeNKjLyRTrQjxlkc;

		private int ySFohZxOKPCJcMPkXAbwjwXIgsKBA;

		private string kDvqzdyheSskJPQnmoMrVkxwISlH;

		private ControllerType FzAhPmrrRsTdylPAdvLJbudrbZCt;

		private ControllerElementType mUhhLjGnIOgALxkVGCfAKXrVuhIf;

		private int aXSaXznaLCMaUPllSpcbILmoYPYR;

		private Pole rhXYjqhzAkUYwpOAzSnyzfkwiiSZ;

		private string jbMsjfqvueqqYtXRzSoSkvbEzSEj;

		private int NBtvAMLVODdLdoTGOoxiEyopKabl;

		private KeyCode tbSjAlDdCboNYVMQekWPdppFnXErA;

		public bool success
		{
			get
			{
				return eiGQYPVInyqgnWCPuNpihcUjudnA;
			}
			internal set
			{
				eiGQYPVInyqgnWCPuNpihcUjudnA = flag;
			}
		}

		public int playerId
		{
			get
			{
				return YIDsdUqHLiAuaeNKjLyRTrQjxlkc;
			}
			internal set
			{
				YIDsdUqHLiAuaeNKjLyRTrQjxlkc = yIDsdUqHLiAuaeNKjLyRTrQjxlkc;
			}
		}

		public int controllerId
		{
			get
			{
				return ySFohZxOKPCJcMPkXAbwjwXIgsKBA;
			}
			internal set
			{
				ySFohZxOKPCJcMPkXAbwjwXIgsKBA = num;
			}
		}

		public string controllerName
		{
			get
			{
				return kDvqzdyheSskJPQnmoMrVkxwISlH;
			}
			internal set
			{
				kDvqzdyheSskJPQnmoMrVkxwISlH = text;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return FzAhPmrrRsTdylPAdvLJbudrbZCt;
			}
			internal set
			{
				FzAhPmrrRsTdylPAdvLJbudrbZCt = fzAhPmrrRsTdylPAdvLJbudrbZCt;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return mUhhLjGnIOgALxkVGCfAKXrVuhIf;
			}
			internal set
			{
				mUhhLjGnIOgALxkVGCfAKXrVuhIf = controllerElementType;
			}
		}

		public int elementIndex
		{
			get
			{
				return aXSaXznaLCMaUPllSpcbILmoYPYR;
			}
			internal set
			{
				aXSaXznaLCMaUPllSpcbILmoYPYR = num;
			}
		}

		public Pole axisPole
		{
			get
			{
				return rhXYjqhzAkUYwpOAzSnyzfkwiiSZ;
			}
			internal set
			{
				rhXYjqhzAkUYwpOAzSnyzfkwiiSZ = pole;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return jbMsjfqvueqqYtXRzSoSkvbEzSEj;
			}
			internal set
			{
				jbMsjfqvueqqYtXRzSoSkvbEzSEj = text;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return NBtvAMLVODdLdoTGOoxiEyopKabl;
			}
			internal set
			{
				NBtvAMLVODdLdoTGOoxiEyopKabl = nBtvAMLVODdLdoTGOoxiEyopKabl;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return tbSjAlDdCboNYVMQekWPdppFnXErA;
			}
			internal set
			{
				tbSjAlDdCboNYVMQekWPdppFnXErA = keyCode;
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
				if (!ReInput.BIeoRJtgpppJNOjultHrXTwltUhx.KBbeYFsHLdSzoLeETxfqUSxdtIVT(YIDsdUqHLiAuaeNKjLyRTrQjxlkc))
				{
					return null;
				}
				return ReInput.BIeoRJtgpppJNOjultHrXTwltUhx.UvJedjalXzUlKEDfIYQQGGlTWIFK(YIDsdUqHLiAuaeNKjLyRTrQjxlkc);
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
				return ReInput.controllers.GetController(FzAhPmrrRsTdylPAdvLJbudrbZCt, ySFohZxOKPCJcMPkXAbwjwXIgsKBA);
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
				return controller?.GetElementIdentifierById(NBtvAMLVODdLdoTGOoxiEyopKabl);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
		{
			eiGQYPVInyqgnWCPuNpihcUjudnA = P_0;
			YIDsdUqHLiAuaeNKjLyRTrQjxlkc = P_1;
			ySFohZxOKPCJcMPkXAbwjwXIgsKBA = P_2;
			kDvqzdyheSskJPQnmoMrVkxwISlH = P_3;
			FzAhPmrrRsTdylPAdvLJbudrbZCt = P_4;
			mUhhLjGnIOgALxkVGCfAKXrVuhIf = P_5;
			aXSaXznaLCMaUPllSpcbILmoYPYR = P_6;
			rhXYjqhzAkUYwpOAzSnyzfkwiiSZ = P_7;
			jbMsjfqvueqqYtXRzSoSkvbEzSEj = P_8;
			NBtvAMLVODdLdoTGOoxiEyopKabl = P_9;
			tbSjAlDdCboNYVMQekWPdppFnXErA = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			eiGQYPVInyqgnWCPuNpihcUjudnA = P_0.eiGQYPVInyqgnWCPuNpihcUjudnA;
			YIDsdUqHLiAuaeNKjLyRTrQjxlkc = P_0.YIDsdUqHLiAuaeNKjLyRTrQjxlkc;
			ySFohZxOKPCJcMPkXAbwjwXIgsKBA = P_0.ySFohZxOKPCJcMPkXAbwjwXIgsKBA;
			kDvqzdyheSskJPQnmoMrVkxwISlH = P_0.kDvqzdyheSskJPQnmoMrVkxwISlH;
			FzAhPmrrRsTdylPAdvLJbudrbZCt = P_0.FzAhPmrrRsTdylPAdvLJbudrbZCt;
			mUhhLjGnIOgALxkVGCfAKXrVuhIf = P_0.mUhhLjGnIOgALxkVGCfAKXrVuhIf;
			aXSaXznaLCMaUPllSpcbILmoYPYR = P_0.aXSaXznaLCMaUPllSpcbILmoYPYR;
			rhXYjqhzAkUYwpOAzSnyzfkwiiSZ = P_0.rhXYjqhzAkUYwpOAzSnyzfkwiiSZ;
			jbMsjfqvueqqYtXRzSoSkvbEzSEj = P_0.jbMsjfqvueqqYtXRzSoSkvbEzSEj;
			NBtvAMLVODdLdoTGOoxiEyopKabl = P_0.NBtvAMLVODdLdoTGOoxiEyopKabl;
			tbSjAlDdCboNYVMQekWPdppFnXErA = P_0.tbSjAlDdCboNYVMQekWPdppFnXErA;
		}

		internal static ControllerPollingInfo ZWKipessSShuyCTGSTGJDqyiCJyY()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
