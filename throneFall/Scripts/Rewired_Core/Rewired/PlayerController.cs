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

				internal virtual Element GXuwoajvBgEvWPkjhsvfOrBjrJWy(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float IzZIcfEgNzZAzFeDjJvABFjJlzeR = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float sARnevrKLDJlyupftFQUPMKIpewt = 1f;

			private AxisCoordinateMode JafhwYPqyRzyEUIcLBEWgFtGlhyq;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return sARnevrKLDJlyupftFQUPMKIpewt;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					sARnevrKLDJlyupftFQUPMKIpewt = value;
				}
			}

			public AxisCoordinateMode coordinateMode => JafhwYPqyRzyEUIcLBEWgFtGlhyq;

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
						if (JafhwYPqyRzyEUIcLBEWgFtGlhyq == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (JafhwYPqyRzyEUIcLBEWgFtGlhyq == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * sARnevrKLDJlyupftFQUPMKIpewt;
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
				sARnevrKLDJlyupftFQUPMKIpewt = P_1.absoluteToRelativeSensitivity;
				JafhwYPqyRzyEUIcLBEWgFtGlhyq = P_1.coordinateMode;
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

				internal virtual Element EePcsgzyXqlSChDjdJAPNVMiKmrp(PlayerController P_0)
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
				private Axis.Definition gxbwcoMFmsvqPVhETuVDdoyWtiMJ;

				private Axis.Definition XXmkyAePhPQTIlbXQoKkrjkSnwnm;

				public Axis.Definition xAxis
				{
					get
					{
						return gxbwcoMFmsvqPVhETuVDdoyWtiMJ;
					}
					set
					{
						gxbwcoMFmsvqPVhETuVDdoyWtiMJ = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return XXmkyAePhPQTIlbXQoKkrjkSnwnm;
					}
					set
					{
						XXmkyAePhPQTIlbXQoKkrjkSnwnm = value;
					}
				}

				internal virtual Element UclXzCyRTnIsbiZOOqIHiVMeHweK(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int BNMCYAPXKvPaOtbfmQHsXkgMeOkk = 0;

			internal const int WCWamzIGNNJTccJaBMMfRksqoMmcA = 1;

			internal const int LBlAhjZuBrxMExZDBaVeuXWmceJs = 2;

			public Axis xAxis => sefcqgFpSAgXzEvLLWDEHiEqSGYHb<Axis>(0);

			public Axis yAxis => sefcqgFpSAgXzEvLLWDEHiEqSGYHb<Axis>(1);

			public virtual Vector2 value => new Vector2(sefcqgFpSAgXzEvLLWDEHiEqSGYHb<Axis>(0).value, sefcqgFpSAgXzEvLLWDEHiEqSGYHb<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(sefcqgFpSAgXzEvLLWDEHiEqSGYHb<Axis>(0).valueRaw, sefcqgFpSAgXzEvLLWDEHiEqSGYHb<Axis>(1).valueRaw);

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

				internal virtual Element UAxpZlDRHnafhXejojWmuBIrIAtC(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => sefcqgFpSAgXzEvLLWDEHiEqSGYHb<MouseAxis>(0);

			public new MouseAxis yAxis => sefcqgFpSAgXzEvLLWDEHiEqSGYHb<MouseAxis>(1);

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
				internal virtual Element rSqeGQHNRdJJZBDGpsmJQlPXXGOJA(PlayerController P_0)
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

			private readonly List<Element> uJzAyBXUOegyobgSPqmPohkAGaoMA;

			internal int eaCpALCnAtvUkMvioUOUCrGLjNRj => uJzAyBXUOegyobgSPqmPohkAGaoMA.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				uJzAyBXUOegyobgSPqmPohkAGaoMA = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						CsGYmrhCgstajekEmgarUdZZseEK(P_2[i].AJFBWmZwQCbqpoeAtXPvVhSrGluz(P_0));
					}
				}
			}

			internal _0001 sefcqgFpSAgXzEvLLWDEHiEqSGYHb<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)uJzAyBXUOegyobgSPqmPohkAGaoMA.Count)
				{
					return null;
				}
				return uJzAyBXUOegyobgSPqmPohkAGaoMA[P_0] as _0001;
			}

			internal void fMuQPWEEtypiRDlZblUYwKOoTLkp(List<Element> P_0)
			{
				for (int i = 0; i < uJzAyBXUOegyobgSPqmPohkAGaoMA.Count; i++)
				{
					if (uJzAyBXUOegyobgSPqmPohkAGaoMA[i] is CompoundElement)
					{
						(uJzAyBXUOegyobgSPqmPohkAGaoMA[i] as CompoundElement).fMuQPWEEtypiRDlZblUYwKOoTLkp(P_0);
					}
					else
					{
						P_0.Add(uJzAyBXUOegyobgSPqmPohkAGaoMA[i]);
					}
				}
			}

			internal void CsGYmrhCgstajekEmgarUdZZseEK(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				uJzAyBXUOegyobgSPqmPohkAGaoMA.Add(P_0);
				P_0.oVlpRVDypdrPXVPzItMrEjFflHQD = true;
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

				internal abstract Element AJFBWmZwQCbqpoeAtXPvVhSrGluz(PlayerController P_0);
			}

			internal struct fKOvNjLmFlWlJcKQSGiepxIBaJMhA
			{
				public ControllerElementType dqliGDKSIotEYInFADdwHmEaCdMRA;

				public int YlkxbsoSZUHzhEiMVhwaNzeKEqhB;

				public float IQScDshFqRrxzRRXLSAnkzzcSZAi;

				public fKOvNjLmFlWlJcKQSGiepxIBaJMhA(ControllerElementType P_0, int P_1, float P_2)
				{
					dqliGDKSIotEYInFADdwHmEaCdMRA = P_0;
					YlkxbsoSZUHzhEiMVhwaNzeKEqhB = P_1;
					IQScDshFqRrxzRRXLSAnkzzcSZAi = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController GcTOrHLjhILSbFPfVOMxpwoRjqEy;

			private bool pJdgYLDLlVCrLrDJRYEKBjUiGCthb;

			private bool wBDDAbmsSRCoDASIDBqmJSSTWkxmA = true;

			private string fuIMosqqduQstkrNScAdsjoJdGOj;

			private static int[] yQNxPISUwOvnMUOtMrBmvnWCthzH;

			private static int[] onGXTmhEExnpnlOpLWcOIYGmwEvd;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(GcTOrHLjhILSbFPfVOMxpwoRjqEy.rOwHrUjAhWKCSZMbOEYVXznZVNRO);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (wBDDAbmsSRCoDASIDBqmJSSTWkxmA)
					{
						return GcTOrHLjhILSbFPfVOMxpwoRjqEy.XUCYwkoFSKzmnwdrzCRukpHlYvdu;
					}
					return false;
				}
			}

			internal bool oVlpRVDypdrPXVPzItMrEjFflHQD
			{
				get
				{
					return pJdgYLDLlVCrLrDJRYEKBjUiGCthb;
				}
				set
				{
					pJdgYLDLlVCrLrDJRYEKBjUiGCthb = true;
				}
			}

			public bool enabled
			{
				get
				{
					return wBDDAbmsSRCoDASIDBqmJSSTWkxmA;
				}
				set
				{
					if (wBDDAbmsSRCoDASIDBqmJSSTWkxmA != value)
					{
						wBDDAbmsSRCoDASIDBqmJSSTWkxmA = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return fuIMosqqduQstkrNScAdsjoJdGOj;
				}
				set
				{
					fuIMosqqduQstkrNScAdsjoJdGOj = value;
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
				GcTOrHLjhILSbFPfVOMxpwoRjqEy = P_0;
				wBDDAbmsSRCoDASIDBqmJSSTWkxmA = P_1.enabled;
				fuIMosqqduQstkrNScAdsjoJdGOj = P_1.name;
			}

			internal virtual void ayFAKMgWchkwyTZndkgiBrjvdvAab()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (yQNxPISUwOvnMUOtMrBmvnWCthzH == null)
				{
					yQNxPISUwOvnMUOtMrBmvnWCthzH = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(yQNxPISUwOvnMUOtMrBmvnWCthzH, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (onGXTmhEExnpnlOpLWcOIYGmwEvd == null)
				{
					onGXTmhEExnpnlOpLWcOIYGmwEvd = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(onGXTmhEExnpnlOpLWcOIYGmwEvd, (int)type);
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
				private int DYVlVwhOYyirZEhVyasDXokYzXJK;

				public int actionId
				{
					get
					{
						return DYVlVwhOYyirZEhVyasDXokYzXJK;
					}
					set
					{
						DYVlVwhOYyirZEhVyasDXokYzXJK = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || DYVlVwhOYyirZEhVyasDXokYzXJK < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(DYVlVwhOYyirZEhVyasDXokYzXJK)?.name;
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
							DYVlVwhOYyirZEhVyasDXokYzXJK = -1;
						}
						else
						{
							DYVlVwhOYyirZEhVyasDXokYzXJK = action.id;
						}
					}
				}

				public Definition()
				{
					DYVlVwhOYyirZEhVyasDXokYzXJK = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int oPOyQJoxggyjswZCRqyyyIOTTzli = -1;

			public int actionId
			{
				get
				{
					return oPOyQJoxggyjswZCRqyyyIOTTzli;
				}
				set
				{
					oPOyQJoxggyjswZCRqyyyIOTTzli = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || oPOyQJoxggyjswZCRqyyyIOTTzli < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(oPOyQJoxggyjswZCRqyyyIOTTzli)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							oPOyQJoxggyjswZCRqyyyIOTTzli = -1;
						}
						else
						{
							oPOyQJoxggyjswZCRqyyyIOTTzli = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				oPOyQJoxggyjswZCRqyyyIOTTzli = P_1.actionId;
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

				internal virtual Element CdZEzqMSqqlafigBIikNaglapTL(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => sefcqgFpSAgXzEvLLWDEHiEqSGYHb<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => sefcqgFpSAgXzEvLLWDEHiEqSGYHb<MouseWheelAxis>(1);

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

				internal virtual Element sPxrSRSFAqtDKkxQccaaoBheGHOr(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float JbOJVUxInmvKhDZshIddYAHMZanH = 0.01f;

			private float CjAviazwwtEFVGnvVtjpMZXamFW = 0.25f;

			private double pUzVCyjGlraeUPSbclrSCnoReTlI;

			private float wwPTzyNFYciNwXoTgqgZOTXoTMuN;

			public float repeatRate
			{
				get
				{
					if (CjAviazwwtEFVGnvVtjpMZXamFW == 0f)
					{
						return 0f;
					}
					return 1f / CjAviazwwtEFVGnvVtjpMZXamFW;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						CjAviazwwtEFVGnvVtjpMZXamFW = 0f;
					}
					else
					{
						CjAviazwwtEFVGnvVtjpMZXamFW = 1f / value;
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
					return wwPTzyNFYciNwXoTgqgZOTXoTMuN;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal void sFzFMcuOaGoMtztHfCJPoRcWGPdN()
			{
				base.ayFAKMgWchkwyTZndkgiBrjvdvAab();
				if (base.selfAndParentEnabled)
				{
					wwPTzyNFYciNwXoTgqgZOTXoTMuN = eAkcQgwtAfgMWHjHNmIeeqssdVoi();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					VNAaNhIDOfEPaWCRAWJReSKgQFKr();
				}
			}

			private float eAkcQgwtAfgMWHjHNmIeeqssdVoi()
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
					if (!flag && ReInput.unscaledTime < pUzVCyjGlraeUPSbclrSCnoReTlI + (double)CjAviazwwtEFVGnvVtjpMZXamFW)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					pUzVCyjGlraeUPSbclrSCnoReTlI = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void VNAaNhIDOfEPaWCRAWJReSKgQFKr()
			{
				wwPTzyNFYciNwXoTgqgZOTXoTMuN = 0f;
				pUzVCyjGlraeUPSbclrSCnoReTlI = 0.0;
			}
		}

		internal readonly int esKWzEAypHHbwigODUvhrmHNrPFL;

		private bool XUCYwkoFSKzmnwdrzCRukpHlYvdu;

		private int rOwHrUjAhWKCSZMbOEYVXznZVNRO;

		private readonly AList<Element> ANLUfHBbjBSIJTRmFoRJaglGsBzI;

		private readonly AList<Button> UdPCRusUfLJprxdsuvrjpnCuICQU;

		private readonly AList<Axis> fldAKtDnmGshsWapYFJtYnYgBIpb;

		private readonly ReadOnlyCollection<Element> WXQuCbCZhmUYuTqgzIitlLdcCjIu;

		private readonly ReadOnlyCollection<Button> UVSIBDygcplwBVpImSNkwRjGhWCq;

		private readonly ReadOnlyCollection<Axis> uTkBdEXNjLmRFhdFmEugPomulKFO;

		private readonly List<Element.fKOvNjLmFlWlJcKQSGiepxIBaJMhA> JJxLbYVfBxCUZyAGIcgSnAEtorAT;

		private Action<int, bool> ubkzJNMPFsPqVsjfsJZVSatNdBYJ;

		private Action<int, float> RcBPFoUwSkkXwFVqYmLYwkANsnjj;

		private Action<bool> GSMQngrIEdlJluPwecNjGNRAYsFcA;

		bool IPlayerController.enabled
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return false;
				}
				return XUCYwkoFSKzmnwdrzCRukpHlYvdu;
			}
			set
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				}
				else
				{
					if (XUCYwkoFSKzmnwdrzCRukpHlYvdu == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					XUCYwkoFSKzmnwdrzCRukpHlYvdu = value;
					for (int i = 0; i < ANLUfHBbjBSIJTRmFoRJaglGsBzI._count; i++)
					{
						ANLUfHBbjBSIJTRmFoRJaglGsBzI[i].enabled = value;
					}
					if (GSMQngrIEdlJluPwecNjGNRAYsFcA != null)
					{
						try
						{
							GSMQngrIEdlJluPwecNjGNRAYsFcA(value);
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
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return -1;
				}
				return rOwHrUjAhWKCSZMbOEYVXznZVNRO;
			}
			set
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				}
				else if (rOwHrUjAhWKCSZMbOEYVXznZVNRO != value)
				{
					rOwHrUjAhWKCSZMbOEYVXznZVNRO = value;
					ClearVars();
				}
			}
		}

		IList<Button> IPlayerController.buttons
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				return UVSIBDygcplwBVpImSNkwRjGhWCq;
			}
		}

		IList<Axis> IPlayerController.axes
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				return uTkBdEXNjLmRFhdFmEugPomulKFO;
			}
		}

		IList<Element> IPlayerController.elements
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return null;
				}
				return WXQuCbCZhmUYuTqgzIitlLdcCjIu;
			}
		}

		int IPlayerController.buttonCount
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return 0;
				}
				if (UdPCRusUfLJprxdsuvrjpnCuICQU == null)
				{
					return 0;
				}
				return UdPCRusUfLJprxdsuvrjpnCuICQU._count;
			}
		}

		int IPlayerController.axisCount
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return 0;
				}
				if (fldAKtDnmGshsWapYFJtYnYgBIpb == null)
				{
					return 0;
				}
				return fldAKtDnmGshsWapYFJtYnYgBIpb._count;
			}
		}

		int IPlayerController.elementCount
		{
			get
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
					return 0;
				}
				if (ANLUfHBbjBSIJTRmFoRJaglGsBzI == null)
				{
					return 0;
				}
				return ANLUfHBbjBSIJTRmFoRJaglGsBzI._count;
			}
		}

		internal Player eOGHRXaBmIViwhvhzLjDfkqkbzsp
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
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				}
				else
				{
					ubkzJNMPFsPqVsjfsJZVSatNdBYJ = (Action<int, bool>)Delegate.Combine(ubkzJNMPFsPqVsjfsJZVSatNdBYJ, value);
				}
			}
			remove
			{
				ubkzJNMPFsPqVsjfsJZVSatNdBYJ = (Action<int, bool>)Delegate.Remove(ubkzJNMPFsPqVsjfsJZVSatNdBYJ, value);
			}
		}

		event Action<int, float> IPlayerController.AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				}
				else
				{
					RcBPFoUwSkkXwFVqYmLYwkANsnjj = (Action<int, float>)Delegate.Combine(RcBPFoUwSkkXwFVqYmLYwkANsnjj, value);
				}
			}
			remove
			{
				RcBPFoUwSkkXwFVqYmLYwkANsnjj = (Action<int, float>)Delegate.Remove(RcBPFoUwSkkXwFVqYmLYwkANsnjj, value);
			}
		}

		event Action<bool> IPlayerController.EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
				{
					ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				}
				else
				{
					GSMQngrIEdlJluPwecNjGNRAYsFcA = (Action<bool>)Delegate.Combine(GSMQngrIEdlJluPwecNjGNRAYsFcA, value);
				}
			}
			remove
			{
				GSMQngrIEdlJluPwecNjGNRAYsFcA = (Action<bool>)Delegate.Remove(GSMQngrIEdlJluPwecNjGNRAYsFcA, value);
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
			esKWzEAypHHbwigODUvhrmHNrPFL = ReInput._id;
			rOwHrUjAhWKCSZMbOEYVXznZVNRO = P_0.playerId;
			XUCYwkoFSKzmnwdrzCRukpHlYvdu = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				kheeewjppaDoRaWqVNKRLvNnqOuOA(element.AJFBWmZwQCbqpoeAtXPvVhSrGluz(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			ANLUfHBbjBSIJTRmFoRJaglGsBzI = new AList<Element>(list);
			UdPCRusUfLJprxdsuvrjpnCuICQU = new AList<Button>(list3);
			fldAKtDnmGshsWapYFJtYnYgBIpb = new AList<Axis>(list4);
			WXQuCbCZhmUYuTqgzIitlLdcCjIu = new ReadOnlyCollection<Element>(ANLUfHBbjBSIJTRmFoRJaglGsBzI);
			UVSIBDygcplwBVpImSNkwRjGhWCq = new ReadOnlyCollection<Button>(UdPCRusUfLJprxdsuvrjpnCuICQU);
			uTkBdEXNjLmRFhdFmEugPomulKFO = new ReadOnlyCollection<Axis>(fldAKtDnmGshsWapYFJtYnYgBIpb);
			JJxLbYVfBxCUZyAGIcgSnAEtorAT = new List<Element.fKOvNjLmFlWlJcKQSGiepxIBaJMhA>();
			ReInput.UpdateEndedEvent += SeMkrxaokDyBwrURgobqTaReXZoq;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= SeMkrxaokDyBwrURgobqTaReXZoq;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
			{
				ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				return false;
			}
			if ((uint)index >= (uint)UdPCRusUfLJprxdsuvrjpnCuICQU._count)
			{
				return false;
			}
			return UdPCRusUfLJprxdsuvrjpnCuICQU[index].value;
		}

		bool IPlayerController.GetButton(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButton
			return this.GetButton(index);
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
			{
				ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				return false;
			}
			if ((uint)index >= (uint)UdPCRusUfLJprxdsuvrjpnCuICQU._count)
			{
				return false;
			}
			return UdPCRusUfLJprxdsuvrjpnCuICQU[index].justPressed;
		}

		bool IPlayerController.GetButtonDown(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonDown
			return this.GetButtonDown(index);
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
			{
				ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				return false;
			}
			if ((uint)index >= (uint)UdPCRusUfLJprxdsuvrjpnCuICQU._count)
			{
				return false;
			}
			return UdPCRusUfLJprxdsuvrjpnCuICQU[index].justReleased;
		}

		bool IPlayerController.GetButtonUp(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonUp
			return this.GetButtonUp(index);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
			{
				ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				return 0f;
			}
			if ((uint)index >= (uint)fldAKtDnmGshsWapYFJtYnYgBIpb._count)
			{
				return 0f;
			}
			return fldAKtDnmGshsWapYFJtYnYgBIpb[index].value;
		}

		float IPlayerController.GetAxis(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxis
			return this.GetAxis(index);
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
			{
				ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				return 0f;
			}
			if ((uint)index >= (uint)fldAKtDnmGshsWapYFJtYnYgBIpb._count)
			{
				return 0f;
			}
			return fldAKtDnmGshsWapYFJtYnYgBIpb[index].valueRaw;
		}

		float IPlayerController.GetAxisRaw(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxisRaw
			return this.GetAxisRaw(index);
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != esKWzEAypHHbwigODUvhrmHNrPFL)
			{
				ReInput.CheckInitialized(esKWzEAypHHbwigODUvhrmHNrPFL);
				return null;
			}
			if ((uint)index >= (uint)ANLUfHBbjBSIJTRmFoRJaglGsBzI._count)
			{
				return null;
			}
			return ANLUfHBbjBSIJTRmFoRJaglGsBzI[index];
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

		private void SeMkrxaokDyBwrURgobqTaReXZoq(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!XUCYwkoFSKzmnwdrzCRukpHlYvdu)
			{
				return false;
			}
			bool flag = RcBPFoUwSkkXwFVqYmLYwkANsnjj != null;
			bool flag2 = ubkzJNMPFsPqVsjfsJZVSatNdBYJ != null;
			for (int i = 0; i < ANLUfHBbjBSIJTRmFoRJaglGsBzI._count; i++)
			{
				float num = 0f;
				if (flag && ANLUfHBbjBSIJTRmFoRJaglGsBzI[i] is Axis)
				{
					Axis axis = ANLUfHBbjBSIJTRmFoRJaglGsBzI[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				ANLUfHBbjBSIJTRmFoRJaglGsBzI[i].ayFAKMgWchkwyTZndkgiBrjvdvAab();
				if (flag2 && ANLUfHBbjBSIJTRmFoRJaglGsBzI[i] is Button)
				{
					Button button = ANLUfHBbjBSIJTRmFoRJaglGsBzI[i] as Button;
					if (button.justPressed && button.value)
					{
						JJxLbYVfBxCUZyAGIcgSnAEtorAT.Add(new Element.fKOvNjLmFlWlJcKQSGiepxIBaJMhA(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						JJxLbYVfBxCUZyAGIcgSnAEtorAT.Add(new Element.fKOvNjLmFlWlJcKQSGiepxIBaJMhA(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && ANLUfHBbjBSIJTRmFoRJaglGsBzI[i] is Axis)
				{
					JJxLbYVfBxCUZyAGIcgSnAEtorAT.Add(new Element.fKOvNjLmFlWlJcKQSGiepxIBaJMhA(ControllerElementType.Axis, i, (ANLUfHBbjBSIJTRmFoRJaglGsBzI[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = JJxLbYVfBxCUZyAGIcgSnAEtorAT.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.fKOvNjLmFlWlJcKQSGiepxIBaJMhA fKOvNjLmFlWlJcKQSGiepxIBaJMhA = JJxLbYVfBxCUZyAGIcgSnAEtorAT[i];
				if (fKOvNjLmFlWlJcKQSGiepxIBaJMhA.dqliGDKSIotEYInFADdwHmEaCdMRA == ControllerElementType.Button)
				{
					try
					{
						ubkzJNMPFsPqVsjfsJZVSatNdBYJ(fKOvNjLmFlWlJcKQSGiepxIBaJMhA.YlkxbsoSZUHzhEiMVhwaNzeKEqhB, fKOvNjLmFlWlJcKQSGiepxIBaJMhA.IQScDshFqRrxzRRXLSAnkzzcSZAi > 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (fKOvNjLmFlWlJcKQSGiepxIBaJMhA.dqliGDKSIotEYInFADdwHmEaCdMRA == ControllerElementType.Axis)
				{
					try
					{
						RcBPFoUwSkkXwFVqYmLYwkANsnjj(fKOvNjLmFlWlJcKQSGiepxIBaJMhA.YlkxbsoSZUHzhEiMVhwaNzeKEqhB, fKOvNjLmFlWlJcKQSGiepxIBaJMhA.IQScDshFqRrxzRRXLSAnkzzcSZAi);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			JJxLbYVfBxCUZyAGIcgSnAEtorAT.Clear();
		}

		protected virtual void ClearVars()
		{
			JJxLbYVfBxCUZyAGIcgSnAEtorAT.Clear();
		}

		internal void MeCHdwNSzDfJpftfRyfTcPNKqZLR(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					fldAKtDnmGshsWapYFJtYnYgBIpb.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					UdPCRusUfLJprxdsuvrjpnCuICQU.Add(P_0 as Button);
				}
				ANLUfHBbjBSIJTRmFoRJaglGsBzI.Add(P_0);
			}
		}

		private void kheeewjppaDoRaWqVNKRLvNnqOuOA(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
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
					(P_0 as CompoundElement).fMuQPWEEtypiRDlZblUYwKOoTLkp(list);
					for (int i = 0; i < list.Count; i++)
					{
						kheeewjppaDoRaWqVNKRLvNnqOuOA(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int WZCQtDeIkocIIcezZRqfttHjSTHZ<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
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
