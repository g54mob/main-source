using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public sealed class CustomController_Editor
	{
		[Serializable]
		public abstract class Element
		{
			public int elementIdentifierId;

			public string name;

			public Element()
			{
			}

			public Element(string P_0, int P_1)
			{
			}

			public abstract Element Clone();
		}

		[Serializable]
		public sealed class Button : Element
		{
			public Button()
			{
			}

			public Button(string P_0)
			{
			}

			public Button(string P_0, int P_1)
			{
			}

			public Button(Button P_0)
			{
			}

			public override Element Clone()
			{
				return null;
			}
		}

		[Serializable]
		public sealed class Axis : Element
		{
			public AxisRange range;

			public bool invert;

			public float deadZone;

			public float zero;

			public float min;

			public float max;

			public bool doNotCalibrateRange;

			public AxisSensitivityType sensitivityType;

			public float sensitivity;

			public AnimationCurve sensitivityCurve;

			public HardwareAxisInfo axisInfo;

			public Axis()
			{
			}

			public Axis(string P_0)
			{
			}

			[Obsolete]
			public Axis(string P_0, string P_1, string P_2, int P_3, AxisRange P_4, bool P_5, float P_6, float P_7, float P_8, float P_9, bool P_10, HardwareAxisInfo P_11)
			{
			}

			public Axis(Axis P_0)
			{
			}

			public override Element Clone()
			{
				return null;
			}
		}

		private sealed class nRwMaaeNisjHsYCsoWMrmyibPNkd : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerElementIdentifier USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public CustomController_Editor GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
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
			public nRwMaaeNisjHsYCsoWMrmyibPNkd(int P_0)
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
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[SerializeField]
		[CustomObfuscation]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private string _descriptiveName;

		[CustomObfuscation]
		[SerializeField]
		private int _id;

		[CustomObfuscation]
		[SerializeField]
		private string _typeGuidString;

		[SerializeField]
		[CustomObfuscation]
		private List<ControllerElementIdentifier> _elementIdentifiers;

		[CustomObfuscation]
		[SerializeField]
		private List<Axis> _axes;

		[SerializeField]
		[CustomObfuscation]
		private List<Button> _buttons;

		[SerializeField]
		[CustomObfuscation]
		private int _elementIdentifierIdCounter;

		public string name
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string descriptiveName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public int id
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public Guid typeGuid
		{
			get
			{
				return default(Guid);
			}
			internal set
			{
			}
		}

		internal string typeGuidString
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<ControllerElementIdentifier> elementIdentifiers
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public List<Axis> axes => null;

		public List<Button> buttons => null;

		public int buttonCount => 0;

		public int axisCount => 0;

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers => null;

		public CustomController_Editor()
		{
		}

		public CustomController_Editor(CustomController_Editor P_0)
		{
		}

		public CustomController_Editor Clone()
		{
			return null;
		}

		public string[] GetElementIdentifierNames()
		{
			return null;
		}

		public int[] GetElementIdentifierIds()
		{
			return null;
		}

		public string[] GetElementIdentifierNamesTypeSorted()
		{
			return null;
		}

		public int[] GetElementIdentifierIdsTypeSorted()
		{
			return null;
		}

		public ControllerElementIdentifier[] GetElementIdentifiersTypeSorted()
		{
			return null;
		}

		public bool ContainsElementIdentifier(int id)
		{
			return false;
		}

		public int IndexOfElementIdentifier(int id)
		{
			return 0;
		}

		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			return null;
		}

		internal ControllerElementType GetEffectiveElementIdentifierType(int elementIdentifierId)
		{
			return default(ControllerElementType);
		}

		internal bool GetEffectiveAxisRange(int elementIdentifierId, out AxisRange axisRange)
		{
			axisRange = default(AxisRange);
			return false;
		}

		public string[] GetButtonNames()
		{
			return null;
		}

		public int[] GetButtonElementIdentifierIds()
		{
			return null;
		}

		public string[] GetAxisNames()
		{
			return null;
		}

		public int[] GetAxisElementIdentifierIds()
		{
			return null;
		}

		public string[] GetElementNames<T>() where T : Element
		{
			return null;
		}

		public string[] GetElementNames(ControllerElementType type)
		{
			return null;
		}

		public int[] GetElementElementIdentifierIds(ControllerElementType type)
		{
			return null;
		}

		public T GetElement<T>(int index) where T : Element
		{
			return null;
		}

		public void AddElement(ControllerElementType type)
		{
		}

		public void AddAxis()
		{
		}

		public void AddButton()
		{
		}

		public void InsertElement(ControllerElementType type, int index)
		{
		}

		public void InsertAxis(int index)
		{
		}

		public void InsertButton(int index)
		{
		}

		public void DeleteElement(ControllerElementType type, int index)
		{
		}

		public void DeleteElement<T>(int index) where T : Element
		{
		}

		public bool ReorderElement(ControllerElementType type, int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateElement(ControllerElementType type, int index)
		{
		}

		private void wduGcjkXMqOWvkDaZqCKnxqRuotJA<_0001>(int P_0, List<_0001> P_1) where _0001 : Element
		{
		}

		private ControllerElementIdentifier bbKjNomsgBEjBKZTyykfDYSAaESeA(int P_0, string P_1)
		{
			return null;
		}

		private Element vntcmHaocmLolFiQkyapvHkgMMnRA(ControllerElementType P_0)
		{
			return null;
		}

		private ControllerElementIdentifier gKjQqgSjtMJoJZAARdhqphEjNFxE(ControllerElementType P_0, string P_1, string P_2, string P_3)
		{
			return null;
		}

		internal HardwareControllerMap_Game CreateGameHardwareMap()
		{
			return null;
		}
	}
}
