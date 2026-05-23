using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class jg : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct PlayerActions
	{
		private jg m_Wrapper;

		public InputAction wyx => null;

		public InputAction wyy => null;

		public InputAction wyz => null;

		public InputAction wza => null;

		public InputAction wzb => null;

		public InputAction wzc => null;

		public InputAction wzd => null;

		public InputAction wze => null;

		public InputAction wzf => null;

		public InputAction wzg => null;

		public InputAction wzh => null;

		public InputAction wzi => null;

		public InputAction wzj => null;

		public InputAction wzk => null;

		public InputAction wzl => null;

		public InputAction wzm => null;

		public bool wzn => false;

		public PlayerActions(jg wrapper)
		{
			m_Wrapper = null;
		}

		public InputActionMap eul()
		{
			return null;
		}

		public void eum()
		{
		}

		public void eun()
		{
		}

		[SpecialName]
		public static InputActionMap eup(PlayerActions a)
		{
			return null;
		}

		public void euq(je a)
		{
		}

		private void eur(je a)
		{
		}

		public void eus(je a)
		{
		}

		public void eut(je a)
		{
		}
	}

	public struct UIActions
	{
		private jg m_Wrapper;

		public InputAction wzo => null;

		public InputAction wzp => null;

		public InputAction wzq => null;

		public InputAction wzr => null;

		public InputAction wzs => null;

		public InputAction wzt => null;

		public InputAction wzu => null;

		public InputAction wzv => null;

		public InputAction wzw => null;

		public InputAction wzx => null;

		public bool wzy => false;

		public UIActions(jg wrapper)
		{
			m_Wrapper = null;
		}

		public InputActionMap eve()
		{
			return null;
		}

		public void evf()
		{
		}

		public void evg()
		{
		}

		[SpecialName]
		public static InputActionMap evi(UIActions a)
		{
			return null;
		}

		public void evj(jf a)
		{
		}

		private void evk(jf a)
		{
		}

		public void evl(jf a)
		{
		}

		public void evm(jf a)
		{
		}
	}

	public interface je
	{
		void evn(InputAction.CallbackContext a);

		void evo(InputAction.CallbackContext a);

		void evp(InputAction.CallbackContext a);

		void evq(InputAction.CallbackContext a);

		void evr(InputAction.CallbackContext a);

		void evs(InputAction.CallbackContext a);

		void evt(InputAction.CallbackContext a);

		void evu(InputAction.CallbackContext a);

		void evv(InputAction.CallbackContext a);

		void evw(InputAction.CallbackContext a);

		void evx(InputAction.CallbackContext a);

		void evy(InputAction.CallbackContext a);

		void evz(InputAction.CallbackContext a);

		void ewa(InputAction.CallbackContext a);

		void ewb(InputAction.CallbackContext a);

		void ewc(InputAction.CallbackContext a);
	}

	public interface jf
	{
		void ewd(InputAction.CallbackContext a);

		void ewe(InputAction.CallbackContext a);

		void ewf(InputAction.CallbackContext a);

		void ewg(InputAction.CallbackContext a);

		void ewh(InputAction.CallbackContext a);

		void ewi(InputAction.CallbackContext a);

		void ewj(InputAction.CallbackContext a);

		void ewk(InputAction.CallbackContext a);

		void ewl(InputAction.CallbackContext a);

		void ewm(InputAction.CallbackContext a);
	}

	private readonly InputActionMap qdw;

	private List<je> qdx;

	private readonly InputAction qdy;

	private readonly InputAction qdz;

	private readonly InputAction qea;

	private readonly InputAction qeb;

	private readonly InputAction qec;

	private readonly InputAction qed;

	private readonly InputAction qee;

	private readonly InputAction qef;

	private readonly InputAction qeg;

	private readonly InputAction qeh;

	private readonly InputAction qei;

	private readonly InputAction qej;

	private readonly InputAction qek;

	private readonly InputAction qel;

	private readonly InputAction qem;

	private readonly InputAction qen;

	private readonly InputActionMap qeo;

	private List<jf> qep;

	private readonly InputAction qeq;

	private readonly InputAction qer;

	private readonly InputAction qes;

	private readonly InputAction qet;

	private readonly InputAction qeu;

	private readonly InputAction qev;

	private readonly InputAction qew;

	private readonly InputAction qex;

	private readonly InputAction qey;

	private readonly InputAction qez;

	private int qfa;

	private int qfb;

	private int qfc;

	private int qfd;

	private int qfe;

	public InputActionAsset qdv
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
	}

	public InputBinding? bindingMask
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes => default(ReadOnlyArray<InputControlScheme>);

	public IEnumerable<InputBinding> bindings => null;

	public PlayerActions wzz => default(PlayerActions);

	public UIActions xaa => default(UIActions);

	public InputControlScheme xab => default(InputControlScheme);

	public InputControlScheme xac => default(InputControlScheme);

	public InputControlScheme xad => default(InputControlScheme);

	public InputControlScheme xae => default(InputControlScheme);

	public InputControlScheme xaf => default(InputControlScheme);

	~jg()
	{
	}

	public void Dispose()
	{
	}

	public bool Contains(InputAction action)
	{
		return false;
	}

	public IEnumerator<InputAction> GetEnumerator()
	{
		return null;
	}

	private IEnumerator ewo()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ewo
		return this.ewo();
	}

	public void Enable()
	{
	}

	public void Disable()
	{
	}

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return null;
	}

	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		action = null;
		return 0;
	}
}
