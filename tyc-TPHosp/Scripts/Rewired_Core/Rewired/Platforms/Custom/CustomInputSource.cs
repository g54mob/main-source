using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

			protected Controller(string deviceName)
			{
				_deviceName = deviceName;
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
			private long? BKdaOxqbTAGWCgnBTRWCklwSDaaL;

			private int GilOEfRsEhDCPCODtRARcQnrnPTg;

			private readonly Axis[] XiWNbwUWYHoLPxZyOZhRZbiCuVm;

			private readonly Button[] fMHXJPWJIudshUOjLfHOLECkvEl;

			private readonly ReadOnlyCollection<Axis> JcrLJYGDkpIAEDBLHjHTMpUXuMf;

			private readonly ReadOnlyCollection<Button> SbTXOHYVHQxqjplfKPBFBpODmGN;

			private bool doEYUoXAmEtSKKXozywgwojoYnT;

			private Rewired.Controller.Extension DLgfvsKWtDDcFdLxaaSpMucpiDtb;

			public long? systemId
			{
				get
				{
					return BKdaOxqbTAGWCgnBTRWCklwSDaaL;
				}
				protected set
				{
					BKdaOxqbTAGWCgnBTRWCklwSDaaL = value;
				}
			}

			public int unityId
			{
				get
				{
					return GilOEfRsEhDCPCODtRARcQnrnPTg;
				}
				protected set
				{
					GilOEfRsEhDCPCODtRARcQnrnPTg = value;
				}
			}

			public IList<Axis> Axes => JcrLJYGDkpIAEDBLHjHTMpUXuMf;

			public IList<Button> Buttons => SbTXOHYVHQxqjplfKPBFBpODmGN;

			public bool supportsVibration
			{
				get
				{
					return doEYUoXAmEtSKKXozywgwojoYnT;
				}
				set
				{
					doEYUoXAmEtSKKXozywgwojoYnT = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return DLgfvsKWtDDcFdLxaaSpMucpiDtb;
				}
				set
				{
					DLgfvsKWtDDcFdLxaaSpMucpiDtb = value;
				}
			}

			public int buttonCount => fMHXJPWJIudshUOjLfHOLECkvEl.Length;

			public int axisCount => XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length;

			public Joystick(string deviceName, long? systemId, int unityId, int axisCount, int buttonCount)
				: base(deviceName)
			{
				if (axisCount < 0)
				{
					axisCount = 0;
				}
				if (buttonCount < 0)
				{
					buttonCount = 0;
				}
				BKdaOxqbTAGWCgnBTRWCklwSDaaL = systemId;
				GilOEfRsEhDCPCODtRARcQnrnPTg = unityId;
				XiWNbwUWYHoLPxZyOZhRZbiCuVm = new Axis[axisCount];
				fMHXJPWJIudshUOjLfHOLECkvEl = new Button[buttonCount];
				for (int i = 0; i < axisCount; i++)
				{
					XiWNbwUWYHoLPxZyOZhRZbiCuVm[i] = new Axis();
				}
				for (int j = 0; j < buttonCount; j++)
				{
					fMHXJPWJIudshUOjLfHOLECkvEl[j] = new Button();
				}
				JcrLJYGDkpIAEDBLHjHTMpUXuMf = new ReadOnlyCollection<Axis>(XiWNbwUWYHoLPxZyOZhRZbiCuVm);
				SbTXOHYVHQxqjplfKPBFBpODmGN = new ReadOnlyCollection<Button>(fMHXJPWJIudshUOjLfHOLECkvEl);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length)
				{
					return 0f;
				}
				return XiWNbwUWYHoLPxZyOZhRZbiCuVm[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= fMHXJPWJIudshUOjLfHOLECkvEl.Length)
				{
					return false;
				}
				return fMHXJPWJIudshUOjLfHOLECkvEl[index].value;
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

		private readonly InputSource ZDlUxkUjsUcGKeLVqrQXLelAILc;

		private readonly List<Joystick> EHRkVwzylbTeeAuCadrFIaoIbePK;

		private readonly ReadOnlyCollection<Joystick> lRqUTyFhibOcmbBFTQYEYjLZKZq;

		private bool lZXZqlDZOGjrAIOZUQQisgtoFSq = true;

		private Action UEhUjvJdVBkFMLWpHPSTpXTwkwu;

		private Action jqcIfTQrTIoasWtkWMlFEMqduUU;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public bool useApproximateMatching
		{
			get
			{
				return lZXZqlDZOGjrAIOZUQQisgtoFSq;
			}
			protected set
			{
				lZXZqlDZOGjrAIOZUQQisgtoFSq = value;
			}
		}

		internal InputSource inputSource => ZDlUxkUjsUcGKeLVqrQXLelAILc;

		public abstract bool isReady { get; }

		private event Action _JoystickConnectedEvent
		{
			add
			{
				Action action = UEhUjvJdVBkFMLWpHPSTpXTwkwu;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref UEhUjvJdVBkFMLWpHPSTpXTwkwu, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = UEhUjvJdVBkFMLWpHPSTpXTwkwu;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref UEhUjvJdVBkFMLWpHPSTpXTwkwu, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action _JoystickDisconnectedEvent
		{
			add
			{
				Action action = jqcIfTQrTIoasWtkWMlFEMqduUU;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref jqcIfTQrTIoasWtkWMlFEMqduUU, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = jqcIfTQrTIoasWtkWMlFEMqduUU;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref jqcIfTQrTIoasWtkWMlFEMqduUU, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action JoystickConnectedEvent
		{
			add
			{
				_JoystickConnectedEvent += value;
			}
			remove
			{
				_JoystickConnectedEvent -= value;
			}
		}

		internal event Action JoystickDisconnectedEvent
		{
			add
			{
				_JoystickDisconnectedEvent += value;
			}
			remove
			{
				_JoystickDisconnectedEvent -= value;
			}
		}

		public CustomInputSource(int inputSource)
		{
			if (!Enum.IsDefined(typeof(InputSource), inputSource))
			{
				Logger.LogError("Unknown InputSource (" + inputSource + ")!");
			}
			ZDlUxkUjsUcGKeLVqrQXLelAILc = (InputSource)inputSource;
			EHRkVwzylbTeeAuCadrFIaoIbePK = new List<Joystick>();
			lRqUTyFhibOcmbBFTQYEYjLZKZq = new ReadOnlyCollection<Joystick>(EHRkVwzylbTeeAuCadrFIaoIbePK);
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (EHRkVwzylbTeeAuCadrFIaoIbePK.Contains(joystick))
				{
					Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				}
				else
				{
					EHRkVwzylbTeeAuCadrFIaoIbePK.Add(joystick);
				}
			}
		}

		public void RemoveJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (!EHRkVwzylbTeeAuCadrFIaoIbePK.Contains(joystick))
				{
					Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				}
				else
				{
					EHRkVwzylbTeeAuCadrFIaoIbePK.Remove(joystick);
				}
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return lRqUTyFhibOcmbBFTQYEYjLZKZq;
		}

		protected virtual void OnJoystickConnected()
		{
			if (UEhUjvJdVBkFMLWpHPSTpXTwkwu != null)
			{
				UEhUjvJdVBkFMLWpHPSTpXTwkwu();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (jqcIfTQrTIoasWtkWMlFEMqduUU != null)
			{
				jqcIfTQrTIoasWtkWMlFEMqduUU();
			}
		}

		internal Joystick[] kqZQuzXBPXjreKeMaNsdehOhbEo()
		{
			List<Joystick> list = new List<Joystick>(EHRkVwzylbTeeAuCadrFIaoIbePK.Count);
			for (int i = 0; i < EHRkVwzylbTeeAuCadrFIaoIbePK.Count; i++)
			{
				Joystick joystick = EHRkVwzylbTeeAuCadrFIaoIbePK[i];
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

		~CustomInputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}

		public abstract void Update();
	}
}
