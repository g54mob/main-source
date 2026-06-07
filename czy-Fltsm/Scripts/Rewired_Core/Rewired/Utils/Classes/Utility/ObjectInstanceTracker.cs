using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker KpZDiNWZSlEquoIiVWbujZxcoPOH;

			private bool GaWIKnXfslVpUcQtwmlSIhopKbqR;

			public Wrapper(T P_0)
				: this(P_0, Default)
			{
			}

			public Wrapper(T P_0, ObjectInstanceTracker P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("instance");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("tracker");
				}
				instance = P_0;
				KpZDiNWZSlEquoIiVWbujZxcoPOH = P_1;
				instanceId = P_1.Register(P_0);
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			~Wrapper()
			{
				Dispose(disposing: false);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!GaWIKnXfslVpUcQtwmlSIhopKbqR)
				{
					if (KpZDiNWZSlEquoIiVWbujZxcoPOH != null)
					{
						KpZDiNWZSlEquoIiVWbujZxcoPOH.Unregister(instanceId);
					}
					GaWIKnXfslVpUcQtwmlSIhopKbqR = true;
				}
			}
		}

		private static ObjectInstanceTracker qvLYksRcppdEsdCdvrYWYfnhUeHL;

		private readonly Dictionary<uint, object> OrKQeDktCYmuwzKUAphDjStmjUEi = new Dictionary<uint, object>();

		private readonly object IzJpFzhanZdsXqoCipAssbFwHThu = new object();

		private uint ryuNbhXDxszkovdbEmhQgSMCuruM;

		private int StjbUsPgjAUyboTCoBgFCRtLoxbv;

		private bool uHTCXcrLDhCRGFBbIyzCgHoSfUTvA;

		public static ObjectInstanceTracker Default => qvLYksRcppdEsdCdvrYWYfnhUeHL ?? (qvLYksRcppdEsdCdvrYWYfnhUeHL = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			StjbUsPgjAUyboTCoBgFCRtLoxbv++;
			uint num = ryuNbhXDxszkovdbEmhQgSMCuruM++;
			OrKQeDktCYmuwzKUAphDjStmjUEi.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			StjbUsPgjAUyboTCoBgFCRtLoxbv--;
			if (StjbUsPgjAUyboTCoBgFCRtLoxbv < 0)
			{
				StjbUsPgjAUyboTCoBgFCRtLoxbv = 0;
			}
			lock (IzJpFzhanZdsXqoCipAssbFwHThu)
			{
				OrKQeDktCYmuwzKUAphDjStmjUEi.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (IzJpFzhanZdsXqoCipAssbFwHThu)
			{
				if (!OrKQeDktCYmuwzKUAphDjStmjUEi.TryGetValue(instanceId, out var value))
				{
					instance = null;
					return false;
				}
				if (value is T)
				{
					instance = (T)value;
					return true;
				}
				instance = null;
				return false;
			}
		}

		public void Dispose()
		{
			dCZbbaSPvslVPnBlTaCbWHARjDgg(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		private void dCZbbaSPvslVPnBlTaCbWHARjDgg(bool P_0)
		{
			if (!uHTCXcrLDhCRGFBbIyzCgHoSfUTvA)
			{
				if (this == qvLYksRcppdEsdCdvrYWYfnhUeHL)
				{
					qvLYksRcppdEsdCdvrYWYfnhUeHL = null;
				}
				uHTCXcrLDhCRGFBbIyzCgHoSfUTvA = true;
			}
		}

		~ObjectInstanceTracker()
		{
			dCZbbaSPvslVPnBlTaCbWHARjDgg(false);
		}
	}
}
