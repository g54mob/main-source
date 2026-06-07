using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ControllerMap_Editor
	{
		private sealed class ZDWyXQyAZfjvpQYHPGFLNRxqOSI : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int bBDkrwTxbtGlIxDQIIWTELPBobf;

			private ActionElementMap iDYxgfqcdbEEVNPDcClqISJNzEeP;

			private int gAJMxkUAFtsGeemSFlllsibzZBTQ;

			public ControllerMap_Editor iJVLlFpqbjDkPZihUIjlCUOAxAGC;

			private int EJknEVwCRtWRVBllziraCyIcjuVu;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public ZDWyXQyAZfjvpQYHPGFLNRxqOSI(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public int id;

		public int categoryId;

		public int layoutId;

		public string name;

		public string hardwareGuidString;

		public int customControllerUid;

		public List<ActionElementMap> actionElementMaps;

		public IEnumerable<ActionElementMap> ActionElementMaps
		{
			[IteratorStateMachine(typeof(ZDWyXQyAZfjvpQYHPGFLNRxqOSI))]
			get
			{
				return null;
			}
		}

		public Guid hardwareGuid => default(Guid);

		public ControllerMap_Editor Clone()
		{
			return null;
		}

		public ActionElementMap GetActionElementMap(int index)
		{
			return null;
		}

		internal JoystickMap OUQOQmWTNFpZYmAqkEuLBYbCeKaHb(Func<int, bool> P_0, HardwareControllerMapIdentifier P_1, HardwareJoystickMap P_2, bool P_3)
		{
			return null;
		}

		internal KeyboardMap VNdAJZQFaOBwIzaVgCykarFQOyeNA(Func<int, bool> P_0)
		{
			return null;
		}

		internal MouseMap NzSZHEaNGCqCZHVKLMvaGJSSUODV(Func<int, bool> P_0)
		{
			return null;
		}

		internal CustomControllerMap FFPBkYitgkJjUazmdLqpaxYXUpfEb(Func<int, bool> P_0, CustomController_Editor P_1)
		{
			return null;
		}

		internal ControllerTemplateMap ILvEHDHzeigcEQJVlKreqlqcLUNHA()
		{
			return null;
		}

		private void sHAXDsVQRVTehjMlqGrSaLgJkoQTA(Func<int, bool> P_0, ControllerMap P_1, HardwareControllerMapIdentifier P_2, HardwareJoystickMap P_3, bool P_4)
		{
		}

		private void JKVdEHhlkwxfIisnXsQGSVwhhwwi(Func<int, bool> P_0, InputSource P_1, CustomControllerMap P_2, CustomController_Editor P_3)
		{
		}

		public void CreateElementsFromHardwareMap(IHardwareControllerMap hardwareJoystickMap)
		{
		}

		public void CreateElementsFromHardwareMap(CustomController_Editor customController)
		{
		}

		public void AddActionElementMap()
		{
		}

		public void InsertActionElementMap(int index)
		{
		}

		public void DeleteActionElementMap(int index)
		{
		}

		public bool ReorderActionElementMap(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateActionElementMap(int index)
		{
		}

		private ActionElementMap vAKhpOWRIHAsHAuKNZQikObtqitoA()
		{
			return null;
		}
	}
}
