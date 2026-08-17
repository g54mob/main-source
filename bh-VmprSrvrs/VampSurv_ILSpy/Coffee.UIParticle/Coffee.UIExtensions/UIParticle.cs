using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coffee.UIParticleExtensions;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Coffee.UIExtensions;

public class UIParticle : MaskableGraphic
{
	public enum MeshSharing
	{
		None,
		Auto,
		Primary,
		PrimarySimulator,
		Reprica
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<ParticleSystem> _003C_003E9__52_0;

		public static Action<ParticleSystem> _003C_003E9__53_0;

		public static Action<ParticleSystem> _003C_003E9__55_0;

		public static Action<ParticleSystem> _003C_003E9__56_0;

		public static Func<UIParticleRenderer, bool> _003C_003E9__64_0;

		public static Action<UIParticleRenderer> _003C_003E9__68_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CPlay_003Eb__52_0(ParticleSystem p)
		{
			bool fixedTimeStep = default(bool);
			p.Simulate(0f, withChildren: false, restart: true, fixedTimeStep);
		}

		internal void _003CPause_003Eb__53_0(ParticleSystem p)
		{
			bool flag = ((UnityEngine.Object)p).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}

		internal void _003CStop_003Eb__55_0(ParticleSystem p)
		{
			p.Stop();
		}

		internal void _003CClear_003Eb__56_0(ParticleSystem p)
		{
			p.Clear(withChildren: true);
		}

		internal bool _003CUpdateRenderers_003Eb__64_0(UIParticleRenderer x)
		{
			if ((object)x != null)
			{
				return ((UnityEngine.Object)x).m_CachedPtr == (IntPtr)0;
			}
			return true;
		}

		internal void _003COnDisable_003Eb__68_0(UIParticleRenderer r)
		{
			//IL_0012: Expected I4, but got I8
			r.Clear(-1);
		}
	}

	private sealed class _003Cget_materials_003Ed__45 : IEnumerable<Material>, IEnumerable, IEnumerator<Material>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Material _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public UIParticle _003C_003E4__this;

		private int _003Ci_003E5__2;

