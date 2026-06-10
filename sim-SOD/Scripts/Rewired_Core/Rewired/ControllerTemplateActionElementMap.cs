using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int ZjhenRHxqNuSrgJhTzeCvEoySmU;

		private readonly ControllerTemplateElementType KBXbDLkLbEVjqjnHFWngPgnQczYe;

		private bool fYgWWBiWXTDKmooXjoXGiYdmpQy;

		private int CijfVweIqbvViXAEzqkELDhcHIR;

		private int YcDcbHqQMwtgQxoISZasthfuQlm;

		private static int sZMcosmXwsGOqLRQIwwliTLKHMs;

		public int id => 0;

		public ControllerTemplateElementType elementType => default(ControllerTemplateElementType);

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int actionId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType)
		{
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, ActionElementMap actionElementMap)
		{
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, int actionId, bool enabled)
		{
		}

		protected ControllerTemplateActionElementMap(ActionElementMap actionElementMap)
		{
		}

		internal int CRkUxNKYAYbCSEpOOiMzkOSpMmqt(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			return 0;
		}

		internal SerializedObject IJTYgxRVETFGIEeOvEZXpvilyrI()
		{
			return null;
		}

		internal virtual void IJTYgxRVETFGIEeOvEZXpvilyrI(SerializedObject P_0)
		{
		}

		internal virtual void jygDICBMHaTDOHrItEJCbjkpEXhs(SerializedObject P_0)
		{
		}

		internal virtual void DcbUeIfyTfvTrRQxceAMfGCsJNs()
		{
		}

		internal abstract int rRcJGCFiwyVGkaRwbAZqUdsdpNx(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int DctzaPwPWpGtJLVQdFiFyCrJcRs(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			return 0;
		}

		internal static ControllerTemplateActionElementMap ocIbkoMmgHsnOyMMcObcgEoKEsQ(SerializedObject P_0)
		{
			return null;
		}

		internal static ControllerTemplateActionElementMap ocIbkoMmgHsnOyMMcObcgEoKEsQ(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
		{
			return null;
		}

		internal static ControllerTemplateActionElementMap ocIbkoMmgHsnOyMMcObcgEoKEsQ(ActionElementMap P_0)
		{
			return null;
		}
	}
}
