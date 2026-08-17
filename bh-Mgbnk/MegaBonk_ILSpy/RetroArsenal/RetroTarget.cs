using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenal;

public class RetroTarget : MonoBehaviour
{
	private sealed class _003CRespawn_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroTarget _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CRespawn_003Ed__14(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0097: Expected I4, but got I8
			//IL_00da: Expected I4, but got O
			RetroTarget retroTarget = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					WaitForSeconds waitForSeconds = new WaitForSeconds(retroTarget.respawnTime);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00cc;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_00cc;
				}
				_003C_003E4__this.SpawnTarget();
			}
			return false;
			IL_00cc:
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
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private sealed class _003CSquashAndStretch_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroTarget _003C_003E4__this;

		private float _003CtimeElapsed_003E5__2;

		private Vector3 _003CstartScale_003E5__3;

		private Vector3 _003CendScale_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CSquashAndStretch_003Ed__16(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0136: Expected I4, but got I8
			//IL_04cc: Expected I4, but got O
			//IL_0039: Expected O, but got I4
			//IL_0103: Expected I4, but got I8
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_01a8: Expected O, but got F4
			//IL_00d0: Expected I4, but got I8
			//IL_009d: Expected I4, but got I8
			//IL_0201: Invalid comparison between I4 and F4
			//IL_024c: Expected F4, but got I4
			//IL_0311: Invalid comparison between I4 and F4
			//IL_035c: Expected F4, but got I4
			//IL_0421: Invalid comparison between I4 and F4
			//IL_025e: Expected O, but got Ref
			//IL_046c: Expected F4, but got I4
			//IL_036e: Expected O, but got Ref
			//IL_047e: Expected O, but got Ref
			RetroTarget retroTarget = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 != 1)
						{
							goto IL_0080;
						}
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this != null)
						{
							goto IL_04d1;
						}
					}
					else
					{
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this != null)
						{
							goto IL_04f7;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						goto IL_051d;
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				_003CtimeElapsed_003E5__2 = 0f;
				if ((object)_003C_003E4__this != null)
				{
					Transform transform = _003C_003E4__this.transform;
					if ((object)transform != null)
					{
						Vector3 localScale = transform.localScale;
						_003CstartScale_003E5__3 = (Vector3)localScale.x;
						_ = localScale.z;
						_003CendScale_003E5__4 = retroTarget.squashScale;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rdi_v1 (RetroArsenal.RetroTarget)+40]");
						_ = 0;
						goto IL_051d;
					}
				}
			}
			goto IL_04be;
			IL_04f7:
			float num2 = default(float);
			if (retroTarget.duration > _003CtimeElapsed_003E5__2)
			{
				Transform transform2 = _003C_003E4__this.transform;
				float num = _003CtimeElapsed_003E5__2 / retroTarget.duration;
				if (!(0f > num))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				if ((object)transform2 == null)
				{
					goto IL_04be;
				}
				transform2.localScale = (Vector3)(&num2);
				float deltaTime = Time.deltaTime;
				float num3 = deltaTime + _003CtimeElapsed_003E5__2;
				_003C_003E2__current = null;
				_003CtimeElapsed_003E5__2 = num3;
				_003C_003E1__state = 2;
				goto IL_0583;
			}
			_003CstartScale_003E5__3 = _003CendScale_003E5__4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (RetroArsenal.RetroTarget+<SquashAndStretch>d__16)+40]");
			_ = 0;
			_003CtimeElapsed_003E5__2 = 0f;
			_003CendScale_003E5__4 = retroTarget.originalScale;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rdi_v1 (RetroArsenal.RetroTarget)+74]");
			_ = 0;
			goto IL_04d1;
			IL_04d1:
			if (!(retroTarget.duration > _003CtimeElapsed_003E5__2))
			{
				goto IL_0080;
			}
			Transform transform3 = _003C_003E4__this.transform;
			float num4 = _003CtimeElapsed_003E5__2 / retroTarget.duration;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			if ((object)transform3 == null)
			{
				goto IL_04be;
			}
			transform3.localScale = (Vector3)(&num2);
			float deltaTime2 = Time.deltaTime;
			float num5 = deltaTime2 + _003CtimeElapsed_003E5__2;
			_003C_003E2__current = null;
			_003CtimeElapsed_003E5__2 = num5;
			_003C_003E1__state = 3;
			goto IL_0583;
			IL_04be:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0080:
			return false;
			IL_0583:
			return true;
			IL_051d:
			if (retroTarget.duration > _003CtimeElapsed_003E5__2)
			{
				Transform transform4 = _003C_003E4__this.transform;
				float num6 = _003CtimeElapsed_003E5__2 / retroTarget.duration;
				if (!(0f > num6))
				{
					if (num6 > 1f)
					{
						num6 = 1f;
					}
				}
				else
				{
					num6 = 0f;
				}
				if ((object)transform4 == null)
				{
					goto IL_04be;
				}
				transform4.localScale = (Vector3)(&num2);
				float deltaTime3 = Time.deltaTime;
				float num7 = deltaTime3 + _003CtimeElapsed_003E5__2;
				_003C_003E2__current = null;
				_003CtimeElapsed_003E5__2 = num7;
				_003C_003E1__state = 1;
				goto IL_0583;
			}
			_003CstartScale_003E5__3 = _003CendScale_003E5__4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (RetroArsenal.RetroTarget+<SquashAndStretch>d__16)+40]");
			_ = 0;
			_003CtimeElapsed_003E5__2 = 0f;
			_003CendScale_003E5__4 = retroTarget.stretchScale;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rdi_v1 (RetroArsenal.RetroTarget)+4C]");
			_ = 0;
			goto IL_04f7;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public TargetEffects effects;

	public int hitsToDestroy;

	public float respawnTime;

	public bool enableSquashAndStretch;

	public float duration;

	public Vector3 squashScale;

	public Vector3 stretchScale;

	private Renderer targetRenderer;

	private Collider targetCollider;

	private AudioSource audioSource;

	private int currentHits;

	private Vector3 originalScale;

	private void Start()
	{
		//IL_0053: Expected O, but got F4
		Renderer component = GetComponent<Renderer>();
		targetRenderer = component;
		Collider component2 = GetComponent<Collider>();
		targetCollider = component2;
		AudioSource component3 = GetComponent<AudioSource>();
		audioSource = component3;
		Transform transform = base.transform;
		Vector3 localScale = transform.localScale;
		originalScale = (Vector3)localScale.x;
		_ = localScale.z;
	}

	private unsafe void SpawnTarget()
	{
		//IL_00cb: Expected O, but got Ref
		//IL_00cb: Expected O, but got Ref
		targetRenderer.enabled = true;
		targetCollider.enabled = true;
		TargetEffects targetEffects = effects;
		if ((bool)targetEffects.respawnParticle)
		{
			TargetEffects targetEffects2 = effects;
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Quaternion rotation = transform2.rotation;
			object obj2 = default(object);
			object obj3 = default(object);
			GameObject obj = UnityEngine.Object.Instantiate(targetEffects2.respawnParticle, (Vector3)(&obj2), (Quaternion)(&obj3));
			UnityEngine.Object.Destroy(obj, 3.5f);
		}
		TargetEffects targetEffects3 = effects;
		if ((bool)targetEffects3.respawnSound && (bool)audioSource)
		{
			TargetEffects targetEffects4 = effects;
			audioSource.PlayOneShot(targetEffects4.respawnSound);
		}
		currentHits = 0;
	}

	private IEnumerator Respawn()
	{
		_003CRespawn_003Ed__14 obj = new _003CRespawn_003Ed__14(0);
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			return obj;
		}
		return (IEnumerator)new NullReferenceException();
	}

	public unsafe void OnHit()
	{
		//IL_00a6: Expected O, but got Ref
		//IL_00a6: Expected O, but got Ref
		if (++currentHits < hitsToDestroy)
		{
			TargetEffects targetEffects = effects;
			if ((bool)targetEffects.hitParticle)
			{
				TargetEffects targetEffects2 = effects;
				Transform transform = base.transform;
				Vector3 position = transform.position;
				Transform transform2 = base.transform;
				Quaternion rotation = transform2.rotation;
				object obj2 = default(object);
				object obj3 = default(object);
				GameObject obj = UnityEngine.Object.Instantiate(targetEffects2.hitParticle, (Vector3)(&obj2), (Quaternion)(&obj3));
				UnityEngine.Object.Destroy(obj, 2f);
			}
			if (enableSquashAndStretch)
			{
				_003CSquashAndStretch_003Ed__16 obj4 = new _003CSquashAndStretch_003Ed__16(0);
				obj4._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj4);
			}
		}
		else
		{
			DestroyTarget();
		}
	}

	private IEnumerator SquashAndStretch()
	{
		_003CSquashAndStretch_003Ed__16 obj = new _003CSquashAndStretch_003Ed__16(0);
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			return obj;
		}
		return (IEnumerator)new NullReferenceException();
	}

	private unsafe void DestroyTarget()
	{
		//IL_00f0: Expected O, but got Ref
		//IL_00f0: Expected O, but got Ref
		TargetEffects targetEffects = effects;
		List<GameObject> deathParticles = targetEffects.deathParticles;
		if (deathParticles._size > 0)
		{
			int index;
			if (deathParticles._size != 1)
			{
				int num = UnityEngine.Random.Range(0, deathParticles._size);
				TargetEffects targetEffects2 = effects;
				deathParticles = targetEffects2.deathParticles;
				index = num;
			}
			else
			{
				index = 0;
			}
			GameObject original = deathParticles.get_Item(index);
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Quaternion rotation = transform2.rotation;
			object obj2 = default(object);
			object obj3 = default(object);
			GameObject obj = UnityEngine.Object.Instantiate(original, (Vector3)(&obj2), (Quaternion)(&obj3));
			UnityEngine.Object.Destroy(obj, 2f);
		}
		targetRenderer.enabled = false;
		targetCollider.enabled = false;
		TargetEffects targetEffects3 = effects;
		if ((bool)targetEffects3.destroySound && (bool)audioSource)
		{
			TargetEffects targetEffects4 = effects;
			audioSource.PlayOneShot(targetEffects4.destroySound);
		}
		_003CRespawn_003Ed__14 obj4 = new _003CRespawn_003Ed__14(0);
		obj4._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj4);
	}

	public RetroTarget()
	{
		//IL_0037: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		hitsToDestroy = 5;
		respawnTime = 3f;
		enableSquashAndStretch = true;
		duration = 0.07f;
		squashScale = (Vector3)1061997773;
		_ = 1067030938;
		_ = 1065353216;
		stretchScale = (Vector3)1067030938;
		_ = 1061997773;
		_ = 1065353216;
		base._002Ector();
	}
}
