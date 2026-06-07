using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum BobGtjCezglJWpoVzEoNqVuPLQN
		{
			wPDGmXLmCEWUrCodMbeBQAlQiheJ = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(BobGtjCezglJWpoVzEoNqVuPLQN eventType, Delegate listener);

		public abstract void RemoveEventListener(BobGtjCezglJWpoVzEoNqVuPLQN eventType, Delegate listener);
	}
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> yusqSEeGsxKphlQjuUmjJBaMoIh = EqualityComparerNoAlloc<T>.Default;

		private bool URTGuYoaDBJxnEskQPmbEItKsdG;

		private T oEeTqWLfGqIvjjZLGKQRMTdJbXv;

		private bool gbqmBhMdSotlkWexbLWbMoEUoPt;

		private Func<T> FaDtDTZzePovypFTKFNVqrcAkzk;

		private Action<T> XKfOdKLjXOchRyzSYnTsvFPGrap;

		public override bool changed
		{
			get
			{
				return URTGuYoaDBJxnEskQPmbEItKsdG;
			}
		}

		public override bool autoTriggerEvent
		{
			get
			{
				return gbqmBhMdSotlkWexbLWbMoEUoPt;
			}
			set
			{
				gbqmBhMdSotlkWexbLWbMoEUoPt = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return FaDtDTZzePovypFTKFNVqrcAkzk;
			}
			set
			{
				FaDtDTZzePovypFTKFNVqrcAkzk = value;
			}
		}

		public T value
		{
			get
			{
				return oEeTqWLfGqIvjjZLGKQRMTdJbXv;
			}
		}

		public event Action<T> ChangedEvent
		{
			add
			{
				XKfOdKLjXOchRyzSYnTsvFPGrap = (Action<T>)Delegate.Combine(XKfOdKLjXOchRyzSYnTsvFPGrap, value);
			}
			remove
			{
				XKfOdKLjXOchRyzSYnTsvFPGrap = (Action<T>)Delegate.Remove(XKfOdKLjXOchRyzSYnTsvFPGrap, value);
			}
		}

		public ValueWatcher(T initialValue, bool autoTriggerEvent)
		{
			oEeTqWLfGqIvjjZLGKQRMTdJbXv = initialValue;
			gbqmBhMdSotlkWexbLWbMoEUoPt = autoTriggerEvent;
		}

		public ValueWatcher(T initialValue, Func<T> getValueDelegate, bool autoTriggerEvent)
			: this(initialValue, autoTriggerEvent)
		{
			while (true)
			{
				int num = -1136477509;
				while (true)
				{
					switch (num ^ -1136477511)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0026;
					case 1:
						return;
					}
					break;
					IL_0026:
					FaDtDTZzePovypFTKFNVqrcAkzk = getValueDelegate;
					num = -1136477512;
				}
			}
		}

		public override bool Update()
		{
			if (FaDtDTZzePovypFTKFNVqrcAkzk == null)
			{
				return false;
			}
			bool result = default(bool);
			try
			{
				result = Set(FaDtDTZzePovypFTKFNVqrcAkzk());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				while (true)
				{
					IL_002f:
					int num = 1457126710;
					while (true)
					{
						switch (num ^ 0x56D9FD34)
						{
						case 0:
							break;
						default:
							goto end_IL_0034;
						case 2:
							goto IL_004d;
						case 1:
							goto end_IL_0034;
						}
						goto IL_002f;
						IL_004d:
						result = false;
						num = 1457126709;
						continue;
						end_IL_0034:
						break;
					}
					break;
				}
			}
			return result;
		}

		public override bool Use()
		{
			if (!URTGuYoaDBJxnEskQPmbEItKsdG)
			{
				return false;
			}
			URTGuYoaDBJxnEskQPmbEItKsdG = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!URTGuYoaDBJxnEskQPmbEItKsdG)
			{
				return false;
			}
			if (XKfOdKLjXOchRyzSYnTsvFPGrap == null)
			{
				return true;
			}
			try
			{
				Use();
				while (true)
				{
					int num = 1610703372;
					while (true)
					{
						switch (num ^ 0x6001620D)
						{
						case 2:
							break;
						case 1:
							goto IL_0039;
						default:
							return true;
						}
						break;
						IL_0039:
						XKfOdKLjXOchRyzSYnTsvFPGrap(oEeTqWLfGqIvjjZLGKQRMTdJbXv);
						num = 1610703373;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by ValueChangedEvent handler.\n" + ex);
				return false;
			}
		}

		public bool Set(T value)
		{
			if (yusqSEeGsxKphlQjuUmjJBaMoIh.Equals(oEeTqWLfGqIvjjZLGKQRMTdJbXv, value))
			{
				return false;
			}
			oEeTqWLfGqIvjjZLGKQRMTdJbXv = value;
			URTGuYoaDBJxnEskQPmbEItKsdG = true;
			if (gbqmBhMdSotlkWexbLWbMoEUoPt)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(BobGtjCezglJWpoVzEoNqVuPLQN eventType, Delegate listener)
		{
			if (eventType == BobGtjCezglJWpoVzEoNqVuPLQN.wPDGmXLmCEWUrCodMbeBQAlQiheJ)
			{
				while (true)
				{
					int num = -1973098253;
					while (true)
					{
						switch (num ^ -1973098254)
						{
						case 0:
							break;
						case 4:
							ChangedEvent += (Action<T>)listener;
							return;
						case 2:
							throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
						case 1:
							goto IL_006b;
						default:
							goto end_IL_0006;
						}
						break;
						IL_006b:
						int num2;
						if (listener is Action<T>)
						{
							num = -1973098250;
							num2 = num;
						}
						else
						{
							num = -1973098256;
							num2 = num;
						}
					}
					continue;
					end_IL_0006:
					break;
				}
			}
			throw new NotImplementedException();
		}

		public override void RemoveEventListener(BobGtjCezglJWpoVzEoNqVuPLQN eventType, Delegate listener)
		{
			while (true)
			{
				switch (0x3AC2E41 ^ 0x3AC2E43)
				{
				case 0:
					continue;
				case 2:
					if (eventType != BobGtjCezglJWpoVzEoNqVuPLQN.wPDGmXLmCEWUrCodMbeBQAlQiheJ)
					{
						break;
					}
					if (!(listener is Action<T>))
					{
						throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
					}
					goto case 3;
				case 3:
					ChangedEvent -= (Action<T>)listener;
					return;
				}
				break;
			}
			throw new NotImplementedException();
		}
	}
}
