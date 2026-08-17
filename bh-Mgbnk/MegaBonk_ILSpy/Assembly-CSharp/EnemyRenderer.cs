using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
	public Enemy enemy;

	public Renderer enemyRenderer;

	private MaterialPropertyBlock propertyBlock;

	private Color freezeColorSpecular;

	private Color freezeColorAlbedo;

	private Color stunColorSpecular;

	private Color stunColorAlbedo;

	private Color echoColorSpecular;

	private Color echoColorAlbedo;

	private Color charmColorAlbedo;

	private Color charmColorSpecular;

	private Color lastSetSpecularColor;

	private string specularColorKey;

	private string albedoColorKey;

	private string rimColorKey;

	private void Awake()
	{
		//IL_0092: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00a9: Expected I, but got O
		//IL_006b: Expected I, but got O
		//IL_00f3: Expected I, but got O
		//IL_0104: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_011b: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_0205: Expected O, but got I4
		//IL_0213: Expected I, but got O
		//IL_0260: Expected O, but got I4
		//IL_0269: Expected O, but got I4
		//IL_0277: Expected I, but got O
		Enemy enemy = this.enemy;
		Delegate obj6;
		Delegate obj4;
		if ((object)this.enemy != null)
		{
			Action<EDebuff> b = OnDebuffAdded;
			Delegate obj = Delegate.Combine(enemy.A_DebuffAdded, b);
			nint num;
			object obj2;
			object obj3;
			if ((object)obj == null)
			{
				enemy.A_DebuffAdded = (Action<EDebuff>)obj;
				num = (nint)enemy.A_DebuffAdded;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<EDebuff> action = default(Action<EDebuff>);
				bool flag = action == null;
				obj2 = 0;
				obj3 = 0;
				nint num2 = (nint)typeof(Action<EDebuff>);
				obj4 = obj;
				if (flag)
				{
					goto IL_02bb;
				}
				enemy.A_DebuffAdded = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				num = (nint)typeof(Action<EDebuff>);
				obj6 = obj;
				obj2 = 0;
				obj3 = 0;
				num2 = (nint)typeof(Action<EDebuff>);
				if (flag2)
				{
					goto IL_02c6;
				}
			}
			Enemy enemy2 = this.enemy;
			bool flag3 = (object)this.enemy == null;
			obj6 = obj;
			obj2 = 0;
			obj3 = 0;
			nint num3 = num;
			if (!flag3)
			{
				Action<EDebuff> b2 = OnDebuffRemoved;
				Delegate obj7 = Delegate.Combine(enemy2.A_DebuffRemoved, b2);
				if ((object)obj7 == null)
				{
					enemy2.A_DebuffRemoved = (Action<EDebuff>)obj7;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<EDebuff> action2 = default(Action<EDebuff>);
				bool flag4 = action2 == null;
				obj6 = obj7;
				obj2 = 0;
				obj3 = 0;
				num3 = (nint)typeof(Action<EDebuff>);
				Delegate obj8 = obj7;
				if (!flag4)
				{
					enemy2.A_DebuffRemoved = action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj9 = default(object);
					bool flag5 = obj9 == null;
					obj6 = obj7;
					obj2 = 0;
					obj3 = 0;
					num3 = (nint)typeof(Action<EDebuff>);
					if (!flag5)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					obj8 = obj6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				nint num2 = num3;
				goto IL_02c6;
			}
		}
		throw new NullReferenceException();
		IL_02c6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_02bb;
		IL_02bb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_0092: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00a9: Expected I, but got O
		//IL_006b: Expected I, but got O
		//IL_00f3: Expected I, but got O
		//IL_0104: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_011b: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_0205: Expected O, but got I4
		//IL_0213: Expected I, but got O
		//IL_0260: Expected O, but got I4
		//IL_0269: Expected O, but got I4
		//IL_0277: Expected I, but got O
		Enemy enemy = this.enemy;
		Delegate obj6;
		Delegate obj4;
		if ((object)this.enemy != null)
		{
			Action<EDebuff> value = OnDebuffAdded;
			Delegate obj = Delegate.Remove(enemy.A_DebuffAdded, value);
			nint num;
			object obj2;
			object obj3;
			if ((object)obj == null)
			{
				enemy.A_DebuffAdded = (Action<EDebuff>)obj;
				num = (nint)enemy.A_DebuffAdded;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<EDebuff> action = default(Action<EDebuff>);
				bool flag = action == null;
				obj2 = 0;
				obj3 = 0;
				nint num2 = (nint)typeof(Action<EDebuff>);
				obj4 = obj;
				if (flag)
				{
					goto IL_02bb;
				}
				enemy.A_DebuffAdded = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				num = (nint)typeof(Action<EDebuff>);
				obj6 = obj;
				obj2 = 0;
				obj3 = 0;
				num2 = (nint)typeof(Action<EDebuff>);
				if (flag2)
				{
					goto IL_02c6;
				}
			}
			Enemy enemy2 = this.enemy;
			bool flag3 = (object)this.enemy == null;
			obj6 = obj;
			obj2 = 0;
			obj3 = 0;
			nint num3 = num;
			if (!flag3)
			{
				Action<EDebuff> value2 = OnDebuffRemoved;
				Delegate obj7 = Delegate.Remove(enemy2.A_DebuffRemoved, value2);
				if ((object)obj7 == null)
				{
					enemy2.A_DebuffRemoved = (Action<EDebuff>)obj7;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<EDebuff> action2 = default(Action<EDebuff>);
				bool flag4 = action2 == null;
				obj6 = obj7;
				obj2 = 0;
				obj3 = 0;
				num3 = (nint)typeof(Action<EDebuff>);
				Delegate obj8 = obj7;
				if (!flag4)
				{
					enemy2.A_DebuffRemoved = action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj9 = default(object);
					bool flag5 = obj9 == null;
					obj6 = obj7;
					obj2 = 0;
					obj3 = 0;
					num3 = (nint)typeof(Action<EDebuff>);
					if (!flag5)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					obj8 = obj6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				nint num2 = num3;
				goto IL_02c6;
			}
		}
		throw new NullReferenceException();
		IL_02c6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_02bb;
		IL_02bb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void Reset()
	{
	}

	public void Set(EnemyData enemyData)
	{
		if (propertyBlock == null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			propertyBlock = materialPropertyBlock;
		}
		enemyRenderer.SetMaterial(enemyData.material);
		enemyRenderer.Internal_GetPropertyBlockMaterialIndex(propertyBlock, 0);
		propertyBlock.Clear();
		enemyRenderer.Internal_SetPropertyBlockMaterialIndex(propertyBlock, 0);
	}

	private void OnDebuffAdded(EDebuff debuff)
	{
		RefreshColor(debuff);
	}

	private unsafe void GetDebuffColor(out Color specular, out Color albedo)
	{
		ref Color reference = ref *(Color*)null;
		_ = 0;
		_ = 1065353216;
		ref Color reference2 = ref *(Color*)1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		Enemy enemy = this.enemy;
		int count = enemy.debuffs.Count;
		if (count <= 0)
		{
			return;
		}
		Enemy enemy2 = this.enemy;
		if (((Dictionary<System.Int32Enum, object>)(object)enemy2.debuffs).ContainsKey((System.Int32Enum)16))
		{
			reference = ref *(Color*)echoColorSpecular;
			reference2 = ref *(Color*)echoColorAlbedo;
		}
		Enemy enemy3 = this.enemy;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		Dictionary<EDebuff, EnemyDebuff>.Enumerator enumerator = default(Dictionary<EDebuff, EnemyDebuff>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = default(object);
			if ((nint)obj == 2)
			{
				reference = ref *(Color*)freezeColorSpecular;
				reference2 = ref *(Color*)freezeColorAlbedo;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				return;
			}
			if ((nint)obj != 8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				return;
			}
			reference = ref *(Color*)stunColorSpecular;
			reference2 = ref *(Color*)stunColorAlbedo;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}

	private void OnDebuffRemoved(EDebuff debuff)
	{
		RefreshColor(debuff);
	}

	public unsafe void SetInvulnerable(bool invulnerable)
	{
		//IL_003f: Expected O, but got Ref
		enemyRenderer.Internal_GetPropertyBlockMaterialIndex(propertyBlock, 0);
		if (invulnerable)
		{
		}
		object obj = default(object);
		propertyBlock.SetColor(rimColorKey, (Color)(&obj));
		enemyRenderer.Internal_SetPropertyBlockMaterialIndex(propertyBlock, 0);
	}

	private unsafe void RefreshColor(EDebuff debuff)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_00b5: Invalid comparison between F4 and O
		//IL_00d4: Expected O, but got I4
		//IL_0109: Expected O, but got Ref
		//IL_0123: Expected O, but got Ref
		GetDebuffColor(out var specular, out var albedo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemyRenderer)+BC]");
		object obj2 = default(object);
		object obj = 0 - obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemyRenderer)+C0]");
		object obj4 = default(object);
		object obj3 = 0 - obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EnemyRenderer)+C4]");
		object obj6 = default(object);
		object obj5 = 0 - obj6;
		object obj7 = obj * obj;
		object obj8 = obj3 * obj3;
		object obj9 = lastSetSpecularColor * lastSetSpecularColor;
		object obj10 = obj5 * obj5;
		object obj11 = obj7 + obj9;
		object obj12 = obj11 + obj8;
		object obj13 = obj12 + obj10;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
		{
			lastSetSpecularColor = (Color)0;
			enemyRenderer.Internal_GetPropertyBlockMaterialIndex(propertyBlock, 0);
			propertyBlock.SetColor(specularColorKey, (Color)(&specular));
			propertyBlock.SetColor(albedoColorKey, (Color)(&albedo));
			enemyRenderer.Internal_SetPropertyBlockMaterialIndex(propertyBlock, 0);
		}
	}

	public EnemyRenderer()
	{
		//IL_0022: Expected O, but got F4
		//IL_0044: Expected O, but got F4
		//IL_0061: Expected O, but got F4
		//IL_0083: Expected O, but got F4
		//IL_00a0: Expected O, but got F4
		//IL_00c2: Expected O, but got F4
		//IL_00df: Expected O, but got F4
		//IL_0101: Expected O, but got F4
		freezeColorSpecular = (Color)MyColorUtility.StringToColor("#009A9A").r;
		freezeColorAlbedo = (Color)MyColorUtility.StringToColor("#A8FEFF").r;
		stunColorSpecular = (Color)MyColorUtility.StringToColor("#918200").r;
		stunColorAlbedo = (Color)MyColorUtility.StringToColor("#FFFF88").r;
		echoColorSpecular = (Color)MyColorUtility.StringToColor("#00D182").r;
		echoColorAlbedo = (Color)MyColorUtility.StringToColor("#94FFCD").r;
		charmColorAlbedo = (Color)MyColorUtility.StringToColor("#FFD5E9").r;
		charmColorSpecular = (Color)MyColorUtility.StringToColor("#C11B85").r;
		specularColorKey = "_SpecularColor";
		albedoColorKey = "_AlbedoColor";
		rimColorKey = "_RimColor";
		base._002Ector();
	}
}
