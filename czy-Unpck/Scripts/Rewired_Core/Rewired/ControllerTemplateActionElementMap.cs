using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int tqPurZpByiUWRrPJKwHxxaZZua;

		private readonly ControllerTemplateElementType iDCCUtfTWxxiRkkzZhazaAppvzo;

		private bool FnzJwrQpikWfZbmfjZhFwutJGAA;

		private int qxoYaUQyNIsvDIFklnqXHPrHJLd;

		private int yBWjkrHKbDlkjegyONinAthRElAh;

		private static int EMLanSKUFRaQBGWyQdgiFgZjtXMN;

		public int id => tqPurZpByiUWRrPJKwHxxaZZua;

		public ControllerTemplateElementType elementType => iDCCUtfTWxxiRkkzZhazaAppvzo;

		public bool enabled
		{
			get
			{
				return FnzJwrQpikWfZbmfjZhFwutJGAA;
			}
			set
			{
				FnzJwrQpikWfZbmfjZhFwutJGAA = value;
			}
		}

		public int actionId
		{
			get
			{
				return qxoYaUQyNIsvDIFklnqXHPrHJLd;
			}
			set
			{
				qxoYaUQyNIsvDIFklnqXHPrHJLd = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return yBWjkrHKbDlkjegyONinAthRElAh;
			}
			set
			{
				yBWjkrHKbDlkjegyONinAthRElAh = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType)
		{
			if (!InputTools.IsMappableType(elementType))
			{
				throw new ArgumentException(string.Concat(elementType, " is not a supported mappable Controller Template element type."));
			}
			iDCCUtfTWxxiRkkzZhazaAppvzo = elementType;
			tqPurZpByiUWRrPJKwHxxaZZua = EMLanSKUFRaQBGWyQdgiFgZjtXMN++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, ActionElementMap actionElementMap)
			: this(elementType)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			qxoYaUQyNIsvDIFklnqXHPrHJLd = actionElementMap._actionId;
			yBWjkrHKbDlkjegyONinAthRElAh = elementIdentifierId;
			FnzJwrQpikWfZbmfjZhFwutJGAA = actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, int actionId, bool enabled)
			: this(elementType)
		{
			qxoYaUQyNIsvDIFklnqXHPrHJLd = actionId;
			yBWjkrHKbDlkjegyONinAthRElAh = elementIdentifierId;
			FnzJwrQpikWfZbmfjZhFwutJGAA = enabled;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap actionElementMap)
		{
		}

		internal int eKnqmjiMlbYPbNAwCiMmSHMCWkS(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			int index = default(int);
			int num2 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (P_1 != null)
			{
				while (true)
				{
					IL_00ad:
					int num;
					if (!P_2)
					{
						P_1.Clear();
						num = 1479605482;
						goto IL_0016;
					}
					goto IL_0084;
					IL_0016:
					while (true)
					{
						switch (num ^ 0x5830FCED)
						{
						case 0:
							num = 1479605481;
							continue;
						case 8:
							P_1[index]._actionId = qxoYaUQyNIsvDIFklnqXHPrHJLd;
							num2++;
							num = 1479605487;
							continue;
						case 1:
							index = num4 + num2;
							P_1[index].FnzJwrQpikWfZbmfjZhFwutJGAA = FnzJwrQpikWfZbmfjZhFwutJGAA;
							num = 1479605477;
							continue;
						case 7:
							break;
						case 3:
							goto IL_0095;
						case 5:
							goto IL_00ad;
						case 6:
							num2 = 0;
							num = 1479605487;
							continue;
						case 4:
							goto end_IL_00ad;
						default:
							if (num2 >= num3)
							{
								return num3;
							}
							goto case 1;
						}
						break;
						IL_0095:
						if (num3 == 0)
						{
							return 0;
						}
						num4 = P_1.Count - num3;
						num = 1479605483;
					}
					goto IL_0084;
					IL_0084:
					num3 = rdcEqIQUyEYJAAYflLCruMUyamf(P_0, P_1, P_2);
					num = 1479605486;
					goto IL_0016;
					continue;
					end_IL_00ad:
					break;
				}
			}
			throw new ArgumentNullException("results");
		}

		internal SerializedObject mtMtVVrohwWTxFPivXmGbDyGevo()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			mtMtVVrohwWTxFPivXmGbDyGevo(serializedObject);
			return serializedObject;
		}

		internal virtual void mtMtVVrohwWTxFPivXmGbDyGevo(SerializedObject P_0)
		{
			P_0.Add("elementType", iDCCUtfTWxxiRkkzZhazaAppvzo);
			while (true)
			{
				int num = 1615663823;
				while (true)
				{
					switch (num ^ 0x604D12CE)
					{
					case 4:
						break;
					default:
						return;
					case 1:
						P_0.Add("enabled", FnzJwrQpikWfZbmfjZhFwutJGAA);
						num = 1615663821;
						continue;
					case 2:
						P_0.Add("actionId", qxoYaUQyNIsvDIFklnqXHPrHJLd);
						num = 1615663822;
						continue;
					case 3:
						P_0.Add("elementIdentifierId", yBWjkrHKbDlkjegyONinAthRElAh);
						num = 1615663820;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal virtual void FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject P_0)
		{
			tAgADqjTsMUxSqYXeDyJIdETYRAp();
			P_0.TryGetDeserializedValueByRef("enabled", ref FnzJwrQpikWfZbmfjZhFwutJGAA);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref yBWjkrHKbDlkjegyONinAthRElAh);
			P_0.TryGetDeserializedValueByRef("actionId", ref qxoYaUQyNIsvDIFklnqXHPrHJLd);
		}

		internal virtual void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			FnzJwrQpikWfZbmfjZhFwutJGAA = true;
			yBWjkrHKbDlkjegyONinAthRElAh = -1;
			qxoYaUQyNIsvDIFklnqXHPrHJLd = -1;
		}

		internal abstract int TPjqYspfJVdLLflGpdCjWPeGAtN(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int rdcEqIQUyEYJAAYflLCruMUyamf(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			IControllerTemplateElementSource source;
			while (true)
			{
				int num;
				if (!P_2)
				{
					P_1.Clear();
					num = -1409459317;
					goto IL_0013;
				}
				goto IL_0040;
				IL_0013:
				while (true)
				{
					switch (num ^ -1409459317)
					{
					case 2:
						num = -1409459320;
						continue;
					case 3:
						break;
					case 0:
						goto IL_0040;
					default:
						return 0;
					}
					break;
				}
				continue;
				IL_0040:
				IControllerTemplateElement element = P_0.GetElement(yBWjkrHKbDlkjegyONinAthRElAh);
				if (element == null)
				{
					return 0;
				}
				source = element.source;
				if (source != null)
				{
					break;
				}
				num = -1409459318;
				goto IL_0013;
			}
			return TPjqYspfJVdLLflGpdCjWPeGAtN(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap GIHuiEkmFihgdjpqkqIhwXanlmm(SerializedObject P_0)
		{
			if (P_0 == null)
			{
				return null;
			}
			if (!P_0.TryGetDeserializedValue<ControllerTemplateElementType>("elementType", out var value))
			{
				return null;
			}
			switch (value)
			{
			default:
				while (true)
				{
					switch (0x4D471C5A ^ 0x4D471C5B)
					{
					case 2:
						continue;
					case 1:
						throw new NotImplementedException();
					}
					break;
				}
				goto case ControllerTemplateElementType.Axis;
			case ControllerTemplateElementType.Axis:
				return new ControllerTemplateActionAxisMap(P_0);
			case ControllerTemplateElementType.Button:
				return new ControllerTemplateActionButtonMap(P_0);
			}
		}

		internal static ControllerTemplateActionElementMap GIHuiEkmFihgdjpqkqIhwXanlmm(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				goto IL_0003;
			}
			goto IL_0037;
			IL_0003:
			int num = 1789989295;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x6AB111AC)
			{
			case 0:
				break;
			case 3:
				throw new ArgumentNullException("actionElementMap");
			case 2:
				goto IL_0037;
			default:
				return new ControllerTemplateActionAxisMap(P_0.element.id, P_0.axisRange, P_1);
			}
			goto IL_0003;
			IL_0037:
			if (P_0.elementType == ControllerTemplateElementType.Axis)
			{
				num = 1789989293;
				goto IL_0008;
			}
			if (P_0.elementType == ControllerTemplateElementType.Button)
			{
				return new ControllerTemplateActionButtonMap(P_0.element.id, P_1);
			}
			throw new NotImplementedException();
		}

		internal static ControllerTemplateActionElementMap GIHuiEkmFihgdjpqkqIhwXanlmm(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			while (true)
			{
				ControllerTemplateElementType controllerTemplateElementType = zRJHFfVYpYamSokTjXZVUKlCnAG.BRBXzDYhhYIycYzhOeZDlUThiws(P_0._elementType, false);
				if (!InputTools.IsMappableType(controllerTemplateElementType))
				{
					return null;
				}
				int num;
				if (controllerTemplateElementType == ControllerTemplateElementType.Axis)
				{
					num = -1087638208;
				}
				else
				{
					if (controllerTemplateElementType != ControllerTemplateElementType.Button)
					{
						break;
					}
					num = -1087638205;
				}
				while (true)
				{
					switch (num ^ -1087638205)
					{
					case 2:
						goto IL_000e;
					case 1:
						break;
					case 3:
						return new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.FnzJwrQpikWfZbmfjZhFwutJGAA);
					default:
						return new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.FnzJwrQpikWfZbmfjZhFwutJGAA);
					}
					break;
					IL_000e:
					num = -1087638206;
				}
			}
			throw new NotImplementedException();
		}
	}
}
