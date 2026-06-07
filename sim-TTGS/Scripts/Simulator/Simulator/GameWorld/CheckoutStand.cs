using UnityEngine;

namespace Simulator.GameWorld
{
	public class CheckoutStand : Stand
	{
		[Header("Cash Register")]
		[SerializeField]
		private CashRegister m_cashRegister;

		private IStandUser m_currentUser;

		public override EStandType Type => EStandType.CHECKOUT;

		public override int LocationCount => 1;

		public IStandUser CurrentUser
		{
			get
			{
				return m_currentUser;
			}
			set
			{
				m_currentUser = value;
				if (m_currentUser is AIClientBehaviour aIClientBehaviour)
				{
					m_cashRegister.Workshop.CurrentlyCheckingOutCharacter = aIClientBehaviour.ClientCharacter;
					return;
				}
				m_cashRegister.Workshop.CurrentlyCheckingOutCharacter = null;
				if (m_currentUser != null)
				{
					AskToQuitStand(m_currentUser, completed: false);
				}
			}
		}

		public bool HasClientCheckingOut => CurrentUser != null;

		public override bool IsLocationRelevant(int locationIndex)
		{
			return true;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			m_cashRegister.Workshop.ClientCollected += OnClientCollected;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_cashRegister.Workshop.ClientCollected -= OnClientCollected;
		}

		public override void AccessViaSituation(IStandUser user, AIStandSituation situation)
		{
			base.AccessViaSituation(user, situation);
			if (situation.hasAccess)
			{
				CurrentUser = user;
				m_cashRegister.Workshop.WelcomeLoadedCheckingOutCharacter();
			}
		}

		protected override void OnUserGetPlace(IStandUser user, int placeIndex)
		{
			base.OnUserGetPlace(user, placeIndex);
			CurrentUser = user;
		}

		protected override void OnArrivedAtStand(IStandUser user)
		{
			base.OnArrivedAtStand(user);
			if (user is AIClientBehaviour aIClientBehaviour)
			{
				m_cashRegister.Workshop.WelcomeClient(aIClientBehaviour.GetPaymentMethod());
			}
		}

		private void OnClientCollected()
		{
			IStandUser currentUser = CurrentUser;
			CurrentUser = null;
			AskToQuitStand(currentUser, completed: true);
		}
	}
}
