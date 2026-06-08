using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int qxoYaUQyNIsvDIFklnqXHPrHJLd = -1;

			private ControllerMap FcwxSEAqxlQQhiIiSEyJjkwZaAa;

			private ActionElementMap eouBCOJWSKVOOLCgVSQaapKPlmF;

			private AxisRange AjHPmuUkudbUaCaQQgjlYFMJlCCn = AxisRange.Positive;

			private bool yUyawoDmbmvqRHFODQrxsVStOAB;

			public int actionId
			{
				get
				{
					return qxoYaUQyNIsvDIFklnqXHPrHJLd;
				}
				set
				{
					if (!udAMddxnAAvKCfofyUgsUjZGlSf())
					{
						qxoYaUQyNIsvDIFklnqXHPrHJLd = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(qxoYaUQyNIsvDIFklnqXHPrHJLd);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (udAMddxnAAvKCfofyUgsUjZGlSf())
					{
						goto IL_0008;
					}
					goto IL_007c;
					IL_0008:
					int num = 810937638;
					goto IL_000d;
					IL_000d:
					InputAction action = default(InputAction);
					while (true)
					{
						switch (num ^ 0x3055ED23)
						{
						case 0:
							break;
						default:
							return;
						case 5:
							return;
						case 4:
							qxoYaUQyNIsvDIFklnqXHPrHJLd = action.id;
							num = 810937634;
							continue;
						case 3:
							return;
						case 2:
							qxoYaUQyNIsvDIFklnqXHPrHJLd = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
							num = 810937632;
							continue;
						case 6:
							goto IL_007c;
						case 1:
							return;
						}
						break;
					}
					goto IL_0008;
					IL_007c:
					action = ReInput.mapping.GetAction(value);
					int num2;
					if (action == null)
					{
						num = 810937633;
						num2 = num;
					}
					else
					{
						num = 810937639;
						num2 = num;
					}
					goto IL_000d;
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return FcwxSEAqxlQQhiIiSEyJjkwZaAa;
				}
				set
				{
					if (udAMddxnAAvKCfofyUgsUjZGlSf())
					{
						return;
					}
					while (true)
					{
						FcwxSEAqxlQQhiIiSEyJjkwZaAa = value;
						int num = 2005308697;
						while (true)
						{
							switch (num ^ 0x77869519)
							{
							case 2:
								goto IL_0009;
							default:
								return;
							case 1:
								break;
							case 0:
								return;
							}
							break;
							IL_0009:
							num = 2005308696;
						}
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return eouBCOJWSKVOOLCgVSQaapKPlmF;
				}
				set
				{
					if (!udAMddxnAAvKCfofyUgsUjZGlSf())
					{
						eouBCOJWSKVOOLCgVSQaapKPlmF = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return AjHPmuUkudbUaCaQQgjlYFMJlCCn;
				}
				set
				{
					if (udAMddxnAAvKCfofyUgsUjZGlSf())
					{
						return;
					}
					while (true)
					{
						AjHPmuUkudbUaCaQQgjlYFMJlCCn = value;
						int num = -369663339;
						while (true)
						{
							switch (num ^ -369663340)
							{
							case 0:
								goto IL_0009;
							default:
								return;
							case 2:
								break;
							case 1:
								return;
							}
							break;
							IL_0009:
							num = -369663338;
						}
					}
				}
			}

			public Context()
			{
			}

			private Context(Context source)
				: this()
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				Copy(source, this);
			}

			public Context Clone()
			{
				return new Context(this);
			}

			internal void pKQjimPFOYEhwfoUwiExuudUivJD()
			{
				yUyawoDmbmvqRHFODQrxsVStOAB = true;
			}

			private bool udAMddxnAAvKCfofyUgsUjZGlSf()
			{
				if (yUyawoDmbmvqRHFODQrxsVStOAB)
				{
					Logger.LogError("Context is read-only and cannot be modified after Input Mapper has been started.");
					return true;
				}
				return false;
			}

			public static void Copy(Context source, Context destination)
			{
				if (source == null)
				{
					goto IL_0003;
				}
				goto IL_003b;
				IL_0003:
				int num = 1622036158;
				goto IL_0008;
				IL_0008:
				switch (num ^ 0x60AE4EBF)
				{
				case 2:
					break;
				case 1:
					throw new ArgumentNullException("source");
				case 3:
					goto IL_003b;
				case 4:
					goto IL_0050;
				default:
					destination.AjHPmuUkudbUaCaQQgjlYFMJlCCn = source.AjHPmuUkudbUaCaQQgjlYFMJlCCn;
					return;
				}
				goto IL_0003;
				IL_0050:
				destination.qxoYaUQyNIsvDIFklnqXHPrHJLd = source.qxoYaUQyNIsvDIFklnqXHPrHJLd;
				destination.FcwxSEAqxlQQhiIiSEyJjkwZaAa = source.FcwxSEAqxlQQhiIiSEyJjkwZaAa;
				destination.eouBCOJWSKVOOLCgVSQaapKPlmF = source.eouBCOJWSKVOOLCgVSQaapKPlmF;
				num = 1622036159;
				goto IL_0008;
				IL_003b:
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				goto IL_0050;
			}
		}

		public enum ConflictResponse
		{
			Cancel = 0,
			Replace = 1,
			Add = 2,
			Ignore = 3
		}

		public abstract class EventData
		{
			public readonly InputMapper inputMapper;

			internal EventData(InputMapper inputMapper)
			{
				this.inputMapper = inputMapper;
			}
		}

		public class InputMappedEventData : EventData
		{
			public readonly ActionElementMap actionElementMap;

			internal InputMappedEventData(InputMapper mapper, ActionElementMap actionElementMap)
				: base(mapper)
			{
				this.actionElementMap = actionElementMap;
			}
		}

		public class CanceledEventData : EventData
		{
			public readonly string message;

			internal CanceledEventData(InputMapper mapper, string message)
				: base(mapper)
			{
				while (true)
				{
					int num = -564445098;
					while (true)
					{
						switch (num ^ -564445100)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0025;
						case 1:
							return;
						}
						break;
						IL_0025:
						this.message = message;
						num = -564445099;
					}
				}
			}
		}

		public class ErrorEventData : EventData
		{
			public readonly string message;

			internal ErrorEventData(InputMapper mapper, string message)
				: base(mapper)
			{
				this.message = message;
			}
		}

		public class TimedOutEventData : EventData
		{
			internal TimedOutEventData(InputMapper mapper)
				: base(mapper)
			{
			}
		}

		public class StartedEventData : EventData
		{
			internal StartedEventData(InputMapper mapper)
				: base(mapper)
			{
			}
		}

		public class StoppedEventData : EventData
		{
			internal StoppedEventData(InputMapper mapper)
				: base(mapper)
			{
			}
		}

		public class ConflictFoundEventData : EventData
		{
			public readonly Action<ConflictResponse> responseCallback;

			public readonly ElementAssignmentInfo assignment;

			public readonly IList<ElementAssignmentConflictInfo> conflicts;

			public readonly bool isProtected;

			internal ConflictFoundEventData(InputMapper mapper, Action<ConflictResponse> responseCallback, ElementAssignmentInfo assignment, IList<ElementAssignmentConflictInfo> conflicts, bool isProtected)
				: base(mapper)
			{
				while (true)
				{
					int num = 1716230549;
					while (true)
					{
						switch (num ^ 0x664B9994)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
							this.assignment = assignment;
							this.conflicts = conflicts;
							this.isProtected = isProtected;
							return;
						}
						break;
						IL_0025:
						this.responseCallback = responseCallback;
						num = 1716230548;
					}
				}
			}
		}

		private enum ScGjCehqJbLHTgNXcKmfFYCwKZJp
		{
			UWHKuObharcWmREwTRfXxbHHaMG = 0,
			ZtUwsrwXzuJnuLzcmZfjeVDsJIY = 1,
			aINsxdepuysANqyrNfBHMmbfpCs = 2,
			FZMOQWNOeHtGxdPTCjkbKhypcZrH = 3,
			ABchwhDllxYJyZPlcZPhoqaCCBl = 4,
			GcfjljcglleFSsSWstdsMiSqqXV = 5,
			BnoGDRJVJJkmalzbYKviQcGpYaW = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class daUybjwOixexSGMKtqpHUdttZhkL
		{
			private enum IbWFlWDuuTwCtSbjipSXSXaKpng
			{
				zEbQSWrljsQrYcFYvEzvbxmAFlgp = 0,
				phEfcHmOUEqIkRBNHmZwuZOVNOp = 1
			}

			private enum mrxVUraOKWQMkggMlSNCDLwZMdz
			{
				XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
				vwEjYoLhWdDSHmDBYHxTpSpUXtC = 1
			}

			private class hiwSVdgTkncDRwEPXOTHGxfrnPJ
			{
				private Player gPwfZkeassnAZjQOgQSROFcEjaCL;

				private int qxoYaUQyNIsvDIFklnqXHPrHJLd;

				private Context julpBgNuOdWOsnBlqfgXBMiRLQb;

				private ControllerType fkEwyowpQQKzBaGTBxLUNmLjHtN;

				private int vnEdenUwZllTYBycKwkNdiMcIIS;

				private ControllerPollingInfo vntxbqHTMmJOFosWorJYrSEEXF;

				private ModifierKeyFlags YfXbVhhWcSuyNKacqoMLhXaiabR;

				public Player player => gPwfZkeassnAZjQOgQSROFcEjaCL;

				public int actionId => qxoYaUQyNIsvDIFklnqXHPrHJLd;

				public Context mappingContext => julpBgNuOdWOsnBlqfgXBMiRLQb;

				public ControllerType controllerType => fkEwyowpQQKzBaGTBxLUNmLjHtN;

				public int controllerId => vnEdenUwZllTYBycKwkNdiMcIIS;

				public ControllerPollingInfo pollingInfo => vntxbqHTMmJOFosWorJYrSEEXF;

				public ModifierKeyFlags modifierKeyFlags => YfXbVhhWcSuyNKacqoMLhXaiabR;

				public AxisRange axisRange
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
						while (true)
						{
							int num = -1046422123;
							while (true)
							{
								switch (num ^ -1046422126)
								{
								case 3:
									break;
								case 4:
									result = ((pollingInfo.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
									num = -1046422125;
									continue;
								case 0:
									num = -1046422125;
									continue;
								case 7:
									controllerPollingInfo = pollingInfo;
									num = -1046422124;
									continue;
								case 6:
								{
									int num3;
									if (controllerPollingInfo.elementType != ControllerElementType.Axis)
									{
										num = -1046422125;
										num3 = num;
									}
									else
									{
										num = -1046422128;
										num3 = num;
									}
									continue;
								}
								case 5:
									result = AxisRange.Full;
									num = -1046422126;
									continue;
								case 2:
								{
									int num2;
									if (julpBgNuOdWOsnBlqfgXBMiRLQb.actionRange == AxisRange.Full)
									{
										num = -1046422121;
										num2 = num;
									}
									else
									{
										num = -1046422122;
										num2 = num;
									}
									continue;
								}
								default:
									return result;
								}
								break;
							}
						}
					}
				}

				public string elementName
				{
					get
					{
						if (controllerType == ControllerType.Keyboard && modifierKeyFlags != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(modifierKeyFlags)} + {pollingInfo.elementIdentifierName}";
						}
						string text = pollingInfo.elementIdentifierName;
						while (true)
						{
							int num = -2002901945;
							while (true)
							{
								switch (num ^ -2002901948)
								{
								case 0:
									break;
								case 3:
									if (pollingInfo.elementType == ControllerElementType.Axis)
									{
										if (axisRange == AxisRange.Positive)
										{
											text += " +";
											num = -2002901947;
											continue;
										}
										goto case 2;
									}
									goto default;
								case 2:
									if (axisRange == AxisRange.Negative)
									{
										text += " -";
										num = -2002901947;
										continue;
									}
									goto default;
								default:
									return text;
								}
								break;
							}
						}
					}
				}

				public void SdmfoteCDVoXNaSlWEvRMBbwmDy(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					while (true)
					{
						tAgADqjTsMUxSqYXeDyJIdETYRAp();
						int num = 57107951;
						while (true)
						{
							switch (num ^ 0x36765EC)
							{
							case 0:
								num = 57107950;
								continue;
							case 2:
								break;
							case 3:
								gPwfZkeassnAZjQOgQSROFcEjaCL = P_0;
								qxoYaUQyNIsvDIFklnqXHPrHJLd = P_1.actionId;
								fkEwyowpQQKzBaGTBxLUNmLjHtN = P_1.controllerMap.controllerType;
								vnEdenUwZllTYBycKwkNdiMcIIS = P_1.controllerMap.controllerId;
								julpBgNuOdWOsnBlqfgXBMiRLQb = P_1;
								fkEwyowpQQKzBaGTBxLUNmLjHtN = P_1.controllerMap.controllerType;
								vnEdenUwZllTYBycKwkNdiMcIIS = P_1.controllerMap.controllerId;
								num = 57107949;
								continue;
							default:
								P_1.pKQjimPFOYEhwfoUwiExuudUivJD();
								return;
							}
							break;
						}
					}
				}

				public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
				{
					gPwfZkeassnAZjQOgQSROFcEjaCL = null;
					qxoYaUQyNIsvDIFklnqXHPrHJLd = -1;
					julpBgNuOdWOsnBlqfgXBMiRLQb = null;
					fkEwyowpQQKzBaGTBxLUNmLjHtN = ControllerType.Keyboard;
					vnEdenUwZllTYBycKwkNdiMcIIS = -1;
					vntxbqHTMmJOFosWorJYrSEEXF = default(ControllerPollingInfo);
					YfXbVhhWcSuyNKacqoMLhXaiabR = ModifierKeyFlags.None;
				}

				public ElementAssignment TZQuKgxHxINNqyCfDdLrjESbRmCo(ControllerPollingInfo P_0)
				{
					vntxbqHTMmJOFosWorJYrSEEXF = P_0;
					return TZQuKgxHxINNqyCfDdLrjESbRmCo();
				}

				public ElementAssignment TZQuKgxHxINNqyCfDdLrjESbRmCo(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					vntxbqHTMmJOFosWorJYrSEEXF = P_0;
					YfXbVhhWcSuyNKacqoMLhXaiabR = P_1;
					return TZQuKgxHxINNqyCfDdLrjESbRmCo();
				}

				public ElementAssignment TZQuKgxHxINNqyCfDdLrjESbRmCo()
				{
					return new ElementAssignment(controllerType, vntxbqHTMmJOFosWorJYrSEEXF.elementType, vntxbqHTMmJOFosWorJYrSEEXF.elementIdentifierId, axisRange, vntxbqHTMmJOFosWorJYrSEEXF.keyboardKey, YfXbVhhWcSuyNKacqoMLhXaiabR, qxoYaUQyNIsvDIFklnqXHPrHJLd, (julpBgNuOdWOsnBlqfgXBMiRLQb.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, invert: false, (julpBgNuOdWOsnBlqfgXBMiRLQb.actionElementMapToReplace != null) ? julpBgNuOdWOsnBlqfgXBMiRLQb.actionElementMapToReplace.id : (-1));
				}
			}

			private readonly InputMapper ZcHJtpUHuctAcnqSflrxCAOupGj;

			private readonly Options KzCUiawVxPrFPXkDhBSZNsDIaLv = new Options();

			private readonly hiwSVdgTkncDRwEPXOTHGxfrnPJ cPVAKFeyxMEfqfqaoCTorALFqDOc = new hiwSVdgTkncDRwEPXOTHGxfrnPJ();

			private readonly Dictionary<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate> pGOgISGmzqLUgLQoxeyCGBYLDXUk;

			private readonly Dictionary<string, SafeDelegate> nTtGkrwuEYqKbZpiWdPlhNclOFXk;

			private Status eSInhTAigaqzirlKBZDnfWuZpmC;

			private mrxVUraOKWQMkggMlSNCDLwZMdz FNwofgjNrmPRPxCGUpdKZDdJYTB;

			private double bbAzXbTKHckGyRxoHHwNHchbXzf;

			private bool BIJbswxmHZfgkIifPloPdbZterlf;

			private List<Player> FPlhXdvEeMmeMLLXsDPfvRAlgBU = new List<Player>();

			private readonly List<ControllerPollingInfo> afsEvhjtvtFoWTKfvuddVqbsezQ = new List<ControllerPollingInfo>();

			private ElementAssignment PyhTyIsXuhJgPhngyfsxjdLyXbxP;

			public Status status => eSInhTAigaqzirlKBZDnfWuZpmC;

			public float timeRemaining
			{
				get
				{
					if (eSInhTAigaqzirlKBZDnfWuZpmC == Status.Idle)
					{
						return 0f;
					}
					if (KzCUiawVxPrFPXkDhBSZNsDIaLv.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, bbAzXbTKHckGyRxoHHwNHchbXzf + (double)KzCUiawVxPrFPXkDhBSZNsDIaLv.timeout - ReInput.unscaledTime);
				}
			}

			public Context context
			{
				get
				{
					if (eSInhTAigaqzirlKBZDnfWuZpmC == Status.Idle)
					{
						return null;
					}
					return cPVAKFeyxMEfqfqaoCTorALFqDOc.mappingContext;
				}
			}

			private bool checkTimer
			{
				get
				{
					if (BIJbswxmHZfgkIifPloPdbZterlf)
					{
						return false;
					}
					if (!(KzCUiawVxPrFPXkDhBSZNsDIaLv.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public daUybjwOixexSGMKtqpHUdttZhkL(InputMapper parent, Dictionary<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate> events)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (events == null)
				{
					throw new ArgumentNullException("events");
				}
				ZcHJtpUHuctAcnqSflrxCAOupGj = parent;
				pGOgISGmzqLUgLQoxeyCGBYLDXUk = events;
				SzVBYfzbaWIKmEuGhrHZnyHUdDX();
			}

			~daUybjwOixexSGMKtqpHUdttZhkL()
			{
				yZNQlKaRQXMrTuFffDONHMEhgPXx();
			}

			public void NoiITHOkBgdirKSZopWLLfLYZOJ(Context P_0, Options P_1)
			{
				if (eSInhTAigaqzirlKBZDnfWuZpmC != Status.Idle)
				{
					goto IL_000b;
				}
				goto IL_0117;
				IL_000b:
				int num = -1590088853;
				goto IL_0010;
				IL_0010:
				Player player = default(Player);
				while (true)
				{
					switch (num ^ -1590088850)
					{
					case 6:
						break;
					case 0:
						goto IL_0044;
					case 2:
						cPVAKFeyxMEfqfqaoCTorALFqDOc.SdmfoteCDVoXNaSlWEvRMBbwmDy(player, P_0);
						eSInhTAigaqzirlKBZDnfWuZpmC = Status.Listening;
						num = -1590088855;
						continue;
					case 3:
						if (ReInput.mapping.GetAction(P_0.actionId) == null)
						{
							TXbaTLHoDuZJZGChosMqvmCUBrSi("No Action found for actionId: " + P_0.actionId);
							return;
						}
						goto case 2;
					case 4:
						goto IL_00b6;
					case 5:
						JQVaToGvCEZETStIKyUHLwgPjCC("User started a new listening session.");
						num = -1590088858;
						continue;
					case 1:
						goto IL_00ff;
					case 8:
						goto IL_0117;
					default:
						BcbbceSEftXnUnpLWASmAEcUgnMO();
						ktDBntjbFnvTnmtaFBpLkuaYPMn();
						YrTxeMoLundvWLepDHpoCyMernAC();
						NiYrImCUnLKeUAyAIKghVwMCcFe();
						return;
					}
					break;
				}
				goto IL_000b;
				IL_0044:
				if (P_0.controllerMap == null)
				{
					throw new ArgumentNullException("controllerMap");
				}
				goto IL_00ff;
				IL_00b6:
				P_0 = P_0.Clone();
				Options.Copy(P_1, KzCUiawVxPrFPXkDhBSZNsDIaLv);
				player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				num = -1590088851;
				goto IL_0010;
				IL_00ff:
				if (P_1 == null)
				{
					throw new ArgumentNullException("options");
				}
				goto IL_00b6;
				IL_0117:
				if (P_0 == null)
				{
					throw new ArgumentNullException("context");
				}
				goto IL_0044;
			}

			public void LMUxrvabDmlOyshBlFENjJpzElf(string P_0)
			{
				if (eSInhTAigaqzirlKBZDnfWuZpmC != Status.Idle)
				{
					JQVaToGvCEZETStIKyUHLwgPjCC(P_0);
				}
			}

			private void GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
			{
				if (P_0 != UpdateLoopType.Update)
				{
					return;
				}
				ElementAssignment elementAssignment = default(ElementAssignment);
				while (eSInhTAigaqzirlKBZDnfWuZpmC == Status.Listening)
				{
					while (true)
					{
						IL_00bd:
						if (!checkTimer || !(timeRemaining <= 0f))
						{
							while (true)
							{
								IL_004e:
								Controller controller = ReInput.controllers.GetController(cPVAKFeyxMEfqfqaoCTorALFqDOc.controllerType, cPVAKFeyxMEfqfqaoCTorALFqDOc.controllerId);
								int num;
								int num2;
								if (controller == null)
								{
									num = -186455192;
									num2 = num;
								}
								else
								{
									num = -186455187;
									num2 = num;
								}
								while (true)
								{
									switch (num ^ -186455185)
									{
									case 8:
										num = -186455186;
										continue;
									default:
										return;
									case 1:
										break;
									case 6:
										goto IL_004e;
									case 3:
										if (ewXhdUsLdymdNzSdIDTbPgCsrnm(elementAssignment) == IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp)
										{
											return;
										}
										goto case 0;
									case 0:
										PdMprecJqNvqACEDUySddpTJTAG(elementAssignment);
										num = -186455189;
										continue;
									case 2:
										if (dTbGBBjEDxGdjHpMbPAtDOVNCRDW(out elementAssignment) == IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp)
										{
											return;
										}
										goto case 3;
									case 5:
										goto IL_00bd;
									case 7:
										TXbaTLHoDuZJZGChosMqvmCUBrSi(string.Concat("Controller not found for type: ", cPVAKFeyxMEfqfqaoCTorALFqDOc.controllerType, " id: ", cPVAKFeyxMEfqfqaoCTorALFqDOc.controllerId));
										return;
									case 4:
										return;
									}
									break;
								}
								break;
							}
							break;
						}
						kLxGiphiRUPKKDrdkAMHgfhFrkow();
						return;
					}
				}
			}

			private void AsLGHAVbjPEacNmJeQPEsuzzptZ()
			{
				if (eSInhTAigaqzirlKBZDnfWuZpmC != Status.Idle)
				{
					SzVBYfzbaWIKmEuGhrHZnyHUdDX();
					yZNQlKaRQXMrTuFffDONHMEhgPXx();
					EnQBDdzqXfYmioIiwuucwWViODd();
				}
			}

			private void SzVBYfzbaWIKmEuGhrHZnyHUdDX()
			{
				eSInhTAigaqzirlKBZDnfWuZpmC = Status.Idle;
				bbAzXbTKHckGyRxoHHwNHchbXzf = 0.0;
				KzCUiawVxPrFPXkDhBSZNsDIaLv.tAgADqjTsMUxSqYXeDyJIdETYRAp();
				cPVAKFeyxMEfqfqaoCTorALFqDOc.tAgADqjTsMUxSqYXeDyJIdETYRAp();
				PyhTyIsXuhJgPhngyfsxjdLyXbxP = default(ElementAssignment);
				FNwofgjNrmPRPxCGUpdKZDdJYTB = mrxVUraOKWQMkggMlSNCDLwZMdz.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
				BIJbswxmHZfgkIifPloPdbZterlf = false;
				FPlhXdvEeMmeMLLXsDPfvRAlgBU.Clear();
			}

			private IbWFlWDuuTwCtSbjipSXSXaKpng dTbGBBjEDxGdjHpMbPAtDOVNCRDW(out ElementAssignment P_0)
			{
				if (!lCldeWjMAuMryDZJKDjctVNZDsm(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					goto IL_0013;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				int num = -706030471;
				goto IL_0018;
				IL_0018:
				int num5;
				switch (num ^ -706030471)
				{
				case 2:
					break;
				case 1:
					return IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp;
				default:
					{
						using (IEnumerator<ControllerPollingInfo> enumerator = enumerable.GetEnumerator())
						{
							ControllerPollingInfo current = default(ControllerPollingInfo);
							while (true)
							{
								IL_0072:
								int num2;
								int num3;
								if (enumerator.MoveNext())
								{
									num2 = -706030472;
									num3 = num2;
								}
								else
								{
									num2 = -706030467;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ -706030471)
									{
									case 3:
										num2 = -706030472;
										continue;
									default:
										goto end_IL_0051;
									case 0:
										break;
									case 2:
										if (!TvdSBIstiQEoKQRxGbqLgZbbEPG(current, KzCUiawVxPrFPXkDhBSZNsDIaLv))
										{
											controllerPollingInfo = current;
											num2 = -706030467;
											continue;
										}
										break;
									case 1:
									{
										current = enumerator.Current;
										int num4;
										if (!current.success)
										{
											num2 = -706030471;
											num4 = num2;
										}
										else
										{
											num2 = -706030469;
											num4 = num2;
										}
										continue;
									}
									case 4:
										goto end_IL_0051;
									}
									goto IL_0072;
									continue;
									end_IL_0051:
									break;
								}
								break;
							}
						}
						if (!controllerPollingInfo.success)
						{
							goto IL_00dc;
						}
						if (!EFyMEWlDUqTJVXkbiWsNOGSeKEz(cPVAKFeyxMEfqfqaoCTorALFqDOc, controllerPollingInfo, KzCUiawVxPrFPXkDhBSZNsDIaLv))
						{
							P_0 = default(ElementAssignment);
							return IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp;
						}
						P_0 = cPVAKFeyxMEfqfqaoCTorALFqDOc.TZQuKgxHxINNqyCfDdLrjESbRmCo(controllerPollingInfo);
						num5 = -706030469;
						goto IL_00e1;
					}
					IL_00e1:
					while (true)
					{
						switch (num5 ^ -706030471)
						{
						case 0:
							break;
						case 3:
							P_0 = default(ElementAssignment);
							return IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp;
						case 2:
							goto IL_013d;
						default:
							return IbWFlWDuuTwCtSbjipSXSXaKpng.phEfcHmOUEqIkRBNHmZwuZOVNOp;
						}
						break;
						IL_013d:
						P_0.modifierKeyFlags = modifierKeyFlags;
						num5 = -706030472;
					}
					goto IL_00dc;
					IL_00dc:
					num5 = -706030470;
					goto IL_00e1;
				}
				goto IL_0013;
				IL_0013:
				num = -706030472;
				goto IL_0018;
			}

			private bool lCldeWjMAuMryDZJKDjctVNZDsm(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = cPVAKFeyxMEfqfqaoCTorALFqDOc.controllerType;
				int controllerId = cPVAKFeyxMEfqfqaoCTorALFqDOc.controllerId;
				while (true)
				{
					int num = 1346504605;
					while (true)
					{
						switch (num ^ 0x50420798)
						{
						case 10:
							break;
						case 8:
						{
							int num3;
							if (!KzCUiawVxPrFPXkDhBSZNsDIaLv.allowButtons)
							{
								num = 1346504593;
								num3 = num;
							}
							else
							{
								num = 1346504607;
								num3 = num;
							}
							continue;
						}
						case 3:
							if (cPVAKFeyxMEfqfqaoCTorALFqDOc.player == null)
							{
								goto case 11;
							}
							P_0 = cPVAKFeyxMEfqfqaoCTorALFqDOc.player.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
							goto case 4;
						case 0:
							if (cPVAKFeyxMEfqfqaoCTorALFqDOc.player == null)
							{
								goto case 1;
							}
							P_0 = cPVAKFeyxMEfqfqaoCTorALFqDOc.player.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
							goto case 4;
						case 12:
							P_0 = ypSFFgjKkPSASVervKSdRqzqUTy(out P_1);
							return true;
						case 9:
							TXbaTLHoDuZJZGChosMqvmCUBrSi("You must enable listening for at least one element type.");
							num = 1346504606;
							continue;
						case 11:
							P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
							goto case 4;
						case 1:
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(cPVAKFeyxMEfqfqaoCTorALFqDOc.controllerType, cPVAKFeyxMEfqfqaoCTorALFqDOc.controllerId);
							num = 1346504604;
							continue;
						case 2:
							P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
							goto case 4;
						case 7:
							if (cPVAKFeyxMEfqfqaoCTorALFqDOc.player == null)
							{
								goto case 2;
							}
							P_0 = cPVAKFeyxMEfqfqaoCTorALFqDOc.player.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
							goto case 4;
						case 5:
							if (controllerType != ControllerType.Keyboard)
							{
								if (KzCUiawVxPrFPXkDhBSZNsDIaLv.allowAxes)
								{
									int num2;
									if (!KzCUiawVxPrFPXkDhBSZNsDIaLv.allowButtons)
									{
										num = 1346504603;
										num2 = num;
									}
									else
									{
										num = 1346504600;
										num2 = num;
									}
									continue;
								}
								goto case 8;
							}
							num = 1346504596;
							continue;
						default:
							P_0 = null;
							return false;
						case 4:
							return true;
						}
						break;
					}
				}
			}

			private IEnumerable<ControllerPollingInfo> ypSFFgjKkPSASVervKSdRqzqUTy(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				while (true)
				{
					int num = 809207656;
					while (true)
					{
						switch (num ^ 0x303B8769)
						{
						case 0:
							break;
						case 1:
							afsEvhjtvtFoWTKfvuddVqbsezQ.Clear();
							if (!KzCUiawVxPrFPXkDhBSZNsDIaLv.allowButtons)
							{
								goto IL_0039;
							}
							afsEvhjtvtFoWTKfvuddVqbsezQ.Add(KyuLqqAPOCcMjgkanNzFQVWzrbWG(KzCUiawVxPrFPXkDhBSZNsDIaLv, out P_0));
							return afsEvhjtvtFoWTKfvuddVqbsezQ;
						default:
							return afsEvhjtvtFoWTKfvuddVqbsezQ;
						}
						break;
						IL_0039:
						num = 809207659;
					}
				}
			}

			private ControllerPollingInfo KyuLqqAPOCcMjgkanNzFQVWzrbWG(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = KyuLqqAPOCcMjgkanNzFQVWzrbWG(P_0, out flag, out P_1, out text);
				if (flag)
				{
					BcbbceSEftXnUnpLWASmAEcUgnMO();
				}
				return result;
			}

			private static ControllerPollingInfo KyuLqqAPOCcMjgkanNzFQVWzrbWG(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_3 = string.Empty;
				int num3 = default(int);
				ControllerPollingInfo result2 = default(ControllerPollingInfo);
				ControllerPollingInfo result = default(ControllerPollingInfo);
				ModifierKeyFlags modifierKeyFlags = default(ModifierKeyFlags);
				KeyCode keyboardKey = default(KeyCode);
				ControllerPollingInfo result3 = default(ControllerPollingInfo);
				ControllerPollingInfo result4 = default(ControllerPollingInfo);
				while (true)
				{
					int num = -1341074203;
					while (true)
					{
						int num5;
						switch (num ^ -1341074204)
						{
						case 0:
							break;
						case 1:
							P_1 = false;
							P_2 = ModifierKeyFlags.None;
							num3 = 0;
							num = -1341074202;
							continue;
						case 2:
							result2 = default(ControllerPollingInfo);
							result = default(ControllerPollingInfo);
							modifierKeyFlags = ModifierKeyFlags.None;
							num = -1341074201;
							continue;
						default:
							{
								using (IEnumerator<ControllerPollingInfo> enumerator = ReInput.controllers.Keyboard.PollForAllKeys().GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										while (true)
										{
											ControllerPollingInfo current = enumerator.Current;
											int num2 = -1341074208;
											while (true)
											{
												switch (num2 ^ -1341074204)
												{
												case 6:
													num2 = -1341074201;
													continue;
												case 7:
													num2 = -1341074207;
													continue;
												case 0:
													if (result2.keyboardKey == KeyCode.None)
													{
														result2 = current;
														num2 = -1341074207;
														continue;
													}
													goto end_IL_00bb;
												case 3:
													break;
												case 4:
													goto IL_00cb;
												case 2:
													if (!Keyboard.IsModifierKey(current.keyboardKey))
													{
														goto case 0;
													}
													if (num3 == 0)
													{
														result = current;
														num2 = -1341074203;
														continue;
													}
													goto case 1;
												case 1:
													modifierKeyFlags |= Keyboard.KeyCodeToModifierKeyFlags(keyboardKey);
													num3++;
													num2 = -1341074205;
													continue;
												default:
													goto end_IL_00bb;
												}
												break;
												IL_00cb:
												keyboardKey = current.keyboardKey;
												int num4;
												if (keyboardKey == KeyCode.AltGr)
												{
													num2 = -1341074207;
													num4 = num2;
												}
												else
												{
													num2 = -1341074202;
													num4 = num2;
												}
											}
											continue;
											end_IL_00bb:
											break;
										}
									}
								}
								if (result2.keyboardKey != KeyCode.None)
								{
									if (!ReInput.controllers.Keyboard.GetKeyDown(result2.keyboardKey))
									{
										goto IL_0162;
									}
									if (num3 == 0)
									{
										goto IL_01d7;
									}
									if (P_0.allowKeyboardKeysWithModifiers)
									{
										P_2 = modifierKeyFlags;
										return result2;
									}
									num5 = -1341074203;
								}
								else
								{
									if (num3 <= 0)
									{
										goto IL_0207;
									}
									P_1 = true;
									num5 = -1341074206;
								}
								goto IL_0167;
							}
							IL_0162:
							num5 = -1341074208;
							goto IL_0167;
							IL_0207:
							result3 = default(ControllerPollingInfo);
							num5 = -1341074205;
							goto IL_0167;
							IL_01d7:
							return result2;
							IL_0255:
							if (!ReInput.controllers.Keyboard.GetKeyDown(result.keyboardKey))
							{
								return default(ControllerPollingInfo);
							}
							return result;
							IL_0167:
							while (true)
							{
								switch (num5 ^ -1341074204)
								{
								case 9:
									break;
								case 5:
									goto IL_01a3;
								case 10:
									num5 = -1341074204;
									continue;
								case 1:
									goto IL_01d7;
								case 3:
									return result4;
								case 0:
									goto IL_0207;
								case 4:
									result4 = default(ControllerPollingInfo);
									num5 = -1341074201;
									continue;
								case 2:
									P_3 = Keyboard.ModifierKeyFlagsToString(modifierKeyFlags);
									num5 = -1341074204;
									continue;
								case 6:
									goto IL_023d;
								case 8:
									goto IL_0255;
								default:
									return result3;
								}
								break;
								IL_023d:
								int num6;
								if (num3 == 1)
								{
									num5 = -1341074207;
									num6 = num5;
								}
								else
								{
									num5 = -1341074202;
									num6 = num5;
								}
								continue;
								IL_01a3:
								if (P_0.allowKeyboardModifierKeyAsPrimary)
								{
									if (!P_0.allowKeyboardKeysWithModifiers)
									{
										goto IL_0255;
									}
									if (P_0.holdDurationToMapKeyboardModifierKeyAsPrimary <= 0f)
									{
										num5 = -1341074196;
										continue;
									}
									if (ReInput.controllers.Keyboard.GetKeyTimePressed(result.keyboardKey) >= (double)P_0.holdDurationToMapKeyboardModifierKeyAsPrimary)
									{
										return result;
									}
								}
								P_3 = Keyboard.GetKeyName(result.keyboardKey);
								num5 = -1341074194;
							}
							goto IL_0162;
						}
						break;
					}
				}
			}

			private static bool TvdSBIstiQEoKQRxGbqLgZbbEPG(ControllerPollingInfo P_0, Options P_1)
			{
				if (!P_1.allowAxes && P_0.elementType == ControllerElementType.Axis)
				{
					return false;
				}
				if (!P_1.allowButtons && P_0.elementType == ControllerElementType.Button)
				{
					return false;
				}
				if (P_0.controllerType == ControllerType.Mouse && P_0.elementType == ControllerElementType.Axis)
				{
					while (true)
					{
						int num = 1527644200;
						while (true)
						{
							switch (num ^ 0x5B0E0029)
							{
							case 3:
								break;
							case 4:
								goto IL_0060;
							case 1:
								goto IL_0082;
							default:
								return true;
							case 0:
								goto end_IL_003a;
							}
							break;
							IL_0082:
							switch (P_0.elementIndex)
							{
							case 0:
								break;
							case 1:
								goto IL_006a;
							default:
								goto IL_0098;
							}
							goto IL_0060;
							IL_0098:
							num = 1527644201;
							continue;
							IL_006a:
							if (!P_1.ignoreMouseYAxis)
							{
								goto end_IL_003a;
							}
							num = 1527644203;
							continue;
							IL_0060:
							if (!P_1.ignoreMouseXAxis)
							{
								goto end_IL_003a;
							}
							return true;
						}
						continue;
						end_IL_003a:
						break;
					}
				}
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.tkhqzIqJXmsHMZXHJPpavCWkDqu<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool EFyMEWlDUqTJVXkbiWsNOGSeKEz(hiwSVdgTkncDRwEPXOTHGxfrnPJ P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.axisRange == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void ktDBntjbFnvTnmtaFBpLkuaYPMn()
			{
				if (!KzCUiawVxPrFPXkDhBSZNsDIaLv.checkForConflicts)
				{
					return;
				}
				IList<Player> allPlayers = default(IList<Player>);
				int num3 = default(int);
				int num5 = default(int);
				IList<Player> players = default(IList<Player>);
				int count = default(int);
				while (true)
				{
					int num;
					int num2;
					if (KzCUiawVxPrFPXkDhBSZNsDIaLv.checkForConflictsWithSelf)
					{
						num = -1697143723;
						num2 = num;
					}
					else
					{
						num = -1697143724;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1697143716)
						{
						case 0:
							num = -1697143715;
							continue;
						default:
							return;
						case 10:
							ListTools.AddIfUnique(FPlhXdvEeMmeMLLXsDPfvRAlgBU, allPlayers[num3]);
							num = -1697143718;
							continue;
						case 9:
							if (cPVAKFeyxMEfqfqaoCTorALFqDOc.player != null)
							{
								ListTools.AddIfUnique(FPlhXdvEeMmeMLLXsDPfvRAlgBU, cPVAKFeyxMEfqfqaoCTorALFqDOc.player);
								num = -1697143724;
								continue;
							}
							goto case 8;
						case 12:
						{
							int num6;
							if (!ArrayTools.Contains(KzCUiawVxPrFPXkDhBSZNsDIaLv.checkForConflictsWithPlayerIds, allPlayers[num3].id))
							{
								num = -1697143718;
								num6 = num;
							}
							else
							{
								num = -1697143722;
								num6 = num;
							}
							continue;
						}
						case 2:
							if (num5 >= players.Count)
							{
								return;
							}
							goto case 7;
						case 8:
							if (KzCUiawVxPrFPXkDhBSZNsDIaLv.checkForConflictsWithSystemPlayer)
							{
								ListTools.AddIfUnique(FPlhXdvEeMmeMLLXsDPfvRAlgBU, ReInput.players.SystemPlayer);
								num = -1697143726;
								continue;
							}
							goto case 14;
						case 7:
							ListTools.AddIfUnique(FPlhXdvEeMmeMLLXsDPfvRAlgBU, players[num5]);
							num = -1697143721;
							continue;
						case 1:
							break;
						case 11:
							num5++;
							num = -1697143714;
							continue;
						case 5:
							num3 = 0;
							num = -1697143727;
							continue;
						case 13:
						{
							int num4;
							if (num3 < count)
							{
								num = -1697143728;
								num4 = num;
							}
							else
							{
								num = -1697143720;
								num4 = num;
							}
							continue;
						}
						case 3:
							if (KzCUiawVxPrFPXkDhBSZNsDIaLv.checkForConflictsWithPlayerIds != null)
							{
								allPlayers = ReInput.players.AllPlayers;
								count = allPlayers.Count;
								num = -1697143719;
								continue;
							}
							return;
						case 14:
							if (KzCUiawVxPrFPXkDhBSZNsDIaLv.checkForConflictsWithAllPlayers)
							{
								players = ReInput.players.Players;
								num5 = 0;
								num = -1697143714;
								continue;
							}
							goto case 3;
						case 6:
							num3++;
							num = -1697143727;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}

			private IbWFlWDuuTwCtSbjipSXSXaKpng ewXhdUsLdymdNzSdIDTbPgCsrnm(ElementAssignment P_0)
			{
				if (KzCUiawVxPrFPXkDhBSZNsDIaLv.checkForConflicts && cPVAKFeyxMEfqfqaoCTorALFqDOc.player != null && AiHAWxwRfGJqVCbHZDCBhaILzqI(cPVAKFeyxMEfqfqaoCTorALFqDOc, P_0, FPlhXdvEeMmeMLLXsDPfvRAlgBU))
				{
					return oWZTkMwUpqtIHSULAqpfNBdObIY(P_0);
				}
				return IbWFlWDuuTwCtSbjipSXSXaKpng.phEfcHmOUEqIkRBNHmZwuZOVNOp;
			}

			private static bool AiHAWxwRfGJqVCbHZDCBhaILzqI(hiwSVdgTkncDRwEPXOTHGxfrnPJ P_0, ElementAssignment P_1, List<Player> P_2)
			{
				int num;
				if (P_0 != null)
				{
					if (P_0.player == null)
					{
						goto IL_000b;
					}
					int num2;
					if (P_2 == null)
					{
						num = 705423750;
						num2 = num;
					}
					else
					{
						num = 705423751;
						num2 = num;
					}
					goto IL_0010;
				}
				goto IL_0039;
				IL_0010:
				int num3 = default(int);
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				while (true)
				{
					switch (num ^ 0x2A0BE985)
					{
					case 0:
						break;
					case 6:
						goto IL_0039;
					case 3:
						return false;
					case 2:
						goto IL_0063;
					case 5:
						return false;
					case 4:
						goto IL_007d;
					default:
						if (num3 >= P_2.Count)
						{
							return false;
						}
						goto IL_007d;
					}
					break;
					IL_007d:
					if (P_2[num3].controllers.conflictChecking.DoesElementAssignmentConflict(conflictCheck))
					{
						return true;
					}
					num3++;
					num = 705423748;
					continue;
					IL_0063:
					if (P_2.Count != 0)
					{
						if (!sTSGMvxTAPHzdzlYTJYRRBADHor(P_0, P_1, out conflictCheck))
						{
							num = 705423744;
							continue;
						}
						num3 = 0;
						num = 705423748;
					}
					else
					{
						num = 705423750;
					}
				}
				goto IL_000b;
				IL_000b:
				num = 705423747;
				goto IL_0010;
				IL_0039:
				return false;
			}

			private static bool szJqPDKQubwesScswVZyRtMlfDa(hiwSVdgTkncDRwEPXOTHGxfrnPJ P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null)
				{
					goto IL_002d;
				}
				if (P_0.player == null)
				{
					goto IL_000b;
				}
				if (P_2 == null)
				{
					goto IL_0041;
				}
				int num;
				if (P_2.Count == 0)
				{
					num = 2014517108;
					goto IL_0010;
				}
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				if (!sTSGMvxTAPHzdzlYTJYRRBADHor(P_0, P_1, out conflictCheck))
				{
					return false;
				}
				int num2 = 0;
				goto IL_012b;
				IL_0010:
				switch (num ^ 0x78131774)
				{
				case 3:
					break;
				case 1:
					goto IL_002d;
				case 0:
					goto IL_0041;
				default:
					goto IL_005e;
				}
				goto IL_000b;
				IL_0041:
				return false;
				IL_002d:
				return false;
				IL_0112:
				int num3;
				switch (num3 ^ 0x78131774)
				{
				case 0:
					break;
				case 1:
					goto IL_012b;
				default:
					return false;
				}
				goto IL_010d;
				IL_010d:
				num3 = 2014517109;
				goto IL_0112;
				IL_012b:
				if (num2 < P_2.Count)
				{
					goto IL_005e;
				}
				num3 = 2014517110;
				goto IL_0112;
				IL_005e:
				IEnumerator<ElementAssignmentConflictInfo> enumerator = P_2[num2].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							int num4;
							int num5;
							if (enumerator.Current.isUserAssignable)
							{
								num4 = 2014517110;
								num5 = num4;
							}
							else
							{
								num4 = 2014517111;
								num5 = num4;
							}
							while (true)
							{
								switch (num4 ^ 0x78131774)
								{
								case 0:
									num4 = 2014517109;
									continue;
								case 1:
									break;
								case 3:
									return true;
								default:
									goto end_IL_00a0;
								}
								break;
							}
							continue;
							end_IL_00a0:
							break;
						}
					}
				}
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_00dc:
							int num6 = 2014517109;
							while (true)
							{
								switch (num6 ^ 0x78131774)
								{
								case 2:
									break;
								default:
									goto end_IL_00e1;
								case 1:
									goto IL_00fa;
								case 0:
									goto end_IL_00e1;
								}
								goto IL_00dc;
								IL_00fa:
								enumerator.Dispose();
								num6 = 2014517108;
								continue;
								end_IL_00e1:
								break;
							}
							break;
						}
					}
				}
				num2++;
				goto IL_010d;
				IL_000b:
				num = 2014517109;
				goto IL_0010;
			}

			private static IList<ElementAssignmentConflictInfo> FrNVqqkwwKMKBJSWdWdYiRqZuvQ(hiwSVdgTkncDRwEPXOTHGxfrnPJ P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null)
				{
					goto IL_002d;
				}
				if (P_0.player == null)
				{
					goto IL_000b;
				}
				if (P_2 == null)
				{
					goto IL_0041;
				}
				int num;
				if (P_2.Count == 0)
				{
					num = -172381641;
					goto IL_0010;
				}
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				if (!sTSGMvxTAPHzdzlYTJYRRBADHor(P_0, P_1, out conflictCheck))
				{
					return null;
				}
				List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
				int num2 = 0;
				goto IL_00fc;
				IL_0010:
				switch (num ^ -172381642)
				{
				case 3:
					break;
				case 2:
					goto IL_002d;
				case 1:
					goto IL_0041;
				default:
					goto IL_0064;
				}
				goto IL_000b;
				IL_0041:
				return null;
				IL_002d:
				return null;
				IL_00fc:
				if (num2 < P_2.Count)
				{
					goto IL_0064;
				}
				int num3 = -172381642;
				goto IL_00e3;
				IL_00e3:
				switch (num3 ^ -172381642)
				{
				case 2:
					break;
				case 1:
					goto IL_00fc;
				default:
					return list;
				}
				goto IL_00de;
				IL_00de:
				num3 = -172381641;
				goto IL_00e3;
				IL_0064:
				using (IEnumerator<ElementAssignmentConflictInfo> enumerator = P_2[num2].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							ElementAssignmentConflictInfo current = enumerator.Current;
							int num4 = -172381641;
							while (true)
							{
								switch (num4 ^ -172381642)
								{
								case 0:
									num4 = -172381643;
									continue;
								case 3:
									break;
								case 1:
									list.Add(current);
									num4 = -172381644;
									continue;
								default:
									goto end_IL_00a6;
								}
								break;
							}
							continue;
							end_IL_00a6:
							break;
						}
					}
				}
				num2++;
				goto IL_00de;
				IL_000b:
				num = -172381644;
				goto IL_0010;
			}

			private static bool sTSGMvxTAPHzdzlYTJYRRBADHor(hiwSVdgTkncDRwEPXOTHGxfrnPJ P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				int num;
				if (P_0 != null)
				{
					Player player;
					if ((player = P_0.player) == null)
					{
						goto IL_000d;
					}
					P_2 = P_1.ToElementAssignmentConflictCheck();
					P_2.playerId = player.id;
					P_2.controllerType = P_0.controllerType;
					P_2.controllerId = P_0.controllerId;
					num = 89020396;
					goto IL_0012;
				}
				goto IL_003a;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x54E57E9)
					{
					case 2:
						break;
					case 4:
						goto IL_003a;
					case 3:
						P_2.controllerMapCategoryId = P_0.mappingContext.controllerMap.categoryId;
						num = 89020392;
						continue;
					case 1:
						if (P_0.mappingContext.actionElementMapToReplace != null)
						{
							P_2.elementMapId = P_0.mappingContext.actionElementMapToReplace.id;
							num = 89020393;
							continue;
						}
						goto default;
					case 5:
						P_2.controllerMapId = P_0.mappingContext.controllerMap.id;
						num = 89020394;
						continue;
					default:
						return true;
					}
					break;
				}
				goto IL_000d;
				IL_003a:
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
				IL_000d:
				num = 89020397;
				goto IL_0012;
			}

			private static void IqVhpEXwjtbfZeDIYBONIiLjtMX(hiwSVdgTkncDRwEPXOTHGxfrnPJ P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 != null)
				{
					if (P_0.player == null)
					{
						goto IL_000b;
					}
					goto IL_003e;
				}
				return;
				IL_0035:
				int num = 0;
				int num2 = 1441007533;
				goto IL_0010;
				IL_000b:
				num2 = 1441007531;
				goto IL_0010;
				IL_0010:
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				while (true)
				{
					switch (num2 ^ 0x55E407AE)
					{
					case 0:
						break;
					case 1:
						goto IL_0035;
					case 2:
						goto IL_003e;
					case 4:
						P_2[num].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
						num++;
						num2 = 1441007533;
						continue;
					case 5:
						return;
					default:
						if (num >= P_2.Count)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
				goto IL_000b;
				IL_003e:
				if (!sTSGMvxTAPHzdzlYTJYRRBADHor(P_0, P_1, out conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				goto IL_0035;
			}

			private void YrTxeMoLundvWLepDHpoCyMernAC()
			{
				ReInput.UpdateEndedEvent -= GzCliicOSMFLMvKajLgvnmGSSrh;
				ReInput.UpdateEndedEvent += GzCliicOSMFLMvKajLgvnmGSSrh;
			}

			private void yZNQlKaRQXMrTuFffDONHMEhgPXx()
			{
				ReInput.UpdateEndedEvent -= GzCliicOSMFLMvKajLgvnmGSSrh;
			}

			private bool TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp P_0)
			{
				SafeDelegate safeDelegate = pGOgISGmzqLUgLQoxeyCGBYLDXUk[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void mhNGMkIiyXwbcwgxAjoiCSSjQzTd<T>(ScGjCehqJbLHTgNXcKmfFYCwKZJp P_0, T P_1)
			{
				SafeAction<T> safeAction = (SafeAction<T>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[P_0];
				while (true)
				{
					int num = 690580656;
					while (true)
					{
						switch (num ^ 0x29296CB3)
						{
						case 2:
							break;
						case 3:
						{
							int num2;
							if (safeAction.Count != 0)
							{
								num = 690580658;
								num2 = num;
							}
							else
							{
								num = 690580659;
								num2 = num;
							}
							continue;
						}
						case 0:
							return;
						default:
							safeAction.Invoke(P_1);
							return;
						}
						break;
					}
				}
			}

			private void BcbbceSEftXnUnpLWASmAEcUgnMO()
			{
				bbAzXbTKHckGyRxoHHwNHchbXzf = ReInput.unscaledTime;
			}

			private void DQyTMgQDyYNGAbhPmEosNtOYVIl()
			{
				BIJbswxmHZfgkIifPloPdbZterlf = true;
			}

			private void WHJNfQyTJJoUzfmMMVYMmXaUIuo(ActionElementMap P_0)
			{
				kcruICbMwIbRyCNdOpNSanNjnPJb(P_0);
				AsLGHAVbjPEacNmJeQPEsuzzptZ();
			}

			private void JQVaToGvCEZETStIKyUHLwgPjCC(string P_0)
			{
				fKumIyCrMFskiqtEHdwQWKRhtdg(P_0);
				AsLGHAVbjPEacNmJeQPEsuzzptZ();
			}

			private IbWFlWDuuTwCtSbjipSXSXaKpng oWZTkMwUpqtIHSULAqpfNBdObIY(ElementAssignment P_0)
			{
				IList<ElementAssignmentConflictInfo> list = default(IList<ElementAssignmentConflictInfo>);
				bool flag = default(bool);
				if (TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp.BnoGDRJVJJkmalzbYKviQcGpYaW))
				{
					while (true)
					{
						int num = 1678176491;
						while (true)
						{
							switch (num ^ 0x6406F0EA)
							{
							case 2:
								break;
							case 1:
								goto IL_0027;
							default:
								FNwofgjNrmPRPxCGUpdKZDdJYTB = mrxVUraOKWQMkggMlSNCDLwZMdz.vwEjYoLhWdDSHmDBYHxTpSpUXtC;
								WmmfivTNKNwboTgUTGVOFBUwGcA();
								fcnyMSvOfiFEkmQUEARyEbdgJFr(new ElementAssignmentInfo(cPVAKFeyxMEfqfqaoCTorALFqDOc.mappingContext.controllerMap, P_0), list, flag);
								return IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp;
							}
							break;
							IL_0027:
							flag = szJqPDKQubwesScswVZyRtMlfDa(cPVAKFeyxMEfqfqaoCTorALFqDOc, P_0, FPlhXdvEeMmeMLLXsDPfvRAlgBU);
							PyhTyIsXuhJgPhngyfsxjdLyXbxP = P_0;
							list = FrNVqqkwwKMKBJSWdWdYiRqZuvQ(cPVAKFeyxMEfqfqaoCTorALFqDOc, P_0, FPlhXdvEeMmeMLLXsDPfvRAlgBU);
							num = 1678176490;
						}
					}
				}
				return GxVlRahRuaebQCcqaazjDbdOgmdH(KzCUiawVxPrFPXkDhBSZNsDIaLv.defaultActionWhenConflictFound, P_0);
			}

			private IbWFlWDuuTwCtSbjipSXSXaKpng GxVlRahRuaebQCcqaazjDbdOgmdH(ConflictResponse P_0, ElementAssignment P_1)
			{
				return GxVlRahRuaebQCcqaazjDbdOgmdH(P_0, P_1, szJqPDKQubwesScswVZyRtMlfDa(cPVAKFeyxMEfqfqaoCTorALFqDOc, P_1, FPlhXdvEeMmeMLLXsDPfvRAlgBU));
			}

			private IbWFlWDuuTwCtSbjipSXSXaKpng GxVlRahRuaebQCcqaazjDbdOgmdH(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					JQVaToGvCEZETStIKyUHLwgPjCC("Mapping assignment was canceled due to a conflict.");
					return IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp;
				case ConflictResponse.Replace:
					if (P_2)
					{
						JQVaToGvCEZETStIKyUHLwgPjCC("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp;
					}
					IqVhpEXwjtbfZeDIYBONIiLjtMX(cPVAKFeyxMEfqfqaoCTorALFqDOc, P_1, FPlhXdvEeMmeMLLXsDPfvRAlgBU);
					return IbWFlWDuuTwCtSbjipSXSXaKpng.phEfcHmOUEqIkRBNHmZwuZOVNOp;
				case ConflictResponse.Add:
					return IbWFlWDuuTwCtSbjipSXSXaKpng.phEfcHmOUEqIkRBNHmZwuZOVNOp;
				case ConflictResponse.Ignore:
					FCvTrZCWZrEmUlmTnYynykDtwIP();
					return IbWFlWDuuTwCtSbjipSXSXaKpng.zEbQSWrljsQrYcFYvEzvbxmAFlgp;
				default:
					throw new NotImplementedException();
				}
			}

			private void kLxGiphiRUPKKDrdkAMHgfhFrkow()
			{
				gySucvFbphioJEChDBECkcnuMGIg();
				AsLGHAVbjPEacNmJeQPEsuzzptZ();
			}

			private void TXbaTLHoDuZJZGChosMqvmCUBrSi(string P_0)
			{
				PjMQthjeKjxVoaBgUVlKCWmjMss(P_0);
				AsLGHAVbjPEacNmJeQPEsuzzptZ();
			}

			private void WmmfivTNKNwboTgUTGVOFBUwGcA()
			{
				DQyTMgQDyYNGAbhPmEosNtOYVIl();
				yZNQlKaRQXMrTuFffDONHMEhgPXx();
				eSInhTAigaqzirlKBZDnfWuZpmC = Status.AwaitingResponse;
			}

			private void FCvTrZCWZrEmUlmTnYynykDtwIP()
			{
				eSInhTAigaqzirlKBZDnfWuZpmC = Status.Listening;
				FNwofgjNrmPRPxCGUpdKZDdJYTB = mrxVUraOKWQMkggMlSNCDLwZMdz.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
				while (true)
				{
					int num = -411468073;
					while (true)
					{
						switch (num ^ -411468074)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_002c;
						case 2:
							return;
						}
						break;
						IL_002c:
						BcbbceSEftXnUnpLWASmAEcUgnMO();
						YrTxeMoLundvWLepDHpoCyMernAC();
						num = -411468076;
					}
				}
			}

			private void PdMprecJqNvqACEDUySddpTJTAG(ElementAssignment P_0)
			{
				if (cPVAKFeyxMEfqfqaoCTorALFqDOc.mappingContext.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					goto IL_001a;
				}
				goto IL_004b;
				IL_001a:
				int num = -1997871134;
				goto IL_001f;
				IL_001f:
				switch (num ^ -1997871133)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					WHJNfQyTJJoUzfmMMVYMmXaUIuo(result);
					return;
				case 3:
					goto IL_004b;
				case 2:
					return;
				}
				goto IL_001a;
				IL_004b:
				TXbaTLHoDuZJZGChosMqvmCUBrSi("Failed to create element assignment.");
				num = -1997871135;
				goto IL_001f;
			}

			private void kcruICbMwIbRyCNdOpNSanNjnPJb(ActionElementMap P_0)
			{
				if (!TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp.UWHKuObharcWmREwTRfXxbHHaMG))
				{
					while (true)
					{
						switch (0x3FAD5A8 ^ 0x3FAD5AA)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				mhNGMkIiyXwbcwgxAjoiCSSjQzTd(ScGjCehqJbLHTgNXcKmfFYCwKZJp.UWHKuObharcWmREwTRfXxbHHaMG, new InputMappedEventData(ZcHJtpUHuctAcnqSflrxCAOupGj, P_0));
			}

			private void gySucvFbphioJEChDBECkcnuMGIg()
			{
				if (TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp.FZMOQWNOeHtGxdPTCjkbKhypcZrH))
				{
					mhNGMkIiyXwbcwgxAjoiCSSjQzTd(ScGjCehqJbLHTgNXcKmfFYCwKZJp.FZMOQWNOeHtGxdPTCjkbKhypcZrH, new TimedOutEventData(ZcHJtpUHuctAcnqSflrxCAOupGj));
				}
			}

			private void PjMQthjeKjxVoaBgUVlKCWmjMss(string P_0)
			{
				if (TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp.ZtUwsrwXzuJnuLzcmZfjeVDsJIY))
				{
					mhNGMkIiyXwbcwgxAjoiCSSjQzTd(ScGjCehqJbLHTgNXcKmfFYCwKZJp.ZtUwsrwXzuJnuLzcmZfjeVDsJIY, new ErrorEventData(ZcHJtpUHuctAcnqSflrxCAOupGj, P_0));
				}
			}

			private void fKumIyCrMFskiqtEHdwQWKRhtdg(string P_0)
			{
				if (TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp.aINsxdepuysANqyrNfBHMmbfpCs))
				{
					mhNGMkIiyXwbcwgxAjoiCSSjQzTd(ScGjCehqJbLHTgNXcKmfFYCwKZJp.aINsxdepuysANqyrNfBHMmbfpCs, new CanceledEventData(ZcHJtpUHuctAcnqSflrxCAOupGj, P_0));
				}
			}

			private void fcnyMSvOfiFEkmQUEARyEbdgJFr(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				if (!TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp.BnoGDRJVJJkmalzbYKviQcGpYaW))
				{
					while (true)
					{
						switch (-1299707305 ^ -1299707307)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				mhNGMkIiyXwbcwgxAjoiCSSjQzTd(ScGjCehqJbLHTgNXcKmfFYCwKZJp.BnoGDRJVJJkmalzbYKviQcGpYaW, new ConflictFoundEventData(ZcHJtpUHuctAcnqSflrxCAOupGj, lssnuzhlGuGDJBCKFroMdRynoSy, P_0, P_1, P_2));
			}

			private void NiYrImCUnLKeUAyAIKghVwMCcFe()
			{
				if (!TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp.ABchwhDllxYJyZPlcZPhoqaCCBl))
				{
					return;
				}
				while (true)
				{
					mhNGMkIiyXwbcwgxAjoiCSSjQzTd(ScGjCehqJbLHTgNXcKmfFYCwKZJp.ABchwhDllxYJyZPlcZPhoqaCCBl, new StartedEventData(ZcHJtpUHuctAcnqSflrxCAOupGj));
					int num = 473381158;
					while (true)
					{
						switch (num ^ 0x1C373926)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 473381159;
					}
				}
			}

			private void EnQBDdzqXfYmioIiwuucwWViODd()
			{
				if (!TeTeRJdKLVGmNbHvIWnKNkySLvE(ScGjCehqJbLHTgNXcKmfFYCwKZJp.GcfjljcglleFSsSWstdsMiSqqXV))
				{
					return;
				}
				while (true)
				{
					mhNGMkIiyXwbcwgxAjoiCSSjQzTd(ScGjCehqJbLHTgNXcKmfFYCwKZJp.GcfjljcglleFSsSWstdsMiSqqXV, new StoppedEventData(ZcHJtpUHuctAcnqSflrxCAOupGj));
					int num = 1958464579;
					while (true)
					{
						switch (num ^ 0x74BBCC42)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = 1958464576;
					}
				}
			}

			public void lssnuzhlGuGDJBCKFroMdRynoSy(ConflictResponse P_0)
			{
				if (eSInhTAigaqzirlKBZDnfWuZpmC == Status.AwaitingResponse)
				{
					if (FNwofgjNrmPRPxCGUpdKZDdJYTB == mrxVUraOKWQMkggMlSNCDLwZMdz.vwEjYoLhWdDSHmDBYHxTpSpUXtC)
					{
						try
						{
							if (GxVlRahRuaebQCcqaazjDbdOgmdH(P_0, PyhTyIsXuhJgPhngyfsxjdLyXbxP) == IbWFlWDuuTwCtSbjipSXSXaKpng.phEfcHmOUEqIkRBNHmZwuZOVNOp)
							{
								PdMprecJqNvqACEDUySddpTJTAG(PyhTyIsXuhJgPhngyfsxjdLyXbxP);
							}
							return;
						}
						catch (Exception ex)
						{
							Logger.LogError("An exception occurred in the conflict check user response callback.\n" + ex);
							return;
						}
					}
					goto IL_0012;
				}
				goto IL_0030;
				IL_0017:
				int num;
				switch (num ^ 0x6E7002EC)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_0030;
				case 2:
					return;
				}
				goto IL_0012;
				IL_0030:
				Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
				num = 1852834542;
				goto IL_0017;
				IL_0012:
				num = 1852834541;
				goto IL_0017;
			}
		}

		public class Options
		{
			internal const string KSwHYvUsKHsRFjEptlJqEhadKjx = "isElementAllowed";

			private bool rUlYvcHaURsynwbZqKoMTIGpspN = true;

			private bool fqwuRjSaYDgGuXeIEaIRrlUhMsk = true;

			private bool vStgaOHGfIqhMvZfRBsinbnssfJ = true;

			private float WGhanFlCluEJUkKLNxXJBQUPpGQ;

			private bool lKGIDqypbsTIQJxTBmAiMkeLtrV = true;

			private bool TgMjpdEWJtYcTCJmsVNCgqSvPgN = true;

			private bool RgcavIcCBshPlTpmwibUjvMEdKtB = true;

			private bool LccCNoGGRMYkQdFabFzgEZWHIHYg = true;

			private int[] LjqFNoXHosbkdfwmSJYxZLGQWCE;

			private ConflictResponse tQaiymOBQWomHqAjdmvsqEjNgRAJ = ConflictResponse.Replace;

			private bool kpCRrevPkyWjdvQQjteQcCQoLUK;

			private bool QpGnXLOjexWuccGKdJksqTkBKcv;

			private bool MIctjozkBNhAwLAUvecLOPNyPUE = true;

			private bool FMGIxfSWWrInbMFyGOJsMjxxRsq = true;

			private float ifevYKjoOklxYBMreolsGmyPhUv = 1f;

			private readonly Dictionary<string, SafeDelegate> nTtGkrwuEYqKbZpiWdPlhNclOFXk = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			[CompilerGenerated]
			private static Action<Exception> GDswEDbawSjkEDQugEPLwdWcEzL;

			public bool allowAxes
			{
				get
				{
					return rUlYvcHaURsynwbZqKoMTIGpspN;
				}
				set
				{
					rUlYvcHaURsynwbZqKoMTIGpspN = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return fqwuRjSaYDgGuXeIEaIRrlUhMsk;
				}
				set
				{
					fqwuRjSaYDgGuXeIEaIRrlUhMsk = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return vStgaOHGfIqhMvZfRBsinbnssfJ;
				}
				set
				{
					vStgaOHGfIqhMvZfRBsinbnssfJ = value;
				}
			}

			public float timeout
			{
				get
				{
					return WGhanFlCluEJUkKLNxXJBQUPpGQ;
				}
				set
				{
					WGhanFlCluEJUkKLNxXJBQUPpGQ = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return lKGIDqypbsTIQJxTBmAiMkeLtrV;
				}
				set
				{
					lKGIDqypbsTIQJxTBmAiMkeLtrV = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return TgMjpdEWJtYcTCJmsVNCgqSvPgN;
				}
				set
				{
					TgMjpdEWJtYcTCJmsVNCgqSvPgN = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return RgcavIcCBshPlTpmwibUjvMEdKtB;
				}
				set
				{
					RgcavIcCBshPlTpmwibUjvMEdKtB = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return LccCNoGGRMYkQdFabFzgEZWHIHYg;
				}
				set
				{
					LccCNoGGRMYkQdFabFzgEZWHIHYg = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return LjqFNoXHosbkdfwmSJYxZLGQWCE;
				}
				set
				{
					LjqFNoXHosbkdfwmSJYxZLGQWCE = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return tQaiymOBQWomHqAjdmvsqEjNgRAJ;
				}
				set
				{
					tQaiymOBQWomHqAjdmvsqEjNgRAJ = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return kpCRrevPkyWjdvQQjteQcCQoLUK;
				}
				set
				{
					kpCRrevPkyWjdvQQjteQcCQoLUK = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return QpGnXLOjexWuccGKdJksqTkBKcv;
				}
				set
				{
					QpGnXLOjexWuccGKdJksqTkBKcv = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return MIctjozkBNhAwLAUvecLOPNyPUE;
				}
				set
				{
					MIctjozkBNhAwLAUvecLOPNyPUE = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return FMGIxfSWWrInbMFyGOJsMjxxRsq;
				}
				set
				{
					FMGIxfSWWrInbMFyGOJsMjxxRsq = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return ifevYKjoOklxYBMreolsGmyPhUv;
				}
				set
				{
					ifevYKjoOklxYBMreolsGmyPhUv = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)nTtGkrwuEYqKbZpiWdPlhNclOFXk["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = delegate(Exception P_0)
						{
							ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
						};
					}
					nTtGkrwuEYqKbZpiWdPlhNclOFXk["isElementAllowed"] = safePredicate;
				}
			}

			internal T tkhqzIqJXmsHMZXHJPpavCWkDqu<T>(string P_0) where T : SafeDelegate
			{
				if (!nTtGkrwuEYqKbZpiWdPlhNclOFXk.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as T;
			}

			public Options()
			{
				while (true)
				{
					int num = 1670677018;
					while (true)
					{
						switch (num ^ 0x63948218)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_008e;
						case 1:
							return;
						}
						break;
						IL_008e:
						tAgADqjTsMUxSqYXeDyJIdETYRAp();
						num = 1670677017;
					}
				}
			}

			private Options(Options source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				Copy(source, this);
			}

			public Options Clone()
			{
				return new Options(this);
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				while (true)
				{
					int num = 819133827;
					while (true)
					{
						switch (num ^ 0x30D2FD81)
						{
						case 3:
							break;
						case 0:
							stringBuilder.Append("ignoreMouseXAxis = " + kpCRrevPkyWjdvQQjteQcCQoLUK);
							stringBuilder.Append("ignoreMouseYAxis = " + QpGnXLOjexWuccGKdJksqTkBKcv);
							stringBuilder.Append("allowKeyboardKeysWithModifiers = " + MIctjozkBNhAwLAUvecLOPNyPUE + "\n");
							stringBuilder.Append("allowKeyboardModifierAsPrimary = " + FMGIxfSWWrInbMFyGOJsMjxxRsq + "\n");
							stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + ifevYKjoOklxYBMreolsGmyPhUv + "\n");
							num = 819133829;
							continue;
						case 1:
							stringBuilder.Append("timeout = " + WGhanFlCluEJUkKLNxXJBQUPpGQ + "\n");
							stringBuilder.Append("checkForConflicts = " + lKGIDqypbsTIQJxTBmAiMkeLtrV + "\n");
							stringBuilder.Append("checkForConflictsWithAllPlayers = " + TgMjpdEWJtYcTCJmsVNCgqSvPgN + "\n");
							stringBuilder.Append("checkForConflictsWithSelf = " + RgcavIcCBshPlTpmwibUjvMEdKtB + "\n");
							stringBuilder.Append("checkForConflictsWithSystemPlayer = " + LccCNoGGRMYkQdFabFzgEZWHIHYg + "\n");
							if (LjqFNoXHosbkdfwmSJYxZLGQWCE == null)
							{
								stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
								num = 819133828;
								continue;
							}
							goto case 6;
						case 2:
							stringBuilder.Append("Options:\n");
							stringBuilder.Append("allowAxes = " + rUlYvcHaURsynwbZqKoMTIGpspN + "\n");
							stringBuilder.Append("allowButtons = " + fqwuRjSaYDgGuXeIEaIRrlUhMsk + "\n");
							stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + vStgaOHGfIqhMvZfRBsinbnssfJ + "\n");
							num = 819133824;
							continue;
						case 6:
							stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(LjqFNoXHosbkdfwmSJYxZLGQWCE) + "\n");
							num = 819133828;
							continue;
						case 5:
							stringBuilder.Append(string.Concat("defaultActionWhenConflictFound = ", tQaiymOBQWomHqAjdmvsqEjNgRAJ, "\n"));
							num = 819133825;
							continue;
						default:
							return stringBuilder.ToString();
						}
						break;
					}
				}
			}

			internal void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				rUlYvcHaURsynwbZqKoMTIGpspN = true;
				fqwuRjSaYDgGuXeIEaIRrlUhMsk = true;
				vStgaOHGfIqhMvZfRBsinbnssfJ = true;
				WGhanFlCluEJUkKLNxXJBQUPpGQ = 0f;
				lKGIDqypbsTIQJxTBmAiMkeLtrV = true;
				while (true)
				{
					int num = -1595570293;
					while (true)
					{
						switch (num ^ -1595570289)
						{
						case 0:
							break;
						case 4:
							TgMjpdEWJtYcTCJmsVNCgqSvPgN = true;
							RgcavIcCBshPlTpmwibUjvMEdKtB = true;
							num = -1595570291;
							continue;
						case 3:
							ifevYKjoOklxYBMreolsGmyPhUv = 1f;
							num = -1595570294;
							continue;
						case 2:
							LccCNoGGRMYkQdFabFzgEZWHIHYg = true;
							LjqFNoXHosbkdfwmSJYxZLGQWCE = null;
							tQaiymOBQWomHqAjdmvsqEjNgRAJ = ConflictResponse.Replace;
							kpCRrevPkyWjdvQQjteQcCQoLUK = false;
							QpGnXLOjexWuccGKdJksqTkBKcv = false;
							num = -1595570290;
							continue;
						case 1:
							MIctjozkBNhAwLAUvecLOPNyPUE = true;
							FMGIxfSWWrInbMFyGOJsMjxxRsq = true;
							num = -1595570292;
							continue;
						default:
						{
							List<string> list = new List<string>(nTtGkrwuEYqKbZpiWdPlhNclOFXk.Keys);
							using (List<string>.Enumerator enumerator = list.GetEnumerator())
							{
								while (true)
								{
									int num2;
									int num3;
									if (!enumerator.MoveNext())
									{
										num2 = -1595570291;
										num3 = num2;
									}
									else
									{
										num2 = -1595570290;
										num3 = num2;
									}
									while (true)
									{
										switch (num2 ^ -1595570289)
										{
										case 0:
											num2 = -1595570290;
											continue;
										default:
											return;
										case 1:
										{
											string current = enumerator.Current;
											nTtGkrwuEYqKbZpiWdPlhNclOFXk[current] = null;
											num2 = -1595570292;
											continue;
										}
										case 3:
											break;
										case 2:
											return;
										}
										break;
									}
								}
							}
						}
						}
						break;
					}
				}
			}

			public static void Copy(Options source, Options destination)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				while (destination != null)
				{
					while (true)
					{
						destination.rUlYvcHaURsynwbZqKoMTIGpspN = source.rUlYvcHaURsynwbZqKoMTIGpspN;
						destination.fqwuRjSaYDgGuXeIEaIRrlUhMsk = source.fqwuRjSaYDgGuXeIEaIRrlUhMsk;
						destination.vStgaOHGfIqhMvZfRBsinbnssfJ = source.vStgaOHGfIqhMvZfRBsinbnssfJ;
						destination.WGhanFlCluEJUkKLNxXJBQUPpGQ = source.WGhanFlCluEJUkKLNxXJBQUPpGQ;
						int num = 1604211552;
						while (true)
						{
							switch (num ^ 0x5F9E5362)
							{
							case 0:
								num = 1604211559;
								continue;
							case 4:
								destination.ifevYKjoOklxYBMreolsGmyPhUv = source.ifevYKjoOklxYBMreolsGmyPhUv;
								num = 1604211563;
								continue;
							case 6:
								destination.TgMjpdEWJtYcTCJmsVNCgqSvPgN = source.TgMjpdEWJtYcTCJmsVNCgqSvPgN;
								num = 1604211557;
								continue;
							case 8:
								destination.LccCNoGGRMYkQdFabFzgEZWHIHYg = source.LccCNoGGRMYkQdFabFzgEZWHIHYg;
								destination.LjqFNoXHosbkdfwmSJYxZLGQWCE = ArrayTools.ShallowCopy(source.LjqFNoXHosbkdfwmSJYxZLGQWCE);
								num = 1604211555;
								continue;
							case 2:
								destination.lKGIDqypbsTIQJxTBmAiMkeLtrV = source.lKGIDqypbsTIQJxTBmAiMkeLtrV;
								num = 1604211556;
								continue;
							case 3:
								break;
							case 7:
								destination.RgcavIcCBshPlTpmwibUjvMEdKtB = source.RgcavIcCBshPlTpmwibUjvMEdKtB;
								num = 1604211562;
								continue;
							case 5:
								goto end_IL_00b1;
							case 1:
								destination.tQaiymOBQWomHqAjdmvsqEjNgRAJ = source.tQaiymOBQWomHqAjdmvsqEjNgRAJ;
								destination.kpCRrevPkyWjdvQQjteQcCQoLUK = source.kpCRrevPkyWjdvQQjteQcCQoLUK;
								destination.QpGnXLOjexWuccGKdJksqTkBKcv = source.QpGnXLOjexWuccGKdJksqTkBKcv;
								destination.MIctjozkBNhAwLAUvecLOPNyPUE = source.MIctjozkBNhAwLAUvecLOPNyPUE;
								destination.FMGIxfSWWrInbMFyGOJsMjxxRsq = source.FMGIxfSWWrInbMFyGOJsMjxxRsq;
								num = 1604211558;
								continue;
							default:
							{
								using (Dictionary<string, SafeDelegate>.Enumerator enumerator = source.nTtGkrwuEYqKbZpiWdPlhNclOFXk.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										while (true)
										{
											KeyValuePair<string, SafeDelegate> current = enumerator.Current;
											destination.nTtGkrwuEYqKbZpiWdPlhNclOFXk[current.Key] = MiscTools.Clone(current.Value);
											int num2 = 1604211554;
											while (true)
											{
												switch (num2 ^ 0x5F9E5362)
												{
												case 2:
													num2 = 1604211555;
													continue;
												case 1:
													break;
												default:
													goto end_IL_018b;
												}
												break;
											}
											continue;
											end_IL_018b:
											break;
										}
									}
									return;
								}
							}
							}
							break;
						}
						continue;
						end_IL_00b1:
						break;
					}
				}
				throw new ArgumentNullException("destination");
			}

			[CompilerGenerated]
			private static void HvHQTAINiiifFdKfUrWBpTTAUWL(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
			}
		}

		private static InputMapper BgVAlBbqHGOjWMKDVziUeWXeAbTf;

		private static int yaBkMAQfYXPgUDRJlmRDPEwrgbOa = 0;

		private readonly int PvsuSGRwBhtIXJREfzZZvubyLRp;

		private readonly bool JxAzCfJgIjKncgvkHADgyQmPizR;

		private readonly daUybjwOixexSGMKtqpHUdttZhkL LEoExUcRwpkZBlcxtzqcKcxyEBJE;

		private Options KzCUiawVxPrFPXkDhBSZNsDIaLv;

		private readonly Dictionary<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate> pGOgISGmzqLUgLQoxeyCGBYLDXUk = new Dictionary<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate>
		{
			{
				ScGjCehqJbLHTgNXcKmfFYCwKZJp.UWHKuObharcWmREwTRfXxbHHaMG,
				new SafeAction<InputMappedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
				})
			},
			{
				ScGjCehqJbLHTgNXcKmfFYCwKZJp.ZtUwsrwXzuJnuLzcmZfjeVDsJIY,
				new SafeAction<ErrorEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
				})
			},
			{
				ScGjCehqJbLHTgNXcKmfFYCwKZJp.aINsxdepuysANqyrNfBHMmbfpCs,
				new SafeAction<CanceledEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
				})
			},
			{
				ScGjCehqJbLHTgNXcKmfFYCwKZJp.FZMOQWNOeHtGxdPTCjkbKhypcZrH,
				new SafeAction<TimedOutEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
				})
			},
			{
				ScGjCehqJbLHTgNXcKmfFYCwKZJp.ABchwhDllxYJyZPlcZPhoqaCCBl,
				new SafeAction<StartedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
				})
			},
			{
				ScGjCehqJbLHTgNXcKmfFYCwKZJp.GcfjljcglleFSsSWstdsMiSqqXV,
				new SafeAction<StoppedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
				})
			},
			{
				ScGjCehqJbLHTgNXcKmfFYCwKZJp.BnoGDRJVJJkmalzbYKviQcGpYaW,
				new SafeAction<ConflictFoundEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
				})
			}
		};

		[CompilerGenerated]
		private static Action<Exception> ghYJxANpWGveOpFBjMcwfFSLCAL;

		[CompilerGenerated]
		private static Action<Exception> EyBkQPbuchCaphJGejOOODWtaKP;

		[CompilerGenerated]
		private static Action<Exception> bpsDUSEXpyykcWJldajgxpogOph;

		[CompilerGenerated]
		private static Action<Exception> OgstaTqPAOzzFqCzJSUslPPVDpI;

		[CompilerGenerated]
		private static Action<Exception> gmAvcjyWGshkTcssusYxOZNlQzx;

		[CompilerGenerated]
		private static Action<Exception> JzBaUdlwHurNHsAdDtAfhdMolvT;

		[CompilerGenerated]
		private static Action<Exception> UfcPvNRbPeRZHsphQpaqIgDeGVG;

		public static InputMapper Default => BgVAlBbqHGOjWMKDVziUeWXeAbTf ?? (BgVAlBbqHGOjWMKDVziUeWXeAbTf = new InputMapper(isDefault: true));

		public Options options
		{
			get
			{
				Options obj = KzCUiawVxPrFPXkDhBSZNsDIaLv;
				if (obj == null)
				{
					while (true)
					{
						int num = 1308672157;
						while (true)
						{
							switch (num ^ 0x4E00C09C)
							{
							case 0:
								break;
							case 1:
								goto IL_0028;
							default:
								return KzCUiawVxPrFPXkDhBSZNsDIaLv = Default.options.Clone();
							}
							break;
							IL_0028:
							if (JxAzCfJgIjKncgvkHADgyQmPizR)
							{
								goto end_IL_000a;
							}
							num = 1308672158;
						}
						continue;
						end_IL_000a:
						break;
					}
					obj = (KzCUiawVxPrFPXkDhBSZNsDIaLv = new Options());
				}
				return obj;
			}
			set
			{
				KzCUiawVxPrFPXkDhBSZNsDIaLv = value;
			}
		}

		public Context mappingContext => LEoExUcRwpkZBlcxtzqcKcxyEBJE.context;

		public Status status => LEoExUcRwpkZBlcxtzqcKcxyEBJE.status;

		public float timeRemaining => LEoExUcRwpkZBlcxtzqcKcxyEBJE.timeRemaining;

		internal int id => PvsuSGRwBhtIXJREfzZZvubyLRp;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.UWHKuObharcWmREwTRfXxbHHaMG;
					int num = 1002440547;
					while (true)
					{
						switch (num ^ 0x3BC00763)
						{
						case 2:
							goto IL_0004;
						case 1:
							break;
						default:
							pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<InputMappedEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] + value;
							return;
						}
						break;
						IL_0004:
						num = 1002440546;
					}
				}
			}
			remove
			{
				if (value == null)
				{
					while (true)
					{
						switch (0x4A56E8E1 ^ 0x4A56E8E0)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.UWHKuObharcWmREwTRfXxbHHaMG;
				pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<InputMappedEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] - value;
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value == null)
				{
					goto IL_0003;
				}
				goto IL_002d;
				IL_0003:
				int num = -1420423368;
				goto IL_0008;
				IL_0008:
				ScGjCehqJbLHTgNXcKmfFYCwKZJp key = default(ScGjCehqJbLHTgNXcKmfFYCwKZJp);
				switch (num ^ -1420423367)
				{
				case 2:
					break;
				case 1:
					return;
				case 0:
					goto IL_002d;
				default:
					pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<ErrorEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] + value;
					return;
				}
				goto IL_0003;
				IL_002d:
				key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.ZtUwsrwXzuJnuLzcmZfjeVDsJIY;
				num = -1420423366;
				goto IL_0008;
			}
			remove
			{
				if (value == null)
				{
					while (true)
					{
						switch (-2105076277 ^ -2105076279)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.ZtUwsrwXzuJnuLzcmZfjeVDsJIY;
				pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<ErrorEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] - value;
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.aINsxdepuysANqyrNfBHMmbfpCs;
					pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<CanceledEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] + value;
				}
			}
			remove
			{
				if (value == null)
				{
					while (true)
					{
						switch (0x4BC1B7BE ^ 0x4BC1B7BF)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.aINsxdepuysANqyrNfBHMmbfpCs;
				pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<CanceledEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] - value;
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.FZMOQWNOeHtGxdPTCjkbKhypcZrH;
					pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<TimedOutEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] + value;
					int num = -557230393;
					while (true)
					{
						switch (num ^ -557230394)
						{
						case 0:
							goto IL_0004;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0004:
						num = -557230396;
					}
				}
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.FZMOQWNOeHtGxdPTCjkbKhypcZrH;
					pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<TimedOutEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] - value;
					int num = 571425773;
					while (true)
					{
						switch (num ^ 0x220F43EF)
						{
						case 0:
							goto IL_0004;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0004:
						num = 571425774;
					}
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.ABchwhDllxYJyZPlcZPhoqaCCBl;
					int num = -1655967559;
					while (true)
					{
						switch (num ^ -1655967560)
						{
						case 0:
							num = -1655967558;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<StartedEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] + value;
							num = -1655967557;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				if (value == null)
				{
					goto IL_0003;
				}
				goto IL_002d;
				IL_0003:
				int num = 1030037016;
				goto IL_0008;
				IL_0008:
				switch (num ^ 0x3D651E1A)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_002d;
				case 0:
					return;
				}
				goto IL_0003;
				IL_002d:
				ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.ABchwhDllxYJyZPlcZPhoqaCCBl;
				pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<StartedEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] - value;
				num = 1030037018;
				goto IL_0008;
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.GcfjljcglleFSsSWstdsMiSqqXV;
					pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<StoppedEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] + value;
				}
			}
			remove
			{
				if (value == null)
				{
					while (true)
					{
						switch (0x56264ED0 ^ 0x56264ED2)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.GcfjljcglleFSsSWstdsMiSqqXV;
				pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<StoppedEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] - value;
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value == null)
				{
					while (true)
					{
						switch (0x1E43B473 ^ 0x1E43B471)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.BnoGDRJVJJkmalzbYKviQcGpYaW;
				pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<ConflictFoundEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					ScGjCehqJbLHTgNXcKmfFYCwKZJp key = ScGjCehqJbLHTgNXcKmfFYCwKZJp.BnoGDRJVJJkmalzbYKviQcGpYaW;
					int num = 420326610;
					while (true)
					{
						switch (num ^ 0x190DACD0)
						{
						case 0:
							goto IL_0004;
						case 1:
							break;
						default:
							pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] = (SafeAction<ConflictFoundEventData>)pGOgISGmzqLUgLQoxeyCGBYLDXUk[key] - value;
							return;
						}
						break;
						IL_0004:
						num = 420326609;
					}
				}
			}
		}

		private static int ymfZHQJFLVXluDlZAfQnEXIukxp()
		{
			int result = yaBkMAQfYXPgUDRJlmRDPEwrgbOa;
			if (yaBkMAQfYXPgUDRJlmRDPEwrgbOa == int.MaxValue)
			{
				goto IL_0012;
			}
			goto IL_0041;
			IL_0012:
			int num = 1373120075;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ 0x51D8264A)
				{
				case 3:
					break;
				case 1:
					yaBkMAQfYXPgUDRJlmRDPEwrgbOa = 0;
					num = 1373120072;
					continue;
				case 0:
					goto IL_0041;
				default:
					return result;
				}
				break;
			}
			goto IL_0012;
			IL_0041:
			yaBkMAQfYXPgUDRJlmRDPEwrgbOa++;
			num = 1373120072;
			goto IL_0017;
		}

		public InputMapper()
			: this(isDefault: false)
		{
			while (true)
			{
				int num = -1916811466;
				while (true)
				{
					switch (num ^ -1916811465)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0025;
					case 2:
						return;
					}
					break;
					IL_0025:
					PvsuSGRwBhtIXJREfzZZvubyLRp = ymfZHQJFLVXluDlZAfQnEXIukxp();
					num = -1916811467;
				}
			}
		}

		private InputMapper(bool isDefault)
		{
			JxAzCfJgIjKncgvkHADgyQmPizR = isDefault;
			if (JxAzCfJgIjKncgvkHADgyQmPizR)
			{
				KzCUiawVxPrFPXkDhBSZNsDIaLv = new Options();
			}
			LEoExUcRwpkZBlcxtzqcKcxyEBJE = new daUybjwOixexSGMKtqpHUdttZhkL(this, pGOgISGmzqLUgLQoxeyCGBYLDXUk);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			using (Dictionary<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate>.Enumerator enumerator = pGOgISGmzqLUgLQoxeyCGBYLDXUk.GetEnumerator())
			{
				KeyValuePair<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate> current = default(KeyValuePair<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate>);
				while (true)
				{
					int num;
					int num2;
					if (!enumerator.MoveNext())
					{
						num = -215351136;
						num2 = num;
					}
					else
					{
						num = -215351131;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -215351132)
						{
						case 3:
							num = -215351131;
							continue;
						default:
							return;
						case 2:
							break;
						case 0:
							current.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
							num = -215351130;
							continue;
						case 1:
							current = enumerator.Current;
							num = -215351132;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}
		}

		public void RemoveAllEventListeners()
		{
			using (Dictionary<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate>.Enumerator enumerator = pGOgISGmzqLUgLQoxeyCGBYLDXUk.GetEnumerator())
			{
				KeyValuePair<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate> current = default(KeyValuePair<ScGjCehqJbLHTgNXcKmfFYCwKZJp, SafeDelegate>);
				while (true)
				{
					int num;
					int num2;
					if (enumerator.MoveNext())
					{
						num = 836964298;
						num2 = num;
					}
					else
					{
						num = 836964300;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x31E30FCE)
						{
						case 0:
							num = 836964298;
							continue;
						default:
							return;
						case 4:
							current = enumerator.Current;
							num = 836964303;
							continue;
						case 1:
							current.Value.Clear();
							num = 836964301;
							continue;
						case 3:
							break;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		internal void nKQBApeeoEJRlcUYbYamozZTUjbE(object P_0)
		{
		}

		internal void TSxxUoGSamSYqjUojdcrDPGCpyJ()
		{
		}

		public bool Start(Context mappingContext)
		{
			return NoiITHOkBgdirKSZopWLLfLYZOJ(mappingContext, (KzCUiawVxPrFPXkDhBSZNsDIaLv != null) ? KzCUiawVxPrFPXkDhBSZNsDIaLv : Default.options);
		}

		public void Stop()
		{
			LEoExUcRwpkZBlcxtzqcKcxyEBJE.LMUxrvabDmlOyshBlFENjJpzElf("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			TSxxUoGSamSYqjUojdcrDPGCpyJ();
			KzCUiawVxPrFPXkDhBSZNsDIaLv = null;
		}

		private bool NoiITHOkBgdirKSZopWLLfLYZOJ(Context P_0, Options P_1)
		{
			if (!ReInput.isReady)
			{
				return false;
			}
			if (P_0 == null)
			{
				Logger.LogError("The Context cannot be null.");
				goto IL_0016;
			}
			int num;
			if (P_0.controllerMap == null)
			{
				num = -628140619;
			}
			else
			{
				if (P_0.actionElementMapToReplace == null)
				{
					goto IL_0099;
				}
				num = -628140618;
			}
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ -628140618)
				{
				case 4:
					break;
				case 5:
					return false;
				case 3:
					Logger.LogError("The Controller Map cannot be null.");
					num = -628140620;
					continue;
				case 0:
					goto IL_0062;
				case 2:
					return false;
				default:
					return false;
				}
				break;
				IL_0062:
				if (!P_0.controllerMap.ContainsElementMap(P_0.actionElementMapToReplace))
				{
					Logger.LogError("The Action Element Map must belong to the same Controller Map you are passing in.");
					num = -628140617;
					continue;
				}
				goto IL_0099;
			}
			goto IL_0016;
			IL_0016:
			num = -628140621;
			goto IL_001b;
			IL_0099:
			try
			{
				LEoExUcRwpkZBlcxtzqcKcxyEBJE.NoiITHOkBgdirKSZopWLLfLYZOJ(P_0, P_1);
				return true;
			}
			catch
			{
				LEoExUcRwpkZBlcxtzqcKcxyEBJE.LMUxrvabDmlOyshBlFENjJpzElf("Failed to start due to an exception.");
				return false;
			}
		}

		[CompilerGenerated]
		private static void bOXOXMSIseINaVoIJMpRQvRRYMp(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
		}

		[CompilerGenerated]
		private static void EreXIoHgZSDQKKoBEjvcjrGvsLZN(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
		}

		[CompilerGenerated]
		private static void hCIvNRRFeBGJEqklKBXQPNqJbfp(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
		}

		[CompilerGenerated]
		private static void SsFILxHxyfubADpNJDLdkAbRDmPR(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
		}

		[CompilerGenerated]
		private static void cUdGkijyUKSfnWfFFJdQajYOUod(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
		}

		[CompilerGenerated]
		private static void gDJhXOuoHbcEbCvxlghSFDPDstP(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
		}

		[CompilerGenerated]
		private static void cyAGixGijKKZWSPyIKPJvBzhiNo(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
		}
	}
}
