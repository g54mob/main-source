using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomInputSource : IDisposable
	{
		public abstract class Controller
		{
			protected bool _isConnected;

			protected string _deviceName;

			protected string _customName;

			public string customName => _customName;

			public bool isConnected
			{
				get
				{
					return _isConnected;
				}
				set
				{
					if (value != _isConnected)
					{
						_ = _isConnected;
						_isConnected = value;
					}
				}
			}

			public string deviceName => _deviceName;

			protected Controller(string P_0)
			{
				_deviceName = P_0;
			}

			public void Disconnect()
			{
				if (_isConnected)
				{
					_isConnected = false;
				}
			}

			public void Connect()
			{
				if (!_isConnected)
				{
					_isConnected = true;
				}
			}

			public abstract void Update();
		}

		public abstract class Joystick : Controller
		{
			private long? GRLnyUHuAbTqyfJgIMXqjoOCAoCj;

			private int aLXjiFAiGdcgKiZsPPaTBPunKQfQA;

			private readonly Axis[] KYDomJCzkZvEovkrcSXZYNxjeItq;

			private readonly Button[] SdzmrLzRDVnWnPLkJWHqvdlZjdLP;

			private readonly ReadOnlyCollection<Axis> tbJqCTfVbzVgFoypVXWvLczHBFmi;

			private readonly ReadOnlyCollection<Button> IQUzHBFhtZIzaobPqDEJfpBhbaIw;

			private bool FhQcOnHQqskLNlqbGPwiEOGJJxWzB;

			private Rewired.Controller.Extension GPKWEhXfOaeqYcwmiSdthAJvurKLA;

			public long? systemId
			{
				get
				{
					return GRLnyUHuAbTqyfJgIMXqjoOCAoCj;
				}
				protected set
				{
					GRLnyUHuAbTqyfJgIMXqjoOCAoCj = value;
				}
			}

			public int unityId
			{
				get
				{
					return aLXjiFAiGdcgKiZsPPaTBPunKQfQA;
				}
				protected set
				{
					aLXjiFAiGdcgKiZsPPaTBPunKQfQA = value;
				}
			}

			public IList<Axis> Axes => tbJqCTfVbzVgFoypVXWvLczHBFmi;

			public IList<Button> Buttons => IQUzHBFhtZIzaobPqDEJfpBhbaIw;

			public bool supportsVibration
			{
				get
				{
					return FhQcOnHQqskLNlqbGPwiEOGJJxWzB;
				}
				set
				{
					FhQcOnHQqskLNlqbGPwiEOGJJxWzB = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return GPKWEhXfOaeqYcwmiSdthAJvurKLA;
				}
				set
				{
					GPKWEhXfOaeqYcwmiSdthAJvurKLA = value;
				}
			}

			public int buttonCount => SdzmrLzRDVnWnPLkJWHqvdlZjdLP.Length;

			public int axisCount => KYDomJCzkZvEovkrcSXZYNxjeItq.Length;

			public Joystick(string P_0, long? P_1, int P_2, int P_3, int P_4)
				: base(P_0)
			{
				if (P_3 < 0)
				{
					P_3 = 0;
				}
				if (P_4 < 0)
				{
					P_4 = 0;
				}
				GRLnyUHuAbTqyfJgIMXqjoOCAoCj = P_1;
				aLXjiFAiGdcgKiZsPPaTBPunKQfQA = P_2;
				KYDomJCzkZvEovkrcSXZYNxjeItq = new Axis[P_3];
				SdzmrLzRDVnWnPLkJWHqvdlZjdLP = new Button[P_4];
				for (int i = 0; i < P_3; i++)
				{
					KYDomJCzkZvEovkrcSXZYNxjeItq[i] = new Axis();
				}
				for (int j = 0; j < P_4; j++)
				{
					SdzmrLzRDVnWnPLkJWHqvdlZjdLP[j] = new Button();
				}
				tbJqCTfVbzVgFoypVXWvLczHBFmi = new ReadOnlyCollection<Axis>(KYDomJCzkZvEovkrcSXZYNxjeItq);
				IQUzHBFhtZIzaobPqDEJfpBhbaIw = new ReadOnlyCollection<Button>(SdzmrLzRDVnWnPLkJWHqvdlZjdLP);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= KYDomJCzkZvEovkrcSXZYNxjeItq.Length)
				{
					return 0f;
				}
				return KYDomJCzkZvEovkrcSXZYNxjeItq[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= SdzmrLzRDVnWnPLkJWHqvdlZjdLP.Length)
				{
					return false;
				}
				return SdzmrLzRDVnWnPLkJWHqvdlZjdLP[index].value;
			}
		}

		public abstract class Element
		{
		}

		public sealed class Axis : Element
		{
			public float value;
		}

		public sealed class Button : Element
		{
			public bool value;
		}

		private readonly InputSource dGruROteZycoYhOyBaHkDNMCnrTiA;

		private readonly List<Joystick> DcXCQxjGiIjSKndqxoqEVCxebNKFA;

		private readonly ReadOnlyCollection<Joystick> cBNqcVZrfWDMXUGhPqbYAvdptdDK;

		private bool QpofdQiNDyJHvDGKvnamGKppOYVUA = true;

		[CompilerGenerated]
		private Action m_MZoXEFpQOWokPegvKGrpwUXvzgUo;

		[CompilerGenerated]
		private Action m_GQlcUkJdxBUnlanqFEsqFFqLmpMeb;

		private bool sFcgIQsYcqOTGjjLkftcieUklRFu;

		public bool useApproximateMatching
		{
			get
			{
				return QpofdQiNDyJHvDGKvnamGKppOYVUA;
			}
			protected set
			{
				QpofdQiNDyJHvDGKvnamGKppOYVUA = value;
			}
		}

		internal InputSource nRqNNZnjVHBvSDAJWwOGOwOIEHyt => dGruROteZycoYhOyBaHkDNMCnrTiA;

		public abstract bool isReady { get; }

		private event Action MZoXEFpQOWokPegvKGrpwUXvzgUo
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_MZoXEFpQOWokPegvKGrpwUXvzgUo;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_MZoXEFpQOWokPegvKGrpwUXvzgUo, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_MZoXEFpQOWokPegvKGrpwUXvzgUo;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_MZoXEFpQOWokPegvKGrpwUXvzgUo, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action GQlcUkJdxBUnlanqFEsqFFqLmpMeb
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_GQlcUkJdxBUnlanqFEsqFFqLmpMeb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_GQlcUkJdxBUnlanqFEsqFFqLmpMeb, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_GQlcUkJdxBUnlanqFEsqFFqLmpMeb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_GQlcUkJdxBUnlanqFEsqFFqLmpMeb, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action TWUwWrgRaapFEgJKNkjWoHcmtpwH
		{
			add
			{
				MZoXEFpQOWokPegvKGrpwUXvzgUo += action;
			}
			remove
			{
				MZoXEFpQOWokPegvKGrpwUXvzgUo -= action;
			}
		}

		internal event Action jsTqsdgTSbCuFDWhkQPlmLkDnzYQ
		{
			add
			{
				GQlcUkJdxBUnlanqFEsqFFqLmpMeb += action;
			}
			remove
			{
				GQlcUkJdxBUnlanqFEsqFFqLmpMeb -= action;
			}
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			dGruROteZycoYhOyBaHkDNMCnrTiA = (InputSource)P_0;
			DcXCQxjGiIjSKndqxoqEVCxebNKFA = new List<Joystick>();
			cBNqcVZrfWDMXUGhPqbYAvdptdDK = new ReadOnlyCollection<Joystick>(DcXCQxjGiIjSKndqxoqEVCxebNKFA);
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (DcXCQxjGiIjSKndqxoqEVCxebNKFA.Contains(joystick))
				{
					Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				}
				else
				{
					DcXCQxjGiIjSKndqxoqEVCxebNKFA.Add(joystick);
				}
			}
		}

		public void RemoveJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (!DcXCQxjGiIjSKndqxoqEVCxebNKFA.Contains(joystick))
				{
					Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				}
				else
				{
					DcXCQxjGiIjSKndqxoqEVCxebNKFA.Remove(joystick);
				}
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return cBNqcVZrfWDMXUGhPqbYAvdptdDK;
		}

		protected virtual void OnJoystickConnected()
		{
			if (this.MZoXEFpQOWokPegvKGrpwUXvzgUo != null)
			{
				this.MZoXEFpQOWokPegvKGrpwUXvzgUo();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (this.GQlcUkJdxBUnlanqFEsqFFqLmpMeb != null)
			{
				this.GQlcUkJdxBUnlanqFEsqFFqLmpMeb();
			}
		}

		internal Joystick[] PYQCqlToMPGmuUYZadqtJMvJpfVJ()
		{
			List<Joystick> list = new List<Joystick>(DcXCQxjGiIjSKndqxoqEVCxebNKFA.Count);
			for (int i = 0; i < DcXCQxjGiIjSKndqxoqEVCxebNKFA.Count; i++)
			{
				Joystick joystick = DcXCQxjGiIjSKndqxoqEVCxebNKFA[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		public virtual void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~CustomInputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!sFcgIQsYcqOTGjjLkftcieUklRFu)
			{
				sFcgIQsYcqOTGjjLkftcieUklRFu = true;
			}
		}

		public abstract void Update();
	}
}