		Material IEnumerator<Material>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003Cget_materials_003Ed__45(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			_003C_003El__initialThreadId = num;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0056: Expected I4, but got I8
			//IL_02bf: Expected I4, but got O
			UIParticle uIParticle = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003Ci_003E5__2 = _003C_003E1__state;
				goto IL_0292;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_0260;
			}
			_003C_003E1__state = -1;
			goto IL_02f5;
			IL_0260:
			return false;
			IL_02f5:
			int num = _003Ci_003E5__2 + 1;
			_003Ci_003E5__2 = num;
			goto IL_0292;
			IL_0292:
			if ((object)_003C_003E4__this != null)
			{
				List<UIParticleRenderer> renderers = uIParticle.m_Renderers;
				if (uIParticle.m_Renderers != null)
				{
					if (_003Ci_003E5__2 >= renderers._size)
					{
						goto IL_0260;
					}
					List<UIParticleRenderer> renderers2 = uIParticle.m_Renderers;
					int num2 = _003Ci_003E5__2;
					if (_003Ci_003E5__2 < renderers2._size)
					{
						UIParticleRenderer[] items = renderers2._items;
						if (renderers2._items != null)
						{
							UIParticleRenderer uIParticleRenderer = items[num2];
							if ((object)items[num2] == null || ((UnityEngine.Object)uIParticleRenderer).m_CachedPtr == (IntPtr)0)
							{
								goto IL_02f5;
							}
							if (uIParticle.m_Renderers != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								object obj = default(object);
								if (obj != null)
								{
									object obj2 = obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v406 @ rdx_v5+338] (should have been resolved before IL gen)");
									UnityEngine.Object obj3 = default(UnityEngine.Object);
									if (!obj3)
									{
										goto IL_02f5;
									}
									if (uIParticle.m_Renderers != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										object obj4 = default(object);
										if (obj4 != null)
										{
											object obj5 = obj4;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v423 @ rdx_v9+338] (should have been resolved before IL gen)");
											Material material = default(Material);
											_003C_003E2__current = material;
											_003C_003E1__state = 1;
											return true;
										}
									}
								}
							}
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}

		IEnumerator<Material> IEnumerable<Material>.GetEnumerator()
		{
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					return this;
				}
			}
			_003Cget_materials_003Ed__45 obj2 = null;
			obj2._003C_003E1__state = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			obj2._003C_003El__initialThreadId = num;
			obj2._003C_003E4__this = _003C_003E4__this;
			return obj2;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					return this;
				}
			}
			_003Cget_materials_003Ed__45 obj2 = null;
			obj2._003C_003E1__state = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			obj2._003C_003El__initialThreadId = num;
			obj2._003C_003E4__this = _003C_003E4__this;
			return obj2;
		}
	}

	internal bool m_IsTrail;

	private Vector3 m_Scale3D;

	internal AnimatableProperty[] m_AnimatableProperties;

	private List<ParticleSystem> m_Particles;

	private MeshSharing m_MeshSharing;

	private int m_GroupId;

	private int m_GroupMaxId;

	private bool m_AbsoluteMode;

	private List<UIParticleRenderer> m_Renderers;

	private DrivenRectTransformTracker _tracker;

	private Camera _orthoCamera;

	private int _groupId;

	private bool _003CisPaused_003Ek__BackingField;

	public override bool raycastTarget
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public MeshSharing meshSharing
	{
		get
		{
			return m_MeshSharing;
		}
		set
		{
			m_MeshSharing = value;
		}
	}

	public int groupId
	{
		get
		{
			return _groupId;
		}
		set
		{
			if (m_GroupId != value)
			{
				m_GroupId = value;
				if (value != m_GroupMaxId)
				{
					ResetGroupId();
				}
			}
		}
	}

	public int groupMaxId
	{
		get
		{
			return m_GroupMaxId;
		}
		set
		{
			if (m_GroupMaxId != value)
			{
				m_GroupMaxId = value;
				ResetGroupId();
			}
		}
	}

	public bool absoluteMode
	{
		get
		{
			return m_AbsoluteMode;
		}
		set
		{
			m_AbsoluteMode = value;
		}
	}

	internal bool useMeshSharing
	{
		get
		{
			bool flag = m_MeshSharing < MeshSharing.None;
			bool flag2 = m_MeshSharing == MeshSharing.None;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
	}

	internal bool isPrimary
	{
		get
		{
			//IL_0038: Expected O, but got I4
			if (m_MeshSharing == MeshSharing.Primary)
			{
				return true;
			}
			object obj = m_MeshSharing - 3;
			return obj == null;
		}
	}

	internal bool canSimulate
	{
		get
		{
			//IL_006d: Expected O, but got I4
			if (m_MeshSharing != MeshSharing.None && m_MeshSharing != MeshSharing.Auto && m_MeshSharing != MeshSharing.Primary)
			{
				object obj = m_MeshSharing - 3;
				return obj == null;
			}
			return true;
		}
	}

	internal bool canRender
	{
		get
		{
			//IL_006d: Expected O, but got I4
			if (m_MeshSharing != MeshSharing.None && m_MeshSharing != MeshSharing.Auto && m_MeshSharing != MeshSharing.Primary)
			{
				object obj = m_MeshSharing - 4;
				return obj == null;
			}
			return true;
		}
	}

	public float scale
	{
		get
		{
			//IL_0007: Expected F4, but got O
			return (float)m_Scale3D;
		}
		set
		{
			Vector3 vector = default(Vector3);
			m_Scale3D = vector;
		}
	}

	public unsafe Vector3 scale3D
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)m_Scale3D;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Coffee.UIExtensions.UIParticle)+EC]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		set
		{
			//IL_000f: Expected O, but got F4
			m_Scale3D = (Vector3)value.x;
			_ = value.z;
		}
	}

	public List<ParticleSystem> particles => m_Particles;

	public IEnumerable<Material> materials
	{
		get
		{
			//IL_0021: Expected I4, but got I8
			_003Cget_materials_003Ed__45 obj = null;
			obj._003C_003E1__state = -2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			obj._003C_003El__initialThreadId = num;
			obj._003C_003E4__this = this;
			return obj;
		}
	}

	public override Material materialForRendering => null;

	public bool isPaused
	{
		get
		{
			return _003CisPaused_003Ek__BackingField;
		}
		internal set
		{
			_003CisPaused_003Ek__BackingField = value;
		}
	}

	public void Play()
	{
		Action<ParticleSystem> action = _003C_003Ec._003C_003E9__52_0;
		if (_003C_003Ec._003C_003E9__52_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__52_0 = delegate(ParticleSystem p)
			{
				bool fixedTimeStep = default(bool);
				p.Simulate(0f, withChildren: false, restart: true, fixedTimeStep);
			});
		}
		ParticleSystemExtensions.Exec(m_Particles, action);
		_003CisPaused_003Ek__BackingField = false;
	}

	public void Pause()
	{
		Action<ParticleSystem> action = _003C_003Ec._003C_003E9__53_0;
		if (_003C_003Ec._003C_003E9__53_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__53_0 = delegate(ParticleSystem p)
			{
				bool flag = ((UnityEngine.Object)p).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			});
		}
		ParticleSystemExtensions.Exec(m_Particles, action);
		_003CisPaused_003Ek__BackingField = true;
	}

	public void Resume()
	{
		_003CisPaused_003Ek__BackingField = false;
	}

	public void Stop()
	{
		Action<ParticleSystem> action = _003C_003Ec._003C_003E9__55_0;
		if (_003C_003Ec._003C_003E9__55_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__55_0 = delegate(ParticleSystem p)
			{
				p.Stop();
			});
		}
		ParticleSystemExtensions.Exec(m_Particles, action);
		_003CisPaused_003Ek__BackingField = true;
	}

	public void Clear()
	{
		Action<ParticleSystem> action = _003C_003Ec._003C_003E9__56_0;
		if (_003C_003Ec._003C_003E9__56_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__56_0 = delegate(ParticleSystem p)
			{
				p.Clear(withChildren: true);
			});
		}
		ParticleSystemExtensions.Exec(m_Particles, action);
		_003CisPaused_003Ek__BackingField = true;
	}

	public void SetParticleSystemInstance(GameObject instance)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x181B96D10\"");
	}

	public unsafe void SetParticleSystemInstance(GameObject instance, bool destroyOldParticles)
	{
		//IL_0405: Expected I4, but got O
		//IL_026e: Expected O, but got Ref
		//IL_028a: Expected O, but got Ref
		//IL_0297: Expected F4, but got I4
		//IL_0292: Expected native int or pointer, but got O
		//IL_00b7: Expected I, but got O
		//IL_0142: Expected O, but got I4
		//IL_0393: Expected I, but got O
		//IL_00ef: Expected O, but got I
		//IL_034b: Expected O, but got I
		//IL_0161: Expected O, but got I
		//IL_0177: Expected O, but got I
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01c2: Expected O, but got I
		//IL_01fa: Expected O, but got I
		//IL_022c: Expected O, but got I4
		//IL_043e->IL030c: Incompatible stack heights: 1 vs 0
		//IL_048c->IL030b: Incompatible stack heights: 3 vs 0
		//IL_03f7->IL03fc: Incompatible stack heights: 6 vs 0
		//IL_0266->IL03fc: Incompatible stack heights: 6 vs 0
		if ((object)instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			IEnumerator enumerator = transform.GetEnumerator();
			object obj = default(object);
			object obj2 = default(object);
			object obj10 = default(object);
			bool flag3 = default(bool);
			while (true)
			{
				bool flag = (byte)(int)(~obj) != 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj2 == null)
				{
					break;
				}
				bool flag2 = obj == null;
				nint num = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ r10_v15 (Il2CppClass<System.Object>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_012f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ r10_v15 (Il2CppClass<System.Object>)+B0]");
				object obj3 = 0;
				nint num2 = 0;
				while (true)
				{
					object obj4 = num2 + num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ r8_v20+v788 @ rax_v92*8]");
					if (0 == (nint)typeof(IEnumerator))
					{
						break;
					}
					num2++;
					nint intPtr = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ r10_v15 (Il2CppClass<System.Object>)+12E]");
					if (intPtr < 0)
					{
						continue;
					}
					goto IL_012f;
				}
				object obj5 = num2 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ r8_v20+8+v856 @ rcx_v73*8]");
				object obj6 = (nint)0 + (nint)1;
				object obj7 = obj6 << 4;
				object obj8 = obj7 + 312;
				object obj9 = obj8 + num;
				goto IL_037b;
				IL_012f:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj3 = 1;
				obj9 = obj10;
				goto IL_037b;
				IL_037b:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v864 @ rdx_v36] (should have been resolved before IL gen)");
				nint num3 = (nint)typeof(Transform);
				if (flag3)
				{
					nint num4 = (((bool*)(flag3 ? 1 : 0))->m_value ? 1 : 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rcx_v60 (Il2CppClass<UnityEngine.Transform>)+130]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r9_v14 (Il2CppMethodInfo)+130]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rcx_v60 (Il2CppClass<UnityEngine.Transform>)+130]");
					bool flag4 = num5 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r9_v14 (Il2CppMethodInfo)+C8]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ rax_v77+FFFFFFF8+v761 @ rax_v76*8]");
					bool flag5 = 0 != (nint)typeof(Transform);
					GameObject gameObject = ((Component)flag3).gameObject;
					bool flag6 = (object)gameObject == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v78 (UnityEngine.GameObject)+10]");
					bool flag7 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v78 (UnityEngine.GameObject)+10]");
					GameObject.SetActive_Injected((IntPtr)0, false);
					if (destroyOldParticles)
					{
						UnityEngine.Object.Destroy(gameObject);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			Vector3 vector = (Vector3)(&obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Vector3 vector2 = (Vector3)(&obj);
			bool flag8 = default(bool);
			((Vector3*)(nint)vector2)->x = (flag8 ? 1 : 0);
			if (flag8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			Transform transform2 = instance.transform;
			Transform transform3 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag9 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				bool flag10 = (object)transform3 == null;
				nint parent = 0;
				if (!flag10)
				{
					parent = ((UnityEngine.Object)transform3).m_CachedPtr;
				}
				Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)parent, false);
				bool flag11 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				RefreshParticles(instance);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SetParticleSystemPrefab(GameObject prefab)
	{
		if ((object)prefab != null && ((UnityEngine.Object)prefab).m_CachedPtr != (IntPtr)0)
		{
			GameObject instance = UnityEngine.Object.Instantiate(prefab);
			SetParticleSystemInstance(instance, destroyOldParticles: true);
		}
	}

	public void RefreshParticles()
	{
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 12 Invalid \"Jump target not found in method: 0x181B97410\"");
	}

	private unsafe void RefreshParticles(GameObject root)
	{
		//IL_008f: Expected O, but got Ref
		if ((object)root == null || ((UnityEngine.Object)root).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		root.GetComponentsInChildren(includeInactive: false, m_Particles);
		Predicate<ParticleSystem> match = delegate(ParticleSystem x)
		{
			//IL_0101: Expected I4, but got O
			//IL_014b: Expected O, but got I4
			//IL_0165: Expected O, but got I4
			if ((object)x != null)
			{
				UIParticle componentInParent = x.GetComponentInParent<UIParticle>();
				bool flag = (object)componentInParent == null;
				bool flag2 = (object)this == null;
				object obj = flag2 & flag;
				bool flag3 = obj == null;
				object obj2 = !flag3;
				if (obj2 != null)
				{
					return false;
				}
				if ((object)this != null)
				{
					if ((object)componentInParent != null)
					{
						object obj3 = (object)componentInParent - (object)this;
						bool flag4 = obj3 == null;
						return !flag4;
					}
					bool flag5 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					return !flag5;
				}
				if ((object)componentInParent != null)
				{
					bool flag6 = ((UnityEngine.Object)componentInParent).m_CachedPtr == (IntPtr)0;
					return !flag6;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		int num = ((List<object>)(object)m_Particles).RemoveAll((Predicate<object>)match);
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<ParticleSystem>.Enumerator enumerator2 = (List<ParticleSystem>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		RefreshParticles(m_Particles);
	}

	public void RefreshParticles(List<ParticleSystem> particles)
	{
		//IL_0138: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rbx_v1 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		GetComponentsInChildren(includeInactive: false, m_Renderers);
		int num2 = 0;
		bool flag = false;
		int i = 0;
		int num3 = 0;
		ParticleSystem particleSystem2 = default(ParticleSystem);
		object obj2 = default(object);
		ParticleSystem particleSystem3 = default(ParticleSystem);
		int num5 = default(int);
		while (true)
		{
			if (num3 < particles._size)
			{
				if ((flag ? 1 : 0) >= particles._size)
				{
					break;
				}
				ParticleSystem[] items = particles._items;
				ParticleSystem particleSystem = items[flag ? 1u : 0u];
				if ((object)items[flag ? 1u : 0u] != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
				{
					int num4 = i + 1;
					UIParticleRenderer renderer = GetRenderer(i);
					((Component)(object)particles).GetComponentsInChildren(flag, (List<UIParticleRenderer>)null);
					renderer.Set(this, particleSystem2, isTrail: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCF8]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCF8]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj == null)
						{
							MissingMethodException ex = new MissingMethodException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v545 @ rax_v29 (should have been resolved before IL gen)");
					bool flag2 = obj2 == null;
					i = num4;
					if (!flag2)
					{
						i = num4 + 1;
						UIParticleRenderer renderer2 = GetRenderer(num4);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						renderer2.Set(this, particleSystem3, isTrail: true);
						num2 = num5;
					}
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				num3 = (flag ? 1 : 0);
				continue;
			}
			for (List<UIParticleRenderer> renderers = m_Renderers; i < renderers._size; i++)
			{
				UIParticleRenderer renderer3 = GetRenderer(i);
				renderer3.Clear(i);
				renderers = m_Renderers;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	internal void UpdateTransformScale()
	{
		//IL_01c4->IL00d2: Incompatible stack heights: 1 vs 0
		//IL_02c4->IL02c4: Incompatible stack heights: 4 vs 2
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Transform parent = transform.parent;
			if ((object)parent != null)
			{
				bool flag = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
				Transform.get_lossyScale_Injected(((UnityEngine.Object)parent).m_CachedPtr, out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj = default(object);
				bool flag2 = obj != null;
				float num = 1f;
				if (!flag2)
				{
					num = 1f / (float)ret;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj2 = default(object);
				bool flag3 = obj2 != null;
				float num2 = 1f;
				if (!flag3)
				{
					object obj3 = default(object);
					num2 = 1f / (float)obj3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj4 = default(object);
				bool flag4 = obj4 != null;
				float num3 = 1f;
				if (!flag4)
				{
					num3 = 1f / 0f;
				}
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
					float num4 = (float)ret - num;
					object obj5 = default(object);
					float num5 = (float)obj5 - num2;
					float num6 = 0f - num3;
					float num7 = num5 * num5;
					float num8 = num6 * num6;
					float num9 = num4 * num4;
					float num10 = num7 + num9;
					float num11 = num10 + num8;
					if (!(9.9999994E-11f > num11))
					{
						Transform transform3 = base.transform;
						bool flag6 = (object)transform3 == null;
						bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref ret);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	internal void UpdateRenderers()
	{
		//IL_0183: Expected O, but got I4
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_012c: Expected O, but got I4
		//IL_016e->IL0220: Incompatible stack heights: 2 vs 1
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj == null)
		{
			return;
		}
		Func<UIParticleRenderer, bool> predicate = _003C_003Ec._003C_003E9__64_0;
		if (_003C_003Ec._003C_003E9__64_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__64_0 = (UIParticleRenderer x) => (object)x == null || ((UnityEngine.Object)x).m_CachedPtr == (IntPtr)0);
		}
		if (Enumerable.Any(m_Renderers, predicate))
		{
			RefreshParticles(m_Particles);
		}
		Camera bakeCamera = GetBakeCamera();
		List<UIParticleRenderer> renderers = m_Renderers;
		Func<UIParticleRenderer, bool> func = null;
		Func<UIParticleRenderer, bool> func2 = null;
		while ((nint)func < renderers._size)
		{
			List<UIParticleRenderer> renderers2 = m_Renderers;
			bool flag2 = (nint)func2 >= renderers2._size;
			UIParticleRenderer[] items = renderers2._items;
			UIParticleRenderer uIParticleRenderer = items[(object)func2];
			if ((object)items[(object)func2] != null && ((UnityEngine.Object)uIParticleRenderer).m_CachedPtr != (IntPtr)0)
			{
				UIParticleRenderer uIParticleRenderer2 = (UIParticleRenderer)Enumerable.Any(m_Renderers, func2);
				uIParticleRenderer2.UpdateMesh(bakeCamera);
			}
			renderers = m_Renderers;
			func2 = (Func<UIParticleRenderer, bool>)(func2 + 1);
			func = func2;
		}
	}

	internal void UpdateParticleCount()
	{
		//IL_00ed: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		List<UIParticleRenderer> renderers = m_Renderers;
		object obj = 0;
		object obj2 = 0;
		UIParticleRenderer uIParticleRenderer2 = default(UIParticleRenderer);
		while (true)
		{
			if ((nint)obj2 < renderers._size)
			{
				List<UIParticleRenderer> renderers2 = m_Renderers;
				if ((nint)obj >= renderers2._size)
				{
					break;
				}
				UIParticleRenderer[] items = renderers2._items;
				UIParticleRenderer uIParticleRenderer = items[obj];
				if ((object)items[obj] != null && ((UnityEngine.Object)uIParticleRenderer).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					uIParticleRenderer2.UpdateParticleCount();
				}
				renderers = m_Renderers;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected override void OnEnable()
	{
		ResetGroupId();
		RectTransform rectTransform = base.rectTransform;
		if ((object)this != null && ((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
		{
			List<object> s_ActiveParticles = (List<object>)(object)UIParticleUpdater.s_ActiveParticles;
			int version = s_ActiveParticles._version + 1;
			s_ActiveParticles._version = version;
			object[] items = s_ActiveParticles._items;
			if (s_ActiveParticles._size >= items.Length)
			{
				s_ActiveParticles.AddWithResize((object)this);
			}
			else
			{
				int size = s_ActiveParticles._size + 1;
				s_ActiveParticles._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
		UnityAction action = UpdateRendererMaterial;
		RegisterDirtyMaterialCallback(action);
		List<ParticleSystem> list = m_Particles;
		if (list._size <= 0)
		{
			GameObject root = base.gameObject;
			RefreshParticles(root);
		}
		else
		{
			RefreshParticles(list);
		}
		OnEnable();
		m_ShouldRecalculateStencil = true;
		UpdateClipParent();
		base.SetMaterialDirty();
		if (base.m_IsMaskingGraphic)
		{
			MaskUtilities.NotifyStencilStateChanged(this);
		}
	}

	internal void ResetGroupId()
	{
		//IL_0042: Expected O, but got I4
		//IL_0051: Expected I4, but got O
		if (m_GroupId == m_GroupMaxId)
		{
			_groupId = m_GroupId;
			return;
		}
		object obj = m_GroupMaxId + 1;
		int num = UnityEngine.Random.RandomRangeInt(m_GroupId, (int)obj);
		_groupId = num;
	}

	protected override void OnDisable()
	{
		//IL_00a2: Expected O, but got I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		if ((object)this != null && ((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
		{
			bool flag = ((List<object>)(object)UIParticleUpdater.s_ActiveParticles).Remove((object)this);
		}
		List<UIParticleRenderer> renderers = m_Renderers;
		Action<UIParticleRenderer> action = _003C_003Ec._003C_003E9__68_0;
		if (_003C_003Ec._003C_003E9__68_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__68_0 = delegate(UIParticleRenderer r)
			{
				//IL_0012: Expected I4, but got I8
				r.Clear(-1);
			});
		}
		if (action == null)
		{
			goto IL_01ce;
		}
		bool flag2 = renderers._size <= 0;
		object obj = 0;
		if (flag2)
		{
			goto IL_00fb;
		}
		while (renderers._version == renderers._version)
		{
			UIParticleRenderer[] items = renderers._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v273 @ rsi_v6 (System.Action`1<Coffee.UIExtensions.UIParticleRenderer>)+18] (should have been resolved before IL gen)");
			obj++;
			if ((nint)obj < renderers._size)
			{
				continue;
			}
			goto IL_00fb;
		}
		goto IL_01d9;
		IL_01d9:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
		goto IL_01ce;
		IL_00fb:
		if (renderers._version == renderers._version)
		{
			UnityAction action2 = UpdateRendererMaterial;
			UnregisterDirtyMaterialCallback(action2);
			base.OnDisable();
			return;
		}
		goto IL_01d9;
		IL_01ce:
		System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.action);
	}

	protected override void UpdateMaterial()
	{
	}

	protected override void UpdateGeometry()
	{
	}

	protected override void OnDidApplyAnimationProperties()
	{
	}

	private void UpdateRendererMaterial()
	{
		//IL_0131: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		List<UIParticleRenderer> renderers = m_Renderers;
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		object obj5 = default(object);
		while (true)
		{
			if ((nint)obj2 >= renderers._size)
			{
				return;
			}
			List<UIParticleRenderer> renderers2 = m_Renderers;
			if ((nint)obj >= renderers2._size)
			{
				break;
			}
			UIParticleRenderer[] items = renderers2._items;
			UIParticleRenderer uIParticleRenderer = items[obj];
			if ((object)items[obj] != null && ((UnityEngine.Object)uIParticleRenderer).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool num = base.m_Maskable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v13+C0]");
				object obj3;
				if ((nint)(num ? 1 : 0) != 0)
				{
					obj3 = obj4;
					_ = base.m_Maskable;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v57 @ r8_v3+308] (should have been resolved before IL gen)");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				obj3 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v57 @ r8_v3+308] (should have been resolved before IL gen)");
			}
			renderers = m_Renderers;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	internal UIParticleRenderer GetRenderer(int index)
	{
		List<UIParticleRenderer> renderers = m_Renderers;
		if (renderers._size <= index)
		{
			UIParticleRenderer uIParticleRenderer = UIParticleRenderer.AddRenderer(this, index);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800049E0");
		}
		List<UIParticleRenderer> renderers2 = m_Renderers;
		if (index < renderers2._size)
		{
			UIParticleRenderer[] items = renderers2._items;
			UIParticleRenderer uIParticleRenderer2 = items[index];
			if ((object)items[index] == null || ((UnityEngine.Object)uIParticleRenderer2).m_CachedPtr == (IntPtr)0)
			{
				List<UIParticleRenderer> renderers3 = m_Renderers;
				UIParticleRenderer uIParticleRenderer3 = UIParticleRenderer.AddRenderer(this, index);
				if (index >= renderers3._size)
				{
					goto IL_019f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int version = renderers3._version + 1;
				renderers3._version = version;
			}
			List<UIParticleRenderer> renderers4 = m_Renderers;
			if (index < renderers4._size)
			{
				UIParticleRenderer[] items2 = renderers4._items;
				return items2[index];
			}
		}
		goto IL_019f;
		IL_019f:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		UIParticleRenderer result = default(UIParticleRenderer);
		return result;
	}

	private unsafe Camera GetBakeCamera()
	{
		//IL_01ea->IL01ea: Incompatible stack heights: 5 vs 2
		//IL_0329->IL04b9: Incompatible stack heights: 11 vs 2
		Canvas canvas = base.canvas;
		if ((object)canvas != null && ((UnityEngine.Object)canvas).m_CachedPtr != (IntPtr)0)
		{
			Canvas canvas2 = base.canvas;
			bool flag = (object)canvas2 == null;
			Canvas rootCanvas = canvas2.rootCanvas;
			bool flag2 = (object)rootCanvas == null;
			if (rootCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				if (!_orthoCamera)
				{
					Camera componentInChildren = GetComponentInChildren<Camera>();
					_orthoCamera = componentInChildren;
					if (!_orthoCamera)
					{
						GameObject gameObject = new GameObject("UIParticleOverlayCamera");
						bool flag3 = (object)gameObject == null;
						gameObject.hideFlags = HideFlags.DontSave;
						gameObject.SetActive(value: false);
						Transform transform = gameObject.transform;
						Transform parent = base.transform;
						bool flag4 = (object)transform == null;
						transform.SetParent(parent, worldPositionStays: false);
						Camera orthoCamera = gameObject.AddComponent<Camera>();
						_orthoCamera = orthoCamera;
						bool flag5 = (object)_orthoCamera == null;
						_orthoCamera.enabled = false;
					}
				}
				Transform transform2 = rootCanvas.transform;
				bool flag6 = (object)transform2 == null;
				bool flag7 = (object)transform2.GetType() != typeof(RectTransform);
				Transform transform3 = null;
				if (!flag7)
				{
					transform3 = transform2;
				}
				bool flag8 = (object)transform3 == null;
				bool flag9 = (object)transform2.GetType() != typeof(RectTransform);
				Transform transform4 = null;
				if (!flag9)
				{
					transform4 = transform2;
				}
				bool flag10 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				RectTransform.get_rect_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out Rect ret);
				float scaleFactor = rootCanvas.scaleFactor;
				bool flag11 = (object)_orthoCamera == null;
				object obj = default(object);
				object obj2 = default(object);
				bool flag12 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
				object obj3 = obj;
				if (!flag12)
				{
					obj3 = obj2;
				}
				float orthographicSize = (float)obj3 * scaleFactor;
				_orthoCamera.orthographicSize = orthographicSize;
				bool flag13 = (object)_orthoCamera == null;
				Transform transform5 = _orthoCamera.transform;
				bool flag14 = (object)transform5 == null;
				bool flag15 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
				Quaternion rotation = default(Quaternion);
				Transform.SetPositionAndRotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&ret), ref rotation);
				bool flag16 = (object)_orthoCamera == null;
				_orthoCamera.orthographic = true;
				bool flag17 = (object)_orthoCamera == null;
				_orthoCamera.farClipPlane = 2000f;
				return _orthoCamera;
			}
			Camera worldCamera = rootCanvas.worldCamera;
			if ((bool)worldCamera)
			{
				return rootCanvas.worldCamera;
			}
			return Camera.main;
		}
		return Camera.main;
	}

	public UIParticle()
	{
		Vector3 vector = default(Vector3);
		m_Scale3D = vector;
		_ = 10f;
		AnimatableProperty[] animatableProperties = new AnimatableProperty[0];
		m_AnimatableProperties = animatableProperties;
		m_Particles = new List<ParticleSystem>();
		m_Renderers = new List<UIParticleRenderer>();
		base._002Ector();
	}

	private bool _003CRefreshParticles_003Eb__61_0(ParticleSystem x)
	{
		//IL_0101: Expected I4, but got O
		//IL_014b: Expected O, but got I4
		//IL_0165: Expected O, but got I4
		if ((object)x != null)
		{
			UIParticle componentInParent = x.GetComponentInParent<UIParticle>();
			bool flag = (object)componentInParent == null;
			bool flag2 = (object)this == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 != null)
			{
				return false;
			}
			if ((object)this != null)
			{
				if ((object)componentInParent != null)
				{
					object obj3 = (object)componentInParent - (object)this;
					bool flag4 = obj3 == null;
					return !flag4;
				}
				bool flag5 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				return !flag5;
			}
			if ((object)componentInParent != null)
			{
				bool flag6 = ((UnityEngine.Object)componentInParent).m_CachedPtr == (IntPtr)0;
				return !flag6;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
