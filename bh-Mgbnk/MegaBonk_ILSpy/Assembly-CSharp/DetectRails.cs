using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using Cpp2ILInjected;
using UnityEngine;

public class DetectRails : MonoBehaviour
{
	public LayerMask whatIsRails;

	private PlayerMovement playerMovement;

	private Collider[] buffer;

	private string railTag;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		PlayerMovement component = GetComponent<PlayerMovement>();
		playerMovement = component;
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDamage(PlayerHealth arg1, DamageContainer arg2, bool arg3)
	{
		playerMovement.StopRail();
	}

	private unsafe void FixedUpdate()
	{
		//IL_0150: Expected O, but got Ref
		//IL_017d: Expected O, but got I4
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		if (!(this.playerMovement != null))
		{
			return;
		}
		PlayerMovement playerMovement = this.playerMovement;
		if (!(playerMovement.rb != null))
		{
			return;
		}
		PlayerMovement playerMovement2 = this.playerMovement;
		if (!(playerMovement2.rail == null))
		{
			return;
		}
		PlayerMovement playerMovement3 = this.playerMovement;
		if (!(playerMovement3.rail == null))
		{
			return;
		}
		PlayerMovement playerMovement4 = this.playerMovement;
		Vector3 position = playerMovement4.rb.position;
		GameObject gameObject = playerMovement4.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			Transform transform = playerMovement4.transform;
			Vector3 position2 = transform.position;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v19 (PlayerMovement)+12C]");
		bool flag = (nint)0 == 0;
		float radius = playerMovement4._003CplayerRadius_003Ek__BackingField * 1.75f;
		if (!flag)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		object obj = default(object);
		int layerMask = default(int);
		int num = Physics.OverlapSphereNonAlloc((Vector3)(&obj), radius, buffer, layerMask);
		if (num <= 0)
		{
			return;
		}
		object obj2 = 0;
		Rail component;
		while (true)
		{
			Collider[] array = buffer;
			if (array[obj2].CompareTag(railTag))
			{
				component = array[obj2].GetComponent<Rail>();
				if (component != null && !component.IsOnCooldown())
				{
					break;
				}
			}
			obj2++;
			if ((nint)obj2 >= num)
			{
				return;
			}
		}
		this.playerMovement.StartRail(component);
	}

	public DetectRails()
	{
		Collider[] array = new Collider[10];
		buffer = array;
		railTag = "Rail";
		base._002Ector();
	}
}
