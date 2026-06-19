using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int LeSBLSKJOgbMRxJwNnkAEiDKlllzb;

		private readonly ControllerTemplateElementType sPMqlOtMUaldNuvcYNlYcDzXNwOT;

		private bool vnjExQcxzcqsXUYSLSvJsLsXaIKp;

		private int pAGBCdrmBgorGYdHrlJkoDBKqjMl;

		private int FcHFnNTDcTugNrHfusXCvbWtlXxn;

		private static int znhSPmtMQvKQJzHYQdZWalVowpgxA;

		public int id => LeSBLSKJOgbMRxJwNnkAEiDKlllzb;

		public ControllerTemplateElementType elementType => sPMqlOtMUaldNuvcYNlYcDzXNwOT;

		public bool enabled
		{
			get
			{
				return vnjExQcxzcqsXUYSLSvJsLsXaIKp;
			}
			set
			{
				vnjExQcxzcqsXUYSLSvJsLsXaIKp = value;
			}
		}

		public int actionId
		{
			get
			{
				return pAGBCdrmBgorGYdHrlJkoDBKqjMl;
			}
			set
			{
				pAGBCdrmBgorGYdHrlJkoDBKqjMl = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return FcHFnNTDcTugNrHfusXCvbWtlXxn;
			}
			set
			{
				FcHFnNTDcTugNrHfusXCvbWtlXxn = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			sPMqlOtMUaldNuvcYNlYcDzXNwOT = P_0;
			LeSBLSKJOgbMRxJwNnkAEiDKlllzb = znhSPmtMQvKQJzHYQdZWalVowpgxA++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			pAGBCdrmBgorGYdHrlJkoDBKqjMl = P_2._actionId;
			FcHFnNTDcTugNrHfusXCvbWtlXxn = P_1;
			vnjExQcxzcqsXUYSLSvJsLsXaIKp = P_2.fpFEHHilwCsNTxvZcaeleakbBkQCb;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			pAGBCdrmBgorGYdHrlJkoDBKqjMl = P_2;
			FcHFnNTDcTugNrHfusXCvbWtlXxn = P_1;
			vnjExQcxzcqsXUYSLSvJsLsXaIKp = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int kDKaDdJQHThExDzsQWjvqhSCqPECA(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = EDqUMsvnwyOJAruzurqIaBxCBMVdA(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].fpFEHHilwCsNTxvZcaeleakbBkQCb = vnjExQcxzcqsXUYSLSvJsLsXaIKp;
				P_1[index]._actionId = pAGBCdrmBgorGYdHrlJkoDBKqjMl;
			}
			return num;
		}

		internal SerializedObject vxFvXJxOxgWltUtVuuPlJZRQpEze()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			vABcCNWeRmzGbFnvLaadmaTXvjBx(serializedObject);
			return serializedObject;
		}

		internal virtual void vABcCNWeRmzGbFnvLaadmaTXvjBx(SerializedObject P_0)
		{
			P_0.Add("elementType", sPMqlOtMUaldNuvcYNlYcDzXNwOT);
			P_0.Add("enabled", vnjExQcxzcqsXUYSLSvJsLsXaIKp);
			P_0.Add("elementIdentifierId", FcHFnNTDcTugNrHfusXCvbWtlXxn);
			P_0.Add("actionId", pAGBCdrmBgorGYdHrlJkoDBKqjMl);
		}

		internal virtual void uMqyncwXliJAiRiUiWiUyLiSfrpdA(SerializedObject P_0)
		{
			dPOvKSYHoszSYxjPyUducmauZjzs();
			P_0.TryGetDeserializedValueByRef("enabled", ref vnjExQcxzcqsXUYSLSvJsLsXaIKp);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref FcHFnNTDcTugNrHfusXCvbWtlXxn);
			P_0.TryGetDeserializedValueByRef("actionId", ref pAGBCdrmBgorGYdHrlJkoDBKqjMl);
		}

		internal virtual void dPOvKSYHoszSYxjPyUducmauZjzs()
		{
			vnjExQcxzcqsXUYSLSvJsLsXaIKp = true;
			FcHFnNTDcTugNrHfusXCvbWtlXxn = -1;
			pAGBCdrmBgorGYdHrlJkoDBKqjMl = -1;
		}

		internal abstract int BEvHAxicJCIUXXnEOrbFrerDrmdW(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int EDqUMsvnwyOJAruzurqIaBxCBMVdA(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(FcHFnNTDcTugNrHfusXCvbWtlXxn);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return BEvHAxicJCIUXXnEOrbFrerDrmdW(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap KQwAKVUFIbokGUYCJhocoKKfVlKn(SerializedObject P_0)
		{
			if (P_0 == null)
			{
				return null;
			}
			if (!P_0.TryGetDeserializedValue<ControllerTemplateElementType>("elementType", out var value))
			{
				return null;
			}
			return value switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal static ControllerTemplateActionElementMap KDPxbJXBcLfMqHUazPygyUwMsyWo(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.elementType == ControllerTemplateElementType.Axis)
			{
				return new ControllerTemplateActionAxisMap(P_0.element.id, P_0.axisRange, P_1);
			}
			if (P_0.elementType == ControllerTemplateElementType.Button)
			{
				return new ControllerTemplateActionButtonMap(P_0.element.id, P_1);
			}
			throw new NotImplementedException();
		}

		internal static ControllerTemplateActionElementMap uAgYsMBZAISeyFOKLCMUFHKCoTswA(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = nwsTruCLxjorysrNysDvPYrmMcrb.PhBsCcmHGqkEUBEQPMQesliDCkBe(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.fpFEHHilwCsNTxvZcaeleakbBkQCb), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.fpFEHHilwCsNTxvZcaeleakbBkQCb), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
