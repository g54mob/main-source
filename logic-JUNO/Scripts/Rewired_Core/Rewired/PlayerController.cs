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

				internal virtual Element xcWVIanIYNzcvAirKZArJrUOhcKE(PlayerController P_0)
				{
					return new Axis(P_0, this);
				}
			}

			internal const float vUtsfvCoKYJBIWdYEYZGSbTukJgM = 1f;

			[CustomObfuscation(rename = false)]
			internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

			private float PgxFtbxHKqGnNdrgYimIMnehFSgKA = 1f;

			private AxisCoordinateMode cmHRWsVjIukjFTnGgqgAfXSrZHke;

			public float absoluteToRelativeSensitivity
			{
				get
				{
					return PgxFtbxHKqGnNdrgYimIMnehFSgKA;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					PgxFtbxHKqGnNdrgYimIMnehFSgKA = value;
				}
			}

			public AxisCoordinateMode coordinateMode => cmHRWsVjIukjFTnGgqgAfXSrZHke;

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
						if (cmHRWsVjIukjFTnGgqgAfXSrZHke == AxisCoordinateMode.Absolute)
						{
							return 0f;
						}
						break;
					case AxisCoordinateMode.Absolute:
						if (cmHRWsVjIukjFTnGgqgAfXSrZHke == AxisCoordinateMode.Relative)
						{
							num *= (float)ReInput.unscaledDeltaTime * PgxFtbxHKqGnNdrgYimIMnehFSgKA;
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
				PgxFtbxHKqGnNdrgYimIMnehFSgKA = P_1.absoluteToRelativeSensitivity;
				cmHRWsVjIukjFTnGgqgAfXSrZHke = P_1.coordinateMode;
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

				internal virtual Element vUdFNcnCQTNfviGyWAoPdKsBSYvSA(PlayerController P_0)
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
				private Axis.Definition LHTuHeCMhTcxoQBTyYQLmLChDXSFA;

				private Axis.Definition woQJrUoDcacIniyWtEQsgTQdVRhw;

				public Axis.Definition xAxis
				{
					get
					{
						return LHTuHeCMhTcxoQBTyYQLmLChDXSFA;
					}
					set
					{
						LHTuHeCMhTcxoQBTyYQLmLChDXSFA = value;
					}
				}

				public Axis.Definition yAxis
				{
					get
					{
						return woQJrUoDcacIniyWtEQsgTQdVRhw;
					}
					set
					{
						woQJrUoDcacIniyWtEQsgTQdVRhw = value;
					}
				}

				internal virtual Element jRVUqYyUcWoMMnTjzmFHpaqXhbcK(PlayerController P_0)
				{
					return new Axis2D(P_0, this);
				}
			}

			internal const int sYaYnQRROASFhcAuLEssYRStUCau = 0;

			internal const int zIaBJjWkGkHjVGIxkmWjnoQDokeI = 1;

			internal const int ofNSEhLjGKIWvaASihKonToTAPTi = 2;

			public Axis xAxis => ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<Axis>(0);

			public Axis yAxis => ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<Axis>(1);

			public virtual Vector2 value => new Vector2(ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<Axis>(0).value, ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<Axis>(1).value);

			public virtual Vector2 valueRaw => new Vector2(ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<Axis>(0).valueRaw, ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<Axis>(1).valueRaw);

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

				internal virtual Element fyTbEDeBAAXwQDQnZtBuijvKAorNA(PlayerController P_0)
				{
					return new MouseAxis2D(P_0, this);
				}
			}

			public new MouseAxis xAxis => ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<MouseAxis>(0);

			public new MouseAxis yAxis => ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<MouseAxis>(1);

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
				internal virtual Element EKjpGPYQMNJqGwVSdMTqLvkEyWcA(PlayerController P_0)
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

			private readonly List<Element> NvTRVLLHaPkByfDLoMNwwMInAyOB;

			internal int ZLivENUtPUjtNTpfNjeQRJqsCJZHA => NvTRVLLHaPkByfDLoMNwwMInAyOB.Count;

			internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
				: base(P_0, P_1)
			{
				NvTRVLLHaPkByfDLoMNwwMInAyOB = new List<Element>();
				if (P_2 == null)
				{
					return;
				}
				for (int i = 0; i < P_2.Length; i++)
				{
					if (P_2[i] != null)
					{
						zgyYhzrsDBVfGjCVLLUbRqhoKQWR(P_2[i].xDzhzcLhFxRsAndLSDrjfYqMXVcs(P_0));
					}
				}
			}

			internal _0001 ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<_0001>(int P_0) where _0001 : Element
			{
				if ((uint)P_0 >= (uint)NvTRVLLHaPkByfDLoMNwwMInAyOB.Count)
				{
					return null;
				}
				return NvTRVLLHaPkByfDLoMNwwMInAyOB[P_0] as _0001;
			}

			internal void SAEuqYKLwNcUgMGUMwjUbcqBvNqf(List<Element> P_0)
			{
				for (int i = 0; i < NvTRVLLHaPkByfDLoMNwwMInAyOB.Count; i++)
				{
					if (NvTRVLLHaPkByfDLoMNwwMInAyOB[i] is CompoundElement)
					{
						(NvTRVLLHaPkByfDLoMNwwMInAyOB[i] as CompoundElement).SAEuqYKLwNcUgMGUMwjUbcqBvNqf(P_0);
					}
					else
					{
						P_0.Add(NvTRVLLHaPkByfDLoMNwwMInAyOB[i]);
					}
				}
			}

			internal void zgyYhzrsDBVfGjCVLLUbRqhoKQWR(Element P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("element");
				}
				NvTRVLLHaPkByfDLoMNwwMInAyOB.Add(P_0);
				P_0.JRFXSVPvdMttiCEMrjFGfRBUMVCYA = true;
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

				internal abstract Element xDzhzcLhFxRsAndLSDrjfYqMXVcs(PlayerController P_0);
			}

			internal struct SWooPnJhIYheyzWNbAxiuFkavEGl
			{
				public ControllerElementType IwPBfJEJJVvCnBQGxyVghUuToPAy;

				public int vAQIWjHsVygFQHHtFjHuiOTFxkEge;

				public float jooSZwlirgQvIYsKgcshbPRHymSu;

				public SWooPnJhIYheyzWNbAxiuFkavEGl(ControllerElementType P_0, int P_1, float P_2)
				{
					IwPBfJEJJVvCnBQGxyVghUuToPAy = P_0;
					vAQIWjHsVygFQHHtFjHuiOTFxkEge = P_1;
					jooSZwlirgQvIYsKgcshbPRHymSu = P_2;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const bool defaultEnabled = true;

			private readonly PlayerController dQlKVNZwkpMZCYjakkJvkdGwMWQL;

			private bool YRvhJNdkahroFMGgfmAMceJEuxZA;

			private bool HkjHdtqMXaaqiRnPefUyeNqynApTA = true;

			private string UEiZpasApNPAQxqcdCArhwIugZCV;

			private static int[] NjhmQOELvphrvTLobhFgcRkheRtM;

			private static int[] XYwgeXFbNOwtWQaHcYoaFVsJfElyA;

			protected Player player
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					return ReInput.players.GetPlayer(dQlKVNZwkpMZCYjakkJvkdGwMWQL.UxCcOUjbgnNEvIhkdJiBEXFeMdJw);
				}
			}

			protected bool selfAndParentEnabled
			{
				get
				{
					if (HkjHdtqMXaaqiRnPefUyeNqynApTA)
					{
						return dQlKVNZwkpMZCYjakkJvkdGwMWQL.eDcRlgqYFphpGxHmQSvshgrYvFfp;
					}
					return false;
				}
			}

			internal bool JRFXSVPvdMttiCEMrjFGfRBUMVCYA
			{
				get
				{
					return YRvhJNdkahroFMGgfmAMceJEuxZA;
				}
				set
				{
					YRvhJNdkahroFMGgfmAMceJEuxZA = true;
				}
			}

			public bool enabled
			{
				get
				{
					return HkjHdtqMXaaqiRnPefUyeNqynApTA;
				}
				set
				{
					if (HkjHdtqMXaaqiRnPefUyeNqynApTA != value)
					{
						HkjHdtqMXaaqiRnPefUyeNqynApTA = value;
						EnabledStateChanged(value);
					}
				}
			}

			public string name
			{
				get
				{
					return UEiZpasApNPAQxqcdCArhwIugZCV;
				}
				set
				{
					UEiZpasApNPAQxqcdCArhwIugZCV = value;
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
				dQlKVNZwkpMZCYjakkJvkdGwMWQL = P_0;
				HkjHdtqMXaaqiRnPefUyeNqynApTA = P_1.enabled;
				UEiZpasApNPAQxqcdCArhwIugZCV = P_1.name;
			}

			internal virtual void RAnlkSSfVGoWVCgYOKScuJJWVBOf()
			{
			}

			protected virtual void EnabledStateChanged(bool state)
			{
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsTypeWithSource(Type type)
			{
				if (NjhmQOELvphrvTLobhFgcRkheRtM == null)
				{
					NjhmQOELvphrvTLobhFgcRkheRtM = (int[])Enum.GetValues(typeof(TypeWithSource));
				}
				return ArrayTools.Contains(NjhmQOELvphrvTLobhFgcRkheRtM, (int)type);
			}

			[CustomObfuscation(rename = false)]
			internal static bool IsCompoundType(Type type)
			{
				if (XYwgeXFbNOwtWQaHcYoaFVsJfElyA == null)
				{
					XYwgeXFbNOwtWQaHcYoaFVsJfElyA = (int[])Enum.GetValues(typeof(CompoundTypes));
				}
				return ArrayTools.Contains(XYwgeXFbNOwtWQaHcYoaFVsJfElyA, (int)type);
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
				private int uOlsAuvARXbpwDnEZgIVECQjVFBs;

				public int actionId
				{
					get
					{
						return uOlsAuvARXbpwDnEZgIVECQjVFBs;
					}
					set
					{
						uOlsAuvARXbpwDnEZgIVECQjVFBs = value;
					}
				}

				public string actionName
				{
					get
					{
						if (!ReInput.isReady || uOlsAuvARXbpwDnEZgIVECQjVFBs < 0)
						{
							return null;
						}
						return ReInput.mapping.GetAction(uOlsAuvARXbpwDnEZgIVECQjVFBs)?.name;
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
							uOlsAuvARXbpwDnEZgIVECQjVFBs = -1;
						}
						else
						{
							uOlsAuvARXbpwDnEZgIVECQjVFBs = action.id;
						}
					}
				}

				public Definition()
				{
					uOlsAuvARXbpwDnEZgIVECQjVFBs = -1;
				}
			}

			[CustomObfuscation(rename = false)]
			internal const int defaultActionId = -1;

			private int PksfTNyvjHGmXliZuSXgliqkCfbs = -1;

			public int actionId
			{
				get
				{
					return PksfTNyvjHGmXliZuSXgliqkCfbs;
				}
				set
				{
					PksfTNyvjHGmXliZuSXgliqkCfbs = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || PksfTNyvjHGmXliZuSXgliqkCfbs < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(PksfTNyvjHGmXliZuSXgliqkCfbs)?.name;
				}
				set
				{
					if (ReInput.isReady)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							PksfTNyvjHGmXliZuSXgliqkCfbs = -1;
						}
						else
						{
							PksfTNyvjHGmXliZuSXgliqkCfbs = action.id;
						}
					}
				}
			}

			internal ElementWithSource(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				PksfTNyvjHGmXliZuSXgliqkCfbs = P_1.actionId;
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

				internal virtual Element bzNeujDyXFsqRMuhoKcqnKISeSJGb(PlayerController P_0)
				{
					return new MouseWheel(P_0, this);
				}
			}

			public new MouseWheelAxis xAxis => ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<MouseWheelAxis>(0);

			public new MouseWheelAxis yAxis => ZuXfTqHgHvDVSFeAcStGGdyBSsMoA<MouseWheelAxis>(1);

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

				internal virtual Element TcTVUXUUXLPhljcPFOQsxPLTdpIw(PlayerController P_0)
				{
					return new MouseWheelAxis(P_0, this);
				}
			}

			[CustomObfuscation(rename = false)]
			internal const float defaultRepeatRate = 4f;

			[CustomObfuscation(rename = false)]
			internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

			private const float uYeVmErhRZMtWIKMQAatALphbtbab = 0.01f;

			private float bvRdQoHadNpEaCGqOnHvCgvyRUZbA = 0.25f;

			private double WfTsestUiWAobGekBVXMTdMqBSzZ;

			private float DCrIJwPXMJRiZIiAFSvRTKzBwnyg;

			public float repeatRate
			{
				get
				{
					if (bvRdQoHadNpEaCGqOnHvCgvyRUZbA == 0f)
					{
						return 0f;
					}
					return 1f / bvRdQoHadNpEaCGqOnHvCgvyRUZbA;
				}
				set
				{
					if (value < 0f)
					{
						value = 0f;
					}
					if (value == 0f)
					{
						bvRdQoHadNpEaCGqOnHvCgvyRUZbA = 0f;
					}
					else
					{
						bvRdQoHadNpEaCGqOnHvCgvyRUZbA = 1f / value;
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
					return DCrIJwPXMJRiZIiAFSvRTKzBwnyg;
				}
			}

			internal MouseWheelAxis(PlayerController P_0, Definition P_1)
				: base(P_0, P_1)
			{
				repeatRate = P_1.repeatRate;
			}

			internal void ZYVvuigAhhSwUiAYChfHviEfpfzU()
			{
				base.RAnlkSSfVGoWVCgYOKScuJJWVBOf();
				if (base.selfAndParentEnabled)
				{
					DCrIJwPXMJRiZIiAFSvRTKzBwnyg = TMOQXowZZQeXpEaGskSmhBMTmTax();
				}
			}

			protected override void EnabledStateChanged(bool state)
			{
				base.EnabledStateChanged(state);
				if (!state)
				{
					agoIJdCXZAtNZFEQdozXddsXAtUiA();
				}
			}

			private float TMOQXowZZQeXpEaGskSmhBMTmTax()
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
					if (!flag && ReInput.unscaledTime < WfTsestUiWAobGekBVXMTdMqBSzZ + (double)bvRdQoHadNpEaCGqOnHvCgvyRUZbA)
					{
						return 0f;
					}
					if (Mathf.Abs(num) <= 0.01f)
					{
						return 0f;
					}
					num = Mathf.Sign(num);
					num *= base.absoluteToRelativeSensitivity;
					WfTsestUiWAobGekBVXMTdMqBSzZ = ReInput.unscaledTime;
					break;
				}
				}
				return num;
			}

			private void agoIJdCXZAtNZFEQdozXddsXAtUiA()
			{
				DCrIJwPXMJRiZIiAFSvRTKzBwnyg = 0f;
				WfTsestUiWAobGekBVXMTdMqBSzZ = 0.0;
			}
		}

		internal readonly int LngTlIEEzmFRPfjDkkuvKylesNHMA;

		private bool eDcRlgqYFphpGxHmQSvshgrYvFfp;

		private int UxCcOUjbgnNEvIhkdJiBEXFeMdJw;

		private readonly AList<Element> tYpytLFDoylKwCfhcQADxYFvGSlX;

		private readonly AList<Button> xvrDoouDguTnYqbtTDFvCsoVWqAmA;

		private readonly AList<Axis> GhNdbrKTyfJkFQTprbhZBXTFllQHb;

		private readonly ReadOnlyCollection<Element> dbafqnCdgNGOLMgfWfEterXDQBOp;

		private readonly ReadOnlyCollection<Button> flucwReYhOuUeYJRXhsmbVTxweIg;

		private readonly ReadOnlyCollection<Axis> FnOiAIJOiaBcwgPEHwQoQJMPGqPFA;

		private readonly List<Element.SWooPnJhIYheyzWNbAxiuFkavEGl> oDHNiKTtOYoYuxHXdTQMoqcMHBCO;

		private Action<int, bool> VLSrIZQxKRnJmpYcLJnLBQLqyZSO;

		private Action<int, float> kqpiXgYWHDqMXWNhvKmKrJqyEJlj;

		private Action<bool> fZeAhmnwFIByGfinNxgvQcpxfKLx;

		bool IPlayerController.enabled
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return false;
				}
				return eDcRlgqYFphpGxHmQSvshgrYvFfp;
			}
			set
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				}
				else
				{
					if (eDcRlgqYFphpGxHmQSvshgrYvFfp == value)
					{
						return;
					}
					if (!value)
					{
						ClearVars();
					}
					eDcRlgqYFphpGxHmQSvshgrYvFfp = value;
					for (int i = 0; i < tYpytLFDoylKwCfhcQADxYFvGSlX._count; i++)
					{
						tYpytLFDoylKwCfhcQADxYFvGSlX[i].enabled = value;
					}
					if (fZeAhmnwFIByGfinNxgvQcpxfKLx != null)
					{
						try
						{
							fZeAhmnwFIByGfinNxgvQcpxfKLx(value);
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
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return -1;
				}
				return UxCcOUjbgnNEvIhkdJiBEXFeMdJw;
			}
			set
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				}
				else if (UxCcOUjbgnNEvIhkdJiBEXFeMdJw != value)
				{
					UxCcOUjbgnNEvIhkdJiBEXFeMdJw = value;
					ClearVars();
				}
			}
		}

		IList<Button> IPlayerController.buttons
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				return flucwReYhOuUeYJRXhsmbVTxweIg;
			}
		}

		IList<Axis> IPlayerController.axes
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				return FnOiAIJOiaBcwgPEHwQoQJMPGqPFA;
			}
		}

		IList<Element> IPlayerController.elements
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return null;
				}
				return dbafqnCdgNGOLMgfWfEterXDQBOp;
			}
		}

		int IPlayerController.buttonCount
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return 0;
				}
				if (xvrDoouDguTnYqbtTDFvCsoVWqAmA == null)
				{
					return 0;
				}
				return xvrDoouDguTnYqbtTDFvCsoVWqAmA._count;
			}
		}

		int IPlayerController.axisCount
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return 0;
				}
				if (GhNdbrKTyfJkFQTprbhZBXTFllQHb == null)
				{
					return 0;
				}
				return GhNdbrKTyfJkFQTprbhZBXTFllQHb._count;
			}
		}

		int IPlayerController.elementCount
		{
			get
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
					return 0;
				}
				if (tYpytLFDoylKwCfhcQADxYFvGSlX == null)
				{
					return 0;
				}
				return tYpytLFDoylKwCfhcQADxYFvGSlX._count;
			}
		}

		internal Player PXgboTkZzlEkFsUiSrFJitKXuHkW
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
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				}
				else
				{
					VLSrIZQxKRnJmpYcLJnLBQLqyZSO = (Action<int, bool>)Delegate.Combine(VLSrIZQxKRnJmpYcLJnLBQLqyZSO, value);
				}
			}
			remove
			{
				VLSrIZQxKRnJmpYcLJnLBQLqyZSO = (Action<int, bool>)Delegate.Remove(VLSrIZQxKRnJmpYcLJnLBQLqyZSO, value);
			}
		}

		event Action<int, float> IPlayerController.AxisValueChangedEvent
		{
			add
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				}
				else
				{
					kqpiXgYWHDqMXWNhvKmKrJqyEJlj = (Action<int, float>)Delegate.Combine(kqpiXgYWHDqMXWNhvKmKrJqyEJlj, value);
				}
			}
			remove
			{
				kqpiXgYWHDqMXWNhvKmKrJqyEJlj = (Action<int, float>)Delegate.Remove(kqpiXgYWHDqMXWNhvKmKrJqyEJlj, value);
			}
		}

		event Action<bool> IPlayerController.EnabledStateChangedEvent
		{
			add
			{
				if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
				{
					ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				}
				else
				{
					fZeAhmnwFIByGfinNxgvQcpxfKLx = (Action<bool>)Delegate.Combine(fZeAhmnwFIByGfinNxgvQcpxfKLx, value);
				}
			}
			remove
			{
				fZeAhmnwFIByGfinNxgvQcpxfKLx = (Action<bool>)Delegate.Remove(fZeAhmnwFIByGfinNxgvQcpxfKLx, value);
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
			LngTlIEEzmFRPfjDkkuvKylesNHMA = ReInput._id;
			UxCcOUjbgnNEvIhkdJiBEXFeMdJw = P_0.playerId;
			eDcRlgqYFphpGxHmQSvshgrYvFfp = P_0.enabled;
			List<Element> list = new List<Element>();
			List<Element> list2 = new List<Element>();
			List<Button> list3 = new List<Button>();
			List<Axis> list4 = new List<Axis>();
			foreach (Element.Definition element in P_0.elements)
			{
				PXCaZilwmXTosPtzkaeDoftUmagX(element.xDzhzcLhFxRsAndLSDrjfYqMXVcs(this), list, list2, list3, list4);
			}
			list.AddRange(list2);
			tYpytLFDoylKwCfhcQADxYFvGSlX = new AList<Element>(list);
			xvrDoouDguTnYqbtTDFvCsoVWqAmA = new AList<Button>(list3);
			GhNdbrKTyfJkFQTprbhZBXTFllQHb = new AList<Axis>(list4);
			dbafqnCdgNGOLMgfWfEterXDQBOp = new ReadOnlyCollection<Element>(tYpytLFDoylKwCfhcQADxYFvGSlX);
			flucwReYhOuUeYJRXhsmbVTxweIg = new ReadOnlyCollection<Button>(xvrDoouDguTnYqbtTDFvCsoVWqAmA);
			FnOiAIJOiaBcwgPEHwQoQJMPGqPFA = new ReadOnlyCollection<Axis>(GhNdbrKTyfJkFQTprbhZBXTFllQHb);
			oDHNiKTtOYoYuxHXdTQMoqcMHBCO = new List<Element.SWooPnJhIYheyzWNbAxiuFkavEGl>();
			ReInput.UpdateEndedEvent += jusKGrgabgEDFivQFWRwQUvJUhgX;
		}

		~PlayerController()
		{
			ReInput.UpdateEndedEvent -= jusKGrgabgEDFivQFWRwQUvJUhgX;
		}

		public bool GetButton(int index)
		{
			if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
			{
				ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				return false;
			}
			if ((uint)index >= (uint)xvrDoouDguTnYqbtTDFvCsoVWqAmA._count)
			{
				return false;
			}
			return xvrDoouDguTnYqbtTDFvCsoVWqAmA[index].value;
		}

		bool IPlayerController.GetButton(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButton
			return this.GetButton(index);
		}

		public bool GetButtonDown(int index)
		{
			if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
			{
				ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				return false;
			}
			if ((uint)index >= (uint)xvrDoouDguTnYqbtTDFvCsoVWqAmA._count)
			{
				return false;
			}
			return xvrDoouDguTnYqbtTDFvCsoVWqAmA[index].justPressed;
		}

		bool IPlayerController.GetButtonDown(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonDown
			return this.GetButtonDown(index);
		}

		public bool GetButtonUp(int index)
		{
			if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
			{
				ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				return false;
			}
			if ((uint)index >= (uint)xvrDoouDguTnYqbtTDFvCsoVWqAmA._count)
			{
				return false;
			}
			return xvrDoouDguTnYqbtTDFvCsoVWqAmA[index].justReleased;
		}

		bool IPlayerController.GetButtonUp(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetButtonUp
			return this.GetButtonUp(index);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
			{
				ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				return 0f;
			}
			if ((uint)index >= (uint)GhNdbrKTyfJkFQTprbhZBXTFllQHb._count)
			{
				return 0f;
			}
			return GhNdbrKTyfJkFQTprbhZBXTFllQHb[index].value;
		}

		float IPlayerController.GetAxis(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxis
			return this.GetAxis(index);
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
			{
				ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				return 0f;
			}
			if ((uint)index >= (uint)GhNdbrKTyfJkFQTprbhZBXTFllQHb._count)
			{
				return 0f;
			}
			return GhNdbrKTyfJkFQTprbhZBXTFllQHb[index].valueRaw;
		}

		float IPlayerController.GetAxisRaw(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAxisRaw
			return this.GetAxisRaw(index);
		}

		public Element GetElement(int index)
		{
			if (ReInput._id != LngTlIEEzmFRPfjDkkuvKylesNHMA)
			{
				ReInput.CheckInitialized(LngTlIEEzmFRPfjDkkuvKylesNHMA);
				return null;
			}
			if ((uint)index >= (uint)tYpytLFDoylKwCfhcQADxYFvGSlX._count)
			{
				return null;
			}
			return tYpytLFDoylKwCfhcQADxYFvGSlX[index];
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

		private void jusKGrgabgEDFivQFWRwQUvJUhgX(UpdateLoopType P_0)
		{
			Update(P_0);
			UpdateFinished();
		}

		protected virtual bool Update(UpdateLoopType updateLoop)
		{
			if (!eDcRlgqYFphpGxHmQSvshgrYvFfp)
			{
				return false;
			}
			bool flag = kqpiXgYWHDqMXWNhvKmKrJqyEJlj != null;
			bool flag2 = VLSrIZQxKRnJmpYcLJnLBQLqyZSO != null;
			for (int i = 0; i < tYpytLFDoylKwCfhcQADxYFvGSlX._count; i++)
			{
				float num = 0f;
				if (flag && tYpytLFDoylKwCfhcQADxYFvGSlX[i] is Axis)
				{
					Axis axis = tYpytLFDoylKwCfhcQADxYFvGSlX[i] as Axis;
					num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
				}
				tYpytLFDoylKwCfhcQADxYFvGSlX[i].RAnlkSSfVGoWVCgYOKScuJJWVBOf();
				if (flag2 && tYpytLFDoylKwCfhcQADxYFvGSlX[i] is Button)
				{
					Button button = tYpytLFDoylKwCfhcQADxYFvGSlX[i] as Button;
					if (button.justPressed && button.value)
					{
						oDHNiKTtOYoYuxHXdTQMoqcMHBCO.Add(new Element.SWooPnJhIYheyzWNbAxiuFkavEGl(ControllerElementType.Button, i, 1f));
					}
					else if (button.justReleased && !button.value)
					{
						oDHNiKTtOYoYuxHXdTQMoqcMHBCO.Add(new Element.SWooPnJhIYheyzWNbAxiuFkavEGl(ControllerElementType.Button, i, 0f));
					}
				}
				else if (flag && tYpytLFDoylKwCfhcQADxYFvGSlX[i] is Axis)
				{
					oDHNiKTtOYoYuxHXdTQMoqcMHBCO.Add(new Element.SWooPnJhIYheyzWNbAxiuFkavEGl(ControllerElementType.Axis, i, (tYpytLFDoylKwCfhcQADxYFvGSlX[i] as Axis).value - num));
				}
			}
			return true;
		}

		protected virtual void UpdateFinished()
		{
			int count = oDHNiKTtOYoYuxHXdTQMoqcMHBCO.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				Element.SWooPnJhIYheyzWNbAxiuFkavEGl sWooPnJhIYheyzWNbAxiuFkavEGl = oDHNiKTtOYoYuxHXdTQMoqcMHBCO[i];
				if (sWooPnJhIYheyzWNbAxiuFkavEGl.IwPBfJEJJVvCnBQGxyVghUuToPAy == ControllerElementType.Button)
				{
					try
					{
						VLSrIZQxKRnJmpYcLJnLBQLqyZSO(sWooPnJhIYheyzWNbAxiuFkavEGl.vAQIWjHsVygFQHHtFjHuiOTFxkEge, sWooPnJhIYheyzWNbAxiuFkavEGl.jooSZwlirgQvIYsKgcshbPRHymSu > 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
					}
				}
				else if (sWooPnJhIYheyzWNbAxiuFkavEGl.IwPBfJEJJVvCnBQGxyVghUuToPAy == ControllerElementType.Axis)
				{
					try
					{
						kqpiXgYWHDqMXWNhvKmKrJqyEJlj(sWooPnJhIYheyzWNbAxiuFkavEGl.vAQIWjHsVygFQHHtFjHuiOTFxkEge, sWooPnJhIYheyzWNbAxiuFkavEGl.jooSZwlirgQvIYsKgcshbPRHymSu);
					}
					catch (Exception ex2)
					{
						Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
					}
				}
			}
			oDHNiKTtOYoYuxHXdTQMoqcMHBCO.Clear();
		}

		protected virtual void ClearVars()
		{
			oDHNiKTtOYoYuxHXdTQMoqcMHBCO.Clear();
		}

		internal void hiyMgiVoJcFSJysckXNgbxortREc(Element P_0)
		{
			if (P_0 != null)
			{
				if (P_0 is Axis)
				{
					GhNdbrKTyfJkFQTprbhZBXTFllQHb.Add(P_0 as Axis);
				}
				else if (P_0 is Button)
				{
					xvrDoouDguTnYqbtTDFvCsoVWqAmA.Add(P_0 as Button);
				}
				tYpytLFDoylKwCfhcQADxYFvGSlX.Add(P_0);
			}
		}

		private void PXCaZilwmXTosPtzkaeDoftUmagX(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
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
					(P_0 as CompoundElement).SAEuqYKLwNcUgMGUMwjUbcqBvNqf(list);
					for (int i = 0; i < list.Count; i++)
					{
						PXCaZilwmXTosPtzkaeDoftUmagX(list[i], P_1, P_2, P_3, P_4);
					}
				}
				P_2.Add(P_0);
			}
			else
			{
				Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
			}
		}

		internal static int bHwURNkVdDYhdzxesQhhqttMvZZF<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
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
