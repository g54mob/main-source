using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker xFUOIHwnIrDycpKoqheDZHIcFCdB;

			private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

			public Wrapper(T instance)
				: this(instance, Default)
			{
			}

			public Wrapper(T instance, ObjectInstanceTracker tracker)
			{
				while (true)
				{
					int num = 2128657638;
					while (true)
					{
						switch (num ^ 0x7EE0BCE7)
						{
						case 2:
							break;
						case 1:
						{
							int num2;
							if (instance != null)
							{
								num = 2128657639;
								num2 = num;
							}
							else
							{
								num = 2128657635;
								num2 = num;
							}
							continue;
						}
						case 4:
							throw new ArgumentNullException("instance");
						case 0:
							if (tracker == null)
							{
								throw new ArgumentNullException("tracker");
							}
							goto default;
						default:
							this.instance = instance;
							xFUOIHwnIrDycpKoqheDZHIcFCdB = tracker;
							instanceId = tracker.Register(instance);
							return;
						}
						break;
					}
				}
			}

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			~Wrapper()
			{
				Dispose(false);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (QQqHByfwytAJSuMZiCPjJlZYHKG)
				{
					return;
				}
				while (true)
				{
					int num;
					if (xFUOIHwnIrDycpKoqheDZHIcFCdB != null)
					{
						xFUOIHwnIrDycpKoqheDZHIcFCdB.Unregister(instanceId);
						num = 939967896;
						goto IL_000e;
					}
					goto IL_004d;
					IL_000e:
					while (true)
					{
						switch (num ^ 0x3806C599)
						{
						case 0:
							num = 939967899;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_004d;
						case 3:
							return;
						}
						break;
					}
					continue;
					IL_004d:
					QQqHByfwytAJSuMZiCPjJlZYHKG = true;
					num = 939967898;
					goto IL_000e;
				}
			}
		}

		private static ObjectInstanceTracker gePIlGMmtUuQJnaTMLFTWnhtmcu;

		private readonly Dictionary<uint, object> qmzQGqEmyobJBKWtLOYDnRCFTxMP = new Dictionary<uint, object>();

		private readonly object toiLPpwyJtvaolVgPcCZvovCMnj = new object();

		private uint oabDAVbtEUnlwgQOdlvTeAzgWqjQ;

		private int OZMhGVpOZfPIYdcvncDNFeKocLk;

		private bool DoLDnfyVUvaiASgvGlQCEEjxXPg;

		public static ObjectInstanceTracker Default
		{
			get
			{
				return gePIlGMmtUuQJnaTMLFTWnhtmcu ?? (gePIlGMmtUuQJnaTMLFTWnhtmcu = new ObjectInstanceTracker());
			}
		}

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			while (true)
			{
				OZMhGVpOZfPIYdcvncDNFeKocLk++;
				uint num = oabDAVbtEUnlwgQOdlvTeAzgWqjQ++;
				qmzQGqEmyobJBKWtLOYDnRCFTxMP.Add(num, instance);
				int num2 = 1657832187;
				while (true)
				{
					switch (num2 ^ 0x62D082F9)
					{
					case 0:
						goto IL_000e;
					case 1:
						break;
					default:
						return num;
					}
					break;
					IL_000e:
					num2 = 1657832184;
				}
			}
		}

		public void Unregister(uint instanceId)
		{
			OZMhGVpOZfPIYdcvncDNFeKocLk--;
			if (OZMhGVpOZfPIYdcvncDNFeKocLk < 0)
			{
				while (true)
				{
					int num = -1444286977;
					while (true)
					{
						switch (num ^ -1444286978)
						{
						case 2:
							break;
						case 1:
							OZMhGVpOZfPIYdcvncDNFeKocLk = 0;
							num = -1444286978;
							continue;
						default:
							goto end_IL_0017;
						}
						break;
					}
					continue;
					end_IL_0017:
					break;
				}
			}
			lock (toiLPpwyJtvaolVgPcCZvovCMnj)
			{
				qmzQGqEmyobJBKWtLOYDnRCFTxMP.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			bool result = default(bool);
			lock (toiLPpwyJtvaolVgPcCZvovCMnj)
			{
				object value;
				if (!qmzQGqEmyobJBKWtLOYDnRCFTxMP.TryGetValue(instanceId, out value))
				{
					instance = null;
					goto IL_0024;
				}
				goto IL_0082;
				IL_0082:
				int num;
				int num2;
				if (value is T)
				{
					num = -2000305501;
					num2 = num;
				}
				else
				{
					num = -2000305497;
					num2 = num;
				}
				goto IL_0029;
				IL_0024:
				num = -2000305498;
				goto IL_0029;
				IL_0029:
				while (true)
				{
					switch (num ^ -2000305499)
					{
					case 5:
						break;
					case 3:
						result = false;
						goto end_IL_000d;
					case 0:
						result = true;
						num = -2000305503;
						continue;
					case 6:
						instance = (T)value;
						num = -2000305499;
						continue;
					case 4:
						goto end_IL_000d;
					case 1:
						goto IL_0082;
					default:
						instance = null;
						result = false;
						goto end_IL_000d;
					}
					break;
				}
				goto IL_0024;
				end_IL_000d:;
			}
			return result;
		}

		public void Dispose()
		{
			yByeqDDEKPzAKiUpxfZrBkMpiHln(true);
			GC.SuppressFinalize(this);
		}

		private void yByeqDDEKPzAKiUpxfZrBkMpiHln(bool P_0)
		{
			if (DoLDnfyVUvaiASgvGlQCEEjxXPg)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 2060389412;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x7ACF0C27)
			{
			case 2:
				break;
			case 3:
				return;
			case 0:
				goto IL_0032;
			default:
				goto IL_0049;
			}
			goto IL_0008;
			IL_0032:
			if (this == gePIlGMmtUuQJnaTMLFTWnhtmcu)
			{
				gePIlGMmtUuQJnaTMLFTWnhtmcu = null;
				num = 2060389414;
				goto IL_000d;
			}
			goto IL_0049;
			IL_0049:
			DoLDnfyVUvaiASgvGlQCEEjxXPg = true;
		}

		~ObjectInstanceTracker()
		{
			yByeqDDEKPzAKiUpxfZrBkMpiHln(false);
		}
	}
}
