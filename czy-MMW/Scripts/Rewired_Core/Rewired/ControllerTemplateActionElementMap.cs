using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int VHCJjuAjvkTIQGNlDABEOeKEgIx;

		private readonly ControllerTemplateElementType qnRwmlYEnrFXCraZcbRDhSKyBfpab;

		private bool noaqexZgIxAGKXwrnwDSEZNirVxT;

		private int pJPZGCWqijtKLFikLmXtGialQprS;

		private int ZiQLyiyLDUlGCctIQfnPVFrUcGGGA;

		private static int dVaOiXGdaemYKwfmqbuZFmoNkERe;

		public int id => VHCJjuAjvkTIQGNlDABEOeKEgIx;

		public ControllerTemplateElementType elementType => qnRwmlYEnrFXCraZcbRDhSKyBfpab;

		public bool enabled
		{
			get
			{
				return noaqexZgIxAGKXwrnwDSEZNirVxT;
			}
			set
			{
				noaqexZgIxAGKXwrnwDSEZNirVxT = value;
			}
		}

		public int actionId
		{
			get
			{
				return pJPZGCWqijtKLFikLmXtGialQprS;
			}
			set
			{
				pJPZGCWqijtKLFikLmXtGialQprS = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return ZiQLyiyLDUlGCctIQfnPVFrUcGGGA;
			}
			set
			{
				ZiQLyiyLDUlGCctIQfnPVFrUcGGGA = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			qnRwmlYEnrFXCraZcbRDhSKyBfpab = P_0;
			VHCJjuAjvkTIQGNlDABEOeKEgIx = dVaOiXGdaemYKwfmqbuZFmoNkERe++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			pJPZGCWqijtKLFikLmXtGialQprS = P_2._actionId;
			ZiQLyiyLDUlGCctIQfnPVFrUcGGGA = P_1;
			noaqexZgIxAGKXwrnwDSEZNirVxT = P_2.dQASdaEFVJzbOgxgKEdsYSDArFzi;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			pJPZGCWqijtKLFikLmXtGialQprS = P_2;
			ZiQLyiyLDUlGCctIQfnPVFrUcGGGA = P_1;
			noaqexZgIxAGKXwrnwDSEZNirVxT = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int ueJqIGwNkYdgqyqDkeFaPtxdONzl(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
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
			int num = GylXLiIPWfzNumUJGAJmYGArLcqc(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].dQASdaEFVJzbOgxgKEdsYSDArFzi = noaqexZgIxAGKXwrnwDSEZNirVxT;
				P_1[index]._actionId = pJPZGCWqijtKLFikLmXtGialQprS;
			}
			return num;
		}

		internal SerializedObject jnIDmqDKnldoyoJQKbMmrrobSwSy()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			rEEPJurqodegiEtUjISsUIygEwqP(serializedObject);
			return serializedObject;
		}

		internal virtual void rEEPJurqodegiEtUjISsUIygEwqP(SerializedObject P_0)
		{
			P_0.Add("elementType", qnRwmlYEnrFXCraZcbRDhSKyBfpab);
			P_0.Add("enabled", noaqexZgIxAGKXwrnwDSEZNirVxT);
			P_0.Add("elementIdentifierId", ZiQLyiyLDUlGCctIQfnPVFrUcGGGA);
			P_0.Add("actionId", pJPZGCWqijtKLFikLmXtGialQprS);
		}

		internal virtual void qnVwNfJEznmnhAlEVWZNSXzfyGGb(SerializedObject P_0)
		{
			brJDjWfLTbiFiioRCZdvMBUPmGvb();
			P_0.TryGetDeserializedValueByRef("enabled", ref noaqexZgIxAGKXwrnwDSEZNirVxT);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref ZiQLyiyLDUlGCctIQfnPVFrUcGGGA);
			P_0.TryGetDeserializedValueByRef("actionId", ref pJPZGCWqijtKLFikLmXtGialQprS);
		}

		internal virtual void brJDjWfLTbiFiioRCZdvMBUPmGvb()
		{
			noaqexZgIxAGKXwrnwDSEZNirVxT = true;
			ZiQLyiyLDUlGCctIQfnPVFrUcGGGA = -1;
			pJPZGCWqijtKLFikLmXtGialQprS = -1;
		}

		internal abstract int LxceKSTvmTduKIEfcaHAGVMsIxINA(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int GylXLiIPWfzNumUJGAJmYGArLcqc(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(ZiQLyiyLDUlGCctIQfnPVFrUcGGGA);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return LxceKSTvmTduKIEfcaHAGVMsIxINA(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap YmbOLerfjswQFZTvzfYzYGlAcwns(SerializedObject P_0)
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

		internal static ControllerTemplateActionElementMap WXSDkkmTTKGydYeBBBOjCYLzThdUA(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
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

		internal static ControllerTemplateActionElementMap kijvlholgRWdaOdzpmVGxzirWRyB(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = pMvvECjJycyKibKKCAXEnFbBPTVk.RBEXvfBrylcGHQlrvbaxUlUsGPcaA(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.dQASdaEFVJzbOgxgKEdsYSDArFzi), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.dQASdaEFVJzbOgxgKEdsYSDArFzi), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
