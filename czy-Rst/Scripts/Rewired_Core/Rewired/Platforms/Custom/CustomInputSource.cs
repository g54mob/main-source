using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Interfaces;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomInputSource : IDisposable
	{
		public abstract class Controller
		{
			protected bool _isConnected;

			protected string _deviceName;

			protected string _customName;

			protected object _customIdentifier;

			protected Guid _persistentGuid;

			private Action<bool> AIVhiRxeZYguxFOyNmZLCQpGhWSHA;

			public string customName => _customName;

			public bool isConnected
			{
				get
				{
					return _isConnected;
				}
				set
				{
					if (value == _isConnected)
					{
						return;
					}
					_isConnected = value;
					Action<bool> aIVhiRxeZYguxFOyNmZLCQpGhWSHA = AIVhiRxeZYguxFOyNmZLCQpGhWSHA;
					if (aIVhiRxeZYguxFOyNmZLCQpGhWSHA == null)
					{
						return;
					}
					try
					{
						aIVhiRxeZYguxFOyNmZLCQpGhWSHA(value);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("CustomInputSource.Controller.ConnectedStateChangedEvent", exception);
					}
				}
			}

			public string deviceName => _deviceName;

			public object customIdentifier
			{
				get
				{
					return _customIdentifier;
				}
				set
				{
					_customIdentifier = value;
				}
			}

			public Guid deviceInstanceGuid
			{
				get
				{
					return _persistentGuid;
				}
				set
				{
					_persistentGuid = value;
				}
			}

			public event Action<bool> ConnectedStateChangedEvent
			{
				add
				{
					AIVhiRxeZYguxFOyNmZLCQpGhWSHA = (Action<bool>)Delegate.Combine(AIVhiRxeZYguxFOyNmZLCQpGhWSHA, value);
				}
				remove
				{
					AIVhiRxeZYguxFOyNmZLCQpGhWSHA = (Action<bool>)Delegate.Remove(AIVhiRxeZYguxFOyNmZLCQpGhWSHA, value);
				}
			}

			protected Controller(string P_0)
			{
				_deviceName = P_0;
			}

			public void Disconnect()
			{
				if (_isConnected)
				{
					isConnected = false;
				}
			}

			public void Connect()
			{
				if (!_isConnected)
				{
					isConnected = true;
				}
			}

			public abstract void Update();
		}

		public abstract class Joystick : Controller
		{
			private long? TLhoFlZkQwJGefrlAAMMhuuvgpAf;

			private int xjvDhoUSCyfiWERdLbaxGVKdOajtb;

			private readonly Axis[] DXnTjgAacGnGafYguIBpIcVOyanr;

			private readonly Button[] XbRzwilHHYtfjDptLMuWzLJwFwRG;

			private readonly ReadOnlyCollection<Axis> yEjtmcrtwoPFBkmoBBsTJTbgbjsh;

			private readonly ReadOnlyCollection<Button> VQyekpXjNWlgIiWOsQvOfzhSGYUb;

			private bool ODoMXGGQcjjHHamkGkiSAbaowTOS;

			private Rewired.Controller.Extension BueqRGZdAvQaWwrfawbLExpGdDIO;

			public long? systemId
			{
				get
				{
					return TLhoFlZkQwJGefrlAAMMhuuvgpAf;
				}
				protected set
				{
					TLhoFlZkQwJGefrlAAMMhuuvgpAf = value;
				}
			}

			public int unityId
			{
				get
				{
					return xjvDhoUSCyfiWERdLbaxGVKdOajtb;
				}
				protected set
				{
					xjvDhoUSCyfiWERdLbaxGVKdOajtb = value;
				}
			}

			public IList<Axis> Axes => yEjtmcrtwoPFBkmoBBsTJTbgbjsh;

			public IList<Button> Buttons => VQyekpXjNWlgIiWOsQvOfzhSGYUb;

			public bool supportsVibration
			{
				get
				{
					return ODoMXGGQcjjHHamkGkiSAbaowTOS;
				}
				set
				{
					ODoMXGGQcjjHHamkGkiSAbaowTOS = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return BueqRGZdAvQaWwrfawbLExpGdDIO;
				}
				set
				{
					BueqRGZdAvQaWwrfawbLExpGdDIO = value;
					if (BueqRGZdAvQaWwrfawbLExpGdDIO is IControllerVibrator)
					{
						ODoMXGGQcjjHHamkGkiSAbaowTOS = true;
					}
				}
			}

			public int buttonCount => XbRzwilHHYtfjDptLMuWzLJwFwRG.Length;

			public int axisCount => DXnTjgAacGnGafYguIBpIcVOyanr.Length;

			protected Joystick(string P_0, long P_1, int P_2, int P_3)
				: this(P_0, P_1, 0, P_2, P_3)
			{
			}

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
				TLhoFlZkQwJGefrlAAMMhuuvgpAf = P_1;
				xjvDhoUSCyfiWERdLbaxGVKdOajtb = P_2;
				DXnTjgAacGnGafYguIBpIcVOyanr = new Axis[P_3];
				XbRzwilHHYtfjDptLMuWzLJwFwRG = new Button[P_4];
				for (int i = 0; i < P_3; i++)
				{
					DXnTjgAacGnGafYguIBpIcVOyanr[i] = new Axis();
				}
				for (int j = 0; j < P_4; j++)
				{
					XbRzwilHHYtfjDptLMuWzLJwFwRG[j] = new Button();
				}
				yEjtmcrtwoPFBkmoBBsTJTbgbjsh = new ReadOnlyCollection<Axis>(DXnTjgAacGnGafYguIBpIcVOyanr);
				VQyekpXjNWlgIiWOsQvOfzhSGYUb = new ReadOnlyCollection<Button>(XbRzwilHHYtfjDptLMuWzLJwFwRG);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= DXnTjgAacGnGafYguIBpIcVOyanr.Length)
				{
					return 0f;
				}
				return DXnTjgAacGnGafYguIBpIcVOyanr[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= XbRzwilHHYtfjDptLMuWzLJwFwRG.Length)
				{
					return false;
				}
				return XbRzwilHHYtfjDptLMuWzLJwFwRG[index].boolValue;
			}

			public virtual float GetButtonFloatValue(int index)
			{
				if (index < 0 || index >= XbRzwilHHYtfjDptLMuWzLJwFwRG.Length)
				{
					return 0f;
				}
				return XbRzwilHHYtfjDptLMuWzLJwFwRG[index].floatValue;
			}

			public virtual void SetAxisValue(int index, float value)
			{
				if (index >= 0 && index < DXnTjgAacGnGafYguIBpIcVOyanr.Length)
				{
					DXnTjgAacGnGafYguIBpIcVOyanr[index].value = value;
				}
			}

			public virtual void SetButtonValue(int index, bool value)
			{
				if (index >= 0 && index < XbRzwilHHYtfjDptLMuWzLJwFwRG.Length)
				{
					XbRzwilHHYtfjDptLMuWzLJwFwRG[index].boolValue = value;
				}
			}

			public virtual void SetButtonFloatValue(int index, float value)
			{
				if (index >= 0 && index < XbRzwilHHYtfjDptLMuWzLJwFwRG.Length)
				{
					XbRzwilHHYtfjDptLMuWzLJwFwRG[index].floatValue = value;
				}
			}

			internal void dSehppvDTQEdUIfyuJEEaPkHqLxDc(int P_0, out bool P_1, out float P_2)
			{
				if (P_0 < 0 || P_0 >= XbRzwilHHYtfjDptLMuWzLJwFwRG.Length)
				{
					P_1 = false;
					P_2 = 0f;
				}
				else
				{
					P_1 = XbRzwilHHYtfjDptLMuWzLJwFwRG[P_0].IPpHzpEugzwIioBNJmPSzFzxkqbk;
					P_2 = XbRzwilHHYtfjDptLMuWzLJwFwRG[P_0].floatValue;
				}
			}

			internal virtual void yBKSMAHvVuJLGNUzduiKTanNxIEN()
			{
				for (int i = 0; i < XbRzwilHHYtfjDptLMuWzLJwFwRG.Length; i++)
				{
					if (XbRzwilHHYtfjDptLMuWzLJwFwRG[i] != null)
					{
						XbRzwilHHYtfjDptLMuWzLJwFwRG[i].PuqlIWGZwQOiQYIcNcHJOWwdnMuB();
					}
				}
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
			[Obsolete("Deprecated. Use boolValue instead.", false)]
			public bool value;

			private float wfpyLcgjdgRmUgldthZDsjEJQtTN;

			private bool RidkVYfJQjdaWqjgYUhEQztcLxut;

			public bool boolValue
			{
				get
				{
					return value;
				}
				set
				{
					_ = this.value;
					if (!this.value && value)
					{
						RidkVYfJQjdaWqjgYUhEQztcLxut = true;
					}
					this.value = value;
				}
			}

			public float floatValue
			{
				get
				{
					return wfpyLcgjdgRmUgldthZDsjEJQtTN;
				}
				set
				{
					wfpyLcgjdgRmUgldthZDsjEJQtTN = value;
				}
			}

			internal bool IPpHzpEugzwIioBNJmPSzFzxkqbk
			{
				get
				{
					if (!value)
					{
						return RidkVYfJQjdaWqjgYUhEQztcLxut;
					}
					return true;
				}
			}

			internal void PuqlIWGZwQOiQYIcNcHJOWwdnMuB()
			{
				RidkVYfJQjdaWqjgYUhEQztcLxut = false;
			}
		}

		private readonly InputSource ujRhhfbNAxezMhvqFLnIBkgzVzNd;

		private readonly List<Joystick> MCxRxIxoLDGiMtilhezuRcBZtnAK;

		private readonly ReadOnlyCollection<Joystick> pZdzayXfnNNoXODiXEqwGdVQKNZV;

		private bool ZkWhqnRePbwLdAAZzOyEWtFEEsXN = true;

		private IUnifiedKeyboardSource pQOAhTtQkxVtliJaNDnmDtlWRApdA;

		private IUnifiedMouseSource FLKPfWFSOHjszvocIfErJnPZoRBi;

		[CompilerGenerated]
		private Action m_HaGPNipuKJucRyJmSjlLiupWqWQZ;

		[CompilerGenerated]
		private Action m_JjDFBbPjCGldbszKPiEIDBCcNlGg;

		private bool pDGjLpGocvHCQrvWwPvMgqgDNfHwA;

		public bool useApproximateMatching
		{
			get
			{
				return ZkWhqnRePbwLdAAZzOyEWtFEEsXN;
			}
			protected set
			{
				ZkWhqnRePbwLdAAZzOyEWtFEEsXN = value;
			}
		}

		internal InputSource qPMUMehiHEDlGbNIUsQohQervpgoA => ujRhhfbNAxezMhvqFLnIBkgzVzNd;

		public abstract bool isReady { get; }

		private event Action HaGPNipuKJucRyJmSjlLiupWqWQZ
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_HaGPNipuKJucRyJmSjlLiupWqWQZ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_HaGPNipuKJucRyJmSjlLiupWqWQZ, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_HaGPNipuKJucRyJmSjlLiupWqWQZ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_HaGPNipuKJucRyJmSjlLiupWqWQZ, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action JjDFBbPjCGldbszKPiEIDBCcNlGg
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_JjDFBbPjCGldbszKPiEIDBCcNlGg;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_JjDFBbPjCGldbszKPiEIDBCcNlGg, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_JjDFBbPjCGldbszKPiEIDBCcNlGg;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_JjDFBbPjCGldbszKPiEIDBCcNlGg, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action WCoAzlaXXzRdOenGFGiicoQXERqTA
		{
			add
			{
				HaGPNipuKJucRyJmSjlLiupWqWQZ += action;
			}
			remove
			{
				HaGPNipuKJucRyJmSjlLiupWqWQZ -= action;
			}
		}

		internal event Action oNzWdKopEkCqTjVyaPJBAwAupHAoA
		{
			add
			{
				JjDFBbPjCGldbszKPiEIDBCcNlGg += action;
			}
			remove
			{
				JjDFBbPjCGldbszKPiEIDBCcNlGg -= action;
			}
		}

		internal IUnifiedKeyboardSource WGiWTegEKFEInJWOSunAWtaqdWCUA()
		{
			return pQOAhTtQkxVtliJaNDnmDtlWRApdA;
		}

		internal IUnifiedMouseSource BsgRyFJghmDeJarLdvjREaudnpHP()
		{
			return FLKPfWFSOHjszvocIfErJnPZoRBi;
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			ujRhhfbNAxezMhvqFLnIBkgzVzNd = (InputSource)P_0;
			MCxRxIxoLDGiMtilhezuRcBZtnAK = new List<Joystick>();
			pZdzayXfnNNoXODiXEqwGdVQKNZV = new ReadOnlyCollection<Joystick>(MCxRxIxoLDGiMtilhezuRcBZtnAK);
		}

		internal CustomInputSource(int P_0, IUnifiedKeyboardSource P_1, IUnifiedMouseSource P_2)
			: this(P_0)
		{
			pQOAhTtQkxVtliJaNDnmDtlWRApdA = P_1;
			FLKPfWFSOHjszvocIfErJnPZoRBi = P_2;
		}

		internal virtual void PusaYVcABdgihSkdmyFkhbobGEPF()
		{
			OnInitialize();
		}

		protected virtual void OnInitialize()
		{
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			if (MCxRxIxoLDGiMtilhezuRcBZtnAK.Contains(joystick))
			{
				Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				return;
			}
			MCxRxIxoLDGiMtilhezuRcBZtnAK.Add(joystick);
			joystick.ConnectedStateChangedEvent += CaCRmQikiVLMtZLwkgPIggSkyDUiA;
			if (joystick.isConnected)
			{
				OnJoystickConnected();
			}
		}

		public void RemoveJoystick(Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			if (!MCxRxIxoLDGiMtilhezuRcBZtnAK.Contains(joystick))
			{
				Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				return;
			}
			MCxRxIxoLDGiMtilhezuRcBZtnAK.Remove(joystick);
			joystick.ConnectedStateChangedEvent -= CaCRmQikiVLMtZLwkgPIggSkyDUiA;
			if (joystick.isConnected)
			{
				OnJoystickDisconnected();
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return pZdzayXfnNNoXODiXEqwGdVQKNZV;
		}

		protected virtual void OnJoystickConnected()
		{
			if (this.HaGPNipuKJucRyJmSjlLiupWqWQZ != null)
			{
				this.HaGPNipuKJucRyJmSjlLiupWqWQZ();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (this.JjDFBbPjCGldbszKPiEIDBCcNlGg != null)
			{
				this.JjDFBbPjCGldbszKPiEIDBCcNlGg();
			}
		}

		private void CaCRmQikiVLMtZLwkgPIggSkyDUiA(bool P_0)
		{
			if (P_0)
			{
				OnJoystickConnected();
			}
			else
			{
				OnJoystickDisconnected();
			}
		}

		internal Joystick[] CCyTkYTATYWcfKUbohfTFZlqDLBe()
		{
			List<Joystick> list = new List<Joystick>(MCxRxIxoLDGiMtilhezuRcBZtnAK.Count);
			for (int i = 0; i < MCxRxIxoLDGiMtilhezuRcBZtnAK.Count; i++)
			{
				Joystick joystick = MCxRxIxoLDGiMtilhezuRcBZtnAK[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		internal virtual void jVehwmutETkRglGYTdMvCzjrpzjL()
		{
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
			if (pDGjLpGocvHCQrvWwPvMgqgDNfHwA)
			{
				return;
			}
			if (disposing)
			{
				if (pQOAhTtQkxVtliJaNDnmDtlWRApdA is IDisposable)
				{
					try
					{
						(pQOAhTtQkxVtliJaNDnmDtlWRApdA as IDisposable).Dispose();
					}
					catch (Exception msg)
					{
						Logger.LogError(msg);
					}
				}
				if (FLKPfWFSOHjszvocIfErJnPZoRBi is IDisposable)
				{
					try
					{
						(FLKPfWFSOHjszvocIfErJnPZoRBi as IDisposable).Dispose();
					}
					catch (Exception msg2)
					{
						Logger.LogError(msg2);
					}
				}
			}
			pDGjLpGocvHCQrvWwPvMgqgDNfHwA = true;
		}

		public abstract void Update();
	}
}
