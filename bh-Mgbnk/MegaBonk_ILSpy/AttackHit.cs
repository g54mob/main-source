using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

public class AttackHit : MonoBehaviour
{
	public float timeout;

	public RandomSfx randomSfx;

	public ParticleSystem ps;

	public ObjectPool<GameObject> pool;

	public AudioClip enemyHitSfx;

	public AudioClip wallHitSfx;

	public void Play(bool hitEnemy, bool useSfx)
	{
		//IL_004c: Invalid comparison between I4 and F4
		//IL_0279: Expected I4, but got O
		//IL_0384: Expected O, but got I4
		//IL_0202: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172CFB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = false;
		bool flag6 = default(bool);
		if (!flag)
		{
			gameObject.SetActive(value: true);
			bool flag3 = !(0f < timeout);
			flag2 = true;
			bool flag4 = false;
			if (flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Exception ex = new Exception("Need a timeout on projectile hit effect");
				ex._002Ector("Need a timeout on projectile hit effect");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}
			bool flag5 = !flag6;
			flag2 = true;
			if (flag5)
			{
				goto IL_0298;
			}
			RandomSfx randomSfx = this.randomSfx;
			bool flag7 = (object)this.randomSfx == null;
			flag2 = true;
			flag6 = false;
			if (!flag7)
			{
				bool flag8 = (object)randomSfx.s == null;
				flag2 = true;
				flag6 = false;
				if (!flag8)
				{
					bool flag9 = randomSfx.s.enabled;
					bool flag10 = !flag9;
					flag2 = false;
					if (flag10)
					{
						goto IL_0298;
					}
					RandomSfx randomSfx2 = this.randomSfx;
					bool flag11 = (object)this.randomSfx == null;
					flag2 = false;
					flag6 = false;
					if (!flag11)
					{
						AudioClip[] sounds = randomSfx2.sounds;
						if (!hitEnemy)
						{
							bool flag12 = randomSfx2.sounds == null;
							flag2 = false;
							flag6 = false;
							if (flag12)
							{
								goto IL_02e2;
							}
							bool flag13 = sounds.Length <= 0;
							flag2 = false;
							flag6 = false;
							if (flag13)
							{
								goto IL_035e;
							}
							flag2 = (byte)(int)wallHitSfx != 0;
						}
						else
						{
							bool flag14 = randomSfx2.sounds == null;
							flag2 = false;
							flag6 = false;
							if (flag14)
							{
								goto IL_02e2;
							}
							bool flag15 = sounds.Length <= 0;
							flag2 = false;
							flag6 = false;
							if (flag15)
							{
								goto IL_035e;
							}
							flag2 = (byte)(int)enemyHitSfx != 0;
						}
						sounds[0] = (AudioClip)flag2;
						bool flag16 = (object)this.randomSfx == null;
						flag6 = false;
						if (!flag16)
						{
							this.randomSfx.Play();
							goto IL_0298;
						}
					}
				}
			}
		}
		goto IL_02e2;
		IL_0298:
		bool flag17 = (object)ps == null;
		flag6 = false;
		if (!flag17)
		{
			ps.Play();
			Invoke("ReleaseToPool", timeout);
			return;
		}
		goto IL_02e2;
		IL_035e:
		throw new IndexOutOfRangeException();
		IL_02e2:
		throw new NullReferenceException();
	}

	private void ReleaseToPool()
	{
		GameObject element = base.gameObject;
		pool.Release(element);
	}

	private void OnValidate()
	{
		RandomSfx component = GetComponent<RandomSfx>();
		randomSfx = component;
		ParticleSystem component2 = GetComponent<ParticleSystem>();
		ps = component2;
	}
}
