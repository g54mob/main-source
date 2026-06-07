using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int qTyNghlDdoNDmLjDeHVYDpksMqmSA;

		private readonly ControllerTemplateElementType JdeZShBnzwhoucUJnaQSzwUAHxXP;

		private bool OFPDUrBQUyjviMAdaNUJZtHQnDJVA;

		private int WRauKOFliytgdQeiGCAkjnwBdbTV;

		private int aqbKmVpNGJfobpEUZqALklmoKgnB;

		private static int AkRPoFLMhtLBqdipnKuOcoolImdq;

		public int id => qTyNghlDdoNDmLjDeHVYDpksMqmSA;

		public ControllerTemplateElementType elementType => JdeZShBnzwhoucUJnaQSzwUAHxXP;

		public bool enabled
		{
			get
			{
				return OFPDUrBQUyjviMAdaNUJZtHQnDJVA;
			}
			set
			{
				OFPDUrBQUyjviMAdaNUJZtHQnDJVA = value;
			}
		}

		public int actionId
		{
			get
			{
				return WRauKOFliytgdQeiGCAkjnwBdbTV;
			}
			set
			{
				WRauKOFliytgdQeiGCAkjnwBdbTV = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return aqbKmVpNGJfobpEUZqALklmoKgnB;
			}
			set
			{
				aqbKmVpNGJfobpEUZqALklmoKgnB = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			JdeZShBnzwhoucUJnaQSzwUAHxXP = P_0;
			qTyNghlDdoNDmLjDeHVYDpksMqmSA = AkRPoFLMhtLBqdipnKuOcoolImdq++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			WRauKOFliytgdQeiGCAkjnwBdbTV = P_2._actionId;
			aqbKmVpNGJfobpEUZqALklmoKgnB = P_1;
			OFPDUrBQUyjviMAdaNUJZtHQnDJVA = P_2.IdtDkaTUBQdYslzoHMBnxOLemrRM;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			WRauKOFliytgdQeiGCAkjnwBdbTV = P_2;
			aqbKmVpNGJfobpEUZqALklmoKgnB = P_1;
			OFPDUrBQUyjviMAdaNUJZtHQnDJVA = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int XgPaUfnsXGLGqvXxSObscbJiKDxA(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
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
			int num = tpAnvLBqPeeQrpROPvBOfIQFFTKJA(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].IdtDkaTUBQdYslzoHMBnxOLemrRM = OFPDUrBQUyjviMAdaNUJZtHQnDJVA;
				P_1[index]._actionId = WRauKOFliytgdQeiGCAkjnwBdbTV;
			}
			return num;
		}

		internal SerializedObject GVfGeiJcrohTAEfQLEFzaAkTcmoYA()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			CmnfhwiyqiNdINILsJMpriXEkjSC(serializedObject);
			return serializedObject;
		}

		internal virtual void CmnfhwiyqiNdINILsJMpriXEkjSC(SerializedObject P_0)
		{
			P_0.Add("elementType", JdeZShBnzwhoucUJnaQSzwUAHxXP);
			P_0.Add("enabled", OFPDUrBQUyjviMAdaNUJZtHQnDJVA);
			P_0.Add("elementIdentifierId", aqbKmVpNGJfobpEUZqALklmoKgnB);
			P_0.Add("actionId", WRauKOFliytgdQeiGCAkjnwBdbTV);
		}

		internal virtual void TiARSBGHYwWRRTIpTBPKxkTBxqeX(SerializedObject P_0)
		{
			GHinftmATwSVxrZaNhWmfXPzwayy();
			P_0.TryGetDeserializedValueByRef("enabled", ref OFPDUrBQUyjviMAdaNUJZtHQnDJVA);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref aqbKmVpNGJfobpEUZqALklmoKgnB);
			P_0.TryGetDeserializedValueByRef("actionId", ref WRauKOFliytgdQeiGCAkjnwBdbTV);
		}

		internal virtual void GHinftmATwSVxrZaNhWmfXPzwayy()
		{
			OFPDUrBQUyjviMAdaNUJZtHQnDJVA = true;
			aqbKmVpNGJfobpEUZqALklmoKgnB = -1;
			WRauKOFliytgdQeiGCAkjnwBdbTV = -1;
		}

		internal abstract int yJTumWOEcMXpkHeprAHVmbSUfRoF(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int tpAnvLBqPeeQrpROPvBOfIQFFTKJA(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(aqbKmVpNGJfobpEUZqALklmoKgnB);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return yJTumWOEcMXpkHeprAHVmbSUfRoF(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap bySbytotDdpkbEbKiPwqrtlkywVC(SerializedObject P_0)
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

		internal static ControllerTemplateActionElementMap jjzKnyfcVLTIBXPTOTqopjNLbNFG(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
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

		internal static ControllerTemplateActionElementMap XxEQBlxofIpvLXrxiHzIUjjLLEnV(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = SVQbmGoCgjXlQooYDoNZCFflMVzP.qJtXJpUXwwvizFfxspHyzGUSDxUj(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.IdtDkaTUBQdYslzoHMBnxOLemrRM), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.IdtDkaTUBQdYslzoHMBnxOLemrRM), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
