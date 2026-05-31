using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate
	{
		internal abstract class sVxZtXOEFOIKGbskGYuCcZDzKWiD : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate lNLlpcURMXkCiVBaiOQpguboCVx;

			private readonly int JYRMuwETpVNRqJXmtBgBFhZdTeP;

			private readonly string qpIGvFaemznETzYbpRdmOKmaPCL;

			private readonly ControllerTemplateElementType AkkykLRVUWzqzDOfDtdSigYijIy;

			protected readonly int VumWnlylMgxSbyJcluXptXvaaZa;

			public int id
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return -1;
					}
					return JYRMuwETpVNRqJXmtBgBFhZdTeP;
				}
			}

			public string descriptiveName
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return qpIGvFaemznETzYbpRdmOKmaPCL;
				}
			}

			public ControllerTemplateElementType type
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerTemplateElementType.Axis;
					}
					return AkkykLRVUWzqzDOfDtdSigYijIy;
				}
			}

			public IControllerTemplate parent => lNLlpcURMXkCiVBaiOQpguboCVx;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected sVxZtXOEFOIKGbskGYuCcZDzKWiD(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				lNLlpcURMXkCiVBaiOQpguboCVx = parent;
				JYRMuwETpVNRqJXmtBgBFhZdTeP = id;
				qpIGvFaemznETzYbpRdmOKmaPCL = name;
				AkkykLRVUWzqzDOfDtdSigYijIy = elementType;
				VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class ssgmYMMXyzeaALJcZhSQpVaOieh : sVxZtXOEFOIKGbskGYuCcZDzKWiD
		{
			protected readonly int hRmctwDVJLrLmWwPiYsEKJbqtMxO;

			protected readonly NolDTfvtsKbAKKAFyaBkjhVjxMvb[] bJrqujyartCgGBfAeZDWcpHsDsm;

			public override bool exists
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (bJrqujyartCgGBfAeZDWcpHsDsm == null)
					{
						return false;
					}
					for (int i = 0; i < bJrqujyartCgGBfAeZDWcpHsDsm.Length; i++)
					{
						if (bJrqujyartCgGBfAeZDWcpHsDsm[i].PROiOPXLPssOzqJmzIHKLhOlSLw != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected ssgmYMMXyzeaALJcZhSQpVaOieh(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IList<NolDTfvtsKbAKKAFyaBkjhVjxMvb> sourceElements)
				: base(parent, id, name, elementType)
			{
				bJrqujyartCgGBfAeZDWcpHsDsm = ((sourceElements != null) ? ListTools.ToArray(sourceElements) : null);
				hRmctwDVJLrLmWwPiYsEKJbqtMxO = ((bJrqujyartCgGBfAeZDWcpHsDsm != null) ? bJrqujyartCgGBfAeZDWcpHsDsm.Length : 0);
			}
		}

		internal abstract class wgiWmEBoGrEBAKMjuToBnVvTzZL : ssgmYMMXyzeaALJcZhSQpVaOieh, IControllerTemplateElement, IControllerTemplateAxis, IControllerTemplateButton
		{
			private OyJZlVlspSSqIjquoKnBSuwliGg PzcnjoNqEkQAHZfcMtoihQXpiFG;

			private string xRKgPqjlpjGGlIAUSKVecqZdHrDb;

			private string vKCegYWgTkoGkcEhJkmFbGSXDGCf;

			public float floatValue
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 1)
					{
						return bJrqujyartCgGBfAeZDWcpHsDsm[0].floatValue;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 2)
					{
						float num = bJrqujyartCgGBfAeZDWcpHsDsm[0].floatValue;
						float num2 = bJrqujyartCgGBfAeZDWcpHsDsm[1].floatValue;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 1)
					{
						return bJrqujyartCgGBfAeZDWcpHsDsm[0].floatValuePrev;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 2)
					{
						float num = bJrqujyartCgGBfAeZDWcpHsDsm[0].floatValuePrev;
						float num2 = bJrqujyartCgGBfAeZDWcpHsDsm[1].floatValuePrev;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool boolValue
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 1)
					{
						return bJrqujyartCgGBfAeZDWcpHsDsm[0].boolValue;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 2)
					{
						if (!bJrqujyartCgGBfAeZDWcpHsDsm[0].boolValue)
						{
							return bJrqujyartCgGBfAeZDWcpHsDsm[1].boolValue;
						}
						return true;
					}
					return false;
				}
			}

			public bool boolValuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 1)
					{
						return bJrqujyartCgGBfAeZDWcpHsDsm[0].boolValuePrev;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 2)
					{
						if (!bJrqujyartCgGBfAeZDWcpHsDsm[0].boolValuePrev)
						{
							return bJrqujyartCgGBfAeZDWcpHsDsm[1].boolValuePrev;
						}
						return true;
					}
					return false;
				}
			}

			string IControllerTemplateAxis.positiveDescriptiveName
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return xRKgPqjlpjGGlIAUSKVecqZdHrDb;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return vKCegYWgTkoGkcEhJkmFbGSXDGCf;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return PzcnjoNqEkQAHZfcMtoihQXpiFG;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return boolValue;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return boolValuePrev;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 1)
					{
						return bJrqujyartCgGBfAeZDWcpHsDsm[0].justPressed;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 2)
					{
						if (!bJrqujyartCgGBfAeZDWcpHsDsm[0].justPressed || bJrqujyartCgGBfAeZDWcpHsDsm[1].boolValuePrev)
						{
							if (bJrqujyartCgGBfAeZDWcpHsDsm[1].justPressed)
							{
								return !bJrqujyartCgGBfAeZDWcpHsDsm[0].boolValuePrev;
							}
							return false;
						}
						return true;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justReleased
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 1)
					{
						return bJrqujyartCgGBfAeZDWcpHsDsm[0].justReleased;
					}
					if (hRmctwDVJLrLmWwPiYsEKJbqtMxO == 2)
					{
						if (!bJrqujyartCgGBfAeZDWcpHsDsm[0].justReleased || bJrqujyartCgGBfAeZDWcpHsDsm[1].boolValue)
						{
							if (bJrqujyartCgGBfAeZDWcpHsDsm[1].justReleased)
							{
								return !bJrqujyartCgGBfAeZDWcpHsDsm[0].boolValue;
							}
							return false;
						}
						return true;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justChangedState
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return boolValue != boolValuePrev;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return PzcnjoNqEkQAHZfcMtoihQXpiFG;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return PzcnjoNqEkQAHZfcMtoihQXpiFG;
				}
			}

			public override int elementCount => 0;

			public IControllerTemplateAxis AsAxis
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return this;
				}
			}

			public IControllerTemplateButton AsButton
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return this;
				}
			}

			protected wgiWmEBoGrEBAKMjuToBnVvTzZL(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, OyJZlVlspSSqIjquoKnBSuwliGg target, IList<NolDTfvtsKbAKKAFyaBkjhVjxMvb> sourceElements)
				: base(parent, id, name, elementType, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				PzcnjoNqEkQAHZfcMtoihQXpiFG = target;
				xRKgPqjlpjGGlIAUSKVecqZdHrDb = positiveName;
				vKCegYWgTkoGkcEhJkmFbGSXDGCf = negativeName;
			}

			private string IYnZonvTmIUNYqFWSbbQiORtGNmv(AxisRange P_0)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return P_0 switch
				{
					AxisRange.Full => base.descriptiveName, 
					AxisRange.Positive => xRKgPqjlpjGGlIAUSKVecqZdHrDb, 
					AxisRange.Negative => vKCegYWgTkoGkcEhJkmFbGSXDGCf, 
					_ => throw new NotImplementedException(), 
				};
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in IYnZonvTmIUNYqFWSbbQiORtGNmv
				return this.IYnZonvTmIUNYqFWSbbQiORtGNmv(P_0);
			}

			public override IControllerTemplateElement GetElement(int index)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
			{
				if (find.elementIdentifierId < 0)
				{
					return 0;
				}
				int num = 0;
				switch (base.type)
				{
				case ControllerTemplateElementType.Axis:
				{
					IControllerTemplateAxisSource pzcnjoNqEkQAHZfcMtoihQXpiFG = PzcnjoNqEkQAHZfcMtoihQXpiFG;
					if (pzcnjoNqEkQAHZfcMtoihQXpiFG.splitAxis)
					{
						if (URPggrulszrLyJUAHStnGOIHqVW(find, pzcnjoNqEkQAHZfcMtoihQXpiFG.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (URPggrulszrLyJUAHStnGOIHqVW(find, pzcnjoNqEkQAHZfcMtoihQXpiFG.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (URPggrulszrLyJUAHStnGOIHqVW(find, pzcnjoNqEkQAHZfcMtoihQXpiFG.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (URPggrulszrLyJUAHStnGOIHqVW(find, ((IControllerTemplateButtonSource)PzcnjoNqEkQAHZfcMtoihQXpiFG).target))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Full));
						num++;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return num;
			}

			private static bool URPggrulszrLyJUAHStnGOIHqVW(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				if (P_1.elementIdentifierId != P_0.elementIdentifierId)
				{
					return false;
				}
				switch (P_1.elementType)
				{
				case ControllerElementType.Axis:
				{
					AxisRange axisRange = P_1.axisRange;
					if (axisRange == AxisRange.Full)
					{
						return true;
					}
					if (axisRange == P_0.axisRange)
					{
						return true;
					}
					return false;
				}
				case ControllerElementType.Button:
					return true;
				default:
					throw new NotImplementedException();
				}
			}
		}

		internal sealed class BcsgzfiNbJVqGaXhVbRUQoXQjUG : wgiWmEBoGrEBAKMjuToBnVvTzZL
		{
			public BcsgzfiNbJVqGaXhVbRUQoXQjUG(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, OyJZlVlspSSqIjquoKnBSuwliGg target, IList<NolDTfvtsKbAKKAFyaBkjhVjxMvb> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Axis, target, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static BcsgzfiNbJVqGaXhVbRUQoXQjUG wDPkgttzlRAAdnlXproyhCFJCGW(IControllerTemplate P_0)
			{
				return new BcsgzfiNbJVqGaXhVbRUQoXQjUG(P_0, -1, string.Empty, string.Empty, string.Empty, OyJZlVlspSSqIjquoKnBSuwliGg.wDPkgttzlRAAdnlXproyhCFJCGW(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class swEhcufEMLgUZhjvUlomxFFPIQZ : wgiWmEBoGrEBAKMjuToBnVvTzZL
		{
			public swEhcufEMLgUZhjvUlomxFFPIQZ(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, OyJZlVlspSSqIjquoKnBSuwliGg target, IList<NolDTfvtsKbAKKAFyaBkjhVjxMvb> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Button, target, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static swEhcufEMLgUZhjvUlomxFFPIQZ wDPkgttzlRAAdnlXproyhCFJCGW(IControllerTemplate P_0)
			{
				return new swEhcufEMLgUZhjvUlomxFFPIQZ(P_0, -1, string.Empty, string.Empty, string.Empty, OyJZlVlspSSqIjquoKnBSuwliGg.wDPkgttzlRAAdnlXproyhCFJCGW(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class GuUXFxBVZcRZMpvzGbYxTDJLGEFA : sVxZtXOEFOIKGbskGYuCcZDzKWiD
		{
			protected readonly int miqLAIiHXdFucCNqFOcSCTFkdXH;

			protected readonly sVxZtXOEFOIKGbskGYuCcZDzKWiD[] omxIKEAXItSjJrzFPUwpagFQPsi;

			public override bool exists
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					for (int i = 0; i < miqLAIiHXdFucCNqFOcSCTFkdXH; i++)
					{
						if (omxIKEAXItSjJrzFPUwpagFQPsi[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return null;
				}
			}

			public override int elementCount => miqLAIiHXdFucCNqFOcSCTFkdXH;

			protected GuUXFxBVZcRZMpvzGbYxTDJLGEFA(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, elementType)
			{
				if (elements == null)
				{
					throw new ArgumentNullException("elements");
				}
				if (elements.Length == 0)
				{
					throw new ArgumentException("elements.Length is zero.");
				}
				for (int i = 0; i < elements.Length; i++)
				{
					if (elements[i] == null)
					{
						throw new ArgumentNullException("elements contains a null entry.");
					}
				}
				omxIKEAXItSjJrzFPUwpagFQPsi = elements;
				miqLAIiHXdFucCNqFOcSCTFkdXH = elements.Length;
			}

			public virtual IControllerTemplateElement mqLOUmOxEQDrMnAgTyphyrVuicA(int P_0)
			{
				return omxIKEAXItSjJrzFPUwpagFQPsi[P_0];
			}

			public virtual int aRPyUdMihEUTfdeZvQqFTaEeiWD(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < omxIKEAXItSjJrzFPUwpagFQPsi.Length; i++)
				{
					num += omxIKEAXItSjJrzFPUwpagFQPsi[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class uVzTnBKPfDmSxRhXiqOvbPJaiZlb : GuUXFxBVZcRZMpvzGbYxTDJLGEFA, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int OSJjZLBvdXhcCtyROIdChbmVcDy = 0;

			protected const int puYejeYTfaIoBjVQNtVeHuyrfiAh = 1;

			protected const int ArdukuaVHSljHgrgJuNPCFOcCgv = 2;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					return new Vector2((miqLAIiHXdFucCNqFOcSCTFkdXH > 0) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValue : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 1) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValue : 0f);
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					return new Vector2((miqLAIiHXdFucCNqFOcSCTFkdXH > 0) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValuePrev : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 1) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[1];
				}
			}

			protected uVzTnBKPfDmSxRhXiqOvbPJaiZlb(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class unpeOmiNMjFCMgoKoFISnzvdyOY : GuUXFxBVZcRZMpvzGbYxTDJLGEFA, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int OSJjZLBvdXhcCtyROIdChbmVcDy = 0;

			protected const int puYejeYTfaIoBjVQNtVeHuyrfiAh = 1;

			protected const int hEnCUaiPNJcsbQBLSYrKRFivaSX = 2;

			protected const int ArdukuaVHSljHgrgJuNPCFOcCgv = 3;

			public Vector3 value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector3.zero;
					}
					return new Vector3((miqLAIiHXdFucCNqFOcSCTFkdXH > 0) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValue : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 1) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValue : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 2) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[2]).floatValue : 0f);
				}
			}

			public Vector3 valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector3.zero;
					}
					return new Vector3((miqLAIiHXdFucCNqFOcSCTFkdXH > 0) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValuePrev : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 1) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValuePrev : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 2) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[2]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[1];
				}
			}

			public IControllerTemplateAxis depth
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[2];
				}
			}

			protected unpeOmiNMjFCMgoKoFISnzvdyOY(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class CNFAjiIBDHPLUybGDHyhAdkEPjUf : GuUXFxBVZcRZMpvzGbYxTDJLGEFA, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int aWdLSiJPfwVZKLMctdtWiWomaNG = 0;

			protected const int nSmDGiKcUSKwtYmePIPrynFRLRSX = 1;

			protected const int YsMrGgwEJLfeziJxVRNJBpyWTwoO = 2;

			protected const int pSCLoNGDVsKeZBEYGemUdFVCgSUa = 3;

			protected const int OxtycLPCDDXDqbMWWarqVRcZaWB = 4;

			protected const int EASnOocYKxXmwKdzCxCLJQCEWJM = 5;

			protected const int ArdukuaVHSljHgrgJuNPCFOcCgv = 6;

			public Vector3 position
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector3.zero;
					}
					return new Vector3((miqLAIiHXdFucCNqFOcSCTFkdXH > 0) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValue : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 1) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValue : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 2) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[2]).floatValue : 0f);
				}
			}

			public Vector3 positionPrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector3.zero;
					}
					return new Vector3((miqLAIiHXdFucCNqFOcSCTFkdXH > 0) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValuePrev : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 1) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValuePrev : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 2) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[2]).floatValuePrev : 0f);
				}
			}

			public Vector3 rotation
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector3.zero;
					}
					return new Vector3((miqLAIiHXdFucCNqFOcSCTFkdXH > 3) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[3]).floatValue : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 4) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[4]).floatValue : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 5) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[5]).floatValue : 0f);
				}
			}

			public Vector3 rotationPrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector3.zero;
					}
					return new Vector3((miqLAIiHXdFucCNqFOcSCTFkdXH > 3) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[3]).floatValuePrev : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 4) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[4]).floatValuePrev : 0f, (miqLAIiHXdFucCNqFOcSCTFkdXH > 5) ? ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[5]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis positionX
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[0];
				}
			}

			public IControllerTemplateAxis positionY
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[1];
				}
			}

			public IControllerTemplateAxis positionZ
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[2];
				}
			}

			public IControllerTemplateAxis rotationX
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[3];
				}
			}

			public IControllerTemplateAxis rotationY
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[4];
				}
			}

			public IControllerTemplateAxis rotationZ
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[5];
				}
			}

			protected CNFAjiIBDHPLUybGDHyhAdkEPjUf(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal sealed class CxXBAyFBajSUCSNfjbHfAQRGPMZ : unpeOmiNMjFCMgoKoFISnzvdyOY, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int ArdukuaVHSljHgrgJuNPCFOcCgv = 3;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[2];
				}
			}

			private CxXBAyFBajSUCSNfjbHfAQRGPMZ(IControllerTemplate parent, int id, string name, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick, elements)
			{
				if (elements.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public CxXBAyFBajSUCSNfjbHfAQRGPMZ(IControllerTemplate parent, int id, string name, wgiWmEBoGrEBAKMjuToBnVvTzZL xAxis, wgiWmEBoGrEBAKMjuToBnVvTzZL yAxis, wgiWmEBoGrEBAKMjuToBnVvTzZL zAxis)
				: this(parent, id, name, new sVxZtXOEFOIKGbskGYuCcZDzKWiD[3] { xAxis, yAxis, zAxis })
			{
			}
		}

		internal sealed class TJgfnGAdNCnkoFhCGMmgGDqSXFkn : uVzTnBKPfDmSxRhXiqOvbPJaiZlb, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int QVezLRYRrhLZcBYfcqBeHMUJdLmJ = 2;

			private new const int ArdukuaVHSljHgrgJuNPCFOcCgv = 3;

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[2];
				}
			}

			private TJgfnGAdNCnkoFhCGMmgGDqSXFkn(IControllerTemplate parent, int id, string name, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.ThumbStick, elements)
			{
				if (elements.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal TJgfnGAdNCnkoFhCGMmgGDqSXFkn(IControllerTemplate parent, int id, string name, wgiWmEBoGrEBAKMjuToBnVvTzZL xAxis, wgiWmEBoGrEBAKMjuToBnVvTzZL yAxis, wgiWmEBoGrEBAKMjuToBnVvTzZL button)
				: this(parent, id, name, new sVxZtXOEFOIKGbskGYuCcZDzKWiD[3] { xAxis, yAxis, button })
			{
			}
		}

		internal sealed class nQNXpNYAgNdvJahvmlLzgOekvbuc : GuUXFxBVZcRZMpvzGbYxTDJLGEFA, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int ACaiPWnfBzUFoCFpohQIHetXolOV = 0;

			private const int BRmeJQJJdMiMyOuAEShGbOnnkkb = 1;

			private const int jxaeYsHvgPsufFArGRYSTuCAysUh = 2;

			private const int XWMpAXkpjTurtIDxMSeoEXHISBw = 3;

			private const int fMjMmSioPBDKdcAKRjXZPfLKBDog = 4;

			private const int ArdukuaVHSljHgrgJuNPCFOcCgv = 5;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValue + ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[2]).floatValue * -1f, -1f, 1f), MathTools.Clamp(((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[3]).floatValue * -1f + ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValue, -1f, 1f));
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValuePrev + ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[2]).floatValuePrev * -1f, -1f, 1f), MathTools.Clamp(((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[3]).floatValuePrev * -1f + ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValuePrev, -1f, 1f));
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[0];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[1];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[2];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[3];
				}
			}

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[4];
				}
			}

			private nQNXpNYAgNdvJahvmlLzgOekvbuc(IControllerTemplate parent, int id, string name, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.DPad, elements)
			{
				if (elements.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal nQNXpNYAgNdvJahvmlLzgOekvbuc(IControllerTemplate parent, int id, string name, wgiWmEBoGrEBAKMjuToBnVvTzZL up, wgiWmEBoGrEBAKMjuToBnVvTzZL right, wgiWmEBoGrEBAKMjuToBnVvTzZL down, wgiWmEBoGrEBAKMjuToBnVvTzZL left, wgiWmEBoGrEBAKMjuToBnVvTzZL press)
				: this(parent, id, name, new sVxZtXOEFOIKGbskGYuCcZDzKWiD[5] { up, right, down, left, press })
			{
			}
		}

		internal sealed class kOxmoxVQSJStyFQFQvmiHLfaGkA : GuUXFxBVZcRZMpvzGbYxTDJLGEFA, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int hcYuKRHHpFYPjrmqcNRkwKulqYq = 0;

			private const int iDnbDMfVIJVlRMFmEeShsiLizDmA = 1;

			private const int ArdukuaVHSljHgrgJuNPCFOcCgv = 2;

			public float value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValue;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValuePrev;
				}
			}

			public IControllerTemplateAxis throttle
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[0];
				}
			}

			public IControllerTemplateButton minDetent
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[1];
				}
			}

			private kOxmoxVQSJStyFQFQvmiHLfaGkA(IControllerTemplate parent, int id, string name, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Throttle, elements)
			{
				if (elements.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal kOxmoxVQSJStyFQFQvmiHLfaGkA(IControllerTemplate parent, int id, string name, wgiWmEBoGrEBAKMjuToBnVvTzZL axis, wgiWmEBoGrEBAKMjuToBnVvTzZL zeroDetentButton)
				: this(parent, id, name, new sVxZtXOEFOIKGbskGYuCcZDzKWiD[2] { axis, zeroDetentButton })
			{
			}
		}

		internal sealed class DpJyllsDKrJYbeInJEEHtfrtKom : GuUXFxBVZcRZMpvzGbYxTDJLGEFA, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int ACaiPWnfBzUFoCFpohQIHetXolOV = 0;

			private const int uuYarrtuUFknVQvbgflKAPZJXzZ = 1;

			private const int BRmeJQJJdMiMyOuAEShGbOnnkkb = 2;

			private const int NVYrJYeWbPcpCrebBMIpmOenvZI = 3;

			private const int jxaeYsHvgPsufFArGRYSTuCAysUh = 4;

			private const int HzCYpAsEYreuUFmoCLXnmZDkdqS = 5;

			private const int XWMpAXkpjTurtIDxMSeoEXHISBw = 6;

			private const int eudGmqsnogLEVkaTGgEDDxWGVQEs = 7;

			private const int ArdukuaVHSljHgrgJuNPCFOcCgv = 8;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValue;
					result.x += ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[2]).floatValue;
					result.y -= ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[4]).floatValue;
					result.x -= ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[6]).floatValue;
					float floatValue = ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValue;
					float floatValue2 = ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[3]).floatValue;
					float floatValue3 = ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[5]).floatValue;
					float floatValue4 = ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[7]).floatValue;
					result.x += floatValue + floatValue2 - floatValue3 - floatValue4;
					result.y += floatValue + floatValue4 - floatValue2 - floatValue3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[0]).floatValuePrev;
					result.x += ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[2]).floatValuePrev;
					result.y -= ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[4]).floatValuePrev;
					result.x -= ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[6]).floatValuePrev;
					float floatValuePrev = ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[1]).floatValuePrev;
					float floatValuePrev2 = ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[3]).floatValuePrev;
					float floatValuePrev3 = ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[5]).floatValuePrev;
					float floatValuePrev4 = ((wgiWmEBoGrEBAKMjuToBnVvTzZL)omxIKEAXItSjJrzFPUwpagFQPsi[7]).floatValuePrev;
					result.x += floatValuePrev + floatValuePrev2 - floatValuePrev3 - floatValuePrev4;
					result.y += floatValuePrev + floatValuePrev4 - floatValuePrev2 - floatValuePrev3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[0];
				}
			}

			public IControllerTemplateButton upRight
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[1];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[2];
				}
			}

			public IControllerTemplateButton downRight
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[3];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[4];
				}
			}

			public IControllerTemplateButton downLeft
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[5];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[6];
				}
			}

			public IControllerTemplateButton upLeft
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateButton)omxIKEAXItSjJrzFPUwpagFQPsi[7];
				}
			}

			private DpJyllsDKrJYbeInJEEHtfrtKom(IControllerTemplate parent, int id, string name, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Hat, elements)
			{
				if (elements.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal DpJyllsDKrJYbeInJEEHtfrtKom(IControllerTemplate parent, int id, string name, wgiWmEBoGrEBAKMjuToBnVvTzZL up, wgiWmEBoGrEBAKMjuToBnVvTzZL upRight, wgiWmEBoGrEBAKMjuToBnVvTzZL right, wgiWmEBoGrEBAKMjuToBnVvTzZL downRight, wgiWmEBoGrEBAKMjuToBnVvTzZL down, wgiWmEBoGrEBAKMjuToBnVvTzZL downLeft, wgiWmEBoGrEBAKMjuToBnVvTzZL left, wgiWmEBoGrEBAKMjuToBnVvTzZL upLeft)
				: this(parent, id, name, new sVxZtXOEFOIKGbskGYuCcZDzKWiD[8] { up, upRight, right, downRight, down, downLeft, left, upLeft })
			{
			}
		}

		internal sealed class JhSMlYwytimEwKAzogzLZRkrcmLC : uVzTnBKPfDmSxRhXiqOvbPJaiZlb, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int ArdukuaVHSljHgrgJuNPCFOcCgv = 2;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[0];
				}
			}

			public IControllerTemplateAxis pushPull
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (IControllerTemplateAxis)omxIKEAXItSjJrzFPUwpagFQPsi[1];
				}
			}

			private JhSMlYwytimEwKAzogzLZRkrcmLC(IControllerTemplate parent, int id, string name, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, elements)
			{
			}

			internal JhSMlYwytimEwKAzogzLZRkrcmLC(IControllerTemplate parent, int id, string name, wgiWmEBoGrEBAKMjuToBnVvTzZL rollAxis, wgiWmEBoGrEBAKMjuToBnVvTzZL pitchAxis)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, new sVxZtXOEFOIKGbskGYuCcZDzKWiD[2] { rollAxis, pitchAxis })
			{
			}
		}

		internal sealed class zjHDJHKsWJdhmZSgsuTWTSsJNtO : CNFAjiIBDHPLUybGDHyhAdkEPjUf, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int ArdukuaVHSljHgrgJuNPCFOcCgv = 6;

			private zjHDJHKsWJdhmZSgsuTWTSsJNtO(IControllerTemplate parent, int id, string name, sVxZtXOEFOIKGbskGYuCcZDzKWiD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, elements)
			{
			}

			internal zjHDJHKsWJdhmZSgsuTWTSsJNtO(IControllerTemplate parent, int id, string name, wgiWmEBoGrEBAKMjuToBnVvTzZL positionX, wgiWmEBoGrEBAKMjuToBnVvTzZL positionY, wgiWmEBoGrEBAKMjuToBnVvTzZL positionZ, wgiWmEBoGrEBAKMjuToBnVvTzZL rotationX, wgiWmEBoGrEBAKMjuToBnVvTzZL rotationY, wgiWmEBoGrEBAKMjuToBnVvTzZL rotationZ)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, new sVxZtXOEFOIKGbskGYuCcZDzKWiD[6] { positionX, positionY, positionZ, rotationX, rotationY, rotationZ })
			{
			}
		}

		internal class NolDTfvtsKbAKKAFyaBkjhVjxMvb
		{
			public readonly Controller.Element PROiOPXLPssOzqJmzIHKLhOlSLw;

			public readonly IControllerElementTarget FGdfYZnSDUbKvZGpdheRKxuypZdG;

			public bool boolValue
			{
				get
				{
					if (PROiOPXLPssOzqJmzIHKLhOlSLw == null)
					{
						return false;
					}
					switch (PROiOPXLPssOzqJmzIHKLhOlSLw.type)
					{
					case ControllerElementType.Button:
						return (PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Axis).value;
						switch (FGdfYZnSDUbKvZGpdheRKxuypZdG.axisRange)
						{
						case AxisRange.Full:
							if (value > 0.01f)
							{
								return true;
							}
							if (value < -0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Positive:
							if (value > 0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Negative:
							if (value < -0.01f)
							{
								return true;
							}
							break;
						}
						break;
					}
					}
					return false;
				}
			}

			public bool boolValuePrev
			{
				get
				{
					if (PROiOPXLPssOzqJmzIHKLhOlSLw == null)
					{
						return false;
					}
					switch (PROiOPXLPssOzqJmzIHKLhOlSLw.type)
					{
					case ControllerElementType.Button:
						return (PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Axis).valuePrev;
						switch (FGdfYZnSDUbKvZGpdheRKxuypZdG.axisRange)
						{
						case AxisRange.Full:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							if (valuePrev < -0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Positive:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Negative:
							if (valuePrev < -0.01f)
							{
								return true;
							}
							break;
						}
						break;
					}
					}
					return false;
				}
			}

			public bool justPressed
			{
				get
				{
					if (PROiOPXLPssOzqJmzIHKLhOlSLw == null)
					{
						return false;
					}
					switch (PROiOPXLPssOzqJmzIHKLhOlSLw.type)
					{
					case ControllerElementType.Button:
						return (PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(floatValue) > 0.01f && MathTools.Abs(floatValuePrev) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (PROiOPXLPssOzqJmzIHKLhOlSLw == null)
					{
						return false;
					}
					switch (PROiOPXLPssOzqJmzIHKLhOlSLw.type)
					{
					case ControllerElementType.Button:
						return (PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(floatValue) <= 0.01f && MathTools.Abs(floatValuePrev) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float floatValue
			{
				get
				{
					if (PROiOPXLPssOzqJmzIHKLhOlSLw == null)
					{
						return 0f;
					}
					switch (PROiOPXLPssOzqJmzIHKLhOlSLw.type)
					{
					case ControllerElementType.Button:
						if (!(PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Axis).value;
						switch (FGdfYZnSDUbKvZGpdheRKxuypZdG.axisRange)
						{
						case AxisRange.Full:
							return value;
						case AxisRange.Positive:
							if (value > 0f)
							{
								return value;
							}
							break;
						case AxisRange.Negative:
							if (value < 0f)
							{
								return value;
							}
							break;
						}
						break;
					}
					}
					return 0f;
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (PROiOPXLPssOzqJmzIHKLhOlSLw == null)
					{
						return 0f;
					}
					switch (PROiOPXLPssOzqJmzIHKLhOlSLw.type)
					{
					case ControllerElementType.Button:
						if (!(PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (PROiOPXLPssOzqJmzIHKLhOlSLw as Controller.Axis).valuePrev;
						switch (FGdfYZnSDUbKvZGpdheRKxuypZdG.axisRange)
						{
						case AxisRange.Full:
							return valuePrev;
						case AxisRange.Positive:
							if (valuePrev > 0f)
							{
								return valuePrev;
							}
							break;
						case AxisRange.Negative:
							if (valuePrev < 0f)
							{
								return valuePrev;
							}
							break;
						}
						break;
					}
					}
					return 0f;
				}
			}

			public NolDTfvtsKbAKKAFyaBkjhVjxMvb(IControllerElementTarget target, Controller.Element element)
			{
				PROiOPXLPssOzqJmzIHKLhOlSLw = element;
				FGdfYZnSDUbKvZGpdheRKxuypZdG = target;
			}

			public static NolDTfvtsKbAKKAFyaBkjhVjxMvb wDPkgttzlRAAdnlXproyhCFJCGW()
			{
				return new NolDTfvtsKbAKKAFyaBkjhVjxMvb(rRNhjRpfbeHXdDjgkCEeGsrflVcU.wDPkgttzlRAAdnlXproyhCFJCGW(), null);
			}
		}

		internal class vJpxyzAPgFJpoYbgmnjsfIfNSQv
		{
			public readonly Controller FKtcxmBappHTSHGoccIYREwbpfog;

			public readonly IHardwareControllerTemplateMap_Internal KhTsCQhbWGiypOwfqcrHkLAfxVE;

			public vJpxyzAPgFJpoYbgmnjsfIfNSQv(Controller controller, IHardwareControllerTemplateMap_Internal templateMap)
			{
				if (controller == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (templateMap == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				FKtcxmBappHTSHGoccIYREwbpfog = controller;
				KhTsCQhbWGiypOwfqcrHkLAfxVE = templateMap;
			}
		}

		private readonly string qpIGvFaemznETzYbpRdmOKmaPCL;

		private readonly Guid FRIjVVLQpBHiXiVsnZsmHfmTOr;

		private readonly Controller frSJxBhFNALntnzeNKOcTHuHKsS;

		private readonly ADictionary<int, IControllerTemplateElement> CZKthKcQlIIuZtzsqmsbKljXmtt;

		private readonly ADictionary<string, IControllerTemplateElement> uelgSlZxQbcRxpbQTxWxLDkAzjI;

		private IControllerTemplateElement[] omxIKEAXItSjJrzFPUwpagFQPsi;

		private ReadOnlyCollection<IControllerTemplateElement> WOxVRRtZDKwuVNgdENoHiNyWQgT;

		private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return frSJxBhFNALntnzeNKOcTHuHKsS;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return qpIGvFaemznETzYbpRdmOKmaPCL;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Guid.Empty;
				}
				return FRIjVVLQpBHiXiVsnZsmHfmTOr;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return WOxVRRtZDKwuVNgdENoHiNyWQgT;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return omxIKEAXItSjJrzFPUwpagFQPsi.Length;
			}
		}

		protected ControllerTemplate(object payload)
			: this((vJpxyzAPgFJpoYbgmnjsfIfNSQv)payload)
		{
		}

		private ControllerTemplate(vJpxyzAPgFJpoYbgmnjsfIfNSQv initializer)
		{
			if (initializer == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (initializer.FKtcxmBappHTSHGoccIYREwbpfog == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (initializer.KhTsCQhbWGiypOwfqcrHkLAfxVE == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
			frSJxBhFNALntnzeNKOcTHuHKsS = initializer.FKtcxmBappHTSHGoccIYREwbpfog;
			IHardwareControllerTemplateMap_Internal khTsCQhbWGiypOwfqcrHkLAfxVE = initializer.KhTsCQhbWGiypOwfqcrHkLAfxVE;
			qpIGvFaemznETzYbpRdmOKmaPCL = khTsCQhbWGiypOwfqcrHkLAfxVE.name;
			FRIjVVLQpBHiXiVsnZsmHfmTOr = khTsCQhbWGiypOwfqcrHkLAfxVE.typeGuid;
			int elementIdentifierCount = khTsCQhbWGiypOwfqcrHkLAfxVE.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = khTsCQhbWGiypOwfqcrHkLAfxVE.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						OyJZlVlspSSqIjquoKnBSuwliGg oyJZlVlspSSqIjquoKnBSuwliGg2 = khTsCQhbWGiypOwfqcrHkLAfxVE.GetAxisTarget(frSJxBhFNALntnzeNKOcTHuHKsS, templateElementIdentifier.id) ?? OyJZlVlspSSqIjquoKnBSuwliGg.wDPkgttzlRAAdnlXproyhCFJCGW(ControllerTemplateElementType.Axis);
						BcsgzfiNbJVqGaXhVbRUQoXQjUG item2 = new BcsgzfiNbJVqGaXhVbRUQoXQjUG(this, templateElementIdentifier.id, templateElementIdentifier.name, (!string.IsNullOrEmpty(templateElementIdentifier.positiveName)) ? templateElementIdentifier.positiveName : (templateElementIdentifier.name + " +"), (!string.IsNullOrEmpty(templateElementIdentifier.negativeName)) ? templateElementIdentifier.negativeName : (templateElementIdentifier.name + " -"), oyJZlVlspSSqIjquoKnBSuwliGg2, FhaGBDqAnDyCElFCexvaKsntTCz(frSJxBhFNALntnzeNKOcTHuHKsS, (IControllerTemplateAxisSource)oyJZlVlspSSqIjquoKnBSuwliGg2));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						OyJZlVlspSSqIjquoKnBSuwliGg oyJZlVlspSSqIjquoKnBSuwliGg = khTsCQhbWGiypOwfqcrHkLAfxVE.GetButtonTarget(frSJxBhFNALntnzeNKOcTHuHKsS, templateElementIdentifier.id) ?? OyJZlVlspSSqIjquoKnBSuwliGg.wDPkgttzlRAAdnlXproyhCFJCGW(ControllerTemplateElementType.Button);
						swEhcufEMLgUZhjvUlomxFFPIQZ item = new swEhcufEMLgUZhjvUlomxFFPIQZ(this, templateElementIdentifier.id, templateElementIdentifier.name, templateElementIdentifier.name, templateElementIdentifier.name + " -", oyJZlVlspSSqIjquoKnBSuwliGg, FhaGBDqAnDyCElFCexvaKsntTCz(frSJxBhFNALntnzeNKOcTHuHKsS, (IControllerTemplateButtonSource)oyJZlVlspSSqIjquoKnBSuwliGg));
						list3.Add(item);
						break;
					}
					default:
						throw new NotImplementedException();
					}
				}
			}
			for (int j = 0; j < list2.Count; j++)
			{
				list.Add(list2[j]);
			}
			for (int k = 0; k < list3.Count; k++)
			{
				list.Add(list3[k]);
			}
			for (int l = 0; l < list.Count; l++)
			{
				aDictionary.Add(list[l].id, list[l]);
			}
			for (int m = 0; m < elementIdentifierCount; m++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier2 = khTsCQhbWGiypOwfqcrHkLAfxVE.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = khTsCQhbWGiypOwfqcrHkLAfxVE.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				sVxZtXOEFOIKGbskGYuCcZDzKWiD sVxZtXOEFOIKGbskGYuCcZDzKWiD2;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					sVxZtXOEFOIKGbskGYuCcZDzKWiD2 = new TJgfnGAdNCnkoFhCGMmgGDqSXFkn(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping5 != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping5.eid_axisX) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping5 != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping5.eid_axisY) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping5 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping5.eid_button) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					sVxZtXOEFOIKGbskGYuCcZDzKWiD2 = new nQNXpNYAgNdvJahvmlLzgOekvbuc(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping3 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping3.eid_up) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping3 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping3.eid_right) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping3 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping3.eid_down) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping3 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping3.eid_left) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping3 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping3.eid_press) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					sVxZtXOEFOIKGbskGYuCcZDzKWiD2 = new CxXBAyFBajSUCSNfjbHfAQRGPMZ(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping2 != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping2.eid_axisX) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping2 != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping2.eid_axisY) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping2 != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping2.eid_axisZ) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					sVxZtXOEFOIKGbskGYuCcZDzKWiD2 = new kOxmoxVQSJStyFQFQvmiHLfaGkA(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping6 != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping6.eid_axis) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping6 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping6.eid_minDetent) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					sVxZtXOEFOIKGbskGYuCcZDzKWiD2 = new DpJyllsDKrJYbeInJEEHtfrtKom(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping7 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping7.eid_up) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping7 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping7.eid_upRight) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping7 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping7.eid_right) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping7 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping7.eid_downRight) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping7 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping7.eid_down) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping7 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping7.eid_downLeft) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping7 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping7.eid_left) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping7 != null) ? tbTaqwCgVnCLKvHsvgjnjEDiwyz(this, aDictionary, mapping7.eid_upLeft) : swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					sVxZtXOEFOIKGbskGYuCcZDzKWiD2 = new JhSMlYwytimEwKAzogzLZRkrcmLC(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping4 != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping4.eid_axisX) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping4 != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping4.eid_axisZ) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					sVxZtXOEFOIKGbskGYuCcZDzKWiD2 = new zjHDJHKsWJdhmZSgsuTWTSsJNtO(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping.eid_positionX) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping.eid_positionY) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping.eid_positionZ) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping.eid_rotationX) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping.eid_rotationY) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this), (mapping != null) ? QSaubHtGggZtiyCTYYzekClRWIA(this, aDictionary, mapping.eid_rotationZ) : BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (sVxZtXOEFOIKGbskGYuCcZDzKWiD2 != null)
				{
					list4.Add(sVxZtXOEFOIKGbskGYuCcZDzKWiD2);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			omxIKEAXItSjJrzFPUwpagFQPsi = list.ToArray();
			CZKthKcQlIIuZtzsqmsbKljXmtt = aDictionary;
			uelgSlZxQbcRxpbQTxWxLDkAzjI = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < omxIKEAXItSjJrzFPUwpagFQPsi.Length; num++)
			{
				if (!(khTsCQhbWGiypOwfqcrHkLAfxVE.GetTemplateElementIdentifierById(omxIKEAXItSjJrzFPUwpagFQPsi[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
				{
					continue;
				}
				for (int num2 = 0; num2 < 2; num2++)
				{
					string text = ((num2 != 0) ? controllerTemplateElementIdentifier_Editor.alternateScriptingName : controllerTemplateElementIdentifier_Editor.scriptingName);
					if (!string.IsNullOrEmpty(text))
					{
						try
						{
							uelgSlZxQbcRxpbQTxWxLDkAzjI.Add(text, omxIKEAXItSjJrzFPUwpagFQPsi[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + qpIGvFaemznETzYbpRdmOKmaPCL + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			WOxVRRtZDKwuVNgdENoHiNyWQgT = new ReadOnlyCollection<IControllerTemplateElement>(omxIKEAXItSjJrzFPUwpagFQPsi);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!CZKthKcQlIIuZtzsqmsbKljXmtt.TryGetValue(id, out var value))
			{
				Logger.LogWarning("There is no element with the id \"" + id + "\" in the " + GetType().ToString() + ".");
			}
			return value;
		}

		protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
		{
			return GetElement(id) as T;
		}

		private IControllerTemplateElement hRrTsMFWDtBcsCvqFAlIJsNMrhe(int P_0)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return GetElement(P_0);
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hRrTsMFWDtBcsCvqFAlIJsNMrhe
			return this.hRrTsMFWDtBcsCvqFAlIJsNMrhe(P_0);
		}

		private T hRrTsMFWDtBcsCvqFAlIJsNMrhe<T>(int P_0) where T : class, IControllerTemplateElement
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return GetElement<T>(P_0);
		}

		T IControllerTemplate.GetElement<T>(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hRrTsMFWDtBcsCvqFAlIJsNMrhe
			return this.hRrTsMFWDtBcsCvqFAlIJsNMrhe<T>(P_0);
		}

		private int ysJXwSViKBtKVegskUKDpZTciae(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			return aRPyUdMihEUTfdeZvQqFTaEeiWD(P_0, ref P_1);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ysJXwSViKBtKVegskUKDpZTciae
			return this.ysJXwSViKBtKVegskUKDpZTciae(P_0, P_1);
		}

		private int aRPyUdMihEUTfdeZvQqFTaEeiWD(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
		{
			if (P_1 != null)
			{
				P_1.Clear();
			}
			int num = 0;
			for (int i = 0; i < omxIKEAXItSjJrzFPUwpagFQPsi.Length; i++)
			{
				if (InputTools.IsMappableType(omxIKEAXItSjJrzFPUwpagFQPsi[i].type))
				{
					num += (omxIKEAXItSjJrzFPUwpagFQPsi[i] as IControllerTemplateElement_Internal).GetElementTargets(P_0, ref P_1);
				}
			}
			return num;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			return elementType switch
			{
				ControllerTemplateElementType.Axis => typeof(IControllerTemplateAxis), 
				ControllerTemplateElementType.Button => typeof(IControllerTemplateButton), 
				ControllerTemplateElementType.ThumbStick => typeof(IControllerTemplateThumbStick), 
				ControllerTemplateElementType.DPad => typeof(IControllerTemplateDPad), 
				ControllerTemplateElementType.Stick => typeof(IControllerTemplateStick), 
				ControllerTemplateElementType.Throttle => typeof(IControllerTemplateThrottle), 
				ControllerTemplateElementType.Hat => typeof(IControllerTemplateHat), 
				ControllerTemplateElementType.Yoke => typeof(IControllerTemplateYoke), 
				ControllerTemplateElementType.Stick6D => typeof(IControllerTemplateStick6D), 
				_ => throw new NotImplementedException(), 
			};
		}

		private static IList<NolDTfvtsKbAKKAFyaBkjhVjxMvb> FhaGBDqAnDyCElFCexvaKsntTCz(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<NolDTfvtsKbAKKAFyaBkjhVjxMvb> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new NolDTfvtsKbAKKAFyaBkjhVjxMvb(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, NolDTfvtsKbAKKAFyaBkjhVjxMvb.wDPkgttzlRAAdnlXproyhCFJCGW());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new NolDTfvtsKbAKKAFyaBkjhVjxMvb(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, NolDTfvtsKbAKKAFyaBkjhVjxMvb.wDPkgttzlRAAdnlXproyhCFJCGW());
				}
				return list;
			}
			return FhaGBDqAnDyCElFCexvaKsntTCz(P_0, P_1.fullTarget);
		}

		private static IList<NolDTfvtsKbAKKAFyaBkjhVjxMvb> FhaGBDqAnDyCElFCexvaKsntTCz(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return FhaGBDqAnDyCElFCexvaKsntTCz(P_0, P_1.target);
		}

		private static IList<NolDTfvtsKbAKKAFyaBkjhVjxMvb> FhaGBDqAnDyCElFCexvaKsntTCz(Controller P_0, IControllerElementTarget P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			Controller.Element elementById = P_0.GetElementById(P_1.elementIdentifierId);
			if (elementById == null)
			{
				return null;
			}
			List<NolDTfvtsKbAKKAFyaBkjhVjxMvb> list = new List<NolDTfvtsKbAKKAFyaBkjhVjxMvb>();
			list.Add(new NolDTfvtsKbAKKAFyaBkjhVjxMvb(P_1, elementById));
			return list;
		}

		private static IControllerTemplateElement fwbDaChzymRXvBFGPgTvfaASCmdT(List<IControllerTemplateElement> P_0, int P_1)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i].id == P_1)
				{
					return P_0[i];
				}
			}
			return null;
		}

		private static wgiWmEBoGrEBAKMjuToBnVvTzZL QSaubHtGggZtiyCTYYzekClRWIA(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is wgiWmEBoGrEBAKMjuToBnVvTzZL result))
			{
				return BcsgzfiNbJVqGaXhVbRUQoXQjUG.wDPkgttzlRAAdnlXproyhCFJCGW(P_0);
			}
			return result;
		}

		private static wgiWmEBoGrEBAKMjuToBnVvTzZL tbTaqwCgVnCLKvHsvgjnjEDiwyz(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is wgiWmEBoGrEBAKMjuToBnVvTzZL result))
			{
				return swEhcufEMLgUZhjvUlomxFFPIQZ.wDPkgttzlRAAdnlXproyhCFJCGW(P_0);
			}
			return result;
		}
	}
}
