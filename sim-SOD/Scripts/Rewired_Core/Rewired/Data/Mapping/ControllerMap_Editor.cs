using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ControllerMap_Editor
	{
		private sealed class BNOUhkjDjClSLUdmYHvivwzFGii : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			private int heukQwubtgAAwETRDLwZfpUeIur;

			public ControllerMap_Editor OLVemnFdjzUkQSlFFFIOsrknazt;

			public int hkjZwEtRcbNEZzlBIpvzpzhYPxY;

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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public BNOUhkjDjClSLUdmYHvivwzFGii(int _003C_003E1__state)
			{
			}
		}

		public int id;

		public int categoryId;

		public int layoutId;

		public string name;

		public string hardwareGuidString;

		public int customControllerUid;

		public List<ActionElementMap> actionElementMaps;

		public IEnumerable<ActionElementMap> ActionElementMaps => null;

		public Guid hardwareGuid => default(Guid);

		public ControllerMap_Editor Clone()
		{
			return null;
		}

		public ActionElementMap GetActionElementMap(int index)
		{
			return null;
		}

		internal JoystickMap zzVoQBlaQuQOMJFxPFuTEnlasBX(Func<int, bool> P_0, HardwareControllerMapIdentifier P_1, HardwareJoystickMap P_2, bool P_3)
		{
			return null;
		}

		internal KeyboardMap ycrjOSefTaqKhbAwahjvZkzmWJIL(Func<int, bool> P_0)
		{
			return null;
		}

		internal MouseMap dvtcuSesDcYsilabkezgOrbzFjAN(Func<int, bool> P_0)
		{
			return null;
		}

		internal CustomControllerMap HzauPQFncqNfzHIhvSfAgizqQnH(Func<int, bool> P_0, CustomController_Editor P_1)
		{
			return null;
		}

		internal ControllerTemplateMap mzTaAVKARmtxUDpOaOygFkdfkpbO()
		{
			return null;
		}

		private void rzDlrdEPoVsMefWuKohVcpXmahM(Func<int, bool> P_0, ControllerMap P_1, HardwareControllerMapIdentifier P_2, HardwareJoystickMap P_3, bool P_4)
		{
		}

		private void uviVgCbOavrFnOpaTDFVGknGDRhn(Func<int, bool> P_0, InputSource P_1, CustomControllerMap P_2, CustomController_Editor P_3)
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

		private ActionElementMap IPwHrZIPlfLmQxocKGAAsAraHmz()
		{
			return null;
		}
	}
}
