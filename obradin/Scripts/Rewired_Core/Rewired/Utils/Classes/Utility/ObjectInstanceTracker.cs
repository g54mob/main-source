using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker MDOELICkCliFJZMtIDaTaPKgdHuH;

			private bool vsurYtRlepcrpAzAENwjqjJEZPT;

			public Wrapper(T instance)
				: this(instance, Default)
			{
			}

			public Wrapper(T instance, ObjectInstanceTracker tracker)
			{
				if (instance == null)
				{
					throw new ArgumentNullException("instance");
				}
				if (tracker == null)
				{
					throw new ArgumentNullException("tracker");
				}
				this.instance = instance;
				MDOELICkCliFJZMtIDaTaPKgdHuH = tracker;
				instanceId = tracker.Register(instance);
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
				if (vsurYtRlepcrpAzAENwjqjJEZPT)
				{
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (MDOELICkCliFJZMtIDaTaPKgdHuH == null)
					{
						num = -1886456538;
						num2 = num;
					}
					else
					{
						num = -1886456537;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1886456539)
						{
						case 0:
							num = -1886456540;
							continue;
						case 1:
							break;
						case 2:
							MDOELICkCliFJZMtIDaTaPKgdHuH.Unregister(instanceId);
							num = -1886456538;
							continue;
						default:
							vsurYtRlepcrpAzAENwjqjJEZPT = true;
							return;
						}
						break;
					}
				}
			}
		}

		private static ObjectInstanceTracker LDwDTzcqSaJaAJzktFPjtpIxftC;

		private readonly Dictionary<uint, object> JZbhNpypmeAwwhiixsUFliEFruTP = new Dictionary<uint, object>();

		private readonly object ApoGIkESPluZZXxnlCUFKEbYmQw = new object();

		private uint PMlTXERnECEKPoKLZlfFpvvYIbu;

		private int pbQDaYJgPflojVjuHQmFyxQcOKp;

		private bool ynRCLoOeYzBpdwIeiDhWlnvtGGrB;

		public static ObjectInstanceTracker Default
		{
			get
			{
				return LDwDTzcqSaJaAJzktFPjtpIxftC ?? (LDwDTzcqSaJaAJzktFPjtpIxftC = new ObjectInstanceTracker());
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
				pbQDaYJgPflojVjuHQmFyxQcOKp++;
				uint num = PMlTXERnECEKPoKLZlfFpvvYIbu++;
				int num2 = 1050063349;
				while (true)
				{
					switch (num2 ^ 0x3E96B1F4)
					{
					case 0:
						goto IL_000e;
					case 2:
						break;
					default:
						JZbhNpypmeAwwhiixsUFliEFruTP.Add(num, instance);
						return num;
					}
					break;
					IL_000e:
					num2 = 1050063350;
				}
			}
		}

		public void Unregister(uint instanceId)
		{
			pbQDaYJgPflojVjuHQmFyxQcOKp--;
			while (true)
			{
				int num = -1072674490;
				while (true)
				{
					switch (num ^ -1072674489)
					{
					case 2:
						break;
					case 1:
					{
						int num2;
						if (pbQDaYJgPflojVjuHQmFyxQcOKp < 0)
						{
							num = -1072674489;
							num2 = num;
						}
						else
						{
							num = -1072674492;
							num2 = num;
						}
						continue;
					}
					case 0:
						pbQDaYJgPflojVjuHQmFyxQcOKp = 0;
						num = -1072674492;
						continue;
					default:
						lock (ApoGIkESPluZZXxnlCUFKEbYmQw)
						{
							JZbhNpypmeAwwhiixsUFliEFruTP.Remove(instanceId);
							return;
						}
					}
					break;
				}
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			bool result = default(bool);
			lock (ApoGIkESPluZZXxnlCUFKEbYmQw)
			{
				object value;
				if (!JZbhNpypmeAwwhiixsUFliEFruTP.TryGetValue(instanceId, out value))
				{
					instance = null;
					goto IL_0024;
				}
				goto IL_0055;
				IL_007b:
				instance = null;
				result = false;
				goto end_IL_000d;
				IL_0024:
				int num = -1402124023;
				goto IL_0029;
				IL_0029:
				switch (num ^ -1402124024)
				{
				case 4:
					break;
				case 1:
					result = false;
					goto end_IL_000d;
				case 0:
					goto IL_0055;
				case 3:
					goto end_IL_000d;
				default:
					goto IL_007b;
				}
				goto IL_0024;
				IL_0055:
				if (value is T)
				{
					instance = (T)value;
					result = true;
					num = -1402124021;
					goto IL_0029;
				}
				goto IL_007b;
				end_IL_000d:;
			}
			return result;
		}

		public void Dispose()
		{
			DJeUzQoMEVOxbEpwDFXbTBWdIKu(true);
			while (true)
			{
				int num = -829704840;
				while (true)
				{
					switch (num ^ -829704838)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0025;
					case 1:
						return;
					}
					break;
					IL_0025:
					GC.SuppressFinalize(this);
					num = -829704837;
				}
			}
		}

		private void DJeUzQoMEVOxbEpwDFXbTBWdIKu(bool P_0)
		{
			if (ynRCLoOeYzBpdwIeiDhWlnvtGGrB)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -1317035235;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1317035239)
				{
				case 0:
					break;
				case 4:
					return;
				case 2:
					goto IL_0036;
				case 3:
					LDwDTzcqSaJaAJzktFPjtpIxftC = null;
					num = -1317035240;
					continue;
				default:
					ynRCLoOeYzBpdwIeiDhWlnvtGGrB = true;
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0036:
			int num2;
			if (this == LDwDTzcqSaJaAJzktFPjtpIxftC)
			{
				num = -1317035238;
				num2 = num;
			}
			else
			{
				num = -1317035240;
				num2 = num;
			}
			goto IL_000d;
		}

		~ObjectInstanceTracker()
		{
			DJeUzQoMEVOxbEpwDFXbTBWdIKu(false);
		}
	}
}
