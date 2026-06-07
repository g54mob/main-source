using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[CustomClassObfuscation]
	[DisallowMultipleComponent]
	public class CustomController : ComponentController
	{
		[Serializable]
		public class CreateCustomControllerSettings
		{
			[SerializeField]
			[CustomObfuscation]
			private bool _createCustomController;

			[SerializeField]
			[CustomObfuscation]
			private int _customControllerSourceId;

			[SerializeField]
			[CustomObfuscation]
			private int _assignToPlayerId;

			[SerializeField]
			[CustomObfuscation]
			private bool _destroyCustomController;

			public bool createCustomController
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int customControllerSourceId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int assignToPlayerId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool destroyCustomController
			{
				get
				{
					return false;
				}
				set
				{
				}
			}
		}

		private struct fGAlSCdCTveGuzXnAxWHotwolTux
		{
			public CustomControllerElementSelector.ElementType HdUojRicHUlIpCmGkuawfkOvHDMt;

			public int sqskcboieqNphlkypEagOBTMghIL;

			public float pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

			public fGAlSCdCTveGuzXnAxWHotwolTux(CustomControllerElementSelector.ElementType P_0, int P_1, float P_2)
			{
				HdUojRicHUlIpCmGkuawfkOvHDMt = default(CustomControllerElementSelector.ElementType);
				sqskcboieqNphlkypEagOBTMghIL = 0;
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 0f;
			}

			public fGAlSCdCTveGuzXnAxWHotwolTux(CustomControllerElementSelector.ElementType P_0, int P_1, bool P_2)
			{
				HdUojRicHUlIpCmGkuawfkOvHDMt = default(CustomControllerElementSelector.ElementType);
				sqskcboieqNphlkypEagOBTMghIL = 0;
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 0f;
			}

			public bool XVkiIeDdnmnyuteunuUxdseAjcdq(CustomControllerElementSelector.ElementType P_0, int P_1)
			{
				return false;
			}

			public void vZqRRYviGPiQjlKBnPeuANBeHCxEA(float P_0)
			{
			}

			public void vZqRRYviGPiQjlKBnPeuANBeHCxEA(bool P_0)
			{
			}
		}

		[SerializeField]
		[CustomObfuscation]
		private InputManager_Base _rewiredInputManager;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerSelector _customControllerSelector;

		[SerializeField]
		[CustomObfuscation]
		private CreateCustomControllerSettings _createCustomControllerSettings;

		private List<fGAlSCdCTveGuzXnAxWHotwolTux> bnAyfuRuVWLasqvQvcyUnMMnERsI;

		[NonSerialized]
		private int EvqLeXjoynoUtaGIjYzIdKCdwOkN;

		private Action EEvWOInbYwCpcrCfajmNfbyGrZAW;

		public InputManager_Base rewiredInputManager
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CustomControllerSelector customControllerSelector => null;

		public CreateCustomControllerSettings createCustomControllerSettings => null;

		internal event Action InputSourceUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		internal CustomController()
		{
		}

		public Rewired.CustomController GetCustomController()
		{
			return null;
		}

		[CustomObfuscation]
		internal override void OnEnable()
		{
		}

		[CustomObfuscation]
		internal override void OnDisable()
		{
		}

		[CustomObfuscation]
		internal override void OnValidate()
		{
		}

		[CustomObfuscation]
		internal override void OnDestroy()
		{
		}

		internal override bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			return false;
		}

		internal override void pmxmOeyRAlBoCxmllQyaxtECbvcr()
		{
		}

		internal override void KhQueZDBBtkbvKkxubYmYxeSHJrfA()
		{
		}

		public override void ClearControlValues()
		{
		}

		[CustomObfuscation]
		internal virtual bool GetUseCustomController()
		{
			return false;
		}

		[CustomObfuscation]
		internal virtual void SetUseCustomController(bool value)
		{
		}

		internal void SetAxisValue(CustomControllerElementSelector element, float value)
		{
		}

		internal void SetButtonValue(CustomControllerElementSelector element, bool value)
		{
		}

		internal void ClearElementValue(CustomControllerElementTargetSet targetSet)
		{
		}

		internal void ClearElementValue(CustomControllerElementTarget target)
		{
		}

		internal void ClearElementValue(CustomControllerElementSelector element)
		{
		}

		internal int ElementExists_Editor(CustomControllerElementSelector element)
		{
			return 0;
		}

		internal bool ElementExists(CustomControllerElementSelector element)
		{
			return false;
		}

		internal bool ValidateElements(CustomControllerElementTargetSet targetSet)
		{
			return false;
		}

		internal bool ValidateElement(CustomControllerElementTarget target)
		{
			return false;
		}

		internal bool ValidateElement(CustomControllerElementSelector element)
		{
			return false;
		}

		private void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
		}

		private bool xtOaTZjNcNEDSzHtXzyLfcbgMCzr()
		{
			return false;
		}

		private void lqTUhCwdWMAMoLtgyBRrJofStIlI()
		{
		}

		private Rewired.CustomController BEujAwJXazSYZkephxsuXudfwVop(bool P_0)
		{
			return null;
		}

		private void gWJwCnRORkFqemLcjtDBNqaOplQP(Rewired.CustomController P_0)
		{
		}

		private void rvQOXFzTIFbaRmdntsqwzrNlgFcU()
		{
		}

		private void xSRfhYigPyqxupRTdbIDngvwyRcJ()
		{
		}
	}
}
