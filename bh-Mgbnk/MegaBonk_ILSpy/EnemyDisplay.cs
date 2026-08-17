using System;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Cpp2ILInjected;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
	public AnimatedMesh animatedMesh;

	public MeshRenderer meshRenderer;

	public Camera camera;

	public LayerMask layerMask;

	private float cameraDistance = 1f;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EEnemy> b = SetEnemy;
		Delegate obj = Delegate.Combine(MyButtonLog.A_EnemySelected, b);
		if ((object)obj == null)
		{
			MyButtonLog.A_EnemySelected = (Action<EEnemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EEnemy> action = default(Action<EEnemy>);
		if (action != null)
		{
			MyButtonLog.A_EnemySelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EEnemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EEnemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EEnemy> value = SetEnemy;
		Delegate obj = Delegate.Remove(MyButtonLog.A_EnemySelected, value);
		if ((object)obj == null)
		{
			MyButtonLog.A_EnemySelected = (Action<EEnemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EEnemy> action = default(Action<EEnemy>);
		if (action != null)
		{
			MyButtonLog.A_EnemySelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EEnemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EEnemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void SetEnemy(EEnemy eEnemy)
	{
		EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy);
		if (enemyData != null)
		{
			GameObject gameObject = animatedMesh.gameObject;
			gameObject.SetActive(value: true);
			animatedMesh.SetAnimation(enemyData.animation);
			((Renderer)meshRenderer).SetMaterial(enemyData.material);
		}
		else
		{
			GameObject gameObject2 = animatedMesh.gameObject;
			gameObject2.SetActive(value: false);
		}
		EncapsulateEnemyRenderer();
		GameObject gameObject3 = animatedMesh.gameObject;
		int layer = LayerMask.NameToLayer("UiCamera");
		gameObject3.layer = layer;
	}

	private unsafe void EncapsulateEnemyRenderer()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_00c8: Expected F4, but got O
		//IL_00da: Expected F4, but got O
		//IL_00ec: Expected F4, but got O
		//IL_0187: Expected O, but got I4
		//IL_0136: Expected O, but got I4
		//IL_014c: Invalid comparison between F4 and O
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_020d: Expected O, but got Ref
		//IL_0174: Expected O, but got F4
		Bounds bounds = meshRenderer.bounds;
		object obj2 = default(object);
		object obj = (object)bounds.m_Center - obj2;
		object obj3 = obj2 + (object)bounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v6 (UnityEngine.Bounds)+10]");
		object obj4 = 0 + obj2;
		object obj6 = default(object);
		object obj5 = obj6 + obj2;
		object obj7 = obj3 - obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v6 (UnityEngine.Bounds)+10]");
		object obj8 = obj2 - 0;
		object obj9 = obj4 - obj8;
		object obj10 = obj2 - obj6;
		object obj11 = obj5 - obj10;
		float[] array = new float[3]
		{
			(float)obj7,
			(float)obj9,
			(float)obj11
		};
		if (array.Length != 0)
		{
			if (array.Length > 1)
			{
				object obj12 = 1;
				do
				{
					float num = array[obj12];
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
					{
						obj7 = array[obj12];
					}
					obj12++;
				}
				while ((nint)obj12 < array.Length);
			}
		}
		else
		{
			obj7 = 0;
		}
		float fieldOfView = camera.fieldOfView;
		float num2 = fieldOfView * ((float)Math.PI / 360f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300560");
		Transform transform = camera.transform;
		Transform transform2 = camera.transform;
		Vector3 forward = transform2.forward;
		float num3 = default(float);
		transform.position = (Vector3)(&num3);
	}
}
