using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors;

public class BlackDiskCutscene
{
	private sealed class _003C_BlackDiskCutscene_003Ed__0(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Enemy_TP_Death death;

		private PhaserSprite _003CblackBackground_003E5__2;

		private PhaserSprite _003CnoMask_003E5__3;

		private List<Sprite> _003CspriteList_003E5__4;

		private Blitter _003Cblitter_003E5__5;

		private PhaserSprite _003Cdisk_003E5__6;

		private TweenerCore<Quaternion, Vector3, QuaternionOptions> _003Cspin_003E5__7;

		private float _003CbeatLength_003E5__8;

		private float _003Ctimer_003E5__9;

		private float _003Cduration_003E5__10;

		private int _003ClastBeat_003E5__11;

		private int _003Ci_003E5__12;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0012: Expected O, but got I8
			//IL_002c: Expected O, but got I8
			while (true)
			{
				int num = _003C_003E1__state;
				if (_003C_003E1__state > 9)
				{
					break;
				}
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v1+6DCC268+v32 @ rax_v2 (System.Int32)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v69 @ rcx_v3 (should have been resolved before IL gen)");
			}
			return false;
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
	}

	public static IEnumerator _BlackDiskCutscene(Enemy_TP_Death death)
	{
		_003C_BlackDiskCutscene_003Ed__0 obj = null;
		obj._003C_003E1__state = 0;
		obj.death = death;
		return obj;
	}

	private static void AddBobs(Blitter blitter, int amount, List<Sprite> spriteList)
	{
		//IL_000e: Expected O, but got I4
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected I4, but got Unknown
		//IL_01e4: Expected O, but got F4
		//IL_0225: Expected I, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		//IL_0233: Expected O, but got F4
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_018f: Expected I4, but got O
		//IL_0199->IL0238: Incompatible stack heights: 1 vs 0
		//IL_019e->IL023d: Incompatible stack heights: 1 vs 0
		if (amount > 0)
		{
			object obj = 0;
			List<Sprite> list = spriteList;
			int num = amount;
			Blitter blitter2 = default(Blitter);
			Vector2 vector = default(Vector2);
			bool flag2;
			do
			{
				int num2 = obj / amount;
				float num3 = (float)num2 * (float)Math.PI;
				object obj2 = Time.time;
				float num4 = num3 + num3;
				float num5 = (float)amount * ((float)Math.PI / 2f);
				float num6 = num5 + num4;
				nint num7 = (nint)typeof(ArcadePhysics);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				int num8 = obj % spriteList._size;
				bool flag = num8 >= spriteList._size;
				Sprite[] items = spriteList._items;
				Bob bob = blitter2.CreateBob(vector, items[num8]);
				BobData bobData = bob._bobData;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num9 = num6 * 0.02f;
				bobData._003CVx_003Ek__BackingField = num9;
				BobData bobData2 = bob._bobData;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num10 = (bobData2._003CVy_003Ek__BackingField = num6 * 0.02f);
				BobData bobData3 = bob._bobData;
				object obj3 = UnityEngine.Random.value;
				float num11 = num10 * 0.2f;
				obj++;
				float num12 = num11 + 1f;
				bobData3._003CBounce_003Ek__BackingField = num12;
				flag2 = (nint)obj < amount;
				list = (List<Sprite>)(object)items[num8];
				num = (int)vector;
			}
			while (flag2);
		}
	}

	private static void BlitterBounce(Blitter blitter, float left, float right, float top, float bottom, float alpha)
	{
		List<Bob>.Enumerator enumerator = default(List<Bob>.Enumerator);
		if (enumerator.MoveNext())
		{
			Bob bob = null;
			throw new NullReferenceException();
		}
	}
}
