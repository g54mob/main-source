using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum kjlDyxkwVmEpsBfKROVHPBjTIfK
		{
			VPPlpSnFQYSjKakgcaaTxvpETid = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(kjlDyxkwVmEpsBfKROVHPBjTIfK eventType, Delegate listener);

		public abstract void RemoveEventListener(kjlDyxkwVmEpsBfKROVHPBjTIfK eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> RwMbRKuOdanOLkRGMSxgLZQPfw = EqualityComparerNoAlloc<T>.Default;

		private bool hJRNrDQZRVunSwslcVFpjuAEhcL;

		private T FAoORBrTWqKCGNyMiKXRtudTOgk;

		private bool ZfkrYaysGyJEDcOwJpSxzjCUQKy;

		private Func<T> qCNjWQjjyXaFJLnKeFHRLSgIIuze;

		private Action<T> uUlXBBxcvOZIgMswkbNgOjHWaug;

		public override bool changed
		{
			get
			{
				return hJRNrDQZRVunSwslcVFpjuAEhcL;
			}
		}

		public override bool autoTriggerEvent
		{
			get
			{
				return ZfkrYaysGyJEDcOwJpSxzjCUQKy;
			}
			set
			{
				ZfkrYaysGyJEDcOwJpSxzjCUQKy = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return qCNjWQjjyXaFJLnKeFHRLSgIIuze;
			}
			set
			{
				qCNjWQjjyXaFJLnKeFHRLSgIIuze = value;
			}
		}

		public T value
		{
			get
			{
				return FAoORBrTWqKCGNyMiKXRtudTOgk;
			}
		}

		public event Action<T> ChangedEvent
		{
			add
			{
				uUlXBBxcvOZIgMswkbNgOjHWaug = (Action<T>)Delegate.Combine(uUlXBBxcvOZIgMswkbNgOjHWaug, value);
			}
			remove
			{
				uUlXBBxcvOZIgMswkbNgOjHWaug = (Action<T>)Delegate.Remove(uUlXBBxcvOZIgMswkbNgOjHWaug, value);
			}
		}

		public ValueWatcher(T initialValue, bool autoTriggerEvent)
		{
			FAoORBrTWqKCGNyMiKXRtudTOgk = initialValue;
			ZfkrYaysGyJEDcOwJpSxzjCUQKy = autoTriggerEvent;
		}

		public ValueWatcher(T initialValue, Func<T> getValueDelegate, bool autoTriggerEvent)
			: this(initialValue, autoTriggerEvent)
		{
			qCNjWQjjyXaFJLnKeFHRLSgIIuze = getValueDelegate;
		}

		public override bool Update()
		{
			if (qCNjWQjjyXaFJLnKeFHRLSgIIuze == null)
			{
				return false;
			}
			try
			{
				return Set(qCNjWQjjyXaFJLnKeFHRLSgIIuze());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!hJRNrDQZRVunSwslcVFpjuAEhcL)
			{
				return false;
			}
			hJRNrDQZRVunSwslcVFpjuAEhcL = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!hJRNrDQZRVunSwslcVFpjuAEhcL)
			{
				return false;
			}
			if (uUlXBBxcvOZIgMswkbNgOjHWaug == null)
			{
				return true;
			}
			bool result = default(bool);
			try
			{
				Use();
				uUlXBBxcvOZIgMswkbNgOjHWaug(FAoORBrTWqKCGNyMiKXRtudTOgk);
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by ValueChangedEvent handler.\n" + ex);
				while (true)
				{
					IL_0041:
					int num = 2090577274;
					while (true)
					{
						switch (num ^ 0x7C9BAD78)
						{
						case 0:
							break;
						default:
							goto end_IL_0046;
						case 2:
							goto IL_005f;
						case 1:
							goto end_IL_0046;
						}
						goto IL_0041;
						IL_005f:
						result = false;
						num = 2090577273;
						continue;
						end_IL_0046:
						break;
					}
					break;
				}
			}
			return result;
		}

		public bool Set(T value)
		{
			if (RwMbRKuOdanOLkRGMSxgLZQPfw.Equals(FAoORBrTWqKCGNyMiKXRtudTOgk, value))
			{
				return false;
			}
			FAoORBrTWqKCGNyMiKXRtudTOgk = value;
			while (true)
			{
				int num = -1679928725;
				while (true)
				{
					switch (num ^ -1679928727)
					{
					case 0:
						break;
					case 2:
						hJRNrDQZRVunSwslcVFpjuAEhcL = true;
						if (ZfkrYaysGyJEDcOwJpSxzjCUQKy)
						{
							goto IL_0049;
						}
						goto default;
					default:
						return true;
					}
					break;
					IL_0049:
					TriggerEvent();
					num = -1679928728;
				}
			}
		}

		public override void AddEventListener(kjlDyxkwVmEpsBfKROVHPBjTIfK eventType, Delegate listener)
		{
			if (eventType == kjlDyxkwVmEpsBfKROVHPBjTIfK.VPPlpSnFQYSjKakgcaaTxvpETid)
			{
				if (!(listener is Action<T>))
				{
					throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
				}
				while (true)
				{
					ChangedEvent += (Action<T>)listener;
					int num = 817758689;
					while (true)
					{
						switch (num ^ 0x30BE01E0)
						{
						case 0:
							num = 817758691;
							continue;
						case 3:
							break;
						case 1:
							return;
						default:
							goto end_IL_0054;
						}
						break;
					}
					continue;
					end_IL_0054:
					break;
				}
			}
			throw new NotImplementedException();
		}

		public override void RemoveEventListener(kjlDyxkwVmEpsBfKROVHPBjTIfK eventType, Delegate listener)
		{
			if (eventType == kjlDyxkwVmEpsBfKROVHPBjTIfK.VPPlpSnFQYSjKakgcaaTxvpETid)
			{
				if (!(listener is Action<T>))
				{
					throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
				}
				ChangedEvent -= (Action<T>)listener;
				return;
			}
			throw new NotImplementedException();
		}
	}
}
