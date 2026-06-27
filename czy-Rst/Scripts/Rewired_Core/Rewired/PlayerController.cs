using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public class PlayerController : IPlayerController
	{
		public class Definition
		{
			public bool enabled = true;

			public int playerId = -1;

			public ICollection<Element.Definition> elements;
		}

		public static class Factory
		{
			public static PlayerController Create(Definition definition)
			{
				return new PlayerController(definition);
			}
		}

		public class Axis : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				public AxisCoordinateMode coordinateMode;

				public float absoluteToRelativeSensitivity;

				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Absolute;
					absoluteToRelativeSensitivity = 1f;
				}

				internal virtual Element icnTaLmNCyWqoIswqmwWxvSwtAeC(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float mtYctEDTThicBUVSkdynBmRIOPMRA = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float OOOVyQwrNTYcMnOawZelirmLYfUJ = 1f;

			private AxisCoordinateMode vmgVPpADuPXFgByzGXafBaPTPNIi;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return OOOVyQwrNTYcMnOawZelirmLYfUJ;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					OOOVyQwrNTYcMnOawZelirmLYfUJ = value;
				}
			}

			public AxisCoordinateMode coordinateMode => vmgVPpADuPXFgByzGXafBaPTPNIi;

			public virtual float value
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return 0f;
					}
					float num = base.player.GetAxis(base.actionId);
					switch (base.player.GetAxisCoordinateMode(base.actionId))
					{
					case AxisCoordinateMode.Relative:
						if (vmgVPpADuPXFgByzGXafBaPTPNIi == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (vmgVPpADuPXFgByzGXafBaPTPNIi == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * OOOVyQwrNTYcMnOawZelirmLYfUJ;
						}
						break;
					}
					return num;
				}
			}

			public virtual float valueRaw
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return 0f;
					}
					return base.player.GetAxisRaw(base.actionId);
				}
			}

			internal Axis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				OOOVyQwrNTYcMnOawZelirmLYfUJ = P_1.absoluteToRelativeSensitivity;
				vmgVPpADuPXFgByzGXafBaPTPNIi = P_1.coordinateMode;
			}
		}

		public class MouseAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Relative;
					absoluteToRelativeSensitivity = 600f;
				}

				internal virtual Element evMPVBoEJaeAsEesaoVmnywbjOZpA(PlayerController P_0)
				{
					return new MouseAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			[CustomObfuscation(rename = false)]
			internal const float defaultAbsoluteToRelativeSensitivity = 600f;

			float Axis.value
			{
				get
				{
					float num = base.value;
					if (num == 0f)
					{
						return 0f;
					}
					if (base.coordinateMode == AxisCoordinateMode.Relative && base.player.GetAxisCoordinateMode(base.actionId) == AxisCoordinateMode.Absolute)
					{
						num *= (float)Screen.currentResolution.width / 1920f;
					}
					return num;
				}
			}

			internal MouseAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
			}
		}

		public class Axis2D : CompoundElement
		{
			public new class Definition : CompoundElement.Definition
			{
				private Axis.Definition OmwGNVDTmaAOlaGPFOnaCQOlRVaEc;

				private Axis.Definition fnjBwxhtfFfBumdCFchNMtYXqHBp;

				public Axis.Definition xAxis
				{
					get
					{
						return OmwGNVDTmaAOlaGPFOnaCQOlRVaEc;
					}
					set
					{
						OmwGNVDTmaAOlaGPFOnaCQOlRVaEc = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return fnjBwxhtfFfBumdCFchNMtYXqHBp;
					}
					set
					{
						fnjBwxhtfFfBumdCFchNMtYXqHBp = value;
					}
				}

				internal virtual Element yomMjZhBovNHylPWDBsVLafdhWic(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int rILDlpaGNnLykkGwbxFVyUODcOKo = 0;

			internal const int ipRZGYLDJNmuSGnnWDTGTSahmoWD = 1;

			internal const int xNeKJSWNObjxasKvGUQZBsDnOFjg = 2;

			public Axis xAxis => AVcPVNWYYMByNsnYOBCbPycnogyX<Axis>(0);

			public Axis yAxis => AVcPVNWYYMByNsnYOBCbPycnogyX<Axis>(1);

			public virtual Vector2 value => new Vector2(AVcPVNWYYMByNsnYOBCbPycnogyX<Axis>(0).value, AVcPVNWYYMByNsnYOBCbPycnogyX<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(AVcPVNWYYMByNsnYOBCbPycnogyX<Axis>(0).valueRaw, AVcPVNWYYMByNsnYOBCbPycnogyX<Axis>(1).valueRaw);

			internal Axis2D(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1, P_2)
			{
			}

			internal Axis2D(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new Axis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new Axis.Definition()
				})
			{
			}
		}

		public sealed class MouseAxis2D : Axis2D
		{
			public new class Definition : Axis2D.Definition
			{
				public new MouseAxis.Definition xAxis
				{
					get
					{
						return base.xAxis as MouseAxis.Definition;
					}
					set
					{
						base.xAxis = value;
					}
				}

				public new MouseAxis.Definition yAxis
				{
					get
					{
						return base.yAxis as MouseAxis.Definition;
					}
					set
					{
						base.yAxis = value;
					}
				}

				internal virtual Element yUewGoIIJzHVZGxjzzuZPCpiYcFy(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => AVcPVNWYYMByNsnYOBCbPycnogyX<MouseAxis>(0);

			public new MouseAxis yAxis => AVcPVNWYYMByNsnYOBCbPycnogyX<MouseAxis>(1);

			internal MouseAxis2D(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new MouseAxis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new MouseAxis.Definition()
				})
			{
			}
		}

		public sealed class Button : ElementWithSource
		{
			public new class Definition : ElementWithSource.Definition
			{
				internal virtual Element NYtdahKVuvqGdAHNqntyKqrKsMui(PlayerController P_0)
				{
					return new Button(P_0, this);
				}
			}

			public bool value
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButton(base.actionId);
				}
			}

			public bool valuePrev
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonPrev(base.actionId);
				}
			}

			public bool justPressed
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonDown(base.actionId);
				}
			}

			public bool justReleased
			{
				get
				{
					if (!base.selfAndParentEnabled || base.player == null)
					{
						return false;
					}
					return base.player.GetButtonUp(base.actionId);
				}
			}

			internal Button(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
			}
		}

		public abstract class CompoundElement : Element
		{
			public new abstract class Definition : Element.Definition
			{
				public Definition()
				{
				}
			}

			private readonly List<Element> EOaFMkUIQgPpGfLnMbAeWgGBKFKH;

			internal int IuNESsEVWlFGKcDdjjVxadezQPxJb => EOaFMkUIQgPpGfLnMbAeWgGBKFKH.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				EOaFMkUIQgPpGfLnMbAeWgGBKFKH = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						aNFbxGiXWeWMXzEFpIdEclzKnWwwA(P_2[i].wvIRpHGMOCCXBBhFoMSOksqsMFQaA(P_0));
					}
				}
			}

			internal _0001 AVcPVNWYYMByNsnYOBCbPycnogyX<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)EOaFMkUIQgPpGfLnMbAeWgGBKFKH.Count)
				{
					return null;
				}
				return EOaFMkUIQgPpGfLnMbAeWgGBKFKH[P_0] as _0001;
			}

			internal void XvpdqvHwzwsBxElCucVhEJyjYdCdA(List<Element> P_0)
			{
				for (int i = 0; i < EOaFMkUIQgPpGfLnMbAeWgGBKFKH.Count; i++)
				{
					if (EOaFMkUIQgPpGfLnMbAeWgGBKFKH[i] is CompoundElement)
					{
						(EOaFMkUIQgPpGfLnMbAeWgGBKFKH[i] as CompoundElement).XvpdqvHwzwsBxElCucVhEJyjYdCdA(P_0);
					}
					else
					{
						P_0.Add(EOaFMkUIQgPpGfLnMbAeWgGBKFKH[i]);
					}
				}
			}

			internal void aNFbxGiXWeWMXzEFpIdEclzKnWwwA(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				EOaFMkUIQgPpGfLnMbAeWgGBKFKH.Add(P_0);
				P_0.OKicQiBEstVKpOWENiehMfLqoJiFb = true;
			}
		}

		public abstract class Element
		{
			[CustomObfuscation(rename = false)]
			internal enum Type
			{
				[CustomObfuscation(rename = false)]
				Button = 0,
				[CustomObfuscation(rename = false)]
				Axis = 1,
				[CustomObfuscation(rename = false)]
				MouseAxis = 2,
				[CustomObfuscation(rename = false)]
				MouseWheelAxis = 3,
				[CustomObfuscation(rename = false)]
				Axis2D = 100,
				[CustomObfuscation(rename = false)]
				MouseAxis2D = 101,
				[CustomObfuscation(rename = false)]
				MouseWheel = 102
			}

			[CustomObfuscation(rename = false)]
			internal enum TypeWithSource
			{
				[CustomObfuscation(rename = false)]
				Button = 0,
				[CustomObfuscation(rename = false)]
				Axis = 1,
				[CustomObfuscation(rename = false)]
				MouseAxis = 2,
				[CustomObfuscation(rename = false)]
				MouseWheelAxis = 3
			}

			[CustomObfuscation(rename = false)]
			internal enum CompoundTypes
			{
				[CustomObfuscation(rename = false)]
				Axis2D = 100,
				[CustomObfuscation(rename = false)]
				MouseAxis2D = 101,
				[CustomObfuscation(rename = false)]
				MouseWheel = 102
			}

			public abstract class Definition
			{
				public bool enabled;

				public string name;

				public Definition()
				{
					enabled = true;
					name = null;
				}

				internal abstract Element wvIRpHGMOCCXBBhFoMSOksqsMFQaA(PlayerController P_0);
			}

			internal struct XLbaIzMFvKAvOxHJdfTmEwIPhcFb
			{
				public ControllerElementType HeovMmVoAadsgLcQLyAVPXwvLiof;

				public int oGjwISpdKXUgVJFrZKsFufZHUuSW;

				public float qFREZNijcLDIReOIQPTGFDLvxyymA;

				public XLbaIzMFvKAvOxHJdfTmEwIPhcFb(ControllerElementType P_0, int P_1, float P_2)
				{
					HeovMmVoAadsgLcQLyAVPXwvLiof = P_0;
					oGjwISpdKXUgVJFrZKsFufZHUuSW = P_1;
					qFREZNijcLDIReOIQPTGFDLvxyymA = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController mJOSQeUCbYhbBCAyQJTAUDGEPScW;

			private bool HUgnXmMrxZCjhMQPMHLjCwAdwBTh;

			private bool IuIrtYrhALVRvPTHGArPvKoMHSRZ = true;

			private string JoPBvTirumLzPcjeCHdClVKnGFiYb;

			private static int[] QBQjOtTUmCmOuJoiNmuVOBaDVBRV;

			private static int[] AHNwgaeMStfWPAmZQzDTWbuphSVdb;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(mJOSQeUCbYhbBCAyQJTAUDGEPScW.VCtGkbqWdMvdqYduBaFoqHFCBrpdA);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (IuIrtYrhALVRvPTHGArPvKoMHSRZ)
					{
						return mJOSQeUCbYhbBCAyQJTAUDGEPScW.fmZEbFlIAQAQXjzcuXQLIBvqORVHA;
					}
					return false;
				}
			}

			internal bool OKicQiBEstVKpOWENiehMfLqoJiFb
			{
				get
				{
					return HUgnXmMrxZCjhMQPMHLjCwAdwBTh;
				}
				set
				{
					HUgnXmMrxZCjhMQPMHLjCwAdwBTh = true;
				}
			}

			public bool enabled
			{
				get
				{
					return IuIrtYrhALVRvPTHGArPvKoMHSRZ;
				}
				set
				{
					if (IuIrtYrhALVRvPTHGArPvKoMHSRZ != value)
					{
						IuIrtYrhALVRvPTHGArPvKoMHSRZ = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return JoPBvTirumLzPcjeCHdClVKnGFiYb;
				}
				set
				{
					JoPBvTirumLzPcjeCHdClVKnGFiYb = value;
				}
			}

			internal Element(PlayerController P_0, Definition P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("definition");
				}
				mJOSQeUCbYhbBCAyQJTAUDGEPScW = P_0;
				IuIrtYrhALVRvPTHGArPvKoMHSRZ = P_1.enabled;
				JoPBvTirumLzPcjeCHdClVKnGFiYb = P_1.name;
			}

			internal virtual void MkWnSjZuAfXyQSoemfLXQBAgJyqe()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (QBQjOtTUmCmOuJoiNmuVOBaDVBRV == null)
				{
					QBQjOtTUmCmOuJoiNmuVOBaDVBRV = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(QBQjOtTUmCmOuJoiNmuVOBaDVBRV, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (AHNwgaeMStfWPAmZQzDTWbuphSVdb == null)
				{
					AHNwgaeMStfWPAmZQzDTWbuphSVdb = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(AHNwgaeMStfWPAmZQzDTWbuphSVdb, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static int GetMaxElementCount(Type type)
			{
				if (IsTypeWithSource(type))
				{
					return 1;
				}
				if (IsCompoundType(type))
				{
					return type switch
					{
						Type.Axis2D => 2, 
						Type.MouseAxis2D => 2, 
						Type.MouseWheel => 2, 
						_ => throw new NotImplementedException(), 
					};
				}
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static string GetElementTitle(Type type, int index)
			{
				if (index < 0 || index > GetMaxElementCount(type))
				{
					return null;
				}
				if (IsTypeWithSource(type))
				{
					return null;
				}
				if (IsCompoundType(type))
				{
					if ((uint)(type - 100) <= 2u)
					{
						if (index != 0)
						{
							return "Y Axis";
						}
						return "X Axis";
					}
					throw new NotImplementedException();
				}
				throw new NotImplementedException();
			}

			[CustomObfuscation(rename = false)]
			internal static Definition CreateDefinition(Type type)
			{
				return type switch
				{
					Type.Axis => new Axis.Definition(), 
					Type.Button => new Button.Definition(), 
					Type.MouseAxis => new MouseAxis.Definition(), 
					Type.MouseWheelAxis => new MouseWheelAxis.Definition(), 
					Type.Axis2D => new Axis2D.Definition(), 
					Type.MouseAxis2D => new MouseAxis2D.Definition(), 
					Type.MouseWheel => new MouseWheel.Definition(), 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		public abstract class ElementWithSource : Element
		{
			public new abstract class Definition : Element.Definition
			{
				private int jgUayFyyKmKddTjAdFrgssAZgPvX;

				public int actionId
				{
					get
					{
						return jgUayFyyKmKddTjAdFrgssAZgPvX;
					}
					set
					{
						jgUayFyyKmKddTjAdFrgssAZgPvX = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || jgUayFyyKmKddTjAdFrgssAZgPvX < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(jgUayFyyKmKddTjAdFrgssAZgPvX)?.name;
					}
					set
					{
						if (!ReInput.isReady)
						{
							Logger.LogError("You cannot set an Action Name because Rewired has not been intialized.");
							return;
						}
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							jgUayFyyKmKddTjAdFrgssAZgPvX = -1;
						}
						else
						{
							jgUayFyyKmKddTjAdFrgssAZgPvX = action.id;
						}
					}
				}

				public Definition()
				{
					jgUayFyyKmKddTjAdFrgssAZgPvX = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int KBRrJanZoepJKnBDCixXFTqOvnLkA = -1;

			public int actionId
			{
				get
				{
					return KBRrJanZoepJKnBDCixXFTqOvnLkA;
				}
				set
				{
					KBRrJanZoepJKnBDCixXFTqOvnLkA = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || KBRrJanZoepJKnBDCixXFTqOvnLkA < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(KBRrJanZoepJKnBDCixXFTqOvnLkA)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							KBRrJanZoepJKnBDCixXFTqOvnLkA = -1;
						}
						else
						{
							KBRrJanZoepJKnBDCixXFTqOvnLkA = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				KBRrJanZoepJKnBDCixXFTqOvnLkA = P_1.actionId;
			}
		}

		public sealed class MouseWheel : Axis2D
		{
			public new class Definition : Axis2D.Definition
			{
				public new MouseWheelAxis.Definition xAxis
				{
					get
					{
						return base.xAxis as MouseWheelAxis.Definition;
					}
					set
					{
						base.xAxis = value;
					}
				}

				public new MouseWheelAxis.Definition yAxis
				{
					get
					{
						return base.yAxis as MouseWheelAxis.Definition;
					}
					set
					{
						base.yAxis = value;
					}
				}

				internal virtual Element qOmUyAfCMsKLCqKhIsJBsTMuoOnp(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => AVcPVNWYYMByNsnYOBCbPycnogyX<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => AVcPVNWYYMByNsnYOBCbPycnogyX<MouseWheelAxis>(1);

			internal MouseWheel(PlayerController P_0, Definition P_1)
				: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
				{
					(P_1.xAxis != null) ? P_1.xAxis : new MouseWheelAxis.Definition(),
					(P_1.yAxis != null) ? P_1.yAxis : new MouseWheelAxis.Definition()
				})
			{
			}
		}

		public sealed class MouseWheelAxis : Axis
		{
			public new class Definition : Axis.Definition
			{
				public float repeatRate;

				public Definition()
				{
					coordinateMode = AxisCoordinateMode.Relative;
					repeatRate = 4f;
				}

				internal virtual Element ODuHKgBZYwWGqUhDzPhRCJPntbcsA(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float jqPAsphoIeDKFNICuPVADzjFujJWA = 0.01f;

			private float cuktSNhFuwOllKFeeFoMaAbOACnWA = 0.25f;

			private double XJwEaJJwflFPgvEexiubejCgIQVac;

			private float AAqUTWlUunuYYkAfIbytDvdaeOz;

			public float repeatRate
			{
				get
				{
					if (cuktSNhFuwOllKFeeFoMaAbOACnWA == 0f)
					{
						return 0f;
					}
					return 1f / cuktSNhFuwOllKFeeFoMaAbOACnWA;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						cuktSNhFuwOllKFeeFoMaAbOACnWA = 0f;
					}
					else
					{
						cuktSNhFuwOllKFeeFoMaAbOACnWA = 1f / value;
					}
				}
			}

			float Axis.value
			{
				get
				{
					if (!base.selfAndParentEnabled)
					{
						return 0f;
					}
					return AAqUTWlUunuYYkAfIbytDvdaeOz;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal void SOuzyNhauGfoPojAyOVwLXGXtrTF()
			{
				base.MkWnSjZuAfXyQSoemfLXQBAgJyqe();
				if (base.selfAndParentEnabled)
				{
					AAqUTWlUunuYYkAfIbytDvdaeOz = AMjGVXhfSzFFsFEMQUtPmDWbnFIRA();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					pgZKTMTlUvauOTjILgMwiPmhyjsbA();
				}
			}

			private float AMjGVXhfSzFFsFEMQUtPmDWbnFIRA()
			{
				if (base.player == null)
				{
					return 0f;
				}
				float num = base.player.GetAxis(base.actionId);
				switch (base.player.GetAxisCoordinateMode(base.actionId))
				{
				case AxisCoordinateMode.Absolute:
				{
					bool flag = false;
					if (base.player.GetButtonDown(base.actionId))
					{
						flag = true;
						num = 1f;
					}
					else if (base.player.GetNegativeButtonDown(base.actionId))
					{
						flag = true;
						num = -1f;
					}
					if (!flag && ReInput.unscaledTime < XJwEaJJwflFPgvEexiubejCgIQVac + (double)cuktSNhFuwOllKFeeFoMaAbOACnWA)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					XJwEaJJwflFPgvEexiubejCgIQVac = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void pgZKTMTlUvauOTjILgMwiPmhyjsbA()
			{
				AAqUTWlUunuYYkAfIbytDvdaeOz = 0f;
				XJwEaJJwflFPgvEexiubejCgIQVac = 0.0;
			}
		}

		internal readonly int EhPgbjEHiDiwEXvFGrVWBQrjWRfBB;

		private bool fmZEbFlIAQAQXjzcuXQLIBvqORVHA;

		private int VCtGkbqWdMvdqYduBaFoqHFCBrpdA;

		private readonly AList<Element> qISCrqHCbFqbjiAzBEbeXVNPXAHpb;

		private readonly AList<Button> oVWNwPjbnBAGBoTzbysWMQuzcegv;

		private readonly AList<Axis> NaaAdQcArCoNCnHxLYAydtJllbifA;

		private readonly ReadOnlyCollection<Element> oLQxGBkbafUGEabsglMMsRrIPkV;

		private readonly ReadOnlyCollection<Button> yJNcbapAeriXvOmRdjGRDJDDAymP;

		private readonly ReadOnlyCollection<Axis> ClpRYhMuzZRFpcKUpyxJqKUlrixm;

		private readonly List<Element.XLbaIzMFvKAvOxHJdfTmEwIPhcFb> tucjsxEnJnhxdzpBDnwfEDmcKLsr;

		private Action<int, bool> YnpHSgXvTegibrsslVKejRFGqNwy;

		private Action<int, float> fkWgvTVcQgfJKYhtLThhFTwGSGJn;

		private Action<bool> gBFFGDwpCfikFlWvtAIWwZxXTAdS;

		bool IPlayerController.enabled
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return false;
				}
				return fmZEbFlIAQAQXjzcuXQLIBvqORVHA;
			}
			set
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				}
				else
				{
					if (fmZEbFlIAQAQXjzcuXQLIBvqORVHA == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					fmZEbFlIAQAQXjzcuXQLIBvqORVHA = value;
					for (int i = 0; i < qISCrqHCbFqbjiAzBEbeXVNPXAHpb._count; i++)
					{
						qISCrqHCbFqbjiAzBEbeXVNPXAHpb[i].enabled = value;
					}
					if (gBFFGDwpCfikFlWvtAIWwZxXTAdS != null)
					{
						try
						{
							gBFFGDwpCfikFlWvtAIWwZxXTAdS(value);
						}
						catch (Exception ex)
						{
							Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
						}
					}
				}
			}
		}

		int IPlayerController.playerId
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return -1;
				}
				return VCtGkbqWdMvdqYduBaFoqHFCBrpdA;
			}
			set
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				}
				else if (VCtGkbqWdMvdqYduBaFoqHFCBrpdA != value)
				{
					VCtGkbqWdMvdqYduBaFoqHFCBrpdA = value;
					ClearVars();
				}
			}
		}

		IList<Button> IPlayerController.buttons
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				return yJNcbapAeriXvOmRdjGRDJDDAymP;
			}
		}

		IList<Axis> IPlayerController.axes
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				return ClpRYhMuzZRFpcKUpyxJqKUlrixm;
			}
		}

		IList<Element> IPlayerController.elements
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return null;
				}
				return oLQxGBkbafUGEabsglMMsRrIPkV;
			}
		}

		int IPlayerController.buttonCount
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return 0;
				}
				if (oVWNwPjbnBAGBoTzbysWMQuzcegv == null)
				{
					return 0;
				}
				return oVWNwPjbnBAGBoTzbysWMQuzcegv._count;
			}
		}

		int IPlayerController.axisCount
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return 0;
				}
				if (NaaAdQcArCoNCnHxLYAydtJllbifA == null)
				{
					return 0;
				}
				return NaaAdQcArCoNCnHxLYAydtJllbifA._count;
			}
		}

		int IPlayerController.elementCount
		{
			get
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
					return 0;
				}
				if (qISCrqHCbFqbjiAzBEbeXVNPXAHpb == null)
				{
					return 0;
				}
				return qISCrqHCbFqbjiAzBEbeXVNPXAHpb._count;
			}
		}

		internal Player MDDgkwbJiEBbIwTqycYiMjItJMYL
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(Rewired_002EIPlayerController_002EplayerId);
			}
		}

		event Action<int, bool> IPlayerController.ButtonStateChangedEvent
		{
			add
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				}
				else
				{
					YnpHSgXvTegibrsslVKejRFGqNwy = (Action<int, bool>)Delegate.Combine(YnpHSgXvTegibrsslVKejRFGqNwy, value);
				}
			}
			remove
			{
				YnpHSgXvTegibrsslVKejRFGqNwy = (Action<int, bool>)Delegate.Remove(YnpHSgXvTegibrsslVKejRFGqNwy, value);
			}
		}

		event Action<int, float> IPlayerController.AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				}
				else
				{
					fkWgvTVcQgfJKYhtLThhFTwGSGJn = (Action<int, float>)Delegate.Combine(fkWgvTVcQgfJKYhtLThhFTwGSGJn, value);
				}
			}
			remove
			{
				fkWgvTVcQgfJKYhtLThhFTwGSGJn = (Action<int, float>)Delegate.Remove(fkWgvTVcQgfJKYhtLThhFTwGSGJn, value);
			}
		}

		event Action<bool> IPlayerController.EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
				{
					ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				}
				else
				{
					gBFFGDwpCfikFlWvtAIWwZxXTAdS = (Action<bool>)Delegate.Combine(gBFFGDwpCfikFlWvtAIWwZxXTAdS, value);
				}
			}
			remove
			{
				gBFFGDwpCfikFlWvtAIWwZxXTAdS = (Action<bool>)Delegate.Remove(gBFFGDwpCfikFlWvtAIWwZxXTAdS, value);
			}
		}

		internal PlayerController(Definition P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("definition");
			}
			if (P_0.elements == null)
			{
				throw new ArgumentNullException("definition.elements");
			}
			EhPgbjEHiDiwEXvFGrVWBQrjWRfBB = ReInput._id;
			VCtGkbqWdMvdqYduBaFoqHFCBrpdA = P_0.playerId;
			fmZEbFlIAQAQXjzcuXQLIBvqORVHA = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				CqzZbDeotiTnfLcjQLhaChxwdmYP(element.wvIRpHGMOCCXBBhFoMSOksqsMFQaA(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			qISCrqHCbFqbjiAzBEbeXVNPXAHpb = new AList<Element>(list);
			oVWNwPjbnBAGBoTzbysWMQuzcegv = new AList<Button>(list3);
			NaaAdQcArCoNCnHxLYAydtJllbifA = new AList<Axis>(list4);
			oLQxGBkbafUGEabsglMMsRrIPkV = new ReadOnlyCollection<Element>(qISCrqHCbFqbjiAzBEbeXVNPXAHpb);
			yJNcbapAeriXvOmRdjGRDJDDAymP = new ReadOnlyCollection<Button>(oVWNwPjbnBAGBoTzbysWMQuzcegv);
			ClpRYhMuzZRFpcKUpyxJqKUlrixm = new ReadOnlyCollection<Axis>(NaaAdQcArCoNCnHxLYAydtJllbifA);
			tucjsxEnJnhxdzpBDnwfEDmcKLsr = new List<Element.XLbaIzMFvKAvOxHJdfTmEwIPhcFb>();
			ReInput.UpdateEndedEvent += iTLEjCxMwZkKImuOliNPkbpldoEI;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= iTLEjCxMwZkKImuOliNPkbpldoEI;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
			{
				ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				return false;
			}
			if ((uint)index >= (uint)oVWNwPjbnBAGBoTzbysWMQuzcegv._count)
			{
				return false;
			}
			return oVWNwPjbnBAGBoTzbysWMQuzcegv[index].value;
		}

		bool IPlayerController.GetButton(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButton
			return this.GetButton(index);
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
			{
				ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				return false;
			}
			if ((uint)index >= (uint)oVWNwPjbnBAGBoTzbysWMQuzcegv._count)
			{
				return false;
			}
			return oVWNwPjbnBAGBoTzbysWMQuzcegv[index].justPressed;
		}

		bool IPlayerController.GetButtonDown(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonDown
			return this.GetButtonDown(index);
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
			{
				ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				return false;
			}
			if ((uint)index >= (uint)oVWNwPjbnBAGBoTzbysWMQuzcegv._count)
			{
				return false;
			}
			return oVWNwPjbnBAGBoTzbysWMQuzcegv[index].justReleased;
		}

		bool IPlayerController.GetButtonUp(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonUp
			return this.GetButtonUp(index);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
			{
				ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				return 0f;
			}
			if ((uint)index >= (uint)NaaAdQcArCoNCnHxLYAydtJllbifA._count)
			{
				return 0f;
			}
			return NaaAdQcArCoNCnHxLYAydtJllbifA[index].value;
		}

		float IPlayerController.GetAxis(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxis
			return this.GetAxis(index);
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
			{
				ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				return 0f;
			}
			if ((uint)index >= (uint)NaaAdQcArCoNCnHxLYAydtJllbifA._count)
			{
				return 0f;
			}
			return NaaAdQcArCoNCnHxLYAydtJllbifA[index].valueRaw;
		}

		float IPlayerController.GetAxisRaw(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxisRaw
			return this.GetAxisRaw(index);
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != EhPgbjEHiDiwEXvFGrVWBQrjWRfBB)
			{
				ReInput.CheckInitialized(EhPgbjEHiDiwEXvFGrVWBQrjWRfBB);
				return null;
			}
			if ((uint)index >= (uint)qISCrqHCbFqbjiAzBEbeXVNPXAHpb._count)
			{
				return null;
			}
			return qISCrqHCbFqbjiAzBEbeXVNPXAHpb[index];
		}

		Element IPlayerController.GetElement(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElement
			return this.GetElement(index);
		}

		public T GetElement<T>(int index) where T : Element
		{
			return GetElement(index) as T;
		}

		T IPlayerController.GetElement<T>(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElement
			return this.GetElement<T>(index);
		}

		private void iTLEjCxMwZkKImuOliNPkbpldoEI(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!fmZEbFlIAQAQXjzcuXQLIBvqORVHA)
			{
				return false;
			}
			bool flag = fkWgvTVcQgfJKYhtLThhFTwGSGJn != null;
			bool flag2 = YnpHSgXvTegibrsslVKejRFGqNwy != null;
			for (int i = 0; i < qISCrqHCbFqbjiAzBEbeXVNPXAHpb._count; i++)
			{
				float num = 0f;
				if (flag && qISCrqHCbFqbjiAzBEbeXVNPXAHpb[i] is Axis)
				{
					Axis axis = qISCrqHCbFqbjiAzBEbeXVNPXAHpb[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				qISCrqHCbFqbjiAzBEbeXVNPXAHpb[i].MkWnSjZuAfXyQSoemfLXQBAgJyqe();
				if (flag2 && qISCrqHCbFqbjiAzBEbeXVNPXAHpb[i] is Button)
				{
					Button button = qISCrqHCbFqbjiAzBEbeXVNPXAHpb[i] as Button;
					if (button.justPressed && button.value)
					{
						tucjsxEnJnhxdzpBDnwfEDmcKLsr.Add(new Element.XLbaIzMFvKAvOxHJdfTmEwIPhcFb(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						tucjsxEnJnhxdzpBDnwfEDmcKLsr.Add(new Element.XLbaIzMFvKAvOxHJdfTmEwIPhcFb(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && qISCrqHCbFqbjiAzBEbeXVNPXAHpb[i] is Axis)
				{
					tucjsxEnJnhxdzpBDnwfEDmcKLsr.Add(new Element.XLbaIzMFvKAvOxHJdfTmEwIPhcFb(ControllerElementType.Axis, i, (qISCrqHCbFqbjiAzBEbeXVNPXAHpb[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = tucjsxEnJnhxdzpBDnwfEDmcKLsr.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.XLbaIzMFvKAvOxHJdfTmEwIPhcFb xLbaIzMFvKAvOxHJdfTmEwIPhcFb = tucjsxEnJnhxdzpBDnwfEDmcKLsr[i];
				if (xLbaIzMFvKAvOxHJdfTmEwIPhcFb.HeovMmVoAadsgLcQLyAVPXwvLiof == ControllerElementType.Button)
				{
					try
					{
						YnpHSgXvTegibrsslVKejRFGqNwy(xLbaIzMFvKAvOxHJdfTmEwIPhcFb.oGjwISpdKXUgVJFrZKsFufZHUuSW, xLbaIzMFvKAvOxHJdfTmEwIPhcFb.qFREZNijcLDIReOIQPTGFDLvxyymA > 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (xLbaIzMFvKAvOxHJdfTmEwIPhcFb.HeovMmVoAadsgLcQLyAVPXwvLiof == ControllerElementType.Axis)
				{
					try
					{
						fkWgvTVcQgfJKYhtLThhFTwGSGJn(xLbaIzMFvKAvOxHJdfTmEwIPhcFb.oGjwISpdKXUgVJFrZKsFufZHUuSW, xLbaIzMFvKAvOxHJdfTmEwIPhcFb.qFREZNijcLDIReOIQPTGFDLvxyymA);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			tucjsxEnJnhxdzpBDnwfEDmcKLsr.Clear();
		}

		protected virtual void ClearVars()
		{
			tucjsxEnJnhxdzpBDnwfEDmcKLsr.Clear();
		}

		internal void qqFUsNYFvJuhFeUqKyzsHdwRdDxG(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					NaaAdQcArCoNCnHxLYAydtJllbifA.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					oVWNwPjbnBAGBoTzbysWMQuzcegv.Add(P_0 as Button);
				}
				qISCrqHCbFqbjiAzBEbeXVNPXAHpb.Add(P_0);
			}
		}

		private void CqzZbDeotiTnfLcjQLhaChxwdmYP(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.GetType();
			if (P_0 is ElementWithSource)
			{
				if (P_0 is Button)
				{
					P_3.Add((Button)P_0);
				}
				else
				{
					if (!(P_0 is Axis))
					{
						Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
						return;
					}
					P_4.Add((Axis)P_0);
				}
				P_1.Add(P_0);
			}
			else if (P_0 is CompoundElement)
			{
				using (TempListPool.TList<Element> tList = TempListPool.GetTList<Element>())
				{
					List<Element> list = tList.list;
					(P_0 as CompoundElement).XvpdqvHwzwsBxElCucVhEJyjYdCdA(list);
					for (int i = 0; i < list.Count; i++)
					{
						CqzZbDeotiTnfLcjQLhaChxwdmYP(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int epXCAyhmsanjwlKyWerCHErytnxZ<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
		{
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_1(P_0[i]))
				{
					num++;
				}
				if (num == P_2)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
