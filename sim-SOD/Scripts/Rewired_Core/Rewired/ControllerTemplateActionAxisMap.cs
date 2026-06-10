using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange cABCOnvRSkGcigODbszHBBdAJzQM;

		private Pole zJDZegKBEylmTufyxXBEpUosAk;

		private bool BGMqqEuRVgwTmFNpxwYAfFxSbFL;

		public AxisRange axisRange => default(AxisRange);

		public Pole axisContribution => default(Pole);

		public bool invert => false;

		internal ControllerTemplateActionAxisMap(SerializedObject serializedObject)
			: base(default(ControllerTemplateElementType))
		{
		}

		internal ControllerTemplateActionAxisMap(int templateElementIdentifierId, AxisRange axisRange, ActionElementMap actionElementMap)
			: base(default(ControllerTemplateElementType))
		{
		}

		internal ControllerTemplateActionAxisMap(int elementIdentifierId, int actionId, AxisRange axisRange, Pole axisContribution, bool invert, bool enabled)
			: base(default(ControllerTemplateElementType))
		{
		}

		internal override void IJTYgxRVETFGIEeOvEZXpvilyrI(SerializedObject P_0)
		{
		}

		internal override void jygDICBMHaTDOHrItEJCbjkpEXhs(SerializedObject P_0)
		{
		}

		internal override void DcbUeIfyTfvTrRQxceAMfGCsJNs()
		{
		}

		internal override int rRcJGCFiwyVGkaRwbAZqUdsdpNx(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			return 0;
		}

		private ActionElementMap GxYMChHYFthVeSRtRVteeUCrcfp(IControllerElementTarget P_0, AxisRange P_1)
		{
			return null;
		}

		private ActionElementMap pLeMAofJKuJSltuRnCjVtuLWDCi(IControllerElementTarget P_0, Pole P_1, Pole P_2)
		{
			return null;
		}
	}
}
