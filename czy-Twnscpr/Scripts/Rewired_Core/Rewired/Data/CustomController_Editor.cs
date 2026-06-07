using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
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

			public Element(string name, int elementIdentifierId)
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

			public Button(string name)
			{
			}

			public Button(string name, int elementIdentifierId)
			{
			}

			public Button(Button source)
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

			public Axis(string name)
			{
			}

			[Obsolete]
			public Axis(string name, string positiveName, string negativeName, int elementIdentifierId, AxisRange range, bool invert, float deadZone, float zero, float min, float max, bool doNotCalibrateRange, HardwareAxisInfo axisInfo)
			{
			}

			public Axis(Axis source)
			{
			}

			public override Element Clone()
			{
				return null;
			}
		}

		private sealed class XdzWvUdLLsOYFECWEiXJOpexHPk : IDisposable, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>, IEnumerator, IEnumerable
		{
			private ControllerElementIdentifier BkCCsqltFMRNvCZoZtUjDVFIQQJ;

			private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

			private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

			public CustomController_Editor TiaUIShtPVkFOKyDFxywSfPUjyv;

			public int qmSYAdZCWBVZBfxBKWlRZEObgpC;

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
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
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
			public XdzWvUdLLsOYFECWEiXJOpexHPk(int _003C_003E1__state)
			{
			}
		}

		[CustomObfuscation]
		[SerializeField]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private string _descriptiveName;

		[CustomObfuscation]
		[SerializeField]
		private int _id;

		[SerializeField]
		[CustomObfuscation]
		private string _typeGuidString;

		[SerializeField]
		[CustomObfuscation]
		private List<ControllerElementIdentifier> _elementIdentifiers;

		[SerializeField]
		[CustomObfuscation]
		private List<Axis> _axes;

		[CustomObfuscation]
		[SerializeField]
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

		public CustomController_Editor(CustomController_Editor source)
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

		internal ControllerElementType SiMcurLKVxBAulSasIPcYMnnwba(int P_0)
		{
			return default(ControllerElementType);
		}

		internal bool EKQGPNLarOfSflreAnwmJwLaYnm(int P_0, out AxisRange P_1)
		{
			P_1 = default(AxisRange);
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

		private void ztRdHLvpeeVTTHMUOCTxdVshHNiq<T>(int P_0, List<T> P_1) where T : Element
		{
		}

		private ControllerElementIdentifier eDjdmOAkQZUizHPxdBrWgGOabxT(int P_0, string P_1)
		{
			return null;
		}

		private Element gqQFFfQfSgbdLgOwzOhGpVwCOro(ControllerElementType P_0)
		{
			return null;
		}

		private ControllerElementIdentifier bTKEhKaYLClUSHjgEPmFRVrRmQc(ControllerElementType P_0, string P_1, string P_2, string P_3)
		{
			return null;
		}

		internal HardwareControllerMap_Game vdSkbJcQOSeEHGgymDoYhdFfkDdj()
		{
			return null;
		}
	}
}
