using System;
using Coffee.UIExtensions;
using Cpp2ILInjected;
using UnityEngine;

public class MenuParticles : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public MenuParticles _003C_003E4__this;

		public ParticleSystem ps;

		internal void _003CCoinEffect_003Eb__0()
		{
			MenuParticles menuParticles = _003C_003E4__this;
			menuParticles.coinAttractor.RemoveParticleSystem(ps);
		}
	}

	public GameObject coinEffect;

	public GameObject cointEffectParent;

	public UIParticleAttractor coinAttractor;

	public static MenuParticles Instance;

	private void Awake()
	{
		Instance = this;
	}

	public unsafe void CoinEffect(Vector3 position)
	{
		//IL_00d1: Expected O, but got Ref
		//IL_00f7: Expected I, but got O
		//IL_0133: Expected I, but got O
		//IL_017e: Expected I, but got O
		//IL_01d0: Expected I, but got O
		//IL_0320: Expected O, but got I4
		//IL_032e: Expected I, but got O
		//IL_0354: Expected O, but got I4
		//IL_0362: Expected I, but got O
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass5_0();
		bool flag = CS_0024_003C_003E8__locals7 == null;
		_003C_003Ec__DisplayClass5_0 obj = CS_0024_003C_003E8__locals7;
		NullReferenceException ex;
		if (!flag)
		{
			CS_0024_003C_003E8__locals7._003C_003E4__this = this;
			bool flag2 = (object)cointEffectParent == null;
			obj = (_003C_003Ec__DisplayClass5_0)(object)cointEffectParent;
			if (!flag2)
			{
				Transform parent = cointEffectParent.transform;
				GameObject gameObject = UnityEngine.Object.Instantiate(coinEffect, parent);
				bool flag3 = (object)gameObject == null;
				nint num = 0;
				obj = (_003C_003Ec__DisplayClass5_0)(object)coinEffect;
				if (!flag3)
				{
					Transform transform = gameObject.transform;
					bool flag4 = (object)transform == null;
					num = 0;
					obj = (_003C_003Ec__DisplayClass5_0)(object)gameObject;
					if (!flag4)
					{
						object obj2 = default(object);
						transform.position = (Vector3)(&obj2);
						Transform transform2 = gameObject.transform;
						bool flag5 = (object)transform2 == null;
						num = unchecked((nint)null);
						obj = (_003C_003Ec__DisplayClass5_0)(object)gameObject;
						if (!flag5)
						{
							Transform child = transform2.GetChild(0);
							bool flag6 = (object)child == null;
							num = unchecked((nint)null);
							obj = (_003C_003Ec__DisplayClass5_0)(object)transform2;
							if (!flag6)
							{
								ParticleSystem component = child.GetComponent<ParticleSystem>();
								CS_0024_003C_003E8__locals7.ps = component;
								bool flag7 = (object)coinAttractor == null;
								num = unchecked((nint)null);
								obj = (_003C_003Ec__DisplayClass5_0)(object)coinAttractor;
								if (!flag7)
								{
									coinAttractor.AddParticleSystem(CS_0024_003C_003E8__locals7.ps);
									DestroyObject component2 = gameObject.GetComponent<DestroyObject>();
									bool flag8 = (object)component2 == null;
									num = unchecked((nint)null);
									obj = (_003C_003Ec__DisplayClass5_0)(object)gameObject;
									if (!flag8)
									{
										Action b = delegate
										{
											MenuParticles menuParticles = CS_0024_003C_003E8__locals7._003C_003E4__this;
											menuParticles.coinAttractor.RemoveParticleSystem(CS_0024_003C_003E8__locals7.ps);
										};
										Delegate obj3 = Delegate.Combine(component2.OnDestroy, b);
										if ((object)obj3 == null)
										{
											component2.OnDestroy = null;
											return;
										}
										bool flag9 = (object)obj3.GetType() != typeof(Action);
										Delegate obj4 = null;
										if (!flag9)
										{
											obj4 = obj3;
										}
										bool flag10 = (object)obj4 == null;
										object obj5 = 0;
										num = (nint)typeof(Action);
										if (flag10)
										{
											goto IL_0386;
										}
										component2.OnDestroy = (Action)obj4;
										bool flag11 = (object)obj3.GetType() != typeof(Action);
										Delegate obj6 = null;
										if (!flag11)
										{
											obj6 = obj3;
										}
										bool flag12 = (object)obj6 == null;
										obj5 = 0;
										num = (nint)typeof(Action);
										ex = (NullReferenceException)(object)obj3;
										obj = (_003C_003Ec__DisplayClass5_0)(object)typeof(Action);
										if (!flag12)
										{
											return;
										}
										goto IL_0391;
									}
								}
							}
						}
					}
				}
			}
		}
		ex = new NullReferenceException();
		goto IL_0391;
		IL_0391:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0386;
		IL_0386:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void OnCoinCollected()
	{
	}
}
