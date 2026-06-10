using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomInputSource : IDisposable
	{
		public abstract class Controller
		{
			protected bool _isConnected;

			protected string _deviceName;

			protected string _customName;

			public string customName => null;

			public bool isConnected
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public string deviceName => null;

			protected Controller(string deviceName)
			{
			}

			public void Disconnect()
			{
			}

			public void Connect()
			{
			}

			public abstract void Update();
		}

		public abstract class Joystick : Controller
		{
			private long? vfhDSyYRRPSuFBJTwCxAcNujvXTt;

			private int sEzKVyrEWoiLWeuTErqDupvWixa;

			private readonly Axis[] jfSzAhoLMSSmYVeJnsaVjFknPkD;

			private readonly Button[] VkPFJCiiJjjRwtsEoPQYtrARvQCi;

			private readonly ReadOnlyCollection<Axis> dufFFBhiNcLqZjlZkPMRswbsZFEl;

			private readonly ReadOnlyCollection<Button> muXbNRoSZHEDdhNbjyoDApdgORes;

			private bool VzYtArxDKBQJJkpZOaFkCQeHajMD;

			private Rewired.Controller.Extension nLirTpmApUFQKRfjXAdrcqyOjsEQ;

			public long? systemId
			{
				get
				{
					return null;
				}
				protected set
				{
				}
			}

			public int unityId
			{
				get
				{
					return 0;
				}
				protected set
				{
				}
			}

			public IList<Axis> Axes => null;

			public IList<Button> Buttons => null;

			public bool supportsVibration
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public int buttonCount => 0;

			public int axisCount => 0;

			public Joystick(string deviceName, long? systemId, int unityId, int axisCount, int buttonCount)
				: base(null)
			{
			}

			public virtual float GetAxisValue(int index)
			{
				return 0f;
			}

			public virtual bool GetButtonValue(int index)
			{
				return false;
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

		private readonly InputSource nsrFMpeNaTdaRBKZHvEZepzjJoJc;

		private readonly List<Joystick> wSZBJpFPxydMxgXQLAERGcgndVoY;

		private readonly ReadOnlyCollection<Joystick> DisJRhtybgAqvLBpoxGEiJPssgN;

		private bool TwVSBstrBVVDFsBYtvdwKocXksR;

		private Action yhvtEkdjBWcSBanriTeNiJBReFTb;

		private Action NZolICqPBRbEfkmmrNpNzqgWCDro;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public bool useApproximateMatching
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		internal InputSource inputSource => default(InputSource);

		public abstract bool isReady { get; }

		private event Action _JoystickConnectedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event Action _JoystickDisconnectedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		internal event Action JoystickConnectedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		internal event Action JoystickDisconnectedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public CustomInputSource(int inputSource)
		{
		}

		public void AddJoystick(Joystick joystick)
		{
		}

		public void RemoveJoystick(Joystick joystick)
		{
		}

		public IList<Joystick> GetJoysticks()
		{
			return null;
		}

		protected virtual void OnJoystickConnected()
		{
		}

		protected virtual void OnJoystickDisconnected()
		{
		}

		internal Joystick[] KZNmKmvWZAFThszAXeVzScIISvF()
		{
			return null;
		}

		public virtual void Dispose()
		{
		}

		~CustomInputSource()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public abstract void Update();
	}
}
